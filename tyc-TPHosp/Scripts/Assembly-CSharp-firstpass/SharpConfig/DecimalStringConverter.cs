using System;

namespace SharpConfig
{
	internal sealed class DecimalStringConverter : TypeStringConverter<decimal>
	{
		public override string ConvertToString(object value)
		{
			return ((decimal)value).ToString(Configuration.NumberFormat);
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return decimal.Parse(value, Configuration.NumberFormat);
		}
	}
}
