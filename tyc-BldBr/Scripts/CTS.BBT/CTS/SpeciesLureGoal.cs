using CTS.BBT.AI;

namespace CTS
{
	public class SpeciesLureGoal : BaseSpecificSpeciesNumericalGoal
	{
		public SpeciesLureGoal(Quest quest, int entryID, string variableName, string targetVariableName, ESpecies speciesToLure)
			: base(quest, entryID, variableName, targetVariableName, speciesToLure)
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
			if (agent is Customer customer && customer.SpawnParameters.CharacterData.Species == base.TargetSpecies)
			{
				AddToGoalVariable(1);
			}
		}
	}
}
