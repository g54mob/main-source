using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class LeaderboardType : ScriptableObject
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string displayName;

		[SerializeField]
		private string playerPrefsKey_score;

		[SerializeField]
		private string playerPrefsKey_rank;

		[SerializeField]
		private string switch_categoryName;

		[SerializeField]
		private bool isMonthlyLeaderboard;

		[SerializeField]
		private CustomModeConfiguration customModeConfiguration;

		private Dictionary<string, ulong> urlById = new Dictionary<string, ulong>();

		public bool IsMonthlyLeaderboard => isMonthlyLeaderboard;

		public bool IsNotInitialized
		{
			get
			{
				if (isMonthlyLeaderboard)
				{
					if (customModeConfiguration.month != 0)
					{
						return customModeConfiguration.year == 0;
					}
					return true;
				}
				return false;
			}
		}

		public string GetPlayerPrefsScoreKey(bool useSystemTimeInsteadOfGameTime = false)
		{
			if (isMonthlyLeaderboard)
			{
				if (useSystemTimeInsteadOfGameTime)
				{
					DateTime now = DateTime.Now;
					return $"{playerPrefsKey_score}_{now.Year:0000}{now.Month:00}";
				}
				return playerPrefsKey_score + "_" + customModeConfiguration.DateKey;
			}
			return playerPrefsKey_score;
		}

		public string GetPlayerPrefsRankKey()
		{
			if (isMonthlyLeaderboard)
			{
				return playerPrefsKey_rank + "_" + customModeConfiguration.DateKey;
			}
			return playerPrefsKey_rank;
		}

		public string GetLeaderboardId()
		{
			if (isMonthlyLeaderboard)
			{
				return id + "_" + customModeConfiguration.DateKey;
			}
			return id;
		}

		public void SetURLId(ulong steamId)
		{
			if (!urlById.ContainsKey(GetLeaderboardId()))
			{
				urlById.Add(GetLeaderboardId(), steamId);
			}
			urlById[GetLeaderboardId()] = steamId;
		}

		public ulong GetUrl()
		{
			if (urlById.ContainsKey(GetLeaderboardId()))
			{
				return urlById[GetLeaderboardId()];
			}
			return 0uL;
		}

		public string GetDisplayName(bool useSystemTimeInsteadOfGameTime = false)
		{
			if (isMonthlyLeaderboard)
			{
				if (useSystemTimeInsteadOfGameTime)
				{
					DateTime now = DateTime.Now;
					return $"{displayName} {now.Month:00}/{now.Year:0000}";
				}
				return $"{displayName} {customModeConfiguration.month:00}/{customModeConfiguration.year:0000}";
			}
			return displayName;
		}

		public string GetSwitchCategoryName()
		{
			return switch_categoryName;
		}

		public string GetPendingHighscorePlayerPrefsKey(bool useSystemTimeInsteadOfGameTime = false)
		{
			return GetPlayerPrefsScoreKey(useSystemTimeInsteadOfGameTime) + "_validatedOfflineScore";
		}
	}
}
