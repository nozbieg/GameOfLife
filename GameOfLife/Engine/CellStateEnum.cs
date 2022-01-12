using System;
using System.Linq;
using GameOfLife.CustomAttributes;

namespace GameOfLife.Engine
{
    public enum CellStateEnum
    {
        [StringValue("[O]")]
        Alive = 0,
        [StringValue("[X]")]
        Dead = 1
    }
}
