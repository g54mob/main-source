using System;
using System.ComponentModel;
using System.Globalization;

namespace Sentry
{
	internal class SubstringOrRegexPatternTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
		{
			return sourceType == typeof(string);
		}

		public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
		{
			return new SubstringOrRegexPattern((string)value);
		}
	}
}
