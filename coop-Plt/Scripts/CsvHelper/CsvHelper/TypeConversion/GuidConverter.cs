using System;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class GuidConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			if (text == null)
			{
				return base.ConvertFromString(text, row, memberMapData);
			}
			return new Guid(text);
		}
	}
}
