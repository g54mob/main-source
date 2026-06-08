using System.Globalization;
using System.Linq;
using System.Numerics;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class BigIntegerConverter : DefaultTypeConverter
	{
		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			if (value is BigInteger bigInteger && memberMapData.TypeConverterOptions.Formats?.FirstOrDefault() == null)
			{
				return bigInteger.ToString("R", memberMapData.TypeConverterOptions.CultureInfo);
			}
			return base.ConvertToString(value, row, memberMapData);
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			NumberStyles style = memberMapData.TypeConverterOptions.NumberStyles ?? NumberStyles.Integer;
			if (BigInteger.TryParse(text, style, memberMapData.TypeConverterOptions.CultureInfo, out var result))
			{
				return result;
			}
			return base.ConvertFromString(text, row, memberMapData);
		}
	}
}
