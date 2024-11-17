using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Inventar
    {
        public string[,] inventar { get; set; }
        public int Chosenslot { get; set; }
        public Inventar()
        {
            inventar = new string[9, 2];
            for (int i = 0; i < inventar.GetLength(0); i++)
            {
                inventar[i, 1] = "0";
            }
            for (int i = 0; i < inventar.GetLength(0); i++)
            {
                inventar[i, 0] = "-";
            }
        }
        public void Changeslot(int newslot)
        {
            Chosenslot=newslot-1;
        }
    }
}
