using FIMSpace.FGenerating;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_SoftLimitAnchor : RagdollAnimatorFeatureUpdate
	{
		private FUniversalVariable softLimit;

		private FUniversalVariable resetRange;

		private FUniversalVariable fallRange;

		private float standingDuration;

		private float lastFactor;

		public override bool UseFixedUpdate => true;

		public override bool OnInit()
		{
			softLimit = base.InitializedWith.RequestVariable("Soft Limit Range:", 0.5f);
			resetRange = base.InitializedWith.RequestVariable("Reset On Range:", 0f);
			fallRange = base.InitializedWith.RequestVariable("Fall On Factor:", 0f);
			base.ParentRagdollHandler.AddToOnFallModeSwitchActions(RefreshFactor);
			return base.OnInit();
		}

		public override void FixedUpdate()
		{
			if (!base.Helper.Enabled)
			{
				return;
			}
			if (softLimit.GetFloat() <= 0f)
			{
				base.ParentRagdollHandler.anchorBoneSpringPositionMultiplier = 1f;
				return;
			}
			RagdollChainBone getAnchorBoneController = base.ParentRagdollHandler.GetAnchorBoneController;
			float num = (getAnchorBoneController.BoneProcessor.LastMatchingRigidodyOrigin - getAnchorBoneController.GameRigidbody.worldCenterOfMass).sqrMagnitude * softLimit.GetFloat() * 25f + 1f;
			base.ParentRagdollHandler.anchorBoneSpringPositionMultiplier = 1f / num;
			lastFactor = num;
			if (base.ParentRagdollHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
			{
				standingDuration += Time.fixedDeltaTime;
				if (!(standingDuration < 0.5f))
				{
					if (resetRange.GetFloat() > 1f && num > resetRange.GetFloat())
					{
						base.ParentRagdollHandler.anchorBoneSpringPositionMultiplier = 1f;
					}
					if (fallRange.GetFloat() > 2f && num > fallRange.GetFloat())
					{
						base.ParentRagdollHandler.User_SwitchFallState();
					}
				}
			}
			else
			{
				standingDuration = 0f;
			}
		}

		public override void OnEnabledSwitch()
		{
			lastFactor = 0f;
		}

		private void RefreshFactor()
		{
			lastFactor = 0f;
		}

		public override void OnDestroyFeature()
		{
			base.OnDestroyFeature();
			base.ParentRagdollHandler.RemoveFromOnFallModeSwitchActions(RefreshFactor);
		}
	}
}
