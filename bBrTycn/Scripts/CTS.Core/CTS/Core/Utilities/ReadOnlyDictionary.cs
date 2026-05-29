using System;
using System.Collections;
using System.Collections.Generic;

namespace CTS.Core.Utilities
{
	public readonly struct ReadOnlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEquatable<Dictionary<TKey, TValue>>, IEquatable<ReadOnlyDictionary<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>, Dictionary<TKey, TValue>.Enumerator>
	{
		private readonly Dictionary<TKey, TValue> _dictionary;

		public int Count => _dictionary.Count;

		public TValue this[TKey key] => _dictionary[key];

		IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => _dictionary.Keys;

		IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => _dictionary.Values;

		public Dictionary<TKey, TValue>.KeyCollection Keys => _dictionary.Keys;

		public Dictionary<TKey, TValue>.ValueCollection Values => _dictionary.Values;

		public ReadOnlyDictionary(Dictionary<TKey, TValue> dictionary)
		{
			_dictionary = dictionary;
		}

		public ReadOnlyDictionary(SerializableDictionaryBase<TKey, TValue> dictionary)
		{
			_dictionary = dictionary.Dict;
		}

		public static implicit operator ReadOnlyDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
		{
			return new ReadOnlyDictionary<TKey, TValue>(dictionary);
		}

		public static implicit operator ReadOnlyDictionary<TKey, TValue>(SerializableDictionaryBase<TKey, TValue> dictionary)
		{
			return dictionary.Dict;
		}

		public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return _dictionary.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public bool ContainsKey(TKey key)
		{
			return _dictionary.ContainsKey(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return _dictionary.TryGetValue(key, out value);
		}

		public Dictionary<TKey, TValue> Copy()
		{
			return new Dictionary<TKey, TValue>(_dictionary);
		}

		public static bool operator ==(ReadOnlyDictionary<TKey, TValue> dict, Dictionary<TKey, TValue> otherDict)
		{
			return dict.Equals(otherDict);
		}

		public static bool operator !=(ReadOnlyDictionary<TKey, TValue> dict, Dictionary<TKey, TValue> otherDict)
		{
			return !dict.Equals(otherDict);
		}

		public static bool operator ==(ReadOnlyDictionary<TKey, TValue> dict, ReadOnlyDictionary<TKey, TValue> otherDict)
		{
			return dict.Equals(otherDict);
		}

		public static bool operator !=(ReadOnlyDictionary<TKey, TValue> dict, ReadOnlyDictionary<TKey, TValue> otherDict)
		{
			return !dict.Equals(otherDict);
		}

		public static bool operator ==(Dictionary<TKey, TValue> dict, ReadOnlyDictionary<TKey, TValue> otherDict)
		{
			return otherDict.Equals(dict);
		}

		public static bool operator !=(Dictionary<TKey, TValue> dict, ReadOnlyDictionary<TKey, TValue> otherDict)
		{
			return !otherDict.Equals(dict);
		}

		public bool Equals(Dictionary<TKey, TValue> other)
		{
			if (_dictionary == null)
			{
				return other == null;
			}
			return _dictionary.Equals(other);
		}

		public bool Equals(ReadOnlyDictionary<TKey, TValue> other)
		{
			return Equals(other._dictionary);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ReadOnlyDictionary<TKey, TValue> other))
			{
				if (!(obj is Dictionary<TKey, TValue> other2))
				{
					if (obj is SerializableDictionaryBase<TKey, TValue> serializableDictionaryBase)
					{
						return Equals(serializableDictionaryBase);
					}
					return false;
				}
				return Equals(other2);
			}
			return Equals(other);
		}

		public override int GetHashCode()
		{
			return _dictionary.GetHashCode();
		}
	}
}
