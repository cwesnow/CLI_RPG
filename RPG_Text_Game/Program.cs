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
        static int roomX = 10101;
        static Player player = new Player();
        static Room room = new Room();

        static void Main(string[] Args)
        {
            // Main Game Loop
            do
            {
                room.update(roomX); // Grab current Room Information
                
                textColor(ConsoleColor.Cyan);
                Console.WriteLine(room.title);
                
                textColor(ConsoleColor.DarkCyan);
                Console.WriteLine(room.view);

                Console.Write("Also found: ");
                foreach (var item in room.items)
                {
                    if (item == room.items.LastOrDefault<string>())
                    {
                        Console.WriteLine(item);
                    }
                    else
                    {
                        Console.Write("{0},", item);
                    }
                }

                Console.Write("Exits: ");
                foreach (var exit in room.exits)
                {
                    if(exit == room.exits.LastOrDefault<string>())
                    {
                        Console.WriteLine(exit);
                    }
                    else
                    {
                        Console.Write("{0},", exit);
                    }
                }

                textColor(ConsoleColor.DarkGray);
                Console.WriteLine("Command: "); // User Prompt asking for input
                
                textColor(ConsoleColor.DarkCyan);
                tryCommand(Console.ReadLine()); // Validate and do as commanded
            }
            while (running) ; // End Main Game Loop

        } // End Main Method

        static void tryCommand(string s)
        {
            textColor(ConsoleColor.DarkGreen);
            // Shortcut Commands
            if (s.Length < 3)
            {
                if (s.ToUpper() == "N") s = "NORTH";
                if (s.ToUpper() == "S") s = "SOUTH";
                if (s.ToUpper() == "E") s = "EAST";
                if (s.ToUpper() == "W") s = "WEST";
                if (s.ToUpper() == "NE") s = "NORTHEAST";
                if (s.ToUpper() == "NW") s = "NORTHWEST";
                if (s.ToUpper() == "SE") s = "SOUTHEAST";
                if (s.ToUpper() == "SW") s = "SOUTHWEST";
            }

            if (s.ToUpper() == "NORTH")
            {
                roomX += 1;
                Console.WriteLine("Moving North . . . ");
            }

            if (s.ToUpper() == "SOUTH")
            {
                roomX += -1;
                Console.WriteLine("Moving South . . . ");
            }

            if (s.ToUpper() == "EAST")
            {
                roomX += 100;
                Console.WriteLine("Moving East . . . ");
            }

            if (s.ToUpper() == "WEST")
            {
                roomX += -100;
                Console.WriteLine("Moving West . . . ");
            }

            if (s.ToUpper() == "NORTHEAST")
            {
                roomX += 101;
                Console.WriteLine("Moving Northeast . . . ");
            }

            if (s.ToUpper() == "SOUTHEAST")
            {
                roomX += 99;
                Console.WriteLine("Moving Southeast . . . ");
            }

            if (s.ToUpper() == "NORTHWEST")
            {
                roomX += -99;
                Console.WriteLine("Moving Northwest . . . ");
            }

            if (s.ToUpper() == "SOUTHWEST")
            {
                roomX += -101;
                Console.WriteLine("Moving Southwest . . . ");
            }

            if (s.ToUpper() == "UP")
            {
                roomX += 10000;
                Console.WriteLine("Moving Up . . . ");
            }

            if (s.ToUpper() == "DOWN")
            {
                roomX += -10000;
                Console.WriteLine("Moving Down . . . ");
            }

            if (s.ToUpper() == "LOOK")
            {
                Console.WriteLine(room.title);
            }

            // if string is too small, will cause errors with substring
            if (s.Length > 5 && s.ToUpper().Substring(0,6) == "ATTACK")
            {
                // This is for targeting a specific Monster or NPC, else randomly attacks a Monster if present
                if (s.Length > 7)
                {
                    // TODO Target NPC/Monster and start combat mode
                    Console.WriteLine("I swing wildly at {0}", s.Substring(7));
                }
                else
                {
                    // TODO: Code for auto-attack or normal combat behavior
                    Console.WriteLine("Attacking without a target.");
                }
            }

            // For Testing Purposes
            if (s.ToUpper() == "LEVELUP")
            {
                player.levelUp();
            }

            if (s.ToUpper() == "STATUS")
            {
                player.status();
            }

            if (s.ToUpper() == "EQUIPMENT")
            {
                player.equipment();
            }

            if (s.ToUpper() == "EXIT" || s.ToUpper() == "QUIT")
                running = false;
        }

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

} // End NameSpace
