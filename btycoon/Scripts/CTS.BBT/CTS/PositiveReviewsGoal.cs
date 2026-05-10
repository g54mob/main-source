using CTS.BBT.AI;

namespace CTS
{
	public class PositiveReviewsGoal : QuestNumericGoal
	{
		public PositiveReviewsGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
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
			if (reviewScore > 0)
			{
				AddToGoalVariable(1);
			}
		}
	}
}
