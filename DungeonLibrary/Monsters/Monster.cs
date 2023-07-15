using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;

        public int MaxDamage { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //MinDamage can't exceed Max and can't be less than 1
                _minDamage = (value > 0 && value < MaxDamage) ? value : 1;
            }
        }

        public string Description { get; set; }

        public Monster(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description)
            : base(name, hitChance, block, maxLife)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }
        public Monster()
        {
            //added so we can create "default" monster subtypes
            //Name = "Baby Goblin"
            //HitChance = 15
            //Goblin babyGoblin = new Goblin()
        }

        public override string ToString()
        {
            return $"*********** MONSTER ***********\n" +
                $"{base.ToString()}\n" +
                $"Damage: {MinDamage} - {MaxDamage}\n" +
                $"Description: {Description}";
        }

        public override int CalcDamage()
        {
            //throw new NotImplementedException();
            return new Random().Next(MinDamage, MaxDamage + 1);//+1 because it's exclusive
        }

        public static Monster GetMonster()
        {
            //TODO Come back to replace these monsters with your own monster subtypes later.
            Monster m1 = new("Naga", 50, 20, 25, 8, 2, "Serpent-like creature with the upper body of a humanoid.");
            Monster m2 = new("Kirin", 70, 20, 25, 8, 2, "Mythical creature resembling a combination of a deer and a dragon.");
            Monster m3 = new("Bakemono", 50, 20, 25, 8, 2, "Shapeshifting monster that can assume the form of ordinary objects or animals.");
            Monster m4 = new("Kijo", 45, 25, 40, 12, 5, " Female demon known for their beauty and seductive charms.");

            List<Monster> monsters = new()
            {
                m1, m1,m1,
                m2, m2, m2,
                m3, m3, 
                m4, m4
            };

            Random rand = new Random();
            int index = rand.Next(monsters.Count);
            Monster monster = monsters[index];
            return monster;

            //return monsters[new Random().Next(monsters.Count)];
        }
    }
}
