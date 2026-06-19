using System;

namespace SharpConfig
{
	internal sealed class SByteStringConverter : TypeStringConverter<sbyte>
	{
		public override string ConvertToString(object value)
		{
			return ((sbyte)value).ToString(Configuration.NumberFormat);
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return sbyte.Parse(value, Configuration.NumberFormat);
		}
	}
}
