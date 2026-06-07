namespace Gh.Tk.Story.Config
{
	public class PatronTierNeedConfigNode : PatronNeedConfigNode
	{
		public override string GetNeedTitleKey(int patronTier)
		{
			return null;
		}

		protected override bool IsNeedMet(PatronPopulationData pawn, PatronNeedData needData, out string reasonKey, bool ignoreSecondaryNeeds = false)
		{
			reasonKey = null;
			return false;
		}
	}
}
