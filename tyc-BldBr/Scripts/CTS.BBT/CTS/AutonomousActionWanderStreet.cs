using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Wander Street")]
	public class AutonomousActionWanderStreet : AgentAutonomousAction
	{
		[SerializeField]
		private int _wanderStreetScore = 1000;

		public override int CalculateScore(Agent agent, AgentAction action1)
		{
			return _wanderStreetScore;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new AgentActionWanderStreet();
		}
	}
}
