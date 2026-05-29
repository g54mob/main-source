using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class BloodBagQualityProductionGoal : QuestNumericGoal
	{
		private string _targetQuality;

		public BloodBagQualityProductionGoal(Quest quest, int entryID, string variableName, string targetVariableName, string targetQuality)
			: base(quest, entryID, variableName, targetVariableName)
		{
			_targetQuality = targetQuality;
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
			if (bloodBag.Quality > (float)DialogueLua.GetVariable(_targetQuality).asInt)
			{
				AddToGoalVariable(bloodBag.StackCount);
			}
		}
	}
}
