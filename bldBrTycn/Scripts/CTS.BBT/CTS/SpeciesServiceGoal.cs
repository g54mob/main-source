using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	public class SpeciesServiceGoal : BaseSpecificSpeciesNumericalGoal
	{
		public SpeciesServiceGoal(Quest quest, int entryID, string variableName, string targetVariableName, ESpecies speciesToServe)
			: base(quest, entryID, variableName, targetVariableName, speciesToServe)
		{
		}

		public override void StopObserving()
		{
			WorkerChoreDrinkDelivery.DrinkDelivered -= OnDrinkDelivered;
		}

		public override void StartObserving()
		{
			WorkerChoreDrinkDelivery.DrinkDelivered += OnDrinkDelivered;
		}

		private void OnDrinkDelivered(CustomerOrder order)
		{
			if (order.CustomerRef.SpawnParameters.CharacterData.Species == base.TargetSpecies)
			{
				AddToGoalVariable(1);
			}
		}
	}
}
