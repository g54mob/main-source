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
