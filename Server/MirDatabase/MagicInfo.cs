﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Server.MirEnvir;
using S = ServerPackets;

namespace Server.MirDatabase
{
    public class MagicInfo
    {
        public static List<MagicInfo> Magics = new List<MagicInfo>();

        //Warrior
        public static MagicInfo Fencing,
                                Slaying,
                                Thrusting,
                                HalfMoon,
                                ShoulderDash,
                                TwinDrakeBlade,
                                Entrapment,
                                FlamingSword,
                                LionRoar,
                                CrossHalfMoon,
                                BladeAvalanche,
                                ProtectionField,
                                Rage,
                                CounterAttack,
                                SlashingBurst,
                                Fury;

        //Wizard
        public static MagicInfo FireBall,
                                Repulsion,
                                ElectricShock,
                                GreatFireBall,
                                HellFire,
                                ThunderBolt,
                                Teleport,
                                FireBang,
                                FireWall,
                                Lightning,
                                FrostCrunch,
                                ThunderStorm,
                                MagicShield,
                                TurnUndead,
                                Vampirism,
                                IceStorm,
                                FlameDisruptor,
                                Mirroring,
                                FlameField,
                                Blizzard,
                                MagicBooster,
                                MeteorStrike,
                                IceThrust,
                                Blink;

        //Taoist
        public static MagicInfo Healing,
                                SpiriSword,
                                Poisoning,
                                SoulFireBall,
                                SummonSkeleton,
                                Hiding,
                                MassHiding,
                                SoulShield,
                                Revelation,
                                BlessedArmour,
                                EnergyRepulsor,
                                TrapHexagon,
                                Purification,
                                MassHealing,
                                Hallucination,
                                UltimateEnchancer,
                                SummonShinsu,
                                Reincarnation,
                                SummonHolyDeva,
                                Curse,
                                Plague,
                                PoisonCloud,
                                EnergyShield;

        //Assassin
        public static MagicInfo FatalSword,
                                DoubleSlash,
                                Haste,
                                FlashDash,
                                LightBody,
                                HeavenlySword,
                                FireBurst,
                                Trap,
                                PoisonSword,
                                MoonLight,
                                MPEater,
                                SwiftFeet,
                                DarkBody,
                                Hemorrhage,
                                CresentSlash;

        //Archer
        public static MagicInfo Focus,
                                StraightShot,
                                DoubleShot,
                                ExplosiveTrap,
                                DelayedExplosion,
                                Meditation,
                                BackStep,
                                ElementalShot,
                                Concentration,
                                BindingShot,
                                //Stonetrap,
                                ElementalBarrier,
                                SummonVampire,
                                VampireShot,
                                SummonToad,
                                PoisonShot,
                                CrippleShot,
                                SummonSnakes,
                                NapalmShot,
                                OneWithNature,
                                MentalState;


        public Spell Spell;
        public byte BaseCost, LevelCost, Icon;
        public byte Level1, Level2, Level3, Level4;
        public ushort Need1, Need2, Need3, Need4;
        
        public bool HumUpTrain = false;

