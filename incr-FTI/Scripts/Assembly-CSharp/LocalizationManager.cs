using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class LocalizationManager
{
	private static LocalizationManager instance;

	private Dictionary<string, string> localizedStrings;

	private Dictionary<string, string> englishStrings;

	public readonly Dictionary<EntityId, string> defaultHotkeys;

	private bool isReady;

	public CultureInfo cultureInfo;

	public UserLanguage currentLanguage;

	public static LocalizationManager Instance => instance;

	public LocalizationManager()
	{
		localizedStrings = new Dictionary<string, string>(1000);
		englishStrings = new Dictionary<string, string>(1000);
		defaultHotkeys = new Dictionary<EntityId, string>(100);
	}

	public static void Init()
	{
		instance = new LocalizationManager();
	}

	public static UserLanguage LanguageForCode(string code)
	{
		foreach (UserLanguage value in Enum.GetValues(typeof(UserLanguage)))
		{
			if (value != UserLanguage.None && code == LanguageCode(value))
			{
				return value;
			}
		}
		return UserLanguage.None;
	}

	public static bool IsEnglish()
	{
		return instance.currentLanguage == UserLanguage.DefaultEnglish;
	}

	public static bool IsCurrentLanguageSpaced()
	{
		if (instance.currentLanguage != UserLanguage.SimplifiedChinese)
		{
			return instance.currentLanguage != UserLanguage.TraditionalChinese;
		}
		return false;
	}

	public static string HeaderKeyForUserLanguage(UserLanguage userLanguage)
	{
		return userLanguage switch
		{
			UserLanguage.SimplifiedChinese => "zhCN", 
			UserLanguage.TraditionalChinese => "zhTW", 
			_ => LanguageCode(userLanguage), 
		};
	}

	public static string LanguageCode(UserLanguage language)
	{
		return language switch
		{
			UserLanguage.DefaultEnglish => "en", 
			UserLanguage.French => "fr", 
			UserLanguage.Turkish => "tr", 
			UserLanguage.German => "de", 
			UserLanguage.Italian => "it", 
			UserLanguage.Spanish => "es", 
			UserLanguage.Russian => "ru", 
			UserLanguage.Japanese => "ja", 
			UserLanguage.Polish => "pl", 
			UserLanguage.PortugueseBrazilian => "pt-br", 
			UserLanguage.PortugueseEuropean => "pt", 
			UserLanguage.SimplifiedChinese => "zh-CN", 
			UserLanguage.TraditionalChinese => "zh-TW", 
			UserLanguage.Swedish => "sv", 
			UserLanguage.Dutch => "nl", 
			UserLanguage.Czech => "cz", 
			UserLanguage.Ukrainian => "uk", 
			_ => "None", 
		};
	}

	public void ReadLocalizationFile(string filePath)
	{
		UnityEngine.Debug.Log("Read localization file " + filePath);
		LoadJsonItemsIntoDictionary(File.ReadAllText(filePath));
	}

	public void ReadMasterLocalizationFile(UserLanguage userLanguage)
	{
		string[] array = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "FTIdle Localization - localizedStrings.tsv"));
		if (array.Length == 0)
		{
			return;
		}
		string obj = array[0];
		char separator = '\t';
		string[] array2 = obj.Split(separator);
		string text = HeaderKeyForUserLanguage(userLanguage);
		int num = -1;
		for (int i = 0; i < array2.Length; i++)
		{
			if (array2[i] == text)
			{
				num = i;
				break;
			}
		}
		for (int j = 1; j < array.Length; j++)
		{
			string text2 = array[j];
			string[] array3 = text2.Split(separator);
			string key = array3[0];
			if (num >= 0)
			{
				string text3 = array3[num];
				if (text3.Length > 0)
				{
					localizedStrings[key] = text3;
				}
			}
			else
			{
				localizedStrings[key] = text2;
			}
		}
		isReady = true;
	}

	private static string StringOfCharSet(HashSet<char> charSet)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char item in charSet)
		{
			stringBuilder.Append(item);
		}
		return stringBuilder.ToString();
	}

	private static void CompareCharacterSets()
	{
		HashSet<char> hashSet = new HashSet<char>();
		string text = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Old Kanji.txt"));
		HashSet<char> hashSet2 = new HashSet<char>();
		string text2 = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "New Kanji.txt"));
		HashSet<char> hashSet3 = new HashSet<char>();
		HashSet<char> hashSet4 = new HashSet<char>();
		char[] array = text.ToCharArray();
		foreach (char item in array)
		{
			if (hashSet.Contains(item))
			{
				hashSet3.Add(item);
			}
			else
			{
				hashSet.Add(item);
			}
		}
		array = text2.ToCharArray();
		foreach (char item2 in array)
		{
			if (hashSet2.Contains(item2))
			{
				hashSet4.Add(item2);
			}
			else
			{
				hashSet2.Add(item2);
			}
		}
		HashSet<char> hashSet5 = new HashSet<char>();
		HashSet<char> hashSet6 = new HashSet<char>();
		HashSet<char> hashSet7 = new HashSet<char>();
		foreach (char item3 in hashSet)
		{
			if (hashSet2.Contains(item3))
			{
				hashSet7.Add(item3);
			}
			else
			{
				hashSet5.Add(item3);
			}
		}
		foreach (char item4 in hashSet2)
		{
			if (!hashSet.Contains(item4))
			{
				hashSet6.Add(item4);
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char item5 in hashSet5)
		{
			stringBuilder.Append(item5);
		}
		stringBuilder.Clear();
		foreach (char item6 in hashSet6)
		{
			stringBuilder.Append(item6);
		}
		stringBuilder.Clear();
		foreach (char item7 in hashSet7)
		{
			stringBuilder.Append(item7);
		}
	}

	private static void CheckForDuplicates()
	{
		HashSet<char> hashSet = new HashSet<char>();
		string text = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Test Codes.txt"));
		int num = 0;
		char[] array = text.ToCharArray();
		foreach (char item in array)
		{
			if (hashSet.Contains(item))
			{
				num++;
			}
			else
			{
				hashSet.Add(item);
			}
		}
	}

	[Conditional("UNITY_EDITOR")]
	private static void DebugPrintCharacterCodes()
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		HashSet<char> hashSet = new HashSet<char>();
		for (int i = 32; i <= 126; i++)
		{
			hashSet.Add((char)i);
		}
		for (int j = 192; j <= 383; j++)
		{
			hashSet.Add((char)j);
		}
		hashSet.Add('č');
		hashSet.Add('œ');
		hashSet.Add('š');
		if (Instance.currentLanguage == UserLanguage.SimplifiedChinese || Instance.currentLanguage == UserLanguage.TraditionalChinese)
		{
			char[] array = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Chinese Character Codes.txt")).ToCharArray();
			foreach (char item in array)
			{
				hashSet.Add(item);
			}
		}
		stringBuilder.Clear();
		stringBuilder2.Clear();
		foreach (char item2 in hashSet)
		{
			stringBuilder.Append(item2);
		}
		if (false)
		{
			foreach (string value in Instance.localizedStrings.Values)
			{
				char[] array = value.ToCharArray();
				foreach (char c in array)
				{
					if (!hashSet.Contains(c))
					{
						stringBuilder.Append(c);
						hashSet.Add(c);
						stringBuilder2.Append(c);
					}
				}
			}
		}
		UnityEngine.Debug.Log("Characters " + Instance.currentLanguage.ToString() + ":");
		UnityEngine.Debug.Log(stringBuilder);
		UnityEngine.Debug.Log("Additional: " + stringBuilder2);
		UnityEngine.Debug.Log("Character count " + hashSet.Count);
	}

	private static void AppendCharactersFromLanguage(UserLanguage lang, LocalizationMasterRows loadedData, HashSet<char> defaultCharSet)
	{
		LocalizationMasterRow[] items = loadedData.items;
		for (int i = 0; i < items.Length; i++)
		{
			char[] array = items[i].GetValue(lang).ToCharArray();
			foreach (char item in array)
			{
				defaultCharSet.Add(item);
			}
		}
	}

	private void LoadJsonItemsIntoDictionary(string dataAsJson)
	{
		dataAsJson = "{\"items\":" + dataAsJson + "}";
		LocalizationItem[] items = JsonUtility.FromJson<LocalizationItems>(dataAsJson).items;
		foreach (LocalizationItem localizationItem in items)
		{
			try
			{
				localizedStrings[localizationItem.Key] = localizationItem.Value;
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogWarning("Unable to add item: " + localizationItem.Key + ":" + ex.ToString());
			}
		}
		isReady = true;
	}

	public void LoadUniversalStrings()
	{
		string text = Path.Combine(Application.streamingAssetsPath, "universalStrings.json");
		if (File.Exists(text))
		{
			ReadLocalizationFile(text);
		}
	}

	public void LoadPreferredLanguage()
	{
		string text = Preferences.ValueForKey("PrefInterfaceKeyLanguage");
		UserLanguage userLanguage = LanguageForCode(text);
		UnityEngine.Debug.Log("LoadPreferredLanguage Read master localization file from pref:" + text + " userLanguage:" + userLanguage);
		currentLanguage = userLanguage;
		ReadMasterLocalizationFile(userLanguage);
		cultureInfo = CultureFromLanguage(userLanguage);
		List<TMP_FontAsset> fallbackFontAssetTable = TMP_Settings.defaultFontAsset.fallbackFontAssetTable;
		fallbackFontAssetTable.Clear();
		if (userLanguage == UserLanguage.SimplifiedChinese || userLanguage == UserLanguage.TraditionalChinese)
		{
			UnityEngine.Debug.Log("LoadPreferredLanguage set priority: Chinese Font");
			fallbackFontAssetTable.Add(PrefabManager.Instance.chineseFont);
			fallbackFontAssetTable.Add(PrefabManager.Instance.japaneseFont);
		}
		else
		{
			UnityEngine.Debug.Log("LoadPreferredLanguage set priority: Japanese Font");
			fallbackFontAssetTable.Add(PrefabManager.Instance.japaneseFont);
			fallbackFontAssetTable.Add(PrefabManager.Instance.chineseFont);
		}
	}

	public static int LocalizedIndexOf(string stringToSearch, string stringToFind)
	{
		CultureInfo cultureInfo = instance.cultureInfo;
		int num = cultureInfo.CompareInfo.IndexOf(stringToSearch, stringToFind, CompareOptions.IgnoreCase);
		if (num >= 0)
		{
			return num;
		}
		bool flag = false;
		if (stringToFind.Contains(' '))
		{
			string[] array = stringToFind.Trim().Split(' ');
			foreach (string value in array)
			{
				if (cultureInfo.CompareInfo.IndexOf(stringToSearch, value, CompareOptions.IgnoreCase) < 0)
				{
					return -1;
				}
				flag = true;
			}
		}
		if (flag)
		{
			return 1;
		}
		return -1;
	}

	public static bool Contains(string stringToSearch, string stringToFind)
	{
		return LocalizedIndexOf(stringToSearch, stringToFind) >= 0;
	}

	public void LoadCurrentLanguage()
	{
		UnityEngine.Debug.Log("Loading localization dictionary");
		defaultHotkeys.Clear();
		localizedStrings.Clear();
		LoadUniversalStrings();
		LoadPreferredLanguage();
	}

	public static CultureInfo CultureFromLanguage(UserLanguage lang)
	{
		return lang switch
		{
			UserLanguage.DefaultEnglish => new CultureInfo("en-US"), 
			UserLanguage.French => new CultureInfo("fr-FR"), 
			UserLanguage.Turkish => new CultureInfo("tr-TR"), 
			UserLanguage.Italian => new CultureInfo("it-IT"), 
			UserLanguage.German => new CultureInfo("de-DE"), 
			UserLanguage.Spanish => new CultureInfo("es-ES"), 
			UserLanguage.SimplifiedChinese => new CultureInfo("zh-CN"), 
			UserLanguage.Russian => new CultureInfo("ru-RU"), 
			UserLanguage.Polish => new CultureInfo("pl-PL"), 
			UserLanguage.PortugueseBrazilian => new CultureInfo("pt-BR"), 
			UserLanguage.PortugueseEuropean => new CultureInfo("pt-PT"), 
			UserLanguage.Swedish => new CultureInfo("sv-SE"), 
			UserLanguage.Dutch => new CultureInfo("nl-NL"), 
			UserLanguage.TraditionalChinese => new CultureInfo("zh-TW"), 
			UserLanguage.Japanese => new CultureInfo("ja-JP"), 
			UserLanguage.Czech => new CultureInfo("cs-CZ"), 
			UserLanguage.Ukrainian => new CultureInfo("uk-UA"), 
			_ => new CultureInfo("en-US"), 
		};
	}

	public static bool TryParseIntLocalized(string s, out int result)
	{
		if (int.TryParse(s, NumberStyles.Any, Instance.cultureInfo, out var result2))
		{
			result = result2;
			return true;
		}
		result = 0;
		return false;
	}

	public static List<string> KeysStartingWith(string startText)
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, string> localizedString in instance.localizedStrings)
		{
			if (localizedString.Key.StartsWith(startText))
			{
				list.Add(localizedString.Key);
			}
		}
		return list;
	}

	public static bool HasLocalizedValueForKey(string key)
	{
		return instance.localizedStrings.ContainsKey(key);
	}

	public static string EnglishValueForKey(string key)
	{
		if (instance.englishStrings.TryGetValue(key, out var value))
		{
			return value;
		}
		return null;
	}

	public static string LocalizedValueForKey(string key)
	{
		if (instance == null)
		{
			return key;
		}
		if (instance.localizedStrings.TryGetValue(key, out var value))
		{
			return value;
		}
		return null;
	}

	public static bool GetIsReady()
	{
		if (instance == null)
		{
			return false;
		}
		return instance.isReady;
	}
}
