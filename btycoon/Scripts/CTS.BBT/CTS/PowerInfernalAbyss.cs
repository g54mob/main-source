using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Powers/AOE - Infernal Abyss")]
	public class PowerInfernalAbyss : AreaOfEffectPowerData
	{
		[SerializeField]
		private int _vigilanceToAdd;

		public static event Action KillAnotherNPC;

		public static event Action KillSomeone;

		public override void CastPower(List<Collider> colliders)
		{
			foreach (Collider collider in colliders)
			{
				Agent componentInParent = collider.GetComponentInParent<Agent>();
				if ((bool)componentInParent && !componentInParent.IsDead && !componentInParent.ContextualFSM.CurrentStateEquals<ContextualStateStuck>())
				{
					if (!componentInParent.IsHuman)
					{
						PowerInfernalAbyss.KillAnotherNPC?.Invoke();
					}
					PowerInfernalAbyss.KillSomeone?.Invoke();
					AgentActionGetDeleted newAction = new AgentActionGetDeleted(_vigilanceToAdd);
					componentInParent.ActionPlayer.ForceStopAll();
					componentInParent.ActionPlayer.ForceAction(newAction, EActionPriority.Power);
				}
			}
		}
	}
}
