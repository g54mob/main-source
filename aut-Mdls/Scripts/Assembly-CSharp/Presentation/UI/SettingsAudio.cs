using Data.Variables;
using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using UnityEngine.UI;
using Utils.Enums;

namespace Presentation.UI
{
	public class SettingsAudio : MonoBehaviour
	{
		[SerializeField]
		private Button _resetAllButton;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private Slider _masterVolumeSlider;

		[SerializeField]
		private Slider _musicVolumeSlider;

		[SerializeField]
		private Slider _SFXVolumeSlider;

		[SerializeField]
		private FloatVariableSO _musicVolume;

		[SerializeField]
		private FloatVariableSO _sfxVolume;

		[SerializeField]
		private FloatVariableSO _masterVolume;

		private void Start()
		{
			_resetAllButton.onClick.AddListener(HandleReset);
			SetInitialVolumeValues();
			_masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
			_musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
			_SFXVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
		}

		private void OnDestroy()
		{
			_resetAllButton.onClick.RemoveListener(HandleReset);
			_masterVolumeSlider.onValueChanged.RemoveListener(OnMasterVolumeChanged);
			_musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
			_SFXVolumeSlider.onValueChanged.RemoveListener(OnSFXVolumeChanged);
		}

		private void HandleReset()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("ModalWarning.Title", "ModalWarning.ResetSettingsGeneric", Sizes.S, ResetAudio, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalWarning.ResetBindingsConfirmButton"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		private void ResetAudio()
		{
			_musicVolume.ResetToDefault();
			_sfxVolume.ResetToDefault();
			_masterVolume.ResetToDefault();
			SetInitialVolumeValues();
		}

		private void SetInitialVolumeValues()
		{
			_masterVolumeSlider.value = _masterVolume.Value;
			_musicVolumeSlider.value = _musicVolume.Value;
			_SFXVolumeSlider.value = _sfxVolume.Value;
		}

		private void OnMasterVolumeChanged(float value)
		{
			_masterVolume.SetValue(Mathf.Clamp01(value));
		}

		private void OnMusicVolumeChanged(float value)
		{
			_musicVolume.SetValue(Mathf.Clamp01(value));
		}

		private void OnSFXVolumeChanged(float value)
		{
			_sfxVolume.SetValue(Mathf.Clamp01(value));
		}
	}
}
