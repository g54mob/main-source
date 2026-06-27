namespace Alekrus.UnivarsalPlatform.Achievements
{
	public interface IAchievementInfo
	{
		AchievementId Id { get; }

		Image UnlockedIcon { get; }

		Image LockedIcon { get; }

		string UnlockedName { get; }

		string UnlockedDescription { get; }

		string LockedName { get; }

		string LockedDescription { get; }

		double MinProgress { get; }

		double MaxProgress { get; }
	}
}
