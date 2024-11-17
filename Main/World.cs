using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Main
{
    class World
    {
        static string[,] _worldschow = new string[120,34];
        public string[,] WorldShown { get => _worldschow; }
        public (int, int) cursor = (0, 0);
        public Player P { get;  }
        public World()
        {
            GenerateTreeain();
            GenerateTrees();
            GenerateVillage();
            GenerateOres();
            PlaceStronghold();
        }
        public void Move(ConsoleKeyInfo pos,  string[,]world, ref Player P,int biome,int dimension)
        {
            if (pos.KeyChar == 'a' && P.X - 1 < 0)
            {
                return;
            } 
            else if (pos.KeyChar == 'd' && P.X + 1 >= world.GetLength(0))
            {
                return;
            }

            switch (pos.KeyChar)
            {
                case 'a':

                    if ((world[P.X - 1, P.Y] == null || world[P.X - 1, P.Y] == "v" || world[P.X-1,P.Y]=="b" ))
                    {
                        if (world[P.X, P.Y] == "bp")
                        {
                            world[P.X, P.Y] = "b";
                            Console.SetCursorPosition(P.X, P.Y+1);
                            if (biome == 1 || biome == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write("⚘");
                            }
                            else if (biome == 2)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("▆");
                            }
                            else if (biome == 3)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("⚘");
                            }
                        }
                        else
                        {
                            world[P.X, P.Y] = "v";
                        }
                        P.X--;
                        if (world[P.X, P.Y] == "b")
                        {
                            world[P.X, P.Y] = "bp";
                        }
                        else
                        {
                        world[P.X, P.Y] = "p";                                
                        }
                    }
                    break;
                case 'd':
                    if ((world[P.X + 1, P.Y] == null || world[P.X + 1, P.Y] == "v" || world[P.X + 1, P.Y] == "b"))
                    {
                        if (world[P.X, P.Y] == "bp")
                        {
                            world[P.X, P.Y] = "b";
                            Console.SetCursorPosition(P.X, P.Y + 1);
                            if (biome == 1 || biome == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write("⚘");
                            }
                            else if (biome == 2)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("▆");
                            }
                            else if (biome == 3)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("⚘");
                            }
                        }
                        else
                        {
                            world[P.X, P.Y] = "v";
                        }
                        P.X++;
                        if (world[P.X, P.Y] == "b")
                        {
                            world[P.X, P.Y] = "bp";
                        }
                        else
                        {
                            world[P.X, P.Y] = "p";
                        }
                    }
                    break;
            }
            if (pos.KeyChar == 'w')
            {
                if (P.Y > 0 && P.Y < 33)
                {
                    if ((world[P.X, P.Y - 1] == null || world[P.X, P.Y - 1] == "v") && (world[P.X, P.Y + 2] != "v" | (world[P.X, P.Y + 1] != "v")))
                    {
                        if (world[P.X, P.Y] == "bp")
                        {
                            world[P.X, P.Y] = "b";
                            Console.SetCursorPosition(P.X, P.Y + 1);
                            if (biome == 1 || biome == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write("⚘");
                            }
                            else if (biome == 2)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("▆");
                            }
                            else if (biome == 3)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("⚘");
                            }
                        }
                        else if (world[P.X, P.Y] == "p")
                        {
                        world[P.X, P.Y] = "v";
                        }
                        P.Y--;
                        world[P.X, P.Y] = "p";

                    }
                }
            }
            else
            {
                for (int i = P.Y + 1; (world[P.X, P.Y + 1] == null || world[P.X, P.Y + 1] == "v" || world[P.X,P.Y+1]=="b") && i < 34; i++)
                {
                    world[P.X, P.Y] = "v";
                    
                    P.Y = i;
                    if (world[P.X, P.Y] == "b")
                    {
                        world[P.X, P.Y] = "bp";
                    }
                    else
                    {
                        world[P.X, P.Y] = "p";
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(121, 3);
            Console.Write($"x:{P.X}   y:{P.Y}   ");
        }
        public void MoveCurser(ConsoleKeyInfo pos,Player P,int range )
        {
            if (pos.Key == ConsoleKey.LeftArrow)
            {
                if (cursor.Item1-1>=0    && cursor.Item1-1>(P.X-range))
                {
                    cursor.Item1--;
                }
            }
            else if (pos.Key==ConsoleKey.UpArrow)
            {
                if (cursor.Item2 - 1 > 0 && cursor.Item2 - 1 > (P.Y - range))
                {
                    cursor.Item2--;
                }
            }
            else if (pos.Key==ConsoleKey.RightArrow)
            {
                if (cursor.Item1 + 1 < 120 && cursor.Item1 + 1 < (P.X + range))
                {
                    cursor.Item1++;
                }
            }
            else if (pos.Key == ConsoleKey.DownArrow)
            {
                if (cursor.Item2 + 1 < 34 && cursor.Item2 + 1 < (P.Y + range))
                {
                    cursor.Item2++;
                }
            }
        }
        public void DoAction(ConsoleKeyInfo pos, Player P, Inventar inventar, string[,] world, ref bool changedimension,ref End e)
        {
            
            if (pos.KeyChar=='q')
            {
                if (((cursor.Item1 != P.X || cursor.Item2 != P.Y) && (world[cursor.Item1, cursor.Item2] != "v" && world[cursor.Item1,cursor.Item2]!=null))&&cursor.Item2+1<34)
                {
                    if (world[cursor.Item1, cursor.Item2] == "sop")
                    {
                        if (Program.Dimension == 1 || Program.Dimension == 0)
                        {
                            Program.Dimension = 2;
                            changedimension = true;
                        }
                        else
                        {
                            Program.Dimension = 1;
                            changedimension = true;
                        }
                    }
                    else if (world[cursor.Item1, cursor.Item2] == "strsh")
                    {
                        if (inventar.inventar[inventar.Chosenslot, 0] == "br"&& cursor.Item2 < 118)
                        {
                            world[cursor.Item1, cursor.Item2] = "strshac";
                            Program.strongholdplaced++;
                            Console.SetCursorPosition(cursor.Item1, cursor.Item2 + 1);
                            Program.Printthing(world, cursor.Item1, cursor.Item2);
                            int lol = Convert.ToInt32(inventar.inventar[inventar.Chosenslot, 1]) - 1;
                            inventar.inventar[inventar.Chosenslot, 1] = Convert.ToString(lol);
                            if (inventar.inventar[inventar.Chosenslot, 1] == "0")
                            {
                                inventar.inventar[inventar.Chosenslot, 0] = "0";
                            }
                            if (Program.strongholdplaced==4)
                            {
                                bool pubg = false;
                                for (int i = 0; i < world.GetLength(1) && !pubg; i++)
                                {
                                    for (int j = 0; j < world.GetLength(0) && !pubg; j++)
                                    {
                                        if (world[j, i] == "strprtl" )
                                        {
                                            pubg = true;
                                            world[j, i] = "strprtlac";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (world[cursor.Item1,cursor.Item2]== "strprtlac")
                    {
                        if (Program.Dimension == 1 || Program.Dimension == 0)
                        {
                            Program.Dimension = 3;
                            changedimension = true;
                        }
                        else
                        {
                            Program.Dimension = 1;
                            changedimension = true;
                        }
                    }
                    else if (world[cursor.Item1, cursor.Item2] == "strshac"|| world[cursor.Item1, cursor.Item2] == "str-"|| world[cursor.Item1, cursor.Item2] == "str|"|| world[cursor.Item1, cursor.Item2] == "strprtl")
                    {

                    }
                    else if (world[cursor.Item1, cursor.Item2] == "ed1" || world[cursor.Item1, cursor.Item2] == "ed2")
                    {
                        e.d.health--;
                    }
                    else if (!IsInvFull(inventar.inventar, world[cursor.Item1,cursor.Item2]))
                    {

                        bool done = false;
                        for (int i = 0; i < inventar.inventar.GetLength(0)&&!done; i++)
                        {
                            if ((inventar.inventar[i, 0] == "0" || inventar.inventar[i, 0] == "-" || (inventar.inventar[i,0]== world[cursor.Item1, cursor.Item2] &&Convert.ToInt32( inventar.inventar[i,1])<64)))
                            {
                                inventar.inventar[i, 0] = world[cursor.Item1, cursor.Item2];
                                int lol = Convert.ToInt32(inventar.inventar[i, 1]) + 1;
                                inventar.inventar[i, 1] = Convert.ToString(lol);
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(cursor.Item1, cursor.Item2 + 1);
                                Console.WriteLine(" ");
                                world[cursor.Item1, cursor.Item2] = "v";
                                done = true;
                            }
                        }

                        for (int i = P.Y + 1; (world[P.X, P.Y + 1] == null || world[P.X, P.Y + 1] == "v" || world[P.X, P.Y + 1] == "b") && i < 34; i++)
                        {
                            world[P.X, P.Y] = "v";

                            P.Y = i;
                            if (world[P.X, P.Y] == "b")
                            {
                                world[P.X, P.Y] = "bp";
                            }
                            else
                            {
                                world[P.X, P.Y] = "p";
                            }
                        }
                        cursor.Item1 = P.X;
                        cursor.Item2 = P.Y;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Inv full!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Program.PrintWorld(world);
                }// net selber abeun
            }//abbauen
            else if (pos.KeyChar=='e')
            {
                if (((cursor.Item1 != P.X || cursor.Item2 != P.Y) && (world[cursor.Item1, cursor.Item2] == "v" || world[cursor.Item1, cursor.Item2] == null)) && cursor.Item2 + 1 < 34)
                {
                    if (Convert.ToInt32(inventar.inventar[inventar.Chosenslot,1])>0)
                    {
                        if (cursor.Item2<118)
                        {
                            if (world[cursor.Item1,cursor.Item2+2]=="so"&& world[cursor.Item1, cursor.Item2+2] == "so")
                            {
                                world[cursor.Item1, cursor.Item2] = "sop";
                            }
                            else
                            {
                                world[cursor.Item1, cursor.Item2] = inventar.inventar[inventar.Chosenslot, 0];
                            }
                        }
                        else
                        {
                            world[cursor.Item1, cursor.Item2] = inventar.inventar[inventar.Chosenslot, 0];
                        }


                        Console.SetCursorPosition(cursor.Item1, cursor.Item2 + 1);
                        Program.Printthing(world, cursor.Item1, cursor.Item2);
                        int lol = Convert.ToInt32(inventar.inventar[inventar.Chosenslot, 1]) - 1;
                        inventar.inventar[inventar.Chosenslot, 1] = Convert.ToString(lol);
                        if (inventar.inventar[inventar.Chosenslot, 1] == "0")
                        {
                            inventar.inventar[inventar.Chosenslot, 0] = "0";
                        }
                        cursor.Item1 = P.X;
                        cursor.Item2 = P.Y;
                    }
                }
            }
        }
        public bool IsInvFull(string[,] inv,string type)
        {
            bool isfull = true;
            for (int i = 0; i < inv.GetLength(1); i++)
            {
                if (inv[i, 1] != "v" || inv[i,1]=="-")
                {
                    isfull = false;
                }
                else if (inv[i,1]==type)
                {

                }
            }
            return isfull;
        }
        public void GenerateTrees()
        {
            int treeanzahl = new Random().Next(4, 7);

            for (int j = 0; j < treeanzahl; j++)
            {
                int x = new Random().Next(5, 115);
                int y = 0;
                for (int i = 2; i < 30 && String.IsNullOrEmpty(_worldschow[x, i ]); i++)
                {
                    y = i;
                }
                if (y>2)
                {
                    if (_worldschow[x, y +1] == "g")
                    {
                        _worldschow = PlaceTree(_worldschow, x, y);
                    }
                    else
                    {
                        j--;
                    }

                }

            }
            //BLUMEN
            treeanzahl = new Random().Next(5, 10);
            for (int i = 0; i < treeanzahl; i++)
            {
                int y = 0;
                int x = new Random().Next(20, 100);
                for (int j = 0; j < 33 && String.IsNullOrEmpty(_worldschow[x, j]); j++)
                {
                    y = j;
                }
                if (_worldschow[x,y+1]=="g")
                {
                _worldschow[x, y] = "b";
                }
                else
                {
                    i--;
                }


            }
            
        }
        static string[,] PlaceTree(string[,] world, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            world[x, y] = "h";
            y--;
            world[x, y] = "h";
            y--;
            world[x, y] = "h";
            y++;
            x -= 2;
            world[x, y] = "l";
            x++;
            world[x, y] = "l";
            y--;
            x--;
            world[x, y] = "l";
            x++;
            world[x, y] = "l";
            x += 2;
            y++;
            world[x, y] = "l";
            x++;
            world[x, y] = "l";
            y--;
            x -= 2;
            world[x, y] = "l";
            x++;
            world[x, y] = "l";
            x++;
            world[x, y] = "l";
            x -= 3;
            y--;
            world[x, y] = "l";
            x++;
            world[x, y] = "l";
            x++;
            world[x, y] = "l";
            return world;
        }
        public void GenerateTreeain()
        {
            int yanzahl = new Random().Next(5, 20);
            for (int x = 0; x < _worldschow.GetLength(0); x++)
            {
                int neues_anzahl = new Random().Next(-1, 2);
                if (yanzahl - neues_anzahl > 5 && yanzahl - neues_anzahl < 34)
                {
                    yanzahl = yanzahl - neues_anzahl;
                    _worldschow[x, yanzahl] = "g";
                    for (int i = yanzahl + 1; i < yanzahl + 6 && i < 34; i++)
                    {
                        _worldschow[x, i] = "d";
                    }
                    for (int i = yanzahl + 3; i < 34; i++)
                    {
                        _worldschow[x, i] = "s";
                    }
                }
                else
                {
                    x--;
                }
            }
        }
        public void SpawnPlayer(Player p )
        {
            int y = 0;
            int x = new Random().Next(20, 100);
            for (int j = 0; j < 31 && String.IsNullOrEmpty(_worldschow[x, j]); j++)
            {
                y = j;
            }
            _worldschow[x, y] = "p";
            p.X = x;
            p.Y = y;

        }
        public void GenerateVillage()
        {
            int randomm = new Random().Next(0, 5);
            if (randomm ==3)
            {
            int houseanzahl = new Random().Next(3, 5);
            for (int j = 0; j < houseanzahl; j++)
            {
                int x = new Random().Next(10, 100);
                int y = 0;
                for (int i = 2; i < 30 && String.IsNullOrEmpty(_worldschow[x, i]); i++)
                {
                    y = i;
                }
                if (y > 3)
                {
                    if (_worldschow[x,y+1]=="g")
                    {
                           PlaceHouse(x, y);
                    }
               
                }
            }
            }

        }
        public void PlaceHouse(int x, int y)
        {
            _worldschow[x, y] = "s";
            _worldschow[x, y - 1] = "/";
            _worldschow[x + 1, y] = "s";
            _worldschow[x+1,y-1] = @"\";
        }
        public void GenerateOres()
        {
            int granitecluster = new Random().Next(2, 5);
            int dioritecluster = new Random().Next(2, 5);
            int andesitecluster = new Random().Next(2, 5);
            int dias = new Random().Next(5, 8);
            int iron = new Random().Next(8, 14);
            int obsidian = new Random().Next(5, 8);
            int yplacement = 0;
            int xplacement = 0;
            for (int i = 0; i < granitecluster; i++)
            {
                yplacement =new Random().Next(5, 28);
                xplacement =new Random().Next(10, 100);
                if (_worldschow[xplacement,yplacement]=="s")
                {
                    PlaceClusters("sg", xplacement, yplacement);
                }
                else{i--;}
            }//sg
            for (int i = 0; i < dioritecluster; i++)
            {
                yplacement = new Random().Next(5, 30);
                xplacement = new Random().Next(10, 100);
                if (_worldschow[xplacement, yplacement] == "s")
                {
                    PlaceClusters("sd", xplacement, yplacement);
                }
                else
                {
                    i--;
                }
            }//sd
            for (int i = 0; i < andesitecluster; i++)
            {
                yplacement = new Random().Next(5, 30);
                xplacement = new Random().Next(10, 100);
                if (_worldschow[xplacement, yplacement] == "s")
                {
                    PlaceClusters("sa", xplacement, yplacement);
                }
                else
                {
                    i--;
                }
            }//sa
            for (int i = 0; i < dias; i++)
            {
                yplacement = new Random().Next(28, 33);
                xplacement = new Random().Next(10 ,100);
                if (_worldschow[xplacement, yplacement] == "s")
                {
                    _worldschow[xplacement, yplacement] = "sdi";
                }
                else
                {
                    i--;
                }
            }//sdi
            for (int i = 0; i < iron; i++)
            {
                yplacement = new Random().Next(5, 30);
                xplacement = new Random().Next(10, 100);
                if (_worldschow[xplacement, yplacement] == "s")
                {
                    _worldschow[xplacement, yplacement] = "si";
                }
                else
                {
                    i--;
                }
            }//si
            for (int i = 0; i < obsidian; i++)
            {
                yplacement = new Random().Next(5, 30);
                xplacement = new Random().Next(10, 100);
                if (_worldschow[xplacement, yplacement] == "s")
                {
                    _worldschow[xplacement, yplacement] = "so";
                }
                else
                {
                    i--;
                }
            }//so

        }
        public static void PlaceClusters(string type, int x, int y)
        {
            int clustersize =new Random().Next(0, 4);
            switch (clustersize)
            {
                case 0:
                    _worldschow[x-1, y-1] = type;
                    _worldschow[x, y-1] = type;
                    _worldschow[x-1, y] = type;
                    _worldschow[x, y] = type;
                    _worldschow[x+1, y] = type;
                    _worldschow[x-1, y+1] = type;
                    _worldschow[x, y+1] = type;break;
                case 1:
                    _worldschow[x-1, y-3] = type;
                    _worldschow[x, y-3] = type;
                    _worldschow[x-1, y-2] = type;
                    _worldschow[x, y-2] = type;
                    _worldschow[x+1, y-2] = type;
                    _worldschow[x-1, y-1] = type;
                    _worldschow[x, y-1] = type;
                    _worldschow[x+1, y-1] = type;
                    _worldschow[x, y] = type;
                    _worldschow[x+1, y] = type;
                    _worldschow[x-1, y+1] = type;
                    _worldschow[x, y+1] = type;
                    _worldschow[x+1, y+1] = type;
                    _worldschow[x-2, y+2] = type;
                    _worldschow[x-1, y+2] = type;
                    _worldschow[x, y+2] = type;
                    _worldschow[x-1, y+3] = type;break;
                case 2:
                    _worldschow[x-1, y-2] = type;
                    _worldschow[x, y-2] = type;
                    _worldschow[x-2, y-1] = type;
                    _worldschow[x-1, y-1] = type;
                    _worldschow[x, y-1] = type;
                    _worldschow[x+1, y-1] = type;
                    _worldschow[x+2, y-1] = type;
                    _worldschow[x-2, y] = type;
                    _worldschow[x-1, y] = type;
                    _worldschow[x, y] = type;
                    _worldschow[x+1, y] = type;
                    _worldschow[x+2, y] = type;
                    _worldschow[x-1, y+1] = type;
                    _worldschow[x, y+1] = type;
                    _worldschow[x+1, y+1] = type;
                    _worldschow[x+2, y+1] = type;
                    _worldschow[x, y+2] = type;
                    _worldschow[x+1, y+2] = type;break;
                case 3:
                    _worldschow[x+1, y-2] = type;
                    _worldschow[x+2, y-2] = type;
                    _worldschow[x-2, y-1] = type;
                    _worldschow[x-1, y-1] = type;
                    _worldschow[x, y-1] = type;
                    _worldschow[x+1, y-1] = type;
                    _worldschow[x + 2, y - 1] = type;
                    _worldschow[x-2, y] = type;
                    _worldschow[x-1, y] = type;
                    _worldschow[x, y] = type;
                    _worldschow[x+1, y] = type;
                    _worldschow[x+2, y] = type;
                    _worldschow[x-1, y+1] = type;
                    _worldschow[x, y+1] = type;
                    _worldschow[x+1, y+1] = type;
                    _worldschow[x, y+2] = type;break;
            }
        }
        public void PlaceStronghold()
        {
            int randx = new Random().Next(1, 114);
            _worldschow[randx, 32] = "strsh";
            _worldschow[randx+1, 32] = "str-";
            _worldschow[randx+2, 32] = "str-";
            _worldschow[randx+3, 32] = "str-";
            _worldschow[randx+4, 32] = "strsh";

            _worldschow[randx, 31] = "str|";
            _worldschow[randx + 1, 31] = "s";
            _worldschow[randx + 2, 31] = "s";
            _worldschow[randx + 3, 31] = "s";
            _worldschow[randx + 4, 31] = "str|";

            _worldschow[randx, 30] = "str|";
            _worldschow[randx + 1, 30] = "s";
            _worldschow[randx + 2, 30] = "strprtl";
            _worldschow[randx + 3, 30] = "s";
            _worldschow[randx + 4, 30] = "str|";

            _worldschow[randx, 29] = "str|";
            _worldschow[randx + 1, 29] = "s";
            _worldschow[randx + 2, 29] = "s";
            _worldschow[randx + 3, 29] = "s";
            _worldschow[randx + 4, 29] = "str|";

            _worldschow[randx, 28] = "strsh";
            _worldschow[randx + 1, 28] = "str-";
            _worldschow[randx + 2, 28] = "str-";
            _worldschow[randx + 3, 28] = "str-";
            _worldschow[randx + 4, 28] = "strsh";

        }
    }
}
//lucas schau nur 735 zeilen, ich weis genau dass du scaeun willst, das is kleencode