using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace MyBox
{
	[PublicAPI]
	public static class MyCollections
	{
		public static T[] InsertAt<T>(this T[] array, int index)
		{
			return null;
		}

		public static T[] RemoveAt<T>(this T[] array, int index)
		{
			return null;
		}

		public static T GetRandom<T>(this T[] collection)
		{
			return default(T);
		}

		public static T GetRandom<T>(this IList<T> collection)
		{
			return default(T);
		}

		public static T GetRandom<T>(this IEnumerable<T> collection)
		{
			return default(T);
		}

		public static bool IsNullOrEmpty<T>(this T[] collection)
		{
			return false;
		}

		public static bool IsNullOrEmpty<T>(this IList<T> collection)
		{
			return false;
		}

		public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
		{
			return false;
		}

		public static bool NotNullOrEmpty<T>(this T[] collection)
		{
			return false;
		}

		public static bool NotNullOrEmpty<T>(this IList<T> collection)
		{
			return false;
		}

		public static bool NotNullOrEmpty<T>(this IEnumerable<T> collection)
		{
			return false;
		}

		public static int NextIndexInCircle<T>(this T[] array, int desiredPosition)
		{
			return 0;
		}

		public static int IndexOfItem<T>(this IEnumerable<T> collection, T item)
		{
			return 0;
		}

		public static bool ContentsMatch<T>(this IEnumerable<T> first, IEnumerable<T> second)
		{
			return false;
		}

		public static bool ContentsMatchKeys<T1, T2>(this IDictionary<T1, T2> source, IEnumerable<T1> check)
		{
			return false;
		}

		public static bool ContentsMatchValues<T1, T2>(this IDictionary<T1, T2> source, IEnumerable<T2> check)
		{
			return false;
		}

		public static TValue GetOrAddDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key) where TValue : new()
		{
			return default(TValue);
		}

		public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
		{
			return default(TValue);
		}

		public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Func<TValue> valueFactory)
		{
			return default(TValue);
		}

		public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Func<TKey, TValue> valueFactory)
		{
			return default(TValue);
		}

		public static TValue GetOrAdd<TKey, TValue, TArg>(this IDictionary<TKey, TValue> source, TKey key, Func<TKey, TArg, TValue> valueFactory, TArg factoryArgument)
		{
			return default(TValue);
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			return null;
		}

		public static IEnumerable<T> ForEach<T, R>(this IEnumerable<T> source, Func<T, R> func)
		{
			return null;
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
		{
			return null;
		}

		public static IEnumerable<T> ForEach<T, R>(this IEnumerable<T> source, Func<T, int, R> func)
		{
			return null;
		}

		public static T MaxBy<T, S>(this IEnumerable<T> source, Func<T, S> selector)
		{
			return default(T);
		}

		public static T MinBy<T, S>(this IEnumerable<T> source, Func<T, S> selector)
		{
			return default(T);
		}

		public static IEnumerable<T> SingleToEnumerable<T>(this T source)
		{
			return null;
		}

		public static int FirstIndex<T>(this IList<T> source, Predicate<T> predicate)
		{
			return 0;
		}

		public static int FirstIndex<T>(this IEnumerable<T> source, Predicate<T> predicate)
		{
			return 0;
		}

		public static int LastIndex<T>(this IList<T> source, Predicate<T> predicate)
		{
			return 0;
		}

		public static int GetWeightedRandomIndex<T>(this IEnumerable<T> source, Func<T, double> weightSelector)
		{
			return 0;
		}

		public static T GetWeightedRandom<T>(this IList<T> source, Func<T, double> weightSelector)
		{
			return default(T);
		}

		public static T GetWeightedRandom<T>(this IEnumerable<T> source, Func<T, double> weightSelector)
		{
			return default(T);
		}

		public static IList<T> FillBy<T>(this IList<T> source, Func<int, T> valueFactory)
		{
			return null;
		}

		public static T[] FillBy<T>(this T[] source, Func<int, T> valueFactory)
		{
			return null;
		}

		public static T[] ExclusiveSample<T>(this IList<T> source, int sampleNumber)
		{
			return null;
		}

		public static IList<T> SwapInPlace<T>(this IList<T> source, int index1, int index2)
		{
			return null;
		}

		public static IList<T> Shuffle<T>(this IList<T> source)
		{
			return null;
		}
	}
}
