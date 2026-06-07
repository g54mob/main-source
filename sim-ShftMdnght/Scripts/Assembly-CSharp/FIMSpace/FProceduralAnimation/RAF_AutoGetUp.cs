using System.Collections.Generic;
using FIMSpace.FGenerating;
using UnityEngine;
using UnityEngine.Events;

namespace FIMSpace.FProceduralAnimation
{
	public class RAF_AutoGetUp : RagdollAnimatorFeatureUpdate
	{
		private FUniversalVariable getupDelay;

		private FUniversalVariable maxAvgTranslation;

		private FUniversalVariable maxAvgTorq;

		private FUniversalVariable groundMask;

		private FUniversalVariable minimumStable;

		private FUniversalVariable ragdollStandupBlendDuration;

		private FUniversalVariable crossfadesDelay;

		private FUniversalVariable quickBlendFade;

		private FUniversalVariable freezeHipsDuration;

		private FUniversalVariable standingRestore;

		private FUniversalVariable standingRestoreMinTime;

		private FUniversalVariable restoreAngle;

		private float fallingDuration;

		private float stableTime;

		private float legsStandElapsed;

		public override bool UseFixedUpdate => true;

		public ERagdollGetUpType getUpType { get; private set; }

		public RaycastHit groundHit { get; private set; }

		public override bool OnInit()
		{
			getupDelay = base.InitializedWith.RequestVariable("Minimum Delay:", 0.4f);
			maxAvgTranslation = base.InitializedWith.RequestVariable("Max avg. Translation:", 0.075f);
			maxAvgTorq = base.InitializedWith.RequestVariable("Max avg. Torque:", 1f);
			groundMask = base.InitializedWith.RequestVariable("Ground Mask:", 0);
			minimumStable = base.InitializedWith.RequestVariable("Minimum Stability:", 0.15f);
			crossfadesDelay = base.InitializedWith.RequestVariable("Animator Fade Delay:", 0f);
			ragdollStandupBlendDuration = base.InitializedWith.RequestVariable("To Standing Transition Duration:", 1f);
			quickBlendFade = base.InitializedWith.RequestVariable("Quick Blend Fade:", 0.3f);
			CheckBackCompatibility(base.InitializedWith);
			freezeHipsDuration = base.InitializedWith.RequestVariable("Freeze Source Animator Hips:", 0f);
			standingRestore = base.InitializedWith.RequestVariable("Allow Standing Restore:", false);
			standingRestoreMinTime = base.InitializedWith.RequestVariable("Restore After:", 0.3f);
			restoreAngle = base.InitializedWith.RequestVariable("Max Body Angle To Restore:", 35f);
			fallingDuration = 0f;
			stableTime = 0f;
			getUpType = ERagdollGetUpType.None;
			groundHit = default(RaycastHit);
			return base.OnInit();
		}

		private void CheckBackCompatibility(RagdollAnimatorFeatureHelper helper)
		{
			if (helper.HasVariable("Feeze Source Animator Hips:"))
			{
				FUniversalVariable fUniversalVariable = helper.RequestVariable("Feeze Source Animator Hips:", 0f);
				if (fUniversalVariable.GetFloat() != 0f)
				{
					helper.RequestVariable("Freeze Source Animator Hips:", 0f).SetValue(fUniversalVariable.GetFloat());
					fUniversalVariable.SetValue(0f);
				}
			}
		}

		public override void FixedUpdate()
		{
			if (!base.InitializedWith.Enabled)
			{
				return;
			}
			RagdollHandler parentRagdollHandler = base.ParentRagdollHandler;
			if (parentRagdollHandler.AnimatingMode == RagdollHandler.EAnimatingMode.Standing)
			{
				fallingDuration = 0f;
				stableTime = 0f;
			}
			else
			{
				if (parentRagdollHandler.AnimatingMode != RagdollHandler.EAnimatingMode.Falling)
				{
					return;
				}
				fallingDuration += Time.fixedDeltaTime;
				if (fallingDuration < getupDelay.GetFloat())
				{
					legsStandElapsed = 0f;
					return;
				}
				float magnitude = parentRagdollHandler.User_GetChainBonesAverageTranslation(ERagdollChainType.Core).magnitude;
				if (magnitude > maxAvgTranslation.GetFloat())
				{
					stableTime = 0f;
					legsStandElapsed = 0f;
					return;
				}
				if (parentRagdollHandler.User_GetChainAngularVelocity(ERagdollChainType.Core).magnitude > maxAvgTorq.GetFloat() * parentRagdollHandler.User_CoreLowTranslationFactor(magnitude))
				{
					stableTime = 0f;
					legsStandElapsed = 0f;
					return;
				}
				stableTime += Time.deltaTime;
				if (stableTime < minimumStable.GetFloat())
				{
					return;
				}
				bool flag = true;
				if (groundMask.GetInt() != 0)
				{
					groundHit = parentRagdollHandler.ProbeGroundBelowHips(groundMask.GetInt(), parentRagdollHandler.GetAnchorBoneController.MainBoneCollider.bounds.size.magnitude + 0.01f);
					if (groundHit.transform == null)
					{
						flag = false;
					}
				}
				if (!flag)
				{
					if (!standingRestore.GetBool() || Vector3.Angle(parentRagdollHandler.User_BoneWorldUp(parentRagdollHandler.GetAnchorBoneController), Vector3.up) > restoreAngle.GetFloat())
					{
						return;
					}
					RagdollBonesChain chain = parentRagdollHandler.GetChain(ERagdollChainType.LeftLeg);
					if (chain == null)
					{
						return;
					}
					RagdollBonesChain chain2 = parentRagdollHandler.GetChain(ERagdollChainType.RightLeg);
					if (chain2 != null && !(parentRagdollHandler.ProbeGroundBelow(chain.GetBone(100), groundMask.GetInt()).transform == null) && !(parentRagdollHandler.ProbeGroundBelow(chain2.GetBone(100), groundMask.GetInt()).transform == null))
					{
						legsStandElapsed += Time.fixedDeltaTime;
						if (legsStandElapsed > standingRestoreMinTime.GetFloat())
						{
							parentRagdollHandler.User_TransitionToStandingMode(ragdollStandupBlendDuration.GetFloat(), quickBlendFade.GetFloat(), (crossfadesDelay.GetFloat() > 0f) ? 0.1f : 0f, 0f, 0f, isOnLegsRestoreCall: true);
							base.Helper.customEventsList[0].Invoke();
						}
					}
				}
				else
				{
					getUpType = parentRagdollHandler.User_CanGetUpByRotation();
					parentRagdollHandler.User_TransitionToStandingMode(ragdollStandupBlendDuration.GetFloat(), quickBlendFade.GetFloat(), (crossfadesDelay.GetFloat() > 0f) ? 0.1f : 0f, freezeHipsDuration.GetFloat());
					base.Helper.customEventsList[0].Invoke();
				}
			}
		}

		private bool RefreshHelperEvents(RagdollAnimatorFeatureHelper helper)
		{
			bool result = false;
			if (helper.customEventsList == null)
			{
				helper.customEventsList = new List<UnityEvent>();
				result = true;
			}
			while (helper.customEventsList.Count < 1)
			{
				helper.customEventsList.Add(new UnityEvent());
				result = true;
			}
			return result;
		}
	}
}
