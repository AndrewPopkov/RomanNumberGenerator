namespace romansNumberGenerator
{
    public class RomanCharacter
    {
        public int arabicSymbol { get; set; }
        public char romanSymbol { get; set; }
        public int rankNumber { get; set; }
        public bool isLastSymbolInRank { get; set; }

        public override string ToString()
        {
            return romanSymbol.ToString();
        }
    }
}