using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentAssertions.Common
{
	internal static class DictionaryHelpers
	{
		public static IEnumerable<TKey> GetKeys<TCollection, TKey, TValue>(this TCollection collection) where TCollection : IEnumerable<KeyValuePair<TKey, TValue>>
		{
			if (!(collection is IDictionary<TKey, TValue> dictionary))
			{
				if (!(collection is IReadOnlyDictionary<TKey, TValue> { Keys: var keys }))
				{
					return collection.Select((KeyValuePair<TKey, TValue> kvp) => kvp.Key).ToList();
				}
				return keys;
			}
			return dictionary.Keys;
		}

		public static IEnumerable<TValue> GetValues<TCollection, TKey, TValue>(this TCollection collection) where TCollection : IEnumerable<KeyValuePair<TKey, TValue>>
		{
			if (!(collection is IDictionary<TKey, TValue> dictionary))
			{
				if (!(collection is IReadOnlyDictionary<TKey, TValue> { Values: var values }))
				{
					return collection.Select((KeyValuePair<TKey, TValue> kvp) => kvp.Value).ToList();
				}
				return values;
			}
			return dictionary.Values;
		}

		public static bool ContainsKey<TCollection, TKey, TValue>(this TCollection collection, TKey key) where TCollection : IEnumerable<KeyValuePair<TKey, TValue>>
		{
			if (!(collection is IDictionary<TKey, TValue> dictionary))
			{
				if (collection is IReadOnlyDictionary<TKey, TValue> readOnlyDictionary)
				{
					return readOnlyDictionary.ContainsKey(key);
				}
				return ContainsKey(collection, key);
			}
			return dictionary.ContainsKey(key);
			static bool ContainsKey(TCollection val, TKey arg)
			{
				Func<TKey, TKey, bool> areSameOrEqual = ObjectExtensions.GetComparer<TKey>();
				return val.Any((KeyValuePair<TKey, TValue> kvp) => areSameOrEqual(kvp.Key, arg));
			}
		}

		public static bool TryGetValue<TCollection, TKey, TValue>(this TCollection collection, TKey key, out TValue value) where TCollection : IEnumerable<KeyValuePair<TKey, TValue>>
		{
			if (!(collection is IDictionary<TKey, TValue> dictionary))
			{
				if (collection is IReadOnlyDictionary<TKey, TValue> readOnlyDictionary)
				{
					return readOnlyDictionary.TryGetValue(key, out value);
				}
				return TryGetValue(collection, key, out value);
			}
			return dictionary.TryGetValue(key, out value);
			static bool TryGetValue(TCollection val, TKey arg, out TValue reference)
			{
				Func<TKey, TKey, bool> comparer = ObjectExtensions.GetComparer<TKey>();
				foreach (KeyValuePair<TKey, TValue> item in val)
				{
					if (comparer(item.Key, arg))
					{
						reference = item.Value;
						return true;
					}
				}
				reference = default(TValue);
				return false;
			}
		}

		public static TValue GetValue<TCollection, TKey, TValue>(this TCollection collection, TKey key) where TCollection : IEnumerable<KeyValuePair<TKey, TValue>>
		{
			if (!(collection is IDictionary<TKey, TValue> dictionary))
			{
				if (collection is IReadOnlyDictionary<TKey, TValue> readOnlyDictionary)
				{
					return readOnlyDictionary[key];
				}
				return GetValue(collection, key);
			}
			return dictionary[key];
			static TValue GetValue(TCollection val, TKey arg)
			{
				Func<TKey, TKey, bool> areSameOrEqual = ObjectExtensions.GetComparer<TKey>();
				return val.First((KeyValuePair<TKey, TValue> kvp) => areSameOrEqual(kvp.Key, arg)).Value;
			}
		}
	}
}
