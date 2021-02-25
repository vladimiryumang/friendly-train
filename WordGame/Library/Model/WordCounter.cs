using Interface;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class WordCounter : IWordCounter
    {
        public string word { get; set; }
        public int frequency  { get; set; }
        public List<string> wordInParagraph { get; set; }

        public WordCounter()
        {
            wordInParagraph = new List<string>();
        }
       
        public void FindWordInList(string strToFind, List<string> lstToSearchFrom)
        {
            word = strToFind;
            int index = 1;
            foreach (var item in lstToSearchFrom)
            {
                var strSplitList = item.Split(' ').ToList();
                foreach (var sen in strSplitList)
                {
                    if (sen.ToLower().TrimEnd(',') == strToFind.ToLower())
                    {
                        frequency++;
                        wordInParagraph.Add(index.ToString());
                    }
                }
                index++;
            }
        }

        public void FindWordInList(string strToFind, string strToSearchFrom)
        {
            List<string> lstToSearchFrom = strToSearchFrom.Split(' ').ToList();
            FindWordInList(strToFind, lstToSearchFrom);
        }
    }
}
