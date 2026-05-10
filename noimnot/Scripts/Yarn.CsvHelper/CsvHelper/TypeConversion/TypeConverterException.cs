using System;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	[Serializable]
	public class TypeConverterException : CsvHelperException
	{
		public string Text { get; private set; }

		public object Value { get; private set; }

		public ITypeConverter TypeConverter { get; private set; }

		public MemberMapData MemberMapData { get; private set; }

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, string text, ReadingContext context)
		{
		}

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, object value, WritingContext context)
		{
		}

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, string text, ReadingContext context, string message)
		{
		}

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, object value, WritingContext context, string message)
		{
		}

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, string text, ReadingContext context, string message, Exception innerException)
		{
		}

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, object value, WritingContext context, string message, Exception innerException)
		{
		}
	}
}
