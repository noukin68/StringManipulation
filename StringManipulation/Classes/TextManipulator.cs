using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace StringManipulation.Classes
{
    public class TextManipulator
    {
        private static readonly Regex WordRegex = new Regex(@"\b\w+\b", RegexOptions.Compiled);

        private static string GetTextFromRichTextBox(RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
        }

        public string AddSpaceBeforeCapitalLetters(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string result = Regex.Replace(text, @"([A-Z])", " $1");
            return result;
        }

        public string AddSpacesBetweenCharacters(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string result = string.Join(" ", text.ToCharArray());
            return result;
        }

        public string ReplaceCharacters(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string result = text.Replace("-+", "0");
            return result;
        }

        public string ReplaceWithNextCharacter(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string result = new string(text.Select(c => c == 'я' ? ' ' : (char)(Convert.ToInt32(c) + 1)).ToArray());
            return result;
        }

        public string ReplaceWithPreviousCharacter(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string result = new string(text.Select(c => c == 'а' ? ' ' : (char)(Convert.ToInt32(c) - 1)).ToArray());
            return result;
        }

        public string InsertCharacterCodes(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string result = string.Join(" ", text
                .Where(c => c != '\r' && c != '\n')
                .Select(c => $"{c}{(int)c}"));
            return result.Trim();

        }

        public string GetEvenOddCharacters(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string evenChars = new string(text.Where((c, i) => i % 2 == 0).ToArray());
            string oddChars = new string(text.Where((c, i) => i % 2 != 0).ToArray());
            return $"Четные индексы: {evenChars}\nНечетные индексы: {oddChars}";
        }

        public string CombineStrings(RichTextBox richTextBox1, RichTextBox richTextBox2)
        {
            string text1 = GetTextFromRichTextBox(richTextBox1);
            string text2 = GetTextFromRichTextBox(richTextBox2);
            string result = string.Concat(text1.Zip(text2, (c1, c2) => $"{c1}{c2}"));
            return result;
        }

        public string AppendWordLengths(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string result = WordRegex.Replace(text, match => $"{match.Value}{match.Length}");
            return result;
        }

        public string GetPenultimateWord(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string[] words = text.Split(' ');
            string penultimateWord = words.ElementAtOrDefault(words.Length - 2);
            return penultimateWord ?? string.Empty;

        }

        public string ReplaceMultipleSpaces(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string result = Regex.Replace(text, @" {2,}", match => match.Value.Length % 2 == 0 ? "Ч" : "Н");
            return result;
        }

        public string InsertCharacterCodesByLanguage(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string result = string.Empty;
            foreach (char c in text)
            {
                if (IsRussianLetter(c))
                {
                    result += $"{c}{Convert.ToInt32(c)}";
                }
                else if (IsLatinLetter(c))
                {
                    result += $"{c} ";
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        public string InsertBracketsAfterMathWords(RichTextBox richTextBox)
        {
            string text = GetTextFromRichTextBox(richTextBox);
            string result = Regex.Replace(text, @"\b(sin|cos|log)\b", "$1(");
            return result;
        }

        private static bool IsRussianLetter(char c)
        {
            return c >= 'а' && c <= 'я' || c >= 'А' && c <= 'Я';
        }

        private static bool IsLatinLetter(char c)
        {
            return c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z';
        }
    }
}
