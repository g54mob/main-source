using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using PartyCSharpSDK;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Multiplayer;
using PlayFab.MultiplayerModels;
using PlayFab.Party;
using Unity.XGamingRuntime;
using Unity.XGamingRuntime.Interop;
using UnityEngine;

namespace Aggro.Core
{
	public class GameCorePlatform : IPlatform
	{
		private enum InitializationState
		{
			NotInitialized = 0,
			Errored = 1,
			Initialized = 2
		}

		public enum LobbyPermissionResult
		{
			Allowed = 0,
			BlockedFromMultiplayer = 1,
			BlockedFromVoice = 2,
			BlockedFromBoth = 3,
			Error = 4
		}

		private delegate bool TryParseDelegate<T>(string input, out T result);

		private InitializationState _initializationState;

		public const string SCID = "00000000-0000-0000-0000-00006afd5dc2";

		public const string TITLEID = "6AFD5DC2";

		private const bool SAVEONDEMAND = true;

		private const string SAVESLOTCONTAINERNAME = "saveslotcontainer";

		private const string SAVESLOTBLOBNAME = "saveslotblob";

		public const string EXPECTEDTESTINGSANDBOX = "MHZRWV.1";

		public const string CONNECTIONSTRINGPARSINGREGEX = "connectionString=([^&]*)(?:&|$)";

		public const string NETWORKIDPROPERTY = "networkid";

		public const string FULLCONNECTIONSTRINGREGEX = "(cv.+)";

		public const int LEAVELOBBYTIMEOUTMILISECONDS = 4000;

		private readonly Dictionary<string, int> _localStatCache = new Dictionary<string, int>
		{
			{ "stat_crashout_count", 0 },
			{ "stat_boost_count", 0 },
			{ "stat_drift_distance", 0 },
			{ "stat_shipped_boxes", 0 },
			{ "stat_shipped_explosives", 0 },
			{ "stat_shipped_animals", 0 },
			{ "stat_fires_extinguished", 0 },
			{ "stat_junk_destroyed", 0 },
			{ "stat_trash_money", 0 },
			{ "stat_banana_slips", 0 },
			{ "stat_messes_cleaned", 0 },
			{ "stat_clowns_released", 0 },
			{ "stat_tiptap_minutes", 0 }
		};

		private float _driftingDistanceCache;

		private const float _driftingDistanceUpdateinterval = 1.5f;

		private float _lastDriftingUpdateTime;

		private float _tiptapTimeCache;

		private const int ACHIEVEMENT_MIN_PROGRESS = 5;

		private readonly Dictionary<string, long> _tiptapLikesCache = new Dictionary<string, long>();

		private ulong[] _hostXuid = new ulong[1];

		private TaskCompletionSource<bool> _mirrorHostForceUpdate;

		private XAsyncBlock playFabAsyncBlockForLogin;

		private XTaskQueueHandle playFabLoginTaskHandle;

		private XUserGetTokenAndSignatureData playFabResponseHandle;

		private ulong playFabSignatureResponseSize;

		private XAsyncCompletionRoutine playFabTokenCompletionRoutine;

		private XblSocialManagerUserGroupHandle socialGroupHandle;

		private ulong[] socialUserXUIDs;

		private XblSocialManagerUser[] socialUsers;

		private SemaphoreSlim initializationSemaphore { get; set; } = new SemaphoreSlim(0, 1);

		private SemaphoreSlim leaveLobbySempahore { get; set; } = new SemaphoreSlim(1, 1);

		private SemaphoreSlim updateMPASemaphore { get; set; } = new SemaphoreSlim(1, 1);

		private Action<PlatformGameJoin> _onJoinGame { get; set; }

		private bool shouldResumePlayFab { get; set; }

		private string queuedJoinGameInviteUri { get; set; }

		private GameCoreManager gameCoreManager
		{
			get
			{
				if (_gameCoreManagerSet)
				{
					return _gameCoreManager;
				}
				_gameCoreManager = GameCoreManager.GetOrCreateManager();
				_gameCoreManagerSet = true;
				return _gameCoreManager;
			}
		}

		private GameCoreManager _gameCoreManager { get; set; }

		private bool _gameCoreManagerSet { get; set; }

		public async Task<bool> InitializeAsync(Action<PlatformGameJoin> onJoinedLobby)
		{
			bool result = await InitializeAsyncImpl(onJoinedLobby);
			if (_initializationState == InitializationState.Errored)
			{
				Application.Quit();
			}
			return result;
		}

