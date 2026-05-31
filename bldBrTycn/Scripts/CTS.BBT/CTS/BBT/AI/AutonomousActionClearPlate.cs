using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Clear Plate")]
	public class AutonomousActionClearPlate : AgentAutonomousAction
	{
		[SerializeField]
		private int _clearPlateScore = 2000;

		public override int CalculateScore(Agent agent, AgentAction action1)
		{
			if (!agent.ObjectHolding.IsHolding(OrderPlate.HasNoCleanDrinks))
			{
				return -1;
			}
			return 2000;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new WorkerActionClearPlate();
		}
	}
}
