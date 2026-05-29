using UnityEngine;

namespace UniversalSettings
{
	[AddComponentMenu("Universal Settings/Effect/Post Processing Toggle")]
	public class PostProcessingController : SettingsComponentToggle
	{
		[SerializeField]
		private bool autoApply;

		protected override ref bool SettingsValue()
		{
			return ref universalSettings.viewSettings.postProcessing;
		}

		protected override bool AutoApplyValue()
		{
			return autoApply;
		}

		protected override void AutoApply()
		{
			universalSettings.SetPostProcessing(SettingsValue());
		}
	}
}
