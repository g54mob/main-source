using System;
using System.Collections.Generic;
using Factory;
using Motorways.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class ProfileSelectButton : AnimatedCard
	{
		[SerializeField]
		private Image _backgroundColor;

		[SerializeField]
		private Image _profileIcon;

		[SerializeField]
		private GameObject _currentlySelectedProfileTick;

		[SerializeField]
		private LocalizedTextUI _totalTripsText;

		[SerializeField]
		private LocalizedTextUI _lastDatePlayedText;

		public TouchButton editButton;

		[SerializeField]
		private DelegateCanvasGroup _createPanel;

		private Player _player;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private ProfileSelectScreen _screen;

		[Dependency]
		private LocaleDatabase _localeDatabase;

		[Dependency]
		private MotorwaysThemeDatabase _themeDatabase;

		[Dependency]
		private VisualConstantsData _visualConstants;

		private bool _isCreateButton;

		private bool _isSelectedProfile;

		public bool IsCreateButton
		{
			get
			{
				return _isCreateButton;
			}
			set
			{
				_isCreateButton = value;
				_createPanel.Alpha = (_isCreateButton ? 1 : 0);
				_createPanel.SetBlocksRaycasts(_isCreateButton);
			}
		}

		public Player Player => _player;

		public bool IsSelectedProfile
		{
			get
			{
				return _isSelectedProfile;
			}
			set
			{
				_isSelectedProfile = value;
				_currentlySelectedProfileTick.SetActive(_isSelectedProfile);
			}
		}

		public int ProfileBackgroundIndex { get; private set; }

		public int ProfileIconIndex { get; private set; }

		public void Initialize(Player player)
		{
			IsCreateButton = false;
			Initialize(_scope);
			if (player != null)
			{
				SetPlayer(player);
			}
		}

		public void OnEditButtonPressed()
		{
			if (!IsCreateButton)
			{
				_screen.OnEditProfile(this);
			}
			else
			{
				OnCreateButtonPressed();
			}
		}

		public void OnCreateButtonPressed()
		{
			_screen.OnProfileCreateButtonPressed(this);
		}

		public override void OnTabSelectMidFlip()
		{
			base.OnTabSelectMidFlip();
			if (IsCreateButton)
			{
				IsCreateButton = false;
				_screen.TransitionInNewCreateButton();
			}
		}

		public void TurnIntoNewProfile(Player newPlayer)
		{
			if (Diagnostics.Verify(IsCreateButton, "We can't turn an existing profile button into a new button!"))
			{
				SetPlayer(newPlayer);
				base.onAnimationMidFlip += OnTabSelectMidFlip;
				TweenToNextCard();
			}
		}

		public void ScrollToMe()
		{
			_screen.ScrollToButton(this);
		}

		public void SetupButtonNavigation(ProfileSelectButton previousButton, Selectable selectButton, Selectable backButton)
		{
			AnimatedCard.SetNavigationOnUp(editButton, backButton);
			AnimatedCard.SetNavigationOnDown(editButton, selectButton);
			if (previousButton != null)
			{
				AnimatedCard.SetNavigationOnLeft(editButton, previousButton.editButton);
				AnimatedCard.SetNavigationOnRight(previousButton.editButton, editButton);
			}
		}

		public override void OnCardConfirmed()
		{
			base.OnCardConfirmed();
			_currentlySelectedProfileTick.SetActive(value: true);
		}

		public override void OnOtherCardConfirmed(bool pushLeft, float delay)
		{
			_currentlySelectedProfileTick.SetActive(value: false);
		}

		public void SetPlayer(Player player)
		{
			_player = player;
			ProfileBackgroundIndex = player.AvatarColorIndex;
			ProfileIconIndex = player.AvatarIconIndex;
			_backgroundColor.color = _themeDatabase.GetGlobalColor(ProfileCreationScreen.GetProfileColorEnumForIndex(ProfileBackgroundIndex));
			_profileIcon.sprite = _visualConstants.GetProfileIcon(ProfileIconIndex);
			Locale currentLocale = _localeDatabase.CurrentLocale;
			int num = 0;
			if (_player.UserProfile is LegacyMotorwaysUserProfile legacyMotorwaysUserProfile)
			{
				foreach (MapDefinition.CityNames value2 in Enum.GetValues(typeof(MapDefinition.CityNames)))
				{
					MotorwaysCityStatistics cityStatisticsForCity = legacyMotorwaysUserProfile.GetCityStatisticsForCity(value2.ToString(), GameMode.Normal);
					if (cityStatisticsForCity != null)
					{
						num += cityStatisticsForCity.TotalTrips;
					}
				}
			}
			_totalTripsText.LocString = StandaloneLocString.CreateString(_scope, new MotorwaysStringKey(StringId.TotalTrips, new Dictionary<StringParameterId, string> { 
			{
				StringParameterId.Num,
				_localeDatabase.CurrentLocale.FormatNumber(num)
			} }));
			string value = currentLocale.FormatDateTime(player.LastPlayedUtcTimeOnLocalDevice.ToLocalTime());
			_lastDatePlayedText.LocString = StandaloneLocString.CreateString(_scope, new MotorwaysStringKey(StringId.LastDatePlayed, new Dictionary<StringParameterId, string> { 
			{
				StringParameterId.Date,
				value
			} }));
		}
	}
}
