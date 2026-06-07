using CTS.BBT;
using CTS.BBT.AI;
using CTS.TechTree;

namespace CTS
{
	public class TurnoverGoal : QuestNumericGoal
	{
		public TurnoverGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			CustomerOrder.DrinkPayed -= OnCustomerPayedDrink;
			TechTreePointsConverter.ResearchPointSellMoneyGenerated -= AddToTurnover;
			SellBasket.StockSold -= AddToTurnover;
		}

		public override void StartObserving()
		{
			CustomerOrder.DrinkPayed += OnCustomerPayedDrink;
			TechTreePointsConverter.ResearchPointSellMoneyGenerated += AddToTurnover;
			SellBasket.StockSold += AddToTurnover;
		}

		private void OnCustomerPayedDrink(DrinkSO sO, int price)
		{
			AddToTurnover(price);
		}

		private void AddToTurnover(int price)
		{
			AddToGoalVariable(price);
		}
	}
}
