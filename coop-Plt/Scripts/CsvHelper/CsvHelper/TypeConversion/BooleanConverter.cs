using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class BooleanConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			if (bool.TryParse(text, out var result))
			{
				return result;
			}
			if (short.TryParse(text, out var result2))
			{
				switch (result2)
				{
				case 0:
					return false;
				case 1:
					return true;
				}
			}
			string @string = (text ?? string.Empty).Trim();
			foreach (string booleanTrueValue in memberMapData.TypeConverterOptions.BooleanTrueValues)
			{
				if (memberMapData.TypeConverterOptions.CultureInfo.CompareInfo.Compare(booleanTrueValue, @string, CompareOptions.IgnoreCase) == 0)
				{
					return true;
				}
			}
			foreach (string booleanFalseValue in memberMapData.TypeConverterOptions.BooleanFalseValues)
			{
				if (memberMapData.TypeConverterOptions.CultureInfo.CompareInfo.Compare(booleanFalseValue, @string, CompareOptions.IgnoreCase) == 0)
				{
					return false;
				}
			}
			return base.ConvertFromString(text, row, memberMapData);
		}

		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			bool? flag = value as bool?;
			if (flag == true && memberMapData.TypeConverterOptions.BooleanTrueValues.Count > 0)
			{
				return memberMapData.TypeConverterOptions.BooleanTrueValues.First();
			}
			if (flag == false && memberMapData.TypeConverterOptions.BooleanFalseValues.Count > 0)
			{
				return memberMapData.TypeConverterOptions.BooleanFalseValues.First();
			}
			return base.ConvertToString(value, row, memberMapData);
		}
	}
}
