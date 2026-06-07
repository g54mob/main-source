using System;

namespace NGenerics.Util
{
	public static class Guard
	{
		public static void ArgumentNotNullOrEmptyString(string argumentValue, string argumentName)
		{
			ArgumentNotNull(argumentValue, argumentName);
			if (argumentValue.Length == 0)
			{
				throw new ArgumentException("String cannot be empty.", argumentName);
			}
		}

		public static void ArgumentNotNull(object argumentValue, string argumentName)
		{
			if (argumentValue == null)
			{
				throw new ArgumentNullException(argumentName);
			}
		}
	}
}
