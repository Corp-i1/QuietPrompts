using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Input;

namespace QuietPrompts
{
    public class PromptButton
    {
        public string Text { get; set; }
        public Brush Color { get; set; }
        public ICommand Action { get; set; }

        public PromptButton(string text, Brush color = null, ICommand action = null)
        {
            Text = text;
            Color = color;
            Action = action;
        }
    }

    public class PromptOptions
    {
        public ImageSource Icon { get; set; }
        public bool TitleBarVisible { get; set; } = true;
        public string WindowTitle { get; set; } = "Prompt";
        public string MainTitle { get; set; } = "Prompt";
        public string MainText { get; set; } = "This is a prompt message.";
        public string Sound { get; set; } = "none";
        public ObservableCollection<PromptButton> Buttons { get; set; } = new();
        public Brush BackgroundColor { get; set; } = Brushes.White;
        public Brush ForegroundColor { get; set; } = Brushes.Black;
        public bool ShowTitleBar { get; internal set; } = true;
        public string IconPath { get; internal set; } = "Prompt";
    }
}