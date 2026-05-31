using CTS.BBT.AI;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Use Machine For Fun")]
	public class AutonomousActionUseMachineForFun : AgentAutonomousAction
	{
		[SerializeField]
		[MinMaxSlider(0f, 1f)]
		private Vector2 _startStatisticRange = new Vector2(0f, 0.5f);

		[SerializeField]
		[Range(0f, 1f)]
		private float _completionStatisticValue = 0.5f;

		[SerializeField]
		private int _score;

		public override int CalculateScore(Agent agent, AgentAction action1)
		{
			if (agent.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			if (!IsStatWithinRange(agent))
			{
				return -1;
			}
			return _score;
		}

		public bool IsStatWithinRange(Agent agent)
		{
			if (!agent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.Fun, out var statisticValue))
			{
				return false;
			}
			if (statisticValue >= _startStatisticRange.x)
			{
				return statisticValue <= _startStatisticRange.y;
			}
			return false;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new ActionHubGetFun(_completionStatisticValue);
		}
	}
}
