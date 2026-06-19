using System;

namespace SharpConfig
{
	internal sealed class DoubleStringConverter : TypeStringConverter<double>
	{
		public override string ConvertToString(object value)
		{
			return ((double)value).ToString(Configuration.NumberFormat);
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return double.Parse(value, Configuration.NumberFormat);
		}
	}
}
