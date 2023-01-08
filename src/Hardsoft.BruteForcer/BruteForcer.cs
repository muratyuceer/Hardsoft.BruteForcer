using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardsoft.BruteForcer.Algorithms;
using Hardsoft.BruteForcer.Chars;

namespace Hardsoft.BruteForcer
{
    public class BruteForcer : IBruteForcer
    {
        private readonly IBruteForceAlgorithm _bruteForceAlgorithm;

        public BruteForcer(IBruteForceAlgorithm? bruteForceAlgorithm = null)
        {
            _bruteForceAlgorithm = bruteForceAlgorithm ?? new DefaultBruteForceAlgorithm();
        }

        public bool Start(
            int passwordCharacterLengthToTest,
            char[] charactersToTest,
            Func<string, bool> test)
        {
            return _bruteForceAlgorithm.Start(
                passwordCharacterLengthToTest,
                charactersToTest,
                test);
        }

        public bool Start(
            int passwordCharacterLengthToTest,
            CharGroup charGroup,
            Func<string, bool> test)
        {
            return _bruteForceAlgorithm.Start(
                passwordCharacterLengthToTest,
                CharSet.GetCharSet(charGroup),
                test);
        }

        public bool Start(
            int minPasswordCharacterLengthToTest,
            int maxPasswordCharacterLengthToTest,
            char[] charactersToTest,
            Func<string, bool> test)
        {
            bool result = false;
            for (int i = minPasswordCharacterLengthToTest; i <= maxPasswordCharacterLengthToTest; i++)
            {
                result = Start(i, charactersToTest, test);
                if (result)
                    return result;
            }
            return result;
        }

        public bool Start(
            int minPasswordCharacterLengthToTest,
            int maxPasswordCharacterLengthToTest,
            CharGroup charGroup,
            Func<string, bool> test)
        {
            bool result = false;

            //Parallel.For(
            //    minPasswordCharacterLengthToTest,
            //    maxPasswordCharacterLengthToTest + 1,
            //    (i, loopState) =>
            //    {
            //        result = Start(i, charGroup, test);
            //        if (result)
            //            loopState.Stop();
            //    });

            for (int i = minPasswordCharacterLengthToTest; i <= maxPasswordCharacterLengthToTest; i++)
            {
                result = Start(i, charGroup, test);
                if (result)
                    return result;
            }

            return result;
        }
    }
}