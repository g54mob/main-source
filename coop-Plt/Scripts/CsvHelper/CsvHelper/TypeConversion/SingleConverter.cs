using System;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class SingleConverter : DefaultTypeConverter
	{
		private Lazy<string> defaultFormat = new Lazy<string>(() => (!float.TryParse(float.MaxValue.ToString("R"), out var _)) ? "G9" : "R");

		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			string text = memberMapData.TypeConverterOptions.Formats?.FirstOrDefault() ?? defaultFormat.Value;
			if (value is float num)
			{
				return num.ToString(text, memberMapData.TypeConverterOptions.CultureInfo);
			}
			return base.ConvertToString(value, row, memberMapData);
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			NumberStyles style = memberMapData.TypeConverterOptions.NumberStyles ?? (NumberStyles.Float | NumberStyles.AllowThousands);
			if (float.TryParse(text, style, memberMapData.TypeConverterOptions.CultureInfo, out var result))
			{
				return result;
			}
			return base.ConvertFromString(text, row, memberMapData);
		}
	}
}
