using System;

namespace SharpConfig
{
	internal sealed class SingleStringConverter : TypeStringConverter<float>
	{
		public override string ConvertToString(object value)
		{
			return ((float)value).ToString(Configuration.NumberFormat);
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return float.Parse(value, Configuration.NumberFormat);
		}
	}
}
