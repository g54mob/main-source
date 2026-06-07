using UnityEngine;

namespace UIScripts.SettingHandles.References
{
	public class SettingToggleTwoIconsReference : SettingToggleReference
	{
		public GameObject offIcon;

		private void Awake()
		{
			if (offIcon != null)
			{
				toggle.onValueChanged.AddListener(OnToggled);
				OnToggled(toggle.isOn);
			}
		}

		private void OnToggled(bool val)
		{
			offIcon.SetActive(!val);
		}
	}
}
