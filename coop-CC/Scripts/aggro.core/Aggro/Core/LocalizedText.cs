using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aggro.Core
{
	[ExecuteAlways]
	public class LocalizedText : MonoBehaviour
	{
		public enum Language
		{
			English = 0,
			French = 1,
			German = 2,
			Italian = 3,
			SpanishLatam = 4,
			BRPortuguese = 5,
			Russian = 6,
			SimplifiedChinese = 7,
			Japanese = 8
		}

		public enum FontStyle
		{
			Normal = 0,
			Shadow = 1,
			Fuzzy = 2,
			Outline = 3,
			Custom = 4
		}

		private static Dictionary<string, List<string>> MAIN_TABLE;

		private static Dictionary<string, List<string>> TABLE_PC = new Dictionary<string, List<string>>();

		private static Dictionary<string, List<string>> TABLE_SW = new Dictionary<string, List<string>>();

		private static Dictionary<string, List<string>> TABLE_XB = new Dictionary<string, List<string>>();

		private static Dictionary<string, List<string>> TABLE_PS = new Dictionary<string, List<string>>();

		private static Dictionary<string, List<string>> DIALOGUE_TABLE;

		public static Action OnLangugageChanged;

		public const string MAIN_PATH = "Localization/Localized_Text";

		public const string FULL_PATH = "Assets/Resources/Localization/Localized_Text.csv";

		public const string UNLOCALIZED_PATH = "Localization/Unlocalized_Text";

		public const string FULL_PATH_UNLOCALIZED = "Assets/Resources/Localization/Unlocalized_Text.csv";

		public const string SERIALIZED_TERMS_PATH = "Localization/SerializedTermsData";

		public const string SERIALIZED_DIALOGUE_PATH = "Localization/SerializedDialogueData";

		public const string SERIALIZED_TERMS_PATH_FULL = "Assets/Resources/Localization/SerializedTermsData.txt";

		public const string SERIALIZED_DIALOGUE_PATH_FULL = "Assets/Resources/Localization/SerializedDialogueData.txt";

		public const int LANGUAGE_COUNT = 9;

		public static Language CURRENT_LANGUAGE = Language.English;

		public string index;

		public TMP_Text tmp;

		public bool autoSet = true;

		private int row;

		[SerializeField]
		private string currentText;

		public bool useDebugLanguage;

		public Language debugLanguage;

		public bool tripleIt;

		public Func<string, string> onRefreshText;

		private static int lineLength;

		public string addendum;

		public FontStyle fontStyle;

		public const char UNBREAKABLE_SPACE = '\u00a0';

		private static List<char> unbreakableSpaceRequiredChars = new List<char> { '?', '!', ':', ';', '"', '%' };

		public static Dictionary<string, List<string>> mainTable
		{
			get
			{
				if (MAIN_TABLE == null)
				{
					LoadMainTable();
				}
				return MAIN_TABLE;
			}
		}

		public static Dictionary<string, List<string>> dialogueTable
		{
			get
			{
				if (DIALOGUE_TABLE == null)
				{
					InitDialogueTable();
				}
				return DIALOGUE_TABLE;
			}
		}

		public static bool languageSupportsAllCaps
		{
			get
			{
				if (CURRENT_LANGUAGE == Language.Russian || CURRENT_LANGUAGE == Language.SimplifiedChinese || CURRENT_LANGUAGE == Language.Japanese)
				{
					return false;
				}
				return true;
			}
		}

		public static void TryInitTables()
		{
			if (MAIN_TABLE == null)
			{
				LoadMainTable();
			}
			if (DIALOGUE_TABLE == null)
			{
				InitDialogueTable();
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RuntimeInitialization()
		{
			MAIN_TABLE = null;
			DIALOGUE_TABLE = null;
			TABLE_PC.Clear();
			TABLE_SW.Clear();
			TABLE_XB.Clear();
			TABLE_PS.Clear();
			CURRENT_LANGUAGE = Language.English;
			OnLangugageChanged = null;
			LoadMainTable();
		}

		private void OnEnable()
		{
			if (string.IsNullOrEmpty(index))
			{
				index = row.ToString();
			}
			TryFindTextAsset();
			if (Application.isPlaying)
			{
				InitDisplayType();
			}
			RefreshText();
		}

		public void DebugReload()
		{
			LoadMainTable();
			OnEnable();
			RefreshAllText();
		}

		public static void ReloadAll()
		{
			LoadMainTable();
			RefreshAllText();
		}

		private void InitDisplayType()
		{
		}

		[ContextMenu("Debug Serialization")]
		private void DebugSerialization()
		{
			SerializeMainTable();
		}

		private static string SerializeMainTable()
		{
			string text = JsonConvert.SerializeObject(mainTable);
			File.WriteAllText("Assets/Resources/Localization/SerializedTermsData.txt", text);
			return text;
		}

		private static string SerializeDialogueTable()
		{
			string text = JsonConvert.SerializeObject(dialogueTable);
			File.WriteAllText("Assets/Resources/Localization/SerializedDialogueData.txt", text);
			return text;
		}

		public static void LoadMainTable(bool forceSerialization = true)
		{
			if (Application.isEditor && forceSerialization)
			{
				MAIN_TABLE = CSVReader.SplitCsvDict((Resources.Load("Localization/Localized_Text") as TextAsset).text);
				TextAsset textAsset = Resources.Load("Localization/Unlocalized_Text") as TextAsset;
				MAIN_TABLE = MAIN_TABLE.Concat(CSVReader.SplitCsvDict(textAsset.text)).ToDictionary((KeyValuePair<string, List<string>> x) => x.Key, (KeyValuePair<string, List<string>> x) => x.Value);
				SerializeMainTable();
			}
			else
			{
				MAIN_TABLE = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>((Resources.Load("Localization/SerializedTermsData") as TextAsset).text);
			}
			if (!Application.isPlaying)
			{
				using Dictionary<string, List<string>>.KeyCollection.Enumerator enumerator = MAIN_TABLE.Keys.GetEnumerator();
				if (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					lineLength = MAIN_TABLE[current].Count;
				}
			}
			InitPlatformSpecificTables();
		}

		public static void InitDialogueTable(bool forceSerialization = false)
		{
		}

		private static void InitPlatformSpecificTables()
		{
			TABLE_PC = new Dictionary<string, List<string>>();
			TABLE_XB = new Dictionary<string, List<string>>();
			TABLE_SW = new Dictionary<string, List<string>>();
			TABLE_PS = new Dictionary<string, List<string>>();
			List<string> list = new List<string>();
			foreach (string key in MAIN_TABLE.Keys)
			{
				if (TryInsertIntoTable(TABLE_PC, key, MAIN_TABLE[key], "_PC") || TryInsertIntoTable(TABLE_XB, key, MAIN_TABLE[key], "_XB") || TryInsertIntoTable(TABLE_SW, key, MAIN_TABLE[key], "_SW") || TryInsertIntoTable(TABLE_PS, key, MAIN_TABLE[key], "_PS"))
				{
					list.Add(key);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				MAIN_TABLE.Remove(list[i]);
			}
		}

		private static bool TryInsertIntoTable(Dictionary<string, List<string>> table, string i, List<string> contents, string refToRemove)
		{
			string text = i;
			if (text.EndsWith(refToRemove))
			{
				text = text.Substring(0, text.LastIndexOf(refToRemove, StringComparison.InvariantCulture));
				table.Add(text.ToUpperInvariant(), contents);
				return true;
			}
			return false;
		}

		private void TryFindTextAsset()
		{
			tmp = GetComponent<TMP_Text>();
		}

		public void RefreshText()
		{
			if (useDebugLanguage && !Application.isPlaying)
			{
				CURRENT_LANGUAGE = debugLanguage;
			}
			if (!tmp)
			{
				TryFindTextAsset();
			}
			if (autoSet)
			{
				currentText = GetText();
				currentText += addendum;
				if ((bool)tmp)
				{
					tmp.text = currentText;
					if (!Application.isPlaying && tripleIt)
					{
						tmp.text = tmp.text + tmp.text + tmp.text;
					}
				}
				if (onRefreshText != null)
				{
					tmp.text = onRefreshText(tmp.text);
				}
			}
			UpdateSpriteAsset();
		}

		private void UpdateSpriteAsset()
		{
		}

		private static string FailsafeParsing(string s)
		{
			s = s.Replace("\"\"", "\"");
			_ = CURRENT_LANGUAGE;
			_ = 1;
			return s;
		}

		private static string Frenchify(string s)
		{
			for (int i = 0; i < s.Length; i++)
			{
				if (!unbreakableSpaceRequiredChars.Contains(s[i]))
				{
					continue;
				}
				if (i == 0)
				{
					s = s.Insert(i, '\u00a0'.ToString());
					continue;
				}
				switch (s[i - 1])
				{
				case ' ':
					s = s.Remove(i - 1, 1).Insert(i - 1, '\u00a0'.ToString());
					break;
				default:
					s = s.Insert(i - 1, '\u00a0'.ToString());
					break;
				case '\u00a0':
					break;
				}
			}
			return s;
		}

		private static string ReplaceCustomValues(string s)
		{
			return s;
		}

		public string GetText()
		{
			string text = GetText(index);
			if (!string.IsNullOrEmpty(text))
			{
				return text;
			}
			return "";
		}

		public void SetText(string text)
		{
			if (!tmp)
			{
				TryFindTextAsset();
			}
			if ((bool)tmp)
			{
				tmp.text = text;
			}
			index = "";
		}

		public void SetTextLocalized(string id)
		{
			SetText(GetText(id));
		}

		public void SetIndex(string index)
		{
			if (!this.index.Equals(index))
			{
				this.index = index;
				RefreshText();
			}
		}

		private static string GetText(int intid)
		{
			return GetText(intid.ToString());
		}

		public static string GetText(string id, bool printDebug = true)
		{
			List<string> list = null;
			id = id.ToUpperInvariant();
			try
			{
				if (mainTable.TryGetValue(id, out var value))
				{
					list = value;
				}
				if (list != null)
				{
					string s = list[(int)CURRENT_LANGUAGE];
					s = FailsafeParsing(s);
					if (string.IsNullOrEmpty(s))
					{
						s = list[0];
						s = FailsafeParsing(s);
						s = ReplaceCustomValues(s);
					}
					return s;
				}
				if (printDebug)
				{
					return "LOC: " + id;
				}
				Debug.LogError("Failed to load text: " + id);
				return "";
			}
			catch (Exception ex)
			{
				Debug.LogError("Failed to load text: " + id + "\n" + ex);
				return "";
			}
		}

		public static string GetText(string id, Language language)
		{
			try
			{
				return mainTable[id.ToUpperInvariant()][(int)language];
			}
			catch (Exception)
			{
				return "";
			}
		}

		public static string GetText(string id, TextMeshProUGUI text)
		{
			if (text != null && text.GetComponent<LocalizedText>() == null)
			{
				text.gameObject.AddComponent<LocalizedText>().autoSet = false;
			}
			return GetText(id);
		}

		public static string GetText(string id, TextMeshPro text)
		{
			if (text != null && text.GetComponent<LocalizedText>() == null)
			{
				text.gameObject.AddComponent<LocalizedText>().autoSet = false;
			}
			return GetText(id);
		}

		public static string GetText(string id, Text text)
		{
			if (text != null && text.GetComponent<LocalizedText>() == null)
			{
				text.gameObject.AddComponent<LocalizedText>().autoSet = false;
			}
			return GetText(id);
		}

		public static Language GetSystemLanguage()
		{
			return Application.systemLanguage switch
			{
				SystemLanguage.English => Language.English, 
				SystemLanguage.French => Language.French, 
				SystemLanguage.Italian => Language.Italian, 
				SystemLanguage.German => Language.German, 
				SystemLanguage.Japanese => Language.Japanese, 
				SystemLanguage.Russian => Language.Russian, 
				SystemLanguage.ChineseSimplified => Language.SimplifiedChinese, 
				SystemLanguage.Spanish => Language.SpanishLatam, 
				SystemLanguage.Portuguese => Language.BRPortuguese, 
				_ => Language.English, 
			};
		}

		public static void SetLanguageToSystemLanguage()
		{
			CURRENT_LANGUAGE = GetSystemLanguage();
		}

		public static void SetLanguage(int languageInt)
		{
			if (languageInt == -1)
			{
				SetLanguageToSystemLanguage();
			}
			else
			{
				CURRENT_LANGUAGE = (Language)languageInt;
			}
			RefreshAllText();
		}

		public static void RefreshAllText()
		{
			LocalizedText[] array = UnityEngine.Object.FindObjectsByType<LocalizedText>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RefreshText();
			}
			OnLangugageChanged?.Invoke();
		}

		public static void AppendCSVLine(string line, string basicPath, string fullPath)
		{
		}

		public static string GetNameIndex(string displayName)
		{
			return "NAME_" + displayName;
		}

		public static string GetDescriptionIndex(string displayName)
		{
			return "DESC_" + displayName;
		}
	}
}
