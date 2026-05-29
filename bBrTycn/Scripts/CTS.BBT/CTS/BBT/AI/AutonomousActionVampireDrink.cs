using System.Linq;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Vampire Drink")]
	public class AutonomousActionVampireDrink : AgentAutonomousAction
	{
		[SerializeField]
		private DrinkList _drinkData;

		[SerializeField]
		private int _suckBloodScore = 999;

		private const int HardThreshold = 74;

		private DayCheck<Agent, float> _findDrinkCheck = new DayCheck<Agent, float>(ShouldFindDrink);

		private static bool ShouldFindDrink(Agent agent, float thirstValue)
		{
			if (agent.Statistics.TryGetStatisticValue(EAgentStatistics.HungerAttackThreshold, out var statisticValue))
			{
				if (thirstValue > 74f)
				{
					return false;
				}
				return (Random.value * 100f).Remap(0f, 100f, statisticValue, 100f) > thirstValue;
			}
			return false;
		}

		public override int CalculateScore(Agent agent, AgentAction action)
		{
			if (agent.ObjectHolding.IsHolding(Drink.IsNotEmptyFilter))
			{
				return -1;
			}
			if (agent.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			if (!agent.Statistics.TryGetStatisticPercentage(EAgentStatistics.Hunger, out var statisticValue))
			{
				return -1;
			}
			if (!_findDrinkCheck.Check(agent, statisticValue))
			{
				return -1;
			}
			foreach (DrinkSO item in _drinkData.List)
			{
				if (item.CanBePrepared())
				{
					_findDrinkCheck.ResetValue();
					return _suckBloodScore;
				}
			}
			return -1;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new ActionHubAgentFindDrink(_drinkData.List.OrderBy((DrinkSO _) => Random.value).ToList());
		}
	}
}
