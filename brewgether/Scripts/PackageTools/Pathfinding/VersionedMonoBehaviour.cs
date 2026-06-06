using System.Runtime.CompilerServices;
using Pathfinding.Drawing;
using Pathfinding.Serialization;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	public abstract class VersionedMonoBehaviour : MonoBehaviourGizmos, ISerializationCallbackReceiver, IVersionedMonoBehaviourInternal, IEntityIndex
	{
		[SerializeField]
		[HideInInspector]
		private int version;

		int IEntityIndex.EntityIndex
		{
			[CompilerGenerated]
			get
			{
				return 0;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Reset()
		{
		}

		private void DisableGizmosIcon()
		{
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		protected void UpgradeSerializedData(bool isUnityThread)
		{
		}

		protected virtual void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
		}

		void IVersionedMonoBehaviourInternal.UpgradeFromUnityThread()
		{
		}
	}
}
