using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Objects;

namespace Cards
{
    public class Pack
    {
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private IDictionary<Suit, Dictionary<Value, PlayingCard>> _cardPack;

        private readonly Random randomCardSelector = new Random();

        public Pack()
        {

            _cardPack = new SortedDictionary<Suit, Dictionary<Value, PlayingCard>>();

            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {

                Dictionary<Value, PlayingCard> cardsInSuit = new Dictionary<Value, PlayingCard>();
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    cardsInSuit.Add(value, new PlayingCard(suit, value));
                }
                _cardPack.Add(suit, cardsInSuit);
            }
        }

        public PlayingCard DealCardFromPack()
        {
            Suit suit = (Suit)randomCardSelector.Next(NumSuits);
            while (IsSuitEmpty(suit))
            {
                suit = (Suit)randomCardSelector.Next(NumSuits);
            }

            Value value = (Value)randomCardSelector.Next(CardsPerSuit);
            while (IsCardAlreadyDealt(suit, value))
            {
                value = (Value)randomCardSelector.Next(CardsPerSuit);
            }

            Dictionary<Value, PlayingCard> cardsInSuit = _cardPack[suit];
            PlayingCard card = cardsInSuit[value];
            cardsInSuit.Remove(value);
            return card;
        }

        private bool IsSuitEmpty(Suit suit)
        {
            bool result = true;

            for (Value value = Value.Two; value <= Value.Ace; value++)
            {
                if (IsCardAlreadyDealt(suit, value)) continue;
                result = false;
                break;
            }

            return result;
        }

        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
            Dictionary<Value, PlayingCard> cardsInSuit = _cardPack[suit];
            return (!cardsInSuit.ContainsKey(value));
        }
    }
}
