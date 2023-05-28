using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem2.BL
{
    class Deck
    {
        public Deck()
        {
            for (int suit = 0; suit < 4; suit++)
            {
                for (int value = 0; value < 52 / 4; value++)
                {
                    cards.Add(new Card(value, suit));
                }
            }
        }
        List<Card> cards = new List<Card>();
        public void Shuffle()
        {
            Random random = new Random();
                for (int i = 0; i < cards.Count; i++)
                {
                int randomIndex = i + random.Next(52 - i);
                Card temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
                }
        }
        public Card DealCard()
        {
            Card card;
            if(cards.Count>0)
            {
                card = cards.First();
                cards.Remove(card);
            }
            else
            {
                card = null;
            }
            return card;
        }
        public int CardsLeft()
        {
            return cards.Count;
        }
    }
}
