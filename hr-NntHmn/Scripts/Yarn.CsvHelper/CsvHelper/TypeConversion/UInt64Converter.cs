using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class UInt64Converter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
