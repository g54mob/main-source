namespace CTS
{
	public class BloodBagProductionGoal : QuestNumericGoal
	{
		public BloodBagProductionGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			BloodDistiller.BloodBagGenerated -= OnBloodBagGenerated;
		}

		public override void StartObserving()
		{
			BloodDistiller.BloodBagGenerated += OnBloodBagGenerated;
		}

		private void OnBloodBagGenerated(BloodDistiller distiller, StockStack stackGenerated)
		{
			AddToGoalVariable(stackGenerated.StackCount);
		}
	}
}
