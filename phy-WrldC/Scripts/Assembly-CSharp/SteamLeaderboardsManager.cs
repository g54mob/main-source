using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Steamworks;
using UnityEngine;

public class SteamLeaderboardsManager : MonoBehaviour
{
	public struct UserScoreData
	{
		public ulong userId;

		public string userName;

		public int rank;

		public int score;

		public int time;

		public int blocks;

		public int cost;

		public int weight;

		public int difficult;

		public LeaderboardType leadboardType;

		public bool isCurrentUser;
	}

	public struct BestUserData
	{
		public ulong userId;

		public string userName;

		public int score;

		public int goldMedal;

		public int silverMedal;

		public int bronzeMedal;

		public bool isCurrentUser;
	}

	private static CallResult<LeaderboardFindResult_t> leaderboardFindResult;

	private static CallResult<LeaderboardScoreUploaded_t> leaderboardScoreUploaded;

	private static CallResult<LeaderboardScoresDownloaded_t> leaderboardScoresDownloaded;

	private bool isDownloadingBestUsersScores;

	private bool shouldAbortDownloadBestUsersScores;

	private Action callbackOnAborted;

	public static SteamLeaderboardsManager Instance => Singleton<SteamLeaderboardsManager>.Instance;

	public static bool Exist => Singleton<SteamLeaderboardsManager>.Exist;

	public bool IsUploadFinished { get; private set; }

	public event Action<bool, int, int> OnNewScoreUploadedEvent;

	public event Action<List<UserScoreData>> OnScoresDownloadedEvent;

	public event Action<List<BestUserData>> OnBestUsersScoresDownloadedEvent;

	public event Action<int, int, List<BestUserData>> OnBestUsersScoresDownloadingEvent;

	public event Action OnNewScoreFailedUploadEvent;

	public event Action OnLeaderboardNotFoundEvent;

	public event Action OnLeaderboardFailedDownloadEvent;

	private void Awake()
	{
		leaderboardScoreUploaded = new CallResult<LeaderboardScoreUploaded_t>();
		leaderboardFindResult = new CallResult<LeaderboardFindResult_t>();
		leaderboardScoresDownloaded = new CallResult<LeaderboardScoresDownloaded_t>();
		isDownloadingBestUsersScores = false;
		shouldAbortDownloadBestUsersScores = false;
	}

	public void UploadScore(string levelId, LeaderboardType type, LeaderboardDifficult difficult, int time, int blocks, int cost, int weight, int realDifficult)
	{
		IsUploadFinished = false;
		string leaderboardId = GetLeaderboardId(levelId, type, difficult);
		int[] details = new int[5] { time, blocks, cost, weight, realDifficult };
		int score = details[(int)type];
		SteamAPICall_t hAPICall = SteamUserStats.FindOrCreateLeaderboard(leaderboardId, ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric);
		leaderboardFindResult.Set(hAPICall, OnLeaderboardFindResult);
		void OnLeaderboardFindResult(LeaderboardFindResult_t pCallback, bool bIOFailure)
		{
			Debug.Log($"STEAM LEADERBOARDS: Failure: {bIOFailure}, Found: {pCallback.m_bLeaderboardFound}, LeaderboardID: {pCallback.m_hSteamLeaderboard.m_SteamLeaderboard}");
			if (bIOFailure || pCallback.m_bLeaderboardFound != 1)
			{
				this.OnNewScoreFailedUploadEvent?.Invoke();
				IsUploadFinished = true;
			}
			else
			{
				SteamAPICall_t hAPICall2 = SteamUserStats.UploadLeaderboardScore(pCallback.m_hSteamLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest, score, details, details.Length);
				leaderboardScoreUploaded.Set(hAPICall2, OnLeaderboardUploadResult);
			}
		}
		void OnLeaderboardUploadResult(LeaderboardScoreUploaded_t pCallback, bool bIOFailure)
		{
			Debug.Log($"STEAM LEADERBOARDS: Failure: {bIOFailure}, Completed: {pCallback.m_bSuccess}, NewScore: {pCallback.m_nGlobalRankNew}, Score: {pCallback.m_nScore}, HasChanged: {pCallback.m_bScoreChanged}");
			if (bIOFailure || pCallback.m_bSuccess != 1)
			{
				this.OnNewScoreFailedUploadEvent?.Invoke();
				IsUploadFinished = true;
			}
			else
			{
				this.OnNewScoreUploadedEvent?.Invoke(pCallback.m_bScoreChanged == 1, pCallback.m_nGlobalRankPrevious, pCallback.m_nGlobalRankNew);
				IsUploadFinished = true;
			}
		}
	}

