using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using I2.Loc;
using PimDeWitte.UnityMainThreadDispatcher;
using Pug.Platform;
using PugPlatform;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

public class SteamPlatform : PlatformInterface, IPlatformUserManager, INetworkStateProvider
{
	private class SteamRichPresence : IRichPresence
	{
		private const string STEAM_DISPLAY = "steam_display";

		private const string STEAM_PLAYER_GROUP = "steam_player_group";

		private const string STEAM_PLAYER_GROUP_SIZE = "steam_player_group_size";

		private const string TASK_TOKEN = "task";

		private const string BIOME_TOKEN = "biome";

		private readonly string[] _statusTokens = new string[3] { "", "#Status_InMainMenu", "#Status_InGame" };

		private Dictionary<int, string> _numberStringCache = new Dictionary<int, string>();

		public void StartSession(RichPresenceSessionTypes type)
		{
			SteamFriends.SetRichPresence("steam_display", _statusTokens[(int)type]);
		}

		public void EndSession()
		{
			if (SteamClient.IsValid)
			{
				SteamFriends.ClearRichPresence();
			}
		}

		public void SetPartySize(int size)
		{
			if (!_numberStringCache.TryGetValue(size, out var value))
			{
				value = size.ToString(CultureInfo.InvariantCulture);
				_numberStringCache.Add(size, value);
			}
			SteamFriends.SetRichPresence("steam_player_group_size", value);
		}

		public void SetCurrentBiome(string biome)
		{
			SteamFriends.SetRichPresence("biome", biome);
		}

		public void SetCurrentTask(string task)
		{
			SteamFriends.SetRichPresence("task", task);
		}

		public void SetSessionKey(string sessionKey)
		{
			SteamFriends.SetRichPresence("steam_player_group", sessionKey);
		}
	}

	public const uint APP_ID = 1621690u;

	public const uint TEST_APP_ID = 2347300u;

	public const uint AMBASSADOR_APP_ID = 3621230u;

	private bool isInitialized;

	private string playerPrefsInitialSyncDone;

	private string playerPrefsNoSyncUp;

	private string playerPrefsTimestampPrefix;

	private string playerPrefsHashPrefix;

	private string steamId = "unknown";

	private ulong steamId64;

	private SteamPlatformUserID steamPlatformUserId;

	private bool[] achievementTriggered = new bool[Enum.GetValues(typeof(AchievementID)).Length + 1];

	private string[] achievementSteamIdentifier = new string[Enum.GetValues(typeof(AchievementID)).Length + 1];

	private bool statsInitialized;

	private bool statsRequested;

	private bool statsRequestErrorPrinted;

	private bool isLoggedOn;

	private SteamRichPresence _richPresence;

	private readonly List<uint> appIdList = new List<uint> { 0u, 1232010u, 1621690u };

	private readonly List<uint> dlcAppIdList = new List<uint> { 0u, 4160230u };

	private PlatformInterface.GotControllerTextInput gotControllerTextInputCallback;

	public List<PlatformUserID> PlatformFriends { get; }

	public string Name => "Steam";

	public Platform Platform { get; } = Platform.Steam;

	public string SavePrefix { get; private set; }

	public string BetaBranch => SteamApps.CurrentBetaName;

	public bool IsLoggedOn => isLoggedOn;

	public bool HasNetwork
	{
		get
		{
			if (isLoggedOn)
			{
				return Application.internetReachability != NetworkReachability.NotReachable;
			}
			return false;
		}
	}

	public bool HasNetworkConnection => HasNetwork;

	public event Action<bool> PlatformOverlayStateChanged;

	public event Action<ApplicationFocusChange> ApplicationFocusChanged;

	public event Action<NetworkConnectionStatus> NetworkConnectionStatusChanged;

	public event Action<UserSignInCompleteVO> UserSignInComplete;

	public event Action<string> JoinRequest;

