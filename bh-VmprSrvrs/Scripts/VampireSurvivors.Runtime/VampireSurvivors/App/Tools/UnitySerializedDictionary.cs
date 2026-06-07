using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.App.Tools
{
	public abstract class UnitySerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		[SerializeField]
		[HideInInspector]
		private List<TKey> keyData;

		[SerializeField]
		[HideInInspector]
		private List<TValue> valueData;

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}
	}
}
