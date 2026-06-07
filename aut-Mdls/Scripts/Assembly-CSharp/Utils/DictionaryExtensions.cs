using System.Collections.Generic;
using System.Linq;

namespace Utils
{
	public static class DictionaryExtensions
	{
		public static bool ContentEquals<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Dictionary<TKey, TValue> otherDictionary)
		{
			if (dictionary.Count == otherDictionary.Count)
			{
				return (otherDictionary ?? new Dictionary<TKey, TValue>()).OrderBy((KeyValuePair<TKey, TValue> kvp) => kvp.Key).SequenceEqual((dictionary ?? new Dictionary<TKey, TValue>()).OrderBy((KeyValuePair<TKey, TValue> kvp) => kvp.Key));
			}
			return false;
		}
	}
}
