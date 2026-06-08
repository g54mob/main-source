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
			NullableType = type;
			UnderlyingType = Nullable.GetUnderlyingType(type);
			if (UnderlyingType == null)
			{
				throw new ArgumentException("type is not a nullable type.");
			}
			UnderlyingTypeConverter = typeConverterFactory.GetConverter(UnderlyingType);
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			foreach (string nullValue in memberMapData.TypeConverterOptions.NullValues)
			{
				if (text == nullValue)
				{
					return null;
				}
			}
			return UnderlyingTypeConverter.ConvertFromString(text, row, memberMapData);
		}

		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			return UnderlyingTypeConverter.ConvertToString(value, row, memberMapData);
		}
	}
}
