using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Sentry.Internal.Extensions
{
	internal static class CollectionsExtensions
	{
		public static TValue GetOrCreate<TValue>(this ConcurrentDictionary<string, object> dictionary, string key) where TValue : class, new()
		{
			object orAdd = dictionary.GetOrAdd(key, (string _) => new TValue());
			if (orAdd is TValue result)
			{
				return result;
			}
			throw new Exception($"Expected a type of {typeof(TValue)} to exist for the key '{key}'. Instead found a {orAdd.GetType()}. The likely cause of this is that the value for '{key}' has been incorrectly set to an instance of a different type.");
		}

		public static void TryCopyTo<TKey, TValue>(this IDictionary<TKey, TValue> from, IDictionary<TKey, TValue> to) where TKey : notnull
		{
			foreach (var (key, value) in from)
			{
				if (!to.ContainsKey(key))
				{
					to[key] = value;
				}
			}
		}

		internal static Dictionary<TKey, TValue> ToDict<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source) where TKey : notnull
		{
			return source.ToDictionary<KeyValuePair<TKey, TValue>, TKey, TValue>((KeyValuePair<TKey, TValue> kvp) => kvp.Key, (KeyValuePair<TKey, TValue> kvp) => kvp.Value);
		}

		public static IEnumerable<KeyValuePair<TKey, TValue>> WhereNotNullValue<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue?>> source) where TKey : notnull
		{
			foreach (KeyValuePair<TKey, TValue> item in source)
			{
				if (item.Value != null)
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<KeyValuePair<TKey, TValue>> Append<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, TKey key, TValue value)
		{
			return source.Append(new KeyValuePair<TKey, TValue>(key, value));
		}

		public static IReadOnlyList<T> AsReadOnly<T>(this IList<T> list)
		{
			return (list as IReadOnlyList<T>) ?? new ReadOnlyCollection<T>(list);
		}

		public static IReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary) where TKey : notnull
		{
			return new ReadOnlyDictionary<TKey, TValue>(dictionary);
		}

		public static IEnumerable<T> ExceptNulls<T>(this IEnumerable<T?> source)
		{
			return from x in source
				where x != null
				select (x);
		}

		public static bool TryGetTypedValue<T>(this IDictionary<string, object?> source, string key, [NotNullWhen(true)] out T value)
		{
			if (source.TryGetValue(key, out object value2) && value2 is T val)
			{
				value = val;
				return true;
			}
			value = default(T);
			return false;
		}
	}
}
