using ModApi.Settings.Core;

namespace ModApi.Settings
{
	public class AudioSettings : SettingsCategory<AudioSettings>
	{
		public enum MusicLevel
		{
			Low = 0,
			High = 1
		}

		public NumericSetting<float> MasterVolume { get; private set; }

		public EnumSetting<MusicLevel> MusicQuality { get; private set; }

		public NumericSetting<float> MusicVolume { get; private set; }

		public NumericSetting<float> SoundVolume { get; private set; }

		public BoolSetting SpaceMuffle { get; private set; }

		public AudioSettings()
			: base("Audio")
		{
		}

		protected override void InitializeSettings()
		{
			MasterVolume = CreateNumeric("Master Volume", 0f, 1f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the volume of both sound and music.").SetDefault(1f);
			DeviceFlags flags = CurrentDevice.Flags;
			MusicVolume = CreateNumeric("Music Volume", 0f, 1f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the volume of the music.").SetDefault((flags.HasFlag(DeviceFlags.LowRam) && flags.HasFlag(DeviceFlags.Mobile)) ? 0f : 0.8f);
			SoundVolume = CreateNumeric("Sound Volume", 0f, 1f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the volume of the sound.").SetDefault(1f);
			SpaceMuffle = CreateBool("Space Sound Attenuation").SetDescription("Enables or disables space sound attenuation. When enabled, the sound will be muffled when in space.").SetDefault(value: true);
			MusicQuality = CreateEnum<MusicLevel>("MusicQuality").SetDefault((!flags.HasFlag(DeviceFlags.LowRam) || !flags.HasFlag(DeviceFlags.Mobile)) ? MusicLevel.High : MusicLevel.Low).SetState(SettingState.Disabled);
		}
	}
}
