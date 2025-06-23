using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace QuietPrompts
{
    public class PromptBuilder
    {
        private readonly PromptOptions _options = new();

        public PromptBuilder WithTitle(string title)
        {
            _options.WindowTitle = title;
            return this;
        }

        public PromptBuilder WithIcon(string iconPath)
        {
            _options.IconPath = iconPath;
            return this;
        }

        public PromptBuilder WithButton(string text, Color? color = null, Action? action = null)
        {
            if (_options.Buttons == null)
                _options.Buttons = new ObservableCollection<PromptButton>();

            _options.Buttons.Add(new PromptButton(text,
                color.HasValue ? new SolidColorBrush(color.Value) : null,
                action != null ? new RelayCommand(action) : null));
            return this;
        }

        public PromptBuilder WithText(string text)
        {
            _options.MainText = text;
            return this;
        }

        public PromptBuilder WithBackground(Color color)
        {
            _options.BackgroundColor = new SolidColorBrush(color);
            return this;
        }

        public PromptBuilder WithForeground(Color color)
        {
            _options.ForegroundColor = new SolidColorBrush(color);
            return this;
        }

        public PromptBuilder WithTitleBar(bool visible)
        {
            _options.ShowTitleBar = visible;
            return this;
        }

        public void Show()
        {
            var window = new PromptWindow(_options);
            window.ShowDialog();
        }
    }

    public class RelayCommand : System.Windows.Input.ICommand
    {
        private readonly Action _execute;
        public RelayCommand(Action execute) => _execute = execute;
        public bool CanExecute(object? parameter) => true;
        public void Execute(object? parameter) => _execute();
        public event EventHandler? CanExecuteChanged { add { } remove { } }
    }

}