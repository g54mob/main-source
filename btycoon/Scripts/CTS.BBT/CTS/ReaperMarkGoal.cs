using CTS.BBT.AI;

namespace CTS
{
	public class ReaperMarkGoal : QuestNumericGoal
	{
		public ReaperMarkGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			ReaperTargetingManager.HostileMarked -= OnHostileMarked;
		}

		public override void StartObserving()
		{
			ReaperTargetingManager.HostileMarked += OnHostileMarked;
		}

		private void OnHostileMarked(Customer customer)
		{
			AddToGoalVariable(1);
		}
	}
}
