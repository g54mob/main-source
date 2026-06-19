using System;
using Steamworks;
using UnityEngine;

namespace TH20
{
	public class SteamDataFile : BaseOnlineDataFile
	{
		private SteamDataDownloadFile downloadFile;

		private SteamDataUploadFile uploadFile;

		public string Filename
		{
			get
			{
				if (downloadFile != null)
				{
					return downloadFile.Filename;
				}
				if (uploadFile != null)
				{
					return uploadFile.Filename;
				}
				UnityEngine.Debug.LogWarning("No upload or download file found. Should this have been called?");
				return "";
			}
		}

		private OnlinePlayerID PlayerID
		{
			get
			{
				if (downloadFile != null)
				{
					return downloadFile.SteamID;
				}
				UnityEngine.Debug.LogWarning("No upload or download file found. Should this have been called?");
				return OnlinePlayerID.Nil;
			}
		}

		private bool IsUploadingValue => uploadFile.IsUploading;

		private bool IsDownloadingValue => downloadFile.IsDownloading;

		private DownloadResult LastDownloadResult => downloadFile.LastDownloadResult;

		public uint LastTimeUpdated => downloadFile.LastTimeUpdated;

		public EOnlineResult LastOnlineResult => downloadFile.LastOnlineResult;

		public bool LeaderboardEntryFound => uploadFile.LeaderboardEntryFound;

		private ulong LeaderboardHandle
		{
			get
			{
				if (downloadFile != null)
				{
					return (ulong)downloadFile.LeaderboardHandle;
				}
				if (uploadFile != null)
				{
					return (ulong)uploadFile.LeaderboardHandle;
				}
				UnityEngine.Debug.LogWarning("No upload or download file found. Should this have been called?");
				return 0uL;
			}
			set
			{
				if (downloadFile != null)
				{
					downloadFile.LeaderboardHandle = (SteamLeaderboard_t)value;
				}
				else if (uploadFile != null)
				{
					uploadFile.LeaderboardHandle = (SteamLeaderboard_t)value;
				}
			}
		}

		private ulong UGCHandle
		{
			get
			{
				if (downloadFile != null)
				{
					return (ulong)downloadFile.UGCHandle;
				}
				if (uploadFile != null)
				{
					return (ulong)uploadFile.UGCHandle;
				}
				UnityEngine.Debug.LogWarning("No upload or download file found. Should this have been called?");
				return 0uL;
			}
			set
			{
				if (downloadFile != null)
				{
					downloadFile.UGCHandle = (UGCHandle_t)value;
				}
				else if (uploadFile != null)
				{
					uploadFile.UGCHandle = (UGCHandle_t)value;
				}
			}
		}

		private byte[] CachedData
		{
			get
			{
				return downloadFile.CachedData;
			}
			set
			{
				downloadFile.CachedData = value;
			}
		}

		public void SteamDataDownloadFile(OnlineFileClass fileClass, string filename, OnlinePlayerID playerID)
		{
			downloadFile = new SteamDataDownloadFile(fileClass, filename, playerID);
			SteamDataDownloadFile steamDataDownloadFile = downloadFile;
			steamDataDownloadFile.OnFileDownloadFinished = (Action<SteamDataDownloadFile, DownloadResult, EOnlineResult>)Delegate.Combine(steamDataDownloadFile.OnFileDownloadFinished, new Action<SteamDataDownloadFile, DownloadResult, EOnlineResult>(OnDownloadCompleted));
		}

		public void SteamDataUploadFile(OnlineFileClass fileClass, string filename)
		{
			uploadFile = new SteamDataUploadFile(fileClass, filename);
			SteamDataUploadFile steamDataUploadFile = uploadFile;
			steamDataUploadFile.OnFileDeletionCompleted = (Action<SteamDataUploadFile>)Delegate.Combine(steamDataUploadFile.OnFileDeletionCompleted, new Action<SteamDataUploadFile>(OnDeleteCompleted));
			SteamDataUploadFile steamDataUploadFile2 = uploadFile;
			steamDataUploadFile2.OnFileDeletionFailed = (Action<SteamDataUploadFile>)Delegate.Combine(steamDataUploadFile2.OnFileDeletionFailed, new Action<SteamDataUploadFile>(OnDeleteFailed));
			SteamDataUploadFile steamDataUploadFile3 = uploadFile;
			steamDataUploadFile3.OnFileUploadCompleted = (Action<SteamDataUploadFile>)Delegate.Combine(steamDataUploadFile3.OnFileUploadCompleted, new Action<SteamDataUploadFile>(OnUploadCompleted));
			SteamDataUploadFile steamDataUploadFile4 = uploadFile;
			steamDataUploadFile4.OnFileUploadFailed = (Action<SteamDataUploadFile>)Delegate.Combine(steamDataUploadFile4.OnFileUploadFailed, new Action<SteamDataUploadFile>(OnUploadFailed));
		}

		public SteamDataFile(OnlineFileClass fileClass, string filename)
		{
			SteamDataUploadFile(fileClass, filename);
		}

		public SteamDataFile(OnlineFileClass fileClass, string filename, OnlinePlayerID playerID)
		{
			SteamDataDownloadFile(fileClass, filename, playerID);
		}

		public SteamDataFile()
		{
			throw new NotImplementedException("Data files not implemented for non steam platforms yet");
		}

		public override void Download(bool forceTry = false)
		{
			downloadFile.Download(forceTry);
		}

		private bool GetDownloadProgress(out int numBytesDownloaded, out int numBytesExpected)
		{
			return downloadFile.GetDownloadProgress(out numBytesDownloaded, out numBytesExpected);
		}

		public override EOnlineResult Deserialize<T>(out T obj)
		{
			return downloadFile.Deserialize<T>(out obj);
		}

		public override void TryUpload()
		{
			uploadFile.TryUpload();
		}

		public override void ForceUpload()
		{
			uploadFile.ForceUpload();
		}

		public override void Delete()
		{
			uploadFile.Delete();
		}

		public override void Serialize<T>(T obj)
		{
			uploadFile.Serialize(obj);
		}

		public override string GetFilename()
		{
			return Filename;
		}

		public override OnlinePlayerID GetPlayerID()
		{
			return PlayerID;
		}

		public override uint GetLastTimeUpdated()
		{
			return LastTimeUpdated;
		}

		public override EOnlineResult GetLastOnlineResult()
		{
			return LastOnlineResult;
		}

		public override bool IsUploading()
		{
			return IsUploadingValue;
		}

		public override bool IsDownloading()
		{
			return IsDownloadingValue;
		}

		public override DownloadResult GetLastDownloadResult()
		{
			return LastDownloadResult;
		}

		private bool GetLeaderboardEntryFound()
		{
			return LeaderboardEntryFound;
		}

		private ulong GetLeaderboardHandle()
		{
			return LeaderboardHandle;
		}

		private ulong GetUGCHandle()
		{
			return UGCHandle;
		}

		private byte[] GetCachedData()
		{
			return CachedData;
		}
	}
}
