namespace VoxelBusters.EssentialKit
{
	public class GameServicesLoadAchievementDescriptionsResult
	{
		public IAchievementDescription[] AchievementDescriptions { get; private set; }

		internal GameServicesLoadAchievementDescriptionsResult(IAchievementDescription[] descriptions)
		{
		}
	}
}
