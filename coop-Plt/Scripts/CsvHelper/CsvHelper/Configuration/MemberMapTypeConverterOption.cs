using System;
using System.Globalization;

namespace CsvHelper.Configuration
{
	public class MemberMapTypeConverterOption
	{
		private readonly MemberMap memberMap;

		public MemberMapTypeConverterOption(MemberMap memberMap)
		{
			this.memberMap = memberMap;
		}

		public virtual MemberMap CultureInfo(CultureInfo cultureInfo)
		{
			memberMap.Data.TypeConverterOptions.CultureInfo = cultureInfo;
			return memberMap;
		}

		public virtual MemberMap DateTimeStyles(DateTimeStyles dateTimeStyle)
		{
			memberMap.Data.TypeConverterOptions.DateTimeStyle = dateTimeStyle;
			return memberMap;
		}

		public virtual MemberMap TimespanStyles(TimeSpanStyles timeSpanStyles)
		{
			memberMap.Data.TypeConverterOptions.TimeSpanStyle = timeSpanStyles;
			return memberMap;
		}

		public virtual MemberMap NumberStyles(NumberStyles numberStyle)
		{
			memberMap.Data.TypeConverterOptions.NumberStyles = numberStyle;
			return memberMap;
		}

		public virtual MemberMap Format(params string[] formats)
		{
			memberMap.Data.TypeConverterOptions.Formats = formats;
			return memberMap;
		}

		public virtual MemberMap UriKind(UriKind uriKind)
		{
			memberMap.Data.TypeConverterOptions.UriKind = uriKind;
			return memberMap;
		}

		public virtual MemberMap BooleanValues(bool isTrue, bool clearValues = true, params string[] booleanValues)
		{
			if (isTrue)
			{
				if (clearValues)
				{
					memberMap.Data.TypeConverterOptions.BooleanTrueValues.Clear();
				}
				memberMap.Data.TypeConverterOptions.BooleanTrueValues.AddRange(booleanValues);
			}
			else
			{
				if (clearValues)
				{
					memberMap.Data.TypeConverterOptions.BooleanFalseValues.Clear();
				}
				memberMap.Data.TypeConverterOptions.BooleanFalseValues.AddRange(booleanValues);
			}
			return memberMap;
		}

		public virtual MemberMap NullValues(params string[] nullValues)
		{
			return NullValues(clearValues: true, nullValues);
		}

		public virtual MemberMap NullValues(bool clearValues, params string[] nullValues)
		{
			if (clearValues)
			{
				memberMap.Data.TypeConverterOptions.NullValues.Clear();
			}
			memberMap.Data.TypeConverterOptions.NullValues.AddRange(nullValues);
			return memberMap;
		}

		public virtual MemberMap EnumIgnoreCase(bool ignoreCase = true)
		{
			memberMap.Data.TypeConverterOptions.EnumIgnoreCase = ignoreCase;
			return memberMap;
		}
	}
}
