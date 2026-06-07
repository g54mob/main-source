using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class DefaultTypeConverter : ITypeConverter
	{
		public virtual string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			return null;
		}

		public virtual object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
