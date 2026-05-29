using UnityEngine;

namespace UniversalSettings
{
	[AddComponentMenu("Universal Settings/Sound/Audio Mixer Volume Slider")]
	public class AudioMixerVolumeController : SettingsComponentSlider
	{
		[SerializeField]
		private bool autoApply;

		[SerializeField]
		private int audioMixerConfigId;

		protected override ref float SettingsValue()
		{
			return ref universalSettings.viewSettings.audioMixerVolume[audioMixerConfigId];
		}

		protected override bool AutoApplyValue()
		{
			return autoApply;
		}

		protected override void AutoApply()
		{
			universalSettings.SetAudioMixerVolume(audioMixerConfigId, SettingsValue());
		}
	}
}
