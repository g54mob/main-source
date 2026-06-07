namespace Toybox.Port
{
	public interface IPlatformManager
	{
		IPlatformAchievement PlatformAchievement { get; }

		IPlatformSave PlatformSave { get; }

		IPlatformPlayerPrefs PlatformPlayerPrefs { get; }

		IPlatformGamepad PlatformGamepad { get; }

		IPlatformLeaderboard PlatformLeaderboard { get; }

		bool IsConstrained { get; }

		bool IsInitialized { get; }

		void Init();

		void Update();
	}
}
