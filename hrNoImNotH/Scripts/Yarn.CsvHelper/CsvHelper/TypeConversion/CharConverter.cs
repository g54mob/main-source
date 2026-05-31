using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class CharConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
