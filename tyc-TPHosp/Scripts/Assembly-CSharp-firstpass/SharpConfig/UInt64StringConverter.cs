using System;

namespace SharpConfig
{
	internal sealed class UInt64StringConverter : TypeStringConverter<ulong>
	{
		public override string ConvertToString(object value)
		{
			return ((ulong)value).ToString(Configuration.NumberFormat);
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return ulong.Parse(value, Configuration.NumberFormat);
		}
	}
}
