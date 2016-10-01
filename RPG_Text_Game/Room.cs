using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG_Text_Game
{
    class Room
    {
        public string title { get; set; }
        public string view { get; set; }
        public List<NPC> npc = new List<NPC>();
        public List<string> monsters = new List<string>();
        public List<string> items = new List<string>();
        public List<string> exits = new List<string>();

        public void show(bool verbose)
        {
            // The room Title
            writeColor(ConsoleColor.Cyan, title + "\n");

            // The room Description
            if (verbose)
            {
                writeColor(ConsoleColor.Gray, "    " + view + "\n");
            }

            // You notice Items here.
            if (items.Count > 0)
            {
                writeColor(ConsoleColor.DarkCyan, "Noticed: ");
                foreach (var item in items)
                {

                    if (item == items.LastOrDefault<string>())
                    {
                        Console.WriteLine("{0} here.", item);
                    }
                    else
                    {
                        Console.Write("{0}, ", item);
                    }
                }
            }

            // Also here: NPC.
            if (npc.Count > 0)
            {
                writeColor(ConsoleColor.Magenta, "Also here: ");

                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (var item in npc)
                {
                    if (item == npc.LastOrDefault<NPC>())
                    {
                        Console.Write("{0}", item.name);
                        writeColor(ConsoleColor.Magenta, ".\n");
                    }
                    else
                    {
                        Console.Write("{0}, ", item.name);
                    }
                }
            }

            // Threats: Monsters.
            if (monsters.Count > 0)
            {
                writeColor(ConsoleColor.DarkRed, "Also here: ");

                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var item in monsters)
                {
                    if (item == monsters.LastOrDefault<string>())
                    {
                        Console.Write("{0}", item);
                        writeColor(ConsoleColor.Red, ".\n");
                    }
                    else
                    {
                        Console.Write("{0}, ", item);
                    }
                }
            }

            // Obvious exits: direction
            writeColor(ConsoleColor.Green, "Obvious exits: ");
            foreach (var exit in exits)
            {
                if (exit == exits.LastOrDefault<string>())
                {
                    Console.WriteLine(exit);
                }
                else
                {
                    Console.Write("{0}, ", exit);
                }
            }

        } // End Show()

        public void update(int x)
        {
            // Reset Room Objects
            items.Clear();
            npc.Clear();
            monsters.Clear();
            exits.Clear();

            switch (x)
            {
                // X = Map:00, Floor:0, X:00, Y:00
                case 0100110:
                    title = "Rockville NW Tower";
                    view = "This tower provides an excellent view for miles.";
                    npc.Add( new NPC("Guard", "This seasoned soldier looks like he could kill somebody without thinking about it"));
                    exits.Add("southeast");
                    break;

                case 0100510:
                    title = "North Pebble Way";
                    view = "The northern path is currently blocked.";
                    exits.Add("south");
                    break;

                case 0101010:
                    title = "Rockville NE Tower";
                    view = "This tower provides an excellent view for miles.";
                    npc.Add( new NPC("Guard","This seasoned soldier looks like he could kill somebody without thinking about it"));
                    exits.Add("southwest");
                    break;

                case 0100209:
                    title = "Corner of Boulder Way and Eagles Way";
                    view =
                        "This corner connects North Boulder Way with West Eagle Way" +
                        "A guard tower sits to the Northwest.";
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("northwest");
                    break;

                case 0100309:
                    title = "West Eagles Way";
                    view = "You see the Mayor's house to the south.";
                    exits.Add("east");
                    exits.Add("west");
                    break;

                case 0100409:
                    title = "West Eagles Way";
                    view = "You see a Gambling hall to the south.";
                    exits.Add("east");
                    exits.Add("west");
                    break;

                case 0100509:
                    title = "Intersection of Eagles Way and North Pebble Way";
                    view =
                        "This intersection connects Pebble Way and Eagles Way.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100609:
                    title = "East Eagles Way";
                    view = "You see a Spell Shop to the south.";
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100709:
                    title = "East Eagles Way";
                    view = "You see a warriors training hall to the south.";
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100809:
                    title = "East Eagles Way";
                    view = "You see a thieves training hall to the south.";
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100909:
                    title = "Corner of East Eagles Way and North Gravel Way";
                    view =
                        "This corner connects North Gravel Way with East Eagle Way" +
                        "A guard tower sits to the Northeast.";
                    exits.Add("south");
                    exits.Add("west");
                    exits.Add("northeast");
                    break;

                case 0100208:
                    title = "North Boulder Way";
                    view = "The streets runs from North to South, and you see the Mayor's house to your east.";
                    exits.Add("north");
                    exits.Add("south");
                    break;

                case 0100308:
                    title = "Mayor's House, Back Room";
                    view = "This lavish room has been decorated with all manner of finery.";
                    npc.Add( new NPC("Mayor","His broad and stern face shows a man that's spent many years in thought."));
                    exits.Add("south");
                    break;

                case 0100408:
                    title = "Sweet Pete's Gambling House";
                    view = "This small room is packed with an assortment of games.";
                    npc.Add( new NPC("Gambling Man","A slick looking city boy that seems totally in control here."));
                    items.Add("Cards");
                    exits.Add("east");
                    break;
                
                case 0100508:
                    title = "North Pebble Way";
                    view = "You see a Gambling Hall to the West,";
                    exits.Add("north");
                    exits.Add("south");
                    exits.Add("west");
                    break;
                
                case 0100608:
                    title = "Treexi's Spell Shop - Harmful Stuff";
                    view = "This room is covered in Scrolls and Books.";
                    npc.Add( new NPC("Treexi","This crazy woman seems to mutter fireballs and freezing storms while making strange gestures in the mirror."));
                    exits.Add("north");
                    break;

                case 0100708:
                    title = "Warrior Trainer";
                    view = "This room is full of armor and various weapons.";
                    npc.Add( new NPC("Master Warrior","This massive dwarven warrior shifts his armor with ease as his two handed axe rests across his entire back like an after thought."));
                    exits.Add("north");
                    break;
                
                case 0100808:
                    title = "Thief Trainer";
                    view = "This room is dimly lit, and you feel like somebody is in the shadows...";
                    npc.Add( new NPC("Master Thief","This shadowy figure is concealed with dark clothing, and seems to rather be left alone in the dark."));
                    exits.Add("north");
                    break;

                case 0100908:
                    title = "North Gravel Way";
                    view = "You see the academy to your west.";
                    exits.Add("north");
                    exits.Add("south");
                    break;

                case 0100207:
                    title = "North Boulder Way";
                    view = "You see the Major's house to the east.";
                    exits.Add("north");
                    exits.Add("south");
                    break;

                case 0100307:
                    title = "Mayor's House";
                    view = "This is the mayor's public room";
                    npc.Add( new NPC("Mayor", "His broad and stern face shows a man that's spent many years in thought."));
                    exits.Add("north");
                    exits.Add("south");
                    break;

                case 0100407:
                    title = "Home";
                    view = "This run down old home is your personal sanctuary of rest.";
                    items.Add("Favorite Chair");
                    items.Add("Comfy Beds");
                    items.Add("Last nights ToFu");
                    npc.Add( new NPC("Mom","Clothes are always stained, but her smile never stops shining for you."));
                    npc.Add(new NPC("Dad","Stains, and ripped coverals might make him seem uncool, but he never lets you down."));
                    npc.Add(new NPC("Fluffy","Her black fur makes it hard to see much detail."));
                    npc.Add(new NPC("Woofy","His brown short hair and fierce eyes let's you know he'll be loyal to the ends of the earth for you."));
                    exits.Add("south");
                    exits.Add("east");
                    break;

                case 0100507:
                    title = "North Pebble Way";
                    view = "You see a spell shop to the East, and your house to the West.";
                    exits.Add("north");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100607:
                    title = "Chinthalai's Spell Shop - Helpful Stuff";
                    view = "You see Scrolls, and Books lining every wall and counter space.";
                    npc.Add(new NPC("Chinthalai", "Her favorite tune hums innocently as she carries about the shop helping everyone become better."));
                    exits.Add("south");
                    break;

                case 0100707:
                    title = "Mage Trainer";
                    view = "Various scrolls and items scatter this room, " +
                        "and there's a faint taste of sulfur in the air.";
                    npc.Add( new NPC("Master Mage","His blackened robes shine with strange writings and symbols, and his gnarled staff feels like a viper in waiting... ready to strike."));
                    exits.Add("south");
                    break;

                case 0100807:
                    title = "Priest Trainer";
                    view = "Holy chants fill you with inner peace and resolve.";
                    npc.Add( new NPC("Master Priest","The most holy wears robes of the purest whites and speaks in the calmest of whispers."));
                    exits.Add("south");
                    break;

                case 0100907:
                    title = "North Gravel Way";
                    view = "You see the Academy to your West.";
                    exits.Add("north");
                    exits.Add("south");
                    break;

                case 0100106:
                    title = "West Hawks Way";
                    view = "The western path is currently blocked.";
                    exits.Add("east");
                    break;

                case 0100206:
                    title = "Intersection of Boulders Way and West Hawks Way";
                    view = "This intersection connects Boulders Way with West Hawks Way.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100306:
                    title = "West Hawks Way";
                    view = "This street runs West to East." +
                        "You see the Major's House to the North, and a Weapon's Shop to the South.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("west");
                    break;

                case 0100406:
                    title = "West Hawks Way";
                    view = "You see your house to the North and the Bank to the South.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100506:
                    title = "Intersection of Pebbles Way and Hawks Way";
                    view = "This is the Town Square of Rockville.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100606:
                    title = "East Hawks Way";
                    view = "You see a spell shop to the North, and a Gambling Hall to the South.";
                    exits.Add("north");
                    exits.Add("west");
                    exits.Add("east");
                    break;

                case 0100706:
                    title = "East Hawks Way";
                    view = "You see a Mage Trainer to the North, and a Potion Shop to the South.";
                    exits.Add("north");
                    exits.Add("west");
                    exits.Add("south");
                    exits.Add("east");
                    break;

                case 0100806:
                    title = "East Hawks Way";
                    view = "You see a Priest Trainer to the North, and an Armor shop to the south.";
                    exits.Add("north");
                    exits.Add("west");
                    exits.Add("east");
                    break;

                case 0100906:
                    title = "Intersection of Gravel Way and East Hawks Way.";
                    view = "This intersection connects Gravel Way with East Hawks Way.";
                    exits.Add("north");
                    exits.Add("west");
                    exits.Add("south");
                    exits.Add("east");
                    break;

                case 0101006:
                    title = "Hawks Way";
                    view = "The eastern path is currently blocked.";
                    exits.Add("west");
                    break;

                case 0100205:
                    title = "South Boulder Way";
                    view = "You see a sword shop to the East.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("south");
                    break;
                
                case 0100305:
                    title = "Gurtz Weapons - Sword Shop";
                    view = "You see several swords and daggers on display.";
                    npc.Add( new NPC("Gurtz","This slender and quick moving Elf moves almost as if swords are just an extension of his arms."));
                    exits.Add("west");
                    break;
                
                case 0100405:
                    title = "Rockville Bank";
                    view = "The bank will keep your money away from thieves and monsters.";
                    npc.Add( new NPC("Hueik", "This old man is well dressed and speaks with the utmost respect with all his customers."));
                    exits.Add("north");
                    exits.Add("east");
                    break;
                
                case 0100505:
                    title = "South Pebble Way";
                    view = "You see a bank to the West, and gambling halls to the East.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("west");
                    break;
                
                case 0100605:
                    title = "Verksaas Casino";
                    view = "The crowd is mostly gathered around a few tables playing a card game.";
                    npc.Add(new NPC("Verksaas","This heavy set man dresses like a regular greasy city politician.  His eyes constantly darting over everyone, as he tries to talk to everyone."));
                    items.Add("Card Table");
                    exits.Add("west");
                    break;
                
                case 0100705:
                    title = "Myrrucki's Potions";
                    view = "A series of strangely colored and shaped bottles line this shops walls. " +
                        "Along the counter top it says \"It's not if I can afford it, but if I can afford not to have it tomorrow\"";
                    npc.Add(new NPC("Myrrucki", "This wild crazy old man seems to have everything in his shop."));
                    exits.Add("north");
                    exits.Add("south");
                    break;

                case 0100805:
                    title = "Kuirog's Armor - Leather Shop";
                    view = "Proudly displayed along the walls are a series of different kinds of armor sets. " +
                        "Basic leather wraps and simple tools fill out the lower counters, " +
                        "while the more advanced combat leathers hang up proudly along the walls.";
                    npc.Add(new NPC("Kuirog","His smooth skin fits into tight leathers betters than anyone else in town."));
                    exits.Add("east");
                    break;

                case 0100905:
                    title = "South Gravel Way";
                    view = "You see an leather shop to the West.";
                    exits.Add("north");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100204:
                    title = "South Boulder Way";
                    view = "You see a mace shop to the East";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("south");
                    break;

                case 0100304:
                    title = "Origou Weapons - Mace Shop";
                    view = "An assortment of steel hammers and flails list the walls here.";
                    npc.Add( new NPC("Origou","This strong and silent type keeps a massive battle flail at his side while wearing full plate armor all day."));
                    exits.Add("west");
                    break;

                case 0100404:
                    title = "Zimmzee's Potions";
                    view = "Oddly colored potions flicker and flash in this shop. " +
                        "The potions here are mostly for children, and pranks.";
                    npc.Add( new NPC("Zimmzee","Her well practiced hands have years of experience, but her favorite part of the day is the little splash of fun."));
                    exits.Add("east");
                    break;

                case 0100504:
                    title = "South Pebble Way";
                    view = "This street runs South and North. " +
                        "You see a potion shop to the West and a Gambling Hall to the East.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100604:
                    title = "Nuukari's Gambling Hall";
                    view = "Strange contraptions line up the walls with a strange stick poking out. " +
                        "You see people pulling down the lever and an array of lights and symbols whirling." +
                        "Maybe you should try it out, it seems to be interesting.";
                    npc.Add(new NPC("Nuukari","A dark set of leathers fit tightly around her, and you see glimmers of ornate jewelry as she moves.") );
                    items.Add("Slot Machine");
                    exits.Add("west");
                    break;

                case 0100704:
                    title = "Myrrucki's Potions - The Back Room";
                    view = "Long shelves line this room with a wide assortment of colors, shapes, and textures.";
                    npc.Add( new NPC("Myrrucki", "This wild crazy old man seems to have everything in his shop."));
                    exits.Add("north");
                    break;

                case 0100804:
                    title = "Kuirog's Armor - ScaleMail Shop";
                    view = "Armor lines the walls with metal chains or beads ornately woven together. " +
                        "It's designed to be lighter than Full Armor, but offer better protection than Leather.";
                    npc.Add( new NPC("Kuirog", "A well toned and athletic warrior makes wearing scalemail look like a new trend in town."));
                    exits.Add("east");
                    break;

                case 0100904:
                    title = "South Gravel Way";
                    view = "You see a scalemail shop to the West.";
                    exits.Add("north");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100203:
                    title = "Boulder Way";
                    view = "You see a polearm shop to the East.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("south");
                    break;

                case 0100303:
                    title = "Phryzee Weapons - Polearms";
                    view = "This shop is full of large heavy weapons " +
                        "designed for maximum power and a range advantage.";
                    npc.Add( new NPC("Phryzee","This large warrior hefts his weapons with grace and ease.") );
                    exits.Add("west");
                    break;

                case 0100403:
                    title = "Adlymn's Potions";
                    view = "This almost boring display of potions seems popular with adventurers. " +
                    "I wonder what secrets they hold.";
                    npc.Add( new NPC("Adlymn","This old man seems worldly, and like he holds many secrets about his craft."));
                    exits.Add("east");
                    break;

                case 0100503:
                    title = "South Pebble Way";
                    view = "You see a potion shop to the West, and a gambling hall to the East.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100603:
                    title = "Druukia's Casino";
                    view = "This dice hall is full of rattling cups and crazy bidders.";
                    items.Add("Dice");
                    exits.Add("west");
                    break;

                case 0100703:
                    title = "Jorik's Armor - Shields";
                    view =
                        "Shields of every kind fill this room, small to large and some extremely large too.";
                    npc.Add( new NPC("Jorik", "His lean muscles and incredible size makes it easy for him to work on the heaviest of armors."));
                    exits.Add("east");
                    break;

                case 0100803:
                    title = "Jorik's Armor - Plate Shop";
                    view = "Heavy duty armor fills this room, and weighs heavily on sturdy stands. " +
                        "It offers complete protection, along with soft lining to soften brutal blows.";
                    npc.Add( new NPC("Jorik", "His lean muscles and incredible size makes it easy for him to work on the heaviest of armors."));
                    exits.Add("east");
                    exits.Add("west");
                    break;

                case 0100903:
                    title = "South Gravel Way";
                    view = "You see a plate shop to the West.";
                    exits.Add("north");
                    exits.Add("south");
                    exits.Add("west");
                    break;

                case 0100202:
                    title = "Corner of Boulder Way and Ravens Way";
                    view =
                        "This corner connects South Boulder Way with West Ravens Way" +
                        "A guard tower sits to the Southwest.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("southwest");
                    break;

                case 0100302:
                    title = "West Ravens Way";
                    view = "You see a weapons shop to the North.";
                    exits.Add("east");
                    exits.Add("west");
                    break;

                case 0100402:
                    title = "West Ravens Way";
                    view = "You see a Potion Shop to the North.";
                    exits.Add("east");
                    exits.Add("west");
                    break;
                
                case 0100502:
                    title = "Intersection of South Pebble Way and Ravens Way";
                    view = "This intersection connects South Pebble Way with Ravens Way.";
                    exits.Add("north");
                    exits.Add("east");
                    exits.Add("south");
                    exits.Add("west");
                    break;
                
                case 0100602:
                    title = "East Ravens Way";
                    view = "You see a gambling hall to the North.";
                    exits.Add("east");
                    exits.Add("west");
                    break;
                
                case 0100702:
                    title = "East Ravens Way";
                    view = "You see an armor shop to the North.";
                    exits.Add("east");
                    exits.Add("west");
                    break;
                
                case 0100802:
                    title = "East Ravens Way";
                    view = "You see an armor shop to the North.";
                    exits.Add("east");
                    exits.Add("west");
                    break;
                
                case 0100902:
                    title = "Corner of Gravel Way and Ravens Way";
                    view =
                        "This corner connects South Gravel Way with East Ravens Way" +
                        "A guard tower sits to the Southeast.";
                    exits.Add("north");
                    exits.Add("southeast");
                    exits.Add("west");
                    break;

                case 0100101:
                    title = "Rockville SW Tower";
                    view = "This tower provides an excellent view for miles.";
                    npc.Add( new NPC("Guard", "This seasoned soldier looks like he could kill somebody without thinking about it"));
                    exits.Add("northeast");
                    break;

                case 0100501:
                    title = "South Pebble Way";
                    view = "";
                    exits.Add("north");
                    break;

                case 0101001:
                    title = "Rockville SE Tower";
                    view = "This tower provides an excellent view for miles.";
                    npc.Add( new NPC("Guard", "This seasoned soldier looks like he could kill somebody without thinking about it"));
                    exits.Add("northwest");
                    break;
                
                default:
                    Console.WriteLine(
                        "Error! This room {0} does not exist yet.", x);
                    break;

            } // End Switch

        } // End Update()

        static void writeColor(ConsoleColor color, string s)
        {
            Console.ForegroundColor = color;
            Console.Write(s);
        }

    } // End Class

} // End Namespace
