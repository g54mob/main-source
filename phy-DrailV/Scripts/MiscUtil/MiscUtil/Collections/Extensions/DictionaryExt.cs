using System;
using System.Collections.Generic;

namespace MiscUtil.Collections.Extensions
{
	public static class DictionaryExt
	{
		public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
		{
			if (!dictionary.TryGetValue(key, out var value))
			{
				value = (dictionary[key] = new TValue());
			}
			return value;
		}

		public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueProvider)
		{
			if (!dictionary.TryGetValue(key, out var value))
			{
				value = (dictionary[key] = valueProvider());
			}
			return value;
		}

		public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue missingValue)
		{
			if (!dictionary.TryGetValue(key, out var value))
			{
				value = (dictionary[key] = missingValue);
			}
			return value;
		}
	}
}
