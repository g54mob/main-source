using System;
using System.Collections.Generic;
using Steamworks;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Platforms.SteamworksIntegration
{
	public class SteamworksAchievementsManager : IPlatformAchievementsManager, ILastErrorProvider
	{
		private ErroInfo m_LastError;

		private AchievementsManagerState m_State;

		private Dictionary<AchievementType, AchievementData> m_AchievementDefinitions;

		private bool m_storeStats;

		protected Action<bool, List<AchievementType>> m_onInitCompleteCallback;

		protected List<AchievementType> m_inout_Completed;

		public AchievementsManagerState State => default(AchievementsManagerState);

		public ErroInfo LastError => default(ErroInfo);

		public void Close()
		{
		}

		public void InitAsync(Dictionary<AchievementType, AchievementData> readonly_achievementDefinitions, List<AchievementType> inout_Completed, Action<bool, List<AchievementType>> onComplete)
		{
		}

		private void OnUserStatsReceived(SteamId steamId, Result result)
		{
		}

		public void ReportProgressAsync(AchievementType id, float newprogress = 1f, Action<AchievementType, bool> onComplete = null)
		{
		}
	}
}
