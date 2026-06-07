using XNode;

namespace Gh.Tk.Story.Config
{
	public class RaceDistributionConfigNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		public int orcsPercentage;

		public int dwarvesPercentage;

		public int humansPercentage;

		public int halflingsPercentage;

		public int elvesPercentage;

		public int GetPercentageForRace(string race)
		{
			return 0;
		}

		public void Validate()
		{
		}
	}
}
