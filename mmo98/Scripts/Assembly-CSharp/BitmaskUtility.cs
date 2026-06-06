using System;
using System.Collections.Generic;
using ZLinq;

public static class BitmaskUtility
{
	public static T AddFlag<T>(this ref T mask, T flag) where T : struct, Enum
	{
		return mask = (T)Enum.ToObject(typeof(T), Convert.ToUInt64(mask) | Convert.ToUInt64(flag));
	}

	public static T RemoveFlag<T>(this ref T mask, T flag) where T : struct, Enum
	{
		return mask = (T)Enum.ToObject(typeof(T), Convert.ToUInt64(mask) & ~Convert.ToUInt64(flag));
	}

	public static T ToggleFlag<T>(this ref T mask, T flag) where T : struct, Enum
	{
		return mask = (T)Enum.ToObject(typeof(T), Convert.ToUInt64(mask) ^ Convert.ToUInt64(flag));
	}

	public static T Clear<T>(this ref T mask) where T : struct, Enum
	{
		return mask = default(T);
	}

	public static T Invert<T>(this ref T mask) where T : struct, Enum
	{
		return mask = (T)Enum.ToObject(typeof(T), ~Convert.ToUInt64(mask) & GetAllFlagsValue<T>());
	}

	public static bool HasFlag<T>(this T mask, T flag) where T : struct, Enum
	{
		ulong num = Convert.ToUInt64(flag);
		return (Convert.ToUInt64(mask) & num) == num;
	}

	public static bool HasAnyFlag<T>(this T mask, T flag) where T : struct, Enum
	{
		return (Convert.ToUInt64(mask) & Convert.ToUInt64(flag)) != 0;
	}

	public static bool IsExactly<T>(this T mask, T flag) where T : struct, Enum
	{
		return EqualityComparer<T>.Default.Equals(mask, flag);
	}

	public static bool IsEmpty<T>(this T mask) where T : struct, Enum
	{
		return Convert.ToUInt64(mask) == 0;
	}

	public static T GetRandomFlag<T>(this T mask) where T : struct, Enum
	{
		return (from T f in Enum.GetValues(typeof(T)).AsValueEnumerable()
			where mask.HasFlag(f)
			select f).Random();
	}

	public static ulong GetAllFlagsValue<T>() where T : struct, Enum
	{
		ulong num = 0uL;
		foreach (object value in Enum.GetValues(typeof(T)))
		{
			num |= Convert.ToUInt64(value);
		}
		return num;
	}
}
