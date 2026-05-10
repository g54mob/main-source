using CTS.Core;

namespace CTS
{
	public class CreateNewRoomGoal : QuestGoal
	{
		private int _startingRoomAmount;

		public CreateNewRoomGoal(Quest quest, int entryID)
			: base(quest, entryID)
		{
			_startingRoomAmount = MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentContainer.GeneratedRooms.Count;
		}

		public override void StopObserving()
		{
			ConstructionSystem.OnConstructionGenerated -= OnConstructionGenerated;
		}

		public override void StartObserving()
		{
			ConstructionSystem.OnConstructionGenerated += OnConstructionGenerated;
		}

		private void OnConstructionGenerated(int roomID, int cellsAmount, int roomCellAmount)
		{
			if (cellsAmount != 0 && roomCellAmount > 0 && _startingRoomAmount < MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentContainer.GeneratedRooms.Count)
			{
				ConstructionSystem.OnConstructionGenerated -= OnConstructionGenerated;
				SetGoalState(success: true);
			}
		}
	}
}
