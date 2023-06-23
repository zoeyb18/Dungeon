using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class BigHoss : Monster
    {
        public BigHoss()
        {
            MaxLife = 99;
            HitChance = 50;
            Block = 15;
            MaxDamage = 25;
            MinDamage = 10;

        }
         
    }
}
