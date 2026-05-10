using CTS.Core;
using Steamworks;
using UnityEngine;

namespace CTS
{
	public class SteamAchievementManager : AchievementManager
	{
		protected override void AddToStats_(string statID, int statValue)
		{
			if (SteamManager.Initialized && SteamUserStats.GetStat(statID, out int pData))
			{
				SteamUserStats.SetStat(statID, pData + statValue);
				SteamUserStats.StoreStats();
			}
		}

		protected override void SetStats_(string statID, int statNewValue)
		{
			if (SteamManager.Initialized)
			{
				SteamUserStats.SetStat(statID, statNewValue);
				SteamUserStats.StoreStats();
			}
		}

		protected override int? GetStats_(string statID)
		{
			if (!SteamManager.Initialized)
			{
				return null;
			}
			if (SteamUserStats.GetStat(statID, out int pData))
			{
				return pData;
			}
			return null;
		}

		protected override bool UnlockAchievement_(string ID)
		{
			if (!CTSSingleton<GamePlatform>.Instance.Library.TryAuthenticateGame())
			{
				Application.Quit();
				return false;
			}
			if (!SteamManager.Initialized)
			{
				Application.Quit();
				return false;
			}
			if (string.IsNullOrWhiteSpace(SteamFriends.GetPersonaName()))
			{
				Debug.LogError("The 'statID' was empty!");
				return false;
			}
			if (!SteamUserStats.GetAchievement(ID, out var pbAchieved))
			{
				Debug.LogError("Fail to found Steam achievement : " + ID);
				return false;
			}
			if (!pbAchieved && SteamUserStats.SetAchievement(ID))
			{
				SteamUserStats.StoreStats();
				Debug.Log("Steam Achievement Unlocked : " + ID);
				return true;
			}
			return false;
		}

		protected override bool ClearAchievement_(string ID)
		{
			if (!SteamManager.Initialized)
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(SteamFriends.GetPersonaName()))
			{
				Debug.LogError("The 'statID' was empty!");
				return false;
			}
			if (!SteamUserStats.GetAchievement(ID, out var pbAchieved))
			{
				Debug.LogError("Fail to found Steam achievement : " + ID);
				return false;
			}
			if (pbAchieved && SteamUserStats.ClearAchievement(ID))
			{
				SteamUserStats.StoreStats();
				Debug.Log("Steam Achievement Cleared : " + ID);
				return true;
			}
			return false;
		}

		protected override void ResetAllAchievement_()
		{
			if (SteamManager.Initialized)
			{
				SteamUserStats.ResetAllStats(bAchievementsToo: true);
			}
		}

		protected override void ResetAllStats_()
		{
			if (SteamManager.Initialized)
			{
				SteamUserStats.ResetAllStats(bAchievementsToo: false);
			}
		}
	}
}
