using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public abstract class SerializableDictionaryBase
{
	public abstract class Storage
	{
	}

	protected class Dictionary<TKey, TValue> : System.Collections.Generic.Dictionary<TKey, TValue>
	{
		public Dictionary()
		{
		}

		public Dictionary(IDictionary<TKey, TValue> dict)
		{
		}

		public Dictionary(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
[Serializable]
public abstract class SerializableDictionaryBase<TKey, TValue, TValueStorage> : SerializableDictionaryBase, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, ISerializationCallbackReceiver, IDeserializationCallback, ISerializable
{
	private Dictionary<TKey, TValue> m_dict;

	[SerializeField]
	private TKey[] m_keys;

	[SerializeField]
	private TValueStorage[] m_values;

	public ICollection<TKey> Keys => null;

	public ICollection<TValue> Values => null;

	public int Count => 0;

	public bool IsReadOnly => false;

	public TValue this[TKey key]
	{
		get
		{
			return default(TValue);
		}
		set
		{
		}
	}

	public bool IsFixedSize => false;

	ICollection IDictionary.Keys => null;

	ICollection IDictionary.Values => null;

	public bool IsSynchronized => false;

	public object SyncRoot => null;

	public object this[object key]
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public SerializableDictionaryBase()
	{
	}

	public SerializableDictionaryBase(IDictionary<TKey, TValue> dict)
	{
	}

	protected abstract void SetValue(TValueStorage[] storage, int i, TValue value);

	protected abstract TValue GetValue(TValueStorage[] storage, int i);

	public void CopyFrom(IDictionary<TKey, TValue> dict)
	{
	}

	public void OnAfterDeserialize()
	{
	}

	public void OnBeforeSerialize()
	{
	}

	public void Add(TKey key, TValue value)
	{
	}

	public bool ContainsKey(TKey key)
	{
		return false;
	}

	public bool Remove(TKey key)
	{
		return false;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		value = default(TValue);
		return false;
	}

	public void Add(KeyValuePair<TKey, TValue> item)
	{
	}

	public void Clear()
	{
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		return false;
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
	}

	public bool Remove(KeyValuePair<TKey, TValue> item)
	{
		return false;
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return null;
	}

	public void Add(object key, object value)
	{
	}

	public bool Contains(object key)
	{
		return false;
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return null;
	}

	public void Remove(object key)
	{
	}

	public void CopyTo(Array array, int index)
	{
	}

	public void OnDeserialization(object sender)
	{
	}

	protected SerializableDictionaryBase(SerializationInfo info, StreamingContext context)
	{
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
	}
}
