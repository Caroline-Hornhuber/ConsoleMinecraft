using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class End
    {
        static string[,] _endschow = new string[120, 34];
        public string[,] EndShown { get => _endschow; }
        public (int, int) portal = (0, 0);
        public  Dragon d = new Dragon();
        public End()
        {
            GenerateTreeain();
            
        }
        public void GenerateTreeain()
        {
            {
                int yanzahl = new Random().Next(20, 22);
                for (int x = 0; x < _endschow.GetLength(0); x++)
                {
                    int neues_anzahl = new Random().Next(-1, 2);
                    if (yanzahl - neues_anzahl > 20 && yanzahl - neues_anzahl < 33)
                    {
                        int isneuzal = new Random().Next(0, 4);
                        if (isneuzal == 2)
                        {
                        yanzahl = yanzahl - neues_anzahl;
                        }
                        _endschow[x, yanzahl] = "se";
                        for (int i = yanzahl + 1; i < 34; i++)
                        {
                            _endschow[x, i] = "se";
                        }
                    }
                    else
                    {
                        x--;
                    }
                }

                int yy = 0;
                int xx = new Random().Next(20, 100);
                for (int j = 0; j < 31 && String.IsNullOrEmpty(_endschow[xx, j]); j++)
                {
                    yy = j;
                }
                _endschow[xx, yy] = "p";
            }
            Place_tower();
            Place_midportal();
        }
        public void Place_tower()
        {
            int treeanzahl = new Random().Next(3, 5);

            for (int j = 0; j < treeanzahl; j++)
            {
                int x = new Random().Next(5, 115);
                int y = 0;
                for (int i = 2; i < 30 && String.IsNullOrEmpty(_endschow[x, i]); i++)
                {
                    y = i;
                }
                if (y > 2)
                {
                    if (_endschow[x, y + 1] == "se")
                    {
                        PlacePillar( x, y);
                    }
                    else
                    {
                        j--;
                    }

                }

            }
        }
        private void PlacePillar(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            _endschow[x, y] = "so";
            int height = y-new Random().Next(4, 7);
            for (int i = y; i > height; i--)
            {
                _endschow[x, i] = "so";
            }
            x++;
            for (int i = height+1; _endschow[x,i]!="se"; i++)
            {
                _endschow[x, i] = "so";
            }
        }
        private void Place_midportal()
        {
            int xpl = new Random().Next(40, 80);
            int ypl = 0;
            bool done = false;
            for (int i = 0; i<31 && !done; i++)
            {
                if ((_endschow[xpl, i] != "v" && _endschow[xpl, i] != null))
                {
                    done = true;
                }
                ypl = i;
            }
            ypl -= 2;
            _endschow[xpl - 2, ypl] = "so";
            _endschow[xpl - 1, ypl + 1] = "so";
            _endschow[xpl, ypl + 1] = "so";
            _endschow[xpl, ypl] = "strprtl";
            portal.Item1 = xpl;
            portal.Item2 = ypl;
            _endschow[xpl, ypl - 1] = "so";
            _endschow[xpl + 1, ypl + 1] = "so";
            _endschow[xpl + 2, ypl] = "so";

        }
        public void PlaceDragon()
        {
            _endschow[d.pos.Item1-2, d.pos.Item2-1] = "v";
            _endschow[d.pos.Item1 - 1, d.pos.Item2 - 1] = "v";
            _endschow[d.pos.Item1 , d.pos.Item2 - 1] = "v";
            _endschow[d.pos.Item1+1, d.pos.Item2 - 1] = "v";

            _endschow[d.pos.Item1 -2, d.pos.Item2 ] = "v";
            if (d.dead)
            {
                _endschow[d.pos.Item1 - 1, d.pos.Item2] = "ed1";
                _endschow[d.pos.Item1, d.pos.Item2] = "ed1";
            }
            else if (d.facing)
            {
                _endschow[d.pos.Item1 - 1, d.pos.Item2] = "ed1";
                _endschow[d.pos.Item1, d.pos.Item2] = "ed2";
            }
            else
            {
                _endschow[d.pos.Item1 - 1, d.pos.Item2] = "ed2";
                _endschow[d.pos.Item1, d.pos.Item2] = "ed1";
            }
            _endschow[d.pos.Item1+1, d.pos.Item2] = "v";

            _endschow[d.pos.Item1 - 2, d.pos.Item2 + 1] = "v";
            _endschow[d.pos.Item1 - 1, d.pos.Item2 + 1] = "ed1";
            _endschow[d.pos.Item1    , d.pos.Item2 + 1] = "ed1";
            _endschow[d.pos.Item1 + 1, d.pos.Item2 + 1] = "v";

            _endschow[d.pos.Item1 - 2, d.pos.Item2 + 2] = "v";
            _endschow[d.pos.Item1 - 1, d.pos.Item2 + 2] = "v";
            _endschow[d.pos.Item1    , d.pos.Item2 + 2] = "v";
            _endschow[d.pos.Item1 + 1, d.pos.Item2 + 2] = "v";


        }
    }
}
