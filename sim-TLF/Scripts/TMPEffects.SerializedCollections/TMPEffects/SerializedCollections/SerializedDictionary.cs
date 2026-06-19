using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMPEffects.SerializedCollections
{
	[Serializable]
	public class SerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializedDictionary<TKey, TValue>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, ISerializationCallbackReceiver
	{
		[SerializeField]
		internal List<SerializedKeyValuePair<TKey, TValue>> _serializedList = new List<SerializedKeyValuePair<TKey, TValue>>();

		public List<SerializedKeyValuePair<TKey, TValue>> SerializedList
		{
			get
			{
				return _serializedList;
			}
			set
			{
				_serializedList = value;
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
		}
	}
}
