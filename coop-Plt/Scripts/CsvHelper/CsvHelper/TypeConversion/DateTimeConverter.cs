using System;
using System.Globalization;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class DateTimeConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			if (text == null)
			{
				return base.ConvertFromString(null, row, memberMapData);
			}
			IFormatProvider provider = ((IFormatProvider)memberMapData.TypeConverterOptions.CultureInfo.GetFormat(typeof(DateTimeFormatInfo))) ?? memberMapData.TypeConverterOptions.CultureInfo;
			DateTimeStyles valueOrDefault = memberMapData.TypeConverterOptions.DateTimeStyle.GetValueOrDefault();
			return (memberMapData.TypeConverterOptions.Formats == null || memberMapData.TypeConverterOptions.Formats.Length == 0) ? DateTime.Parse(text, provider, valueOrDefault) : DateTime.ParseExact(text, memberMapData.TypeConverterOptions.Formats, provider, valueOrDefault);
		}
	}
}
