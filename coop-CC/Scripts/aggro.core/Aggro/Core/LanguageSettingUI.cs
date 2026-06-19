using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Aggro.Core
{
	public class LanguageSettingUI : AggroSettingUI
	{
		public TMP_Dropdown dropdown;

		public string[] languages;

		private LanguageSetting _setting;

		private List<string> _options = new List<string>();

		public override void Set(AggroSettingBase setting)
		{
			if (setting is LanguageSetting setting2)
			{
				_setting = setting2;
				for (int i = 0; i < languages.Length; i++)
				{
					_options.Add(languages[i]);
				}
				dropdown.ClearOptions();
				dropdown.AddOptions(_options);
				dropdown.SetValueWithoutNotify((int)_setting.currentLanguage);
			}
			else
			{
				Debug.LogWarning("[SETTINGS] Invalid setting type for LanguageSettingUI!");
			}
		}

		public override void Refresh()
		{
		}

		public void OnDropDownValueChanged(int index)
		{
			_setting.SetLanguage((LocalizedText.Language)index);
			_setting.Save();
		}
	}
}
