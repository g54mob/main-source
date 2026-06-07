using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_BlendOnSourceCollision : RAF_BlendOnCollisions
	{
		protected override void InitIndicators()
		{
			base.ParentRagdollHandler.PrepareSourceBonesCollisionIndicators(triggerHandlers: true, enableCollisionCollecting: true);
			foreach (RagdollBonesChain chain in base.ParentRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					foreach (RagdollChainBone.ColliderSetup collider in boneSetup.Colliders)
					{
						base.ParentRagdollHandler.IgnoreCollisionWith(collider.GameColliderOnSource);
					}
				}
			}
			base.ParentRagdollHandler.EnsureRelatedCollidersIgnore();
			foreach (RagdollBonesChain chain2 in base.ParentRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup2 in chain2.BoneSetups)
				{
					foreach (RagdollChainBone.ColliderSetup collider2 in boneSetup2.Colliders)
					{
						Rigidbody rigidbody = boneSetup2.SourceBone.gameObject.AddComponent<Rigidbody>();
						if ((bool)rigidbody)
						{
							rigidbody.isKinematic = true;
						}
						if ((bool)collider2.GameColliderOnSource)
						{
							collider2.GameColliderOnSource.isTrigger = true;
						}
					}
				}
			}
		}

		protected override RA2BoneCollisionHandlerBase GetCollisionHandler(RagdollChainBone bone)
		{
			return bone.SourceBone.GetComponent<RA2BoneTriggerCollisionHandler>();
		}
	}
}
