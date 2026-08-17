using System;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageButtonMenu : MonoBehaviour
{
	public TextMeshProUGUI languageText;

	public TextSizer textSizer;

	public ButtonTextWrapper buttonTextWrapper;

	private void Start()
	{
		Locale selectedLocale = LocalizationSettings.SelectedLocale;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172137]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string languageName = LocalizationUtility.GetLanguageName(selectedLocale);
		languageText.text = languageName;
		Invoke("DelayedRefresh", 0f);
	}

	private void Awake()
	{
		Action<Locale> value = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged += value;
	}

	private void OnDestroy()
	{
		Action<Locale> value = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged -= value;
	}

	private void OnLocaleChanged(Locale newLocale)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172137]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string languageName = LocalizationUtility.GetLanguageName(newLocale);
		languageText.text = languageName;
		Invoke("DelayedRefresh", 0f);
	}

	private void DelayedRefresh()
	{
		if (textSizer != null)
		{
			textSizer.Refresh();
			textSizer.Recalculate();
		}
		if (buttonTextWrapper != null)
		{
			buttonTextWrapper.Refresh();
		}
	}
}
