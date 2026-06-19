#define LOG_LEVEL_VERBOSE
using System.Text;
using Steamworks;
using TH20;
using UnityEngine;

public class SteamTestComponent : MonoBehaviour
{
	public string FileToUse;

	public CSteamID SteamID;

	public string SteamName;

	private int _friendIndex;

	public int FriendCount;

	private readonly CallResult<RemoteStorageFileWriteAsyncComplete_t> _fileWriteResult = CallResult<RemoteStorageFileWriteAsyncComplete_t>.Create();

	private readonly CallResult<RemoteStorageFileShareResult_t> _fileShareResult = CallResult<RemoteStorageFileShareResult_t>.Create();

	public string FileName = "test.dat";

	private void Start()
	{
		FriendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagAll);
	}

	private void OnFileWriteAsyncFinished(RemoteStorageFileWriteAsyncComplete_t result, bool ioFailure)
	{
		Logging.Info(LogChannels.Online, "FileWriteAsync {2} - Complete = {0} - {1}", result.m_eResult, ioFailure ? "True" : "False", FileName);
	}

	private void OnFileShareFinished(RemoteStorageFileShareResult_t result, bool ioFailure)
	{
		Logging.Info(LogChannels.Online, "FileShare {3} - Complete ({2})= {0} - {1}", result.m_eResult, ioFailure ? "True" : "False", result.m_hFile, FileName);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.U))
		{
			Logging.Info(LogChannels.Online, "Gathering Rich Presence Data for {0}", SteamFriends.GetFriendPersonaName(SteamID));
			Logging.Info(LogChannels.Online, "{0}: {1}", SteamFriends.GetFriendPersonaName(SteamID), SteamRichPresence.SteamRichPresenceUtils.GetAllRichPresenceValuesForSteamID(SteamID));
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			_friendIndex = (_friendIndex + 1) % FriendCount;
			SteamID = SteamFriends.GetFriendByIndex(_friendIndex, EFriendFlags.k_EFriendFlagAll);
			SteamName = SteamFriends.GetFriendPersonaName(SteamID);
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			SteamID = OnlineManager.GetLocalPlayerID();
			SteamName = SteamFriends.GetFriendPersonaName(SteamID);
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			string text = "Hello World! " + SteamUtils.GetServerRealTime();
			byte[] bytes = Encoding.Default.GetBytes(text);
			Logging.Info(LogChannels.Online, "FileWriteAsync {1} - {0}", text, FileName);
			SteamAPICall_t hAPICall = SteamRemoteStorage.FileWriteAsync(FileName, bytes, (uint)bytes.Length);
			_fileWriteResult.Set(hAPICall, OnFileWriteAsyncFinished);
		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			string text2 = "Hello World! " + SteamUtils.GetServerRealTime();
			byte[] bytes2 = Encoding.Default.GetBytes(text2);
			bool flag = SteamRemoteStorage.FileWrite(FileName, bytes2, bytes2.Length);
			Logging.Info(LogChannels.Online, "FileWrite {1} - {0} - {2}", text2, FileName, flag ? "Success" : "Failed");
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			Logging.Info(LogChannels.Online, "FileShare {0}", FileName);
			SteamAPICall_t hAPICall2 = SteamRemoteStorage.FileShare(FileName);
			_fileShareResult.Set(hAPICall2, OnFileShareFinished);
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			int fileSize = SteamRemoteStorage.GetFileSize(FileName);
			byte[] array = new byte[fileSize];
			SteamRemoteStorage.FileRead(FileName, array, fileSize);
			Logging.Info(LogChannels.Online, "File Read {1} - {0}", Encoding.Default.GetString(array), FileName);
		}
		Input.GetKeyDown(KeyCode.S);
		Input.GetKeyDown(KeyCode.L);
		if (Input.GetKeyDown(KeyCode.M))
		{
			if (SteamRemoteStorage.FileDelete(FileName))
			{
				Logging.Info(LogChannels.Online, "FileDelete {0} - Success", FileName);
			}
			else
			{
				Logging.Info(LogChannels.Online, "FileDelete {0} - Failed", FileName);
			}
		}
	}
}
