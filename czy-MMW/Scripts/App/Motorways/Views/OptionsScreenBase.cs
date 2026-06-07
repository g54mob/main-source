using System;
using System.Collections;
using System.Collections.Generic;
using Analytics;
using Factory;
using Motorways.Audio;
using Motorways.UI;
using NaughtyAttributes;
using NotificationService.Events;
using Notifications;
using Notifications.Services;
using Popups;
using Screens;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using UnityEngine.UI;
using com.dinopoloclub.analytics;

namespace Motorways.Views
{
	public class OptionsScreenBase : BaseScalingScreen
	{
		public MapDefinition tutorialDefinition;

		private AssetBundleUtility.AsyncLoadResult _tutorialCityDefinition;

		public SymbolOptionButton onlineIndicator;

		public SymbolOptionButton signedInToiCloudIndicator;

		public SymbolOptionButton syncedWithiCloudIndicator;

		public LocalizedTextUI iCloudStatusMessage;

		public SymbolOptionButton fullscreenToggle;

		public SymbolOptionButton nightModeToggle;

		public SymbolOptionButton colorblindModeToggle;

		public SymbolOptionButton skipTransitionsToggle;

		public TouchOptionButton antiAliasingLevelOptions;

		public SymbolOptionButton vibrationsToggle;

		public SymbolOptionButton drawModeToggleToggle;

		public SymbolOptionButton telemetryToggle;

		public SymbolOptionButton analyticsToggle;

		[FormerlySerializedAs("tapDrawToggle")]
		public SymbolOptionButton holdToDrawToggle;

		public TouchOptionButton volumeOptions;

		public TouchOptionButton soundscapeOptions;

		public TouchOptionButton controllerSensitivityOptions;

		public SymbolOptionButton zoomToggle;

		private TouchButton zoomToggleTouchButton;

		public TouchOptionButton zoomLevelOptions;

		public ColorblindCustomisationPanel colorblindCustomisationPanel;

		public DropdownBox resolutionsDropdown;

		public TouchOptionButton displaySelectionOptions;

		public PaginatedScrollView optionsPages;

		public LocalizedTextUI versionString;

		[Dependency]
		private IHardwareCapabilities _hardwareCapabilities;

		[Dependency]
		private ISoftwareCapabilities _softwareCapabilities;

		[Dependency]
		private IPersistentStorageService _storage;

		[Dependency]
		private LocaleDatabase _locales;

		[Dependency]
		private FontDatabase _fontDatabase;

		[Dependency]
		private ISystemNotificationService _systemNotificationService;

		[Dependency]
		private NotificationScheduler _notificationScheduler;

		[Dependency]
		private INotificationEventSystem _notificationEventSystem;

		[Dependency]
		private IControllerButtonToSymbolService _controllerButtonToSymbolService;

		[Dependency]
		private ISteamCloudSyncService _cloudSyncService;

		[Dependency]
		private VisualConstantsData _visualConstants;

		public LanguageButton localeButtonPrefab;

		private Selectable firstLanguageButton;

		public RectTransform languagePanel;

		private List<LanguageButton> languageButtons;

		public CanvasGroup optionsCanvasGroup;

		public CanvasGroup controllerCanvas;

		public CanvasGroup siriRemoteCanvas;

		public CanvasGroup keyboardCanvas;

		public CanvasGroup mouseCanvas;

		public CanvasGroup touchCanvas;

		public CanvasGroup switchJoyconDualCanvas;

		public CanvasGroup switchHandheldCanvas;

		public CanvasGroup switchProCanvas;

		public CanvasGroup switchJoyconLCanvas;

		public CanvasGroup switchJoyconRCanvas;

		public ButtonGroup inputMethodButtonGroup;

		public TouchButton siriRemoteButton;

		public TouchButton keyboardButton;

		public TouchButton mouseButton;

		public TouchButton touchInputButton;

		public TouchButton gamepadInputButton;

		public TouchButton switchJoyconDualButton;

		public TouchButton switchHandheldButton;

		public TouchButton switchProButton;

		public TouchButton switchJoyconLButton;

		public TouchButton switchJoyconRButton;

		private bool _hasNewiCloudMessage;

		private string _iCloudMessageKey;

		public TouchButton _faqButton;

		private Selectable _focusBeforeModalScreen;

		public TouchButton resetAchievementButton;

		public SymbolOptionButton menuMessagesButton;

		public SymbolOptionButton challengeRemindersButton;

		public SymbolOptionButton contentRemindersButton;

		public LocalizedTextUI notificationsStatusText;

		public TouchButton enableNotificationsButton;

		public TouchButton clearNotificationEventsButton;

		public TouchButton sendTestNotificationButton;

		public TouchButton debugPageButton;

		public DebugOptionsPage debugOptionsPage;

		public TouchButton audioButton;

		public TouchButton displayButton;

		public TouchButton iCloudButton;

		public TouchButton crossSaveButton;

		public TouchButton creditsButton;

		public TouchButton messagesButton;

		public TouchButton privacyButton;

		public ButtonGroup tabButtonGroup;

		public Transform importSaveButton;

		public TouchOptionButton VolumeControls;

		public GameObject mfiControllerDiagram;

		[Tooltip("The duration of the fade to black if Skip Transitions is on")]
		[MinValue(0)]
		public float skippedTransitionFadeDuration = 1f;

		private bool _enterTutorialNextTick;

		[Dependency]
		private IReachability _reachability;

		private Action OnNotificationAuthorizationRequestComplete;

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("OptionsScreen");

