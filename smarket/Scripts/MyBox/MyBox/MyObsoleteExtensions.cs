using System;
using System.Collections.Generic;

namespace MyBox
{
	public static class MyObsoleteExtensions
	{
		[Obsolete("1.6.3: Use MyCollections.GetOrAdd instead")]
		public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue customDefault = default(TValue))
		{
			return default(TValue);
		}

		[Obsolete("1.6.3: Use MyCollections.GetOrAdd instead")]
		public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Func<TValue> customDefaultGenerator)
		{
			return default(TValue);
		}
	}
}
