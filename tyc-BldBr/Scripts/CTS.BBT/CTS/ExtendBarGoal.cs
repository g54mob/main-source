using CTS.Core;

namespace CTS
{
	public class ExtendBarGoal : QuestGoal
	{
		private int _startingCells;

		public ExtendBarGoal(Quest quest, int entryID)
			: base(quest, entryID)
		{
		}

		public override void StopObserving()
		{
			EntranceResolver.EntrancesChecked -= OnEntrancesChecked;
		}

		public override void StartObserving()
		{
			if ((bool)MonoSingleton<BuildingRoomsContainerManager>.Instance)
			{
				_startingCells = MonoSingleton<BuildingRoomsContainerManager>.Instance.TotalCellsInBar;
			}
			EntranceResolver.EntrancesChecked += OnEntrancesChecked;
		}

		private void OnBuildablePlaced(BuildableElement element)
		{
			OnEntrancesChecked();
		}

		private void OnConstructionGenerated(int arg1, int arg2, int arg3)
		{
			OnEntrancesChecked();
		}

		private void OnEntrancesChecked()
		{
			if (MonoSingleton<BuildingRoomsContainerManager>.Instance.AllRoomHaveExteriorAccess == EAccess.Accessible && MonoSingleton<BuildingRoomsContainerManager>.Instance.TotalCellsInBar > _startingCells)
			{
				SetGoalState(success: true);
			}
		}
	}
}
