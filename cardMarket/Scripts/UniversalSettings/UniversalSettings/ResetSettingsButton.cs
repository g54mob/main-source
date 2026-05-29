using UnityEngine;

namespace UniversalSettings
{
	[AddComponentMenu("Universal Settings/Button/Reset Settings")]
	public class ResetSettingsButton : SettingsButton
	{
		protected override void OnClick()
		{
			universalSettings.ResetSettings();
		}

		internal override void UpdateButton(SettingsProfile settings)
		{
		}
	}
}
