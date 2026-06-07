#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_WARNINGS
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Utils;

public static class LocalizationUtility
{
	private const string _settingsAssetPath = "Assets/Resources/Localization/LocalizationSettings.asset";

	private const string _dataAssetsPath = "Localization/";

	private static LanguageCode _currLanguage;

	private static LocalizationData _currData;

	private static LocalizationSettings _settings;

	private static Dictionary<TMP_FontAsset, List<TMP_FontAsset>> _originalFallbacks;

	public static LocalizationSettings Settings
	{
		get
		{
			if (_settings == null)
			{
				_settings = Resources.Load<LocalizationSettings>("Localization/" + Path.GetFileNameWithoutExtension("Assets/Resources/Localization/LocalizationSettings.asset"));
			}
			return _settings;
		}
	}

	public static LanguageCode CurrentLanguage => _currLanguage;

	public static event Action OnLanguageUpdate;

	public static event Action OnLanguagePostUpdate;

	static LocalizationUtility()
	{
		_currLanguage = LanguageCode.EN;
		_settings = null;
		TryApplyLocale(GetSystemLocale(Application.systemLanguage).Replace("-", "_"));
	}

	private static bool SetLanguageFromSystem()
	{
		string text = GetSystemLocale(Application.systemLanguage).Replace("-", "_");
		if (string.IsNullOrEmpty(text))
		{
			return false;
		}
		while (!TryApplyLocale(text))
		{
			int num = text.IndexOf("_");
			if (num <= 0)
			{
				typeof(LocalizationUtility).LogWarning("Could not get locale from platform", "SetLanguageFromSystem", 77);
				return false;
			}
			text = text.Substring(0, num);
			typeof(LocalizationUtility).LogWarning("Trying more general locale " + text, "SetLanguageFromSystem", 81);
		}
		return true;
	}

	public static bool SetLanguageFromSystem(LanguageCode fallback)
	{
		if (SetLanguageFromSystem())
		{
			return true;
		}
		if (HasData() && CurrentLanguage == fallback)
		{
			return true;
		}
		return SetLanguage(fallback);
	}

	public static bool SetLanguage(LanguageCode language)
	{
		if (IsLanguageAvailable(language))
		{
			if (_currLanguage != language)
			{
				_currLanguage = language;
			}
			_currData = Resources.Load<LocalizationData>("Localization/" + _currLanguage.ToString() + "_Translation");
			ApplyFontFallbacks();
			LocalizationUtility.OnLanguageUpdate?.Invoke();
			LocalizationUtility.OnLanguagePostUpdate?.Invoke();
			return true;
		}
		typeof(LocalizationUtility).Log("not going here are we?", "SetLanguage", 122);
		_currLanguage = LanguageCode.EN;
		_currData = Resources.Load<LocalizationData>("Localization/" + _currLanguage.ToString() + "_Translation");
		typeof(LocalizationUtility).LogError(string.Format("Requested language ({0}) is not available.\nPlease verify that you have the file: Resources/Localization/{0}", language), "SetLanguage", 125);
		return false;
	}

	public static bool IsLanguageAvailable(LanguageCode language)
	{
		foreach (LocalizedLanguage language2 in Settings.Languages)
		{
			if (language2.LanguageCode == language && language2.IsActive)
			{
				return true;
			}
		}
		if (language == LanguageCode.PSEUDO)
		{
			return true;
		}
		return false;
	}

	public static string GetSystemLocale()
	{
		return GetSystemLocale(Application.systemLanguage);
	}

