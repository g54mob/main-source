using System.Collections;
using System.Collections.Generic;

namespace HandlebarsDotNet.Collections
{
	public interface IReadOnlyIndexed<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		TValue this[in TKey key] { get; }

		bool ContainsKey(in TKey key);

		bool TryGetValue(in TKey key, out TValue value);
	}
}
