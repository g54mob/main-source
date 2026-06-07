using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class IEnumerableGenericConverter : IEnumerableConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
