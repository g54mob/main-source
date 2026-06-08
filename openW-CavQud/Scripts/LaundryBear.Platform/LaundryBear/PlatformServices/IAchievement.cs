namespace LaundryBear.PlatformServices
{
	public interface IAchievement
	{
		IUser User { get; }

		bool IsSecret { get; }

		string LockedDescription { get; }

		string UnlockedDescription { get; }

		int Progress { get; }

		void SetProgress(int progress, OnAchievementSet onComplete);
	}
}
