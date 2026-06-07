using System;
using System.Globalization;
using SteamIntegrations;
using UnityEngine;

namespace SettingScripts
{
	public static class ChallengesProgress
	{
		public static Color unlockedStarColor = new Color(0.906f, 0.702f, 0f);

		public static Color lockedStarColor = new Color(0.6f, 0.6f, 0.6f);

		public static string NameToKey(string name)
		{
			return name.Replace(" ", "").ToLower();
		}

		public static string NameToAchievementKey(string name, int level)
		{
			return "ACH_" + NameToKey(name).ToUpperInvariant() + $"_{level}STAR";
		}

		public static int GetStarOfChallenge(string challengeName)
		{
			return PlayerPrefs.GetInt(NameToKey(challengeName) + "Star", 0);
		}

		public static void SetStarOfChallenge(string challengeName, int val)
		{
			PlayerPrefs.SetInt(NameToKey(challengeName) + "Star", val);
		}

		public static bool HasEverCompletedChallenge(string challengeName)
		{
			return GetStarOfChallenge(challengeName) > 0;
		}

		public static ChallengeScoreInfo GetHighScoreOfChallenge(string challengeName)
		{
			string text = NameToKey(challengeName);
			string text2 = PlayerPrefs.GetString(text + "Time", null);
			return new ChallengeScoreInfo
			{
				challengeName = challengeName,
				starAttained = GetStarOfChallenge(challengeName),
				score = PlayerPrefs.GetFloat(text + "Score", float.NaN),
				championName = PlayerPrefs.GetString(text + "ChampionName", ""),
				championFullPath = PlayerPrefs.GetString(text + "ChampionPath", ""),
				time = (string.IsNullOrEmpty(text2) ? DateTime.UnixEpoch : DateTime.Parse(text2, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind))
			};
		}

		public static bool TrySetHighScoreOfChallenge(ChallengeScoreInfo info, bool highIsBetter)
		{
			string text = NameToKey(info.challengeName);
			ChallengeScoreInfo highScoreOfChallenge = GetHighScoreOfChallenge(info.challengeName);
			if (info.starAttained > 0)
			{
				AchievementManager.Trigger(NameToAchievementKey(info.challengeName, 1));
			}
			if (info.starAttained > 1)
			{
				AchievementManager.Trigger(NameToAchievementKey(info.challengeName, 2));
			}
			if (info.starAttained > 2)
			{
				AchievementManager.Trigger(NameToAchievementKey(info.challengeName, 3));
			}
			if (highScoreOfChallenge.starAttained > info.starAttained)
			{
				return false;
			}
			if (float.IsNaN(info.score))
			{
				return false;
			}
			if (!float.IsNaN(highScoreOfChallenge.score) && !(highIsBetter ? (info.score > highScoreOfChallenge.score) : (info.score < highScoreOfChallenge.score)))
			{
				return false;
			}
			SetStarOfChallenge(info.challengeName, info.starAttained);
			PlayerPrefs.SetFloat(text + "Score", info.score);
			PlayerPrefs.SetString(text + "ChampionName", info.championName);
			PlayerPrefs.SetString(text + "ChampionPath", info.championFullPath);
			PlayerPrefs.SetString(text + "Time", info.time.ToString("O"));
			PlayerPrefs.Save();
			return true;
		}

		public static void ResetHighscore(string challengeName)
		{
			string text = NameToKey(challengeName);
			PlayerPrefs.SetInt(text + "Star", 0);
			PlayerPrefs.SetFloat(text + "Score", float.NaN);
			PlayerPrefs.SetString(text + "ChampionName", "");
			PlayerPrefs.SetString(text + "ChampionPath", "");
			PlayerPrefs.SetString(text + "Time", "");
		}
	}
}