		private List<Resolution> _displayedResolutions = new List<Resolution>();

		private ControllerSymbol[] _controllerSymbols;

		[SerializeField]
		private GameObject[] _toolbarLockingControls;

		[Tooltip("How long in seconds the options screen should fade in/out when it loses focus")]
		[SerializeField]
		private float _fadeDuration;

		private bool _shouldFadeIn;

		private bool _shouldFadeOut;

		private bool SystemNotificationsAuthorized => _systemNotificationService.AuthorizationStatus == AuthorizationStatus.Authorized;

		public void OnFullscreenButtonToggled(bool isFullScreen)
		{
			if (!_hardwareCapabilities.SupportsChangingResolution)
			{
				return;
			}
			Resolution nativeResolution = GetNativeResolution();
			if (isFullScreen)
			{
				Screen.SetResolution(nativeResolution.width, nativeResolution.height, FullScreenMode.MaximizedWindow);
				Log.Info("Set resolution to {0}x{1}, {2}", nativeResolution.width, nativeResolution.height, true);
				for (int i = 0; i < _displayedResolutions.Count; i++)
				{
					if (_displayedResolutions[i].width == nativeResolution.width && _displayedResolutions[i].height == nativeResolution.height)
					{
						resolutionsDropdown.SetSelectedOption(i);
						break;
					}
				}
			}
			else if (Screen.fullScreen || Application.isEditor)
			{
				int num = -1;
				Vector2 a = new Vector2((float)nativeResolution.width * 0.5f, (float)nativeResolution.height * 0.5f);
				float num2 = float.MaxValue;
				for (int j = 0; j < _displayedResolutions.Count; j++)
				{
					Resolution resolution = _displayedResolutions[j];
					Vector2 b = new Vector2(resolution.width, resolution.height);
					float num3 = Vector2.Distance(a, b);
					if (num3 < num2)
					{
						num = j;
						num2 = num3;
					}
				}
				Resolution resolution2 = _displayedResolutions[num];
				Screen.SetResolution(resolution2.width, resolution2.height, fullscreen: false);
				Log.Info("Set resolution to {0}, fullscreen: {1}", resolution2, false);
				resolutionsDropdown.SetSelectedOption(num);
			}
			else
			{
				Log.Info("Ignoring switch to windowed because the app's window isn't fullscreen.");
			}
			StartCoroutine(ResizeOptionsScreenAtEndOfFrame(new Vector2(Screen.width, Screen.height)));
		}

		private Resolution GetNativeResolution()
		{
			if (DesktopHardwareCapabilities.SafeAreaHeight > 0)
			{
				Vector2Int closestResolution = DesktopHardwareCapabilities.GetClosestResolution(DesktopHardwareCapabilities.SafeAreaDimensions);
				foreach (Resolution displayedResolution in _displayedResolutions)
				{
					if (displayedResolution.width == closestResolution.x && displayedResolution.height == closestResolution.y)
					{
						Log.Info("Selecting {0}x{1} as the native resolution to fit the screen's safe area better than the actual resolution of {2}x{3}.", displayedResolution.width, displayedResolution.height, _displayedResolutions[0].width, _displayedResolutions[0].height);
						return displayedResolution;
					}
					Log.Warn("Couldn't find a resolution to fit the safe area of {0}x{1}.", closestResolution.x, closestResolution.y);
				}
			}
			return _displayedResolutions[0];
		}

		public void OnAnalyticsToggled(bool analyticsOn)
		{
			AnalyticsService.ConsentState analyticsConsentState = (analyticsOn ? AnalyticsService.ConsentState.Accepted : AnalyticsService.ConsentState.Declined);
			_player.AnalyticsConsentState = analyticsConsentState;
			_appScope.Get<AnalyticsEventHandler>().SetAnalyticsConsentState(analyticsConsentState);
		}

		public void OnCloudSavesButtonToggled(bool cloudSavesOn)
		{
			_player.SyncToCloud = cloudSavesOn;
		}

		public void OnNightmodeButtonToggled(bool nightmodeOn)
		{
			_themeDatabase.SetNightMode(nightmodeOn, forceBlend: true);
			colorblindCustomisationPanel.BuildVisualPanel();
		}

		public void OnColorblindButtonToggled(bool colorblindOn)
		{
			_themeDatabase.SetColorblindMode(colorblindOn, forceBlend: true);
			colorblindCustomisationPanel.gameObject.SetActive(_themeDatabase.IsInColorblindMode);
			_player.SetNewContentSeen("NewColorblindPopup");
		}

		public void OnSkipTransitionsButtonToggled(bool doSkipTransitions)
		{
			_player.IsSkipTransitionsEnabled = !doSkipTransitions;
		}

		public void OnAntiAliasingLevelChanged(int newAntiAliasingLevelOptionsValue)
		{
			_player.AntiAliasingLevel = newAntiAliasingLevelOptionsValue;
			SetAntiAliasingLevel(_player.AntiAliasingMSAALevelForUniversalRenderPipeline);
		}

		public static void SetAntiAliasingLevel(int newAntiAliasingLevel)
		{
			if (GraphicsSettings.currentRenderPipeline is UniversalRenderPipelineAsset universalRenderPipelineAsset)
			{
				universalRenderPipelineAsset.msaaSampleCount = newAntiAliasingLevel;
			}
		}

		public void OnZoomButtonToggled(bool zoomOn)
		{
			_player.IsZoomEnabled = zoomOn;
		}

		public void OnZoomLevelChanged(int newZoomLevel)
		{
			_player.ZoomLevel = newZoomLevel;
		}

