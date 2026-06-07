using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_AddAnimatorBonesIndicators : RagdollAnimatorFeatureBase
	{
		public override bool OnInit()
		{
			RagdollHandler parentRagdollHandler = base.ParentRagdollHandler;
			if (base.InitializedWith.RequestVariable("Add Colliders On The Source Bones:", false).GetBool())
			{
				RagdollHandlerUtilities.AddCollidersOnTheCharacterBones(parentRagdollHandler);
				parentRagdollHandler.User_FindAllCollidersInsideAndIgnoreTheirCollisionWithDummyColliders(parentRagdollHandler.GetBaseTransform());
				if (base.InitializedWith.RequestVariable("Only Trigger Colliders:", false).GetBool())
				{
					foreach (RagdollBonesChain chain in base.ParentRagdollHandler.Chains)
					{
						foreach (RagdollChainBone boneSetup in chain.BoneSetups)
						{
							foreach (RagdollChainBone.ColliderSetup collider in boneSetup.Colliders)
							{
								if ((bool)collider.GameColliderOnSource)
								{
									collider.GameColliderOnSource.isTrigger = true;
								}
							}
						}
					}
				}
			}
			foreach (RagdollBonesChain chain2 in parentRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup2 in chain2.BoneSetups)
				{
					RagdollAnimator2BoneIndicator ragdollAnimator2BoneIndicator = boneSetup2.SourceBone.gameObject.GetComponent<RagdollAnimator2BoneIndicator>();
					if (ragdollAnimator2BoneIndicator == null)
					{
						ragdollAnimator2BoneIndicator = boneSetup2.SourceBone.gameObject.AddComponent<RagdollAnimator2BoneIndicator>();
					}
					ragdollAnimator2BoneIndicator.Initialize(parentRagdollHandler, boneSetup2.BoneProcessor, chain2, isAnimatorBone: true);
				}
			}
			if (parentRagdollHandler.BaseTransform.gameObject.GetComponent<RagdollAnimator2BoneIndicator>() == null)
			{
				RagdollAnimator2BoneIndicator ragdollAnimator2BoneIndicator2 = parentRagdollHandler.BaseTransform.gameObject.AddComponent<RagdollAnimator2BoneIndicator>();
				ragdollAnimator2BoneIndicator2.Initialize(parentRagdollHandler, null, null, isAnimatorBone: true);
				ragdollAnimator2BoneIndicator2.hideFlags = HideFlags.HideInInspector;
			}
			return true;
		}
	}
}
