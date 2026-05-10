using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Sit Down")]
	public class AutonomousActionSitDown : AgentAutonomousAction<AgentActionSitDown>
	{
		[SerializeField]
		private int _notSeatedScore = 50;

		protected override AgentActionSitDown CreateActionInstance(Agent agent)
		{
			if (!(agent is Customer customer))
			{
				return null;
			}
			return new AgentActionSitDown(customer.AssignedSeat);
		}

		protected override int CalculateScore(Agent agent, AgentActionSitDown sitAction)
		{
			if (!(agent is Customer customer))
			{
				return -1;
			}
			if (customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			if ((object)customer.AssignedSeat != null && !customer.AssignedSeat.RoomObject.CurrentRoom.NavArea.IsInMask(customer.Movement.AreaMask))
			{
				customer.ReleaseSeat();
			}
			if (customer.AssignedSeat == null)
			{
				return -1;
			}
			if (customer.AtTable)
			{
				return -1;
			}
			sitAction.Seat = customer.AssignedSeat;
			return _notSeatedScore;
		}
	}
}