	public static string GetSystemLocale(SystemLanguage language)
	{
		switch (language)
		{
		case SystemLanguage.Afrikaans:
			return "af";
		case SystemLanguage.Arabic:
			return "ar";
		case SystemLanguage.Basque:
			return "eu";
		case SystemLanguage.Belarusian:
			return "be";
		case SystemLanguage.Bulgarian:
			return "bg";
		case SystemLanguage.Catalan:
			return "ca";
		case SystemLanguage.Chinese:
		case SystemLanguage.ChineseSimplified:
			return "zh-cn";
		case SystemLanguage.ChineseTraditional:
			return "zh-tw";
		case SystemLanguage.Czech:
			return "cs";
		case SystemLanguage.Danish:
			return "da";
		case SystemLanguage.Dutch:
			return "nl";
		case SystemLanguage.English:
			return "en";
		case SystemLanguage.Estonian:
			return "et";
		case SystemLanguage.Faroese:
			return "fo";
		case SystemLanguage.Finnish:
			return "fi";
		case SystemLanguage.French:
			return "fr";
		case SystemLanguage.German:
			return "de";
		case SystemLanguage.Greek:
			return "el";
		case SystemLanguage.Hebrew:
			return "he";
		case SystemLanguage.Hungarian:
			return "hu";
		case SystemLanguage.Icelandic:
			return "is";
		case SystemLanguage.Indonesian:
			return "id";
		case SystemLanguage.Italian:
			return "it";
		case SystemLanguage.Japanese:
			return "ja";
		case SystemLanguage.Korean:
			return "ko";
		case SystemLanguage.Latvian:
			return "lv";
		case SystemLanguage.Lithuanian:
			return "lt";
		case SystemLanguage.Norwegian:
			return "no";
		case SystemLanguage.Polish:
			return "pl";
		case SystemLanguage.Portuguese:
			return "pt-br";
		case SystemLanguage.Romanian:
			return "ro";
		case SystemLanguage.Russian:
			return "ru";
		case SystemLanguage.SerboCroatian:
			return "hr";
		case SystemLanguage.Slovak:
			return "sk";
		case SystemLanguage.Slovenian:
			return "sl";
		case SystemLanguage.Spanish:
			return "es";
		case SystemLanguage.Swedish:
			return "sv";
		case SystemLanguage.Thai:
			return "th";
		case SystemLanguage.Turkish:
			return "tr";
		case SystemLanguage.Ukrainian:
			return "uk";
		case SystemLanguage.Vietnamese:
			return "vi";
		default:
			typeof(LocalizationUtility).LogWarning("Unknown language: " + Application.systemLanguage, "GetSystemLocale", 244);
			return "en";
		}
	}

	private static bool TryApplyLocale(string locale)
	{
		LanguageCode languageCode = StringToLanguageCode(locale);
		if (languageCode != LanguageCode.N)
		{
			typeof(LocalizationUtility).Log("Identified locale " + locale + " with code " + languageCode, "TryApplyLocale", 252);
			if (!IsLanguageAvailable(languageCode))
			{
				typeof(LocalizationUtility).LogWarning("Unable to apply language " + languageCode, "TryApplyLocale", 255);
				return false;
			}
			if (HasData() && CurrentLanguage == languageCode)
			{
				typeof(LocalizationUtility).Log("Language is already set to " + languageCode, "TryApplyLocale", 260);
				return true;
			}
			if (SetLanguage(languageCode))
			{
				typeof(LocalizationUtility).Log("Successfully applied language " + languageCode, "TryApplyLocale", 266);
				return true;
			}
			typeof(LocalizationUtility).LogWarning("Unable to apply language " + languageCode, "TryApplyLocale", 271);
		}
		else
		{
			typeof(LocalizationUtility).LogWarning("Could not identify language code for " + locale, "TryApplyLocale", 276);
		}
		return false;
	}

	public static string GetLocalizedText(string key)
	{
		if (_currData == null)
		{
			_currData = Resources.Load<LocalizationData>("Localization/" + _currLanguage.ToString() + "_Translation");
		}
		if (string.IsNullOrEmpty(key))
		{
			return "<<MISSING_LOCA_KEY: " + key + ">>";
		}
		if (!_currData.Items.TryGetValue(key, out var value))
		{
			return "<<" + key + ">>";
		}
		return value;
	}

