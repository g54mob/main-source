using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumExtensions
{
	private static void CheckIsEnum<T>(bool withFlags)
	{
		if (!typeof(T).IsEnum)
		{
			throw new ArgumentException($"Type '{typeof(T).FullName}' is not an enum");
		}
		if (withFlags && !Attribute.IsDefined(typeof(T), typeof(FlagsAttribute)))
		{
			throw new ArgumentException($"Type '{typeof(T).FullName}' doesn't have the 'Flags' attribute");
		}
	}

	public static bool HasFlag<T>(this T value, T flag) where T : struct, IConvertible
	{
		CheckIsEnum<T>(withFlags: true);
		long num = Convert.ToInt64(value);
		long num2 = Convert.ToInt64(flag);
		return (num & num2) != 0;
	}

	public static IEnumerable<T> GetFlags<T>(this T value) where T : struct, IConvertible
	{
		CheckIsEnum<T>(withFlags: true);
		foreach (T item in Enum.GetValues(typeof(T)).Cast<T>())
		{
			if (value.HasFlag(item))
			{
				yield return item;
			}
		}
	}

	public static T SetFlags<T>(this T value, T flags, bool on) where T : struct, IConvertible
	{
		CheckIsEnum<T>(withFlags: true);
		long num = Convert.ToInt64(value);
		long num2 = Convert.ToInt64(flags);
		num = ((!on) ? (num & ~num2) : (num | num2));
		return (T)Enum.ToObject(typeof(T), num);
	}

	public static T SetFlags<T>(this T value, T flags) where T : struct, IConvertible
	{
		return value.SetFlags(flags, on: true);
	}

	public static T ClearFlags<T>(this T value, T flags) where T : struct, IConvertible
	{
		return value.SetFlags(flags, on: false);
	}

	public static T CombineFlags<T>(this IEnumerable<T> flags) where T : struct, IConvertible
	{
		CheckIsEnum<T>(withFlags: true);
		long num = 0L;
		foreach (T flag in flags)
		{
			long num2 = Convert.ToInt64(flag);
			num |= num2;
		}
		return (T)Enum.ToObject(typeof(T), num);
	}
}
