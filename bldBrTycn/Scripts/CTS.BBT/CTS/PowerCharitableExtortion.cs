using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Powers/AOE - Charitable Extortion")]
	public class PowerCharitableExtortion : AreaOfEffectPowerData
	{
		public static readonly Resource<VFXData> HeadLoopVFX = new Resource<VFXData>("Scriptables/VFX/VFX_CharitableExtortion_HeadLoop");

		public override void CastPower(List<Collider> colliders)
		{
			foreach (Collider collider in colliders)
			{
				Customer componentInParent = collider.GetComponentInParent<Customer>();
				if ((bool)componentInParent && !componentInParent.IsVampire && componentInParent.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
				{
					AgentActionCharitableExtortion agentActionCharitableExtortion = new AgentActionCharitableExtortion();
					componentInParent.ActionPlayer.ForceAction(agentActionCharitableExtortion, EActionPriority.Power);
					if (componentInParent.ActionPlayer.HasAction(agentActionCharitableExtortion) && componentInParent.SkeletonData.TryGetBone(EBone.Head, out var boneTransform))
					{
						componentInParent.VFXManager.Play(HeadLoopVFX, boneTransform);
					}
				}
			}
		}
	}
}
