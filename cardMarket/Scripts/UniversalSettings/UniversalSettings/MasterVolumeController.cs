using UnityEngine;

namespace UniversalSettings
{
	[AddComponentMenu("Universal Settings/Sound/Master Volume Slider")]
	public class MasterVolumeController : SettingsComponentSlider
	{
		[SerializeField]
		private bool autoApply;

		protected override ref float SettingsValue()
		{
			return ref universalSettings.viewSettings.masterVolume;
		}

		protected override bool AutoApplyValue()
		{
			return autoApply;
		}

		protected override void AutoApply()
		{
			universalSettings.SetMasterVolume(SettingsValue());
		}
	}
}
