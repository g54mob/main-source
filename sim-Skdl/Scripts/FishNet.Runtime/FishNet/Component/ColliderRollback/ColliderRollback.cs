using FishNet.Object;
using UnityEngine;

namespace FishNet.Component.ColliderRollback
{
	public class ColliderRollback : NetworkBehaviour
	{
		internal enum BoundingBoxType
		{
			Disabled = 0,
			Manual = 1
		}

		[Tooltip("How to configure the bounding box check.")]
		[SerializeField]
		private BoundingBoxType _boundingBox;

		[Tooltip("Physics type to generate a bounding box for.")]
		[SerializeField]
		private RollbackPhysicsType _physicsType;

		[Tooltip("Size for the bounding box.. This is only used when BoundingBox is set to Manual.")]
		[SerializeField]
		private Vector3 _boundingBoxSize;

		[Tooltip("Objects holding colliders which can rollback.")]
		[SerializeField]
		private GameObject[] _colliderParents;

		private bool NetworkInitialize___EarlyFishNet_002EComponent_002EColliderRollback_002EColliderRollbackFishNet_002ERuntime_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EComponent_002EColliderRollback_002EColliderRollbackFishNet_002ERuntime_002Edll_Excuted;

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		public virtual void Awake()
		{
		}
	}
}
