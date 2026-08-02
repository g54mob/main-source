using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

public class FontManager : MonoBehaviour
{
	[Header("Fonts")]
	public TMP_FontAsset defaultFont;

	public TMP_FontAsset chineseFont;

	public TMP_FontAsset cyrillicFont;

	public TMP_FontAsset turkishFont;

	public TMP_FontAsset japaneseFont;

	public TMP_FontAsset frenchFont;

	private List<TMP_Text> registeredTexts = new List<TMP_Text>();

	private void Start()
	{
		LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
	}

	public TMP_FontAsset GetFontForLanguage(string languageCode)
	{
		switch (languageCode)
		{
		case "zh":
		case "zh-CN":
			return chineseFont;
		case "ja":
			return japaneseFont;
		case "tr-TR":
			return turkishFont;
		case "ru":
			return cyrillicFont;
		case "fr":
			return frenchFont;
		default:
			return defaultFont;
		}
	}

	public void RegisterText(TMP_Text textComponent)
	{
		if (!registeredTexts.Contains(textComponent))
		{
			registeredTexts.Add(textComponent);
			UpdateSingleTextFont(textComponent);
		}
	}

	public void UnregisterText(TMP_Text textComponent)
	{
		registeredTexts.Remove(textComponent);
	}

	private void OnLocaleChanged(Locale locale)
	{
		UpdateAllRegisteredTexts();
	}

	private void UpdateAllRegisteredTexts()
	{
		string languageCode = LocalizationSettings.SelectedLocale?.Identifier.Code ?? "en";
		TMP_FontAsset fontForLanguage = GetFontForLanguage(languageCode);
		registeredTexts.RemoveAll((TMP_Text text) => text == null);
		foreach (TMP_Text registeredText in registeredTexts)
		{
			registeredText.font = fontForLanguage;
			registeredText.fontSharedMaterial = fontForLanguage.material;
		}
	}

	private void UpdateSingleTextFont(TMP_Text textComponent)
	{
		string languageCode = LocalizationSettings.SelectedLocale?.Identifier.Code ?? "en";
		TMP_FontAsset tMP_FontAsset = (textComponent.font = GetFontForLanguage(languageCode));
		textComponent.fontSharedMaterial = tMP_FontAsset.material;
	}

	private void OnDestroy()
	{
		LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
	}

	public void AddDynamicFontSwitcherToAll()
	{
		LocalizeStringEvent[] array = Object.FindObjectsOfType<LocalizeStringEvent>(includeInactive: true);
		int num = 0;
		LocalizeStringEvent[] array2 = array;
		foreach (LocalizeStringEvent localizeStringEvent in array2)
		{
			if (localizeStringEvent.GetComponent<DynamicFontSwitcher>() == null)
			{
				localizeStringEvent.gameObject.AddComponent<DynamicFontSwitcher>();
				num++;
			}
		}
		Debug.Log($"[FontManager] {array.Length} LocalizeStringEvent bulundu. {num} objeye DynamicFontSwitcher eklendi.");
	}
}
