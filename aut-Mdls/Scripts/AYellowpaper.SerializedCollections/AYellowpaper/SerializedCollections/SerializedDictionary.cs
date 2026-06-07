using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace AYellowpaper.SerializedCollections
{
	[Serializable]
	public class SerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		[SerializeField]
		internal List<SerializedKeyValuePair<TKey, TValue>> _serializedList = new List<SerializedKeyValuePair<TKey, TValue>>();

		public SerializedDictionary()
		{
		}

		public SerializedDictionary(SerializedDictionary<TKey, TValue> serializedDictionary)
			: base((IDictionary<TKey, TValue>)serializedDictionary)
		{
		}

		public SerializedDictionary(IDictionary<TKey, TValue> dictionary)
			: base(dictionary)
		{
		}

		public SerializedDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
			: base(dictionary, comparer)
		{
		}

		public SerializedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
			: base(collection)
		{
		}

		public SerializedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
			: base(collection, comparer)
		{
		}

		public SerializedDictionary(IEqualityComparer<TKey> comparer)
			: base(comparer)
		{
		}

		public SerializedDictionary(int capacity)
			: base(capacity)
		{
		}

		public SerializedDictionary(int capacity, IEqualityComparer<TKey> comparer)
			: base(capacity, comparer)
		{
		}

		[Conditional("UNITY_EDITOR")]
		private void SyncDictionaryToBackingField_Editor()
		{
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<TKey, TValue> current = enumerator.Current;
				_serializedList.Add(new SerializedKeyValuePair<TKey, TValue>(current.Key, current.Value));
			}
		}

		public void OnAfterDeserialize()
		{
			Clear();
			foreach (SerializedKeyValuePair<TKey, TValue> serialized in _serializedList)
			{
				Add(serialized.Key, serialized.Value);
			}
			_serializedList.Clear();
		}

		public void OnBeforeSerialize()
		{
			_serializedList.Clear();
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<TKey, TValue> current = enumerator.Current;
				_serializedList.Add(new SerializedKeyValuePair<TKey, TValue>(current.Key, current.Value));
			}
		}
	}
}