	public string[] GetCommandLine()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		string commandLine = SteamApps.CommandLine;
		string[] array = (string.IsNullOrEmpty(commandLine) ? Array.Empty<string>() : commandLine.Split(' '));
		string[] array2 = new string[commandLineArgs.Length + array.Length];
		commandLineArgs.CopyTo(array2, 0);
		array.CopyTo(array2, commandLineArgs.Length);
		return array2;
	}

	public bool IsPlatformOverlayActive()
	{
		return false;
	}

	public void RegisterSuspendHandler(Action suspendHandler)
	{
	}

	public string GetAccountId()
	{
		return steamId;
	}

	public void GetLocalUserName(Action<string> callback)
	{
		GetUserProfile(GetPlatformUserID(), UserImageSize.None, delegate(UserPlatformProfile profile)
		{
			callback?.Invoke(profile.UserName);
		});
	}

	public void GetUserProfile(PlatformUserID userId, UserImageSize size, Action<UserPlatformProfile> callback)
	{
		callback?.Invoke(new UserPlatformProfile
		{
			UserName = ""
		});
	}

	public void GetUserDisplayImage(PlatformUserID userId, UserImageSize size, Action<UserPlatformProfile> callback)
	{
		callback?.Invoke(new UserPlatformProfile());
	}

	public void SignInDefaultUser()
	{
	}

	public PlatformUserID GetPlatformUserID()
	{
		return steamPlatformUserId;
	}

	public bool IsUserIdValid(PlatformUserID id)
	{
		return true;
	}

	public void RefreshPlatformFriends(bool getProfiles = false)
	{
	}

	public void SendInvitation(string sessionId, List<PlatformUserID> invitees, Action<bool> callback)
	{
		callback?.Invoke(obj: true);
	}

	public string GetSystemLanguage()
	{
		return LocalizationManager.GetLanguageCode(SteamUtils.SteamUILanguage);
	}

	public bool TryStartFreeCommunication(bool showPlatformUi)
	{
		return true;
	}

	public void EndFreeCommunication()
	{
	}

	public void SetPresence(Dictionary<string, string> presence)
	{
		UnityEngine.Debug.LogWarning("SteamPlatform.SetPresence is not implemented.");
	}

	public void ClearPresence()
	{
		UnityEngine.Debug.LogWarning("SteamPlatform.ClearPresence is not implemented.");
	}

	public bool IsUserPremium(bool showPrompt, Action<bool> premiumStatusCallback)
	{
		return true;
	}

	public void OpenUserProfile(PlatformUserID userId)
	{
	}

	public void CheckUserPrivileges(PlatformInterface.UserPrivileges privilegesToCheck, bool showUI, Action<PlatformInterface.PrivilegesResult> callback)
	{
		callback?.Invoke(new PlatformInterface.PrivilegesResult
		{
			CheckStatus = PlatformInterface.PrivilegeCheckStatus.Completed,
			isAllowedToPlayMultiplayer = true
		});
	}

	public void RefreshBlockedUsers(List<PlatformUserID> platformUserIds, Action<bool> callback)
	{
		callback?.Invoke(obj: true);
	}

	public void IsUserBlocked(List<PlatformUserID> accountIds, Action<bool> callback)
	{
		callback?.Invoke(obj: false);
	}

	public bool IsUserPremium(bool showPrompt)
	{
		return true;
	}

	public bool IsSubscribedFromFreeWeekend()
	{
		return SteamApps.IsSubscribedFromFreeWeekend;
	}

	public bool RefreshJoinableSessions(Action<PlatformInterface.SessionFetchStatus, List<PlatformSession>> callback)
	{
		return true;
	}

	public void Update()
	{
		if (isLoggedOn && !statsInitialized && !statsRequested)
		{
			statsRequested = true;
			SteamUserStats.RequestCurrentStats();
		}
		SteamClient.RunCallbacks();
	}

	public void SetJoinString(string value)
	{
		if (value == null)
		{
			SteamFriends.SetRichPresence("connect", "");
		}
		else
		{
			SteamFriends.SetRichPresence("connect", value);
		}
	}

	public bool HasDlc(Dlc value)
	{
		int num = (int)value;
		if (num >= dlcAppIdList.Count)
		{
			UnityEngine.Debug.LogError("Missing steam appid for dlc " + value);
			return false;
		}
		return SteamApps.IsDlcInstalled(dlcAppIdList[num]);
	}

	public bool HasApp(App value)
	{
		int num = (int)value;
		if (num >= appIdList.Count)
		{
			UnityEngine.Debug.LogError("Missing steam appid for dlc " + value);
			return false;
		}
		return SteamApps.IsSubscribedToApp(appIdList[num]);
	}

	public void OpenLink(string url)
	{
		if (SteamUtils.IsOverlayEnabled)
		{
			SteamFriends.OpenWebOverlay(url);
		}
		else
		{
			Application.OpenURL(url);
		}
	}

	public bool CanSetFullscreen()
	{
		return !SteamUtils.IsSteamInBigPictureMode;
	}

	private void OnGamepadTextInputDismissed(bool submitted)
	{
		string input = (submitted ? SteamUtils.GetEnteredGamepadText() : null);
		gotControllerTextInputCallback?.Invoke(submitted, input);
	}

	public bool GetControllerTextInput(string description, int maxChars, string currentText, PlatformInterface.GotControllerTextInput callback, bool hidden = false)
	{
		if (description == null)
		{
			description = "";
		}
		if (currentText == null)
		{
			currentText = "";
		}
		if (!SteamUtils.ShowGamepadTextInput(hidden ? GamepadTextInputMode.Password : GamepadTextInputMode.Normal, GamepadTextInputLineMode.SingleLine, description, maxChars, currentText))
		{
			return false;
		}
		gotControllerTextInputCallback = callback;
		return true;
	}

	public void InitializeAchievements()
	{
	}

	public bool TriggerAchievement(AchievementData achievementData)
	{
		return TriggerAchievement(achievementData.SteamID);
	}

	private bool TriggerAchievement(string achievementIdentifier)
	{
		if (!statsInitialized)
		{
			UnityEngine.Debug.Log("Didn't trigger achievement " + achievementIdentifier + ": not initialized");
			return false;
		}
		_ = Manager.main.player;
		bool flag = false;
		foreach (Achievement achievement in SteamUserStats.Achievements)
		{
			if (achievement.Identifier.Equals(achievementIdentifier))
			{
				flag = true;
				achievement.Trigger();
				SteamUserStats.StoreStats();
				UnityEngine.Debug.Log("Try trigger achievement " + achievement.Identifier);
				break;
			}
		}
		if (!flag)
		{
			UnityEngine.Debug.LogWarning("Couldn't find achievement " + achievementIdentifier);
			return false;
		}
		return true;
	}

	public void ClearAllAchievements()
	{
		SteamUserStats.ResetAll(includeAchievements: true);
	}

	public void Restart(Dictionary<string, string> args)
	{
		Process currentProcess = Process.GetCurrentProcess();
		ProcessModule mainModule = currentProcess.MainModule;
		if (mainModule == null)
		{
			UnityEngine.Debug.LogError("couldn't fetch exe path");
			return;
		}
		args.Add("-waitfor", currentProcess.Id.ToString());
		string gameExePath = mainModule.FileName;
		Manager.afterQuitHandlers += delegate
		{
			Process.Start(gameExePath, string.Concat(args.Select((KeyValuePair<string, string> x) => x.Key + " " + x.Value)));
		};
		Application.Quit();
	}

	public async Task<bool> HasNetworkCheck()
	{
		bool hasNetwork = false;
		await UnityMainThreadDispatcher.Instance().EnqueueAsync(delegate
		{
			hasNetwork = HasNetwork;
		});
		return hasNetwork;
	}

	public void HasNetworkConnectionWithCallback(Action<bool> callback)
	{
		callback?.Invoke(HasNetwork);
	}

	public Task<bool> HasNetworkConnectionAsync()
	{
		return Task.FromResult(HasNetwork);
	}

	private static uint SetAppID()
	{
		uint num = 1621690u;
		string path = Application.dataPath + "/../steam_appid.txt";
		try
		{
			if (File.Exists(path) && uint.TryParse(File.ReadAllText(path), out var result) && (result == 2347300 || result == 3621230))
			{
				num = result;
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
		UnityEngine.Debug.Log($"Initializing Steamworks with AppID {num}");
		return num;
	}

	public bool Init()
	{
		Dispatch.OnException = delegate(Exception e)
		{
			UnityEngine.Debug.LogException(e);
		};
		uint appid = SetAppID();
		if (SteamClient.RestartAppIfNecessary(appid))
		{
			UnityEngine.Debug.Log("Exiting and restarting via steam");
			return false;
		}
		try
		{
			SteamClient.Init(appid, asyncCallbacks: false);
			if (!SteamClient.IsValid)
			{
				UnityEngine.Debug.LogWarning("Steam client not valid or not logged in");
				return false;
			}
			UnityEngine.Debug.Log("Steam API initialized branch=" + SteamApps.CurrentBetaName);
			isLoggedOn = SteamClient.IsLoggedOn;
			steamId = SteamClient.SteamId.AccountId.ToString();
			steamId64 = SteamClient.SteamId.Value;
			steamPlatformUserId = new SteamPlatformUserID(steamId64);
			SentryOptionsConfiguration.piiList.Add(SteamClient.SteamId.AccountId.ToString());
			SentryOptionsConfiguration.piiList.Add(SteamClient.SteamId.Value.ToString());
			SentryOptionsConfiguration.piiList.Add(Environment.UserName);
			if (SteamApps.CurrentBetaName == "experimental")
			{
				SavePrefix = "experimental";
			}
			else
			{
				SavePrefix = null;
			}
			playerPrefsTimestampPrefix = SavePrefix;
			playerPrefsHashPrefix = SavePrefix;
			playerPrefsInitialSyncDone = SavePrefix;
			playerPrefsNoSyncUp = SavePrefix;
			if (!string.IsNullOrEmpty(SavePrefix))
			{
				playerPrefsTimestampPrefix += "/";
				playerPrefsHashPrefix += "/";
				playerPrefsInitialSyncDone += "/";
				playerPrefsNoSyncUp += "/";
			}
			playerPrefsTimestampPrefix = playerPrefsTimestampPrefix + "pugcloud/steam/" + steamId + "/saves/";
			playerPrefsHashPrefix = playerPrefsHashPrefix + "pugcloud/steam/" + steamId + "/hashes/";
			playerPrefsInitialSyncDone = playerPrefsInitialSyncDone + "pugcloud/steam/" + steamId + "/initialsyncdone";
			playerPrefsNoSyncUp = playerPrefsNoSyncUp + "pugcloud/steam/" + steamId + "/nosyncup";
			_richPresence = new SteamRichPresence();
			RichPresence.AddBackend(_richPresence);
			SteamFriends.OnGameRichPresenceJoinRequested += delegate(Friend friend, string s)
			{
				this.JoinRequest?.Invoke(s);
			};
			SteamUtils.OnGamepadTextInputDismissed += OnGamepadTextInputDismissed;
			SteamUserStats.OnUserStatsReceived += delegate(SteamId steamId, Result result)
			{
				statsRequested = false;
				if (result != Result.OK)
				{
					if (!statsRequestErrorPrinted)
					{
						statsRequestErrorPrinted = true;
						UnityEngine.Debug.Log($"Failed to get steam stats: {result}");
					}
				}
				else
				{
					UnityEngine.Debug.Log("Steam stats received");
					statsInitialized = true;
					string[] names = Enum.GetNames(typeof(AchievementID));
					string[] array = SteamUserStats.Achievements.Select((Achievement x) => x.Identifier).ToArray();
					string[] array2 = array;
					foreach (string text in array2)
					{
						if (!names.Contains(text))
						{
							UnityEngine.Debug.LogError("Steam achievement " + text + " not configured");
						}
					}
					array2 = names;
					foreach (string text2 in array2)
					{
						if (!text2.Equals("None") && !array.Contains(text2))
						{
							UnityEngine.Debug.LogWarning("Achievement " + text2 + " not found in steam");
						}
					}
					if (names.Length - 1 != array.Length)
					{
						UnityEngine.Debug.LogWarning($"Expected {names.Length - 1} steam achievements, got {array.Length}");
					}
				}
			};
			SteamUserStats.OnUserStatsUnloaded += delegate(SteamId id)
			{
				if (id.Value == steamId64)
				{
					UnityEngine.Debug.Log("Steam stats unloaded, requesting current stats");
					statsInitialized = false;
					statsRequested = true;
					SteamUserStats.RequestCurrentStats();
				}
			};
			SteamUserStats.OnUserStatsStored += delegate(Result result)
			{
				if (result != Result.OK)
				{
					UnityEngine.Debug.LogError($"SteamUserStats.StoreStats() failed: {result}");
				}
				else
				{
					UnityEngine.Debug.Log("Steam stats stored");
				}
			};
			SteamUserStats.OnAchievementProgress += delegate(Achievement achievement, int progress, int maxProgress)
			{
				if (progress == maxProgress)
				{
					UnityEngine.Debug.Log("got achievement " + achievement.Identifier);
				}
				else
				{
					UnityEngine.Debug.Log($"achievement progress {achievement.Identifier}: {progress}/{maxProgress}");
				}
			};
			statsRequested = true;
			SteamUserStats.RequestCurrentStats();
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
			return false;
		}
		isInitialized = true;
		return true;
	}

	public void Deinit()
	{
		if (_richPresence != null)
		{
			RichPresence.RemoveBackend(_richPresence);
			_richPresence = null;
		}
		if (SteamClient.IsValid)
		{
			SteamFriends.ClearRichPresence();
			SteamClient.Shutdown();
		}
		isInitialized = false;
	}

	public void CloudSyncDown()
	{
		if (!SteamClient.IsValid && isInitialized)
		{
			return;
		}
		UnityEngine.Debug.Log("CloudSyncDown");
		if (!SteamRemoteStorage.IsCloudEnabled && !PlayerPrefs.HasKey(playerPrefsInitialSyncDone))
		{
			try
			{
				List<string> cloudFiles = GetCloudFiles();
				bool flag = false;
				foreach (string item in cloudFiles)
				{
					FilesystemManager.File file = FilesystemManager.Parse(item, detectOldEncrypted: true);
					if (file.fileTypeId != 0 && !file.Exists())
					{
						byte[] array = CloudRead(item);
						if (array == null)
						{
							UnityEngine.Debug.LogError("Got null when fetching " + item + " from cloud (initial)");
							flag = true;
							continue;
						}
						UnityEngine.Debug.Log("Adding new local file " + item + " from cloud (initial)");
						file.Write(array, addToPool: false, force: true, raw: true);
						PlayerPrefs.SetString(playerPrefsTimestampPrefix + item, CloudTimestampString(item));
						PlayerPrefs.SetString(playerPrefsHashPrefix + item, CloudHash(array));
					}
				}
				if (!flag)
				{
					PlayerPrefs.SetInt(playerPrefsInitialSyncDone, 1);
				}
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogError("Failed to do initial sync from Steam Cloud");
				UnityEngine.Debug.LogException(exception);
			}
			finally
			{
				Manager.filesystemManager.Flush();
				PlayerPrefs.Save();
			}
		}
		if (!SteamRemoteStorage.IsCloudEnabled)
		{
			return;
		}
		try
		{
			bool flag2 = !PlayerPrefs.HasKey(playerPrefsNoSyncUp);
			PlayerPrefs.SetInt(playerPrefsNoSyncUp, 1);
			List<string> cloudFiles2 = GetCloudFiles();
			bool flag3 = false;
			foreach (string item2 in cloudFiles2)
			{
				FilesystemManager.File file2 = FilesystemManager.Parse(item2, detectOldEncrypted: true);
				if (file2.fileTypeId != 0)
				{
					byte[] array2 = CloudRead(item2);
					if (array2 == null)
					{
						UnityEngine.Debug.LogError("Got null from Steam Cloud trying to read " + item2);
						flag3 = true;
						continue;
					}
					string key = playerPrefsHashPrefix + item2;
					string key2 = playerPrefsTimestampPrefix + item2;
					if (flag2 && PlayerPrefs.HasKey(key))
					{
						string value = CloudHash(array2);
						if (!PlayerPrefs.GetString(key).Equals(value))
						{
							if (file2.Exists())
							{
								UnityEngine.Debug.Log("Got updated file for " + item2 + " from Steam Cloud, store old in cloudconflicts/" + item2);
								Manager.filesystemManager.Write(file2, file2.Read(raw: true), addToPool: false, force: true, raw: true, "cloudconflicts/");
							}
							file2.Write(array2, addToPool: false, force: true, raw: true);
							PlayerPrefs.SetString(key, value);
							PlayerPrefs.SetString(key2, CloudTimestampString(item2));
						}
					}
					else
					{
						DateTime dateTime = CloudTimestamp(item2);
						bool flag4 = file2.Exists();
						DateTime dateTime2 = (flag4 ? file2.GetFileTime() : default(DateTime));
						UnityEngine.Debug.Log($"localExists={flag4} localTimestamp={dateTime2} cloudTimestamp={dateTime}");
						if (flag4 && dateTime2 > dateTime)
						{
							byte[] data = file2.Read(raw: true);
							if (CloudWrite(item2, data))
							{
								UnityEngine.Debug.Log("Using newer local file for " + item2 + " store Steam Cloud file in cloudconflicts/" + item2);
								PlayerPrefs.SetString(key, CloudHash(data));
								PlayerPrefs.SetString(key2, CloudTimestampString(item2));
								Manager.filesystemManager.Write(file2, array2, addToPool: false, force: true, raw: true, "cloudconflicts/");
							}
							else
							{
								UnityEngine.Debug.LogError("Failed to update cloud file with local file: " + item2);
							}
						}
						else
						{
							if (file2.Exists())
							{
								UnityEngine.Debug.Log("Got updated file for " + item2 + " from Steam Cloud (time check), store old in cloudconflicts/" + item2);
								Manager.filesystemManager.Write(file2, file2.Read(raw: true), addToPool: false, force: true, raw: true, "cloudconflicts/");
							}
							file2.Write(array2, addToPool: false, force: true, raw: true);
							PlayerPrefs.SetString(key, CloudHash(array2));
							PlayerPrefs.SetString(key2, CloudTimestampString(item2));
						}
					}
				}
				if (Manager.filesystemManager.IsCloudSynced(file2))
				{
					continue;
				}
				UnityEngine.Debug.Log("Removing previously synced file " + item2 + " from cloud");
				if (CloudDelete(item2))
				{
					string key3 = playerPrefsTimestampPrefix + item2;
					if (PlayerPrefs.HasKey(key3))
					{
						PlayerPrefs.DeleteKey(key3);
					}
					string key4 = playerPrefsHashPrefix + item2;
					if (PlayerPrefs.HasKey(key4))
					{
						PlayerPrefs.DeleteKey(key4);
					}
				}
				else
				{
					UnityEngine.Debug.LogError("Failed to delete cloud file " + item2);
				}
			}
			foreach (FilesystemManager.File allFile in Manager.filesystemManager.GetAllFiles(detectOldEncrypted: true))
			{
				if (!Manager.filesystemManager.IsCloudSynced(allFile))
				{
					continue;
				}
				string filePath = allFile.GetFilePath();
				bool flag5 = false;
				foreach (string item3 in cloudFiles2)
				{
					if (string.Compare(filePath, item3, StringComparison.InvariantCultureIgnoreCase) == 0)
					{
						flag5 = true;
						break;
					}
				}
				if (flag5)
				{
					continue;
				}
				string key5 = playerPrefsHashPrefix + filePath;
				if (PlayerPrefs.HasKey(key5) && PlayerPrefs.GetString(key5).Equals(CloudHash(allFile.Read(raw: true))))
				{
					UnityEngine.Debug.Log("Deleting local file " + filePath + " not found in cloud");
					allFile.Delete(force: true);
					PlayerPrefs.DeleteKey(key5);
					string key6 = playerPrefsTimestampPrefix + filePath;
					if (PlayerPrefs.HasKey(key6))
					{
						PlayerPrefs.DeleteKey(key6);
					}
				}
				else
				{
					byte[] data2 = allFile.Read(raw: true);
					if (CloudWrite(filePath, data2))
					{
						PlayerPrefs.SetString(key5, CloudHash(data2));
						PlayerPrefs.SetString(playerPrefsTimestampPrefix + filePath, CloudTimestampString(filePath));
					}
					else
					{
						UnityEngine.Debug.LogError("Failed to upload local file to cloud: " + filePath);
					}
				}
			}
			if (!flag3)
			{
				PlayerPrefs.SetInt(playerPrefsInitialSyncDone, 1);
			}
		}
		catch (Exception exception2)
		{
			UnityEngine.Debug.LogError("Failed to download save data from Steam Cloud");
			UnityEngine.Debug.LogException(exception2);
		}
		finally
		{
			Manager.filesystemManager.Flush();
			PlayerPrefs.Save();
		}
	}

	public void CloudSyncUp()
	{
		if (!SteamClient.IsValid && isInitialized)
		{
			return;
		}
		UnityEngine.Debug.Log("CloudSyncUp");
		try
		{
			SteamRemoteStorage.BeginFileWriteBatch();
			foreach (FilesystemManager.File dirtyFile in Manager.filesystemManager.GetDirtyFiles())
			{
				if (dirtyFile.Exists() && Manager.filesystemManager.IsCloudSynced(dirtyFile))
				{
					string filePath = dirtyFile.GetFilePath();
					byte[] data = dirtyFile.Read(raw: true);
					if (CloudWrite(filePath, data))
					{
						PlayerPrefs.SetString(playerPrefsHashPrefix + filePath, CloudHash(data));
						PlayerPrefs.SetString(playerPrefsTimestampPrefix + filePath, CloudTimestampString(filePath));
					}
					else
					{
						UnityEngine.Debug.LogError("Failed to upload local file to cloud: " + filePath);
					}
				}
			}
			HashSet<string> hashSet = new HashSet<string>();
			foreach (FilesystemManager.File allFile in Manager.filesystemManager.GetAllFiles(detectOldEncrypted: true))
			{
				if (Manager.filesystemManager.IsCloudSynced(allFile))
				{
					string item = allFile.GetFilePath().ToLowerInvariant();
					hashSet.Add(item);
				}
			}
			foreach (string cloudFile in GetCloudFiles())
			{
				string item2 = cloudFile.ToLowerInvariant();
				bool num = hashSet.Contains(item2);
				string key = playerPrefsHashPrefix + cloudFile;
				if (num || !PlayerPrefs.HasKey(key))
				{
					continue;
				}
				byte[] array = CloudRead(cloudFile);
				if (array == null)
				{
					UnityEngine.Debug.LogError("Got null when fetching " + cloudFile + " from cloud (delete check)");
				}
				else
				{
					if (!PlayerPrefs.GetString(key).Equals(CloudHash(array)))
					{
						continue;
					}
					UnityEngine.Debug.Log("Removing cloud file " + cloudFile + " since it was removed locally");
					FilesystemManager.File file = FilesystemManager.Parse(cloudFile, detectOldEncrypted: true);
					if (file.FileID != FilesystemManager.FileID.None)
					{
						UnityEngine.Debug.Log("Storing deleted cloud file in cloudconflicts/" + cloudFile);
						Manager.filesystemManager.Write(file, array, addToPool: false, force: true, raw: true, "cloudconflicts/");
					}
					if (CloudDelete(cloudFile))
					{
						PlayerPrefs.DeleteKey(key);
						string key2 = playerPrefsTimestampPrefix + cloudFile;
						if (PlayerPrefs.HasKey(key2))
						{
							PlayerPrefs.DeleteKey(key2);
						}
					}
					else
					{
						UnityEngine.Debug.LogError("Failed to delete cloud file " + cloudFile);
					}
				}
			}
			SteamRemoteStorage.EndFileWriteBatch();
			PlayerPrefs.DeleteKey(playerPrefsNoSyncUp);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogError("Failed to upload saves to Steam Cloud");
			UnityEngine.Debug.LogException(exception);
		}
		finally
		{
			PlayerPrefs.Save();
		}
	}

	private List<string> GetCloudFiles()
	{
		if (string.IsNullOrEmpty(SavePrefix))
		{
			return new List<string>(SteamRemoteStorage.Files.Where((string x) => !x.StartsWith("experimental/")));
		}
		string savePrefixDir = SavePrefix + "/";
		return new List<string>(from x in SteamRemoteStorage.Files
			where x.StartsWith(savePrefixDir)
			select x.Substring(savePrefixDir.Length));
	}

	private byte[] CloudRead(string path)
	{
		if (!string.IsNullOrEmpty(SavePrefix))
		{
			path = SavePrefix + "/" + path;
		}
		return SteamRemoteStorage.FileRead(path);
	}

	private bool CloudWrite(string path, byte[] data)
	{
		if (!string.IsNullOrEmpty(SavePrefix))
		{
			path = SavePrefix + "/" + path;
		}
		return SteamRemoteStorage.FileWrite(path, data);
	}

	private bool CloudDelete(string path)
	{
		if (!string.IsNullOrEmpty(SavePrefix))
		{
			path = SavePrefix + "/" + path;
		}
		return SteamRemoteStorage.FileDelete(path);
	}

	private DateTime CloudTimestamp(string path)
	{
		if (!string.IsNullOrEmpty(SavePrefix))
		{
			path = SavePrefix + "/" + path;
		}
		return SteamRemoteStorage.FileTime(path);
	}

	private string CloudTimestampString(string path)
	{
		if (!string.IsNullOrEmpty(SavePrefix))
		{
			path = SavePrefix + "/" + path;
		}
		return SteamRemoteStorage.FileTime(path).ToString(CultureInfo.InvariantCulture);
	}

	private string CloudHash(byte[] data)
	{
		return Convert.ToBase64String(MD5.Create().ComputeHash(data));
	}
}
