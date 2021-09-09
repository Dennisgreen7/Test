using System;

namespace Exam
{
    class Program
    {
        static int WinWidth = Console.WindowWidth;
        static int WinHeight = Console.WindowHeight;
        static int[,] BoardPixels = new int[WinWidth, WinHeight];

        public static void PrintShapes(int ShapeCount)
        {
            Random rnd = new Random();

            for (int i = 0; i < ShapeCount; i++)
            {
                switch (rnd.Next(0, 4))
                {
                    case 0:
                        Line line = new Line();
                        BoardPixels = line.PrintShape(ref BoardPixels);
                        break;
                    case 1:
                        Rectangle rectangle = new Rectangle();
                        BoardPixels = rectangle.PrintShape(ref BoardPixels);
                        break;
                    case 2:
                        Square square = new Square();
                        BoardPixels = square.PrintShape(ref BoardPixels);
                        break;
                    case 3:
                        Triangle triangle = new Triangle();
                        BoardPixels = triangle.PrintShape(ref BoardPixels);
                        break;
                }
            }
        }

        public static void PrintPlayer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("*");
        }

        public static void StartGame(int[,] arr)
        {
            int flag = 0;
            int x = 0;
            int y = 0;
            int GameOver;
            int Points = 0;
            string LastMove = "";
            Console.CursorVisible = false;
            for (int i = 0, j = 3; i < 15; i++, j++)
            {
                PrintShapes(j);
                x = 0;
                y = 0;
                while (flag != 1)
                {
                    if (arr[x, y] == 0)
                    {
                        flag = 1;
                    }
                    else
                    {
                        x++;
                        y++;
                    }
                }
                PrintPlayer(x, y);
                LastMove = "";
                GameOver = 0;
                while (GameOver != 1)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    var command = Console.ReadKey().Key;
                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            //Console.SetCursorPosition(x, y);
                            //Console.Write("*");
                            y++;
                            if (y > Console.WindowHeight - 1 || LastMove == "Up")
                            {
                                y--;
                                Console.SetCursorPosition(x, y);
                                Console.Write("*");
                            }
                            else
                            {
                                Console.SetCursorPosition(x, y);
                                if (arr[x, y] == 1 || arr[x, y] == 2)
                                {
                                    GameOver = 1;
                                }
                                else
                                {
                                    Console.SetCursorPosition(x, y);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write("*");
                                    arr[x, y] = 2;
                                    LastMove = "Down";
                                    Points++;
                                }
                            }
                            break;

                        case ConsoleKey.UpArrow:
                            Console.SetCursorPosition(x, y);
                            Console.Write("*");
                            y--;
                            if (y < 0 || LastMove == "Down")
                            {
                                y++;
                                Console.SetCursorPosition(x, y);
                                Console.Write("*");
                            }
                            else
                            {
                                Console.SetCursorPosition(x, y);
                                if (arr[x, y] == 1 || arr[x, y] == 2)
                                {
                                    GameOver = 1;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write("*");
                                    arr[x, y] = 2;
                                    LastMove = "Up";
                                    Points++;
                                }
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            x--;
                            if (x < 0 || LastMove == "Rigth")
                            {
                                x++;
                                Console.SetCursorPosition(x, y);
                                

                            }
                            else
                            {
                                Console.SetCursorPosition(x, y);
                                if (arr[x, y] == 1 || arr[x, y] == 2)
                                {
                                    GameOver = 1;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write("*");
                                    arr[x, y] = 2;
                                    if (x == 0)
                                    {
                                        Console.SetCursorPosition(x, y);
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(x - 1, y);
                                    }
                                    LastMove = "Left";
                                    Points++;
                                }
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            Console.SetCursorPosition(x, y);
                            Console.Write("*");
                            x++;
                            if (x >= Console.WindowWidth || LastMove == "Left")
                            {
                                x--;
                                Console.SetCursorPosition(x, y);
                            }
                            else
                            {
                                Console.SetCursorPosition(x, y);
                                if (arr[x, y] == 1 || arr[x, y] == 2)
                                {
                                    GameOver = 1;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write("*");
                                    arr[x, y] = 2;
                                    LastMove = "Rigth";
                                    Points++;
                                }
                            }
                            break;
                    }
                }

                Console.Clear();
                if (i == 14)
                {
                    Console.Write("Game Over" + " \n" + (i + 1) + " Points " + Points + " \n Press any key to countine the Game");
                }
                else
                {
                    Console.Write("Round " + (i + 1) + " Points " + Points + " \n Press any key to countine the Game");
                    Console.WriteLine();
                }
                Console.ReadLine();
                Console.Clear();
                Array.Clear(arr, 0, arr.Length);
            }
        }
        static void Main(string[] args)
        {
            StartGame(BoardPixels);
        }
    }
}
