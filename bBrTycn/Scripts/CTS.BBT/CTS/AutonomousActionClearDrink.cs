using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Clear Drink")]
	public class AutonomousActionClearDrink : AgentAutonomousAction
	{
		[SerializeField]
		private int _drinkInHandScore = 500;

		public override int CalculateScore(Agent agent, AgentAction action1)
		{
			if (agent.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			if (agent.ObjectHolding.IsHolding(Drink.IsEmptyFilter))
			{
				return _drinkInHandScore;
			}
			return -1;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new AgentActionClearDrink();
		}
	}
}
