using CTS.BBT.AI;

namespace CTS
{
	public class SubSpeciesLureGoal : BaseSpecificSubSpeciesNumericalGoal
	{
		public SubSpeciesLureGoal(Quest quest, int entryID, string variableName, string targetVariableName, ESubSpecies subSpeciesToLure)
			: base(quest, entryID, variableName, targetVariableName, subSpeciesToLure)
		{
		}

		public override void StopObserving()
		{
			Agent.EnteringBar -= OnCustomerEntering;
		}

		public override void StartObserving()
		{
			Agent.EnteringBar += OnCustomerEntering;
		}

		private void OnCustomerEntering(Agent agent)
		{
			if (agent is Customer customer && customer.SpawnParameters.CharacterData.SubSpecies == base.TargetSubSpecies)
			{
				AddToGoalVariable(1);
			}
		}
	}
}
