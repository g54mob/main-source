using System.Collections;
using System.Collections.Generic;

namespace TMPEffects.SerializedCollections
{
	internal interface ISerializedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		List<SerializedKeyValuePair<TKey, TValue>> SerializedList { get; set; }
	}
}