        static MagicInfo()
        {            
            //Warrior
            Fencing = new MagicInfo { Spell = Spell.Fencing, Icon = 2, Level1 = 7, Level2 = 9, Level3 = 12, Need1 = 270, Need2 = 600, Need3 = 1300 };
            Slaying = new MagicInfo { Spell = Spell.Slaying, Icon = 6, Level1 = 15, Level2 = 17, Level3 = 20, Need1 = 500, Need2 = 1100, Need3 = 1800 };
            Thrusting = new MagicInfo { Spell = Spell.Thrusting, Icon = 11, Level1 = 22, Level2 = 24, Level3 = 27, Need1 = 2000, Need2 = 3500, Need3 = 6000 };
            HalfMoon = new MagicInfo { Spell = Spell.HalfMoon, Icon = 24, Level1 = 26, Level2 = 28, Level3 = 31, Need1 = 5000, Need2 = 8000, Need3 = 14000, BaseCost = 3 };
            ShoulderDash = new MagicInfo { Spell = Spell.ShoulderDash, Icon = 26, Level1 = 30, Level2 = 32, Level3 = 34, Need1 = 3000, Need2 = 4000, Need3 = 6000, BaseCost = 4, LevelCost = 4 };
            TwinDrakeBlade = new MagicInfo { Spell = Spell.TwinDrakeBlade, Icon = 37, Level1 = 32, Level2 = 34, Level3 = 37, Need1 = 4000, Need2 = 6000, Need3 = 10000, BaseCost = 10 };
            Entrapment = new MagicInfo { Spell = Spell.Entrapment, Icon = 46, Level1 = 32, Level2 = 35, Level3 = 37, Need1 = 2000, Need2 = 3500, Need3 = 5500, BaseCost = 15, LevelCost = 3 };
            FlamingSword = new MagicInfo { Spell = Spell.FlamingSword, Icon = 25, Level1 = 35, Level2 = 37, Level3 = 40, Need1 = 2000, Need2 = 4000, Need3 = 6000, BaseCost = 7 };
            LionRoar = new MagicInfo { Spell = Spell.LionRoar, Icon = 42, Level1 = 36, Level2 = 39, Level3 = 41, Level4 = 62, Need1 = 5000, Need2 = 8000, Need3 = 12000, Need4 = 15000, BaseCost = 14, LevelCost = 4, HumUpTrain = true };
            CrossHalfMoon = new MagicInfo { Spell = Spell.CrossHalfMoon, Icon = 33, Level1 = 38, Level2 = 40, Level3 = 42, Level4 = 62, Need1 = 7000, Need2 = 11000, Need3 = 16000, Need4 = 24000, BaseCost = 6, HumUpTrain = true };
            BladeAvalanche = new MagicInfo { Spell = Spell.BladeAvalanche, Icon = 43, Level1 = 38, Level2 = 41, Level3 = 43, Level4 = 62, Need1 = 5000, Need2 = 8000, Need3 = 12000, Need4 = 15000, BaseCost = 14, LevelCost = 4, HumUpTrain = true };
            ProtectionField = new MagicInfo { Spell = Spell.ProtectionField, Icon = 50, Level1 = 39, Level2 = 42, Level3 = 45, Level4 = 62, Need1 = 6000, Need2 = 12000, Need3 = 18000, Need4 = 24000, BaseCost = 23, LevelCost = 6, HumUpTrain = true };
            Rage = new MagicInfo { Spell = Spell.Rage, Icon = 49, Level1 = 44, Level2 = 47, Level3 = 50, Need1 = 8000, Need2 = 14000, Need3 = 20000, BaseCost = 20, LevelCost = 5 };
            CounterAttack = new MagicInfo { Spell = Spell.CounterAttack, Icon = 72, Level1 = 47, Level2 = 51, Level3 = 55, Level4 = 62, Need1 = 7000, Need2 = 11000, Need3 = 15000, Need4 = 18000, BaseCost = 12, LevelCost = 4, HumUpTrain = true };
            SlashingBurst = new MagicInfo { Spell = Spell.SlashingBurst, Icon = 55, Level1 = 50, Level2 = 53, Level3 = 56, Need1 = 10000, Need2 = 16000, Need3 = 24000, BaseCost = 25, LevelCost = 4 };
            Fury = new MagicInfo { Spell = Spell.Fury, Icon = 76, Level1 = 45, Level2 = 48, Level3 = 51, Level4 = 62, Need1 = 8000, Need2 = 14000, Need3 = 20000, Need4 = 24000, BaseCost = 10, LevelCost = 4, HumUpTrain = true };

            //Wizard
            FireBall = new MagicInfo { Spell = Spell.FireBall, Icon = 0, Level1 = 7, Level2 = 9, Level3 = 11, Level4 = 62, Need1 = 200, Need2 = 350, Need3 = 700, Need4 = 10000, BaseCost = 3, LevelCost = 2, HumUpTrain = false };
            Repulsion = new MagicInfo { Spell = Spell.Repulsion, Icon = 7, Level1 = 12, Level2 = 15, Level3 = 19, Level4 = 62, Need1 = 500, Need2 = 1300, Need3 = 2200, Need4 = 10000, BaseCost = 2, LevelCost = 2, HumUpTrain = false };
            ElectricShock = new MagicInfo { Spell = Spell.ElectricShock, Icon = 19, Level1 = 13, Level2 = 18, Level3 = 24, Level4 = 62, Need1 = 530, Need2 = 1100, Need3 = 2200, Need4 = 10000, BaseCost = 3, LevelCost = 1, HumUpTrain = false };
            GreatFireBall = new MagicInfo { Spell = Spell.GreatFireBall, Icon = 4, Level1 = 15, Level2 = 18, Level3 = 21, Level4 = 62, Need1 = 2000, Need2 = 2700, Need3 = 3500, Need4 = 10000, BaseCost = 5, LevelCost = 1, HumUpTrain = false };
            HellFire = new MagicInfo { Spell = Spell.HellFire, Icon = 8, Level1 = 16, Level2 = 20, Level3 = 24, Level4 = 62, Need1 = 700, Need2 = 2700, Need3 = 3500, Need4 = 10000, BaseCost = 10, LevelCost = 3, HumUpTrain = false };
            ThunderBolt = new MagicInfo { Spell = Spell.ThunderBolt, Icon = 10, Level1 = 17, Level2 = 20, Level3 = 23, Level4 = 62, Need1 = 500, Need2 = 2000, Need3 = 3500, Need4 = 10000, BaseCost = 9, LevelCost = 2, HumUpTrain = true };
            Teleport = new MagicInfo { Spell = Spell.Teleport, Icon = 20, Level1 = 19, Level2 = 22, Level3 = 25, Level4 = 62, Need1 = 350, Need2 = 1000, Need3 = 2000, Need4 = 10000, BaseCost = 10, LevelCost = 3, HumUpTrain = false };
            FireBang = new MagicInfo { Spell = Spell.FireBang, Icon = 22, Level1 = 22, Level2 = 25, Level3 = 28, Level4 = 62, Need1 = 3000, Need2 = 5000, Need3 = 10000, Need4 = 10000, BaseCost = 14, LevelCost = 4, HumUpTrain = true };
            FireWall = new MagicInfo { Spell = Spell.FireWall, Icon = 21, Level1 = 24, Level2 = 28, Level3 = 33, Level4 = 62, Need1 = 4000, Need2 = 10000, Need3 = 20000, Need4 = 10000, BaseCost = 30, LevelCost = 5, HumUpTrain = true };
            Lightning = new MagicInfo { Spell = Spell.Lightning, Icon = 9, Level1 = 26, Level2 = 29, Level3 = 32, Level4 = 62, Need1 = 3000, Need2 = 6000, Need3 = 12000, Need4 = 10000, BaseCost = 38, LevelCost = 7, HumUpTrain = false };
            FrostCrunch = new MagicInfo { Spell = Spell.FrostCrunch, Icon = 38, Level1 = 28, Level2 = 30, Level3 = 33, Level4 = 62, Need1 = 3000, Need2 = 5000, Need3 = 8000, Need4 = 10000, BaseCost = 15, LevelCost = 3, HumUpTrain = false };
            ThunderStorm = new MagicInfo { Spell = Spell.ThunderStorm, Icon = 23, Level1 = 30, Level2 = 32, Level3 = 34, Level4 = 62, Need1 = 4000, Need2 = 8000, Need3 = 12000, Need4 = 10000, BaseCost = 29, LevelCost = 9, HumUpTrain = true };
            MagicShield = new MagicInfo { Spell = Spell.MagicShield, Icon = 30, Level1 = 31, Level2 = 34, Level3 = 38, Level4 = 62, Need1 = 3000, Need2 = 7000, Need3 = 10000, Need4 = 10000, BaseCost = 35, LevelCost = 5, HumUpTrain = true };
            TurnUndead = new MagicInfo { Spell = Spell.TurnUndead, Icon = 31, Level1 = 32, Level2 = 35, Level3 = 39, Level4 = 62, Need1 = 3000, Need2 = 7000, Need3 = 10000, Need4 = 10000, BaseCost = 52, LevelCost = 13, HumUpTrain = true };
            Vampirism = new MagicInfo { Spell = Spell.Vampirism, Icon = 47, Level1 = 33, Level2 = 36, Level3 = 40, Level4 = 62, Need1 = 3000, Need2 = 5000, Need3 = 8000, Need4 = 10000, BaseCost = 26, LevelCost = 13, HumUpTrain = true };
            IceStorm = new MagicInfo { Spell = Spell.IceStorm, Icon = 32, Level1 = 35, Level2 = 37, Level3 = 40, Level4 = 62, Need1 = 4000, Need2 = 8000, Need3 = 12000, Need4 = 10000, BaseCost = 33, LevelCost = 3, HumUpTrain = true };
            FlameDisruptor = new MagicInfo { Spell = Spell.FlameDisruptor, Icon = 34, Level1 = 38, Level2 = 40, Level3 = 42, Level4 = 62, Need1 = 5000, Need2 = 9000, Need3 = 14000, Need4 = 10000, BaseCost = 28, LevelCost = 3, HumUpTrain = true };
            Mirroring = new MagicInfo { Spell = Spell.Mirroring, Icon = 41, Level1 = 41, Level2 = 43, Level3 = 45, Level4 = 62, Need1 = 6000, Need2 = 11000, Need3 = 16000, Need4 = 10000, BaseCost = 21, HumUpTrain = false };
            FlameField = new MagicInfo { Spell = Spell.FlameField, Icon = 44, Level1 = 42, Level2 = 43, Level3 = 45, Level4 = 62, Need1 = 6000, Need2 = 11000, Need3 = 16000, Need4 = 10000, BaseCost = 45, LevelCost = 8, HumUpTrain = false };
            Blizzard = new MagicInfo { Spell = Spell.Blizzard, Icon = 51, Level1 = 44, Level2 = 47, Level3 = 50, Level4 = 62, Need1 = 8000, Need2 = 16000, Need3 = 24000, Need4 = 10000, BaseCost = 65, LevelCost = 10, HumUpTrain = false };
            MagicBooster = new MagicInfo { Spell = Spell.MagicBooster, Icon = 73, Level1 = 47, Level2 = 49, Level3 = 52, Level4 = 62, Need1 = 12000, Need2 = 18000, Need3 = 24000, Need4 = 10000, BaseCost = 150, LevelCost = 15, HumUpTrain = true };
            MeteorStrike = new MagicInfo { Spell = Spell.MeteorStrike, Icon = 52, Level1 = 49, Level2 = 52, Level3 = 55, Level4 = 62, Need1 = 15000, Need2 = 20000, Need3 = 25000, Need4 = 10000, BaseCost = 115, LevelCost = 17, HumUpTrain = true };
            IceThrust = new MagicInfo { Spell = Spell.IceThrust, Icon = 56, Level1 = 53, Level2 = 56, Level3 = 59, Level4 = 62, Need1 = 17000, Need2 = 22000, Need3 = 27000, Need4 = 10000, BaseCost = 100, LevelCost = 20, HumUpTrain = false };
            Blink = new MagicInfo { Spell = Spell.Blink, Icon = 20, Level1 = 19, Level2 = 22, Level3 = 25, Need1 = 350, Need2 = 1000, Need3 = 2000, BaseCost = 10, LevelCost = 3 };

            //Taoist
            Healing = new MagicInfo { Spell = Spell.Healing, Icon = 1, Level1 = 7, Level2 = 11, Level3 = 14, Level4 = 62, Need1 = 150, Need2 = 350, Need3 = 700, Need4 = 10000, BaseCost = 3, LevelCost = 2, HumUpTrain = false };
            SpiriSword = new MagicInfo { Spell = Spell.SpiritSword, Icon = 3, Level1 = 9, Level2 = 12, Level3 = 15, Level4 = 62, Need1 = 350, Need2 = 1300, Need3 = 2700, HumUpTrain = false };
            Poisoning = new MagicInfo { Spell = Spell.Poisoning, Icon = 5, Level1 = 14, Level2 = 17, Level3 = 20, Level4 = 62, Need1 = 700, Need2 = 1300, Need3 = 2700, Need4 = 10000, BaseCost = 2, LevelCost = 1, HumUpTrain = true };
            SoulFireBall = new MagicInfo { Spell = Spell.SoulFireBall, Icon = 12, Level1 = 18, Level2 = 21, Level3 = 24, Level4 = 62, Need1 = 1300, Need2 = 2700, Need3 = 4000, Need4 = 10000, BaseCost = 3, LevelCost = 1, HumUpTrain = true };
            SummonSkeleton = new MagicInfo { Spell = Spell.SummonSkeleton, Icon = 16, Level1 = 19, Level2 = 22, Level3 = 26, Level4 = 62, Need1 = 1000, Need2 = 2000, Need3 = 3500, Need4 = 10000, BaseCost = 12, LevelCost = 4, HumUpTrain = false };
            Hiding = new MagicInfo { Spell = Spell.Hiding, Icon = 17, Level1 = 20, Level2 = 23, Level3 = 26, Level4 = 62, Need1 = 1300, Need2 = 2700, Need3 = 5300, Need4 = 10000, BaseCost = 1, LevelCost = 1, HumUpTrain = false };
            MassHiding = new MagicInfo { Spell = Spell.MassHiding, Icon = 18, Level1 = 21, Level2 = 25, Level3 = 29, Level4 = 62, Need1 = 1300, Need2 = 2700, Need3 = 5300, Need4 = 10000, BaseCost = 2, LevelCost = 2, HumUpTrain = false };
            SoulShield = new MagicInfo { Spell = Spell.SoulShield, Icon = 13, Level1 = 22, Level2 = 24, Level3 = 26, Level4 = 62, Need1 = 2000, Need2 = 3500, Need3 = 7000, Need4 = 10000, BaseCost = 2, LevelCost = 2, HumUpTrain = false };
            Revelation = new MagicInfo { Spell = Spell.Revelation, Icon = 27, Level1 = 23, Level2 = 25, Level3 = 28, Level4 = 62, Need1 = 1500, Need2 = 2500, Need3 = 4000, Need4 = 10000, BaseCost = 4, LevelCost = 4, HumUpTrain = false };
            BlessedArmour = new MagicInfo { Spell = Spell.BlessedArmour, Icon = 14, Level1 = 25, Level2 = 27, Level3 = 29, Level4 = 62, Need1 = 4000, Need2 = 6000, Need3 = 10000, Need4 = 10000, BaseCost = 2, LevelCost = 2, HumUpTrain = false };
            EnergyRepulsor = new MagicInfo { Spell = Spell.EnergyRepulsor, Icon = 36, Level1 = 27, Level2 = 29, Level3 = 31, Level4 = 62, Need1 = 1800, Need2 = 2400, Need3 = 3200, Need4 = 10000, BaseCost = 2, LevelCost = 2, HumUpTrain = false };
            TrapHexagon = new MagicInfo { Spell = Spell.TrapHexagon, Icon = 15, Level1 = 28, Level2 = 30, Level3 = 32, Level4 = 62, Need1 = 2500, Need2 = 5000, Need3 = 10000, Need4 = 10000, BaseCost = 7, LevelCost = 3, HumUpTrain = false };
            Purification = new MagicInfo { Spell = Spell.Purification, Icon = 39, Level1 = 30, Level2 = 32, Level3 = 35, Level4 = 62, Need1 = 3000, Need2 = 5000, Need3 = 8000, Need4 = 10000, BaseCost = 14, LevelCost = 2, HumUpTrain = false };
            MassHealing = new MagicInfo { Spell = Spell.MassHealing, Icon = 28, Level1 = 31, Level2 = 33, Level3 = 36, Level4 = 62, Need1 = 2000, Need2 = 4000, Need3 = 8000, Need4 = 10000, BaseCost = 28, LevelCost = 3, HumUpTrain = true };
            Hallucination = new MagicInfo { Spell = Spell.Hallucination, Icon = 48, Level1 = 31, Level2 = 34, Level3 = 36, Level4 = 62, Need1 = 4000, Need2 = 6000, Need3 = 9000, Need4 = 10000, BaseCost = 22, LevelCost = 10, HumUpTrain = false };
            UltimateEnchancer = new MagicInfo { Spell = Spell.UltimateEnhancer, Icon = 35, Level1 = 33, Level2 = 35, Level3 = 38, Level4 = 62, Need1 = 5000, Need2 = 7000, Need3 = 10000, Need4 = 10000, BaseCost = 28, LevelCost = 4, HumUpTrain = false };
            SummonShinsu = new MagicInfo { Spell = Spell.SummonShinsu, Icon = 29, Level1 = 35, Level2 = 37, Level3 = 40, Level4 = 62, Need1 = 2000, Need2 = 4000, Need3 = 6000, Need4 = 10000, BaseCost = 28, LevelCost = 4, HumUpTrain = true };
            Reincarnation = new MagicInfo { Spell = Spell.Reincarnation, Icon = 53, Level1 = 37, Level2 = 39, Level3 = 41, Level4 = 62, Need1 = 2000, Need2 = 6000, Need3 = 10000, Need4 = 10000, BaseCost = 125, LevelCost = 17, HumUpTrain = true };
            SummonHolyDeva = new MagicInfo { Spell = Spell.SummonHolyDeva, Icon = 40, Level1 = 38, Level2 = 41, Level3 = 43, Level4 = 62, Need1 = 4000, Need2 = 6000, Need3 = 9000, Need4 = 10000, BaseCost = 28, LevelCost = 4, HumUpTrain = true };
            Curse = new MagicInfo { Spell = Spell.Curse, Icon = 45, Level1 = 40, Level2 = 42, Level3 = 44, Level4 = 62, Need1 = 4000, Need2 = 6000, Need3 = 9000, Need4 = 10000, BaseCost = 17, LevelCost = 3, HumUpTrain = true };
            Plague = new MagicInfo { Spell = Spell.Plague, Icon = 74, Level1 = 42, Level2 = 44, Level3 = 47, Level4 = 62, Need1 = 5000, Need2 = 9000, Need3 = 13000, Need4 = 10000, BaseCost = 20, LevelCost = 5, HumUpTrain = true };
            PoisonCloud = new MagicInfo { Spell = Spell.PoisonCloud, Icon = 54, Level1 = 43, Level2 = 45, Level3 = 48, Level4 = 62, Need1 = 4000, Need2 = 8000, Need3 = 12000, Need4 = 10000, BaseCost = 30, LevelCost = 5, HumUpTrain = true };
            EnergyShield = new MagicInfo { Spell = Spell.EnergyShield, Icon = 57, Level1 = 48, Level2 = 51, Level3 = 54, Level4 = 62, Need1 = 5000, Need2 = 9000, Need3 = 13000, Need4 = 10000, BaseCost = 50, LevelCost = 20, HumUpTrain = true };

            //Assassin
            FatalSword = new MagicInfo { Spell = Spell.FatalSword, Icon = 58, Level1 = 7, Level2 = 9, Level3 = 12, Level4 = 62, Need1 = 500, Need2 = 1000, Need3 = 2300, HumUpTrain = true };
            DoubleSlash = new MagicInfo { Spell = Spell.DoubleSlash, Icon = 59, Level1 = 15, Level2 = 17, Level3 = 19, Level4 = 62, Need1 = 700, Need2 = 1500, Need3 = 2200, Need4 = 10000, BaseCost = 2, LevelCost = 1, HumUpTrain = false };
            Haste = new MagicInfo { Spell = Spell.Haste, Icon = 60, Level1 = 20, Level2 = 22, Level3 = 25, Level4 = 62, Need1 = 2000, Need2 = 3000, Need3 = 6000, Need4 = 10000, BaseCost = 3, LevelCost = 2, HumUpTrain = true };
            FlashDash = new MagicInfo { Spell = Spell.FlashDash, Icon = 61, Level1 = 25, Level2 = 27, Level3 = 30, Level4 = 62, Need1 = 4000, Need2 = 7000, Need3 = 9000, Need4 = 10000, BaseCost = 12, LevelCost = 2, HumUpTrain = true };
            LightBody = new MagicInfo { Spell = Spell.LightBody, Icon = 68, Level1 = 27, Level2 = 29, Level3 = 32, Level4 = 62, Need1 = 5000, Need2 = 7000, Need3 = 10000, Need4 = 10000, BaseCost = 11, LevelCost = 2, HumUpTrain = false };
            HeavenlySword = new MagicInfo { Spell = Spell.HeavenlySword, Icon = 62, Level1 = 30, Level2 = 32, Level3 = 35, Level4 = 62, Need1 = 4000, Need2 = 8000, Need3 = 10000, Need4 = 10000, BaseCost = 13, LevelCost = 2, HumUpTrain = true };
            FireBurst = new MagicInfo { Spell = Spell.FireBurst, Icon = 63, Level1 = 33, Level2 = 35, Level3 = 38, Level4 = 62, Need1 = 4000, Need2 = 6000, Need3 = 8000, Need4 = 10000, BaseCost = 10, LevelCost = 1, HumUpTrain = false };
            Trap = new MagicInfo { Spell = Spell.Trap, Icon = 64, Level1 = 33, Level2 = 35, Level3 = 38, Level4 = 62, Need1 = 2000, Need2 = 4000, Need3 = 6000, Need4 = 10000, BaseCost = 14, LevelCost = 2, HumUpTrain = false };
            PoisonSword = new MagicInfo { Spell = Spell.PoisonSword, Icon = 69, Level1 = 34, Level2 = 36, Level3 = 39, Level4 = 62, Need1 = 5000, Need2 = 8000, Need3 = 11000, Need4 = 10000, BaseCost = 14, LevelCost = 3, HumUpTrain = false };
            MoonLight = new MagicInfo { Spell = Spell.MoonLight, Icon = 65, Level1 = 36, Level2 = 39, Level3 = 42, Level4 = 62, Need1 = 3000, Need2 = 5000, Need3 = 8000, Need4 = 10000, BaseCost = 36, LevelCost = 3, HumUpTrain = true };
            MPEater = new MagicInfo { Spell = Spell.MPEater, Icon = 66, Level1 = 38, Level2 = 41, Level3 = 44, Level4 = 62, Need1 = 5000, Need2 = 8000, Need3 = 11000, HumUpTrain = true };
            SwiftFeet = new MagicInfo { Spell = Spell.SwiftFeet, Icon = 67, Level1 = 40, Level2 = 43, Level3 = 46, Level4 = 62, Need1 = 4000, Need2 = 6000, Need3 = 9000, Need4 = 10000, BaseCost = 17, LevelCost = 5, HumUpTrain = true };
            DarkBody = new MagicInfo { Spell = Spell.DarkBody, Icon = 70, Level1 = 46, Level2 = 49, Level3 = 52, Level4 = 62, Need1 = 6000, Need2 = 10000, Need3 = 14000, Need4 = 10000, BaseCost = 40, LevelCost = 7, HumUpTrain = false };
            Hemorrhage = new MagicInfo { Spell = Spell.Hemorrhage, Icon = 75, Level1 = 47, Level2 = 51, Level3 = 55, Level4 = 62, Need1 = 9000, Need2 = 15000, Need3 = 21000, HumUpTrain = false };
            CresentSlash = new MagicInfo { Spell = Spell.CrescentSlash, Icon = 71, Level1 = 50, Level2 = 53, Level3 = 56, Level4 = 62, Need1 = 12000, Need2 = 16000, Need3 = 24000, Need4 = 10000, BaseCost = 19, LevelCost = 5, HumUpTrain = true };


            //Archer
            Focus = new MagicInfo { Spell = Spell.Focus, Icon = 88, Level1 = 7, Level2 = 13, Level3 = 17, Level4 = 62, Need1 = 270, Need2 = 600, Need3 = 1300, HumUpTrain = false };
            StraightShot = new MagicInfo { Spell = Spell.StraightShot, Icon = 89, Level1 = 9, Level2 = 12, Level3 = 16, Level4 = 62, Need1 = 350, Need2 = 750, Need3 = 1400, Need4 = 10000, BaseCost = 3, LevelCost = 2, HumUpTrain = true };
            DoubleShot = new MagicInfo { Spell = Spell.DoubleShot, Icon = 90, Level1 = 14, Level2 = 18, Level3 = 21, Level4 = 62, Need1 = 700, Need2 = 1500, Need3 = 2100, Need4 = 10000, BaseCost = 3, LevelCost = 2, HumUpTrain = true };
            ExplosiveTrap = new MagicInfo { Spell = Spell.ExplosiveTrap, Icon = 91, Level1 = 22, Level2 = 25, Level3 = 30, Level4 = 62, Need1 = 2000, Need2 = 3500, Need3 = 5000, Need4 = 10000, BaseCost = 10, LevelCost = 3, HumUpTrain = false };
            DelayedExplosion = new MagicInfo { Spell = Spell.DelayedExplosion, Icon = 92, Level1 = 31, Level2 = 34, Level3 = 39, Level4 = 62, Need1 = 3000, Need2 = 7000, Need3 = 10000, Need4 = 10000, BaseCost = 8, LevelCost = 2, HumUpTrain = true };
            //ArcherSpells Elemental system
            Meditation = new MagicInfo { Spell = Spell.Meditation, Icon = 93, Level1 = 19, Level2 = 24, Level3 = 29, Level4 = 62, Need1 = 1800, Need2 = 2600, Need3 = 5600, Need4 = 10000, BaseCost = 8, LevelCost = 2, HumUpTrain = true };
            ElementalShot = new MagicInfo { Spell = Spell.ElementalShot, Icon = 94, Level1 = 20, Level2 = 25, Level3 = 31, Level4 = 62, Need1 = 1800, Need2 = 2700, Need3 = 6000, Need4 = 10000, BaseCost = 8, LevelCost = 2, HumUpTrain = true };
            Concentration = new MagicInfo { Spell = Spell.Concentration, Icon = 96, Level1 = 23, Level2 = 27, Level3 = 32, Level4 = 62, Need1 = 2100, Need2 = 3800, Need3 = 6500, Need4 = 10000, BaseCost = 8, LevelCost = 2, HumUpTrain = false };
            ElementalBarrier = new MagicInfo { Spell = Spell.ElementalBarrier, Icon = 98, Level1 = 33, Level2 = 38, Level3 = 44, Level4 = 62, Need1 = 3000, Need2 = 7000, Need3 = 10000, Need4 = 10000, BaseCost = 10, LevelCost = 2, HumUpTrain = true };
            //
            BackStep = new MagicInfo { Spell = Spell.BackStep, Icon = 95, Level1 = 30, Level2 = 34, Level3 = 38, Level4 = 62, Need1 = 2400, Need2 = 3000, Need3 = 6000, Need4 = 10000, BaseCost = 12, LevelCost = 2, HumUpTrain = false };
            BindingShot = new MagicInfo { Spell = Spell.BindingShot, Icon = 97, Level1 = 35, Level2 = 39, Level3 = 42, Level4 = 62, Need1 = 400, Need2 = 7000, Need3 = 9500, Need4 = 10000, BaseCost = 7, LevelCost = 3, HumUpTrain = false };
            SummonVampire = new MagicInfo { Spell = Spell.SummonVampire, Icon = 99, Level1 = 28, Level2 = 33, Level3 = 41, Level4 = 62, Need1 = 2000, Need2 = 2700, Need3 = 7500, Need4 = 10000, BaseCost = 10, LevelCost = 5, HumUpTrain = true };
            VampireShot = new MagicInfo { Spell = Spell.VampireShot, Icon = 100, Level1 = 26, Level2 = 32, Level3 = 36, Level4 = 62, Need1 = 3000, Need2 = 6000, Need3 = 12000, Need4 = 10000, BaseCost = 12, LevelCost = 3, HumUpTrain = true };//ArcherSpells - VampireShot
            SummonToad = new MagicInfo { Spell = Spell.SummonToad, Icon = 101, Level1 = 37, Level2 = 43, Level3 = 47, Level4 = 62, Need1 = 5800, Need2 = 10000, Need3 = 13000, Need4 = 10000, BaseCost = 10, LevelCost = 5, HumUpTrain = true };
            PoisonShot = new MagicInfo { Spell = Spell.PoisonShot, Icon = 102, Level1 = 40, Level2 = 45, Level3 = 49, Level4 = 62, Need1 = 6000, Need2 = 14000, Need3 = 16000, Need4 = 10000, BaseCost = 10, LevelCost = 4, HumUpTrain = false };//ArcherSpells - PoisonShot
            CrippleShot = new MagicInfo { Spell = Spell.CrippleShot, Icon = 103, Level1 = 43, Level2 = 47, Level3 = 50, Level4 = 62, Need1 = 12000, Need2 = 15000, Need3 = 18000, Need4 = 10000, BaseCost = 15, LevelCost = 3, HumUpTrain = false };//ArcherSpells - CrippleShot
            SummonSnakes = new MagicInfo { Spell = Spell.SummonSnakes, Icon = 104, Level1 = 46, Level2 = 51, Level3 = 54, Level4 = 62, Need1 = 14000, Need2 = 17000, Need3 = 20000, Need4 = 10000, BaseCost = 10, LevelCost = 5, HumUpTrain = false };
            NapalmShot = new MagicInfo { Spell = Spell.NapalmShot, Icon = 105, Level1 = 48, Level2 = 52, Level3 = 55, Level4 = 62, Need1 = 15000, Need2 = 18000, Need3 = 21000, Need4 = 10000, BaseCost = 40, LevelCost = 10, HumUpTrain = true };//ArcherSpells - NapalmShot
            OneWithNature = new MagicInfo { Spell = Spell.OneWithNature, Icon = 106, Level1 = 50, Level2 = 53, Level3 = 56, Level4 = 62, Need1 = 17000, Need2 = 19000, Need3 = 24000, Need4 = 10000, BaseCost = 80, LevelCost = 15, HumUpTrain = true };//ArcherSpells - OneWithNature
            MentalState = new MagicInfo { Spell = Spell.MentalState, Icon = 81, Level1 = 11, Level2 = 15, Level3 = 22, Level4 = 62, Need1 = 500, Need2 = 900, Need3 = 1800, Need4 = 10000, BaseCost = 1, LevelCost = 1, HumUpTrain = false };//todo make this proper }}
            }
            
