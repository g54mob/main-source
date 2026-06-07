using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Settings;

public class InputModalWindow : ModalWindow
{
	[SerializeField]
	private TMP_InputField inputField;

	private Action<string> yesActionString;

	public void SetUp(string header, string defualtInputText, Action<string> yesAction, Action noAction, string yesButtonText = "", string noButtonText = "", bool forceShowBothButtons = false, int characterLimit = 0)
	{
		yesActionString = yesAction;
		base.noAction = noAction;
		if (header != null && header.Trim() != "")
		{
			headerGroup.gameObject.SetActive(value: true);
			headerText.text = header;
		}
		else
		{
			headerGroup.gameObject.SetActive(value: false);
		}
		EventSystem.current.SetSelectedGameObject(inputField.gameObject);
		inputField.text = defualtInputText;
		inputField.characterLimit = characterLimit;
		yesButton.gameObject.SetActive(value: true);
		noButton.gameObject.SetActive(forceShowBothButtons || noAction != null);
		yesButton.onClick.AddListener(YesPressed);
		noButton.onClick.AddListener(NoPressed);
		if (yesButtonText != "")
		{
			yesButton.GetComponentInChildren<TextMeshProUGUI>().text = yesButtonText;
		}
		else
		{
			yesButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_yes").Entry.GetLocalizedString();
		}
		if (noButtonText != "")
		{
			noButton.GetComponentInChildren<TextMeshProUGUI>().text = noButtonText;
		}
		else
		{
			noButton.GetComponentInChildren<TextMeshProUGUI>().text = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_no").Entry.GetLocalizedString();
		}
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	public override void YesPressed()
	{
		if (yesActionString != null)
		{
			yesActionString(inputField.text);
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
