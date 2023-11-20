//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DungeonLibrary
//{

//    public sealed class Player : Character
//    {

//        //FIELDS - Funny
//        //no fields, no business rules

//        //PROPS - People
//        public Race PlayerRace { get; set; }
//        public Weapon EquippedWeapon { get; set; }
//        public int Score { get; set; }

//        //CTORs - Collect
//        public Player(string name, /*int hitChance, int block, int maxLife,*/ Race playerRace, Weapon equippedWeapon)
//            : base(name, 70, 5, 40)//hitchance, block, maxlife/life
//        {
//            PlayerRace = playerRace;
//            EquippedWeapon = equippedWeapon;

//            #region Potential Expansion: Racial Bonuses
//            //build a switch based on the PlayerRace. Apply buffs/debuffs depending on which race they picked.
//            switch (PlayerRace)
//            {
//                case Race.Kitsune:
//                    HitChance += 5;
//                    Life -= 3;
//                    MaxLife -= 3;
//                    break;
//                case Race.Tengu:
//                    break;
//                case Race.Nekomata:
//                    break;
//                case Race.Oni:
//                    break;
//                case Race.Kappa:
//                    break;
//                case Race.Komainu:
//                    break;
//                default:
//                    break;
//            }

//            #endregion
//        }//End CTOR

//        //METHODS - Monkeys
//        private static string GetRaceDesc(Race race)
//        {
//            switch (race)
//            {
//                case Race.Kitsune:
//                    return "Kitsune are fox-like humanoid creatures. They are often depicted with multiple tails and possess mystical abilities such as shape-shifting and illusion magic.";
//                case Race.Tengu:
//                    return "Tengu are humanoid beings with bird-like features, often depicted with wings, beaks, and sometimes with long noses.";
//                case Race.Nekomata:
//                    return ": Nekomata are cat-like spirits or yokai known for their mystical powers. " +
//                        "They often have the ability to shape-shift, possess enhanced agility and senses, and are associated with magic.";
//                case Race.Oni:
//                    return " Oni are powerful and fearsome creatures. They have varying appearances but are often depicted as hulking, horned humanoids with great strength.";
//                case Race.Kappa:
//                    return " Kappa are water-dwelling creatures with reptilian features, typically depicted as child-sized with a shell on their back and a bowl-like depression on their head that holds water.";
//                case Race.Komainu:
//                    return "Komainu are mythical guardian creatures typically depicted as lion or dog-like beings. ";
//                default:
//                    return "";
//            }
//        }//end getRaceDesc()
//        public override string ToString()
//        {
//            return base.ToString() + $"\nWeapon: \n{EquippedWeapon}\n" +
//                $"Description: \n{GetRaceDesc(PlayerRace)}";
//        }

//        //CalcDamage() override -> return a random number between the EquippedWeapon's MinDamage and MaxDamage properties.
//        public override int CalcDamage()
//        {
//            //throw new NotImplementedException();
//            Random rand = new Random();
//            //.Next() 0 to int.MaxValue
//            //.Next(int value) 0 to value - 1
//            //.Next(int value1, int value2) value1 to value2 - 1
//            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
//            //Upper bound is exclusive, so we add 1 to the max damage.
//            return damage;
//        }
//        //CalcHitChance() override -> return the HitChance + EquippedWeapon's BonusHitChance property.
//        public override int CalcHitChance()
//        {
//            int chance = HitChance + EquippedWeapon.BonusHitChance;
//            return chance;
//        }
//    }
//}
