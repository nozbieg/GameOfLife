using System;
using System.Linq;

namespace GameOfLife.Engine.GameSettings
{
    public class GameProperties
    {
        public GameProperties(GridSizeProperties? gridSizeProperties)
        {
            GridSizeProperties = gridSizeProperties;
        }
        public GridSizeProperties? GridSizeProperties { get; set; }
    }
}
