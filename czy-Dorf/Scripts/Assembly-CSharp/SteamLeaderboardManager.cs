using System;
using System.Collections.Generic;
using Dorfromantik;
using Steamworks;
using UnityEngine;

public class SteamLeaderboardManager : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public SteamLeaderboardManager _003C_003E4__this;

		public LeaderboardType type;

		internal void _003CFindOrCreateLeaderboard_003Eb__0(LeaderboardFindResult_t t, bool failure)
		{
			_003C_003E4__this.OnLeaderboardFound(t, failure, type);
		}
	}

	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public SteamLeaderboardManager _003C_003E4__this;

		public LeaderboardType type;

		internal void _003CDownloadUserLeaderboardEntry_003Eb__0(LeaderboardScoresDownloaded_t t, bool failure)
		{
			_003C_003E4__this.OnUserLeaderboardEntryDownloaded(t, failure, type);
		}
	}

	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public SteamLeaderboardManager _003C_003E4__this;

		public LeaderboardType leaderboardType;

		internal void _003CSetHighscore_003Eb__0(LeaderboardScoreUploaded_t scoreUploaded, bool failure)
		{
			_003C_003E4__this.OnScoreUploaded(scoreUploaded, failure, leaderboardType);
		}
	}

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private LeaderboardManager leaderboardManager;

	[SerializeField]
	private CustomModeConfiguration customModeConfiguration;

	[SerializeField]
	private TileGenerator tileGenerator;

	private static CallResult<LeaderboardFindResult_t> leaderboardFoundResult = new CallResult<LeaderboardFindResult_t>();

	private static CallResult<LeaderboardScoreUploaded_t> leaderboardUploadResult = new CallResult<LeaderboardScoreUploaded_t>();

	private static CallResult<LeaderboardScoresDownloaded_t> fillLeaderboardDownloadResult = new CallResult<LeaderboardScoresDownloaded_t>();

	private static CallResult<LeaderboardScoresDownloaded_t> globalTopDownloadResult = new CallResult<LeaderboardScoresDownloaded_t>();

	private static CallResult<LeaderboardScoresDownloaded_t> userLeaderboardDownloadResult = new CallResult<LeaderboardScoresDownloaded_t>();

	private float lastUploadedHighscoreTime = -500f;

	private float uploadHighscoreDelay = 120f;

	private Dictionary<string, LeaderboardType> leaderboardTypeById = new Dictionary<string, LeaderboardType>();

	private Dictionary<string, SteamLeaderboard_t> steamLeaderboardById = new Dictionary<string, SteamLeaderboard_t>();

	public event Action<List<LeaderboardEntryData>> OnGlobalTopEntriesReceived;

	private void Start()
	{
		foreach (LeaderboardType allLeaderboard in leaderboardManager.allLeaderboards)
		{
			if (!allLeaderboard.IsNotInitialized)
			{
				leaderboardTypeById.Add(allLeaderboard.GetLeaderboardId(), allLeaderboard);
				FindOrCreateLeaderboard(allLeaderboard);
			}
		}
		rewardSystem.OnLeaderboardUpdateRequested += DownloadUserLeaderboardEntry;
		rewardSystem.OnNewHighscoreSet += SetHighscore;
		customModeConfiguration.OnRequestCurrentTime += SetCurrentTime;
		leaderboardManager.OnRequestShowLeaderboardOverlay += ShowLeaderboardOverlay;
	}

	private void SetCurrentTime()
	{
		if (SteamManager.Initialized)
		{
			DateTime currentRemoteTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(SteamUtils.GetServerRealTime());
			customModeConfiguration.SetCurrentRemoteTime(currentRemoteTime);
		}
	}

	private void FindOrCreateLeaderboard(LeaderboardType type)
	{
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		CS_0024_003C_003E8__locals5.type = type;
		if (!SteamManager.Initialized)
		{
			Debug.LogError("Steam Manager not initialized");
			return;
		}
		SteamAPICall_t hAPICall = SteamUserStats.FindOrCreateLeaderboard(CS_0024_003C_003E8__locals5.type.GetLeaderboardId(), ELeaderboardSortMethod.k_ELeaderboardSortMethodDescending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric);
		new CallResult<LeaderboardFindResult_t>().Set(hAPICall, delegate(LeaderboardFindResult_t t, bool failure)
		{
			CS_0024_003C_003E8__locals5._003C_003E4__this.OnLeaderboardFound(t, failure, CS_0024_003C_003E8__locals5.type);
		});
	}

	private void OnLeaderboardFound(LeaderboardFindResult_t param, bool failure, LeaderboardType type)
	{
		if (failure)
		{
			Debug.Log("failed to find the leaderboard " + type.GetLeaderboardId());
			return;
		}
		string leaderboardId = type.GetLeaderboardId();
		if (steamLeaderboardById.ContainsKey(leaderboardId))
		{
			steamLeaderboardById[leaderboardId] = param.m_hSteamLeaderboard;
		}
		else
		{
			steamLeaderboardById.Add(leaderboardId, param.m_hSteamLeaderboard);
		}
		type.SetURLId(param.m_hSteamLeaderboard.m_SteamLeaderboard);
		DownloadUserLeaderboardEntry(type);
	}

	private void DownloadUserLeaderboardEntry(LeaderboardType type)
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		CS_0024_003C_003E8__locals9.type = type;
		string leaderboardId = CS_0024_003C_003E8__locals9.type.GetLeaderboardId();
		Debug.Log("Download User LeaderboardEntry for " + leaderboardId);
		if (!steamLeaderboardById.ContainsKey(leaderboardId))
		{
			Debug.LogWarning("Leaderboard " + CS_0024_003C_003E8__locals9.type.GetLeaderboardId() + " not initialized");
			if (!CS_0024_003C_003E8__locals9.type.IsNotInitialized)
			{
				FindOrCreateLeaderboard(CS_0024_003C_003E8__locals9.type);
			}
			return;
		}
		Debug.Log($"Download User Leaderboard Entry for {CS_0024_003C_003E8__locals9.type.GetDisplayName()}, steamId {steamLeaderboardById[leaderboardId]}, userId {SteamUser.GetSteamID()}");
		CSteamID steamID = SteamUser.GetSteamID();
		SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntriesForUsers(steamLeaderboardById[leaderboardId], new CSteamID[1] { steamID }, 1);
		new CallResult<LeaderboardScoresDownloaded_t>().Set(hAPICall, delegate(LeaderboardScoresDownloaded_t t, bool failure)
		{
			CS_0024_003C_003E8__locals9._003C_003E4__this.OnUserLeaderboardEntryDownloaded(t, failure, CS_0024_003C_003E8__locals9.type);
		});
	}

	private void OnUserLeaderboardEntryDownloaded(LeaderboardScoresDownloaded_t param, bool failure, LeaderboardType type)
	{
		if (failure || param.m_cEntryCount < 1)
		{
			Debug.Log($"failed to download leaderboard {type} entries {failure}, entry count: {param.m_cEntryCount}");
			return;
		}
		int[] array = new int[8];
		SteamUserStats.GetDownloadedLeaderboardEntry(param.m_hSteamLeaderboardEntries, 0, out var pLeaderboardEntry, array, 8);
		int nGlobalRank = pLeaderboardEntry.m_nGlobalRank;
		Debug.Log($"leaderboard {param.m_hSteamLeaderboard.m_SteamLeaderboard} rank retrieved: {nGlobalRank}, score: {pLeaderboardEntry.m_nScore}");
		rewardSystem.SetLeaderboardRank(type, nGlobalRank);
		rewardSystem.SetLocalHighscore(type, pLeaderboardEntry.m_nScore);
		Debug.Log($"Downloaded User Leaderboard Entry for leaderboard {type.GetLeaderboardId()}; score: {pLeaderboardEntry.m_nScore}; rank: {nGlobalRank}");
		this.OnGlobalTopEntriesReceived?.Invoke(new List<LeaderboardEntryData>
		{
			new LeaderboardEntryData
			{
				name = SteamFriends.GetFriendPersonaName(pLeaderboardEntry.m_steamIDUser),
				score = pLeaderboardEntry.m_nScore,
				rank = pLeaderboardEntry.m_nGlobalRank,
				checkScore = array[0],
				level = array[1],
				questsFulfilled = array[2],
				questsFailed = array[3],
				perfectPlacements = array[4],
				tilesPlaced = array[5],
				playtime = ((array.Length > 6) ? array[6] : (-1)),
				tileGenerationSeed = ((array.Length > 7) ? array[7] : (-1))
			}
		});
	}

	public void GetGlobalTopLeaderboard(LeaderboardType leaderboardType, int count)
	{
		string leaderboardId = leaderboardType.GetLeaderboardId();
		if (!steamLeaderboardById.ContainsKey(leaderboardId))
		{
			if (!leaderboardType.IsNotInitialized)
			{
				FindOrCreateLeaderboard(leaderboardType);
			}
			Debug.LogError("Leaderboard not initialized");
		}
		else
		{
			SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntries(steamLeaderboardById[leaderboardId], ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, 0, count);
			globalTopDownloadResult.Set(hAPICall, OnGlobalTopEntriesDownloaded);
		}
	}

	private void OnGlobalTopEntriesDownloaded(LeaderboardScoresDownloaded_t param, bool failure)
	{
		if (failure)
		{
			Debug.Log("failed to download leaderboard entries");
			return;
		}
		List<LeaderboardEntryData> list = new List<LeaderboardEntryData>();
		for (int i = 0; i < param.m_cEntryCount; i++)
		{
			int[] array = new int[7];
			SteamUserStats.GetDownloadedLeaderboardEntry(param.m_hSteamLeaderboardEntries, i, out var pLeaderboardEntry, array, 8);
			list.Add(new LeaderboardEntryData
			{
				name = SteamFriends.GetFriendPersonaName(pLeaderboardEntry.m_steamIDUser),
				score = pLeaderboardEntry.m_nScore,
				rank = pLeaderboardEntry.m_nGlobalRank,
				checkScore = array[0],
				level = array[1],
				questsFulfilled = array[2],
				questsFailed = array[3],
				perfectPlacements = array[4],
				tilesPlaced = array[5],
				playtime = array[6],
				steamId = pLeaderboardEntry.m_steamIDUser.m_SteamID,
				tileGenerationSeed = ((array.Length > 7) ? array[7] : (-1))
			});
		}
		this.OnGlobalTopEntriesReceived?.Invoke(list);
	}

	private void DebugSteamTime()
	{
		DateTime value = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(SteamUtils.GetServerRealTime());
		Debug.Log("Steam Time: " + value.ToLongDateString() + " " + value.ToLongTimeString() + "\nUTC Time: " + DateTime.UtcNow.ToLongDateString() + " " + DateTime.UtcNow.ToLongTimeString());
		TimeSpan timeSpan = DateTime.UtcNow.Subtract(value).Duration();
		Debug.Log($"Difference: [Days] {timeSpan.Days} [Hours] {timeSpan.Hours} [Seconds] {timeSpan.Seconds}");
	}

	private void SetHighscore(LeaderboardType leaderboardType, int score, bool forceUpdate)
	{
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass25_0();
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		CS_0024_003C_003E8__locals9.leaderboardType = leaderboardType;
		string leaderboardId = CS_0024_003C_003E8__locals9.leaderboardType.GetLeaderboardId();
		if (!steamLeaderboardById.ContainsKey(leaderboardId))
		{
			Debug.LogError($"leaderboard {CS_0024_003C_003E8__locals9.leaderboardType} not initialized");
			if (!CS_0024_003C_003E8__locals9.leaderboardType.IsNotInitialized)
			{
				FindOrCreateLeaderboard(CS_0024_003C_003E8__locals9.leaderboardType);
			}
		}
		else if (forceUpdate || Time.time > lastUploadedHighscoreTime + uploadHighscoreDelay)
		{
			lastUploadedHighscoreTime = Time.time;
			GameMode gameMode = OverwritingSingleton<GameSession>.Instance.GameMode;
			LeaderboardEntryData leaderboardEntryData = new LeaderboardEntryData
			{
				score = score,
				level = rewardSystem.Level,
				questsFulfilled = rewardSystem.QuestFulfilledCount,
				questsFailed = rewardSystem.QuestFailedCount,
				perfectPlacements = rewardSystem.PerfectPlacementCount,
				tilesPlaced = OverwritingSingleton<IngameUi>.Instance.world.GetAllPlacedTiles().Count,
				playtime = Mathf.RoundToInt(rewardSystem.Playtime),
				tileGenerationSeed = tileGenerator.TileGenerationSeed,
				gameModeId = gameMode.id,
				tileLimit = Mathf.RoundToInt(gameMode.usesCustomConfiguration ? customModeConfiguration.GetValue(CustomRuleType.TileLimit) : (-1f)),
				worldBorder = Mathf.RoundToInt(gameMode.usesCustomConfiguration ? customModeConfiguration.GetValue(CustomRuleType.WorldBorderRadius) : (-1f)),
				configString = (gameMode.usesCustomConfiguration ? customModeConfiguration.configString : ""),
				year = (gameMode.usesCustomConfiguration ? customModeConfiguration.year : (-1)),
				month = (gameMode.usesCustomConfiguration ? customModeConfiguration.month : (-1))
			};
			if (!BasicSteamLeaderboardValidator.IsScoreValid(leaderboardEntryData, out var _))
			{
				Debug.Log("not uploading, score is invalid");
				return;
			}
			if (OverwritingSingleton<GameSession>.Instance.GameMode.usesCustomConfiguration && !customModeConfiguration.IsScoreValid(leaderboardEntryData))
			{
				Debug.Log("not uploading, Custom Mode score is invalid");
				return;
			}
			int[] array = new int[8] { leaderboardEntryData.score, leaderboardEntryData.level, leaderboardEntryData.questsFulfilled, leaderboardEntryData.questsFailed, leaderboardEntryData.perfectPlacements, leaderboardEntryData.tilesPlaced, leaderboardEntryData.playtime, leaderboardEntryData.tileGenerationSeed };
			Debug.Log($"uploading highscore {score} on {CS_0024_003C_003E8__locals9.leaderboardType}");
			SteamAPICall_t hAPICall = SteamUserStats.UploadLeaderboardScore(steamLeaderboardById[leaderboardId], ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest, score, array, array.Length);
			leaderboardUploadResult.Set(hAPICall, delegate(LeaderboardScoreUploaded_t scoreUploaded, bool failure)
			{
				CS_0024_003C_003E8__locals9._003C_003E4__this.OnScoreUploaded(scoreUploaded, failure, CS_0024_003C_003E8__locals9.leaderboardType);
			});
		}
		else
		{
			Debug.Log($"not uploading highscore || {Time.time} > {lastUploadedHighscoreTime + uploadHighscoreDelay}");
		}
	}

	private void OnScoreUploaded(LeaderboardScoreUploaded_t param, bool failure, LeaderboardType leaderboardType)
	{
		Debug.Log($"score {param.m_nScore} was uploaded to leaderboard {leaderboardType} - success? {!failure}");
		rewardSystem.SetLeaderboardRank(leaderboardType, param.m_nGlobalRankNew);
		rewardSystem.SetLocalHighscore(leaderboardType, param.m_nScore);
	}

	private void ShowLeaderboardOverlay(LeaderboardType currentLeaderboard)
	{
		if ((bool)currentLeaderboard)
		{
			Debug.Log(string.Format("Show Steam Leaderboard {0} - {1}/{2}", currentLeaderboard, "https://steamcommunity.com/stats/1455840/leaderboards", currentLeaderboard.GetUrl()));
			SteamOverlayOpener.OpenURLInSteamOverlay(string.Format("{0}/{1}", "https://steamcommunity.com/stats/1455840/leaderboards", currentLeaderboard.GetUrl()));
		}
	}

	private void OnDestroy()
	{
		rewardSystem.OnNewHighscoreSet -= SetHighscore;
		rewardSystem.OnLeaderboardUpdateRequested -= DownloadUserLeaderboardEntry;
		customModeConfiguration.OnRequestCurrentTime -= SetCurrentTime;
		leaderboardManager.OnRequestShowLeaderboardOverlay -= ShowLeaderboardOverlay;
	}
}
