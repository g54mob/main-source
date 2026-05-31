using System;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Get Drink From Machine")]
	public class AutonomousActionGetDrinkFromMachine : AgentAutonomousAction
	{
		[SerializeField]
		private int _score;

		[SerializeField]
		private float _delayFromOrder = 30f;

		private BloodyExpresso _bloodyExpresso;

		public override int CalculateScore(Agent agent, AgentAction action)
		{
			agent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.Thirst, out var statisticValue);
			if (statisticValue >= 0.3f)
			{
				return -1;
			}
			if (agent is Customer customer && (bool)customer.AssignedSeat && customer.CurrentOrder != null && Time.time - customer.CurrentOrder.LastStageTime < _delayFromOrder)
			{
				return -1;
			}
			if (CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor(agent.RoomObject, out _bloodyExpresso, out float _, (Func<BloodyExpresso, bool>)MachineBase.IsOn))
			{
				if (agent.IsHuman)
				{
					return _score;
				}
				if (_bloodyExpresso.HasAVictim)
				{
					return _score;
				}
			}
			_bloodyExpresso = null;
			return -1;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new AgentActionUseMachine(_bloodyExpresso);
		}
	}
}
