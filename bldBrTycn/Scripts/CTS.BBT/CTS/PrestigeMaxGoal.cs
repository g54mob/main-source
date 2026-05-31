namespace CTS
{
	public class PrestigeMaxGoal : QuestNumericGoal
	{
		public PrestigeMaxGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			Prestige.PrestigeChanged -= OnPrestigeChanged;
		}

		public override void StartObserving()
		{
			Prestige.PrestigeChanged += OnPrestigeChanged;
		}

		private void OnPrestigeChanged(PrestigeLevelData data, float prestige)
		{
			base.TargetValue = Prestige.MaxPrestigeRequired;
			SetGoalVariable(prestige);
		}
	}
}
