using Steamworks;

namespace Assets.Source.Player
{
	public class SteamAchievement
	{
		public static void Trigger(string name)
		{
			if (GamePlayer.Current != null && GamePlayer.Current.Integrity && SteamManager.Initialized)
			{
				SteamUserStats.GetAchievement(name, out var pbAchieved);
				if (!pbAchieved)
				{
					SteamUserStats.SetAchievement(name);
					SteamUserStats.StoreStats();
				}
			}
		}

		public static void Clear(string name = null)
		{
			if (SteamManager.Initialized)
			{
				if (name == null)
				{
					SteamUserStats.ResetAllStats(bAchievementsToo: true);
				}
				else
				{
					SteamUserStats.ClearAchievement(name);
				}
				SteamUserStats.StoreStats();
			}
		}
	}
}
