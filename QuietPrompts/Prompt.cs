using System.Windows;
using System.Windows.Media;

namespace QuietPrompts
{
    public static class Prompt
    {
        public static void Error(string text, string? title = null, PromptOptions? options = null)
        {
            var opts = options ?? new PromptOptions
            {
                MainText = text,
                WindowTitle = title ?? "Error",
                IconPath = "pack://application:,,,/ErrorIconPath.png", // Replace
                ForegroundColor = new SolidColorBrush(Colors.Red)
            };
            ShowPrompt(opts);
        }

        public static void Warning(string text, string? title = null, PromptOptions? options = null)
        {
            var opts = options ?? new PromptOptions
            {
                MainText = text,
                WindowTitle = title ?? "Warning",
                IconPath = "pack://application:,,,/WarningIconPath.png", // Replace
                ForegroundColor = new SolidColorBrush(Colors.Orange)
            };
            ShowPrompt(opts);
        }

        public static void Info(string text, string? title = null, PromptOptions? options = null)
        {
            var opts = options ?? new PromptOptions
            {
                MainText = text,
                WindowTitle = title ?? "Info",
                IconPath = "pack://application:,,,/InfoIconPath.png", // Replace
                ForegroundColor = new SolidColorBrush(Colors.Blue)
            };
            ShowPrompt(opts);
        }

        private static void ShowPrompt(PromptOptions options)
        {
            var window = new PromptWindow(options);
            window.ShowDialog();
        }
    }
}