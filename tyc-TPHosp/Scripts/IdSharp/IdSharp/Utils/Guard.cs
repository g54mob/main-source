using System;

namespace IdSharp.Utils
{
	internal static class Guard
	{
		public static void ArgumentNotNull(object value, string parameterName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName, $"Parameter '{parameterName}' cannot be null.");
			}
		}

		public static void ArgumentNotNullOrEmptyString(string value, string parameterName)
		{
			ArgumentNotNull(value, parameterName);
			if (value.Length == 0)
			{
				throw new ArgumentException($"String parameter '{parameterName}' cannot be empty.", parameterName);
			}
		}
	}
}
