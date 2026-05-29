namespace CTS
{
	public class AchievementManager
	{
		protected static AchievementManager Instance;

		public static bool ExistsInstance => Instance != null;

		public AchievementManager()
		{
			Instance = this;
		}

		public static void ResetAllAchievement()
		{
			if (Instance != null)
			{
				Instance.ResetAllAchievement_();
			}
		}

		public static void ResetAllStats()
		{
			if (Instance != null)
			{
				Instance.ResetAllStats_();
			}
		}

		public static bool UnlockAchievement(string ID)
		{
			if (Instance == null)
			{
				return false;
			}
			return Instance.UnlockAchievement_(ID);
		}

		public static bool ClearAchievement(string ID)
		{
			if (Instance == null)
			{
				return false;
			}
			return Instance.ClearAchievement_(ID);
		}

		public static int? GetStats(string statID)
		{
			if (Instance == null)
			{
				return null;
			}
			return Instance.GetStats_(statID);
		}

		public static void AddToStats(string statID, int statAddedValue)
		{
			if (Instance != null)
			{
				Instance.AddToStats_(statID, statAddedValue);
			}
		}

		public static void SetStats(string statID, int statAddedValue)
		{
			if (Instance != null)
			{
				Instance.SetStats_(statID, statAddedValue);
			}
		}

		protected virtual bool UnlockAchievement_(string ID)
		{
			return false;
		}

		protected virtual bool ClearAchievement_(string ID)
		{
			return false;
		}

		protected virtual int? GetStats_(string statID)
		{
			return null;
		}

		protected virtual void AddToStats_(string statID, int statAddedValue)
		{
		}

		protected virtual void SetStats_(string statID, int statNewValue)
		{
		}

		protected virtual void ResetAllAchievement_()
		{
		}

		protected virtual void ResetAllStats_()
		{
		}
	}
}
