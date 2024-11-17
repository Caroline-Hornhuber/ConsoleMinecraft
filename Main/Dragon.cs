using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Dragon
    {
        public (int, int) pos =  (0,0);
        public int health { get; set; }
        public bool facing { get; set; }//tru rechts und fals lings
        public bool dead { get; set; }
        
        public Dragon()
        {
            pos.Item1 = 60;
            pos.Item2 = 10;
            health = 10;
            facing = true;
        }
        public void DragonHelthBar()
        {
            Console.SetCursorPosition(50, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Ender Dragon");
            if (!dead)
            {
            for (int i = 0; i < 10; i++)
            {
                if (i<=health)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("❤");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("❤");
                }
            }
            }
            else
            {
                Console.Write("dead");
            }

        }

    }
}
