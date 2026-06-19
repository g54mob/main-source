using System;

namespace SharpConfig
{
	internal sealed class Int64StringConverter : TypeStringConverter<long>
	{
		public override string ConvertToString(object value)
		{
			return ((long)value).ToString(Configuration.NumberFormat);
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return long.Parse(value, Configuration.NumberFormat);
		}
	}
}
