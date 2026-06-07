using Galaxy.Api;
using UnityEngine;

public class StatsAndAchievements : MonoBehaviour
{
	private class UserStatsAndAchievementsRetrieveListener : GlobalUserStatsAndAchievementsRetrieveListener
	{
		public bool retrieved;

		public override void OnUserStatsAndAchievementsRetrieveSuccess(GalaxyID userID)
		{
		}

		public override void OnUserStatsAndAchievementsRetrieveFailure(GalaxyID userID, FailureReason failureReason)
		{
		}
	}

	private class StatsAndAchievementsStoreListener : GlobalStatsAndAchievementsStoreListener
	{
		public override void OnUserStatsAndAchievementsStoreFailure(FailureReason failureReason)
		{
		}

		public override void OnUserStatsAndAchievementsStoreSuccess()
		{
		}
	}

	private class AchievementChangeListener : GlobalAchievementChangeListener
	{
		public override void OnAchievementUnlocked(string name)
		{
		}
	}

	private UserStatsAndAchievementsRetrieveListener achievementRetrieveListener;

	private AchievementChangeListener achievementChangeListener;

	private StatsAndAchievementsStoreListener achievementStoreListener;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void ListenersInit()
	{
	}

	private void ListenersDispose()
	{
	}

	public bool IsRetrieved()
	{
		return false;
	}

	public void RequestUserStatsAndAchievements()
	{
	}

	public void SetAchievement(string apiKey)
	{
	}

	public bool GetAchievement(string apiKey)
	{
		return false;
	}

	public string GetAchievementName(string apiKey)
	{
		return null;
	}

	public void SetStatFloat(string apiKey, float statValue)
	{
	}

	public void SetStatInt(string apiKey, int statValue)
	{
	}

	public float GetStatFloat(string apiKey)
	{
		return 0f;
	}

	public int GetStatInt(string apiKey)
	{
		return 0;
	}

	public void ResetStatsAndAchievements()
	{
	}
}
