#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Text;
using FullInspector.Internal;
using FullSerializerSave;
using Steamworks;

namespace TH20
{
	public static class SteamHelpers
	{
		public static BiDictionary<int, object> AssetIDs;

		private static fsSerializer Serializer;

		private static readonly StringBuilder LargeStringBuilderCacheForJSON = new StringBuilder();

		private static readonly StringBuilder SmallStringBuilderCacheForJSON = new StringBuilder();

		public static IEnumerator ReadFriendDataCoroutine(SteamDataDownloadFile file, Action<bool> onCompleted, Action<Exception> onError)
		{
			if (file == null)
			{
				onError.InvokeSafe(new Exception("ReadFriendDataCoroutine - SteamDataDownloadFile was null"));
				yield break;
			}
			if (file.LeaderboardHandle.m_SteamLeaderboard == 0L)
			{
				SteamAPICall_t callback = SteamUserStats.FindLeaderboard(file.Filename);
				WaitForCallResult<LeaderboardFindResult_t> callResultLeaderboard = new WaitForCallResult<LeaderboardFindResult_t>(callback);
				yield return callResultLeaderboard.WaitForResult();
				if (callResultLeaderboard.Result.m_bLeaderboardFound == 0)
				{
					onError.InvokeSafe(ExceptionUtils.NewFormat("ReadFriendDataCoroutine - Leaderboard {0} not found!", file.Filename));
					yield break;
				}
				file.LeaderboardHandle = callResultLeaderboard.Result.m_hSteamLeaderboard;
			}
			SteamAPICall_t callback2 = SteamUserStats.DownloadLeaderboardEntriesForUsers(file.LeaderboardHandle, new CSteamID[1] { file.SteamID }, 1);
			WaitForCallResult<LeaderboardScoresDownloaded_t> callResultDownload = new WaitForCallResult<LeaderboardScoresDownloaded_t>(callback2);
			yield return callResultDownload.WaitForResult();
			if (callResultDownload.Result.m_cEntryCount != 1)
			{
				onCompleted.InvokeSafe(param: false);
				yield break;
			}
			SteamUserStats.GetDownloadedLeaderboardEntry(callResultDownload.Result.m_hSteamLeaderboardEntries, 0, out var pLeaderboardEntry, null, 0);
			if (pLeaderboardEntry.m_steamIDUser != file.SteamID)
			{
				onError.InvokeSafe(ExceptionUtils.NewFormat("ReadFriendDataCoroutine - Leaderboard {0} but downloaded entry does not match steamID for {1}", file.Filename, SteamFriends.GetFriendPersonaName(file.SteamID)));
				yield break;
			}
			if (pLeaderboardEntry.m_hUGC == UGCHandle_t.Invalid)
			{
				file.UGCHandle = pLeaderboardEntry.m_hUGC;
				onCompleted.InvokeSafe(param: false);
				yield break;
			}
			if (file.UGCHandle.Equals(pLeaderboardEntry.m_hUGC))
			{
				onCompleted.InvokeSafe(param: false);
				yield break;
			}
			file.UGCHandle = pLeaderboardEntry.m_hUGC;
			SteamAPICall_t callback3 = SteamRemoteStorage.UGCDownload(file.UGCHandle, 0u);
			WaitForCallResult<RemoteStorageDownloadUGCResult_t> callResultDownloadUGC = new WaitForCallResult<RemoteStorageDownloadUGCResult_t>(callback3);
			yield return callResultDownloadUGC.WaitForResult();
			EResult eResult = callResultDownloadUGC.Result.m_eResult;
			if (eResult != EResult.k_EResultOK)
			{
				string message = $"ReadFriendDataCoroutine: Downloading file {file.UGCHandle} failed with result {eResult.ToString()}";
				if (eResult == EResult.k_EResultTimeout)
				{
					onError.InvokeSafe(new FileDownloadTimeOutException(message));
				}
				else
				{
					onError.InvokeSafe(new Exception(message));
				}
			}
			else
			{
				file.CachedData = new byte[callResultDownloadUGC.Result.m_nSizeInBytes];
				SteamRemoteStorage.UGCRead(callResultDownloadUGC.Result.m_hFile, file.CachedData, callResultDownloadUGC.Result.m_nSizeInBytes, 0u, EUGCReadAction.k_EUGCRead_ContinueReadingUntilFinished);
				onCompleted.InvokeSafe(param: true);
			}
		}

