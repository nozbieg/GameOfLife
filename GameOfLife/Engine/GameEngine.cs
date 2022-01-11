using System;
using System.Linq;
using GameOfLife.Engine.GameSettings;

namespace GameOfLife.Engine
{
    public class GameEngine
    {
        public string[,]? GameGrid { get; set; }
        const string EMPTYCELL = "[ ]";
        const string LIVECELL = "[O]";
        const string DEADCELL = "[X]";
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

        public string[,]? GenerateGameArray(GridSizeProperties? gridSizeProperties)
        {
            if (gridSizeProperties == null)
            {
                return null;
            }

            var emptyGrid = new string[gridSizeProperties.GridXSize, gridSizeProperties.GridYSize];
            return emptyGrid;
        }
        void FillGameGrid()
        {
            for (int i = 0; i < GameGrid?.GetLength(0); i++)
            {
                for (int j = 0; j < GameGrid?.GetLength(1); j++)
                {
                    GameGrid[i, j] = EMPTYCELL;
                }
            }
        }
        public GameEngine()
        {
            GameProperties = new(new(ReadGridSize()));
            GameGrid = GenerateGameArray(GameProperties.GridSizeProperties);
            FillGameGrid();
        }
    }
}
