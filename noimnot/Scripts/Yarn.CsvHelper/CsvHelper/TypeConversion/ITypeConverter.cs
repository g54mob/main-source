using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public interface ITypeConverter
	{
		string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData);

		object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData);
	}
}
