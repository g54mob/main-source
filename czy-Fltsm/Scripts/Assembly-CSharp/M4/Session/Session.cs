using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Events;

namespace M4.Session
{
	public class Session : MonoBehaviour, IUserEventHandler, IPlatformPausable, ILocalizationParamsManager
	{
		public static readonly DateTime RELEASE_DATE = new DateTime(2025, 12, 4, 16, 0, 0, DateTimeKind.Utc);

		private IPlatform platform;

		private DateTime startTime;

		private DateTime endTime;

		private float duration;

		private bool hasRequestedPlayerProfile;

		private bool isReady;

		private IRun currentRun;

		private UnityAction<IUser> playerRequestCallback;

		private IUser user;

		private PlayerProfile playerProfile;

		private UnityAction<PlayerProfile> playerProfileRequestCallback;

		private bool hasNotStarted = true;

		private bool hasSignedInUserUI;

		private bool mainMenuOnDialogClose;

		internal static SessionState state;

		private static Session s_Instance;

		public bool ItBlocksPlatformUnpause { get; private set; }

		public bool ItBlocksUnpause => false;

		public static Guid Id { get; private set; }

		public static bool IsReady => s_Instance.isReady;

		public static IPlatform Platform => s_Instance.platform;

		public static PlayerProfile Profile => s_Instance.playerProfile;

		public static List<PlayerRun> Runs => s_Instance.playerProfile.Runs;

