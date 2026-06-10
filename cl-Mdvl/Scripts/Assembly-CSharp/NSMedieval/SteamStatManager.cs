using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using Steamworks;

namespace NSMedieval
{
	public class SteamStatManager : MonoSingleton<SteamStatManager>
	{
		private readonly Dictionary<string, int> statValues = new Dictionary<string, int>();

		private readonly Dictionary<string, int> refreshIntervals = new Dictionary<string, int>();

		public void RefreshStatValues()
		{
			if (SteamAPI.IsSteamRunning() && SteamSdkManager.IsSteamInitialised)
			{
				LoadInitialStatValues();
			}
		}

		public int GetSyncedStatValue(string id)
		{
			if (!statValues.ContainsKey(id))
			{
				return 0;
			}
			return statValues[id];
		}

		public bool ShouldRefresh(string id)
		{
			if (!refreshIntervals.ContainsKey(id))
			{
				return false;
			}
			if (!statValues.ContainsKey(id))
			{
				return false;
			}
			if (!SteamAPI.IsSteamRunning())
			{
				return false;
			}
			if (!SteamUserStats.GetStat(id, out int pData))
			{
				return false;
			}
			return Math.Abs(pData - GetSyncedStatValue(id)) >= refreshIntervals[id];
		}

		private void Start()
		{
			if (SteamSdkManager.IsSteamInitialised)
			{
				RefreshStatValues();
			}
		}

		private void LoadInitialStatValues()
		{
			AchievementSettings data = Repository<AchievementSettingsData, AchievementSettings>.Instance.GetData<AchievementSettings>();
			if (data.Stats == null || data.Stats.Length == 0)
			{
				return;
			}
			statValues.Clear();
			refreshIntervals.Clear();
			AchievementSettings.StatSettings[] stats = data.Stats;
			for (int i = 0; i < stats.Length; i++)
			{
				AchievementSettings.StatSettings statSettings = stats[i];
				refreshIntervals[statSettings.ID] = statSettings.RefreshInterval;
				if (!SteamUserStats.GetStat(statSettings.ID, out int pData))
				{
					statValues[statSettings.ID] = 0;
				}
				else
				{
					statValues[statSettings.ID] = pData;
				}
			}
		}
	}
}
