using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class SlipTrigger : CTSBehaviour
	{
		private void OnTriggerStay(Collider other)
		{
			Agent componentInParent = other.GetComponentInParent<Agent>();
			if ((object)componentInParent == null || (object)componentInParent.FurnitureAssignment.CurrentSeat != null || componentInParent.Cooldowns.IsOnCooldown(BBTAgentTags.CD_SlipOnPuddle) || componentInParent.ActionPlayer.HasAnyActionOfType<AgentActionSlipOnPuddle>() || componentInParent.Movement.Velocity.sqrMagnitude < 0.0001f || componentInParent.ObjectHolding.IsHolding<BodyBag>())
			{
				return;
			}
			float num = 0.6f;
			if (componentInParent.Statistics.TryGetNumericStatistic(EAgentStatistics.SlipChance, out var numericStatistic))
			{
				num = numericStatistic.InitializationRange.RandomInRange();
			}
			if (Random.value < num)
			{
				componentInParent.Cooldowns.StartCooldown(BBTAgentTags.CD_SlipOnPuddle, 10f);
				if (componentInParent.ActionPlayer.ActionQueue.Count > 0)
				{
					if (componentInParent.ActionPlayer.CurrentAction == null)
					{
						componentInParent.ActionPlayer.InsertAction(new AgentActionSlipOnPuddle(), AgentActionPlayer.EInsertType.Silent, EActionPriority.Autonomous);
						return;
					}
					AgentActionSlipOnPuddle action = new AgentActionSlipOnPuddle
					{
						ResumeAction = componentInParent.ActionPlayer.CurrentAction
					};
					componentInParent.ActionPlayer.InsertAction(action, AgentActionPlayer.EInsertType.SoftCancel, EActionPriority.Autonomous);
				}
				else
				{
					componentInParent.ActionPlayer.ForceStopAll();
					componentInParent.ActionPlayer.ForceAction(new AgentActionSlipOnPuddle(), EActionPriority.Autonomous);
				}
			}
			else
			{
				componentInParent.Cooldowns.StartCooldown(BBTAgentTags.CD_SlipOnPuddle, 4f);
			}
		}
	}
}
