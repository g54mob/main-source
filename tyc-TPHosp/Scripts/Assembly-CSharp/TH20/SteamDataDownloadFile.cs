#define LOG_LEVEL_VERBOSE
using System;
using System.Linq;
using Steamworks;

namespace TH20
{
	public class SteamDataDownloadFile
	{
		private bool _wasPlayingAtLastDownload;

		private bool _firstDownloadCompleted;

		private bool _forceTry;

		private readonly int _fileVersion;

		public readonly string Filename;

		public readonly CSteamID SteamID;

		public DownloadResult LastDownloadResult;

		public EOnlineResult LastOnlineResult = EOnlineResult.EOnlineResultOk;

		public uint LastTimeUpdated;

		public SteamLeaderboard_t LeaderboardHandle;

		public UGCHandle_t UGCHandle;

		public byte[] CachedData;

		public Action<SteamDataDownloadFile, DownloadResult, EOnlineResult> OnFileDownloadFinished;

		public bool IsDownloading { get; private set; }

		public SteamDataDownloadFile(OnlineFileClass fileClass, string filename, CSteamID steamID)
		{
			Filename = filename;
			SteamID = steamID;
			_fileVersion = SteamManager.DataVersions[(int)fileClass];
		}

		public void Download(bool forceTry = false)
		{
			_forceTry = forceTry | _forceTry;
			if (_firstDownloadCompleted && !_forceTry && !IsPlayingGame() && !_wasPlayingAtLastDownload)
			{
				OnFileDownloadFinished.InvokeSafe(this, DownloadResult.FileNotUpdated, EOnlineResult.EOnlineResultOk);
			}
			else if (!IsDownloading)
			{
				IsDownloading = true;
				OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(SteamHelpers.ReadFriendDataCoroutine(this, OnDownloadCompleted, OnDownloadFailed));
			}
		}

		public bool GetDownloadProgress(out int numBytesDownloaded, out int numBytesExpected)
		{
			numBytesDownloaded = 0;
			numBytesExpected = 0;
			if (!IsDownloading)
			{
				return false;
			}
			if (UGCHandle == UGCHandle_t.Invalid)
			{
				return false;
			}
			if (UGCHandle.m_UGCHandle == 0L)
			{
				return false;
			}
			return SteamRemoteStorage.GetUGCDownloadProgress(UGCHandle, out numBytesDownloaded, out numBytesExpected);
		}

		private void OnDownloadCompleted(bool didFileChange)
		{
			IsDownloading = false;
			_firstDownloadCompleted = true;
			_forceTry = false;
			DownloadResult lastDownloadResult;
			if (CachedData == null || CachedData.Length == 0 || UGCHandle == UGCHandle_t.Invalid)
			{
				lastDownloadResult = DownloadResult.FileNotFound;
			}
			else if (didFileChange)
			{
				Logging.Info(LogChannels.Online, "Steam File {0} for {1} - Downloaded new file", Filename, SteamFriends.GetFriendPersonaName(SteamID));
				SteamFriends.GetFriendGamePlayed(SteamID, out var _);
				_wasPlayingAtLastDownload = IsPlayingGame();
				LastTimeUpdated = OnlineManager.GetServerTime();
				lastDownloadResult = DownloadResult.FileUpdated;
			}
			else
			{
				lastDownloadResult = DownloadResult.FileNotUpdated;
			}
			LastDownloadResult = lastDownloadResult;
			LastOnlineResult = EOnlineResult.EOnlineResultOk;
			OnFileDownloadFinished.InvokeSafe(this, LastDownloadResult, LastOnlineResult);
		}

		private void OnDownloadFailed(Exception e)
		{
			IsDownloading = false;
			Logging.Warning(LogChannels.Online, "Steam File {1} for {0} failed to update with exception - {2}", SteamFriends.GetFriendPersonaName(SteamID), Filename, e.Message);
			LastDownloadResult = DownloadResult.FileFailed;
			LastOnlineResult = EOnlineResult.EOnlineResultOk;
			if (e is FileDownloadTimeOutException)
			{
				LastOnlineResult = EOnlineResult.EOnlineResultTimedOut;
			}
			else
			{
				LastOnlineResult = EOnlineResult.EOnlineResultFail;
			}
			OnFileDownloadFinished.InvokeSafe(this, LastDownloadResult, LastOnlineResult);
		}

		private bool IsPlayingGame()
		{
			SteamFriends.GetFriendGamePlayed(SteamID, out var pFriendGameInfo);
			return pFriendGameInfo.m_gameID == (CGameID)OSManager.AppID;
		}

		public EOnlineResult Deserialize<T>(out T obj) where T : OnlineManager.IOnlineSerializable
		{
			obj = default(T);
			if (CachedData == null)
			{
				return EOnlineResult.EOnlineResultFileDoesNotExist;
			}
			if (CachedData.Length == 0)
			{
				return EOnlineResult.EOnlineResultFileEmpty;
			}
			uint num = BitConverter.ToUInt32(CachedData, 0);
			if (num > _fileVersion)
			{
				return EOnlineResult.EOnlineResultFileForwardVersion;
			}
			if (num < _fileVersion)
			{
				return EOnlineResult.EOnlineResultFileOutOfDate;
			}
			return SteamHelpers.Deserialize<T>(CachedData.Skip(4).ToArray(), out obj);
		}
	}
}
