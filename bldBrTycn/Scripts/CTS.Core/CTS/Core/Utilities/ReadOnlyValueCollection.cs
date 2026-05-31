using System.Collections;
using System.Collections.Generic;

namespace CTS.Core.Utilities
{
	public readonly struct ReadOnlyValueCollection<TKey, TValue> : IReadOnlyCollection<TValue>, IEnumerable<TValue>, IEnumerable
	{
		private readonly Dictionary<TKey, TValue>.ValueCollection _collection;

		public int Count => _collection.Count;

		public ReadOnlyValueCollection(Dictionary<TKey, TValue> dictionary)
		{
			_collection = dictionary.Values;
		}

		public ReadOnlyValueCollection(SerializableDictionaryBase<TKey, TValue> dictionary)
		{
			_collection = dictionary.Dict.Values;
		}

		public static implicit operator ReadOnlyValueCollection<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
		{
			return new ReadOnlyValueCollection<TKey, TValue>(dictionary);
		}

		public static implicit operator ReadOnlyValueCollection<TKey, TValue>(SerializableDictionaryBase<TKey, TValue> dictionary)
		{
			return new ReadOnlyValueCollection<TKey, TValue>(dictionary);
		}

		public Dictionary<TKey, TValue>.ValueCollection.Enumerator GetEnumerator()
		{
			return _collection.GetEnumerator();
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
