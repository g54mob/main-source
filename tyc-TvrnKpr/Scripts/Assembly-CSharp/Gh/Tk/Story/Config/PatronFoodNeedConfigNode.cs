using UnityEngine;

namespace Gh.Tk.Story.Config
{
	public class PatronFoodNeedConfigNode : PatronNeedConfigNode
	{
		[Header("Secondary Needs")]
		[Tooltip("Chance that pawns who want food will also want dessert (dessert only applies to tier>1)")]
		public int dessertChance;

		[Tooltip("Chance that pawns will want a specific meal type (such as soup or roast)")]
		public int specificFoodTypeChance;

		public override void AddSecondaryNeeds(PatronPopulationData pawn, PatronNeedData data, bool tryForceSecondaryNeed)
		{
		}

		private static string[] GetPossibleMealTypes()
		{
			return null;
		}

		protected override void OnPatronSpawned(Patron patron, PatronNeedData needData)
		{
		}
	}
}
