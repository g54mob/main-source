namespace CTS
{
	public class BlueBloodBagProductionGoal : QuestNumericGoal
	{
		public BlueBloodBagProductionGoal(Quest quest, int entryID, string variableName, string targetVariableName)
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

		private void OnBloodBagGenerated(BloodDistiller distiller, StockStack bloodBag)
		{
			if (bloodBag.Quality > 5f)
			{
				AddToGoalVariable(bloodBag.StackCount);
			}
		}
	}
}
