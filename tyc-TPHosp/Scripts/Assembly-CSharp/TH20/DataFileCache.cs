#define LOG_LEVEL_VERBOSE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class DataFileCache : MustCallDestroy
	{
		private readonly Dictionary<string, BaseOnlineDataFile> _uploadData = new Dictionary<string, BaseOnlineDataFile>();

		private readonly Dictionary<OnlinePlayerID, Dictionary<string, BaseOnlineDataFile>> _downloadData = new Dictionary<OnlinePlayerID, Dictionary<string, BaseOnlineDataFile>>();

		private bool _isDestroyed;

		private Coroutine _uploadCoroutine;

		public void ClearFiles()
		{
			_uploadData.Clear();
			_downloadData.Clear();
		}

		public void PrintFiles()
		{
			UnityEngine.Debug.Log("DataFile Cache \n\tLocal Files:");
			UnityEngine.Debug.Log("Local Player Cache");
			foreach (KeyValuePair<string, BaseOnlineDataFile> uploadDatum in _uploadData)
			{
				UnityEngine.Debug.Log("PlayerID: " + uploadDatum.Key + "DataFile :\n\t" + uploadDatum.Value.GetFilename());
			}
			UnityEngine.Debug.Log("Friend Cache");
			foreach (KeyValuePair<OnlinePlayerID, Dictionary<string, BaseOnlineDataFile>> downloadDatum in _downloadData)
			{
				UnityEngine.Debug.Log("PlayerID" + downloadDatum.Key.ToString() + "DataFile:");
				foreach (KeyValuePair<string, BaseOnlineDataFile> item in downloadDatum.Value)
				{
					UnityEngine.Debug.Log("\t" + item.Value.GetFilename());
				}
			}
		}

		public void StartUploadCoroutine()
		{
			_uploadCoroutine = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(TryUploadEveryInterval());
		}

		private IEnumerator TryUploadEveryInterval()
		{
			while (!_isDestroyed)
			{
				yield return new WaitForSecondsRealtime(10f);
				TryUploadLocalPlayerData();
			}
		}

		private void TryUploadLocalPlayerData()
		{
			foreach (KeyValuePair<string, BaseOnlineDataFile> uploadDatum in _uploadData)
			{
				BaseOnlineDataFile value = uploadDatum.Value;
				if (value == null)
				{
					Logging.Warning("TryUploadLocalPlayerData called with null file: " + uploadDatum.Key);
				}
				else
				{
					value.TryUpload();
				}
			}
		}

		public override void Destroy()
		{
			_isDestroyed = true;
			if (_uploadCoroutine != null)
			{
				OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_uploadCoroutine);
			}
			base.Destroy();
		}

		public void WriteFile<T>(OnlineFileClass fileClass, string fileID, T obj) where T : OnlineManager.IOnlineSerializable
		{
			BaseOnlineDataFile localPlayerDataFile = GetLocalPlayerDataFile(fileClass, fileID, createIfNone: true);
			if (localPlayerDataFile != null)
			{
				localPlayerDataFile.Serialize(obj);
				localPlayerDataFile.TryUpload();
			}
		}

		public T ReadFile<T>(OnlineFileClass fileClass, string fileID, OnlinePlayerID playerID) where T : OnlineManager.IOnlineSerializable
		{
			BaseOnlineDataFile friendDataFile = GetFriendDataFile(fileClass, fileID, playerID, createIfNone: true);
			if (friendDataFile == null)
			{
				return default(T);
			}
			if (friendDataFile.Deserialize<T>(out var obj) != EOnlineResult.EOnlineResultOk)
			{
				return default(T);
			}
			return obj;
		}

		public void DeleteFile(OnlineFileClass fileClass, string fileID)
		{
			GetLocalPlayerDataFile(fileClass, fileID, createIfNone: true)?.Delete();
		}

		public BaseOnlineDataFile GetFriendDataFile(OnlineFileClass fileClass, string fileID, OnlinePlayerID playerID, bool createIfNone = false)
		{
			if (!_downloadData.TryGetValue(playerID, out var value))
			{
				if (!createIfNone)
				{
					return null;
				}
				value = new Dictionary<string, BaseOnlineDataFile>();
				_downloadData[playerID] = value;
			}
			if (!value.TryGetValue(fileID, out var value2) && createIfNone)
			{
				value2 = (value[fileID] = CreateDataFile(fileClass, fileID, playerID));
			}
			return value2;
		}

		public BaseOnlineDataFile GetLocalPlayerDataFile(OnlineFileClass fileClass, string fileID, bool createIfNone = false)
		{
			if (!_uploadData.TryGetValue(fileID, out var value) && createIfNone)
			{
				value = CreateDataFile(fileClass, fileID);
				_uploadData[fileID] = value;
			}
			return value;
		}

		public Dictionary<OnlinePlayerID, BaseOnlineDataFile> GatherDataFiles(OnlineFileClass fileClass, string fileID, List<OnlinePlayerID> onlineIDs, bool createIfNone)
		{
			Dictionary<OnlinePlayerID, BaseOnlineDataFile> dictionary = new Dictionary<OnlinePlayerID, BaseOnlineDataFile>();
			if (onlineIDs == null)
			{
				foreach (OnlinePlayerID friendPlayerID in OnlineManager.GetFriendPlayerIDs())
				{
					BaseOnlineDataFile friendDataFile = GetFriendDataFile(fileClass, fileID, friendPlayerID, createIfNone);
					if (friendDataFile != null)
					{
						dictionary[friendPlayerID] = friendDataFile;
					}
				}
				return dictionary;
			}
			foreach (OnlinePlayerID onlineID in onlineIDs)
			{
				BaseOnlineDataFile friendDataFile2 = GetFriendDataFile(fileClass, fileID, onlineID, createIfNone);
				if (friendDataFile2 != null)
				{
					dictionary[onlineID] = friendDataFile2;
				}
			}
			return dictionary;
		}

		public List<BaseOnlineDataFile> GatherDataFiles(OnlineFileClass fileClass, OnlinePlayerID playerID, List<string> fileIDList, bool createIfNone)
		{
			List<BaseOnlineDataFile> list = new List<BaseOnlineDataFile>();
			if (!_downloadData.TryGetValue(playerID, out var value))
			{
				if (!createIfNone)
				{
					return null;
				}
				value = new Dictionary<string, BaseOnlineDataFile>();
				_downloadData[playerID] = value;
			}
			for (int i = 0; i < fileIDList.Count; i++)
			{
				if (!value.TryGetValue(fileIDList[i], out var value2))
				{
					if (!createIfNone)
					{
						continue;
					}
					value2 = CreateDataFile(fileClass, fileIDList[i], playerID);
					value[fileIDList[i]] = value2;
				}
				list.Add(value2);
			}
			return list;
		}

		public List<BaseOnlineDataFile> GatherDataFiles(OnlineFileClass fileClass, List<OnlinePlayerID> playerIDList, List<string> fileIDList, bool createIfNone)
		{
			List<BaseOnlineDataFile> list = new List<BaseOnlineDataFile>();
			for (int i = 0; i < playerIDList.Count; i++)
			{
				list.AddRange(GatherDataFiles(fileClass, playerIDList[i], fileIDList, createIfNone));
			}
			return list;
		}

		private BaseOnlineDataFile CreateDataFile(OnlineFileClass fileClass, string filename, OnlinePlayerID playerID)
		{
			if (playerID == OnlinePlayerID.Nil)
			{
				return null;
			}
			if (OnlineManager.GetLocalPlayerID() == OnlinePlayerID.Nil)
			{
				UnityEngine.Debug.Log("No Local User Set up, Dont Create OnlineDataFile");
				return null;
			}
			return new SteamDataFile(fileClass, filename, playerID);
		}

		private BaseOnlineDataFile CreateDataFile(OnlineFileClass fileClass, string filename)
		{
			if (OnlineManager.GetLocalPlayerID() == OnlinePlayerID.Nil)
			{
				UnityEngine.Debug.Log("No Local User Set up, Dont Create OnlineDataFile");
				return null;
			}
			return new SteamDataFile(fileClass, filename);
		}
	}
}
