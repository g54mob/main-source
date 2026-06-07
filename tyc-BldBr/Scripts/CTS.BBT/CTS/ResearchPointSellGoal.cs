using CTS.TechTree;

namespace CTS
{
	public class ResearchPointSellGoal : QuestNumericGoal
	{
		public ResearchPointSellGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			TechTreePointsConverter.ResearchPointSold -= OnResearchPointSold;
		}

		public override void StartObserving()
		{
			TechTreePointsConverter.ResearchPointSold += OnResearchPointSold;
		}

		private void OnResearchPointSold(int amount)
		{
			AddToGoalVariable(amount);
		}
	}
}
