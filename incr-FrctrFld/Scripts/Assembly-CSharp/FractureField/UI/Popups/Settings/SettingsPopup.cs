using FractureField.UI.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.Popups.Settings
{
	public class SettingsPopup : Popup
	{
		[SerializeField]
		private Slider _masterVolumeSlider;

		[SerializeField]
		private Slider _musicVolumeSlider;

		[SerializeField]
		private Slider _sfxVolumeSlider;

		[SerializeField]
		private ToggleWithLabel _disableFloatingDamageTextToggle;

		[SerializeField]
		private ToggleWithLabel _disableCurrencyTextToggle;

		[SerializeField]
		private TMP_Dropdown _screenModeDropdown;

		protected override void Awake()
		{
		}

		private void SetupScreenModeDropdown()
		{
		}

		private int ScreenModeToDropdownIndex(FullScreenMode mode)
		{
			return 0;
		}

		private FullScreenMode DropdownIndexToScreenMode(int index)
		{
			return default(FullScreenMode);
		}

		public override void Open()
		{
		}

		public void OnMasterVolumeChanged()
		{
		}

		public void OnMusicVolumeChanged()
		{
		}

		public void OnSFXVolumeChanged()
		{
		}

		public void OnScreenModeChanged()
		{
		}

		public void ClickedHardReset()
		{
		}

		public void ClickedViewChangelog()
		{
		}

		public void ClickedImport()
		{
		}

		public void ClickedExport()
		{
		}

		public void ClickedLanguage()
		{
		}

		public void ClickedSaveAndQuit()
		{
		}
	}
}
