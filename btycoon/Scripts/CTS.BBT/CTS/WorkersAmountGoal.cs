namespace CTS
{
	public class WorkersAmountGoal : QuestNumericGoal
	{
		public WorkersAmountGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			WorkerList.WorkerListUpdated -= OnWorkerListUpdated;
		}

		public override void StartObserving()
		{
			WorkerList.WorkerListUpdated += OnWorkerListUpdated;
			OnWorkerListUpdated(WorkerList.Count);
		}

		private void OnWorkerListUpdated(int count)
		{
			SetGoalVariable(count);
		}
	}
}
