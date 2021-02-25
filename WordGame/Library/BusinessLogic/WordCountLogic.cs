using Interface;
using Library.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BusinessLogic
{
    public class WordCountLogic : IWordCountLogic
    {
        private string Directory { get; set; }
        private string WordFilename { get; set; }
        private string LookUpFilename { get; set; }
        public List<string> ParagraphList { get; set; }
        public string LookUpText { get; set; }
        private IEnumerable<string> WordList { get; set; }


        public WordCountLogic()
        {

        }
        public WordCountLogic(string directory, string wordFilename, string lookupFileName)
        {
            this.Directory = directory;
            this.WordFilename = wordFilename;
            this.LookUpFilename = lookupFileName;            
        }

        public void Produce()
        {   
            try
            {
                //Get File
                ReadFile();

                //Convert source lookup to identify where the word belongs to a paragraph(element)
                ConvertLookUpToParagraph();

                //Process word frequency and it's element
                CountWords();
            }
            catch (Exception)
            {
                Console.ReadLine();
            }
           
        }

        private void ReadFile()
        {
            var fs = new FileStreamer(Directory, WordFilename);
            WordList = fs.ReadByLine();

            fs.FileName = LookUpFilename;
            LookUpText = fs.ReadAllText();
        }

        public void ConvertLookUpToParagraph()
        {
            ParagraphList = StringManipulation.ConvertLookUpToList(LookUpText);
        }

        private void CountWords()
        {
            int ctrIndex = 65; // starting numeric index of a alphabet, 65=a, 66=b etc
            int ctrIndexMax = 90; // last numeric index of a alphabet, 90=z
            int multiplier = 1;

            foreach (var word in WordList)
            {
                var wc = new WordCounter();
                wc.FindWordInList(word, ParagraphList);

                string joined = StringManipulation.Join(",", wc.wordInParagraph);

                string alphabet = StringManipulation.IntToAlphabet(ctrIndex);

                string strIndex = new StringBuilder().Insert(0, alphabet, multiplier).ToString();

                Console.WriteLine($"{strIndex}. {word} {{{wc.frequency.ToString()}:{joined}}})");

                if (ctrIndex == ctrIndexMax)
                {
                    ctrIndex = 65;
                    multiplier++;
                }
                else
                {
                    ctrIndex++;
                }
            }
            Console.ReadLine();
        }
    }
}
