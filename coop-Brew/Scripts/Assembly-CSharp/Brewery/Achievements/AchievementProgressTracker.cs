using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;

namespace Brewery.Achievements
{
	public class AchievementProgressTracker : ISaveable
	{
		public class LifetimeStats
		{
			public int totalBrewsCompleted;

			public int totalBeerBrews;

			public int totalWineBrews;

			public int totalSpiritsBrews;

			public int totalCatalystBrews;

			public int totalLegendaryBrews;

			public int totalDiscoveriesUnlocked;

			public int totalBrawlsWon;

			public int totalBrawlsLost;

			public int totalThiefCampsCleared;

			public int totalQuestsCompleted;

			public HashSet<string> questsCompleted;

			public float peakCurrencyReached;

			public float totalCurrencyEarned;

			public int totalTradesMade;

			public HashSet<string> stationsUsed;

			public HashSet<string> factionsTraded;

			public HashSet<string> npcsTraded;

			public HashSet<string> npcsMaxRep;

			public HashSet<string> locationsUnlocked;

			public HashSet<string> vehiclesPurchased;

			public HashSet<string> tagsDiscovered;

			public HashSet<string> brewsDiscovered;

			public int thiefCampTier1Cleared;

			public int thiefCampTier2Cleared;

			public int thiefCampTier3Cleared;

			public int currentBrawlStreak;

			public int bestBrawlStreak;

			public HashSet<string> barFactionsSold;

			public Dictionary<string, int> barFactionSaleCounts;
		}

		private static AchievementProgressTracker _instance;

		private Dictionary<string, int> achievementProgress;

		private Dictionary<string, long> unlockedAchievements;

		private Queue<string> offlineUnlockQueue;

		private Dictionary<string, int> compoundConditionProgress;

		private Dictionary<string, int> streakProgress;

		private int saveVersion;

		private bool hasProcessedRetroactiveUnlocks;

		private LifetimeStats lifetimeStats;

		public static AchievementProgressTracker Instance => null;

		public string SaveableId => null;

		public int SavePriority => 0;

		public LifetimeStats Stats => null;

		public bool HasProcessedRetroactiveUnlocks => false;

		public event Action<string, int, int> OnProgressUpdated
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

		public event Action<string> OnAchievementUnlockedLocally
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

		public event Action OnSaveDataRestored
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

		public int GetProgress(string achievementId)
		{
			return 0;
		}

		public void SetProgress(string achievementId, int value, int targetValue)
		{
		}

		public int IncrementProgress(string achievementId, int delta, int targetValue)
		{
			return 0;
		}

		public bool IsUnlockedLocally(string achievementId)
		{
			return false;
		}

		public void MarkUnlocked(string achievementId)
		{
		}

		public IEnumerable<string> GetUnlockedAchievements()
		{
			return null;
		}

		public void RemoveUnlockedAchievement(string achievementId)
		{
		}

		public int GetCompoundConditionProgress(string achievementId, int conditionIndex)
		{
			return 0;
		}

		public void SetCompoundConditionProgress(string achievementId, int conditionIndex, int value)
		{
		}

		public int IncrementCompoundConditionProgress(string achievementId, int conditionIndex, int delta = 1)
		{
			return 0;
		}

		public int GetStreak(string achievementId)
		{
			return 0;
		}

		public int IncrementStreak(string achievementId)
		{
			return 0;
		}

		public void ResetStreak(string achievementId)
		{
		}

		public void QueueOfflineUnlock(string achievementId)
		{
		}

		public IEnumerable<string> GetOfflineQueue()
		{
			return null;
		}

		public void ClearOfflineQueue()
		{
		}

		public void DequeueOfflineUnlock(string achievementId)
		{
		}

		public void MarkRetroactiveUnlocksProcessed()
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		public void ResetAllProgress()
		{
		}
	}
}
