using System;
using System.Collections;
using System.Collections.Generic;

namespace VoxelBusters.CoreLibrary
{
	public static class CollectionUtility
	{
		public static bool IsNullOrEmpty<T>(this IList<T> list)
		{
			return false;
		}

		public static bool AddUnique<T>(this IList<T> list, T item)
		{
			return false;
		}

		public static IList<T> Add<T>(this IList<T> list, Func<bool> condition, Func<T> getItem)
		{
			return null;
		}

		public static void AddOrReplace<T>(this List<T> list, T item, Predicate<T> match)
		{
		}

		public static bool Remove<T>(this List<T> list, Predicate<T> match)
		{
			return false;
		}

		public static T GetItemAt<T>(this IList<T> list, int index, bool throwError = true)
		{
			return default(T);
		}

		public static void AddFirst<T>(this IList<T> list, T item)
		{
		}

		public static void AddLast<T>(this IList<T> list, T item)
		{
		}

		public static T PopFirst<T>(this IList<T> list)
		{
			return default(T);
		}

		public static T PopLast<T>(this IList<T> list)
		{
			return default(T);
		}

		public static void ForEach<T>(this IList<T> list, Action<T> action)
		{
		}

		public static TOutput[] ConvertAll<TInput, TOutput>(this IList<TInput> source, Converter<TInput, TOutput> converter, Predicate<TInput> match = null)
		{
			return null;
		}

		public static bool IsNullOrEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dict)
		{
			return false;
		}

		public static bool ContainsKeyPath(this IDictionary dictionary, string keyPath)
		{
			return false;
		}

		public static T GetIfAvailable<T>(this IDictionary dictionary, string key, T defaultValue = default(T))
		{
			return default(T);
		}

		public static T GetIfAvailable<T>(this IDictionary dictionary, string key, string path)
		{
			return default(T);
		}

		public static string GetKey<T>(this IDictionary dictionary, T value)
		{
			return null;
		}
	}
}
