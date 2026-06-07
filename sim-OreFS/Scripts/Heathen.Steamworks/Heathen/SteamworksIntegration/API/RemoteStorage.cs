using System;
using System.Text;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration.API
{
	public static class RemoteStorage
	{
		public static class Client
		{
			private static RemoteStorageLocalFileChangeEvent eventRemoteStorageLocalFileChange = new RemoteStorageLocalFileChangeEvent();

			private static Callback<RemoteStorageLocalFileChange_t> m_RemoteStorageLocalFileChange_t;

			private static CallResult<RemoteStorageFileReadAsyncComplete_t> m_RemoteStorageFileReadAsyncComplete_t;

			private static CallResult<RemoteStorageFileShareResult_t> m_RemoteStorageFileShareResult_t;

			private static CallResult<RemoteStorageFileWriteAsyncComplete_t> m_RemoteStorageFileWriteAsyncComplete_t;

			private static CallResult<RemoteStorageDownloadUGCResult_t> m_RemoteStorageDownloadUGCResult_t;

			public static bool IsEnabledForAccount => SteamRemoteStorage.IsCloudEnabledForAccount();

			public static bool IsEnabledForApp
			{
				get
				{
					return SteamRemoteStorage.IsCloudEnabledForApp();
				}
				set
				{
					SteamRemoteStorage.SetCloudEnabledForApp(value);
				}
			}

			public static bool IsEnabled
			{
				get
				{
					if (IsEnabledForAccount)
					{
						return IsEnabledForApp;
					}
					return false;
				}
			}

			public static RemoteStorageLocalFileChangeEvent EventLocalFileChange
			{
				get
				{
					if (m_RemoteStorageLocalFileChange_t == null)
					{
						m_RemoteStorageLocalFileChange_t = Callback<RemoteStorageLocalFileChange_t>.Create(eventRemoteStorageLocalFileChange.Invoke);
					}
					return eventRemoteStorageLocalFileChange;
				}
			}

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void Init()
			{
				eventRemoteStorageLocalFileChange = new RemoteStorageLocalFileChangeEvent();
				m_RemoteStorageLocalFileChange_t = null;
				m_RemoteStorageFileReadAsyncComplete_t = null;
				m_RemoteStorageFileShareResult_t = null;
				m_RemoteStorageFileWriteAsyncComplete_t = null;
				m_RemoteStorageDownloadUGCResult_t = null;
			}

			public static bool FileDelete(string file)
			{
				return SteamRemoteStorage.FileDelete(file);
			}

			public static bool FileExists(string file)
			{
				return SteamRemoteStorage.FileExists(file);
			}

			public static bool FileForget(string file)
			{
				return SteamRemoteStorage.FileForget(file);
			}

			public static byte[] FileRead(string file)
			{
				int fileSize = SteamRemoteStorage.GetFileSize(file);
				byte[] array = new byte[fileSize];
				SteamRemoteStorage.FileRead(file, array, fileSize);
				return array;
			}

			public static string FileReadString(string fileName, Encoding encoding)
			{
				byte[] array = new byte[SteamRemoteStorage.GetFileSize(fileName)];
				SteamRemoteStorage.FileRead(fileName, array, array.Length);
				return encoding.GetString(array);
			}

			public static T FileReadJson<T>(string fileName, Encoding encoding)
			{
				int fileSize = SteamRemoteStorage.GetFileSize(fileName);
				if (fileSize <= 0)
				{
					return default(T);
				}
				byte[] array = new byte[fileSize];
				SteamRemoteStorage.FileRead(fileName, array, array.Length);
				return JsonUtility.FromJson<T>(encoding.GetString(array));
			}

			public static void FileReadAsync(string file, Action<byte[], bool> callback)
			{
				if (callback == null)
				{
					return;
				}
				if (m_RemoteStorageFileReadAsyncComplete_t == null)
				{
					m_RemoteStorageFileReadAsyncComplete_t = CallResult<RemoteStorageFileReadAsyncComplete_t>.Create();
				}
				int size = SteamRemoteStorage.GetFileSize(file);
				SteamAPICall_t hAPICall = SteamRemoteStorage.FileReadAsync(file, 0u, (uint)size);
				m_RemoteStorageFileReadAsyncComplete_t.Set(hAPICall, delegate(RemoteStorageFileReadAsyncComplete_t r, bool e)
				{
					if (!e && r.m_eResult == EResult.k_EResultOK)
					{
						byte[] array = new byte[size];
						SteamRemoteStorage.FileReadAsyncComplete(r.m_hFileReadAsync, array, r.m_cubRead);
						callback(array, e);
					}
					else
					{
						callback(new byte[0], e);
					}
				});
			}

			public static void FileShare(string file, Action<RemoteStorageFileShareResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_RemoteStorageFileShareResult_t == null)
					{
						m_RemoteStorageFileShareResult_t = CallResult<RemoteStorageFileShareResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamRemoteStorage.FileShare(file);
					m_RemoteStorageFileShareResult_t.Set(hAPICall, callback.Invoke);
				}
			}

			public static bool FileWrite(string file, byte[] data)
			{
				return SteamRemoteStorage.FileWrite(file, data, data.Length);
			}

			public static bool FileWrite(string file, string body, Encoding encoding)
			{
				byte[] bytes = encoding.GetBytes(body);
				return FileWrite(file, bytes);
			}

			public static bool FileWrite(string file, string body)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(body);
				return FileWrite(file, bytes);
			}

			public static bool FileWrite(string fileName, object JsonObject, Encoding encoding)
			{
				return FileWrite(fileName, JsonUtility.ToJson(JsonObject), encoding);
			}

			public static bool FileWrite(string fileName, object JsonObject)
			{
				return FileWrite(fileName, JsonUtility.ToJson(JsonObject), Encoding.UTF8);
			}

			public static void FileWriteAsync(string file, byte[] data, Action<RemoteStorageFileWriteAsyncComplete_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_RemoteStorageFileWriteAsyncComplete_t == null)
					{
						m_RemoteStorageFileWriteAsyncComplete_t = CallResult<RemoteStorageFileWriteAsyncComplete_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamRemoteStorage.FileWriteAsync(file, data, (uint)data.Length);
					m_RemoteStorageFileWriteAsyncComplete_t.Set(hAPICall, callback.Invoke);
				}
			}

			public static void FileWriteAsync(string file, string body, Encoding encoding, Action<RemoteStorageFileWriteAsyncComplete_t, bool> callback)
			{
				byte[] bytes = encoding.GetBytes(body);
				FileWriteAsync(file, bytes, callback);
			}

			public static void FileWriteAsync(string fileName, object JsonObject, Encoding encoding, Action<RemoteStorageFileWriteAsyncComplete_t, bool> callback)
			{
				FileWriteAsync(fileName, JsonUtility.ToJson(JsonObject), encoding, callback);
			}

			public static bool FileWriteStreamCancel(UGCFileWriteStreamHandle_t handle)
			{
				return SteamRemoteStorage.FileWriteStreamCancel(handle);
			}

			public static bool FileWriteStreamClose(UGCFileWriteStreamHandle_t handle)
			{
				return SteamRemoteStorage.FileWriteStreamClose(handle);
			}

			public static UGCFileWriteStreamHandle_t FileWriteStreamOpen(string file)
			{
				return SteamRemoteStorage.FileWriteStreamOpen(file);
			}

			public static bool FileWriteStreamWriteChunk(UGCFileWriteStreamHandle_t handle, byte[] data)
			{
				return SteamRemoteStorage.FileWriteStreamWriteChunk(handle, data, data.Length);
			}

			public static int GetCachedUGCCount()
			{
				return SteamRemoteStorage.GetCachedUGCCount();
			}

			public static UGCHandle_t GetCachedUGCHandle(int index)
			{
				return SteamRemoteStorage.GetCachedUGCHandle(index);
			}

			public static UGCHandle_t[] GetCashedUGCHandles()
			{
				int cachedUGCCount = SteamRemoteStorage.GetCachedUGCCount();
				UGCHandle_t[] array = new UGCHandle_t[cachedUGCCount];
				for (int i = 0; i < cachedUGCCount; i++)
				{
					array[i] = SteamRemoteStorage.GetCachedUGCHandle(i);
				}
				return array;
			}

			public static int GetFileCount()
			{
				return SteamRemoteStorage.GetFileCount();
			}

			public static RemoteStorageFile[] GetFiles()
			{
				int fileCount = SteamRemoteStorage.GetFileCount();
				RemoteStorageFile[] array = new RemoteStorageFile[fileCount];
				for (int i = 0; i < fileCount; i++)
				{
					int pnFileSizeInBytes;
					string fileNameAndSize = SteamRemoteStorage.GetFileNameAndSize(i, out pnFileSizeInBytes);
					DateTime timestamp = new DateTime(1970, 1, 1).AddSeconds(SteamRemoteStorage.GetFileTimestamp(fileNameAndSize));
					array[i] = new RemoteStorageFile
					{
						name = fileNameAndSize,
						size = pnFileSizeInBytes,
						timestamp = timestamp
					};
				}
				return array;
			}

			public static RemoteStorageFile[] GetFiles(string extension)
			{
				int fileCount = SteamRemoteStorage.GetFileCount();
				RemoteStorageFile[] array = new RemoteStorageFile[fileCount];
				int num = 0;
				for (int i = 0; i < fileCount; i++)
				{
					int pnFileSizeInBytes;
					string fileNameAndSize = SteamRemoteStorage.GetFileNameAndSize(i, out pnFileSizeInBytes);
					if (fileNameAndSize.ToLower().EndsWith(extension))
					{
						DateTime timestamp = new DateTime(1970, 1, 1).AddSeconds(SteamRemoteStorage.GetFileTimestamp(fileNameAndSize));
						array[num] = new RemoteStorageFile
						{
							name = fileNameAndSize,
							size = pnFileSizeInBytes,
							timestamp = timestamp
						};
						num++;
					}
				}
				Array.Resize(ref array, num);
				return array;
			}

			public static DateTime GetFileTimestamp(string name)
			{
				return new DateTime(1970, 1, 1).AddSeconds(SteamRemoteStorage.GetFileTimestamp(name));
			}

			public static int GetLocalFileChangeCount()
			{
				return SteamRemoteStorage.GetLocalFileChangeCount();
			}

			public static string GetLocalFileChange(int index, out ERemoteStorageLocalFileChange changeType, out ERemoteStorageFilePathType pathType)
			{
				return SteamRemoteStorage.GetLocalFileChange(index, out changeType, out pathType);
			}

			public static bool GetQuota(out ulong totalBytes, out ulong remainingBytes)
			{
				return SteamRemoteStorage.GetQuota(out totalBytes, out remainingBytes);
			}

			public static ERemoteStoragePlatform GetSyncPlatforms(string file)
			{
				return SteamRemoteStorage.GetSyncPlatforms(file);
			}

			public static bool GetUGCDetails(UGCHandle_t handle, out AppId_t appId, out string name, out int size, out CSteamID owner)
			{
				return SteamRemoteStorage.GetUGCDetails(handle, out appId, out name, out size, out owner);
			}

			public static bool GetUGCDownloadProgress(UGCHandle_t handle, out int downloaded, out int expected)
			{
				return SteamRemoteStorage.GetUGCDownloadProgress(handle, out downloaded, out expected);
			}

			public static bool SetSyncPlatforms(string file, ERemoteStoragePlatform platform)
			{
				return SteamRemoteStorage.SetSyncPlatforms(file, platform);
			}

			public static void UGCDownload(UGCHandle_t handle, uint priority, Action<RemoteStorageDownloadUGCResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_RemoteStorageDownloadUGCResult_t == null)
					{
						m_RemoteStorageDownloadUGCResult_t = CallResult<RemoteStorageDownloadUGCResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamRemoteStorage.UGCDownload(handle, priority);
					m_RemoteStorageDownloadUGCResult_t.Set(hAPICall, callback.Invoke);
				}
			}

			public static void UGCDownloadToLocation(UGCHandle_t handle, string location, uint priority, Action<RemoteStorageDownloadUGCResult_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_RemoteStorageDownloadUGCResult_t == null)
					{
						m_RemoteStorageDownloadUGCResult_t = CallResult<RemoteStorageDownloadUGCResult_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamRemoteStorage.UGCDownloadToLocation(handle, location, priority);
					m_RemoteStorageDownloadUGCResult_t.Set(hAPICall, callback.Invoke);
				}
			}

			public static byte[] UGCRead(UGCHandle_t handle)
			{
				SteamRemoteStorage.GetUGCDetails(handle, out var _, out var _, out var pnFileSizeInBytes, out var _);
				byte[] array = new byte[pnFileSizeInBytes];
				SteamRemoteStorage.UGCRead(handle, array, pnFileSizeInBytes, 0u, EUGCReadAction.k_EUGCRead_ContinueReadingUntilFinished);
				return array;
			}
		}
	}
}
