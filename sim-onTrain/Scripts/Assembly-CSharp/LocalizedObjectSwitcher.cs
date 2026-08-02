using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalizedObjectSwitcher : MonoBehaviour
{
	[Serializable]
	public struct LanguageEntry
	{
		public string languageCode;

		public GameObject target;
	}

	[SerializeField]
	private LanguageEntry[] entries;

	private void PopulateLanguages()
	{
		List<Locale> list = LocalizationSettings.AvailableLocales?.Locales;
		if (list == null || list.Count == 0)
		{
			Debug.LogError("No locales found. Make sure Localization Settings is configured.");
			return;
		}
		entries = new LanguageEntry[list.Count];
		int num = -1;
		for (int i = 0; i < list.Count; i++)
		{
			entries[i].languageCode = list[i].Identifier.Code;
			if (entries[i].languageCode.Equals("en", StringComparison.OrdinalIgnoreCase))
			{
				num = i;
			}
		}
		if (num > 0)
		{
			ref LanguageEntry reference = ref entries[0];
			ref LanguageEntry reference2 = ref entries[num];
			LanguageEntry languageEntry = entries[num];
			LanguageEntry languageEntry2 = entries[0];
			reference = languageEntry;
			reference2 = languageEntry2;
		}
		Debug.Log($"Populated {list.Count} languages.");
	}

	private void Start()
	{
		StartCoroutine(InitAfterLocalization());
	}

	private IEnumerator InitAfterLocalization()
	{
		yield return LocalizationSettings.InitializationOperation;
		Apply(LocalizationSettings.SelectedLocale);
	}

	private void OnEnable()
	{
		LocalizationSettings.SelectedLocaleChanged += Apply;
	}

	private void OnDisable()
	{
		LocalizationSettings.SelectedLocaleChanged -= Apply;
	}

	private void Apply(Locale locale)
	{
		if (locale == null)
		{
			return;
		}
		string code = locale.Identifier.Code;
		LanguageEntry[] array = entries;
		for (int i = 0; i < array.Length; i++)
		{
			LanguageEntry languageEntry = array[i];
			if (languageEntry.target != null)
			{
				languageEntry.target.SetActive(string.Equals(languageEntry.languageCode, code, StringComparison.OrdinalIgnoreCase));
			}
		}
	}
}
