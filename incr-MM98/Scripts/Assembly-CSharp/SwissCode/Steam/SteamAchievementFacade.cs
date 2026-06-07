using Steamworks;

namespace SwissCode.Steam
{
	public class SteamAchievementFacade : SteamFacade
	{
		public bool HasAchievement(string name)
		{
			if (!Initialized || string.IsNullOrEmpty(name))
			{
				return false;
			}
			bool pbAchieved;
			return SteamUserStats.GetAchievement(name, out pbAchieved) && pbAchieved;
		}

		public void UnlockAchievement(string name, bool store = true)
		{
			if (Initialized && !string.IsNullOrEmpty(name) && SteamUserStats.SetAchievement(name) && store)
			{
				SteamUserStats.StoreStats();
			}
		}

		public void ClearAchievement(string name, bool store = true)
		{
			if (Initialized && !string.IsNullOrEmpty(name) && SteamUserStats.ClearAchievement(name) && store)
			{
				SteamUserStats.StoreStats();
			}
		}

		public (bool, uint) GetAchievementUnlockTime(string name)
		{
			if (!Initialized || string.IsNullOrEmpty(name))
			{
				return default((bool, uint));
			}
			SteamUserStats.GetAchievementAndUnlockTime(name, out var pbAchieved, out var punUnlockTime);
			return (pbAchieved, punUnlockTime);
		}

		public string GetAchievementName(string name)
		{
			if (Initialized && !string.IsNullOrEmpty(name))
			{
				return SteamUserStats.GetAchievementDisplayAttribute(name, "name");
			}
			return null;
		}

		public string GetAchievementDescription(string name)
		{
			if (Initialized && !string.IsNullOrEmpty(name))
			{
				return SteamUserStats.GetAchievementDisplayAttribute(name, "description");
			}
			return null;
		}

		public bool IsAchievementHidden(string name)
		{
			if (Initialized && !string.IsNullOrEmpty(name))
			{
				return SteamUserStats.GetAchievementDisplayAttribute(name, "hidden") == "1";
			}
			return false;
		}

		public void IndicateAchievementProgress(string name, uint current, uint total)
		{
			if (Initialized && !string.IsNullOrEmpty(name))
			{
				SteamUserStats.IndicateAchievementProgress(name, current, total);
			}
		}

		public bool HasAchievementForUser(CSteamID steamId, string name)
		{
			bool pbAchieved = default(bool);
			return Initialized && !string.IsNullOrEmpty(name) && SteamUserStats.GetUserAchievement(steamId, name, out pbAchieved) && pbAchieved;
		}

		public (bool, uint) GetAchievementUnlockTimeForUser(CSteamID steamId, string name)
		{
			if (!Initialized || string.IsNullOrEmpty(name))
			{
				return default((bool, uint));
			}
			SteamUserStats.GetUserAchievementAndUnlockTime(steamId, name, out var pbAchieved, out var punUnlockTime);
			return (pbAchieved, punUnlockTime);
		}

		public float GetAchievementAchievedPercentage(string name)
		{
			if (Initialized && !string.IsNullOrEmpty(name))
			{
				if (!SteamUserStats.GetAchievementAchievedPercent(name, out var pflPercent))
				{
					return 0f;
				}
				return pflPercent;
			}
			return 0f;
		}
	}
}
