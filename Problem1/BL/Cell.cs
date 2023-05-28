using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.BL
{
    class Cell
    {
        char Value;
        int X;
        int Y;

        public Cell(char Value, int X, int Y)
        {
            this.Value = Value;
            this.X = X;
            this.Y = Y;
        }

        public char GetValue()
        {
            return Value;
        }

        public void SetValue(char Value)
        {
            this.Value = Value;
        }

        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }

        public bool IsPacmanPresent()
        {
            return Value == 'P';
        }

        public bool IsGhostPresent(char ghostCharacter)
        {
            return Value == ghostCharacter;
        }
    }
}
