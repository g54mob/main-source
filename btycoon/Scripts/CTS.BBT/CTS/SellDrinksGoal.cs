using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	public class SellDrinksGoal : QuestNumericGoal
	{
		public SellDrinksGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			CustomerOrder.DrinkPayed -= OnCustomerPayedDrink;
		}

		public override void StartObserving()
		{
			CustomerOrder.DrinkPayed += OnCustomerPayedDrink;
		}

		private void OnCustomerPayedDrink(DrinkSO drink, int price)
		{
			AddToGoalVariable(price);
		}
	}
}
