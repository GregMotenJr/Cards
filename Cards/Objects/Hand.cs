using Cards.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Hand
    {
        public const int HandSize = 13;
        private readonly IList _cards;

        public Hand()
        {
            _cards = new List<PlayingCard>();
        }

        public void AddCardToHand(PlayingCard cardDealt)
        {
            if (_cards.Count >= HandSize)
            {
                throw new ArgumentException("Too many cards");
            }
            _cards.Add(cardDealt);
        }

        public override string ToString()
        {
            string result = "";
            foreach (PlayingCard card in _cards)
            {
                result += card.ToString() + Environment.NewLine;
            }

            return result;
        }
    }
}
