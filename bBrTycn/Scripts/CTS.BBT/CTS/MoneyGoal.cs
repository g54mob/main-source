namespace CTS
{
	public class MoneyGoal : QuestNumericGoal
	{
		public MoneyGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			MoneyHandler.MoneyAmountChanged -= OnMoneyAmountChanged;
		}

		public override void StartObserving()
		{
			MoneyHandler.MoneyAmountChanged += OnMoneyAmountChanged;
		}

		private void OnMoneyAmountChanged(int newAmount)
		{
			SetGoalVariable(newAmount);
		}
	}
}
