using System.Collections;
using System.Collections.Generic;
using Client;
using Easing;
using Factory;
using Factory.Pools;
using Motorways.Models;
using Motorways.Processes;
using Motorways.UI;
using NaughtyAttributes;
using Popups;
using Screens;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class GameOverScreen : InGameScalingScreen, IReusable
	{
		[Dependency]
		private IScope _scope;

		[Dependency]
		private ISoftwareCapabilities _softwareCapabilities;

		[SerializeField]
		private float _timeToFillText = 1f;

		[SerializeField]
		private float _buttonAnimationDelay = 2f;

		[SerializeField]
		private float _challengeIconsAdditionalDelay = 1f;

		[SerializeField]
		private float _delayToFillText = 1f;

		[SerializeField]
		private float _timeToFillButton = 0.25f;

		[SerializeField]
		private float _timeToAlphaButtonText = 0.25f;

		[SerializeField]
		private ChallengeIcon[] _challengeIcons;

		[SerializeField]
		private Animator _challengeIconContainer;

		private static readonly int AnimateInStateID = Animator.StringToHash("AnimateIn");

		private static readonly int NormalTriggerID = Animator.StringToHash("Normal");

		[SerializeField]
		private Animator _uiPing;

		private static readonly int PingTriggerID = Animator.StringToHash("Ping");

		[SerializeField]
		private FloatingElement _gameOverTextContainer;

		public Vector3 focusPoint;

		public LocalizedTextUI textTitle;

		public LocalizedTextUI textLineOne;

		public LocalizedTextUI textLineTwo;

		public LocalizedTextUI restartButtonText;

		public LocalizedTextUI exitButtonText;

		public LocalizedTextUI continueInEndlessText;

		public TouchButton restartButton;

		public TouchButton exitButton;

		public TouchButton continueInEndlessButton;

		public GameObject photoModeButtonAnchor;

		public TouchButton photoModeButton;

		private float _soakTestCountdown = -1f;

		private bool _hasSoakTestTransitionedOut;

		private Diagnostics.ReportUpload _reportUpload;

		public TouchButton submitDiagnosticsReportButton;

		public NewsletterModal submitDiagnosticsReportModal;

		public TouchButton finishSubmittingReportButton;

		public TextMeshProUGUI reportIdLabel;

		private const string TransitionDetails = "Transition Details";

		[FoldoutGroup("Transition Details")]
		public AnimationCurve movementTransitionCurve;

		[FoldoutGroup("Transition Details")]
		public AnimationCurve rotationTransitionCurve;

		[FoldoutGroup("Transition Details")]
		public AnimationCurve zoomTransitionCurve;

		[FoldoutGroup("Transition Details")]
		public AnimationCurve blurTransitionCurve;

		public Vector2 scalingReferenceResolution = new Vector2(1920f, 1080f);

		private bool _doTransitionAnimation;

		private bool _hasNewHighScore;

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			base.TransitionIn(outScreen);
			_doTransitionAnimation = outScreen != ScreenStack.MotorwaysScreen.ChallengeInfo;
			bool flag = _gameScope.Get<City>().Rules is TutorialGameRules;
			_skipTransitions = false;
			if (flag)
			{
				restartButton.gameObject.SetActive(value: false);
				continueInEndlessButton.gameObject.SetActive(value: false);
				firstFocus = exitButton;
			}
			else
			{
				restartButton.gameObject.SetActive(value: true);
				continueInEndlessButton.gameObject.SetActive(value: true);
				firstFocus = restartButton;
			}
			restartButtonText.SetStringId(_appScope, PauseScreen.GetRestartText(_game));
			if (_doTransitionAnimation)
			{
				restartButton.image.fillAmount = 0f;
				exitButton.image.fillAmount = 0f;
				continueInEndlessButton.image.fillAmount = 0f;
			}
			ActiveChallengesModel model = _game.Simulation.GetModel<ActiveChallengesModel>();
			if (outScreen == ScreenStack.MotorwaysScreen.InGame)
			{
				_game.OnGameEnd(GameEndReason.GameOver);
				foreach (NewUpgradeAnimationView view in _gameScope.Get<ViewClient>().GetViews<NewUpgradeAnimationView>())
				{
					view.Hide();
				}
				MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.OutOfGame, _gameScope, MotorwaysInGameStateToggleController.StateSwapActionBehaviour.CancelActions);
				ScoreModel scoreModel = _gameScope.Get<ScoreModel>();
				ClockModel clockModel = _gameScope.Get<ClockModel>();
				GameRules rules = _game.Scope.Get<City>().Rules;
				MotorwaysStringKey motorwaysStringKey = _gameScope.Get<MotorwaysStringKey>();
				motorwaysStringKey.InitWithStringId(rules.GetGameOverLineOne(), clockModel.Day);
				MotorwaysStringKey motorwaysStringKey2 = _gameScope.Get<MotorwaysStringKey>();
				motorwaysStringKey2.InitWithStringId(rules.GetGameOverLineTwo(), scoreModel.Score, new Dictionary<string, string>
				{
					{
						"Num",
						scoreModel.Score.ToString()
					},
					{
						"Day",
						clockModel.Day.ToString()
					}
				});
				textLineOne.LocString = StandaloneLocString.CreateString(_gameScope, motorwaysStringKey);
				textLineTwo.LocString = StandaloneLocString.CreateString(_gameScope, motorwaysStringKey2);
				textLineOne.gameObject.SetActive(!flag);
				textLineTwo.TextField.maxVisibleCharacters = 0;
				StringId fromKey = StringId.GameOver;
				StringId fromKey2 = StringId.Menu;
				if (flag)
				{
					fromKey = StringId.Tutorial_Completed;
					fromKey2 = StringId.GameOver_Tutorial_MenuButton;
				}
				else if (model.HasChallenges)
				{
					if (model.challengeType == MapChallenge.ChallengeType.Daily)
					{
						fromKey = StringId.DailyChallenge;
					}
					else if (model.challengeType == MapChallenge.ChallengeType.Weekly)
					{
						fromKey = StringId.WeeklyChallenge;
					}
					else if (model.challengeType == MapChallenge.ChallengeType.City)
					{
						_ = _game.MapDefinition.cityChallenges[model.cityChallengeIndex].titleStringId;
					}
				}
				textTitle.LocString = StandaloneLocString.CreateString(_gameScope, fromKey);
				exitButtonText.LocString = StandaloneLocString.CreateString(_gameScope, fromKey2);
				continueInEndlessText.LocString = StandaloneLocString.CreateString(_gameScope, StringId.ContinueInEndless);
				CityModel model2 = _game.Simulation.GetModel<CityModel>();
				int num = scoreModel.Score + 1;
				if (model.HasChallenges)
				{
					if (model.challengeType == MapChallenge.ChallengeType.City)
					{
						num = _player.GetCityChallengeScore(model2.cityName, model2.Mode, model.cityChallengeIndex).BestScore;
					}
					else if (model.challengeType == MapChallenge.ChallengeType.Weekly)
					{
						num = _player.GetChallengeScore(MapChallenge.ChallengeType.Weekly, model.timeEnd).Score;
					}
				}
				else
				{
					MotorwaysCityStatistics cityStatisticsForCity = _player.GetCityStatisticsForCity(model2.cityName, model2.Mode);
					if (cityStatisticsForCity != null)
					{
						num = cityStatisticsForCity.MaxTrips;
					}
				}
				_hasNewHighScore = scoreModel.Score == num;
			}
			if (_doTransitionAnimation)
			{
				photoModeButtonAnchor.SetActive(value: false);
				photoModeButton.interactable = _softwareCapabilities.CanShareImage;
			}
			for (int i = 0; i < _challengeIcons.Length; i++)
			{
				if (i < model.challenges.Count)
				{
					ChallengeData challengeData = model.challenges[i];
					_challengeIcons[i].gameObject.SetActive(value: true);
					_challengeIcons[i].SetChallengeIcons(challengeData.icon, isWildcardChallenge: false, challengeData.subIcon, challengeData.subIconBackground);
				}
				else
				{
					_challengeIcons[i].gameObject.SetActive(value: false);
				}
			}
			if (_doTransitionAnimation)
			{
				_challengeIconContainer.gameObject.SetActive(value: false);
				restartButtonText.TextField.alpha = 0f;
				continueInEndlessText.TextField.alpha = 0f;
				exitButtonText.TextField.alpha = 0f;
			}
			GameUIScreen gameUIScreen = _gameScope.Get<GameUIScreen>();
			gameUIScreen.SetUIVisible(visible: false, instantly: false, forceHide: true, forceHideWorldGrid: true);
			gameUIScreen.SetRoadCursorActive(active: false);
			if (gameUIScreen.IsFocusPointActive)
			{
				gameUIScreen.SetFocusPointActive(active: false);
			}
			if (flag)
			{
				_player.SetTutorialTypeComplete(TutorialProgressionProcess.TutorialTypeForInputType(_inputState.CurrentDeviceInputType));
			}
			_appScope.Get<ISoftwareCapabilities>().SetIsInGame(isInGame: false);
			if (FeatureToggle.IsFeatureEnabled(Feature.DiagnosticReportsButton))
			{
				submitDiagnosticsReportButton.gameObject.SetActive(!flag);
			}
			else
			{
				submitDiagnosticsReportButton.gameObject.SetActive(value: false);
			}
			_soakTestCountdown = 4f;
			_reportUpload = null;
			LayoutRebuilder.ForceRebuildLayoutImmediate(_gameOverTextContainer.GetComponent<RectTransform>());
			_gameOverTextContainer.Snap();
		}

		public override void OnTransitionedIn()
		{
			if (_doTransitionAnimation)
			{
				FireAllAnimations();
			}
			else
			{
				base.OnTransitionedIn();
			}
		}

		public override void OnTransitionedOut()
		{
			base.OnTransitionedOut();
			if (_doTransitionAnimation)
			{
				textLineTwo.TextField.maxVisibleCharacters = 0;
			}
		}

		private void FireAllAnimations()
		{
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: false);
			_canvasGroup.SetInteractable(isInteractable: false);
			StartCoroutine(AnimateFillText(textLineTwo));
			if (_hasNewHighScore)
			{
				StartCoroutine(AnimatePing(_delayToFillText, textLineTwo));
			}
			ActiveChallengesModel model = _game.Simulation.GetModel<ActiveChallengesModel>();
			float num = _buttonAnimationDelay;
			if (model.HasChallenges)
			{
				StartCoroutine(EnableChallengeButtons(num));
				num += _challengeIconsAdditionalDelay;
			}
			else
			{
				_challengeIconContainer.gameObject.SetActive(value: false);
			}
			StartCoroutine(AnimateButtonFill(num, restartButton));
			StartCoroutine(AnimateButtonText(num + _timeToAlphaButtonText, restartButtonText));
			StartCoroutine(AnimateButtonFill(num + _timeToFillButton, continueInEndlessButton));
			StartCoroutine(AnimateButtonText(num + _timeToFillButton + _timeToAlphaButtonText, continueInEndlessText));
			StartCoroutine(AnimateButtonFill(num + _timeToFillButton * 2f, exitButton));
			StartCoroutine(AnimateButtonText(num + _timeToFillButton * 2f + _timeToAlphaButtonText, exitButtonText));
			StartCoroutine(EnablePhotoModeButton(num + _timeToFillButton * 2f + _timeToAlphaButtonText));
			StartCoroutine(EnableScreenInteraction(num + _timeToFillButton * 2f + _timeToAlphaButtonText));
		}

		private IEnumerator EnableChallengeButtons(float delay)
		{
			yield return new WaitForSeconds(delay);
			_challengeIconContainer.gameObject.SetActive(value: true);
			_challengeIconContainer.Play(AnimateInStateID);
			_challengeIconContainer.ResetTrigger(NormalTriggerID);
		}

		private IEnumerator EnablePhotoModeButton(float delay)
		{
			yield return new WaitForSeconds(delay);
			if (_softwareCapabilities.CanShareImage)
			{
				bool flag = _gameScope.Get<City>().Rules is TutorialGameRules;
				photoModeButtonAnchor.SetActive(!flag);
				photoModeButton.interactable = !flag && _softwareCapabilities.CanShareImage;
			}
		}

		private IEnumerator EnableScreenInteraction(float delay)
		{
			yield return new WaitForSeconds(delay);
			base.OnTransitionedIn();
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: true);
			_canvasGroup.SetInteractable(isInteractable: true);
		}

		private IEnumerator AnimateFillText(LocalizedTextUI text)
		{
			text.TextField.maxVisibleCharacters = 0;
			yield return new WaitForSeconds(_delayToFillText);
			int textLength = text.TextField.text.Length;
			if (textLength > 0)
			{
				float step = _timeToFillText / (float)textLength;
				while (textLength > text.TextField.maxVisibleCharacters)
				{
					text.TextField.maxVisibleCharacters++;
					yield return new WaitForSeconds(step);
				}
			}
		}

		private IEnumerator AnimatePing(float delay, LocalizedTextUI text)
		{
			yield return new WaitForSeconds(delay);
			_uiPing.SetTrigger(PingTriggerID);
		}

		private IEnumerator AnimateButtonFill(float delay, TouchButton button)
		{
			button.image.fillAmount = 0f;
			yield return new WaitForSeconds(delay);
			float runningTime = 0f;
			while (button.image.fillAmount < 1f)
			{
				runningTime += Time.deltaTime;
				button.image.fillAmount = Mathf.Lerp(0f, 1f, runningTime / _timeToFillButton);
				yield return new WaitForFixedUpdate();
			}
		}

		private IEnumerator AnimateButtonText(float delay, LocalizedTextUI button)
		{
			button.TextField.alpha = 0f;
			yield return new WaitForSeconds(delay);
			float runningTime = 0f;
			while (button.TextField.alpha < 1f)
			{
				runningTime += Time.deltaTime;
				button.TextField.alpha = Mathf.Lerp(0f, 1f, runningTime / _timeToFillButton);
				yield return new WaitForFixedUpdate();
			}
		}

		private void SetupWorldSpaceCanvas(float endZoom)
		{
			float num = endZoom * 2f / (float)Screen.height;
			num *= (float)Screen.height / scalingReferenceResolution.y;
			float num2 = (float)Screen.width / (float)Screen.height;
			_rectTransform.sizeDelta = new Vector2(scalingReferenceResolution.y * num2, scalingReferenceResolution.y);
			base.transform.localScale = num * Vector3.one;
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
			if (!FeatureToggle.IsFeatureEnabled(Feature.SoakTest) || IsTransitioningIn() || IsTransitioningOut() || _hasSoakTestTransitionedOut || !(_soakTestCountdown > 0f))
			{
				return;
			}
			_soakTestCountdown -= deltaTime;
			if ((int)_soakTestCountdown != (int)(_soakTestCountdown + deltaTime))
			{
				Diagnostics.Log.Message(Diagnostics.Log.Level.Info, "Soak", "GameOverScreen.Tick() soak countdown down to {0}.", _soakTestCountdown);
			}
			if (_soakTestCountdown <= 0f)
			{
				_soakTestCountdown = 2f;
				if (Random.Bool())
				{
					Diagnostics.Log.Message(Diagnostics.Log.Level.Info, "Soak", "GameOverScreen restarting.");
					OnRestart();
				}
				else
				{
					Diagnostics.Log.Message(Diagnostics.Log.Level.Info, "Soak", "GameOverScreen quitting.");
					OnQuit();
				}
			}
		}

		public override void Reset()
		{
			base.Reset();
			_doTransitionAnimation = false;
			focusPoint = default(Vector3);
			_soakTestCountdown = -1f;
			_hasSoakTestTransitionedOut = false;
			_hasNewHighScore = false;
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
		}

		public void OnChallengeButtonsPressed()
		{
			ActiveChallengesModel challengeModel = _game.Simulation.GetModel<ActiveChallengesModel>();
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.ChallengeInfo, delegate(ChallengeInfoScreen screen)
			{
				screen.PrepareScreen(challengeModel.challengeType, challengeModel.challenges, challengeModel.timeStart, challengeModel.timeEnd, StringId.Continue, changeBlurWhenTransitioning: false, showBackButton: true, _game.Scope);
			});
		}

		public override void TransitionInTick()
		{
			float time = TransitionInPercentage();
			float num = blurTransitionCurve.Evaluate(time);
			_canvasGroup.Alpha = num;
			if (_gameOverTextContainer.IsAnimating)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(_gameOverTextContainer.GetComponent<RectTransform>());
				_gameOverTextContainer.Snap();
			}
			if (!_doTransitionAnimation)
			{
				time = 1f;
				num = blurTransitionCurve.Evaluate(time);
			}
			float t = movementTransitionCurve.Evaluate(time);
			Vector3 b = Vector3.Lerp(_transitionDetails.spline.inPoint, focusPoint, t);
			b = Vector3.Lerp(_gameCamera.transform.position, b, TransitionInPercentage() * 5f);
			_gameCamera.SetPosition(b);
			float time2 = rotationTransitionCurve.Evaluate(time);
			_gameCamera.transform.rotation = _transitionDetails.spline.EvaluateRotation(time2);
			float zoomFor = _screenStack.GetZoomFor(base.ScreenType);
			float t2 = zoomTransitionCurve.Evaluate(time);
			_gameCamera.OrthographicSize = Mathf.Lerp(_previousCameraZoom, zoomFor, t2);
			b = _transitionDetails.spline.outPoint;
			b.z = base.transform.position.z;
			base.transform.position = b;
			base.transform.rotation = _transitionDetails.spline.endRotation;
			SetupWorldSpaceCanvas(zoomFor);
			_gameCamera.customBlur.Strength = num;
			_navigation.SetNewFocus(null);
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			base.TransitionOut(inScreen);
			_doTransitionAnimation = inScreen != ScreenStack.MotorwaysScreen.ChallengeInfo;
			_alignToCamera = false;
			_scaleToCamera = false;
			if (_doTransitionAnimation)
			{
				photoModeButtonAnchor.SetActive(value: false);
			}
			_skipTransitions = _skipTransitions && inScreen != ScreenStack.MotorwaysScreen.Photo && inScreen != ScreenStack.MotorwaysScreen.InGame;
			_hasSoakTestTransitionedOut = true;
			submitDiagnosticsReportModal.HideModal();
		}

		public override void TransitionOutTick()
		{
			base.TransitionOutTick();
			float num = Easings.QuarticEaseIn(Mathf.Clamp01((1f - TransitionOutPercentage()) * 2f - 0.5f));
			_canvasGroup.Alpha = num;
			if (_doTransitionAnimation)
			{
				_gameCamera.customBlur.Strength = num;
			}
		}

		public void OnCameraMode()
		{
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.Photo, additive: false, _gameScope);
		}

		public void OnRestart()
		{
			GameContainerScreen activeScreen = _screenStack.GetActiveScreen<GameContainerScreen>();
			MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles, _gameScope);
			if (Diagnostics.Verify(activeScreen != null, "We don't have an active GameContainerScreen even though we're at the GameOverScreen!"))
			{
				GameMode startedWithGameMode = _gameScope.Get<MotorwaysGame>().StartedWithGameMode;
				activeScreen.PrepareForRestartMap(startedWithGameMode);
			}
			_canvasGroup.Alpha = 0f;
			_screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.InGame);
			_appScope.Get<ISoftwareCapabilities>().SetIsInGame(isInGame: true);
		}

		public void OnContinueInEndless()
		{
			GameContainerScreen activeScreen = _screenStack.GetActiveScreen<GameContainerScreen>();
			MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles, _gameScope);
			if (Diagnostics.Verify(activeScreen != null, "We don't have an active GameContainerScreen even though we're at the GameOverScreen!"))
			{
				activeScreen.PrepareForContinueInEndless();
			}
			_canvasGroup.Alpha = 0f;
			_screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.InGame);
			_appScope.Get<ISoftwareCapabilities>().SetIsInGame(isInGame: true);
			_gameScope.Get<GameUIScreen>().ResetForceHiddenState();
			_gameScope.Get<ScoreModel>().ResetForEndless();
		}

		public void OnQuit()
		{
			_game.StopAudio();
			ScreenStack.MotorwaysScreen motorwaysScreen;
			if (_gameScope.Get<City>().Rules is TutorialGameRules)
			{
				if (!_screenStack.IsScreenActive<MainMenuScreen>())
				{
					motorwaysScreen = ScreenStack.MotorwaysScreen.MainMenu;
					_screenStack.ReplaceScreens<MainMenuScreen>(motorwaysScreen, typeof(GameContainerScreen));
				}
				else
				{
					motorwaysScreen = _screenStack.GetScreenTypeBelowScreenType(ScreenStack.MotorwaysScreen.InGame);
					_screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.InGame, inclusive: true);
				}
			}
			else if (!_screenStack.IsScreenActive<MapSelectScreen>())
			{
				motorwaysScreen = ScreenStack.MotorwaysScreen.MapSelect;
				_screenStack.ReplaceScreens(motorwaysScreen, delegate(MapSelectScreen mapSelectScreen)
				{
					mapSelectScreen.PrepareScreen(_game);
				}, typeof(GameContainerScreen));
			}
			else if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				popupStack.PushPopup<AppleDemoCardPopup>().Initialise();
				motorwaysScreen = ScreenStack.MotorwaysScreen.MainMenu;
				_screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.MainMenu);
			}
			else
			{
				motorwaysScreen = _screenStack.GetScreenTypeBelowScreenType(ScreenStack.MotorwaysScreen.InGame);
				_screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.InGame, inclusive: true);
			}
			StartupScreen activeScreen = _screenStack.GetActiveScreen<StartupScreen>();
			float duration = _screenStack.GetTransitionDetailsFrom(base.ScreenType, motorwaysScreen).duration;
			if (activeScreen != null)
			{
				_themeDatabase.SetCurrentMapDefinition(activeScreen.mapDefinition, duration);
			}
			_appScope.Get<ISoftwareCapabilities>().SetIsInGame(isInGame: false);
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
	}
}
