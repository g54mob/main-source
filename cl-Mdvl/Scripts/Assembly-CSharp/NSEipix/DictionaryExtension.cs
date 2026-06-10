using System;
using System.Collections.Generic;
using System.Linq;

namespace NSEipix
{
	public static class DictionaryExtension
	{
		public static void SafeAdd<TK, TV>(this Dictionary<TK, TV> dictionary, TK key, TV value)
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

		public static void SafeRemove<TK, TV>(this Dictionary<TK, TV> dictionary, TK key, TV value)
		{
			if (dictionary.ContainsKey(key))
			{
				dictionary.Remove(key);
			}
		}

		public static void RemoveFirst<TK, TV>(this Dictionary<TK, TV> dictionary, Func<KeyValuePair<TK, TV>, bool> condition)
		{
			foreach (KeyValuePair<TK, TV> item in dictionary)
			{
				if (condition(item))
				{
					dictionary.Remove(item.Key);
					break;
				}
			}
		}

		public static void RemoveAll<TK, TV>(this Dictionary<TK, TV> dictionary, Func<KeyValuePair<TK, TV>, bool> condition)
		{
			KeyValuePair<TK, TV>[] array = dictionary.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				KeyValuePair<TK, TV> arg = array[i];
				if (condition(arg))
				{
					dictionary.Remove(arg.Key);
				}
			}
		}

		public static TV GetOrAdd<TK, TV>(this IDictionary<TK, TV> dictionary, TK key) where TV : new()
		{
			if (!dictionary.TryGetValue(key, out var value))
			{
				TV value2 = new TV();
				dictionary.TryAdd(key, value2);
				return dictionary[key];
			}
			return value;
		}
	}
}
