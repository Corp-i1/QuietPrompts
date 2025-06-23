using QuietPrompts;
using System.Windows.Media;

namespace Quiet_Prompts
{
    internal class Main
    {
        internal void main()
        {
            Logger.IntLog();

            var options = new PromptOptions
            {
                MainTitle = "Hello!",
                MainText = "This is a custom prompt.",
                WindowTitle = "Sample Prompt",
                BackgroundColor = new SolidColorBrush(Colors.White),
                ForegroundColor = new SolidColorBrush(Colors.Black)
            };

            PromptWindow promptWindow = new PromptWindow(options);
            promptWindow.Show();
        }
    }
}