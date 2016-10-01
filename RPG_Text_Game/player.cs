using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG_Text_Game
{
    class Player
    {
        public string name { get; set; }

        public int level { get; set; }
        public int experience { get; set; }

        public string race { get; set; }
        public string job { get; set; } //class is reserved

        public int health { get; set; }
        public int mana { get; set; }

        public int armour { get; set; }
        public int toHit { get; set; }

        public int strength { get; set; }
        public int intelligence { get; set; }
        public int wisdom { get; set; }
        public int agility { get; set; }
        public int stamina { get; set; }
        public int charm { get; set; }

        List<string> inventory = new List<string>();

        public Player()
        {
            // Default Stats
            name = "Player";
            level = 1;
            race = "Race";
            job = "Class";
            health = 20;

            strength = 30;
            intelligence = 30;
            wisdom = 30;
            agility = 30;
            stamina = 30;
            charm = 30;

            // Default Gear
            inventory.Add("Wooden Sword");
            inventory.Add("Wooden Shield");
            inventory.Add("Basic Tunic");

        } // End default Constructor

        public void levelUp()
        {
            level += 1;
            Console.WriteLine("You are now level {0}!", level);
        } // End Level Up

        private void outLine(int x, string a, string b, string c)
        {
            string A = "";
            string B = "";
            string C = "";

            switch (x)
            {

                case 1:
                    A = "Name:";
                    C = "Level";
                    break;

                case 2:
                    A = "Exp:";
                    C = "Race:";
                    break;

                case 3:
                    C = "Class";

                    break;

                case 4: break;

                case 5:
                    A = "Health:";
                    B = "Armour:";
                    C = "To Hit:";
                    break;

                case 6: break;

                case 7:
                    A = "Strength:";
                    B = "Intellect:";
                    C = "Agility:";
                    break;

                case 8:
                    A = "Stamina:";
                    B = "Wisdom:";
                    C = "Charm:";
                    break;

                case 9: break;

                default:
                    A = "Col. A:";
                    B = "Col. B:";
                    C = "Col. C";
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0,-12}", A);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0,-12}", a);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0,-12}", B);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0,-12}", b);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0,-12}", C);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,-10}", c);
        }

        public void showStatus()
        {
            Console.WriteLine();
            outLine(1, this.name, "", this.level.ToString());
            outLine(2, this.experience.ToString(), "", this.race);
            outLine(3, "", "", this.job);
            outLine(5, this.health.ToString(), this.armour.ToString(), this.toHit.ToString());
            outLine(7, this.strength.ToString(), this.intelligence.ToString(), this.agility.ToString());
            outLine(8, this.stamina.ToString(), this.wisdom.ToString(), this.charm.ToString());
            Console.WriteLine();
        } // End Status

        public void showExp()
        {
            Console.WriteLine("Exp: {0}", this.experience);
        }

        public void showInventory()
        {
            Console.Write("\nInventory: ");
            foreach (string item in inventory)
            {
                if (item != inventory.LastOrDefault<string>())
                {
                    Console.Write("{0}, ", item);
                }
                else { Console.WriteLine("{0}.", item); }
            }
        }

        public void addInventory(string s)
        {
            this.inventory.Add(s);
        }

        public void removeInventory(string s)
        {
            this.inventory.Remove(s);
        }
    }
}