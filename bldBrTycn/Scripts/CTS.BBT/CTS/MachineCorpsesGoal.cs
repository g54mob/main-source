namespace CTS
{
	public class MachineCorpsesGoal : QuestNumericGoal
	{
		public MachineCorpsesGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			MachineBase.CorpseDisposed -= OnCorpseDisposed;
		}

		public override void StartObserving()
		{
			MachineBase.CorpseDisposed += OnCorpseDisposed;
		}

		private void OnCorpseDisposed(MachineBase machine)
		{
			AddToGoalVariable(1);
		}
	}
}
