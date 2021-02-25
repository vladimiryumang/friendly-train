using System.Collections.Generic;

namespace Interface
{
    public interface IWordCountLogic
    {
        string LookUpText { get; set; }

        List<string> ParagraphList { get; set; }

        void Produce();

        void ConvertLookUpToParagraph();
    }
}