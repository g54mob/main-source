using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocalizationSystem : MonoBehaviour
{
	public enum Language
	{
		EN = 0,
		FR = 1,
		IT = 2,
		DE = 3,
		ES = 4,
		JA = 5,
		KO = 6,
		SCH = 7,
		TCH = 8,
		PTBR = 9,
		EE = 10
	}

	public static Language language = Language.EN;

	private static Dictionary<string, string> localizedEN;

	private static Dictionary<string, string> localizedFR;

	private static Dictionary<string, string> localizedIT;

	private static Dictionary<string, string> localizedDE;

	private static Dictionary<string, string> localizedES;

	private static Dictionary<string, string> localizedJA;

	private static Dictionary<string, string> localizedKO;

	private static Dictionary<string, string> localizedSCH;

	private static Dictionary<string, string> localizedTCH;

	private static Dictionary<string, string> localizedPTBR;

	private static Dictionary<string, string> localizedEE;

	public static bool isInit;

	private static Dictionary<string, string> vampireSurvivors = new Dictionary<string, string>
	{
		{ "<rusty>", "Poe" },
		{ "<haiku>", "Antonio" },
		{ "<sonnet>", "Poppea" },
		{ "<pinion>", "Dommario" },
		{ "<forbic>", "Imelda" },
		{ "<echo>", "Lama" },
		{ "<slate>", "Giovanna" },
		{ "<splunk>", "Arca" }
	};

	private static Dictionary<string, string> balatro = new Dictionary<string, string>
	{
		{ "<rusty>", "Jimbo" },
		{ "<haiku>", "Misprint" },
		{ "<sonnet>", "Abstract" },
		{ "<pinion>", "Juggler" },
		{ "<forbic>", "Stuntman" },
		{ "<echo>", "Crafty Joker" },
		{ "<slate>", "Mad Joker" },
		{ "<splunk>", "Blueprint" }
	};

	private static string[] crossoverKeys = new string[35]
	{
		"_RUSTY", "_HAIKU", "_ECHOS_HOUSE", "_ECHOS_HOUSE_DESC", "_SONNET_SHOP", "_SONNET_SHOP_DESC", "_HAIKUS_HOUSE", "_HAIKUS_HOUSE_DESC", "_SPLUNKS_HOUSE", "_SPLUNKS_HOUSE_DESC",
		"_SLATES_HOUSE", "_SLATES_HOUSE_DESC", "_FORBICS_HOUSE", "_FORBICS_HOUSE_DESC", "_PINION_HOUSE", "_PINION_HOUSE_DESC", "_REAPER_SHOP", "_REAPER_SHOP_DESC", "_BUILD_ECHO_TO_UNLOCK", "_BUILD_SONNET_TO_UNLOCK",
		"_BUILD_HAIKU_TO_UNLOCK", "_BUILD_SLATE_TO_UNLOCK", "_BUILD_FORBIC_TO_UNLOCK", "_BUILD_PINION_TO_UNLOCK", "_ENABLE_SPLUNK", "_DISABLE_SPLUNK", "_SPLUNKS_SIGNS", "_DONT_SEED_DESC", "_Q_ECHO", "_A_ECHO",
		"_Q_SLATE", "_A_SLATE", "_Q_SPLUNK", "_A_SPLUNK", "_A_BULBHIVES"
	};

	public static void SetLanguage(Language newLanguage)
	{
		language = newLanguage;
	}

	public static void Init()
	{
		CSVLoader cSVLoader = new CSVLoader();
		cSVLoader.LoadCSV();
		localizedEN = cSVLoader.GetDictionaryValues("EN");
		localizedFR = cSVLoader.GetDictionaryValues("FR");
		localizedIT = cSVLoader.GetDictionaryValues("IT");
		localizedDE = cSVLoader.GetDictionaryValues("DE");
		localizedES = cSVLoader.GetDictionaryValues("ES");
		localizedJA = cSVLoader.GetDictionaryValues("JA");
		localizedKO = cSVLoader.GetDictionaryValues("KO");
		localizedSCH = cSVLoader.GetDictionaryValues("SCH");
		localizedTCH = cSVLoader.GetDictionaryValues("TCH");
		localizedPTBR = cSVLoader.GetDictionaryValues("PTBR");
		localizedEE = cSVLoader.GetDictionaryValues("EE");
		isInit = true;
	}

	public static string GetLocalizedValue(string key)
	{
		if (!isInit)
		{
			Init();
		}
		string value = key;
		bool flag = false;
		if ((bool)SaveData.ins)
		{
			flag = SaveData.ins.checkIfCrossover(out var _);
		}
		if (flag)
		{
			key = ReplaceKeysForCrossoverContent(key);
		}
		switch (language)
		{
		case Language.EN:
			localizedEN.TryGetValue(key, out value);
			break;
		case Language.FR:
			localizedFR.TryGetValue(key, out value);
			break;
		case Language.IT:
			localizedIT.TryGetValue(key, out value);
			break;
		case Language.DE:
			localizedDE.TryGetValue(key, out value);
			break;
		case Language.ES:
			localizedES.TryGetValue(key, out value);
			break;
		case Language.JA:
			localizedJA.TryGetValue(key, out value);
			break;
		case Language.KO:
			localizedKO.TryGetValue(key, out value);
			break;
		case Language.SCH:
			localizedSCH.TryGetValue(key, out value);
			break;
		case Language.TCH:
			localizedTCH.TryGetValue(key, out value);
			break;
		case Language.PTBR:
			localizedPTBR.TryGetValue(key, out value);
			break;
		case Language.EE:
			localizedEE.TryGetValue(key, out value);
			break;
		}
		if (flag)
		{
			value = ReplacePlaceholdersForCrossoverContent(value);
		}
		return value;
	}

	private static string ReplaceKeysForCrossoverContent(string key)
	{
		if (crossoverKeys.Contains(key))
		{
			return key + "_XO";
		}
		return key;
	}

	private static string ReplacePlaceholdersForCrossoverContent(string source)
	{
		if (!SaveData.ins.checkIfCrossover(out var crossover) || source == "" || source == null)
		{
			return source;
		}
		Dictionary<string, string> dictionary = vampireSurvivors;
		switch (crossover)
		{
		case CrossoverFarmType.VampireSurvivors:
			dictionary = vampireSurvivors;
			break;
		case CrossoverFarmType.Balatro:
			dictionary = balatro;
			break;
		}
		foreach (KeyValuePair<string, string> item in dictionary)
		{
			source = source.Replace(item.Key, item.Value);
		}
		return source;
	}
}
