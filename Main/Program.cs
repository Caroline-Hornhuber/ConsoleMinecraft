using System;
using System.Windows;
namespace Main
{

    class Program
    {
        Random Random = new Random();
        static int constint = 1;// new Random().Next(0, 4);// biome genarator? // wenn sie das auf 1 setzen ist normal
        public static int Dimension = 1; //0..ovweworlt 1nether 2.. end 3..easter egg
        public static  int range = 5;
        static bool changedimension = false;
        public static int strongholdplaced = 0;
        /* 
         * shit i want 2 add:
         * end boss fight ka/v
         * gescheiter startscreen!
         * 
         *///to do list

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            Console.WindowHeight = 40;
            Console.WindowWidth = 150;
            Console.WriteLine("                                                                     MINECRAFT");
            StartScreen();
            StartScreenEasy();
            World w = new World();
            Nether n = new Nether();
            End e = new End();
            Inventar i = new Inventar();
            Console.BackgroundColor = ConsoleColor.Black;
            Player P = new Player(w);
            Console.BackgroundColor = ConsoleColor.Black;
            P.Spwanplayer();
            PrintWorld(w.WorldShown);
            PrintInv(w.WorldShown, i);
            Gameverlauf(w.WorldShown, w,P,i,n.NetherShown,e);
            StopPretty();
        }
        public static void Gameverlauf(string[,] world,World w,Player P,Inventar inv, string[,]netherworld, End e)
        {
            int x = 0;
            int y = 0;  
            {
                for (int i = 0; i < world.GetLength(0); i++)
                {
                    for (int j = 0; j < world.GetLength(1); j++)
                    {
                        if (world[i, j] == "p")
                        {
                            x = i;
                            y = j;
                        }
                    }
                }// get playah

                Console.SetCursorPosition(121, 3);
                Console.Write($"x:{x}   y:{y}");
            }//f3
            bool done = false;

            do
            {
                if (changedimension)
                {
                    if (Dimension==1||Dimension==0)
                    {
                        PrintWorld(world);
                        bool pubg = false;
                        range = 5;
                        for (int i = 0; i < world.GetLength(1)&&!pubg; i++)
                        {
                            for (int j = 0; j < world.GetLength(0)&&!pubg; j++)
                            {
                                if (world[j, i] == "p" || world[j,i]=="bp")
                                {
                                    pubg = true;
                                    P.X = j;
                                    P.Y = i;
                                    w.cursor.Item1 = P.X;
                                    w.cursor.Item2 = P.Y;
                                }
                            }
                        }
                    }
                    else if (Dimension==2)
                    {
                        PrintWorld(netherworld);
                        bool pubg = false;
                        for (int i = 0; i < netherworld.GetLength(1) && !pubg; i++)
                        {
                            for (int j = 0; j < netherworld.GetLength(0) && !pubg; j++)
                            {
                                if (netherworld[j, i] == "p")
                                {
                                    pubg = true;
                                    P.X = j;
                                    P.Y = i;
                                    w.cursor.Item1 = P.X;
                                    w.cursor.Item2 = P.Y;
                                    Printthing(netherworld, P.X, P.Y);
                                }
                            }
                        }
                    }
                    else if (Dimension==3)
                    {
                        PrintWorld(e.EndShown);
                        range = 20;
                        bool pubg = false;
                        for (int i = 0; i < e.EndShown.GetLength(1) && !pubg; i++)
                        {
                            for (int j = 0; j < e.EndShown.GetLength(0) && !pubg; j++)
                            {
                                if (e.EndShown[j, i] == "p")
                                {
                                    pubg = true;
                                    P.X = j;
                                    P.Y = i;
                                    w.cursor.Item1 = P.X;
                                    w.cursor.Item2 = P.Y;
                                    Printthing(e.EndShown, P.X, P.Y);
                                    e.PlaceDragon();
                                    PrintWorld(e.EndShown);
                                }
                            }
                        }
                    }
                    changedimension = false;
                }
                else if (Dimension == 1 || Dimension == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    PrintInv(world, inv);
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo var = Console.ReadKey();
                        //next eingabe
                        if (var.KeyChar == '0')
                        {
                            done = true;
                        } // endprokram
                        else if (var.Key == ConsoleKey.LeftArrow || var.Key == ConsoleKey.UpArrow || var.Key == ConsoleKey.RightArrow || var.Key == ConsoleKey.DownArrow)
                        {
                            Console.SetCursorPosition(w.cursor.Item1, w.cursor.Item2 + 1);
                            Printthing(world, w.cursor.Item1, w.cursor.Item2);
                            w.MoveCurser(var, P, range);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.SetCursorPosition(w.cursor.Item1, w.cursor.Item2 + 1);
                            Console.Write("▒");
                        }//moce curser
                        else if (var.KeyChar == 'q' || var.KeyChar == 'e')
                        {
                            w.DoAction(var, P, inv, world,ref changedimension,ref e);
                        }//da action
                        else if (var.KeyChar == '1' || var.KeyChar == '2' || var.KeyChar == '3' || var.KeyChar == '3' || var.KeyChar == '4' || var.KeyChar == '5' || var.KeyChar == '6' || var.KeyChar == '7' || var.KeyChar == '8' || var.KeyChar == '9')
                        {
                            inv.Changeslot(Convert.ToInt32(var.KeyChar - '0'));
                        }//change chosed slot
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(P.X, P.Y + 1);
                            if (world[P.X, P.Y] == "b")
                            {
                                int biome = constint;
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
                                world[P.X, P.Y] = "b";
                            }
                            else
                            {
                                Console.WriteLine(" ");
                            }
                            w.Move(var, world, ref P, constint, Dimension);
                            Console.SetCursorPosition(w.cursor.Item1, w.cursor.Item2 + 1);
                            Printthing(world, w.cursor.Item1, w.cursor.Item2);
                            w.cursor.Item1 = P.X;
                            w.cursor.Item2 = P.Y;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.SetCursorPosition(P.X, P.Y + 1);
                            Console.WriteLine("⌆");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }//move
                    }


                }// overworld
                else if (Dimension == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    PrintInv(netherworld, inv);
                    Console.ForegroundColor = ConsoleColor.Black;

                        ConsoleKeyInfo var = Console.ReadKey();
                        //next eingabe
                        if (var.KeyChar == '0')
                        {
                            done = true;
                        } // endprokram
                        else if (var.Key == ConsoleKey.LeftArrow || var.Key == ConsoleKey.UpArrow || var.Key == ConsoleKey.RightArrow || var.Key == ConsoleKey.DownArrow)
                        {
                            Console.SetCursorPosition(w.cursor.Item1, w.cursor.Item2 + 1);
                            Printthing(netherworld, w.cursor.Item1, w.cursor.Item2);
                            w.MoveCurser(var, P, range);
                            Console.BackgroundColor = ConsoleColor.Red;
                            
                            Console.SetCursorPosition(w.cursor.Item1, w.cursor.Item2 + 1);
                            Console.Write("▒");
                        }//moce curser
                        else if (var.KeyChar == 'q' || var.KeyChar == 'e')
                        {
                            w.DoAction(var, P, inv, netherworld, ref changedimension,ref e);
                        }//da action
                        else if (var.KeyChar == '1' || var.KeyChar == '2' || var.KeyChar == '3' || var.KeyChar == '3' || var.KeyChar == '4' || var.KeyChar == '5' || var.KeyChar == '6' || var.KeyChar == '7' || var.KeyChar == '8' || var.KeyChar == '9')
                        {
                            inv.Changeslot(Convert.ToInt32(var.KeyChar - '0'));
                        }//change chosed slot
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(P.X, P.Y + 1);
                            Console.WriteLine(" ");
                            w.Move(var, netherworld, ref P, constint, Dimension);
                            Console.SetCursorPosition(w.cursor.Item1, w.cursor.Item2 + 1);
                            Printthing(netherworld, w.cursor.Item1, w.cursor.Item2);
                            w.cursor.Item1 = P.X;
                            w.cursor.Item2 = P.Y;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(P.X, P.Y + 1);
                            Console.WriteLine("⌆");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }//move
                    
                }//nether
                else if (Dimension == 3)//end
                {

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    PrintInv(e.EndShown, inv);
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo var = Console.ReadKey();
                        //next eingabe
                        if (var.KeyChar == '0')
                        {
                            done = true;
                        } // endprokram
                        else if (var.Key == ConsoleKey.LeftArrow || var.Key == ConsoleKey.UpArrow || var.Key == ConsoleKey.RightArrow || var.Key == ConsoleKey.DownArrow)
                        {
                            Console.SetCursorPosition(w.cursor.Item1, w.cursor.Item2 + 1);
                            Printthing(e.EndShown, w.cursor.Item1, w.cursor.Item2);
                            w.MoveCurser(var, P, range);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.SetCursorPosition(w.cursor.Item1, w.cursor.Item2 + 1);
                            Console.Write("▒");
                        }//moce curser
                        else if (var.KeyChar == 'q' || var.KeyChar == 'e')
                        {
                            w.DoAction(var, P, inv, e.EndShown,ref changedimension,ref e);
                        }//da action
                        else if (var.KeyChar == '1' || var.KeyChar == '2' || var.KeyChar == '3' || var.KeyChar == '3' || var.KeyChar == '4' || var.KeyChar == '5' || var.KeyChar == '6' || var.KeyChar == '7' || var.KeyChar == '8' || var.KeyChar == '9')
                        {
                            inv.Changeslot(Convert.ToInt32(var.KeyChar - '0'));
                        }//change chosed slot
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(P.X, P.Y + 1);
                                Console.WriteLine(" ");
                            w.Move(var,  e.EndShown, ref P, constint, Dimension);
                            Console.SetCursorPosition(w.cursor.Item1, w.cursor.Item2 + 1);
                            Printthing(e.EndShown, w.cursor.Item1, w.cursor.Item2);
                            w.cursor.Item1 = P.X;
                            w.cursor.Item2 = P.Y;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(P.X, P.Y + 1);
                            Console.WriteLine("⌆");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }//move
                    }
                    else
                    {
                        if (e.d.health >= 0)
                        {
                        int doesdragonmove = new Random().Next(50,70);
                        if (doesdragonmove==69)
                        {
                            int doeshechangedirection = new Random().Next(0, 10);
                            if (doeshechangedirection==1)
                            {
                                if (e.d.facing)
                                {
                                    e.d.facing = false;
                                    if (e.d.pos.Item2<118&&e.d.pos.Item1>2)
                                    {
                                        e.d.pos.Item1--;
                                    }
                                }
                                else
                                {
                                    e.d.facing = true;
                                    if (e.d.pos.Item2 < 118 && e.d.pos.Item1 > 2)
                                    {
                                        e.d.pos.Item1++;
                                    }
                                }
                            }
                            else
                            {
                                if (e.d.facing)
                                {
                                    if (e.d.pos.Item2 < 118 && e.d.pos.Item1 > 2)
                                    {
                                        e.d.pos.Item1--;
                                    }
                                }
                                else
                                {
                                    if (e.d.pos.Item2 < 118 && e.d.pos.Item1 > 2)
                                    {
                                        e.d.pos.Item1++;
                                    }
                                }
                            }

                            e.PlaceDragon();
                            PrintWorld(e.EndShown);
                            e.d.DragonHelthBar();
                            if (w.cursor.Item1!=P.X&&w.cursor.Item2!=P.Y)
                            {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.SetCursorPosition(w.cursor.Item1, w.cursor.Item2 + 1);
                            Console.Write("▒");
                            }

                        }
                        }
                        else
                        {
                            e.PlaceDragon();
                            Console.SetCursorPosition(0, 0);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("                                            Enderdragon : dead  goto portalthing to be back at normal world   ");
                            e.d.dead = true;
                            e.EndShown[e.portal.Item1, e.portal.Item2] = "strprtlac";
                        }


                    }
                }
            } while (done == false);
        }
        static string[,] PrintInv(string[,] world,Inventar inven)
        {
            Console.SetCursorPosition(130, 0);
            for (int i = 1; i < 35; i++)
            {
                Console.SetCursorPosition(120, i);
                Console.WriteLine("*");
                Console.CursorTop += 1;
            }
            Console.SetCursorPosition(133, 0);
            Console.WriteLine("INVENTAR");
            {
                Console.SetCursorPosition(121, 1);
                Console.Write("Players: 1");
                Console.SetCursorPosition(121, 2);
                Console.Write("Biome  : ");
                if (Dimension == 2)
                {
                    Console.Write("nether");
                }
                else if (Dimension==3)
                {
                    Console.Write("end   ");
                }
                else if (constint == 0 || constint == 1)
                {
                    Console.Write("forest");
                }
                else if (constint == 2)
                {
                    Console.Write("Desert");
                }
                else if (constint == 3)
                {
                    Console.Write("Snowy tundra");
                }
                Console.SetCursorPosition(121, 4);
                Console.Write("items:");
                for (int i = 0; i < 9; i++)
                {
                    Console.SetCursorPosition(121, 5+i);
                    if (inven.Chosenslot==i)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Console.Write($"{i + 1}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Printthing(inven.inventar, i, 0);
                    Console.Write($"({inven.inventar[i,1]})");
                }
                
            }//players und biome etc

            return world;
        }
        static void StopPretty()
        {
            Console.SetCursorPosition(140,36);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static  void PrintWorld(string[,]world)
        {

            Console.SetCursorPosition(0, 1);
            int biome = constint;
            for (int j = 0; j < 34; j++)
            {
                for (int i = 0; i < world.GetLength(0); i++)
                {
                    Printthing(world, i, j);
                }
                Console.WriteLine();
            }
        }
        static void StartScreen()
        {
            Console.WriteLine("Welcome to Minecraft!\n"+
                             "This is oviously 2d and simplified\n" +
                             "you are the ⌆ and can moove and jump 2 blocks high\n" +
                             "you also have a cursor for actions like breaking/placing/using blocks and fighting\n" +
                             "some other features are: \n" +
                             "random generation\n" +
                             "Bioms\n" +
                             "end, nether dimensions\n" +
                             "random villages with houses and no villagers\n" +
                             "a inventory with 9 slots\n" +
                             "ores and types of stone\n" +
                             "and the moste important: pinkflowers :)\n" +
                             "\n" +
                             "the goal is to go into the end and slay the ender dragon\n" +
                             "\n\n\n" +
                             "~~~WICHTIG:~~~\n" +
                             "verwendete schrift: MS GOTHIC \n" +
                             "verwendes visual studio: vs 22 mit .net6\n" +
                             "und der code ist sehr hässlich\n" +
                             "made by caro\n" +
                             "viel spass:)\n" +
                             "press any key to continue\n");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                            MINECRAFT");

        }
        private static void StartScreenEasy()
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine("Zusammengefasst heist das:        ******WICHTIG BITTE LESEN*****\n" +
                "du kannst dich mit wasd bewegen\n" +
                "deinen curser mit den pfeiltasten\n" +
                "blöcke abbbauen/benutzen mit q\n" +
                "blöcke plaziren mit e\n" +
                "mit den nummertasten (1-9) kannst du jeweilige blöcke auswählen die du plaziren/benutzen willst\n" +
                "nether portal: 3 obsidian(die lila blöcke) übereinander bauen und \n" +
                "q auf den obersten\n" +
                "end portal: mit blazerods aus dem nether auf je eine der vier ecken der\n" +
                "konstruktion die im boden in der overworld ist mit q interagiren und mit auf den mittleren block\n" +
                "q drücken\n" +
                "\n" +
                "bei bugs und fragen bitte an mich wenden danke\n" +
                "press any key to continue\n");
            
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                            MINECRAFT");
        }
        public static void Printthing(string[,]world,int i, int j)
        {
            if (world[i, j] == "s")//stein
            {
                if (constint == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else if (constint == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else if (constint == 0 || constint == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                Console.Write("⚅");
            }//stein
            else if (world[i, j] == "g")//grass
            {
                if (constint == 0 || constint == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }//0,1..forest und 2..desert und 3 .. snowy tundra
                else if (constint == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                else if (constint == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;//da gehöhrt weis hin aber nein
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                Console.Write("▀");
            }//grass
            else if (world[i, j] == "d")//dirt
            {
                if (constint == 0 || constint == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (constint == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                else if (constint == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.Write("▓");
            }//dirt
            else if (world[i, j] == "h")//holz
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                if (constint == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                Console.Write("☰");
            }//holz
            else if (world[i, j] == "l")//leaves
            {
                if (constint == 0 || constint == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                else if (constint == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else if (constint == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.Write("≋");
            }//leaves
            else if (world[i, j] == "b")//blume
            {
                if (constint == 1 || constint == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("⚘");
                }
                else if (constint == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("▆");
                }
                else if (constint == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("⚘");
                }
            }//flower
            else if (world[i, j] == "/")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("◢");
            }//hausdach1
            else if (world[i, j] == @"\")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write($@"◣");
            }//hausdach2
            else if (String.IsNullOrEmpty(world[i, j]) || world[i, j] == "v")//air
            {
                if (Dimension==1||Dimension==0)
                {
                Console.BackgroundColor = ConsoleColor.Blue;
                }
                else if (Dimension==2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;  
                }
                else if (Dimension==3)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write(" ");
            }//air
            else if (world[i, j] == "p")
            {
                Console.BackgroundColor = ConsoleColor.Blue; if (Dimension == 1 || Dimension == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else if (Dimension == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else if (Dimension==3)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("⌆");
            }//playah
            else if (world[i, j] == "sg")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write("⚅");
            }//stone granite
            else if (world[i, j] == "sa")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write("⚅");
            }//stone andesite
            else if (world[i, j] == "sd")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write("⚅");
            }//stone diorite
            else if (world[i, j] == "si")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write("▦");
            }//stone iron
            else if (world[i, j] == "sdi")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write("▦");
            }//stine diamonds
            else if (world[i,j]=="so")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                if (Dimension==3)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                }

                Console.Write("▦");
            }
            else if (world[i, j]=="sop")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                if (Dimension==2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                Console.BackgroundColor = ConsoleColor.Blue;//DarkGray;
                }

                Console.Write("▦");
            }
            else if (world[i, j] == "bp")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("⌆");
            }//player standing on flower
            else if (world[i,j]=="snr")
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Red;//DarkGray;
                Console.Write("▦");
            }
            else if (world[i,j]=="br")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.DarkYellow;//DarkGray;
                Console.Write("/");
            }
            else if (world[i,j]=="lv")
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Yellow;//DarkGray;
                Console.Write("≋");
            }
            else if (world[i, j] == "strsh")
            {
                Console.BackgroundColor = ConsoleColor.DarkGray; ;
                Console.ForegroundColor = ConsoleColor.Black;//DarkGray;
                Console.Write("⧈");
            }
            else if (world[i, j] == "strshac")
            {
                Console.BackgroundColor = ConsoleColor.DarkGray; ;
                Console.ForegroundColor = ConsoleColor.Gray;//DarkGray;
                Console.Write("⧈");
            }

            else if (world[i, j] == "str-")
            {
                Console.BackgroundColor = ConsoleColor.DarkGray; ;
                Console.ForegroundColor = ConsoleColor.Black;//DarkGray;
                Console.Write("▤");
            }
            else if (world[i, j] == "str|")
            {
                Console.BackgroundColor = ConsoleColor.DarkGray; ;
                Console.ForegroundColor = ConsoleColor.Black;//DarkGray;
                Console.Write("▤");
            }
            else if (world[i, j] == "strprtl")
            {
                Console.BackgroundColor = ConsoleColor.DarkGray; ;
                Console.ForegroundColor = ConsoleColor.Black;//DarkGray;
                Console.Write("▦");
            }
            else if (world[i, j] == "strprtlac")
            {
                Console.BackgroundColor = ConsoleColor.DarkGray; ;
                Console.ForegroundColor = ConsoleColor.Black;//DarkGray;
                Console.Write("▦");
            }
            else if (world[i, j] == "se")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write("▒");
            }
            else if (world[i,j]=="ed1")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("▒");
            }
            else if (world[i,j]=="ed2")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("▒");
            }
            Console.ResetColor();
        }
    }
}
//lucas nur 708 zeilen (vorsorge, ich weis zu 100% dass du scheun willst lol)