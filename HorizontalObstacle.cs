using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze1
{
    public class HorizontalObstacle : Unit
    {
        private bool _obstacleDownDir = true;
        private char[,] _map;

        public HorizontalObstacle(int startX, int startY, char symbol, ConsoleRenderer renderer, char[,] map) :
            base(startX, startY, symbol, renderer)
        {
            _map = map;
        }

        public override void Update()
        {
            if (_obstacleDownDir)
            {
                if (!TryMoveLeft(_map))
                    _obstacleDownDir = false;
            }
            else
            {
                if (!TryMoveRight(_map))
                    _obstacleDownDir = true;
            }
        }
    }
}
