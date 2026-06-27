using System.Collections.Generic;
using System.Linq;

namespace Helpers.Extensions
{
	public static class DictionaryExtensions
	{
		public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this Dictionary<TKey, TValue> source)
		{
			return source.ToDictionary((KeyValuePair<TKey, TValue> entry) => entry.Key, (KeyValuePair<TKey, TValue> entry) => entry.Value);
		}
	}
}
