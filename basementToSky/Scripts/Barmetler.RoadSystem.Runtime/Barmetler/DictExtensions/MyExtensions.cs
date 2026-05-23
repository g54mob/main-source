using System.Collections.Generic;

namespace Barmetler.DictExtensions
{
	public static class MyExtensions
	{
		public static V GetWithDefault<K, V>(this Dictionary<K, V> dict, K key, V defaultValue)
		{
			if (!dict.TryGetValue(key, out var value))
			{
				return defaultValue;
			}
			return value;
		}
	}
}
