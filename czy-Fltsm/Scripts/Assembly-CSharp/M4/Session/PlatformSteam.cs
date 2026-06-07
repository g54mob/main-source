using System;
using System.IO;
using I2.Loc;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace M4.Session
{
	public class PlatformSteam : IPlatform
	{
		public const ulong GAME_ID = 821250uL;

		public static readonly AppId_t APP_ID = new AppId_t(821250u);

		public static string SETTINGS_PATH = Path.GetFullPath(Application.persistentDataPath + Path.DirectorySeparatorChar + "PlayerSettings.json");

		private SteamManager steamManager;

		private IUser user;

		private Callback<GameOverlayActivated_t> _gameOverlayActivatedCallback;

		private Callback<GamepadTextInputDismissed_t> _gamePadTextInputDismissedCallback;

		private UnityAction<GamepadTextInputDismissed_t> _gamePadTextInputDismissedCallbackHandler;

		public bool ItIsInitialized { get; private set; }

		public bool ItHasDefaultUser => true;

		public bool ItHandlesTextInput { get; private set; }

		public LocalizedString InitializationFailedMessage { get; private set; } = new LocalizedString("PLATFORM_STEAM_INITIALIZATION_FAILED");

		public void Initialize()
		{
			LoadSettings();
			if (SteamManager.SetPlatform(this))
			{
				InitializeCallbacks();
				ItHandlesTextInput = SteamUtils.IsSteamInBigPictureMode() || SteamUtils.IsSteamRunningOnSteamDeck();
				ItIsInitialized = true;
			}
			else
			{
				PopUpDialog.Instance.TryOpenDialog(DialogProperties.ID.PlatformInitializationFailed, InitializationFailedMessage);
				PopUpDialog.Instance.DialogFeedbackEvent.AddListener(OnInitializationFailedDialogFeedback);
			}
		}

		public void InitializeCallbacks()
		{
			_gameOverlayActivatedCallback = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
			_gamePadTextInputDismissedCallback = Callback<GamepadTextInputDismissed_t>.Create(OnGamePadTextInputDismissed);
		}

		public void OnStart()
		{
		}

		public void OnUpdate()
		{
		}

		public void OnQuit()
		{
		}

		public void RequestUser(UnityAction<UserRequestResult, IUser> callback)
		{
			if (user == null)
			{
				user = new SteamUser();
			}
			callback(UserRequestResult.SUCCES, user);
		}

		public IUser ChangeUser(IUser user)
		{
			throw new NotImplementedException("TODO");
		}

		public void ToggleSignedInUserUI(bool enabled)
		{
		}

		public void SaveSettings(object settings)
		{
			File.WriteAllBytes(SETTINGS_PATH, Settings.ENCODING.GetBytes(JsonUtility.ToJson(settings)));
		}

		private void LoadSettings()
		{
			if (Settings.IsInitialized)
			{
				return;
			}
			if (File.Exists(SETTINGS_PATH))
			{
				try
				{
					Settings.SetInstance(JsonUtility.FromJson<Settings>(Settings.ENCODING.GetString(File.ReadAllBytes(SETTINGS_PATH))));
					return;
				}
				catch (Exception ex)
				{
					Debug.LogWarning("Settings could no be loaded: " + ex.Message);
				}
			}
			Settings.CreateInstance();
		}

		private void OnGameOverlayActivated(GameOverlayActivated_t callback)
		{
		}

		public void RegisterGamePadTextInputDismissedHandler(UnityAction<GamepadTextInputDismissed_t> handler)
		{
			_gamePadTextInputDismissedCallbackHandler = handler;
		}

		private void OnGamePadTextInputDismissed(GamepadTextInputDismissed_t callback)
		{
			if (_gamePadTextInputDismissedCallbackHandler != null)
			{
				_gamePadTextInputDismissedCallbackHandler(callback);
			}
		}

		private void OnInitializationFailedDialogFeedback(bool succes)
		{
			Application.Quit();
		}
	}
}
