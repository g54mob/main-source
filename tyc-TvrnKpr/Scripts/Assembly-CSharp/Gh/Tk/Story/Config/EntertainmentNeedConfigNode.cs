namespace Gh.Tk.Story.Config
{
	public class EntertainmentNeedConfigNode : PatronNeedConfigNode
	{
		protected override bool IsNeedMet(PatronPopulationData pawn, PatronNeedData needData, out string reasonKey, bool ignoreSecondaryNeeds = false)
		{
			reasonKey = null;
			return false;
		}

		protected override void OnPatronSpawned(Patron patron, PatronNeedData needData)
		{
		}
	}
}
