using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Text_Game
{
    class Program
    {
        static bool running = true;
        static int roomX = 0;
        static Hero hero = new Hero();

        static void Main(string[] Args)
        {
            // Main Game Loop
            do
            {
                textColor(ConsoleColor.Cyan);
                room(roomX); // Update Room Name, Description, Items, People, Monsters seen
                textColor(ConsoleColor.DarkRed);
                Console.WriteLine("Command: "); // User Prompt asking for input
                textColor(ConsoleColor.DarkYellow);
                tryCommand( Console.ReadLine() ); // Validate and do as commanded
            }
            while (running) ; // End Main Game Loop

        } // End Main Method

        static void tryCommand(string s)
        {
            // Shortcut Commands
            if (s.Length < 3)
            {
                if (s.ToUpper() == "N") s = "NORTH";
                if (s.ToUpper() == "S") s = "SOUTH";
                if (s.ToUpper() == "E") s = "EAST";
                if (s.ToUpper() == "W") s = "West";
                if (s.ToUpper() == "NE") s = "NORTHEAST";
                if (s.ToUpper() == "NW") s = "NORTHWEST";
                if (s.ToUpper() == "SE") s = "SOUTHEAST";
                if (s.ToUpper() == "SW") s = "SOUTHWEST";
            }

            if (s.ToUpper() == "NORTH")
            {
                Console.WriteLine("Moving North . . . ");
            }

            if (s.ToUpper() == "SOUTH")
            {
                Console.WriteLine("Moving South . . . ");
            }

            if (s.ToUpper() == "EAST")
            {
                Console.WriteLine("Moving East . . . ");
            }

            if (s.ToUpper() == "WEST")
            {
                Console.WriteLine("Moving West . . . ");
            }

            if (s.ToUpper() == "NORTHEAST")
            {
                Console.WriteLine("Moving Northeast . . . ");
            }

            if (s.ToUpper() == "SOUTHEAST")
            {
                Console.WriteLine("Moving Southeast . . . ");
            }

            if (s.ToUpper() == "NORTHWEST")
            {
                Console.WriteLine("Moving Northwest . . . ");
            }

            if (s.ToUpper() == "SOUTHWEST")
            {
                Console.WriteLine("Moving Southwest . . . ");
            }

            if (s.ToUpper() == "UP")
            {
                Console.WriteLine("Moving Up . . . ");
            }

            if (s.ToUpper() == "DOWN")
            {
                Console.WriteLine("Moving Down . . . ");
            }

            if (s.ToUpper() == "LOOK")
            {
                room(roomX);
            }

            // if string is too small, will cause errors with substring
            if (s.Length > 5 && s.ToUpper().Substring(0,6) == "ATTACK")
            {
                // This is for targeting a specific Monster or NPC, else randomly attacks a Monster if present
                if (s.Length > 7)
                {
                    Console.WriteLine("I swing wildly at {0}", s.Substring(7));
                }
                else
                {
                    Console.WriteLine("Attacking without a target.");
                }
            }

            // For Testing Purposes
            if (s.ToUpper() == "LEVELUP")
            {
                hero.levelUp();
            }

            if (s.ToUpper() == "STATUS")
            {
                hero.status();
            }

            if (s.ToUpper() == "EQUIPMENT")
            {
                hero.equipment();
            }

            if (s.ToUpper() == "EXIT" || s.ToUpper() == "QUIT")
                running = false;
        }

        static void room(int x)
        {
            switch (x)
            {
                case 0:
                    Console.WriteLine(
                        "Welcome to Castle Grabber \n\n" +
                        "It's a land dominated by powerful Kings and Queens, Glorious Battles, and Hidden Danger! \n\n" +
                        "But your story is just beginning...\n\n"
                        );
                    pause();
                    
                    Console.WriteLine(
                    "You wake up to the screams and cries of the village under attack. \n" +
                    "Your parents knew this day would come, and force you into a secret tunnel. \n"
                    );
                    pause();

                    Console.WriteLine(
                        "The dark tunnels slowly led you away from the the terror and chaos. \n" +
                        "It seemed like you had crawled for hours, but soon a new room revealed itself. \n "
                        );
                    pause();

                    Console.WriteLine(
                        "It's a large bedroom with a large bookshelf of books \n" +
                        "The bed is made out of real oak, with ornate patterns. \n" +
                        "and there's an envelope on the desk... \n"
                        );
                    pause();

                    Console.WriteLine(
                        "The letter explains who you really are! \n\n" +
                        "My child, \n" +
                        "  You were hidden away from an evil King. \n" +
                        "His madness grows as he seeks to destroy you. \n" +
                        "He fears you and the prophecy of his downfall...\n"
                        );
                    roomX = 1;
                    break;

                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                default:
                    break;
            } // End Switch

        } // End Room Method

        static void pause()
        {
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
        }

        static void textColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

    } // End Program Class

    class Hero
    {
        public int level {get; set;}
        public int health { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int speed { get; set; }
        List<string> inventory = new List<string>();

        public void levelUp()
        {
            level += 1;
            health = 20 + (level/10 * 10);
            attack = 2 + (level/3);
            defense = 2 + (level/4);
            speed = 2 + (level/5);
            Console.WriteLine("You are now level {0}!", level);
        }

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
        }

        public void equipment()
        {
            inventory.Add("Sword");
            inventory.Add("Shield");
            inventory.Add("Leather");

            Console.Write("\nInventory: ");

            foreach (string item in inventory)
            {
                if (item == inventory.LastOrDefault<string>())
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.Write(item + ", ");
                }
            }

        }

    } // End Hero

} // End NameSpace
