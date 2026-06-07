using System;
using Factory;
using Motorways.Themes;
using Popups;
using Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class ProfileCreationScreen : BaseScalingScreen
	{
		[Dependency]
		private VisualConstantsData _visualConstants;

		[Dependency]
		private ProfileSelectScreen _profileSelectScreen;

		[SerializeField]
		private Image _backgroundColor;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TouchOptionButton _backgroundSelector;

		[SerializeField]
		private TouchOptionButton _iconSelector;

		private Player _playerToEdit;

		private int _currentBackgroundIndex;

		private int _currentIconIndex;

		[Dependency]
		private PlayerDatabase _playerDatabase;

		private const string ProfileColorEnumId = "ProfileColor";

		public ThemedMaterialType CurrentColorType => GetProfileColorEnumForIndex(_currentBackgroundIndex);

		public void OnNextIcon()
		{
			_currentIconIndex = (_currentIconIndex + 1) % _visualConstants.ProfileIconCount;
			_icon.sprite = _visualConstants.GetProfileIcon(_currentIconIndex);
		}

		public void OnSetIconIndex(int index)
		{
			_currentIconIndex = index;
			_icon.sprite = _visualConstants.GetProfileIcon(_currentIconIndex);
		}

		public void OnNextColor()
		{
			_currentBackgroundIndex = (_currentBackgroundIndex + 1) % 6;
			Color globalColor = _themeDatabase.GetGlobalColor(CurrentColorType);
			_backgroundColor.color = globalColor;
		}

		public void OnSetColorIndex(int index)
		{
			_currentBackgroundIndex = index;
			Color globalColor = _themeDatabase.GetGlobalColor(CurrentColorType);
			_backgroundColor.color = globalColor;
		}

		public void OnDeleteProfileButton()
		{
			popupStack.PushConfirmationPopup<ConfirmationPopup>(StringId.DeleteProfile, OnDeleteProfileCancel, OnDeleteProfileFirstPromptConfirmed, StringId.DeleteProfileDescription);
		}

		private void OnDeleteProfileFirstPromptConfirmed()
		{
			popupStack.PushConfirmationPopup<ConfirmationPopup>(StringId.DeleteProfile, OnDeleteProfileReconsiderWaived, OnDeleteProfileCancel, StringId.DeleteProfileDescription2);
		}

		private void OnDeleteProfileReconsiderWaived()
		{
			popupStack.PushConfirmationPopup<ConfirmationPopup>(StringId.DeleteProfile, OnDeleteProfileCancel, OnDeleteProfileFinalConfirmation, StringId.DeleteProfileDescription3);
		}

		private void OnDeleteProfileFinalConfirmation()
		{
			_playerDatabase.DeletePlayer(_playerToEdit);
			_profileSelectScreen.Enable(shouldBeVisible: true);
			_profileSelectScreen.PrepareScreen();
			_screenStack.PopOneScreen();
		}

		private void OnDeleteProfileCancel()
		{
		}

		public void PrepareScreen(Player player)
		{
			_playerToEdit = player;
			_backgroundSelector.SetOption(_playerToEdit.AvatarColorIndex, invokeMethod: true);
			_iconSelector.SetOption(_playerToEdit.AvatarIconIndex, invokeMethod: true);
		}

		public static ThemedMaterialType GetProfileColorEnumForIndex(int index)
		{
			if (Diagnostics.Verify(Enum.TryParse<ThemedMaterialType>(string.Format("{0}{1}", "ProfileColor", index + 1), out var result), "No profile color for index {0}", index))
			{
				return result;
			}
			return ThemedMaterialType.ProfileColor1;
		}

		public void OnBack()
		{
			_playerToEdit.AvatarColorIndex = _currentBackgroundIndex;
			_playerToEdit.AvatarIconIndex = _currentIconIndex;
			_screenStack.PopOneScreen();
		}

		public override void Reset()
		{
			base.Reset();
			_currentIconIndex = 0;
			_currentBackgroundIndex = 0;
		}
	}
}
