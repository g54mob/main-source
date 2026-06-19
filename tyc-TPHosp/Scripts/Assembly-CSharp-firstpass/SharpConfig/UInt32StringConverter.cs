using System;

namespace SharpConfig
{
	internal sealed class UInt32StringConverter : TypeStringConverter<uint>
	{
		public override string ConvertToString(object value)
		{
			return ((uint)value).ToString(Configuration.NumberFormat);
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return uint.Parse(value, Configuration.NumberFormat);
		}
	}
}
