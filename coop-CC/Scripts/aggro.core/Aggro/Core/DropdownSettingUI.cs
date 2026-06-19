using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Aggro.Core
{
	public class DropdownSettingUI : AggroSettingUI
	{
		public TMP_Dropdown dropdown;

		private DropdownSetting _setting;

		private List<string> _options = new List<string>();

		public override void Set(AggroSettingBase setting)
		{
			if (setting is DropdownSetting setting2)
			{
				_setting = setting2;
				Refresh();
			}
			else
			{
				Debug.LogWarning("[SETTINGS] Invalid setting type for DropdownSettingUI!");
			}
		}

		public override void Refresh()
		{
			_options.Clear();
			if (AggroSettings.isLocalizing)
			{
				for (int i = 0; i < _setting.options.Length; i++)
				{
					_options.Add(LocalizedText.GetText(_setting.options[i]));
				}
			}
			else
			{
				_options.AddRangeNoGarbage(_setting.options);
			}
			dropdown.ClearOptions();
			dropdown.AddOptions(_options);
			dropdown.SetValueWithoutNotify(_setting.index);
		}

		public void OnDropDownValueChanged(int index)
		{
			_setting.SetIndex(index);
			_setting.Save();
		}
	}
}
