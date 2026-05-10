using System;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Vomit")]
	public class AutonomousActionVomit : AgentAutonomousAction
	{
		[SerializeField]
		private int _vomitScore = 500;

		private DayCheck<Agent> _dayCheck = new DayCheck<Agent>(DayCheck);

		public static event Action<Agent> AgentThrowUp;

		private static bool DayCheck(Agent agent)
		{
			if (!agent.Statistics.TryGetStatisticPercentage(EAgentStatistics.VomitThreshold, out var statisticValue))
			{
				return false;
			}
			if (!agent.Statistics.TryGetNumericStatistic(EAgentStatistics.VomitChance, out var numericStatistic))
			{
				return false;
			}
			if (!agent.Statistics.TryGetStatisticPercentage(EAgentStatistics.Alcohol, out var statisticValue2))
			{
				return false;
			}
			if (statisticValue2 < statisticValue)
			{
				return false;
			}
			float num = statisticValue2.Remap(statisticValue, 100f, 0f, 100f);
			num = Mathf.Lerp(numericStatistic.Min, numericStatistic.Max, num * 0.01f);
			AutonomousActionVomit.AgentThrowUp?.Invoke(agent);
			return UnityEngine.Random.value * 100f < num;
		}

		public override int CalculateScore(Agent agent, AgentAction action1)
		{
			if (agent.AlcoholLevel.CurrentState < AlcoholLevel.EState.Drunk)
			{
				return -1;
			}
			if (_dayCheck.Check(agent))
			{
				return _vomitScore;
			}
			return -1;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new AgentActionVomit();
		}
	}
}
