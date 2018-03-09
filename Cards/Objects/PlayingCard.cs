namespace Cards.Objects
{
    /// <summary>
    /// Represents a single playing card.
    /// </summary>
    public class PlayingCard
    {
        public Suit Suit { get; }
        public Value Value { get; }

        public PlayingCard(Suit s, Value v)
        {
            Suit = s;
            Value = v;
        }

        public override string ToString()
        {
            string result = $"{Value} of {Suit}";
            return result;
        }
    }
}
