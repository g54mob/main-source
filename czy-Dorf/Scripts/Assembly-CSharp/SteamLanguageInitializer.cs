using System.Collections.Generic;
using Dorfromantik;
using Steamworks;
using UnityEngine;

public class SteamLanguageInitializer : MonoBehaviour
{
	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private BuildInfo buildInfo;

	public static Dictionary<string, Language> LanguageBySteamLanguageId = new Dictionary<string, Language>
	{
		{
			"arabic",
			Language.Arabic
		},
		{
			"schinese",
			Language.ChineseSimplified
		},
		{
			"tchinese",
			Language.ChineseTraditional
		},
		{
			"czech",
			Language.Czech
		},
		{
			"dutch",
			Language.Dutch
		},
		{
			"english",
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
			"hungarian",
			Language.Hungarian
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
			"koreana",
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
			"brazilian",
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
			"latam",
			Language.SpanishLatinoamerica
		},
		{
			"swedish",
			Language.Swedish
		},
		{
			"turkish",
			Language.Turkish
		},
		{
			"ukrainian",
			Language.Ukrainian
		}
	};

	private void Start()
	{
		if (SteamManager.Initialized)
		{
			InitializeLanguage();
			InitializeBranchInfo();
		}
	}

	private void InitializeBranchInfo()
	{
		SteamApps.GetCurrentBetaName(out buildInfo.branchName, 20);
	}

	private void InitializeLanguage()
	{
		string steamUILanguage = SteamUtils.GetSteamUILanguage();
		Debug.Log("detected language: " + steamUILanguage);
		if (!string.IsNullOrEmpty(steamUILanguage) && PlayerPrefs.GetInt("Language", -1) == -1 && LanguageBySteamLanguageId.ContainsKey(steamUILanguage))
		{
			Language language = LanguageBySteamLanguageId[steamUILanguage];
			if (LocalizationManager.Instance.AvailableLanguages.Contains(language))
			{
				settingsRouter.ChangeLanguage(language);
			}
		}
	}
}
