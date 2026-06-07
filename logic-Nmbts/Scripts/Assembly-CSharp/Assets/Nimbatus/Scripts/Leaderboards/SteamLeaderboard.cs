using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Leaderboards
{
	public class SteamLeaderboard : MonoBehaviour
	{
		public ELeaderboard LeaderboardType;

		public string LeaderBoardName;

		public ELeaderboardSortMethod SortMethod;

		public ELeaderboardDisplayType DisplayType;

		[HideInInspector]
		public List<LeaderBoardEntry> LeaderboardEntries = new List<LeaderBoardEntry>();

		private SteamLeaderboard_t _steamLeaderBoard;

		private bool _initialized;

		public IEnumerator Initialize()
		{
			if (SteamManager.Initialized && !_initialized)
			{
				SteamCallbackCoroutine<LeaderboardFindResult_t> findLeaderBoard = new SteamCallbackCoroutine<LeaderboardFindResult_t>();
				SteamAPICall_t handle = SteamUserStats.FindOrCreateLeaderboard(LeaderBoardName, SortMethod, DisplayType);
				IEnumerator enumerator = findLeaderBoard.Start(handle, 10f);
				while (enumerator.MoveNext())
				{
					yield return enumerator.Current;
				}
				if (findLeaderBoard.HasResult)
				{
					_steamLeaderBoard = findLeaderBoard.Result.m_hSteamLeaderboard;
					_initialized = true;
				}
			}
		}

		public IEnumerator AddScoreWithAttachement(int score, byte[] attachement, string attachementName, bool forceReplace = false)
		{
			if (attachement == null || attachement.Length == 0 || !_initialized || SteamManager.ModsActive)
			{
				yield break;
			}
			attachementName += SteamUser.GetSteamID().m_SteamID;
			SteamCallbackCoroutine<LeaderboardScoreUploaded_t> uploadScore = new SteamCallbackCoroutine<LeaderboardScoreUploaded_t>();
			SteamAPICall_t handle = SteamUserStats.UploadLeaderboardScore(_steamLeaderBoard, (!forceReplace) ? ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest : ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, score, new int[0], 0);
			IEnumerator enumerator = uploadScore.Start(handle, 30f);
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}
			if (uploadScore.HasResult)
			{
				if (SteamRemoteStorage.FileWrite(attachementName, attachement, attachement.Length))
				{
					SteamCallbackCoroutine<RemoteStorageFileShareResult_t> shareDrone = new SteamCallbackCoroutine<RemoteStorageFileShareResult_t>();
					SteamAPICall_t handle2 = SteamRemoteStorage.FileShare(attachementName);
					enumerator = shareDrone.Start(handle2, 30f);
					while (enumerator.MoveNext())
					{
						yield return enumerator.Current;
					}
					if (shareDrone.HasResult)
					{
						SteamCallbackCoroutine<LeaderboardUGCSet_t> attachLeaderboard = new SteamCallbackCoroutine<LeaderboardUGCSet_t>();
						SteamAPICall_t handle3 = SteamUserStats.AttachLeaderboardUGC(_steamLeaderBoard, shareDrone.Result.m_hFile);
						enumerator = attachLeaderboard.Start(handle3, 30f);
						while (enumerator.MoveNext())
						{
							yield return enumerator.Current;
						}
						if (!attachLeaderboard.HasResult)
						{
							Debug.LogError("AttachLeaderboardUGC failed");
						}
					}
					else
					{
						Debug.LogError("FileShare failed");
					}
				}
				else
				{
					Debug.LogError("FileWrite failed");
				}
			}
			else
			{
				Debug.LogError("Upload Score failed");
			}
		}

		public IEnumerator AddScore(int score, bool forceReplace = false)
		{
			if (_initialized && !SteamManager.ModsActive)
			{
				SteamCallbackCoroutine<LeaderboardScoreUploaded_t> uploadScore = new SteamCallbackCoroutine<LeaderboardScoreUploaded_t>();
				SteamAPICall_t handle = SteamUserStats.UploadLeaderboardScore(_steamLeaderBoard, (!forceReplace) ? ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest : ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, score, new int[0], 0);
				IEnumerator enumerator = uploadScore.Start(handle, 30f);
				while (enumerator.MoveNext())
				{
					yield return enumerator.Current;
				}
				if (uploadScore.HasResult)
				{
					BaseSingleton<SteamStatsManager>.Instance.StoreStats();
				}
			}
		}

		public int GetMaxEntryCount()
		{
			if (_initialized)
			{
				return SteamUserStats.GetLeaderboardEntryCount(_steamLeaderBoard);
			}
			return 0;
		}

		public IEnumerator UpdateEntriesFromPercentRange(int percentStart, int percentEnd, bool withAttachements)
		{
			if (_initialized)
			{
				int maxEntryCount = GetMaxEntryCount();
				percentStart = 100 - percentStart;
				percentEnd = 100 - percentEnd;
				int min = (int)Math.Ceiling((float)maxEntryCount / 100f * (float)percentEnd);
				int max = (int)Math.Ceiling((float)maxEntryCount / 100f * (float)percentStart);
				int b = UnityEngine.Random.Range(min, max);
				int num = Mathf.Max(0, Mathf.Min(maxEntryCount, b));
				int rangeEnd = Mathf.Max(0, Mathf.Min(maxEntryCount, num + 5));
				IEnumerator enumerator = UpdateEntries(ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, num, rangeEnd, withAttachements);
				while (enumerator.MoveNext())
				{
					yield return enumerator.Current;
				}
			}
		}

		public IEnumerator UpdateEntries(ELeaderboardDataRequest data, int rangeStart, int rangeEnd, bool withAttachements)
		{
			if (!_initialized)
			{
				yield break;
			}
			LeaderboardEntries = new List<LeaderBoardEntry>();
			SteamCallbackCoroutine<LeaderboardScoresDownloaded_t> callback = new SteamCallbackCoroutine<LeaderboardScoresDownloaded_t>();
			SteamUserStats.GetLeaderboardEntryCount(_steamLeaderBoard);
			SteamAPICall_t handle = SteamUserStats.DownloadLeaderboardEntries(_steamLeaderBoard, data, rangeStart, rangeEnd);
			IEnumerator enumerator = callback.Start(handle, 120f);
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}
			if (!callback.HasResult)
			{
				yield break;
			}
			int count = callback.Result.m_cEntryCount;
			for (int i = 0; i < count; i++)
			{
				int[] pDetails = new int[0];
				LeaderboardEntry_t pLeaderboardEntry;
				SteamUserStats.GetDownloadedLeaderboardEntry(callback.Result.m_hSteamLeaderboardEntries, i, out pLeaderboardEntry, pDetails, 0);
				LeaderBoardEntry e = new LeaderBoardEntry();
				string friendPersonaName = SteamFriends.GetFriendPersonaName(pLeaderboardEntry.m_steamIDUser);
				e.Score = pLeaderboardEntry.m_nScore;
				e.UserName = friendPersonaName;
				e.UserId = pLeaderboardEntry.m_steamIDUser.m_SteamID;
				e.Rank = pLeaderboardEntry.m_nGlobalRank;
				if (withAttachements)
				{
					SteamCallbackCoroutine<RemoteStorageDownloadUGCResult_t> downloadAttachement = new SteamCallbackCoroutine<RemoteStorageDownloadUGCResult_t>();
					SteamAPICall_t handle2 = SteamRemoteStorage.UGCDownload(pLeaderboardEntry.m_hUGC, 0u);
					enumerator = downloadAttachement.Start(handle2, 30f);
					while (enumerator.MoveNext())
					{
						yield return enumerator.Current;
					}
					if (downloadAttachement.HasResult)
					{
						int nSizeInBytes = downloadAttachement.Result.m_nSizeInBytes;
						byte[] array = new byte[nSizeInBytes];
						SteamRemoteStorage.UGCRead(downloadAttachement.Result.m_hFile, array, nSizeInBytes, 0u, EUGCReadAction.k_EUGCRead_Close);
						e.Attachement = array;
					}
				}
				LeaderboardEntries.Add(e);
			}
		}
	}
}
