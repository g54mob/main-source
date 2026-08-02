using System;
using System.Collections.Generic;

namespace MoonSharp.Interpreter
{
	internal static class Extension_Methods
	{
		public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
		{
			return default(TValue);
		}

		public static TValue GetOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> creator)
		{
			return default(TValue);
		}
	}
}
