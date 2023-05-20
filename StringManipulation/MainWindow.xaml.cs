using StringManipulation.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StringManipulation
{
    public partial class MainWindow : Window
    {
        private TextManipulator manipulator;
        public MainWindow()
        {
            InitializeComponent();
            manipulator = new TextManipulator();
            string initialText = "HelloWorld+abc-XYZ яблокоsin cos log-+";
            textInput.AppendText(initialText);

        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = new TextRange(textInput.Document.ContentStart, textInput.Document.ContentEnd).Text;
            FlowDocument resultDocument = new FlowDocument();

            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task1, manipulator.AddSpaceBeforeCapitalLetters(textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task2, manipulator.AddSpacesBetweenCharacters(textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task3, manipulator.ReplaceCharacters(textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task4, manipulator.ReplaceWithNextCharacter(textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task5, manipulator.ReplaceWithPreviousCharacter(textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task6, manipulator.InsertCharacterCodes(textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task7, manipulator.GetEvenOddCharacters(textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task8, manipulator.CombineStrings(textInput, textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task9, manipulator.AppendWordLengths(textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task10, manipulator.GetPenultimateWord(textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task11, manipulator.ReplaceMultipleSpaces(textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task12, manipulator.InsertCharacterCodesByLanguage(textInput)));
            resultDocument.Blocks.Add(ParagraphFactory.CreateParagraph(TaskLabels.Task13, manipulator.InsertBracketsAfterMathWords(textInput)));

            resultOutput.Document = resultDocument;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            resultOutput.Document.Blocks.Clear();
        }
    }
}