namespace Hardsoft.BruteForcer.Chars
{
    public static class CharSet
    {
        public static char[] numbericChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static char[] alphaChars = "AaBbCcÇçDdEeFfGgĞğHhIıİiJjKkLlMmNnOoPpQqRrSsTtUuÜüVvWwXxYyZz".ToArray();
        public static char[] specialChars = "@$#*&{},[]-=.();+?'‘/\\!^%&½_~|<> ".ToArray();

        public static Dictionary<CharGroup, char[]> CharSets = new Dictionary<CharGroup, char[]>
        {
            { CharGroup.Numberic, numbericChars },
            { CharGroup.Alpha, alphaChars },
            { CharGroup.Special, specialChars },
        };

        public static char[] GetCharSet(CharGroup charGroup)
        {
            return CharSets
                .Where(p => charGroup.HasFlag(p.Key))
                .SelectMany(p => p.Value)
                .ToArray();
        }
    }
}