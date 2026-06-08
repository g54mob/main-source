using System;
using System.Collections;

namespace HandlebarsDotNet
{
	public static class HandlebarsUtils
	{
		public static bool IsTruthy(object value)
		{
			return !IsFalsy(value);
		}

		public static bool IsFalsy(object value)
		{
			if (!(value is UndefinedBindingResult) && value != null)
			{
				if (!(value is bool flag))
				{
					if (value is string text)
					{
						return text == string.Empty;
					}
					if (IsNumber(value))
					{
						return !Convert.ToBoolean(value);
					}
					return false;
				}
				return !flag;
			}
			return true;
		}

		public static bool IsTruthyOrNonEmpty(object value)
		{
			return !IsFalsyOrEmpty(value);
		}

		public static bool IsFalsyOrEmpty(object value)
		{
			if (IsFalsy(value))
			{
				return true;
			}
			if (value is IEnumerable builder)
			{
				return !builder.Any();
			}
			return false;
		}

		private static bool IsNumber(object value)
		{
			if (!(value is sbyte) && !(value is byte) && !(value is short) && !(value is ushort) && !(value is int) && !(value is uint) && !(value is long) && !(value is ulong) && !(value is float) && !(value is double))
			{
				return value is decimal;
			}
			return true;
		}
	}
}
