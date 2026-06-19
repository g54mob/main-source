using System;

namespace SharpConfig
{
	internal sealed class DateTimeStringConverter : TypeStringConverter<DateTime>
	{
		public override string ConvertToString(object value)
		{
			return ((DateTime)value).ToString(Configuration.DateTimeFormat);
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return DateTime.Parse(value, Configuration.DateTimeFormat);
		}
	}
}
