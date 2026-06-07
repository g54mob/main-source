using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class SByteConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
