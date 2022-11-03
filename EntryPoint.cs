using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorWars.Enum;

namespace WarriorWars
{
    class EntryPoint
    {
        static Random rng = new Random();
        static void Main()
        {
            Warrior goodGuy = new Warrior("Bramanadhan",Faction.GoodGuy);
            Warrior badGuy = new Warrior("El Kresendo ",Faction.BadGuy);

            while (goodGuy.IsAlive && badGuy.IsAlive)
            {
                if (rng.Next(0,10) < 5)
                {
                    goodGuy.Attack(badGuy);
                }
                else
                {
                    badGuy.Attack(goodGuy);
                }
            }


        }
    }
}