		public static IEnumerator UploadPlayerDataCoroutine(SteamDataUploadFile file, Action onCompleted, Action<Exception> onError)
		{
			if (file == null)
			{
				onError.InvokeSafe(new Exception("UploadPlayerDataCoroutine - SteamDataUploadFile was null"));
				yield break;
			}
			if (file.LeaderboardHandle.m_SteamLeaderboard == 0L)
			{
				SteamAPICall_t callback = SteamUserStats.FindLeaderboard(file.Filename);
				WaitForCallResult<LeaderboardFindResult_t> callResultLeaderboard = new WaitForCallResult<LeaderboardFindResult_t>(callback);
				yield return callResultLeaderboard.WaitForResult();
				if (callResultLeaderboard.Result.m_bLeaderboardFound == 0)
				{
					onError.InvokeSafe(ExceptionUtils.NewFormat("UploadPlayerDataCoroutine - Leaderboard {0} not found!", file.Filename));
					yield break;
				}
				file.LeaderboardHandle = callResultLeaderboard.Result.m_hSteamLeaderboard;
			}
			if (!file.LeaderboardEntryFound)
			{
				SteamAPICall_t callback2 = SteamUserStats.DownloadLeaderboardEntriesForUsers(file.LeaderboardHandle, new CSteamID[1] { SteamUser.GetSteamID() }, 1);
				WaitForCallResult<LeaderboardScoresDownloaded_t> callResultDownload = new WaitForCallResult<LeaderboardScoresDownloaded_t>(callback2);
				yield return callResultDownload.WaitForResult();
				file.LeaderboardEntryFound = callResultDownload.Result.m_cEntryCount == 1;
			}
			if (!file.LeaderboardEntryFound)
			{
				SteamAPICall_t callback3 = SteamUserStats.UploadLeaderboardScore(file.LeaderboardHandle, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest, 0, null, 0);
				WaitForCallResult<LeaderboardScoreUploaded_t> callResultUpload = new WaitForCallResult<LeaderboardScoreUploaded_t>(callback3);
				yield return callResultUpload.WaitForResult();
				if (callResultUpload.Result.m_bSuccess == 0)
				{
					onError.InvokeSafe(ExceptionUtils.NewFormat("UploadPlayerDataCoroutine - Failed to upload new score to leaderboard {0}!", file.Filename));
					yield break;
				}
			}
			SteamAPICall_t callback4 = SteamRemoteStorage.FileWriteAsync(file.Filename + ".dat", file.CachedData, (uint)file.CachedDataLength);
			file.IsDirty = false;
			WaitForCallResult<RemoteStorageFileWriteAsyncComplete_t> callResultFileWrite = new WaitForCallResult<RemoteStorageFileWriteAsyncComplete_t>(callback4);
			yield return callResultFileWrite.WaitForResult();
			if (callResultFileWrite.Result.m_eResult != EResult.k_EResultOK)
			{
				onError.InvokeSafe(ExceptionUtils.NewFormat("UploadPlayerDataCoroutine: FileWriteAsync to file {0} has failed with result {1}", file.Filename + ".dat", callResultFileWrite.Result.m_eResult.ToString()));
				yield break;
			}
			SteamAPICall_t callback5 = SteamRemoteStorage.FileShare(file.Filename + ".dat");
			WaitForCallResult<RemoteStorageFileShareResult_t> callResultFileShare = new WaitForCallResult<RemoteStorageFileShareResult_t>(callback5);
			yield return callResultFileShare.WaitForResult();
			if (callResultFileShare.Result.m_eResult != EResult.k_EResultOK)
			{
				onError.InvokeSafe(ExceptionUtils.NewFormat("UploadPlayerDataCoroutine: FileShare on file {0} has failed with result {1}", file.Filename + ".dat", callResultFileShare.Result.m_eResult.ToString()));
				yield break;
			}
			if (callResultFileShare.Result.m_hFile == UGCHandle_t.Invalid)
			{
				onError.InvokeSafe(ExceptionUtils.NewFormat("UploadPlayerDataCoroutine: FileShare on file {0} has returned an invalid UGC Handle", file.Filename + ".dat"));
				yield break;
			}
			file.UGCHandle = callResultFileShare.Result.m_hFile;
			SteamAPICall_t callback6 = SteamUserStats.AttachLeaderboardUGC(file.LeaderboardHandle, file.UGCHandle);
			WaitForCallResult<LeaderboardUGCSet_t> callResultAttach = new WaitForCallResult<LeaderboardUGCSet_t>(callback6);
			yield return callResultAttach.WaitForResult();
			if (callResultAttach.Result.m_eResult != EResult.k_EResultOK)
			{
				onError.InvokeSafe(ExceptionUtils.NewFormat("UploadPlayerDataCoroutine: AttachLeaderboardUGC for file {0} has failed with result {1}", file.Filename + ".dat", callResultAttach.Result.m_eResult.ToString()));
			}
			else
			{
				onCompleted.InvokeSafe();
			}
		}

