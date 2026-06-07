using System;
using System.Collections;
using System.Collections.Generic;

public abstract class UnityDictionary<K, V> : IDictionary<K, V>, ICollection<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable
{
	internal sealed class UnityDictionaryEnumerator : IEnumerator<KeyValuePair<K, V>>, IEnumerator, IDisposable
	{
		private KeyValuePair<K, V>[] items;

		private int index;

		object IEnumerator.Current => null;

		public KeyValuePair<K, V> Current => default(KeyValuePair<K, V>);

		public KeyValuePair<K, V> Entry => default(KeyValuePair<K, V>);

		public K Key => default(K);

		public V Value => default(V);

		internal UnityDictionaryEnumerator()
		{
		}

		internal UnityDictionaryEnumerator(UnityDictionary<K, V> ud)
		{
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			return false;
		}

		private void ValidateIndex()
		{
		}

		public void Reset()
		{
		}
	}

	protected abstract List<UnityKeyValuePair<K, V>> KeyValuePairs { get; set; }

	public virtual V this[K key]
	{
		get
		{
			return default(V);
		}
		set
		{
		}
	}

	public int Count => 0;

	public ICollection<K> Keys => null;

	public ICollection<V> Values => null;

	public ICollection<KeyValuePair<K, V>> Items => null;

	public V SyncRoot => default(V);

	public bool IsFixedSize => false;

	public bool IsReadOnly => false;

	public bool IsSynchronized => false;

	protected abstract void SetKeyValuePair(K k, V v);

	public void Add(K key, V value)
	{
	}

	public void Add(KeyValuePair<K, V> kvp)
	{
	}

	public bool TryGetValue(K key, out V value)
	{
		value = default(V);
		return false;
	}

	public bool Remove(KeyValuePair<K, V> item)
	{
		return false;
	}

	public bool Remove(K key)
	{
		return false;
	}

	public void Clear()
	{
	}

	public bool ContainsKey(K key)
	{
		return false;
	}

	public bool Contains(KeyValuePair<K, V> kvp)
	{
		return false;
	}

	public void CopyTo(KeyValuePair<K, V>[] array, int index)
	{
	}

	public KeyValuePair<K, V> ConvertUkvp(UnityKeyValuePair<K, V> ukvp)
	{
		return default(KeyValuePair<K, V>);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return null;
	}

	public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
	{
		return null;
	}
}
public abstract class UnityDictionary<V> : UnityDictionary<string, V>
{
}
