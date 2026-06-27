using System;
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions.Formatting;

namespace FluentAssertions.Common
{
	internal static class ObjectExtensions
	{
		public static Func<T, T, bool> GetComparer<T>()
		{
			if (typeof(T).IsValueType)
			{
				return (T actual, T expected) => EqualityComparer<T>.Default.Equals(actual, expected);
			}
			if (typeof(T) != typeof(object))
			{
				return (T actual, T expected) => (actual != null) ? (expected != null && EqualityComparer<T>.Default.Equals(actual, expected)) : (expected == null);
			}
			return (T actual, T expected) => (actual != null) ? (expected != null && (EqualityComparer<T>.Default.Equals(actual, expected) || CompareNumerics(actual, expected))) : (expected == null);
		}

		private static bool CompareNumerics(object actual, object expected)
		{
			Type type = expected.GetType();
			Type type2 = actual.GetType();
			if (type2 != type && actual.IsNumericType() && expected.IsNumericType() && CanConvert(actual, expected, type2, type))
			{
				return CanConvert(expected, actual, type, type2);
			}
			return false;
		}

		private static bool CanConvert(object source, object target, Type sourceType, Type targetType)
		{
			try
			{
				object obj = source.ConvertTo(targetType);
				return source.Equals(obj.ConvertTo(sourceType)) && obj.Equals(target);
			}
			catch
			{
				return false;
			}
		}

		private static object ConvertTo(this object source, Type targetType)
		{
			return Convert.ChangeType(source, targetType, CultureInfo.InvariantCulture);
		}

		private static bool IsNumericType(this object obj)
		{
			if (obj != null && (obj is int || obj is long || obj is float || obj is double || obj is decimal || obj is sbyte || obj is byte || obj is short || obj is ushort || obj is uint || obj is ulong))
			{
				return true;
			}
			return false;
		}

		public static string ToFormattedString(this object source)
		{
			return Formatter.ToString(source);
		}
	}
}
