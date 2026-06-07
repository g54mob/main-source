using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Motorways.Leaderboards;
using Steamworks;
using Steamworks.Data;

public static class SteamworksShared
{
	private static readonly LeaderboardError UnknownError = new LeaderboardError(LeaderboardErrorCode.Unknown, StringId.LeaderboardError_Generic);

	private static readonly LeaderboardError NotAuthenticatedError = new LeaderboardError(LeaderboardErrorCode.Unknown, StringId.LeaderboardError_Generic);

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("SteamworksApi");

	private const int PerAttemptQueryCount = 20;

	private const int MaxAttemptsToFilterScores = 10;

	private const int MaximumScore = 200000;

	public static bool IsValid => SteamClient.IsValid;

	public static bool RestartAppIfNecessary(uint appId)
	{
		bool result = false;
		try
		{
			result = SteamClient.RestartAppIfNecessary(appId);
		}
		catch (Exception arg)
		{
			Log.Error($"Caught Exception : {arg}");
		}
		return result;
	}

	public static bool Init(uint appId)
	{
		try
		{
			SteamClient.Init(appId);
			SteamUserStats.RequestCurrentStats();
		}
		catch (Exception arg)
		{
			Log.Error($"Caught Exception : {arg}");
		}
		return IsValid;
	}

	public static void Shutdown()
	{
		SteamClient.Shutdown();
	}

	public static void RunCallbacks()
	{
		SteamClient.RunCallbacks();
	}

	public static async void RequestLocalLeaderboardEntry(string leaderboardName, LocalEntryRequestCompleted localEntryRequestCompleted)
	{
		if (!IsValid)
		{
			localEntryRequestCompleted(null, 0L, NotAuthenticatedError);
			return;
		}
		Leaderboard? leaderboard = await GetLeaderboard(leaderboardName);
		if (!Diagnostics.Verify(leaderboard.HasValue, "Unable to find leaderboard {0}", leaderboardName))
		{
			localEntryRequestCompleted(null, 0L, UnknownError);
			return;
		}
		Steamworks.Data.LeaderboardEntry[] array = await leaderboard.Value.GetScoresAroundUserAsync(0, 0);
		LeaderboardEntry localEntry = ((array == null || array.Length == 0) ? null : ToLeaderboardEntry(array[0]));
		localEntryRequestCompleted(localEntry, leaderboard.Value.EntryCount, null);
	}

	public static async void SubmitScore(LeaderboardId leaderboardId, string leaderboardName, int score, LeaderboardScoreState scoreState, SubmitScoreRequestCompleted onCompleted)
	{
		if (!IsValid)
		{
			onCompleted(submittedSuccessfully: false);
			return;
		}
		Leaderboard? leaderboard = await GetLeaderboard(leaderboardName);
		LeaderboardUpdate? leaderboardUpdate = null;
		if (Diagnostics.Verify(leaderboard.HasValue, "Unable to find leaderboard {0}", leaderboardName))
		{
			int num = LeaderboardService.EncodeScoreContext(leaderboardId, scoreState);
			int[] details = new int[1] { num };
			leaderboardUpdate = ((scoreState != LeaderboardScoreState.Locked) ? (await leaderboard.Value.SubmitScoreAsync(score, details)) : (await leaderboard.Value.ReplaceScore(score, details)));
		}
		onCompleted(leaderboardUpdate.HasValue);
	}

