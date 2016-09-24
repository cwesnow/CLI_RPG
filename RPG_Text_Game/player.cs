using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Text_Game
{
    class Player
    {
        public int level { get; set; }
        public int health { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int speed { get; set; }
        List<string> inventory = new List<string>();

        public Player()
        {
            // Default Stats
            level = 1;
            health = 20 + (level / 10 * 10);
            attack = 2 + (level / 3);
            defense = 2 + (level / 4);
            speed = 2 + (level / 5);

            // Default Gear
            inventory.Add("Wooden Sword");
            inventory.Add("Wooden Shield");
            inventory.Add("Basic Tunic");

        } // End default Constructor

        public void levelUp()
        {
            level += 1;
            health = 20 + (level / 10 * 10);
            attack = 2 + (level / 3);
            defense = 2 + (level / 4);
            speed = 2 + (level / 5);
            Console.WriteLine("You are now level {0}!", level);
        } // End Level Up

        public void status()
        {
            Console.WriteLine(
                    "Level: {0}\n" +
                    "Health: {1}\n" +
                    "Attack: {2}\n" +
                    "Defense: {3}\n" +
                    "Speed: {4}\n"
                    , level, health, attack, defense, speed
                    );
        } // End Status

        public void equipment()
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

        } // End Equipment
    }
}
