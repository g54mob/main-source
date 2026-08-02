using System;
using TMPro;
using UnityEngine;

public class SignTextInputPanel : UIPanelBase
{
	[Header("UI Elements")]
	public TMP_InputField textInputField;

	private Action<string> onChange;

	private void Update()
	{
		if (isPanelOpen && Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.ExitKey))
		{
			ClosePanel();
		}
	}

	public void Open(string currentText, int maxChars, Action<string> changeCallback)
	{
		onChange = changeCallback;
		if (textInputField != null)
		{
			textInputField.onValueChanged.RemoveListener(HandleChanged);
			textInputField.characterLimit = maxChars;
			textInputField.restoreOriginalTextOnEscape = false;
			textInputField.SetTextWithoutNotify(currentText ?? "");
			textInputField.onValueChanged.AddListener(HandleChanged);
		}
		ShowPanel();
		if (textInputField != null)
		{
			textInputField.ActivateInputField();
		}
		ChatPanelController.isInputFocused = true;
	}

	private void HandleChanged(string value)
	{
		onChange?.Invoke(value);
	}

	public void ClosePanel()
	{
		if (textInputField != null)
		{
			textInputField.onValueChanged.RemoveListener(HandleChanged);
			onChange?.Invoke(textInputField.text);
			textInputField.DeactivateInputField();
		}
		onChange = null;
		ChatPanelController.isInputFocused = false;
		HidePanel();
		if (Singleton<MainUIManager>.Instance != null)
		{
			Singleton<MainUIManager>.Instance.OnInGamePanelClosed.Invoke(this);
		}
	}
}
