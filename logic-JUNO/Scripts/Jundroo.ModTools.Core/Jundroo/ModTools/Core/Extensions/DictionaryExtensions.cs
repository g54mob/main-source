using System.Collections.Generic;

namespace Jundroo.ModTools.Core.Extensions
{
	public static class DictionaryExtensions
	{
		public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
		{
			TValue value = default(TValue);
			dictionary.TryGetValue(key, out value);
			return value;
		}
	}
}
