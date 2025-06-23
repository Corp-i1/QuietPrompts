using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace QuietPrompts
{
    public partial class PromptWindow : Window
    {
        public PromptOptions Options { get; }

        public PromptWindow(PromptOptions options)
        {
            Options = options;
            DataContext = Options;
            Loaded += PromptWindow_Loaded;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is PromptButton promptButton)
            {
                if (promptButton.Action?.CanExecute(null) == true)
                {
                    promptButton.Action.Execute(null);
                }
            }
            this.DialogResult = true;
            this.Close();
        }

        private void PromptWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Find the TextBlock for main text (assumes it's the only one in row 2)
            var mainTextBlock = FindMainTextBlock();
            if (mainTextBlock != null)
            {
                mainTextBlock.Inlines.Clear();
                foreach (var inline in ParseColorMarkup(Options.MainText))
                    mainTextBlock.Inlines.Add(inline);
            }
        }

        private TextBlock FindMainTextBlock()
        {
            // Assumes the main text TextBlock is the first in row 2
            foreach (var child in ((Grid)Content).Children)
            {
                if (child is TextBlock tb && Grid.GetRow(tb) == 2)
                    return tb;
            }
            return null;
        }

        // Simple parser for <color>text</color> tags (e.g., <red>Warning</red>)
        private static Inline[] ParseColorMarkup(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new Inline[] { new Run("") };

            var inlines = new List<Inline>();
            var regex = new Regex(@"<(\w+)>(.*?)<\/\1>", RegexOptions.IgnoreCase);
            int lastIndex = 0;

            foreach (Match match in regex.Matches(text))
            {
                if (match.Index > lastIndex)
                {
                    inlines.Add(new Run(text.Substring(lastIndex, match.Index - lastIndex)));
                }

                var colorName = match.Groups[1].Value;
                var innerText = match.Groups[2].Value;
                var run = new Run(innerText);

                try
                {
                    run.Foreground = (Brush)new BrushConverter().ConvertFromString(colorName);
                }
                catch
                {
                    run.Foreground = Brushes.Black;
                }

                inlines.Add(run);
                lastIndex = match.Index + match.Length;
            }

            if (lastIndex < text.Length)
            {
                inlines.Add(new Run(text.Substring(lastIndex)));
            }

            return inlines.ToArray();
        }
    }
}
