namespace CTS
{
	public class SmokedBloodProductionGoal : QuestNumericGoal
	{
		public SmokedBloodProductionGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			BloodySmoker.BloodBagGenerated -= OnBloodBagGenerated;
		}

		public override void StartObserving()
		{
			BloodySmoker.BloodBagGenerated += OnBloodBagGenerated;
		}

		private void OnBloodBagGenerated(BloodySmoker distiller, StockStack stackGenerated)
		{
			AddToGoalVariable(stackGenerated.StackCount);
		}
	}
}
