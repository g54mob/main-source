using Factory;
using Motorways.Audio;
using Motorways.Leaderboards;
using Motorways.Models;
using Motorways.Processes;
using Motorways.UI;
using Popups;
using Screens;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class PauseScreen : InGameScalingScreen
	{
		[Dependency]
		private IScope _scope;

		[Dependency]
		private ISoftwareCapabilities _softwareCapabilities;

		[Dependency]
		private ChallengeSystem _challengeSystem;

		private Diagnostics.ReportUpload _reportUpload;

		public LocalizedTextUI exitButtonText;

		public SymbolOptionButton volumeToggle;

		public SymbolOptionButton nightmodeToggle;

		public TouchButton submitDiagnosticsReportButton;

		public NewsletterModal submitDiagnosticsReportModal;

		public TouchButton finishSubmittingReportButton;

		public TextMeshProUGUI reportIdLabel;

		public LocalizedTextUI restartButtonText;

		[SerializeField]
		private TouchButton _photoModeButton;

		[SerializeField]
		private TouchButton _challengeInfoButton;

		[SerializeField]
		private TouchButton _movieButton;

		[SerializeField]
		private TouchButton _endlessModeInfoButton;

		[SerializeField]
		private TouchButton _expertModeInfoButton;

		[SerializeField]
		private TouchButton _creativeModeInfoButton;

		[SerializeField]
		private TouchButton _cinematicModeButton;

		[SerializeField]
		private GameCenterAccessPointButton _gameCenterAccessPointButton;

		[Tooltip("How long in seconds the pause menu should fade in/out when it loses focus")]
		[SerializeField]
		private float _fadeDuration;

		[SerializeField]
		private TouchButton volumeToggleTouchButton;

		private GameStarter _customScreenGameStarter;

		private bool _changeBlurWhenTransitioning;

		private bool _fastFadeOut;

		private bool _shouldFadeIn;

		private bool _shouldFadeOut;

		private bool _restartGameWhenGainedFocus;

		public static readonly KeyCode[] SubmitReportKeySequence = new KeyCode[8]
		{
			KeyCode.D,
			KeyCode.I,
			KeyCode.N,
			KeyCode.O,
			KeyCode.H,
			KeyCode.E,
			KeyCode.L,
			KeyCode.P
		};

		private const float MaxTimeBetweenKeysInSeconds = 2f;

		private float _lastTimeKeyHitInSequence = float.MinValue;

		private int _nextKeyIndex;

		public override void OnCreatedInScope(IScope scope)
		{
			base.OnCreatedInScope(scope);
			_gameCenterAccessPointButton.Initialise(scope);
		}

		public void OnExit()
		{
			_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.Transition, UIAudioProfile.None, GetTransitionDuration(), condition: true, null, ScreenStack.MotorwaysScreen.MainMenu));
			_game.TrySave(GameJournalMotive.PlayerQuit);
			_game.StopAudio();
			_game.OnGameEnd(GameEndReason.Exit);
			_game.Scope.Get<GameUIScreen>().SetUIVisible(visible: false, instantly: false, forceHide: true);
			ScreenStack.MotorwaysScreen motorwaysScreen;
			if (!_screenStack.IsScreenActive<MainMenuScreen>())
			{
				motorwaysScreen = ScreenStack.MotorwaysScreen.MainMenu;
				_screenStack.ReplaceScreens<MainMenuScreen>(motorwaysScreen, typeof(GameContainerScreen));
			}
			else if (_gameScope.Get<City>().Rules is TutorialGameRules && _player.IsAnyTutorialCompleted)
			{
				if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
				{
					popupStack.PushPopup<AppleDemoCardPopup>().Initialise();
				}
				motorwaysScreen = ScreenStack.MotorwaysScreen.MainMenu;
				_screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.MainMenu);
			}
			else if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				popupStack.PushPopup<AppleDemoCardPopup>().Initialise();
				motorwaysScreen = ScreenStack.MotorwaysScreen.MainMenu;
				_screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.MainMenu);
			}
			else if (!_screenStack.IsScreenInStack<MapSelectScreen>())
			{
				motorwaysScreen = ScreenStack.MotorwaysScreen.MapSelect;
				_screenStack.ReplaceScreens(motorwaysScreen, delegate(MapSelectScreen mapSelectScreen)
				{
					mapSelectScreen.PrepareScreen(_game);
				}, typeof(GameContainerScreen));
			}
			else
			{
				motorwaysScreen = ScreenStack.MotorwaysScreen.MapSelect;
				_screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.MapSelect);
			}
			StartupScreen activeScreen = _screenStack.GetActiveScreen<StartupScreen>();
			float duration = _screenStack.GetTransitionDetailsFrom(base.ScreenType, motorwaysScreen).duration;
			if (activeScreen != null)
			{
				_themeDatabase.SetCurrentMapDefinition(activeScreen.mapDefinition, duration);
			}
			if (_gameScope.Get<City>().Rules is TutorialGameRules)
			{
				TutorialProgressionProcess tutorialProgressionProcess = _game.Scope.Get<TutorialProgressionProcess>();
				_player.SetTutorialTypeComplete(TutorialProgressionProcess.TutorialTypeForInputType(_inputState.CurrentDeviceInputType));
				tutorialProgressionProcess.SkipTutorial();
			}
		}

		public void OnResume()
		{
			_screenStack.PopOneScreen();
			MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles, _scope);
			_appScope.Get<ISoftwareCapabilities>().SetIsInGame(isInGame: true);
		}

		public void OnRestart()
		{
			bool flag = true;
			ActiveChallengesModel model = _simulation.GetModel<ActiveChallengesModel>();
			MotorwaysTimedChallengeScore challengeScore = _player.GetChallengeScore(MapChallenge.ChallengeType.Daily, _challengeSystem.DailyChallenge.TimeEnd);
			if (model.challengeType == MapChallenge.ChallengeType.Daily && challengeScore.ScoreState != LeaderboardScoreState.Locked)
			{
				flag = false;
				popupStack.PushPopup<ConfirmationPopup>().Initialise(_appScope, StringId.DailyChallenge, null, delegate
				{
					_restartGameWhenGainedFocus = true;
				}, StringId.DailyChallenge_RestartConfirmation);
			}
			if (_gameScope.Get<City>().Rules is TutorialGameRules)
			{
				_game.Scope.Get<TutorialProgressionProcess>().UnregisterActions();
			}
			if (flag)
			{
				RestartGame();
			}
		}

		public void OnPause()
		{
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.OptionsPause);
		}

		private void RestartGame()
		{
			_game.OnGameEnd(GameEndReason.Restart);
			GameContainerScreen activeScreen = _screenStack.GetActiveScreen<GameContainerScreen>();
			if (Diagnostics.Verify(activeScreen != null, "We don't have an active GameContainerScreen even though we're at the PauseScreen!"))
			{
				GameMode startedWithGameMode = _gameScope.Get<MotorwaysGame>().StartedWithGameMode;
				activeScreen.PrepareForRestartMap(startedWithGameMode);
			}
			MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles, _scope);
			_screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.InGame);
			activeScreen.SkipNextTransition();
			MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles, _scope);
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			_changeBlurWhenTransitioning = inScreen != ScreenStack.MotorwaysScreen.ChallengeInfo && inScreen != ScreenStack.MotorwaysScreen.OptionsPause;
			_fastFadeOut = inScreen != ScreenStack.MotorwaysScreen.InGame && inScreen != ScreenStack.MotorwaysScreen.ChallengeInfo && inScreen != ScreenStack.MotorwaysScreen.OptionsPause;
			submitDiagnosticsReportModal.HideModal();
			base.TransitionOut(inScreen);
			_skipTransitions = (inScreen != ScreenStack.MotorwaysScreen.InGame && _skipTransitions) || inScreen == ScreenStack.MotorwaysScreen.ChallengeInfo || inScreen == ScreenStack.MotorwaysScreen.OptionsPause;
			_gameCenterAccessPointButton.Hide();
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			base.TransitionIn(outScreen);
			_skipTransitions = false;
			_canvasGroup.Alpha = 0f;
			restartButtonText.SetStringId(_scope, GetRestartText(_game));
			_changeBlurWhenTransitioning = outScreen != ScreenStack.MotorwaysScreen.ChallengeInfo && outScreen != ScreenStack.MotorwaysScreen.OptionsPause && outScreen != ScreenStack.MotorwaysScreen.CinematicMode;
			if (_gameScope.Get<City>().Rules is TutorialGameRules && !_player.IsAnyTutorialCompleted)
			{
				exitButtonText.LocString = StandaloneLocString.CreateString(_gameScope, StringId.SkipTutorial);
			}
			else
			{
				exitButtonText.LocString = StandaloneLocString.CreateString(_gameScope, StringId.MainMenu);
			}
			MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.PauseScreen, _scope, MotorwaysInGameStateToggleController.StateSwapActionBehaviour.CancelActions);
			_appScope.Get<ISoftwareCapabilities>().SetIsInGame(isInGame: false);
			UpdateButtonStates();
			GameUIScreen gameUIScreen = _gameScope.Get<GameUIScreen>();
			gameUIScreen.SetUIVisible(visible: false);
			gameUIScreen.ExitEditModeUI();
			_photoModeButton.gameObject.SetActive(_softwareCapabilities.CanShareImage);
			_challengeInfoButton.gameObject.SetActive(_game.Simulation.GetModel<ActiveChallengesModel>().HasChallenges);
			GameMode mode = _gameScope.Get<CityModel>().Mode;
			_cinematicModeButton.gameObject.SetActive(mode != GameMode.Tutorial);
			bool flag = mode == GameMode.Endless;
			_endlessModeInfoButton.gameObject.SetActive(flag);
			bool flag2 = mode == GameMode.Expert;
			_expertModeInfoButton.gameObject.SetActive(flag2);
			bool flag3 = mode == GameMode.Creative;
			_creativeModeInfoButton.gameObject.SetActive(flag3);
			_movieButton.gameObject.SetActive(_softwareCapabilities.CanShareImage && _softwareCapabilities.SupportsMovieScreen);
			if (_gameScope.Get<City>().Rules is TutorialGameRules)
			{
				TutorialProgressionProcess tutorialProgressionProcess = _gameScope.Get<TutorialProgressionProcess>();
				if (tutorialProgressionProcess.HasVisibleMessage)
				{
					tutorialProgressionProcess.TemporarilyHideMessage();
				}
				_movieButton.gameObject.SetActive(value: false);
				_photoModeButton.gameObject.SetActive(value: false);
			}
			_gameScope.Get<CameraView>().ResetPlayerViewport();
			RegisterThemeComponents(_themeDatabase.GetTheme());
			_reportUpload = null;
			SetupNavigationOnBottomRightButtons(flag, flag2, flag3);
		}

		public static StringId GetRestartText(MotorwaysGame game)
		{
			switch (game.StartedWithGameMode)
			{
			case GameMode.Normal:
			{
				ActiveChallengesModel activeChallengesModel = game.Scope.Get<ActiveChallengesModel>();
				if (activeChallengesModel.challengeType == MapChallenge.ChallengeType.Daily)
				{
					return StringId.Replay_Challenge;
				}
				if (activeChallengesModel.challengeType == MapChallenge.ChallengeType.City || activeChallengesModel.challengeType == MapChallenge.ChallengeType.Weekly)
				{
					return StringId.Restart_Challenge;
				}
				return StringId.Restart_Classic;
			}
			case GameMode.Endless:
				return StringId.Restart_Endless;
			case GameMode.Expert:
				return StringId.Restart_Expert;
			default:
				return StringId.Restart;
			}
		}

		public override void TransitionInTick()
		{
			base.TransitionInTick();
			if (_changeBlurWhenTransitioning)
			{
				_gameCamera.customBlur.Strength = TransitionInPercentage();
			}
			_canvasGroup.Alpha = TransitionInPercentage();
		}

		public override void TransitionOutTick()
		{
			base.TransitionOutTick();
			if (_changeBlurWhenTransitioning)
			{
				_gameCamera.customBlur.Strength = 1f - TransitionOutPercentage();
			}
			float num = TransitionOutPercentage();
			if (_fastFadeOut)
			{
				num *= 4f;
			}
			_canvasGroup.Alpha = 1f - num;
		}

		public override void OnTransitionedIn()
		{
			base.OnTransitionedIn();
			_gameCenterAccessPointButton.Show();
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
			if (_customScreenGameStarter != null && _customScreenGameStarter.CanStart)
			{
				_customScreenGameStarter.Start(_screenStack, _scope);
				_customScreenGameStarter = null;
			}
		}

		public override void OnLostFocus()
		{
			base.OnLostFocus();
			_shouldFadeIn = false;
			_shouldFadeOut = true;
		}

		public override void OnGainedFocus()
		{
			base.OnGainedFocus();
			_shouldFadeIn = true;
			_shouldFadeOut = false;
			if (_restartGameWhenGainedFocus)
			{
				_restartGameWhenGainedFocus = false;
				RestartGame();
			}
		}

		public void OnPhotoMode()
		{
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.Photo, additive: false, _gameScope);
		}

		public void OnMovieButtonPressed()
		{
			MotorwaysGameJournalSave motorwaysGameJournalSave = _gameScope.Get<MotorwaysGameJournalSave>();
			if (motorwaysGameJournalSave.InitializeFromSimulation(_simulation, GameJournalMotive.PlayerQuit))
			{
				if (_customScreenGameStarter == null)
				{
					_customScreenGameStarter = new GameStarter(this);
				}
				MapDatabase mapDatabase = _appScope.Get<MapDatabase>();
				_customScreenGameStarter.StartSavedGameFromCustomScreen(mapDatabase.MapLibrary, motorwaysGameJournalSave, ScreenStack.MotorwaysScreen.Movie);
			}
		}

		public void OnCinematicModeButtonPressed()
		{
			if (_game.StartedWithGameMode == GameMode.Endless)
			{
				_screenStack.PushScreen(ScreenStack.MotorwaysScreen.CinematicMode, additive: true, _gameScope);
				return;
			}
			MotorwaysGameJournalSave motorwaysGameJournalSave = _gameScope.Get<MotorwaysGameJournalSave>();
			if (motorwaysGameJournalSave.InitializeFromSimulation(_simulation, GameJournalMotive.PlayerQuit))
			{
				if (_customScreenGameStarter == null)
				{
					_customScreenGameStarter = new GameStarter(this);
				}
				MapDatabase mapDatabase = _appScope.Get<MapDatabase>();
				_customScreenGameStarter.StartSavedGameFromCustomScreen(mapDatabase.MapLibrary, motorwaysGameJournalSave, ScreenStack.MotorwaysScreen.CinematicMode);
			}
			else
			{
				Diagnostics.FailAssert("Cinematic mode failed to start from pause screen. Likely due to save not initializing correctly.");
			}
		}

		public void OnNightModeButtonToggled(bool toggleOn)
		{
			_themeDatabase.SetNightMode(toggleOn, forceBlend: true);
		}

		public void OnChallengesButton()
		{
			ActiveChallengesModel challengeModel = _game.Simulation.GetModel<ActiveChallengesModel>();
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.ChallengeInfo, delegate(ChallengeInfoScreen screen)
			{
				screen.PrepareScreen(challengeModel.challengeType, challengeModel.challenges, challengeModel.timeStart, challengeModel.timeEnd, StringId.Continue, changeBlurWhenTransitioning: false, showBackButton: true, _game.Scope);
			});
		}

		public void OnModeInfoButton()
		{
			popupStack.PushPopup<ModeInfoPopupInGame>().Initialize(_appScope, _game.Scope.Get<CityModel>().Mode, delegate
			{
				_appScope.Get<InputState>().BlockGameInput = _blocksGameInput;
			});
		}

		public void OnVolumeButtonToggled(bool toggledOn)
		{
			int volumeSetting = (toggledOn ? _player.PreviousVolumeSetting : 0);
			_player.VolumeSetting = volumeSetting;
		}

		public void OnSubmitDiagnosticsReport()
		{
			if (_reportUpload == null && !(_scope.Get<IAppCommandSource>() is JournalAppCommandSource))
			{
				submitDiagnosticsReportModal.ShowModal();
				finishSubmittingReportButton.interactable = false;
				_canvasGroup.SetInteractable(isInteractable: false);
				previousBackButton = backButton;
				backButton = finishSubmittingReportButton;
				_navigation.SetNewFocus(finishSubmittingReportButton);
				reportIdLabel.text = "Submitting...";
				Diagnostics.Report report = _game.GenerateDiagnosticReport("manual", DiagnosticReportAttachments.SimCommandJournal | DiagnosticReportAttachments.SimArchive | DiagnosticReportAttachments.Screenshot | DiagnosticReportAttachments.Log);
				_reportUpload = report.Upload();
			}
		}

		private void UpdateButtonStates()
		{
			nightmodeToggle.SetOption(_themeDatabase.IsInNightMode ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			volumeToggle.gameObject.SetActive(_audioSystem.RequiresVolumeControl);
			volumeToggle.SetOption((_player.VolumeSetting != 0) ? 1 : 0, invokeMethod: true, invokeTriggerMethod: false);
			if (FeatureToggle.IsFeatureEnabled(Feature.DiagnosticReportsButton))
			{
				submitDiagnosticsReportButton.gameObject.SetActive(value: true);
			}
			else
			{
				submitDiagnosticsReportButton.gameObject.SetActive(value: false);
			}
		}

		public override bool CanTransitionIn()
		{
			return !_screenStack.AreAnyScreensTransitioning;
		}

		public override void Reset()
		{
			base.Reset();
			_changeBlurWhenTransitioning = false;
			_shouldFadeIn = false;
			_shouldFadeOut = false;
			_fastFadeOut = false;
		}

		private void OnEnable()
		{
			_canvasGroup.Alpha = 0f;
		}

		public void Update()
		{
			if (_reportUpload != null)
			{
				string text = "Uploading metadata ...";
				if (_reportUpload.IsComplete)
				{
					text = $"Done!\nReport id: {_reportUpload.Id}";
				}
				else if (_reportUpload.Id > 0)
				{
					text = $"Report id: {_reportUpload.Id}\nUploaded {Mathf.Max(1, _reportUpload.BytesUploaded / 1024)} KiB / {Mathf.Max(1, _reportUpload.BytesToUpload / 1024)} KiB";
				}
				reportIdLabel.text = text;
				if (_reportUpload.IsComplete)
				{
					finishSubmittingReportButton.interactable = true;
					backButton = previousBackButton;
					_navigation.SetNewFocus(finishSubmittingReportButton);
					_reportUpload = null;
				}
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.ToggleDiagnosticReportButtonWithKeyCode))
			{
				SubmitReportButtonKeySequenceCheck();
			}
		}

		private void SubmitReportButtonKeySequenceCheck()
		{
			if (Input.GetKeyDown(SubmitReportKeySequence[_nextKeyIndex]))
			{
				_lastTimeKeyHitInSequence = Time.time;
				_nextKeyIndex++;
				if (_nextKeyIndex >= SubmitReportKeySequence.Length)
				{
					submitDiagnosticsReportButton.gameObject.SetActive(!submitDiagnosticsReportButton.gameObject.activeSelf);
					_lastTimeKeyHitInSequence = float.MinValue;
					_nextKeyIndex = 0;
				}
			}
			else if (Input.anyKeyDown)
			{
				_lastTimeKeyHitInSequence = float.MinValue;
				_nextKeyIndex = 0;
			}
			if (_lastTimeKeyHitInSequence > float.MinValue && Time.time - _lastTimeKeyHitInSequence > 2f)
			{
				_lastTimeKeyHitInSequence = float.MinValue;
				_nextKeyIndex = 0;
			}
		}

		private void SetupNavigationOnBottomRightButtons(bool showEndlessModeInfoButton, bool showExpertModeInfoButton, bool showCreativeModeInfoButton)
		{
			if (showEndlessModeInfoButton)
			{
				SetNavigationOnLeftMostButton(_endlessModeInfoButton);
			}
			else if (showExpertModeInfoButton)
			{
				SetNavigationOnLeftMostButton(_expertModeInfoButton);
			}
			else if (showCreativeModeInfoButton)
			{
				SetNavigationOnLeftMostButton(_creativeModeInfoButton);
			}
			else if (_game.Simulation.GetModel<ActiveChallengesModel>().HasChallenges)
			{
				SetNavigationOnLeftMostButton(_challengeInfoButton);
			}
			else
			{
				SetNavigationOnLeftMostButton(_cinematicModeButton);
			}
		}

		private void SetNavigationOnLeftMostButton(TouchButton leftMostButton)
		{
			BaseScalingScreen.SetNavigationOnDown(volumeToggleTouchButton, leftMostButton);
			BaseScalingScreen.SetNavigationOnRight(volumeToggleTouchButton, leftMostButton);
			BaseScalingScreen.SetNavigationOnUp(leftMostButton, volumeToggleTouchButton);
		}
	}
}
