using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SZTGUI_LAB_4
{
    internal class FoodsEnumToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Foods)value)
            {
                case Foods.Appetizer:
                    return Brushes.LightPink;
                    break;
                case Foods.Dessert:
                    return Brushes.LightSkyBlue;
                    break;
                case Foods.Drink:
                    return Brushes.LightGreen;
                    break;
                case Foods.MainCourse:
                    return Brushes.LightYellow;
                    break;
                default: return Brushes.Black;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
