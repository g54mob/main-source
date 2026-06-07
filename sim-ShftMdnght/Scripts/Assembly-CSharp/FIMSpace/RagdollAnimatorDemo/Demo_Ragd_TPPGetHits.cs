using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_TPPGetHits : FimpossibleComponent
	{
		public int HPPoints = 5;

		public RagdollAnimator2 Ragdoll;

		public float FallImpactPower = 9f;

		public ForceMode Force;

		public bool Sleep = true;

		public void Hitted(Demo_Ragd_Bullet.HitInfo info)
		{
			HPPoints -= Mathf.RoundToInt(info.Damage);
			RagdollAnimator2BoneIndicator component = info.rHit.collider.GetComponent<RagdollAnimator2BoneIndicator>();
			if ((bool)component && component.BodyBoneID == ERagdollBoneID.Head)
			{
				HPPoints -= Mathf.RoundToInt(info.Damage) * 4;
			}
			if (HPPoints > 0)
			{
				return;
			}
			Ragdoll.Mecanim.SetBool("Action", value: true);
			Ragdoll.User_SwitchFallState(Sleep ? RagdollHandler.EAnimatingMode.Sleep : RagdollHandler.EAnimatingMode.Falling);
			Ragdoll.Settings.User_ResetOverrideBlends();
			Ragdoll.User_DisableMecanimAfter(2.5f);
			if (component == null || component.ParentChain == null)
			{
				Ragdoll.Mecanim.CrossFadeInFixedTime("Fall", 0.12f);
			}
			else
			{
				float fixedTransitionDuration = 0.12f;
				if (component.ParentChain.ChainType == ERagdollChainType.Core)
				{
					if (component.BodyBoneID == ERagdollBoneID.Head)
					{
						Ragdoll.Mecanim.CrossFadeInFixedTime("Hit Head", fixedTransitionDuration);
					}
					else if (component.BodyBoneID == ERagdollBoneID.Hips)
					{
						Ragdoll.Mecanim.CrossFadeInFixedTime("Hit Stomach", fixedTransitionDuration);
					}
					else
					{
						Ragdoll.Mecanim.CrossFadeInFixedTime("Hit Chest", fixedTransitionDuration);
					}
				}
				else if (component.ParentChain.ChainType == ERagdollChainType.LeftLeg)
				{
					Ragdoll.Mecanim.CrossFadeInFixedTime("Hit L Leg", fixedTransitionDuration);
				}
				else if (component.ParentChain.ChainType == ERagdollChainType.RightLeg)
				{
					Ragdoll.Mecanim.CrossFadeInFixedTime("Hit R Leg", fixedTransitionDuration);
				}
				else if (component.ParentChain.ChainType == ERagdollChainType.LeftArm)
				{
					Ragdoll.Mecanim.CrossFadeInFixedTime("Hit L Arm", fixedTransitionDuration);
				}
				else if (component.ParentChain.ChainType == ERagdollChainType.RightArm)
				{
					Ragdoll.Mecanim.CrossFadeInFixedTime("Hit R Arm", fixedTransitionDuration);
				}
			}
			if ((bool)component && component.BoneSettings != null)
			{
				Ragdoll.User_AddBoneImpact(component.BoneSettings, info.flightDirection * FallImpactPower, 0.05f, Force);
			}
		}
	}
}
