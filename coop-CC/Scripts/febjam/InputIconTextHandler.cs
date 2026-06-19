using System.Collections.Generic;
using Aggro.Core;
using TMPro;
using UnityEngine;

public class InputIconTextHandler : EntityBehaviourBase
{
	private string _previousText = "";

	public string text = "";

	private string _gamePadCache = "";

	private string _keyboardCache = "";

	private InputMode _previousInputMode;

	protected override void OnUpdatePresentation()
	{
		if (text != _previousText)
		{
			UpdateTextCaches();
		}
		if (text != _previousText || _previousInputMode != AggroInputManager.mode)
		{
			UpdateTextMesh();
		}
		_previousText = text;
		_previousInputMode = AggroInputManager.mode;
	}

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			UpdateTextCaches();
			UpdateTextMesh();
		}
	}

	protected override void OnEntityCreated()
	{
		if (Application.isPlaying)
		{
			UpdateTextCaches();
		}
		_previousText = text;
	}

	public void UpdateTextMesh()
	{
		TextMeshProUGUI component = base.gameObject.GetComponent<TextMeshProUGUI>();
		if (component == null)
		{
			Debug.LogError("no TextMeshProUGUI component attached");
		}
		else
		{
			component.text = ((AggroInputManager.mode == InputMode.Gamepad) ? _gamePadCache : _keyboardCache);
		}
	}

	public void UpdateTextCaches()
	{
		TextMeshProUGUI component = base.gameObject.GetComponent<TextMeshProUGUI>();
		if (component == null)
		{
			Debug.LogError("no TextMeshProUGUI component attached");
			return;
		}
		string text = this.text;
		if (!(GlobalScriptableObject<InputIconText>.instance != null))
		{
			return;
		}
		Dictionary<string, InputIconText.InputActionIconSet> inputActionIconSets = GlobalScriptableObject<InputIconText>.instance.GetInputActionIconSets();
		_gamePadCache = text;
		_keyboardCache = text;
		foreach (string key in inputActionIconSets.Keys)
		{
			new List<string>();
			string text2 = "";
			foreach (string keyboardString in inputActionIconSets[key].keyboardStrings)
			{
				text2 += GetCompiledIconString(keyboardString, "keyboard");
			}
			if (text.Contains(text2))
			{
				text = text.Replace(text2, GetCompiledActionString(key));
			}
			text2 = "";
			foreach (string gamepadString in inputActionIconSets[key].gamepadStrings)
			{
				text2 += GetCompiledIconString(gamepadString, "gamepad");
			}
			if (text.Contains(text2))
			{
				text = text.Replace(text2, GetCompiledActionString(key));
			}
			if (text.Contains(key))
			{
				text2 = "";
				foreach (string gamepadString2 in inputActionIconSets[key].gamepadStrings)
				{
					text2 += GetCompiledIconString(gamepadString2, "gamepad");
				}
				_gamePadCache = _gamePadCache.Replace(GetCompiledActionString(key), text2);
				text2 = "";
				foreach (string keyboardString2 in inputActionIconSets[key].keyboardStrings)
				{
					text2 += GetCompiledIconString(keyboardString2, "keyboard");
				}
				_keyboardCache = _keyboardCache.Replace(GetCompiledActionString(key), text2);
			}
			component.text = ((AggroInputManager.mode == InputMode.Gamepad) ? _gamePadCache : _keyboardCache);
		}
	}

	private string GetCompiledActionString(string actionString)
	{
		return "<" + actionString + ">";
	}

	private string GetCompiledIconString(string iconString, string modeString)
	{
		return "<sprite=\"sprite-" + modeString + "\" name=\"" + iconString + "\">";
	}
}
