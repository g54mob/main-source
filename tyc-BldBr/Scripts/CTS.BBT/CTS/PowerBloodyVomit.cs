using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Powers/AOE - Bloody Vomit")]
	public class PowerBloodyVomit : AreaOfEffectPowerData
	{
		public static readonly Resource<VFXData> HeadLoopVFX = new Resource<VFXData>("Scriptables/VFX/VFX_BloodyVomit_HeadLoop");

		public override void CastPower(List<Collider> colliders)
		{
			foreach (Collider collider in colliders)
			{
				Customer componentInParent = collider.GetComponentInParent<Customer>();
				if ((bool)componentInParent && !componentInParent.IsVampire)
				{
					if (!componentInParent.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
					{
						break;
					}
					AgentActionVomitBlood agentActionVomitBlood = new AgentActionVomitBlood();
					componentInParent.ActionPlayer.ForceAction(agentActionVomitBlood, EActionPriority.Power);
					if (!componentInParent.ActionPlayer.HasAction(agentActionVomitBlood))
					{
						break;
					}
					if (componentInParent.SkeletonData.TryGetBone(EBone.Head, out var boneTransform))
					{
						componentInParent.VFXManager.Play(HeadLoopVFX, boneTransform);
					}
				}
			}
		}
	}
}
