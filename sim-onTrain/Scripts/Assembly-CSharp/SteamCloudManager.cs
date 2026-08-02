using System;
using System.IO;
using Steamworks;
using UnityEngine;

public class SteamCloudManager : Singleton<SteamCloudManager>
{
	[SerializeField]
	private bool enableCloudSync = true;

	public bool IsCloudAvailable
	{
		get
		{
			if (SteamManager.Initialized && SteamRemoteStorage.IsCloudEnabledForAccount())
			{
				return SteamRemoteStorage.IsCloudEnabledForApp();
			}
			return false;
		}
	}

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		Debug.Log($"[SteamCloudManager] Start - AppID: {SteamUtils.GetAppID()}, Cloud Available: {IsCloudAvailable}, Initialized: {SteamManager.Initialized}");
		LogCloudQuota();
	}

	public bool UploadSaveToCloud(string localFilePath)
	{
		if (!enableCloudSync || !IsCloudAvailable)
		{
			return false;
		}
		if (!File.Exists(localFilePath))
		{
			Debug.LogWarning("[SteamCloud] Local file not found: " + localFilePath);
			return false;
		}
		try
		{
			string cloudFileName = GetCloudFileName(localFilePath);
			byte[] array = File.ReadAllBytes(localFilePath);
			bool flag = SteamRemoteStorage.FileWrite(cloudFileName, array, array.Length);
			if (flag)
			{
				Debug.Log($"[SteamCloud] Uploaded: {cloudFileName} ({array.Length} bytes)");
			}
			else
			{
				SteamRemoteStorage.GetQuota(out var pnTotalBytes, out var puAvailableBytes);
				Debug.LogWarning($"[SteamCloud] Failed to upload: {cloudFileName} (size: {array.Length} bytes, quota: {puAvailableBytes}/{pnTotalBytes})");
			}
			return flag;
		}
		catch (Exception ex)
		{
			Debug.LogError("[SteamCloud] Upload error: " + ex.Message);
			return false;
		}
	}

	public bool DownloadSaveFromCloud(string localFilePath)
	{
		if (!enableCloudSync || !IsCloudAvailable)
		{
			return false;
		}
		try
		{
			string cloudFileName = GetCloudFileName(localFilePath);
			if (!SteamRemoteStorage.FileExists(cloudFileName))
			{
				return false;
			}
			long fileTimestamp = SteamRemoteStorage.GetFileTimestamp(cloudFileName);
			if (File.Exists(localFilePath) && new DateTimeOffset(File.GetLastWriteTimeUtc(localFilePath)).ToUnixTimeSeconds() >= fileTimestamp)
			{
				Debug.Log("[SteamCloud] Local file is up to date: " + cloudFileName);
				return false;
			}
			int fileSize = SteamRemoteStorage.GetFileSize(cloudFileName);
			byte[] array = new byte[fileSize];
			int num = SteamRemoteStorage.FileRead(cloudFileName, array, fileSize);
			if (num > 0)
			{
				string directoryName = Path.GetDirectoryName(localFilePath);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				File.WriteAllBytes(localFilePath, array);
				Debug.Log($"[SteamCloud] Downloaded: {cloudFileName} ({num} bytes)");
				return true;
			}
			Debug.LogWarning("[SteamCloud] Failed to read cloud file: " + cloudFileName);
			return false;
		}
		catch (Exception ex)
		{
			Debug.LogError("[SteamCloud] Download error: " + ex.Message);
			return false;
		}
	}

	public bool DeleteCloudSave(string localFilePath)
	{
		if (!IsCloudAvailable)
		{
			return false;
		}
		string cloudFileName = GetCloudFileName(localFilePath);
		if (SteamRemoteStorage.FileExists(cloudFileName))
		{
			bool num = SteamRemoteStorage.FileDelete(cloudFileName);
			if (num)
			{
				Debug.Log("[SteamCloud] Deleted: " + cloudFileName);
			}
			return num;
		}
		return false;
	}

	public void LogCloudQuota()
	{
		if (IsCloudAvailable)
		{
			SteamRemoteStorage.GetQuota(out var pnTotalBytes, out var puAvailableBytes);
			ulong num = pnTotalBytes - puAvailableBytes;
			Debug.Log($"[SteamCloud] Quota: {num / 1024}KB / {pnTotalBytes / 1024}KB used");
		}
	}

	private string GetCloudFileName(string localFilePath)
	{
		string fileName = Path.GetFileName(localFilePath);
		return "saves/" + fileName;
	}
}
