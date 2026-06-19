using System.Collections.Generic;

namespace Sentry.Internal.Extensions
{
	internal static class ReadOnlyDictionaryExtensions
	{
		public static TValue? TryGetValue<TKey, TValue>(this IReadOnlyDictionary<TKey, object?> dictionary, TKey key) where TKey : notnull
		{
			if (dictionary.TryGetValue(key, out object value) && value is TValue)
			{
				return (TValue)value;
			}
			return default(TValue);
		}
	}
}
