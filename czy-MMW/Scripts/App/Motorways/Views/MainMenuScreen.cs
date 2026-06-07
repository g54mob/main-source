using System;
using System.Collections.Generic;
using Analytics;
using Factory;
using Motorways.Audio;
using NaughtyAttributes;
using NotificationService.Events;
using Notifications;
using Popups;
using Screens;
using UnityEngine;
using UnityEngine.UI;
using com.dinopoloclub.analytics;

namespace Motorways.Views
{
	public class MainMenuScreen : BaseScalingScreen, InputState.IObserver
	{
		public interface IObserver
		{
			void OnMainMenuTransitionedIn();

			void OnMainMenuTransitionOut();

			void OnMainMenuExit();
		}

		[Dependency]
		private MapDatabase _mapDatabase;

		[Dependency]
		private InGameMessageUIManager _inGameMessages;

		[Dependency]
		private IPersistentStorageService _storageService;

		private GameStarter _gameStarter;

		public GameObject resumeButton;

		[SerializeField]
		private GameObject _tutorialButton;

		[SerializeField]
		private GameObject _optionsButton;

		[SerializeField]
		private TouchButton _exitButton;

		[SerializeField]
		private GameCenterAccessPointButton _gameCenterAccessPointButton;

		[SerializeField]
		private TouchButton _profileSelectButton;

		[SerializeField]
		private Image _profileSelectBackground;

		[SerializeField]
		private TouchButton _evergreenButton;

		public RectTransform inGameMessageStartingPosition;

		public RectTransform inGameMessageStackStartPosition;

		[Dependency]
		private ISoftwareCapabilities _softwareCapabilities;

		[Dependency]
		private IHardwareCapabilities _hardwareCapabilities;

		[Dependency]
		private ActivePlayer _activePlayer;

		[Dependency]
		private VisualConstantsData _visualConstants;

		[Dependency]
		private ISystemNotificationService _systemNotificationService;

		[Dependency]
		private INotificationEventSystem _notificationEvents;

		[Dependency]
		private NewsAndNotificationData _newsAndNotificationData;

		[MinValue(0)]
		[Tooltip("The duration of the fade to black if Skip Transitions is on")]
		public float skippedTransitionFadeDuration = 1f;

		private NewsAndNotificationObject _currentNewsAndNotificationObject;

		public const string LocalNotificationsPermissionRequest = "LocalNotificationsPermissionRequest";

		public const string NewControllerSchemePopup = "NewControllerSchemePopup";

		public const string NewColorblindPopup = "NewColorblindPopup";

		private const string FTUX_AccessibilitySkipTransitionsFirstVisitNCI = "SkipTransitionsFTUXMessageFirstVisit";

		private const string FTUX_AccessibilitySkipTransitionsNCI = "SkipTransitionsFTUXMessage";

		private const string EnableAnalytics = "EnableAnalytics";

		private const string OptionsScreenMessageTabNCI = "OptionsScreenMessageTab";

		private Action onNotificationAuthorizationCompleteHandler;

		[Serialize(false, null)]
		private readonly ObserverList<IObserver> _observers = new ObserverList<IObserver>();

		protected ObserverList<IObserver> Observers => _observers;

