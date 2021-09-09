using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Square : Shape
    {
        private int SquareSize { get; set; }
        private string Symbol = "ם";
        private Random rnd = new Random();

        public Square()
        {
            this.SquareSize = rnd.Next(3, 10);
        }

        public override int [,] PrintShape(ref int[,] BoardPixels)
        {
            int TzirX=0, TzirY=0;
            //Window Size
            int WinWidth = Console.WindowWidth;
            int WinHeight = Console.WindowHeight;
            int flag = 1;
            while (flag != 0)
            {
                flag = 0;
                TzirX = rnd.Next(0, WinWidth - this.SquareSize);
                TzirY = rnd.Next(0, WinHeight - this.SquareSize);
                for (int i = 0; i < this.SquareSize; i++)
                {
                    for (int j = 0; j < this.SquareSize; j++)
                    {
                        if (BoardPixels[TzirX + j, TzirY + i] == 1)
                        {
                            flag = 1;
                        }
                    }
                }
            }
            for (int i = 0; i < this.SquareSize; i++)
            {
                for (int j = 0; j < this.SquareSize; j++)
                {
                    Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");
                    Console.SetCursorPosition(TzirX + j, TzirY + i);
                    BoardPixels[TzirX + j, TzirY + i] = 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(this.Symbol);
                }
                Console.WriteLine();
            }
            return BoardPixels;
        }
    }
}
