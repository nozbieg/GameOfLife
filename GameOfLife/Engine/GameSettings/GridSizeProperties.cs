using System;
using System.Linq;

namespace GameOfLife.Engine.GameSettings
{
    public class GridSizeProperties
    {
        public int GridXSize { get; set; }
        public int GridYSize { get; set; }

        public GridSizeProperties(GridSizeProperties gridSizeProperties)
        {
            GridXSize = gridSizeProperties.GridXSize;
            GridYSize = gridSizeProperties.GridYSize;
        }
        public GridSizeProperties(int gridXSize, int gridYSize)
        {
            GridXSize = gridXSize;
            GridYSize = gridYSize;
        }
    }
}
