using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Lang
{
	public class Language
	{
		public readonly string langId;

		public readonly string name;

		public readonly bool present;

		public readonly SystemLanguage systemLanguage;

		public readonly bool isAsian;

		public readonly bool isRTL;

		public Language(string langId_, string name_, SystemLanguage systemLanguage_)
		{
			langId = langId_;
			name = name_;
			systemLanguage = systemLanguage_;
			string path = Path.Combine(Application.streamingAssetsPath, "lang-" + langId);
			present = File.Exists(path);
			isAsian = langId == "ja" || langId.StartsWith("zh");
			isRTL = GetIsRTL(langId);
		}

		public static bool GetIsRTL(string langId)
		{
			return langId == "ar";
		}
	}

	private static int generation_ = 0;

	private static bool isNull;

	private static LangPack langPack;

	private static Dictionary<string, string> stringsDict;

	private static Dictionary<string, Sprite> spritesDict;

	public static List<string> accessed;

	private static string identifierChars = "abcdefghijklmnopqrstuvwxyz0123456789_.?";

	private static Language[] languages = new Language[15]
	{
		new Language("en", "English", SystemLanguage.English),
		new Language("fr", "Français", SystemLanguage.French),
		new Language("de", "Deutsch", SystemLanguage.German),
		new Language("es", "Español", SystemLanguage.Spanish),
		new Language("pt", "Português", SystemLanguage.Portuguese),
		new Language("it", "Italiano", SystemLanguage.Italian),
		new Language("ru", "Русский", SystemLanguage.Russian),
		new Language("pl", "Polski", SystemLanguage.Polish),
		new Language("ja", "日本語", SystemLanguage.Japanese),
		new Language("zh-s", "简体中文", SystemLanguage.ChineseSimplified),
		new Language("zh-t", "繁體中文", SystemLanguage.ChineseTraditional),
		new Language("ko", "한국어", SystemLanguage.Korean),
		new Language("uk", "Українська", SystemLanguage.Ukrainian),
		new Language("ar", "ﺍﻟﻌﺮﺑﻴﺔ", SystemLanguage.Arabic),
		new Language("null", "Null", SystemLanguage.Unknown)
	};

	public static int generation
	{
		get
		{
			return generation_;
		}
	}

	public static bool isLoaded
	{
		get
		{
			return isNull || stringsDict != null;
		}
	}

	public static Language loadedLanguage
	{
		get
		{
			string text = (isNull ? "null" : ((!(langPack != null)) ? null : langPack.code));
			Language[] array = languages;
			foreach (Language language in array)
			{
				if (language.langId == text)
				{
					return language;
				}
			}
			return languages[0];
		}
	}

	public static void Load(string langId)
	{
		Debug.Log("[Lang] " + langId);
		if (stringsDict != null)
		{
			stringsDict = null;
		}
		if (spritesDict != null)
		{
			spritesDict = null;
		}
		if (langId == "null")
		{
			Load("en");
			isNull = true;
			return;
		}
		string text = Path.Combine(Application.streamingAssetsPath, "lang-" + langId);
		AssetBundle assetBundle = AssetBundle.LoadFromFile(text);
		if (assetBundle == null)
		{
			throw new UnityException("Failed to load language asset: " + text);
		}
		langPack = assetBundle.LoadAsset<LangPack>("Assets/Localization/Languages/" + langId + "/LangPack.asset");
		if (langPack == null)
		{
			throw new UnityException("Asset does not contain LangPack: " + text);
		}
		if (langPack.code != langId || langPack.strings.Count == 0 || !langPack.buildDate.HasValue())
		{
			throw new UnityException("Asset contains invalid LangPack: " + text);
		}
		stringsDict = new Dictionary<string, string>();
		foreach (LangPack.StringEntry @string in langPack.strings)
		{
			string val = @string.val;
			stringsDict.Add(@string.key, val);
		}
		spritesDict = new Dictionary<string, Sprite>();
		foreach (LangPack.SpriteEntry sprite in langPack.sprites)
		{
			spritesDict.Add(sprite.key, sprite.val);
		}
		Debug.LogFormat("[Lang] {0} strings, {1} sprites", stringsDict.Count, spritesDict.Count);
		assetBundle.Unload(false);
		generation_++;
		isNull = false;
	}

	public static string Get(string id, string key0 = null, object val0 = null, string key1 = null, object val1 = null, string key2 = null, object val2 = null, string key3 = null, object val3 = null, string key4 = null, object val4 = null, string key5 = null, object val5 = null, string key6 = null, object val6 = null)
	{
		if (isNull)
		{
			string text = id;
			if (key0 != null && val0 != null)
			{
				text += string.Format(" ({0}={1})", key0, val0);
			}
			if (key1 != null && val1 != null)
			{
				text += string.Format(" ({0}={1})", key1, val1);
			}
			if (key2 != null && val2 != null)
			{
				text += string.Format(" ({0}={1})", key2, val2);
			}
			if (key3 != null && val3 != null)
			{
				text += string.Format(" ({0}={1})", key3, val3);
			}
			if (key4 != null && val4 != null)
			{
				text += string.Format(" ({0}={1})", key4, val4);
			}
			if (key5 != null && val5 != null)
			{
				text += string.Format(" ({0}={1})", key5, val5);
			}
			if (key6 != null && val6 != null)
			{
				text += string.Format(" ({0}={1})", key6, val6);
			}
			return text;
		}
		if (!isLoaded)
		{
			LoadSystemLanguage();
		}
		string value;
		if (!stringsDict.TryGetValue(id, out value))
		{
			return id;
		}
		value = TranslateActionNames(value);
		if (key0 != null && val0 != null)
		{
			value = value.Replace(key0, val0.ToString());
		}
		if (key1 != null && val1 != null)
		{
			value = value.Replace(key1, val1.ToString());
		}
		if (key2 != null && val2 != null)
		{
			value = value.Replace(key2, val2.ToString());
		}
		if (key3 != null && val3 != null)
		{
			value = value.Replace(key3, val3.ToString());
		}
		if (key4 != null && val4 != null)
		{
			value = value.Replace(key4, val4.ToString());
		}
		if (key5 != null && val5 != null)
		{
			value = value.Replace(key5, val5.ToString());
		}
		if (key6 != null && val6 != null)
		{
			value = value.Replace(key6, val6.ToString());
		}
		return value;
	}

	public static string GetCounted(int count, string idZero, string idOne, string idMany)
	{
		if (count <= 0)
		{
			return Get(idZero);
		}
		if (count == 1)
		{
			return Get(idOne, "$0", count.ToString());
		}
		return Get(idMany, "$0", count.ToString());
	}

	public static string GetGendered(string id, Manifest.Gender gender)
	{
		string text = Get(id);
		if (text.Contains("<>"))
		{
			text = Manifest.ApplyGender(text, gender, gender);
		}
		return text;
	}

	public static string GetGenderedForPlayer(string id)
	{
		string text = Get(id);
		if (text.Contains("<>"))
		{
			Manifest.Gender playerGender = SaveData.it.generalRo.playerGender;
			text = Manifest.ApplyGender(text, playerGender, playerGender);
		}
		return text;
	}

	public static string TranslateActionNames(string originalText)
	{
		if (isNull)
		{
			return originalText;
		}
		string text = originalText;
		if (RInput.actionInfos != null)
		{
			foreach (RInput.ActionInfo actionInfo in RInput.actionInfos)
			{
				text = text.Replace(actionInfo.textCode, "[" + RInput.GetActionName(actionInfo.id) + "]");
			}
		}
		return text;
	}

	public static string ExpandReferences(string encoded)
	{
		for (int i = 0; i < 3; i++)
		{
			if (!encoded.Contains("#"))
			{
				break;
			}
			encoded = ExpandReferencesInternal(encoded);
		}
		return encoded;
	}

	private static string ExpandReferencesInternal(string encoded)
	{
		if (encoded.StartsWith("##"))
		{
			string text = string.Empty;
			string text2 = string.Empty;
			bool flag = false;
			for (int i = 2; i < encoded.Length; i++)
			{
				string text3 = encoded.Substring(i, 1);
				if (text3 == "#")
				{
					if (text2.HasValue())
					{
						text += Get(text2);
					}
					flag = true;
					text2 = string.Empty;
				}
				else if (flag)
				{
					if (text3 == "#")
					{
						if (text2.HasValue())
						{
							text += Get(text2);
						}
						flag = true;
						text2 = string.Empty;
					}
					else if (identifierChars.Contains(text3))
					{
						text2 += text3;
					}
					else if (text2.HasValue())
					{
						text += Get(text2);
						text += text3;
						flag = false;
						text2 = string.Empty;
					}
				}
				else
				{
					text += text3;
				}
			}
			if (text2.HasValue())
			{
				text += Get(text2);
			}
			return text;
		}
		if (encoded.StartsWith("#"))
		{
			return Get(encoded.Substring(1));
		}
		return encoded;
	}

	public static IEnumerable<string> IterateIds(string prefix)
	{
		if (!isLoaded)
		{
			LoadSystemLanguage();
		}
		foreach (LangPack.StringEntry entry in langPack.strings)
		{
			if (entry.key.StartsWith(prefix))
			{
				yield return entry.key;
			}
		}
	}

	public static Sprite GetSprite(string id)
	{
		if (!isLoaded)
		{
			LoadSystemLanguage();
		}
		Sprite value = null;
		spritesDict.TryGetValue(id, out value);
		return value;
	}

	private static void LoadSystemLanguage()
	{
		Load(GetSystemLanguage().langId);
	}

	public static IEnumerable<Language> IterateAvailableLanguages()
	{
		Language[] array = languages;
		foreach (Language language in array)
		{
			if (language.present)
			{
				yield return language;
			}
		}
	}

	private static Language GetSystemLanguage()
	{
		Language[] array = languages;
		foreach (Language language in array)
		{
			if (language.present && language.systemLanguage == Application.systemLanguage)
			{
				return language;
			}
		}
		return languages[0];
	}
}
