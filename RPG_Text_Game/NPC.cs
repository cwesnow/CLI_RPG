using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Text_Game
{
    class NPC
    {
        public string name { get; private set; }
        public string description { get; private set; }

        public NPC(string Title, string Look) {
            this.name = Title;
            this.description = Look;
        }

        public void greet()
        {
            Console.WriteLine("{0} looks at you strangely, but doesn't say anything back.",this.name);
        }

        public void look()
        {
            Console.WriteLine(this.description);
        }
    }
}
