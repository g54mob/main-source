using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;

[RequireComponent(typeof(GalaxyManager))]
public class GogLanguageInitializer : MonoBehaviour
{
	private GalaxyManager galaxyManager;

	[SerializeField]
	private bool callOnEnable;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private BuildInfo buildInfo;

	private static Dictionary<string, Language> LanguageByLanguageId = new Dictionary<string, Language>
	{
		{
			"ar-SA",
			Language.Arabic
		},
		{
			"zh-TW",
			Language.ChineseTraditional
		},
		{
			"cs-CZ",
			Language.Czech
		},
		{
			"ko-KR",
			Language.Korean
		},
		{
			"nb-NO",
			Language.Norwegian
		},
		{
			"pl-PL",
			Language.Polish
		},
		{
			"sv-SE",
			Language.Swedish
		},
		{
			"de-CH",
			Language.German
		},
		{
			"en-GB",
			Language.English
		},
		{
			"es-MX",
			Language.SpanishLatinoamerica
		},
		{
			"fr-BE",
			Language.French
		},
		{
			"it-CH",
			Language.Italian
		},
		{
			"nn-NO",
			Language.Norwegian
		},
		{
			"sv-FI",
			Language.Swedish
		},
		{
			"zh-HK",
			Language.ChineseSimplified
		},
		{
			"en-US",
			Language.English
		},
		{
			"es-ES",
			Language.SpanishLatinoamerica
		},
		{
			"zh-Hans",
			Language.ChineseSimplified
		},
		{
			"zh-Hant",
			Language.ChineseTraditional
		},
		{
			"ru-RU",
			Language.Russian
		},
		{
			"de-DE",
			Language.German
		},
		{
			"it-IT",
			Language.Italian
		},
		{
			"pt-BR",
			Language.BrazilianPortuguese
		},
		{
			"ja-JP",
			Language.Japanese
		},
		{
			"fr-FR",
			Language.French
		},
		{
			"pt-PT",
			Language.Portuguese
		},
		{
			"chinese (simplified)",
			Language.ChineseSimplified
		},
		{
			"chinese (traditional)",
			Language.ChineseTraditional
		},
		{
			"czech",
			Language.Czech
		},
		{
			"english",
			Language.English
		},
		{
			"british english",
			Language.English
		},
		{
			"french",
			Language.French
		},
		{
			"german",
			Language.German
		},
		{
			"italian",
			Language.Italian
		},
		{
			"japanese",
			Language.Japanese
		},
		{
			"korean",
			Language.Korean
		},
		{
			"norwegian",
			Language.Norwegian
		},
		{
			"polish",
			Language.Polish
		},
		{
			"portuguese",
			Language.Portuguese
		},
		{
			"portuguese (brazilian)",
			Language.BrazilianPortuguese
		},
		{
			"russian",
			Language.Russian
		},
		{
			"spanish",
			Language.Spanish
		},
		{
			"swedish",
			Language.Swedish
		},
		{
			"latin american spanish",
			Language.SpanishLatinoamerica
		}
	};

	private void OnEnable()
	{
		if (callOnEnable)
		{
			galaxyManager = GetComponent<GalaxyManager>();
			GalaxyManager.OnSignInSuccessful += InitializeLanguage;
		}
	}

	private void InitializeLanguage()
	{
		string currentGameLanguage = galaxyManager.GetCurrentGameLanguage();
		GalaxyManager.OnSignInSuccessful -= InitializeLanguage;
		if (string.IsNullOrWhiteSpace(currentGameLanguage))
		{
			return;
		}
		currentGameLanguage = currentGameLanguage.ToLowerInvariant();
		if (PlayerPrefs.GetInt("Language", -1) == -1 && LanguageByLanguageId.ContainsKey(currentGameLanguage))
		{
			Language language = LanguageByLanguageId[currentGameLanguage];
			if (LocalizationManager.Instance.AvailableLanguages.Contains(language))
			{
				settingsRouter.ChangeLanguage(language);
				InitializeBranchInfo();
			}
		}
	}

	private void InitializeBranchInfo()
	{
		buildInfo.branchName = "";
	}

	private void OnDestroy()
	{
		GalaxyManager.OnSignInSuccessful -= InitializeLanguage;
	}
}
