using System.Text.RegularExpressions;
using Aggro.Core;
using TMPro;
using UnityEngine;

public class SettingSpriteText : EntityBehaviourBase
{
	[TextArea]
	[SerializeField]
	private string _text;

	private TMP_Text _tmpText;

	private bool _isDirty;

	private uint _globalSaveVersion;

	private int _inputVersion;

	private LocalizedText.Language _prevLanguage;

	private static readonly Regex REGEX = new Regex("<input='(?<input>[a-zA-Z0-9-_]+)'>", RegexOptions.Compiled);

	protected override void OnInitializeBehaviour()
	{
		_tmpText = GetComponent<TMP_Text>();
		if (_tmpText == null)
		{
			base.enabled = false;
		}
		else
		{
			_isDirty = true;
		}
	}

	protected override void OnUpdatePresentationLate()
	{
		if (_isDirty || _inputVersion != AggroInputManager.version || _globalSaveVersion != AggroSettings.globalSaveVersion || _prevLanguage != LocalizedText.CURRENT_LANGUAGE)
		{
			_isDirty = false;
			_inputVersion = AggroInputManager.version;
			_globalSaveVersion = AggroSettings.globalSaveVersion;
			_prevLanguage = LocalizedText.CURRENT_LANGUAGE;
			string input = ((!AggroSettings.isLocalizing) ? _text : LocalizedText.GetText(_text, printDebug: false));
			_tmpText.text = REGEX.Replace(input, delegate(Match match)
			{
				Group obj = match.Groups["input"];
				InputSetting setting;
				string kbmPath;
				string gamepadPath;
				string path = (AggroSettings.TryGetSetting<InputSetting>(obj.Value, out setting) ? (AggroInputManager.mode switch
				{
					InputMode.KBM => setting.GetKbmPath(), 
					InputMode.Gamepad => setting.GetGamepadPath(), 
					_ => throw new InvalidEnumException(), 
				}) : ((!GlobalScriptableObject<AggroSettingsObject>.instance.TryGetFallbackPath(obj.Value, out kbmPath, out gamepadPath)) ? "unknown" : (AggroInputManager.mode switch
				{
					InputMode.KBM => kbmPath, 
					InputMode.Gamepad => gamepadPath, 
					_ => throw new InvalidEnumException(), 
				})));
				string text = AggroInputManager.mode switch
				{
					InputMode.KBM => GlobalScriptableObject<AggroSettingsObject>.instance.kbmIconSpriteSheet.name, 
					InputMode.Gamepad => GlobalScriptableObject<AggroSettingsObject>.instance.gamepadIconSpriteSheet.name, 
					_ => throw new InvalidEnumException(), 
				};
				return "<sprite=\"" + text + "\" name=\"" + GlobalScriptableObject<AggroSettingsObject>.instance.GetInputSprite(path).name + "\">";
			});
		}
	}

	public void SetText(string text)
	{
		_text = text;
		_isDirty = true;
	}
}
