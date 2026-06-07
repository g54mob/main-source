using Dhs5.Utility.Debuggers;

namespace Simulator
{
	public static class SteamAchievementsExtension
	{
		public static void Trigger(this ESteamAchievement steamAchievement)
		{
			Debugger<EDebugCategory>.Log(EDebugCategory.STEAM_ACHIEVEMENT, steamAchievement.ToString(), 0);
			AchievementsManager.UnlockAchievement((AchievementID)steamAchievement);
		}
	}
}
