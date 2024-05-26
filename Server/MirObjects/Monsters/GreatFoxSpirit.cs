﻿using Server.Library.MirDatabase;
using Server.Library.MirEnvir;
using Shared;
using Shared.Data;
using Shared.Functions;

namespace Server.Library.MirObjects.Monsters {
    public class GreatFoxSpirit : MonsterObject {
        private byte _stage;
        private long RecallTime;
        private byte AttackRange = 7;

        protected override bool CanMove => false;

        protected internal GreatFoxSpirit(MonsterInfo info)
            : base(info) { }

        protected override bool InAttackRange() {
            return CurrentMap == Target.CurrentMap &&
                   Functions.InRange(CurrentLocation, Target.CurrentLocation, AttackRange);
        }

        protected override void ProcessAI() {
            if(Dead) {
                return;
            }

            if(Stats[Stat.HP] >= 4) {
                byte stage = (byte)(4 - (HP / (Stats[Stat.HP] / 4)));

                if(stage > _stage) {
                    _stage = stage;
                    Broadcast(GetInfo());
                }
            }

            base.ProcessAI();
        }


        public override void Turn(MirDirection dir) { }

        public override bool Walk(MirDirection dir) {
            return false;
        }

        protected override void ProcessRoam() { }

        protected override void ProcessTarget() {
            if(Target == null) {
                return;
            }

            //remark: does this mean nobody gets teleported if the main target is standing closeby + does it mean it always try's to teleport the person with lowest x/y coords?)
            if(Functions.MaxDistance(CurrentLocation, Target.CurrentLocation) > 3 && Envir.Random.Next(10) == 0 &&
               Envir.Time >= RecallTime) {
                RecallTime = Envir.Time + 10000;
                List<MapObject> targets = FindAllTargets(30, CurrentLocation);
                if(targets.Count != 0 && Envir.Random.Next(4) > 0) {
                    for (int i = 0; i < targets.Count; i++) {
                        if(Functions.MaxDistance(CurrentLocation, targets[i].CurrentLocation) > 3) {
                            if(Envir.Random.Next(Settings.MagicResistWeight) < targets[i].Stats[Stat.MagicResist]) {
                                continue;
                            }

                            if(!targets[i].Teleport(CurrentMap,
                                   Functions.PointMove(CurrentLocation, (MirDirection)(byte)Envir.Random.Next(7), 1))) {
                                targets[i].Teleport(CurrentMap, CurrentLocation);
                            }

                            return;
                        }
                    }
                }
            }

            if(InAttackRange() && CanAttack) {
                Attack();

                if(Target.Dead) {
                    FindTarget();
                }

                return;
            }

            if(Envir.Time < ShockTime) {
                Target = null;
                return;
            }
        }

        protected override void Attack() {
            if(!Target.IsAttackTarget(this)) {
                Target = null;
                return;
            }

            int damage = GetAttackPower(Stats[Stat.MinDC], Stats[Stat.MaxDC]);
            if(damage == 0) {
                return;
            }

            ShockTime = 0;
            ActionTime = Envir.Time + 300;
            AttackTime = Envir.Time + AttackSpeed;

            bool ranged = CurrentLocation == Target.CurrentLocation ||
                          Functions.MaxDistance(CurrentLocation, Target.CurrentLocation) > 2;

            List<MapObject> targets = FindAllTargets(ranged ? AttackRange : 2, CurrentLocation);
            if(targets.Count == 0) {
                return;
            }

            if(ranged) {
                Broadcast(new ServerPacket.ObjectRangeAttack
                    { ObjectID = ObjectID, Direction = Direction, Location = CurrentLocation });
            } else {
                Broadcast(new ServerPacket.ObjectAttack
                    { ObjectID = ObjectID, Direction = Direction, Location = CurrentLocation });
            }

            for (int i = 0; i < targets.Count; i++) {
                Target = targets[i];
                if(ranged) {
                    Broadcast(new ServerPacket.ObjectEffect
                        { ObjectID = Target.ObjectID, Effect = SpellEffect.GreatFoxSpirit });
                }

                DelayedAction action = new(DelayedType.Damage, Envir.Time + 300, Target, damage, DefenceType.MAC);
                ActionList.Add(action);
            }
        }

        protected override void CompleteAttack(IList<object> data) {
            MapObject target = (MapObject)data[0];
            int damage = (int)data[1];
            DefenceType defence = (DefenceType)data[2];

            if(target == null || !target.IsAttackTarget(this) || target.CurrentMap != CurrentMap ||
               target.Node == null) {
                return;
            }

            if(target.Attacked(this, damage, defence) <= 0) {
                return;
            }

            PoisonTarget(target, 5, 15, PoisonType.Slow, 1000);
            PoisonTarget(target, 5, 5, PoisonType.Paralysis, 1000);
        }

        public override void Die() {
            if(Dead) {
                return;
            }

            ChangeGuardianState(false);
            base.Die();
        }

        public override void Spawned() {
            base.Spawned();
            ChangeGuardianState(true);
        }

        private void ChangeGuardianState(bool Active) {
            int ExpectedDistance = 20;
            for (int y = CurrentLocation.Y - ExpectedDistance; y <= CurrentLocation.Y + ExpectedDistance; y++) {
                if(y < 0) {
                    continue;
                }

                if(y >= CurrentMap.Height) {
                    break;
                }

                for (int x = CurrentLocation.X - ExpectedDistance; x <= CurrentLocation.X + ExpectedDistance; x++) {
                    if(x < 0) {
                        continue;
                    }

                    if(x >= CurrentMap.Width) {
                        break;
                    }

                    Cell cell = CurrentMap.GetCell(x, y);

                    if(!cell.Valid || cell.Objects == null) {
                        continue;
                    }

                    for (int i = 0; i < cell.Objects.Count; i++) {
                        GuardianRock target = cell.Objects[i] as GuardianRock;
                        if(target == null) {
                            continue;
                        }

                        target.Active = Active;
                    }
                }
            }
        }

        public override Packet GetInfo() {
            return new ServerPacket.ObjectMonster {
                ObjectID = ObjectID,
                Name = Name,
                NameColour = NameColour,
                Location = CurrentLocation,
                Image = Info.Image,
                Direction = Direction,
                Effect = Info.Effect,
                AI = Info.AI,
                Light = Info.Light,
                Dead = Dead,
                Skeleton = Harvested,
                Poison = CurrentPoison,
                Hidden = Hidden,
                ExtraByte = _stage,
                Buffs = Buffs.Where(d => d.Info.Visible).Select(e => e.Type).ToList()
            };
        }
    }
}
