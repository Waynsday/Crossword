using System;

namespace Crossword
{
    class Program
    {
        public const int MapWidth = 10;
        public const int MapHeight = 10;
        public char[,] Map = new char[MapHeight, MapWidth];

        //Enter to continue
        public void Wait()
        {
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        public int GenerateRnd(int a)
        {
            Random r = new Random();
            int z = r.Next(a);
            return z;
        }

        public char GenerateRndChar()
        {
            Random r = new Random();
            char z = Convert.ToChar(r.Next(65,91));
            return z;
        }

        public void PrintMap(string[] a, int b)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Words Remaining: {0}\n\n\n", b);

            Console.ForegroundColor = ConsoleColor.White;

            //crossword
            for (int i = 0; i < MapHeight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                { 
                    {
                        Console.Write("{0}  ", Map[i, j]);
                    }
                }
                Console.Write('\n');
            }

            //wordpool
            Console.WriteLine("\n\n\nWORD POOL:\n");
            for (int i = 0; i < a.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (a[i].StartsWith('*'))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write("{0}  ", a[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool ValidString(string a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                if (int.TryParse(a, out int b))
                {
                    return false;
                }
            }

            return true;
        }

        public bool ValidPosition(string input, int x, int y, int length, int direction)
        {
            switch (direction)
            {
                //up
                case 0:
                    if(y-length >= 0)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if (Map[y - i, x] != ' ' && Map[y - i, x] != input[i])
                            {
                                return false;
                            }
                        }
                    } else
                    {
                        return false;
                    }
                    break;
                //down
                case 1:
                    if(y+length < MapHeight)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if (Map[y + i, x] != ' ' && Map[y + i, x] != input[i])
                            {
                                return false;
                            }
                        }
                    } else
                    {
                        return false;
                    }
                    break;
                //right
                case 2:
                    if(x + length < MapWidth)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if (Map[y, x + i] != ' ' && Map[y, x + i] != input[i])
                            {
                                return false;
                            }
                        }
                    } else
                    {
                        return false;
                    }
                    
                    break;
                //left
                case 3:
                    if(x-length >= 0)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if (Map[y, x - i] != ' ' && Map[y, x - i] != input[i])
                            {
                                return false;
                            }
                        }
                    } else
                    {
                        return false;
                    }
                    break;
                //up-right
                case 4:
                    if(y-length >= 0 && x + length < MapWidth){
                        for (int i = 0; i < length; i++)
                        {
                            if (Map[y - i, x + i] != ' ' && Map[y - i, x + i] != input[i])
                            {
                                return false;
                            }
                        }
                    } else
                    {
                        return false;
                    }
                    
                    break;
                //up-left
                case 5:
                    if(y-length >= 0 && x - length >= 0)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if (Map[y - i, x - i] != ' ' && Map[y - i, x - i] != input[i])
                            {
                                return false;
                            }
                        }
                    } else
                    {
                        return false;
                    }
                    
                    break;
                //down-right
                case 6:
                    if(y + length <MapHeight && x +length < MapWidth)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if (Map[y + i, x + i] != ' ' && Map[y + i, x + i] != input[i])
                            {
                                return false;
                            }
                        }
                    } else
                    {
                        return false;
                    }
                    break;
                //down-left
                case 7:
                    if(y + length < MapHeight && x - length >= 0)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            if (Map[y + i, x - i] != ' ' && Map[y + i, x - i] != input[i])
                            {
                                return false;
                            }
                        }
                    } else
                    {
                        return false;
                    }
                    break;
            }
            return true;

        }

        public void PlaceOnMap(string input, int x, int y, int direction)
        {
            switch (direction)
            {
                //up
                case 0:
                    for(int i = 0; i < input.Length; i++)
                    {
                        Map[y - i, x] = input[i];
                    }
                    break;
                //down
                case 1:
                    for(int i = 0; i < input.Length; i++)
                    {
                        Map[y + i, x] = input[i];
                    }
                    break;
                //right
                case 2:
                    for(int i = 0; i < input.Length; i++)
                    {
                        Map[y, x+i] = input[i];
                    }
                    break;
                //left
                case 3:
                    for(int i = 0; i < input.Length; i++)
                    {
                        Map[y, x - i] = input[i];
                    }
                    break;
                //up-right
                case 4:
                    for(int i = 0; i < input.Length; i++)
                    {
                        Map[y - i, x + i] = input[i];
                    }
                    break;
                //up-left
                case 5:
                    for(int i = 0; i < input.Length; i++)
                    {
                        Map[y - i, x - i] = input[i];
                    }
                    break;
                //down-right
                case 6:
                    for(int i = 0; i < input.Length; i++)
                    {
                        Map[y + i, x + i] = input[i];
                    }
                    break;
                //down-left
                case 7:
                    for (int i = 0; i < input.Length; i++)
                    {
                        Map[y + i, x - i] = input[i];
                    }
                    break;
            }
        }

        static void Main(string[] args)
        {
            
            Program p = new Program();
            int Wordcount;
            string input;
            int counter = 0;

            //conversion from \0 to spaces
            for (int i = 0; i < MapHeight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                {
                    if (p.Map[i, j] == '\0')
                    {
                        p.Map[i, j] = ' ';
                    }
                }
            }

            //Ask for the number of words
            do
            {
                Console.Clear();
                Console.Write("Welcome to crossword generator!\nHow many words do you want to input?\t");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out Wordcount));
            Wordcount = Convert.ToInt16(input);

            //Ask for words
            string[] pool = new string[Wordcount];
            while (counter != Wordcount)
            {
                do
                {
                    Console.Clear();
                    Console.Write("Enter word #{0}", counter + 1);
                    input = Console.ReadLine();
                } while (!p.ValidString(input));
                pool[counter] = input.ToUpper();
                counter++;
            }

            //Word positioning
            for(int i = 0; i < pool.Length; i++)
            {
                int x, y, dir;
                //Generate X,Y in 30x30 grid until valid
                do
                {
                    x = p.GenerateRnd(MapWidth);
                    y = p.GenerateRnd(MapHeight);
                    dir = p.GenerateRnd(8);
                    Console.WriteLine("{0}", !p.ValidPosition(pool[i], x, y, pool[i].Length, dir));
                } while (!p.ValidPosition(pool[i], x, y, pool[i].Length, dir));

                //Place word in Map
                p.PlaceOnMap(pool[i], x, y, dir);
            }

            //convert spaces to random character
            for (int i = 0; i < MapHeight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                {
                    if (p.Map[i, j] == ' ')
                    {
                        p.Map[i, j] = p.GenerateRndChar();
                    }
                }
            }
            p.Wait();

            //printing and getting player input on what he/she found
            counter = 0;
            while(counter != Wordcount)
            {
                //print crossword and word pool
                Console.Clear();
                p.PrintMap(pool, Wordcount - counter);

                Console.Write("Enter word you have found: ");
                input = Console.ReadLine();
                for(int i = 0; i < pool.Length; i++)
                {
                    if (input.ToUpper() == pool[i])
                    {
                        pool[i] = '*' + pool[i];
                        counter++;
                    }
                }
            }

            Console.Clear();
            Console.Write("Congratulations! You've found all the words!");
            //print
            p.Wait();
        }
    }
}
