using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizationFontHandler : MonoBehaviour
{
	private FontManager fontManager;

	private void Start()
	{
		fontManager = Object.FindObjectOfType<FontManager>();
		LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
	}

	private void OnLocaleChanged(Locale locale)
	{
		UpdateAllTextFonts(locale.Identifier.Code);
	}

	private void UpdateAllTextFonts(string localeCode)
	{
	}
}
