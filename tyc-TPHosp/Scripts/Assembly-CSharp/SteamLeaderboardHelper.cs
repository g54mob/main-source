using System;
using System.Collections;
using System.Collections.Generic;
using Steamworks;
using TH20;
using UnityEngine;

public class SteamLeaderboardHelper : ILeaderboardHelper
{
	private CreateOrFindResult _createOrFindResult;

	private UploadEntryResult _uploadEntryResult;

	private DownloadEntryResult _downloadEntryResult;

	private EntryCountResult _entryCountResult;

	private Dictionary<string, SuperBugLeaderboard> _lookup = new Dictionary<string, SuperBugLeaderboard>();

	public IEnumerator DownloadLeaderboardEntryForLocalUser(SuperBugLeaderboard leaderboard)
	{
		SteamAPICall_t callback = SteamUserStats.DownloadLeaderboardEntriesForUsers(leaderboard.steamHandle, new CSteamID[1] { SteamUser.GetSteamID() }, 1);
		WaitForCallResult<LeaderboardScoresDownloaded_t> callResultDownload = new WaitForCallResult<LeaderboardScoresDownloaded_t>(callback);
		yield return callResultDownload.WaitForResult();
		_downloadEntryResult.hasEntry = callResultDownload.Result.m_cEntryCount == 1;
	}

	public IEnumerator FindLeaderboard(string pchLeaderboardName)
	{
		SteamAPICall_t callback = SteamUserStats.FindLeaderboard(pchLeaderboardName);
		WaitForCallResult<LeaderboardFindResult_t> callResultLeaderboard = new WaitForCallResult<LeaderboardFindResult_t>(callback);
		yield return callResultLeaderboard.WaitForResult();
		if (callResultLeaderboard.Result.m_bLeaderboardFound != 0)
		{
			_createOrFindResult.found = true;
			if (_lookup.ContainsKey(pchLeaderboardName))
			{
				_createOrFindResult.leaderboard = _lookup[pchLeaderboardName];
			}
			else
			{
				_createOrFindResult.leaderboard = new SuperBugLeaderboard(pchLeaderboardName);
				_lookup.Add(pchLeaderboardName, _createOrFindResult.leaderboard);
			}
			_createOrFindResult.leaderboard.steamHandle = callResultLeaderboard.Result.m_hSteamLeaderboard;
		}
		else
		{
			_createOrFindResult.found = false;
		}
	}

	public IEnumerator FindOrCreateLeaderboard(string pchLeaderboardName)
	{
		SteamAPICall_t callback = SteamUserStats.FindOrCreateLeaderboard(pchLeaderboardName, ELeaderboardSortMethod.k_ELeaderboardSortMethodAscending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric);
		WaitForCallResult<LeaderboardFindResult_t> callResultLeaderboard = new WaitForCallResult<LeaderboardFindResult_t>(callback);
		yield return callResultLeaderboard.WaitForResult();
		if (callResultLeaderboard.Result.m_bLeaderboardFound == 0)
		{
			_createOrFindResult.found = false;
			yield break;
		}
		_createOrFindResult.found = true;
		if (_lookup.ContainsKey(pchLeaderboardName))
		{
			_createOrFindResult.leaderboard = _lookup[pchLeaderboardName];
		}
		else
		{
			_createOrFindResult.leaderboard = new SuperBugLeaderboard(pchLeaderboardName);
			_lookup.Add(pchLeaderboardName, _createOrFindResult.leaderboard);
		}
		_createOrFindResult.leaderboard.steamHandle = callResultLeaderboard.Result.m_hSteamLeaderboard;
	}

	public IEnumerator UploadEntry(SuperBugLeaderboard leaderboard)
	{
		SteamAPICall_t callback = SteamUserStats.UploadLeaderboardScore(leaderboard.steamHandle, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, 1, null, 0);
		WaitForCallResult<LeaderboardScoreUploaded_t> callResultUpload = new WaitForCallResult<LeaderboardScoreUploaded_t>(callback);
		yield return callResultUpload.WaitForResult();
		_uploadEntryResult.success = Convert.ToBoolean(callResultUpload.Result.m_bSuccess);
	}

	public CreateOrFindResult GetCreateOrFindResult()
	{
		return _createOrFindResult;
	}

	public DownloadEntryResult GetDownloadEntryResult()
	{
		return _downloadEntryResult;
	}

	public IEnumerator GetEntryCount(SuperBugLeaderboard leaderboard)
	{
		_entryCountResult.count = SteamUserStats.GetLeaderboardEntryCount(leaderboard.steamHandle);
		return null;
	}

	public EntryCountResult GetEntryCountResult()
	{
		return _entryCountResult;
	}

	public UploadEntryResult GetUploadResult()
	{
		return _uploadEntryResult;
	}

	public void CreateAndUploadDummyEntry(List<string> leaderboardName)
	{
		UnityEngine.Debug.Log("Playfab editor function being used on steam implementation, make sure LeaderboardHelperWrapper uses PlayfabLeaderboardHelper");
	}
}
