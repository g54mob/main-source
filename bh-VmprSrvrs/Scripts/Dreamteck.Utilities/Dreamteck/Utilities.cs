using System;
using System.Collections.Generic;

namespace Dreamteck
{
	public static class Utilities
	{
		public static T SerializableClone<T>(this T obj)
		{
			return default(T);
		}

		public static void Shuffle<T>(this IList<T> list)
		{
		}

		public static void RemoveAtUnsorted<T>(this List<T> list, int i)
		{
		}

		public static T PopLast<T>(this IList<T> list)
		{
			return default(T);
		}

		public static void Swap<T>(this IList<T> list, int left, int right)
		{
		}

		public static void SafeInvoke(this Delegate del, params object[] parameters)
		{
		}

		public static T PopRandom<T>(this List<T> list)
		{
			return default(T);
		}
	}
}
