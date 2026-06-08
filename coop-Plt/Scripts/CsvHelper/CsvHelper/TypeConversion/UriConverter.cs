using System;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class UriConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			UriKind valueOrDefault = memberMapData.TypeConverterOptions.UriKind.GetValueOrDefault();
			if (Uri.TryCreate(text, valueOrDefault, out var result))
			{
				return result;
			}
			return base.ConvertFromString(text, row, memberMapData);
		}
	}
}
