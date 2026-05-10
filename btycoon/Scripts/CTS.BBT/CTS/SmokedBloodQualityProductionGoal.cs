using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class SmokedBloodQualityProductionGoal : QuestNumericGoal
	{
		private string _targetQuality;

		public SmokedBloodQualityProductionGoal(Quest quest, int entryID, string variableName, string targetVariableName, string targetQuality)
			: base(quest, entryID, variableName, targetVariableName)
		{
			_targetQuality = targetQuality;
		}

		public override void StopObserving()
		{
			BloodySmoker.BloodBagGenerated -= OnBloodBagGenerated;
		}

		public override void StartObserving()
		{
			BloodySmoker.BloodBagGenerated += OnBloodBagGenerated;
		}

		private void OnBloodBagGenerated(BloodySmoker distiller, StockStack bloodBag)
		{
			if (bloodBag.Quality > (float)DialogueLua.GetVariable(_targetQuality).asInt)
			{
				AddToGoalVariable(bloodBag.StackCount);
			}
		}
	}
}