	public static bool TryGetLocalizedText(string key, out string foundString)
	{
		if (_currData == null)
		{
			_currData = Resources.Load<LocalizationData>("Localization/" + _currLanguage.ToString() + "_Translation");
		}
		if (string.IsNullOrEmpty(key))
		{
			foundString = "<<MISSING_LOCA_KEY: " + key + ">>";
			return false;
		}
		if (!_currData.Items.TryGetValue(key, out var value))
		{
			foundString = "<<" + key + ">>";
			return false;
		}
		foundString = value;
		return true;
	}

	private static void ApplyFontFallbacks()
	{
		if (!(Settings == null) && Settings.ManagedFontAssets != null && Settings.ManagedFontAssets.Count != 0)
		{
			CacheOriginalFallbacks();
			if (_currData != null && _currData.FontFallbacks != null && _currData.FontFallbacks.Count > 0)
			{
				ApplyFallbackFonts();
			}
			else
			{
				ResetFallbackFonts();
			}
		}
	}

	private static void CacheOriginalFallbacks()
	{
		if (_originalFallbacks != null)
		{
			return;
		}
		_originalFallbacks = new Dictionary<TMP_FontAsset, List<TMP_FontAsset>>();
		foreach (TMP_FontAsset managedFontAsset in Settings.ManagedFontAssets)
		{
			if (managedFontAsset != null)
			{
				_originalFallbacks[managedFontAsset] = new List<TMP_FontAsset>(managedFontAsset.fallbackFontAssetTable);
			}
		}
	}

	private static void ApplyFallbackFonts()
	{
		foreach (TMP_FontAsset managedFontAsset in Settings.ManagedFontAssets)
		{
			if (managedFontAsset != null)
			{
				managedFontAsset.fallbackFontAssetTable = new List<TMP_FontAsset>();
			}
		}
		foreach (FontFallbackEntry fontFallback in _currData.FontFallbacks)
		{
			if (fontFallback.ManagedFont != null && fontFallback.FallbackFont != null)
			{
				fontFallback.ManagedFont.fallbackFontAssetTable = new List<TMP_FontAsset> { fontFallback.FallbackFont };
			}
		}
	}

	private static void ResetFallbackFonts()
	{
		foreach (TMP_FontAsset managedFontAsset in Settings.ManagedFontAssets)
		{
			if (managedFontAsset != null && _originalFallbacks.TryGetValue(managedFontAsset, out var value))
			{
				managedFontAsset.fallbackFontAssetTable = new List<TMP_FontAsset>(value);
			}
		}
	}

	private static void RestoreOriginalFallbacks()
	{
		if (_originalFallbacks == null || Settings == null || Settings.ManagedFontAssets == null)
		{
			return;
		}
		foreach (TMP_FontAsset managedFontAsset in Settings.ManagedFontAssets)
		{
			if (managedFontAsset != null && _originalFallbacks.TryGetValue(managedFontAsset, out var value))
			{
				managedFontAsset.fallbackFontAssetTable = value;
			}
		}
		_originalFallbacks = null;
	}

	public static string LimitTextLength(string text, int maxLength)
	{
		if (text.Length <= maxLength)
		{
			return text;
		}
		return text.Substring(0, maxLength - 3) + "...";
	}

	public static bool HasData()
	{
		return _currData != null;
	}

	public static LanguageCode StringToLanguageCode(string language)
	{
		if (string.IsNullOrEmpty(language))
		{
			return LanguageCode.N;
		}
		language = language.ToUpper();
		foreach (LanguageCode value in Enum.GetValues(typeof(LanguageCode)))
		{
			if ((value.ToString() ?? "") == language)
			{
				return value;
			}
		}
		typeof(LocalizationUtility).LogError("There is no language: [" + language + "]", "StringToLanguageCode", 497);
		return LanguageCode.N;
	}

	public static LanguageCode LanguageNameToCode(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return LanguageCode.N;
		}
		foreach (LocalizedLanguage language in Settings.Languages)
		{
			if (name == language.Name)
			{
				return language.LanguageCode;
			}
		}
		typeof(LocalizationUtility).LogError("There is no language named: [" + name + "]", "LanguageNameToCode", 511);
		return LanguageCode.N;
	}
}
