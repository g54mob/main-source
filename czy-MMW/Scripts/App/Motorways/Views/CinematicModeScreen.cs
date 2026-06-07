using System;
using System.Collections.Generic;
using Client;
using Factory;
using Motorways.Audio;
using Motorways.Models;
using Motorways.UI;
using UnityEngine;

namespace Motorways.Views
{
	public class CinematicModeScreen : OverlayBaseScreen, IGameStartScreen
	{
		[Dependency]
		private VisualConstantsData _visualConstantsData;

		[SerializeField]
		private GameObject _zoomOutButtonAnchor;

		[SerializeField]
		private GameObject _zoomOutButtonInactiveAnchor;

		private CameraView _cameraView;

		private CityDefinition _newCity;

		private MapDefinition _newMapDefinition;

		private MapChallenge _newMapChallenge;

		private bool _cinematicGameRunning;

		private bool _waitingOnCinematicModeExit;

		public const string ShowCinematicModeDebugInfo = "ShowCinematicModeDebugInfo";

		protected override OverlayScreenType overlayScreenType => OverlayScreenType.CinematicModeScreen;

		protected override MapDefinition GetMapDefinition()
		{
			if (!(_newMapDefinition != null))
			{
				return _game.MapDefinition;
			}
			return _newMapDefinition;
		}

		public override void OnTransitionedIn()
		{
			if (_game == null)
			{
				Diagnostics.FailAssert("Cinematic mode transitioning in without a valid game.");
				return;
			}
			_game.SetPaused(isPaused: false);
			_game.SetTimeScale(TimeScale.Single);
			if (Get.Pulse.Scale != TimeScale.Single)
			{
				Get.Pulse.Scale = TimeScale.Single;
				AudioPlayer.UI?.PlaySample("ui_clockSlow", 0.75f, 0.5f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
			}
			_game.Scope.Get<GameContainerScreen>().SetRecentlyExitedCinematicMode(recentlyExitedCinematicMode: true);
			if (_game.StartedWithGameMode == GameMode.Endless)
			{
				_simulation.GetModel<ClockModel>().expansionTimeManuallyPaused = true;
			}
			else
			{
				SetBaseGameSuspended(suspend: true);
				StartCinematicGame();
			}
			_cameraView = _game.Scope.Get<CameraView>();
			_cameraView.EnterCinematicMode();
			_cameraView.GoToNextAgentInCinematicMode();
			base.OnTransitionedIn();
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			base.TransitionOut(inScreen);
			_simulation.GetModel<ClockModel>().expansionTimeManuallyPaused = false;
			_waitingOnCinematicModeExit = false;
			if (_cinematicGameRunning)
			{
				ReleaseCinematicGame();
				SetBaseGameSuspended(suspend: false);
			}
		}

		public void OnBackPressed()
		{
			if (isToolbarVisible)
			{
				_cameraView.ExitCinematicMode();
				_waitingOnCinematicModeExit = true;
				ToggleToolbarVisibility();
				MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles, _gameScope);
			}
		}

		public override void SetToolbarVisible(bool visible, bool hasAudio = false)
		{
			base.SetToolbarVisible(visible);
			if (hasAudio)
			{
				AudioPlayer.Default?.PlaySample("iso-ui-" + (visible ? "show" : "hide") + "-controls", 0.5f, 1f, 1f, 0.0, -1.0, loop: false, null, stereo: false, randomStart: false, 0f, isImportant: true);
			}
			_zoomOutButtonAnchor.SetActive(visible);
			_zoomOutButtonInactiveAnchor.SetActive(value: true);
		}

		public override void ToggleToolbarVisibility()
		{
			base.ToggleToolbarVisibility();
			RefreshCinematicButtonDisplay();
		}