		public void OnControllerSensitivityChanged(int newSensitivity)
		{
			_player.ControllerSensitivity = newSensitivity;
		}

		public void OnDisplayChanged(int newDisplayValue)
		{
			if (Diagnostics.Verify(MultiDisplayCapabilitiesBridge.SetActiveDisplayIndex(newDisplayValue), "Failed to change selected display to {0}", newDisplayValue))
			{
				_player.SelectedDisplay = MultiDisplayCapabilitiesBridge.GetActiveDisplayIndex();
			}
			UpdateResolutions();
			if (!Screen.fullScreen && !Application.isEditor)
			{
				return;
			}
			int selectedOption = 0;
			for (int i = 0; i < _displayedResolutions.Count; i++)
			{
				if (_displayedResolutions[i].height == Screen.currentResolution.height && _displayedResolutions[i].width == Screen.currentResolution.width)
				{
					selectedOption = i;
					break;
				}
			}
			resolutionsDropdown.SetSelectedOption(selectedOption);
		}

		public void OnVibrationButtonToggled(bool enableVibrations)
		{
			_player.IsVibrationEnabled = enableVibrations;
		}

		public void OnDrawModeToggleButtonToggled(bool enableDrawModeToggle)
		{
			_player.IsDrawModeToggleEnabled = enableDrawModeToggle;
		}

		private void OnTelemetryButtonToggled(bool enableTelemetry)
		{
			_player.IsTelemetryEnabled = enableTelemetry;
		}

		private void OnHoldDrawButtonToggled(bool enableHoldToDraw)
		{
			_player.IsTapDrawEnabled = !enableHoldToDraw;
		}

		public void OnVolumeChanged(int newValue)
		{
			_player.VolumeSetting = newValue;
		}

		public void OnSoundscapeChanged(int newValue)
		{
			_player.Soundscape = newValue;
		}

		public void OnResolutionSelected(int resolutionIndex)
		{
			Resolution resolution = _displayedResolutions[resolutionIndex];
			Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
			Log.Info("Setting resolution to {0}x{1}", resolution.width, resolution.height);
			StartCoroutine(ResizeOptionsScreenAtEndOfFrame(new Vector2(Screen.width, Screen.height)));
		}

		private IEnumerator ResizeOptionsScreenAtEndOfFrame(Vector2 oldResolution)
		{
			yield return new WaitForEndOfFrame();
			if (Application.isEditor)
			{
				yield break;
			}
			for (int attemptNumber = 0; attemptNumber < 100; attemptNumber++)
			{
				if (Diagnostics.Verify(oldResolution.x != (float)Screen.width || oldResolution.y != (float)Screen.height, "We waited for the end of the frame and the screen size still isn't different! Old res: {0} - new res: {1}. Attempt number {2}", oldResolution, new Vector2(Screen.width, Screen.height), attemptNumber))
				{
					Log.Info("Refreshing the options screen based on current resolution: {0}x{1} from {2}", Screen.width, Screen.height, oldResolution);
					optionsPages.RefreshPageTransforms(1);
					break;
				}
				yield return new WaitForEndOfFrame();
			}
		}

		public void OnMenuMessagesButtonToggled(bool enableMenuMessages)
		{
			_player.AreMenuMessagesEnabled = enableMenuMessages;
		}

		public void OnChallengeRemindersButtonToggled(bool enableChallengeReminders)
		{
			_player.IsChallengeRemindersEnabledSetting = enableChallengeReminders;
			_notificationScheduler.ScheduleNotifications();
		}

		public void OnContentRemindersButtonToggled(bool enableContentReminders)
		{
			_player.IsContentRemindersEnabledSetting = enableContentReminders;
			_notificationScheduler.ScheduleNotifications();
		}

		public void OnEnableNotificationsButtonPressed()
		{
			AuthorizationStatus authorizationStatus = _systemNotificationService.AuthorizationStatus;
			if ((uint)authorizationStatus <= 1u)
			{
				_systemNotificationService.RequestAuthorization(delegate(bool granted)
				{
					OnNotificationAuthorizationRequestComplete = UpdateButtonStatesFromSettings;
					if (!granted && _systemNotificationService.AuthorizationStatus == AuthorizationStatus.Denied && _systemNotificationService is iOSSystemNotificationService iOSSystemNotificationService2)
					{
						iOSSystemNotificationService2.OpenApplicationSettings();
					}
				});
			}
			else
			{
				Diagnostics.FailAssert("Enable Notifications button pressed when status was {0}. This should not be possible.", _systemNotificationService.AuthorizationStatus);
			}
		}

		public void OnSendTestNotificationButtonPressed()
		{
			_notificationScheduler.ScheduleTestNotification();
		}

		public void OnClearEventsButtonPressed()
		{
			_notificationEventSystem.RemoveAll();
			_notificationEventSystem.RecordEvent(new OpenedMiniMotorways());
			UpdateClearEventsButtonText();
		}

		public void OnResetAchievementsButton()
		{
			GameCenterShared.GCResetAchievements();
		}

		public void OnOpeniCloudFaq()
		{
			Application.OpenURL(_visualConstants.iCloudLinkString);
		}

		private void UpdateClearEventsButtonText()
		{
			clearNotificationEventsButton.transform.GetComponentInChildren<TMP_Text>().text = $"Clear {_notificationEventSystem.AllEvents.Count} Events";
		}

		private void UpdateSendTestNotificationButtonText()
		{
			sendTestNotificationButton.transform.GetComponentInChildren<TMP_Text>().text = $"Send Test Notification (in {15}s)";
		}

