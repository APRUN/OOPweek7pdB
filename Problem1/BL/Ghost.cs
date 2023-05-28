using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.BL
{
    class Ghost
    {
        int X;
        int Y;
        string ghostDirection;
        char ghostCharacter;
        float speed;
        char previousItem;
        float deltaChange;
        Grid mazeGrid;

        public Ghost(int X, int Y, char ghostCharacter, string ghostDirection, float speed, char previousItem, Grid mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.ghostCharacter = ghostCharacter;
            this.ghostDirection = ghostDirection;
            this.speed = speed;
            this.previousItem = previousItem;
            this.mazeGrid = mazeGrid;
            this.mazeGrid.GetDownCell(new Cell(' ', X, Y-1)).SetValue(ghostCharacter);
        }

        public void SetDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }

        public string GetDirection()
        {
            return ghostDirection;
        }

        public void Remove()
        {
            mazeGrid.GetDownCell(new Cell(' ', X, Y - 1)).SetValue(previousItem);
            Console.SetCursorPosition(X, Y);
            Console.Write(previousItem);
        }

        public void Draw()
        {
            mazeGrid.GetDownCell(new Cell(' ', X, Y - 1)).SetValue(ghostCharacter);
            Console.SetCursorPosition(X, Y);
            Console.Write(ghostCharacter);
        }

        public char GetCharacter()
        {
            return ghostCharacter;
        }

        public void ChangeDelta()
        {
            deltaChange += speed;
        }

        public float GetDelta()
        {
            return deltaChange;
        }

        public void SetDeltaZero()
        {
            deltaChange = 0;
        }

        public void Move()
        {
            ChangeDelta();
            if (Math.Floor(GetDelta()) == 1)
            {
                Remove();
                if (ghostCharacter=='H')
                {
                    MoveHorizontal();
                }
                else if (ghostCharacter == 'V')
                {
                    MoveVertical();
                }
                else if (ghostCharacter == 'R')
                {
                    MoveRandom();
                }
                else if (ghostCharacter == 'C')
                {
                    MoveSmart();
                }
                Draw();
                SetDeltaZero();
            }
        }

        public void MoveHorizontal()
        {
            if (ghostDirection == "left")
            {
                Cell next = mazeGrid.GetLeftCell(new Cell(' ',X,Y));
                if (next.GetValue() == ' ' || next.GetValue() == '.')
                {
                    previousItem = next.GetValue();
                    X = next.GetX();
                }
                else
                {
                    ghostDirection = "right";
                }
            }
            else if (ghostDirection == "right")
            {
                Cell next = mazeGrid.GetRightCell(new Cell(' ', X, Y));
                if (next.GetValue() == ' ' || next.GetValue() == '.')
                {
                    previousItem = next.GetValue();
                    X = next.GetX();
                }
                else
                {
                    ghostDirection = "left";
                }
            }
        }

        public void MoveVertical()
        {
            if (ghostDirection == "up")
            {
                Cell next = mazeGrid.GetUpCell(new Cell(' ', X, Y));
                if (next.GetValue() == ' ' || next.GetValue() == '.')
                {
                    previousItem = next.GetValue();
                    Y = next.GetY();
                }
                else
                {
                    ghostDirection = "down";
                }
            }
            else if (ghostDirection == "down")
            {
                Cell next = mazeGrid.GetDownCell(new Cell(' ', X, Y));
                if (next.GetValue() == ' ' || next.GetValue() == '.')
                {
                    previousItem = next.GetValue();
                    Y = next.GetY();
                }
                else
                {
                    ghostDirection = "up";
                }
            }
        }
        public int GenerateRandom()
        {
           return new Random().Next(0, 4);
        }

        public void MoveRandom()
        {
            int random = GenerateRandom();
            Cell currentCell = new Cell(' ', X, Y);
            Cell next;
            switch(random)
            {
                case 0:
                    next = mazeGrid.GetUpCell(currentCell);
                    break;
                case 1:
                    next = mazeGrid.GetDownCell(currentCell);
                    break;
                case 2:
                    next = mazeGrid.GetLeftCell(currentCell);
                    break;
                default:
                    next = mazeGrid.GetRightCell(currentCell);
                    break;
            }
            if (next.GetValue() == ' ' || next.GetValue() == '.')
            {
                previousItem = next.GetValue();
                X = next.GetX();
                Y = next.GetY();
            }
        }

        public void MoveSmart()
        {
            Cell next;
            Cell PlayerCell = mazeGrid.FindPacman();

            if (PlayerCell.GetY() < Y)
            {
                next = mazeGrid.GetUpCell(new Cell(' ', X, Y));
                if (next.GetValue() == ' ' || next.GetValue() == '.')
                {
                    previousItem = next.GetValue();
                    X = next.GetX();
                    Y = next.GetY();
                }
            }
            else
            {
                next = mazeGrid.GetDownCell(new Cell(' ', X, Y));
                if (next.GetValue() == ' ' || next.GetValue() == '.')
                {
                    previousItem = next.GetValue();
                    X = next.GetX();
                    Y = next.GetY();
                }
            }
            if (PlayerCell.GetX() < X)
            {
                next = mazeGrid.GetLeftCell(new Cell(' ', X, Y));
                if (next.GetValue() == ' ' || next.GetValue() == '.')
                {
                    previousItem = next.GetValue();
                    X = next.GetX();
                    Y = next.GetY();
                }
            }
            else
            {
                next = mazeGrid.GetRightCell(new Cell(' ', X, Y));
                if (next.GetValue() == ' ' || next.GetValue() == '.')
                {
                    previousItem = next.GetValue();
                    X = next.GetX();
                    Y = next.GetY();
                }
            }
        }

        public double CalculateDistance(Cell current, Cell pacmanLocation)
        {
            return Math.Sqrt(Math.Pow(current.GetX() + current.GetY(), 2) + Math.Pow(current.GetX() + current.GetY(), 2));
        }
    }
}
