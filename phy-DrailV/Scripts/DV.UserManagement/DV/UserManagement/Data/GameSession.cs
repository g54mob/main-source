using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DV.Common;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using DV.UserManagement.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement.Data
{
	public class GameSession : IGameSession, IThing, IDisposable
	{
		internal const int GameSessionDataVersion = 1;

		internal const int SessionUID_Digits = 3;

		private static readonly Dictionary<SaveType, int> SaveTypeMaxCounts = new Dictionary<SaveType, int>
		{
			{
				SaveType.Quick,
				1
			},
			{
				SaveType.Auto,
				20
			},
			{
				SaveType.Manual,
				int.MaxValue
			}
		};

		[JsonIgnore]
		private ObservableCollection<ISaveGame> saves;

		[JsonIgnore]
		private UniqueNumbers saveUIDs = new UniqueNumbers(5);

		internal static readonly AJSONDataUpgrader[] InternalSessionDataUpgraders = new AJSONDataUpgrader[0];

		internal static readonly Regex SessionNamePattern = new Regex("^([0-9]{" + 3 + "})_.*$");

		internal static readonly string UIDFormat = new string('0', 3);

		private IStorageProvider storage;

		private UserManager manager;

		private User owner;

		[JsonProperty]
		public int DataVersion { get; private set; } = 1;

		[JsonProperty]
		public string Name { get; set; }

		[JsonProperty]
		public string GameMode { get; private set; }

		[JsonProperty]
		public string World { get; private set; }

		[JsonProperty]
		public int SessionID { get; private set; }

		[JsonProperty]
		public JObject GameData { get; internal set; }

		[JsonIgnore]
		public ReadOnlyObservableCollection<ISaveGame> Saves { get; private set; }

		[JsonIgnore]
		public IUserProfile Owner => owner;

		[JsonIgnore]
		public string BasePath { get; private set; }

		[JsonIgnore]
		public ISaveGame LatestSave
		{
			get
			{
				if (saves == null || saves.Count < 1)
				{
					return null;
				}
				return saves[0];
			}
		}

		internal GameSession(UserManager manager, IStorageProvider storage, string path, User owner, string name, string gameMode, string world, int sessionID, ObservableCollection<ISaveGame> saves)
		{
			this.owner = owner;
			Name = name;
			GameMode = gameMode;
			World = world;
			SessionID = sessionID;
			GameData = new JObject();
			BasePath = storage.SanitizeName(path);
			this.saves = saves;
			this.storage = storage;
			this.manager = manager;
			Saves = new ReadOnlyObservableCollection<ISaveGame>(this.saves);
		}

		internal static GameSession Load(UserManager manager, User owner, int uid, IStorageProvider storage, string path)
		{
			GameSession gameSession = JObject.Parse(storage.ReadFileToString(Path.Combine(path, "sessionData.json"))).Upgrade(manager, path, storage, InternalSessionDataUpgraders, manager.sessionDataUpgraders).ToObject<GameSession>();
			if (!manager.gameModeSet.Contains(gameSession.GameMode))
			{
				throw new InvalidDataException("GameSession has invalid GameMode '" + gameSession.GameMode + "'");
			}
			gameSession.SessionID = uid;
			gameSession.BasePath = storage.SanitizeName(path);
			gameSession.owner = owner;
			gameSession.storage = storage;
			gameSession.manager = manager;
			if (gameSession.GameData == null)
			{
				gameSession.GameData = new JObject();
			}
			gameSession.EnumerateSaves();
			return gameSession;
		}

		public void Save()
		{
			string text = Path.Combine(BasePath, "sessionData.json");
			try
			{
				JObject jObject = JObject.FromObject(this);
				if (jObject.Count > 0)
				{
					jObject.SetVersion(manager.SessionDataVersion);
					string text2 = jObject.ToString();
					storage.WriteFile(text + "_temp", text2);
					string text3 = storage.ReadFileToString(text + "_temp").Trim();
					if (text3.Length > 0 && text3 == text2)
					{
						storage.CopyFile(text + "_temp", text);
						storage.DeleteFile(text + "_temp");
					}
					else
					{
						Debug.LogError("Failed to save session data to " + text + ": read-back data is empty or doesn't match the original");
					}
				}
				else
				{
					Debug.LogError("Session data empty, not saving it");
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Failed to save session to " + text + ": " + ex.Message);
				Debug.LogException(ex);
			}
			string path = Path.Combine(BasePath, "Saves");
			if (!storage.DirectoryExists(path))
			{
				storage.CreateDirectory(path);
			}
		}

		private void CheckForPackingUpgrades()
		{
			string text = Path.Combine(BasePath, "Saves");
			List<string> list = storage.ListFiles(text, "*.json");
			for (int i = 0; i < list.Count; i++)
			{
				string text2 = list[i].Substring(0, list[i].Length - ".json".Length);
				string path = Path.Combine(text, list[i]);
				string path2 = Path.Combine(text, text2 + ".sav");
				string path3 = Path.Combine(text, text2 + ".jpg");
				string path4 = Path.Combine(text, text2 + ".save");
				if (!storage.FileExists(path2))
				{
					Debug.LogError("Error while upgrading save file '" + list[i] + "': incomplete, no matching main .sav file found");
					continue;
				}
				try
				{
					byte[] data = storage.ReadFileToBytes(path);
					byte[] data2 = storage.ReadFileToBytes(path2);
					byte[] array = (storage.FileExists(path3) ? storage.ReadFileToBytes(path3) : null);
					List<Paky.InputData> list2 = new List<Paky.InputData>();
					list2.Add(new Paky.InputData(2, data));
					list2.Add(new Paky.InputData(1, data2));
					if (array != null)
					{
						list2.Add(new Paky.InputData(3, array));
					}
					Stream stream = storage.OpenFileForWriting(path4);
					Paky.Pack(list2, "SAVE", 1, stream);
					stream.Close();
					storage.DeleteFile(path);
					storage.DeleteFile(path2);
					if (storage.FileExists(path3))
					{
						storage.DeleteFile(path3);
					}
				}
				catch (Exception ex)
				{
					Debug.LogError("Error while upgrading save file '" + list[i] + "': " + ex.Message);
					Debug.LogException(ex);
				}
			}
		}

		public void ForceRefreshSaves()
		{
			saves.Clear();
			saveUIDs = new UniqueNumbers(5);
			EnumerateSaves();
		}

		protected void EnumerateSaves()
		{
			CheckForPackingUpgrades();
			string text = Path.Combine(BasePath, "Saves");
			List<string> list = storage.ListFiles(text, "*.save");
			List<SaveGameSnapshot> list2 = new List<SaveGameSnapshot>();
			List<SaveGameSnapshot> list3 = new List<SaveGameSnapshot>();
			foreach (string item in list)
			{
				int num = -1;
				Match match = SaveGameSnapshot.SaveSnapshotPattern.Match(item);
				if (!match.Success)
				{
					Debug.LogWarning("Malformed save file name, will auto-generate UID: " + item);
				}
				else
				{
					num = int.Parse(match.Groups[1].Value);
					if (saveUIDs.Contains(num))
					{
						Debug.LogWarning($"Duplicate save file UID = {num}, auto-generating new");
						num = -1;
					}
				}
				string path = item;
				try
				{
					string text2 = Path.Combine(text, item);
					Paky paky = new Paky(storage.OpenFileForReading(text2), "SAVE", 1);
					JObject jObject = JsonConvert.DeserializeObject<JObject>(paky.ReadFirstAsText(2), UserManager.JSON_SERIALIZER_SETTINGS);
					jObject.Upgrade(manager, "", storage, SaveGameSnapshot.InternalSnapshotMetaUpgraders, manager.snapshotMetaUpgraders);
					SaveGameSnapshot saveGameSnapshot = jObject.ToObject<SaveGameSnapshot>();
					if (!manager.gameModeSet.Contains(saveGameSnapshot.GameMode))
					{
						throw new InvalidDataException("Game mode '" + saveGameSnapshot.GameMode + "' is invalid for the current UserManager (" + text2 + ")");
					}
					saveGameSnapshot.LoadedPak = paky;
					saveGameSnapshot.ParentManager = manager;
					saveGameSnapshot.Storage = storage;
					saveGameSnapshot.BasePath = storage.SanitizeName(Path.Combine(text, path));
					saveGameSnapshot.ParentSession = this;
					if (num >= 0)
					{
						saveGameSnapshot.UID = num;
						saveUIDs.Put(saveGameSnapshot.UID);
						list2.Add(saveGameSnapshot);
					}
					else
					{
						list3.Add(saveGameSnapshot);
					}
				}
				catch (Exception ex)
				{
					Debug.LogError("Error loading save file '" + item + "': " + ex.Message + "\n" + ex.StackTrace);
				}
			}
			foreach (SaveGameSnapshot item2 in list3)
			{
				if (!saveUIDs.HasFree)
				{
					Debug.LogError($"No free unique identifiers left for a save game, maximum of {saveUIDs.MaxCount} is already reached");
					break;
				}
				item2.UID = saveUIDs.TakeFirstFree();
				list2.Add(item2);
			}
			list2.Sort((SaveGameSnapshot x, SaveGameSnapshot y) => y.Timestamp.CompareTo(x.Timestamp));
			if (saves != null)
			{
				saves.Clear();
				{
					foreach (SaveGameSnapshot item3 in list2)
					{
						saves.Add(item3);
					}
					return;
				}
			}
			saves = new ObservableCollection<ISaveGame>(list2);
			Saves = new ReadOnlyObservableCollection<ISaveGame>(saves);
		}

		internal void CopySavesFrom(GameSession other, User.CopySaveGamePostprocessor copyProc = null)
		{
			if (saves.Count > 0)
			{
				throw new InvalidOperationException("This should only be used on brand new sessions as a part of the copy process, this one already has some saves");
			}
			foreach (SaveGameSnapshot safe in other.Saves)
			{
				saveUIDs.Put(safe.UID);
				safe.LoadData();
				JObject data = new JObject(safe.Data);
				SaveGameSnapshot saveGameSnapshot2 = new SaveGameSnapshot(manager, this, storage, safe.Type, safe.UID, safe.Timestamp, safe.Name, data, safe.Thumbnail, safe.CustomChunkData);
				if (copyProc != null && Owner is User user)
				{
					copyProc(user, this, saveGameSnapshot2);
				}
				saveGameSnapshot2.WriteData();
				saves.Add(saveGameSnapshot2);
			}
		}

		[Obsolete("Don't use this in code, this is for JSON processing only")]
		[JsonConstructor]
		internal GameSession()
		{
		}

		public void DeleteSaveGame(ISaveGame save)
		{
			if (!saves.Contains(save))
			{
				throw new InvalidOperationException("Savegame slated for deletion doesn't exist in this session");
			}
			saves.Remove(save);
			saveUIDs.Remove(save.UID);
			if (save is SaveGameSnapshot saveGameSnapshot)
			{
				saveGameSnapshot.DeleteData();
			}
		}

		public ISaveGame SaveGame(SaveType type, JObject data, Texture2D thumbnail, List<(int Type, byte[] Data)> customChunks = null, ISaveGame overwrite = null)
		{
			return SaveGame(DateTimeOffset.Now, type, data, thumbnail, customChunks, overwrite);
		}

		private SaveGameSnapshot SaveGame(DateTimeOffset timeStamp, SaveType type, JObject data, Texture2D thumbnail, List<(int Type, byte[] Data)> customChunks = null, ISaveGame overwrite = null)
		{
			return SaveGame((overwrite != null) ? overwrite.Name : timeStamp.ToString("yyyy-MM-dd HH:mm:ss"), timeStamp, type, data, thumbnail, customChunks, overwrite);
		}

		private SaveGameSnapshot SaveGame(string name, DateTimeOffset timeStamp, SaveType type, JObject data, Texture2D thumbnail, List<(int Type, byte[] Data)> customChunks = null, ISaveGame overwrite = null)
		{
			if (customChunks != null)
			{
				foreach (var customChunk in customChunks)
				{
					if (customChunk.Type < 10)
					{
						throw new InvalidDataException(string.Format("One of the custom data chunks has {0} = {1}, which is lower than allowed number for custom chunks, must be >= {2}", "Type", customChunk.Type, 10));
					}
				}
			}
			int uid;
			if (overwrite != null)
			{
				if (!saves.Contains(overwrite))
				{
					throw new InvalidOperationException("Save game slated to be overwritten isn't from this session, thus the operation makes no sense");
				}
				uid = overwrite.UID;
				saves.Remove(overwrite);
				if (overwrite is SaveGameSnapshot saveGameSnapshot)
				{
					saveGameSnapshot.DeleteData();
				}
			}
			else
			{
				if (!saveUIDs.HasFree)
				{
					throw new InvalidOperationException($"No free unique identifiers left, maximum of {saveUIDs.MaxCount} is already reached");
				}
				uid = saveUIDs.TakeFirstFree();
			}
			SaveGameSnapshot saveGameSnapshot2 = new SaveGameSnapshot(manager, this, storage, type, uid, timeStamp, name, data.DeepClone() as JObject, thumbnail, customChunks);
			saveGameSnapshot2.WriteData();
			saves.Insert(0, saveGameSnapshot2);
			if (overwrite == null)
			{
				TrimSaves(type, SaveTypeMaxCounts[type], saveGameSnapshot2);
			}
			return saveGameSnapshot2;
		}

		public int TrimSaves(SaveType type, int maxCount, ISaveGame excluded = null)
		{
			if (maxCount == int.MaxValue)
			{
				return 0;
			}
			int num = 0;
			int num2 = ((excluded != null && excluded.Type == type) ? 1 : 0);
			for (int i = 0; i < saves.Count; i++)
			{
				if (saves[i].Type == type && saves[i] != excluded)
				{
					if (num2 < maxCount)
					{
						num2++;
						continue;
					}
					num++;
					DeleteSaveGame(saves[i]);
					i--;
				}
			}
			return num;
		}

		public int GetSavesCountByType(SaveType type)
		{
			return saves.Count((ISaveGame s) => s.Type == type);
		}

		public bool CanCreateNewSaves(SaveType saveType)
		{
			if (saveUIDs.HasFree)
			{
				return GetSavesCountByType(saveType) < SaveTypeMaxCounts[saveType];
			}
			return false;
		}

		public void MakeCurrent()
		{
			owner.SelectSession(this);
		}

		public override string ToString()
		{
			return "[" + SessionID.ToString(UIDFormat) + " - " + GameMode + "] " + Name;
		}

		public void Dispose()
		{
			foreach (ISaveGame safe in saves)
			{
				safe.Dispose();
			}
		}
	}
}
