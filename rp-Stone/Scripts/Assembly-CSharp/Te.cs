using System;
using System.Collections.Generic;
using UnityEngine;

public class Te
{
	public static string id;

	public static string displayName;

	public static int totalWords = 0;

	private static Dictionary<int, string> englishToTids = new Dictionary<int, string>();

	private static Dictionary<string, string> englishFallback = new Dictionary<string, string>();

	private static Dictionary<string, string> tidTable = new Dictionary<string, string>();

	private static Dictionary<string, string> translatedToTids = new Dictionary<string, string>();

	private static HashSet<string> femaleTexts = new HashSet<string>();

	private static int[] charBuffer = new int[1024];

	public static event Action<string, string> OnLanguageChanged;

	public static void InitEnglish(Localization.File file)
	{
		Utils.LogIfEditor("Loading English " + file.sheet);
		string text = "";
		string[] texts = file.texts;
		for (int i = 0; i < texts.Length - 1; i++)
		{
			string text2 = texts[i];
			if (!text2.StartsWith("tid_"))
			{
				continue;
			}
			string text3 = file.texts[i + 1];
			text3 = text3.Replace("\\n", "\n");
			i++;
			int key = GetKey(text3);
			if (englishToTids.ContainsKey(key))
			{
				Utils.LogIfEditor("Loading English string '" + text3 + "' with " + text2 + ", but the table already has an identical entry with " + englishToTids[key]);
			}
			else
			{
				englishToTids.Add(key, text2);
				englishFallback.Add(text2, text3);
				if (Localization.COUNT_WORDS)
				{
					char c = ' ';
					for (int j = 0; j < text3.Length; j++)
					{
						if (c == ' ' && text3[j] != ' ')
						{
							totalWords++;
						}
						c = text3[j];
					}
				}
			}
			if (Localization.CREATE_GIBBERISH)
			{
				if (text.Length > 15000)
				{
					Utils.Log(text);
					text = "";
				}
				text = text + text2 + ", \"" + Mutate(text3) + "\",\n";
			}
		}
		if (Localization.CREATE_GIBBERISH)
		{
			Utils.Log(text);
		}
	}

	private static string Mutate(string str)
	{
		string text = "";
		for (int i = 0; i < str.Length; i++)
		{
			char c = str[i];
			if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
			{
				int num = UnityEngine.Random.Range(65, 117);
				if (num > 90)
				{
					num += 6;
				}
				text += (char)num;
			}
			else
			{
				text += c;
			}
		}
		return text;
	}

	public static void Clear()
	{
		tidTable.Clear();
		translatedToTids.Clear();
		femaleTexts.Clear();
	}

	public static void Load(Localization.File file)
	{
		Utils.LogIfEditor("Loading " + file.sheet + " in " + file.displayName);
		string arg = id;
		id = file.id;
		displayName = file.displayName;
		string[] texts = file.texts;
		for (int i = 0; i + 1 < texts.Length; i += 2)
		{
			string text = texts[i];
			string text2 = texts[i + 1];
			if (text.StartsWith("//"))
			{
				continue;
			}
			if (!text.StartsWith("tid_"))
			{
				Utils.LogError("There may be something wrong with " + text + ": " + text2);
			}
			else if (tidTable.ContainsKey(text))
			{
				Utils.LogError("Duplicate tid " + text + " in localization file " + displayName + " " + id);
			}
			else
			{
				if (!(text2 != "#"))
				{
					continue;
				}
				if (text2.StartsWith("(F)"))
				{
					text2 = text2.Substring(3);
					if (!femaleTexts.Contains(text2))
					{
						femaleTexts.Add(text2);
					}
				}
				text2 = text2.Replace("\\n", "\n");
				tidTable.Add(text, text2);
				if (!translatedToTids.ContainsKey(text2))
				{
					translatedToTids.Add(text2, text);
				}
			}
		}
		if (Te.OnLanguageChanged != null)
		{
			Te.OnLanguageChanged(arg, id);
		}
	}

	public static string xt(string inStr)
	{
		if (string.IsNullOrEmpty(inStr))
		{
			return inStr;
		}
		if (inStr.StartsWith("tid_"))
		{
			if (tidTable.ContainsKey(inStr))
			{
				return tidTable[inStr];
			}
			if (englishFallback.ContainsKey(inStr))
			{
				Utils.LogErrorIfEditor("Using English fallback for key " + inStr);
				return englishFallback[inStr];
			}
			Utils.LogErrorIfEditor("Localization key " + inStr + " not found.");
		}
		int key = GetKey(inStr);
		if (englishToTids.ContainsKey(key))
		{
			string text = englishToTids[key];
			if (tidTable.ContainsKey(text))
			{
				return tidTable[text];
			}
			Utils.LogError("Found " + text + ", but there's no corresponding localized text.");
		}
		Utils.LogErrorIfEditor("Using non-localized text: " + inStr);
		return inStr;
	}

	public static bool IsFemale(string inStr)
	{
		return femaleTexts.Contains(inStr);
	}

	public static string GetTID(string str)
	{
		if (translatedToTids.ContainsKey(str))
		{
			return translatedToTids[str];
		}
		return str;
	}

	public static string ToEnglish(string str)
	{
		if (translatedToTids.ContainsKey(str))
		{
			string key = translatedToTids[str];
			if (englishFallback.ContainsKey(key))
			{
				return englishFallback[key];
			}
		}
		return str;
	}

	private static int GetKey(string str)
	{
		int num = 0;
		for (int i = 0; i < str.Length; i++)
		{
			if (num >= charBuffer.Length)
			{
				break;
			}
			int num2 = str[i];
			if (num2 == 92 && i + 1 < str.Length && str[i + 1] == 'n')
			{
				i++;
				charBuffer[num] = 10;
			}
			else
			{
				charBuffer[num] = num2;
			}
			num++;
		}
		int num3 = 352654597;
		int num4 = num3;
		for (int j = 0; j < num; j += 2)
		{
			int num5 = charBuffer[j];
			num3 = ((num3 << 5) + num3) ^ num5;
			if (j == num - 1)
			{
				break;
			}
			int num6 = charBuffer[j + 1];
			num4 = ((num4 << 5) + num4) ^ num6;
		}
		return num3 + num4 * 1566083941;
	}
}
