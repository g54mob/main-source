using System;
using System.Collections.Generic;
using Factory;
using JetBrains.Annotations;
using Motorways.Audio;
using Motorways.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class MapButtonChallengeCard : MapButtonCard
	{
		[SerializeField]
		private TouchToggle[] _challengeButtons;

		[SerializeField]
		private LocalizedTextUI[] _challengeButtonTitles;

		[SerializeField]
		private LocalizedTextUI[] _challengeButtonScores;

		[SerializeField]
		private LocalizedTextUI _scoreText;

		[SerializeField]
		private LocalizedTextUI _selectChallengeText;

		[SerializeField]
		private ChallengeIcon[] _challengeIcons;

		[SerializeField]
		private DelegateCanvasGroup _lockedCanvasGroup;

		[SerializeField]
		private LocalizedTextUI _unlockText;

		[SerializeField]
		private TouchButton _challengeModifiersButton;

		[SerializeField]
		private TouchButton _moreInfoButton;

		[SerializeField]
		private Animator _unlockEffectAnimator;

		private IScope _scope;

		private MapButton _owningMapButton;

		private readonly int ChallengeSelected = Animator.StringToHash("ChallengeSelected");

		private readonly int ChallengesUnlocked = Animator.StringToHash("Unlock");

		private bool _showingCardAsLocked;

		public TouchButton MoreInfoButton => _moreInfoButton;

		private CityChallengeData[] Challenges => _owningMapButton.MapDefinition.cityChallenges;

		public bool LeaderboardShowsSelectedChallenge
		{
			get
			{
				return _owningMapButton._leaderboardShowsSelectedChallenge;
			}
			set
			{
				_owningMapButton._leaderboardShowsSelectedChallenge = value;
			}
		}

		private CityChallengeData SelectedChallenge => _owningMapButton.SelectedChallenge;

		public int SelectedCityChallengeIndex
		{
			get
			{
				return _owningMapButton.SelectedChallengeIndex;
			}
			private set
			{
				_owningMapButton.SelectedChallengeIndex = value;
			}
		}

		public bool ShowingCardAsLocked
		{
			get
			{
				return _showingCardAsLocked;
			}
			private set
			{
				_showingCardAsLocked = value;
				_lockedCanvasGroup.SetBlocksRaycasts(_showingCardAsLocked);
				_lockedCanvasGroup.gameObject.SetActive(_showingCardAsLocked);
				SetChallengeButtonsActive(!_showingCardAsLocked);
				InitializeFooter(_showingCardAsLocked);
			}
		}

		public TouchToggle[] ChallengeButtons => _challengeButtons;

		public TouchButton ChallengeModifiersButton => _challengeModifiersButton;

		private event Action _onUnlockAnimationComplete;

		public event Action OnChallengeSelected;

		private void ResetCard()
		{
			ChallengeIcon[] challengeIcons = _challengeIcons;
			for (int i = 0; i < challengeIcons.Length; i++)
			{
				challengeIcons[i].gameObject.SetActive(value: false);
			}
			_unlockText.gameObject.SetActive(value: false);
			_selectChallengeText.gameObject.SetActive(value: false);
			_scoreText.gameObject.SetActive(value: false);
			_challengeModifiersButton.gameObject.SetActive(value: false);
		}

		public void Initialize(IScope scope, MapButton owningMapButton)
		{
			ResetCard();
			_scope = scope;
			_owningMapButton = owningMapButton;
			InitializeFormattedLocalizedStrings();
		}

		public static string GetNewContentIndicatorID(MapDefinition mapDefinition)
		{
			return "ChallengeTab-" + mapDefinition.cityName.ToLower();
		}

		public static string GetUnlockAnimationNciID(MapDefinition mapDefinition)
		{
			return "ChallengeUnlockAnimation-" + mapDefinition.cityName.ToLower();
		}

		private void InitializeFormattedLocalizedStrings()
		{
			MotorwaysStringKey motorwaysStringKey = _scope.Get<MotorwaysStringKey>();
			for (int i = 0; i < _challengeButtons.Length; i++)
			{
				if (Challenges != null && i < Challenges.Length)
				{
					UpdateChallengeButtonScore(i);
					motorwaysStringKey.InitWithString(Challenges[i].descriptionStringId);
					_challengeButtonTitles[i].LocString = StandaloneLocString.CreateString(_scope, motorwaysStringKey);
				}
			}
			motorwaysStringKey.InitWithStringId(StringId.CityChallenge_UnlockChallenge, _owningMapButton.MapDefinition.challengeModeTargetScore, new Dictionary<string, string> { 
			{
				"Num",
				_owningMapButton.MapDefinition.challengeModeTargetScore.ToString()
			} });
			_unlockText.LocString = StandaloneLocString.CreateString(_scope, motorwaysStringKey);
		}

		public override void SetVisible(bool isVisible)
		{
			base.SetVisible(isVisible);
			if (!isVisible)
			{
				return;
			}
			bool flag = _scope.Get<ActivePlayer>().HasSeenNewContent(GetUnlockAnimationNciID(_owningMapButton.MapDefinition));
			if (!_owningMapButton.AreChallengesLocked && !flag)
			{
				ShowingCardAsLocked = true;
				PlayUnlockAnimation(delegate
				{
					ShowingCardAsLocked = false;
				});
			}
			else
			{
				ShowingCardAsLocked = _owningMapButton.AreChallengesLocked;
			}
		}

		private void UpdateChallengeButtonScore(int buttonIndex)
		{
			ActivePlayer activePlayer = _scope.Get<ActivePlayer>();
			MotorwaysStringKey motorwaysStringKey = _scope.Get<MotorwaysStringKey>();
			CityChallengeStatistics cityChallengeScore = activePlayer.GetCityChallengeScore(_owningMapButton.MapDefinition.cityName, GameMode.Normal, buttonIndex);
			motorwaysStringKey.InitWithStringId(StringId.BestScore, cityChallengeScore.BestScore, new Dictionary<string, string> { 
			{
				"Num",
				cityChallengeScore.BestScore.ToString()
			} });
			_challengeButtonScores[buttonIndex].LocString = StandaloneLocString.CreateString(_scope, motorwaysStringKey);
		}

		public void UpdateChallengeButtonScores()
		{
			for (int i = 0; i < _challengeButtons.Length; i++)
			{
				if (Challenges != null && i < Challenges.Length)
				{
					UpdateChallengeButtonScore(i);
				}
			}
		}

		private void SetChallengeButtonsActive(bool active)
		{
			for (int i = 0; i < _challengeButtons.Length; i++)
			{
				_challengeButtons[i].gameObject.SetActive(active && i < Challenges.Length);
			}
			if (active)
			{
				RefreshSelectedButtonAnimations();
			}
		}

		private void InitializeFooter(bool isLocked)
		{
			_unlockText.gameObject.SetActive(isLocked);
			if (isLocked)
			{
				_selectChallengeText.gameObject.SetActive(value: false);
				_scoreText.gameObject.SetActive(value: false);
				_challengeModifiersButton.gameObject.SetActive(value: false);
			}
			else
			{
				bool flag = SelectedCityChallengeIndex != -1;
				_selectChallengeText.gameObject.SetActive(!flag);
				_scoreText.gameObject.SetActive(flag);
				_challengeModifiersButton.gameObject.SetActive(flag);
			}
		}

		public void OnChallengeIconPressed()
		{
			_scope.Get<ScreenStack>().PushScreen(ScreenStack.MotorwaysScreen.ChallengeInfo, delegate(ChallengeInfoScreen screen)
			{
				screen.PrepareScreenForCityChallenge(_owningMapButton.MapDefinition, SelectedCityChallengeIndex, StringId.Back, changeBlurWhenTransitioning: true, showBackButton: false);
			}, additive: true);
		}

		private void RefreshSelectedButtonAnimations()
		{
			for (int i = 0; i < _challengeButtons.Length; i++)
			{
				_challengeButtons[i].GetComponent<Animator>().SetBool(ChallengeSelected, i == SelectedCityChallengeIndex);
			}
		}

		[UsedImplicitly]
		private void OnButtonSelected(int selectedButtonIndex)
		{
			if (SelectedCityChallengeIndex != selectedButtonIndex)
			{
				SelectChallengeIndex(selectedButtonIndex);
			}
		}

		public void SelectChallengeIndex(int challengeIndex)
		{
			SelectedCityChallengeIndex = challengeIndex;
			LeaderboardShowsSelectedChallenge = false;
			RefreshSelectedButtonAnimations();
			for (int i = 0; i < _challengeIcons.Length; i++)
			{
				if (i < SelectedChallenge.challenges.Length)
				{
					ChallengeData challengeData = SelectedChallenge.challenges[i];
					_challengeIcons[i].gameObject.SetActive(value: true);
					_challengeIcons[i].SetChallengeIcons(challengeData.icon, isWildcardChallenge: false, challengeData.subIcon, challengeData.subIconBackground);
				}
				else
				{
					_challengeIcons[i].gameObject.SetActive(value: false);
				}
			}
			CityChallengeStatistics cityChallengeScore = _scope.Get<ActivePlayer>().GetCityChallengeScore(_owningMapButton.MapDefinition.cityName, GameMode.Normal, SelectedCityChallengeIndex);
			MotorwaysStringKey motorwaysStringKey = _scope.Get<MotorwaysStringKey>();
			if (cityChallengeScore.BestScore >= SelectedChallenge.targetScore)
			{
				motorwaysStringKey.InitWithStringId(StringId.BestScore, cityChallengeScore.BestScore, new Dictionary<string, string> { 
				{
					"Num",
					cityChallengeScore.BestScore.ToString()
				} });
			}
			else
			{
				motorwaysStringKey.InitWithStringId(StringId.TargetScore, SelectedChallenge.targetScore, new Dictionary<string, string> { 
				{
					"Num",
					SelectedChallenge.targetScore.ToString()
				} });
			}
			_scoreText.LocString = StandaloneLocString.CreateString(_scope, motorwaysStringKey);
			InitializeFooter(ShowingCardAsLocked);
			this.OnChallengeSelected?.Invoke();
		}

		public void DeselectCityChallenge()
		{
			TouchToggle[] challengeButtons = _challengeButtons;
			for (int i = 0; i < challengeButtons.Length; i++)
			{
				challengeButtons[i].GetComponent<Animator>().SetBool(ChallengeSelected, value: false);
			}
			ChallengeIcon[] challengeIcons = _challengeIcons;
			for (int i = 0; i < challengeIcons.Length; i++)
			{
				challengeIcons[i].gameObject.SetActive(value: false);
			}
			_scoreText.LocString = null;
			InitializeFooter(ShowingCardAsLocked);
		}

		public void SetupChallengeModifiersButtonNavigation()
		{
			int num = _challengeButtons.Length;
			if (Diagnostics.Verify(num > 0, "No city challenge buttons"))
			{
				TouchToggle selectable = _challengeButtons[num - 1];
				Selectable firstFocus = _owningMapButton.MapSelectScreen.firstFocus;
				AnimatedCard.SetNavigationOnDown(selectable, _challengeModifiersButton);
				AnimatedCard.SetNavigationOnUp(firstFocus, _challengeModifiersButton);
			}
		}

		private void PlayUnlockAnimation(Action onComplete)
		{
			_scope.Get<AudioSystem>().ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.UnlockMap));
			_scope.Get<ActivePlayer>().SetNewContentSeen(GetNewContentIndicatorID(_owningMapButton.MapDefinition));
			_scope.Get<ActivePlayer>().SetNewContentSeen(GetUnlockAnimationNciID(_owningMapButton.MapDefinition));
			_onUnlockAnimationComplete += onComplete;
			_unlockEffectAnimator.SetTrigger(ChallengesUnlocked);
		}

		[UsedImplicitly]
		public void UnlockAnimationComplete()
		{
			this._onUnlockAnimationComplete?.Invoke();
		}

		[UsedImplicitly]
		public void OnMoreInfoButtonClicked()
		{
			_owningMapButton.OnChallengeModeMoreInfoButtonClicked();
		}

		[UsedImplicitly]
		public void OnMoreInfoButtonSelected()
		{
			if (Diagnostics.Verify(_owningMapButton != null))
			{
				_owningMapButton.ScrollToMe();
			}
		}
	}
}
