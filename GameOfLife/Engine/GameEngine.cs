using System;
using System.Linq;

namespace GameOfLife.Engine
{
    public class GameEngine
    {
        public CellStateEnum[,]? GameGrid { get; set; }

        public GameProperties? GameProperties { get; set; }

        public GridSizeProperties ReadGridSize()
        {
            Console.WriteLine("x grid size");
            var input = Console.ReadLine();
            int numberX;
            int.TryParse(input, out numberX);
            Console.WriteLine("y grid size");
            input = Console.ReadLine();
            int numberY;
            int.TryParse(input, out numberY);

            return new GridSizeProperties(numberX, numberY);
        }

        public CellStateEnum[,]? GenerateGameArray(GridSizeProperties? gridSizeProperties)
        {
            if (gridSizeProperties == null)
            {
                return null;
            }

            var emptyGrid = new CellStateEnum[gridSizeProperties.GridXSize, gridSizeProperties.GridYSize];
            return emptyGrid;
        }
        void FillGameGridwithRandomCells()
        {
            for (int row = 0; row < GameGrid?.GetLength(0); row++)
            {
                for (int column = 0; column < GameGrid?.GetLength(1); column++)
                {
                    GameGrid[row, column] = (CellStateEnum)RandomNumberGenerator.GetInt32(0, 2);
                }
            }
        }
        public void CalculateNextGeneration(CellStateEnum[,]? gameGrid)
        {
            var nextGeneration = new CellStateEnum[gameGrid.GetLength(0), gameGrid.GetLength(1)];

            // Loop through every cell 
            for (var row = 0; row < gameGrid.GetLength(0) - 1; row++)
            {
                for (var column = 0; column < gameGrid.GetLength(1) - 1; column++)
                {
                    // Find the alive neighbors
                    var aliveNeighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            if (row + i < 0)
                            { row = gameGrid.GetLength(0); }
                            if (column + j < 0)
                            { column = gameGrid.GetLength(1); }
                            if (row + i > gameGrid.GetLength(0) - 1)
                            { row = 0; }
                            if (column + j > gameGrid.GetLength(1) - 1)
                            { column = 0; }
                            aliveNeighbors += gameGrid[row + i, column + j] == CellStateEnum.Alive ? 1 : 0;
                        }
                    }

                    var currentCell = gameGrid[row, column];

                    // Subtract the current cell from the neighbor count
                    aliveNeighbors -= currentCell == CellStateEnum.Alive ? 1 : 0;

                    // Implementing the Rules of Life 

                    // Cell is lonely and dies 
                    if (currentCell == CellStateEnum.Alive && aliveNeighbors < 2)
                    {
                        nextGeneration[row, column] = CellStateEnum.Dead;
                    }

                    // Cell dies due to over population 
                    else if (currentCell == CellStateEnum.Alive && aliveNeighbors > 3)
                    {
                        nextGeneration[row, column] = CellStateEnum.Dead;
                    }

                    // A new cell is born 
                    else if (currentCell == CellStateEnum.Dead && aliveNeighbors == 3)
                    {
                        nextGeneration[row, column] = CellStateEnum.Alive;
                    }

                    // All other cells stay the same
                    else
                    {
                        nextGeneration[row, column] = currentCell;
                    }
                }
            }
            GameGrid = nextGeneration;
        }
        public GameEngine()
        {
            GameProperties = new(new(ReadGridSize()));
            GameGrid = GenerateGameArray(GameProperties.GridSizeProperties);
            FillGameGridwithRandomCells();
        }
    }
}