	public static async void RequestTopLeaderboardEntries(string leaderboardName, int entryCount, EntryRequestCompleted entryRequestCompleted)
	{
		if (!IsValid)
		{
			entryRequestCompleted(null, 0L, NotAuthenticatedError);
			return;
		}
		Leaderboard? leaderboard = await GetLeaderboard(leaderboardName);
		if (!Diagnostics.Verify(leaderboard.HasValue, "Unable to findOrCreate leaderboard {0}", leaderboardName))
		{
			entryRequestCompleted(null, 0L, UnknownError);
			return;
		}
		List<Steamworks.Data.LeaderboardEntry> filteredLeaderboardEntries = new List<Steamworks.Data.LeaderboardEntry>(entryCount);
		for (int attemptIndex = 0; attemptIndex < 10; attemptIndex++)
		{
			if (filteredLeaderboardEntries.Count >= entryCount)
			{
				break;
			}
			Steamworks.Data.LeaderboardEntry[] array = await leaderboard.Value.GetScoresAsync(20, attemptIndex * 21 + 1);
			if (array == null)
			{
				break;
			}
			Steamworks.Data.LeaderboardEntry[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Steamworks.Data.LeaderboardEntry item = array2[i];
				Friend user = item.User;
				int num;
				if (!user.IsMe)
				{
					user = item.User;
					num = (user.IsFriend ? 1 : 0);
				}
				else
				{
					num = 1;
				}
				if (num != 0 || item.Score < 200000)
				{
					filteredLeaderboardEntries.Add(item);
				}
				if (filteredLeaderboardEntries.Count >= entryCount)
				{
					break;
				}
			}
			if (array.Length < 20)
			{
				break;
			}
		}
		List<LeaderboardEntry> list = new List<LeaderboardEntry>(filteredLeaderboardEntries.Count);
		for (int j = 0; j < filteredLeaderboardEntries.Count; j++)
		{
			LeaderboardEntry item2 = ToLeaderboardEntry(filteredLeaderboardEntries[j], j + 1);
			list.Add(item2);
		}
		entryRequestCompleted(list, leaderboard.Value.EntryCount, null);
	}

	public static async void RequestPlayerCenteredLeaderboardEntries(string leaderboardName, int entryCount, EntryRequestCompleted entryRequestCompleted)
	{
		if (!IsValid)
		{
			entryRequestCompleted(null, 0L, NotAuthenticatedError);
			return;
		}
		Leaderboard? leaderboard = await GetLeaderboard(leaderboardName);
		if (!Diagnostics.Verify(leaderboard.HasValue, "Unable to findOrCreate leaderboard {0}", leaderboardName))
		{
			entryRequestCompleted(null, 0L, UnknownError);
			return;
		}
		List<Steamworks.Data.LeaderboardEntry> filteredLeaderboardEntries = new List<Steamworks.Data.LeaderboardEntry>(entryCount);
		int num = entryCount / 2;
		int attemptIndex = 0;
		int start = -num;
		int end = num;
		int removedScoreCount = 0;
		for (; attemptIndex < 10; attemptIndex++)
		{
			if (filteredLeaderboardEntries.Count >= entryCount)
			{
				break;
			}
			Steamworks.Data.LeaderboardEntry[] array = await leaderboard.Value.GetScoresAroundUserAsync(start, end);
			if (array == null)
			{
				break;
			}
			Steamworks.Data.LeaderboardEntry[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Steamworks.Data.LeaderboardEntry item = array2[i];
				Friend user = item.User;
				int num2;
				if (!user.IsMe)
				{
					user = item.User;
					num2 = (user.IsFriend ? 1 : 0);
				}
				else
				{
					num2 = 1;
				}
				if (num2 != 0 || item.Score < 200000)
				{
					filteredLeaderboardEntries.Add(item);
				}
				else
				{
					removedScoreCount++;
				}
				if (filteredLeaderboardEntries.Count > entryCount)
				{
					break;
				}
			}
			if (array.Length < entryCount)
			{
				break;
			}
			start = end + 1;
			end = end + 20 + 1;
		}
		Steamworks.Data.LeaderboardEntry? leaderboardEntry = null;
		int num3 = 0;
		for (int j = 0; j < filteredLeaderboardEntries.Count; j++)
		{
			Steamworks.Data.LeaderboardEntry value = filteredLeaderboardEntries[j];
			if (value.User.IsMe)
			{
				leaderboardEntry = value;
				num3 = j;
			}
		}
		List<LeaderboardEntry> list = new List<LeaderboardEntry>(filteredLeaderboardEntries.Count);
		if (leaderboardEntry.HasValue)
		{
			for (int k = 0; k < filteredLeaderboardEntries.Count; k++)
			{
				Steamworks.Data.LeaderboardEntry steamworksEntry = filteredLeaderboardEntries[k];
				int num4 = leaderboardEntry.Value.GlobalRank - removedScoreCount + (k - num3);
				LeaderboardEntry item2 = ToLeaderboardEntry(steamworksEntry, num4);
				list.Add(item2);
			}
			entryRequestCompleted(list, leaderboard.Value.EntryCount, null);
		}
		else
		{
			RequestTopLeaderboardEntries(leaderboardName, entryCount, delegate(List<LeaderboardEntry> topScores, long totalLeaderboardEntryCount, LeaderboardError error)
			{
				entryRequestCompleted(topScores, totalLeaderboardEntryCount, null);
			});
		}
	}

