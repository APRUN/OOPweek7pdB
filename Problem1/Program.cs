using Problem1.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "maze.txt";

            Grid mazeGrid = new Grid(24, 71, path);

            Pacman player = new Pacman(32, 9, mazeGrid);
            Ghost ghost1 = new Ghost(39, 15, 'H', "left", 0.1F, ' ', mazeGrid);
            Ghost ghost2 = new Ghost(57, 20, 'V', "up", 0.2F, ' ', mazeGrid);
            Ghost ghost3 = new Ghost(26, 19, 'R', "up", 1F, ' ', mazeGrid);
            Ghost ghost4 = new Ghost(21, 18, 'C', "up", 0.5F, ' ', mazeGrid);
           

            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(ghost1);
            enemies.Add(ghost2);
            enemies.Add(ghost3);
            enemies.Add(ghost4);
            mazeGrid.Draw();
            player.Draw();

            bool gameRunning = true;
            while(gameRunning)
            {
                Thread.Sleep(90);

                player.PrintScore();
                player.Remove();
                player.Move();
                player.Draw();

               foreach(Ghost ghost in enemies)
                {
                    ghost.Remove();
                    ghost.Move();
                    ghost.Draw();
                }
                if(mazeGrid.IsStoppingCondition())
                {
                    gameRunning = false;
                }
            }
        }
    }
}
