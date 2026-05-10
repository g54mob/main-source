using CTS.BBT.TechTree;
using CTS.TechTree;

namespace CTS
{
	public class ResearchPointThresholdGoal : QuestNumericGoal
	{
		public ResearchPointThresholdGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			TechTreePoints.OnGainResearchPoints -= OnGainResearchPoints;
		}

		public override void StartObserving()
		{
			TechTreePoints.OnGainResearchPoints += OnGainResearchPoints;
		}

		private void OnGainResearchPoints()
		{
			SetGoalVariable(TechTreeManager.GetCurrentPoints);
		}
	}
}
