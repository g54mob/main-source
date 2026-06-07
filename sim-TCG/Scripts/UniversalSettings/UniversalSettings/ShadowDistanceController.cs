using UnityEngine;

namespace UniversalSettings
{
	[AddComponentMenu("Universal Settings/Graphic/Shadow Distance Dropdown")]
	public class ShadowDistanceController : SettingsComponentDropdown
	{
		[SerializeField]
		private bool autoApply;

		protected override void Setup()
		{
			CreateOptions(universalSettings.GetDropdownShadowDistanceOptions());
		}

		protected override ref int SettingsValue()
		{
			return ref universalSettings.viewSettings.shadowDistanceIndex;
		}

		protected override bool AutoApplyValue()
		{
			return autoApply;
		}

		protected override void AutoApply()
		{
			universalSettings.SetShadowDistance((ShadowDistance)SettingsValue());
		}

		internal override void UpdateComponent(SettingsProfile settings)
		{
			SetDropdownActive(settings.shadowModeIndex > 0);
			base.UpdateComponent(settings);
		}
	}
}
