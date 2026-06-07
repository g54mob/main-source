using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Networking;

namespace Sirenix.OdinInspector
{
	[ShowOdinSerializedPropertiesInInspector]
	public abstract class SerializedNetworkBehaviour : NetworkBehaviour, ISerializationCallbackReceiver, ISupportsPrefabSerialization
	{
		[SerializeField]
		[HideInInspector]
		private SerializationData serializationData;

		SerializationData ISupportsPrefabSerialization.SerializationData
		{
			get
			{
				return serializationData;
			}
			set
			{
				serializationData = value;
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			UnitySerializationUtility.DeserializeUnityObject(this, ref serializationData);
			OnAfterDeserialize();
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			UnitySerializationUtility.SerializeUnityObject(this, ref serializationData);
			OnBeforeSerialize();
		}

		protected virtual void OnAfterDeserialize()
		{
		}

		protected virtual void OnBeforeSerialize()
		{
		}

		private void UNetVersion()
		{
		}

		public override bool OnSerialize(NetworkWriter writer, bool forceAll)
		{
			bool result = default(bool);
			return result;
		}

		public override void OnDeserialize(NetworkReader reader, bool initialState)
		{
		}
	}
}
