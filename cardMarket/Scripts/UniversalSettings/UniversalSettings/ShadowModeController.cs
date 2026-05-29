using UnityEngine;

namespace UniversalSettings
{
	[AddComponentMenu("Universal Settings/Graphic/Shadow Mode Dropdown")]
	public class ShadowModeController : SettingsComponentDropdown
	{
		[SerializeField]
		private bool autoApply;

		protected override void Setup()
		{
			CreateOptions(universalSettings.GetDropdownShadowModeOptions());
		}

		protected override ref int SettingsValue()
		{
			return ref universalSettings.viewSettings.shadowModeIndex;
		}

		protected override bool AutoApplyValue()
		{
			return autoApply;
		}

		protected override void AutoApply()
		{
			universalSettings.SetShadowMode((ShadowMode)SettingsValue());
		}
	}
}
