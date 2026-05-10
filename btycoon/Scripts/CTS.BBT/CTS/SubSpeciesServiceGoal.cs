using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	public class SubSpeciesServiceGoal : BaseSpecificSubSpeciesNumericalGoal
	{
		public SubSpeciesServiceGoal(Quest quest, int entryID, string variableName, string targetVariableName, ESubSpecies subSpeciesToServe)
			: base(quest, entryID, variableName, targetVariableName, subSpeciesToServe)
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
			if (order.CustomerRef.SpawnParameters.CharacterData.SubSpecies == base.TargetSubSpecies)
			{
				AddToGoalVariable(1);
			}
		}
	}
}
