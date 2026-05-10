using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest14 : Level02Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _bankEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _loanEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		protected override void StopObservingObjectives()
		{
			FinancialUI.FinancialUIOpened -= OnFinancialUIOpened;
			FinancialLoaningManager.OnTakeOutALoan -= OnTakeOutALoan;
		}

		protected override void StartObservingObjectives()
		{
			FinancialUI.FinancialUIOpened += OnFinancialUIOpened;
			HighlightButton.Highlight(BBTUI.Instance.ButtonID_Finances);
			HighlightButton.Highlight(BBTUI.Instance.ButtonID_Finances_LoanTab);
			FinancialLoaningManager.OnTakeOutALoan += OnTakeOutALoan;
		}

		private void OnFinancialUIOpened()
		{
			FinancialUI.FinancialUIOpened -= OnFinancialUIOpened;
			QuestEntrySuccess(_bankEntry);
		}

		private void OnTakeOutALoan(int amount)
		{
			FinancialLoaningManager.OnTakeOutALoan -= OnTakeOutALoan;
			QuestEntrySuccess(_loanEntry);
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			EventsManager.ChangeMoney?.Invoke(Currencies.Dollars, 15000);
		}
	}
}
