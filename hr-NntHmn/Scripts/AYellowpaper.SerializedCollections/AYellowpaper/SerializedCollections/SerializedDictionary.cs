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
		internal List<SerializedKeyValuePair<TKey, TValue>> _serializedList;

		public SerializedDictionary()
		{
		}

		public SerializedDictionary(SerializedDictionary<TKey, TValue> serializedDictionary)
		{
		}

		public SerializedDictionary(IDictionary<TKey, TValue> dictionary)
		{
		}

		public SerializedDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
		}

		public SerializedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
		{
		}

		public SerializedDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
		{
		}

		public SerializedDictionary(IEqualityComparer<TKey> comparer)
		{
		}

		public SerializedDictionary(int capacity)
		{
		}

		public SerializedDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
		}

		[Conditional("UNITY_EDITOR")]
		private void SyncDictionaryToBackingField_Editor()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}
	}
}
