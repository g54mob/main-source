namespace CTS
{
	public class LoanGoal : QuestGoal
	{
		public LoanGoal(Quest quest, int entryID)
			: base(quest, entryID)
		{
		}

		public override void StopObserving()
		{
			FinancialLoaningManager.OnTakeOutALoan -= OnTakeOutALoan;
		}

		public override void StartObserving()
		{
			FinancialLoaningManager.OnTakeOutALoan += OnTakeOutALoan;
		}

		private void OnTakeOutALoan(int obj)
		{
			SetGoalState(success: true);
		}
	}
}
