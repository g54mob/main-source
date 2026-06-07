using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SaintsField
{
	[Serializable]
	public abstract class SaintsDictionaryBase<TKey, TValue> : IDictionary, ICollection, IEnumerable, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, ISerializationCallbackReceiver
	{
		protected Dictionary<TKey, TValue> Dictionary = new Dictionary<TKey, TValue>();

		private ICollection _keys;

		private ICollection _values;

		protected readonly object SyncRootObj = new object();

		protected abstract List<TKey> SerializedKeys { get; }

		protected abstract List<TValue> SerializedValues { get; }

		public ICollection<TKey> Keys => Dictionary.Keys;

		ICollection IDictionary.Values => Dictionary.Values;

		ICollection IDictionary.Keys => Dictionary.Keys;

		public ICollection<TValue> Values => Dictionary.Values;

		public virtual bool IsFixedSize => false;

		public int Count => Dictionary.Count;

		public bool IsSynchronized => false;

		public virtual object SyncRoot => SyncRootObj;

		public virtual bool IsReadOnly => false;

		public object this[object key]
		{
			get
			{
				return Dictionary[(TKey)key];
			}
			set
			{
				TKey key2 = (TKey)key;
				TValue value2 = (TValue)value;
				Dictionary[key2] = value2;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				return Dictionary[key];
			}
			set
			{
				Dictionary[key] = value;
			}
		}

		public void OnBeforeSerialize()
		{
			SerializedKeys.Clear();
			SerializedValues.Clear();
			foreach (KeyValuePair<TKey, TValue> item in Dictionary)
			{
				SerializedKeys.Add(item.Key);
				SerializedValues.Add(item.Value);
			}
		}

		public void OnAfterDeserialize()
		{
			Dictionary.Clear();
			for (int i = 0; i < SerializedKeys.Count; i++)
			{
				TKey key = SerializedKeys[i];
				TValue value = ((SerializedValues.Count > i) ? SerializedValues[i] : default(TValue));
				Dictionary.Add(key, value);
			}
			SerializedKeys.Clear();
			SerializedValues.Clear();
		}

		public void Add(TKey key, TValue value)
		{
			Dictionary.Add(key, value);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return Dictionary.TryGetValue(key, out value);
		}

		public bool Contains(object key)
		{
			return Dictionary.ContainsKey((TKey)key);
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return Dictionary.GetEnumerator();
		}

		public void Remove(object key)
		{
			TKey key2 = (TKey)key;
			Dictionary.Remove(key2);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return Dictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Dictionary.Add(item.Key, item.Value);
		}

		public void Add(object key, object value)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			Dictionary.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return Dictionary.Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<TKey, TValue>>)Dictionary).CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Dictionary.Remove(item.Key);
		}

		public void CopyTo(Array array, int arrayIndex)
		{
			KeyValuePair<object, object>[] array2 = new KeyValuePair<object, object>[Dictionary.Count];
			int num = 0;
			foreach (KeyValuePair<TKey, TValue> item in Dictionary)
			{
				array2[num] = new KeyValuePair<object, object>(item.Key, item.Value);
				num++;
			}
			array2.CopyTo(array, arrayIndex);
		}

		public bool ContainsKey(TKey key)
		{
			return Dictionary.ContainsKey(key);
		}

		public bool Remove(TKey key)
		{
			if (Dictionary.Remove(key))
			{
				return true;
			}
			return false;
		}

		public bool TryAdd(TKey key, TValue value)
		{
			if (Dictionary.ContainsKey(key))
			{
				return false;
			}
			Dictionary.Add(key, value);
			return true;
		}
	}
}
