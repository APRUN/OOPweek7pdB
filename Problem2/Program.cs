using Problem2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Card cardShown;
            Card PredictionCard;
            bool userPrediction;
            Deck deck = new Deck();
            float score = 0;
            int gamesPlayed = 0;
            deck.Shuffle();
            cardShown = deck.DealCard();
            bool running = true;
            while (running)
            {
                ShowCard(cardShown);
                userPrediction = TakeUserPrediction();
                PredictionCard = deck.DealCard();
                if ((PredictionCard.GetValue() > cardShown.GetValue() && userPrediction == true) || (PredictionCard.GetValue() < cardShown.GetValue() && userPrediction == false) && deck.CardsLeft()!=0)
                {
                    score+=2.5F;
                    cardShown = PredictionCard;
                }
                else
                {
                    gamesPlayed++;
                    deck = new Deck();
                    deck.Shuffle();
                    running = ContinuePlaying();
                }
            }
            PrintAverageScore(score / gamesPlayed);
        }
        static void PrintAverageScore(float score)
        {
            Console.WriteLine("Your average score is : {0}", score);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        static void ShowCard(Card card)
        {
            Console.WriteLine("Card is : {0}", card.AsString());
        }
        static bool ContinuePlaying()
        {
            Console.WriteLine("Do you want to Continue playing[yes/no]: ");
            string input = Console.ReadLine();
            while (true)
            {
                if (input.ToLower() == "yes")
                {
                    return true;
                }
                else if (input.ToLower() == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input,it should be 'yes' or 'no'");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
            }
        }
        static bool TakeUserPrediction()
        {
            while (true)
            {
                Console.WriteLine("predict weather the next would be higher or lower: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "higher")
                {
                    return true;
                }
                else if (input.ToLower() == "lower")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("invalid input,it should be 'higher' or 'lower'");
                    Console.WriteLine("press enter to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}
