using System;
using System.Collections.Generic;

namespace Libs
{
	public static class DictionaryExtension
	{
		public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
		{
			return default(TValue);
		}

		public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue addValue, Func<TValue, TValue> updateValueFactory)
		{
			return default(TValue);
		}

		public static TValue AddDefaultOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue, TValue> updateValueFactory)
		{
			return default(TValue);
		}

		public static TValue AddDefaultOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TValue, TValue> updateValueFactory)
		{
			return default(TValue);
		}

		public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
		{
			return default(TValue);
		}

		public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TValue> addValueFactory, Func<TValue, TValue> updateValueFactory)
		{
			return default(TValue);
		}

		public static bool TryAddNew<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key) where TValue : new()
		{
			return false;
		}

		public static bool TryAddDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
		{
			return false;
		}

		public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue addValue)
		{
			return false;
		}

		public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> addValueFactory)
		{
			return false;
		}

		public static TValue GetOrAddNew<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key) where TValue : new()
		{
			return default(TValue);
		}

		public static TValue GetOrAddDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
		{
			return default(TValue);
		}

		public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue addValue)
		{
			return default(TValue);
		}

		public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> valueFactory)
		{
			return default(TValue);
		}

		public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
		{
			return default(TValue);
		}
	}
}
