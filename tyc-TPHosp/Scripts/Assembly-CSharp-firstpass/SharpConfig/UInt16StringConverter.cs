using System;

namespace SharpConfig
{
	internal sealed class UInt16StringConverter : TypeStringConverter<ushort>
	{
		public override string ConvertToString(object value)
		{
			return ((ushort)value).ToString(Configuration.NumberFormat);
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return ushort.Parse(value, Configuration.NumberFormat);
		}
	}
}
