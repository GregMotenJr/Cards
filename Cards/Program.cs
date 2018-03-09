using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Cards.Objects;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NumHands = 4;

            Pack pack = new Pack();
            IList<Hand> hands = new List<Hand>();

            for (int handNum = 0; handNum < NumHands; handNum++)
            {
                hands.Add(new Hand()); 
                for (int numCards = 0; numCards < Hand.HandSize; numCards++)
                {
                    PlayingCard cardDealt = pack.DealCardFromPack();
                    hands.ElementAt(handNum).AddCardToHand(cardDealt);
                }
            }


            for (int handNum = 0; handNum < NumHands; handNum++)
            {
                Console.WriteLine($"Hand {handNum + 1}: " + Environment.NewLine + hands.ElementAt(handNum));
                Console.WriteLine("===============================================");
            }


            Console.ReadKey();
        }
    }
}

    

