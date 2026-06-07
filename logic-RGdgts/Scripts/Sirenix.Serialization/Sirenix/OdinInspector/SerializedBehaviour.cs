using Sirenix.Serialization;
using UnityEngine;

namespace Sirenix.OdinInspector
{
	public abstract class SerializedBehaviour : Behaviour, ISerializationCallbackReceiver, ISupportsPrefabSerialization
	{
		[HideInInspector]
		[SerializeField]
		private SerializationData serializationData;

		SerializationData ISupportsPrefabSerialization.SerializationData
		{
			get
			{
				return default(SerializationData);
			}
			set
			{
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		protected virtual void OnAfterDeserialize()
		{
		}

		protected virtual void OnBeforeSerialize()
		{
		}
	}
}
