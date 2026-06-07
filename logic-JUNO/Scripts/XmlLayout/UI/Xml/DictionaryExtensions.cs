using System.Collections.Generic;

namespace UI.Xml
{
	public static class DictionaryExtensions
	{
		public static void AddIfKeyNotExists<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
		{
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, value);
			}
		}

		public static void SetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
		{
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, value);
			}
			else
			{
				dictionary[key] = value;
			}
		}
	}
}
