using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.BL
{
    class Card
    {
        public Card(int value,int suit)
        {
            this.value=value;
            this.suit=suit;
        }
        int value;
        int suit;
        public int GetSuit()
        {
            return suit;
        }
        public int GetValue()
        {
            return value;
        }
        public string GetValueAsString()
        {
            string output;
            if(value==1)
            {
                output = "Ace";
            }
            else if(value==11)
            {
                output = "Jack";
            }
            else if (value==12)
            {
                output = "Queen";
            }
            else if(value==13)
            {
                output = "King";
            }
            else
            {
                output = value.ToString();
            }
            return output;
        }
        public string GetSuitAsString()
        {
            string output;
            switch(value)
            {
                case 1:
                    output = "Clubs";
                    break;
                case 2:
                    output = "Diamonds";
                    break;
                case 3:
                    output = "Hearts";
                    break;
                default:
                    output = "Spades";
                    break;
            }
            return output;
        }
        public string AsString()
        {
            return GetValueAsString() + " of " + GetSuitAsString();
        }
    }
}
