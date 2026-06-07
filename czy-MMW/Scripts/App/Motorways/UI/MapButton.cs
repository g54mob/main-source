using System;
using System.Collections.Generic;
using System.Reflection;
using Client;
using Factory;
using JetBrains.Annotations;
using Motorways.Audio;
using Motorways.Leaderboards;
using Motorways.Themes;
using Motorways.Views;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class MapButton : AnimatedCard
	{
		public enum MapButtonType
		{
			City = 0,
			DailyChallenge = 1,
			WeeklyChallenge = 2
		}

		public enum Card
		{
			Main = 0,
			Leaderboard = 1,
			Locked = 2,
			Challenge = 3,
			Mode = 4
		}

		[SerializeField]
		private RectTransform mainCardParent;

		[SerializeField]
		private RectTransform leaderboardCardParent;

		[FormerlySerializedAs("lockCardParent")]
		[SerializeField]
		private RectTransform _lockCardParent;

		[SerializeField]
		private RectTransform _challengeCardParent;

		[SerializeField]
		private RectTransform _modeSelectCardParent;

		[SerializeField]
		private MapButtonMainCard cityCardPrefab;

		[SerializeField]
		private MapButtonLeaderboardCard _leaderboardCardPrefab;

		[SerializeField]
		private MapButtonLockedCard _lockedCardPrefab;

		[SerializeField]
		private MapButtonMainCard _mainChallengeCardPrefab;

		[SerializeField]
		private MapButtonChallengeCard _challengeCardPrefab;

		[SerializeField]
		private MapButtonModeSelectCard _modeSelectCardPrefab;

		[SerializeField]
		private MapButtonTab _mainTabButton;

		[SerializeField]
		private MapButtonTab _leaderboardTabButton;

		[SerializeField]
		private MapButtonTab _challengeTabButton;

		[SerializeField]
		private MapButtonTab _modeSelectTabButton;

		[SerializeField]
		private TouchButton _lockUnlockButton;

		private VisualConstantsData _visualConstants;

		private readonly List<IThemeComponent> _themedMapButtonComponents = new List<IThemeComponent>();

		private readonly List<IThemeComponent> _dynamicMapButtonComponents = new List<IThemeComponent>();

		private ITheme _lastThemeBlendedFrom;

		private ITheme _lastThemeBlendedTo;

		private MapButtonMainCard _mainCard;

		public bool _leaderboardShowsSelectedChallenge;

		private MapSelectScreen _screen;

		private MapDefinition _mapDefinition;

		private MapChallenge _mapChallenge;

		private StringKey _challengeTimeLeftKey;

		private StringId _previousChallengeTimerKey;

		private int _previousChallengeTimerCount;

		private bool _isUpdatingChallenge;

		private IScope _scope;

		private ActivePlayer _player;

		private MotorwaysThemeDatabase _themeDatabase;

		private Card _currentCard;

		private ITheme _previousTheme;

		private MotorwaysThemePreference _selectedTheme;

		private Selectable _playButton;

		private static readonly ProfilerMarker Profiler_ApplyBlendedTheme = new ProfilerMarker(ProfilerCategory.Scripts, "MapButton.ApplyBlendedTheme()");

		public MapButtonTab LeaderboardTabButton => _leaderboardTabButton;

		public MapButtonTab ChallengeTabButton => _challengeTabButton;

		public MapButtonTab ModeSelectTabButton => _modeSelectTabButton;

		public ThemeSelectButton ColorfulSelect => _mainCard.ColorfulSelect;

		public ThemeSelectButton DarkSelect => _mainCard.DarkSelect;

		public ThemeSelectButton MapsSelect => _mainCard.MapsSelect;

		public TouchButton MoreInfoButton => _mainCard.MoreInfoButton;

		public StringId PlayTextStringId => StringId.Play;

		public MapButtonMainCard MainCard => _mainCard;

		private MapButtonLeaderboardCard LeaderboardCard { get; set; }

		private MapButtonLockedCard LockedCard { get; set; }

		private MapButtonChallengeCard ChallengeCard { get; set; }

		public MapButtonModeSelectCard ModeSelectCard { get; set; }

		public CityChallengeData SelectedChallenge
		{
			get
			{
				CityChallengeData[] cityChallenges = _mapDefinition.cityChallenges;
				if (SelectedChallengeIndex >= 0 && SelectedChallengeIndex < cityChallenges.Length)
				{
					return cityChallenges[SelectedChallengeIndex];
				}
				return null;
			}
		}

		public int SelectedChallengeIndex { get; set; } = -1;

		public bool AreChallengesLocked
		{
			get
			{
				if (FeatureToggle.IsFeatureDisabled(Feature.MapUnlocks))
				{
					return false;
				}
				int bestScoreForCityLeaderboard = MapSelectScreen.GetBestScoreForCityLeaderboard(_mapDefinition.cityName, GameMode.Normal);
				return _mapDefinition.challengeModeTargetScore > bestScoreForCityLeaderboard;
			}
		}

		public bool LeaderboardShowsSelectedChallenge
		{
			get
			{
				return _leaderboardShowsSelectedChallenge;
			}
			set
			{
				_leaderboardShowsSelectedChallenge = value;
			}
		}

		private bool HasCityChallenge => SelectedChallengeIndex >= 0;

		public bool IsRandomChallengeCard { get; private set; }

		public MapSelectScreen MapSelectScreen => _screen;

		public MapButtonType Type { get; private set; }

		public Selectable PlayButton => _playButton;

		public bool IsLocked => _currentCard == Card.Locked;

		public Card CurrentCard => _currentCard;

		public MapDefinition MapDefinition => _mapDefinition;

		public MapChallenge MapChallenge
		{
			get
			{
				if (HasCityChallenge)
				{
					return MapChallenge.CreateCityChallenge(_scope.Get<ChallengeSystem>(), SelectedChallengeIndex, MapDefinition, SelectedChallenge.challenges, 0uL);
				}
				return _mapChallenge;
			}
		}

		public bool HasExpired => _mapChallenge.HasExpired();

		public override string NewContentId
		{
			get
			{
				switch (Type)
				{
				case MapButtonType.DailyChallenge:
				case MapButtonType.WeeklyChallenge:
					return $"New{Type}-{_mapChallenge.TimeStart}";
				case MapButtonType.City:
					return "NewCity-" + MapDefinition.cityName;
				default:
					Diagnostics.FailAssert("Unhandled map type: {0}", Type);
					return null;
				}
			}
		}

		protected override bool BypassNewContentData => true;

		private bool ShowsChallengeTab
		{
			get
			{
				if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
				{
					return false;
				}
				if (FeatureToggle.IsFeatureEnabled(Feature.CityChallenges))
				{
					return _mapChallenge == null;
				}
				return false;
			}
		}

		public event Action<MapButton> onChallengeExpired;

		public event Action<MapButton> onSelected;

		public event Action onShowMoreChallengeInfo;

		public event Action onShowModeInfo;

		public event Action onExpertModeLockedPressed;

		public void DeselectCityChallenge()
		{
			SelectedChallengeIndex = -1;
			LeaderboardShowsSelectedChallenge = false;
			if (ChallengeCard != null)
			{
				ChallengeCard.DeselectCityChallenge();
			}
		}

		public GameMode GetCurrentSelectedGameMode()
		{
			if (Type == MapButtonType.City)
			{
				if (ModeSelectCard != null)
				{
					return ModeSelectCard.GameMode;
				}
				return _player.GetSelectedModeForMap(_mapDefinition.mapName);
			}
			return GameMode.Normal;
		}

		protected override void Awake()
		{
			base.Awake();
			_animator = GetComponent<Animator>();
			_lockUnlockButton.gameObject.SetActive(FeatureToggle.IsFeatureEnabled(Feature.DebugMapUnlockButton));
		}

		public override void RegisterThemeComponents()
		{
			GetComponentsInChildren(includeInactive: true, _themedMapButtonComponents);
			foreach (IThemeComponent themedMapButtonComponent in _themedMapButtonComponents)
			{
				themedMapButtonComponent.InitializeTheme(_themeDatabase);
			}
		}

		public override void UnregisterThemeComponents()
		{
			foreach (IThemeComponent themedMapButtonComponent in _themedMapButtonComponents)
			{
				themedMapButtonComponent.ReleaseTheme(_themeDatabase);
			}
			_themedMapButtonComponents.Clear();
		}

		protected override void Update()
		{
			base.Update();
			if (!IsChallengeMapButton() || _scope == null || _isUpdatingChallenge)
			{
				return;
			}
			if (_mapChallenge.HasExpired())
			{
				this.onChallengeExpired?.Invoke(this);
				_isUpdatingChallenge = true;
				return;
			}
			int secondsLeft = _mapChallenge.SecondsLeft;
			int num = secondsLeft / 60;
			int num2 = num / 60;
			int num3 = num2 / 24;
			StringId stringId;
			int num4;
			if (num3 > 0)
			{
				stringId = StringId.Challenge_TimeLeft_Days;
				num4 = num3;
			}
			else if (num2 > 0)
			{
				stringId = StringId.Challenge_TimeLeft_Hours;
				num4 = num2;
			}
			else if (num > 0)
			{
				stringId = StringId.Challenge_TimeLeft_Minutes;
				num4 = num;
			}
			else
			{
				stringId = StringId.Challenge_TimeLeft_Seconds;
				num4 = secondsLeft;
			}
			if (stringId != _previousChallengeTimerKey || num4 != _previousChallengeTimerCount)
			{
				_challengeTimeLeftKey.InitWithStringId(stringId, num4, new Dictionary<string, string> { 
				{
					"Num",
					num4.ToString()
				} });
				_mainCard.TimeLeftText.LocString = StandaloneLocString.CreateString(_scope, _challengeTimeLeftKey);
				_previousChallengeTimerKey = stringId;
				_previousChallengeTimerCount = num4;
			}
		}

		public void OnClicked()
		{
			_screen.SelectMap(this);
		}

		public void ScrollToMe()
		{
			_screen.ScrollToButton(this);
		}

		public void ShowChallengeInfo()
		{
			if (Type == MapButtonType.DailyChallenge)
			{
				_screen.ShowDailyChallengeInfo();
			}
			else if (Type == MapButtonType.WeeklyChallenge)
			{
				_screen.ShowWeeklyChallengeInfo();
			}
		}

		public void SetThemePreference(MotorwaysThemePreference selectedTheme)
		{
			if (selectedTheme != _selectedTheme)
			{
				_selectedTheme = selectedTheme;
				_screen.SetThemePreference(selectedTheme);
			}
		}

		public void EnsureThemeButtonSelectedState(MotorwaysThemePreference? newTheme = null)
		{
			_selectedTheme = newTheme ?? _selectedTheme;
			switch (_selectedTheme)
			{
			case MotorwaysThemePreference.Dark:
			case MotorwaysThemePreference.DarkColorblind:
				ColorfulSelect.SetUnselected();
				DarkSelect.SetSelected();
				MapsSelect.SetUnselected();
				break;
			case MotorwaysThemePreference.Maps:
				ColorfulSelect.SetUnselected();
				DarkSelect.SetUnselected();
				MapsSelect.SetSelected();
				break;
			default:
				ColorfulSelect.SetSelected();
				DarkSelect.SetUnselected();
				MapsSelect.SetUnselected();
				break;
			}
		}

		public void SetupButtonNavigation()
		{
			MapButton previousButton = MapSelectScreen.GetPreviousButton(this);
			MapButton nextButton = MapSelectScreen.GetNextButton(this);
			Selectable firstFocus = MapSelectScreen.firstFocus;
			Selectable backButton = MapSelectScreen.backButton;
			MotorwaysThemePreference themePreference = _themeDatabase.ThemePreference;
			TouchButton touchButton = ((previousButton == null) ? null : ((previousButton._mainTabButton == null) ? null : previousButton._mainTabButton.GetComponent<TouchButton>()));
			TouchButton touchButton2 = ((previousButton == null) ? null : ((previousButton._leaderboardTabButton == null) ? null : previousButton._leaderboardTabButton.GetComponent<TouchButton>()));
			TouchButton touchButton3 = ((previousButton == null) ? null : ((previousButton._challengeTabButton == null) ? null : previousButton._challengeTabButton.GetComponent<TouchButton>()));
			TouchButton touchButton4 = ((previousButton == null) ? null : ((previousButton._modeSelectTabButton == null) ? null : previousButton._modeSelectTabButton.GetComponent<TouchButton>()));
			TouchButton touchButton5 = ((previousButton == null) ? null : previousButton.MoreInfoButton);
			if (previousButton != null && previousButton.IsLocked)
			{
				touchButton = previousButton.LockedCard.TouchButton;
				touchButton2 = previousButton.LockedCard.TouchButton;
				touchButton3 = previousButton.LockedCard.TouchButton;
				touchButton4 = previousButton.LockedCard.TouchButton;
				touchButton5 = previousButton.LockedCard.TouchButton;
			}
			TouchButton nextMainButton = ((nextButton == null) ? null : ((nextButton._mainTabButton == null) ? null : nextButton._mainTabButton.GetComponent<TouchButton>()));
			TouchButton nextLeaderboardButton = ((nextButton == null) ? null : ((nextButton._leaderboardTabButton == null) ? null : nextButton._leaderboardTabButton.GetComponent<TouchButton>()));
			TouchButton nextChallengeButton = ((nextButton == null) ? null : ((nextButton._challengeTabButton == null) ? null : nextButton._challengeTabButton.GetComponent<TouchButton>()));
			TouchButton nextModeSelectButton = ((nextButton == null) ? null : ((nextButton._modeSelectTabButton == null) ? null : nextButton._modeSelectTabButton.GetComponent<TouchButton>()));
			TouchButton touchButton6 = ((nextButton == null) ? null : nextButton.MoreInfoButton);
			if (nextButton != null && nextButton.IsLocked)
			{
				nextMainButton = nextButton.LockedCard.TouchButton;
				nextLeaderboardButton = nextButton.LockedCard.TouchButton;
				nextChallengeButton = nextButton.LockedCard.TouchButton;
				nextModeSelectButton = nextButton.LockedCard.TouchButton;
				touchButton6 = nextButton.LockedCard.TouchButton;
			}
			TouchButton mainButton = _mainTabButton.GetComponent<TouchButton>();
			TouchButton leaderboardButton = _leaderboardTabButton.GetComponent<TouchButton>();
			TouchButton challengeButton = _challengeTabButton.GetComponent<TouchButton>();
			TouchButton modeSelectButton = _modeSelectTabButton.GetComponent<TouchButton>();
			TouchButton touchButton7 = leaderboardButton;
			if (IsLocked)
			{
				AnimatedCard.SetNavigationOnLeft(LockedCard.TouchButton, touchButton);
				AnimatedCard.SetNavigationOnRight(LockedCard.TouchButton, nextMainButton);
				AnimatedCard.SetNavigationOnUp(LockedCard.TouchButton, backButton);
			}
			else
			{
				AnimatedCard.SetNavigationOnLeft(mainButton, touchButton);
				AnimatedCard.SetNavigationOnRight(mainButton, nextMainButton);
				AnimatedCard.SetNavigationOnLeft(leaderboardButton, touchButton2);
				AnimatedCard.SetNavigationOnRight(leaderboardButton, nextLeaderboardButton);
				AnimatedCard.SetNavigationOnLeft(challengeButton, (previousButton != null && previousButton.IsChallengeMapButton()) ? touchButton2 : touchButton3);
				AnimatedCard.SetNavigationOnRight(challengeButton, (nextButton != null && nextButton.IsChallengeMapButton()) ? nextLeaderboardButton : nextChallengeButton);
				AnimatedCard.SetNavigationOnLeft(modeSelectButton, (previousButton != null && previousButton.IsChallengeMapButton()) ? touchButton2 : touchButton4);
				AnimatedCard.SetNavigationOnRight(modeSelectButton, (nextButton != null && nextButton.IsChallengeMapButton()) ? nextLeaderboardButton : nextModeSelectButton);
				AnimatedCard.SetNavigationOnDown(touchButton7, firstFocus);
				switch (CurrentCard)
				{
				case Card.Main:
					if (IsChallengeMapButton())
					{
						AnimatedCard.SetNavigationOnDown(touchButton7, MainCard.ChallengeButtonSet);
					}
					SetTabButtonRightNavigation(goToNextMap: true);
					break;
				case Card.Leaderboard:
					AnimatedCard.SetNavigationOnDown(touchButton7, LeaderboardCard.LeaderboardHistogramButton);
					if (LeaderboardCard.LeaderboardHistogramButton.isActiveAndEnabled)
					{
						SetTabButtonRightNavigation(goToNextMap: false, LeaderboardCard.LeaderboardHistogramButton);
					}
					else
					{
						SetTabButtonRightNavigation(goToNextMap: false, LeaderboardCard.LeaderboardSelectorPrevious);
					}
					AnimatedCard.SetNavigationOnUp(LeaderboardCard.LeaderboardSelectorPrevious, backButton);
					AnimatedCard.SetNavigationOnUp(LeaderboardCard.LeaderboardSelectorNext, backButton);
					AnimatedCard.SetNavigationOnUp(LeaderboardCard.LeaderboardHistogramButton, LeaderboardCard.LeaderboardErrorButton);
					AnimatedCard.SetNavigationOnUp(LeaderboardCard.LeaderboardGlobalButton, LeaderboardCard.LeaderboardErrorButton);
					AnimatedCard.SetNavigationOnUp(LeaderboardCard.LeaderboardFriendsButton, LeaderboardCard.LeaderboardErrorButton);
					AnimatedCard.SetNavigationOnUp(LeaderboardCard.LeaderboardSurroundingButton, LeaderboardCard.LeaderboardErrorButton);
					AnimatedCard.SetNavigationOnUp(LeaderboardCard.LeaderboardErrorButton, LeaderboardCard.LeaderboardSelectorPrevious);
					AnimatedCard.SetNavigationOnDown(LeaderboardCard.LeaderboardSelectorPrevious, LeaderboardCard.LeaderboardErrorButton);
					AnimatedCard.SetNavigationOnDown(LeaderboardCard.LeaderboardSelectorNext, LeaderboardCard.LeaderboardErrorButton);
					AnimatedCard.SetNavigationOnDown(LeaderboardCard.LeaderboardHistogramButton, firstFocus);
					AnimatedCard.SetNavigationOnDown(LeaderboardCard.LeaderboardGlobalButton, firstFocus);
					AnimatedCard.SetNavigationOnDown(LeaderboardCard.LeaderboardFriendsButton, firstFocus);
					AnimatedCard.SetNavigationOnDown(LeaderboardCard.LeaderboardSurroundingButton, firstFocus);
					AnimatedCard.SetNavigationOnDown(LeaderboardCard.LeaderboardErrorButton, LeaderboardCard.LeaderboardHistogramButton);
					AnimatedCard.SetNavigationOnRight(LeaderboardCard.LeaderboardSelectorPrevious, LeaderboardCard.LeaderboardSelectorNext);
					AnimatedCard.SetNavigationOnLeft(LeaderboardCard.LeaderboardSelectorNext, LeaderboardCard.LeaderboardSelectorPrevious);
					AnimatedCard.SetNavigationOnLeft(LeaderboardCard.LeaderboardSelectorPrevious, leaderboardButton);
					AnimatedCard.SetNavigationOnLeft(LeaderboardCard.LeaderboardErrorButton, leaderboardButton);
					AnimatedCard.SetNavigationOnLeft(LeaderboardCard.LeaderboardHistogramButton, leaderboardButton);
					AnimatedCard.SetNavigationOnUp(firstFocus, touchButton7);
					AnimatedCard.SetNavigationOnRight(LeaderboardCard.LeaderboardSelectorNext, nextLeaderboardButton);
					AnimatedCard.SetNavigationOnRight(LeaderboardCard.LeaderboardSurroundingButton, nextLeaderboardButton);
					break;
				case Card.Challenge:
					SetTabButtonRightNavigation(goToNextMap: false, (nextButton != null && nextButton.IsChallengeMapButton()) ? nextLeaderboardButton : nextChallengeButton);
					AnimatedCard.SetNavigationOnUp(ChallengeCard.MoreInfoButton, MapSelectScreen.backButton);
					AnimatedCard.SetNavigationOnLeft(ChallengeCard.MoreInfoButton, challengeButton);
					if (ChallengeCard.ShowingCardAsLocked)
					{
						SetTabButtonRightNavigation(goToNextMap: false, ChallengeCard.MoreInfoButton);
					}
					else
					{
						TouchToggle[] challengeButtons = ChallengeCard.ChallengeButtons;
						int num = challengeButtons.Length;
						for (int i = 0; i < num; i++)
						{
							TouchToggle touchToggle = challengeButtons[i];
							if (i == 0)
							{
								SetTabButtonRightNavigation(goToNextMap: false, touchToggle);
							}
							AnimatedCard.SetNavigationOnLeft(touchToggle, challengeButton);
							AnimatedCard.SetNavigationOnRight(touchToggle, nextChallengeButton);
						}
						AnimatedCard.SetNavigationOnLeft(ChallengeCard.ChallengeModifiersButton, challengeButton);
						ChallengeCard.SetupChallengeModifiersButtonNavigation();
						bool flag = ChallengeCard.SelectedCityChallengeIndex != -1;
						if (num > 0)
						{
							TouchToggle selectOnUp = challengeButtons[num - 1];
							AnimatedCard.SetNavigationOnUp(ChallengeCard.ChallengeModifiersButton, selectOnUp);
							AnimatedCard.SetNavigationOnDown(ChallengeCard.ChallengeModifiersButton, flag ? firstFocus : null);
						}
						AnimatedCard.SetNavigationOnDown(touchButton7, flag ? _screen.firstFocus : null);
					}
					ChallengeCard.OnChallengeSelected += OnChallengeSelected;
					break;
				case Card.Mode:
					SetTabButtonRightNavigation(goToNextMap: false, ModeSelectCard.NormalButton);
					AnimatedCard.SetNavigationOnLeft(ModeSelectCard.NormalButton, modeSelectButton);
					AnimatedCard.SetNavigationOnLeft(ModeSelectCard.EndlessButton, modeSelectButton);
					AnimatedCard.SetNavigationOnLeft(ModeSelectCard.ExpertButton, modeSelectButton);
					AnimatedCard.SetNavigationOnLeft(ModeSelectCard.CreativeButton, modeSelectButton);
					AnimatedCard.SetNavigationOnDown(ModeSelectCard.CreativeButton, firstFocus);
					AnimatedCard.SetNavigationOnUp(ModeSelectCard.InfoButton, backButton);
					if (GetCurrentSelectedGameMode() == GameMode.Normal)
					{
						AnimatedCard.SetNavigationOnUp(ModeSelectCard.NormalButton, backButton);
					}
					else
					{
						AnimatedCard.SetNavigationOnUp(ModeSelectCard.NormalButton, ModeSelectCard.InfoButton);
					}
					AnimatedCard.SetNavigationOnDown(modeSelectButton, challengeButton);
					AnimatedCard.SetNavigationOnRight(ModeSelectCard.NormalButton, nextModeSelectButton);
					AnimatedCard.SetNavigationOnRight(ModeSelectCard.EndlessButton, nextModeSelectButton);
					AnimatedCard.SetNavigationOnRight(ModeSelectCard.ExpertButton, nextModeSelectButton);
					AnimatedCard.SetNavigationOnRight(ModeSelectCard.CreativeButton, nextModeSelectButton);
					AnimatedCard.SetNavigationOnRight(ModeSelectCard.InfoButton, nextModeSelectButton);
					break;
				}
			}
			if (IsChallengeMapButton())
			{
				AnimatedCard.SetNavigationOnUp(ColorfulSelect, MoreInfoButton);
				AnimatedCard.SetNavigationOnUp(DarkSelect, MoreInfoButton);
				AnimatedCard.SetNavigationOnUp(MapsSelect, MoreInfoButton);
				AnimatedCard.SetNavigationOnUp(MoreInfoButton, backButton);
				AnimatedCard.SetNavigationOnUp(MainCard.ChallengeButtonSet, touchButton7);
				AnimatedCard.SetNavigationOnDown(MainCard.ChallengeButtonSet, _screen.firstFocus);
				AnimatedCard.SetNavigationOnLeft(MoreInfoButton, (touchButton5 != null) ? touchButton5 : touchButton);
				AnimatedCard.SetNavigationOnRight(MoreInfoButton, (touchButton6 != null) ? touchButton6 : touchButton);
				AnimatedCard.SetNavigationOnUp(leaderboardButton, mainButton);
				AnimatedCard.SetNavigationOnDown(mainButton, leaderboardButton);
			}
			else
			{
				AnimatedCard.SetNavigationOnUp(ColorfulSelect, backButton);
				AnimatedCard.SetNavigationOnUp(DarkSelect, backButton);
				AnimatedCard.SetNavigationOnUp(MapsSelect, backButton);
			}
			AnimatedCard.SetNavigationOnDown(ColorfulSelect, mainButton);
			AnimatedCard.SetNavigationOnDown(DarkSelect, mainButton);
			AnimatedCard.SetNavigationOnDown(MapsSelect, mainButton);
			_selectedTheme = themePreference;
			EnsureThemeButtonSelectedState();
			SetupNavigationToThemeButtons(themePreference);
			void SetTabButtonRightNavigation(bool goToNextMap, Selectable selectOnRight = null)
			{
				AnimatedCard.SetNavigationOnRight(mainButton, goToNextMap ? nextMainButton : selectOnRight);
				AnimatedCard.SetNavigationOnRight(leaderboardButton, goToNextMap ? nextLeaderboardButton : selectOnRight);
				AnimatedCard.SetNavigationOnRight(challengeButton, goToNextMap ? nextChallengeButton : selectOnRight);
				AnimatedCard.SetNavigationOnRight(modeSelectButton, goToNextMap ? nextModeSelectButton : selectOnRight);
			}
		}

		private void OnChallengeSelected()
		{
			bool flag = ChallengeCard.SelectedCityChallengeIndex != -1;
			AnimatedCard.SetNavigationOnDown(_leaderboardTabButton.GetComponent<TouchButton>(), flag ? _screen.firstFocus : null);
			AnimatedCard.SetNavigationOnDown(ChallengeCard.ChallengeModifiersButton, flag ? _screen.firstFocus : null);
			ResetModeSelection();
		}

		public bool IsChallengeMapButton()
		{
			if (Type != MapButtonType.DailyChallenge)
			{
				return Type == MapButtonType.WeeklyChallenge;
			}
			return true;
		}

		private void SetupNavigationToThemeButtons(MotorwaysThemePreference themePreference)
		{
			TouchButton component = _mainTabButton.GetComponent<TouchButton>();
			ThemeSelectButton themeButton = GetThemeButton(themePreference);
			AnimatedCard.SetNavigationOnUp(component, themeButton);
			if (IsChallengeMapButton())
			{
				AnimatedCard.SetNavigationOnDown(MoreInfoButton, themeButton);
			}
		}

		private ThemeSelectButton GetThemeButton(MotorwaysThemePreference themePreference)
		{
			switch (themePreference)
			{
			case MotorwaysThemePreference.Maps:
				return MapsSelect;
			case MotorwaysThemePreference.Dark:
			case MotorwaysThemePreference.DarkColorblind:
				return DarkSelect;
			default:
				return ColorfulSelect;
			}
		}

		private void ShowRelevantTabs()
		{
			_mainTabButton.Show();
			_leaderboardTabButton.Show();
			if (ShowsChallengeTab)
			{
				_challengeTabButton.Show();
				_modeSelectTabButton.Show();
			}
			else
			{
				_challengeTabButton.Hide();
				_modeSelectTabButton.Hide();
				_leaderboardTabButton.transform.position = _modeSelectTabButton.transform.position;
			}
			_screen.SetScreenButtonNavigation();
		}

		public void SetSelected(bool isSelected)
		{
			if (isSelected)
			{
				base.interactable = false;
				if (_currentCard != Card.Locked)
				{
					ShowRelevantTabs();
				}
				this.onSelected?.Invoke(this);
			}
			else
			{
				base.interactable = true;
				if (_currentCard != Card.Locked)
				{
					_mainTabButton.Hide();
					_leaderboardTabButton.Hide();
					_challengeTabButton.Hide();
					_modeSelectTabButton.Hide();
				}
				DeselectCityChallenge();
				if (_currentCard != Card.Main && _currentCard != Card.Locked)
				{
					OnMainTabSelected();
					if (Type != MapButtonType.DailyChallenge && Type != MapButtonType.WeeklyChallenge)
					{
						SetupFrontCardForDefaultState();
					}
				}
			}
			_mainCard.OnMapButtonSelected(isSelected);
			if (isSelected && IsNewContentItem(_scope))
			{
				SetNewContentSeen(_scope);
				if (!IsNewContent(_scope))
				{
					PlayNewContentIndicatorExit();
				}
			}
		}

		public override bool IsNewContentItem(IScope appScope)
		{
			if (base.IsNewContentItem(appScope))
			{
				return !IsLocked;
			}
			return false;
		}

		public void SetChallengeIcons(ChallengeData[] challenges, ChallengeDatabase challengeDatabase)
		{
			_mainCard.SetChallengeIcons(challenges, challengeDatabase);
		}

		public override void SetSelectedValue(float distance)
		{
			base.SetSelectedValue(distance);
			ColorfulSelect.SetSelectorAlpha(distance);
			DarkSelect.SetSelectorAlpha(distance);
			MapsSelect.SetSelectorAlpha(distance);
		}

		public override void OnCardConfirmed()
		{
			base.OnCardConfirmed();
			if (_currentCard != Card.Main)
			{
				if (_currentCard == Card.Challenge)
				{
					SetupFrontCardForCityChallenge(SelectedChallengeIndex);
				}
				OnMainTabSelected();
			}
			_mainTabButton.Hide();
			_leaderboardTabButton.Hide();
			_challengeTabButton.Hide();
			_modeSelectTabButton.Hide();
		}

		public void Initialize(MapSelectScreen screen, IScope scope, VisualConstantsData visualConstants)
		{
			if (FeatureToggle.IsFeatureDisabled(Feature.RandomChallengesMapButton))
			{
				Diagnostics.FailAssert("Tried to initialize a random map button without having the feature enabled!");
			}
			_scope = scope;
			_player = _scope.Get<ActivePlayer>();
			_visualConstants = visualConstants;
			IsRandomChallengeCard = true;
			AssignRandomMapChallenge();
			Initialize(screen, _mapDefinition, scope, 0, _visualConstants, _mapChallenge);
			Type = MapButtonType.City;
			_mainCard.Header.SetStringId(scope, StringId.Challenge_RandomChallengesMapTitle);
			_mainCard.Description.SetStringId(scope, StringId.Challenge_RandomChallengesMapDescription);
			_mainCard.BestScoreText.gameObject.SetActive(value: false);
			_mainCard.CurrentModeText.gameObject.SetActive(value: false);
			_mainTabButton.gameObject.SetActive(value: false);
			_leaderboardTabButton.gameObject.SetActive(value: false);
			_challengeTabButton.gameObject.SetActive(value: false);
			_modeSelectTabButton.gameObject.SetActive(value: false);
		}

		public void Initialize(MapSelectScreen screen, MapDefinition definition, IScope scope, int bestScore, VisualConstantsData visualConstants, MapChallenge mapChallenge = null)
		{
			_screen = screen;
			_mapDefinition = definition;
			_scope = scope;
			_player = _scope.Get<ActivePlayer>();
			_mapChallenge = mapChallenge;
			Type = GetButtonType(mapChallenge);
			_challengeTimeLeftKey = scope.Get<MotorwaysStringKey>();
			_visualConstants = visualConstants;
			if (_mainCard != null)
			{
				UnityEngine.Object.Destroy(_mainCard.gameObject);
			}
			switch (Type)
			{
			case MapButtonType.City:
				_mainCard = UnityEngine.Object.Instantiate(cityCardPrefab, mainCardParent);
				_mainCard.parentMapButton = this;
				_mainCard.Header.SetStringId(scope, definition.mapName);
				_mainCard.Description.SetStringId(scope, definition.mapDescription);
				SetBestScoreTextOnMainCard(scope, bestScore);
				break;
			case MapButtonType.DailyChallenge:
				_mainCard = UnityEngine.Object.Instantiate(_mainChallengeCardPrefab, mainCardParent);
				_mainCard.Header.SetStringId(_scope, StringId.DailyChallenge);
				_mainCard.parentMapButton = this;
				SetChallengeData(mapChallenge, scope, bestScore);
				break;
			case MapButtonType.WeeklyChallenge:
				_mainCard = UnityEngine.Object.Instantiate(_mainChallengeCardPrefab, mainCardParent);
				_mainCard.Header.SetStringId(_scope, StringId.WeeklyChallenge);
				_mainCard.parentMapButton = this;
				SetChallengeData(mapChallenge, scope, bestScore);
				break;
			}
			_mainCard.SetMapType(definition.isTrainMap, definition.isBoatMap);
			BaseInitializeCard(_mainCard);
			_mainCard.onMoreChallengeInfoPressed += delegate
			{
				this.onShowMoreChallengeInfo?.Invoke();
			};
			_mainCard.ColorfulSelect.mapButton = this;
			_mainCard.DarkSelect.mapButton = this;
			_mainCard.MapsSelect.mapButton = this;
			if (LockedCard != null)
			{
				UnityEngine.Object.Destroy(LockedCard.gameObject);
			}
			if (LeaderboardCard != null)
			{
				UnityEngine.Object.Destroy(LeaderboardCard.gameObject);
			}
			if (ModeSelectCard != null)
			{
				UnityEngine.Object.Destroy(ModeSelectCard.gameObject);
			}
			_themeDatabase = scope.Get<MotorwaysThemeDatabase>();
			_previousTheme = _mapDefinition.themes[(int)_themeDatabase.ThemePreference];
			UnregisterThemeComponents();
			RegisterThemeComponents();
			_mainCard.PreviewImage.sprite = _mapDefinition.themePreviewSprites[(int)_themeDatabase.ThemePreference];
			_mainTabButton.OnClicked();
			_leaderboardTabButton.OnOtherTabSelected();
			_challengeTabButton.OnOtherTabSelected();
			_modeSelectTabButton.OnOtherTabSelected();
			if (!AreChallengesLocked)
			{
				_challengeTabButton.TouchButton.SetNewContentID(MapButtonChallengeCard.GetNewContentIndicatorID(definition), bypassNewContent: true, isManuallyTriggered: true);
			}
			if (_mapDefinition.IsExpertModeUnlocked(_scope))
			{
				_modeSelectTabButton.TouchButton.SetNewContentID(MapButtonModeSelectCard.GetNewContentIndicatorID(definition), bypassNewContent: true, isManuallyTriggered: true);
			}
			_currentCard = Card.Main;
			SetNextCard();
			_mainCard.Initialize(_scope, _visualConstants);
			if (!ShowsChallengeTab)
			{
				_challengeTabButton.gameObject.SetActive(value: false);
				_modeSelectTabButton.gameObject.SetActive(value: false);
			}
		}

		private void InitializeRecurringLeaderboardSelector()
		{
			TouchOptionButton recurringLeaderboardSelector = LeaderboardCard.RecurringLeaderboardSelector;
			recurringLeaderboardSelector.gameObject.SetActive(value: false);
			recurringLeaderboardSelector.onOptionChanged.AddListener(OnLeaderboardSelectorChanged);
			if (_mapChallenge != null)
			{
				recurringLeaderboardSelector.gameObject.SetActive(value: true);
				if (_mapChallenge.type == MapChallenge.ChallengeType.Daily)
				{
					ChallengeSystem challengeSystem = _scope.Get<ChallengeSystem>();
					SetRecurringLeaderboardStartDay(challengeSystem.DailyChallenge.StartOfChallenge.DayOfWeek);
					recurringLeaderboardSelector.SetOption(recurringLeaderboardSelector.options.Length - 1, invokeMethod: false);
				}
				else if (_mapChallenge.type == MapChallenge.ChallengeType.Weekly)
				{
					recurringLeaderboardSelector.options = LeaderboardCard.RecurringWeekOptions;
					recurringLeaderboardSelector.SetOption(recurringLeaderboardSelector.options.Length - 1, invokeMethod: false);
				}
			}
			else if (_mapDefinition.cityChallenges.Length != 0)
			{
				recurringLeaderboardSelector.gameObject.SetActive(value: true);
				recurringLeaderboardSelector.options = LeaderboardCard.RecurringTypeOptions;
				recurringLeaderboardSelector.SetOption(0, invokeMethod: false);
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				recurringLeaderboardSelector.gameObject.SetActive(value: false);
			}
		}

		public void SetRecurringLeaderboardStartDay(DayOfWeek dayOfWeek)
		{
			TouchOptionButton recurringLeaderboardSelector = LeaderboardCard.RecurringLeaderboardSelector;
			GameObject[] array = new GameObject[7];
			for (int i = 0; i < 7; i++)
			{
				int num = (int)(i + dayOfWeek + 1) % 7;
				array[i] = LeaderboardCard.RecurringDayOptions[num];
			}
			recurringLeaderboardSelector.options = array;
		}

		public void RefreshLeaderboardOptions(MapChallenge challenge, IScope scope)
		{
			if (LeaderboardCard != null)
			{
				if (challenge.type == MapChallenge.ChallengeType.Daily)
				{
					ChallengeSystem challengeSystem = scope.Get<ChallengeSystem>();
					SetRecurringLeaderboardStartDay(challengeSystem.DailyChallenge.StartOfChallenge.DayOfWeek);
				}
				TouchOptionButton recurringLeaderboardSelector = LeaderboardCard.RecurringLeaderboardSelector;
				recurringLeaderboardSelector.SetOption(recurringLeaderboardSelector.options.Length - 1, invokeMethod: false);
			}
		}

		private void InitializeLeaderboardPanel(MapButton button)
		{
			if (Diagnostics.Verify(button.LeaderboardCard.LeaderboardPanel != null))
			{
				bool leaderboardShowsSelectedChallenge = LeaderboardShowsSelectedChallenge;
				if (!leaderboardShowsSelectedChallenge)
				{
					DeselectCityChallenge();
				}
				button.LeaderboardCard.LeaderboardPanel.Initialize(_scope, LeaderboardCard.RecurringLeaderboardSelector, this);
				if (GetCurrentSelectedGameMode() == GameMode.Expert && !leaderboardShowsSelectedChallenge)
				{
					LeaderboardCard.RecurringLeaderboardSelector.SetOption(1);
				}
				LeaderboardId leaderboardIdForMapButton = GetLeaderboardIdForMapButton();
				button.LeaderboardCard.LeaderboardPanel.ShowLeaderboardFor(GetDefaultLeaderboardType(), leaderboardIdForMapButton);
				if (leaderboardShowsSelectedChallenge)
				{
					DeselectCityChallenge();
				}
			}
		}

		private void OnLeaderboardSelectorChanged(int index)
		{
			LeaderboardCard.LeaderboardPanel.ShowLeaderboardFor(GetDefaultLeaderboardType(), GetLeaderboardIdForMapButton());
		}

		private LeaderboardType GetDefaultLeaderboardType()
		{
			if (_screen.PlayerSelectedLeaderboardType.HasValue)
			{
				LeaderboardType value = _screen.PlayerSelectedLeaderboardType.Value;
				if (value != LeaderboardType.Global || IsChallengeMapButton())
				{
					return value;
				}
			}
			return LeaderboardType.Histogram;
		}

		public void AssignRandomMapChallenge()
		{
			ChallengeSystem challengeSystem = _scope.Get<ChallengeSystem>();
			ChallengeDatabase challengeDatabase = _scope.Get<ChallengeDatabase>();
			_mapChallenge = MapChallenge.CreateMysteryChallenge(challengeSystem, challengeDatabase);
			_mapDefinition = _mapChallenge.mapDefinition;
		}

		private static MapButtonType GetButtonType(MapChallenge mapChallenge)
		{
			MapButtonType result = MapButtonType.City;
			if (mapChallenge != null)
			{
				if (mapChallenge.type == MapChallenge.ChallengeType.Daily)
				{
					result = MapButtonType.DailyChallenge;
				}
				else if (mapChallenge.type == MapChallenge.ChallengeType.Weekly)
				{
					result = MapButtonType.WeeklyChallenge;
				}
			}
			return result;
		}

		public void SetChallengeData(MapChallenge mapChallenge, IScope scope, int bestScore = 0)
		{
			_mapChallenge = mapChallenge;
			_mapDefinition = mapChallenge.mapDefinition;
			_mainCard.Header.SetStringId(scope, (Type == MapButtonType.DailyChallenge) ? StringId.DailyChallenge : StringId.WeeklyChallenge);
			_mainCard.Description.SetStringId(scope, mapChallenge.mapDefinition.mapName);
			_isUpdatingChallenge = false;
			SetBestScoreTextOnMainCard(scope, bestScore);
			_mainCard.SetMapType(mapChallenge.mapDefinition.isTrainMap, mapChallenge.mapDefinition.isBoatMap);
		}

		public void SetBestScoreTextOnModeCard(IScope scope, int bestScore)
		{
			if (ModeSelectCard != null)
			{
				SetBestScoreText(scope, bestScore, ModeSelectCard.BestScoreText);
			}
		}

		public void SetBestScoreTextOnMainCard(IScope scope, int bestScore)
		{
			SetBestScoreText(scope, bestScore, MainCard.BestScoreText);
		}

		private void SetBestScoreText(IScope scope, int bestScore, LocalizedTextUI textUI)
		{
			if (IsRandomChallengeCard)
			{
				return;
			}
			MotorwaysStringKey motorwaysStringKey = scope.Get<MotorwaysStringKey>();
			if (Type == MapButtonType.City)
			{
				GameMode currentSelectedGameMode = GetCurrentSelectedGameMode();
				if (currentSelectedGameMode == GameMode.Endless || currentSelectedGameMode == GameMode.Creative)
				{
					textUI.gameObject.SetActive(value: false);
					return;
				}
				textUI.gameObject.SetActive(value: true);
				motorwaysStringKey.InitWithStringId(StringId.BestScore, bestScore, new Dictionary<string, string> { 
				{
					"Num",
					bestScore.ToString()
				} });
				textUI.LocString = StandaloneLocString.CreateString(scope, motorwaysStringKey);
			}
			else if (IsChallengeMapButton())
			{
				switch (bestScore)
				{
				case -1:
					motorwaysStringKey.InitWithStringId(StringId.New);
					break;
				case -2:
					motorwaysStringKey.InitWithStringId(StringId.InProgress);
					break;
				default:
					motorwaysStringKey.InitWithStringId(StringId.Score, bestScore, new Dictionary<string, string> { 
					{
						"Num",
						bestScore.ToString()
					} });
					break;
				}
				textUI.LocString = StandaloneLocString.CreateString(scope, motorwaysStringKey);
			}
		}

		private void OnMainTabSelected()
		{
			if (_currentCard != Card.Main)
			{
				ShowCard(Card.Main);
			}
		}

		[UsedImplicitly]
		public void OnMainTabClicked()
		{
			DeselectCityChallenge();
			if (Type == MapButtonType.City)
			{
				SetupFrontCardForDefaultState();
			}
			OnMainTabSelected();
		}

		private void SetupFrontCardForDefaultState()
		{
			GameMode currentSelectedGameMode = GetCurrentSelectedGameMode();
			int bestScoreForCityLeaderboard = MapSelectScreen.GetBestScoreForCityLeaderboard(_mapDefinition.cityName, currentSelectedGameMode);
			SetBestScoreTextOnMainCard(_scope, bestScoreForCityLeaderboard);
			_mainCard.Description.LocString = StandaloneLocString.CreateString(_scope, MapDefinition.mapDescription);
		}

		public void SetupFrontCardForCityChallenge(int challengeIndex)
		{
			CityChallengeStatistics cityChallengeScore = _player.GetCityChallengeScore(MapDefinition.cityName, GameMode.Normal, challengeIndex);
			SetBestScoreTextOnMainCard(_scope, cityChallengeScore.BestScore);
			_mainCard.Description.LocString = StandaloneLocString.CreateString(_scope, MapDefinition.cityChallenges[challengeIndex].titleStringId);
		}

		public void ShowCard(Card card)
		{
			_currentCard = card;
			TweenToNextCard();
			base.onAnimationMidFlip += OnTabSelectMidFlip;
		}

		public void OnLeaderboardTabSelected()
		{
			if (_currentCard != Card.Leaderboard)
			{
				ShowCard(Card.Leaderboard);
			}
		}

		public void OnChallengeTabSelected()
		{
			if (_currentCard != Card.Challenge)
			{
				ShowCard(Card.Challenge);
			}
		}

		public override void OnTabSelectMidFlip()
		{
			SetNextCard();
			base.OnTabSelectMidFlip();
		}

		public void OnChallengeModeMoreInfoButtonClicked()
		{
			_screen.ShowChallengeModeInfoPopup();
		}

		private void OnModeSelectTabSelected()
		{
			if (_currentCard != Card.Mode)
			{
				ShowCard(Card.Mode);
			}
		}

		[UsedImplicitly]
		public void OnModeSelectTabClicked()
		{
			DeselectCityChallenge();
			if (Type == MapButtonType.City)
			{
				SetupFrontCardForDefaultState();
			}
			OnModeSelectTabSelected();
		}

		public void RefreshTabs()
		{
			switch (_currentCard)
			{
			case Card.Main:
				_mainTabButton.SetSelected(isSelected: true);
				_leaderboardTabButton.SetSelected(isSelected: false);
				_challengeTabButton.SetSelected(isSelected: false);
				_modeSelectTabButton.SetSelected(isSelected: false);
				break;
			case Card.Leaderboard:
				_mainTabButton.SetSelected(isSelected: false);
				_leaderboardTabButton.SetSelected(isSelected: true);
				_challengeTabButton.SetSelected(isSelected: false);
				_modeSelectTabButton.SetSelected(isSelected: false);
				break;
			case Card.Locked:
				_mainTabButton.SetSelected(isSelected: false);
				_leaderboardTabButton.SetSelected(isSelected: false);
				_challengeTabButton.SetSelected(isSelected: false);
				_modeSelectTabButton.SetSelected(isSelected: false);
				break;
			case Card.Challenge:
				_mainTabButton.SetSelected(isSelected: false);
				_leaderboardTabButton.SetSelected(isSelected: false);
				_challengeTabButton.SetSelected(isSelected: true);
				_modeSelectTabButton.SetSelected(isSelected: false);
				break;
			case Card.Mode:
				_mainTabButton.SetSelected(isSelected: false);
				_leaderboardTabButton.SetSelected(isSelected: false);
				_challengeTabButton.SetSelected(isSelected: false);
				_modeSelectTabButton.SetSelected(isSelected: true);
				break;
			}
		}

		private void SetNextCard()
		{
			switch (_currentCard)
			{
			case Card.Leaderboard:
				if (LeaderboardCard == null)
				{
					LeaderboardCard = UnityEngine.Object.Instantiate(_leaderboardCardPrefab, leaderboardCardParent);
					BaseInitializeCard(LeaderboardCard);
					InitializeRecurringLeaderboardSelector();
				}
				SetCardInvisible(_mainCard);
				SetCardVisible(LeaderboardCard);
				SetCardInvisible(LockedCard);
				SetCardInvisible(ChallengeCard);
				SetCardInvisible(ModeSelectCard);
				_mainTabButton.OnOtherTabSelected();
				_leaderboardTabButton.OnClicked();
				_challengeTabButton.OnOtherTabSelected();
				_modeSelectTabButton.OnOtherTabSelected();
				SetExpanded(ExpansionLevel.Wide);
				InitializeLeaderboardPanel(this);
				break;
			case Card.Main:
				SetCardVisible(_mainCard);
				SetCardInvisible(LeaderboardCard);
				SetCardInvisible(LockedCard);
				SetCardInvisible(ChallengeCard);
				SetCardInvisible(ModeSelectCard);
				_mainTabButton.OnClicked();
				_leaderboardTabButton.OnOtherTabSelected();
				_challengeTabButton.OnOtherTabSelected();
				_modeSelectTabButton.OnOtherTabSelected();
				SetExpanded(ExpansionLevel.Narrow);
				break;
			case Card.Locked:
				if (LockedCard == null)
				{
					LockedCard = UnityEngine.Object.Instantiate(_lockedCardPrefab, _lockCardParent);
					BaseInitializeCard(LockedCard);
					LockedCard.Header.SetStringId(_scope, _mapDefinition.mapName);
					LockedCard.OnNavButtonClicked += ScrollToMe;
				}
				SetCardInvisible(_mainCard);
				SetCardInvisible(LeaderboardCard);
				SetCardInvisible(ModeSelectCard);
				SetCardVisible(LockedCard);
				SetCardInvisible(ChallengeCard);
				_mainTabButton.Hide();
				_leaderboardTabButton.Hide();
				break;
			case Card.Challenge:
				if (ChallengeCard == null)
				{
					ChallengeCard = UnityEngine.Object.Instantiate(_challengeCardPrefab, _challengeCardParent);
					BaseInitializeCard(ChallengeCard);
					ChallengeCard.Initialize(_scope, this);
				}
				ChallengeCard.UpdateChallengeButtonScores();
				if (LeaderboardShowsSelectedChallenge)
				{
					ChallengeCard.SelectChallengeIndex(SelectedChallengeIndex);
					LeaderboardShowsSelectedChallenge = true;
				}
				SetCardInvisible(_mainCard);
				SetCardInvisible(LeaderboardCard);
				SetCardInvisible(LockedCard);
				SetCardInvisible(ModeSelectCard);
				SetCardVisible(ChallengeCard);
				_challengeTabButton.OnClicked();
				_leaderboardTabButton.OnOtherTabSelected();
				_mainTabButton.OnOtherTabSelected();
				_modeSelectTabButton.OnOtherTabSelected();
				SetExpanded(ExpansionLevel.Wide);
				break;
			case Card.Mode:
				if (ModeSelectCard == null)
				{
					ModeSelectCard = UnityEngine.Object.Instantiate(_modeSelectCardPrefab, _modeSelectCardParent);
					BaseInitializeCard(ModeSelectCard);
					ModeSelectCard.Initialize(_scope, _visualConstants, this);
					GameMode currentSelectedGameMode = GetCurrentSelectedGameMode();
					int bestScoreForCityLeaderboard = MapSelectScreen.GetBestScoreForCityLeaderboard(_mapDefinition.cityName, currentSelectedGameMode);
					SetBestScoreTextOnModeCard(_scope, bestScoreForCityLeaderboard);
					ModeSelectCard.onMoreModeInfoPressed += delegate
					{
						this.onShowModeInfo?.Invoke();
					};
					ModeSelectCard.onModePressed += delegate
					{
						OnModeSelected();
					};
					ModeSelectCard.onExpertLockedPressed += delegate
					{
						this.onExpertModeLockedPressed?.Invoke();
					};
				}
				base.onFlipAnimationComplete -= ModeSelectCard.UpdateButtonLockStatus;
				base.onFlipAnimationComplete += ModeSelectCard.UpdateButtonLockStatus;
				SetCardVisible(ModeSelectCard);
				SetCardInvisible(_mainCard);
				SetCardInvisible(LeaderboardCard);
				SetCardInvisible(LockedCard);
				SetCardInvisible(ChallengeCard);
				_modeSelectTabButton.OnClicked();
				_leaderboardTabButton.OnOtherTabSelected();
				_challengeTabButton.OnOtherTabSelected();
				_mainTabButton.OnOtherTabSelected();
				SetExpanded(ExpansionLevel.Medium);
				break;
			}
			SetupButtonNavigation();
			ColorfulSelect.gameObject.SetActive(_currentCard == Card.Main);
			DarkSelect.gameObject.SetActive(_currentCard == Card.Main);
			MapsSelect.gameObject.SetActive(_currentCard == Card.Main && !_themeDatabase.IsInColorblindMode);
		}

		protected override void SetExpanded(ExpansionLevel expansionLevel)
		{
			base.SetExpanded(expansionLevel);
			_screen.OffsetNeighbouringCardsToButton(this, expansionLevel);
		}

		private void SetCardVisible(MapButtonCard card)
		{
			card.SetVisible(isVisible: true);
		}

		private void SetCardInvisible(MapButtonCard card)
		{
			if (card != null)
			{
				card.SetVisible(isVisible: false);
			}
		}

		private void BaseInitializeCard(MapButtonCard card)
		{
			List<IThemeComponent> list = new List<IThemeComponent>();
			card.GetComponentsInChildren(includeInactive: true, list);
			MapSelectScreen.RegisterAdditionalThemeComponents(list);
			List<VariableDeviceSelectable> list2 = new List<VariableDeviceSelectable>();
			card.GetComponentsInChildren(includeInactive: true, list2);
			MapSelectScreen.RegisterAdditionalButtons(list2);
			List<LocalizedTextUI> list3 = new List<LocalizedTextUI>();
			card.GetComponentsInChildren(includeInactive: true, list3);
			MapSelectScreen.RegisterAdditionalLocalizedTextChildren(list3);
		}

		public void ApplyTheme()
		{
			Color color = _mapDefinition.themes[_themeDatabase.IsInColorblindMode ? 3 : 0].GetColor(ThemedMaterialType.PrimaryMenu);
			ColorfulSelect.themeColorPreviewImage.color = color;
			foreach (IThemeComponent themedMapButtonComponent in _themedMapButtonComponents)
			{
				themedMapButtonComponent.ApplyTheme(_mapDefinition.themes[(int)_themeDatabase.ThemePreference]);
			}
			_mainCard.PreviewImage.sprite = _mapDefinition.themePreviewSprites[(int)_themeDatabase.ThemePreference];
			SetupNavigationToThemeButtons(_themeDatabase.ThemePreference);
			_previousTheme = _mapDefinition.themes[(int)_themeDatabase.ThemePreference];
		}

		public void ApplyBlendedTheme(float progress)
		{
			Color color = _mapDefinition.themes[_themeDatabase.IsInColorblindMode ? 3 : 0].GetColor(ThemedMaterialType.PrimaryMenu);
			ColorfulSelect.themeColorPreviewImage.color = color;
			_mainCard.PreviewImage.sprite = _mapDefinition.themePreviewSprites[(int)_themeDatabase.ThemePreference];
			ITheme theme = _mapDefinition.themes[(int)_themeDatabase.ThemePreference];
			if (_lastThemeBlendedFrom != _previousTheme || _lastThemeBlendedTo != theme)
			{
				_lastThemeBlendedFrom = _previousTheme;
				_lastThemeBlendedTo = theme;
				_dynamicMapButtonComponents.Clear();
				foreach (IThemeComponent themedMapButtonComponent in _themedMapButtonComponents)
				{
					if (themedMapButtonComponent.ApplyBlendedTheme(_previousTheme, theme, progress) == ThemeBlendingResult.ContinueBlending)
					{
						_dynamicMapButtonComponents.Add(themedMapButtonComponent);
					}
				}
			}
			else
			{
				foreach (IThemeComponent dynamicMapButtonComponent in _dynamicMapButtonComponents)
				{
					dynamicMapButtonComponent.ApplyBlendedTheme(_previousTheme, theme, progress);
				}
			}
			if (progress >= 1f)
			{
				_previousTheme = theme;
			}
			SetupNavigationToThemeButtons(_themeDatabase.ThemePreference);
		}

		public void SetLocked(StringId headerId, StringId descriptionId)
		{
			_currentCard = Card.Locked;
			SetNextCard();
			if (headerId == StringId.None)
			{
				LockedCard.DescriptionHeader.gameObject.SetActive(value: false);
			}
			else
			{
				LockedCard.DescriptionHeader.gameObject.SetActive(value: true);
				LockedCard.DescriptionHeader.SetStringId(_scope, headerId);
			}
			LockedCard.Description.SetStringId(_scope, descriptionId);
		}

		public void HackSetUnlocked()
		{
			_currentCard = Card.Main;
			SetNextCard();
		}

		public void SetUnlocked()
		{
			_currentCard = Card.Main;
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.UnlockMap));
			LockedCard.PlayUnlockAnimation(null);
		}

		public void FlipCard()
		{
			base.onAnimationMidFlip += OnTabSelectMidFlip;
			TweenToNextCard();
		}

		public bool IsSelected()
		{
			if (_screen.ButtonCount != 0)
			{
				return _screen.CurrentlySelectedMapButton == this;
			}
			return false;
		}

		private LeaderboardId GetLeaderboardIdForMapButton()
		{
			int selectedOptionIndex = LeaderboardCard.RecurringLeaderboardSelector.SelectedOptionIndex;
			if (MapChallenge != null)
			{
				switch (MapChallenge.type)
				{
				case MapChallenge.ChallengeType.Daily:
				{
					GameObject gameObject = LeaderboardCard.RecurringLeaderboardSelector.options[selectedOptionIndex];
					if (Enum.TryParse<DayOfWeek>(gameObject.name, out var result))
					{
						return new DailyLeaderboardId(ChallengeSystem.ToTimestamp(ChallengeSystem.GetStartOfLastOccurence(result)));
					}
					Diagnostics.FailAssert("Invalid daily challenge leaderboard option: {0}", gameObject.name);
					return null;
				}
				case MapChallenge.ChallengeType.Weekly:
				{
					ChallengeSystem.LeaderboardWeek leaderboardWeek = ChallengeSystem.GetLeaderboardWeek(MapChallenge.TimeStart);
					if (selectedOptionIndex == 0 || selectedOptionIndex == 1)
					{
						return new WeeklyLeaderboardId(ChallengeSystem.ToTimestamp(ChallengeSystem.GetStartOfLastOccurence((selectedOptionIndex == 1) ? leaderboardWeek : leaderboardWeek.Other())));
					}
					Diagnostics.FailAssert("Invalid weekly challenge leaderboard option index: {0}", selectedOptionIndex);
					return null;
				}
				case MapChallenge.ChallengeType.City:
					return new CityLeaderboardId(MapDefinition.CityNameEnum, CityGameMode.CityChallenge, SelectedChallengeIndex);
				default:
					Diagnostics.FailAssert("Invalid challenge type for leaderboard: {0}", MapChallenge.type);
					return null;
				}
			}
			if (selectedOptionIndex >= 0 && selectedOptionIndex < LeaderboardCard.RecurringLeaderboardSelector.options.Length)
			{
				return new CityLeaderboardId(_mapDefinition.CityNameEnum, LeaderboardSelectorInfo.GetGameModeForIndex(selectedOptionIndex), (selectedOptionIndex >= 2) ? (selectedOptionIndex - 2) : (-1));
			}
			return null;
		}

		private void OnModeSelected()
		{
			_mainCard.UpdateModeStrings(GetCurrentSelectedGameMode());
			if (GetCurrentSelectedGameMode() != GameMode.Normal)
			{
				DeselectCityChallenge();
			}
			GameMode currentSelectedGameMode = GetCurrentSelectedGameMode();
			int bestScoreForCityLeaderboard = MapSelectScreen.GetBestScoreForCityLeaderboard(_mapDefinition.cityName, currentSelectedGameMode);
			SetBestScoreText(_scope, bestScoreForCityLeaderboard, MainCard.BestScoreText);
			SetBestScoreTextOnModeCard(_scope, bestScoreForCityLeaderboard);
			if (GetCurrentSelectedGameMode() == GameMode.Normal)
			{
				AnimatedCard.SetNavigationOnUp(ModeSelectCard.NormalButton, MapSelectScreen.backButton);
			}
			else
			{
				AnimatedCard.SetNavigationOnUp(ModeSelectCard.NormalButton, ModeSelectCard.InfoButton);
			}
		}

		private void ResetModeSelection()
		{
			if (ModeSelectCard != null)
			{
				ModeSelectCard.ResetToNormal();
				_mainCard.UpdateModeStrings(GetCurrentSelectedGameMode());
			}
			else
			{
				_mainCard.UpdateModeStrings(GameMode.Normal);
				_player.SetSelectedGameMode(_mapDefinition.mapName, GameMode.Normal);
			}
			int bestScoreForCityLeaderboard = MapSelectScreen.GetBestScoreForCityLeaderboard(_mapDefinition.cityName, GameMode.Normal);
			SetBestScoreText(_scope, bestScoreForCityLeaderboard, MainCard.BestScoreText);
			SetBestScoreTextOnModeCard(_scope, bestScoreForCityLeaderboard);
		}

		public void LockUnlockPressed()
		{
			if (FeatureToggle.IsFeatureDisabled(Feature.DebugMapUnlockButton))
			{
				return;
			}
			if (_currentCard == Card.Locked)
			{
				ToggleLockInAchievements(isNowLocked: true);
				SetUnlocked();
				StorableUtilities.StoreJsonStorable(_player.ExtendedUserProfile);
				return;
			}
			ToggleLockInAchievements(isNowLocked: false);
			if (MapDefinition.HowToUnlockDescription == StringId.None)
			{
				SetLocked(StringId.MapUnlock_ToUnlock, StringId.MapUnlock_ToUnlock);
				_leaderboardTabButton.Hide();
				_challengeTabButton.Hide();
				_modeSelectTabButton.Hide();
				_mainTabButton.Hide();
			}
			else
			{
				SetLocked(StringId.MapUnlock_ToUnlock, MapDefinition.HowToUnlockDescription);
				_leaderboardTabButton.Hide();
				_challengeTabButton.Hide();
				_modeSelectTabButton.Hide();
				_mainTabButton.Hide();
			}
			StorableUtilities.StoreJsonStorable(_player.ExtendedUserProfile);
		}

		private void ToggleLockInAchievements(bool isNowLocked)
		{
			if (FeatureToggle.IsFeatureDisabled(Feature.DebugMapUnlockButton))
			{
				return;
			}
			AchievementDatabase achievementDatabase = _scope.Get<AchievementDatabase>();
			if (!isNowLocked)
			{
				MotorwaysCityStatistics cityStatisticsForCity = _player.MotorwaysUserProfile.GetCityStatisticsForCity(MapDefinition.cityName, GameMode.Normal);
				if (cityStatisticsForCity != null)
				{
					cityStatisticsForCity.MaxTrips = 0;
				}
			}
			foreach (AchievementData allAchievementDatum in achievementDatabase.allAchievementData)
			{
				if (allAchievementDatum is MotorwaysAchievementData motorwaysAchievementData)
				{
					bool flag = false;
					foreach (AchievementData item in MapDefinition._achievementsThatUnlockMap)
					{
						if (item == motorwaysAchievementData)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
				}
				AchievementDefinition achievementDefinition = achievementDatabase[allAchievementDatum.GetId()];
				bool flag2 = _player.IsAchievementCompleted(achievementDefinition);
				if (isNowLocked == flag2)
				{
					continue;
				}
				if (isNowLocked)
				{
					_player.CompleteAchievement(achievementDefinition, showNotification: true);
					continue;
				}
				foreach (Achievement item2 in (List<Achievement>)GetInstanceField(typeof(LegacyBaseUserProfile), _player.UserProfile, "_achievements"))
				{
					if (!(item2.Id == achievementDefinition.Id))
					{
						continue;
					}
					_player.MotorwaysUserProfile.RemoveAchievement(item2.Definition);
					if (item2.Definition is MotorwaysAchievementDefinition motorwaysAchievementDefinition)
					{
						MotorwaysCityStatistics cityStatisticsForCity2 = _player.MotorwaysUserProfile.GetCityStatisticsForCity(motorwaysAchievementDefinition.CityName, GameMode.Normal);
						if (cityStatisticsForCity2 != null)
						{
							cityStatisticsForCity2.MaxTrips = 0;
						}
					}
				}
			}
		}

		public static object GetInstanceField(Type type, object instance, string fieldName)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
			return type.GetField(fieldName, bindingAttr).GetValue(instance);
		}
	}
}
