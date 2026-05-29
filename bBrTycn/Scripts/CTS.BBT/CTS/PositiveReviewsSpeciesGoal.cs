using CTS.BBT.AI;

namespace CTS
{
	public class PositiveReviewsSpeciesGoal : BaseSpecificSpeciesNumericalGoal
	{
		public PositiveReviewsSpeciesGoal(Quest quest, int entryID, string variableName, string targetVariableName, ESpecies specie)
			: base(quest, entryID, variableName, targetVariableName, specie)
		{
		}

		public override void StopObserving()
		{
			PrestigeCustomerReviews.CustomerReviewed -= OnBarReviewedByCustomer;
		}

		public override void StartObserving()
		{
			PrestigeCustomerReviews.CustomerReviewed += OnBarReviewedByCustomer;
		}

		private void OnBarReviewedByCustomer(Customer customer, int reviewScore)
		{
			if (reviewScore > 0 && base.TargetSpecies == customer.SpawnParameters.CharacterData.Species)
			{
				AddToGoalVariable(1);
			}
		}
	}
}
