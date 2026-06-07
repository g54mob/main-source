using CTS.Core;

namespace CTS
{
	public class AddRoomAccessGoal : QuestGoal
	{
		public AddRoomAccessGoal(Quest quest, int entryID)
			: base(quest, entryID)
		{
		}

		public override void StopObserving()
		{
			BuildablePlacementSystem.OnBuildablePlaced -= OnBuildablePlaced;
		}

		public override void StartObserving()
		{
			BuildablePlacementSystem.OnBuildablePlaced += OnBuildablePlaced;
		}

		private void OnBuildablePlaced(BuildableElement element)
		{
			if ((element.BuildableType == BuildableElementSO.EBuildableType.Door || element.BuildableType == BuildableElementSO.EBuildableType.Arch) && MonoSingleton<BuildingRoomsContainerManager>.Instance.AllRoomHaveExteriorAccess == EAccess.Accessible)
			{
				BuildablePlacementSystem.OnBuildablePlaced -= OnBuildablePlaced;
				SetGoalState(success: true);
			}
		}
	}
}
