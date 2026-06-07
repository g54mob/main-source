using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class IDictionaryGenericConverter : IDictionaryConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
