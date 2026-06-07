using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using Jundroo.Common.Utils;
using Jundroo.Juicy;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class AudioSettings : SettingsCategory<AudioSettings>
	{
		public NumericSetting<float> MasterVolume { get; private set; }

		public NumericSetting<float> MusicVolume { get; private set; }

		public NumericSetting<float> UIVolume { get; private set; }

		public AudioSettings()
			: base("Audio")
		{
		}

		protected override void InitializeSettings()
		{
			MasterVolume = CreateNumeric("Master Volume", 0f, 1f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the volume of both sound and music.").SetDefault(1f);
			MasterVolume.RaiseChangedEventOnlyWhenCommitted = false;
			MusicVolume = CreateNumeric("Music Volume", 0f, 1f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the volume of the music.").SetDefault(0.5f);
			MusicVolume.RaiseChangedEventOnlyWhenCommitted = false;
			UIVolume = CreateNumeric("User Interface Volume", 0f, 1f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the volume of the user interface.").SetDefault(1f);
			UIVolume.RaiseChangedEventOnlyWhenCommitted = false;
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			MasterVolume.Changed += OnMasterVolumeChanged;
			UIVolume.Changed += OnUIVolumeChanged;
			SetGameVolume(MasterVolume);
			SetUIVolume(UIVolume);
		}

		private static float ExpoVolume(float volume)
		{
			if (volume < 0.02f)
			{
				volume = 0f;
			}
			else if (volume > 0.99f)
			{
				volume = 1f;
			}
			volume = Mathf.Pow(volume, 2f);
			return Mathf.Clamp01(volume);
		}

		private void OnMasterVolumeChanged(object sender, SettingChangedEventArgs<float> e)
		{
			SetGameVolume(e.Setting.Value);
		}

		private void OnUIVolumeChanged(object sender, SettingChangedEventArgs<float> e)
		{
			SetUIVolume(e.Setting.Value);
		}

		private void SetGameVolume(float volume)
		{
			AudioListener.volume = ExpoVolume(volume);
		}

		private void SetUIVolume(float volume)
		{
			WidgetContext.GlobalSoundVolume = ExpoVolume(volume);
		}
	}
}
