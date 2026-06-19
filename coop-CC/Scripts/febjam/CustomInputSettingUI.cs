using Aggro.Core;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class CustomInputSettingUI : AggroSettingUI
{
	public TextMeshProUGUI inputText;

	public Selectable selectable;

	private CustomInputSetting _setting;

	private bool _releaseControl;

	public override void Set(AggroSettingBase setting)
	{
		if (setting is CustomInputSetting setting2)
		{
			_setting = setting2;
			inputText.text = InputControlPath.ToHumanReadableString(_setting.value);
		}
		else
		{
			Debug.LogWarning("[SETTINGS] Invalid setting type for CustomInputSettingUI!");
		}
	}

	public override void Refresh()
	{
		inputText.text = InputControlPath.ToHumanReadableString(_setting.value);
	}

	public void OnListeningForInput()
	{
		inputText.text = "Listening...";
		InputSystem.onAnyButtonPress.CallOnce(OnAnyButtonPress);
		AggroSettings.TakeInputControl();
	}

	private void OnAnyButtonPress(InputControl control)
	{
		_setting.SetValue(control.path);
		_setting.Save();
		inputText.text = InputControlPath.ToHumanReadableString(control.path);
		_releaseControl = true;
	}

	private void LateUpdate()
	{
		if (_releaseControl)
		{
			_releaseControl = false;
			AggroSettings.ReleaseInputControl(selectable.gameObject);
		}
	}
}
