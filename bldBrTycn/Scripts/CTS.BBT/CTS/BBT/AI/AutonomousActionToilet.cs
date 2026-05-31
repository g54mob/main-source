using System;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Toilet")]
	public class AutonomousActionToilet : AgentAutonomousAction<AgentActionToilet>
	{
		[SerializeField]
		private int _score;

		public static bool IsToiletCorrect(Toilet toilet, Customer customer)
		{
			RoomBuilding currentRoom = toilet.Furniture.RoomObject.CurrentRoom;
			if (currentRoom == null)
			{
				return false;
			}
			if (!(1 << currentRoom.NavArea.Area).ExistsInMask(customer.Movement.DefaultAreaMask))
			{
				return false;
			}
			if (toilet.IsDirty)
			{
				return false;
			}
			return true;
		}

		protected override AgentActionToilet CreateActionInstance(Agent agent)
		{
			return new AgentActionToilet(null);
		}

		protected override int CalculateScore(Agent agent, AgentActionToilet toiletAction)
		{
			if (!(agent is Customer customer))
			{
				return -1;
			}
			if (customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			agent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.Bladder, out var statisticValue);
			agent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.ToiletBladderStartAction, out var statisticValue2);
			if (statisticValue > statisticValue2)
			{
				return -1;
			}
			if (CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor(agent.RoomObject, out Toilet outFurniture, out float _, (Func<Toilet, Customer, bool>)IsToiletCorrect, customer))
			{
				toiletAction.SetToilet(outFurniture);
				if (agent.TryGetComponent<SituationnalBarks_CustomerHuman>(out var component))
				{
					component.MoveToilet();
				}
				return _score;
			}
			return -1;
		}
	}
}
