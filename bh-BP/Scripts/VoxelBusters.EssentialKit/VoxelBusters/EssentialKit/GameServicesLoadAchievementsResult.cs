namespace VoxelBusters.EssentialKit
{
	public class GameServicesLoadAchievementsResult
	{
		public IAchievement[] Achievements { get; private set; }

		internal GameServicesLoadAchievementsResult(IAchievement[] achievements)
		{
		}
	}
}
