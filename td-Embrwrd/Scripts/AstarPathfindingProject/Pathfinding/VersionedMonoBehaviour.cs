using UnityEngine;

namespace Pathfinding
{
	public abstract class VersionedMonoBehaviour : MonoBehaviour, ISerializationCallbackReceiver, IVersionedMonoBehaviourInternal
	{
		[SerializeField]
		[HideInInspector]
		private int version;

		protected virtual void Awake()
		{
		}

		protected virtual void Reset()
		{
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		protected virtual int OnUpgradeSerializedData(int version, bool unityThread)
		{
			return 0;
		}

		void IVersionedMonoBehaviourInternal.UpgradeFromUnityThread()
		{
		}
	}
}
