using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.BL
{
    class Pacman
    {
        int X;
        int Y;
        int score;
        Grid mazeGrid;

        public Pacman(int X, int Y, Grid mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.mazeGrid = mazeGrid;
            this.mazeGrid.GetDownCell(new Cell(' ', X, Y-1)).SetValue('P');
        }

        public void Remove()
        {
            mazeGrid.GetDownCell(new Cell(' ', X, Y - 1)).SetValue(' ');
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }

        public void Draw()
        {
            mazeGrid.GetDownCell(new Cell(' ', X, Y - 1)).SetValue('P');
            Console.SetCursorPosition(X, Y);
            Console.Write('P');
        }

        public void MoveLeft(Cell current, Cell next)
        {
            if (next.GetValue() == ' ' || next.GetValue() == '.')
            {
                if (next.GetValue() == '.')
                {
                    score += 5;
                    next.SetValue(' ');
                }
                Remove();
                X = next.GetX();
                Draw();
            }
        }

        public void MoveRight(Cell current, Cell next)
        {
            if (next.GetValue() == ' ' || next.GetValue() == '.')
            {
                if (next.GetValue() == '.')
                {
                    score += 5;
                    next.SetValue(' ');
                }
                Remove();
                X = next.GetX();
                Draw();
            }
        }

        public void MoveUp(Cell current, Cell next)
        {
            if (next.GetValue() == ' ' || next.GetValue() == '.')
            {
                if (next.GetValue() == '.')
                {
                    score += 5;
                    next.SetValue(' ');
                }
                Remove();
                Y = next.GetY();
                Draw();
            }
        }

        public void MoveDown(Cell current, Cell next)
        {
            if (next.GetValue() == ' ' || next.GetValue() == '.')
            {
                if (next.GetValue() == '.')
                {
                    score += 5;
                    next.SetValue(' ');
                }
                Remove();
                Y = next.GetY();
                Draw();
            }
        }

        public void Move()
        {
            
            Cell cell = new Cell(' ', X, Y);
            if (KeyBoard.IsKeyPressed(Key.UpArrow))
            {
                MoveUp(cell, mazeGrid.GetUpCell(cell));
                cell = new Cell(' ', X, Y);//bug fix
            }
            else if(KeyBoard.IsKeyPressed(Key.DownArrow))
            {
                MoveDown(cell, mazeGrid.GetDownCell(cell));
                cell = new Cell(' ', X, Y);//bug fix
            }
            if (KeyBoard.IsKeyPressed(Key.LeftArrow))
            {
                MoveLeft(cell, mazeGrid.GetLeftCell(cell));
            }
            else if (KeyBoard.IsKeyPressed(Key.RightArrow))
            {
                MoveRight(cell, mazeGrid.GetRightCell(cell));
            }
        }

        public void PrintScore()
        {
            Console.SetCursorPosition(100, 10);
            Console.WriteLine(score);
        }
    }
}
