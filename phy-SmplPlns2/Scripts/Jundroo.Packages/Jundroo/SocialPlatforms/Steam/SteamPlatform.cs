using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Jundroo.Common.Platform;
using Jundroo.SocialPlatforms.Achievements;
using Jundroo.SocialPlatforms.Steam.Events;
using Jundroo.SocialPlatforms.Steam.Multiplayer;
using Jundroo.SocialPlatforms.Steam.RemoteStorage;
using Steamworks;
using UnityEngine;

namespace Jundroo.SocialPlatforms.Steam
{
	public class SteamPlatform : ISteamPlatform, ISocialPlatformExt, ISocialPlatform
	{
		public const string Name = "Steam";

		private AchievementDatabase _achievementDatabase;

		private Dictionary<string, Achievement> _achievements;

		private Callback<GameWebCallback_t> _gameWebCallback;

		private bool _loadingUserStats;

		private LocalUser _localUser;

		private Callback<NewUrlLaunchParameters_t> _newLaunchQueryParameters;

		private CallResult<SteamUGCQueryCompleted_t> _publishedWorkshopItemsQueryResult;

		private Callback<RemoteStorageLocalFileChange_t> _remoteStorageLocalFileChange;

		private Coroutine _requestCurrentStatsCoroutine;

		private Dictionary<string, List<AchievementInfo>> _statAchievementLookup;

		private Coroutine _storeStatsCoroutine;

		private Callback<UserAchievementStored_t> _userAchievementStoredCallback;

		private Callback<UserStatsReceived_t> _userStatsReceivedCallback;

		private Callback<UserStatsStored_t> _userStatsStoredCallback;

		public uint AppId { get; private set; }

		public bool DebuggingEnabled { get; set; }

		public ILocalUser localUser => _localUser;

		public string LocalUserDisplayName => SteamFriends.GetPersonaName();

		public ulong LocalUserId => SteamUser.GetSteamID().m_SteamID;

		public bool LoggedOn => SteamUser.BLoggedOn();

		public ISteamPlatformMultiplayer Multiplayer { get; private set; }

		public string PlatformName => "Steam";

		public SteamManager SteamManager { get; private set; }

		public ReadOnlyCollection<WorkshopItemInfo> UserPublishedWorkshopItems { get; private set; }

		public bool UserStatsReceived { get; private set; }

		public event EventHandler<GameWebCallbackEventArgs> GameWebCallback;

		public event EventHandler<NewLaunchParametersEventArgs> NewLaunchParameters;

		public event EventHandler<RemoteStorageLocalFileChangeEventArgs> RemoteStorageLocalFileChange;

		public event EventHandler<UserPublishedWorkshopItemsChangedEventArgs> UserPublishedWorkshopItemsChanged;

		public void ActivateGameOverlayToWebPage(string url)
		{
			SteamFriends.ActivateGameOverlayToWebPage(url);
		}

		public void Authenticate(ILocalUser user, Action<bool> callback)
		{
			callback?.Invoke(obj: true);
		}

		public void Authenticate(ILocalUser user, Action<bool, string> callback)
		{
			callback?.Invoke(arg1: true, null);
		}

		public bool BeginFileWriteBatch()
		{
			return SteamRemoteStorage.BeginFileWriteBatch();
		}

		public IAchievement CreateAchievement()
		{
			return CreateSteamAchievement();
		}

		public ILeaderboard CreateLeaderboard()
		{
			return CreateSteamLeaderboard();
		}

		public void DumpAchievementToConsole()
		{
			foreach (Achievement value in _achievements.Values)
			{
				UnityEngine.Debug.Log(value);
			}
		}

		public bool EndFileWriteBatch()
		{
			return SteamRemoteStorage.EndFileWriteBatch();
		}

		public float GetFloatStat(string statId)
		{
			SteamUserStats.GetStat(statId, out float pData);
			return pData;
		}

		public int GetIntStat(string statId)
		{
			SteamUserStats.GetStat(statId, out int pData);
			return pData;
		}

		public string GetLaunchQueryParam(string paramName)
		{
			return SteamApps.GetLaunchQueryParam(paramName);
		}

		public bool GetLoading(ILeaderboard board)
		{
			return board?.loading ?? false;
		}

