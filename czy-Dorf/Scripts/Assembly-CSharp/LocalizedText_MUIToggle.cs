using Michsky.UI.ModernUIPack;
using UnityEngine;

[RequireComponent(typeof(UIManagerToggle))]
public class LocalizedText_MUIToggle : LocalizedText
{
	[SerializeField]
	private string appendOnKey;

	[SerializeField]
	private string appendOffKey;

	private UIManagerToggle toggleManager;

	protected void Awake()
	{
		Setup();
		toggleManager = GetComponent<UIManagerToggle>();
	}

	protected override void OnDestroy()
	{
		if ((bool)LocalizationManager.Instance)
		{
			LocalizationManager.Instance.OnLanguageChanged -= OnUpdateText;
		}
	}

	private void OnUpdateText()
	{
		UpdateText();
	}

	protected override void UpdateText()
	{
		string text = "";
		for (int i = 0; i < keys.Count; i++)
		{
			if (i > 0)
			{
				text += " ";
			}
			text += LocalizationManager.Instance.GetLocalizedValue(keys[i]);
		}
		if (text == "")
		{
			Debug.LogError("localized text is empty", this);
			return;
		}
		toggleManager.onLabel.text = text + " " + LocalizationManager.Instance.GetLocalizedValue(appendOnKey);
		toggleManager.offLabel.text = text + " " + LocalizationManager.Instance.GetLocalizedValue(appendOffKey);
		toggleManager.onLabel.font = LocalizationManager.Instance.GetFont(style);
		toggleManager.offLabel.font = LocalizationManager.Instance.GetFont(style);
	}
}
