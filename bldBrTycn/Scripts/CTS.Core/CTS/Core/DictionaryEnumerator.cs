using System.Collections;
using System.Collections.Generic;

namespace CTS.Core
{
	public readonly struct DictionaryEnumerator<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private readonly Dictionary<TKey, TValue> _dict;

		public DictionaryEnumerator(Dictionary<TKey, TValue> dict)
		{
			_dict = dict;
		}

		public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return _dict.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
