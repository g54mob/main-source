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

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, string text, CsvContext context)
			: base(context)
		{
			TypeConverter = typeConverter;
			MemberMapData = memberMapData;
			Text = text;
		}

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, object value, CsvContext context)
			: base(context)
		{
			TypeConverter = typeConverter;
			MemberMapData = memberMapData;
			Value = value;
		}

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, string text, CsvContext context, string message)
			: base(context, message)
		{
			TypeConverter = typeConverter;
			MemberMapData = memberMapData;
			Text = text;
		}

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, object value, CsvContext context, string message)
			: base(context, message)
		{
			TypeConverter = typeConverter;
			MemberMapData = memberMapData;
			Value = value;
		}

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, string text, CsvContext context, string message, Exception innerException)
			: base(context, message, innerException)
		{
			TypeConverter = typeConverter;
			MemberMapData = memberMapData;
			Text = text;
		}

		public TypeConverterException(ITypeConverter typeConverter, MemberMapData memberMapData, object value, CsvContext context, string message, Exception innerException)
			: base(context, message, innerException)
		{
			TypeConverter = typeConverter;
			MemberMapData = memberMapData;
			Value = value;
		}
	}
}
