using System;
using System.Collections.Generic;

public static class CollectionLoadExtensions
{
	public static void Each<T>(this IEnumerable<T> collection, Action<T> action)
	{
		foreach (T item in collection)
		{
			action(item);
		}
	}

	public static void Replace<T>(this List<T> collection, IEnumerable<T> entries)
	{
		collection.Clear();
		collection.AddRange(entries);
	}

	public static void Replace<T>(this HashSet<T> collection, IEnumerable<T> entries)
	{
		collection.Clear();
		foreach (T entry in entries)
		{
			collection.Add(entry);
		}
	}

	public static void Replace<TKey, TValue>(this Dictionary<TKey, TValue> collection, IEnumerable<(TKey, TValue)> entries)
	{
		collection.Clear();
		foreach (var (key, value) in entries)
		{
			collection.Add(key, value);
		}
	}

	public static void AddRange<T>(this HashSet<T> collection, IEnumerable<T> entries)
	{
		foreach (T entry in entries)
		{
			collection.Add(entry);
		}
	}
}
