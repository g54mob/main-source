using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class UInt32Converter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
