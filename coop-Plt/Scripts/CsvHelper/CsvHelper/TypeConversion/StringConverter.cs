using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class StringConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			if (text == null)
			{
				return string.Empty;
			}
			foreach (string nullValue in memberMapData.TypeConverterOptions.NullValues)
			{
				if (text == nullValue)
				{
					return null;
				}
			}
			return text;
		}
	}
}
