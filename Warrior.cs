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
            int damage = 10;

            enemy.health -= damage;

            AttackResult(enemy, damage);
            Thread.Sleep(200);
        }

        private void AttackResult(Warrior enemy, int damage)
        {
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;

                Tools.ColorfulWriteLine($"{enemy.name} IS DEAD , ", ConsoleColor.DarkRed);
                Tools.ColorfulWriteLine($"{name} IS VICTORIUS!!", ConsoleColor.Yellow);
            }

            else
            {

                Tools.ColorfulWriteLine($"{name} attacked {enemy.name}.Damage {damage} was inflicted on {enemy.name} ,remaining health of {enemy.name} is  {enemy.health} ", ConsoleColor.Green);
                Console.WriteLine();

            }
        }
    }
}