        public MagicInfo()
        {
            Magics.Add(this);
        }

        public static MagicInfo GetMagicInfo(Spell spell)
        {
            for (int i = 0; i < Magics.Count; i++)
            {
                MagicInfo info = Magics[i];
                if (info.Spell != spell) continue;
                return info;
            }

            return null;
        }
    }

    public class UserMagic
    {
        public Spell Spell;
        public MagicInfo Info;

        public byte Level, Key;
        public ushort Experience;
        public bool IsTempSpell;
        public long CastTime;

        public UserMagic(Spell spell)
        {
            Spell = spell;
            Info = MagicInfo.GetMagicInfo(Spell);
        }
        public UserMagic(BinaryReader reader)
        {
            Spell = (Spell) reader.ReadByte();
            Info = MagicInfo.GetMagicInfo(Spell);

            Level = reader.ReadByte();
            Key = reader.ReadByte();
            Experience = reader.ReadUInt16();

            if (Envir.LoadVersion < 15) return;
            IsTempSpell = reader.ReadBoolean();
        }
        public void Save(BinaryWriter writer)
        {
            writer.Write((byte) Spell);

            writer.Write(Level);
            writer.Write(Key);
            writer.Write(Experience);
            writer.Write(IsTempSpell);
        }

        public Packet GetInfo()
        {
            return new S.NewMagic
                {
                    Magic = CreateClientMagic()
                };
        }

