using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public abstract class RagdollAnimatorFeatureCollisions : RagdollAnimatorFeatureBase
	{
		public virtual bool EnableCollectCollision => false;

		public override bool OnInit()
		{
			base.ParentRagdollHandler.PrepareDummyBonesCollisionIndicators(EnableCollectCollision);
			base.ParentRagdollHandler.AddToDummyBoneCollisionEnterActions(OnCollisionEnterAction);
			return true;
		}

		public override void OnEnableRagdoll()
		{
			base.ParentRagdollHandler.AddToDummyBoneCollisionEnterActions(OnCollisionEnterAction);
		}

		public override void OnDisableRagdoll()
		{
			base.ParentRagdollHandler.RemoveFromDummyBoneCollisionEnterActions(OnCollisionEnterAction);
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.RemoveFromDummyBoneCollisionEnterActions(OnCollisionEnterAction);
		}

		public virtual void OnCollisionEnterAction(RA2BoneCollisionHandler hitted, Collision collision)
		{
		}
	}
}
