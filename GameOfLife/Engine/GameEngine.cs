using System;
using System.Linq;
using GameOfLife.Engine.GameSettings;

namespace GameOfLife.Engine
{
    public class GameEngine
    {

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
        public GameEngine()
        {
            GameProperties = new(new(ReadGridSize()));
        }
    }
}
