namespace CTS
{
	public class PanicGoal : QuestNumericGoal
	{
		public PanicGoal(Quest quest, int entryID, string variableName, string targetVariableName, ENumericGoalType goalType = ENumericGoalType.HigherOrEqual)
			: base(quest, entryID, variableName, targetVariableName, goalType)
		{
		}

		public override void StopObserving()
		{
			PanicCounter.PanicActive -= OnPanicActive;
		}

		public override void StartObserving()
		{
			PanicCounter.PanicActive += OnPanicActive;
		}

		private void OnPanicActive(bool active)
		{
			if (active)
			{
				AddToGoalVariable(1);
			}
		}
	}
}
