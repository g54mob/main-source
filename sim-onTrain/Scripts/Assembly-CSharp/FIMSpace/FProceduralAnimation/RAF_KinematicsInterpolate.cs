using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_KinematicsInterpolate : RagdollAnimatorFeatureBase
	{
		private float lastFixedTime;

		public override bool OnInit()
		{
			base.ParentRagdollHandler.AddToPostLateUpdateLoop(PostLateUpdate);
			return base.OnInit();
		}

		public override void OnDestroyFeature()
		{
			base.ParentRagdollHandler.RemoveFromPostLateUpdateLoop(PostLateUpdate);
		}

		private void PostLateUpdate()
		{
			if (!base.InitializedWith.Enabled || base.ParentRagdollHandler.AnimatingMode != RagdollHandler.EAnimatingMode.Standing)
			{
				return;
			}
			float t = Time.fixedTime - lastFixedTime;
			foreach (RagdollBonesChain chain in base.ParentRagdollHandler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					if (boneSetup.GameRigidbody.isKinematic && !boneSetup.BypassKinematicControl)
					{
						boneSetup.SourceBone.position = Vector3.LerpUnclamped(boneSetup.BoneProcessor.AnimatorPosition, boneSetup.GameRigidbody.position, t);
					}
				}
			}
			lastFixedTime = Time.fixedTime;
		}
	}
}
