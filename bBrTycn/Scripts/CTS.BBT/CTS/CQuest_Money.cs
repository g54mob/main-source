using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class CQuest_Money : CircumstantialQuest
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		[QuestEntryPopup]
		private int _bankEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _loanEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		public override void StopObservingStartConditions()
		{
			MoneyHandler.MoneyAmountChanged -= OnMoneyAmountChanged;
		}

		public override void StartObservingStartConditions()
		{
			MoneyHandler.MoneyAmountChanged += OnMoneyAmountChanged;
		}

		private void OnMoneyAmountChanged(int currentMoney)
		{
			if (currentMoney <= 0)
			{
				MoneyHandler.MoneyAmountChanged -= OnMoneyAmountChanged;
				StartQuest();
			}
		}

		protected override void StopObservingObjectives()
		{
			FinancialUI.FinancialUIOpened -= OnFinancialUIOpened;
			FinancialLoaningManager.OnTakeOutALoan -= OnTakeOutALoan;
		}

		protected override void StartObservingObjectives()
		{
			FinancialUI.FinancialUIOpened += OnFinancialUIOpened;
			FinancialLoaningManager.OnTakeOutALoan += OnTakeOutALoan;
			DialogueHelper.StartConversation(_feedback01);
		}

		private void OnFinancialUIOpened()
		{
			FinancialUI.FinancialUIOpened -= OnFinancialUIOpened;
			QuestEntrySuccess(_bankEntry);
			DialogueHelper.StartConversation(_feedback02);
		}

		private void OnTakeOutALoan(int amount)
		{
			FinancialLoaningManager.OnTakeOutALoan -= OnTakeOutALoan;
			QuestEntrySuccess(_loanEntry);
		}
	}
}
