using System;

namespace SharpConfig
{
	internal sealed class StringStringConverter : TypeStringConverter<string>
	{
		public override string ConvertToString(object value)
		{
			return value.ToString().Trim();
		}

		public override object ConvertFromString(string value, Type hint)
		{
			return value;
		}
	}
}
