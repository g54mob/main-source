using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	public abstract class SerializableDictionaryBase<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, ISerializationCallbackReceiver
	{
		private readonly Dictionary<TKey, int> _indexByKey = new Dictionary<TKey, int>();

		private Dictionary<TKey, TValue> _dict;

		private static readonly Dictionary<TKey, TValue> _tempCollisionDetection = new Dictionary<TKey, TValue>();

		public Dictionary<TKey, TValue> Dict
		{
			get
			{
				Deserialize();
				return _dict;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				return Dict[key];
			}
			set
			{
				Dict[key] = value;
				if (_indexByKey.TryGetValue(key, out var value2))
				{
					SetKeyAndValueAtIndex(value2, key, value);
					return;
				}
				AddKeyAndValue(key, value);
				_indexByKey.Add(key, GetListCount() - 1);
			}
		}

		public ICollection<TKey> Keys => Dict.Keys;

		public ICollection<TValue> Values => Dict.Values;

		public int Count => Dict.Count;

		public bool IsReadOnly { get; set; }

		protected abstract TKey GetKeyAtIndex(int index);

		protected abstract TValue GetValueAtIndex(int index);

		protected abstract int GetListCount();

		protected abstract void SetKeyAndValueAtIndex(int index, TKey key, TValue value);

		protected abstract void AddKeyAndValue(TKey key, TValue value);

		protected abstract void RemoveAtIndex(int index);

		protected abstract void ClearList();

		private bool IsColliding()
		{
			_tempCollisionDetection.Clear();
			for (int i = 0; i < GetListCount(); i++)
			{
				TKey keyAtIndex = GetKeyAtIndex(i);
				if (keyAtIndex != null && !_tempCollisionDetection.ContainsKey(keyAtIndex))
				{
					_tempCollisionDetection.Add(keyAtIndex, GetValueAtIndex(i));
					continue;
				}
				return true;
			}
			return false;
		}

		public void Deserialize()
		{
			if (_dict != null)
			{
				return;
			}
			_dict = new Dictionary<TKey, TValue>();
			_indexByKey.Clear();
			for (int i = 0; i < GetListCount(); i++)
			{
				TKey keyAtIndex = GetKeyAtIndex(i);
				if (keyAtIndex != null && !_dict.ContainsKey(keyAtIndex))
				{
					_dict.Add(keyAtIndex, GetValueAtIndex(i));
					_indexByKey.Add(keyAtIndex, i);
				}
			}
		}

		public void Add(TKey key, TValue value)
		{
			Dict.Add(key, value);
			AddKeyAndValue(key, value);
			_indexByKey.Add(key, GetListCount() - 1);
		}

		public bool ContainsKey(TKey key)
		{
			return Dict.ContainsKey(key);
		}

		public bool Remove(TKey key)
		{
			if (Dict.Remove(key))
			{
				int num = _indexByKey[key];
				RemoveAtIndex(num);
				UpdateIndexLookup(num);
				_indexByKey.Remove(key);
				return true;
			}
			return false;
			void UpdateIndexLookup(int removedIndex)
			{
				for (int i = removedIndex; i < GetListCount(); i++)
				{
					TKey keyAtIndex = GetKeyAtIndex(i);
					_indexByKey[keyAtIndex]--;
				}
			}
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return Dict.TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<TKey, TValue> pair)
		{
			Add(pair.Key, pair.Value);
		}

		public void Clear()
		{
			Dict.Clear();
			ClearList();
			_indexByKey.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> pair)
		{
			if (Dict.TryGetValue(pair.Key, out var value))
			{
				return EqualityComparer<TValue>.Default.Equals(value, pair.Value);
			}
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			Deserialize();
			if (array == null)
			{
				throw new ArgumentException("The array cannot be null.");
			}
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
			}
			if (array.Length - arrayIndex < _dict.Count)
			{
				throw new ArgumentException("The destination array has fewer elements than the collection.");
			}
			foreach (KeyValuePair<TKey, TValue> item in _dict)
			{
				array[arrayIndex] = item;
				arrayIndex++;
			}
		}

		public bool Remove(KeyValuePair<TKey, TValue> pair)
		{
			if (Dict.TryGetValue(pair.Key, out var value) && EqualityComparer<TValue>.Default.Equals(value, pair.Value))
			{
				return Remove(pair.Key);
			}
			return false;
		}

		public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return Dict.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return Dict.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Dict.GetEnumerator();
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			_dict = null;
		}
	}
}
