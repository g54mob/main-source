using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MLCN_Localization
{
	public class LocalizationManager : MonoBehaviour
	{
		public enum Language
		{
			ENGLISH = 0,
			GERMAN = 1
		}

		public LocalizationOption[] languageOptions = new LocalizationOption[2]
		{
			new LocalizationOption(Language.ENGLISH),
			new LocalizationOption(Language.GERMAN)
		};

		[SerializeField]
		private Language language;

		[SerializeField]
		private LocalizationDataTable localizationDataTable;

		private List<LocaleTableData> globalTable;

		private Dictionary<LocalizationDataTable.Tables, List<LocaleTableData>> loadedTables = new Dictionary<LocalizationDataTable.Tables, List<LocaleTableData>>();

		public static UnityEvent<int> OnLanguageChange = new UnityEvent<int>();

		public static UnityEvent<int> OnInitComplete = new UnityEvent<int>();

		private static LocalizationManager instance;

		public void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Object.Destroy(this);
			}
			Object.DontDestroyOnLoad(instance);
			loadedTables = localizationDataTable.GetAllTables();
			globalTable = localizationDataTable.GlobalTable();
			if (GameSettings.IsValid())
			{
				language = (Language)GameSettings.GetActiveConfig().generalSettings.language;
			}
			else
			{
				language = Language.ENGLISH;
			}
			OnInitComplete.Invoke((int)language);
		}

		public static bool IsValidated()
		{
			return instance != null;
		}

		public static LocalizationManager GetInstance()
		{
			return instance;
		}

		[ContextMenu("Set English")]
		private void DebugLoadLanguageEnglish()
		{
			language = Language.ENGLISH;
			ChangeLanguage(language);
		}

		[ContextMenu("Set German")]
		private void DebugLoadLanguageGerman()
		{
			language = Language.GERMAN;
			ChangeLanguage(language);
		}

		public static void ChangeLanguage(Language targetLanguage)
		{
			instance.language = targetLanguage;
			OnLanguageChange.Invoke((int)instance.language);
		}

		public static Language GetCurrentLanguageType()
		{
			return instance.language;
		}

		public static int GetCurrentLanguage()
		{
			return (int)instance.language;
		}

		public static Language TryGetSystemLanguage()
		{
			Language language = Language.ENGLISH;
			return Application.systemLanguage switch
			{
				SystemLanguage.English => Language.ENGLISH, 
				SystemLanguage.German => Language.GERMAN, 
				_ => Language.ENGLISH, 
			};
		}

		public static LocalizationDataTable.Tables GetTableItemKeys()
		{
			return LocalizationDataTable.Tables.Items;
		}

		public static LocalizationDataTable.Tables GetTableComputerKeys()
		{
			return LocalizationDataTable.Tables.ComputerElements;
		}

		public static string GetLocalizedString(string entryKey, LocalizationDataTable.Tables tableKey, string fallback = "Locale Instance Null!")
		{
			if (!IsValidated())
			{
				return fallback;
			}
			instance.loadedTables.TryGetValue(tableKey, out var value);
			return instance.localizationDataTable.GetLocalizedString(entryKey, (int)instance.language, value);
		}

		public static string GetLocalizedString(string entryKey, LocalizationDataTable.Tables tableKey, int language, string fallback = "Locale Instance Null!")
		{
			if (!IsValidated())
			{
				return fallback;
			}
			instance.loadedTables.TryGetValue(tableKey, out var value);
			return instance.localizationDataTable.GetLocalizedString(entryKey, language, value);
		}

		public static List<string> GetLocalizedList(List<string> keyList, LocalizationDataTable.Tables tableKey)
		{
			if (!IsValidated())
			{
				return null;
			}
			List<string> list = new List<string>();
			for (int i = 0; i < keyList.Count; i++)
			{
				list.Add(GetLocalizedString(keyList[i], tableKey, (int)instance.language));
			}
			return list;
		}
	}
}
