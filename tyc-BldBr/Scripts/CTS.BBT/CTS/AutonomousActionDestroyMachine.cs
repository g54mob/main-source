using System;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Destroy Machine")]
	public class AutonomousActionDestroyMachine : AgentAutonomousAction<AgentActionDestroyMachine>
	{
		[SerializeField]
		private int _score;

		private static readonly StringKey _actionKey = "AI_Action_DestroyMachine";

		protected override AgentActionDestroyMachine CreateActionInstance(Agent agent)
		{
			return (AgentActionDestroyMachine)agent.ActionList.InstantiateAction(_actionKey);
		}

		protected override int CalculateScore(Agent agent, AgentActionDestroyMachine action)
		{
			if (agent.Cooldowns.IsOnCooldown(BBTAgentTags.DestroyedMachine))
			{
				return -1;
			}
			if (!agent.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			if (!CTSSingleton<HunterRaid>.Instance.CanDestroyMachines)
			{
				return -1;
			}
			if (!CTSSingleton<BarFurnitures>.Instance.TryGetNearestInteractor(agent.RoomObject, out IDestructibleFurniture outFurniture, out float _, (Func<IDestructibleFurniture, bool>)AutonomousActionKillVampire.IsVisibleAndNotTargeted))
			{
				return -1;
			}
			action.FurnitureToDestroy = outFurniture.Transform.GetComponent<Furniture>();
			return _score;
		}
	}
}
