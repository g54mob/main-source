using System;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class NullableConverter : DefaultTypeConverter
	{
		public Type NullableType { get; private set; }

		public Type UnderlyingType { get; private set; }

		public ITypeConverter UnderlyingTypeConverter { get; private set; }

		public NullableConverter(Type type, TypeConverterCache typeConverterFactory)
		{
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}

		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
