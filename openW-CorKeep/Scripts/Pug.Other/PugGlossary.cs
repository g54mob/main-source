using System;
using System.Collections.Generic;
using UnityEngine;

public class PugGlossary : MonoBehaviour
{
	private const string RESOURCE_DIR = "Glossary.generated/";

	public const string FALLBACK_LANGUAGE = "en";

	[NonSerialized]
	public static readonly List<string> supportedLanguages = new List<string>
	{
		"en", "sv", "de", "fr", "it", "es", "es-mx", "es-la", "pt-br", "ru",
		"pl", "tr", "uk", "cz", "ko", "ja", "zh-cn", "zh-tw"
	};

	private static readonly List<string> latinFontLanguages = new List<string>
	{
		"en", "sv", "de", "fr", "it", "es", "es-MX", "es-US", "pt-BR", "pl",
		"tr", "uk", "cz"
	};

	private Dictionary<string, int> indexLookup;

	private PugGlossaryStrings currentGlossary;

	public static string GetDirectoryPath(bool full = false)
	{
		if (!full)
		{
			return "Glossary.generated/";
		}
		return "Assets/Resources/Glossary.generated/";
	}

	public static string GetLanguageResourcePath(string language, bool full = false)
	{
		return GetDirectoryPath(full) + language + (full ? ".asset" : "");
	}

	public static string GetKeysResourcePath(bool full = false)
	{
		return GetLanguageResourcePath("keys", full);
	}

	public static bool CurrentLanguageUsesLatinFont()
	{
		if (Application.isPlaying)
		{
			return latinFontLanguages.Contains(Manager.prefs.language);
		}
		return false;
	}

	public void CommitLanguage(bool redrawLocalizedTextObjects = true)
	{
		if (currentGlossary != null)
		{
			Resources.UnloadAsset(currentGlossary);
			currentGlossary = null;
		}
		currentGlossary = Resources.Load<PugGlossaryStrings>(GetLanguageResourcePath(Manager.prefs.language));
		if (currentGlossary == null)
		{
			Debug.LogWarning("Could not load " + GetLanguageResourcePath(Manager.prefs.language));
		}
		if (!(Application.isPlaying && redrawLocalizedTextObjects))
		{
			return;
		}
		PugText[] array = UnityEngine.Object.FindObjectsOfType<PugText>();
		foreach (PugText pugText in array)
		{
			if (pugText.localize)
			{
				pugText.Render(rewindEffectAnims: false);
			}
		}
	}

	public void Awake()
	{
		PugGlossaryStrings pugGlossaryStrings = Resources.Load<PugGlossaryStrings>(GetKeysResourcePath());
		if (pugGlossaryStrings == null)
		{
			Debug.LogWarning("Could not load " + GetKeysResourcePath());
		}
		else
		{
			indexLookup = new Dictionary<string, int>(pugGlossaryStrings.strings.Length);
			for (int i = 0; i < pugGlossaryStrings.strings.Length; i++)
			{
				indexLookup[pugGlossaryStrings.strings[i]] = i;
			}
			Resources.UnloadAsset(pugGlossaryStrings);
		}
		CommitLanguage(redrawLocalizedTextObjects: false);
	}

	public string Get(string key)
	{
		if (currentGlossary == null)
		{
			return "M`i`s`s`i`n`g`:* " + key;
		}
		if (!indexLookup.ContainsKey(key))
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogWarning("Glossary.indexLookup miss the key " + key + ".");
				return "M`i`s`s`i`n`g:* " + key;
			}
			return "";
		}
		return currentGlossary.strings[indexLookup[key]];
	}

	public bool GlossaryHasText(string key)
	{
		if (currentGlossary != null && indexLookup.ContainsKey(key))
		{
			return currentGlossary.strings[indexLookup[key]] != "";
		}
		return false;
	}
}
