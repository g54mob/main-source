using System;
using System.Linq;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class DefaultTypeConverter : ITypeConverter
	{
		public virtual object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			if (memberMapData.UseDefaultOnConversionFailure && memberMapData.IsDefaultSet && memberMapData.Member.MemberType() == memberMapData.Default?.GetType())
			{
				return memberMapData.Default;
			}
			if (!row.Configuration.ExceptionMessagesContainRawData)
			{
				text = "Hidden because ExceptionMessagesContainRawData is false.";
			}
			string message = "The conversion cannot be performed." + Environment.NewLine + "    Text: '" + text + "'" + Environment.NewLine + "    MemberType: " + memberMapData.Member?.MemberType().FullName + Environment.NewLine + "    TypeConverter: '" + memberMapData.TypeConverter?.GetType().FullName + "'";
			throw new TypeConverterException(this, memberMapData, text, row.Context, message);
		}

		public virtual string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			if (value == null)
			{
				if (memberMapData.TypeConverterOptions.NullValues.Count > 0)
				{
					return memberMapData.TypeConverterOptions.NullValues.First();
				}
				return string.Empty;
			}
			if (value is IFormattable formattable)
			{
				string text = memberMapData.TypeConverterOptions.Formats?.FirstOrDefault();
				return formattable.ToString(text, memberMapData.TypeConverterOptions.CultureInfo);
			}
			return value.ToString();
		}
	}
}
