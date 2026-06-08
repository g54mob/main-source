using System;

namespace Dorfromantik
{
	[Serializable]
	public class RewardSystemData
	{
		public int level;

		public int score;

		public int consecutivePerfectFits;

		public int consecutivePerfectPlacementsWithoutRotate;

		public int perfectPlacementCount;

		public int questFulfilledCount;

		public int questFailedCount;

		public int placedTileCount;

		public int surroundedTilesCount;

		public RewardSystemData(RewardSystem rewardSystem)
		{
			level = rewardSystem.Level;
			score = rewardSystem.Score;
			consecutivePerfectFits = rewardSystem.ConsecutivePerfectFits;
			consecutivePerfectPlacementsWithoutRotate = rewardSystem.ConsecutivePlacementsWithoutRotate;
			perfectPlacementCount = rewardSystem.PerfectPlacementCount;
			questFulfilledCount = rewardSystem.QuestFulfilledCount;
			questFailedCount = rewardSystem.QuestFailedCount;
			placedTileCount = rewardSystem.PlacedTileCount;
			surroundedTilesCount = rewardSystem.SurroundedTilesCount;
		}
	}
}
