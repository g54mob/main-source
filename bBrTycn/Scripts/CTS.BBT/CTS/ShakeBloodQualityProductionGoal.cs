using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class ShakeBloodQualityProductionGoal : QuestNumericGoal
	{
		private string _targetQuality;

		public ShakeBloodQualityProductionGoal(Quest quest, int entryID, string variableName, string targetVariableName, string targetQuality)
			: base(quest, entryID, variableName, targetVariableName)
		{
			_targetQuality = targetQuality;
		}

		public override void StopObserving()
		{
			BloodyShaker.BloodBagGenerated -= OnBloodBagGenerated;
		}

		public override void StartObserving()
		{
			BloodyShaker.BloodBagGenerated += OnBloodBagGenerated;
		}

		private void OnBloodBagGenerated(BloodyShaker distiller, StockStack bloodBag)
		{
			if (bloodBag.Quality > (float)DialogueLua.GetVariable(_targetQuality).asInt)
			{
				AddToGoalVariable(bloodBag.StackCount);
			}
		}
	}
}
