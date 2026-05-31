namespace CTS
{
	public class UIOpenConstructionGoal : QuestGoal
	{
		public UIOpenConstructionGoal(Quest quest, int entryID)
			: base(quest, entryID)
		{
		}

		public override void StopObserving()
		{
			UI_ConstructionSystem.OnInteriorMode -= OnInteriorMode;
		}

		public override void StartObserving()
		{
			UI_ConstructionSystem.OnInteriorMode += OnInteriorMode;
		}

		private void OnInteriorMode()
		{
			UI_ConstructionSystem.OnInteriorMode -= OnInteriorMode;
			SetGoalState(success: true);
		}
	}
}
