using Restory.Gameplay.GameSettings;
using Restory.UserInterface.CommonElements;
using UnityEngine;

namespace Restory.UserInterface.SettingsMenu
{
	public sealed class GUI_SoundSettingPanel : GUI_BaseSettingPanel
	{
		[Space]
		[SerializeField]
		private GUI_SliderVariant masterVolumeSlider;

		[SerializeField]
		private GUI_SliderVariant musicVolumeSlider;

		[SerializeField]
		private GUI_SliderVariant sFXVolumeSlider;

		private AudioFMODSettings CurrentSettings => gameSettingsManager.AudioSettings;

		private AudioFMODSettings DefaultSettings => gameSettingsManager.DefaultData.AudioSettings;

		protected override void SubscribeChildren()
		{
			base.SubscribeChildren();
			masterVolumeSlider.OnValueChanged += masterVolumeSlider_onValueChanged;
			musicVolumeSlider.OnValueChanged += musicVolumeSlider_onValueChanged;
			sFXVolumeSlider.OnValueChanged += sFXVolumeSlider_onValueChanged;
		}

		protected override void UnsubscribeChildren()
		{
			base.UnsubscribeChildren();
			masterVolumeSlider.OnValueChanged -= masterVolumeSlider_onValueChanged;
			musicVolumeSlider.OnValueChanged -= musicVolumeSlider_onValueChanged;
			sFXVolumeSlider.OnValueChanged -= sFXVolumeSlider_onValueChanged;
		}

		public override void Load()
		{
			masterVolumeSlider.SetValueWithoutNotify(CurrentSettings.Master.Volume * 100f);
			sFXVolumeSlider.SetValueWithoutNotify(CurrentSettings.SFX.Volume * 100f);
			musicVolumeSlider.SetValueWithoutNotify(CurrentSettings.Music.Volume * 100f);
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void SetDefault()
		{
			masterVolumeSlider.SetValueWithoutNotify(DefaultSettings.Master.Volume * 100f);
			sFXVolumeSlider.SetValueWithoutNotify(DefaultSettings.SFX.Volume * 100f);
			musicVolumeSlider.SetValueWithoutNotify(DefaultSettings.Music.Volume * 100f);
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void Apply()
		{
			CurrentSettings.Master.Volume = masterVolumeSlider.Value / 100f;
			CurrentSettings.Music.Volume = musicVolumeSlider.Value / 100f;
			CurrentSettings.SFX.Volume = sFXVolumeSlider.Value / 100f;
			gameSettingsSaver.Save();
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		protected override void UpdateHasChanges()
		{
			if (!(gameSettingsManager == null))
			{
				SetHasChange(Mathf.RoundToInt(masterVolumeSlider.Value) != Mathf.RoundToInt(CurrentSettings.Master.Volume * 100f) || Mathf.RoundToInt(sFXVolumeSlider.Value) != Mathf.RoundToInt(CurrentSettings.SFX.Volume * 100f) || Mathf.RoundToInt(musicVolumeSlider.Value) != Mathf.RoundToInt(CurrentSettings.Music.Volume * 100f));
			}
		}

		protected override void UpdateIsDefaultValues()
		{
			if (!(gameSettingsManager == null))
			{
				SetIsDefaultValues(Mathf.RoundToInt(masterVolumeSlider.Value) == Mathf.RoundToInt(DefaultSettings.Master.Volume * 100f) && Mathf.RoundToInt(sFXVolumeSlider.Value) == Mathf.RoundToInt(DefaultSettings.SFX.Volume * 100f) && Mathf.RoundToInt(musicVolumeSlider.Value) == Mathf.RoundToInt(DefaultSettings.Music.Volume * 100f));
			}
		}

		private void masterVolumeSlider_onValueChanged(float value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}

		private void musicVolumeSlider_onValueChanged(float value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}

		private void sFXVolumeSlider_onValueChanged(float value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}
	}
}
