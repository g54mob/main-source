using System.Collections.Generic;
using System.Text;
using Factory;
using Motorways.Processes;
using Motorways.UI;
using Popups;
using UnityEngine;

namespace Motorways.Views
{
	public class ProfileSelectScreen : ScrollingButtonScreen
	{
		[SerializeField]
		private LocalizedTextUI _selectProfileButtonText;

		[SerializeField]
		private MapDefinition _tutorialDefinition;

		private AssetBundleUtility.AsyncLoadResult _tutorialCityDefinition;

		[Dependency]
		private PlayerDatabase _playerDatabase;

		[Dependency]
		private ActivePlayer _activePlayer;

		[Dependency]
		private VisualConstantsData _visualConstants;

		[Dependency]
		private Diagnostics.StorageAuditTrail _trail;

		private string _lastActivePlayerId;

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ProfileSelectScreen");

		private const int MaximumPlayers = 6;

		private IEnumerable<ProfileSelectButton> ProfileButtons
		{
			get
			{
				foreach (AnimatedCard button in buttons)
				{
					yield return button as ProfileSelectButton;
				}
			}
		}

		private ProfileSelectButton CurrentlySelectedProfileButton => base.CurrentlySelectedButton as ProfileSelectButton;

		private bool CanAddNewCreateProfileButton => _playerDatabase.PlayerCount < 6;

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			if (_tutorialCityDefinition == null)
			{
				_tutorialCityDefinition = AssetBundleUtility.LoadPrefabAsync(_tutorialDefinition.mapAssetBundle, _tutorialDefinition.mapPrefabName, this);
			}
			_lastActivePlayerId = _activePlayer.Id;
			if (!_activePlayer.HasAvatar)
			{
				ConfigureNewPlayer(_activePlayer.Player);
			}
			if (_currentlySelectedButtonIndex >= base.ButtonCount)
			{
				_currentlySelectedButtonIndex = base.ButtonCount - 1;
			}
			int num = 0;
			foreach (Player player in _playerDatabase.Players)
			{
				(buttons[num] as ProfileSelectButton)?.SetPlayer(player);
				num++;
			}
			ScrollToButton(base.CurrentlySelectedButton, instantly: true);
			SetMapButtonValues(scrollRect.normalizedPosition);
			base.TransitionIn(outScreen);
		}

		private int IndexOfCurrentPlayerCard()
		{
			int num = 0;
			foreach (Player player in _playerDatabase.Players)
			{
				if (player == _activePlayer.Player)
				{
					return num;
				}
				num++;
			}
			Diagnostics.FailAssert("We somehow have an active player that isn't in the player database!");
			return 0;
		}

		public void TransitionInNewCreateButton()
		{
			buttons[base.ButtonCount - 1].EnterFromHidden();
		}

		public void OnMainButton()
		{
			if (CurrentlySelectedProfileButton.IsSelectedProfile)
			{
				_screenStack.PopOneScreen();
			}
			else if (CurrentlySelectedProfileButton.IsCreateButton)
			{
				CreateNewProfileFromCurrentButton();
				ShowFTUXAccessibilityForTutorial();
			}
			else
			{
				_activePlayer.ActivatePlayer(CurrentlySelectedProfileButton.Player);
				SetProfileButtonSelected(CurrentlySelectedProfileButton);
				_selectProfileButtonText.SetStringId(_appScope, StringId.Play);
			}
		}

		public void OnBack()
		{
			if (_lastActivePlayerId != _activePlayer.Id)
			{
				_activePlayer.Touch();
			}
			_screenStack.PopOneScreen();
			if (FeatureToggle.IsFeatureEnabled(Feature.RecordStorageAuditTrail))
			{
				Diagnostics.Report report = new Diagnostics.Report();
				report.Motive = "storage";
				report.AttachFile("storage_audit.txt", Encoding.UTF8.GetBytes(_trail.ToJson()));
				report.Upload();
			}
		}

