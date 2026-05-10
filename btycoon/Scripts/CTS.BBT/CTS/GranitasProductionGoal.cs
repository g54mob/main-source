namespace CTS
{
	public class GranitasProductionGoal : QuestNumericGoal
	{
		public GranitasProductionGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			BloodyIceCrusher.GranitasGenerated -= OnGranitasGenerated;
		}

		public override void StartObserving()
		{
			BloodyIceCrusher.GranitasGenerated += OnGranitasGenerated;
		}

		private void OnGranitasGenerated(BloodyIceCrusher distiller, StockStack stackGenerated)
		{
			AddToGoalVariable(stackGenerated.StackCount);
		}
	}
}
