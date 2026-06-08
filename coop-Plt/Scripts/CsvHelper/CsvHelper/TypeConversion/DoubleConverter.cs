using System;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class DoubleConverter : DefaultTypeConverter
	{
		private Lazy<string> defaultFormat = new Lazy<string>(() => (!double.TryParse(double.MaxValue.ToString("R"), out var _)) ? "G17" : "R");

		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			string text = memberMapData.TypeConverterOptions.Formats?.FirstOrDefault() ?? defaultFormat.Value;
			if (value is double num)
			{
				return num.ToString(text, memberMapData.TypeConverterOptions.CultureInfo);
			}
			return base.ConvertToString(value, row, memberMapData);
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			NumberStyles style = memberMapData.TypeConverterOptions.NumberStyles ?? (NumberStyles.Float | NumberStyles.AllowThousands);
			if (double.TryParse(text, style, memberMapData.TypeConverterOptions.CultureInfo, out var result))
			{
				return result;
			}
			return base.ConvertFromString(text, row, memberMapData);
		}
	}
}
