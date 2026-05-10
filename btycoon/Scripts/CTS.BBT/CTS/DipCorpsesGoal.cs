namespace CTS
{
	public class DipCorpsesGoal : QuestNumericGoal
	{
		public DipCorpsesGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			TheDip.Dissolved -= OnDissolved;
		}

		public override void StartObserving()
		{
			TheDip.Dissolved += OnDissolved;
		}

		private void OnDissolved()
		{
			AddToGoalVariable(1);
		}
	}
}
