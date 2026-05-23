using System.Collections.Generic;

namespace Utf8Json.Formatters
{
	public sealed class SortedDictionaryFormatter<TKey, TValue> : DictionaryFormatterBase<TKey, TValue, SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, SortedDictionary<TKey, TValue>>
	{
		protected override void Add(ref SortedDictionary<TKey, TValue> collection, int index, TKey key, TValue value)
		{
		}

		protected override SortedDictionary<TKey, TValue> Complete(ref SortedDictionary<TKey, TValue> intermediateCollection)
		{
			return null;
		}

		protected override SortedDictionary<TKey, TValue> Create()
		{
			return null;
		}

		protected override SortedDictionary<TKey, TValue>.Enumerator GetSourceEnumerator(SortedDictionary<TKey, TValue> source)
		{
			return default(SortedDictionary<TKey, TValue>.Enumerator);
		}
	}
}