		public List<SubscribedWorkshopItemInfo> GetSubscribedWorkshopItems()
		{
			List<SubscribedWorkshopItemInfo> list = new List<SubscribedWorkshopItemInfo>();
			uint numSubscribedItems = SteamUGC.GetNumSubscribedItems();
			PublishedFileId_t[] array = new PublishedFileId_t[numSubscribedItems];
			uint subscribedItems = SteamUGC.GetSubscribedItems(array, numSubscribedItems);
			for (int i = 0; i < subscribedItems; i++)
			{
				PublishedFileId_t nPublishedFileID = array[i];
				bool installed = false;
				string pchFolder = string.Empty;
				uint punTimeStamp = 0u;
				if ((SteamUGC.GetItemState(nPublishedFileID) & 4) == 4 && SteamUGC.GetItemInstallInfo(nPublishedFileID, out var _, out pchFolder, 1024u, out punTimeStamp))
				{
					installed = true;
				}
				list.Add(new SubscribedWorkshopItemInfo(nPublishedFileID.m_PublishedFileId, installed, pchFolder, punTimeStamp));
			}
			return list;
		}

		public void IncrementAchievement(string achievementID, int incrementAmount, bool showProgress, Action<bool> callback)
		{
			SteamManager.StartCoroutine(IncrementAchievementCoroutine(achievementID, incrementAmount, showProgress, asInteger: true, callback));
		}

		public void IncrementAchievement(string achievementID, float incrementAmount, bool showProgress, Action<bool> callback)
		{
			SteamManager.StartCoroutine(IncrementAchievementCoroutine(achievementID, incrementAmount, showProgress, asInteger: false, callback));
		}

		public void IncrementStat(string statID, int incrementAmount, ShouldShowProgress showProgress, Action<bool> callback)
		{
			SteamManager.StartCoroutine(IncrementStatCoroutine(statID, incrementAmount, showProgress, asInteger: true, callback));
		}

		public void IncrementStat(string statID, float incrementAmount, ShouldShowProgress showProgress, Action<bool> callback)
		{
			SteamManager.StartCoroutine(IncrementStatCoroutine(statID, incrementAmount, showProgress, asInteger: false, callback));
		}

		public void Initialize(AchievementDatabase achievementDatabase)
		{
			AppId = SteamUtils.GetAppID().m_AppId;
			string text = (SteamUser.BLoggedOn() ? SteamFriends.GetPersonaName() : "not logged in");
			DebuggingEnabled = text != null && text.ToLower() == "nathan_mikeska";
			DebugLog("Steam Initialized (App '{0}') - User: {1}", AppId, text);
			SteamManager = new GameObject("SteamManager").AddComponent<SteamManager>();
			_userStatsReceivedCallback = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
			_userStatsStoredCallback = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
			_userAchievementStoredCallback = Callback<UserAchievementStored_t>.Create(OnUserAchivementStored);
			_gameWebCallback = Callback<GameWebCallback_t>.Create(OnGameWebCallback);
			_newLaunchQueryParameters = Callback<NewUrlLaunchParameters_t>.Create(OnNewLaunchQueryParameters);
			_remoteStorageLocalFileChange = Callback<RemoteStorageLocalFileChange_t>.Create(OnRemoteStorageLocalFileChange);
			_publishedWorkshopItemsQueryResult = new CallResult<SteamUGCQueryCompleted_t>(OnPublishedWorkshopItemsQueryResult);
			ApplyGreaseToSqueakyWheels();
			InitializeLocalUser();
			_achievements = new Dictionary<string, Achievement>();
			_achievementDatabase = achievementDatabase ?? ScriptableObject.CreateInstance<AchievementDatabase>();
			InitializeStatAchievementLookup();
			if ((object)achievementDatabase != null && achievementDatabase.AchievementsEnabled)
			{
				StopStartCoroutine(ref _requestCurrentStatsCoroutine, RequestCurrentStatsCoroutine, null);
			}
			Multiplayer = new SteamPlatformMultiplayer();
			if (IsRunningOnSteamDeck())
			{
				Device.AddDeviceFlags(DeviceFlags.SteamDeck);
			}
		}

		public bool IsOverlayEnabled()
		{
			return SteamUtils.IsOverlayEnabled();
		}

		public bool IsRunningInBigPicture()
		{
			return SteamUtils.IsSteamInBigPictureMode();
		}

		public bool IsRunningOnSteamDeck()
		{
			return SteamUtils.IsSteamRunningOnSteamDeck();
		}

		public void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback)
		{
			if (callback != null)
			{
				SteamManager.StartCoroutine(WaitForUserStatsCoroutine(LoadAchievementDescriptionsCallback, callback));
			}
		}

		public void LoadAchievements(Action<IAchievement[]> callback)
		{
			if (callback != null)
			{
				SteamManager.StartCoroutine(WaitForUserStatsCoroutine(LoadAchievementsCallback, callback));
			}
		}

