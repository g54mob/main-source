#define ENABLE_DEBUG_EXCEPTIONS
#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using Data.UI.Controls;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Presentation.UI
{
	public class LocalizedTextWithInputs : MonoBehaviour
	{
		[SerializeField]
		private SettingsRebindRuntimeInfo _rebindInfo;

		[SerializeField]
		private TMP_Text _text;

		[Header("Text")]
		[SerializeField]
		[LocaKey]
		private string _textId;

		[SerializeField]
		private InputActionReference[] _inputActions;

		private readonly List<SettingsRebindActionData> _rebindActionData = new List<SettingsRebindActionData>();

		private void Start()
		{
			for (int i = 0; i < _inputActions.Length; i++)
			{
				if (!_rebindInfo.TryGetRebindActionData(_inputActions[i], out var rebindActionData))
				{
					this.LogError($"The InputAction of index {i} doesn't have a rebind?", "Start", 27);
					return;
				}
				foreach (SettingsRebindActionData item in rebindActionData)
				{
					_rebindActionData.Add(item);
					item.OnChanged = (Action)Delegate.Combine(item.OnChanged, new Action(UpdateText));
				}
			}
			LocalizationUtility.OnLanguageUpdate += UpdateText;
			UpdateText();
		}

		private void OnDestroy()
		{
			if (_rebindActionData == null)
			{
				return;
			}
			foreach (SettingsRebindActionData rebindActionDatum in _rebindActionData)
			{
				rebindActionDatum.OnChanged = (Action)Delegate.Remove(rebindActionDatum.OnChanged, new Action(UpdateText));
			}
			LocalizationUtility.OnLanguageUpdate -= UpdateText;
		}

		private void UpdateText()
		{
			string[] array = new string[_inputActions.Length];
			for (int i = 0; i < _inputActions.Length; i++)
			{
				if (!_rebindInfo.TryGetBindingString(_inputActions[i], out var bindingString, getLongVersion: true, ", "))
				{
					this.DevException("Failed to get bindingString?", "UpdateText", 61);
					array[i] = "_";
				}
				else
				{
					array[i] = bindingString;
				}
			}
			string localizedText = LocalizationUtility.GetLocalizedText(_textId);
			TMP_Text text = _text;
			object[] args = array;
			text.SetText(string.Format(localizedText, args));
		}
	}
}
