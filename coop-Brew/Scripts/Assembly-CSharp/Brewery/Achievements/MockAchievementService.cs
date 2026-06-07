using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Brewery.Achievements
{
	public class MockAchievementService : ISteamAchievementService
	{
		private HashSet<string> unlockedAchievements;

		private Dictionary<string, int> stats;

		private bool _isAvailable;

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

		public void SetAvailable(bool available)
		{
		}

		public IEnumerable<string> GetUnlockedAchievements()
		{
			return null;
		}

		public void ResetAll()
		{
		}

		public int GetUnlockCount()
		{
			return 0;
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
