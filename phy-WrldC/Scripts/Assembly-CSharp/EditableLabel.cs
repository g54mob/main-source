using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditableLabel : MonoBehaviour
{
	private TMP_Text labelText;

	private TMP_InputField labelInput;

	private Button editLabelButton;

	public event Action OnBeginingEditLabelEvent;

	public event Action OnEndingEditLabelEvent;

	public event Action<string> OnLabelChangedEvent;

	private void Awake()
	{
		labelText = base.transform.FindComponent<TMP_Text>("LabelText", isRecursively: true);
		labelInput = base.transform.FindComponent<TMP_InputField>("LabelInput", isRecursively: true);
		editLabelButton = base.transform.FindComponent<Button>("EditLabelButton", isRecursively: true);
		editLabelButton.onClick.AddListener(EditLabelButtonHandler);
		labelInput.onEndEdit.AddListener(LabelInputEndEditHandler);
	}

	private void EditLabelButtonHandler()
	{
		editLabelButton.interactable = false;
		labelInput.gameObject.SetActive(value: true);
		labelText.gameObject.SetActive(value: false);
		labelInput.SetTextWithoutNotify(labelText.text);
		labelInput.Select();
		labelInput.ActivateInputField();
		this.OnBeginingEditLabelEvent?.Invoke();
	}

	private void LabelInputEndEditHandler(string newLabelText)
	{
		editLabelButton.interactable = true;
		labelInput.gameObject.SetActive(value: false);
		labelText.gameObject.SetActive(value: true);
		this.OnEndingEditLabelEvent?.Invoke();
		if (!string.IsNullOrEmpty(newLabelText) && !string.IsNullOrWhiteSpace(newLabelText) && labelText.text != newLabelText)
		{
			labelText.SetText(newLabelText);
			this.OnLabelChangedEvent?.Invoke(newLabelText);
		}
	}

	public void SetText(string text)
	{
		labelText.SetText(text);
	}
}
