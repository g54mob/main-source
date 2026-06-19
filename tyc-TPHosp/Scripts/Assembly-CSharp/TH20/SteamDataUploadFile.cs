#define LOG_LEVEL_VERBOSE
using System;
using System.Text;
using Steamworks;
using UnityEngine;

namespace TH20
{
	public class SteamDataUploadFile
	{
		private readonly int _fileVersion;

		public readonly string Filename;

		public SteamLeaderboard_t LeaderboardHandle;

		public UGCHandle_t UGCHandle;

		public bool LeaderboardEntryFound;

		public uint LastUploadedTime;

		public bool IsDirty;

		private byte[] _cachedData;

		private int _cachedDataLength;

		private int _maxBufferSize = 32768;

		private Coroutine _uploadCoroutine;

		public Action<SteamDataUploadFile> OnFileUploadFailed;

		public Action<SteamDataUploadFile> OnFileUploadCompleted;

		public Action<SteamDataUploadFile> OnFileDeletionFailed;

		public Action<SteamDataUploadFile> OnFileDeletionCompleted;

		public bool IsUploading => _uploadCoroutine != null;

		public byte[] CachedData => _cachedData;

		public int CachedDataLength => _cachedDataLength;

		public SteamDataUploadFile(OnlineFileClass fileClass, string filename)
		{
			Filename = filename;
			_fileVersion = SteamManager.DataVersions[(int)fileClass];
		}

		public void Delete()
		{
			_cachedData = null;
			if (IsUploading)
			{
				OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_uploadCoroutine);
			}
			Logging.Info(LogChannels.Online, "Deleting file - {0}", Filename);
			_uploadCoroutine = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(SteamHelpers.DeletePlayerDataCoroutine(this, OnDeleteCompleted, OnDeleteFailed));
		}

		public void TryUpload()
		{
			if (IsDirty && !IsUploading)
			{
				Logging.Info(LogChannels.Online, "Uploading file - {0}", Filename);
				_uploadCoroutine = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(SteamHelpers.UploadPlayerDataCoroutine(this, OnUploadCompleted, OnUploadFailed));
				IsDirty = false;
			}
		}

		public void ForceUpload()
		{
			if (IsUploading)
			{
				OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_uploadCoroutine);
			}
			Logging.Info(LogChannels.Online, "Force Uploading file - {0}", Filename);
			_uploadCoroutine = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(SteamHelpers.UploadPlayerDataCoroutine(this, OnUploadCompleted, OnUploadFailed));
			IsDirty = false;
		}

		private void OnUploadCompleted()
		{
			LastUploadedTime = OnlineManager.GetServerTime();
			_uploadCoroutine = null;
			OnFileUploadCompleted.InvokeSafe(this);
			Logging.Info(LogChannels.Online, "Upload Complete! - {0} (v{1})", Filename, _fileVersion);
		}

		private void OnUploadFailed(Exception e)
		{
			_uploadCoroutine = null;
			OnFileUploadFailed.InvokeSafe(this);
			Logging.Warning(LogChannels.Online, "Upload Failed for file {0} with exception - {1}", Filename, e.Message);
		}

		private void OnDeleteCompleted()
		{
			LastUploadedTime = OnlineManager.GetServerTime();
			IsDirty = false;
			_uploadCoroutine = null;
			OnFileDeletionCompleted.InvokeSafe(this);
			Logging.Info(LogChannels.Online, "Delete Complete! - {0}", Filename);
		}

		private void OnDeleteFailed(Exception e)
		{
			IsDirty = false;
			_uploadCoroutine = null;
			OnFileDeletionFailed.InvokeSafe(this);
			Logging.Warning(LogChannels.Online, "Delete Failed for file {0} with exception - {1}", Filename, e.Message);
		}

		public void Serialize<T>(T obj) where T : OnlineManager.IOnlineSerializable
		{
			string s = SteamHelpers.Serialize(obj);
			int byteCount = Encoding.Default.GetByteCount(s);
			byte[] bytes = BitConverter.GetBytes(_fileVersion);
			_cachedDataLength = bytes.Length + byteCount;
			if (_cachedData == null || _cachedDataLength > _maxBufferSize)
			{
				while (_cachedDataLength > _maxBufferSize)
				{
					_maxBufferSize *= 2;
				}
				_cachedData = new byte[_maxBufferSize];
			}
			bytes.CopyTo(_cachedData, 0);
			Encoding.Default.GetBytes(s).CopyTo(_cachedData, bytes.Length);
			IsDirty = true;
		}
	}
}
