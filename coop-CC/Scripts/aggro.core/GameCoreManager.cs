using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PlayFab.ClientModels;
using PlayFab.Multiplayer;
using PlayFab.MultiplayerModels;
using PlayFab.Party;
using Unity.XGamingRuntime;
using Unity.XGamingRuntime.Interop;
using UnityEngine;

[DisallowMultipleComponent]
public class GameCoreManager : MonoBehaviour
{
	public class UserData
	{
		public XUserHandle userHandle;

		public XUserLocalId m_localId;

		public ulong userXUID;

		public string userGamertag;

		public bool userIsGuest;

		public bool canPlayMultiplayer;

		public ulong[] avoidList;

		public ulong[] muteList;

		public byte[] imageBuffer;

		public Texture2D gamerPicture;

		public Unity.XGamingRuntime.XblContextHandle m_context;
	}

	public class PlayFabData
	{
		public PlayFab.ClientModels.EntityKey ClientEntityKey;

		public PlayFab.MultiplayerModels.EntityKey MultiplayerEntityKey;

		public string PlayFabToken;
	}

	public class PlayFabRememberedLobbyData
	{
		public string CurrentLobbyId { get; set; }

		public string CurrentLobbyConnectionString { get; set; }

		public PlayFab.MultiplayerModels.EntityKey HostKey { get; set; }

		public bool IsHost { get; set; }

		public PlayFabPlayer[] HostList { get; set; } = new PlayFabPlayer[1];

		public bool HostSet { get; set; }

		public bool LobbyJoinable { get; set; } = true;

		public uint CurrentMemberCount { get; set; }

		public uint MaxMemberCount { get; set; }

		public void UpdateFromMultiplayerActivity(XblMultiplayerActivityInfo info)
		{
			CurrentLobbyConnectionString = info.ConnectionString;
			CurrentMemberCount = info.CurrentPlayers;
			MaxMemberCount = info.MaxPlayers;
		}

		public void UpdateFromLobby(PlayFab.MultiplayerModels.Lobby lobby)
		{
			CurrentLobbyId = lobby.LobbyId;
			HostKey = lobby.Owner;
			CurrentMemberCount = (uint)lobby.Members.Count;
			MaxMemberCount = lobby.MaxPlayers;
			CurrentLobbyConnectionString = lobby.ConnectionString;
			HostSet = false;
			IsHost = GetOrCreateManager().PlayFabConnectionData.ClientEntityKey.Id == HostKey.Id;
		}
	}

	public Action OnSuspend;

	public Action<double> OnResume;

	public Action<bool> OnResourceChange;

	public XGameSaveProviderHandle m_GameSaveProviderHandle;

	public XGameSaveContainerHandle m_GameSaveContainerHandle;

	public XGameSaveUpdateHandle m_GameSaveContainerUpdateHandle;

	public XblMultiplayerSessionHandle m_XblMultiplayerSessionHandle;

	private XUserChangeRegistrationToken _userRegistrationToken;

	private XNetworkingRegisterConnectivityHintChangedCallbackToken connectivityHintToken;

	private UserData primaryUser = new UserData();

	private PlayFabData playFabData = new PlayFabData();

	private PlayFabRememberedLobbyData playFabCurrentLobbyData = new PlayFabRememberedLobbyData();

	public const string XAUDIODRIVERREGEX = "\\.\\{([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})\\}";

	protected static GameCoreManager s_Instance { get; set; }

	private Coroutine dispatchCoroutine { get; set; }

	public bool IsConstrained { get; private set; }

	public bool IsSuspended { get; private set; }

	public UserData PrimaryUser => primaryUser;

	public PlayFabData PlayFabConnectionData => playFabData;

	public PlayFabRememberedLobbyData PlayFabLobbyData => playFabCurrentLobbyData;

	public Action<XblSocialManagerUserGroupHandle> OnSocialUserGroupLoaded { get; set; }

	public Action<XblSocialManagerUserGroupHandle> OnLocalUserAdded { get; set; }

	public event Action GamerPictureRetrieved;

	public event Action GamerTagRetrieved;

	public event Action UserSignInStarted;

	public event Action<XUserHandle> UserSignOutStarted;

	public event Action<XUserHandle> UserSignedIn;

	public event Action UserSignedOut;

