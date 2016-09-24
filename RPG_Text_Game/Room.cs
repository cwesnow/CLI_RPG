using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Text_Game
{
    class Room
    {
        public string title { get; set; }
        public string view { get; set; }
        public List<string> items = new List<string>();
        public List<string> exits = new List<string>();

        public void update(int x)
        {
            switch (x)
            {
                    // Floor 00, (x)East 00, (y)North 00
                case 0:
                    title = "Castle Grabber";
                    view = "Many Kings own land, but few will keep them";
                    break;

                case 10101:
                    title = "Room Number: 01 01 01";
                    view = "View";
                    items.Clear();
                    items.Add("1");
                    items.Add("2");
                    exits.Clear();
                    exits.Add("North");
                    exits.Add("NorthEast");
                    exits.Add("East");
                    break;

                case 10201:
                    title = "Room Number: 01 02 01";
                    view = "View";
                    items.Clear();
                    items.Add("1");
                    exits.Clear();
                    exits.Add("North");
                    exits.Add("Northeast");
                    exits.Add("East");
                    exits.Add("West");
                    exits.Add("Northwest");
                    break;

                case 10301:
                    title = "Room Number: 01 03 01";
                    view = "View";
                    items.Clear();
                    items.Add("1");
                    exits.Clear();
                    exits.Add("North");
                    exits.Add("Northwest");
                    exits.Add("West");
                    break;

                case 10102:
                    title = "Room Number: 01 01 02";
                    view = "View";
                    items.Clear();
                    exits.Clear();
                    exits.Add("North");
                    exits.Add("Northeast");
                    exits.Add("East");
                    exits.Add("Southeast");
                    exits.Add("South");
                    break;

                case 10103:
                    title = "Room Number: 01 01 03";
                    view = "View";
                    items.Clear();
                    items.Add("1");
                    exits.Clear();
                    exits.Add("East");
                    exits.Add("Southeast");
                    exits.Add("South");
                    break;

                case 10202:
                    title = "Room Number: 01 02 02";
                    view = "View";
                    items.Clear();
                    items.Add("1");
                    exits.Clear();
                    exits.Add("North");
                    exits.Add("Northeast");
                    exits.Add("East");
                    exits.Add("Southeast");
                    exits.Add("South");
                    exits.Add("Southwest");
                    exits.Add("West");
                    exits.Add("Northwest");
                    break;

                case 10203:
                    title = "Room Number: 01 02 03";
                    view = "View";
                    items.Clear();
                    items.Add("1");
                    exits.Clear();
                    exits.Add("East");
                    exits.Add("Southeast");
                    exits.Add("South");
                    exits.Add("Southwest");
                    exits.Add("West");
                    break;

                case 10302:
                    title = "Room Number: 01 03 02";
                    view = "View";
                    items.Clear();
                    items.Add("1");
                    exits.Clear();
                    exits.Add("North");
                    exits.Add("South");
                    exits.Add("Southwest");
                    exits.Add("West");
                    exits.Add("Northwest");
                    break;

                case 10303:
                    title = "Room Number: 01 03 03";
                    view = "View";
                    items.Clear();
                    items.Add("1");
                    exits.Clear();
                    exits.Add("South");
                    exits.Add("Southwest");
                    exits.Add("West");
                    break;

                default:
                    Console.WriteLine(
                        "Default Land: {0}", x);
                    break;
            } // End Switch
        }
    } // End Class

} // End Namespace