		public void OnEditProfile(ProfileSelectButton button)
		{
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.ProfileCreation, delegate(ProfileCreationScreen profileCreationScreen)
			{
				profileCreationScreen.PrepareScreen(button.Player);
			});
		}

		public void OnProfileCreateButtonPressed(ProfileSelectButton button)
		{
			if (Diagnostics.Verify(button.IsCreateButton))
			{
				if (CurrentlySelectedProfileButton == button)
				{
					CreateNewProfileFromCurrentButton();
					ShowFTUXAccessibilityForTutorial();
					_selectProfileButtonText.SetStringId(_appScope, StringId.Play);
				}
				else
				{
					ScrollToButton(button);
				}
			}
		}

		private void ShowFTUXAccessibilityForTutorial()
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.FTUX_Accessibility))
			{
				popupStack.PushConfirmationPopup<ConfirmationPopup>(StringId.FTUX_Accessibility_ReplayTutorialPrompt, SkipTutorial, EnterTutorial, StringId.FTUX_Accessibility_ReplayTutorialDescription);
			}
		}

		private void SkipTutorial()
		{
			_activePlayer.SetTutorialTypeComplete(TutorialProgressionProcess.TutorialTypeForInputType(_inputState.CurrentDeviceInputType));
			_activePlayer.SetNewContentSeen("NewControllerSchemePopup");
			_activePlayer.SetNewContentSeen("NewColorblindPopup");
		}

		private void EnterTutorial()
		{
			_screenStack.ReplaceScreenOnTop(ScreenStack.MotorwaysScreen.InGame, delegate(GameContainerScreen newScreen)
			{
				newScreen.PrepareForMap(Object.Instantiate(_tutorialCityDefinition.asset as GameObject).GetComponent<CityDefinition>(), _tutorialDefinition, GameMode.Tutorial);
			});
		}

		protected override void OnSelectButton()
		{
			base.OnSelectButton();
			SetupNavigationForButtons();
			if (CurrentlySelectedProfileButton.IsSelectedProfile)
			{
				_selectProfileButtonText.SetStringId(_appScope, StringId.Play);
			}
			else if (CurrentlySelectedProfileButton.IsCreateButton)
			{
				_selectProfileButtonText.SetStringId(_appScope, StringId.Create);
			}
			else
			{
				_selectProfileButtonText.SetStringId(_appScope, StringId.Select);
			}
		}

		public void PrepareScreen()
		{
			AssignOriginPosition();
			CreateProfileButtons();
			Canvas.ForceUpdateCanvases();
			ScrollToButton(base.CurrentlySelectedButton, instantly: true);
		}

		private void CreateProfileButtons()
		{
			DestroyProfileButtons();
			foreach (Player player in _playerDatabase.Players)
			{
				if (!player.HasAvatar)
				{
					player.ChooseAvatar(_visualConstants.ProfileIconCount, 6);
				}
				ProfileSelectButton profileSelectButton = _appScope.Get<ProfileSelectButton>();
				profileSelectButton.transform.SetParent(buttonParent, worldPositionStays: false);
				profileSelectButton.Initialize(player);
				buttons.Add(profileSelectButton);
				if (_activePlayer.Player == player)
				{
					profileSelectButton.IsSelectedProfile = true;
				}
			}
			if (CanAddNewCreateProfileButton)
			{
				buttons.Add(CreateNewProfileButton());
			}
			RegisterAllLocalizedTextChildren();
			RegisterButtons();
			RegisterThemeComponents(_themeDatabase.GetTheme());
			SetupNavigationForButtons();
			_currentlySelectedButtonIndex = IndexOfCurrentPlayerCard();
			ScrollToButton(base.CurrentlySelectedButton, instantly: true);
		}

		private ProfileSelectButton CreateNewProfileButton()
		{
			ProfileSelectButton profileSelectButton = _appScope.Get<ProfileSelectButton>();
			profileSelectButton.transform.SetParent(buttonParent, worldPositionStays: false);
			profileSelectButton.Initialize(null);
			profileSelectButton.IsCreateButton = true;
			return profileSelectButton;
		}

		private void AddNewCreateProfileButton()
		{
			ProfileSelectButton profileSelectButton = CreateNewProfileButton();
			profileSelectButton.SetHideRight();
			AddNewButtonToExistingSet(profileSelectButton);
			SetupNavigationForButtons();
			ScrollToButton(buttons[base.ButtonCount - 2]);
		}

		private void SetupNavigationForButtons()
		{
			for (int i = 0; i < base.ButtonCount; i++)
			{
				ProfileSelectButton previousButton = ((i > 0) ? (buttons[i - 1] as ProfileSelectButton) : null);
				(buttons[i] as ProfileSelectButton).SetupButtonNavigation(previousButton, firstFocus, backButton);
			}
			AnimatedCard.SetNavigationOnUp(firstFocus, CurrentlySelectedProfileButton.editButton);
			AnimatedCard.SetNavigationOnDown(backButton, CurrentlySelectedProfileButton.editButton);
		}

		private void DestroyProfileButtons()
		{
			if (base.ButtonCount > 0)
			{
				for (int i = 0; i < base.ButtonCount; i++)
				{
					_appScope.Release(buttons[i]);
				}
				buttons.Clear();
			}
		}

		private void SetProfileButtonSelected(ProfileSelectButton button)
		{
			foreach (ProfileSelectButton profileButton in ProfileButtons)
			{
				profileButton.IsSelectedProfile = profileButton == button;
			}
		}

		private void CreateNewProfileFromCurrentButton()
		{
			Player player = _playerDatabase.CreatePlayer();
			ConfigureNewPlayer(player);
			_activePlayer.ActivatePlayer(player);
			CurrentlySelectedProfileButton.TurnIntoNewProfile(player);
			SetProfileButtonSelected(CurrentlySelectedProfileButton);
			if (CanAddNewCreateProfileButton)
			{
				AddNewCreateProfileButton();
			}
			else
			{
				_selectProfileButtonText.SetStringId(_appScope, StringId.Play);
			}
		}

		private void ConfigureNewPlayer(Player newPlayer)
		{
			int profileIconCount = _visualConstants.ProfileIconCount;
			int iconCount = 6;
			newPlayer.ChooseAvatar(profileIconCount, iconCount);
			if (newPlayer.UserProfile is LegacyMotorwaysUserProfile legacyMotorwaysUserProfile)
			{
				Log.Info("Setting tutorial for input type {0} complete for new player {1}.", _inputState.CurrentDeviceInputType, newPlayer.Id);
				legacyMotorwaysUserProfile.SetTutorialTypeComplete(TutorialProgressionProcess.TutorialTypeForInputType(_inputState.CurrentDeviceInputType));
			}
		}
	}
}
