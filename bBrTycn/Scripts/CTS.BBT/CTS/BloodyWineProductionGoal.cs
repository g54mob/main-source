namespace CTS
{
	public class BloodyWineProductionGoal : QuestNumericGoal
	{
		public BloodyWineProductionGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			BloodyWineBarrel.BloodBagGenerated -= OnBloodBagGenerated;
		}

		public override void StartObserving()
		{
			BloodyWineBarrel.BloodBagGenerated += OnBloodBagGenerated;
		}

		private void OnBloodBagGenerated(BloodyWineBarrel distiller, StockStack stackGenerated)
		{
			AddToGoalVariable(stackGenerated.StackCount);
		}
	}
}
