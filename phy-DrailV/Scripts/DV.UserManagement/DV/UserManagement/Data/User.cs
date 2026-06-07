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
	public class User : IUserProfile, IDisposable
	{
		public delegate void SessionSelectionDelegate(IGameSession selectedSession);

		public delegate void CopySessionPostprocessor(User user, GameSession session);

		public delegate void CopySaveGamePostprocessor(User user, GameSession session, SaveGameSnapshot snapshot);

		internal const int InternalUserDataVersion = 1;

		internal const int UserUID_Digits = 3;

		private Dictionary<string, ObservableCollection<IGameSession>> sessions;

		private Dictionary<string, UniqueNumbers> sessionUIDs = new Dictionary<string, UniqueNumbers>();

		[JsonProperty]
		private Dictionary<string, int> selectedSessionUID = new Dictionary<string, int>();

		private string basePath;

		private string dirName;

		private string gameDataPath;

		private IStorageProvider storage;

		private UserManager manager;

		internal static readonly Regex UserDirPattern = new Regex("^([0-9]{" + 3 + "})_.*$");

		internal static readonly string UIDFormat = new string('0', 3);

		internal const string GameDataFolderName = "GameData";

		internal static readonly AJSONDataUpgrader[] InternalUserDataUpgraders = new AJSONDataUpgrader[0];

		[JsonIgnore]
		public int UID { get; private set; }

		public string Name { get; set; }

		[JsonProperty]
		public string Signature { get; private set; }

		[JsonIgnore]
		public UserPreferences Preferences { get; private set; }

		[JsonProperty]
		public JObject GameData { get; private set; }

		[JsonProperty]
		public int DataVersion { get; private set; } = 1;

		[JsonIgnore]
		public Dictionary<string, ReadOnlyObservableCollection<IGameSession>> Sessions { get; private set; }

		[JsonIgnore]
		public Dictionary<string, IGameSession> CurrentSessionPerMode { get; private set; }

		[JsonIgnore]
		public IGameSession CurrentSession { get; private set; }

		[JsonProperty]
		public string CurrentMode { get; private set; }

		internal byte[] EncryptionKey { get; private set; }

		[JsonIgnore]
		public string UserBasePath => basePath;

		[JsonIgnore]
		public string GameDataPath => gameDataPath;

		[JsonIgnore]
		public string PreferencesPath => GetPreferencesPath(this);

		[JsonIgnore]
		public IStorageProvider Storage => storage;

		public event SessionSelectionDelegate SessionSelected;

		internal User(UserManager manager, IStorageProvider storage, int uid, string name, string path)
			: this(manager)
		{
			this.storage = storage;
			UID = uid;
			Name = name;
			basePath = path;
			Signature = DV.UserManagement.Util.Util.GenerateSignature();
			GameData = new JObject();
			if (manager.keyProvider != null)
			{
				EncryptionKey = manager.keyProvider.GetKeyFor(UID, Name, Signature);
			}
			CreateObservableLists();
			PrepareGameData();
			Preferences = new UserPreferences(storage, PreferencesPath);
		}

		private User(UserManager manager)
		{
			this.manager = manager;
			sessions = new Dictionary<string, ObservableCollection<IGameSession>>();
			selectedSessionUID = new Dictionary<string, int>();
			CurrentSessionPerMode = new Dictionary<string, IGameSession>();
			GameData = new JObject();
			for (int i = 0; i < manager.gameModeList.Length; i++)
			{
				sessions.Add(manager.gameModeList[i], new ObservableCollection<IGameSession>());
				selectedSessionUID.Add(manager.gameModeList[i], -1);
				CurrentSessionPerMode.Add(manager.gameModeList[i], null);
				sessionUIDs.Add(manager.gameModeList[i], new UniqueNumbers(3));
			}
		}

		private string GetDirName(string path)
		{
			int num = path.Replace('\\', '/').LastIndexOf('/');
			if (num >= 0 && num < path.Length)
			{
				return path.Substring(num + 1);
			}
			return path;
		}

		private void PrepareGameData()
		{
			dirName = GetDirName(basePath);
			gameDataPath = storage.SanitizeName(Path.Combine(basePath, "GameData"));
			if (!storage.DirectoryExists(gameDataPath))
			{
				storage.CreateDirectory(gameDataPath);
			}
		}

		private void CreateObservableLists()
		{
			Sessions = new Dictionary<string, ReadOnlyObservableCollection<IGameSession>>();
			for (int i = 0; i < manager.gameModeList.Length; i++)
			{
				Sessions.Add(manager.gameModeList[i], new ReadOnlyObservableCollection<IGameSession>(sessions[manager.gameModeList[i]]));
			}
		}

		internal static User Load(UserManager manager, int uid, IStorageProvider storage, string path)
		{
			JObject value = JsonConvert.DeserializeObject<JObject>(storage.ReadFileToString(Path.Combine(path, "userData.json")), UserManager.JSON_SERIALIZER_SETTINGS).Upgrade(manager, path, storage, InternalUserDataUpgraders, manager.userDataUpgraders);
			User user = new User(manager);
			value.Populate(user);
			user.UID = uid;
			user.basePath = path;
			user.storage = storage;
			user.manager = manager;
			if (user.GameData == null)
			{
				user.GameData = new JObject();
			}
			user.PrepareGameData();
			if (manager.keyProvider != null)
			{
				user.EncryptionKey = manager.keyProvider.GetKeyFor(user.UID, user.Name, user.Signature);
			}
			try
			{
				user.Preferences = UserPreferences.Load(storage, GetPreferencesPath(user));
			}
			catch (Exception ex)
			{
				Debug.LogError("User preferences for " + user.Name + " couldn't be loaded: " + ex.Message + "\n" + ex.StackTrace);
				user.Preferences = new UserPreferences(storage, GetPreferencesPath(user));
			}
			GameSession gameSession = null;
			string[] gameModeList = manager.gameModeList;
			foreach (string text in gameModeList)
			{
				List<string> list = storage.ListDirectories(Path.Combine(path, text));
				List<KeyValuePair<string, int>> list2 = new List<KeyValuePair<string, int>>();
				List<string> list3 = new List<string>();
				foreach (string item in list)
				{
					if (!GameSession.SessionNamePattern.IsMatch(item))
					{
						Debug.LogWarning("Directory '" + item + "' in " + text + " for user " + user.Name + " doesn't follow the expected naming pattern, skipping");
					}
					else
					{
						int num = int.Parse(GameSession.SessionNamePattern.Match(item).Groups[1].Value);
						if (user.sessionUIDs[text].Contains(num))
						{
							list3.Add(item);
							continue;
						}
						user.sessionUIDs[text].Put(num);
						list2.Add(new KeyValuePair<string, int>(item, num));
					}
				}
				foreach (string item2 in list3)
				{
					if (!user.sessionUIDs[text].HasFree)
					{
						Debug.LogError($"No free unique identifiers left for a session, maximum of {user.sessionUIDs[text].MaxCount} is already reached");
						break;
					}
					int value2 = user.sessionUIDs[text].TakeFirstFree();
					list2.Add(new KeyValuePair<string, int>(item2, value2));
				}
				foreach (KeyValuePair<string, int> item3 in list2)
				{
					try
					{
						GameSession gameSession2 = GameSession.Load(manager, user, item3.Value, storage, Path.Combine(path, text.ToString(), item3.Key));
						if (gameSession2.SessionID == user.selectedSessionUID[text])
						{
							user.CurrentSessionPerMode[text] = gameSession2;
							if (gameSession2.GameMode == user.CurrentMode)
							{
								user.CurrentSession = gameSession2;
							}
						}
						user.PutSession(gameSession2);
						if (gameSession == null && gameSession2.LatestSave != null)
						{
							gameSession = gameSession2;
						}
						else if (gameSession != null && gameSession2.LatestSave != null && gameSession2.LatestSave.Timestamp > gameSession.LatestSave.Timestamp)
						{
							gameSession = gameSession2;
						}
					}
					catch (Exception ex2)
					{
						Debug.LogError("Couldn't load career " + item3.Key + " for user " + user.Name + ": " + ex2.Message + "\n" + ex2.StackTrace);
					}
				}
				if (user.CurrentSessionPerMode[text] == null && user.sessions[text].Count > 0)
				{
					user.CurrentSessionPerMode[text] = user.sessions[text].Last();
				}
			}
			if (user.CurrentSession == null && gameSession != null)
			{
				user.SelectSession(gameSession);
			}
			user.CreateObservableLists();
			return user;
		}

		public void Save(UserSavingMode savingMode = UserSavingMode.AllSessions)
		{
			JObject jObject = JObject.FromObject(this);
			jObject.SetVersion(manager.UserDataVersion);
			storage.WriteFile(Path.Combine(basePath, "userData.json"), jObject.ToString());
			Preferences.Save();
			switch (savingMode)
			{
			case UserSavingMode.CurrentSession:
				CurrentSession?.Save();
				break;
			case UserSavingMode.AllSessions:
			{
				for (int i = 0; i < manager.gameModeList.Length; i++)
				{
					ObservableCollection<IGameSession> observableCollection = sessions[manager.gameModeList[i]];
					for (int j = 0; j < observableCollection.Count; j++)
					{
						observableCollection[j].Save();
					}
				}
				break;
			}
			}
		}

		private void PutSession(GameSession session)
		{
			ObservableCollection<IGameSession> value = null;
			if (!sessions.TryGetValue(session.GameMode, out value))
			{
				value = new ObservableCollection<IGameSession>();
				sessions.Add(session.GameMode, value);
			}
			value.Add(session);
		}

		public GameSession StartSession(string mode, string world, string name = "")
		{
			if (!manager.gameModeSet.Contains(mode))
			{
				throw new ArgumentException("Game mode '" + mode + "' is invalid for the current UserManager", "mode");
			}
			if (string.IsNullOrEmpty(name))
			{
				name = GetGenericSessionName(mode);
			}
			int sessionID = sessionUIDs[mode].TakeFirstFree();
			GameSession gameSession = new GameSession(manager, storage, Path.Combine(basePath, mode.ToString(), sessionID.ToString(GameSession.UIDFormat) + "_" + UserManager.GetIdentifierString(name.Clamp(32))), this, name, mode, world, sessionID, new ObservableCollection<ISaveGame>());
			PutSession(gameSession);
			CurrentSession = gameSession;
			CurrentMode = mode;
			CurrentSessionPerMode[mode] = gameSession;
			selectedSessionUID[mode] = gameSession.SessionID;
			this.SessionSelected?.Invoke(gameSession);
			return gameSession;
		}

		public void DeleteSession(GameSession session)
		{
			if (session == null)
			{
				throw new ArgumentNullException("session");
			}
			if (!sessions[session.GameMode].Contains(session))
			{
				throw new ArgumentException("Session " + session.Name + " is not known to this user, can't be removed", "session");
			}
			session.Dispose();
			storage.DeleteDirectory(session.BasePath);
			sessions[session.GameMode].Remove(session);
			sessionUIDs[session.GameMode].Remove(session.SessionID);
			FindNewSelectionFor(session.GameMode);
		}

		private void FindNewSelectionFor(string mode)
		{
			if (!manager.gameModeSet.Contains(mode))
			{
				throw new ArgumentException("Game mode '" + mode + "' is invalid for the current UserManager", "mode");
			}
			IGameSession gameSession = sessions[mode].OrderByDescending((IGameSession s) => (s.LatestSave == null) ? DateTimeOffset.MinValue : s.LatestSave.Timestamp).FirstOrDefault();
			if (gameSession != null)
			{
				selectedSessionUID[mode] = gameSession.SessionID;
				CurrentSessionPerMode[mode] = gameSession;
			}
			else
			{
				selectedSessionUID[mode] = -1;
				CurrentSessionPerMode[mode] = null;
			}
			if (CurrentMode == mode)
			{
				CurrentSession = gameSession;
				this.SessionSelected?.Invoke(null);
			}
		}

		public void SelectSession(IGameSession session)
		{
			if (session != null && sessions[session.GameMode].Contains(session))
			{
				selectedSessionUID[session.GameMode] = session.SessionID;
				CurrentSessionPerMode[session.GameMode] = session;
				CurrentSession = session;
				CurrentMode = session.GameMode;
				this.SessionSelected?.Invoke(session);
				return;
			}
			throw new ArgumentException("Provided session is not known to this user, bad usage", "session");
		}

		public string GetGenericSessionName(string mode)
		{
			string Prefix = mode + " ";
			if (sessions == null)
			{
				return Prefix + 1;
			}
			ObservableCollection<IGameSession> value = null;
			if (!sessions.TryGetValue(mode, out value))
			{
				return Prefix + 1;
			}
			int i;
			for (i = value.Count + 1; value.Any((IGameSession f) => f.Name == Prefix + i); i++)
			{
			}
			return Prefix + i;
		}

		public void CopyPreferencesFrom(User otherUser)
		{
			if (otherUser == this || otherUser == null)
			{
				throw new ArgumentException("'otherUser' can't be null or the same user");
			}
			byte[] data = storage.ReadFileToBytes(otherUser.PreferencesPath);
			storage.WriteFile(PreferencesPath, data);
			Preferences.Reload();
		}

		public GameSession CopySessionFrom(User otherUser, GameSession session, CopySessionPostprocessor sessionPostProc = null, CopySaveGamePostprocessor savePostProc = null)
		{
			if (otherUser == null || sessions == null || otherUser == this)
			{
				throw new ArgumentNullException("Neither 'otherUser' nor 'sessions' can be null, or copy from the same user");
			}
			if (!otherUser.Sessions[session.GameMode].Contains(session))
			{
				throw new ArgumentException(string.Format("Provided '{0}' is not associated with '{1}'", "session", otherUser));
			}
			int sessionID = sessionUIDs[session.GameMode].TakeFirstFree();
			GameSession gameSession = new GameSession(manager, storage, Path.Combine(basePath, session.GameMode, sessionID.ToString(GameSession.UIDFormat) + "_" + UserManager.GetIdentifierString(session.Name.Clamp(32))), this, session.Name, session.GameMode, session.World, sessionID, new ObservableCollection<ISaveGame>());
			gameSession.GameData = new JObject(session.GameData);
			sessionPostProc?.Invoke(this, gameSession);
			PutSession(gameSession);
			gameSession.CopySavesFrom(session, savePostProc);
			gameSession.Save();
			return gameSession;
		}

		public bool CanCreateNewSessions(string gameMode)
		{
			if (sessionUIDs.TryGetValue(gameMode, out var value))
			{
				return value.HasFree;
			}
			return false;
		}

		public override string ToString()
		{
			return "[" + UID.ToString(UIDFormat) + "] " + Name;
		}

		public void Dispose()
		{
			foreach (KeyValuePair<string, ObservableCollection<IGameSession>> session in sessions)
			{
				foreach (GameSession item in session.Value)
				{
					item.Dispose();
				}
			}
			Preferences.Dispose();
		}

		private static string GetPreferencesPath(User user)
		{
			return Path.Combine("Preferences", user.dirName + ".ini");
		}
	}
}
