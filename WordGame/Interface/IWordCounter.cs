using System.Collections.Generic;

namespace Interface
{
    public interface IWordCounter
    {
        int frequency { get; set; }
        string word { get; set; }
        List<string> wordInParagraph { get; set; }

        void FindWordInList(string strToFind, List<string> lstToSearchFrom);
        void FindWordInList(string strToFind, string strToSearchFrom);
    }
}