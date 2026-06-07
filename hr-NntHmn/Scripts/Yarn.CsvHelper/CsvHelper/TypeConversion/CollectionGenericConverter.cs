using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class CollectionGenericConverter : IEnumerableConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
