namespace CTS
{
	public class EarlGreyProductionGoal : QuestNumericGoal
	{
		public EarlGreyProductionGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			BloodyTeaBag.BloodBagGenerated -= OnBloodBagGenerated;
		}

		public override void StartObserving()
		{
			BloodyTeaBag.BloodBagGenerated += OnBloodBagGenerated;
		}

		private void OnBloodBagGenerated(BloodyTeaBag distiller, StockStack stackGenerated)
		{
			AddToGoalVariable(stackGenerated.StackCount);
		}
	}
}
