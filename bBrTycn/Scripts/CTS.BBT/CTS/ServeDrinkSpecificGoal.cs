using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	public class ServeDrinkSpecificGoal : QuestNumericGoal
	{
		private readonly DrinkSO _drink;

		public ServeDrinkSpecificGoal(Quest quest, int entryID, string variableName, string targetVariableName, DrinkSO drink)
			: base(quest, entryID, variableName, targetVariableName)
		{
			_drink = drink;
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
			if (!(drink != _drink))
			{
				AddToGoalVariable(1);
			}
		}
	}
}
