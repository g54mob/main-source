using System.Collections.Generic;
using Client;
using Factory;
using Motorways.Audio;
using Motorways.Leaderboards;
using Motorways.UI;
using NaughtyAttributes;
using Popups;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class ResumeGameScreen : ScrollingButtonScreen
	{
		[Dependency]
		private ChallengeSystem _challengeSystem;

		[Dependency]
		private ISoftwareCapabilities _softwareCapabilities;

		public MapLibrary mapLibrary;

		private GameStarter _gameStarter;

		public ResumeMapButton resumeButtonPrefab;

		private IGameJournalSave _savePendingDelete;

		public CanvasGroup mapButtonsCanvas;

		[Tooltip("The duration of the fade to black if Skip Transitions is on")]
		[MinValue(0)]
		public float skippedTransitionFadeDuration = 1f;

		private bool _recreateResumeMapButtons;

		public const string LocalSaveGameID = "localsave";

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ResumeGameScreen");

		public IEnumerable<ResumeMapButton> MapButtons
		{
			get
			{
				foreach (AnimatedCard button in buttons)
				{
					yield return button.GetComponent<ResumeMapButton>();
				}
			}
		}

		public void OnBack()
		{
			_screenStack.PopOneScreen();
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			if (_player.HasLocalSavedGame || _player.HasForeignSavedGames)
			{
				CreateResumeMapButtons();
			}
			base.TransitionIn(outScreen);
			_recreateResumeMapButtons = false;
			_player.SavedGamesChanged += ScheduleMapButtonRecreation;
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			base.TransitionOut(inScreen);
			_player.SavedGamesChanged -= ScheduleMapButtonRecreation;
		}

		public override void OnTransitionedOut()
		{
			base.OnTransitionedOut();
			DestroyResumeButtons();
		}

		public ResumeMapButton ResumeButtonAt(int index)
		{
			return buttons[index].GetComponent<ResumeMapButton>();
		}

		public override void Tick(float deltaTime)
		{
			if (_recreateResumeMapButtons)
			{
				_recreateResumeMapButtons = false;
				if (!CreateResumeMapButtons() && !IsTransitioningOut())
				{
					OnBack();
				}
			}
			base.Tick(deltaTime);
			if (_gameStarter != null && _gameStarter.CanStart)
			{
				_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.MenuExit));
				_gameStarter.Start(_screenStack, _appScope);
				_gameStarter = null;
			}
		}

		public void SelectGame(ResumeMapButton button)
		{
			if (!Diagnostics.Verify(_screenStack.GetActiveScreen<GameContainerScreen>() == null, "Attempting to start a game while there already is a game. Earlying out for safety"))
			{
				return;
			}
			MotorwaysGameJournalSave save;
			if (button.GameID == "localsave")
			{
				save = (MotorwaysGameJournalSave)_player.LocalSavedGame;
			}
			else
			{
				save = (MotorwaysGameJournalSave)_player.GetForeignSavedGame(button.GameID);
			}
			if (!Diagnostics.Verify(save != null, "Tried to reload a save of a game we should have by now!"))
			{
				return;
			}
			List<MotorwaysGameJournalSave> activeDailyChallengeSaves = _challengeSystem.GetActiveDailyChallengeSaves(_player);
			if (activeDailyChallengeSaves.Count == 0 || activeDailyChallengeSaves.Contains(save))
			{
				BeginTransitionIntoSaveGame(save);
			}
			else if (_player.GetChallengeScore(MapChallenge.ChallengeType.Daily, _challengeSystem.DailyChallenge.TimeEnd).ScoreState == LeaderboardScoreState.Editable)
			{
				popupStack.PushPopup<ConfirmationPopup>().Initialise(_appScope, StringId.DailyChallenge, null, delegate
				{
					BeginTransitionIntoSaveGame(save);
				}, StringId.DailyChallenge_SaveGameConfirmationResumeGame);
			}
			else
			{
				BeginTransitionIntoSaveGame(save);
			}
		}

		private void BeginTransitionIntoSaveGame(MotorwaysGameJournalSave save)
		{
			if (_gameStarter == null)
			{
				if (_skipTransitions)
				{
					_screenStack.FadeNextTransition(skippedTransitionFadeDuration);
				}
				_gameStarter = new GameStarter(this);
			}
			_gameStarter.StartFromSavedGame(mapLibrary, save, replaceTopScreen: true);
		}

		public void DeleteGame(ResumeMapButton button)
		{
			MotorwaysGameJournalSave motorwaysGameJournalSave = ((!(button.GameID == "localsave")) ? ((MotorwaysGameJournalSave)_player.GetForeignSavedGame(button.GameID)) : ((MotorwaysGameJournalSave)_player.LocalSavedGame));
			if (Diagnostics.Verify(motorwaysGameJournalSave != null, "Tried to delete a save of a game we should have by now!"))
			{
				_savePendingDelete = motorwaysGameJournalSave;
				popupStack.PushPopup<ConfirmationPopup>().Initialise(_appScope, StringId.ConfirmDeleteSpecificJournal, OnCancelDeleteSpecificSave, OnConfirmSpecificSaveData, _softwareCapabilities.DeleteCloudGameStringId);
			}
		}

		public void OnConfirmSpecificSaveData()
		{
			_player.RemoveSavedGame(_savePendingDelete);
			_savePendingDelete = null;
			if (CreateResumeMapButtons())
			{
				OnTransitionedIn();
				_appScope.Get<MenuNavigation>().SetNewFocus(ResumeButtonAt(0).playTouchButton);
			}
			else
			{
				OnBack();
			}
		}

		public void OnCancelDeleteSpecificSave()
		{
			_appScope.Get<MenuNavigation>().SetNewFocus((base.ButtonCount > 0) ? ResumeButtonAt(0).playTouchButton : backButton);
		}

		private void ScheduleMapButtonRecreation()
		{
			Log.Info("Changes to the remote saves detected, scheduling an update for the next tick.");
			_recreateResumeMapButtons = true;
		}

		private bool CreateResumeMapButtons()
		{
			DestroyResumeButtons();
			if (_player.HasLocalSavedGame)
			{
				MotorwaysGameJournalSave savedGame = (MotorwaysGameJournalSave)_player.LocalSavedGame;
				AddResumeButton(savedGame, "localsave");
			}
			foreach (IGameJournalSave foreignSavedGame in _player.ForeignSavedGames)
			{
				AddResumeButton((MotorwaysGameJournalSave)foreignSavedGame, foreignSavedGame.DeviceId);
			}
			if (base.ButtonCount > 0)
			{
				firstFocus = ResumeButtonAt(0).playTouchButton;
			}
			RegisterAllLocalizedTextChildren();
			RegisterButtons();
			RegisterThemeComponents(_themeDatabase.GetTheme());
			SetMapButtonValues(scrollRect.normalizedPosition);
			return base.ButtonCount > 0;
		}

		private void AddResumeButton(MotorwaysGameJournalSave savedGame, string savedGameId)
		{
			if (savedGame != null)
			{
				MapDefinition mapByName = mapLibrary.GetMapByName(savedGame.CityId);
				if (mapByName != null)
				{
					ResumeMapButton resumeMapButton = Object.Instantiate(resumeButtonPrefab, buttonParent);
					resumeMapButton.Initialize(this, savedGameId, savedGame, mapByName, _appScope);
					buttons.Add(resumeMapButton);
				}
			}
		}

		public override void ApplyTheme(ITheme newTheme)
		{
			base.ApplyTheme(newTheme);
			foreach (ResumeMapButton mapButton in MapButtons)
			{
				mapButton.ApplyTheme();
			}
		}

		public override void ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			base.ApplyBlendedTheme(oldTheme, newTheme, progress);
			foreach (ResumeMapButton mapButton in MapButtons)
			{
				mapButton.ApplyTheme();
			}
		}

		private void DestroyResumeButtons()
		{
			UnregisterButtons();
			UnregisterLocalizedTextChildren();
			UnregisterThemeComponents();
			if (base.ButtonCount > 0)
			{
				for (int i = 0; i < base.ButtonCount; i++)
				{
					buttons[i].gameObject.transform.SetParent(null);
					Object.Destroy(buttons[i].gameObject);
				}
				buttons.Clear();
			}
		}

		public override void OnCreatedInScope(IScope scope)
		{
			base.OnCreatedInScope(scope);
			scrollRect.onValueChanged.AddListener(base.SetMapButtonValues);
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			base.OnReleasedFromScope(scope);
			DestroyResumeButtons();
		}

		public override void OnMoveCursor(Selectable currentFocus, MoveDirection direction)
		{
		}
	}
}
