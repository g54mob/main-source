using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Config
{
	public class LevelConfigNode : ConnectedStoryNode
	{
		[Header("Population")]
		public int totalPopulation;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection tierDistribution;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection raceDistribution;

		public TierDistributionConfigNode GetTierDistributionNode()
		{
			return null;
		}

		public RaceDistributionConfigNode GetRaceDistributionNode()
		{
			return null;
		}
	}
}
