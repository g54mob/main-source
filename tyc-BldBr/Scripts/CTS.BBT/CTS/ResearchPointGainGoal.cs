using CTS.TechTree;

namespace CTS
{
	public class ResearchPointGainGoal : QuestNumericGoal
	{
		public ResearchPointGainGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			TechTreePoints.ResearchPointsGained -= OnResearchPointSold;
		}

		public override void StartObserving()
		{
			TechTreePoints.ResearchPointsGained += OnResearchPointSold;
		}

		private void OnResearchPointSold(int amount)
		{
			AddToGoalVariable(amount);
		}
	}
}
