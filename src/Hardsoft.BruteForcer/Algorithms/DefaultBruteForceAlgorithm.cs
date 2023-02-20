using Microsoft.Extensions.ObjectPool;
using System;
using System.Text;

namespace Hardsoft.BruteForcer.Algorithms
{
    public class DefaultBruteForceAlgorithm : IBruteForceAlgorithm
    {


        public bool Start(
            int passwordCharLengthToTest,
            char[] charsToTest,
            Func<string, bool> test,
            Dictionary<int, char>? knownChars = null)
        {
            var testPassword = new StringBuilder();

            int[] testPasswordCharIndexes = new int[passwordCharLengthToTest - (knownChars?.Count ?? 0)];

            int indexOfFirstDigit = testPasswordCharIndexes.Length - 1;

            int testCharsLength = charsToTest.Length;

            while (testPasswordCharIndexes[0] < testCharsLength)
            {
                testPassword.Clear();

                for (int i = 0, x = 0; i < passwordCharLengthToTest; i++)
                {
                    if ((knownChars?.ContainsKey(i) ?? false))
                        testPassword.Append(knownChars[i]);
                    else
                        testPassword.Append(charsToTest[testPasswordCharIndexes[x++]]);
                }

                var isMatched = test.Invoke(testPassword.ToString());

                if (isMatched)
                    return true;

                testPasswordCharIndexes[indexOfFirstDigit]++;

                for (int i = indexOfFirstDigit; i > 0; i--)
                {
                    if (testPasswordCharIndexes[i] == testCharsLength)
                    {
                        testPasswordCharIndexes[i] = 0;
                        testPasswordCharIndexes[i - 1]++;
                    }
                }
            }

            return false;
        }
    }
}