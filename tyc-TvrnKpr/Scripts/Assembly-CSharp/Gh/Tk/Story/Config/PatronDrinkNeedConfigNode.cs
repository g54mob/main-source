namespace Gh.Tk.Story.Config
{
	public class PatronDrinkNeedConfigNode : PatronNeedConfigNode
	{
		public int specificDrinkTypeChance;

		public int specificDrinkChance;

		public override void AddSecondaryNeeds(PatronPopulationData pawn, PatronNeedData data, bool tryForceSecondaryNeed)
		{
		}
	}
}
