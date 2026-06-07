using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BakedLocalizer : MonoBehaviour
{
	[Serializable]
	private class LocalizedValues
	{
		public string Arabic;

		public string German;

		public string English;

		public string Spanish;

		public string French;

		public string Italian;

		public string Japanese;

		public string Korean;

		public string Dutch;

		public string Portugues;

		public string Russian;

		public string Turkish;

		public string ChineseSimplified;

		public string ChineseTraditional;

		public string Get(LocaleDatabase.LocaleId localeId)
		{
			switch (localeId)
			{
			case LocaleDatabase.LocaleId.ar:
				return Arabic;
			case LocaleDatabase.LocaleId.de:
				return German;
			case LocaleDatabase.LocaleId.en_US:
			case LocaleDatabase.LocaleId.en_AU:
			case LocaleDatabase.LocaleId.en_GB:
				return English;
			case LocaleDatabase.LocaleId.es_ES:
				return Spanish;
			case LocaleDatabase.LocaleId.fr:
				return French;
			case LocaleDatabase.LocaleId.it:
				return Italian;
			case LocaleDatabase.LocaleId.ja:
				return Japanese;
			case LocaleDatabase.LocaleId.ko:
				return Korean;
			case LocaleDatabase.LocaleId.nl:
				return Dutch;
			case LocaleDatabase.LocaleId.pt_BR:
				return Portugues;
			case LocaleDatabase.LocaleId.ru:
				return Russian;
			case LocaleDatabase.LocaleId.tr:
				return Turkish;
			case LocaleDatabase.LocaleId.zh_CN:
				return ChineseSimplified;
			case LocaleDatabase.LocaleId.zh_TW:
				return ChineseTraditional;
			default:
				return English;
			}
		}
	}

	[Serializable]
	private class MappingEntry
	{
		[EnumSearch(typeof(StringId), false, isString = true)]
		public string StringId;

		public LocalizedValues Value;
	}

	[SerializeField]
	private FontDatabase _fontDatabase;

	[SerializeField]
	private List<MappingEntry> _localizationMapping;

	public bool GetLocalization(StringId fromId, out string localizedString, out TMP_FontAsset fontAsset)
	{
		LocaleDatabase.LocaleId localeId = GetLocaleId();
		string text = fromId.ToString();
		foreach (MappingEntry item in _localizationMapping)
		{
			if (item.StringId == text)
			{
				localizedString = item.Value.Get(localeId);
				if (string.IsNullOrEmpty(localizedString))
				{
					Diagnostics.FailAssert("Unable to find localization {0} in language {1}. Defaulting to English", fromId, localeId);
					localeId = LocaleDatabase.LocaleId.en_US;
					localizedString = item.Value.Get(localeId);
				}
				fontAsset = GetFontAsset(localeId);
				return true;
			}
		}
		localizedString = null;
		fontAsset = null;
		return false;
	}

	private TMP_FontAsset GetFontAsset(LocaleDatabase.LocaleId fromLocale)
	{
		return _fontDatabase.GetFont(fromLocale switch
		{
			LocaleDatabase.LocaleId.ar => "ar", 
			LocaleDatabase.LocaleId.ja => "jp", 
			LocaleDatabase.LocaleId.ko => "kr", 
			LocaleDatabase.LocaleId.zh_CN => "sc", 
			LocaleDatabase.LocaleId.zh_TW => "tc", 
			_ => "latin", 
		}).FontAsset;
	}

	private LocaleDatabase.LocaleId GetLocaleId()
	{
		return UnityLocaleQuery.GetLocaleId(Application.systemLanguage);
	}
}
