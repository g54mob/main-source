using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public abstract class SerializableHashSet<T> : SerializableHashSetBase, ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ISerializationCallbackReceiver, IDeserializationCallback, ISerializable
{
	private HashSet<T> m_hashSet;

	[SerializeField]
	private T[] m_keys;

	public int Count => 0;

	public bool IsReadOnly => false;

	public SerializableHashSet()
	{
	}

	public SerializableHashSet(ISet<T> set)
	{
	}

	public void CopyFrom(ISet<T> set)
	{
	}

	public void OnAfterDeserialize()
	{
	}

	public void OnBeforeSerialize()
	{
	}

	public bool Add(T item)
	{
		return false;
	}

	public void ExceptWith(IEnumerable<T> other)
	{
	}

	public void IntersectWith(IEnumerable<T> other)
	{
	}

	public bool IsProperSubsetOf(IEnumerable<T> other)
	{
		return false;
	}

	public bool IsProperSupersetOf(IEnumerable<T> other)
	{
		return false;
	}

	public bool IsSubsetOf(IEnumerable<T> other)
	{
		return false;
	}

	public bool IsSupersetOf(IEnumerable<T> other)
	{
		return false;
	}

	public bool Overlaps(IEnumerable<T> other)
	{
		return false;
	}

	public bool SetEquals(IEnumerable<T> other)
	{
		return false;
	}

	public void SymmetricExceptWith(IEnumerable<T> other)
	{
	}

	public void UnionWith(IEnumerable<T> other)
	{
	}

	void ICollection<T>.Add(T item)
	{
	}

	public void Clear()
	{
	}

	public bool Contains(T item)
	{
		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
	}

	public bool Remove(T item)
	{
		return false;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return null;
	}

	public void OnDeserialization(object sender)
	{
	}

	protected SerializableHashSet(SerializationInfo info, StreamingContext context)
	{
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
	}
}