	public static GameCoreManager GetOrCreateManager()
	{
		if (s_Instance == null)
		{
			Debug.Log(string.Format("[{0}] [GameCoreManager] [GetOrCreateManager] Creating manager; adding {1}, {2}, {3}.", Time.frameCount, "GameCoreManager", "PlayfabMultiplayerEventProcessor", "PlayFabMultiplayerManager"));
			s_Instance = new GameObject("GameCoreManager").AddComponent<GameCoreManager>();
			UnityEngine.Object.DontDestroyOnLoad(s_Instance.gameObject);
			s_Instance.gameObject.AddComponent<PlayFabMultiplayerManager>().LogLevel = PlayFabMultiplayerManager.LogLevelType.Minimal;
			PlayFabMultiplayerManager.Get();
			s_Instance.gameObject.AddComponent<PlayfabMultiplayerEventProcessor>();
			Debug.Log($"[{Time.frameCount}] [GameCoreManager] [GetOrCreateManager] GameCoreManager set up complete.");
		}
		return s_Instance;
	}

	protected virtual void Awake()
	{
		if (s_Instance != null && s_Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		s_Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	protected virtual void OnDisable()
	{
		if (dispatchCoroutine != null)
		{
			Debug.Log($"[{Time.frameCount}] [GameCoreManager] [OnDisable] Ending the Dispatch coroutine loop.");
			StopCoroutine(dispatchCoroutine);
		}
	}

	public void StartDispatch()
	{
		if (dispatchCoroutine != null)
		{
			StopCoroutine(dispatchCoroutine);
		}
		dispatchCoroutine = StartCoroutine(Dispatch());
	}

	private IEnumerator Dispatch()
	{
		while (true)
		{
			XblSocialManagerEvent[] socialEvents;
			int num = SDK.XBL.XblSocialManagerDoWork(out socialEvents);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				Debug.LogError($"[{Time.frameCount}] [GameCoreManager] [Dispatch] Something failed while doing social manager work. 0x{num:X8}.");
			}
			if (socialEvents != null && socialEvents.Length != 0)
			{
				XblSocialManagerEvent[] array = socialEvents;
				foreach (XblSocialManagerEvent xblSocialManagerEvent in array)
				{
					if (Unity.XGamingRuntime.Interop.HR.FAILED(xblSocialManagerEvent.Hr))
					{
						Debug.LogError($"[{Time.frameCount}] [GameCoreManager] [Dispatch] Social event failed; HR 0x{xblSocialManagerEvent.Hr:X8}, type {xblSocialManagerEvent.EventType}");
						continue;
					}
					Debug.Log($"[{Time.frameCount}] [GameCoreManager] [Dispatch] Processing social event: {xblSocialManagerEvent.EventType}");
					switch (xblSocialManagerEvent.EventType)
					{
					case XblSocialManagerEventType.SocialUserGroupLoaded:
						OnSocialUserGroupLoaded?.Invoke(xblSocialManagerEvent.LoadedGroup);
						break;
					case XblSocialManagerEventType.LocalUserAdded:
						OnLocalUserAdded?.Invoke(xblSocialManagerEvent.LoadedGroup);
						break;
					}
				}
			}
			SDK.XTaskQueueDispatch(0u);
			yield return null;
		}
	}

	public async Task<bool> YieldUntilSocialManagerEvent(XblSocialManagerEventType eventType, XblSocialManagerUserGroupHandle groupToWaitFor = null, int timeoutMS = 0)
	{
		Debug.Log($"[{Time.frameCount}] [GameCoreManager] [YieldUntilSocialManagerEvent] Beginning to yield until {eventType} occurs");
		TaskCompletionSource<bool> eventSource = new TaskCompletionSource<bool>();
		switch (eventType)
		{
		case XblSocialManagerEventType.LocalUserAdded:
			OnLocalUserAdded = (Action<XblSocialManagerUserGroupHandle>)Delegate.Combine(OnLocalUserAdded, new Action<XblSocialManagerUserGroupHandle>(endWait));
			break;
		case XblSocialManagerEventType.SocialUserGroupLoaded:
			OnSocialUserGroupLoaded = (Action<XblSocialManagerUserGroupHandle>)Delegate.Combine(OnSocialUserGroupLoaded, new Action<XblSocialManagerUserGroupHandle>(endWait));
			break;
		default:
			Debug.LogError($"[{Time.frameCount}] [GameCoreManager] [YieldUntilSocialManagerEvent] Asked to yield until '{eventType}' happens, but we don't have an implemented action for that.");
			return false;
		}
		bool flag;
		if (timeoutMS > 0)
		{
			flag = await Task.WhenAny(eventSource.Task, Task.Delay(timeoutMS)) == eventSource.Task;
		}
		else
		{
			await eventSource.Task;
			flag = true;
		}
		switch (eventType)
		{
		case XblSocialManagerEventType.LocalUserAdded:
			OnLocalUserAdded = (Action<XblSocialManagerUserGroupHandle>)Delegate.Remove(OnLocalUserAdded, new Action<XblSocialManagerUserGroupHandle>(endWait));
			break;
		case XblSocialManagerEventType.SocialUserGroupLoaded:
			OnSocialUserGroupLoaded = (Action<XblSocialManagerUserGroupHandle>)Delegate.Remove(OnSocialUserGroupLoaded, new Action<XblSocialManagerUserGroupHandle>(endWait));
			break;
		}
		if (flag)
		{
			Debug.Log($"[{Time.frameCount}] [GameCoreManager] [YieldUntilSocialManagerEvent] {eventType} occured, finished yielding");
		}
		else
		{
			Debug.LogError($"[{Time.frameCount}] [GameCoreManager] [YieldUntilSocialManagerEvent] Timeout was reached before {eventType} occured");
		}
		return flag;
		void endWait(XblSocialManagerUserGroupHandle loadedGroup)
		{
			if (groupToWaitFor == null || groupToWaitFor == loadedGroup)
			{
				eventSource.SetResult(result: true);
			}
		}
	}

	public async Task InitializePlayerPrefsAsync()
	{
		await Task.Yield();
	}

	private void OnDestroy()
	{
		if (dispatchCoroutine != null)
		{
			StopCoroutine(dispatchCoroutine);
			dispatchCoroutine = null;
		}
		PlayFabMultiplayerManager.Get().ManagedCleanupStep();
		SDK.CloseDefaultXTaskQueue();
		SDK.XBL.XblCleanup(null);
	}

	public void RetrieveGamerPicture()
	{
		SDK.XUserGetGamerPictureAsync(primaryUser.userHandle, XUserGamerPictureSize.Large, GetGamerPictureCallback);
	}

	private void GetGamerPictureCallback(int hResult, byte[] buffer)
	{
		if (Unity.XGamingRuntime.Interop.HR.FAILED(hResult))
		{
			Debug.LogError($"XUserGetGamerPictureAsync() Failed to grab Image. HResult: 0x{hResult:x}");
			return;
		}
		primaryUser.imageBuffer = buffer;
		primaryUser.gamerPicture = new Texture2D(480, 480);
		primaryUser.gamerPicture.LoadImage(primaryUser.imageBuffer);
		primaryUser.gamerPicture.Apply();
		this.GamerPictureRetrieved?.Invoke();
		Debug.Log($"[GameCoreManager] [GetGamerPictureCallback] Finished. XUserLocalID: {primaryUser.m_localId.Value}. Xuid: {primaryUser.userXUID}");
	}

	private IEnumerator RetrievePermissions()
	{
		TaskCompletionSource<Tuple<int, XblPermissionCheckResult>> permissionResult = new TaskCompletionSource<Tuple<int, XblPermissionCheckResult>>();
		SDK.XBL.XblPrivacyCheckPermissionAsync(primaryUser.m_context, XblPermission.PlayMultiplayer, primaryUser.userXUID, delegate(int XBLHresult, XblPermissionCheckResult result)
		{
			permissionResult.SetResult(new Tuple<int, XblPermissionCheckResult>(XBLHresult, result));
		});
		while (!permissionResult.Task.IsCompleted)
		{
			yield return null;
		}
		int item = permissionResult.Task.Result.Item1;
		primaryUser.canPlayMultiplayer = permissionResult.Task.Result.Item2.IsAllowed;
		if (Unity.XGamingRuntime.Interop.HR.FAILED(item))
		{
			Debug.Log($"[GameCoreManager] [GetPermissions] Error getting the PermissionResult. HRESULT: 0x{item:X}");
		}
	}

	private IEnumerator RetrieveMuteList()
	{
		TaskCompletionSource<Tuple<int, ulong[]>> MuteListResult = new TaskCompletionSource<Tuple<int, ulong[]>>();
		SDK.XBL.XblPrivacyGetMuteListAsync(primaryUser.m_context, delegate(int XBLHresult, ulong[] result)
		{
			MuteListResult.SetResult(new Tuple<int, ulong[]>(XBLHresult, result));
		});
		while (!MuteListResult.Task.IsCompleted)
		{
			yield return null;
		}
		int item = MuteListResult.Task.Result.Item1;
		primaryUser.muteList = MuteListResult.Task.Result.Item2;
		if (Unity.XGamingRuntime.Interop.HR.FAILED(item))
		{
			Debug.Log($"[GameCoreManager] [AddUserComplete] [GetMuteList] Error getting the MuteList. HRESULT: 0x{item:X}");
		}
	}

	private void OnSuspendingEvent()
	{
		PlayFabMultiplayerManager.Get().Suspend();
		IsSuspended = true;
	}

	private void OnResumingEvent(double secondsSuspended)
	{
		int num = SDK.XNetworkingRegisterConnectivityHintChanged(ConnectivityEstablishedResume, out connectivityHintToken);
		if (!Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			Debug.LogError($"[GameCoreManager] [OnResumingEvent] Error registering connectivity hint changing. HRESULT: 0x{num:X}");
		}
		IsSuspended = false;
	}

	private void OnResourceAvailabilityChanged(bool constrained)
	{
		IsConstrained = constrained;
	}

	private void ConnectivityEstablishedResume(IntPtr context, XNetworkingConnectivityHint connectivityHint)
	{
		if (connectivityHint.ConnectivityLevel == XNetworkingConnectivityLevelHint.InternetAccess && connectivityHintToken != null)
		{
			PlayFabMultiplayerManager.Get().Resume();
			SDK.XNetworkingUnregisterConnectivityHintChanged(connectivityHintToken, wait: false);
			connectivityHintToken = null;
		}
	}

	private void ResetUserDetails()
	{
		primaryUser.userGamertag = "";
		this.GamerTagRetrieved?.Invoke();
		primaryUser.gamerPicture = new Texture2D(64, 64);
		primaryUser.gamerPicture.Apply();
		this.GamerPictureRetrieved?.Invoke();
	}

	public void RaiseUserSignInStarted()
	{
		this.UserSignInStarted?.Invoke();
	}

	public void RaiseUserSignedIn(XUserHandle userHandle)
	{
		this.UserSignedIn?.Invoke(userHandle);
	}

	public void SignIn(bool showUI = true)
	{
		ResetUserDetails();
		this.UserSignInStarted?.Invoke();
		SDK.XUserAddAsync((!showUI) ? XUserAddOptions.AddDefaultUserAllowingUI : XUserAddOptions.None, AddUserComplete);
	}

	private void AddUserComplete(int hResult, XUserHandle userHandle)
	{
		if (Unity.XGamingRuntime.Interop.HR.FAILED(hResult))
		{
			Debug.LogWarning(string.Format("{0} failed - 0x{1:X8}.", "XUserAddAsync", hResult));
			return;
		}
		int num = SDK.XUserGetLocalId(userHandle, out var userLocalId);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			Debug.Log($"[GameCoreManager] [AddUserComplete] Error getting the XUserLocalID. HRESULT: 0x{num:X}");
			return;
		}
		Debug.Log("[GameCoreManager] [AddUserComplete] LocalUserID");
		num = SDK.XUserGetId(userHandle, out var userId);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			Debug.Log($"[GameCoreManager] [AddUserComplete] Error getting the Xuid. HRESULT: 0x{num:X}");
			return;
		}
		Debug.Log("[GameCoreManager] [AddUserComplete] Xuid");
		num = SDK.XUserGetGamertag(userHandle, XUserGamertagComponent.Modern, out var gamertag);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			Debug.Log($"[GameCoreManager] [AddUserComplete] Error getting the Gamertag. HRESULT: 0x{num:X}");
			return;
		}
		Debug.Log("[GameCoreManager] [AddUserComplete] Gamertag");
		num = SDK.XUserGetIsGuest(userHandle, out var isGuest);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			Debug.Log($"[GameCoreManager] [AddUserComplete] Error checking if the user is a guest. HRESULT: 0x{num:X}");
			return;
		}
		Debug.Log("[GameCoreManager] [AddUserComplete] Is Guest?");
		num = SDK.XBL.XblContextCreateHandle(userHandle, out var context);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			Debug.Log($"[GameCoreManager] [AddUserComplete] Error getting the XblContextHandle. HRESULT: 0x{num:X}");
			return;
		}
		Debug.Log("[GameCoreManager] [AddUserComplete] XblContextHandle");
		primaryUser.m_localId = userLocalId;
		primaryUser.userXUID = userId;
		primaryUser.userGamertag = gamertag;
		primaryUser.userIsGuest = isGuest;
		primaryUser.m_context = context;
		RetrieveGamerPicture();
		Debug.Log($"[GameCoreManager] [AddUserComplete] Finished. XUserLocalID: {userLocalId.Value}. Xuid: {userId}");
		SDK.XUserRegisterForChangeEvent(UserChangeEventCallback, out _userRegistrationToken);
		this.UserSignedIn?.Invoke(userHandle);
	}

	private void ClearUser()
	{
		Debug.Log("[GameCoreManager] [ClearUser] removing Primary user: " + primaryUser.userGamertag);
		if (_userRegistrationToken != null)
		{
			SDK.XUserUnregisterForChangeEvent(_userRegistrationToken);
			_userRegistrationToken = null;
		}
		if (primaryUser.userHandle != null)
		{
			SDK.XUserCloseHandle(primaryUser.userHandle);
			primaryUser.userHandle = null;
		}
		if (primaryUser.m_context != null)
		{
			SDK.XBL.XblContextCloseHandle(primaryUser.m_context);
			primaryUser.m_context = null;
		}
		primaryUser.userGamertag = "";
		primaryUser.userXUID = 0uL;
		primaryUser.userIsGuest = false;
		primaryUser.imageBuffer = null;
		primaryUser.avoidList = null;
		primaryUser.muteList = null;
		Debug.Log("[GameCoreplatform] [ClearUser] User cleared");
		this.UserSignedOut?.Invoke();
	}

	private void UserChangeEventCallback(IntPtr _, XUserLocalId userLocalId, XUserChangeEvent eventType)
	{
		switch (eventType)
		{
		case XUserChangeEvent.SignedOut:
			Application.Quit();
			break;
		case XUserChangeEvent.SigningOut:
			ClearUser();
			this.UserSignOutStarted?.Invoke(primaryUser.userHandle);
			Debug.Log("[GameCoreManager] [UserChangeEventCallback] User Signing Out");
			break;
		}
	}

	public void ClearConnectionData()
	{
		Debug.Log($"[{Time.frameCount}] [GameCoreManager] [ClearConnectionData] Resetting connection data.");
		playFabCurrentLobbyData = new PlayFabRememberedLobbyData();
	}

	private static Guid? ExtractEndpointGuid(string endpointId)
	{
		if (string.IsNullOrEmpty(endpointId))
		{
			return null;
		}
		Match match = Regex.Match(endpointId, "\\.\\{([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})\\}");
		if (!match.Success)
		{
			return null;
		}
		if (Guid.TryParse(match.Groups[1].Value, out var result))
		{
			return result;
		}
		return null;
	}

	public Guid? GetDefaultUserCaptureAudioEndPoint()
	{
		char[] array = new char[SDK.XUserAudioEndpointMaxUtf16Count];
		ulong endpointIdUtf16Used;
		int num = SDK.XUserGetDefaultAudioEndpointUtf16(primaryUser.m_localId, XUserDefaultAudioEndpointKind.CommunicationCapture, (ulong)array.Length, array, out endpointIdUtf16Used);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			Debug.LogWarning($"(Failed to get default audio endpoint: {num})");
			return null;
		}
		string text = new string(array, 0, (int)endpointIdUtf16Used - 1);
		Debug.Log("[GameCoreManager] [GetRecordDefaultDriverInfo] Default audio endpoint: " + text);
		return ExtractEndpointGuid(text);
	}

	public Guid? GetDefaultUserRenderAudioEndPoint()
	{
		char[] array = new char[SDK.XUserAudioEndpointMaxUtf16Count];
		ulong endpointIdUtf16Used;
		int num = SDK.XUserGetDefaultAudioEndpointUtf16(primaryUser.m_localId, XUserDefaultAudioEndpointKind.CommunicationCapture, (ulong)array.Length, array, out endpointIdUtf16Used);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			Debug.LogWarning($"(Failed to get default audio endpoint: {num})");
			return null;
		}
		string text = new string(array, 0, (int)endpointIdUtf16Used - 1);
		Debug.Log("[GameCoreManager] [GetRecordDefaultDriverInfo] Default audio endpoint: " + text);
		return ExtractEndpointGuid(text);
	}
}
