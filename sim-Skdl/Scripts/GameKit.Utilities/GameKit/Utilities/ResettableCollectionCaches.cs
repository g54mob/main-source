using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GameKit.Utilities
{
	public static class ResettableCollectionCaches<T1, T2> where T1 : IResettable where T2 : IResettable
	{
		public static Dictionary<T1, T2> RetrieveDictionary()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void StoreAndDefault(ref Dictionary<T1, T2> value)
		{
		}

		public static void Store(Dictionary<T1, T2> value)
		{
		}
	}
	public static class ResettableCollectionCaches<T> where T : IResettable
	{
		public static T[] RetrieveArray()
		{
			return null;
		}

		public static List<T> RetrieveList()
		{
			return null;
		}

		public static HashSet<T> RetrieveHashSet()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void StoreAndDefault(ref T[] value, int count)
		{
		}

		public static void Store(T[] value, int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void StoreAndDefault(ref List<T> value)
		{
		}

		public static void Store(List<T> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void StoreAndDefault(ref HashSet<T> value)
		{
		}

		public static void Store(HashSet<T> value)
		{
		}
	}
}
