using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Line : Shape
    {
        public int LineSize { get; set; }
        private string Symbol = "=";
        private Random rnd = new Random();

        public Line()
        {
            this.LineSize = rnd.Next(2, 10);
        }

        public override int[,] PrintShape(int[,] BoardPixels)
        {
            int TzirX = 0, TzirY = 0;
            //Window Size
            int WinWidth = Console.WindowWidth;
            int WinHeight = Console.WindowHeight;
            int flag = 1;
            while (flag != 0)
            {
                flag = 0;
                TzirX = rnd.Next(0, WinWidth - this.LineSize);
                TzirY = rnd.Next(0, WinHeight - this.LineSize);
                for (int i = 0; i < this.LineSize; i++)
                {
                    if (BoardPixels[TzirX + i, TzirY] == 1)
                    {
                        flag = 1;
                    }
                }
            }
            for (int i = 0; i < this.LineSize; i++)
            {
                Console.SetCursorPosition(TzirX + i, TzirY);
                BoardPixels[TzirX + i, TzirY] = 1;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(this.Symbol);
            }
            return BoardPixels;
        }
    }
}
