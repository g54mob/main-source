using System;
using JetBrains.Annotations;
using Steamworks;
using Timberborn.AchievementSystem;
using Timberborn.SteamStoreSystem;
using UnityEngine;

namespace Timberborn.SteamAchievementSystem
{
	internal class SteamAchievements : IStoreAchievements
	{
		[UsedImplicitly]
		private Callback<UserStatsReceived_t> _userStatsReceived;

		private readonly SteamManager _steamManager;

		private Action _initializationSuccessCallback;

		public SteamAchievements(SteamManager steamManager)
		{
			_steamManager = steamManager;
		}

		public void Initialize(Action successCallback)
		{
			if (_steamManager.Initialized)
			{
				_initializationSuccessCallback = successCallback;
				_userStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
				SteamUserStats.RequestCurrentStats();
			}
		}

		public bool IsAchievementUnlocked(string achievementId)
		{
			bool pbAchieved = default(bool);
			return _steamManager.Initialized && SteamUserStats.GetAchievement(achievementId, out pbAchieved) && pbAchieved;
		}

		public void UnlockAchievement(string achievementId)
		{
			if (_steamManager.Initialized)
			{
				if (SteamUserStats.SetAchievement(achievementId))
				{
					SteamUserStats.StoreStats();
				}
				else
				{
					Debug.LogError("Failed to unlock achievement: " + achievementId + ".");
				}
			}
		}

		private void OnUserStatsReceived(UserStatsReceived_t callback)
		{
			_userStatsReceived.Dispose();
			_userStatsReceived = null;
			if (callback.m_eResult == EResult.k_EResultOK)
			{
				_initializationSuccessCallback();
			}
			else
			{
				Debug.LogError($"Failed to receive Steam user stats: {callback.m_eResult}.");
			}
		}
	}
}
