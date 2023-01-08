using System;
using System.Text;

namespace Hardsoft.BruteForcer.Algorithms
{
    public class DefaultBruteForceAlgorithm : IBruteForceAlgorithm
    {
        public bool Start(int passwordCharacterLengthToTest, char[] charactersToTest, Func<string, bool> test)
        {
            var charactersLength = charactersToTest.Length;

            var passwordCharIndexes = new int[passwordCharacterLengthToTest];

            int indexOfFirstDigit = passwordCharIndexes.Length - 1;

            StringBuilder password = new StringBuilder();

            while (passwordCharIndexes[0] < charactersLength)
            {
                password.Clear();
                for (int i = 0; i < passwordCharIndexes.Length; i++)
                {
                    password.Append(charactersToTest[passwordCharIndexes[i]]);
                }

                var isMatched = test.Invoke(password.ToString());

                if (isMatched)
                    return true;

                passwordCharIndexes[indexOfFirstDigit]++;

                for (int i = indexOfFirstDigit; i > 0; i--)
                {
                    if (passwordCharIndexes[i] == charactersLength)
                    {
                        passwordCharIndexes[i] = 0;
                        passwordCharIndexes[i - 1]++;
                    }
                }
            }

            return false;
        }
    }
}