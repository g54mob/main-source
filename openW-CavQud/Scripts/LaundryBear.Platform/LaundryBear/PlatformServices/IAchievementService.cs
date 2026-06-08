namespace LaundryBear.PlatformServices
{
	public interface IAchievementService
	{
		void GetAchievement(IUser user, string achievmentID, OnAchievementGet callback);
	}
}
