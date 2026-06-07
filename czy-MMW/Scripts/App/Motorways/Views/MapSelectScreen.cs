using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Client;
using Factory;
using JetBrains.Annotations;
using Motorways.Audio;
using Motorways.Leaderboards;
using Motorways.Models;
using Motorways.UI;
using Motorways.UI.NewContentIndicators;
using NaughtyAttributes;
using Popups;
using TMPro;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class MapSelectScreen : ScrollingButtonScreen
	{
		public const int InvalidScore = -1;

		public const int InProgressScore = -2;

		[Dependency]
		private MapDatabase _mapDatabase;

		[Dependency]
		private ChallengeSystem _challengeSystem;

		[Dependency]
		private NewContentData _newContentDatabase;

		[Dependency]
		private VisualConstantsData _constants;

		[Dependency]
		private AchievementDatabase _achievements;

		[Dependency]
		private GameContainerScreen _gameContainer;

		[Dependency]
		private LeaderboardService _leaderboardService;

		[Dependency]
		private MenuNavigation _menuNavigation;

		[Dependency]
		private IPersistentStorageService _storageService;

		[Dependency]
		private DeepLinkProcessor _deepLinkProcessor;

		public const string WeeklyChallengeTutorialPopupContentID = "WeeklyChallengeTutorialPopup";

		public const string DailyChallengeTutorialPopupContentID = "DailyChallengeTutorialPopup";

		public const string ChallengeCardsNewContentID = "DailyWeeklyChallengeCards";

		public const string NewCityChallengeUnlockInfoPopup = "NewCityChallengeUnlockInfoPopup";

		public MapButton mapButtonPrefab;

		[MinValue(0)]
		[Tooltip("The duration of the fade to black if Skip Transitions is on")]
		public float skippedTransitionFadeDuration = 1f;

		[Tooltip("The delay between the confirmed press and the non-confirmed cards being pushed to the side")]
		[MinValue(0)]
		public float intervalBetweenButtonPushAnimations = 0.1f;

		[Tooltip("The delay before transitioning into the map. Min 1")]
		[MinValue(1)]
		public float delayBeforeTransitioning = 2f;

		[SerializeField]
		[Tooltip("The delay in seconds between each challenge card slides in from left the first time a users sees them")]
		[MinValue(0)]
		private float _nextChallengeCardAppearDelay;

		[SerializeField]
		protected LocalizedTextUI _playButtonText;

		private StringId _playButtonStringId;

		[SerializeField]
		private TextMeshProUGUI _playButtonTextMeshPro;

		[SerializeField]
		private CanvasRenderer _playButtonChallengeIcon;

		[SerializeField]
		private CanvasRenderer _playButtonEndlessIcon;

		[SerializeField]
		private CanvasRenderer _playButtonExpertIcon;

		[SerializeField]
		private CanvasRenderer _playButtonCreativeIcon;

		private const float PlayButtonUninteractableAlpha = 0.5f;

		private const float ScrollParallaxConstant = 0.805f;

		[SerializeField]
		[Tooltip("Wait time when scrolling to the first unlock element.")]
		private float _unlockAnimationTimeToScrollToFirstElement = 0.25f;

		[Tooltip("The time between starting the padlock unlock anim and the scroll anim.")]
		[SerializeField]
		private float _unlockToScrollTime = 0.25f;

		[Tooltip("The time between starting the scroll and starting the flip")]
		[SerializeField]
		private float _scrollToFlipTime = 0.1f;

		[SerializeField]
		[Tooltip("Wait time between starting scroll to next element animation and starting the next unlock animation.")]
		private float _scrollWaitTime = 0.25f;

		[SerializeField]
		[Tooltip("Delay before scrolling back to original map after unlock sequence.")]
		private float _unlockAnimationEndDelay = 0.5f;

		private Vector3? _originPosition;

		private AssetBundleUtility.AsyncLoadResult _cityDefinition;

		private Vector2 _cityCameraTransitionPosition;

		private Vector2 _cityCameraTransitionHandle;

		private bool _transitioningFromGameScreen;

		private float _timerTillTransition = -1f;

		private static readonly int DroppedDown = Animator.StringToHash("DroppedDown");

		private static readonly int ShouldShowChallengeIcon = Animator.StringToHash("ShouldShowChallengeIcon");

		private static readonly int ShouldShowEndlessIcon = Animator.StringToHash("ShouldShowEndlessIcon");

		private static readonly int ShouldShowExpertIcon = Animator.StringToHash("ShouldShowExpertIcon");

		private static readonly int ShouldShowCreativeIcon = Animator.StringToHash("ShouldShowCreativeIcon");

		private bool _mapLoadedForGameScreen;

		private bool _popupHidden = true;

		private bool _handleDeepLinkOnTransition;

		private bool _blurWhileTransitioning;

		private bool _hasSeenDailyChallengeCompletePopUp;

		private readonly HashSet<MapDefinition> _previouslyLockedMapButtons = new HashSet<MapDefinition>();

		private readonly HashSet<MapDefinition> _previouslyLockedCityChallengeMapButtons = new HashSet<MapDefinition>();

		private float _soakTestCountdown;

		private int _challengeButtonCount;

		private readonly List<MapButton> _buttonsToUnlockOnTransitioned = new List<MapButton>();

		private MapButton _buttonToUnlockCityChallengeOnTransitioned;

		private MapButton _buttonToUnlockExpertModeOnTransitioned;

		private MapButton _lastSelectedButtonBeforeTransitionOut;

		private int _selectedChallengeIndex = -1;

		private bool _playHighlightedWhenLastActive;

		private bool _isPlayingAnimation;

		private ScreenStack.MotorwaysScreen _previousScreen;

		private static readonly ProfilerMarker Profiler_Tick = new ProfilerMarker(ProfilerCategory.Scripts, "MapSelectScreen.Tick()");

		private static readonly ProfilerMarker Profiler_ApplyBlendedTheme = new ProfilerMarker(ProfilerCategory.Scripts, "MapSelectScreen.ApplyBlendedTheme()");

		public LeaderboardType? PlayerSelectedLeaderboardType { get; set; }

		private bool ShouldPushGameScreen
		{
			get
			{
				if (_mapLoadedForGameScreen)
				{
					return _popupHidden;
				}
				return false;
			}
		}

		public MapButton CurrentlySelectedMapButton => base.CurrentlySelectedButton.GetComponent<MapButton>();

		public IEnumerable<MapButton> MapButtons
		{
			get
			{
				foreach (AnimatedCard button in buttons)
				{
					yield return button.GetComponent<MapButton>();
				}
			}
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
			bool num = IsVisible();
			if (num)
			{
				_gameCamera.transform.position = GetCameraPosition();
			}
			if (ShouldPushGameScreen)
			{
				HideUnselectedButtons();
				_screenStack.PushScreen(ScreenStack.MotorwaysScreen.InGame, delegate(GameContainerScreen newScreen)
				{
					_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.MenuExit));
					_selectedChallengeIndex = CurrentlySelectedMapButton.SelectedChallengeIndex;
					GameMode currentSelectedGameMode = CurrentlySelectedMapButton.GetCurrentSelectedGameMode();
					newScreen.PrepareForMap(UnityEngine.Object.Instantiate(_cityDefinition.asset as GameObject).GetComponent<CityDefinition>(), CurrentlySelectedMapButton.MapDefinition, currentSelectedGameMode, CurrentlySelectedMapButton.MapChallenge);
					CurrentlySelectedMapButton.DeselectCityChallenge();
				});
				_cityDefinition = null;
				scrollRect.enabled = true;
				_mapLoadedForGameScreen = false;
				if (FeatureToggle.IsFeatureEnabled(Feature.RandomChallengesMapButton) && CurrentlySelectedMapButton.IsRandomChallengeCard)
				{
					CurrentlySelectedMapButton.AssignRandomMapChallenge();
				}
			}
			if (_popupHidden && _timerTillTransition >= 0f)
			{
				_timerTillTransition -= deltaTime;
			}
			if (_cityDefinition != null && _cityDefinition.HasValue && _timerTillTransition < 0f)
			{
				if (_skipTransitions)
				{
					_screenStack.FadeNextTransition(skippedTransitionFadeDuration);
				}
				_mapLoadedForGameScreen = true;
			}
			if (!num)
			{
				return;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.SoakTest) && !IsTransitioningIn() && !IsTransitioningOut() && _soakTestCountdown > 0f)
			{
				_soakTestCountdown -= deltaTime;
				if (_soakTestCountdown <= 0f)
				{
					_soakTestCountdown = -1f;
					ScrollToButton(Random.AnyItem(buttons), instantly: true);
					SelectCurrentMap();
				}
			}
			int nearestButtonIndex = GetNearestButtonIndex();
			bool interactable = firstFocus.interactable;
			MapButton mapButton = MapButtonAt(nearestButtonIndex);
			if (mapButton != null)
			{
				bool flag = !mapButton.IsLocked && (mapButton.CurrentCard != MapButton.Card.Challenge || mapButton.SelectedChallenge != null) && !_isPlayingAnimation;
				float num2 = (flag ? 1f : 0.5f);
				if (interactable != flag)
				{
					if (flag && _playHighlightedWhenLastActive && EventSystem.current.currentSelectedGameObject == null)
					{
						EventSystem.current.SetSelectedGameObject(firstFocus.gameObject);
					}
					else
					{
						_playHighlightedWhenLastActive = EventSystem.current.currentSelectedGameObject == firstFocus.gameObject;
					}
					firstFocus.interactable = flag;
					Color color = _playButtonTextMeshPro.color;
					_playButtonTextMeshPro.color = new Color(color.r, color.b, color.g, num2);
				}
				bool value = mapButton.Type == MapButton.MapButtonType.DailyChallenge || mapButton.Type == MapButton.MapButtonType.WeeklyChallenge || mapButton.IsRandomChallengeCard || mapButton.CurrentCard == MapButton.Card.Challenge;
				firstFocus.animator.SetBool(ShouldShowChallengeIcon, value);
				bool value2 = mapButton.CurrentCard != MapButton.Card.Challenge && mapButton.GetCurrentSelectedGameMode() == GameMode.Endless;
				firstFocus.animator.SetBool(ShouldShowEndlessIcon, value2);
				bool value3 = mapButton.CurrentCard != MapButton.Card.Challenge && mapButton.GetCurrentSelectedGameMode() == GameMode.Expert;
				firstFocus.animator.SetBool(ShouldShowExpertIcon, value3);
				bool value4 = mapButton.CurrentCard != MapButton.Card.Challenge && mapButton.GetCurrentSelectedGameMode() == GameMode.Creative;
				firstFocus.animator.SetBool(ShouldShowCreativeIcon, value4);
				_playButtonChallengeIcon.SetAlpha(num2);
				_playButtonEndlessIcon.SetAlpha(num2);
				_playButtonExpertIcon.SetAlpha(num2);
				_playButtonCreativeIcon.SetAlpha(num2);
				if (mapButton.PlayTextStringId != _playButtonStringId)
				{
					_playButtonStringId = mapButton.PlayTextStringId;
					MotorwaysStringKey motorwaysStringKey = _appScope.Get<MotorwaysStringKey>();
					motorwaysStringKey.InitWithStringId(_playButtonStringId);
					_playButtonText.LocString = StandaloneLocString.CreateString(_appScope, motorwaysStringKey);
				}
			}
			if (_handleDeepLinkOnTransition && _screenStack.HasVisibleScreens())
			{
				_handleDeepLinkOnTransition = false;
				_blurWhileTransitioning = false;
				SelectMap(CurrentlySelectedMapButton);
			}
		}

		private MapButton MapButtonAt(int index)
		{
			if (!Diagnostics.Verify(index >= 0 && index < buttons.Count, "Unexpected index of {0} when we have a count of {1}", index, buttons.Count))
			{
				return null;
			}
			return buttons[index].GetComponent<MapButton>();
		}

		public MapButton GetPreviousButton(MapButton button)
		{
			MapButton result = null;
			int num = buttons.IndexOf(button) - 1;
			if (num >= 0 && num < buttons.Count)
			{
				result = MapButtonAt(num);
			}
			return result;
		}

		public MapButton GetNextButton(MapButton button)
		{
			MapButton result = null;
			int num = buttons.IndexOf(button) + 1;
			if (num >= 0 && num < buttons.Count)
			{
				result = MapButtonAt(num);
			}
			return result;
		}

		public void PrepareScreen(Game currentGame = null, bool handleDeeplinkChallenge = false, bool changeBlurWhenTransitioning = false)
		{
			_blurWhileTransitioning = changeBlurWhenTransitioning;
			RegisterAllLocalizedTextChildren();
			CreateMapButtons();
			AssignOriginPosition();
			if (currentGame != null)
			{
				MapButton mapButton = null;
				MapButton mapButton2 = null;
				ActiveChallengesModel model = currentGame.Simulation.GetModel<ActiveChallengesModel>();
				MapChallenge.ChallengeType challengeType = model.challengeType;
				_selectedChallengeIndex = model.cityChallengeIndex;
				foreach (MapButton mapButton3 in MapButtons)
				{
					if (challengeType != MapChallenge.ChallengeType.None && mapButton3.MapChallenge != null && mapButton3.MapChallenge.type == challengeType)
					{
						mapButton = mapButton3;
						break;
					}
					if ((challengeType == MapChallenge.ChallengeType.None || challengeType == MapChallenge.ChallengeType.City) && (mapButton3.MapChallenge == null || mapButton3.MapChallenge.type == MapChallenge.ChallengeType.None) && mapButton3.MapDefinition.cityName == _gameContainer.CurrentCityName)
					{
						mapButton = mapButton3;
						break;
					}
					if (mapButton2 == null && mapButton3.Type == MapButton.MapButtonType.City)
					{
						mapButton2 = mapButton3;
					}
				}
				if (mapButton == null && mapButton2 != null)
				{
					mapButton = mapButton2;
				}
				if (Diagnostics.Verify(mapButton != null, "Game {0} passed to PrepareScreen but we failed to find a map button matching current game. City: {1}. Challenge: {2}", currentGame, _gameContainer.CurrentCityName, challengeType))
				{
					ScrollToButton(mapButton, instantly: true);
				}
			}
			if (handleDeeplinkChallenge)
			{
				PrepareScreenForDeeplinkChallenge();
			}
		}

		public void PrepareScreenForDeeplinkChallenge()
		{
			if (popupStack.HasActivePopups && popupStack.GetTopPopup().CanBeDismissed())
			{
				popupStack.PopPopup(skipTransition: true);
			}
			MapButton mapButton = null;
			foreach (MapButton mapButton2 in MapButtons)
			{
				if (mapButton2.MapChallenge == null && string.Equals(mapButton2.MapDefinition.cityName, _deepLinkProcessor.challengeMap, StringComparison.OrdinalIgnoreCase))
				{
					mapButton = mapButton2;
					break;
				}
			}
			if (Diagnostics.Verify(mapButton != null, "attempting to deep link to " + _deepLinkProcessor.challengeMap + " but no map button was found"))
			{
				GameMode challengeMode = _deepLinkProcessor.challengeMode;
				_player.SetSelectedGameMode(mapButton.MapDefinition.mapName, challengeMode);
				ScrollToButton(mapButton, instantly: true);
				_handleDeepLinkOnTransition = true;
			}
		}

		private void RefreshChallengeOverridesFromServer()
		{
			_challengeSystem.RefreshOverridesFromServer(delegate(ChallengeOverrides.RefreshResult result, ChallengeSystem.RefreshOverridesDetails details)
			{
				if (result == ChallengeOverrides.RefreshResult.Success)
				{
					if ((details & ChallengeSystem.RefreshOverridesDetails.NewWeeklyChallenge) != ChallengeSystem.RefreshOverridesDetails.None && TryGetButtonOfType(MapButton.MapButtonType.WeeklyChallenge, out var result2))
					{
						OnChallengeExpired(result2);
					}
					if ((details & ChallengeSystem.RefreshOverridesDetails.NewDailyChallenge) != ChallengeSystem.RefreshOverridesDetails.None && TryGetButtonOfType(MapButton.MapButtonType.DailyChallenge, out var result3))
					{
						OnChallengeExpired(result3);
					}
				}
			});
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			_previousScreen = outScreen;
			RefreshChallengeOverridesFromServer();
			foreach (MapButton mapButton2 in MapButtons)
			{
				if (_previouslyLockedMapButtons.Contains(mapButton2.MapDefinition) && !mapButton2.MapDefinition.IsLocked(_appScope) && !mapButton2.IsChallengeMapButton())
				{
					_buttonsToUnlockOnTransitioned.Add(mapButton2);
				}
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				_buttonsToUnlockOnTransitioned.Clear();
			}
			if (_buttonsToUnlockOnTransitioned.Count > 0)
			{
				_lastSelectedButtonBeforeTransitionOut = CurrentlySelectedMapButton;
				MapButton mapButton = _buttonsToUnlockOnTransitioned[0];
				ScrollToButton(mapButton, instantly: true);
				mapButton.ShowCard(mapButton.CurrentCard);
				SetMapButtonValues(scrollRect.normalizedPosition);
			}
			foreach (MapButton mapButton3 in MapButtons)
			{
				if (_previouslyLockedCityChallengeMapButtons.Contains(mapButton3.MapDefinition) && !mapButton3.MapDefinition.IsCityChallengeLocked(_appScope))
				{
					_buttonToUnlockCityChallengeOnTransitioned = mapButton3;
					if (_buttonsToUnlockOnTransitioned.Count == 0)
					{
						ScrollToButton(mapButton3, instantly: true);
						SetMapButtonValues(scrollRect.normalizedPosition);
					}
				}
			}
			if (!_player.HasSeenNewContent(MapButtonModeSelectCard.GetUnlockAnimationNciID(CurrentlySelectedMapButton.MapDefinition)) && CurrentlySelectedMapButton.MapDefinition.IsExpertModeUnlocked(_appScope) && !CurrentlySelectedMapButton.IsRandomChallengeCard && CurrentlySelectedMapButton.Type == MapButton.MapButtonType.City)
			{
				_buttonToUnlockExpertModeOnTransitioned = CurrentlySelectedMapButton;
				if (FeatureToggle.IsFeatureDisabled(Feature.MapUnlocks))
				{
					_buttonToUnlockExpertModeOnTransitioned = null;
				}
			}
			SavePreviouslyLockedMaps();
			TrySubmitOutstandingScores();
			HACK_CompleteMapScore300AchievementFallback();
			base.TransitionIn(outScreen);
			if (!_originPosition.HasValue)
			{
				Vector3 positionFor = _screenStack.GetPositionFor(base.ScreenType);
				positionFor.z = -0.25f;
				positionFor.x -= scrollRect.horizontalNormalizedPosition * buttonParent.sizeDelta.x * base.transform.localScale.x * 0.805f;
				_originPosition = positionFor;
				base.transform.position = positionFor;
			}
			foreach (MapButton mapButton4 in MapButtons)
			{
				if (!mapButton4.IsHidden)
				{
					mapButton4.CanvasGroup.Alpha = 1f;
				}
				mapButton4.CanvasGroup.SetInteractable(isInteractable: true);
				int bestScore = -1;
				switch (mapButton4.Type)
				{
				case MapButton.MapButtonType.City:
				{
					GameMode currentSelectedGameMode = mapButton4.GetCurrentSelectedGameMode();
					bestScore = GetBestScoreForCityLeaderboard(mapButton4.MapDefinition.cityName, currentSelectedGameMode);
					break;
				}
				case MapButton.MapButtonType.DailyChallenge:
					bestScore = GetBestScoreForChallenge(MapChallenge.ChallengeType.Daily);
					break;
				case MapButton.MapButtonType.WeeklyChallenge:
					bestScore = GetBestScoreForChallenge(MapChallenge.ChallengeType.Weekly);
					break;
				}
				mapButton4.SetBestScoreTextOnMainCard(_appScope, bestScore);
				mapButton4.RefreshTabs();
			}
			if (_selectedChallengeIndex != -1)
			{
				CurrentlySelectedMapButton.SetupFrontCardForCityChallenge(_selectedChallengeIndex);
			}
			ScrollToButton(base.CurrentlySelectedButton, instantly: true);
			CurrentlySelectedMapButton.SetSelected(isSelected: true);
			foreach (MapButton mapButton5 in MapButtons)
			{
				mapButton5.EnsureThemeButtonSelectedState(_themeDatabase.ThemePreference);
				GameMode selectedModeForMap = _player.GetSelectedModeForMap(mapButton5.MapDefinition.mapName);
				mapButton5.MainCard.UpdateModeStrings(selectedModeForMap);
			}
			if (_screenStack.IsScreenActive(ScreenStack.MotorwaysScreen.InGame))
			{
				MotorwaysGame motorwaysGame = (MotorwaysGame)_screenStack.GetActiveScreen<GameContainerScreen>().GetActiveGame();
				_cityCameraTransitionHandle = motorwaysGame.StartedWithCityDefinition.cameraZoom.cameraEntrySplineHandle;
				_cityCameraTransitionPosition = motorwaysGame.StartedWithCityDefinition.cameraZoom.cameraEntryPosition;
				_transitioningFromGameScreen = true;
			}
			else
			{
				_transitioningFromGameScreen = false;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.ChallengeTimeControl) && !(GameDateTime.Backend is AdjustableGameDateTime))
			{
				GameDateTime.Backend = new AdjustableGameDateTime();
			}
			_soakTestCountdown = 0.5f;
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			base.TransitionOut(inScreen);
			if (inScreen == ScreenStack.MotorwaysScreen.MainMenu)
			{
				_previouslyLockedMapButtons.Clear();
				_previouslyLockedCityChallengeMapButtons.Clear();
			}
		}

		private void HACK_CompleteMapScore300AchievementFallback()
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				return;
			}
			for (int i = 0; i < buttons.Count; i++)
			{
				MapButton mapButton = MapButtonAt(i);
				if (mapButton.MapDefinition.CityNameEnum != MapDefinition.CityNames.DarEsSalaam || !mapButton.IsLocked || (GetBestScoreForCityLeaderboard(MapDefinition.CityNames.LosAngeles.ToString(), GameMode.Normal) < 300 && GetBestScoreForCityLeaderboard(MapDefinition.CityNames.Beijing.ToString(), GameMode.Normal) < 300 && GetBestScoreForCityLeaderboard(MapDefinition.CityNames.Tokyo.ToString(), GameMode.Normal) < 300))
				{
					continue;
				}
				if (!_buttonsToUnlockOnTransitioned.Contains(mapButton))
				{
					Diagnostics.FailAssert("Map locked even though requirement complete. TotalPointsScored {0}", _player.AchievementStatistics.TotalPointsScored);
					mapButton.HackSetUnlocked();
				}
				AchievementDefinition achievementDefinition = null;
				for (int j = 0; j < _achievements.Count; j++)
				{
					AchievementDefinition achievementDefinition2 = _achievements[j];
					if (achievementDefinition2.Id == "Map_Score_300")
					{
						achievementDefinition = achievementDefinition2;
					}
				}
				if (achievementDefinition != null && !_player.IsAchievementCompleted(achievementDefinition))
				{
					_player.CompleteAchievement(achievementDefinition, showNotification: false);
				}
			}
		}

		private IEnumerator RunUnlockAnimations()
		{
			_canvasGroup.SetInteractable(isInteractable: false);
			_inputState.BlockAllInput = true;
			_isPlayingAnimation = true;
			bool skipScroll = _player.IsSkipTransitionsEnabled;
			bool isFirstButton = true;
			foreach (MapButton button in _buttonsToUnlockOnTransitioned)
			{
				MapButton previousButton = GetPreviousButton(button);
				MapButton nextButton = GetNextButton(button);
				if (skipScroll)
				{
					button.SetUnlocked();
					button.SetupButtonNavigation();
					if (previousButton != null)
					{
						previousButton.SetupButtonNavigation();
					}
					if (nextButton != null)
					{
						nextButton.SetupButtonNavigation();
					}
					yield return new WaitForSeconds(_scrollToFlipTime);
					button.FlipCard();
					yield return new WaitForSeconds(_scrollWaitTime);
					continue;
				}
				if (isFirstButton)
				{
					ScrollToButton(button);
					yield return new WaitForSeconds(_unlockAnimationTimeToScrollToFirstElement);
					isFirstButton = false;
				}
				button.SetUnlocked();
				button.SetupButtonNavigation();
				if (previousButton != null)
				{
					previousButton.SetupButtonNavigation();
				}
				if (nextButton != null)
				{
					nextButton.SetupButtonNavigation();
				}
				yield return new WaitForSeconds(_unlockToScrollTime);
				if (nextButton != null)
				{
					if (_buttonsToUnlockOnTransitioned.Contains(nextButton))
					{
						ScrollToButton(nextButton);
					}
					else
					{
						int num = _buttonsToUnlockOnTransitioned.IndexOf(button) + 1;
						if (_buttonsToUnlockOnTransitioned.Count > num)
						{
							ScrollToButton(_buttonsToUnlockOnTransitioned[num]);
							yield return new WaitForSeconds(_scrollToFlipTime);
						}
					}
				}
				yield return new WaitForSeconds(_scrollToFlipTime);
				button.FlipCard();
				yield return new WaitForSeconds(_scrollWaitTime);
			}
			if (!skipScroll)
			{
				yield return new WaitForSeconds(_unlockAnimationEndDelay);
				ScrollToButton(_lastSelectedButtonBeforeTransitionOut, skipScroll);
				yield return new WaitForSeconds(_unlockAnimationTimeToScrollToFirstElement);
			}
			foreach (MapButton item in _buttonsToUnlockOnTransitioned)
			{
				_player.ClearNewContentSeen(item.NewContentId);
				item.ShowNewContentIndicatorIfNeeded(playIntro: false);
			}
			if (_buttonToUnlockCityChallengeOnTransitioned != null)
			{
				_buttonToUnlockCityChallengeOnTransitioned.ShowCard(MapButton.Card.Challenge);
				_buttonToUnlockCityChallengeOnTransitioned = null;
			}
			_buttonsToUnlockOnTransitioned.Clear();
			_inputState.BlockAllInput = false;
			_isPlayingAnimation = false;
			_canvasGroup.SetInteractable(isInteractable: true);
		}

		public override void OnTransitionedIn()
		{
			base.OnTransitionedIn();
			_scaleToCamera = false;
			if (_newContentDatabase.IsNewContent("DailyWeeklyChallengeCards") && TryGetButtonOfType(MapButton.MapButtonType.WeeklyChallenge, out var result) && TryGetButtonOfType(MapButton.MapButtonType.DailyChallenge, out result))
			{
				StartCoroutine(TransitionInChallengeCards());
				_newContentDatabase.SetNewContentSeen("DailyWeeklyChallengeCards");
			}
			if (TryGetButtonOfType(MapButton.MapButtonType.WeeklyChallenge, out var result2) && result2.HasExpired)
			{
				OnChallengeExpired(result2);
			}
			if (TryGetButtonOfType(MapButton.MapButtonType.DailyChallenge, out var result3) && result3.HasExpired)
			{
				OnChallengeExpired(result3);
			}
			if (_buttonsToUnlockOnTransitioned.Count > 0)
			{
				StartCoroutine(RunUnlockAnimations());
			}
			else if (_buttonToUnlockCityChallengeOnTransitioned != null)
			{
				int index = IndexOf(_buttonToUnlockCityChallengeOnTransitioned);
				MapButtonAt(index).ShowCard(MapButton.Card.Challenge);
				_buttonToUnlockCityChallengeOnTransitioned = null;
			}
			else if (_buttonToUnlockExpertModeOnTransitioned != null)
			{
				int index2 = IndexOf(_buttonToUnlockExpertModeOnTransitioned);
				MapButtonAt(index2).ShowCard(MapButton.Card.Mode);
				_buttonToUnlockExpertModeOnTransitioned = null;
			}
			else if (_selectedChallengeIndex != -1 && _transitioningFromGameScreen)
			{
				CurrentlySelectedMapButton.ShowCard(MapButton.Card.Challenge);
				CurrentlySelectedMapButton.SelectedChallengeIndex = _selectedChallengeIndex;
				CurrentlySelectedMapButton.LeaderboardShowsSelectedChallenge = true;
			}
			if ((_storageService.Status.issues & PersistentStorageServiceIssues.QuotaExceeded) > PersistentStorageServiceIssues.None)
			{
				ShowiCloudStorageFullPopup();
			}
		}

		private IEnumerator WaitWhileThenExecute(Func<bool> predicate, Action action)
		{
			yield return new WaitWhile(predicate);
			action?.Invoke();
		}

		public void SavePreviouslyLockedMaps()
		{
			_previouslyLockedMapButtons.Clear();
			_previouslyLockedCityChallengeMapButtons.Clear();
			foreach (MapDefinition map in _mapDatabase.MapLibrary.Maps)
			{
				if (map.IsLocked(_appScope))
				{
					_previouslyLockedMapButtons.Add(map);
				}
				if (map.IsCityChallengeLocked(_appScope))
				{
					_previouslyLockedCityChallengeMapButtons.Add(map);
				}
			}
		}

		public override void TransitionInTick()
		{
			base.TransitionInTick();
			if (_transitioningFromGameScreen)
			{
				if (TransitionInPercentage() > 1f - _constants.PercentageOfDurationToUseForInitialMovement)
				{
					_canvasGroup.Alpha = 1f;
				}
				else
				{
					_canvasGroup.Alpha = 0f;
				}
				_transitionDetails = _screenStack.GetTransitionDetailsFrom(_previousScreen, base.ScreenType);
				Vector3 cameraPositionForTransitionFromGame = _constants.GetCameraPositionForTransitionFromGame(_transitionDetails, TransitionInPercentage(), _cityCameraTransitionPosition, _cityCameraTransitionHandle);
				_gameCamera.SetPosition(cameraPositionForTransitionFromGame);
			}
			if (_blurWhileTransitioning)
			{
				_gameCamera.customBlur.Strength = 1f - TransitionInPercentage();
			}
		}

		private bool TryGetButtonOfType(MapButton.MapButtonType buttonType, out MapButton result)
		{
			foreach (MapButton mapButton in MapButtons)
			{
				if (mapButton.Type == buttonType)
				{
					result = mapButton;
					return true;
				}
			}
			result = null;
			return false;
		}

		private IEnumerator TransitionInChallengeCards()
		{
			if (_skipTransitions)
			{
				yield return null;
			}
			int buttonIndex = _challengeButtonCount - 1;
			while (buttonIndex >= 0)
			{
				MapButtonAt(buttonIndex).EnterFromHidden();
				yield return new WaitForSeconds(_nextChallengeCardAppearDelay);
				int num = buttonIndex - 1;
				buttonIndex = num;
			}
		}

		public override void OnTransitionedOut()
		{
			firstFocus.animator.SetBool(DroppedDown, value: false);
			firstFocus.animator.Update(1f);
			foreach (MapButton mapButton in MapButtons)
			{
				mapButton.ResetAnimations();
			}
			if (_screenStack.GetTopActiveScreenType() == ScreenStack.MotorwaysScreen.ChallengeInfo)
			{
				_overrideNextTransitionDuration = -1f;
				return;
			}
			CancelButtonScrolling();
			base.OnTransitionedOut();
		}

		public void SelectMap(MapButton button)
		{
			_currentlySelectedButtonIndex = IndexOf(button);
			bool flag = true;
			bool flag2 = _challengeSystem.GetActiveDailyChallengeSaves(_player, localOnly: true).Count > 0;
			bool flag3 = _challengeSystem.GetActiveWeeklyChallengeSaves(_player, localOnly: true).Count > 0;
			MotorwaysTimedChallengeScore challengeScore = _player.GetChallengeScore(MapChallenge.ChallengeType.Daily, _challengeSystem.DailyChallenge.TimeEnd);
			bool flag4 = challengeScore.ScoreState == LeaderboardScoreState.Locked;
			bool flag5 = challengeScore.ScoreState == LeaderboardScoreState.Editable;
			bool hasLocalSavedGame = _player.HasLocalSavedGame;
			MapChallenge mapChallenge = button.MapChallenge;
			if (mapChallenge != null)
			{
				if (mapChallenge.type == MapChallenge.ChallengeType.Daily)
				{
					if (_newContentDatabase.IsNewContent("DailyChallengeTutorialPopup"))
					{
						ShowDailyChallengePopup(delayBeforeTransitioning);
					}
					else if (flag4 && !_hasSeenDailyChallengeCompletePopUp && !(hasLocalSavedGame || flag3))
					{
						flag = false;
						popupStack.PushPopup<ConfirmationPopup>().Initialise(_appScope, StringId.DailyChallenge, null, delegate
						{
							_hasSeenDailyChallengeCompletePopUp = true;
							BeginTransitionIntoGame(button.MapDefinition);
						}, StringId.DailyChallenge_LockedConfirmation);
					}
					else if (flag2 && flag5)
					{
						flag = false;
						popupStack.PushPopup<ConfirmationPopup>().Initialise(_appScope, StringId.DailyChallenge, null, delegate
						{
							BeginTransitionIntoGame(button.MapDefinition);
						}, StringId.DailyChallenge_SaveGameConfirmation);
					}
					else if (hasLocalSavedGame || flag3)
					{
						flag = false;
						popupStack.PushPopup<ConfirmationPopup>().Initialise(_appScope, StringId.StartNewGameHeader, null, delegate
						{
							BeginTransitionIntoGame(button.MapDefinition);
						}, StringId.SaveGameOverwriteConfirmation);
					}
				}
				else if (flag2 && flag5)
				{
					flag = false;
					popupStack.PushPopup<ConfirmationPopup>().Initialise(_appScope, StringId.DailyChallenge, null, delegate
					{
						BeginTransitionIntoGame(button.MapDefinition);
					}, StringId.DailyChallenge_SaveGameConfirmationNewMap);
				}
				else if (mapChallenge.type == MapChallenge.ChallengeType.Weekly)
				{
					if (_newContentDatabase.IsNewContent("WeeklyChallengeTutorialPopup"))
					{
						ShowWeeklyChallengePopup(delayBeforeTransitioning);
					}
					else if (hasLocalSavedGame || flag3)
					{
						flag = false;
						popupStack.PushPopup<ConfirmationPopup>().Initialise(_appScope, StringId.StartNewGameHeader, null, delegate
						{
							BeginTransitionIntoGame(button.MapDefinition);
						}, StringId.SaveGameOverwriteConfirmation);
					}
				}
				else if (mapChallenge.type == MapChallenge.ChallengeType.City && !_player.HasSeenNewContent("NewCityChallengeUnlockInfoPopup"))
				{
					ShowChallengeModeInfoPopup();
				}
				else if (hasLocalSavedGame || flag3)
				{
					flag = false;
					popupStack.PushPopup<ConfirmationPopup>().Initialise(_appScope, StringId.StartNewGameHeader, null, delegate
					{
						BeginTransitionIntoGame(button.MapDefinition);
					}, StringId.SaveGameOverwriteConfirmation);
				}
			}
			else if (flag2 && flag5)
			{
				flag = false;
				popupStack.PushPopup<ConfirmationPopup>().Initialise(_appScope, StringId.DailyChallenge, null, delegate
				{
					BeginTransitionIntoGame(button.MapDefinition);
				}, StringId.DailyChallenge_SaveGameConfirmationNewMap);
			}
			else if (hasLocalSavedGame || flag3)
			{
				flag = false;
				popupStack.PushPopup<ConfirmationPopup>().Initialise(_appScope, StringId.StartNewGameHeader, null, delegate
				{
					BeginTransitionIntoGame(button.MapDefinition);
				}, StringId.SaveGameOverwriteConfirmation);
			}
			if (flag)
			{
				BeginTransitionIntoGame(button.MapDefinition);
			}
		}

		private void BeginTransitionIntoGame(MapDefinition map)
		{
			for (int i = 0; i < buttons.Count; i++)
			{
				if (_currentlySelectedButtonIndex == i)
				{
					MapButtonAt(i).OnCardConfirmed();
					continue;
				}
				float a = (float)(Math.Abs(_currentlySelectedButtonIndex - i) - 1) * intervalBetweenButtonPushAnimations;
				a = Mathf.Min(a, 0.5f);
				MapButtonAt(i).OnOtherCardConfirmed(i < _currentlySelectedButtonIndex, a);
			}
			firstFocus.animator.SetBool(DroppedDown, value: true);
			_cityDefinition = AssetBundleUtility.LoadPrefabAsync(map.mapAssetBundle, map.mapPrefabName, this);
			scrollRect.enabled = false;
			_timerTillTransition = delayBeforeTransitioning;
		}

		public void SelectCurrentMap()
		{
			ScrollToNearestButton();
			SelectMap(CurrentlySelectedMapButton);
		}

		public void UpdateTheme()
		{
			RegisterThemeComponents(_themeDatabase.GetTheme());
			ApplyTheme(_themeDatabase.GetTheme());
		}

		public override void RegisterThemeComponents(ITheme theme)
		{
			base.RegisterThemeComponents(theme);
			foreach (AnimatedCard button in buttons)
			{
				button.RegisterThemeComponents();
			}
		}

		protected override void GetAutoThemeComponents(List<IThemeComponent> components)
		{
			List<GameObject> list = new List<GameObject>();
			list.Add(base.gameObject);
			GameObject gameObject = buttonParent.gameObject;
			while (list.Count > 0)
			{
				GameObject gameObject2 = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
				IThemeComponent component = gameObject2.GetComponent<IThemeComponent>();
				if (component != null)
				{
					components.Add(component);
				}
				Transform transform = gameObject2.transform;
				int childCount = transform.childCount;
				for (int i = 0; i < childCount; i++)
				{
					GameObject gameObject3 = transform.GetChild(i).gameObject;
					if (!(gameObject3 == gameObject))
					{
						list.Add(gameObject3);
					}
				}
			}
		}

		public int GetBestScoreForCityLeaderboard(string cityId, GameMode mode)
		{
			return _player.GetCityStatisticsForCity(cityId, mode)?.MaxTrips ?? 0;
		}

		private int GetBestScoreForChallenge(MapChallenge.ChallengeType challengeType)
		{
			if (!_challengeSystem.TryGetChallenge(challengeType, out var result))
			{
				Diagnostics.FailAssert("TryGetChallenge failed in GetBestScoreForChallenge");
				return 0;
			}
			int timeEnd = result.TimeEnd;
			MotorwaysTimedChallengeScore challengeScore = _player.GetChallengeScore(challengeType, timeEnd);
			if (challengeType == MapChallenge.ChallengeType.Daily && challengeScore.ScoreState == LeaderboardScoreState.Editable)
			{
				return -2;
			}
			return challengeScore.Score;
		}

		public override void ScrollToButton(AnimatedCard button, bool instantly = false)
		{
			if (CurrentlySelectedMapButton != button)
			{
				CurrentlySelectedMapButton.SetSelected(isSelected: false);
				if (!instantly)
				{
					_selectedChallengeIndex = -1;
				}
			}
			base.ScrollToButton(button, instantly);
			CurrentlySelectedMapButton.SetSelected(isSelected: true);
		}

		private void CreateMapButtons()
		{
			if (base.ButtonCount > 0)
			{
				foreach (MapButton mapButton6 in MapButtons)
				{
					mapButton6.ResetAnimations();
				}
				return;
			}
			List<AnimatedCard> list = new List<AnimatedCard>();
			_challengeButtonCount = 0;
			ChallengeDatabase challengeDatabase = _appScope.Get<ChallengeDatabase>();
			if (FeatureToggle.IsFeatureEnabled(Feature.RandomChallengesMapButton))
			{
				_challengeButtonCount++;
				MapButton mapButton = UnityEngine.Object.Instantiate(mapButtonPrefab, buttonParent);
				mapButton.name = "Mystery Challenge Map Button";
				mapButton.Initialize(this, _appScope, _constants);
				list.Add(mapButton);
			}
			if (_challengeSystem.WeeklyChallenge != null && _challengeSystem.AreChallengesUnlocked(_player))
			{
				_challengeButtonCount++;
				MapDefinition mapDefinition = _challengeSystem.WeeklyChallenge.mapDefinition;
				MapButton mapButton2 = UnityEngine.Object.Instantiate(mapButtonPrefab, buttonParent);
				mapButton2.name = "Weekly Challenge Map Button";
				int bestScoreForChallenge = GetBestScoreForChallenge(MapChallenge.ChallengeType.Weekly);
				mapButton2.Initialize(this, mapDefinition, _appScope, bestScoreForChallenge, _constants, _challengeSystem.WeeklyChallenge);
				mapButton2.SetChallengeIcons(_challengeSystem.WeeklyChallenge.challenges, challengeDatabase);
				mapButton2.SetSelected(isSelected: false);
				mapButton2.onChallengeExpired += OnChallengeExpired;
				mapButton2.onShowMoreChallengeInfo += ShowWeeklyChallengePopup;
				if (_newContentDatabase.IsNewContent("DailyWeeklyChallengeCards"))
				{
					mapButton2.SetHideLeft();
				}
				list.Add(mapButton2);
			}
			if (_challengeSystem.DailyChallenge != null && _challengeSystem.AreChallengesUnlocked(_player))
			{
				_challengeButtonCount++;
				MapDefinition mapDefinition2 = _challengeSystem.DailyChallenge.mapDefinition;
				MapButton mapButton3 = UnityEngine.Object.Instantiate(mapButtonPrefab, buttonParent);
				mapButton3.name = "Daily Challenge Map Button";
				int bestScoreForChallenge2 = GetBestScoreForChallenge(MapChallenge.ChallengeType.Daily);
				mapButton3.Initialize(this, mapDefinition2, _appScope, bestScoreForChallenge2, _constants, _challengeSystem.DailyChallenge);
				mapButton3.SetChallengeIcons(_challengeSystem.DailyChallenge.challenges, challengeDatabase);
				mapButton3.SetSelected(isSelected: false);
				mapButton3.onChallengeExpired += OnChallengeExpired;
				mapButton3.onShowMoreChallengeInfo += ShowDailyChallengePopup;
				if (_newContentDatabase.IsNewContent("DailyWeeklyChallengeCards"))
				{
					mapButton3.SetHideLeft();
				}
				list.Add(mapButton3);
			}
			int num = 0;
			foreach (MapDefinition map in _mapDatabase.MapLibrary.Maps)
			{
				int bestScoreForCityLeaderboard = GetBestScoreForCityLeaderboard(map.cityName, GameMode.Normal);
				MapButton mapButton4 = UnityEngine.Object.Instantiate(mapButtonPrefab, buttonParent);
				mapButton4.name = map.cityName + " Map Button";
				mapButton4.Initialize(this, map, _appScope, bestScoreForCityLeaderboard, _constants);
				mapButton4.onShowModeInfo += ShowModeInfoPopup;
				mapButton4.onExpertModeLockedPressed += ShowExpertUnlockInfoPopup;
				if (num > 0)
				{
					mapButton4.SetSelected(isSelected: false);
				}
				list.Add(mapButton4);
				num++;
			}
			SetNewButtons(list);
			ScrollToButton(buttons[_challengeButtonCount], instantly: true);
			if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				for (int i = 3; i < buttons.Count; i++)
				{
					MapButtonAt(i).SetLocked(StringId.None, StringId.AppleDemo_FeatureNotEnabled);
				}
			}
			else
			{
				for (int j = 0; j < buttons.Count; j++)
				{
					MapButton mapButton5 = MapButtonAt(j);
					if (mapButton5.Type == MapButton.MapButtonType.City && !mapButton5.IsRandomChallengeCard && (mapButton5.MapDefinition.IsLocked(_appScope) || _previouslyLockedMapButtons.Contains(mapButton5.MapDefinition)))
					{
						mapButton5.SetLocked(StringId.MapUnlock_ToUnlock, mapButton5.MapDefinition.HowToUnlockDescription);
					}
				}
			}
			for (int k = 0; k < buttons.Count; k++)
			{
				MapButtonAt(k).SetupButtonNavigation();
			}
			CurrentlySelectedMapButton.SetSelected(isSelected: true);
			RegisterButtons();
			SetScreenButtonNavigation();
			ScrollToButton(base.CurrentlySelectedButton, instantly: true);
		}

		public override void OnMoveCursor(Selectable currentFocus, MoveDirection direction)
		{
			if (_cityDefinition == null && !_isPlayingAnimation)
			{
				base.OnMoveCursor(currentFocus, direction);
			}
		}

		public void ShowDailyChallengeInfo()
		{
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.ChallengeInfo, delegate(ChallengeInfoScreen screen)
			{
				MapChallenge dailyChallenge = _challengeSystem.DailyChallenge;
				screen.PrepareScreen(MapChallenge.ChallengeType.Daily, new List<ChallengeData>(dailyChallenge.challenges), dailyChallenge.TimeStart, dailyChallenge.TimeEnd, StringId.Continue, changeBlurWhenTransitioning: true, showBackButton: false);
			}, additive: true);
		}

		public void ShowWeeklyChallengeInfo()
		{
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.ChallengeInfo, delegate(ChallengeInfoScreen screen)
			{
				MapChallenge weeklyChallenge = _challengeSystem.WeeklyChallenge;
				screen.PrepareScreen(MapChallenge.ChallengeType.Weekly, new List<ChallengeData>(weeklyChallenge.challenges), weeklyChallenge.TimeStart, weeklyChallenge.TimeEnd, StringId.Continue, changeBlurWhenTransitioning: true, showBackButton: false);
			}, additive: true);
		}

		private void TrySubmitOutstandingScores()
		{
			if (_leaderboardService.CanSubmitScoresOffline)
			{
				_player.MotorwaysExtendedUserProfile.GetAndClearUnsubmittedScores();
				return;
			}
			foreach (var (leaderboardId, score, scoreState) in _player.MotorwaysExtendedUserProfile.GetAndClearUnsubmittedScores())
			{
				_leaderboardService.SubmitScore(leaderboardId, score, scoreState);
			}
		}

		private void OnChallengeExpired(MapButton challengeMapButton)
		{
			challengeMapButton.ShowCard(MapButton.Card.Main);
			challengeMapButton.onAnimationMidFlip += OnButtonMidFlip;
			void OnButtonMidFlip()
			{
				ChallengeDatabase challengeDatabase = _appScope.Get<ChallengeDatabase>();
				if (_challengeSystem.TryGetChallenge(challengeMapButton.MapChallenge.type, out var result))
				{
					int bestScoreForChallenge = GetBestScoreForChallenge(result.type);
					challengeMapButton.SetChallengeData(result, _appScope, bestScoreForChallenge);
					challengeMapButton.SetChallengeIcons(result.challenges, challengeDatabase);
					challengeMapButton.onAnimationMidFlip -= OnButtonMidFlip;
					challengeMapButton.ApplyTheme();
					challengeMapButton.ShowNewContentIndicatorIfNeeded(playIntro: true);
					challengeMapButton.RefreshLeaderboardOptions(result, _appScope);
					LeaderboardId leaderboardIdForTimedChallenge = MapChallenge.GetLeaderboardIdForTimedChallenge(result.type, result.TimeStart);
					_appScope.Get<LeaderboardService>().ClearLeaderboardEntryCache(leaderboardIdForTimedChallenge);
				}
			}
		}

		public void ShowDailyChallengePopup()
		{
			ShowDailyChallengePopup(0f);
		}

		public void ShowDailyChallengePopup(float delay)
		{
			popupStack.PushPopup<ChallengeInfoPopup>(delay).Initialise(_appScope, StringId.DailyChallenge, StringId.DailyChallenge_Tutorial, OnPopupHidden);
			_appScope.Get<NewContentData>().SetNewContentSeen("DailyChallengeTutorialPopup");
			_popupHidden = false;
		}

		private void ShowModeInfoPopup()
		{
			popupStack.PushPopup<ModeInfoPopup>().Initialize(_appScope, CurrentlySelectedMapButton.GetCurrentSelectedGameMode(), OnPopupHidden);
			_popupHidden = false;
		}

		public void ShowExpertUnlockInfoPopup()
		{
			ExpertUnlockInfoPopup expertUnlockInfoPopup = popupStack.PushPopup<ExpertUnlockInfoPopup>();
			if (FeatureToggle.IsFeatureEnabled(Feature.ExpertLock))
			{
				expertUnlockInfoPopup.InfoText.SetStringId(_appScope, StringId.To_Unlock);
			}
			expertUnlockInfoPopup.Initialize(OnPopupHidden);
			_popupHidden = false;
		}

		public void ShowWeeklyChallengePopup()
		{
			ShowWeeklyChallengePopup(0f);
		}

		public void ShowWeeklyChallengePopup(float delay)
		{
			popupStack.PushPopup<ChallengeInfoPopup>(delay).Initialise(_appScope, StringId.WeeklyChallenge, StringId.WeeklyChallenge_Tutorial, OnPopupHidden);
			_appScope.Get<NewContentData>().SetNewContentSeen("WeeklyChallengeTutorialPopup");
			_popupHidden = false;
		}

		public void ShowChallengeModeInfoPopup()
		{
			popupStack.PushPopup<ChallengeInfoPopup>().Initialise(_appScope, StringId.CityChallenge_InfoPopup_Title, StringId.CityChallenge_InfoPopup_Body, OnPopupHidden);
			_player.SetNewContentSeen("NewCityChallengeUnlockInfoPopup");
			_popupHidden = false;
		}

		public override void OnGainedFocus()
		{
			base.OnGainedFocus();
			CurrentlySelectedMapButton?.ModeSelectCard?.OnRegainedFocus();
		}

		private void OnPopupHidden()
		{
			_popupHidden = true;
		}

		public void HideUnselectedButtons()
		{
			foreach (MapButton mapButton in MapButtons)
			{
				if (mapButton != CurrentlySelectedMapButton)
				{
					mapButton.CanvasGroup.Alpha = 0f;
				}
			}
		}

		public void OffsetNeighbouringCardsToButton(MapButton button, AnimatedCard.ExpansionLevel mainCardExpansionLevel)
		{
			if (button.IsInitialized)
			{
				int num = IndexOf(button);
				if (num > 0)
				{
					MapButtonAt(num - 1).SetOffset(mainCardExpansionLevel, isPushedLeft: true);
				}
				if (num < buttons.Count - 1)
				{
					MapButtonAt(num + 1).SetOffset(mainCardExpansionLevel);
				}
			}
		}

		public void SetThemePreference(MotorwaysThemePreference preference)
		{
			MotorwaysThemeDatabase.Log.Info("Setting theme to {0}", preference);
			MotorwaysThemePreference themePreference = _themeDatabase.ThemePreference;
			MotorwaysThemePreference motorwaysThemePreference = preference;
			if (themePreference == MotorwaysThemePreference.DarkColorblind || themePreference == MotorwaysThemePreference.Colorblind)
			{
				switch (motorwaysThemePreference)
				{
				case MotorwaysThemePreference.Colorful:
					motorwaysThemePreference = MotorwaysThemePreference.Colorblind;
					break;
				case MotorwaysThemePreference.Dark:
					motorwaysThemePreference = MotorwaysThemePreference.DarkColorblind;
					break;
				}
			}
			_themeDatabase.SetThemePreference(motorwaysThemePreference, saveThemePreference: true, playAudio: true, forceBlend: true);
			foreach (MapButton mapButton in MapButtons)
			{
				mapButton.EnsureThemeButtonSelectedState(preference);
			}
		}

		public override void ApplyTheme(ITheme newTheme)
		{
			base.ApplyTheme(newTheme);
			foreach (MapButton mapButton in MapButtons)
			{
				mapButton.ApplyTheme();
				GameMode selectedModeForMap = _player.GetSelectedModeForMap(mapButton.MapDefinition.cityName);
				mapButton.MainCard.UpdateModeStrings(selectedModeForMap);
			}
			SetScreenButtonNavigation();
		}

		public override void ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			if (progress >= 1f)
			{
				SetScreenButtonNavigation();
			}
			base.ApplyBlendedTheme(oldTheme, newTheme, progress);
			if (base.ButtonCount <= 0)
			{
				return;
			}
			foreach (MapButton mapButton in MapButtons)
			{
				mapButton.ApplyBlendedTheme(progress);
			}
		}

		protected override void OnSelectButton()
		{
			if (_cityDefinition == null)
			{
				base.OnSelectButton();
				SetScreenButtonNavigation();
			}
		}

		public void SetScreenButtonNavigation()
		{
			if (base.ButtonCount <= 0 || !(CurrentlySelectedMapButton != null))
			{
				return;
			}
			Navigation navigation = firstFocus.GetComponent<TouchButton>().navigation;
			if (CurrentlySelectedMapButton.IsLocked)
			{
				navigation.selectOnUp = backButton;
			}
			else if (CurrentlySelectedMapButton.CurrentCard != MapButton.Card.Leaderboard)
			{
				if (CurrentlySelectedMapButton.IsChallengeMapButton())
				{
					navigation.selectOnUp = CurrentlySelectedMapButton.MainCard.ChallengeButtonSet;
				}
				else if (CurrentlySelectedMapButton.CurrentCard != MapButton.Card.Challenge)
				{
					navigation.selectOnUp = CurrentlySelectedMapButton.LeaderboardTabButton.GetComponent<Selectable>();
				}
			}
			firstFocus.GetComponent<TouchButton>().navigation = navigation;
			navigation = backButton.GetComponent<TouchButton>().navigation;
			if (CurrentlySelectedMapButton.IsLocked)
			{
				navigation.selectOnDown = firstFocus;
				navigation.selectOnRight = firstFocus;
			}
			else if (CurrentlySelectedMapButton.IsChallengeMapButton())
			{
				navigation.selectOnDown = CurrentlySelectedMapButton.MoreInfoButton;
				navigation.selectOnRight = CurrentlySelectedMapButton.MoreInfoButton;
			}
			else
			{
				switch (_themeDatabase.ThemePreference)
				{
				case MotorwaysThemePreference.Dark:
				case MotorwaysThemePreference.DarkColorblind:
					navigation.selectOnDown = CurrentlySelectedMapButton.DarkSelect;
					navigation.selectOnRight = CurrentlySelectedMapButton.DarkSelect;
					break;
				case MotorwaysThemePreference.Maps:
					navigation.selectOnDown = CurrentlySelectedMapButton.MapsSelect;
					navigation.selectOnRight = CurrentlySelectedMapButton.MapsSelect;
					break;
				default:
					navigation.selectOnDown = CurrentlySelectedMapButton.ColorfulSelect;
					navigation.selectOnRight = CurrentlySelectedMapButton.ColorfulSelect;
					break;
				}
			}
			backButton.GetComponent<TouchButton>().navigation = navigation;
		}

		public void OnBack()
		{
			_screenStack.PopOneScreen();
		}

		public override void BackActivated()
		{
			if (_cityDefinition == null)
			{
				base.BackActivated();
			}
		}

		public override void PageSelected(Vector2 direction)
		{
			if (!_isPlayingAnimation)
			{
				base.PageSelected(direction);
				if (direction.x > 0f && _currentlySelectedButtonIndex < MapButtons.Count() - 1)
				{
					ScrollToButton(buttons[_currentlySelectedButtonIndex + 1]);
				}
				else if (direction.x < 0f && _currentlySelectedButtonIndex > 0)
				{
					ScrollToButton(buttons[_currentlySelectedButtonIndex - 1]);
				}
				ScrollToButton(base.CurrentlySelectedButton);
				_menuNavigation.SetNewFocus(CurrentlySelectedMapButton.PlayButton);
			}
		}

		[UsedImplicitly]
		public void OnChallengeSystemChangeDebugOffset(int numDays)
		{
			if (GameDateTime.Backend is AdjustableGameDateTime adjustableGameDateTime)
			{
				adjustableGameDateTime.UtcOffset += TimeSpan.FromDays(numDays);
			}
		}

		public void OnOpenChallengeCalendar()
		{
			popupStack.PushPopup<DebugOverlayScreen>();
		}

		private void ShowiCloudStorageFullPopup()
		{
			popupStack.PushPopup<LoadScreenInterruptionPopup>().Initialise(StringId.Options_iCloud, StringId.iCloudQuotaExceeded, OnPopupHidden);
			_player.NotifyPlayerOfSaveFailure();
			_popupHidden = false;
		}

		protected override void UnregisterThemeComponents()
		{
			base.UnregisterThemeComponents();
			foreach (AnimatedCard button in buttons)
			{
				button.UnregisterThemeComponents();
			}
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			base.OnReleasedFromScope(scope);
			DestroyButtons();
		}

		public override void Reset()
		{
			base.Reset();
			scrollRect.enabled = true;
			scrollRect.horizontalNormalizedPosition = 0f;
			_originPosition = null;
			_scaleToCamera = true;
			_timerTillTransition = -1f;
			_mapLoadedForGameScreen = false;
			_popupHidden = true;
			_transitioningFromGameScreen = false;
			_playButtonStringId = StringId.None;
			_handleDeepLinkOnTransition = false;
			_blurWhileTransitioning = false;
			_soakTestCountdown = 0f;
			_challengeButtonCount = 0;
			_selectedChallengeIndex = -1;
			_cityCameraTransitionPosition = default(Vector2);
			_cityCameraTransitionHandle = default(Vector2);
			_buttonsToUnlockOnTransitioned.Clear();
			_playHighlightedWhenLastActive = false;
			PlayerSelectedLeaderboardType = null;
			_isPlayingAnimation = false;
			_previousScreen = ScreenStack.MotorwaysScreen.MainMenu;
		}
	}
}
