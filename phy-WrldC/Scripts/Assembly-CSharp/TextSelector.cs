using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextSelector : MonoBehaviour
{
	[SerializeField]
	private List<KeyValuePair<string, string>> idLabelSelectableTexts = new List<KeyValuePair<string, string>>();

	private TextMeshProUGUI textIdLabel;

	private Button prevTextButton;

	private Button nextTextButton;

	private int currentTextSelectedIndex;

	private bool isInteractable;

	public bool IsInteractable
	{
		set
		{
			isInteractable = value;
			prevTextButton.interactable = value;
			nextTextButton.interactable = value;
			textIdLabel.color = new Color(textIdLabel.color.r, textIdLabel.color.g, textIdLabel.color.b, value ? 1f : 0.5f);
			if (isInteractable)
			{
				RefreshPanel();
			}
		}
	}

	public event Action<string> OnValueChangedEvent;

	public void Initialize()
	{
		textIdLabel = base.transform.FindComponent<TextMeshProUGUI>("TextIdLabel", isRecursively: true);
		prevTextButton = base.transform.FindComponent<Button>("PrevTextButton", isRecursively: true);
		nextTextButton = base.transform.FindComponent<Button>("NextTextButton", isRecursively: true);
		prevTextButton.onClick.RemoveAllListeners();
		nextTextButton.onClick.RemoveAllListeners();
		prevTextButton.onClick.AddListener(PrevButtonHandler);
		nextTextButton.onClick.AddListener(NextButtonHandler);
		isInteractable = true;
		currentTextSelectedIndex = 0;
	}

	private void PrevButtonHandler()
	{
		currentTextSelectedIndex--;
		RefreshPanel();
		if (this.OnValueChangedEvent != null)
		{
			this.OnValueChangedEvent(GetSelectedTextId());
		}
	}

	private void NextButtonHandler()
	{
		currentTextSelectedIndex++;
		RefreshPanel();
		if (this.OnValueChangedEvent != null)
		{
			this.OnValueChangedEvent(GetSelectedTextId());
		}
	}

	private void RefreshPanel()
	{
		currentTextSelectedIndex = Mathf.Clamp(currentTextSelectedIndex, 0, idLabelSelectableTexts.Count - 1);
		prevTextButton.interactable = currentTextSelectedIndex != 0 && isInteractable;
		nextTextButton.interactable = currentTextSelectedIndex != idLabelSelectableTexts.Count - 1 && isInteractable;
		textIdLabel.text = idLabelSelectableTexts[currentTextSelectedIndex].Value;
	}

	public void AddText(string id, string text)
	{
		idLabelSelectableTexts.Add(new KeyValuePair<string, string>(id, text));
		RefreshPanel();
	}

	public bool SetSelectedText(string id)
	{
		KeyValuePair<string, string> item;
		try
		{
			item = idLabelSelectableTexts.First((KeyValuePair<string, string> idLabelText) => idLabelText.Key == id);
		}
		catch (Exception)
		{
			return false;
		}
		currentTextSelectedIndex = idLabelSelectableTexts.IndexOf(item);
		RefreshPanel();
		return true;
	}

	public string GetSelectedTextId()
	{
		return idLabelSelectableTexts[currentTextSelectedIndex].Key;
	}

	public void ClearAllTexts()
	{
		idLabelSelectableTexts.Clear();
	}
}
