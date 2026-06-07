using System;
using Cysharp.Threading.Tasks;
using DV.Common;
using DV.Localization;
using DV.UI.PresetEditors;
using DV.UIFramework;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DV.UI
{
	public class MainMenuController : AUIController
	{
		private const string QUIT_CONFIRMATION = "mm/quit_confirm";

		private const string BUILD_VERSION = "build/version";

		[NullCheck]
		public TextMeshProUGUI buildVersionText;

		[NullCheck]
		public RightPaneController rightPaneController;

		[NullCheck]
		public TextMeshProUGUI platformIndicatorText;

		[NullCheck]
		public Popup popup2Buttons;

		[NullCheck]
		public GameObject localizationOverridesWarning;

		public string newsURL = "https://steamcommunity.com/app/588030/announcements/";

		public string communityURL = "https://discord.com/invite/altfuture";

		public string altfutureURL = "https://altfuture.gg";

		public string legalURL = "https://www.altfuture.gg/legal";

		private AMainMenuProvider provider;

		[Header("Left-side buttons")]
		[NullCheck]
		public ButtonDVMarkable sessionsButton;

		[NullCheck]
		public ButtonDVMarkable continueButton;

		[NullCheck]
		public ButtonDVMarkable settingsButton;

		[NullCheck]
		public Button quitButton;

		[NullCheck]
		public Button newsButton;

		[NullCheck]
		public Button badgeButton;

		[NullCheck]
		public Button communityButton;

		[NullCheck]
		public Button altfutureButton;

		[NullCheck]
		public Button changelogButton;

		[NullCheck]
		public Button legalButton;

		[NullCheck]
		public Button bugReportButton;

		private PopupManager _popupManager;

		private PopupManager PopupManager => this.FindPopupManager(ref _popupManager);

		public event Action QuitRequested;

		public event Action<UIStartGameData> StartNewGameRequested;

		public event Action<ISaveGame> ContinueGameRequested;

		private void Start()
		{
			if ((bool)EventSystem.current && EventSystem.current.sendNavigationEvents)
			{
				Debug.LogError("EventSystem.sendNavigationEvents is on, it should be disabled.");
			}
		}

		public void SetProvider(AMainMenuProvider provider)
		{
			if (this.provider != null)
			{
				Util.RunOnce(this, "SetProvider");
				return;
			}
			this.provider = provider;
			rightPaneController.SetProviders(provider, provider.SettingsProvider, provider.UserProfileProvider, provider.ScenarioProvider, provider.BugReportDataProvider);
			provider.PlatformIndicatorInitialized += delegate(string value)
			{
				platformIndicatorText.text = value;
			};
			provider.UserProfileProvider.UserProfileChanged += OnUserProfileChanged;
			provider.UserProfileProvider.SessionChanged += RefreshInterface;
			RefreshInterface();
		}

		private void OnUserProfileChanged()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		private void RefreshInterface()
		{
			if (provider?.UserProfileProvider?.GetCurrentProfile() == null)
			{
				sessionsButton.gameObject.SetActive(value: false);
				continueButton.gameObject.SetActive(value: false);
				settingsButton.gameObject.SetActive(value: false);
				quitButton.gameObject.SetActive(value: true);
			}
			else if ((bool)provider)
			{
				sessionsButton.gameObject.SetActive(value: true);
				continueButton.gameObject.SetActive(provider.UserProfileProvider.HasLastPlayedSessionForAnyGameMode);
				settingsButton.gameObject.SetActive(value: true);
				quitButton.gameObject.SetActive(value: true);
			}
			if ((bool)provider)
			{
				buildVersionText.text = LocalizationAPI.L("build/version", provider.BuildVersionString);
			}
			bugReportButton.gameObject.SetActive((bool)provider && provider.BugReportDataProvider.IsReportingSupported());
			localizationOverridesWarning.SetActive((bool)provider && provider.HasLocalizationOverridesLoaded);
		}

		protected override void Awake()
		{
			base.Awake();
			RefreshInterface();
		}

		private void OnEnable()
		{
			SetupListeners(on: true);
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				quitButton.onClick.AddListener(OnQuitClicked);
				rightPaneController.StartNewGameRequested += OnStartNewGameRequested;
				rightPaneController.ContinueGameRequested += OnContinueGameRequested;
				newsButton.onClick.AddListener(OnNewsClicked);
				badgeButton.onClick.AddListener(OnNewsClicked);
				communityButton.onClick.AddListener(OnCommunityClicked);
				altfutureButton.onClick.AddListener(OnAltfutureClicked);
				changelogButton.onClick.AddListener(OnChangelogClicked);
				legalButton.onClick.AddListener(OnLegalClicked);
			}
			else
			{
				quitButton.onClick.RemoveListener(OnQuitClicked);
				rightPaneController.StartNewGameRequested -= OnStartNewGameRequested;
				rightPaneController.ContinueGameRequested -= OnContinueGameRequested;
				newsButton.onClick.RemoveListener(OnNewsClicked);
				badgeButton.onClick.RemoveListener(OnNewsClicked);
				communityButton.onClick.RemoveListener(OnCommunityClicked);
				altfutureButton.onClick.RemoveListener(OnAltfutureClicked);
				changelogButton.onClick.RemoveListener(OnChangelogClicked);
				legalButton.onClick.RemoveListener(OnLegalClicked);
			}
		}

		private void OnStartNewGameRequested(UIStartGameData data)
		{
			this.StartNewGameRequested?.Invoke(data);
		}

		private void OnContinueGameRequested(ISaveGame saveGame)
		{
			this.ContinueGameRequested?.Invoke(saveGame);
		}

		private void OnNewsClicked()
		{
			Util.OpenURL(newsURL);
		}

		private void OnCommunityClicked()
		{
			Util.OpenURL(communityURL);
		}

		private void OnAltfutureClicked()
		{
			Util.OpenURL(altfutureURL);
		}

		private void OnLegalClicked()
		{
			Util.OpenURL(legalURL);
		}

		private void OnChangelogClicked()
		{
			provider.OpenChangelog();
		}

		private void OnQuitClicked()
		{
			PopupLocalizationKeys keys = new PopupLocalizationKeys
			{
				positiveKey = "yes",
				negativeKey = "no",
				labelKey = "mm/quit_confirm"
			};
			UIMenuController.WaitForSwitchPreventer(base.gameObject).ContinueWith(() => UniTask.Delay(50)).ContinueWith(() => PopupManager.ShowPopupAsync(popup2Buttons, out var _, keys))
				.ContinueWith(delegate(PopupResult result)
				{
					if (result.closedBy == PopupClosedByAction.Positive)
					{
						this.QuitRequested?.Invoke();
					}
				})
				.Forget();
		}
	}
}
