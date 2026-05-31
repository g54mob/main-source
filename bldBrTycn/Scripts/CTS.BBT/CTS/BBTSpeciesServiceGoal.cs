using System;

namespace CTS
{
	[Serializable]
	public class BBTSpeciesServiceGoal : BBTGoal<SpeciesServiceGoal>
	{
		public ESpecies SpeciesToServe;

		protected override void InstantiateGoal()
		{
			Goal = new SpeciesServiceGoal(Quest, Entry, Variable, Target, SpeciesToServe);
		}
	}
}
