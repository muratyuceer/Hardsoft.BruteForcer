namespace Hardsoft.BruteForcer.Chars
{
    [Flags]
    public enum CharGroup
    {
        Numberic = 0b001,
        Alpha = 0b010,
        Special = 0b100,
        All = 0b111
    }
}