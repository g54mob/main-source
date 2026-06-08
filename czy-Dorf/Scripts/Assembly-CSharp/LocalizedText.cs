using System;
using System.Collections.Generic;
using System.Globalization;
using Dorfromantik.UI;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;

public class LocalizedText : MonoBehaviour
{
	[SerializeField]
	protected string key;

	[SerializeField]
	protected LocalizedFontStyle style;

	protected List<string> keys;

	[SerializeField]
	private bool neverSwitchAlignment;

	[SerializeField]
	private bool titleCase;

	[SerializeField]
	private bool firstCharToUpper;

	[SerializeField]
	private string prefixString;

	[SerializeField]
	private bool useHighlightColor;

	[SerializeField]
	private Material highlightMaterial;

	[SerializeField]
	private bool useHighlightFont;

	[SerializeField]
	private bool useFallbackText;

	protected TextMeshProUGUI textMeshUi;

	protected TextMeshPro textMesh;

	private ButtonManager buttonManager;

	private float originalFontSize;

	private HorizontalAlignmentOptions originalHorizontalAlignment;

	private bool hasTextAttributeModifier;

	private UiTextAttributeModifier textAttributeModifier;

	[SerializeField]
	internal string textString;

	protected event Action OnTextUpdated;

	protected virtual void Start()
	{
		if (!string.IsNullOrWhiteSpace(key))
		{
			textAttributeModifier = GetComponent<UiTextAttributeModifier>();
			if (textAttributeModifier != null)
			{
				hasTextAttributeModifier = true;
			}
			Setup();
		}
	}

	protected void Setup()
	{
		textMeshUi = GetComponent<TextMeshProUGUI>();
		buttonManager = GetComponent<ButtonManager>();
		textMesh = GetComponent<TextMeshPro>();
		if ((bool)textMeshUi)
		{
			originalFontSize = textMeshUi.fontSize;
			originalHorizontalAlignment = textMeshUi.horizontalAlignment;
		}
		if ((bool)buttonManager)
		{
			originalFontSize = buttonManager.normalText.fontSize;
			originalHorizontalAlignment = buttonManager.normalText.horizontalAlignment;
		}
		if ((bool)textMesh)
		{
			originalFontSize = textMesh.fontSize;
			originalHorizontalAlignment = textMesh.horizontalAlignment;
		}
		keys = new List<string>(key.Split(';'));
		if (LocalizationManager.Instance != null)
		{
			if (LocalizationManager.Instance.Initialized)
			{
				UpdateText();
			}
			else
			{
				Debug.LogError("Localization Manager is not initialized");
			}
			LocalizationManager.Instance.OnLanguageChanged += OnUpdateText;
		}
		else
		{
			Debug.LogError("LocalizationManager is null");
		}
	}

	protected virtual void OnDestroy()
	{
		if ((bool)LocalizationManager.Instance)
		{
			LocalizationManager.Instance.OnLanguageChanged -= OnUpdateText;
		}
	}

	public void UpdateLocalizedKey(string newLocalizedKey)
	{
		key = newLocalizedKey;
		keys = new List<string> { key };
		UpdateText();
	}

	private void OnUpdateText()
	{
		UpdateText();
	}

	protected virtual void UpdateText()
	{
		string text = "";
		for (int i = 0; i < keys.Count; i++)
		{
			if (i > 0)
			{
				text += " ";
			}
			text += LocalizationManager.Instance.GetLocalizedValue(keys[i], useFallbackText);
		}
		if (text == "")
		{
			Debug.LogWarning("localized text for key " + key + " is empty", this);
			return;
		}
		if (titleCase)
		{
			text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
		}
		if (firstCharToUpper)
		{
			text = StringUtility.FirstCharToUpper(text);
		}
		if (!string.IsNullOrWhiteSpace(prefixString))
		{
			text = (LocalizationManager.Instance.IsCurrentLanguageRightToLeft ? StringUtility.Reverse(prefixString) : prefixString) + text;
		}
		string text2 = "";
		string text3 = "";
		if (useHighlightColor)
		{
			text2 = text2 + "<color=#" + ColorUtility.ToHtmlStringRGBA(highlightMaterial.color) + ">";
			text3 += "</color>";
		}
		if (useHighlightFont)
		{
			text2 = text2 + "<font=\"" + LocalizationManager.Instance.GetFont(LocalizedFontStyle.ExtraBold).name + "\">";
			text3 += "</font>";
		}
		text = text.Replace("[h]", text2).Replace("[/h]", text3);
		if ((bool)textMeshUi)
		{
			UpdateTextMesh(textMeshUi, text);
		}
		if ((bool)textMesh)
		{
			UpdateTextMesh(textMesh, text);
		}
		if ((bool)buttonManager)
		{
			if (LocalizationManager.Instance.IsCurrentLanguageRightToLeft)
			{
				text = StringUtility.Reverse(text);
			}
			UpdateTextMesh(buttonManager.normalText, text);
			UpdateTextMesh(buttonManager.highlightedText, text);
			buttonManager.buttonText = text;
			buttonManager.UpdateUI();
		}
		textString = text;
	}

	protected void UpdateTextMesh(TMP_Text textMeshToUpdate, string targetText)
	{
		LocalizationManager.Instance.UpdateTextMesh(textMeshToUpdate, style, targetText, neverSwitchAlignment ? HorizontalAlignmentOptions.Center : originalHorizontalAlignment, originalFontSize);
		if (hasTextAttributeModifier)
		{
			textAttributeModifier.UpdateText();
		}
	}
}
