using Steamworks;
using UnityEngine;

internal class SteamStatsAndAchievements : MonoBehaviour
{
	private class Achievement_t
	{
		public Achievements.Achievement m_eAchievementID;

		public bool m_bAchieved;

		public Achievement_t(Achievements.Achievement achievementID)
		{
		}
	}

	private Achievement_t[] m_Achievements;

	private CGameID m_GameID;

	private bool m_bRequestedStats;

	private bool m_bStatsValid;

	private bool m_bStoreStats;

	protected Callback<UserStatsReceived_t> m_UserStatsReceived;

	protected Callback<UserStatsStored_t> m_UserStatsStored;

	protected Callback<UserAchievementStored_t> m_UserAchievementStored;

	private bool sync;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void Sync()
	{
	}

	private void SyncStatsAndAchievements()
	{
	}

	private void UnlockAchievement(Achievement_t achievement)
	{
	}

	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
	}

	private void PrintStat(string stat)
	{
	}

	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
	}

	private void OnAchievementStored(UserAchievementStored_t pCallback)
	{
	}
}
