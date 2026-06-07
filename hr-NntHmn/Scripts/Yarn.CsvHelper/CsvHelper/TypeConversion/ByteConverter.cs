using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class ByteConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
