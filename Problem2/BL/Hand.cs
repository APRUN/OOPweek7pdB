using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.BL
{
    class Hand
    {
        public Hand() => cards = new List<Card>();
        List<Card> cards;
        public void Clear() => cards.Clear();
        public void AddCard(Card card) => cards.Add(card);
        public void RemoveCard(Card card) => cards.Remove(card);
        public void RemoveCard(int index) => cards.RemoveAt(index);
        public int GetCardsCount() => cards.Count;
        public Card GetCard(int index) => cards[index];
        public void SortBySuit() => cards.Sort((x, y) => x.GetSuit().CompareTo(y.GetSuit()));
        public void SortByValue() => cards.Sort((x, y) => x.GetValue().CompareTo(y.GetValue()));
    }
}
