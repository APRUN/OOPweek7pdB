using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.BL
{
    class Grid
    {
        Cell[,] maze;
        int rowSize;
        int colSize;

        public Grid(int rowSize, int colSize, string path)
        {
            this.rowSize = rowSize;
            this.colSize = colSize;
            maze = new Cell[rowSize, colSize];
            StreamReader file = new StreamReader(path);
            string line;
            int y = 0;
            while ((line = file.ReadLine()) != null)
            {
                for (int x = 0; x < colSize; x++)
                {
                    maze[y, x] = new Cell(line[x], x, y);
                }
                y++;
            }
        }

        public Cell GetLeftCell(Cell cell)
        {
            return maze[cell.GetY(), cell.GetX() - 1];
        }

        public Cell GetRightCell(Cell cell)
        {
            return maze[cell.GetY(), cell.GetX() + 1];
        }

        public Cell GetUpCell(Cell cell)
        {
            return maze[cell.GetY() - 1, cell.GetX()];
        }

        public Cell GetDownCell(Cell cell)
        {
            return maze[cell.GetY() + 1, cell.GetX()];
        }

        public Cell FindPacman()
        {
            foreach(Cell cell in maze)
            {
                if(cell.IsPacmanPresent())
                {
                    return cell;
                }
            }
            return null;
        }

        public Cell FindGhost(char ghostCharacter)
        {
            foreach (Cell cell in maze)
            {
                if (cell.IsGhostPresent(ghostCharacter))
                {
                    return cell;
                }
            }
            return null;
        }

        public bool IsStoppingCondition()
        {
            foreach(Cell cell in maze)
            {
                if(cell.IsPacmanPresent())
                {
                    for(int i=-1;i<2;i++)
                    {
                        for(int j=-1;j<2;j++)
                        {
                            char testChar = maze[cell.GetY() + i, cell.GetX() + j].GetValue();
                            if (testChar=='H'||testChar=='V'||testChar=='R'||testChar=='C')
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void Draw()
        {
            for(int i =0;i<rowSize;i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    Console.Write(maze[i,j].GetValue());
                }
                Console.Write('\n');
            }
        }
    }
}
