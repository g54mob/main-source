using System;

namespace CTS
{
	[Serializable]
	public class BBTPositiveReviewsSpeciesGoal : BBTGoal<PositiveReviewsSpeciesGoal>
	{
		public ESpecies Species;

		protected override void InstantiateGoal()
		{
			Goal = new PositiveReviewsSpeciesGoal(Quest, Entry, Variable, Target, Species);
		}
	}
}