		public void LoadFriends(ILocalUser user, Action<bool> callback)
		{
			if (user != null && user != localUser)
			{
				UnityEngine.Debug.LogWarning("Attempted to load friends for a local user that doesn't match the expected local user.");
			}
			List<IUserProfile> list = new List<IUserProfile>();
			int friendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
			for (int i = 0; i < friendCount; i++)
			{
				CSteamID friendByIndex = SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagImmediate);
				UserProfile item = new UserProfile
				{
					id = friendByIndex.ToString(),
					userName = SteamFriends.GetFriendPersonaName(friendByIndex),
					isFriend = true,
					state = ConvertState(SteamFriends.GetFriendPersonaState(friendByIndex))
				};
				list.Add(item);
			}
			_localUser.friends = list.ToArray();
			callback?.Invoke(obj: true);
		}

		public void LoadScores(ILeaderboard board, Action<bool> callback)
		{
			UnityEngine.Debug.LogError("Leaderboards not yet implemented for Steam");
			callback?.Invoke(obj: true);
		}

		public void LoadScores(string leaderboardID, Action<IScore[]> callback)
		{
			UnityEngine.Debug.LogError("Leaderboards not yet implemented for Steam");
			callback?.Invoke(new IScore[0]);
		}

		public void LoadUsers(string[] userIDs, Action<IUserProfile[]> callback)
		{
			UnityEngine.Debug.LogError("Loading users not yet implemented for Steam. Load the local user's friends instead.");
			callback?.Invoke(new IUserProfile[0]);
		}

		public IPublishWorkshopItemOperation PublishWorkshopItem(string modName, string folderPath, string previewImagePath, string title, SteamVisibility visibility, string language, IList<string> tags, string description)
		{
			PublishWorkshopItemOperation publishWorkshopItemOperation = new PublishWorkshopItemOperation(modName, null, folderPath, previewImagePath, title, visibility, language, tags, description);
			publishWorkshopItemOperation.PublishAsync();
			return publishWorkshopItemOperation;
		}

		public void QueryUserPublishedWorkshopItems()
		{
			AccountID_t accountID = SteamUser.GetSteamID().GetAccountID();
			AppId_t appID = SteamUtils.GetAppID();
			UGCQueryHandle_t handle = SteamUGC.CreateQueryUserUGCRequest(accountID, EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items, EUserUGCListSortOrder.k_EUserUGCListSortOrder_CreationOrderAsc, appID, appID, 1u);
			SteamUGC.SetReturnKeyValueTags(handle, bReturnKeyValueTags: true);
			SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(handle);
			_publishedWorkshopItemsQueryResult.Set(hAPICall);
		}

		public void ReportProgress(string achievementID, double progress, Action<bool> callback)
		{
			SteamManager.StartCoroutine(ReportProgressCoroutine(achievementID, progress, callback));
		}

		public void ReportScore(long score, string board, Action<bool> callback)
		{
			UnityEngine.Debug.LogError("Leaderboards not yet implemented for Steam");
			callback?.Invoke(obj: true);
		}

		public void ResetAllAchievements()
		{
			UnityEngine.Debug.LogWarningFormat("WARNING! Resetting all Steam stats and achievements for user '{0}' on app '{1}'.", localUser.userName, AppId);
			if (!SteamUserStats.ResetAllStats(bAchievementsToo: true))
			{
				UnityEngine.Debug.LogError("All achievements and stats were unable to be reset");
			}
		}

		public void ShowAchievementsUI()
		{
			SteamFriends.ActivateGameOverlay("Achievements");
		}

		public bool ShowFloatingGamepadTextInput(FloatingGamepadTextInputMode mode, Rect inputFieldPosition)
		{
			return SteamUtils.ShowFloatingGamepadTextInput((EFloatingGamepadTextInputMode)mode, (int)inputFieldPosition.x, Screen.height - (int)inputFieldPosition.y, (int)inputFieldPosition.width, (int)inputFieldPosition.height);
		}

		public void ShowLeaderboardUI()
		{
			UnityEngine.Debug.LogError("Leaderboards not yet implemented for Steam");
		}

		private static UserState ConvertState(EPersonaState state)
		{
			switch (state)
			{
			case EPersonaState.k_EPersonaStateOnline:
			case EPersonaState.k_EPersonaStateLookingToTrade:
			case EPersonaState.k_EPersonaStateLookingToPlay:
				return UserState.Online;
			case EPersonaState.k_EPersonaStateAway:
			case EPersonaState.k_EPersonaStateSnooze:
				return UserState.OnlineAndAway;
			case EPersonaState.k_EPersonaStateBusy:
				return UserState.OnlineAndBusy;
			case EPersonaState.k_EPersonaStateOffline:
				return UserState.Offline;
			default:
				return UserState.Offline;
			}
		}

		private void ApplyGreaseToSqueakyWheels()
		{
			_userStatsReceivedCallback.ToString();
			_userStatsStoredCallback.ToString();
			_userAchievementStoredCallback.ToString();
			_gameWebCallback.ToString();
			_newLaunchQueryParameters.ToString();
			_remoteStorageLocalFileChange.ToString();
			_publishedWorkshopItemsQueryResult.ToString();
		}

		private Achievement CreateSteamAchievement()
		{
			return new Achievement();
		}

		private Leaderboard CreateSteamLeaderboard()
		{
			return new Leaderboard();
		}

		private void DebugLog(string message, params object[] args)
		{
			if (DebuggingEnabled)
			{
				if (args == null || args.Length == 0)
				{
					UnityEngine.Debug.Log(message);
				}
				else
				{
					UnityEngine.Debug.LogFormat(message, args);
				}
			}
		}

		[Conditional("UNITY_EDITOR")]
		private void EnableDebuggingInEditor()
		{
			DebuggingEnabled = true;
		}

		private bool IncrementAchievement(string achievementID, double incrementAmount, bool showProgress, bool asInteger)
		{
			AchievementInfo achievementInfo = _achievementDatabase.FindById(achievementID);
			if (achievementInfo == null)
			{
				UnityEngine.Debug.LogErrorFormat("Cannot increment Steam achievement '{0}'. The achievement ID could not be found in the database.", achievementID);
				return false;
			}
			if (string.IsNullOrEmpty(achievementInfo.SteamStatId))
			{
				UnityEngine.Debug.LogErrorFormat("Cannot increment Steam achievement '{0}'. The achievement is not a stat-based achievement.", achievementID);
				return false;
			}
			List<AchievementInfo> list = (_statAchievementLookup.ContainsKey(achievementInfo.SteamStatId) ? _statAchievementLookup[achievementInfo.SteamStatId] : null);
			if (list == null || list.Count == 0)
			{
				UnityEngine.Debug.LogErrorFormat("Cannot increment Steam achievement '{0}'. The list of achievements sharing stat '{1}' could not be found.", achievementID, achievementInfo.SteamStatId);
				return false;
			}
			int num = list.IndexOf(achievementInfo);
			int num2 = num;
			if (num < 0)
			{
				UnityEngine.Debug.LogErrorFormat("Cannot increment Steam achievement '{0}'. Cannot find the achievement in the shared stat achievement list.", achievementID);
				return false;
			}
			do
			{
				bool flag = num2 == num;
				Achievement achievement = (_achievements.ContainsKey(achievementID) ? _achievements[achievementID] : null);
				if (achievement == null)
				{
					UnityEngine.Debug.LogErrorFormat("Cannot increment Steam achievement '{0}'. The achievement object could not be found.", achievementID);
					return false;
				}
				double num3 = Math.Abs(achievementInfo.MaxValue - achievementInfo.MinValue);
				if (num3 == 0.0)
				{
					num3 = 1.0;
				}
				double num4 = achievement.percentCompleted / 100.0 * num3 + achievementInfo.MinValue + incrementAmount;
				if (flag && !((!asInteger) ? SteamUserStats.SetStat(achievementInfo.SteamStatId, (float)num4) : SteamUserStats.SetStat(achievementInfo.SteamStatId, Mathf.RoundToInt((float)num4))))
				{
					UnityEngine.Debug.LogErrorFormat("Steam stat '{0}' was unable to be set.", achievementInfo.SteamStatId);
					return false;
				}
				achievement.percentCompleted = Math.Max(0.0, Math.Min(100.0, (num4 - achievementInfo.MinValue) / num3 * 100.0));
				achievement.lastReportedDate = DateTime.Now;
				achievement.hidden = achievement.hidden && achievement.percentCompleted <= 0.0;
				if (achievement.percentCompleted >= 100.0)
				{
					if (!UnlockAchievement(achievement))
					{
						return false;
					}
				}
				else if (showProgress && flag)
				{
					SteamUserStats.IndicateAchievementProgress(achievementInfo.SteamId, (uint)num4, (uint)achievementInfo.MaxValue);
				}
				num2++;
				if (num2 >= list.Count)
				{
					num2 = 0;
				}
				achievementInfo = list[num2];
				achievementID = achievementInfo.SteamId;
			}
			while (num2 != num);
			return true;
		}

		private IEnumerator IncrementAchievementCoroutine(string achievementID, double incrementAmount, bool showProgress, bool asInteger, Action<bool> callback)
		{
			while (_loadingUserStats)
			{
				yield return new WaitForSeconds(1f);
			}
			bool flag = true;
			if (UserStatsReceived && IncrementAchievement(achievementID, incrementAmount, showProgress, asInteger))
			{
				flag = false;
				StopStartCoroutine(ref _storeStatsCoroutine, StoreStatsCoroutine, callback);
			}
			else
			{
				UnityEngine.Debug.LogErrorFormat("Cannot increment Steam achievement '{0}'. The user stats were unable to be retrieved.", achievementID);
			}
			if (flag)
			{
				callback?.Invoke(obj: false);
			}
		}

		private bool IncrementStat(string statID, double incrementAmount, ShouldShowProgress showProgress, bool asInteger)
		{
			double previousStatValue;
			double num;
			if (asInteger)
			{
				if (!SteamUserStats.GetStat(statID, out int pData))
				{
					UnityEngine.Debug.LogErrorFormat("Cannot increment Steam stat '{0}'. The current value of the stat could not be retrieved.", statID);
					return false;
				}
				previousStatValue = pData;
				pData += (int)incrementAmount;
				if (!SteamUserStats.SetStat(statID, pData))
				{
					UnityEngine.Debug.LogErrorFormat("Cannot increment Steam stat '{0}'. The value of the stat could not be set.", statID);
					return false;
				}
				num = pData;
			}
			else
			{
				if (!SteamUserStats.GetStat(statID, out float pData2))
				{
					UnityEngine.Debug.LogErrorFormat("Cannot increment Steam stat '{0}'. The current value of the stat could not be retrieved.", statID);
					return false;
				}
				previousStatValue = pData2;
				pData2 += (float)incrementAmount;
				if (!SteamUserStats.SetStat(statID, pData2))
				{
					UnityEngine.Debug.LogErrorFormat("Cannot increment Steam stat '{0}'. The value of the stat could not be set.", statID);
					return false;
				}
				num = pData2;
			}
			bool result = true;
			List<AchievementInfo> list = (_statAchievementLookup.ContainsKey(statID) ? _statAchievementLookup[statID] : new List<AchievementInfo>(0));
			for (int i = 0; i < list.Count; i++)
			{
				AchievementInfo achievementInfo = list[i];
				Achievement achievement = (_achievements.ContainsKey(achievementInfo.Id) ? _achievements[achievementInfo.Id] : null);
				if (achievement == null)
				{
					UnityEngine.Debug.LogErrorFormat("Cannot update Steam achievement '{0}' after incrementing stat '{1}'. The achievement object could not be found.", achievementInfo.Id, statID);
					result = false;
					continue;
				}
				achievement.percentCompleted = Math.Max(0.0, Math.Min(100.0, (num - achievementInfo.MinValue) / achievementInfo.GetValueRange() * 100.0));
				achievement.lastReportedDate = DateTime.Now;
				achievement.hidden = achievement.hidden && achievement.percentCompleted <= 0.0;
				if (achievement.percentCompleted >= 100.0)
				{
					if (!UnlockAchievement(achievement))
					{
						result = false;
					}
				}
				else if (showProgress != null && showProgress(achievementInfo, achievement, previousStatValue, num))
				{
					SteamUserStats.IndicateAchievementProgress(achievementInfo.SteamId, (uint)num, (uint)achievementInfo.MaxValue);
				}
			}
			return result;
		}

		private IEnumerator IncrementStatCoroutine(string statID, double incrementAmount, ShouldShowProgress showProgress, bool asInteger, Action<bool> callback)
		{
			while (_loadingUserStats)
			{
				yield return new WaitForSeconds(1f);
			}
			bool flag = true;
			if (UserStatsReceived && IncrementStat(statID, incrementAmount, showProgress, asInteger))
			{
				flag = false;
				StopStartCoroutine(ref _storeStatsCoroutine, StoreStatsCoroutine, callback);
			}
			else if (UserStatsReceived)
			{
				UnityEngine.Debug.LogErrorFormat("An error occurred trying to increment Steam stat '{0}'.", statID);
			}
			else
			{
				UnityEngine.Debug.LogErrorFormat("Cannot increment Steam stat '{0}'. The user stats were unable to be retrieved.", statID);
			}
			if (flag)
			{
				callback?.Invoke(obj: false);
			}
		}

		private void InitializeLocalUser()
		{
			_localUser = new LocalUser
			{
				id = SteamUser.GetSteamID().ToString(),
				authenticated = SteamUser.BLoggedOn(),
				isFriend = false,
				state = UserState.Playing,
				underage = false,
				userName = SteamFriends.GetPersonaName()
			};
		}

		private void InitializeStatAchievementLookup()
		{
			_statAchievementLookup = new Dictionary<string, List<AchievementInfo>>();
			for (int i = 0; i < _achievementDatabase.Achievements.Count; i++)
			{
				AchievementInfo achievementInfo = _achievementDatabase.Achievements[i];
				string statId = achievementInfo.StatId;
				if (!string.IsNullOrEmpty(statId))
				{
					if (_statAchievementLookup.ContainsKey(statId))
					{
						_statAchievementLookup[statId].Add(achievementInfo);
						continue;
					}
					_statAchievementLookup.Add(statId, new List<AchievementInfo> { achievementInfo });
				}
			}
		}

		private void LoadAchievementDescriptionsCallback(Action<IAchievementDescription[]> callback)
		{
			List<IAchievementDescription> list = new List<IAchievementDescription>();
			foreach (AchievementInfo achievement in _achievementDatabase.Achievements)
			{
				if (_achievements.ContainsKey(achievement.SteamId))
				{
					AchievementDescription item = new AchievementDescription
					{
						id = achievement.SteamId,
						title = achievement.Name,
						achievedDescription = achievement.Description,
						unachievedDescription = achievement.Description,
						hidden = achievement.Hidden,
						points = achievement.Points
					};
					list.Add(item);
				}
			}
			callback(list.ToArray());
		}

		private void LoadAchievementsCallback(Action<IAchievement[]> callback)
		{
			IAchievement[] obj = _achievements.Values.ToArray();
			callback(obj);
		}

		private void OnGameWebCallback(GameWebCallback_t webCallback)
		{
			DebugLog(("Steam GameWebCallback received: " + webCallback == null) ? "(null)" : webCallback.m_szURL);
			if (this.GameWebCallback != null)
			{
				this.GameWebCallback(this, new GameWebCallbackEventArgs(webCallback.m_szURL));
			}
		}

		private void OnNewLaunchQueryParameters(NewUrlLaunchParameters_t newLaunchQueryParameters)
		{
			this.NewLaunchParameters?.Invoke(this, new NewLaunchParametersEventArgs());
		}

		private void OnPublishedWorkshopItemsQueryResult(SteamUGCQueryCompleted_t result, bool iofailure)
		{
			if (result.m_eResult != EResult.k_EResultOK || iofailure)
			{
				UnityEngine.Debug.LogErrorFormat("Steam query to find user's published workshop items has failed. IOFailure: {0}, Result: {1}", iofailure, result.m_eResult);
				return;
			}
			List<WorkshopItemInfo> list = new List<WorkshopItemInfo>();
			for (uint num = 0u; num < result.m_unNumResultsReturned; num++)
			{
				if (!SteamUGC.GetQueryUGCResult(result.m_handle, num, out var pDetails))
				{
					continue;
				}
				string modName = null;
				uint queryUGCNumKeyValueTags = SteamUGC.GetQueryUGCNumKeyValueTags(result.m_handle, num);
				for (uint num2 = 0u; num2 < queryUGCNumKeyValueTags; num2++)
				{
					if (SteamUGC.GetQueryUGCKeyValueTag(result.m_handle, num, num2, out var pchKey, 1024u, out var pchValue, 1024u) && pchKey == "ModName")
					{
						modName = pchValue;
						break;
					}
				}
				WorkshopItemInfo item = new WorkshopItemInfo
				{
					Id = (ulong)pDetails.m_nPublishedFileId,
					ModName = modName,
					Title = pDetails.m_rgchTitle
				};
				list.Add(item);
			}
			SteamUGC.ReleaseQueryUGCRequest(result.m_handle);
			UserPublishedWorkshopItems = new ReadOnlyCollection<WorkshopItemInfo>(list);
			this.UserPublishedWorkshopItemsChanged?.Invoke(this, new UserPublishedWorkshopItemsChangedEventArgs(UserPublishedWorkshopItems));
		}

		private void OnRemoteStorageLocalFileChange(RemoteStorageLocalFileChange_t callbackData)
		{
			DebugLog("Steam: Remote Storage Local File Change Callback Received");
			int localFileChangeCount = SteamRemoteStorage.GetLocalFileChangeCount();
			List<RemoteStorageLocalFileChange> list = new List<RemoteStorageLocalFileChange>(localFileChangeCount);
			for (int i = 0; i < localFileChangeCount; i++)
			{
				ERemoteStorageLocalFileChange pEChangeType;
				ERemoteStorageFilePathType pEFilePathType;
				string localFileChange = SteamRemoteStorage.GetLocalFileChange(i, out pEChangeType, out pEFilePathType);
				list.Add(new RemoteStorageLocalFileChange(localFileChange, (RemoteStorageFilePathType)pEFilePathType, (RemoteStorageLocalFileChangeType)pEChangeType));
			}
			this.RemoteStorageLocalFileChange?.Invoke(this, new RemoteStorageLocalFileChangeEventArgs(list));
		}

		private void OnUserAchivementStored(UserAchievementStored_t userAchievementStored)
		{
			if (userAchievementStored.m_nGameID == AppId)
			{
				DebugLog("Achievement '{0}' successfully sent to Steam.", userAchievementStored.m_rgchAchievementName);
			}
		}

		private void OnUserStatsReceived(UserStatsReceived_t userStatsReceived)
		{
			if (userStatsReceived.m_nGameID != AppId)
			{
				_loadingUserStats = false;
			}
			else if (userStatsReceived.m_eResult != EResult.k_EResultOK)
			{
				_loadingUserStats = false;
				UnityEngine.Debug.LogErrorFormat("Retrieving Steam user stats failed with code '{0}'", userStatsReceived.m_eResult);
			}
			else
			{
				DebugLog("Steam user stats retrieved");
				UpdateAchievements();
				UserStatsReceived = true;
				_loadingUserStats = false;
			}
		}

		private void OnUserStatsStored(UserStatsStored_t userStatsStored)
		{
			if (userStatsStored.m_nGameID == AppId)
			{
				if (userStatsStored.m_eResult == EResult.k_EResultInvalidParam)
				{
					DebugLog("Failed to store stats, Invalid Param Result");
					UpdateAchievements();
				}
				else
				{
					DebugLog("User stats stored '{0}'", userStatsStored.m_eResult);
				}
			}
		}

		private IEnumerator ReportProgressCoroutine(string achievementID, double progress, Action<bool> callback)
		{
			while (_loadingUserStats)
			{
				yield return new WaitForSeconds(1f);
			}
			bool flag = true;
			if (UserStatsReceived)
			{
				AchievementInfo achievementInfo = _achievementDatabase.FindById(achievementID);
				Achievement achievement = (_achievements.ContainsKey(achievementID) ? _achievements[achievementID] : null);
				if (achievementInfo == null)
				{
					UnityEngine.Debug.LogErrorFormat("Cannot report progress for Steam achievement '{0}'. The achievement ID could not be found in the database.", achievementID);
				}
				else if (achievement == null)
				{
					UnityEngine.Debug.LogErrorFormat("Cannot report progress for Steam achievement '{0}'. The achievement object could not be found.", achievementID);
				}
				else if (!string.IsNullOrEmpty(achievementInfo.SteamStatId))
				{
					double num = Math.Abs(achievementInfo.MaxValue - achievementInfo.MinValue);
					if (num == 0.0)
					{
						num = 1.0;
					}
					double num2 = achievement.percentCompleted / 100.0 * num + achievementInfo.MinValue;
					double incrementAmount = Math.Max(0.0, Math.Min(1.0, progress / 100.0)) * num + achievementInfo.MinValue - num2;
					if (IncrementAchievement(achievementID, incrementAmount, showProgress: false, achievementInfo.SteamStatDataType == SteamStatDataType.Integer))
					{
						flag = false;
						StopStartCoroutine(ref _storeStatsCoroutine, StoreStatsCoroutine, callback);
					}
				}
				else if (progress >= 100.0)
				{
					if (UnlockAchievement(achievement))
					{
						flag = false;
						StopStartCoroutine(ref _storeStatsCoroutine, StoreStatsCoroutine, callback);
					}
				}
				else
				{
					UnityEngine.Debug.LogErrorFormat("Cannot report progress of {0}% for Steam achievement '{1}'. The achievement is not a progress based achievement.", progress, achievementID);
				}
			}
			else
			{
				UnityEngine.Debug.LogErrorFormat("Cannot report progress for Steam achievement '{0}'. The user stats were unable to be retrieved.", achievementID);
			}
			if (flag)
			{
				callback?.Invoke(obj: false);
			}
		}

		private IEnumerator RequestCurrentStatsCoroutine(Action<bool> callback)
		{
			_loadingUserStats = true;
			bool success = true;
			int counter = 0;
			while (!SteamUserStats.RequestCurrentStats())
			{
				counter++;
				if (counter == 10)
				{
					UnityEngine.Debug.LogErrorFormat("Steam failed 10 times trying to get the user's stats");
				}
				else if (counter == 100)
				{
					UnityEngine.Debug.LogErrorFormat("Steam failed 100 times trying to get the user's stats, giving up...");
					success = false;
					_loadingUserStats = false;
					break;
				}
				yield return new WaitForSeconds(1f);
			}
			callback?.Invoke(success);
		}

		private void StopStartCoroutine(ref Coroutine coroutineReference, Func<Action<bool>, IEnumerator> coroutineMethod, Action<bool> callback)
		{
			if (coroutineReference != null)
			{
				SteamManager.StopCoroutine(coroutineReference);
			}
			coroutineReference = SteamManager.StartCoroutine(coroutineMethod(callback));
		}

		private IEnumerator StoreStatsCoroutine(Action<bool> callback)
		{
			bool success = true;
			int counter = 0;
			while (!SteamUserStats.StoreStats())
			{
				counter++;
				if (counter == 10)
				{
					UnityEngine.Debug.LogErrorFormat("Steam failed 10 times trying to store the user's stats");
				}
				else if (counter == 100)
				{
					UnityEngine.Debug.LogErrorFormat("Steam failed 100 times trying to store the user's stats, giving up...");
					success = false;
					break;
				}
				yield return new WaitForSeconds(1f);
			}
			callback?.Invoke(success);
		}

		private bool UnlockAchievement(Achievement achievement)
		{
			achievement.percentCompleted = 100.0;
			achievement.lastReportedDate = DateTime.Now;
			achievement.hidden = achievement.hidden && achievement.percentCompleted <= 0.0;
			if (!SteamUserStats.SetAchievement(achievement.id))
			{
				UnityEngine.Debug.LogErrorFormat("Unlocking Steam achievement '{0}' failed.", achievement.id);
				return false;
			}
			return true;
		}

		private void UpdateAchievements()
		{
			string text = string.Empty;
			foreach (AchievementInfo achievement2 in _achievementDatabase.Achievements)
			{
				if (!achievement2.Platforms.Steam)
				{
					continue;
				}
				string steamId = achievement2.SteamId;
				if (SteamUserStats.GetAchievementAndUnlockTime(steamId, out var pbAchieved, out var punUnlockTime))
				{
					Achievement achievement = null;
					if (_achievements.ContainsKey(steamId))
					{
						achievement = _achievements[steamId];
					}
					else
					{
						achievement = CreateSteamAchievement();
						_achievements.Add(steamId, achievement);
					}
					double num = 0.0;
					if (pbAchieved)
					{
						num = 100.0;
					}
					else if (!string.IsNullOrEmpty(achievement2.SteamStatId))
					{
						double num2 = 0.0;
						float pData2;
						if (achievement2.SteamStatDataType == SteamStatDataType.Integer && SteamUserStats.GetStat(achievement2.SteamStatId, out int pData))
						{
							num2 = pData;
						}
						else if (achievement2.SteamStatDataType == SteamStatDataType.Float && SteamUserStats.GetStat(achievement2.SteamStatId, out pData2))
						{
							num2 = pData2;
						}
						double num3 = Math.Abs(achievement2.MaxValue - achievement2.MinValue);
						if (num3 == 0.0)
						{
							num3 = 1.0;
						}
						num = Math.Max(0.0, Math.Min(100.0, (num2 - achievement2.MinValue) / num3 * 100.0));
					}
					achievement.id = steamId;
					achievement.hidden = achievement2.Hidden && num <= 0.0;
					achievement.lastReportedDate = ((punUnlockTime == 0) ? DateTime.Now : new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(punUnlockTime));
					achievement.percentCompleted = num;
				}
				else
				{
					text += $"Unable to obtain achievement info for achievement '{steamId}'\n";
				}
			}
			if (DebuggingEnabled)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					UnityEngine.Debug.LogError(text);
				}
				DumpAchievementToConsole();
			}
		}

		private IEnumerator WaitForUserStatsCoroutine<T>(Action<T> callback, T callbackObject)
		{
			while (_loadingUserStats)
			{
				yield return new WaitForSeconds(1f);
			}
			callback(callbackObject);
		}
	}
}
