using System;

namespace SharpConfig
{
	internal sealed class BoolStringConverter : TypeStringConverter<bool>
	{
		public override string ConvertToString(object value)
		{
			return value.ToString();
		}

		public override object ConvertFromString(string value, Type hint)
		{
			switch (value.ToLowerInvariant())
			{
			case "false":
			case "off":
			case "no":
			case "0":
				return false;
			case "true":
			case "on":
			case "yes":
			case "1":
				return true;
			default:
				throw new ArgumentException($"The value cannot be converted to type '{hint.FullName}'.", "value");
			}
		}
	}
}
