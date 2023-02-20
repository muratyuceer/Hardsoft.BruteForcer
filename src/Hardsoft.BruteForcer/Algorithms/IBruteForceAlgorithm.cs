namespace Hardsoft.BruteForcer.Algorithms
{
    public interface IBruteForceAlgorithm
    {
        public bool Start(
            int passwordCharacterLengthToTest, 
            char[] charactersToTest, 
            Func<string, bool> test,
            Dictionary<int, char>? knownChars = null);//
    }
}