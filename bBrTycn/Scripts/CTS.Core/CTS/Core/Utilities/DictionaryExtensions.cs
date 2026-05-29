using System;
using System.Collections.Generic;

namespace CTS.Core.Utilities
{
	public static class DictionaryExtensions
	{
		public static Dictionary<T, U> Initialize<T, U>(this Dictionary<T, U> dict, U value) where T : Enum where U : unmanaged
		{
			T[] obj = (T[])Enum.GetValues(typeof(T));
			dict.Clear();
			T[] array = obj;
			foreach (T key in array)
			{
				dict.Add(key, value);
			}
			return dict;
		}

		public static Dictionary<T, U> Initialize<T, U>(this Dictionary<T, U> dict) where T : Enum where U : class, new()
		{
			T[] obj = (T[])Enum.GetValues(typeof(T));
			dict.Clear();
			T[] array = obj;
			foreach (T key in array)
			{
				dict.Add(key, new U());
			}
			return dict;
		}

		public static TValue EnsureKeyExists<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : class, new()
		{
			if (dictionary.TryGetValue(key, out var value))
			{
				return value;
			}
			TValue val = new TValue();
			dictionary.Add(key, val);
			return val;
		}
	}
}
