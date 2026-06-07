using System;
using System.Collections.Generic;
using Factory;
using Motorways.Models;
using Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class ChallengeInfoScreen : BaseScalingScreen
	{
		[Dependency]
		protected PlayerActionController _playerActionController;

		[Dependency]
		private LocaleDatabase _localeDatabase;

		[SerializeField]
		private LocalizedTextUI _challengeTitleType;

		[SerializeField]
		private ChallengeInfoText[] _challengeInfoText;

		[SerializeField]
		private LocalizedTextUI _playButtonText;

		[SerializeField]
		private LocalizedTextUI _dateString;

		[SerializeField]
		private TouchButton _continueButton;

		[SerializeField]
		private TouchButton _closeButton;

		private bool _changeBlurWhenTransitioning;

		private bool _continueButtonPopsScreen;

		private MapChallenge.ChallengeType _challengeType;

		private int _challengeIndex = -1;

		private MapDefinition _definition;

		private List<ChallengeData> _challenges;

		private int _timeStart;

		private int _timeEnd;

		private IScope _gameScope;

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
			_canvasGroup.Alpha = TransitionInPercentage();
		}

		public void PrepareScreenForCityChallenge(MapDefinition definition, int challengeIndex, StringId buttonString, bool changeBlurWhenTransitioning, bool showBackButton)
		{
			_challengeType = MapChallenge.ChallengeType.City;
			_definition = definition;
			_challengeIndex = challengeIndex;
			_changeBlurWhenTransitioning = changeBlurWhenTransitioning;
			_challenges = new List<ChallengeData>();
			_challenges.AddRange(definition.cityChallenges[_challengeIndex].challenges);
			_playButtonText.SetStringId(_appScope, buttonString);
			backButton.gameObject.SetActive(showBackButton);
			firstFocus = _closeButton;
			_closeButton.transform.parent.gameObject.SetActive(value: true);
			_continueButton.transform.parent.gameObject.SetActive(value: false);
		}

		public void PrepareScreen(MapChallenge.ChallengeType challengeType, List<ChallengeData> challenges, int timeStart, int timeEnd, StringId buttonString, bool changeBlurWhenTransitioning, bool showBackButton, IScope gameScope = null, bool continueIsBack = true)
		{
			_challengeType = challengeType;
			_challenges = challenges;
			_timeStart = timeStart;
			_timeEnd = timeEnd;
			_gameScope = gameScope;
			backButton.gameObject.SetActive(showBackButton);
			_playButtonText.SetStringId(_appScope, buttonString);
			_changeBlurWhenTransitioning = changeBlurWhenTransitioning;
			_continueButtonPopsScreen = continueIsBack;
			if (_gameScope != null)
			{
				firstFocus = _continueButton;
				_continueButton.transform.parent.gameObject.SetActive(value: true);
				_closeButton.transform.parent.gameObject.SetActive(value: false);
			}
			else
			{
				firstFocus = _closeButton;
				_closeButton.transform.parent.gameObject.SetActive(value: true);
				_continueButton.transform.parent.gameObject.SetActive(value: false);
			}
		}

		public override void OnTransitionedIn()
		{
			base.OnTransitionedIn();
			if (_gameScope != null)
			{
				_appScope.Get<InputState>().BlockGameInput = true;
				_playerActionController.CancelAllActions();
			}
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			base.TransitionIn(outScreen);
			_skipTransitions = false;
			MotorwaysGame motorwaysGame = null;
			if (_gameScope != null)
			{
				motorwaysGame = _gameScope.Get<Game>() as MotorwaysGame;
				motorwaysGame.SetPaused(isPaused: true);
			}
			StringId result = StringId.MiniMotorways;
			if (_challengeType == MapChallenge.ChallengeType.Daily)
			{
				result = StringId.DailyChallenge;
			}
			else if (_challengeType == MapChallenge.ChallengeType.Weekly)
			{
				result = StringId.WeeklyChallenge;
			}
			else if (_challengeType == MapChallenge.ChallengeType.City)
			{
				CityChallengeData cityChallengeData = ((motorwaysGame == null) ? _definition.cityChallenges[_challengeIndex] : motorwaysGame.MapDefinition.cityChallenges[motorwaysGame.Simulation.GetModel<ActiveChallengesModel>().cityChallengeIndex]);
				Diagnostics.Verify(Enum.TryParse<StringId>(cityChallengeData.titleStringId, out result));
			}
			_challengeTitleType.SetStringId(_appScope, result);
			switch (_challengeType)
			{
			case MapChallenge.ChallengeType.Daily:
			{
				DateTime date3 = ChallengeSystem.ToDateTime(_timeStart);
				_dateString.LocString = StandaloneLocString.CreateNonLocalizedString(_appScope, _localeDatabase.CurrentLocale.FormatDate(date3, formatForLocString: false));
				break;
			}
			case MapChallenge.ChallengeType.Weekly:
			{
				DateTime date = ChallengeSystem.ToDateTime(_timeStart);
				DateTime date2 = ChallengeSystem.ToDateTime(_timeEnd).AddDays(-1.0);
				Dictionary<StringParameterId, string> newParameters = new Dictionary<StringParameterId, string>
				{
					{
						StringParameterId.StartDate,
						_localeDatabase.CurrentLocale.FormatDate(date)
					},
					{
						StringParameterId.EndDate,
						_localeDatabase.CurrentLocale.FormatDate(date2)
					}
				};
				_dateString.LocString = StandaloneLocString.CreateString(_appScope, new MotorwaysStringKey(StringId.WeeklyChallengeDateDuration, newParameters));
				break;
			}
			default:
				_dateString.LocString = StandaloneLocString.CreateNonLocalizedString(_appScope, string.Empty);
				break;
			}
			ChallengeDatabase challengeDatabase = _appScope.Get<ChallengeDatabase>();
			List<ChallengeData> list = new List<ChallengeData>();
			list.AddRange(_challenges);
			list.Sort(delegate(ChallengeData a, ChallengeData b)
			{
				int num2 = ((!challengeDatabase.IsChallengeWildcard(a)) ? 1 : 0);
				int value = ((!challengeDatabase.IsChallengeWildcard(b)) ? 1 : 0);
				return num2.CompareTo(value);
			});
			for (int num = 0; num < Math.Max(list.Count, _challengeInfoText.Length); num++)
			{
				if (Diagnostics.Verify(num < _challengeInfoText.Length, "We don't have enough challenge info text for the number of challenges! Have {0} need {1}.", _challengeInfoText.Length, _challenges.Count))
				{
					if (num < list.Count)
					{
						_challengeInfoText[num].gameObject.SetActive(value: true);
						ChallengeData challengeData = list[num];
						bool isWildcard = challengeDatabase.IsChallengeWildcard(challengeData);
						_challengeInfoText[num].SetChallengeInfo(challengeData, isWildcard, _appScope);
					}
					else
					{
						_challengeInfoText[num].gameObject.SetActive(value: false);
					}
				}
			}
			MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.PauseScreen, _appScope);
		}

		public override void BackActivated()
		{
			if (backButton.gameObject.activeInHierarchy)
			{
				base.BackActivated();
			}
			else
			{
				firstFocus.OnSubmit(null);
			}
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			base.TransitionOut(inScreen);
			_changeBlurWhenTransitioning = inScreen != ScreenStack.MotorwaysScreen.Pause && inScreen != ScreenStack.MotorwaysScreen.GameOver;
			_skipTransitions = false;
			if (inScreen == ScreenStack.MotorwaysScreen.InGame)
			{
				MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles, _appScope);
			}
		}

		public void OnContinue()
		{
			if (_continueButtonPopsScreen)
			{
				_screenStack.PopOneScreen();
			}
			else
			{
				_screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.InGame);
			}
		}

		public void OnBack()
		{
			_screenStack.PopOneScreen();
		}

		public override void OnCreatedInScope(IScope scope)
		{
			base.OnCreatedInScope(scope);
			if (_canvas != null && base.gameObject.layer == _gameCamera.OverlayLayerIndex)
			{
				_gameCamera.AttachCameraToCanvas(_canvas, CameraLayer.Overlay);
			}
		}

		public override void Reset()
		{
			_timeStart = 0;
			_timeEnd = 0;
			_challenges = null;
			_challengeType = MapChallenge.ChallengeType.None;
			_challengeIndex = -1;
			_definition = null;
			_gameScope = null;
			_changeBlurWhenTransitioning = false;
			_continueButtonPopsScreen = false;
			base.Reset();
		}
	}
}
