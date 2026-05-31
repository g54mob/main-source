using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Call Waiter")]
	public class AutonomousActionCallWaiter : AgentAutonomousAction
	{
		[SerializeField]
		private int _canGetDrinkScore = 5;

		public override int CalculateScore(Agent agent, AgentAction action1)
		{
			if (!(agent is Customer customer))
			{
				return -1;
			}
			if (customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			if (!customer.AtTable)
			{
				return -1;
			}
			if (customer.CurrentOrder != null)
			{
				return -1;
			}
			if (!customer.GroupData.TryGetWaitingOrder(out var _) && customer.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.Thirst, out var statisticValue) && statisticValue > 0.9f)
			{
				return -1;
			}
			if (customer.CanGetDrink())
			{
				return _canGetDrinkScore;
			}
			return -1;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new CustomerActionCallWaiter();
		}
	}
}
