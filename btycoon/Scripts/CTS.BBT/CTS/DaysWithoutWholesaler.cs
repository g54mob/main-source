using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class DaysWithoutWholesaler : QuestNumericGoal
	{
		public DaysWithoutWholesaler(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			CalendarHandlers.NewDay -= OnNewDay;
			BuyBasket.BasketBought -= OnBasketBought;
		}

		public override void StartObserving()
		{
			CalendarHandlers.NewDay += OnNewDay;
			BuyBasket.BasketBought += OnBasketBought;
		}

		private void OnBasketBought(ShopBasket.BasketValidation obj)
		{
			if (QuestLog.GetQuestEntryState(base.QuestName, base.EntryID) == QuestState.Active)
			{
				SetGoalVariable(0);
			}
		}

		private void OnNewDay()
		{
			AddToGoalVariable(1);
		}
	}
}