	public void DownloadScores(string levelId, LeaderboardType type, LeaderboardDifficult difficult, LeaderboardList list)
	{
		SteamAPICall_t hAPICall = SteamUserStats.FindLeaderboard(GetLeaderboardId(levelId, type, difficult));
		leaderboardFindResult.Set(hAPICall, OnLeaderboardFindResult);
		void OnLeaderboardFindResult(LeaderboardFindResult_t pCallback, bool bIOFailure)
		{
			Debug.Log($"STEAM LEADERBOARDS: Failure: {bIOFailure}, Found: {pCallback.m_bLeaderboardFound}, LeaderboardID: {pCallback.m_hSteamLeaderboard.m_SteamLeaderboard}");
			if (bIOFailure || pCallback.m_bLeaderboardFound != 1)
			{
				this.OnLeaderboardNotFoundEvent?.Invoke();
			}
			else
			{
				ELeaderboardDataRequest eLeaderboardDataRequest = ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser;
				int num = 1;
				int num2 = 10;
				switch (list)
				{
				case LeaderboardList.Personal:
					eLeaderboardDataRequest = ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser;
					num = -4;
					num2 = 5;
					break;
				case LeaderboardList.Friends:
					eLeaderboardDataRequest = ELeaderboardDataRequest.k_ELeaderboardDataRequestFriends;
					num = 1;
					num2 = 10;
					break;
				case LeaderboardList.Top10:
					eLeaderboardDataRequest = ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal;
					num = 1;
					num2 = 10;
					break;
				default:
					eLeaderboardDataRequest = ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser;
					num = -4;
					num2 = 5;
					break;
				}
				SteamAPICall_t hAPICall2 = SteamUserStats.DownloadLeaderboardEntries(pCallback.m_hSteamLeaderboard, eLeaderboardDataRequest, num, num2);
				leaderboardScoresDownloaded.Set(hAPICall2, OnLeaderboardScoresDownloadedResult);
			}
		}
		void OnLeaderboardScoresDownloadedResult(LeaderboardScoresDownloaded_t pCallback, bool bIOFailure)
		{
			Debug.Log($"STEAM LEADERBOARDS: Failure: {bIOFailure}, EntryCount: {pCallback.m_cEntryCount}");
			if (bIOFailure)
			{
				this.OnLeaderboardFailedDownloadEvent?.Invoke();
			}
			else
			{
				List<UserScoreData> list2 = new List<UserScoreData>();
				for (int i = 0; i < pCallback.m_cEntryCount; i++)
				{
					int[] array = new int[5];
					if (SteamUserStats.GetDownloadedLeaderboardEntry(pCallback.m_hSteamLeaderboardEntries, i, out var pLeaderboardEntry, array, 5))
					{
						string friendPersonaName = SteamFriends.GetFriendPersonaName(pLeaderboardEntry.m_steamIDUser);
						string personaName = SteamFriends.GetPersonaName();
						list2.Add(new UserScoreData
						{
							userId = pLeaderboardEntry.m_steamIDUser.m_SteamID,
							userName = friendPersonaName,
							rank = pLeaderboardEntry.m_nGlobalRank,
							score = pLeaderboardEntry.m_nScore,
							leadboardType = type,
							time = array[0],
							blocks = array[1],
							cost = array[2],
							weight = array[3],
							difficult = array[4],
							isCurrentUser = (friendPersonaName == personaName)
						});
					}
				}
				this.OnScoresDownloadedEvent?.Invoke(list2);
			}
		}
	}

