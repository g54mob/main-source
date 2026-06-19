using System;

namespace SharpConfig
{
	internal sealed class EnumStringConverter : TypeStringConverter<Enum>
	{
		public override string ConvertToString(object value)
		{
			return value.ToString();
		}

		public override object ConvertFromString(string value, Type hint)
		{
			int num = value.LastIndexOf('.');
			if (num >= 0)
			{
				value = value.Substring(num + 1, value.Length - num - 1).Trim();
			}
			return Enum.Parse(hint, value);
		}
	}
}
