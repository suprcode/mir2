﻿using Server.Library.MirDatabase;
using Shared;
using Shared.Data;
using Shared.Functions;

namespace Server.Library.MirObjects.Monsters {
    public class BlueSoul : AxeSkeleton {
        protected internal BlueSoul(MonsterInfo info)
            : base(info) { }

        protected override void Attack() {
            if(!Target.IsAttackTarget(this)) {
                Target = null;
                return;
            }

            ShockTime = 0;

            Direction = Functions.DirectionFromPoint(CurrentLocation, Target.CurrentLocation);

            Broadcast(new ServerPacket.ObjectRangeAttack {
                ObjectID = ObjectID, Direction = Direction, Location = CurrentLocation, TargetID = Target.ObjectID,
                Type = 0
            });

            ActionTime = Envir.Time + 300;
            AttackTime = Envir.Time + AttackSpeed;

            int damage = GetAttackPower(Stats[Stat.MinDC], Stats[Stat.MaxDC]);
            if(damage == 0) {
                return;
            }

            DelayedAction action = new(DelayedType.RangeDamage, Envir.Time + 500, Target, damage,
                DefenceType.MACAgility);
            ActionList.Add(action);
        }
    }
}
