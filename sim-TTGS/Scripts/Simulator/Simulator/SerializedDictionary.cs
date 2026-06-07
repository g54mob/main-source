using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public class SerializedDictionary<K, V> : IDictionary<K, V>, ICollection<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable, ISerializationCallbackReceiver
	{
		[Serializable]
		public struct KeyValuePair
		{
			public K key;

			public V value;
		}

		[NonSerialized]
		private Dictionary<K, V> m_dictionary;

		[SerializeField]
		private List<KeyValuePair> m_values = new List<KeyValuePair>();

		public bool IsReadOnly => false;

		public ICollection<K> Keys => m_dictionary.Keys;

		public ICollection<V> Values => m_dictionary.Values;

		public V this[K key]
		{
			get
			{
				return m_dictionary[key];
			}
			set
			{
				m_dictionary[key] = value;
			}
		}

		public int Count => m_dictionary.Count;

		public SerializedDictionary()
		{
			m_dictionary = new Dictionary<K, V>();
		}

		public SerializedDictionary(IEqualityComparer<K> comparer)
		{
			m_dictionary = new Dictionary<K, V>(comparer);
		}

		public void OnBeforeSerialize()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			m_values.Clear();
			foreach (KeyValuePair<K, V> item in m_dictionary)
			{
				m_values.Add(new KeyValuePair
				{
					key = item.Key,
					value = item.Value
				});
			}
		}

		public void OnAfterDeserialize()
		{
			m_dictionary.Clear();
			foreach (KeyValuePair value in m_values)
			{
				m_dictionary.TryAdd(value.key, value.value);
			}
		}

		public void Add(K key, V value)
		{
			m_dictionary.Add(key, value);
		}

		public void Add(KeyValuePair<K, V> item)
		{
			m_dictionary.Add(item.Key, item.Value);
		}

		public bool Remove(K key)
		{
			return m_dictionary.Remove(key);
		}

		public bool Remove(KeyValuePair<K, V> item)
		{
			return m_dictionary.Remove(item.Key);
		}

		public bool Contains(KeyValuePair<K, V> item)
		{
			return m_dictionary.ContainsKey(item.Key);
		}

		public bool ContainsKey(K key)
		{
			return m_dictionary.ContainsKey(key);
		}

		public bool TryGetValue(K key, out V value)
		{
			return m_dictionary.TryGetValue(key, out value);
		}

		public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
		{
			foreach (KeyValuePair<K, V> item in m_dictionary)
			{
				array[arrayIndex++] = item;
			}
		}

		public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
		{
			return m_dictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Clear()
		{
			m_dictionary.Clear();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Dictionary<K, V> GetInnerDictionary()
		{
			return m_dictionary;
		}
	}
}
