using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardsoft.BruteForcer.Chars;

namespace Hardsoft.BruteForcer
{
    public interface IBruteForcer
    {
        public bool Start(
            int passwordCharacterLengthToTest,
            char[] charactersToTest,
            Func<string, bool> test);

        public bool Start(
            int passwordCharacterLengthToTest,
            CharGroup charGroup,
            Func<string, bool> test);

        public bool Start(
            int minPasswordCharacterLengthToTest,
            int maxPasswordCharacterLengthToTest,
            char[] charactersToTest,
            Func<string, bool> test);

        public bool Start(
            int minPasswordCharacterLengthToTest,
            int maxPasswordCharacterLengthToTest,
            CharGroup charGroup,
            Func<string, bool> test);
    }
}