using System.Globalization;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class DecimalConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			NumberStyles style = memberMapData.TypeConverterOptions.NumberStyles ?? NumberStyles.Number;
			if (decimal.TryParse(text, style, memberMapData.TypeConverterOptions.CultureInfo, out var result))
			{
				return result;
			}
			return base.ConvertFromString(text, row, memberMapData);
		}
	}
}
