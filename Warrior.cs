using System;
using System.Threading;
using WarriorWars.Enum;
using WarriorWars.Equipment;

namespace WarriorWars
{
     class Warrior
    {
        private const  int GOOD_GUY_STARTING_HEALTH = 100;
        private const int BAD_GUY_STARTING_HEALTH = 100;


        private readonly Faction FACTION;

        private int health;
        private string name;
        private bool isAlive;

        public bool IsAlive {
            get
            {
                return isAlive;
            }
             }

        private Weapon weapon;
        private Armor armor;


        public Warrior(string name ,Faction faction)
        {
            this.name = name;
            this.FACTION = faction;
            isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;

                    break;
                default:
                    break;
            }
        }

        public void Attack(Warrior enemy)
        {
            int damage = 4;

            enemy.health -=  damage;

            if (enemy.health <= 0)
            {
                enemy.isAlive = false;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{enemy.name} IS DEAD , {name} IS VICTORIUS");
                Console.ResetColor();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{name} attacked {enemy.name}.Damage {damage} was inflicted ,remaining health is  {enemy.health} ");
                Console.WriteLine();
                Console.ResetColor();
            }
            Thread.Sleep(1000);
        }
    }
}
