using UnityEngine;

namespace FractureField.Achievements
{
	public class SteamAchievementBridge : MonoBehaviour
	{
		private static SteamAchievementBridge _instance;

		[SerializeField]
		private bool enableSteamIntegration;

		private static readonly CatLogger Logger;

		public static SteamAchievementBridge Instance => null;

		public bool IsSteamInitialized => false;

		public bool IsSteamIntegrationEnabled => false;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void SyncCompletedAchievements()
		{
		}

		public bool UnlockAchievement(string achievementId)
		{
			return false;
		}

		private bool SetAchievementSilent(string achievementId)
		{
			return false;
		}

		public bool ClearAchievement(string achievementId)
		{
			return false;
		}

		public void ResetAllAchievements()
		{
		}

		public bool IsAchievementUnlocked(string achievementId)
		{
			return false;
		}
	}
}
