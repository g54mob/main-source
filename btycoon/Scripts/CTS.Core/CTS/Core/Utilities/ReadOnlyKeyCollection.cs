using System.Collections;
using System.Collections.Generic;

namespace CTS.Core.Utilities
{
	public readonly struct ReadOnlyKeyCollection<TKey, TValue> : IReadOnlyCollection<TKey>, IEnumerable<TKey>, IEnumerable
	{
		private readonly Dictionary<TKey, TValue>.KeyCollection _collection;

		public int Count => _collection.Count;

		public ReadOnlyKeyCollection(Dictionary<TKey, TValue> dictionary)
		{
			_collection = dictionary.Keys;
		}

		public ReadOnlyKeyCollection(SerializableDictionaryBase<TKey, TValue> dictionary)
		{
			_collection = dictionary.Dict.Keys;
		}

		public static implicit operator ReadOnlyKeyCollection<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
		{
			return new ReadOnlyKeyCollection<TKey, TValue>(dictionary);
		}

		public static implicit operator ReadOnlyKeyCollection<TKey, TValue>(SerializableDictionaryBase<TKey, TValue> dictionary)
		{
			return new ReadOnlyKeyCollection<TKey, TValue>(dictionary);
		}

		public Dictionary<TKey, TValue>.KeyCollection.Enumerator GetEnumerator()
		{
			return _collection.GetEnumerator();
		}

		IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
