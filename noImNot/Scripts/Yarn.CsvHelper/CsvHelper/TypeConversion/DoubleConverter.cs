using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class DoubleConverter : DefaultTypeConverter
	{
		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			return null;
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
