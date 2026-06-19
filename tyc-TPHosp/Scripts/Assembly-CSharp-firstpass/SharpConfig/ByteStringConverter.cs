using System;

namespace SharpConfig
{
	internal sealed class ByteStringConverter : TypeStringConverter<byte>
	{
		public override string ConvertToString(object value)
		{
			return value.ToString();
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return sbyte.Parse(value, Configuration.NumberFormat);
		}
	}
}
