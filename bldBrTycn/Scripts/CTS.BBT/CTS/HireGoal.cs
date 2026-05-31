using CTS.BBT.AI;

namespace CTS
{
	public class HireGoal : QuestNumericGoal
	{
		public HireGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			WorkerHirePanel.Hiring -= OnHiring;
		}

		public override void StartObserving()
		{
			WorkerHirePanel.Hiring += OnHiring;
		}

		private void OnHiring(Agent agent)
		{
			AddToGoalVariable(1);
		}
	}
}
