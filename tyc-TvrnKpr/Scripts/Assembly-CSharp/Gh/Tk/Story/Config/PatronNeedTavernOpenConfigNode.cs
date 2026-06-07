namespace Gh.Tk.Story.Config
{
	public class PatronNeedTavernOpenConfigNode : PatronNeedConfigNode
	{
		protected override bool IsNeedMet(PatronPopulationData pawn, PatronNeedData needData, out string reasonKey, bool ignoreSecondaryNeeds = false)
		{
			reasonKey = null;
			return false;
		}
	}
}