		public void OnBack()
		{
			if (resolutionsDropdown.dropdownList.activeSelf)
			{
				resolutionsDropdown.DismissDropdown();
			}
			else
			{
				_screenStack.PopOneScreen();
			}
		}

		public void OnGamepadInputTypeSelected()
		{
			SetControllerCanvas(_hardwareCapabilities.CurrentGamepadStyle);
			siriRemoteCanvas.alpha = 0f;
			keyboardCanvas.alpha = 0f;
			mouseCanvas.alpha = 0f;
			touchCanvas.alpha = 0f;
		}

		public void OnRemoteInputTypeSelected()
		{
			SetControllerCanvas(DeviceInputGamepadStyle.None);
			siriRemoteCanvas.alpha = 1f;
			keyboardCanvas.alpha = 0f;
			mouseCanvas.alpha = 0f;
			touchCanvas.alpha = 0f;
		}

		public void OnMouseInputTypeSelected()
		{
			SetControllerCanvas(DeviceInputGamepadStyle.None);
			siriRemoteCanvas.alpha = 0f;
			keyboardCanvas.alpha = 0f;
			mouseCanvas.alpha = 1f;
			touchCanvas.alpha = 0f;
		}

		public void OnKeyboardInputTypeSelected()
		{
			SetControllerCanvas(DeviceInputGamepadStyle.None);
			siriRemoteCanvas.alpha = 0f;
			keyboardCanvas.alpha = 1f;
			mouseCanvas.alpha = 0f;
			touchCanvas.alpha = 0f;
		}

		public void OnTouchInputTypeSelected()
		{
			SetControllerCanvas(DeviceInputGamepadStyle.None);
			siriRemoteCanvas.alpha = 0f;
			keyboardCanvas.alpha = 0f;
			mouseCanvas.alpha = 0f;
			touchCanvas.alpha = 1f;
		}

		public void RefreshControllerSymbols()
		{
			if (_controllerSymbols == null)
			{
				_controllerSymbols = base.gameObject.GetComponentsInChildren<ControllerSymbol>();
			}
			ControllerSymbol[] controllerSymbols = _controllerSymbols;
			for (int i = 0; i < controllerSymbols.Length; i++)
			{
				controllerSymbols[i].Initialize(_controllerButtonToSymbolService);
			}
			if (_controllerButtonToSymbolService.HasMappings)
			{
				bool flag = false;
				controllerSymbols = _controllerSymbols;
				foreach (ControllerSymbol controllerSymbol in controllerSymbols)
				{
					if (controllerSymbol.shouldUseControllerButton)
					{
						flag |= controllerSymbol.IsUsingDefaultSymbol;
					}
				}
				mfiControllerDiagram.SetActive(flag);
			}
			RegisterThemeComponents(_themeDatabase.GetTheme());
		}

		private void SetControllerCanvas(DeviceInputGamepadStyle gamepadStyle)
		{
			controllerCanvas.alpha = ((gamepadStyle == DeviceInputGamepadStyle.Generic) ? 1 : 0);
			switchJoyconDualCanvas.alpha = ((gamepadStyle == DeviceInputGamepadStyle.SwitchJoyConDual) ? 1 : 0);
			switchHandheldCanvas.alpha = ((gamepadStyle == DeviceInputGamepadStyle.SwitchHandheld) ? 1 : 0);
			switchProCanvas.alpha = ((gamepadStyle == DeviceInputGamepadStyle.SwitchPro) ? 1 : 0);
			switchJoyconLCanvas.alpha = ((gamepadStyle == DeviceInputGamepadStyle.SwitchJoyConL) ? 1 : 0);
			switchJoyconRCanvas.alpha = ((gamepadStyle == DeviceInputGamepadStyle.SwitchJoyConR) ? 1 : 0);
		}

		private TouchButton GetGamepadStyleButton(DeviceInputGamepadStyle gamepadStyle)
		{
			return gamepadStyle switch
			{
				DeviceInputGamepadStyle.SwitchPro => switchProButton, 
				DeviceInputGamepadStyle.SwitchHandheld => switchHandheldButton, 
				DeviceInputGamepadStyle.SwitchJoyConDual => switchJoyconDualButton, 
				DeviceInputGamepadStyle.SwitchJoyConL => switchJoyconLButton, 
				DeviceInputGamepadStyle.SwitchJoyConR => switchJoyconRButton, 
				_ => gamepadInputButton, 
			};
		}

		public void OnNewPageSelected()
		{
			SetOptionButtonsRightNavigation(optionsPages.GetFirstSelectableOnCurrentPage());
		}

