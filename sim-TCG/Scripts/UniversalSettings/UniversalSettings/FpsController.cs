using UnityEngine;

namespace UniversalSettings
{
	[AddComponentMenu("Universal Settings/Display/Fps Dropdown")]
	public class FpsController : SettingsComponentDropdown
	{
		[SerializeField]
		private bool autoApply;

		protected override void Setup()
		{
			CreateOptions(universalSettings.GetDropdownFpsOptions());
		}

		protected override ref int SettingsValue()
		{
			return ref universalSettings.viewSettings.fpsIndex;
		}

		protected override bool AutoApplyValue()
		{
			return autoApply;
		}

		protected override void AutoApply()
		{
			universalSettings.SetFps(SettingsValue());
		}

		internal override void UpdateComponent(SettingsProfile settings)
		{
			SetDropdownActive(!settings.vsync);
			base.UpdateComponent(settings);
		}
	}
}
