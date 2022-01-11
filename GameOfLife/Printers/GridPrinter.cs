using System;
using System.Linq;

namespace GameOfLife.Printers
{
    public class GridPrinter
    {
        internal void PrintGrid(string[,]? grid)
        {
            for (int i = 0; i < grid?.GetLength(0); i++)
            {
                for (int j = 0; j < grid?.GetLength(1); j++)
                {
                    Console.Write(grid[i, j]);

                }
                Console.WriteLine();
            }
        }
    }
}
