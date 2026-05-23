using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SokLoc : MonoBehaviour
{
	public static SokLoc instance;

	public static SokLanguage[] Languages = new SokLanguage[12]
	{
		new SokLanguage
		{
			LanguageName = "English",
			UnitySystemLanguage = SystemLanguage.English
		},
		new SokLanguage
		{
			LanguageName = "Dutch",
			UnitySystemLanguage = SystemLanguage.Dutch
		},
		new SokLanguage
		{
			LanguageName = "French",
			UnitySystemLanguage = SystemLanguage.French
		},
		new SokLanguage
		{
			LanguageName = "Italian",
			UnitySystemLanguage = SystemLanguage.Italian
		},
		new SokLanguage
		{
			LanguageName = "German",
			UnitySystemLanguage = SystemLanguage.German
		},
		new SokLanguage
		{
			LanguageName = "Spanish",
			UnitySystemLanguage = SystemLanguage.Spanish
		},
		new SokLanguage
		{
			LanguageName = "Polish",
			UnitySystemLanguage = SystemLanguage.Polish
		},
		new SokLanguage
		{
			LanguageName = "Brazilian Portuguese",
			UnitySystemLanguage = SystemLanguage.Portuguese
		},
		new SokLanguage
		{
			LanguageName = "Chinese (Traditional)",
			UnitySystemLanguage = SystemLanguage.ChineseTraditional
		},
		new SokLanguage
		{
			LanguageName = "Chinese (Simplified)",
			UnitySystemLanguage = SystemLanguage.ChineseSimplified
		},
		new SokLanguage
		{
			LanguageName = "Japanese",
			UnitySystemLanguage = SystemLanguage.Japanese
		},
		new SokLanguage
		{
			LanguageName = "Korean",
			UnitySystemLanguage = SystemLanguage.Korean
		}
	};

	private static Dictionary<string, string> localLanguageNames = new Dictionary<string, string>
	{
		{ "English", "English" },
		{ "Dutch", "Nederlands" },
		{ "French", "Français" },
		{ "Italian", "Italiano" },
		{ "German", "Deutsch" },
		{ "Spanish", "Español" },
		{ "Polish", "Polski" },
		{ "Brazilian Portuguese", "Português (Brasil)" },
		{ "Chinese (Traditional)", "繁體中文" },
		{ "Chinese (Simplified)", "简体中文" },
		{ "Japanese", "日本語" },
		{ "Korean", "한국어" }
	};

	private LoadedLocSet currentLocSet;

	private static LoadedLocSet fallbackLocSet;

	public string CurrentLanguage = "Dutch";

	public static SokLanguage DefaultLanguage => Languages[0];

	public LoadedLocSet CurrentLocSet
	{
		get
		{
			if (currentLocSet == null || currentLocSet.Language != CurrentLanguage)
			{
				currentLocSet = new LoadedLocSet(LocResources.Default, CurrentLanguage);
			}
			return currentLocSet;
		}
	}

	public static LoadedLocSet FallbackSet
	{
		get
		{
			if (fallbackLocSet == null)
			{
				fallbackLocSet = new LoadedLocSet(LocResources.Default, "English");
			}
			return fallbackLocSet;
		}
	}

	public event Action LanguageChanged;

	private void Awake()
	{
		instance = this;
	}

	public void SetLanguage(string language)
	{
		if (GetLanguageWithName(language) == null)
		{
			throw new ArgumentException(language + " is not a valid language");
		}
		CurrentLanguage = language;
		this.LanguageChanged?.Invoke();
	}

	public SokLanguage GetLanguageWithName(string languageName)
	{
		SokLanguage[] languages = Languages;
		foreach (SokLanguage sokLanguage in languages)
		{
			if (sokLanguage.LanguageName == languageName)
			{
				return sokLanguage;
			}
		}
		return null;
	}

	public static string Translate(string termId)
	{
		if (instance != null)
		{
			string text = instance.CurrentLocSet.TranslateTerm(termId);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
		}
		return FallbackSet.TranslateTerm(termId);
	}

	public static string Translate(string termId, params LocParam[] locParams)
	{
		if (instance != null)
		{
			string text = instance.CurrentLocSet.TranslateTerm(termId, locParams);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
		}
		return FallbackSet.TranslateTerm(termId, locParams);
	}

	public static SokLanguage DetermineSystemLanguage()
	{
		SokLanguage[] languages = Languages;
		foreach (SokLanguage sokLanguage in languages)
		{
			if (sokLanguage.UnitySystemLanguage == Application.systemLanguage)
			{
				return sokLanguage;
			}
		}
		return DefaultLanguage;
	}

	public static string GetLocalLanguageName(string languageName)
	{
		return localLanguageNames[languageName];
	}

	public void LoadTermsFromFile(string path, bool disableWarning = false)
	{
		string[][] array = ParseTableFromTsv(File.ReadAllText(path));
		int languageColumnIndex = GetLanguageColumnIndex(array, CurrentLanguage);
		if (languageColumnIndex == -1)
		{
			return;
		}
		for (int i = 1; i < array.Length; i++)
		{
			string term = array[i][0];
			string fullText = array[i][languageColumnIndex];
			term = term.Trim().ToLower();
			if (string.IsNullOrEmpty(term))
			{
				continue;
			}
			SokTerm sokTerm = new SokTerm(CurrentLocSet, term, fullText);
			if (CurrentLocSet.TermLookup.ContainsKey(term))
			{
				if (!disableWarning)
				{
					Debug.LogError("Term " + term + " has been found more than once in the localisation sheet. Using last item in sheet.");
				}
				CurrentLocSet.TermLookup[term] = sokTerm;
				CurrentLocSet.AllTerms.RemoveAll((SokTerm x) => x.Id == term);
				CurrentLocSet.AllTerms.Add(sokTerm);
			}
			else
			{
				CurrentLocSet.AllTerms.Add(sokTerm);
				CurrentLocSet.TermLookup.Add(term, sokTerm);
			}
		}
	}

	public static string[][] ParseTableFromTsv(string tsv)
	{
		string[] array = tsv.Trim().Split('\n');
		string[][] array2 = new string[array.Length][];
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			text = text.Replace("\r", "");
			text = text.Replace("#", "\n");
			array2[i] = text.Split('\t');
		}
		Debug.Log($"Parsed {array.Length - 1} rows");
		return array2;
	}

	public static int GetLanguageColumnIndex(string[][] table, string language)
	{
		for (int i = 0; i < table[0].Length; i++)
		{
			if (table[0][i] == language)
			{
				return i;
			}
		}
		Debug.LogError("No column exists for " + language);
		return -1;
	}
}
