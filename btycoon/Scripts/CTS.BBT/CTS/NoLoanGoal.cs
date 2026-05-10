using CTS.Core;

namespace CTS
{
	public class NoLoanGoal : QuestGoal
	{
		public NoLoanGoal(Quest quest, int entryID)
			: base(quest, entryID)
		{
		}

		public override void StopObserving()
		{
			FinancialLoaningManager.OnTakeOutALoan -= OnTakeOutALoan;
			FinancialLoaningManager.OnLoanReimbursed -= CheckLoans;
		}

		public override void StartObserving()
		{
			FinancialLoaningManager.OnTakeOutALoan += OnTakeOutALoan;
			FinancialLoaningManager.OnLoanReimbursed += CheckLoans;
			CheckLoans();
		}

		private void OnTakeOutALoan(int amount)
		{
			CheckLoans();
		}

		private void CheckLoans()
		{
			SetGoalState(MonoSingleton<FinancialLoaningManager>.Instance.ActiveContracts.Count == 0);
		}
	}
}
