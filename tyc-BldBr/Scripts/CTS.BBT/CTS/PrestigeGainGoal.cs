namespace CTS
{
	public class PrestigeGainGoal : QuestNumericGoal
	{
		public PrestigeGainGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			Prestige.PrestigeGained -= OnPrestigeChanged;
		}

		public override void StartObserving()
		{
			Prestige.PrestigeGained += OnPrestigeChanged;
		}

		private void OnPrestigeChanged(float prestigeGained)
		{
			AddToGoalVariable(prestigeGained);
		}
	}
}
