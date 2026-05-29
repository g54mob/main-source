using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Enter Bar")]
	public class AutonomousActionEnterBar : AgentAutonomousAction<AgentActionEnterBar>
	{
		[SerializeField]
		private int _enterBarScore = 1000;

		[SerializeField]
		private bool _forceEnter;

		protected override AgentActionEnterBar CreateActionInstance(Agent agent)
		{
			return new AgentActionEnterBar(_forceEnter);
		}

		protected override int CalculateScore(Agent agent, AgentActionEnterBar action)
		{
			if (agent.Tags.HasTag(EAgentTag.IsInside))
			{
				return -1;
			}
			return _enterBarScore;
		}
	}
}
