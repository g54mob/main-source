using System.Collections.Generic;

namespace GameKit.Utilities
{
	public static class DictionaryFN
	{
		public static bool TryGetValueIL2CPP<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}
	}
}
