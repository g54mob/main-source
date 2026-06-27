using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FluentAssertions.Common
{
	internal static class Guard
	{
		[AttributeUsage(AttributeTargets.Parameter)]
		private sealed class ValidatedNotNullAttribute : Attribute
		{
		}

		public static void ThrowIfArgumentIsNull<T>([ValidatedNotNull] T obj, [CallerArgumentExpression("obj")] string paramName = "")
		{
			if (obj == null)
			{
				throw new ArgumentNullException(paramName);
			}
		}

		public static void ThrowIfArgumentIsNull<T>([ValidatedNotNull] T obj, string paramName, string message)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(paramName, message);
			}
		}

		public static void ThrowIfArgumentIsNullOrEmpty([ValidatedNotNull] string str, [CallerArgumentExpression("str")] string paramName = "")
		{
			if (string.IsNullOrEmpty(str))
			{
				ThrowIfArgumentIsNull(str, paramName);
				throw new ArgumentException("The value cannot be an empty string.", paramName);
			}
		}

		public static void ThrowIfArgumentIsNullOrEmpty([ValidatedNotNull] string str, string paramName, string message)
		{
			if (string.IsNullOrEmpty(str))
			{
				ThrowIfArgumentIsNull(str, paramName, message);
				throw new ArgumentException(message, paramName);
			}
		}

		public static void ThrowIfArgumentIsOutOfRange<T>(T value, [CallerArgumentExpression("value")] string paramName = "") where T : Enum
		{
			if (!Enum.IsDefined(typeof(T), value))
			{
				throw new ArgumentOutOfRangeException(paramName);
			}
		}

		public static void ThrowIfArgumentContainsNull<T>(IEnumerable<T> values, [CallerArgumentExpression("values")] string paramName = "")
		{
			if (values.Any((T t) => t == null))
			{
				throw new ArgumentNullException(paramName, "Collection contains a null value");
			}
		}

		public static void ThrowIfArgumentIsEmpty<T>(IEnumerable<T> values, string paramName, string message)
		{
			if (!values.Any())
			{
				throw new ArgumentException(message, paramName);
			}
		}

		public static void ThrowIfArgumentIsEmpty(string str, string paramName, string message)
		{
			if (str.Length == 0)
			{
				throw new ArgumentException(message, paramName);
			}
		}

		public static void ThrowIfArgumentIsNegative(TimeSpan timeSpan, [CallerArgumentExpression("timeSpan")] string paramName = "")
		{
			if (timeSpan < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException(paramName, "The value must be non-negative.");
			}
		}

		public static void ThrowIfArgumentIsNegative(float value, [CallerArgumentExpression("value")] string paramName = "")
		{
			if (value < 0f)
			{
				throw new ArgumentOutOfRangeException(paramName, "The value must be non-negative.");
			}
		}

		public static void ThrowIfArgumentIsNegative(double value, [CallerArgumentExpression("value")] string paramName = "")
		{
			if (value < 0.0)
			{
				throw new ArgumentOutOfRangeException(paramName, "The value must be non-negative.");
			}
		}

		public static void ThrowIfArgumentIsNegative(decimal value, [CallerArgumentExpression("value")] string paramName = "")
		{
			if (value < 0m)
			{
				throw new ArgumentOutOfRangeException(paramName, "The value must be non-negative.");
			}
		}
	}
}
