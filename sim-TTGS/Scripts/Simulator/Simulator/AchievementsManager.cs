using Steamworks;
using UnityEngine;

namespace Simulator
{
	public class AchievementsManager : MonoBehaviour
	{
		private CGameID _gameID;

		protected Callback<UserStatsReceived_t> _userStatsReceived;

		private static readonly Achievement_t[] _achievements = new Achievement_t[40]
		{
			new Achievement_t(AchievementID.id_success_001),
			new Achievement_t(AchievementID.id_success_002),
			new Achievement_t(AchievementID.id_success_003),
			new Achievement_t(AchievementID.id_success_004),
			new Achievement_t(AchievementID.id_success_005),
			new Achievement_t(AchievementID.id_success_006),
			new Achievement_t(AchievementID.id_success_007),
			new Achievement_t(AchievementID.id_success_008),
			new Achievement_t(AchievementID.id_success_009),
			new Achievement_t(AchievementID.id_success_010),
			new Achievement_t(AchievementID.id_success_011),
			new Achievement_t(AchievementID.id_success_012),
			new Achievement_t(AchievementID.id_success_013),
			new Achievement_t(AchievementID.id_success_014),
			new Achievement_t(AchievementID.id_success_015),
			new Achievement_t(AchievementID.id_success_016),
			new Achievement_t(AchievementID.id_success_017),
			new Achievement_t(AchievementID.id_success_018),
			new Achievement_t(AchievementID.id_success_019),
			new Achievement_t(AchievementID.id_success_020),
			new Achievement_t(AchievementID.id_success_021),
			new Achievement_t(AchievementID.id_success_022),
			new Achievement_t(AchievementID.id_success_023),
			new Achievement_t(AchievementID.id_success_024),
			new Achievement_t(AchievementID.id_success_025),
			new Achievement_t(AchievementID.id_success_026),
			new Achievement_t(AchievementID.id_success_027),
			new Achievement_t(AchievementID.id_success_028),
			new Achievement_t(AchievementID.id_success_029),
			new Achievement_t(AchievementID.id_success_030),
			new Achievement_t(AchievementID.id_success_031),
			new Achievement_t(AchievementID.id_success_032),
			new Achievement_t(AchievementID.id_success_033),
			new Achievement_t(AchievementID.id_success_034),
			new Achievement_t(AchievementID.id_success_035),
			new Achievement_t(AchievementID.id_success_036),
			new Achievement_t(AchievementID.id_success_037),
			new Achievement_t(AchievementID.id_success_038),
			new Achievement_t(AchievementID.id_success_039),
			new Achievement_t(AchievementID.id_success_040)
		};

		public static AchievementsManager Instance { get; set; }

		private void Awake()
		{
			if (Instance != null)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				Instance = this;
			}
		}

		public static void UnlockAchievement(AchievementID achievementId)
		{
			if (IsUnlocked(achievementId))
			{
				Debug.Log(achievementId.ToString() + " est déjà unlocked: " + IsUnlocked(achievementId));
				return;
			}
			SteamUserStats.SetAchievement(achievementId.ToString());
			SteamUserStats.StoreStats();
			Debug.Log($"Achievement \"{achievementId}\" unlocked");
		}

		private void SaveStats()
		{
			PlayerPrefs.Save();
			SteamUserStats.StoreStats();
		}

		public void OnDestroy()
		{
			_userStatsReceived?.Dispose();
		}

		private static bool IsUnlocked(AchievementID achievementId)
		{
			if ((int)achievementId >= _achievements.Length)
			{
				Debug.LogError("Achievement ID " + achievementId.ToString() + " is invalid");
				return false;
			}
			return _achievements[(uint)achievementId].Achieved;
		}

		private void OnUserStatsReceived(UserStatsReceived_t pCallback)
		{
			if (!SteamManager.Initialized || (ulong)_gameID != pCallback.m_nGameID)
			{
				return;
			}
			if (EResult.k_EResultOK != pCallback.m_eResult)
			{
				Debug.Log("RequestStats - failed, " + pCallback.m_eResult);
				return;
			}
			Debug.Log("Received stats and achievements from Steam\n");
			Achievement_t[] achievements = _achievements;
			foreach (Achievement_t achievement_t in achievements)
			{
				if (!SteamUserStats.GetAchievement(achievement_t.ID.ToString(), out achievement_t.Achieved))
				{
					Debug.LogWarning("SteamUserStats.GetAchievement failed for Achievement " + achievement_t.ID.ToString() + "\nIs it registered in the Steam Partner site?");
				}
			}
		}
	}
}
