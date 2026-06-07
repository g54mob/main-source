using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coherence
{
	[Serializable]
	public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		[SerializeField]
		private List<TKey> keys;

		[SerializeField]
		private List<TValue> values;

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