		public static IEnumerator DeletePlayerDataCoroutine(SteamDataUploadFile file, Action onCompleted, Action<Exception> onError)
		{
			if (file == null)
			{
				onError.InvokeSafe(new Exception("DeletePlayerDataCoroutine - SteamDataUploadFile was null"));
				yield break;
			}
			SteamRemoteStorage.FileDelete(file.Filename + ".dat");
			if (file.LeaderboardHandle.m_SteamLeaderboard == 0L)
			{
				SteamAPICall_t callback = SteamUserStats.FindLeaderboard(file.Filename);
				WaitForCallResult<LeaderboardFindResult_t> callResultLeaderboard = new WaitForCallResult<LeaderboardFindResult_t>(callback);
				yield return callResultLeaderboard.WaitForResult();
				if (callResultLeaderboard.Result.m_bLeaderboardFound == 0)
				{
					onError.InvokeSafe(ExceptionUtils.NewFormat("DeletePlayerDataCoroutine - Leaderboard {0} not found!", file.Filename));
					yield break;
				}
				file.LeaderboardHandle = callResultLeaderboard.Result.m_hSteamLeaderboard;
			}
			SteamAPICall_t callback2 = SteamUserStats.UploadLeaderboardScore(file.LeaderboardHandle, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest, 0, null, 0);
			WaitForCallResult<LeaderboardScoreUploaded_t> callResultUpload = new WaitForCallResult<LeaderboardScoreUploaded_t>(callback2);
			yield return callResultUpload.WaitForResult();
			if (callResultUpload.Result.m_bSuccess == 0)
			{
				onError.InvokeSafe(ExceptionUtils.NewFormat("DeletePlayerDataCoroutine - Failed to upload new score to leaderboard {0}!", file.Filename));
				yield break;
			}
			SteamAPICall_t callback3 = SteamUserStats.AttachLeaderboardUGC(file.LeaderboardHandle, UGCHandle_t.Invalid);
			WaitForCallResult<LeaderboardUGCSet_t> callResultAttach = new WaitForCallResult<LeaderboardUGCSet_t>(callback3);
			yield return callResultAttach.WaitForResult();
			if (callResultAttach.Result.m_eResult != EResult.k_EResultOK)
			{
				onError.InvokeSafe(ExceptionUtils.NewFormat("DeletePlayerDataCoroutine: AttachLeaderboardUGC for file {0} has failed with result {1}", file.Filename + ".dat", callResultAttach.Result.m_eResult.ToString()));
			}
			else
			{
				onCompleted.InvokeSafe();
			}
		}

		public static string ReadRemoteFile(string filename)
		{
			int fileSize = SteamRemoteStorage.GetFileSize(filename);
			byte[] array = new byte[fileSize];
			SteamRemoteStorage.FileRead(filename, array, fileSize);
			return Encoding.ASCII.GetString(array);
		}

		public static CallResult<RemoteStorageFileReadAsyncComplete_t> ReadRemoteFileAsync(string filename, Action<string> onCompleted, Action<Exception> onError)
		{
			int fileSize = SteamRemoteStorage.GetFileSize(filename);
			SteamAPICall_t hAPICall = SteamRemoteStorage.FileReadAsync(filename, 0u, (uint)fileSize);
			CallResult<RemoteStorageFileReadAsyncComplete_t> callResult = new CallResult<RemoteStorageFileReadAsyncComplete_t>();
			callResult.Set(hAPICall, delegate(RemoteStorageFileReadAsyncComplete_t result, bool failure)
			{
				if (result.m_eResult != EResult.k_EResultOK)
				{
					onError.InvokeSafe(new Exception($"ReadRemoteFileAsync - Tried to read file {filename} but failed with result {result.m_eResult.ToString()}"));
				}
				else
				{
					byte[] array = new byte[result.m_cubRead];
					if (!SteamRemoteStorage.FileReadAsyncComplete(result.m_hFileReadAsync, array, result.m_cubRead))
					{
						onError.InvokeSafe(new Exception($"ReadRemoteFileAsync.FileReadAsyncComplete - Failed on file {filename}"));
					}
					else
					{
						onCompleted(Encoding.ASCII.GetString(array));
					}
				}
			});
			return callResult;
		}

