using CTS.BBT.AI;

namespace CTS
{
	public class LockInCellGoal : BaseSpecificRoomTypeNumericalGoal
	{
		public LockInCellGoal(Quest quest, int entryID, string variableName, string targetVariableName, params NavigationArea[] navigationAreas)
			: base(quest, entryID, variableName, targetVariableName, navigationAreas)
		{
		}

		public override void StopObserving()
		{
			Cell.AgentCaptured -= OnAgentCaptured;
		}

		public override void StartObserving()
		{
			Cell.AgentCaptured += OnAgentCaptured;
		}

		private void OnAgentCaptured(Cell cell, Agent agent)
		{
			if (base.RoomTypes.Contains(cell.Furniture.RoomObject.CurrentRoom.NavArea))
			{
				AddToGoalVariable(1);
			}
		}
	}
}
