using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{

    public class Nether
    {
        static string[,] _netherschow = new string[120, 34];
        public string[,] NetherShown { get => _netherschow; }
        public Nether()
        {
            GenerateTreeain();
        }
        public void GenerateTreeain()
        {
            int yanzahl = new Random().Next(19, 20);
            int temp = yanzahl;
            for (int x = 0; x < _netherschow.GetLength(0); x++)
            {
                int neues_anzahl = new Random().Next(-1, 2);
                if (yanzahl - neues_anzahl > 19 && yanzahl - neues_anzahl < 32)
                {
                    yanzahl = yanzahl - neues_anzahl;
                    _netherschow[x, yanzahl] = "snr";
                    for (int i = yanzahl + 1; i < 34 && i < 34; i++)
                    {
                        _netherschow[x, i] = "snr";
                    }
                }
                else
                {
                    x--;
                }
            }
            GenerateBalazrods();
            yanzahl = new Random().Next(10, 14);
            for (int x = 0; x < _netherschow.GetLength(0); x++)
            {
                int neues_anzahl = new Random().Next(-1, 2);
                if (yanzahl - neues_anzahl > 0 && yanzahl - neues_anzahl < 14)
                {
                    yanzahl = yanzahl - neues_anzahl;
                    _netherschow[x, yanzahl] = "snr";
                    for (int i = yanzahl + 1; i >= 0; i--)
                    {
                        _netherschow[x, i] = "snr";
                    }
                }
                else
                {
                    x--;
                }
            }
            _netherschow[0, temp ] = "so";
            _netherschow[0, temp - 1] = "so";
            _netherschow[0, temp - 2] = "sop";
            _netherschow[1, temp ] = "p";

        }
        public void GenerateBalazrods()
        {
            int treeanzahl = new Random().Next(5, 7);

            for (int j = 0; j < treeanzahl; j++)
            {
                int x = new Random().Next(5, 115);
                int y = 0;
                for (int i = 2; i < 30 && String.IsNullOrEmpty(_netherschow[x, i]); i++)
                {
                    y = i;
                }
                if (y > 2)
                {
                    if (_netherschow[x, y + 1] == "snr")
                    {
                        _netherschow[x,y] = "br";
                    }
                    else
                    {
                        j--;
                    }

                }

            }
            Generatelava();
        }
        public void Generatelava()
        {
            int treeanzahl = new Random().Next(2, 4);

            for (int j = 0; j < treeanzahl; j++)
            {
                int x = new Random().Next(5, 115);
                int y = 0;
                bool doe = false;
                for (int i = 2; i < 30 && String.IsNullOrEmpty(_netherschow[x, i])&&!doe; i++)
                {
                    if (_netherschow[x, i + 1] == "v" || _netherschow[x, i + 1] == null)
                    {
                        for (int n = i; n < 33&&String.IsNullOrEmpty(_netherschow[x, n]); n++)
                        {
                        _netherschow[x, n] = "lv";
                            doe = true;
                        }

                    }
                    else
                    {
                        j--;
                    }
                    y = i;
                }

                _netherschow[x, y] = "lv";
            }
        }
    }
}