        public ClientMagic CreateClientMagic()
        {
            return new ClientMagic
                {
                    Spell = Spell,
                    BaseCost = Info.BaseCost,
                    LevelCost = Info.LevelCost,
                    Icon = Info.Icon,
                    Level1 = Info.Level1,
                    Level2 = Info.Level2,
                    Level3 = Info.Level3,
                    Level4 = Info.Level4,
                    Need1 = Info.Need1,
                    Need2 = Info.Need2,
                    Need3 = Info.Need3,
                    Need4 = Info.Need4,
                    Level = Level,
                    Key = Key,
                    Experience = Experience,
                    IsHumUpTrain = Info.HumUpTrain,
                    IsTempSpell = IsTempSpell,
                    Delay = GetDelay()
                };
        }


        public int GetPower()
        {
            return (int)Math.Round((MPower() / 4F) * (Level + 1) + DefPower());
        }

        public int MPower()
        {
            switch (Spell)
            {
                case Spell.FireBall:
                    return 8;
                case Spell.GreatFireBall:
                    return 6;
                case Spell.HellFire:
                    return 14;
                case Spell.ThunderBolt:
                    return SMain.Envir.Random.Next(8, 28);
                case Spell.FireBang:
                    return 8;
                case Spell.FireWall:
                    return 3;
                case Spell.Lightning:
                    return 12;
                case Spell.ThunderStorm:
                    return SMain.Envir.Random.Next(10, 30);
                case Spell.IceStorm:
                    return 12;
                case Spell.FlameDisruptor:
                    return SMain.Envir.Random.Next(15, 35);
                case Spell.FrostCrunch:
                    return 12;
                case Spell.Vampirism:
                    return 12;
                case Spell.FlameField:
                    return 100;


                case Spell.Healing:
                    return 14;
                case Spell.Poisoning:
                    return 6;
                case Spell.SoulFireBall:
                    return 8;
                case Spell.MassHealing:
                    return 10;
                case Spell.PoisonCloud:
                    return 40;
                case Spell.Plague:
                    return 10;

                case Spell.SlashingBurst:
                    return 1;

                case Spell.HeavenlySword:
                    return 8;

                case Spell.StraightShot:
                    return 8;
                case Spell.DoubleShot:
                    return 6;
                case Spell.ExplosiveTrap:
                    return 15;
                case Spell.DelayedExplosion:
                    return 30;
                case Spell.ElementalBarrier:
                    return 15;
                case Spell.ElementalShot:
                    return 6;
                case Spell.VampireShot:
                    return 10;
                case Spell.PoisonShot:
                    return 10;
                case Spell.CrippleShot:
                    return SMain.Envir.Random.Next(10,30);
                case Spell.NapalmShot:
                    return SMain.Envir.Random.Next(25,50);
                case Spell.OneWithNature:
                    return SMain.Envir.Random.Next(75, 110);

                default:
                    return 0;
            }
        }
        public int DefPower()
        {
            switch (Spell)
            {
                case Spell.FireBall:
                    return 2;
                case Spell.GreatFireBall:
                    return 10;
                case Spell.HellFire:
                    return 6;
                case Spell.ThunderBolt:
                    return 9;
                case Spell.FireBang:
                    return 8;
                case Spell.FireWall:
                    return 3;
                case Spell.Lightning:
                    return 12;
                case Spell.ThunderStorm:
                    return SMain.Envir.Random.Next(10, 30);
                case Spell.IceStorm:
                    return 14;
                case Spell.FlameDisruptor:
                    return 9;
                case Spell.FrostCrunch:
                    return 12;
                case Spell.Vampirism:
                    return 12;
                case Spell.FlameField:
                    return 25;

                case Spell.SlashingBurst:
                    return 3;

                case Spell.SoulFireBall:
                    return 3;
                case Spell.MassHealing:
                    return 4;
                case Spell.PoisonCloud:
                    return 20;
                case Spell.Plague:
                    return 8;

                case Spell.StraightShot:
                    return 3;
                case Spell.DoubleShot:
                    return 2;
                case Spell.ExplosiveTrap:
                    return 15;
                case Spell.DelayedExplosion:
                    return 15;
                case Spell.ElementalShot:
                    return 3;
                case Spell.ElementalBarrier:
                    return 5;
                case Spell.VampireShot:
                    return 7;
                case Spell.PoisonShot:
                    return 10;
                case Spell.CrippleShot:
                    return 10;
                case Spell.NapalmShot:
                    return 25;
                case Spell.OneWithNature:
                    return SMain.Envir.Random.Next(30, 50);

                default:
                    return 0;
            }
        }

        public int GetPower(int power)
        {
            return (int)Math.Round(power / 4F * (Level + 1) + DefPower());
        }

        public long GetDelay()
        {
            switch (Info.Spell)
            {
                case Spell.PoisonCloud:
                    return (18 - Level * 2) * 1000;
                case Spell.SlashingBurst:
                    return (14 - Level * 4) * 1000;
                case Spell.Fury:
                    return 600000 - Level * 120000;
                case Spell.Trap:
                    return 60000 - Level * 15000;
                case Spell.SwiftFeet:
                    return 210000 - Level * 40000;
                case Spell.CounterAttack:
                    return 24000;
                case Spell.FlashDash:
                    return 250;
                case Spell.ShoulderDash:
                    return 2500;
                case Spell.BackStep:
                    return 2500;

                default:
                    return 1800;
            }
        }
    }
}
