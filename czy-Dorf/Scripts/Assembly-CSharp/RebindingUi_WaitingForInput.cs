using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RebindingUi_WaitingForInput : MonoBehaviour
{
	[Serializable]
	private class ActionIcons
	{
		public string actionKey;

		public List<Sprite> actionIcons;
	}

	[SerializeField]
	private TextMeshProUGUI actionLabel;

	[SerializeField]
	private Image actionIconImage;

	[SerializeField]
	private List<ActionIcons> actionIcons;

	private Dictionary<string, List<Sprite>> icons;

	private string currentKey;

	private void SetupIconsDictionary()
	{
		icons = new Dictionary<string, List<Sprite>>();
		foreach (ActionIcons actionIcon in actionIcons)
		{
			icons.Add(actionIcon.actionKey, actionIcon.actionIcons);
		}
	}

	private void Start()
	{
		LocalizationManager.Instance.OnLanguageChanged += UpdateLabel;
	}

	public void Setup(string actionKey, int bindingIndex)
	{
		Debug.Log($"Show Screen for bindingIndex {bindingIndex}");
		if (icons == null)
		{
			SetupIconsDictionary();
		}
		if (icons.ContainsKey(actionKey))
		{
			actionIconImage.sprite = icons[actionKey][bindingIndex - 1];
			actionIconImage.gameObject.SetActive(value: true);
		}
		else
		{
			actionIconImage.gameObject.SetActive(value: false);
		}
		currentKey = actionKey;
		UpdateLabel();
	}

	private void UpdateLabel()
	{
		if (!string.IsNullOrWhiteSpace(currentKey))
		{
			actionLabel.font = LocalizationManager.Instance.GetFont(LocalizedFontStyle.H1);
			actionLabel.text = LocalizationManager.Instance.GetLocalizedValue(currentKey);
		}
	}

	public void Show(bool newShow)
	{
		base.gameObject.SetActive(newShow);
	}
}
