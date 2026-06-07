using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class DefaultModalWindow : ModalWindow
{
	[SerializeField]
	private TextMeshProUGUI bodyText;

	[SerializeField]
	private GameObject imageGroup;

	[SerializeField]
	private Image image;

	public void SetUp(string bodyMessage, string header, Sprite sprite, Action yesAction, Action noAction, string yesButtonText = "", string noButtonText = "", bool forceShowBothButtons = false)
	{
		bodyText.text = bodyMessage;
		base.yesAction = yesAction;
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
		if (sprite != null)
		{
			imageGroup.gameObject.SetActive(value: true);
			image.sprite = sprite;
		}
		else
		{
			imageGroup.gameObject.SetActive(value: false);
		}
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
}
