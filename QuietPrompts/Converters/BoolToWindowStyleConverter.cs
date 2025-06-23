using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace QuietPrompts.Converters
{
    public class BoolToWindowStyleConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool showTitleBar)
                return showTitleBar ? WindowStyle.SingleBorderWindow : WindowStyle.None;
            return WindowStyle.SingleBorderWindow;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}