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
		internal List<SerializedKeyValuePair<TKey, TValue>> _serializedList;

		public List<SerializedKeyValuePair<TKey, TValue>> SerializedList
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}
	}
}