		public void ZoomIn()
		{
			_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.FocusZoomIn, UIAudioProfile.None, _cameraView.GetInterpolationSpeed()));
			SetCinematicZoomLevel(_cameraView.CinematicZoomIndex + 1);
		}

		public void ZoomOut()
		{
			_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.FocusZoomOut, UIAudioProfile.None, _cameraView.GetInterpolationSpeed()));
			SetCinematicZoomLevel(_cameraView.CinematicZoomIndex - 1);
		}

		public void OnNextVehiclePressed()
		{
			_cameraView.GoToNextAgentInCinematicMode();
		}

		private void SetCinematicZoomLevel(int newZoomLevel)
		{
			_cameraView.SetCinematicZoomLevel(newZoomLevel);
			RefreshCinematicButtonDisplay();
		}

		private void RefreshCinematicButtonDisplay()
		{
			if (_cameraView.CinematicZoomIndex == _cameraView.ZoomLevelCount - 1)
			{
				_zoomInButton.GetComponent<CinematicZoomButton>().Deactivate();
			}
			else
			{
				_zoomInButton.GetComponent<CinematicZoomButton>().Activate();
			}
			if (_cameraView.CinematicZoomIndex == 0)
			{
				_zoomOutButton.GetComponent<CinematicZoomButton>().Deactivate();
			}
			else
			{
				_zoomOutButton.GetComponent<CinematicZoomButton>().Activate();
			}
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
			if (_cinematicGameRunning)
			{
				_game?.Tick(deltaTime);
				if (!_waitingOnCinematicModeExit)
				{
					return;
				}
				if (Diagnostics.Verify(_gameCamera.customBlur.Strength >= 0f, "Cinematic mode blur strength should never be negative.") && Diagnostics.Verify((double)_visualConstantsData.CinematicTransitionOutBlurSpeed >= 0.1, "Cinematic transition out blur speed should never be less than 0.1"))
				{
					_gameCamera.customBlur.Strength = Math.Clamp(_gameCamera.customBlur.Strength + deltaTime * _visualConstantsData.CinematicTransitionOutBlurSpeed, 0f, 1f);
					if (_gameCamera.customBlur.Strength >= 1f)
					{
						_waitingOnCinematicModeExit = false;
						OnBack();
					}
				}
				else
				{
					_waitingOnCinematicModeExit = false;
					OnBack();
				}
			}
			else if (_waitingOnCinematicModeExit && !_cameraView.IsInCinematicMode)
			{
				_waitingOnCinematicModeExit = false;
				_game.Scope.Get<NotificationView>().HideNotification();
				_screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.InGame);
			}
		}

		public override void RegisterThemeComponents(ITheme theme)
		{
			base.RegisterThemeComponents(theme);
			if (!(_newCity != null))
			{
				return;
			}
			List<IThemeComponent> list = new List<IThemeComponent>();
			_newCity.GetComponentsInChildren(list);
			if (list != null)
			{
				foreach (IThemeComponent item in list)
				{
					item.InitializeTheme(_themeDatabase);
				}
			}
			if (themeComponents == null)
			{
				themeComponents = list;
			}
			else
			{
				themeComponents.AddRange(list);
			}
		}

		public void PrepareForNewGame(CityDefinition newCity, MapDefinition newMapDefinition, MotorwaysGame game, MapChallenge newMapChallenge = null, bool startPaused = false)
		{
			_game = game;
			_newCity = newCity;
			_newMapDefinition = newMapDefinition;
			RegisterThemeComponents(_themeDatabase.GetTheme());
		}

		private void StartCinematicGame()
		{
			_game.SetMapDefinition(_newMapDefinition);
			_game.Start(_newCity, GameMode.Cinematic, _newMapChallenge, replaceExistingRules: true);
			_game.Scope.Get<GameBehaviourModel>().CanGameOver = false;
			_game.Scope.Get<CityPlanModel>().SpawningMode = CityPlanModel.BuildingSpawningMode.None;
			_game.SetPaused(isPaused: false);
			_game.Tick(0f);
			_game.StartAudio();
			_cinematicGameRunning = true;
		}

		private void ReleaseCinematicGame()
		{
			if (_game != null && _game.StartedWithGameMode != GameMode.Endless)
			{
				_cinematicGameRunning = false;
				UnregisterThemeComponents();
				_game.StopAudio();
				_game.ClearPathfinder();
				_game.Scope.ParentScope.Release(_game);
				_game = null;
				UnityEngine.Object.Destroy(_newCity.gameObject);
			}
		}

		private void SetBaseGameSuspended(bool suspend)
		{
			GameContainerScreen gameContainerScreen = _appScope.Get<GameContainerScreen>();
			if (gameContainerScreen == null || !(gameContainerScreen.GetActiveGame() is MotorwaysGame motorwaysGame))
			{
				return;
			}
			gameContainerScreen.SetGameSuspended(suspend);
			if (suspend)
			{
				motorwaysGame.StopAudio();
			}
			else
			{
				motorwaysGame.StartAudio();
			}
			motorwaysGame.Scope.Get<ViewClient>().SetAllGameObjectsEnabled(!suspend);
			foreach (DestinationView view in motorwaysGame.Scope.Get<ViewClient>().GetViews<DestinationView>())
			{
				view.SetPinViewVisible(!suspend);
			}
		}

		public override void Reset()
		{
			base.Reset();
			_waitingOnCinematicModeExit = false;
			_cinematicGameRunning = false;
			_cameraView = null;
			_newCity = null;
			_newMapDefinition = null;
			_newMapChallenge = null;
		}
	}
}
