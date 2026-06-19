using System;
using System.Collections;
using System.Collections.Generic;
using TMPEffects.ObjectChanged;
using UnityEngine;

namespace TMPEffects.SerializedCollections
{
	[Serializable]
	public class SerializedObservableDictionary<TKey, TValue> : ObservableDictionary<TKey, TValue>, ISerializedDictionary<TKey, TValue>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, ISerializationCallbackReceiver where TValue : INotifyObjectChanged
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
			mayRaise = false;
			Clear();
			foreach (SerializedKeyValuePair<TKey, TValue> serialized in _serializedList)
			{
				Add(serialized.Key, serialized.Value);
			}
			_serializedList.Clear();
			mayRaise = true;
		}

		public void OnBeforeSerialize()
		{
		}
	}
}