	public void DownloadBestUsersScores(string[] levelIds, LeaderboardType leaderboardType, LeaderboardDifficult leaderboardDifficult)
	{
		isDownloadingBestUsersScores = true;
		Dictionary<ulong, BestUserData> bestUserDatasMap = new Dictionary<ulong, BestUserData>();
		string currentLevelId = string.Empty;
		bool isLeaderboardFinished;
		StartCoroutine(GetBestUsersScores());
		IEnumerator GetBestUsersScores()
		{
			for (int i = 0; i < levelIds.Length; i++)
			{
				isLeaderboardFinished = false;
				currentLevelId = levelIds[i];
				SteamAPICall_t hAPICall = SteamUserStats.FindLeaderboard(GetLeaderboardId(currentLevelId, leaderboardType, leaderboardDifficult));
				leaderboardFindResult.Set(hAPICall, OnLeaderboardFindResult);
				while (!isLeaderboardFinished)
				{
					yield return new WaitForEndOfFrame();
				}
				if (shouldAbortDownloadBestUsersScores)
				{
					shouldAbortDownloadBestUsersScores = false;
					callbackOnAborted?.Invoke();
					yield break;
				}
				this.OnBestUsersScoresDownloadingEvent?.Invoke(i + 1, levelIds.Length, bestUserDatasMap.Values.ToList());
			}
			this.OnBestUsersScoresDownloadedEvent?.Invoke(bestUserDatasMap.Values.ToList());
			isDownloadingBestUsersScores = false;
		}
		void OnLeaderboardFindResult(LeaderboardFindResult_t pCallback, bool bIOFailure)
		{
			Debug.Log($"STEAM LEADERBOARDS: Failure: {bIOFailure}, Found: {pCallback.m_bLeaderboardFound}, LeaderboardID: {pCallback.m_hSteamLeaderboard.m_SteamLeaderboard}");
			if (bIOFailure || pCallback.m_bLeaderboardFound != 1)
			{
				isLeaderboardFinished = true;
				Debug.LogError($"Failed to find result: LevelID: {currentLevelId}, LeaderboardID: {pCallback.m_hSteamLeaderboard.m_SteamLeaderboard}");
			}
			else
			{
				ELeaderboardDataRequest eLeaderboardDataRequest = ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal;
				int nRangeStart = 1;
				int nRangeEnd = 3;
				SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntries(pCallback.m_hSteamLeaderboard, eLeaderboardDataRequest, nRangeStart, nRangeEnd);
				leaderboardScoresDownloaded.Set(hAPICall, OnLeaderboardScoresDownloadedResult);
			}
		}
		void OnLeaderboardScoresDownloadedResult(LeaderboardScoresDownloaded_t pCallback, bool bIOFailure)
		{
			Debug.Log($"STEAM LEADERBOARDS: Failure: {bIOFailure}, EntryCount: {pCallback.m_cEntryCount}");
			if (bIOFailure)
			{
				isLeaderboardFinished = true;
				Debug.LogError($"Failed to download result: LevelID: {currentLevelId}, LeaderboardID: {pCallback.m_hSteamLeaderboard.m_SteamLeaderboard}");
			}
			else
			{
				for (int i = 0; i < pCallback.m_cEntryCount; i++)
				{
					if (SteamUserStats.GetDownloadedLeaderboardEntry(pCallback.m_hSteamLeaderboardEntries, i, out var pLeaderboardEntry, null, 0))
					{
						ulong steamID = pLeaderboardEntry.m_steamIDUser.m_SteamID;
						if (!bestUserDatasMap.ContainsKey(steamID))
						{
							string friendPersonaName = SteamFriends.GetFriendPersonaName(pLeaderboardEntry.m_steamIDUser);
							string personaName = SteamFriends.GetPersonaName();
							BestUserData value = new BestUserData
							{
								userId = steamID,
								userName = friendPersonaName,
								score = 0,
								goldMedal = 0,
								silverMedal = 0,
								bronzeMedal = 0,
								isCurrentUser = (friendPersonaName == personaName)
							};
							bestUserDatasMap.Add(steamID, value);
						}
						BestUserData value2 = bestUserDatasMap[steamID];
						if (i == 0)
						{
							value2.goldMedal++;
							value2.score += 3;
						}
						if (i == 1)
						{
							value2.silverMedal++;
							value2.score += 2;
						}
						if (i == 2)
						{
							value2.bronzeMedal++;
							value2.score++;
						}
						bestUserDatasMap[steamID] = value2;
					}
				}
				isLeaderboardFinished = true;
			}
		}
	}

	public void AbortDownloadBestUsersScores(Action callbackOnAborted = null)
	{
		shouldAbortDownloadBestUsersScores = isDownloadingBestUsersScores;
		if (!isDownloadingBestUsersScores)
		{
			callbackOnAborted?.Invoke();
		}
		this.callbackOnAborted = callbackOnAborted;
	}

	public Texture2D GetUserProfileImage(ulong steamId)
	{
		int smallFriendAvatar = SteamFriends.GetSmallFriendAvatar(new CSteamID(steamId));
		if (smallFriendAvatar == 0)
		{
			return null;
		}
		if (SteamUtils.GetImageSize(smallFriendAvatar, out var pnWidth, out var pnHeight))
		{
			byte[] array = new byte[pnWidth * pnHeight * 4];
			if (SteamUtils.GetImageRGBA(smallFriendAvatar, array, array.Length))
			{
				Texture2D texture2D = new Texture2D((int)pnWidth, (int)pnHeight, TextureFormat.RGBA32, mipChain: false, linear: true);
				texture2D.LoadRawTextureData(array);
				texture2D.Apply();
				return texture2D;
			}
		}
		return null;
	}

	private string GetLeaderboardId(string levelId, LeaderboardType leaderboardType, LeaderboardDifficult leaderboardDifficult)
	{
		string text = levelId;
		switch (leaderboardType)
		{
		case LeaderboardType.Time:
			text += "_t";
			break;
		case LeaderboardType.Blocks:
			text += "_b";
			break;
		case LeaderboardType.Cost:
			text += "_c";
			break;
		case LeaderboardType.Weight:
			text += "_w";
			break;
		default:
			text += "_t";
			break;
		}
		switch (leaderboardDifficult)
		{
		case LeaderboardDifficult.ZeroStar:
			text += "_0";
			break;
		case LeaderboardDifficult.OneStar:
			text += "_1";
			break;
		case LeaderboardDifficult.TwoStar:
			text += "_2";
			break;
		case LeaderboardDifficult.ThreeStar:
			text += "_3";
			break;
		}
		return text;
	}

	public LeaderboardDifficult GetLeaderboardDifficult(bool isPickedUpAllGold, bool isPickedUpAllSilver)
	{
		if (isPickedUpAllGold && isPickedUpAllSilver)
		{
			return LeaderboardDifficult.ThreeStar;
		}
		if (isPickedUpAllGold && !isPickedUpAllSilver)
		{
			return LeaderboardDifficult.TwoStar;
		}
		if (!isPickedUpAllGold && isPickedUpAllSilver)
		{
			return LeaderboardDifficult.OneStar;
		}
		return LeaderboardDifficult.ZeroStar;
	}
}
