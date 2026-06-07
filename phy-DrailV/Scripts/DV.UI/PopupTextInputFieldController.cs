using System;
using System.Text.RegularExpressions;
using DV.UIFramework;
using DV.Utils;
using TMPro;
using UnityEngine;

public class PopupTextInputFieldController : MonoBehaviour, IPopupSubmitHandler
{
	public Popup popup;

	public TMP_InputField field;

	public ButtonDV confirmButton;

	public bool allowEmpty;

	[NonSerialized]
	public bool focusOnStart = true;

	private void Start()
	{
		field.onValueChanged.AddListener(OnInputValueChanged);
		field.onSelect.AddListener(OnSelect);
		field.onEndEdit.AddListener(OnDeselect);
		OnInputValueChanged(field.text);
		if (focusOnStart)
		{
			field.Select();
			field.ActivateInputField();
		}
	}

	private void OnDestroy()
	{
		field.onValueChanged.RemoveListener(OnInputValueChanged);
		field.onSelect.RemoveListener(OnSelect);
		field.onEndEdit.RemoveListener(OnDeselect);
	}

	private void OnSelect(string text)
	{
		SingletonBehaviour<APlatformProvider>.Instance.RequestTextInput(new APlatformProvider.TextInputRequest(field, isMultiLine: false, popup.labelTMPro.text, delegate(APlatformProvider.TextInputResult result)
		{
			if (result.SaveText)
			{
				SetText(result.Text);
				field.caretPosition = int.MaxValue;
			}
			if (result.IsFinished)
			{
				if ((bool)popup.negativeButton)
				{
					field.DeactivateInputField();
				}
				else
				{
					popup.Handle((!result.SaveText) ? PopupClosedByAction.Abortion : ((!IsInputValid(result.Text)) ? PopupClosedByAction.Negative : PopupClosedByAction.Positive));
				}
			}
		}));
	}

	private void OnDeselect(string arg0)
	{
		SingletonBehaviour<APlatformProvider>.Instance.FinishTextInput();
	}

	private void OnInputValueChanged(string value)
	{
		confirmButton.ToggleInteractable(IsInputValid(value));
	}

	public void HandleAction(PopupClosedByAction action)
	{
		switch (action)
		{
		case PopupClosedByAction.Positive:
			if (IsInputValid(field.text))
			{
				RequestPositive();
			}
			break;
		case PopupClosedByAction.Negative:
			RequestNegative();
			break;
		case PopupClosedByAction.Abortion:
			RequestAbortion();
			break;
		default:
			Debug.LogError($"Unhandled action {action}", this);
			break;
		}
	}

	private bool IsInputValid(string value)
	{
		if (!allowEmpty)
		{
			return !string.IsNullOrWhiteSpace(value);
		}
		return true;
	}

	private void RequestPositive()
	{
		popup.RequestClose(PopupClosedByAction.Positive, field.text);
	}

	private void RequestNegative()
	{
		popup.RequestClose(PopupClosedByAction.Negative, null);
	}

	private void RequestAbortion()
	{
		popup.RequestClose(PopupClosedByAction.Abortion, null);
	}

	public void SetText(string text)
	{
		field.text = text;
	}

	public void SetAllowedCharactersPattern(Regex pattern)
	{
		TMP_InputField tMP_InputField = field;
		tMP_InputField.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(tMP_InputField.onValidateInput, (TMP_InputField.OnValidateInput)((string text, int index, char addedChar) => pattern.IsMatch(addedChar.ToString()) ? addedChar : '\0'));
	}
}
