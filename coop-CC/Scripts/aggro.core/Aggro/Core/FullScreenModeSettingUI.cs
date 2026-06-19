using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Aggro.Core
{
	public class FullScreenModeSettingUI : AggroSettingUI
	{
		public TMP_Dropdown dropdown;

		private FullScreenModeSetting _setting;

		private FullScreenMode _mode;

		private List<string> _options = new List<string>();

		private const string FULLSCREEN_LOC_ID = "SETTINGFULLSCREEN";

		private const string WINDOWED_LOC_ID = "SETTINGWINDOWED";

		private const string WINDOWED_FULLSCREEN_LOC_ID = "SETTINGWINDOWEDFULLSCREEN";

		public override void Set(AggroSettingBase setting)
		{
			if (setting is FullScreenModeSetting setting2)
			{
				_setting = setting2;
				Refresh();
			}
			else
			{
				Debug.LogWarning("[SETTINGS] Invalid setting type for FullScreenModeSettingUI!");
			}
		}

		public override void Refresh()
		{
			_options.Clear();
			if (AggroSettings.isLocalizing)
			{
				_options.Add(LocalizedText.GetText("SETTINGFULLSCREEN", printDebug: false));
				_options.Add(LocalizedText.GetText("SETTINGWINDOWED", printDebug: false));
				_options.Add(LocalizedText.GetText("SETTINGWINDOWEDFULLSCREEN", printDebug: false));
			}
			else
			{
				_options.Add("FULLSCREEN");
				_options.Add("WINDOWED");
				_options.Add("WINDOWED FULLSCREEN");
			}
			dropdown.ClearOptions();
			dropdown.AddOptions(_options);
			SetDropDownWithoutNotify();
		}

		private void SetDropDownWithoutNotify()
		{
			switch (Screen.fullScreenMode)
			{
			case FullScreenMode.ExclusiveFullScreen:
				dropdown.SetValueWithoutNotify(0);
				break;
			case FullScreenMode.Windowed:
				dropdown.SetValueWithoutNotify(1);
				break;
			case FullScreenMode.FullScreenWindow:
			case FullScreenMode.MaximizedWindow:
				dropdown.SetValueWithoutNotify(2);
				break;
			default:
				throw new InvalidEnumException();
			}
			_mode = Screen.fullScreenMode;
		}

		public void OnDropDownValueChanged(int index)
		{
			switch (index)
			{
			case 0:
				_setting.SetMode(FullScreenMode.ExclusiveFullScreen);
				break;
			case 1:
				_setting.SetMode(FullScreenMode.Windowed);
				break;
			case 2:
				_setting.SetMode(FullScreenMode.FullScreenWindow);
				break;
			default:
				Debug.LogWarning($"[SETTINGS] Invalid dropdown index! ({index})");
				break;
			}
			_setting.Save();
		}

		private void Update()
		{
			if (_mode != Screen.fullScreenMode)
			{
				SetDropDownWithoutNotify();
			}
		}
	}
}
