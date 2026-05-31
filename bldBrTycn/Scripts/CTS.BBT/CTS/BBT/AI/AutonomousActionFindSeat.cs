using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Find Seat")]
	public class AutonomousActionFindSeat : AgentAutonomousAction
	{
		[SerializeField]
		private int _assignSeatScore = 10;

		public override int CalculateScore(Agent agent, AgentAction action)
		{
			if (!(agent is Customer customer))
			{
				return -1;
			}
			if (customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			if (customer.AtTable)
			{
				return -1;
			}
			if ((bool)customer.AssignedSeat)
			{
				return -1;
			}
			if ((bool)customer.GroupData.AssignedTable && !customer.GroupData.AssignedTable.RoomObject.CurrentRoom.NavArea.IsInMask(customer.Movement.AreaMask))
			{
				customer.SeparateFromGroup();
			}
			return _assignSeatScore;
		}

		public override AgentAction CreateAction(Agent agent)
		{
			return new ActionHubFindSeat();
		}
	}
}
