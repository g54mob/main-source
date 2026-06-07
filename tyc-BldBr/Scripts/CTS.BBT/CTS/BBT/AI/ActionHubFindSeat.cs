using System;
using System.Linq;

namespace CTS.BBT.AI
{
	[Serializable]
	public class ActionHubFindSeat : AgentHubAction
	{
		public ActionHubFindSeat()
		{
			AddScoredAction(new AgentActionAssignTable(), CalculateAssignTable);
			AddScoredAction(new AgentActionAssignSeat(), CalculateAssignSeat);
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			if (!(agent is Customer customer))
			{
				return true;
			}
			if ((bool)customer.AssignedSeat)
			{
				return customer.GroupData.AssignedTable;
			}
			return false;
		}

		private int CalculateAssignTable(Agent agent)
		{
			if (!(agent is Customer customer))
			{
				return -1;
			}
			if (!customer.GroupData.AssignedTable)
			{
				return 150;
			}
			return -1;
		}

		private int CalculateAssignSeat(Agent agent)
		{
			if (!(agent is Customer customer))
			{
				return -1;
			}
			if (!customer.GroupData.AssignedTable)
			{
				return -1;
			}
			if (!customer.AssignedSeat)
			{
				return 140;
			}
			return -1;
		}

		public override void OnCancel()
		{
			base.OnCancel();
			if (base.ActionAgent is Customer customer)
			{
				customer.ReleaseSeat();
				if (!(customer.GroupData.AssignedTable == null) && customer.GroupData.Members.Any((Customer test) => test.AtTable))
				{
					base.ActionAgent.Tags.AddTag(EAgentTag.Angry);
				}
			}
		}
	}
}
