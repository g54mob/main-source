using System;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class EnumConverter : DefaultTypeConverter
	{
		private readonly Type type;

		public EnumConverter(Type type)
		{
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return null;
		}
	}
}
