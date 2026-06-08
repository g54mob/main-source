using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public interface ITypeConverter
	{
		object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData);

		string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData);
	}
}
