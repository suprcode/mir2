﻿using Server.Library.MirDatabase;
using Shared;
using Shared.Data;

namespace Server.Library.MirObjects.Monsters {
    public class CannibalPlant : HarvestMonster {
        public bool Visible;
        public long VisibleTime;

        protected override bool CanAttack => Visible && base.CanAttack;
        protected override bool CanMove => false;

        public override bool Blocking => Visible && base.Blocking;

        protected internal CannibalPlant(MonsterInfo info)
            : base(info) {
            Visible = false;
        }

        protected override void ProcessAI() {
            if(!Dead && Envir.Time > VisibleTime) {
                VisibleTime = Envir.Time + 2000;

                bool visible = FindNearby(3);

                if(!Visible && visible) {
                    Visible = true;
                    CellTime = Envir.Time + 500;
                    Broadcast(GetInfo());
                    Broadcast(new ServerPacket.ObjectShow { ObjectID = ObjectID });
                    ActionTime = Envir.Time + 1000;
                }

                if(Visible && !visible) {
                    Visible = false;
                    VisibleTime = Envir.Time + 3000;

                    Broadcast(new ServerPacket.ObjectHide { ObjectID = ObjectID });

                    SetHP(Stats[Stat.HP]);
                }
            }

            base.ProcessAI();
        }


        public override void Turn(MirDirection dir) { }

        public override bool Walk(MirDirection dir) {
            return false;
        }

        public override bool IsAttackTarget(MonsterObject attacker) {
            return Visible && base.IsAttackTarget(attacker);
        }

        public override bool IsAttackTarget(HumanObject attacker) {
            return Visible && base.IsAttackTarget(attacker);
        }

        protected override void ProcessRoam() { }

        protected override void ProcessSearch() {
            if(Visible) {
                base.ProcessSearch();
            }
        }

        public override Packet GetInfo() {
            if(!Visible) {
                return null;
            }

            return base.GetInfo();
        }
    }
}
