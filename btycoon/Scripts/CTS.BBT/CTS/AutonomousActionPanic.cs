using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Panic")]
	public class AutonomousActionPanic : AgentAutonomousAction
	{
		[SerializeField]
		private int _score;

		[SerializeField]
		private float _randomMoveSearchRadius = 10f;

		public override int CalculateScore(Agent agent, AgentAction action1)
		{
			if (!agent.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			return _score;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new ActionHubPanic(_randomMoveSearchRadius, agent.ContextualFSM.PanicMoveMask);
		}
	}
}