	public static async void RequestTopFriendLeaderboardEntries(string leaderboardName, int entryCount, EntryRequestCompleted entryRequestCompleted)
	{
		if (!IsValid)
		{
			entryRequestCompleted(null, 0L, NotAuthenticatedError);
			return;
		}
		Leaderboard? leaderboard = await GetLeaderboard(leaderboardName);
		if (!Diagnostics.Verify(leaderboard.HasValue, "Unable to findOrCreate leaderboard {0}", leaderboardName))
		{
			entryRequestCompleted(null, 0L, UnknownError);
			return;
		}
		Steamworks.Data.LeaderboardEntry[] array = await leaderboard.Value.GetScoresFromFriendsAsync();
		List<LeaderboardEntry> list = new List<LeaderboardEntry>((array != null) ? array.Length : 0);
		if (array != null)
		{
			Steamworks.Data.LeaderboardEntry[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				LeaderboardEntry item = ToLeaderboardEntry(array2[i]);
				list.Add(item);
			}
		}
		entryRequestCompleted(list, leaderboard.Value.EntryCount, null);
	}

	private static LeaderboardEntry ToLeaderboardEntry(Steamworks.Data.LeaderboardEntry steamworksEntry, long? rankOverride = null)
	{
		LeaderboardEntryType type = LeaderboardEntryType.Global;
		if (steamworksEntry.User.IsMe)
		{
			type = LeaderboardEntryType.Local;
		}
		else if (steamworksEntry.User.IsFriend)
		{
			type = LeaderboardEntryType.Friend;
		}
		LeaderboardScoreState scoreState = LeaderboardScoreState.Editable;
		int timeStamp = 0;
		if (steamworksEntry.Details != null)
		{
			LeaderboardService.DecodeScoreContext(steamworksEntry.Details[0], out timeStamp, out scoreState);
		}
		return new LeaderboardEntry(steamworksEntry.User.Id.ToString(), steamworksEntry.User.Name, type, steamworksEntry.Score, rankOverride ?? steamworksEntry.GlobalRank, timeStamp, scoreState);
	}

	private static Task<Leaderboard?> GetLeaderboard(string leaderboardName)
	{
		return SteamUserStats.FindOrCreateLeaderboardAsync(leaderboardName, LeaderboardSort.Descending, LeaderboardDisplay.Numeric);
	}

	public static bool SaveScreenshot(byte[] bytes, int width, int height)
	{
		if (!IsValid)
		{
			return false;
		}
		return SteamScreenshots.WriteScreenshot(bytes, width, height).HasValue;
	}

	public static void SetRichPresence(Dictionary<string, string> tokens)
	{
		if (!IsValid)
		{
			return;
		}
		if (tokens == null || tokens.Count == 0)
		{
			SteamFriends.ClearRichPresence();
			return;
		}
		foreach (KeyValuePair<string, string> token in tokens)
		{
			SteamFriends.SetRichPresence(token.Key, token.Value);
		}
	}

	public static bool CompleteAchievement(string name)
	{
		if (!IsValid)
		{
			return false;
		}
		if (TryFindAchievement(name, out var result))
		{
			if (result.State)
			{
				return true;
			}
			return result.Trigger();
		}
		return false;
	}

	public static bool ClearAchievement(string name)
	{
		if (!IsValid)
		{
			return false;
		}
		if (TryFindAchievement(name, out var result) && result.State)
		{
			return result.Clear();
		}
		return false;
	}

