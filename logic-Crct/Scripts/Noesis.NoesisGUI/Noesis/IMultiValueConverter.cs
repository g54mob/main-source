using System;
using System.Globalization;

namespace Noesis
{
	public interface IMultiValueConverter
	{
		object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

		object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);
	}
}
