using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMountain
{
    public class Question
    {
        public string Text {  get; }
        public List<string> Options { get; }
        public int CorrectOption { get; }

        public Question(string text, List<string> options, int correctOption)
        {
            Text = text;
            Options = options;
            CorrectOption = correctOption;
        }
    }
}