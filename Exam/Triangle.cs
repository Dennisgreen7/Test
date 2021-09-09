using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Triangle : Shape
    {
        private int Size { get; set; }
        private string Symbol = "#";
        private Random rnd = new Random();

        public Triangle()
        {
            this.Size = rnd.Next(3, 9);
        }

        public override int [,] PrintShape( int[,] BoardPixels)
        {
            int TzirX=0, TzirY=0;
            //Window Size
            int WinWidth = Console.WindowWidth;
            int WinHeight = Console.WindowHeight;
            int flag = 1;
            while (flag != 0)
            {
                flag = 0;
                TzirX = rnd.Next(0, WinWidth - this.Size);
                TzirY = rnd.Next(0, WinHeight - this.Size);
                for (int i = 1; i <= this.Size; i++)
                {
                    for (int k = 1; k <= i; k++)
                    {
                        if (BoardPixels[TzirX + k, TzirY + i] == 1)
                        {
                            flag = 1;
                        }
                    }
                }
            }
            for (int i = 1; i <= this.Size; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    Console.SetCursorPosition(TzirX + k, TzirY + i);
                    BoardPixels[TzirX + k, TzirY + i] = 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(this.Symbol);
                }
                Console.WriteLine();
            }
            return BoardPixels;
        }
    }
}