		private async Task<bool> InitializeAsyncImpl(Action<PlatformGameJoin> onJoinedLobby)
		{
			_onJoinGame = onJoinedLobby;
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [InitializeAsync] Initialization starting");
			await gameCoreManager.InitializePlayerPrefsAsync();
			int num = InitializeGamingRuntime();
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num) || !InitializeXboxLive())
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [InitializeAsync] Initialization failure. HRESULT: 0x{num:X}");
				_initializationState = InitializationState.Errored;
				return false;
			}
			int num2 = Unity.XGamingRuntime.SDK.XGameGetXboxTitleId(out var titleId);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [InitializeAsync] FAILED: Could not get TitleID! hResult: 0x{num2:x} ({Unity.XGamingRuntime.HR.NameOf(num2)})");
			}
			if (!titleId.ToString("X").ToLower().Equals("6AFD5DC2".ToLower()))
			{
				Debug.LogWarning(string.Format("[{0}] [GameCorePlatform] [InitializeAsync] WARNING! Expected Title Id: {1} got: {2:X}", Time.frameCount, "6AFD5DC2", titleId));
			}
			num2 = Unity.XGamingRuntime.SDK.XSystemGetXboxLiveSandboxId(out var sandboxId);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [InitializeAsync] FAILED: Could not get SandboxID! HResult: 0x{num2:x} ({Unity.XGamingRuntime.HR.NameOf(num2)})");
			}
			if (!sandboxId.Equals("MHZRWV.1"))
			{
				Debug.LogWarning(string.Format("[{0}] [GameCorePlatform] [InitializeAsync] WARNING! Expected sandbox Id: {1} got: {2}", Time.frameCount, "MHZRWV.1", sandboxId));
			}
			gameCoreManager.RaiseUserSignInStarted();
			TaskCompletionSource<int> onAddUserResultSource = new TaskCompletionSource<int>();
			int num3 = Unity.XGamingRuntime.SDK.XUserAddAsync(XUserAddOptions.AddDefaultUserAllowingUI, delegate(int hResult, XUserHandle userHandle)
			{
				onAddUserResultSource.SetResult(OnAddUser(hResult, userHandle));
			});
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num3))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [InitializeAsync] Request to add user failed. HRESULT: 0x{num3:X}");
				_initializationState = InitializationState.Errored;
				return false;
			}
			gameCoreManager.StartDispatch();
			while (!onAddUserResultSource.Task.IsCompleted)
			{
				await Task.Yield();
			}
			if (Unity.XGamingRuntime.Interop.HR.FAILED(onAddUserResultSource.Task.Result))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [InitializeAsync] Callback for add user failed. HRESULT: 0x{onAddUserResultSource.Task.Result:X}");
				_initializationState = InitializationState.Errored;
				return false;
			}
			TaskCompletionSource<List<XblAchievement>> xblAchievementSource = new TaskCompletionSource<List<XblAchievement>>();
			Unity.XGamingRuntime.SDK.XBL.XblAchievementsGetAchievementsForTitleIdAsync(gameCoreManager.PrimaryUser.m_context, gameCoreManager.PrimaryUser.userXUID, titleId, XblAchievementType.All, unlockedOnly: false, XblAchievementOrderBy.DefaultOrder, 0u, 0u, async delegate(int hr, XblAchievementsResultHandle resultHandle)
			{
				if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hr))
				{
					List<XblAchievement> xblAchievements = new List<XblAchievement>();
					bool hasNext;
					do
					{
						hasNext = false;
						if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(Unity.XGamingRuntime.SDK.XBL.XblAchievementsResultGetAchievements(resultHandle, out var achievements)))
						{
							xblAchievements.AddRange(achievements);
							Unity.XGamingRuntime.SDK.XBL.XblAchievementsResultHasNext(resultHandle, out hasNext);
							if (hasNext)
							{
								TaskCompletionSource<int> getNextSource = new TaskCompletionSource<int>();
								Unity.XGamingRuntime.SDK.XBL.XblAchievementsResultGetNextAsync(resultHandle, (uint)XboxAchievementRegistry.Achievements.Count, delegate(int result, XblAchievementsResultHandle nextHandle)
								{
									Unity.XGamingRuntime.SDK.XBL.XblAchievementsResultCloseHandle(resultHandle);
									resultHandle = nextHandle;
									getNextSource.SetResult(result);
								});
								hasNext = Unity.XGamingRuntime.Interop.HR.SUCCEEDED(await getNextSource.Task);
							}
						}
					}
					while (hasNext);
					xblAchievementSource.SetResult(xblAchievements);
				}
				else
				{
					xblAchievementSource.SetResult(null);
				}
				Unity.XGamingRuntime.SDK.XBL.XblAchievementsResultCloseHandle(resultHandle);
			});
			List<XblAchievement> list = await xblAchievementSource.Task;
			if (list != null)
			{
				XboxAchievementRegistry.InitProgress(list);
			}
			TaskCompletionSource<Tuple<int, ulong[]>> muteListResult = new TaskCompletionSource<Tuple<int, ulong[]>>();
			Unity.XGamingRuntime.SDK.XBL.XblPrivacyGetMuteListAsync(gameCoreManager.PrimaryUser.m_context, delegate(int hResult, ulong[] result)
			{
				muteListResult.SetResult(new Tuple<int, ulong[]>(hResult, result));
			});
			while (!muteListResult.Task.IsCompleted)
			{
				await Task.Yield();
			}
			if (Unity.XGamingRuntime.Interop.HR.FAILED(muteListResult.Task.Result.Item1))
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OnAddUser] [GetMuteList] Error getting the MuteList. HRESULT: 0x{muteListResult.Task.Result.Item1:X}");
			}
			else
			{
				gameCoreManager.PrimaryUser.muteList = muteListResult.Task.Result.Item2;
				Debug.Log("Mutelist Obtained!");
			}
			TaskCompletionSource<Tuple<int, ulong[]>> avoidListResult = new TaskCompletionSource<Tuple<int, ulong[]>>();
			Unity.XGamingRuntime.SDK.XBL.XblPrivacyGetAvoidListAsync(gameCoreManager.PrimaryUser.m_context, delegate(int hresult, ulong[] xuids)
			{
				avoidListResult.SetResult(new Tuple<int, ulong[]>(hresult, xuids));
			});
			await avoidListResult.Task;
			if (Unity.XGamingRuntime.Interop.HR.FAILED(avoidListResult.Task.Result.Item1))
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OnAddUser] [GetMuteList] Error getting the AvoidList. HRESULT: 0x{avoidListResult.Task.Result.Item1:X}");
			}
			else
			{
				gameCoreManager.PrimaryUser.avoidList = avoidListResult.Task.Result.Item2;
				Debug.Log("Avoidlist Obtained!");
			}
			Unity.XGamingRuntime.SDK.XGameSaveInitializeProviderAsync(gameCoreManager.PrimaryUser.userHandle, "00000000-0000-0000-0000-00006afd5dc2", syncOnDemand: true, delegate(int hresult, XGameSaveProviderHandle gameSaveProviderHandle)
			{
				OnSaveGameInitialized(hresult, gameSaveProviderHandle);
			});
			await initializationSemaphore.WaitAsync();
			await Task.Yield();
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [InitializeAsync] Populate local stat cache");
			await Task.WhenAll(_localStatCache.Keys.Select(GrabAndCacheStatAsync));
			await GrabAndCacheStatAsync("stat_drift_distance");
			Debug.Log(string.Format("[{0}] [GameCorePlatform] [InitializeAsync] Populate local stat test, boxes = {1}", Time.frameCount, _localStatCache["stat_shipped_boxes"]));
			int num4 = Unity.XGamingRuntime.SDK.XBL.XblSocialManagerAddLocalUser(gameCoreManager.PrimaryUser.userHandle, XblSocialManagerExtraDetailLevel.TitleHistoryLevel);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num4))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [InitializeAsync] Failed to initialize self in the social graph. 0x{num4:X8}.");
				return false;
			}
			await gameCoreManager.YieldUntilSocialManagerEvent(XblSocialManagerEventType.LocalUserAdded, null, 2000);
			RegisterToPlayFabCallbacks();
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [InitializeAsync] Initialization complete");
			_initializationState = InitializationState.Initialized;
			return true;
		}

		public PlatformType GetPlatformType()
		{
			return PlatformType.GameCore;
		}

		public bool HasPlatformJoin()
		{
			return true;
		}

		public bool PlayerMutedByPlatform(ulong platformId)
		{
			XUserPrivilegeDenyReason reason;
			if (platformId == gameCoreManager.PrimaryUser.userXUID)
			{
				return !CheckPrivilege(XUserPrivilege.Communications, out reason);
			}
			if (!gameCoreManager.PrimaryUser.muteList.Contains(platformId))
			{
				return gameCoreManager.PrimaryUser.avoidList.Contains(platformId);
			}
			return true;
		}

		public async Task<bool> PlayerMutedByPlatformAsync(ulong platformId)
		{
			return await GetSinglePermission(platformId, XblPermission.CommunicateUsingVoice);
		}

		public bool PlayerMutedByPlatform(string playFabId)
		{
			XUserPrivilegeDenyReason reason;
			if (playFabId.Equals(GetPlayFabId()))
			{
				return !CheckPrivilege(XUserPrivilege.Communications, out reason);
			}
			IList<PlayFabPlayer> remotePlayers = PlayFabMultiplayerManager.Get().RemotePlayers;
			if (remotePlayers == null)
			{
				return false;
			}
			foreach (PlayFabPlayer item in remotePlayers)
			{
				if (item.EntityKey.Id == playFabId)
				{
					Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [PlayerMutedByPlatform] Player {playFabId} chat state = {item.ChatState}.");
					if (item.IsMuted)
					{
						Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [PlayerMutedByPlatform] Player {playFabId} is muted.");
					}
					return item.IsMuted;
				}
			}
			return false;
		}

		private bool CheckPrivilege(XUserPrivilege privilege, out XUserPrivilegeDenyReason reason)
		{
			bool hasPrivilege;
			int num = Unity.XGamingRuntime.SDK.XUserCheckPrivilege(gameCoreManager.PrimaryUser.userHandle, XUserPrivilegeOptions.None, privilege, out hasPrivilege, out reason);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.Log($"[GameCorePlatform] [CheckPrivilege] Failed to check privilege {privilege} for user {gameCoreManager.PrimaryUser.userXUID}. HRESULT: 0x{num:X}");
				return false;
			}
			if (!hasPrivilege)
			{
				Debug.Log($"[GameCorePlatform] [CheckPrivilege] User {gameCoreManager.PrimaryUser.userXUID} does not have privilege {privilege} Reason: {reason}");
				return false;
			}
			return true;
		}

		private async Task<bool> CheckPrivilegeAsync(XUserPrivilege privilege)
		{
			if (!CheckPrivilege(privilege, out var reason))
			{
				Debug.Log($"[GameCorePlatform] [CheckPrivilegeAsync] User {gameCoreManager.PrimaryUser.userXUID} does not have privilege {privilege} Reason: {reason}");
				TaskCompletionSource<int> purchaseResultSource = new TaskCompletionSource<int>();
				Unity.XGamingRuntime.SDK.XUserResolvePrivilegeWithUiAsync(gameCoreManager.PrimaryUser.userHandle, XUserPrivilegeOptions.None, privilege, delegate(int hr)
				{
					purchaseResultSource.SetResult(hr);
				});
				while (!purchaseResultSource.Task.IsCompleted)
				{
					await purchaseResultSource.Task;
				}
				if (Unity.XGamingRuntime.Interop.HR.FAILED(purchaseResultSource.Task.Result))
				{
					Debug.Log($"[GameCorePlatform] [CheckPrivilegeAsync] User {gameCoreManager.PrimaryUser.userXUID} does not gain privilege {privilege}");
					return false;
				}
				Debug.Log($"[GameCorePlatform] [CheckPrivilegeAsync] User {gameCoreManager.PrimaryUser.userXUID} has gained privilege {privilege}");
			}
			return true;
		}

		public void ShowProfile(ulong platformId)
		{
			Unity.XGamingRuntime.SDK.XGameUiShowPlayerProfileCardAsync(gameCoreManager.PrimaryUser.userHandle, platformId, delegate(int hresult)
			{
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hresult))
				{
					Debug.Log($"Failed to show profile for user {platformId}. HRESULT: {Unity.XGamingRuntime.HR.NameOf(hresult)}, 0x{hresult:X}");
				}
			});
		}

		private async Task<bool> GetSinglePermission(ulong targetXuid, XblPermission permission)
		{
			TaskCompletionSource<bool> permissionResult = new TaskCompletionSource<bool>();
			Unity.XGamingRuntime.SDK.XBL.XblPrivacyCheckPermissionAsync(gameCoreManager.PrimaryUser.m_context, permission, targetXuid, delegate(int hResult, XblPermissionCheckResult result)
			{
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hResult))
				{
					Debug.Log($"[GameCorePlatform] Permission check failed against target user {targetXuid} with error {hResult}");
					permissionResult.SetResult(result: false);
				}
				else
				{
					if (!result.IsAllowed)
					{
						Debug.Log($"[GameCorePlatform] [GetSinglePermission] User {gameCoreManager.PrimaryUser.userXUID} blocked user {targetXuid} from {permission}");
					}
					permissionResult.SetResult(result.IsAllowed);
				}
			});
			await permissionResult.Task;
			return permissionResult.Task.Result;
		}

		private async Task<LobbyPermissionResult> CheckUserPermissionsAsync(ulong targetXuid)
		{
			Task<bool> multiplayerPermissionResult = GetSinglePermission(targetXuid, XblPermission.PlayMultiplayer);
			Task<bool> voicePermissionResult = GetSinglePermission(targetXuid, XblPermission.CommunicateUsingVoice);
			await Task.WhenAll<bool>(multiplayerPermissionResult, voicePermissionResult);
			bool result = multiplayerPermissionResult.Result;
			bool result2 = voicePermissionResult.Result;
			if (!result && !result2)
			{
				return LobbyPermissionResult.BlockedFromBoth;
			}
			if (!result)
			{
				return LobbyPermissionResult.BlockedFromMultiplayer;
			}
			if (!result2)
			{
				return LobbyPermissionResult.BlockedFromVoice;
			}
			return LobbyPermissionResult.Allowed;
		}

		public async Task<bool> CreateLobbyAsync(bool allowFriendsToJoin, int maxPlayersIncludingHost)
		{
			if (!(await CheckPrivilegeAsync(XUserPrivilege.Multiplayer)))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [CreateLobbyAsync] User {gameCoreManager.PrimaryUser.userXUID} does not have multiplayer privilege");
				return false;
			}
			if (!(await TryLoginToPlayFab()))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [CreateLobbyAsync] Could not log in to PlayFab, cannot make lobby.");
				return false;
			}
			await _LeaveLobbyAsync();
			string text = await CreateNetworkAndJoinIt((uint)maxPlayersIncludingHost);
			if (string.IsNullOrEmpty(text))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [CreateLobbyAsync] Failed to create a PlayFab party, cannot make lobby.");
				return false;
			}
			CreateLobbyResult createLobbyResult = await CreateLobbyAndJoinIt((uint)maxPlayersIncludingHost, text);
			if (createLobbyResult == null)
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [CreateLobbyAsync] Failed to create lobby.");
				return false;
			}
			int retriesPermitted = 5;
			int miliSecondsBetweenAttempts = 500;
			GetLobbyResult lobbyResult = null;
			while (retriesPermitted > 0 && lobbyResult == null)
			{
				TaskCompletionSource<GetLobbyResult> getLobbyResult = new TaskCompletionSource<GetLobbyResult>();
				PlayFabMultiplayerAPI.GetLobby(new GetLobbyRequest
				{
					LobbyId = createLobbyResult.LobbyId
				}, delegate(GetLobbyResult result)
				{
					getLobbyResult.SetResult(result);
				}, delegate(PlayFabError error)
				{
					Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [CreateLobbyAsync] Failed to get already joined lobby. May try again. {error.ErrorMessage}");
					getLobbyResult.SetResult(null);
				});
				await getLobbyResult.Task;
				if (getLobbyResult.Task.Result == null)
				{
					await Task.Delay(miliSecondsBetweenAttempts);
					retriesPermitted--;
				}
				else
				{
					lobbyResult = getLobbyResult.Task.Result;
				}
			}
			if (lobbyResult == null)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [CreateLobbyAsync] Failed to get own lobby.");
				return false;
			}
			await RefreshCurrentRoomMultiplayerActivityInfoAsync(lobbyResult.Lobby, openToMoreJoiners: true);
			return true;
		}

		private async Task<string> CreateNetworkAndJoinIt(uint playerCount)
		{
			PlayFabMultiplayerManager multiplayerManager = PlayFabMultiplayerManager.Get();
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [CreateNetworkAndJoinIt] Starting to create a PlayFab party; play fab token is '{gameCoreManager.PlayFabConnectionData.PlayFabToken}'");
			TaskCompletionSource<string> pfNetworkJoiningResult = new TaskCompletionSource<string>();
			multiplayerManager.OnNetworkJoined += AfterJoin;
			multiplayerManager.OnError += OnTransportError;
			multiplayerManager.CreateAndJoinNetwork(new PlayFabNetworkConfiguration
			{
				DirectPeerConnectivityOptions = PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS.PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS_ANY_ENTITY_LOGIN_PROVIDER,
				MaxPlayerCount = playerCount
			});
			string text = await pfNetworkJoiningResult.Task;
			multiplayerManager.OnNetworkJoined -= AfterJoin;
			multiplayerManager.OnError -= OnTransportError;
			if (string.IsNullOrEmpty(text))
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [CreateNetworkAndJoinIt] Failed to create network, id was null.");
				return string.Empty;
			}
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [CreateNetworkAndJoinIt] Created network with id {text}");
			return text;
			void AfterJoin(object sender, string networkId)
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [CreateNetworkAndJoinIt] Joined network {networkId}");
				pfNetworkJoiningResult.SetResult(networkId);
			}
			void OnTransportError(object sender, PlayFabMultiplayerManagerErrorArgs args)
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [CreateNetworkAndJoinIt] Failed to create network. {args.Message}");
				pfNetworkJoiningResult.SetResult(null);
			}
		}

		private async Task _LeaveAllLobbiesAsync()
		{
			string filter = "lobby/amMember eq 'true'";
			TaskCompletionSource<bool> completedSource = new TaskCompletionSource<bool>();
			PlayFabMultiplayerAPI.FindLobbies(new FindLobbiesRequest
			{
				Filter = filter
			}, async delegate(FindLobbiesResult findLobbiesResult)
			{
				if (findLobbiesResult.Lobbies.Count > 0)
				{
					Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [_LeaveAllLobbiesAsync] User is currently a member of {findLobbiesResult.Lobbies.Count} lobbies.");
					foreach (LobbySummary curLobby in findLobbiesResult.Lobbies)
					{
						TaskCompletionSource<bool> leftLobbySource = new TaskCompletionSource<bool>();
						PlayFabMultiplayerAPI.LeaveLobby(new LeaveLobbyRequest
						{
							LobbyId = curLobby.LobbyId,
							MemberEntity = gameCoreManager.PlayFabConnectionData.MultiplayerEntityKey
						}, delegate
						{
							Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [_LeaveAllLobbiesAsync] Successfully left lobby id {curLobby.LobbyId}");
							leftLobbySource.SetResult(result: true);
						}, delegate(PlayFabError error)
						{
							Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [_LeaveAllLobbiesAsync] Failed to leave lobby {curLobby.LobbyId}. Error {error.Error} {error.ErrorMessage}.");
							leftLobbySource.SetResult(result: true);
						});
						await leftLobbySource.Task;
					}
				}
				completedSource.SetResult(result: true);
			}, delegate(PlayFabError error)
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [_LeaveAllLobbiesAsync] Failed to find lobbies user is a member of. Error {error.Error} {error.ErrorMessage}.");
				completedSource.SetResult(result: true);
			});
			await completedSource.Task;
		}

		private async Task<CreateLobbyResult> CreateLobbyAndJoinIt(uint maxPlayersIncludingHost, string networkId)
		{
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [CreateLobbyAndJoinIt] Starting to create a PlayFab lobby, with network id '{networkId}'");
			gameCoreManager.PlayFabLobbyData.IsHost = true;
			gameCoreManager.PlayFabLobbyData.HostKey = gameCoreManager.PlayFabConnectionData.MultiplayerEntityKey;
			TaskCompletionSource<CreateLobbyResult> createLobbyResultTCS = new TaskCompletionSource<CreateLobbyResult>();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("networkid", networkId);
			PlayFabMultiplayerAPI.CreateLobby(new CreateLobbyRequest
			{
				MaxPlayers = maxPlayersIncludingHost,
				Owner = gameCoreManager.PlayFabConnectionData.MultiplayerEntityKey,
				Members = new List<Member>
				{
					new Member
					{
						MemberEntity = gameCoreManager.PlayFabConnectionData.MultiplayerEntityKey,
						MemberData = new Dictionary<string, string> { 
						{
							"xuid",
							gameCoreManager.PrimaryUser.userXUID.ToString()
						} }
					}
				},
				LobbyData = dictionary
			}, delegate(CreateLobbyResult result)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [CreateLobbyAsync] Lobby successfully created");
				createLobbyResultTCS.SetResult(result);
			}, delegate(PlayFabError error)
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [CreateLobbyAsync] Failed to create lobby. Error: {error.ToString()}");
				createLobbyResultTCS.SetResult(null);
			}, networkId);
			while (!createLobbyResultTCS.Task.IsCompleted)
			{
				await Task.Yield();
			}
			if (createLobbyResultTCS.Task.Result == null)
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [CreateLobbyAsync] Failed to create lobby.");
				return null;
			}
			await Task.Yield();
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [CreateLobbyAndJoinIt] Successfully created a PlayFab lobby");
			return createLobbyResultTCS.Task.Result;
		}

		public async void LeaveLobby()
		{
			await _LeaveLobbyAsync(suspendPlayfab: true);
		}

		public async Task _LeaveLobbyAsync(bool suspendPlayfab = false)
		{
			_hostXuid[0] = 0uL;
			await leaveLobbySempahore.WaitAsync();
			if (PlayFabSettings.staticPlayer.IsClientLoggedIn())
			{
				Debug.LogWarning($"[{Time.frameCount}] [GameCorePlatform] [_LeaveLobbyAsync] Clearing out the PlayFabMultiplayerManager's current connection data.");
				await PlayFabMultiplayerManager.Get().PEWClearParty();
				Debug.LogWarning($"[{Time.frameCount}] [GameCorePlatform] [_LeaveLobbyAsync] Finished clearing PlayFabMultiplayerManager connection data.");
				await _LeaveAllLobbiesAsync();
			}
			TaskCompletionSource<bool> deleteActivity = new TaskCompletionSource<bool>();
			Unity.XGamingRuntime.SDK.XBL.XblMultiplayerActivityDeleteActivityAsync(gameCoreManager.PrimaryUser.m_context, delegate(int hr)
			{
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
				{
					Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [_LeaveLobbyAsync] Failed to delete activity. HRESULT: 0x{hr:X}");
				}
				else
				{
					Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [_LeaveLobbyAsync] Deleted activity.");
				}
				deleteActivity.SetResult(result: true);
			});
			await deleteActivity.Task;
			GameCoreManager.GetOrCreateManager().ClearConnectionData();
			leaveLobbySempahore.Release();
		}

		public async void SetLobbyJoinable(bool isJoinable)
		{
			Debug.Log($"[{Time.frameCount}] [GameCoreManager] [SetLobbyJoinable] {isJoinable}");
			gameCoreManager.PlayFabLobbyData.LobbyJoinable = isJoinable;
			if (string.IsNullOrEmpty(gameCoreManager.PlayFabLobbyData.CurrentLobbyId))
			{
				Debug.LogWarning($"[{Time.frameCount}] [GameCoreManager] [SetLobbyJoinable] Asked to set joinable status, but not in a lobby. {isJoinable}");
			}
			else
			{
				await RefreshCurrentRoomMultiplayerActivityInfoAsync(gameCoreManager.PlayFabLobbyData.CurrentLobbyId, gameCoreManager.PlayFabLobbyData.CurrentLobbyConnectionString, gameCoreManager.PlayFabLobbyData.CurrentMemberCount, gameCoreManager.PlayFabLobbyData.MaxMemberCount, gameCoreManager.PlayFabLobbyData.LobbyJoinable);
			}
		}

		public void SetLobbyAllowFriends(bool allowFriends)
		{
		}

		public string GetUserName()
		{
			if (_initializationState != InitializationState.Initialized)
			{
				Debug.LogError("[GameCorePlatform] [GetUserName] Attempted to get user name, but the GameCorePlatform has not successfully initialized.");
			}
			return gameCoreManager.PrimaryUser.userGamertag;
		}

		public async Task<Platform.JoinListError> OpenJoinList()
		{
			if (!(await CheckPrivilegeAsync(XUserPrivilege.Multiplayer)))
			{
				return Platform.JoinListError.NotInitialized;
			}
			int num = Unity.XGamingRuntime.SDK.XBL.XblSocialManagerCreateSocialUserGroupFromFilters(gameCoreManager.PrimaryUser.userHandle, XblPresenceFilter.TitleOnline, XblRelationshipFilter.Friends, out socialGroupHandle);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] Failed to get user social group. 0x{num:X8}.");
				Unity.XGamingRuntime.SDK.XBL.XblSocialManagerDestroySocialUserGroup(socialGroupHandle);
				return Platform.JoinListError.NotInitialized;
			}
			bool num2 = await gameCoreManager.YieldUntilSocialManagerEvent(XblSocialManagerEventType.SocialUserGroupLoaded, socialGroupHandle, 5000);
			int num3 = -2147467259;
			if (num2)
			{
				num3 = Unity.XGamingRuntime.SDK.XBL.XblSocialManagerUserGroupGetUsers(socialGroupHandle, out socialUsers);
			}
			int num4 = Unity.XGamingRuntime.SDK.XBL.XblSocialManagerDestroySocialUserGroup(socialGroupHandle);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num4))
			{
				Debug.LogWarning($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] Failed to remove social group handle. Ignoring and continuing. - 0x{num4:X8}.");
			}
			if (!num2)
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] Timeout occurred before SocialUserGroupLoaded event.");
				return Platform.JoinListError.NotInitialized;
			}
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num3))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] Failed to get users - 0x{num3:X8}.");
				return Platform.JoinListError.NotInitialized;
			}
			if (socialUsers.Length == 0)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] This user has no relevant friends currently playing the title.");
				return Platform.JoinListError.NoJoinAvailable;
			}
			string arg = string.Join(", ", socialUsers.Select((XblSocialManagerUser x) => $"{x.XboxUserId} - {x.DisplayName}"));
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] Retrieved all friends who have played this title: {arg}");
			List<ulong> list = new List<ulong>();
			XblSocialManagerUser[] array = socialUsers;
			foreach (XblSocialManagerUser xblSocialManagerUser in array)
			{
				XblSocialManagerPresenceRecord presenceRecord = xblSocialManagerUser.PresenceRecord;
				if (presenceRecord.UserState != XblPresenceUserState.Online)
				{
					Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] This user's record indicates they are not online, so skipping. {xblSocialManagerUser.DisplayName} {xblSocialManagerUser.XboxUserId}");
					continue;
				}
				uint num6 = Convert.ToUInt32("6AFD5DC2", 16);
				XblSocialManagerPresenceTitleRecord[] presenceTitleRecords = presenceRecord.PresenceTitleRecords;
				for (int num7 = 0; num7 < presenceTitleRecords.Length; num7++)
				{
					if (presenceTitleRecords[num7].TitleId == num6)
					{
						Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] This user is marked as online, and in this game. {xblSocialManagerUser.DisplayName} {xblSocialManagerUser.XboxUserId}");
						list.Add(xblSocialManagerUser.XboxUserId);
						break;
					}
				}
			}
			if (list.Count == 0)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] This user has no relevant friends are playing the title. This should show some kind of message.");
				return Platform.JoinListError.NoJoinAvailable;
			}
			socialUserXUIDs = list.ToArray();
			TaskCompletionSource<XblMultiplayerActivityInfo[]> multiplayerActivities = new TaskCompletionSource<XblMultiplayerActivityInfo[]>();
			Unity.XGamingRuntime.SDK.XBL.XblMultiplayerActivityGetActivityAsync(gameCoreManager.PrimaryUser.m_context, socialUserXUIDs, delegate(int hresult, XblMultiplayerActivityInfo[] results)
			{
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hresult))
				{
					Debug.LogError($"[GameCorePlatform] [OpenJoinList] Failed to get multiplayer activities. HRESULT: 0x{hresult:X}");
					multiplayerActivities.SetResult(null);
				}
				else
				{
					multiplayerActivities.SetResult(results);
				}
			});
			await multiplayerActivities.Task;
			if (multiplayerActivities.Task.Result == null)
			{
				return Platform.JoinListError.NoJoinAvailable;
			}
			if (multiplayerActivities.Task.Result.Length == 0)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] None of your friends who are playing the game are in the right multiplayer activity state. This should show some kind of message.");
				return Platform.JoinListError.NoJoinAvailable;
			}
			Dictionary<ulong, string> userToConnectionString = new Dictionary<ulong, string>();
			XblMultiplayerActivityInfo[] result = multiplayerActivities.Task.Result;
			foreach (XblMultiplayerActivityInfo xblMultiplayerActivityInfo in result)
			{
				if (xblMultiplayerActivityInfo.CurrentPlayers >= xblMultiplayerActivityInfo.MaxPlayers)
				{
					Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] This multiplayer activity indicates that it doesn't have room to join. {xblMultiplayerActivityInfo.Xuid}");
					continue;
				}
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] This user has room in their activity's group. {xblMultiplayerActivityInfo.Xuid}");
				userToConnectionString.Add(xblMultiplayerActivityInfo.Xuid, xblMultiplayerActivityInfo.ConnectionString);
			}
			string arg2 = string.Join(", ", userToConnectionString.Select((KeyValuePair<ulong, string> x) => $"{x.Key}"));
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] Final list of friend XUIDs that we can join: {arg2}");
			TaskCompletionSource<ulong?> selectedUsersSource = new TaskCompletionSource<ulong?>();
			int num8 = Unity.XGamingRuntime.SDK.XGameUiShowPlayerPickerAsync(gameCoreManager.PrimaryUser.userHandle, "Join Crashout Crew Lobby", userToConnectionString.Keys.ToArray(), Array.Empty<ulong>(), 1u, 1u, delegate(int hResult, ulong[] selectedUsers)
			{
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hResult))
				{
					Debug.LogError($"[GameCorePlatform] [OpenJoinList] Failed to join player from list. HRESULT: 0x{hResult:X}");
					selectedUsersSource.SetResult(null);
				}
				else if (selectedUsers.Length != 1)
				{
					Debug.LogWarning("[GameCorePlatform] [OpenJoinList] Join list succeeded, but there wasn't exactly one selected user.");
					selectedUsersSource.SetResult(null);
				}
				else
				{
					selectedUsersSource.SetResult(selectedUsers[0]);
				}
			});
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num8))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [OpenJoinList] Failed to open player picker. 0x{num8:X8}.");
				return Platform.JoinListError.NotInitialized;
			}
			await selectedUsersSource.Task;
			if (!selectedUsersSource.Task.Result.HasValue)
			{
				return Platform.JoinListError.None;
			}
			if (!userToConnectionString.TryGetValue(selectedUsersSource.Task.Result.Value, out var value))
			{
				return Platform.JoinListError.NotInitialized;
			}
			PlatformGameJoin obj = await JoinActivityFromInviteUri(value, onlyConnectionString: true);
			if (obj.result != PlatformError.Success)
			{
				return Platform.JoinListError.NotInitialized;
			}
			_onJoinGame(obj);
			return Platform.JoinListError.None;
		}

		public string GetAccountId()
		{
			if (_initializationState != InitializationState.Initialized)
			{
				Debug.LogError("[GameCorePlatform] [GetAccountId] Attempted to get account id, but the GameCorePlatform has not successfully initialized.");
			}
			return gameCoreManager.PrimaryUser.userXUID.ToString();
		}

		public ulong GetPlatformId()
		{
			return gameCoreManager.PrimaryUser.userXUID;
		}

		public string GetPlayFabId()
		{
			if (!PlayFabSettings.staticPlayer.IsClientLoggedIn())
			{
				return string.Empty;
			}
			return gameCoreManager.PlayFabConnectionData.ClientEntityKey.Id;
		}

		public async void OpenInviteList()
		{
			int num = Unity.XGamingRuntime.SDK.XBL.XblSocialManagerCreateSocialUserGroupFromFilters(gameCoreManager.PrimaryUser.userHandle, XblPresenceFilter.All, XblRelationshipFilter.Friends, out socialGroupHandle);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [OpenInviteList] Failed to get user social group. 0x{num:X8}.");
				Unity.XGamingRuntime.SDK.XBL.XblSocialManagerDestroySocialUserGroup(socialGroupHandle);
				return;
			}
			bool num2 = await gameCoreManager.YieldUntilSocialManagerEvent(XblSocialManagerEventType.SocialUserGroupLoaded, socialGroupHandle, 5000);
			int num3 = -2147467259;
			if (num2)
			{
				num3 = Unity.XGamingRuntime.SDK.XBL.XblSocialManagerUserGroupGetUsers(socialGroupHandle, out socialUsers);
			}
			int num4 = Unity.XGamingRuntime.SDK.XBL.XblSocialManagerDestroySocialUserGroup(socialGroupHandle);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num4))
			{
				Debug.LogWarning($"[{Time.frameCount}] [GameCorePlatform] [OpenInviteList] Failed to remove social group handle. Ignoring and continuing. - 0x{num4:X8}.");
			}
			if (!num2)
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [OpenInviteList] Timeout occurred before SocialUserGroupLoaded event.");
				return;
			}
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num3))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [OpenInviteList] Failed to get users - 0x{num3:X8}.");
				return;
			}
			if (socialUsers.Length == 0)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [OpenInviteList] This user has no relevant friends that have played the title. This should show some kind of message.");
				return;
			}
			socialUserXUIDs = new ulong[socialUsers.Length];
			for (int i = 0; i < socialUsers.Length; i++)
			{
				socialUserXUIDs[i] = socialUsers[i].XboxUserId;
			}
			TaskCompletionSource<ulong[]> selectedUsersSource = new TaskCompletionSource<ulong[]>();
			int num5 = Unity.XGamingRuntime.SDK.XGameUiShowPlayerPickerAsync(gameCoreManager.PrimaryUser.userHandle, "Invite to Lobby", socialUserXUIDs, Array.Empty<ulong>(), 0u, (uint)socialUserXUIDs.Length, delegate(int hResult, ulong[] selectedUsers)
			{
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hResult))
				{
					Debug.LogError($"[GameCorePlatform] [OpenInviteList] Failed to invite player from list. HRESULT: 0x{hResult:X}");
					selectedUsersSource.SetResult(null);
				}
				else
				{
					selectedUsersSource.SetResult(selectedUsers);
				}
			});
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num5))
			{
				Debug.LogError($"[GameCorePlatform] [OpenInviteList] Failed to show player picker. HRESULT: 0x{num5:X}");
			}
			await selectedUsersSource.Task;
			if (selectedUsersSource.Task.Result == null || selectedUsersSource.Task.Result.Length == 0)
			{
				return;
			}
			Unity.XGamingRuntime.SDK.XBL.XblMultiplayerActivitySendInvitesAsync(gameCoreManager.PrimaryUser.m_context, selectedUsersSource.Task.Result, allowCrossPlatformJoin: true, gameCoreManager.PlayFabLobbyData.CurrentLobbyConnectionString, delegate(int invitationResult)
			{
				if (Unity.XGamingRuntime.Interop.HR.FAILED(invitationResult))
				{
					Debug.LogError($"[GameCorePlatform] [OpenInviteList] Failed to join player from list. HRESULT: 0x{invitationResult:X}");
				}
			});
		}

		public bool ShouldPause()
		{
			return gameCoreManager.IsConstrained;
		}

		public async Task<bool> RefreshGlobalStatsAsync()
		{
			TaskCompletionSource<bool> tipTapCacheCompletionSource = new TaskCompletionSource<bool>();
			try
			{
				PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(), delegate(GetTitleDataResult result)
				{
					_tiptapLikesCache.Clear();
					foreach (KeyValuePair<string, string> datum in result.Data)
					{
						if (long.TryParse(datum.Value, out var result2))
						{
							_tiptapLikesCache.Add(datum.Key, result2);
						}
					}
					tipTapCacheCompletionSource.SetResult(result: true);
				}, delegate(PlayFabError error)
				{
					Debug.LogError("[GameCorePlatform] [RefreshGlobalStatsAsync] Failed to refresh global stats. Error: " + error.ToString());
					tipTapCacheCompletionSource.SetResult(result: false);
				});
			}
			catch (Exception ex)
			{
				Debug.LogError("[GameCorePlatform] [RefreshGlobalStatsAsync] Failed to refresh global stats. Exception: " + ex.Message);
				tipTapCacheCompletionSource.SetResult(result: false);
			}
			return await tipTapCacheCompletionSource.Task;
		}

		private static string BuildEventDimensions(string field, int value)
		{
			return "{}";
		}

		private static string BuildEventDimensions(string field, float value)
		{
			return "{}";
		}

		private static string BuildEventMeasurements(string field, int value)
		{
			return $"{{\"{field}\":{value}}}";
		}

		private static string BuildEventMeasurements(string field, float value)
		{
			return $"{{\"{field}\":{value}}}";
		}

		private void SetStatXbl(string id, int stat)
		{
			if (_initializationState == InitializationState.Initialized)
			{
				string text = BuildEventMeasurements("Count", stat);
				Debug.Log("[Xbox] Event: " + id + " | Dimensions: {} | Measurements: " + text);
				int num = Unity.XGamingRuntime.SDK.XBL.XblEventsWriteInGameEvent(gameCoreManager.PrimaryUser.m_context, id, "{}", text);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
				{
					Debug.LogError($"[GameCorePlatform] [SetStat] Failed to set stat {id} to {stat} on Server. HRESULT: 0x{num:X}");
				}
				else if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
				{
					Debug.Log($"[GameCorePlatform] [SetStat] Successfully set stat {id} to {stat}");
				}
				else
				{
					Debug.Log($"[GameCorePlatform] [SetStat] Unknown HRESULT: 0x{num:X}");
				}
			}
		}

		private void SetStatXbl(string id, float stat)
		{
			if (_initializationState == InitializationState.Initialized)
			{
				int num = Unity.XGamingRuntime.SDK.XBL.XblEventsWriteInGameEvent(gameCoreManager.PrimaryUser.m_context, id, "{}", BuildEventMeasurements("Count", stat));
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
				{
					Debug.LogError($"[GameCorePlatform] [SetStat] Failed to set stat {id} to {stat}. HRESULT: 0x{num:X}");
				}
				else if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
				{
					_driftingDistanceCache = stat;
					Debug.Log($"[GameCorePlatform] [SetStat] Successfully set stat {id} to {stat}");
				}
				else
				{
					Debug.Log($"[GameCorePlatform] [SetStat] Unknown HRESULT: 0x{num:X}");
				}
			}
		}

		public void SetStat(string id, int stat)
		{
			if (_initializationState == InitializationState.Initialized)
			{
				_localStatCache[id] = stat;
				if (XboxAchievementRegistry.Achievements.TryGetValue(id, out var value) && !UpdateAchievementProgress(value, stat))
				{
					Debug.Log("[GameCorePlatform] [SetStat] [UpdatePlayFabStat] Did not update achievement " + id);
				}
			}
		}

		public void SetStat(string id, float stat)
		{
			if (_initializationState != InitializationState.Initialized)
			{
				return;
			}
			bool num = id == "stat_drift_distance";
			bool flag = id == "stat_tiptap_minutes";
			int num2;
			if (num)
			{
				_driftingDistanceCache = stat;
				num2 = Mathf.RoundToInt(stat);
			}
			else if (flag)
			{
				_tiptapTimeCache = stat;
				num2 = Mathf.RoundToInt(_tiptapTimeCache * 60f);
			}
			else
			{
				num2 = Mathf.RoundToInt(stat);
			}
			_localStatCache[id] = num2;
			if (num)
			{
				if (Time.time - _lastDriftingUpdateTime < 1.5f)
				{
					return;
				}
				_lastDriftingUpdateTime = Time.time;
			}
			if (XboxAchievementRegistry.Achievements.TryGetValue(id, out var value) && !UpdateAchievementProgress(value, num2))
			{
				Debug.Log("[GameCorePlatform] [SetStat] [UpdatePlayFabStat] Did not update achievement " + id);
			}
		}

		private void UpdateAllPlayFabStats()
		{
			if (!PlayFabClientAPI.IsClientLoggedIn())
			{
				Debug.LogWarning("[GameCorePlatform] [Flush] Tried to update stats before login completed!");
				return;
			}
			List<StatisticUpdate> list = new List<StatisticUpdate>();
			foreach (KeyValuePair<string, int> item in _localStatCache)
			{
				list.Add(new StatisticUpdate
				{
					StatisticName = item.Key,
					Value = item.Value
				});
			}
			PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
			{
				Statistics = list
			}, delegate
			{
				Debug.Log("[GameCorePlatform] [SetStat] [UpdatePlayFabStat] Successfully set stat to local cache");
			}, delegate(PlayFabError error)
			{
				Debug.LogError($"[GameCorePlatform] [SetStat] [UpdatePlayFabStat] Failed Update PlayFab Stat Server. Error code: {error.Error} | HTTP: {error.HttpCode} | Message: {error.ErrorMessage}");
			});
		}

		private void UpdatePlayFabStat(string id, int stat)
		{
			if (!PlayFabClientAPI.IsClientLoggedIn())
			{
				Debug.LogWarning("[GameCorePlatform] [SetStat] Tried to update stat " + id + " before login completed!");
				return;
			}
			PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
			{
				Statistics = new List<StatisticUpdate>
				{
					new StatisticUpdate
					{
						StatisticName = id,
						Value = stat
					}
				}
			}, delegate
			{
				Debug.Log($"[GameCorePlatform] [SetStat] [UpdatePlayFabStat] Successfully set stat {id} to {stat}");
			}, delegate(PlayFabError error)
			{
				Debug.LogError($"[GameCorePlatform] [SetStat] [UpdatePlayFabStat] Failed to set stat {id} to {stat} on Server. Error code: {error.Error} | HTTP: {error.HttpCode} | Message: {error.ErrorMessage}");
			});
		}

		public void FlushStatsAndAchievements()
		{
			if (_initializationState != InitializationState.Initialized)
			{
				return;
			}
			UpdateAllPlayFabStats();
			foreach (KeyValuePair<string, int> item in _localStatCache)
			{
				if (item.Value.Equals(0) || !XboxAchievementRegistry.Achievements.TryGetValue(item.Key, out var value) || !(item.Key == "stat_drift_distance"))
				{
					continue;
				}
				if (!UpdateAchievementProgress(value, _driftingDistanceCache))
				{
					Debug.Log("[GameCorePlatform] [SetStat] [UpdatePlayFabStat] Did not update achievement " + item.Key);
				}
				else if (item.Key == "stat_tiptap_minutes")
				{
					if (!UpdateAchievementProgress(value, _tiptapTimeCache))
					{
						Debug.Log("[GameCorePlatform] [SetStat] [UpdatePlayFabStat] Did not update achievement " + item.Key);
					}
					else if (!UpdateAchievementProgress(value, item.Value))
					{
						Debug.Log("[GameCorePlatform] Did not update achievement " + item.Key);
					}
				}
			}
		}

		public bool TryGetStat(string id, out int stat)
		{
			return _localStatCache.TryGetValue(id, out stat);
		}

		public bool TryGetStat(string id, out float stat)
		{
			if (id == "stat_drift_distance")
			{
				stat = _driftingDistanceCache;
				return true;
			}
			if (id == "stat_tiptap_minutes")
			{
				stat = _tiptapTimeCache / 60f;
				return true;
			}
			stat = 0f;
			return false;
		}

		private async Task GrabAndCacheStatAsync(string id)
		{
			var (flag, num) = await TryGetStatAsync<float>(id, float.TryParse);
			if (flag)
			{
				if (id.Equals("stat_drift_distance"))
				{
					_driftingDistanceCache = num;
				}
				else if (id.Equals("stat_tiptap_minutes"))
				{
					_tiptapTimeCache = num / 60f;
				}
				else
				{
					_localStatCache[id] = (int)num;
				}
			}
		}

		private void GrabAndCacheStats()
		{
			if (!PlayFabClientAPI.IsClientLoggedIn())
			{
				return;
			}
			PlayFabClientAPI.GetPlayerStatistics(new GetPlayerStatisticsRequest(), delegate(GetPlayerStatisticsResult result)
			{
				foreach (StatisticValue statistic in result.Statistics)
				{
					Debug.Log($"{statistic.StatisticName}: {statistic.Value}");
					_localStatCache[statistic.StatisticName] = statistic.Value;
				}
				_driftingDistanceCache = _localStatCache["stat_drift_distance"];
				_tiptapTimeCache = (float)_localStatCache["stat_tiptap_minutes"] / 60f;
			}, delegate(PlayFabError error)
			{
				Debug.LogError(error.ErrorMessage);
			});
		}

		private async Task<(bool, T value)> TryGetStatAsync<T>(string id, TryParseDelegate<T> tryParse) where T : struct
		{
			if (_initializationState != InitializationState.Initialized)
			{
				return (false, value: default(T));
			}
			TaskCompletionSource<Tuple<int, Unity.XGamingRuntime.XblUserStatisticsResult>> getStatResultSource = new TaskCompletionSource<Tuple<int, Unity.XGamingRuntime.XblUserStatisticsResult>>();
			Unity.XGamingRuntime.SDK.XBL.XblUserStatisticsGetSingleUserStatisticAsync(gameCoreManager.PrimaryUser.m_context, gameCoreManager.PrimaryUser.userXUID, "00000000-0000-0000-0000-00006afd5dc2", id, delegate(int hResult, Unity.XGamingRuntime.XblUserStatisticsResult userStatisticsResult)
			{
				getStatResultSource.SetResult(Tuple.Create(hResult, userStatisticsResult));
			});
			while (!getStatResultSource.Task.IsCompleted)
			{
				await Task.Yield();
			}
			if (Unity.XGamingRuntime.Interop.HR.FAILED(getStatResultSource.Task.Result.Item1))
			{
				Debug.Log($"[GameCorePlatform] [TryGetStatAsync] Failed to get stat. HRESULT: 0x{getStatResultSource.Task.Result.Item1:X}");
				return (false, value: default(T));
			}
			Unity.XGamingRuntime.XblUserStatisticsResult item = getStatResultSource.Task.Result.Item2;
			if (item.ServiceConfigStatistics != null && item.ServiceConfigStatistics.Length != 0)
			{
				if (item.ServiceConfigStatistics[0].Statistics == null || item.ServiceConfigStatistics[0].Statistics.Length == 0)
				{
					Debug.Log("[GameCorePlatform] [TryGetStatAsync] No statistics found for stat " + id);
					return (false, value: default(T));
				}
				string value = item.ServiceConfigStatistics[0].Statistics[0].Value;
				Debug.Log("[GameCorePlatform] [TryGetStatAsync] Stat value: " + value);
				if (tryParse(value, out var result))
				{
					Debug.Log($"[GameCorePlatform] [TryGetStatAsync] Successfully got stat {id}: {result}");
					return (true, value: result);
				}
			}
			return (false, value: default(T));
		}

		public bool TryGetGlobalStat(string id, out long stat)
		{
			return _tiptapLikesCache.TryGetValue(id, out stat);
		}

		public bool TryGetGlobalStat(string id, out double stat)
		{
			stat = 777.0;
			return false;
		}

		public void UnlockAchievement(string id)
		{
			if (!XboxAchievementRegistry.Achievements.TryGetValue(id, out var value))
			{
				Debug.LogError("[GameCorePlatform] [UnlockAchievement] Failed to unlock achievement " + id + ". Achievement not found.");
			}
			else
			{
				UpdateAchievementProgress(value, value.Threshold);
			}
		}

		private bool UpdateAchievementProgress(XboxAchievementRegistry.XboxAchievement achievement, float stat)
		{
			if (stat < 0f || achievement.IsUnlocked)
			{
				return false;
			}
			uint percentage = (uint)Mathf.FloorToInt(Mathf.Clamp(stat / (float)achievement.Threshold * 100f, 0f, 100f));
			if (percentage == 0)
			{
				return false;
			}
			if (percentage < 100 && achievement.Progress != 0 && percentage - achievement.Progress >= 5)
			{
				return false;
			}
			Unity.XGamingRuntime.SDK.XBL.XblAchievementsUpdateAchievementAsync(gameCoreManager.PrimaryUser.m_context, gameCoreManager.PrimaryUser.userXUID, achievement.XblId, percentage, delegate(int hr)
			{
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
				{
					switch (hr)
					{
					case -2145844844:
						Debug.Log("Achievement " + achievement.XblId + " not found. Progress is not updated");
						break;
					case -2145844944:
						Debug.Log("Achievement " + achievement.XblId + " already met. Progress is not updated");
						if (percentage >= 100)
						{
							achievement.IsUnlocked = true;
						}
						break;
					default:
						Debug.Log($"Failed to update achievement {achievement.XblId} for user {gameCoreManager.PrimaryUser.userXUID}. HRESULT: {Unity.XGamingRuntime.HR.NameOf(hr)}, 0x{hr:X}");
						break;
					}
				}
				else
				{
					Debug.Log($"Successfully updated achievement {achievement.XblId} for user {gameCoreManager.PrimaryUser.userXUID} to {percentage}% completion.");
					achievement.Progress = percentage;
					if (percentage >= 100)
					{
						achievement.IsUnlocked = true;
					}
				}
			});
			return true;
		}

		public void ResetStatsAndAchievements()
		{
			PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
			{
				Statistics = new List<StatisticUpdate>
				{
					new StatisticUpdate
					{
						StatisticName = "stat_drift_distance",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_shipped_animals",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_banana_slips",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_bonus_shipped",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_boost_count",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_shipped_boxes",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_clowns_released",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_crashout_count",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_shipped_explosives",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_fires_extinguished",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_messes_cleaned",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_junk_destroyed",
						Value = 0
					},
					new StatisticUpdate
					{
						StatisticName = "stat_trash_money",
						Value = 0
					}
				}
			}, delegate
			{
				Debug.Log("[GameCorePlatform] [ResetStatsAndAchievements] Successfully reset stats");
			}, null);
			foreach (KeyValuePair<string, XboxAchievementRegistry.XboxAchievement> achievement in XboxAchievementRegistry.Achievements)
			{
				Unity.XGamingRuntime.SDK.XBL.XblAchievementsUpdateAchievementAsync(gameCoreManager.PrimaryUser.m_context, gameCoreManager.PrimaryUser.userXUID, achievement.Value.XblId, 0u, delegate
				{
				});
			}
			_localStatCache.Clear();
			_driftingDistanceCache = 0f;
			_tiptapTimeCache = 0f;
			Debug.LogWarning("[GameCorePlatform] [ResetStatsAndAchievements] Stats and Achievements have been reset. Reboot the game to see changes to gain the ability to unlock previous stat-based achievements");
		}

		private int OnAddUser(int hresult, XUserHandle userHandle)
		{
			if (Unity.XGamingRuntime.Interop.HR.FAILED(hresult))
			{
				Debug.Log($"[GameCorePlatform] [OnAddUser] Error adding a user. HRESULT: 0x{hresult:X}");
				return hresult;
			}
			Debug.Log("[GameCorePlatform] [OnAddUser] UserHandle GameCoreManager");
			gameCoreManager.PrimaryUser.userHandle = userHandle;
			hresult = Unity.XGamingRuntime.SDK.XUserGetLocalId(userHandle, out var userLocalId);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(hresult))
			{
				Debug.Log($"[GameCorePlatform] [OnAddUser] Error getting the XUserLocalID. HRESULT: 0x{hresult:X}");
				return hresult;
			}
			Debug.Log("[GameCorePlatform] [OnAddUser] LocalUserID GameCore Manager");
			gameCoreManager.PrimaryUser.m_localId = userLocalId;
			hresult = Unity.XGamingRuntime.SDK.XUserGetId(userHandle, out var userId);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(hresult))
			{
				Debug.Log($"[GameCorePlatform] [OnAddUser] Error getting the Xuid. HRESULT: 0x{hresult:X}");
				return hresult;
			}
			Debug.Log("[GameCorePlatform] [OnAddUser] Xuid GameCore Manager");
			gameCoreManager.PrimaryUser.userXUID = userId;
			hresult = Unity.XGamingRuntime.SDK.XUserGetGamertag(userHandle, XUserGamertagComponent.Classic, out var gamertag);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(hresult))
			{
				Debug.Log($"[GameCorePlatform] [OnAddUser] Error getting the Gamertag. HRESULT: 0x{hresult:X}");
				return hresult;
			}
			Debug.Log("[GameCorePlatform] [OnAddUser] Gamertag GameCore Manager");
			gameCoreManager.PrimaryUser.userGamertag = gamertag;
			hresult = Unity.XGamingRuntime.SDK.XUserGetIsGuest(userHandle, out var isGuest);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(hresult))
			{
				Debug.Log($"[GameCorePlatform] [OnAddUser] Error checking if the user is a guest. HRESULT: 0x{hresult:X}");
				return hresult;
			}
			Debug.Log("[GameCorePlatform] [OnAddUser] Guest GameCore Manager");
			gameCoreManager.PrimaryUser.userIsGuest = isGuest;
			hresult = Unity.XGamingRuntime.SDK.XBL.XblContextCreateHandle(userHandle, out var context);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(hresult))
			{
				Debug.Log($"[GameCorePlatform] [OnAddUser] Error getting the XblContextHandle. HRESULT: 0x{hresult:X}");
				return hresult;
			}
			Debug.Log("[GameCorePlatform] [OnAddUser] XblContextHandle GameCore Manager");
			gameCoreManager.PrimaryUser.m_context = context;
			Debug.Log($"[GameCorePlatform] [OnAddUser] Finished. XUserLocalID: {userLocalId.Value}. Xuid: {userId}");
			return 0;
		}

		private void OnSaveGameInitialized(int hresult, XGameSaveProviderHandle gameSaveProviderHandle)
		{
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hresult) || hresult == -2138898428)
			{
				gameCoreManager.m_GameSaveProviderHandle = gameSaveProviderHandle;
			}
			initializationSemaphore.Release();
		}

		private int InitializeGamingRuntime()
		{
			int num = Unity.XGamingRuntime.SDK.XGameRuntimeInitialize();
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.Log($"[GameCorePlatform] [InitializeGamingRuntime] FAILED: Initialize XGameRuntime, HResult: 0x{num:X} ({Unity.XGamingRuntime.HR.NameOf(num)})");
				return num;
			}
			num = Unity.XGamingRuntime.SDK.CreateDefaultTaskQueue();
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.LogError($"[GameCorePlatform] [InitializeGamingRuntime] FAILED: XTaskQueueCreate, HResult: 0x{num:X}");
				return num;
			}
			Unity.XGamingRuntime.SDK.XGameInviteRegisterForEvent(HandleReceiveInviteUriAsync, out var _);
			return 0;
		}

		private static bool InitializeXboxLive()
		{
			Debug.Log("[GameCorePlatform] [InitializeXboxLive] Initializing Xbox Live API (SCID: 00000000-0000-0000-0000-00006afd5dc2).");
			int num = Unity.XGamingRuntime.SDK.XBL.XblInitialize("00000000-0000-0000-0000-00006afd5dc2");
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num) && num != -1994173945)
			{
				Debug.Log($"[GameCorePlatform] [InitializeXboxLive] FAILED: Initialize Xbox Live, HResult: 0x{num:X}, {Unity.XGamingRuntime.HR.NameOf(num)}");
				return false;
			}
			return true;
		}

		public async Task<byte[]> LoadSaveAsync(string filepath)
		{
			TaskCompletionSource<XGameSaveBlob[]> saveBlob = new TaskCompletionSource<XGameSaveBlob[]>();
			int num = Unity.XGamingRuntime.SDK.XGameSaveReadBlobDataAsync(gameCoreManager.m_GameSaveContainerHandle, new string[1] { "saveslotblob" }, delegate(int hresult, XGameSaveBlob[] blobs)
			{
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hresult))
				{
					Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [LoadSaveAsync] Failed to load save. HResult: 0x{hresult:x}");
					saveBlob.SetCanceled();
				}
				else
				{
					saveBlob.SetResult(blobs);
				}
			});
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [LoadSaveAsync] Failed when trying to start save loading. HResult: 0x{num:x}");
				return null;
			}
			while (!saveBlob.Task.IsCompleted)
			{
				await Task.Yield();
			}
			if (!saveBlob.Task.IsCompletedSuccessfully)
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [LoadSaveAsync] Failed to load save.");
				return null;
			}
			XGameSaveBlob[] result = saveBlob.Task.Result;
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [LoadSaveAsync] Blobs loaded. Expecting one. Count: {result.Length}");
			if (result.Length == 0)
			{
				Debug.LogWarning($"[{Time.frameCount}] [GameCorePlatform] [LoadSaveAsync] Loaded blobs, but the list was empty. Must not have any saves.");
				return null;
			}
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [LoadSaveAsync] Taking first blob. Size of loaded blob: {result[0].Data.Length}");
			return result[0].Data;
		}

		public async Task SaveAsync(string filepath, byte[] bytes)
		{
			int num = Unity.XGamingRuntime.SDK.XGameSaveCreateContainer(gameCoreManager.m_GameSaveProviderHandle, "saveslotcontainer", out gameCoreManager.m_GameSaveContainerHandle);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [SaveAsync] Failed to create save container. HResult: 0x{num:x}");
				return;
			}
			num = StartContainerUpdate("saveslotcontainer");
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [SaveAsync] Failed to start container update. HResult: 0x{num:x}");
				return;
			}
			num = Unity.XGamingRuntime.SDK.XGameSaveSubmitBlobWrite(gameCoreManager.m_GameSaveContainerUpdateHandle, "saveslotblob", bytes);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [SaveAsync] Failed to write to save blob. HResult: 0x{num:x}");
				return;
			}
			TaskCompletionSource<bool> saveHresult = new TaskCompletionSource<bool>();
			Unity.XGamingRuntime.SDK.XGameSaveSubmitUpdateAsync(gameCoreManager.m_GameSaveContainerUpdateHandle, delegate(int hresult)
			{
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hresult))
				{
					Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [SaveAsync] Failed to process save update. HResult: 0x{hresult:x}");
					saveHresult.SetResult(result: false);
				}
				else
				{
					saveHresult.SetResult(result: true);
				}
			});
			await saveHresult.Task;
			if (saveHresult.Task.Result)
			{
				Unity.XGamingRuntime.SDK.XGameSaveCloseUpdate(gameCoreManager.m_GameSaveContainerUpdateHandle);
				Unity.XGamingRuntime.SDK.XGameSaveCloseContainer(gameCoreManager.m_GameSaveContainerHandle);
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [SaveAsync] Save completed successfully");
			}
		}

		public async Task DeleteSaveAsync(string filepath)
		{
			SemaphoreSlim deleteSemaphore = new SemaphoreSlim(0, 1);
			Unity.XGamingRuntime.SDK.XGameSaveDeleteContainerAsync(gameCoreManager.m_GameSaveProviderHandle, "saveslotcontainer", delegate
			{
				deleteSemaphore.Release();
			});
			await deleteSemaphore.WaitAsync();
		}

		public bool DoesSaveExist(string filepath)
		{
			int num = Unity.XGamingRuntime.SDK.XGameSaveCreateContainer(gameCoreManager.m_GameSaveProviderHandle, "saveslotcontainer", out gameCoreManager.m_GameSaveContainerHandle);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [DoesSaveExist] Failed to create save game container. This is likely a real problem! HResult: 0x{num:x}");
				return false;
			}
			num = Unity.XGamingRuntime.SDK.XGameSaveEnumerateBlobInfoByName(gameCoreManager.m_GameSaveContainerHandle, "saveslotblob", out var blobInfos);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [DoesSaveExist] Attempt to get save file failed; it might exist, but we failed to retrieve it. HResult: 0x{num:x}");
				return false;
			}
			if (blobInfos.Length == 0)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [DoesSaveExist] Retrieved save file blob, but there were no blobs inside it. No existing save file.");
				return false;
			}
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [SaveAsync] Yes, a save exists.");
			return true;
		}

		public int StartContainerUpdate(string containerDisplayName)
		{
			int num = Unity.XGamingRuntime.SDK.XGameSaveCreateUpdate(gameCoreManager.m_GameSaveContainerHandle, containerDisplayName, out gameCoreManager.m_GameSaveContainerUpdateHandle);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.LogError($"[GameCorePlatform] [StartContainerUpdate] Error when creating the {containerDisplayName} update process. HResult: 0x{num:x}");
				return num;
			}
			Debug.Log("[GameCorePlatform] [StartContainerUpdate] Container " + containerDisplayName + " update process created.");
			return num;
		}

		private async void HandleReceiveInviteUriAsync(IntPtr context, string inviteUri)
		{
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [HandleReceiveInviteUriAsync] Received an invite uri of {inviteUri}.");
			queuedJoinGameInviteUri = inviteUri;
			if (_initializationState == InitializationState.Initialized)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [HandleReceiveInviteUriAsync] Because the Platform is initialized, we will immediately act on this invitation.");
				Action<PlatformGameJoin> onJoinGame = _onJoinGame;
				onJoinGame(await AcceptPendingInvite());
			}
			else
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [HandleReceiveInviteUriAsync] Because the Platform is not yet initialized, we will allow HasPendingInvite to handle invitation.");
			}
		}

		private async Task<PlatformGameJoin> JoinActivityFromInviteUri(string inviteUri, bool onlyConnectionString = false)
		{
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Received an invite with uri '{inviteUri}'.");
			if (_initializationState == InitializationState.Errored)
			{
				Debug.Log($"[{Time.frameCount}]  [GameCorePlatform] [JoinActivityFromInviteUri] Initialization has failed. Cannot act on invite.");
				return new PlatformGameJoin(PlatformError.UnknownError);
			}
			if (_initializationState == InitializationState.NotInitialized)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Xbox is not yet initialized. Yielding until initialization complete.");
				while (_initializationState == InitializationState.NotInitialized)
				{
					if (_initializationState == InitializationState.Errored)
					{
						Debug.Log($"[{Time.frameCount}]  [GameCorePlatform] [JoinActivityFromInviteUri] Initialization has failed. Cannot act on invite.");
						return new PlatformGameJoin(PlatformError.UnknownError);
					}
					await Task.Delay(32);
				}
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Xbox completed initialization successfully, continuing to process invite.");
			}
			if (!(await CheckPrivilegeAsync(XUserPrivilege.Multiplayer)))
			{
				return new PlatformGameJoin(PlatformError.UnknownError);
			}
			if (!(await TryLoginToPlayFab()))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Could not log in to PlayFab, cannot make lobby.");
				return new PlatformGameJoin(PlatformError.UnknownError);
			}
			await _LeaveLobbyAsync();
			GameCoreManager gameCoreManager = GameCoreManager.GetOrCreateManager();
			PlayFabMultiplayerManager multiplayerManager = PlayFabMultiplayerManager.Get();
			_ = string.Empty;
			string value;
			if (onlyConnectionString)
			{
				Match match = Regex.Match(inviteUri, "(cv.+)");
				if (!match.Success || match.Groups.Count != 2 || match.Groups[0].Captures.Count != 1)
				{
					Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Couldn't parse a connection string from the invite");
					return new PlatformGameJoin(PlatformError.UnknownError);
				}
				value = match.Groups[1].Captures[0].Value;
			}
			else
			{
				Match match2 = Regex.Match(inviteUri, "connectionString=([^&]*)(?:&|$)");
				if (!match2.Success || match2.Groups.Count != 2 || match2.Groups[0].Captures.Count != 1)
				{
					Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Couldn't parse a connection string from the activity");
					return new PlatformGameJoin(PlatformError.UnknownError);
				}
				value = match2.Groups[1].Captures[0].Value;
			}
			value = Uri.UnescapeDataString(value);
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Connection string after Uri unescaping is {value}");
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUrl] Determined connection string to be {value}");
			TaskCompletionSource<string> joinLobbyResultSource = new TaskCompletionSource<string>();
			PlatformError errorOnJoining = PlatformError.UnknownError;
			PlayFabMultiplayerAPI.JoinLobby(new JoinLobbyRequest
			{
				ConnectionString = value,
				MemberEntity = gameCoreManager.PlayFabConnectionData.MultiplayerEntityKey,
				MemberData = new Dictionary<string, string> { 
				{
					"xuid",
					gameCoreManager.PrimaryUser.userXUID.ToString()
				} }
			}, delegate(JoinLobbyResult joinResult)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Received positive join result.");
				joinLobbyResultSource.SetResult(joinResult.LobbyId);
			}, delegate(PlayFabError errorCallback)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Failed to join lobby. {errorCallback.Error} {errorCallback.ErrorMessage}");
				if (errorCallback.Error == PlayFabErrorCode.LobbyPlayerAlreadyJoined)
				{
					Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Already a member of the target lobby. Waiting for OnLobbyJoinCompleted callback.");
				}
				else if (errorCallback.Error == PlayFabErrorCode.LobbyNotJoinable && errorCallback.ErrorMessage.Contains("The lobby is full"))
				{
					errorOnJoining = PlatformError.LobbyFull;
					joinLobbyResultSource.SetResult(null);
				}
				else
				{
					errorOnJoining = PlatformError.UnknownError;
					joinLobbyResultSource.SetResult(null);
				}
			});
			await joinLobbyResultSource.Task;
			if (joinLobbyResultSource.Task.Result == null)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Failed to join lobby. {errorOnJoining}");
				return new PlatformGameJoin(errorOnJoining);
			}
			TaskCompletionSource<GetLobbyResult> getLobbyResult = new TaskCompletionSource<GetLobbyResult>();
			PlayFabMultiplayerAPI.GetLobby(new GetLobbyRequest
			{
				LobbyId = joinLobbyResultSource.Task.Result
			}, delegate(GetLobbyResult result2)
			{
				getLobbyResult.SetResult(result2);
			}, delegate(PlayFabError error)
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Failed to get already joined lobby. {error.ErrorMessage}");
				getLobbyResult.SetResult(null);
			});
			await getLobbyResult.Task;
			if (getLobbyResult.Task.Result == null)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Failed to get own lobby.");
				return new PlatformGameJoin(PlatformError.UnknownError);
			}
			PlayFab.MultiplayerModels.Lobby lobby = getLobbyResult.Task.Result.Lobby;
			if (lobby.LobbyData == null)
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Somehow, the LobbyData is null. Can't get network id.");
				return new PlatformGameJoin(PlatformError.UnknownError);
			}
			UpdateRecentPlayersFromLobbyData(lobby);
			if (!lobby.LobbyData.TryGetValue("networkid", out var networkId))
			{
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Joined party, but there wasn't a network id in its properties.");
				return new PlatformGameJoin(PlatformError.UnknownError);
			}
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Successfully joined a PlayFab party with network id '{networkId}'. Next is joining a network.");
			TaskCompletionSource<string> pfNetworkJoiningResult = new TaskCompletionSource<string>();
			multiplayerManager.OnNetworkJoined += AfterJoin;
			multiplayerManager.JoinNetwork(networkId);
			await pfNetworkJoiningResult.Task;
			multiplayerManager.OnNetworkJoined -= AfterJoin;
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [JoinActivityFromInviteUri] Sucessfully joined the PlayFab network");
			gameCoreManager.PlayFabLobbyData.UpdateFromLobby(lobby);
			foreach (Member member in lobby.Members)
			{
				if (member.MemberEntity.Id == lobby.Owner.Id)
				{
					if (member.MemberData.TryGetValue("xuid", out var value2) && ulong.TryParse(value2, out var result) && result != gameCoreManager.PrimaryUser.userXUID)
					{
						_hostXuid[0] = result;
					}
					break;
				}
			}
			MirrorHostMultiplayerActivityToClient();
			return new PlatformGameJoin(PlatformError.Success, networkId);
			void AfterJoin(object sender, string result2)
			{
				pfNetworkJoiningResult.SetResult(result2);
			}
		}

		private async void MirrorHostMultiplayerActivityToClient()
		{
			while (_hostXuid[0] != 0L)
			{
				TaskCompletionSource<XblMultiplayerActivityInfo> activityInfoSource = new TaskCompletionSource<XblMultiplayerActivityInfo>();
				Unity.XGamingRuntime.SDK.XBL.XblMultiplayerActivityGetActivityAsync(gameCoreManager.PrimaryUser.m_context, _hostXuid, delegate(int hresult, XblMultiplayerActivityInfo[] results)
				{
					if (Unity.XGamingRuntime.Interop.HR.FAILED(hresult))
					{
						Debug.LogError($"[GameCorePlatform] [MirrorHostMultiplayerActivityToClient] Failed to get activity info for host. HRESULT: 0x{hresult:X}");
					}
					else if (results.Length != 0)
					{
						if (results[0].Xuid == _hostXuid[0])
						{
							activityInfoSource.SetResult(results[0]);
							return;
						}
						Debug.LogError("[GameCorePlatform] [MirrorHostMultiplayerActivityToClient] Failed to get activity info for host. Xuid incorrect.");
					}
					activityInfoSource.SetResult(null);
				});
				await activityInfoSource.Task;
				gameCoreManager.PlayFabLobbyData.UpdateFromMultiplayerActivity(activityInfoSource.Task.Result);
				if (_hostXuid[0] == 0L)
				{
					break;
				}
				int nextUpdateSeconds = 30;
				TaskCompletionSource<int> setActivitySource = new TaskCompletionSource<int>();
				if (activityInfoSource.Task.Result == null)
				{
					Unity.XGamingRuntime.SDK.XBL.XblMultiplayerActivityDeleteActivityAsync(gameCoreManager.PrimaryUser.m_context, delegate(int hr)
					{
						if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
						{
							Debug.LogError($"[GameCorePlatform] [MirrorHostMultiplayerActivityToClient] Failed to delete activity. HRESULT: 0x{hr:X}");
						}
						setActivitySource.SetResult(hr);
					});
				}
				else
				{
					Unity.XGamingRuntime.SDK.XBL.XblMultiplayerActivitySetActivityAsync(gameCoreManager.PrimaryUser.m_context, activityInfoSource.Task.Result, activityInfoSource.Task.Result.CurrentPlayers < activityInfoSource.Task.Result.MaxPlayers, delegate(int hr)
					{
						if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
						{
							Debug.LogError($"[GameCorePlatform] [MirrorHostMultiplayerActivityToClient] Failed to mirror host activity. HRESULT: 0x{hr:X}");
						}
						setActivitySource.SetResult(hr);
					});
					nextUpdateSeconds = 5;
				}
				await setActivitySource.Task;
				_mirrorHostForceUpdate = new TaskCompletionSource<bool>();
				await Task.WhenAny(_mirrorHostForceUpdate.Task, Task.Delay(nextUpdateSeconds * 1000));
				_mirrorHostForceUpdate = null;
			}
			TaskCompletionSource<int> activitySource = new TaskCompletionSource<int>();
			Unity.XGamingRuntime.SDK.XBL.XblMultiplayerActivityDeleteActivityAsync(gameCoreManager.PrimaryUser.m_context, delegate(int hr)
			{
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
				{
					Debug.LogError($"[GameCorePlatform] [MirrorHostMultiplayerActivityToClient] Failed to delete activity. HRESULT: 0x{hr:X}");
				}
				activitySource.SetResult(hr);
			});
			await activitySource.Task;
		}

		public bool HasPendingInvite()
		{
			return !string.IsNullOrWhiteSpace(queuedJoinGameInviteUri);
		}

		public bool HasPlatformInvite()
		{
			return true;
		}

		public async Task<PlatformGameJoin> AcceptPendingInvite()
		{
			string inviteUri = queuedJoinGameInviteUri;
			queuedJoinGameInviteUri = null;
			return await JoinActivityFromInviteUri(inviteUri);
		}

		private async Task<bool> RefreshCurrentRoomMultiplayerActivityInfoAsync(PlayFab.MultiplayerModels.Lobby lobby, bool openToMoreJoiners, bool waitForMPA = false)
		{
			return await RefreshCurrentRoomMultiplayerActivityInfoAsync(lobby.LobbyId, lobby.ConnectionString, (uint)lobby.Members.Count, lobby.MaxPlayers, openToMoreJoiners, waitForMPA);
		}

		private async Task<bool> RefreshCurrentRoomMultiplayerActivityInfoAsync(string lobbyId, string connectionString, uint memberCount, uint maxPlayerCount, bool openToMoreJoiners, bool waitForMPA = false)
		{
			await updateMPASemaphore.WaitAsync();
			GameCoreManager gameCoreManager = GameCoreManager.GetOrCreateManager();
			openToMoreJoiners = gameCoreManager.PlayFabLobbyData.LobbyJoinable && openToMoreJoiners && memberCount < maxPlayerCount;
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [RefreshCurrentRoomMultiplayerActivityInfo] {lobbyId}, {connectionString}, current player count {memberCount}, max player count {maxPlayerCount}, {openToMoreJoiners}");
			gameCoreManager.PlayFabLobbyData.CurrentLobbyId = lobbyId;
			gameCoreManager.PlayFabLobbyData.CurrentLobbyConnectionString = connectionString;
			gameCoreManager.PlayFabLobbyData.CurrentMemberCount = memberCount;
			gameCoreManager.PlayFabLobbyData.MaxMemberCount = maxPlayerCount;
			if (!openToMoreJoiners)
			{
				TaskCompletionSource<int> destroyActivitySource = new TaskCompletionSource<int>();
				Unity.XGamingRuntime.SDK.XBL.XblMultiplayerActivityDeleteActivityAsync(gameCoreManager.PrimaryUser.m_context, delegate(int hr)
				{
					if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
					{
						Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [RefreshCurrentRoomMultiplayerActivityInfoAsync] Failed to delete activity. HRESULT: 0x{hr:X}");
					}
					destroyActivitySource.SetResult(hr);
				});
				if (waitForMPA)
				{
					await destroyActivitySource.Task;
				}
			}
			else
			{
				XblMultiplayerActivityInfo activityInfo = new XblMultiplayerActivityInfo
				{
					ConnectionString = connectionString,
					CurrentPlayers = memberCount,
					GroupId = lobbyId,
					JoinRestriction = XblMultiplayerActivityJoinRestriction.Public,
					MaxPlayers = maxPlayerCount
				};
				TaskCompletionSource<int> setActivitySource = new TaskCompletionSource<int>();
				Unity.XGamingRuntime.SDK.XBL.XblMultiplayerActivitySetActivityAsync(gameCoreManager.PrimaryUser.m_context, activityInfo, openToMoreJoiners, delegate(int hr)
				{
					if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
					{
						Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [RefreshCurrentRoomMultiplayerActivityInfo] Failed to set activity. HRESULT: 0x{hr:X}");
					}
					setActivitySource.SetResult(hr);
				});
				if (waitForMPA)
				{
					await setActivitySource.Task;
				}
			}
			if (gameCoreManager.PlayFabConnectionData != null && gameCoreManager.PlayFabLobbyData.IsHost)
			{
				TaskCompletionSource<bool> lobbyUpdateCompletion = new TaskCompletionSource<bool>();
				Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [RefreshCurrentRoomMultiplayerActivityInfoAsync] Updating lobby. Should more players be able to join? {openToMoreJoiners}");
				PlayFabMultiplayerAPI.UpdateLobby(new UpdateLobbyRequest
				{
					LobbyId = gameCoreManager.PlayFabLobbyData.CurrentLobbyId,
					MembershipLock = ((!openToMoreJoiners) ? MembershipLock.Locked : MembershipLock.Unlocked),
					AccessPolicy = ((!openToMoreJoiners) ? AccessPolicy.Private : AccessPolicy.Public)
				}, delegate
				{
					Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [RefreshCurrentRoomMultiplayerActivityInfoAsync] Finished updating lobby.");
					lobbyUpdateCompletion.SetResult(result: true);
				}, delegate(PlayFabError error)
				{
					Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [RefreshCurrentRoomMultiplayerActivityInfoAsync] Failed to create lobby. Error: {error.ToString()}");
					lobbyUpdateCompletion.SetResult(result: false);
				});
				await lobbyUpdateCompletion.Task;
			}
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [RefreshCurrentRoomMultiplayerActivityInfoAsync] Completed setting activity info. Open? {openToMoreJoiners}");
			updateMPASemaphore.Release();
			return true;
		}

		public async Task<bool> TryLoginToPlayFab()
		{
			if (Unity.XGamingRuntime.Interop.HR.FAILED(Unity.XGamingRuntime.SDK.XTaskQueueCreate(XTaskQueueDispatchMode.Manual, XTaskQueueDispatchMode.Manual, out playFabLoginTaskHandle)))
			{
				Debug.LogError("[GameCorePlatform] [TryLoginToPlayFab] Failed to create a task queue for getting the user's signature");
				return false;
			}
			TaskCompletionSource<XUserGetTokenAndSignatureData> tokenResultSource = new TaskCompletionSource<XUserGetTokenAndSignatureData>();
			string failureMessage = "";
			playFabTokenCompletionRoutine = delegate
			{
				try
				{
					int hr2 = Unity.XGamingRuntime.SDK.XUserGetTokenAndSignatureResultSize(playFabAsyncBlockForLogin, out playFabSignatureResponseSize);
					if (Unity.XGamingRuntime.Interop.HR.FAILED(hr2))
					{
						failureMessage = "[GameCorePlatform] [TryLoginToPlayFab] Failed to create body buffer for user token fetch  Error: " + hr2;
						tokenResultSource.SetCanceled();
					}
					else
					{
						byte[] buffer = new byte[playFabSignatureResponseSize];
						if (Unity.XGamingRuntime.Interop.HR.FAILED(Unity.XGamingRuntime.SDK.XUserGetTokenAndSignatureResult(playFabAsyncBlockForLogin, buffer, out playFabResponseHandle)))
						{
							failureMessage = "[GameCorePlatform] [TryLoginToPlayFab] Failed to create body content for user token fetch  Error: " + hr2;
							tokenResultSource.SetCanceled();
						}
						else
						{
							tokenResultSource.SetResult(playFabResponseHandle);
						}
					}
				}
				catch (Exception ex)
				{
					failureMessage = ex.ToString();
					tokenResultSource.SetCanceled();
				}
			};
			playFabAsyncBlockForLogin = AsyncHelpers.WrapAsyncBlock(playFabLoginTaskHandle, playFabTokenCompletionRoutine);
			int hr = Unity.XGamingRuntime.SDK.XUserGetTokenAndSignatureAsync(gameCoreManager.PrimaryUser.userHandle, XUserGetTokenAndSignatureOptions.None, "POST", "https://playfabapi.com", null, null, playFabAsyncBlockForLogin);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
			{
				Debug.LogError("[GameCorePlatform] [TryLoginToPlayFab] Failed to make HTTPS request to playfabapi.com to get user token  Error: " + hr);
				playFabAsyncBlockForLogin.Dispose();
				return false;
			}
			Debug.Log("[GameCorePlatform] [TryLoginToPlayFab] Waiting for token response");
			while (!tokenResultSource.Task.IsCompleted)
			{
				Unity.XGamingRuntime.SDK.XTaskQueueDispatch(playFabLoginTaskHandle, XTaskQueuePort.Work, 32u);
				Unity.XGamingRuntime.SDK.XTaskQueueDispatch(playFabLoginTaskHandle, XTaskQueuePort.Completion, 0u);
				await Task.Yield();
			}
			Debug.Log("[GameCorePlatform] [TryLoginToPlayFab] Response received");
			playFabAsyncBlockForLogin.Dispose();
			if (!tokenResultSource.Task.IsCompletedSuccessfully)
			{
				Debug.LogError("[GameCorePlatform] [TryLoginToPlayFab] Asynchronous error caught while trying to parse result. Result: " + failureMessage);
				return false;
			}
			playFabAsyncBlockForLogin.Dispose();
			Debug.Log($"[{Time.frameCount}] [GameCorePlatform] [TryLoginToPlayFab] Token result is {playFabResponseHandle.Token}");
			gameCoreManager.PlayFabConnectionData.PlayFabToken = playFabResponseHandle.Token;
			Unity.XGamingRuntime.SDK.XTaskQueueCloseHandle(playFabLoginTaskHandle);
			TaskCompletionSource<bool> waitForXboxLoginCompletionSource = new TaskCompletionSource<bool>();
			PlayFabClientAPI.LoginWithXbox(new LoginWithXboxRequest
			{
				CreateAccount = true,
				XboxToken = gameCoreManager.PlayFabConnectionData.PlayFabToken
			}, delegate(LoginResult loginResult)
			{
				Debug.Log("[GameCorePlatform] [TryLoginToPlayFab] Successful PlayFab login");
				gameCoreManager.PlayFabConnectionData.ClientEntityKey = loginResult.EntityToken.Entity;
				gameCoreManager.PlayFabConnectionData.MultiplayerEntityKey = new PlayFab.MultiplayerModels.EntityKey
				{
					Id = loginResult.EntityToken.Entity.Id,
					Type = loginResult.EntityToken.Entity.Type
				};
				GrabAndCacheStats();
				waitForXboxLoginCompletionSource.SetResult(result: true);
			}, delegate(PlayFabError error)
			{
				Debug.LogError("[GameCorePlatform] [TryLoginToPlayFab] Failed to login. Error: " + error.ToString());
				waitForXboxLoginCompletionSource.SetResult(result: false);
			});
			bool result = await waitForXboxLoginCompletionSource.Task;
			PlayFabMultiplayerManager.Get().UpdateEntityToken(gameCoreManager.PlayFabConnectionData.PlayFabToken);
			if (shouldResumePlayFab)
			{
				Debug.Log("[GameCorePlatform] [TryLoginToPlayFab] Resuming PlayFab after login");
				PlayFabMultiplayerManager.Get().Resume();
				shouldResumePlayFab = false;
			}
			return result;
		}

		public bool IsOnline()
		{
			return true;
		}

		public void RegisterToPlayFabCallbacks()
		{
			PlayFabMultiplayerManager.Get().OnNetworkJoined += OnPartyNetworkJoin;
		}

		public void UnregisterFromPlayFabCallbacks()
		{
			PlayFabMultiplayerManager.Get().OnNetworkJoined -= OnPartyNetworkJoin;
		}

		private void OnPartyNetworkJoin(object sender, string networkId)
		{
			Debug.Log("[GameCorePlatform] [OnPartyNetworkJoin] Joining networkId " + networkId);
		}

		public async void UpdateActivityFromLobby(bool updateRecentPlayers)
		{
			_ = 1;
			try
			{
				bool isHost = gameCoreManager.PlayFabLobbyData.IsHost;
				if (!isHost && _mirrorHostForceUpdate != null)
				{
					_mirrorHostForceUpdate.SetResult(result: true);
				}
				if (!(updateRecentPlayers || isHost))
				{
					return;
				}
				TaskCompletionSource<GetLobbyResult> getLobbyResult = new TaskCompletionSource<GetLobbyResult>();
				PlayFabMultiplayerAPI.GetLobby(new GetLobbyRequest
				{
					LobbyId = gameCoreManager.PlayFabLobbyData.CurrentLobbyId
				}, delegate(GetLobbyResult result)
				{
					getLobbyResult.SetResult(result);
				}, delegate(PlayFabError error)
				{
					Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [UpdateRecentPlayersFromLobby] Failed to get lobby. {error.ErrorMessage}");
					getLobbyResult.SetResult(null);
				});
				await getLobbyResult.Task;
				if (getLobbyResult.Task.Result != null)
				{
					if (updateRecentPlayers)
					{
						UpdateRecentPlayersFromLobbyData(getLobbyResult.Task.Result.Lobby);
					}
					if (isHost)
					{
						await RefreshCurrentRoomMultiplayerActivityInfoAsync(gameCoreManager.PlayFabLobbyData.CurrentLobbyId, gameCoreManager.PlayFabLobbyData.CurrentLobbyConnectionString, gameCoreManager.PlayFabLobbyData.CurrentMemberCount, gameCoreManager.PlayFabLobbyData.MaxMemberCount, gameCoreManager.PlayFabLobbyData.LobbyJoinable);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogError($"[{Time.frameCount}] [GameCorePlatform] [UpdateRecentPlayersFromLobby] Exception: {ex.ToString()}");
			}
		}

		private void UpdateRecentPlayersFromLobbyData(PlayFab.MultiplayerModels.Lobby lobby)
		{
			List<XblMultiplayerActivityRecentPlayerUpdate> list = new List<XblMultiplayerActivityRecentPlayerUpdate>();
			foreach (Member member in lobby.Members)
			{
				if (member.MemberData.TryGetValue("xuid", out var value) && ulong.TryParse(value, out var result) && result != gameCoreManager.PrimaryUser.userXUID)
				{
					list.Add(new XblMultiplayerActivityRecentPlayerUpdate
					{
						Xuid = result
					});
				}
			}
			if (list.Count > 0)
			{
				Unity.XGamingRuntime.SDK.XBL.XblMultiplayerActivityUpdateRecentPlayers(gameCoreManager.PrimaryUser.m_context, list.ToArray());
			}
		}

		private void OnLobbyCreateAndJoinCompleted(PlayFab.Multiplayer.Lobby joinedLobby, int hResult)
		{
			if (!LobbyError.SUCCEEDED(hResult))
			{
				Debug.Log($"[GameCorePlatform] [OnLobbyCreateAndJoinCompleted] Failed to create and join lobby. Result: {hResult}");
			}
			else
			{
				Debug.Log("[GameCorePlatform] [OnLobbyCreateAndJoinCompleted] Successfully created and joined lobby");
			}
		}
	}
}
