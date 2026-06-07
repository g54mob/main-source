using System.Collections.Generic;
using System.Globalization;

namespace CsvHelper.TypeConversion
{
	public class TypeConverterOptions
	{
		private static readonly string[] defaultBooleanTrueValues;

		private static readonly string[] defaultBooleanFalseValues;

		private static readonly string[] defaultNullValues;

		public CultureInfo CultureInfo { get; set; }

		public DateTimeStyles? DateTimeStyle { get; set; }

		public TimeSpanStyles? TimeSpanStyle { get; set; }

		public NumberStyles? NumberStyle { get; set; }

		public string[] Formats { get; set; }

		public List<string> BooleanTrueValues { get; }

		public List<string> BooleanFalseValues { get; }

		public List<string> NullValues { get; }

		public static TypeConverterOptions Merge(params TypeConverterOptions[] sources)
		{
			return null;
		}
	}
}
