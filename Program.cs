using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maze1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = new[,]
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#'},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            };
            ConsoleRenderer renderer = new ConsoleRenderer();
            SetMapPixels(map, renderer);
            Player player = new Player(1, 1, renderer, map);
            HorizontalObstacle obstacle = new HorizontalObstacle(5, 3, '!', renderer, map);
            SmartEnemy enemy = new SmartEnemy(5, 8, '$', renderer, map, player);

            Units units = new Units();
            units.Add(player);
            units.Add(obstacle);

            renderer.Render();

            while (true)
            {
                foreach (Unit unit in units)
                {
                    unit.Update();
                }

                renderer.Render();

                Thread.Sleep(200);

                foreach (Unit unit in units)
                {
                    if (unit == player)
                        continue;

                if (player.X == obstacle.X && player.Y == obstacle.Y)
                    GameOver();
                }
            }
        }

        static void GameOver()
        {
            Environment.Exit(0);
        }

        static void SetMapPixels(char[,] map, ConsoleRenderer renderer)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    renderer.SetPixel(i, j, map[i, j]);
                }
            }
        }
    }
}
