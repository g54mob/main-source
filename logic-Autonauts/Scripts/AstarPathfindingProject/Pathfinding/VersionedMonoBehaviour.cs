using System;
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
			if (Application.isPlaying)
			{
				version = OnUpgradeSerializedData(int.MaxValue, true);
			}
		}

		protected virtual void Reset()
		{
			version = OnUpgradeSerializedData(int.MaxValue, true);
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			int num = OnUpgradeSerializedData(version, false);
			if (num >= 0)
			{
				version = num;
			}
		}

		protected virtual int OnUpgradeSerializedData(int version, bool unityThread)
		{
			return 1;
		}

		void IVersionedMonoBehaviourInternal.UpgradeFromUnityThread()
		{
			int num = OnUpgradeSerializedData(version, true);
			if (num < 0)
			{
				throw new Exception();
			}
			version = num;
		}
	}
}
