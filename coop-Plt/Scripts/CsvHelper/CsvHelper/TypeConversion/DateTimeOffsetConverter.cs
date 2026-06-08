using System;
using System.Globalization;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class DateTimeOffsetConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			if (text == null)
			{
				return base.ConvertFromString(null, row, memberMapData);
			}
			IFormatProvider formatProvider = ((IFormatProvider)memberMapData.TypeConverterOptions.CultureInfo.GetFormat(typeof(DateTimeFormatInfo))) ?? memberMapData.TypeConverterOptions.CultureInfo;
			DateTimeStyles valueOrDefault = memberMapData.TypeConverterOptions.DateTimeStyle.GetValueOrDefault();
			return (memberMapData.TypeConverterOptions.Formats == null || memberMapData.TypeConverterOptions.Formats.Length == 0) ? DateTimeOffset.Parse(text, formatProvider, valueOrDefault) : DateTimeOffset.ParseExact(text, memberMapData.TypeConverterOptions.Formats, formatProvider, valueOrDefault);
		}
	}
}
