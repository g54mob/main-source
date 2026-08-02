using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

[RequireComponent(typeof(TMP_Text))]
public class DynamicFontSwitcher : MonoBehaviour
{
	private TMP_Text textComponent;

	private FontManager fontManager;

	private LocalizeStringEvent localizeEvent;

	public bool isUpper;

	private void Awake()
	{
		textComponent = GetComponent<TMP_Text>();
		fontManager = Object.FindObjectOfType<FontManager>();
		localizeEvent = GetComponent<LocalizeStringEvent>();
	}

	private void Start()
	{
		LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
		if (localizeEvent != null)
		{
			localizeEvent.OnUpdateString.AddListener(OnStringUpdated);
		}
		UpdateFont();
	}

	private void OnLocaleChanged(Locale locale)
	{
		UpdateFont();
	}

	private void OnStringUpdated(string text)
	{
		ApplyText(text);
		UpdateFont();
	}

	public void SetText(string text)
	{
		ApplyText(text);
	}

	private void ApplyText(string text)
	{
		if (textComponent == null)
		{
			return;
		}
		if (isUpper && !string.IsNullOrEmpty(text))
		{
			Locale selectedLocale = LocalizationSettings.SelectedLocale;
			if (selectedLocale != null && selectedLocale.Identifier.CultureInfo != null)
			{
				textComponent.text = text.ToUpper(selectedLocale.Identifier.CultureInfo);
			}
			else
			{
				textComponent.text = text.ToUpperInvariant();
			}
		}
		else
		{
			textComponent.text = text;
		}
	}

	private void UpdateFont()
	{
		if (!(fontManager == null) && !(LocalizationSettings.SelectedLocale == null))
		{
			string code = LocalizationSettings.SelectedLocale.Identifier.Code;
			TMP_FontAsset fontForLanguage = fontManager.GetFontForLanguage(code);
			if (!(fontForLanguage == null))
			{
				textComponent.font = fontForLanguage;
				textComponent.fontSharedMaterial = fontForLanguage.material;
			}
		}
	}

	private void OnDestroy()
	{
		LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
		if (localizeEvent != null)
		{
			localizeEvent.OnUpdateString.RemoveListener(OnStringUpdated);
		}
	}
}
