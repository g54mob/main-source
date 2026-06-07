using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Pee Accident")]
	public class AutonomousActionPeeAccident : AgentAutonomousAction
	{
		[SerializeField]
		private int _peeDanceScore = 1750;

		[SerializeField]
		private int _peeAccidentScore = 50000;

		public override int CalculateScore(Agent agent, AgentAction action1)
		{
			if (agent is Customer { ControllingVampire: not null })
			{
				return -1;
			}
			if (!agent.Statistics.TryGetStatisticPercentage(EAgentStatistics.Bladder, out var statisticValue))
			{
				return -1;
			}
			if (!agent.Statistics.TryGetStatisticPercentage(EAgentStatistics.ToiletBladderPeeDanceThreshold, out var statisticValue2))
			{
				statisticValue2 = 0f;
			}
			if (statisticValue > statisticValue2)
			{
				return -1;
			}
			if (statisticValue <= 0f)
			{
				return _peeAccidentScore;
			}
			return _peeDanceScore;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new AgentActionPeeAccident();
		}
	}
}