		public static string ReadAllRemoteFiles()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int fileCount = SteamRemoteStorage.GetFileCount();
			for (int i = 0; i < fileCount; i++)
			{
				int pnFileSizeInBytes;
				string fileNameAndSize = SteamRemoteStorage.GetFileNameAndSize(i, out pnFileSizeInBytes);
				byte[] array = new byte[pnFileSizeInBytes];
				SteamRemoteStorage.FileRead(fileNameAndSize, array, pnFileSizeInBytes);
				stringBuilder.AppendLine($"File {fileNameAndSize}({pnFileSizeInBytes}) - {Encoding.ASCII.GetString(array)}");
			}
			return stringBuilder.ToString();
		}

		private static void EnsureSerializerExists()
		{
			if (Serializer == null)
			{
				Serializer = new fsSerializer
				{
					Config = 
					{
						DeserializeMissingNegativeObjectIDsAsNull = true
					}
				};
				if (AssetIDs != null)
				{
					Serializer.SetIDObjectMapping(AssetIDs.FirstToSecond, AssetIDs.SecondToFirst);
				}
			}
		}

		public static string Serialize<T>(T obj) where T : OnlineManager.IOnlineSerializable
		{
			EnsureSerializerExists();
			obj?.PrepareForUpload();
			fiSerializationManager.DisableAutomaticSerialization = true;
			fiSerializationManager.IsInSaveOrLoad = true;
			fsData data;
			fsResult fsResult2 = Serializer.TrySerialize(obj, out data);
			fiSerializationManager.DisableAutomaticSerialization = false;
			fiSerializationManager.IsInSaveOrLoad = false;
			if (fsResult2.Failed)
			{
				throw new Exception($"Serialisation Failed: {fsResult2.RawMessages}");
			}
			return fsJsonPrinter.CompressedJson(data, LargeStringBuilderCacheForJSON, SmallStringBuilderCacheForJSON);
		}

		public static EOnlineResult Deserialize<T>(byte[] data, out T obj) where T : OnlineManager.IOnlineSerializable
		{
			obj = default(T);
			if (data == null || data.Length == 0)
			{
				return EOnlineResult.EOnlineResultNoInput;
			}
			return Deserialize<T>(Encoding.Default.GetString(data), out obj);
		}

		public static EOnlineResult Deserialize<T>(string dataString, out T obj) where T : OnlineManager.IOnlineSerializable
		{
			EnsureSerializerExists();
			obj = default(T);
			try
			{
				fsData data;
				fsResult fsResult2 = fsJsonParser.Parse(dataString, out data);
				if (!fsResult2.Succeeded)
				{
					Logging.Warning(LogChannels.Online, "Deserialize - Unable to parse string as JSON: {0} - {1}", dataString, fsResult2.RawMessages);
					return EOnlineResult.EOnlineResultFailParsingJSON;
				}
				fiSerializationManager.DisableAutomaticSerialization = true;
				fiSerializationManager.IsInSaveOrLoad = true;
				fsResult fsResult3 = Serializer.TryDeserialize(data, ref obj);
				fiSerializationManager.DisableAutomaticSerialization = false;
				fiSerializationManager.IsInSaveOrLoad = false;
				if (fsResult3.Failed)
				{
					Logging.Warning(LogChannels.Online, "Deserialize - Failed to Deserialize JSON {0} - {1}", dataString, fsResult3.RawMessages);
					return EOnlineResult.EOnlineResultFailDeserializingJSON;
				}
			}
			catch (Exception ex)
			{
				Logging.Warning(LogChannels.Online, "Deserialize - Failed to Deserialize JSON {0} - {1}", dataString, ex.Message);
				return EOnlineResult.EOnlineResultFailDeserializingJSON;
			}
			finally
			{
				fiSerializationManager.DisableAutomaticSerialization = false;
				fiSerializationManager.IsInSaveOrLoad = false;
			}
			if (obj == null)
			{
				return EOnlineResult.EOnlineResultFailDeserializingJSON;
			}
			obj.RestoreAfterDownload();
			return EOnlineResult.EOnlineResultOk;
		}
	}
}
