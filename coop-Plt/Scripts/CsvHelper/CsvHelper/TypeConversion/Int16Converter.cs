using System.Globalization;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class Int16Converter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			NumberStyles style = memberMapData.TypeConverterOptions.NumberStyles ?? NumberStyles.Integer;
			if (short.TryParse(text, style, memberMapData.TypeConverterOptions.CultureInfo, out var result))
			{
				return result;
			}
			return base.ConvertFromString(text, row, memberMapData);
		}
	}
}
