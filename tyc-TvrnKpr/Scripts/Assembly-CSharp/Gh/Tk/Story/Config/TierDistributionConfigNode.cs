using XNode;

namespace Gh.Tk.Story.Config
{
	public class TierDistributionConfigNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		public int tier1Percentage;

		public int tier2Percentage;

		public int tier3Percentage;

		public int tier4Percentage;

		public int tier5Percentage;

		public int[] GetTierPercentages()
		{
			return null;
		}

		public void Validate()
		{
		}
	}
}
