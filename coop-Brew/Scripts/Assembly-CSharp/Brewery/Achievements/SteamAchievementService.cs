using System;
using System.Runtime.CompilerServices;
using Steamworks;

namespace Brewery.Achievements
{
	public class SteamAchievementService : ISteamAchievementService
	{
		private bool isAvailable;

		private bool statsReceived;

		private Callback<UserStatsReceived_t> userStatsReceivedCallback;

		private Callback<UserStatsStored_t> userStatsStoredCallback;

		private Callback<UserAchievementStored_t> userAchievementStoredCallback;

		public bool IsAvailable => false;

		public event Action OnStatsReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<string> OnAchievementUnlocked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Initialize()
		{
		}

		public bool UnlockAchievement(string achievementId)
		{
			return false;
		}

		public bool IsAchievementUnlocked(string achievementId)
		{
			return false;
		}

		public float GetAchievementUnlockPercentage(string achievementId)
		{
			return 0f;
		}

		public bool StoreStats()
		{
			return false;
		}

		public void RequestCurrentStats()
		{
		}

		public bool SetStat(string statName, int value)
		{
			return false;
		}

		public int GetStat(string statName)
		{
			return 0;
		}

		private void OnUserStatsReceived(UserStatsReceived_t callback)
		{
		}

		private void OnUserStatsStored(UserStatsStored_t callback)
		{
		}

		private void OnUserAchievementStored(UserAchievementStored_t callback)
		{
		}

		public void Dispose()
		{
		}

		public bool ClearAchievement(string achievementId)
		{
			return false;
		}

		public bool ClearAllAchievements()
		{
			return false;
		}
	}
}
