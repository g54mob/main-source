using System;

namespace Utils
{
	public static class TypeUtils
	{
		public static bool Is(this Type type, Type other)
		{
			if (type == null || other == null)
			{
				return false;
			}
			if (!(other == type) && !other.IsSubclassOf(type))
			{
				return other.IsAssignableFrom(type);
			}
			return true;
		}

		public static bool Is<T>(this Type type)
		{
			return type.Is(typeof(T));
		}
	}
}