		public override void OnCreatedInScope(IScope scope)
		{
			base.OnCreatedInScope(scope);
			_gameCenterAccessPointButton.Initialise(scope);
			if (_softwareCapabilities.SupportsEvergreenButton)
			{
				List<NewsAndNotificationObject> notifications = _newsAndNotificationData.GetNotifications(_hardwareCapabilities.Platform);
				if (notifications.Count > 0)
				{
					_currentNewsAndNotificationObject = notifications[0];
				}
				_evergreenButton.gameObject.SetActive(_currentNewsAndNotificationObject != null);
			}
			else
			{
				_evergreenButton.gameObject.SetActive(value: false);
			}
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			EnsureOptionsMessageTabNCISetup();
			base.TransitionIn(outScreen);
			_exitButton.gameObject.SetActive(_hardwareCapabilities.SupportsManualExit);
			_profileSelectButton.image.sprite = _visualConstants.GetProfileIcon(_activePlayer.AvatarIconIndex);
			_profileSelectBackground.color = _themeDatabase.GetGlobalColor(ProfileCreationScreen.GetProfileColorEnumForIndex(_activePlayer.AvatarColorIndex));
			if (_softwareCapabilities.SupportsMultipleProfiles || FeatureToggle.IsFeatureEnabled(Feature.ProfileSelectScreen))
			{
				_profileSelectButton.gameObject.SetActive(value: true);
			}
			else
			{
				_profileSelectButton.gameObject.SetActive(value: false);
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				_player.MotorwaysUserProfile.ClearCityStatistics();
				_tutorialButton.SetActive(value: true);
				_optionsButton.SetActive(value: false);
			}
			else
			{
				_tutorialButton.SetActive(value: false);
				_optionsButton.SetActive(value: true);
			}
			if (_evergreenButton != null && _currentNewsAndNotificationObject != null)
			{
				_evergreenButton.SetNewContentID(_currentNewsAndNotificationObject.ContentIndicatorID, bypassNewContent: true, isManuallyTriggered: true);
				_evergreenButton.ShowNewContentIndicatorIfNeeded(playIntro: false);
			}
			_player.DataChanged += UpdateResumeButtonState;
			_player.SavedGamesChanged += UpdateResumeButtonState;
			UpdateResumeButtonState();
			if (FeatureToggle.IsFeatureEnabled(Feature.SoakTest))
			{
				OnPlay();
			}
		}

		public override void OnTransitionedIn()
		{
			base.OnTransitionedIn();
			_softwareCapabilities.SetIsInMainMenuScreen(isInMainMenuScreen: true);
			_gameCenterAccessPointButton.Show();
			if (!FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				if (ShouldShowAnalyticsPopup())
				{
					ShowAnalyticsPopup();
				}
				else if (ShouldShowFTUXAccessibilityForSkipTransitions())
				{
					ShowFTUXAccessibilityForSkipTransitions();
				}
				else if (ShouldShowNotificationsPermissionsFlow())
				{
					ShowLocalNotificationPrePermissionPopup();
				}
				else if (ShouldShowUpdatedControllerSchemePopup())
				{
					ShowUpdatedControllerSchemePopup();
				}
				else if (ShouldShowUpdatedColorblindPopup())
				{
					ShowUpdatedColorblindPopup();
				}
				else
				{
					_activePlayer.SetNewContentSeen("SkipTransitionsFTUXMessageFirstVisit");
				}
			}
			ObserverList<IObserver>.Enumerator enumerator = Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnMainMenuTransitionedIn();
			}
			if ((_storageService.Status.issues & PersistentStorageServiceIssues.RecentUnauthenticatedData) > PersistentStorageServiceIssues.None)
			{
				ShowiCloudUnauthenticated();
			}
		}

