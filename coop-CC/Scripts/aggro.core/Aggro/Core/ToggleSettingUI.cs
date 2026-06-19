using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

namespace Aggro.Core
{
	public class ToggleSettingUI : AggroSettingUI
	{
		public Toggle toggle;

		public EventReference sfxSelected;

		private ToggleSetting _setting;

		public override void Set(AggroSettingBase setting)
		{
			if (setting is ToggleSetting toggleSetting)
			{
				_setting = toggleSetting;
				toggle.SetIsOnWithoutNotify(toggleSetting.value);
			}
			else
			{
				Debug.LogWarning("[SETTINGS] Invalid setting type for ToggleSettingUI!");
			}
		}

		public override void Refresh()
		{
			toggle.SetIsOnWithoutNotify(_setting.value);
		}

		public void OnToggleValueChanged(bool value)
		{
			AggroUtil.PlaySfxIfValid(sfxSelected);
			_setting.SetValue(value);
			_setting.Save();
		}
	}
}
