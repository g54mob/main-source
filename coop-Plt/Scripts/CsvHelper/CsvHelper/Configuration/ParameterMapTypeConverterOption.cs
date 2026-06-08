using System;
using System.Globalization;

namespace CsvHelper.Configuration
{
	public class ParameterMapTypeConverterOption
	{
		private readonly ParameterMap parameterMap;

		public ParameterMapTypeConverterOption(ParameterMap parameterMap)
		{
			this.parameterMap = parameterMap;
		}

		public virtual ParameterMap CultureInfo(CultureInfo cultureInfo)
		{
			parameterMap.Data.TypeConverterOptions.CultureInfo = cultureInfo;
			return parameterMap;
		}

		public virtual ParameterMap DateTimeStyles(DateTimeStyles dateTimeStyle)
		{
			parameterMap.Data.TypeConverterOptions.DateTimeStyle = dateTimeStyle;
			return parameterMap;
		}

		public virtual ParameterMap TimespanStyles(TimeSpanStyles timeSpanStyles)
		{
			parameterMap.Data.TypeConverterOptions.TimeSpanStyle = timeSpanStyles;
			return parameterMap;
		}

		public virtual ParameterMap NumberStyles(NumberStyles numberStyle)
		{
			parameterMap.Data.TypeConverterOptions.NumberStyles = numberStyle;
			return parameterMap;
		}

		public virtual ParameterMap Format(params string[] formats)
		{
			parameterMap.Data.TypeConverterOptions.Formats = formats;
			return parameterMap;
		}

		public virtual ParameterMap UriKind(UriKind uriKind)
		{
			parameterMap.Data.TypeConverterOptions.UriKind = uriKind;
			return parameterMap;
		}

		public virtual ParameterMap BooleanValues(bool isTrue, bool clearValues = true, params string[] booleanValues)
		{
			if (isTrue)
			{
				if (clearValues)
				{
					parameterMap.Data.TypeConverterOptions.BooleanTrueValues.Clear();
				}
				parameterMap.Data.TypeConverterOptions.BooleanTrueValues.AddRange(booleanValues);
			}
			else
			{
				if (clearValues)
				{
					parameterMap.Data.TypeConverterOptions.BooleanFalseValues.Clear();
				}
				parameterMap.Data.TypeConverterOptions.BooleanFalseValues.AddRange(booleanValues);
			}
			return parameterMap;
		}

		public virtual ParameterMap NullValues(params string[] nullValues)
		{
			return NullValues(clearValues: true, nullValues);
		}

		public virtual ParameterMap NullValues(bool clearValues, params string[] nullValues)
		{
			if (clearValues)
			{
				parameterMap.Data.TypeConverterOptions.NullValues.Clear();
			}
			parameterMap.Data.TypeConverterOptions.NullValues.AddRange(nullValues);
			return parameterMap;
		}
	}
}
