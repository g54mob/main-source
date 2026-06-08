using System.Collections;
using System.Collections.Generic;

namespace HandlebarsDotNet.Collections
{
	public interface IIndexed<TKey, TValue> : IReadOnlyIndexed<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		new TValue this[in TKey key] { get; set; }

		void AddOrReplace(in TKey key, in TValue value);

		void Clear();
	}
}
