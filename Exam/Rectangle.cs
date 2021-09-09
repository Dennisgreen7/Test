using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Rectangle:Shape
    {
        private int RectangleHeight { get; set; }
        private int RectangleWidth { get; set; }
        private string Symbol = "ם";
        private Random rnd = new Random();

        public Rectangle()
        {
            this.RectangleHeight = rnd.Next(3, 10);
            this.RectangleWidth = rnd.Next(2, 10);
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
                TzirX = rnd.Next(0, WinWidth - this.RectangleWidth);
                TzirY = rnd.Next(0, WinHeight - this.RectangleHeight);
                for (int i = 0; i < this.RectangleHeight; i++)
                {
                    for (int j = 0; j < this.RectangleWidth; j++)
                    {
                        if (BoardPixels[TzirX + j, TzirY + i] == 1)
                        {
                            flag = 1;
                        }
                    }
                }
            }
            for (int i = 0; i < this.RectangleHeight; i++)
            {
                for (int j = 0; j < this.RectangleWidth; j++)
                {
                    Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");
                    Console.SetCursorPosition(TzirX + j, TzirY + i);
                    BoardPixels[TzirX + j, TzirY + i] = 1;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(this.Symbol);
                }
                Console.WriteLine();
            }
            return BoardPixels;
        }
    }
}
