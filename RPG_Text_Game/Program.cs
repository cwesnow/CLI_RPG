using System;
using System.Collections;

namespace RPG_Text_Game
{
    class Program
    {
        static bool running = true;
        static bool verbose = false;

        static int roomX = 0100110;
        static Player player = new Player();
        static Room room = new Room();


        static void Main(string[] Args)
        {
            // Setup Console Window
            initialConfig();

            topMenu();

            // Starting Location - Load Room, Show Room
            room.update(roomX);
            room.show(verbose);

            // Main Game Loop
            do
            {
                writeColor(ConsoleColor.Gray, "[HP=" + player.health + "]: ");
                tryCommand(Console.ReadLine()); // Validate Input
            }
            while (running); // End Main Game Loop

        } // End Main Method

        static void tryCommand(string s)
        {
            s = s.ToUpper();

            // Shortcut Commands
            if (s.Length == 0) { room.show(false); }
            if (s.Length < 3)
            {
                if (s == "N") s = "NORTH";
                if (s == "S") s = "SOUTH";
                if (s == "E") s = "EAST";
                if (s == "W") s = "WEST";
                if (s == "NE") s = "NORTHEAST";
                if (s == "NW") s = "NORTHWEST";
                if (s == "SE") s = "SOUTHEAST";
                if (s == "SW") s = "SOUTHWEST";
                if (s == "D") s = "DOWN";
                if (s == "U") s = "UP";
                if (s == "A") s = "ATTACK";
                if (s == "?") s = "HELP";
                if (s == "I") s = "INVENTORY";
                if (s == "L") s = "LOOK";
            }

            if (room.exits.Contains(s.ToLower()))
            {
                int x = 0;
                if (s == "NORTH") x = 1;
                if (s == "SOUTH") x = -1;
                if (s == "EAST") x = 100;
                if (s == "WEST") x = -100;
                if (s == "NORTHEAST") x = 101;
                if (s == "NORTHWEST") x = -99;
                if (s == "SOUTHEAST") x = 99;
                if (s == "SOUTHWEST") x = -101;
                if (s == "DOWN") x = -10000;
                if (s == "UP") x = 10000;
                roomX += x;
                //Update Room and Display
                roomChanged();
            }

            if (s.ToUpper() == "LOOK")
            {
                room.show(true);
            }

            if (s.Length > 5 && s.Substring(0, 4).ToUpper() == "LOOK")
            {
                string target = s.Substring(5);

                foreach (var item in room.npc)
                {
                    if (item.name.ToUpper() == target.ToUpper())
                    {
                        Console.WriteLine(item.description);
                        break;
                    }
                }

                foreach (var item in room.monsters)
                {
                    if (item.name.ToUpper() == target.ToUpper())
                    {
                        Console.WriteLine(item.description);
                        break;
                    }
                }

                foreach (var item in room.items)
                {
                    if (item.name.ToUpper() == target.ToUpper())
                    {
                        Console.WriteLine(item.description);
                        break;
                    }
                }
            }

            // if string is too small, will cause errors with substring
            if (s.Length > 5 && s.ToUpper().Substring(0, 6) == "ATTACK")
            {
                if (room.monsters != null && room.monsters.Count > 0)
                {
                    if (s.ToUpper() == "ATTACK")
                    {
                        writeColor(ConsoleColor.Red, string.Format("You start attacking {0}.\n", room.monsters[0].name));
                    }
                    else
                    if (s.Length > 7 & s.Substring(0,7).ToUpper() == "ATTACK ")
                    {
                        string target = s.Substring(7).ToLower();
                        foreach (var item in room.monsters)
                        {
                            if (item.name.ToUpper() == target.ToUpper())
                            {
                                Console.WriteLine("You start attacking {0}.", target);
                                break;
                            }
                        }
                    }
                    
                    
                }
                else
                {
                    Console.WriteLine("There isn't anything to attack here.");
                }
            }

            // For Testing Purposes
            if (s.ToUpper() == "LEVELUP")
            {
                player.levelUp();
            }

            if (s.ToUpper() == "STATUS")
            {
                player.showStatus();
            }

            if (s.ToUpper() == "EXPERIENCE")
            {
                player.showExp();
            }

            if (s.ToUpper() == "INVENTORY")
            {
                player.showInventory();
            }

            if (s.ToUpper() == "EXIT" || s.ToUpper() == "QUIT")
                running = false;
        }

        static void pause()
        {
            Console.WriteLine("Press any key to continue...\n");
            Console.ReadKey();
        }

        static void writeColor(ConsoleColor color, string s)
        {
            Console.ForegroundColor = color;
            Console.Write(s);
        }

        static void initialConfig()
        {
            // Initial Configuration
            Console.Title = "Castle Grabber";
            Console.WindowWidth = 80;
            Console.WindowHeight = 40;
            Console.SetBufferSize(80, 40);
        }

        static void topMenu()
        {
            string input = "";

            Console.WriteLine(
                " C A S T L E  G R A B B E R \n\n" +
                "[E] . Enter realm of Myrgia \n" +
                "[X] . Exit Game\n");

            while (true)
            {
                input = Console.ReadLine();
                if (input.ToUpper() == "E")
                {
                    createPlayer();
                    break;
                }
                if (input.ToUpper() == "X") Environment.Exit(0);
            }
        }

        static void createPlayer()
        {
            int input = 0;

            Console.WriteLine(
                "[1] . Human\n" +
                "[2] . Elf\n" +
                "[3] . Dwarf\n"
                );

            while (input < 1 || input > 11)
            {
                Int32.TryParse(Console.ReadLine(), out input);
            }

            switch (input)
            {
                case 1:
                    player.race = "Human";
                    player.intelligence += 5;
                    player.charm += 5;
                    break;

                case 2:
                    player.race = "Elf";
                    player.agility += 5;
                    player.wisdom += 5;
                    break;

                case 3:
                    player.race = "Dwarf";
                    player.strength += 5;
                    player.stamina += 5;
                    break;
            }

            Console.WriteLine(
                "[1] . Warrior\n" +
                "[2] . Thief\n" +
                "[3] . Mage\n" +
                "[4] . Priest"
                );

            input = 0;
            while (input < 1 || input > 15)
            {
                Int32.TryParse(Console.ReadLine(), out input);
            }

            switch (input)
            {
                case 1:
                    player.job = "Warrior";
                    player.strength += 5;
                    player.stamina += 5;
                    break;

                case 2:
                    player.job = "Thief";
                    player.agility += 5;
                    player.charm += 5;
                    break;

                case 3:
                    player.job = "Mage";
                    player.intelligence += 5;
                    player.charm += 5;
                    break;

                case 4:
                    player.job = "Priest";
                    player.wisdom += 5;
                    player.stamina += 5;
                    break;
            }

        }

        static void roomChanged()
        {
            room.update(roomX);
            room.show(true);
        }

    } // End Program Class

} // End NameSpace