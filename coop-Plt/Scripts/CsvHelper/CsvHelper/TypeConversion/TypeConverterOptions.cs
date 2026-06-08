using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CsvHelper.TypeConversion
{
	public class TypeConverterOptions
	{
		private static readonly string[] defaultBooleanTrueValues = new string[0];

		private static readonly string[] defaultBooleanFalseValues = new string[0];

		private static readonly string[] defaultNullValues = new string[0];

		public CultureInfo CultureInfo { get; set; }

		public DateTimeStyles? DateTimeStyle { get; set; }

		public TimeSpanStyles? TimeSpanStyle { get; set; }

		public NumberStyles? NumberStyles { get; set; }

		public string[] Formats { get; set; }

		public UriKind? UriKind { get; set; }

		public bool? EnumIgnoreCase { get; set; }

		public List<string> BooleanTrueValues { get; } = new List<string>(defaultBooleanTrueValues);

		public List<string> BooleanFalseValues { get; } = new List<string>(defaultBooleanFalseValues);

		public List<string> NullValues { get; } = new List<string>(defaultNullValues);

		public static TypeConverterOptions Merge(params TypeConverterOptions[] sources)
		{
			if (sources == null || sources.Length == 0)
			{
				return null;
			}
			TypeConverterOptions typeConverterOptions = sources[0];
			for (int i = 1; i < sources.Length; i++)
			{
				TypeConverterOptions typeConverterOptions2 = sources[i];
				if (typeConverterOptions2 != null)
				{
					if (typeConverterOptions2.CultureInfo != null)
					{
						typeConverterOptions.CultureInfo = typeConverterOptions2.CultureInfo;
					}
					if (typeConverterOptions2.DateTimeStyle.HasValue)
					{
						typeConverterOptions.DateTimeStyle = typeConverterOptions2.DateTimeStyle;
					}
					if (typeConverterOptions2.TimeSpanStyle.HasValue)
					{
						typeConverterOptions.TimeSpanStyle = typeConverterOptions2.TimeSpanStyle;
					}
					if (typeConverterOptions2.NumberStyles.HasValue)
					{
						typeConverterOptions.NumberStyles = typeConverterOptions2.NumberStyles;
					}
					if (typeConverterOptions2.Formats != null)
					{
						typeConverterOptions.Formats = typeConverterOptions2.Formats;
					}
					if (typeConverterOptions2.UriKind.HasValue)
					{
						typeConverterOptions.UriKind = typeConverterOptions2.UriKind;
					}
					if (typeConverterOptions2.EnumIgnoreCase.HasValue)
					{
						typeConverterOptions.EnumIgnoreCase = typeConverterOptions2.EnumIgnoreCase;
					}
					if (!defaultBooleanTrueValues.SequenceEqual(typeConverterOptions2.BooleanTrueValues))
					{
						typeConverterOptions.BooleanTrueValues.Clear();
						typeConverterOptions.BooleanTrueValues.AddRange(typeConverterOptions2.BooleanTrueValues);
					}
					if (!defaultBooleanFalseValues.SequenceEqual(typeConverterOptions2.BooleanFalseValues))
					{
						typeConverterOptions.BooleanFalseValues.Clear();
						typeConverterOptions.BooleanFalseValues.AddRange(typeConverterOptions2.BooleanFalseValues);
					}
					if (!defaultNullValues.SequenceEqual(typeConverterOptions2.NullValues))
					{
						typeConverterOptions.NullValues.Clear();
						typeConverterOptions.NullValues.AddRange(typeConverterOptions2.NullValues);
					}
				}
			}
			return typeConverterOptions;
		}
	}
}
