using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using DV.UserManagement.Storage.Implementation;
using DV.UserManagement.Util;
using DV.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement
{
	public class UserManager : SingletonBehaviour<UserManager>
	{
		[Serializable]
		private class GlobalData
		{
			public int DataVersion = 1;

			public string LastUser;

			public JObject GameData;
		}

		public delegate void UserChangedDelegate(User previousUser, User currentUser);

		public static readonly Encoding ENCODING = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: false);

		public static JsonSerializerSettings JSON_SERIALIZER_SETTINGS = new JsonSerializerSettings
		{
			DateParseHandling = DateParseHandling.None
		};

		public static bool inMemoryTestingMode;

		[Header("Configuration")]
		[SerializeField]
		private AUserDataPreparation dataPrep;

		[SerializeField]
		internal AGameModeProvider gameModeProvider;

		[SerializeField]
		internal AKeyProvider keyProvider;

		[SerializeField]
		internal AUserNamingProvider namingProvider;

		[Header("Data upgrading")]
		[SerializeField]
		internal APreLoadUpgrader[] dataPreprocessors;

		[SerializeField]
		internal AJSONDataUpgrader[] globalDataUpgraders;

		[SerializeField]
		internal AJSONDataUpgrader[] userDataUpgraders;

		[SerializeField]
		internal AJSONDataUpgrader[] sessionDataUpgraders;

		[SerializeField]
		internal AJSONDataUpgrader[] snapshotMetaUpgraders;

		[SerializeField]
		internal ASaveSnapshotUpgrader[] saveDataUpgraders;

		private ObservableCollection<User> users;

		private UniqueNumbers userUIDs = new UniqueNumbers(3);

		internal const int InternalGlobalDataVersion = 1;

		internal static readonly AJSONDataUpgrader[] InternalGlobalDataUpgraders = new AJSONDataUpgrader[0];

		internal string[] gameModeList;

		internal HashSet<string> gameModeSet;

		private IStorageProvider storage;

		private GlobalData global;

		private static readonly Regex identifierRegex = new Regex("[^\\p{L}0-9_-]", RegexOptions.Compiled);

		public ReadOnlyObservableCollection<User> Users { get; private set; }

		public User CurrentUser { get; private set; }

		public string[] GameModes => gameModeList;

		public bool IsReady { get; private set; }

		public AKeyProvider KeyProvider => keyProvider;

		public AUserNamingProvider NamingProvider => namingProvider;

		public int GlobalDataVersion { get; private set; }

		public int UserDataVersion { get; private set; }

		public int SessionDataVersion { get; private set; }

		public int SnapshotMetaVersion { get; private set; }

		public int SaveDataVersion { get; private set; }

		public IStorageProvider Storage => storage;

		public event UserChangedDelegate UserChanged;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void StaticReload()
		{
			inMemoryTestingMode = false;
		}

		public string GetLocalizationKey(string gameMode)
		{
			return gameModeProvider.GetLocalizationKey(gameMode);
		}

		protected override void Initialize()
		{
			base.Initialize();
			GlobalDataVersion = ComputeMaxVersion(InternalGlobalDataUpgraders, globalDataUpgraders);
			UserDataVersion = ComputeMaxVersion(User.InternalUserDataUpgraders, userDataUpgraders);
			SessionDataVersion = ComputeMaxVersion(GameSession.InternalSessionDataUpgraders, sessionDataUpgraders);
			SnapshotMetaVersion = ComputeMaxVersion(SaveGameSnapshot.InternalSnapshotMetaUpgraders, snapshotMetaUpgraders);
			SaveDataVersion = ComputeMaxVersion(SaveGameSnapshot.InternalGameDataUpgraders, saveDataUpgraders);
			if (gameModeProvider == null)
			{
				Debug.LogWarning("GameModeProvider is not set, using a single 'Default' game mode");
				gameModeList = new string[1] { "Default" };
			}
			else
			{
				gameModeList = gameModeProvider.GetGameModes();
				if (gameModeList == null || gameModeList.Length == 0)
				{
					Debug.LogWarning("GameModeProvider returned an empty list of game modes, using a single 'Default' game mode");
					gameModeList = new string[1] { "Default" };
				}
			}
			gameModeSet = new HashSet<string>(gameModeList);
			storage = new FileSystemStorage();
			if (dataPrep != null)
			{
				dataPrep.PrepareDataBeforeInit(storage, this);
			}
			for (int i = 0; i < dataPreprocessors.Length; i++)
			{
				dataPreprocessors[i].ProcessData(this, storage);
			}
			InitializeData();
			if (dataPrep != null)
			{
				dataPrep.PrepareDataAfterInit(storage, this);
			}
			IsReady = true;
		}

		private static int ComputeMaxVersion(params IEnumerable<AJSONDataUpgrader>[] dataUpgraders)
		{
			int num = 1;
			for (int i = 0; i < dataUpgraders.Length; i++)
			{
				foreach (AJSONDataUpgrader item in (IEnumerable)dataUpgraders[i])
				{
					num = Mathf.Max(num, item.InputVersion + 1);
				}
			}
			return num;
		}

		private static int ComputeMaxVersion(params IEnumerable<ASaveSnapshotUpgrader>[] dataUpgraders)
		{
			int num = 1;
			for (int i = 0; i < dataUpgraders.Length; i++)
			{
				foreach (ASaveSnapshotUpgrader item in (IEnumerable)dataUpgraders[i])
				{
					num = Mathf.Max(num, item.InputVersion + 1);
				}
			}
			return num;
		}

		private void InitializeData()
		{
			if (storage.FileExists("Users/global.json"))
			{
				try
				{
					JObject json = JObject.Parse(storage.ReadFileToString("Users/global.json"));
					json = json.Upgrade(this, "Users/global.json", storage, InternalGlobalDataUpgraders, globalDataUpgraders);
					global = json.ToObject<GlobalData>();
				}
				catch (Exception ex)
				{
					Debug.LogError("Couldn't load global user data: " + ex.Message + "\n" + ex.StackTrace);
					global = new GlobalData();
				}
			}
			else
			{
				global = new GlobalData();
			}
			List<User> list = new List<User>();
			List<string> list2 = storage.ListDirectories("Users");
			List<KeyValuePair<string, int>> list3 = new List<KeyValuePair<string, int>>();
			List<string> list4 = new List<string>();
			User currentUser = null;
			foreach (string item in list2)
			{
				if (User.UserDirPattern.IsMatch(item))
				{
					int num = int.Parse(User.UserDirPattern.Match(item).Groups[1].Value);
					if (userUIDs.Contains(num))
					{
						list4.Add(item);
						continue;
					}
					userUIDs.Put(num);
					list3.Add(new KeyValuePair<string, int>(item, num));
				}
				else
				{
					Debug.LogWarning("Directory '" + item + "' in USERDATA/Users doesn't follow the expected naming pattern, skipping");
				}
			}
			foreach (string item2 in list4)
			{
				if (!userUIDs.HasFree)
				{
					Debug.LogError($"No free unique identifiers left for a user, maximum of {userUIDs.MaxCount} is already reached");
					break;
				}
				int value = userUIDs.TakeFirstFree();
				list3.Add(new KeyValuePair<string, int>(item2, value));
			}
			foreach (KeyValuePair<string, int> item3 in list3)
			{
				try
				{
					User user = User.Load(this, item3.Value, storage, Path.Combine("Users", item3.Key));
					list.Add(user);
					currentUser = user;
					if (user.Name == global.LastUser)
					{
						CurrentUser = user;
					}
				}
				catch (Exception ex2)
				{
					Debug.LogError("Failed to load user from directory " + item3.Key + " because: " + ex2.Message + "\n" + ex2.StackTrace);
				}
			}
			if (CurrentUser == null)
			{
				CurrentUser = currentUser;
			}
			if (list.Count == 0)
			{
				users = new ObservableCollection<User>();
				CreateDefaultUser();
			}
			else
			{
				users = new ObservableCollection<User>(list);
			}
			Users = new ReadOnlyObservableCollection<User>(users);
		}

		private void SaveGlobals()
		{
			try
			{
				JObject jObject = JObject.FromObject(global);
				jObject.SetVersion(GlobalDataVersion);
				storage.WriteFile("Users/global.json", jObject.ToString());
			}
			catch (Exception ex)
			{
				Debug.LogError("Couldn't save global user data: " + ex.Message + "\n" + ex.StackTrace);
			}
		}

		private void CreateDefaultUser(bool save = true)
		{
			CreateUser(namingProvider.DefaultName);
			if (save)
			{
				SaveCurrentUser();
			}
		}

		internal static string GetNewUserFolderName(User user)
		{
			return GetNewUserFolderName(user.UID, user.Name);
		}

		internal static string GetNewUserFolderName(int uid, string userName)
		{
			return uid.ToString(User.UIDFormat) + "_" + GetIdentifierString(userName.Clamp(32));
		}

		private static string GetNewUserPath(int uid, string userName)
		{
			return "Users/" + GetNewUserFolderName(uid, userName);
		}

		public bool IsNameAvailable(string name)
		{
			if (users != null)
			{
				return !users.Any((User u) => u.Name == name);
			}
			return true;
		}

		public User CreateUser(string name)
		{
			if (!userUIDs.HasFree)
			{
				throw new InvalidOperationException($"Maximum number of users is already reached ({userUIDs.MaxCount})");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("User profile name can't be empty", "name");
			}
			if (!IsNameAvailable(name))
			{
				throw new ArgumentException("User name '" + name + "' is already taken", "name");
			}
			int firstFree = userUIDs.FirstFree;
			User user = new User(this, storage, firstFree, name, GetNewUserPath(firstFree, name));
			userUIDs.Put(firstFree);
			CurrentUser = user;
			global.LastUser = CurrentUser.Name;
			SaveGlobals();
			if (users != null)
			{
				users.Add(user);
			}
			user.Save();
			return user;
		}

		public void SwitchUser(User nextUser)
		{
			if (nextUser == null)
			{
				throw new ArgumentNullException("nextUser");
			}
			if (nextUser != CurrentUser)
			{
				if (!users.Contains(nextUser))
				{
					throw new ArgumentException("Provided user isn't known to this UserManager, this shouldn't happen", "nextUser");
				}
				User currentUser = CurrentUser;
				CurrentUser = nextUser;
				global.LastUser = CurrentUser.Name;
				SaveGlobals();
				this.UserChanged?.Invoke(currentUser, nextUser);
			}
		}

		public void DeleteUser(User user)
		{
			if (user == null)
			{
				throw new ArgumentNullException("user");
			}
			if (!users.Contains(user))
			{
				throw new ArgumentException("User '" + user.Name + "' is not known to this UserManager", "user");
			}
			user.Dispose();
			users.Remove(user);
			storage.DeleteDirectory(user.UserBasePath);
			userUIDs.Remove(user.UID);
			if (users.Count == 0)
			{
				CreateDefaultUser();
				this.UserChanged?.Invoke(user, CurrentUser);
				return;
			}
			CurrentUser = users[users.Count - 1];
			global.LastUser = CurrentUser.Name;
			SaveGlobals();
			this.UserChanged?.Invoke(user, CurrentUser);
		}

		public void SaveAllUsers()
		{
			SaveGlobals();
			for (int i = 0; i < users.Count; i++)
			{
				users[i].Save();
			}
		}

		public void SaveCurrentUser()
		{
			SaveGlobals();
			if (CurrentUser != null)
			{
				CurrentUser.Save();
			}
		}

		public bool IsGameModeValid(string mode)
		{
			return gameModeSet.Contains(mode);
		}

		public bool CanCreateNewUser()
		{
			return userUIDs.HasFree;
		}

		public static string GetIdentifierString(string str)
		{
			return identifierRegex.Replace(str, "_");
		}
	}
}
