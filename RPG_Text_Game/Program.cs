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
            // Setup Console Window
            initialConfig();

            // Main Game Loop
            do
            {
                room.update(roomX); // Grab current Room Information
                
                textColor(ConsoleColor.Cyan);
                Console.WriteLine("\n{0}", room.title);
                
                textColor(ConsoleColor.DarkCyan);
                Console.WriteLine("\n{0}",room.view);

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
                Console.Write("Command: "); // User Prompt
                
                textColor(ConsoleColor.DarkCyan);
                tryCommand(Console.ReadLine()); // Validate Input
            }
            while (running) ; // End Main Game Loop

        } // End Main Method

        static void tryCommand(string s)
        {
            Console.WriteLine();
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

            if (s.ToUpper() == "NORTH"){
                if (room.exits.Contains("North") )
                {
                    roomX += 1;
                    Console.WriteLine("Moving North . . . ");
                }
                else
                {
                    Console.WriteLine("You can't go North.");
                }
            }

            if (s.ToUpper() == "SOUTH")
            {
                if(room.exits.Contains("South"))
                {
                    roomX += -1;
                    Console.WriteLine("Moving South . . . ");
                }
                else
                {
                    Console.WriteLine("You can't go South.");
                }
            }

            if (s.ToUpper() == "EAST")
            {
                if (room.exits.Contains("East"))
                {
                    roomX += 100;
                    Console.WriteLine("Moving East . . . ");
                }
                else
                {
                    Console.WriteLine("You can't go East.");
                }
            }
   
            if (s.ToUpper() == "WEST")
            {
                if(room.exits.Contains("West") )
                {
                    roomX += -100;
                    Console.WriteLine("Moving West . . . ");
                }
                else
                {
                    Console.WriteLine("You can't go West.");
                }
            }

            if (s.ToUpper() == "NORTHEAST")
            {
                if(room.exits.Contains("Northeast") )
                {
                    roomX += 101;
                    Console.WriteLine("Moving Northeast . . . ");
                }
                else
                {
                    Console.WriteLine("You can't go Northeast.");
                }
            }

            if (s.ToUpper() == "SOUTHEAST")
            {
                if(room.exits.Contains("Southeast") )
                {
                    roomX += 99;
                    Console.WriteLine("Moving Southeast . . . ");
                }
                else
                {
                    Console.WriteLine("You can't go Southeast.");
                }
            }

            if (s.ToUpper() == "NORTHWEST")
            {
                if (room.exits.Contains("Northwest"))
                {
                    roomX += -99;
                    Console.WriteLine("Moving Northwest . . . ");
                }
                else
                {
                    Console.WriteLine("You can't go Northwest.");
                }
            }

            if (s.ToUpper() == "SOUTHWEST")
            {
                if (room.exits.Contains("Southwest"))
                {
                    roomX += -101;
                    Console.WriteLine("Moving Southwest . . . ");
                }
                else
                {
                    Console.WriteLine("You can't go Southwest");
                }
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

        static void initialConfig()
        {
            // Initial Configuration
            Console.Title = "Castle Grabber";
            Console.WindowWidth = Console.LargestWindowWidth / 3 * 2;
            Console.WindowHeight = Console.LargestWindowHeight / 3 * 2;
            Console.SetWindowPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }
    } // End Program Class

} // End NameSpace
