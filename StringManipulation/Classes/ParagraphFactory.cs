using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

namespace StringManipulation.Classes
{
    public class ParagraphFactory
    {
        public static Paragraph CreateParagraph(string taskLabel, string result)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(new Run(taskLabel) { FontWeight = FontWeights.Bold });
            paragraph.Inlines.Add(new Run(":\n") { FontWeight = FontWeights.Bold });
            paragraph.Inlines.Add(new Run(result) { Foreground = Brushes.Blue });
            paragraph.Margin = new Thickness(0, 0, 0, 10);
            return paragraph;
        }
    }
}
