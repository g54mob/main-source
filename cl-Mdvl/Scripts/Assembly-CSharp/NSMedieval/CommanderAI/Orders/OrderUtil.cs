using NSMedieval.Controllers;
using NSMedieval.State;

namespace NSMedieval.CommanderAI.Orders
{
	public static class OrderUtil
	{
		public static bool ShouldAbortGoapAgent(HumanoidInstance agent, OrderBase currentOrder, OrderBase nextOrder)
		{
			if (nextOrder == null || currentOrder == null)
			{
				return true;
			}
			if (LoadingController.IsSceneTransition || agent.GetGoapAgent()?.CurrentGoalName == "EnemySelfDefenseGoal")
			{
				return false;
			}
			if (currentOrder is AttackOrder && nextOrder is AttackOrder)
			{
				return false;
			}
			return true;
		}
	}
}
