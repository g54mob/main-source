using System;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Hunger Attack")]
	public class AutonomousActionHungerAttack : AgentAutonomousAction<AgentActionSuckBlood>
	{
		[SerializeField]
		private int _attackScore;

		private DayCheck<Agent> _scoreCheck = new DayCheck<Agent>(ShouldAttack);

		private static readonly Func<Customer, Agent, ReadOnlyHashSet<Customer>, float, bool> _isHumanCorrect = AgentActionSuckBlood.IsHumanCorrect;

		private static bool ShouldAttack(Agent agent)
		{
			if (agent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.Hunger, out var statisticValue) && agent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.HungerAttackThreshold, out var statisticValue2) && agent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.HungerAttackBaseChance, out var statisticValue3))
			{
				if (statisticValue > statisticValue2)
				{
					return false;
				}
				float num = statisticValue.Remap(0f, statisticValue2, 100f, statisticValue3);
				return UnityEngine.Random.value < num;
			}
			return false;
		}

		protected override AgentActionSuckBlood CreateActionInstance(Agent agent)
		{
			return new AgentActionSuckBlood(null);
		}

		protected override int CalculateScore(Agent agent, AgentActionSuckBlood suckAction)
		{
			if (!_scoreCheck.Check(agent))
			{
				return -1;
			}
			if (agent.ObjectHolding.IsHolding(Drink.IsNotEmptyFilter))
			{
				return -1;
			}
			if (agent is Customer { CurrentOrder: { Status: CustomerOrder.EStatus.Delivered } })
			{
				return -1;
			}
			if (!agent.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return -1;
			}
			ReadOnlyHashSet<Customer> allAvailableHumans = CustomerManager.GetAllAvailableHumans();
			ReadOnlyHashSet<Customer> collection = Collections<Customer>.Filter(allAvailableHumans, _isHumanCorrect, agent, allAvailableHumans, 2f);
			if (BBTCollections<Customer>.TryGetNearest(agent.RoomObject, collection, out var outBest, out var _))
			{
				suckAction.Human = outBest;
				_scoreCheck.ResetValue();
				return _attackScore;
			}
			return -1;
		}
	}
}