		private void SetOptionButtonsRightNavigation(Selectable newRightSideSelectable)
		{
			foreach (TouchButton button in tabButtonGroup.buttons)
			{
				Navigation navigation = button.navigation;
				navigation.selectOnRight = newRightSideSelectable;
				button.navigation = navigation;
			}
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			base.TransitionIn(outScreen);
			if (this is OptionsScreenPause)
			{
				_canvasGroup.Alpha = 0f;
			}
			if (_tutorialCityDefinition == null && this is OptionsScreenMain)
			{
				_tutorialCityDefinition = AssetBundleUtility.LoadPrefabAsync(tutorialDefinition.mapAssetBundle, tutorialDefinition.mapPrefabName, this);
			}
			antiAliasingLevelOptions.gameObject.SetActive(_hardwareCapabilities.SupportsAntiAliasingOptions);
			controllerSensitivityOptions.gameObject.SetActive(FeatureToggle.IsFeatureEnabled(Feature.ControllerSensitivityOption));
			fullscreenToggle.gameObject.SetActive(_hardwareCapabilities.SupportsChangingResolution);
			int displayCount = MultiDisplayCapabilitiesBridge.GetDisplayCount();
			displaySelectionOptions.gameObject.SetActive(displayCount > 1 && FeatureToggle.IsFeatureEnabled(Feature.DisplaySelection));
			UpdateResolutions();
			vibrationsToggle.gameObject.SetActive(_hardwareCapabilities.SupportsHapticFeedback);
			drawModeToggleToggle.gameObject.SetActive(_hardwareCapabilities.DefaultDeviceInputType == DeviceInputType.Mouse);
			telemetryToggle.gameObject.SetActive(FeatureToggle.IsFeatureEnabled(Feature.TelemetryToggle));
			analyticsToggle.gameObject.SetActive(FeatureToggle.IsFeatureEnabled(Feature.Analytics) && !AnalyticsUtilities.IsUnderage());
			if (analyticsToggle.gameObject.activeInHierarchy)
			{
				if (_player.AnalyticsConsentState == AnalyticsService.ConsentState.NotYetGiven)
				{
					analyticsToggle.SetOption(0);
					_player.AnalyticsConsentState = AnalyticsService.ConsentState.NotYetGiven;
					_appScope.Get<AnalyticsEventHandler>().SetAnalyticsConsentState(AnalyticsService.ConsentState.NotYetGiven);
				}
				else
				{
					analyticsToggle.SetOption((_player.AnalyticsConsentState == AnalyticsService.ConsentState.Accepted) ? 1 : 0);
				}
			}
			privacyButton.gameObject.SetActive((FeatureToggle.IsFeatureEnabled(Feature.TelemetryToggle) || (FeatureToggle.IsFeatureEnabled(Feature.Analytics) && !AnalyticsUtilities.IsUnderage())) && this is OptionsScreenMain);
			telemetryToggle.onOptionTriggered.AddListener(OnTelemetryButtonToggled);
			holdToDrawToggle.onOptionTriggered.AddListener(OnHoldDrawButtonToggled);
			optionsPages.RefreshPageTransforms();
			firstFocus.OnActivate();
			_reachability.ConnectivityChanged += OnInternetConnectivityChanged;
			OnInternetConnectivityChanged(_reachability.Connectivity);
			_storage.StatusChanged += OnStorageStatusChanged;
			OnStorageStatusChanged(_storage.Status);
			Get.State |= StateType.MenuOptions;
			UpdateButtonStatesFromSettings();
			if (languagePanel.childCount == 0)
			{
				SetupButtons();
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.OptionsDebugMenu))
			{
				debugPageButton.gameObject.SetActive(value: true);
				debugOptionsPage.InitializeButtons();
			}
			else
			{
				debugPageButton.gameObject.SetActive(value: false);
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.MessageDebugButtons) && this is OptionsScreenMain)
			{
				clearNotificationEventsButton.gameObject.SetActive(value: true);
				UpdateClearEventsButtonText();
				sendTestNotificationButton.gameObject.SetActive(value: true);
				UpdateSendTestNotificationButtonText();
			}
			else
			{
				sendTestNotificationButton.gameObject.SetActive(value: false);
				clearNotificationEventsButton.gameObject.SetActive(value: false);
			}
			RegisterButtons();
			RegisterThemeComponents(_themeDatabase.GetTheme());
			RegisterAllLocalizedTextChildren();
			optionsCanvasGroup.alpha = 1f;
			optionsCanvasGroup.interactable = true;
			_player.DataChanged += UpdateButtonStatesFromSettings;
			if (FeatureToggle.IsFeatureEnabled(Feature.ResetAchievementsButton))
			{
				resetAchievementButton.gameObject.SetActive(value: true);
			}
			else
			{
				resetAchievementButton.gameObject.SetActive(value: false);
			}
			versionString.LocString = StandaloneLocString.CreateNonLocalizedString(_appScope, $"Mini Motorways {Version.Name} ({Version.Timestamp})");
			SetOptionButtonsRightNavigation(optionsPages.GetFirstSelectableOnCurrentPage());
			_hardwareCapabilities.OnGamepadStyleChanged += OnGamepadStyleChanged;
			colorblindCustomisationPanel.Initialise(_appScope, popupStack);
			colorblindCustomisationPanel.gameObject.SetActive(_themeDatabase.IsInColorblindMode);
			colorblindCustomisationPanel.onUpdated += OnColorblindCustomisationUpdated;
			zoomToggleTouchButton = zoomToggle.GetComponent<TouchButton>();
			zoomToggle.gameObject.SetActive(FeatureToggle.IsFeatureEnabled(Feature.AutoZoomEnabledOption));
			if (zoomToggleTouchButton != null)
			{
				if (FeatureToggle.IsFeatureEnabled(Feature.AutoZoomEnabledOption))
				{
					BaseScalingScreen.SetNavigationOnUp(zoomLevelOptions.rightButton, zoomToggleTouchButton);
					BaseScalingScreen.SetNavigationOnDown(controllerSensitivityOptions.rightButton, zoomToggleTouchButton);
				}
				else
				{
					BaseScalingScreen.SetNavigationOnUp(zoomLevelOptions.rightButton, controllerSensitivityOptions.rightButton);
					BaseScalingScreen.SetNavigationOnDown(controllerSensitivityOptions.rightButton, zoomLevelOptions.rightButton);
				}
			}
			zoomLevelOptions.gameObject.SetActive(value: true);
			displayButton.gameObject.SetActive(_softwareCapabilities.SupportsDisplayOptions);
			StartCoroutine(UpdateMaxLengthButtons());
		}

		private void OnColorblindCustomisationUpdated()
		{
			_themeDatabase.UpdateThemeFromCurrentDefinition(forceUpdate: true);
		}

		private void UpdateResolutions()
		{
			if (_hardwareCapabilities.SupportsChangingResolution)
			{
				_displayedResolutions.Clear();
				List<string> list = new List<string>();
				Log.Info("Loading up {0} resolutions and trying to find index for current resolution: {1}x{2}", Screen.resolutions.Length, Screen.width, Screen.height);
				int num = -1;
				for (int i = 0; i < Screen.resolutions.Length; i++)
				{
					Resolution resolution = Screen.resolutions[i];
					if (!AlreadyContainsResolution(resolution))
					{
						if (Screen.width == resolution.width && Screen.height == resolution.height)
						{
							num = list.Count;
						}
						list.Add($"{resolution.width}x{resolution.height}");
						_displayedResolutions.Add(resolution);
					}
				}
				if (num < 0)
				{
					num = Screen.resolutions.Length - 1;
				}
				_displayedResolutions.Reverse();
				list.Reverse();
				num = list.Count - 1 - num;
				resolutionsDropdown.gameObject.SetActive(value: true);
				resolutionsDropdown.PopulateList(list, num, _appScope);
			}
			else
			{
				resolutionsDropdown.gameObject.SetActive(value: false);
			}
		}

		private bool AlreadyContainsResolution(Resolution resolution)
		{
			foreach (Resolution displayedResolution in _displayedResolutions)
			{
				if (displayedResolution.width == resolution.width && displayedResolution.height == resolution.height)
				{
					return true;
				}
			}
			return false;
		}

		public void SetupControllerHelpButtons()
		{
			gamepadInputButton.gameObject.SetActive(value: false);
			touchInputButton.gameObject.SetActive(value: false);
			siriRemoteButton.gameObject.SetActive(value: false);
			keyboardButton.gameObject.SetActive(value: false);
			mouseButton.gameObject.SetActive(value: false);
			switchProButton.gameObject.SetActive(value: false);
			switchHandheldButton.gameObject.SetActive(value: false);
			switchJoyconDualButton.gameObject.SetActive(value: false);
			switchJoyconLButton.gameObject.SetActive(value: false);
			switchJoyconRButton.gameObject.SetActive(value: false);
			GetGamepadStyleButton(_hardwareCapabilities.CurrentGamepadStyle).gameObject.SetActive(value: true);
			if (_hardwareCapabilities.DefaultDeviceInputType == DeviceInputType.Mouse)
			{
				keyboardButton.gameObject.SetActive(value: true);
				mouseButton.gameObject.SetActive(value: true);
			}
			if (_hardwareCapabilities.DefaultDeviceInputType == DeviceInputType.Touch || _hardwareCapabilities.CurrentGamepadStyle == DeviceInputGamepadStyle.SwitchHandheld)
			{
				touchInputButton.gameObject.SetActive(value: true);
			}
			switch (_inputState.CurrentDeviceInputType)
			{
			case DeviceInputType.Touch:
				inputMethodButtonGroup.OnButtonClicked(touchInputButton);
				OnTouchInputTypeSelected();
				break;
			case DeviceInputType.Mouse:
				inputMethodButtonGroup.OnButtonClicked(mouseButton);
				OnMouseInputTypeSelected();
				break;
			case DeviceInputType.Remote:
				inputMethodButtonGroup.OnButtonClicked(siriRemoteButton);
				OnRemoteInputTypeSelected();
				break;
			case DeviceInputType.Controller:
			{
				TouchButton gamepadStyleButton = GetGamepadStyleButton(_hardwareCapabilities.CurrentGamepadStyle);
				inputMethodButtonGroup.OnButtonClicked(gamepadStyleButton);
				OnGamepadInputTypeSelected();
				break;
			}
			}
			GameObject[] toolbarLockingControls = _toolbarLockingControls;
			for (int i = 0; i < toolbarLockingControls.Length; i++)
			{
				toolbarLockingControls[i].SetActive(AppContainer.Environment.DeviceCategory == DeviceCategory.Desktop);
			}
		}

		private void OnGamepadStyleChanged(DeviceInputGamepadStyle gamepadStyle)
		{
			if (optionsPages.CurrentPage == 4)
			{
				SetupControllerHelpButtons();
			}
		}

		public override void OnTransitionedIn()
		{
			base.OnTransitionedIn();
			firstFocus.Select();
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			base.TransitionOut(inScreen);
			_skipTransitions = _skipTransitions || this is OptionsScreenPause;
			_player.DataChanged -= UpdateButtonStatesFromSettings;
			_reachability.ConnectivityChanged -= OnInternetConnectivityChanged;
			_storage.StatusChanged -= OnStorageStatusChanged;
			Get.State &= ~StateType.MenuOptions;
			_hardwareCapabilities.OnGamepadStyleChanged -= OnGamepadStyleChanged;
		}

		public override void OnGainedFocus()
		{
			base.OnGainedFocus();
			_shouldFadeIn = this is OptionsScreenPause;
			_shouldFadeOut = false;
		}

		public override void OnLostFocus()
		{
			base.OnLostFocus();
			_shouldFadeIn = false;
			_shouldFadeOut = this is OptionsScreenPause;
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
			if (_shouldFadeIn || _shouldFadeOut)
			{
				float num = _canvasGroup.Alpha + (float)(_shouldFadeIn ? 1 : (-1)) * Time.deltaTime / _fadeDuration;
				if (num <= 0f || num >= 1f)
				{
					num = Mathf.Clamp(num, 0f, 1f);
					_shouldFadeIn = false;
					_shouldFadeOut = false;
				}
				_canvasGroup.Alpha = num;
			}
			if (_hasNewiCloudMessage)
			{
				_hasNewiCloudMessage = false;
				SetiCloudMessage(_iCloudMessageKey);
			}
			if (_enterTutorialNextTick)
			{
				_screenStack.PushScreen(ScreenStack.MotorwaysScreen.InGame, delegate(GameContainerScreen newScreen)
				{
					newScreen.PrepareForMap(UnityEngine.Object.Instantiate(_tutorialCityDefinition.asset as GameObject).GetComponent<CityDefinition>(), tutorialDefinition, GameMode.Tutorial);
				});
				_enterTutorialNextTick = false;
			}
			if (OnNotificationAuthorizationRequestComplete != null)
			{
				OnNotificationAuthorizationRequestComplete();
				OnNotificationAuthorizationRequestComplete = null;
			}
		}

		private void OnApplicationPause(bool pauseStatus)
		{
			if (!pauseStatus)
			{
				UpdateButtonStatesFromSettings();
				RefreshControllerSymbols();
			}
		}

		private void UpdateButtonStatesFromSettings()
		{
			_themeDatabase.OnPlayerDataChanged();
			nightModeToggle.SetOption(_themeDatabase.IsInNightMode ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			colorblindModeToggle.SetOption(_themeDatabase.IsInColorblindMode ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			skipTransitionsToggle.SetOption((!_player.IsSkipTransitionsEnabled) ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			antiAliasingLevelOptions.SetOption(_player.AntiAliasingLevel, invokeMethod: false);
			controllerSensitivityOptions.SetOption(_player.ControllerSensitivity, invokeMethod: false);
			vibrationsToggle.SetOption(_player.IsVibrationEnabled ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			drawModeToggleToggle.SetOption(_player.IsDrawModeToggleEnabled ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			telemetryToggle.SetOption(_player.IsTelemetryEnabled ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			holdToDrawToggle.SetOption((!_player.IsTapDrawEnabled) ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			fullscreenToggle.SetOption(Screen.fullScreen ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			volumeOptions.SetOption(_player.VolumeSetting, invokeMethod: false);
			soundscapeOptions.SetOption(_player.Soundscape, invokeMethod: false);
			zoomToggle.SetOption(_player.IsZoomEnabled ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			zoomLevelOptions.SetOption(_player.ZoomLevel, invokeMethod: false);
			if (!Screen.fullScreen)
			{
				_player.SelectedDisplay = MultiDisplayCapabilitiesBridge.GetActiveDisplayIndex();
			}
			displaySelectionOptions.SetOption(_player.SelectedDisplay, invokeMethod: false);
			for (int i = 0; i < displaySelectionOptions.NumberOfOptions; i++)
			{
				if (i >= _hardwareCapabilities.DisplayCount)
				{
					displaySelectionOptions.SkipOption(i);
				}
				else
				{
					displaySelectionOptions.UnskipOption(i);
				}
			}
			IAudioSystem audioSystem = _appScope.Get<IAudioSystem>();
			VolumeControls.gameObject.SetActive(audioSystem.RequiresVolumeControl);
			IPersistentStorageService persistentStorageService = _appScope.Get<IPersistentStorageService>();
			iCloudButton.gameObject.SetActive(persistentStorageService.RequiresOptionsPanel && this is OptionsScreenMain);
			crossSaveButton.gameObject.SetActive(_cloudSyncService.IsSupported && this is OptionsScreenMain);
			if (_systemNotificationService.RequiresOptionsPanel && this is OptionsScreenMain)
			{
				messagesButton.gameObject.SetActive(value: true);
				menuMessagesButton.SetOption(_player.AreMenuMessagesEnabled ? 1 : 0);
				challengeRemindersButton.SetOption(_player.IsChallengeRemindersEnabledSetting ? 1 : 0);
				contentRemindersButton.SetOption(_player.IsContentRemindersEnabledSetting ? 1 : 0);
				notificationsStatusText.SetStringId(_appScope, SystemNotificationsAuthorized ? StringId.OptionsNotificationsAreEnabled : StringId.OptionsNotificationsAreDisabled);
				notificationsStatusText.transform.parent.parent.gameObject.SetActive(_systemNotificationService.IsAvailable);
				challengeRemindersButton.gameObject.SetActive(_systemNotificationService.IsAvailable && SystemNotificationsAuthorized);
				contentRemindersButton.gameObject.SetActive(_systemNotificationService.IsAvailable && SystemNotificationsAuthorized);
				enableNotificationsButton.gameObject.SetActive(_systemNotificationService.IsAvailable && !SystemNotificationsAuthorized);
			}
			else
			{
				messagesButton.gameObject.SetActive(value: false);
			}
		}

		private void OnInternetConnectivityChanged(InternetConnectivity connectivity)
		{
			onlineIndicator?.SetOption((connectivity == InternetConnectivity.Connected) ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			_hasNewiCloudMessage = true;
		}

		private void OnStorageStatusChanged(PersistentStorageServiceStatus status)
		{
			Log.Info("Updating storage status to show issues {0} and message {1}.", status.issues, status.messageKey);
			bool flag = (status.issues & PersistentStorageServiceIssues.NotAuthenticated) != PersistentStorageServiceIssues.NotAuthenticated;
			bool flag2 = (status.issues & PersistentStorageServiceIssues.NotAvailable) != PersistentStorageServiceIssues.NotAvailable;
			if (_reachability.Connectivity == InternetConnectivity.Disconnected || _reachability.Connectivity == InternetConnectivity.Unknown)
			{
				flag = false;
				flag2 = false;
			}
			signedInToiCloudIndicator?.SetOption(flag ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			syncedWithiCloudIndicator?.SetOption((flag && flag2) ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			if (_faqButton != null)
			{
				bool flag3 = (_storage.Status.issues & PersistentStorageServiceIssues.RecentUnauthenticatedData) > PersistentStorageServiceIssues.None;
				bool flag4 = (_storage.Status.issues & PersistentStorageServiceIssues.QuotaExceeded) > PersistentStorageServiceIssues.None;
				_faqButton.gameObject?.SetActive(flag3 || flag4);
			}
			if (iCloudStatusMessage != null)
			{
				SetiCloudMessage(_iCloudMessageKey);
			}
			_iCloudMessageKey = status.messageKey;
			_hasNewiCloudMessage = true;
		}

		private void SetiCloudMessage(string messageStringKey)
		{
			if (string.IsNullOrEmpty(messageStringKey))
			{
				if (_reachability.Connectivity == InternetConnectivity.Disconnected)
				{
					iCloudStatusMessage.LocString = StandaloneLocString.CreateString(_appScope, StringId.iCloudNotConnectedToInternet);
					iCloudStatusMessage.gameObject.SetActive(value: true);
				}
				else
				{
					iCloudStatusMessage.LocString = StandaloneLocString.CreateNonLocalizedString(_appScope, "");
					iCloudStatusMessage.gameObject.SetActive(value: false);
				}
			}
			else
			{
				StringKey stringKey = _appScope.Get<StringKey>();
				stringKey.InitWithString(messageStringKey);
				iCloudStatusMessage.LocString = StandaloneLocString.CreateString(_appScope, stringKey);
				iCloudStatusMessage.gameObject.SetActive(value: true);
			}
		}

		public Selectable GetButtonForActiveLanguage()
		{
			if (Diagnostics.Verify(languageButtons != null && languageButtons.Count != 0, "Language buttons not set up when trying to transition into the language screen!"))
			{
				Locale currentLocale = _locales.CurrentLocale;
				int index = _locales.GetIndex(currentLocale);
				foreach (LanguageButton languageButton in languageButtons)
				{
					if (languageButton.LocaleIndex == index)
					{
						return languageButton.GetComponent<Selectable>();
					}
				}
			}
			return null;
		}

		public void SetLocale(int index)
		{
			_player.LocaleId = _locales.GetLocale(index).Id;
			Get.State &= ~StateType.MenuLanguage;
			StartCoroutine(UpdateMaxLengthButtons());
		}

		private IEnumerator UpdateMaxLengthButtons()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			LayoutRebuilder.ForceRebuildLayoutImmediate(crossSaveButton.GetComponent<RectTransform>());
			LayoutRebuilder.ForceRebuildLayoutImmediate(importSaveButton.GetComponent<RectTransform>());
			LayoutRebuilder.ForceRebuildLayoutImmediate(creditsButton.GetComponent<RectTransform>());
		}

		private void SetupButtons()
		{
			if (languageButtons == null)
			{
				languageButtons = new List<LanguageButton>();
			}
			else
			{
				languageButtons.Clear();
			}
			ToggleButtonGroup component = languagePanel.GetComponent<ToggleButtonGroup>();
			LocaleDatabase.LocaleId localeId = _player.LocaleId;
			firstLanguageButton = null;
			for (int i = 0; i < _locales.LocaleCount; i++)
			{
				LanguageButton languageButton = UnityEngine.Object.Instantiate(localeButtonPrefab);
				Locale locale = _locales.GetLocale(i);
				languageButton.Initialize(locale, i, _fontDatabase, this, component, localeId == locale.Id);
				languageButton.transform.SetParent(languagePanel);
				languageButton.transform.localScale = Vector3.one;
				firstLanguageButton = ((firstLanguageButton != null) ? firstLanguageButton : languageButton.GetComponent<Selectable>());
				languageButtons.Add(languageButton);
			}
			component.EnsureValidState();
		}

		public void OnTutorial()
		{
			if (_tutorialCityDefinition.HasValue)
			{
				_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.MenuExit));
				if (_skipTransitions)
				{
					_screenStack.FadeNextTransition(skippedTransitionFadeDuration);
				}
				_enterTutorialNextTick = true;
			}
		}

		public void OnImportSteamSaveDataButtonPressed()
		{
			popupStack.PushPopup<CrossSavePopup>().StartSteamSync();
		}

		public void OnCrossSaveHelp()
		{
			popupStack.PushPopup<GenericPopup>().Initialise(StringId.Options_CrossSave, new StringId[2]
			{
				StringId.CrossSave_Explanation_1,
				StringId.CrossSave_Explanation_2
			});
		}

		private void UpdateFocusBeforeModalScreen()
		{
			_focusBeforeModalScreen = _appScope.Get<MenuNavigation>()?.GetCurrentFocus();
		}

		private void UpdateFocusAfterModalScreen()
		{
			if (_appScope.Get<InputState>().CurrentInputTypeRequiresFocus)
			{
				_appScope.Get<MenuNavigation>()?.SetNewFocus(_focusBeforeModalScreen);
			}
		}

		public override void Reset()
		{
			base.Reset();
			_controllerSymbols = null;
		}
	}
}
