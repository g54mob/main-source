using CTS.Core;

namespace CTS.BBT.AI
{
	internal class AgentActionAssignSeat : SimpleAgentAction
	{
		public override bool CanBePerformed(Agent agentRef)
		{
			if (!CTSSingleton<LevelParameters>.Instance)
			{
				return false;
			}
			if (!(agentRef is Customer customer))
			{
				return false;
			}
			if (!customer.GroupData.AssignedTable)
			{
				return false;
			}
			if (!customer.GroupData.AssignedTable.HasAvailableSeat(customer))
			{
				return false;
			}
			return !customer.AssignedSeat;
		}

		protected override void Execute()
		{
			if (base.ActionAgent is Customer customer)
			{
				if (customer.GroupData.AssignedTable.TryGetASeat(customer, out var p_seat))
				{
					customer.AssignSeat(p_seat);
				}
				else
				{
					CancelAction("No seat available");
				}
			}
		}
	}
}
