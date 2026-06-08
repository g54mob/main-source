using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class TypeConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			string message = "Converting System.Type is not supported. If you want to do this, create your own ITypeConverter and register it in the TypeConverterFactory by calling AddConverter.";
			throw new TypeConverterException(this, memberMapData, text, row.Context, message);
		}

		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			string message = "Converting System.Type is not supported. If you want to do this, create your own ITypeConverter and register it in the TypeConverterFactory by calling AddConverter.";
			throw new TypeConverterException(this, memberMapData, value, row.Context, message);
		}
	}
}