		protected virtual void UpdateResumeButtonState()
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				resumeButton.SetActive(value: false);
			}
			else
			{
				resumeButton.SetActive(_player.HasLocalSavedGame || _player.HasForeignSavedGames);
			}
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			base.TransitionOut(inScreen);
			_player.DataChanged -= UpdateResumeButtonState;
			_softwareCapabilities.SetIsInMainMenuScreen(isInMainMenuScreen: false);
			_gameCenterAccessPointButton.Hide();
			ObserverList<IObserver>.Enumerator enumerator = Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnMainMenuTransitionOut();
			}
		}

		public void OnPlay()
		{
			if (!popupStack.HasVisiblePopups)
			{
				_screenStack.PushScreen(ScreenStack.MotorwaysScreen.MapSelect, delegate(MapSelectScreen screen)
				{
					screen.PrepareScreen();
				});
			}
		}

		public void OnOptions()
		{
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.OptionsMain);
		}

		public void OnResumeGame()
		{
			if (_gameStarter != null || (!_player.HasLocalSavedGame && !_player.HasForeignSavedGames))
			{
				return;
			}
			bool flag = _player.HasForeignSavedGames;
			if (FeatureToggle.IsFeatureEnabled(Feature.AlwaysEnterResumeScreen))
			{
				flag = true;
			}
			if (!flag)
			{
				MotorwaysGameJournalSave motorwaysGameJournalSave = (MotorwaysGameJournalSave)_player.LocalSavedGame;
				if (motorwaysGameJournalSave != null)
				{
					_gameStarter = new GameStarter(this);
					_gameStarter.StartFromSavedGame(_mapDatabase.MapLibrary, motorwaysGameJournalSave);
					_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.MenuExit));
					if (_skipTransitions)
					{
						_screenStack.FadeNextTransition(skippedTransitionFadeDuration);
					}
				}
			}
			else
			{
				_screenStack.PushScreen(ScreenStack.MotorwaysScreen.ResumeGame);
			}
		}

		public void OnTutorial()
		{
			if (popupStack.HasVisiblePopups)
			{
				return;
			}
			StartupScreen activeScreen = _screenStack.GetActiveScreen<StartupScreen>();
			if (Diagnostics.Verify(activeScreen != null, "Unable to find StartupScreen, it should always be present.") && Diagnostics.Verify(activeScreen.tutorialDefinition != null, activeScreen, "StartupScreen does not have an assigned tutorial definition"))
			{
				_gameStarter = new GameStarter(this);
				if (_gameStarter.StartFromMapDefinition(activeScreen.tutorialDefinition, GameMode.Tutorial))
				{
					_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.MenuExit));
				}
				else
				{
					_gameStarter = null;
				}
			}
		}

		private void EnsureOptionsMessageTabNCISetup()
		{
			if (!_activePlayer.HasSeenNewContent("OptionsScreenMessagePreNCI"))
			{
				_activePlayer.SetNewContentSeen("OptionsScreenMessagePreNCI");
				_activePlayer.SetNewContentSeen("OptionsScreenMessageTab");
			}
		}

		public bool ShouldShowNotificationsPermissionsFlow()
		{
			if (!_systemNotificationService.IsAvailable)
			{
				return false;
			}
			if (_systemNotificationService.AuthorizationStatus != AuthorizationStatus.NotDetermined)
			{
				return false;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.SkipGameCountAndViewedCheckForPermissionPopup))
			{
				return true;
			}
			if (_activePlayer.HasSeenNewContent("LocalNotificationsPermissionRequest"))
			{
				return false;
			}
			int num = 0;
			foreach (NotificationEvent allEvent in _notificationEvents.AllEvents)
			{
				if (allEvent.EventType is GameOvered)
				{
					num++;
				}
				if (num >= 2)
				{
					return true;
				}
			}
			return false;
		}

		public void ShowLocalNotificationPrePermissionPopup()
		{
			_activePlayer.SetNewContentSeen("LocalNotificationsPermissionRequest");
			popupStack.PushConfirmationPopup<ConfirmationPopup>(StringId.Local_Notifications_PermissionsRequest_Title, OnPrePermissionDenied, OnPrePermissionGranted, StringId.Local_Notifications_PermissionsRequest_Description);
		}

		private bool ShouldShowUpdatedControllerSchemePopup()
		{
			if (_activePlayer.HasSeenNewContent("NewControllerSchemePopup"))
			{
				return false;
			}
			if (!_activePlayer.IsAnyTutorialCompleted)
			{
				return false;
			}
			return _inputState.CurrentDeviceInputType == DeviceInputType.Controller;
		}

		private void ShowUpdatedControllerSchemePopup()
		{
			_activePlayer.SetNewContentSeen("NewControllerSchemePopup");
			popupStack.PushConfirmationPopup<ConfirmationPopup>(StringId.NewControllerScheme_Title, null, OnTutorial, StringId.NewControllerScheme_Description);
		}

		private bool ShouldShowUpdatedColorblindPopup()
		{
			if (_activePlayer.HasSeenNewContent("NewColorblindPopup"))
			{
				return false;
			}
			if (!_activePlayer.IsAnyTutorialCompleted)
			{
				return false;
			}
			return _activePlayer.IsColorblindModeEnabled;
		}

		private void ShowUpdatedColorblindPopup()
		{
			_activePlayer.SetNewContentSeen("NewColorblindPopup");
			popupStack.PushConfirmationPopup<ConfirmationPopup>(StringId.NewColorblindPicker_Title, null, OnOptions, StringId.NewColorblindPicker_Description);
		}

		public override void OnCurrentDeviceInputTypeChanged(DeviceInputType newInputType)
		{
			if (_screenStack.GetTopVisibleScreen() is MainMenuScreen && ShouldShowUpdatedControllerSchemePopup())
			{
				ShowUpdatedControllerSchemePopup();
			}
		}

		private bool ShouldShowFTUXAccessibilityForSkipTransitions()
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.FTUX_Accessibility))
			{
				if (!_activePlayer.IsSkipTransitionsEnabled && !_activePlayer.HasSeenNewContent("SkipTransitionsFTUXMessage"))
				{
					return _activePlayer.HasSeenNewContent("SkipTransitionsFTUXMessageFirstVisit");
				}
				return false;
			}
			return false;
		}

		private void ShowFTUXAccessibilityForSkipTransitions()
		{
			_activePlayer.SetNewContentSeen("SkipTransitionsFTUXMessage");
			popupStack.PushConfirmationPopup<ConfirmationPopup>(StringId.SkipTransitions, null, delegate
			{
				_activePlayer.IsSkipTransitionsEnabled = true;
			}, StringId.FTUX_Accessibility_SkipTransitionDescription);
		}

		private bool ShouldShowAnalyticsPopup()
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.Analytics) && !AnalyticsUtilities.IsUnderage())
			{
				if (_activePlayer.AnalyticsConsentState == AnalyticsService.ConsentState.NotYetGiven && !_activePlayer.HasSeenNewContent("EnableAnalytics"))
				{
					return !(_activePlayer.FirstSession ?? true);
				}
				return false;
			}
			return false;
		}

		private void ShowAnalyticsPopup()
		{
			_activePlayer.SetNewContentSeen("EnableAnalytics");
			popupStack.PushConfirmationPopup<ConfirmationPopup>(StringId.Analytics_MainMenuPrompt, delegate
			{
				_activePlayer.AnalyticsConsentState = AnalyticsService.ConsentState.Declined;
				_appScope.Get<AnalyticsEventHandler>().SetAnalyticsConsentState(AnalyticsService.ConsentState.Declined);
			}, delegate
			{
				_activePlayer.AnalyticsConsentState = AnalyticsService.ConsentState.Accepted;
				_appScope.Get<AnalyticsEventHandler>().SetAnalyticsConsentState(AnalyticsService.ConsentState.Accepted);
			}, StringId.Analytics_MainMenuPrompt_Description);
		}

		private void OnPrePermissionDenied()
		{
			_activePlayer.IsChallengeRemindersEnabledSetting = false;
			_activePlayer.IsContentRemindersEnabledSetting = false;
			_activePlayer.AreMenuMessagesEnabled = true;
			_activePlayer.ClearNewContentSeen("OptionsScreenMessageTab");
			ShowNewContentIndicators();
			_inGameMessages.DisplayMessage(StandaloneLocString.CreateString(_appScope, StringId.Local_Notifications_PermissionsRequest_DeniedConfirmation));
		}

		private void OnPrePermissionGranted()
		{
			switch (_systemNotificationService.AuthorizationStatus)
			{
			case AuthorizationStatus.Authorized:
				OnSystemNotificationsGranted();
				break;
			default:
				OnSystemNotificationsDenied();
				break;
			case AuthorizationStatus.NotDetermined:
				_systemNotificationService.RequestAuthorization(delegate(bool granted)
				{
					if (granted)
					{
						onNotificationAuthorizationCompleteHandler = OnSystemNotificationsGranted;
					}
					else
					{
						onNotificationAuthorizationCompleteHandler = OnSystemNotificationsDenied;
					}
				});
				break;
			}
		}

		private void OnSystemNotificationsDenied()
		{
			_activePlayer.IsChallengeRemindersEnabledSetting = false;
			_activePlayer.IsContentRemindersEnabledSetting = false;
			_activePlayer.AreMenuMessagesEnabled = true;
			_activePlayer.ClearNewContentSeen("OptionsScreenMessageTab");
			ShowNewContentIndicators();
			_inGameMessages.DisplayMessage(StandaloneLocString.CreateString(_appScope, StringId.Local_Notifications_PermissionsRequest_DeniedConfirmation));
		}

		private void OnSystemNotificationsGranted()
		{
			_inGameMessages.DisplayMessage(StandaloneLocString.CreateString(_appScope, StringId.Local_Notifications_PermissionsRequest_Confirmation));
			_activePlayer.IsChallengeRemindersEnabledSetting = true;
			_activePlayer.IsContentRemindersEnabledSetting = true;
			_activePlayer.AreMenuMessagesEnabled = true;
		}

		public void OnExit()
		{
			ObserverList<IObserver>.Enumerator enumerator = Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnMainMenuExit();
			}
			_softwareCapabilities.OnAppShutdown();
			_hardwareCapabilities.Exit();
		}

		public override void BackActivated()
		{
			if (_inGameMessages.HasMessage)
			{
				_inGameMessages.DismissCurrentMessage();
			}
			else
			{
				base.BackActivated();
			}
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
			if (onNotificationAuthorizationCompleteHandler != null)
			{
				onNotificationAuthorizationCompleteHandler();
				onNotificationAuthorizationCompleteHandler = null;
			}
			if (_gameStarter != null && _gameStarter.CanStart)
			{
				_gameStarter.Start(_screenStack, _appScope);
				_gameStarter = null;
			}
		}

		public void OnProfileButtonPressed()
		{
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.ProfileSelect, delegate(ProfileSelectScreen profileScreen)
			{
				profileScreen.PrepareScreen();
			});
		}

		public void OnLogoPinAppear(int pinIndex)
		{
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.LogoPinAppear, 0.5f, pinIndex));
		}

		public void OnLogoPinDisappear(int pinIndex)
		{
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.LogoPinDisappear, 0.5f, pinIndex));
		}

		public void Subscribe(IObserver observer)
		{
			_observers.Subscribe(observer);
		}

		public bool Unsubscribe(IObserver observer)
		{
			return _observers.Unsubscribe(observer);
		}

		public void ShowEvergreenPopup()
		{
			if (_softwareCapabilities.SupportsEvergreenButton)
			{
				_activePlayer.SetNewContentSeen(_currentNewsAndNotificationObject.ContentIndicatorID);
				_evergreenButton.ShowNewContentIndicatorIfNeeded(playIntro: false);
				popupStack.PushConfirmationPopup<ConfirmationPopup>(_currentNewsAndNotificationObject.HeaderID, null, OpenEvergreenLink, _currentNewsAndNotificationObject.BodyID);
			}
		}

		private void OpenEvergreenLink()
		{
			if (_softwareCapabilities.SupportsEvergreenButton && Diagnostics.Verify(_currentNewsAndNotificationObject.WebLink != null, "Evergreen should not be null if SupportsEvergreenButton is true"))
			{
				Application.OpenURL(_currentNewsAndNotificationObject.WebLink);
			}
		}

		private void ShowiCloudUnauthenticated()
		{
			popupStack.PushPopup<LoadScreenInterruptionPopup>().Initialise(StringId.Options_iCloud, StringId.Options_iCloud_CacheIssue_NotSignedIn, null);
		}
	}
}
