using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class TimeSpanConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
