using System;

namespace QRCoder.Extensions
{
	public static class CustomExtensions
	{
		public static string GetStringValue(this Enum value)
		{
			StringValueAttribute[] array = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(StringValueAttribute), inherit: false) as StringValueAttribute[];
			if (array.Length == 0)
			{
				return null;
			}
			return array[0].StringValue;
		}
	}
}