		private void Awake()
		{
			if (s_Instance == null)
			{
				s_Instance = this;
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
				Id = Guid.NewGuid();
				startTime = DateTime.Now;
				duration = 0f;
				state = SessionState.Uninitialized;
				isReady = false;
				ItBlocksPlatformUnpause = false;
			}
			else
			{
				Debug.LogError("A Session instance as already instantiated!");
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void Start()
		{
			InitializePlatform();
			i_OnStart();
		}

		private void InitializePlatform()
		{
			if (platform == null)
			{
				switch (Application.platform)
				{
				case RuntimePlatform.XboxOne:
					platform = new PlatformXboxOne();
					break;
				case RuntimePlatform.Switch:
					platform = new PlatformSwitch();
					break;
				case RuntimePlatform.OSXEditor:
				case RuntimePlatform.OSXPlayer:
				case RuntimePlatform.WindowsPlayer:
				case RuntimePlatform.WindowsEditor:
				case RuntimePlatform.LinuxPlayer:
				case RuntimePlatform.LinuxEditor:
					platform = new PlatformSteam();
					break;
				default:
					throw new NotImplementedException();
				}
				if (!platform.ItIsInitialized)
				{
					platform.Initialize();
				}
			}
		}

		private void Update()
		{
			duration += Time.unscaledDeltaTime;
			if (!isReady)
			{
				if (!platform.ItIsInitialized || (platform.ItHasDefaultUser && playerProfile == null))
				{
					return;
				}
				if (Settings.IsInitialized)
				{
					LocalizationManager.ParamManagers.Add(this);
					state = SessionState.Open;
					isReady = true;
				}
			}
			platform.OnUpdate();
			if (currentRun != null)
			{
				currentRun.Update();
			}
			if (Settings.IsWaitingForApply)
			{
				Settings.Apply();
			}
		}

		private void OnApplicationQuit()
		{
			platform.OnQuit();
		}

		public string GetParameterValue(string parameter)
		{
			if (parameter.Equals("USER"))
			{
				if (user != null)
				{
					return user.Name;
				}
				return "null";
			}
			return null;
		}

		private void i_OnStart()
		{
			if (hasNotStarted)
			{
				platform.OnStart();
				if (platform.ItHasDefaultUser)
				{
					i_RequestPlayerProfile(null);
				}
				hasNotStarted = false;
			}
		}

		private void i_RequestPlayerProfile(UnityAction<PlayerProfile> callback)
		{
			if (user == null || playerProfile == null || hasSignedInUserUI)
			{
				playerProfileRequestCallback = callback;
				platform.RequestUser(OnRequestUserResult);
			}
			else
			{
				callback?.Invoke(playerProfile);
			}
		}

		private void OnRequestUserResult(UserRequestResult result, IUser result_user)
		{
			switch (result)
			{
			case UserRequestResult.STARTED:
				if (state != SessionState.Uninitialized)
				{
					OpenPlayerLoadingPage(UserStrings.SIGN_IN_WAIT_TERM, 0f);
				}
				break;
			case UserRequestResult.SUCCES:
				if (result_user == null)
				{
					throw new NotSupportedException();
				}
				user = result_user;
				user.Initialize(this);
				break;
			case UserRequestResult.FAILED_CANCEL:
			case UserRequestResult.FAILED_ERROR:
				ClosePlayerPage();
				playerProfileRequestCallback(null);
				break;
			default:
				throw new NotSupportedException();
			}
		}

		private void i_BeginRun(IRun run)
		{
			if (currentRun == null)
			{
				if (playerProfile == null)
				{
					throw new NotSupportedException("At this point the Session should have been provisioned with a player profile.");
				}
				currentRun = run;
				return;
			}
			throw new NotSupportedException("Cannot start a new run while a current run is still active");
		}

		private void i_EndRun(IRun run)
		{
			if (currentRun != null)
			{
				if (currentRun != run)
				{
					throw new NotSupportedException();
				}
				currentRun = null;
			}
		}

		public void OnUserEvent(IUser user, UserEventType evt)
		{
			switch (state)
			{
			case SessionState.Uninitialized:
				Uninitialized_OnUserEvent(user, evt);
				break;
			case SessionState.Open:
				Open_OnUserEvent(user, evt);
				break;
			case SessionState.Locked:
				Locked_OnUserEvent(user, evt);
				break;
			}
		}

		private void Uninitialized_OnUserEvent(IUser user, UserEventType evt)
		{
			if (evt == UserEventType.INITIALIZATION_COMPLETE)
			{
				playerProfile = new PlayerProfile(user);
				playerProfile.Load(OnPlayerProfileLoaded);
			}
		}

		private void Open_OnUserEvent(IUser user, UserEventType evt)
		{
			switch (evt)
			{
			case UserEventType.SIGN_OUT_STARTED:
				if (hasSignedInUserUI)
				{
					OpenPlayerLoadingPage(UserStrings.SIGN_OUT_WAIT_TERM, 2f);
				}
				break;
			case UserEventType.SIGN_OUT:
				DisposeUser();
				UpdateSignedInUserUI();
				break;
			case UserEventType.INITIALIZATION_STARTED:
				OpenPlayerLoadingPage(UserStrings.STORAGE_WAIT_TERM, 2f);
				break;
			case UserEventType.INITIALIZATION_COMPLETE:
				playerProfile = new PlayerProfile(user);
				playerProfile.Load(OnPlayerProfileLoaded);
				break;
			case UserEventType.SIGN_OUT_COMPLETE:
				break;
			}
		}

		private void Locked_OnUserEvent(IUser user, UserEventType evt)
		{
			switch (evt)
			{
			case UserEventType.SIGN_IN_REQUEST:
				OpenPlayerLoadingPage(UserStrings.SIGN_IN_WAIT_TERM, 0f);
				break;
			case UserEventType.SIGN_IN_CANCEL:
				OpenPlayerOptionPage(UserStrings.SIGN_IN_CANCEL_TERM, user.RequestSignIn, DisposeUser);
				break;
			case UserEventType.SIGN_IN_ERROR:
				OpenPlayerOptionPage(UserStrings.SIGN_IN_ERROR_TERM, user.RequestSignIn, DisposeUser);
				break;
			case UserEventType.SIGN_IN_CHANGE:
				OpenPlayerOptionPage(UserStrings.CHANGE_TERM, this.user.RequestSignIn, delegate
				{
					ChangeUser(user);
				});
				break;
			case UserEventType.SIGN_IN_COMPLETE:
				this.user = user;
				this.user.Initialize(this);
				break;
			case UserEventType.SIGN_OUT_STARTED:
				OpenPlayerLoadingPage(UserStrings.SIGN_OUT_WAIT_TERM, 2f);
				break;
			case UserEventType.SIGN_OUT:
				OpenPlayerOptionPage(UserStrings.SIGN_OUT_TERM, user.RequestSignIn, DisposeUser);
				break;
			case UserEventType.INITIALIZATION_STARTED:
				OpenPlayerLoadingPage(UserStrings.STORAGE_WAIT_TERM, 2f);
				break;
			case UserEventType.INITIALIZATION_COMPLETE:
				if (playerProfile == null)
				{
					Debug.LogError("The sessions is locked, but somehow the playerProfile has not been properly setup!");
					playerProfile = new PlayerProfile(user);
				}
				else if (playerProfile.UserId != user.Id)
				{
					Debug.LogError("The session is locked, but somehow a new user was initialized!");
					playerProfile.EndRun();
					playerProfile = new PlayerProfile(user);
				}
				playerProfile.Load(OnPlayerProfileLoaded);
				break;
			case UserEventType.SIGN_OUT_COMPLETE:
				break;
			}
		}

		private void OnPlayerProfileLoaded()
		{
			if (Settings.IsInitialized)
			{
				OnSettingsLoaded();
			}
			else
			{
				Settings.Load(user, OnSettingsLoaded);
			}
		}

		private void OnSettingsLoaded()
		{
			if (playerProfileRequestCallback != null)
			{
				playerProfileRequestCallback(playerProfile);
				playerProfileRequestCallback = null;
			}
			GameEventDispatcher.Dispatch(GameEventType.SessionInitialized);
			ClosePlayerPage();
		}

		private void ChangeUser(IUser to_user)
		{
			if (playerProfile != null)
			{
				playerProfile.EndRun();
				playerProfile = null;
			}
			user.Dispose();
			user = platform.ChangeUser(to_user);
			mainMenuOnDialogClose = state == SessionState.Locked;
			user.Initialize(this);
		}

		private void DisposeUser()
		{
			if (playerProfile != null)
			{
				playerProfile.EndRun();
				playerProfile = null;
			}
			user.Dispose();
			user = null;
			mainMenuOnDialogClose = state == SessionState.Locked;
			ClosePlayerPage();
		}

		private void OpenPlayerOptionPage(LocalizedString message_term, UnityAction action_callback, UnityAction continue_callback)
		{
			throw new NotImplementedException();
		}

		private void OpenPlayerLoadingPage(LocalizedString message_term, float minimum_duration)
		{
			throw new NotImplementedException();
		}

		private void ClosePlayerPage()
		{
		}

		private void i_EnableSignedInUserUI()
		{
			throw new NotImplementedException();
		}

		private void i_DisableSignedInUserUI()
		{
			throw new NotImplementedException();
		}

		private void UpdateSignedInUserUI()
		{
			throw new NotImplementedException();
		}

		public static void SetState(SessionState state)
		{
			if (Session.state != state)
			{
				if (state == SessionState.Locked)
				{
					DisableSignedInUserUI();
				}
				Session.state = state;
			}
		}

		public static void OnStart()
		{
			s_Instance.i_OnStart();
		}

		public static void EnableSignedInUserUI()
		{
			state = SessionState.Open;
			s_Instance.i_EnableSignedInUserUI();
		}

		public static void DisableSignedInUserUI()
		{
			s_Instance.i_DisableSignedInUserUI();
		}

		public static void RequestPlayerProfile(UnityAction<PlayerProfile> callback)
		{
			s_Instance.i_RequestPlayerProfile(callback);
		}

		public static void BeginRun(IRun run)
		{
			s_Instance.i_BeginRun(run);
		}

		public static void EndRun(IRun run)
		{
			s_Instance.i_EndRun(run);
		}

		public static void SaveSettings(object settings)
		{
			s_Instance.platform.SaveSettings(settings);
		}

		public static void SaveFile(string path, byte[] data, UnityAction<StorageActionResult> result_callback)
		{
			s_Instance.playerProfile.SaveFile(path, data, result_callback);
		}

		public static bool TryLoadSave(out SaveInfo saveInfo, UnityAction<StorageActionResult> result_callback)
		{
			saveInfo = null;
			if (s_Instance != null)
			{
				return s_Instance.playerProfile.TryLoadSave(out saveInfo, result_callback);
			}
			return false;
		}

		public static void DEBUG_OpenPlayerOptionPage(LocalizedString message, UnityAction action_callback, UnityAction continue_callback)
		{
			throw new NotImplementedException();
		}

		public static void DEBUG_OpenPlayerLoadingPage(LocalizedString message, float minimum_duration)
		{
			throw new NotImplementedException();
		}

		public static void DEBUG_ClosePlayerPage()
		{
			s_Instance.ClosePlayerPage();
		}

		public static bool TryGetMostRecentlySavedRun(out PlayerRun playerRun)
		{
			playerRun = null;
			if (s_Instance != null && s_Instance.playerProfile != null)
			{
				return s_Instance.playerProfile.TryGetMostRecentlySavedRun(out playerRun);
			}
			return false;
		}
	}
}
