using System.Collections.Generic;
using System.Linq;

namespace Library.Helper
{
    public static class StringManipulation
    {
        public static List<string> ConvertLookUpToList(string lookUpText)
        {
            string[] wordexception = { "Mr.", "Mrs.", "e.g." }; // can be put to config

            char find = '.';
            int startIndex = 0;
            int nextIndex = 0;
            int lookUplength = lookUpText.Length;
            var paragraphList = new List<string>();
            while (startIndex < lookUplength)
            {
                var foundString = lookUpText.IndexOf(find, nextIndex);
                var getSpaceLeft = lookUpText.LastIndexOf(' ', foundString);
                var getSpaceRight = lookUpText.IndexOf(' ', foundString);
                if (getSpaceRight != -1)
                {
                    var word = lookUpText.Substring(getSpaceLeft, getSpaceRight - getSpaceLeft);
                    if (wordexception.Contains(word.Trim()) == false)
                    {
                        paragraphList.Add(lookUpText.Substring(startIndex, foundString - startIndex));
                        startIndex = foundString + 1;
                    }
                    nextIndex = foundString + 1;
                }
                else
                {
                    var word = lookUpText.Substring(getSpaceLeft, lookUplength - getSpaceLeft);
                    if (wordexception.Contains(word.Trim()) == false)
                    {
                        paragraphList.Add(lookUpText.Substring(startIndex, foundString - startIndex));
                        startIndex = foundString + 1;
                    }
                    break;
                }
            }
            return paragraphList;
        }

        public static string Join(string delimiter, List<string> toJoin)
        {
            return string.Join(",", toJoin.ToArray());
        }

        public static string IntToAlphabet(int number)
        {
            return ((char)number).ToString().ToLower();
        }

    }
}