	public static bool IsAchievementCompleted(string name)
	{
		if (!IsValid)
		{
			return false;
		}
		if (TryFindAchievement(name, out var result))
		{
			return result.State;
		}
		return false;
	}

	public static bool IncrementStatistic(string statisticId, int amount)
	{
		if (!IsValid)
		{
			return false;
		}
		SteamUserStats.AddStat(statisticId, amount);
		return false;
	}

	public static byte[] ReadCloudFile(string filename)
	{
		if (!IsValid)
		{
			return null;
		}
		return SteamRemoteStorage.FileRead(filename);
	}

	public static bool WriteCloudFile(string filename, byte[] data)
	{
		if (!IsValid)
		{
			return false;
		}
		return SteamRemoteStorage.FileWrite(filename, data);
	}

	public static bool DeleteCloudFile(string filename)
	{
		if (!IsValid)
		{
			return false;
		}
		return SteamRemoteStorage.FileDelete(filename);
	}

	public static IEnumerable<string> GetCloudFiles()
	{
		if (!IsValid)
		{
			yield break;
		}
		foreach (string file in SteamRemoteStorage.Files)
		{
			yield return file;
		}
	}

	public static LocaleDatabase.LocaleId GetLocaleId()
	{
		if (!IsValid)
		{
			return LocaleDatabase.LocaleId.Unknown;
		}
		switch (SteamApps.GameLanguage)
		{
		case "arabic":
			return LocaleDatabase.LocaleId.ar;
		case "bulgarian":
			return LocaleDatabase.LocaleId.bg;
		case "schinese":
			return LocaleDatabase.LocaleId.zh_CN;
		case "tchinese":
			return LocaleDatabase.LocaleId.zh_TW;
		case "czech":
			return LocaleDatabase.LocaleId.cs;
		case "danish":
			return LocaleDatabase.LocaleId.da;
		case "dutch":
			return LocaleDatabase.LocaleId.nl;
		case "english":
			return LocaleDatabase.LocaleId.en_US;
		case "finnish":
			return LocaleDatabase.LocaleId.fi;
		case "french":
			return LocaleDatabase.LocaleId.fr;
		case "german":
			return LocaleDatabase.LocaleId.de;
		case "greek":
			return LocaleDatabase.LocaleId.el;
		case "hungarian":
			return LocaleDatabase.LocaleId.hu;
		case "italian":
			return LocaleDatabase.LocaleId.it;
		case "japanese":
			return LocaleDatabase.LocaleId.ja;
		case "koreana":
			return LocaleDatabase.LocaleId.ko;
		case "norwegian":
			return LocaleDatabase.LocaleId.no;
		case "polish":
			return LocaleDatabase.LocaleId.pl;
		case "portuguese":
			return LocaleDatabase.LocaleId.pt_PT;
		case "brazilian":
			return LocaleDatabase.LocaleId.pt_BR;
		case "romanian":
			return LocaleDatabase.LocaleId.en_US;
		case "russian":
			return LocaleDatabase.LocaleId.ru;
		case "spanish":
			return LocaleDatabase.LocaleId.es_ES;
		case "latam":
			return LocaleDatabase.LocaleId.es_MX;
		case "swedish":
			return LocaleDatabase.LocaleId.sv_SE;
		case "thai":
			return LocaleDatabase.LocaleId.th;
		case "turkish":
			return LocaleDatabase.LocaleId.tr;
		case "ukrainian":
			return LocaleDatabase.LocaleId.uk;
		case "vietnamese":
			return LocaleDatabase.LocaleId.en_US;
		default:
			Log.Warn("Encountered unrecognised language code '{0}'.", SteamApps.GameLanguage);
			return LocaleDatabase.LocaleId.Unknown;
		}
	}

	private static bool TryFindAchievement(string name, out Steamworks.Data.Achievement result)
	{
		foreach (Steamworks.Data.Achievement achievement in SteamUserStats.Achievements)
		{
			if (achievement.Identifier == name)
			{
				result = achievement;
				return true;
			}
		}
		return false;
	}
}
