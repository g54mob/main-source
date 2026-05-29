using System;

namespace FuryStudios.FurySDK
{
	[Flags]
	public enum PlatformFeature : uint
	{
		None = 0u,
		UserManagment = 1u,
		Achievements = 2u,
		AchievementsWithProgress = 4u,
		RichPresence = 8u,
		Leaderboards = 0x10u,
		LeaderboardsWithMetadata = 0x20u,
		SafeArea = 0x40u,
		ChangeUsers = 0x200u,
		ManualForceQuit = 0x400u,
		ShowAchievementsUI = 0x800u,
		Streaming = 0x1000u,
		OpenURL = 0x2000u,
		Wishlist = 0x4000u,
		LockAchievements = 0x8000u,
		DlcOwnership = 0x10000u
	}
}
