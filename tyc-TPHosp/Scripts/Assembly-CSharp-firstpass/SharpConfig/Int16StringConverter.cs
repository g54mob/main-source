using System;

namespace SharpConfig
{
	internal sealed class Int16StringConverter : TypeStringConverter<short>
	{
		public override string ConvertToString(object value)
		{
			return ((short)value).ToString(Configuration.NumberFormat);
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return short.Parse(value, Configuration.NumberFormat);
		}
	}
}
