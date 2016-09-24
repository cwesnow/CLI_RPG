using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Text_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            string input = "";

            do
            {
                Console.WriteLine("Your command: ");
                input = Console.ReadLine();
                if (input.ToLower() == "exit" || input.ToLower() == "quit") running = false;
            }
            while (running) ;
        }
    }
}
