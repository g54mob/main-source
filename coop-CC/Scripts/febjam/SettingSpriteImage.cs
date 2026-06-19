using Aggro.Core;
using UnityEngine;
using UnityEngine.UI;

public class SettingSpriteImage : EntityBehaviourBase
{
	[SerializeField]
	private string _setting;

	private Image _image;

	private int _settingId;

	private uint _saveVersion;

	private int _inputVersion;

	protected override void OnInitializeBehaviour()
	{
		_image = GetComponent<Image>();
		if (_image == null)
		{
			base.enabled = false;
		}
		_settingId = AggroSettings.IdToHash(_setting);
	}

	protected override void OnUpdatePresentationLate()
	{
		if (_inputVersion != AggroInputManager.version || (AggroSettings.HasSetting<InputSetting>(_settingId) && _saveVersion != AggroSettings.GetSaveVersion<InputSetting>(_settingId)))
		{
			_inputVersion = AggroInputManager.version;
			if (AggroSettings.HasSetting<InputSetting>(_settingId))
			{
				_saveVersion = AggroSettings.GetSaveVersion<InputSetting>(_settingId);
			}
			InputSetting setting;
			string kbmPath;
			string gamepadPath;
			string path = (AggroSettings.TryGetSetting<InputSetting>(_settingId, out setting) ? (AggroInputManager.mode switch
			{
				InputMode.KBM => setting.GetKbmPath(), 
				InputMode.Gamepad => setting.GetGamepadPath(), 
				_ => throw new InvalidEnumException(), 
			}) : ((!GlobalScriptableObject<AggroSettingsObject>.instance.TryGetFallbackPath(_setting, out kbmPath, out gamepadPath)) ? "unknown" : (AggroInputManager.mode switch
			{
				InputMode.KBM => kbmPath, 
				InputMode.Gamepad => gamepadPath, 
				_ => throw new InvalidEnumException(), 
			})));
			_image.sprite = GlobalScriptableObject<AggroSettingsObject>.instance.GetInputSprite(path);
		}
	}
}
