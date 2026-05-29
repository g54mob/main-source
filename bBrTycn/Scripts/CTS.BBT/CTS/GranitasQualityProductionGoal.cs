using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class GranitasQualityProductionGoal : QuestNumericGoal
	{
		private string _targetQuality;

		public GranitasQualityProductionGoal(Quest quest, int entryID, string variableName, string targetVariableName, string targetQuality)
			: base(quest, entryID, variableName, targetVariableName)
		{
			_targetQuality = targetQuality;
		}

		public override void StopObserving()
		{
			BloodyIceCrusher.GranitasGenerated -= OnBloodBagGenerated;
		}

		public override void StartObserving()
		{
			BloodyIceCrusher.GranitasGenerated += OnBloodBagGenerated;
		}

		private void OnBloodBagGenerated(BloodyIceCrusher distiller, StockStack bloodBag)
		{
			if (bloodBag.Quality > (float)DialogueLua.GetVariable(_targetQuality).asInt)
			{
				AddToGoalVariable(bloodBag.StackCount);
			}
		}
	}
}
