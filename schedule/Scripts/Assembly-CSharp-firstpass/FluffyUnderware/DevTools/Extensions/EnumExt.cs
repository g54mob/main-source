using System;

namespace FluffyUnderware.DevTools.Extensions
{
	public static class EnumExt
	{
		public static bool HasFlag(this Enum variable, params Enum[] flags)
		{
			return false;
		}

		public static bool HasFlag<T>(this T value, T flag) where T : struct
		{
			return false;
		}

		public static T Set<T>(this Enum value, T append)
		{
			return default(T);
		}

		public static T Set<T>(this Enum value, T append, bool OnOff)
		{
			return default(T);
		}
	}
}
