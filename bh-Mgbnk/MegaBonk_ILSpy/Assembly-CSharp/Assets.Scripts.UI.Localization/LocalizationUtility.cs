using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

namespace Assets.Scripts.UI.Localization;

public class LocalizationUtility
{
	public static bool IsEnglish()
	{
		//IL_005d: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172514]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Locale selectedLocale = LocalizationSettings.SelectedLocale;
		if ((object)selectedLocale != null)
		{
			return (string)selectedLocale.m_Identifier == "en";
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static string GetLocalizedString(string table, string key, string defaultEnglishString, bool useEnglishDefaultIfAvailable = true)
	{
		//IL_0034: Expected O, but got I4
		//IL_004e: Expected O, but got I4
		//IL_00a2: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172514]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Locale selectedLocale = LocalizationSettings.SelectedLocale;
		if ((object)selectedLocale == null)
		{
			goto IL_012b;
		}
		bool flag = (string)selectedLocale.m_Identifier == "en";
		object obj = useEnglishDefaultIfAvailable & flag;
		bool flag2 = obj == null;
		object obj2 = !flag2;
		string text;
		if (obj2 == null)
		{
			LocalizedStringDatabase stringDatabase = LocalizationSettings.StringDatabase;
			TableReference tableReference = table;
			if (stringDatabase == null)
			{
				goto IL_012b;
			}
			object obj3 = default(object);
			DetailedLocalizationTable<StringTableEntry> table2 = stringDatabase.GetTable((TableReference)(&obj3));
			if ((object)table2 != null)
			{
				StringTableEntry entry = table2.GetEntry(key);
				if (entry != null)
				{
					text = entry.Value;
					if (text != null)
					{
						goto IL_0161;
					}
				}
			}
		}
		text = defaultEnglishString;
		goto IL_0161;
		IL_0161:
		return text;
		IL_012b:
		return (string)(object)new NullReferenceException();
	}

	public unsafe static string GetLocalizedString(string table, string key)
	{
		//IL_003d: Expected O, but got Ref
		LocalizedStringDatabase stringDatabase = LocalizationSettings.StringDatabase;
		TableReference tableReference = table;
		string text;
		if (stringDatabase != null)
		{
			object obj = default(object);
			DetailedLocalizationTable<StringTableEntry> table2 = stringDatabase.GetTable((TableReference)(&obj));
			if ((object)table2 != null)
			{
				StringTableEntry entry = table2.GetEntry(key);
				if (entry != null)
				{
					text = entry.Value;
					if (text != null)
					{
						goto IL_00d9;
					}
				}
			}
			text = "Missing localization for " + table + "." + key;
			goto IL_00d9;
		}
		return (string)(object)new NullReferenceException();
		IL_00d9:
		return text;
	}

	public unsafe static string GetLocalizedString(string table, string key, Dictionary<string, string> smartStrings)
	{
		//IL_002e: Expected I, but got O
		//IL_004c: Expected I, but got O
		//IL_005a: Expected O, but got Ref
		//IL_00cf: Expected O, but got I4
		//IL_00e3: Expected I, but got O
		//IL_0116: Expected I, but got O
		//IL_0126: Expected O, but got I
		//IL_013b: Expected O, but got I
		//IL_015c: Expected I, but got O
		LocalizedStringDatabase stringDatabase = LocalizationSettings.StringDatabase;
		TableReference tableReference = table;
		bool flag = stringDatabase == null;
		string text = table;
		nint num = unchecked((nint)null);
		object obj = default(object);
		nint num2 = (nint)(&obj);
		string text2;
		if (!flag)
		{
			nint num3 = (nint)stringDatabase;
			object obj2 = default(object);
			DetailedLocalizationTable<StringTableEntry> table2 = stringDatabase.GetTable((TableReference)(&obj2));
			if ((object)table2 != null)
			{
				StringTableEntry entry = table2.GetEntry(key);
				if (entry != null)
				{
					object[] array = new object[1];
					bool flag2 = array == null;
					text = (string)1;
					num = 0;
					num2 = (nint)typeof(object[]);
					if (flag2)
					{
						goto IL_01f9;
					}
					if (smartStrings != null)
					{
						nint num4 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rdx_v15 (Il2CppClass<System.Object[]>)+40]");
						text = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rdx_v15 (Il2CppClass<System.Object[]>)+40]");
						StringTableEntry entry2 = ((DetailedLocalizationTable<StringTableEntry>)(object)smartStrings).GetEntry((string)0);
						bool flag3 = entry2 == null;
						num = 0;
						num2 = (nint)smartStrings;
						if (flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
							object obj3 = default(object);
							throw obj3;
						}
					}
					if (array.Length <= 0)
					{
						return (string)(object)new IndexOutOfRangeException();
					}
					array[0] = smartStrings;
					text2 = entry.GetLocalizedString(array);
					if (text2 != null)
					{
						goto IL_01f4;
					}
				}
			}
			text2 = "Missing localization for " + table + "." + key;
			goto IL_01f4;
		}
		goto IL_01f9;
		IL_01f4:
		return text2;
		IL_01f9:
		throw new NullReferenceException();
	}

	public static string GetLocalizedDamageSource(string source)
	{
		WeaponData weaponData;
		if (!Enum.TryParse<EWeapon>(source, out var result))
		{
			if (!Enum.TryParse<EItem>(source, out var result2))
			{
				if (source != "Unkown")
				{
					return GetLocalizedString("DamageSources", source);
				}
				return "-";
			}
			if ((object)DataManager.Instance != null)
			{
				ItemData item = DataManager.Instance.GetItem(result2);
				weaponData = (WeaponData)(object)item;
				goto IL_00f7;
			}
		}
		else if ((object)DataManager.Instance != null)
		{
			weaponData = DataManager.Instance.GetWeapon(result);
			goto IL_00f7;
		}
		goto IL_0126;
		IL_00f7:
		if ((object)weaponData != null)
		{
			return weaponData.GetName();
		}
		goto IL_0126;
		IL_0126:
		return (string)(object)new NullReferenceException();
	}

	public unsafe static bool HasLocalizedString(string table, string key)
	{
		//IL_0113: Expected I4, but got O
		//IL_003d: Expected O, but got Ref
		LocalizedStringDatabase stringDatabase = LocalizationSettings.StringDatabase;
		TableReference tableReference = table;
		if (stringDatabase != null)
		{
			object obj = default(object);
			DetailedLocalizationTable<StringTableEntry> table2 = stringDatabase.GetTable((TableReference)(&obj));
			StringTableEntry stringTableEntry;
			UnityEngine.Object obj2;
			if ((object)table2 != null)
			{
				StringTableEntry entry = table2.GetEntry(key);
				stringTableEntry = entry;
				obj2 = table2;
			}
			else
			{
				stringTableEntry = null;
				obj2 = null;
			}
			if (obj2 != null && stringTableEntry != null)
			{
				string value = stringTableEntry.Value;
				bool flag = string.IsNullOrEmpty(value);
				return !flag;
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static LocalizedString GetLocalizedStringReference(string table, string key)
	{
		//IL_003c: Expected O, but got Ref
		//IL_005b: Expected O, but got Ref
		LocalizedString localizedString = new LocalizedString();
		TableReference tableReference = table;
		if (localizedString != null)
		{
			object obj = default(object);
			localizedString.TableReference = (TableReference)(&obj);
			TableEntryReference tableEntryReference = key;
			object obj2 = default(object);
			localizedString.TableEntryReference = (TableEntryReference)(&obj2);
			return localizedString;
		}
		return (LocalizedString)(object)new NullReferenceException();
	}

	public unsafe static string GetStatName(EStat stat)
	{
		//IL_003e: Expected O, but got Ref
		//IL_0068: Expected O, but got Ref
		LocalizedStringDatabase stringDatabase = LocalizationSettings.StringDatabase;
		TableReference tableReference = "Stats";
		if (stringDatabase != null)
		{
			IntPtr intPtr = default(IntPtr);
			StringTable table = stringDatabase.GetTable((TableReference)(&intPtr));
			if ((object)table != null)
			{
				string text = ((Enum)(&intPtr)).ToString();
				string key = text + "_NAME";
				StringTableEntry entry = table.GetEntry(key);
				if (entry != null)
				{
					string value = entry.Value;
					bool flag = value == null;
					string result = "LOCALIZATION ERROR in LocalizationUtility.GetStatName";
					if (!flag)
					{
						result = value;
					}
					return result;
				}
			}
			return "LOCALIZATION ERROR in LocalizationUtility.GetStatName";
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe static string GetStatDesc(EStat stat)
	{
		//IL_003e: Expected O, but got Ref
		//IL_0075: Expected O, but got Ref
		//IL_0132: Expected O, but got Ref
		//IL_015c: Expected O, but got Ref
		LocalizedStringDatabase stringDatabase = LocalizationSettings.StringDatabase;
		TableReference tableReference = "Stats";
		string value;
		string result;
		if (stringDatabase != null)
		{
			string text = default(string);
			StringTable table = stringDatabase.GetTable((TableReference)(&text));
			bool flag = (object)table == null;
			text = tableReference.m_TableCollectionName;
			if (!flag)
			{
				IntPtr intPtr = default(IntPtr);
				string text2 = ((Enum)(&intPtr)).ToString();
				string key = text2 + "_DESC";
				StringTableEntry entry = table.GetEntry(key);
				bool flag2 = entry == null;
				text = (string)(object)typeof(EStat);
				if (!flag2)
				{
					value = entry.Value;
					result = "LOCALIZATION ERROR in LocalizationUtility.GetStatDesc";
					goto IL_01f5;
				}
			}
			LocalizedStringDatabase stringDatabase2 = LocalizationSettings.StringDatabase;
			TableReference tableReference2 = "Stats";
			if (stringDatabase2 != null)
			{
				StringTable table2 = stringDatabase2.GetTable((TableReference)(&text));
				if ((object)table2 != null)
				{
					IntPtr intPtr2 = default(IntPtr);
					string text3 = ((Enum)(&intPtr2)).ToString();
					string key2 = text3 + "_NAME";
					StringTableEntry entry2 = table2.GetEntry(key2);
					if (entry2 != null)
					{
						value = entry2.Value;
						result = "LOCALIZATION ERROR in LocalizationUtility.GetStatName";
						goto IL_01f5;
					}
				}
				return "LOCALIZATION ERROR in LocalizationUtility.GetStatName";
			}
		}
		return (string)(object)new NullReferenceException();
		IL_01f5:
		if (value != null)
		{
			result = value;
		}
		return result;
	}

	public static string GetCharacterName(ECharacter character)
	{
		if ((object)DataManager.Instance != null)
		{
			CharacterData characterData = DataManager.Instance.GetCharacterData(character);
			if ((object)characterData != null)
			{
				return characterData.GetName();
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe static string GetEnemyName(EEnemy enemy)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string key = ((Enum)(&obj)).ToString();
		return GetLocalizedString("Enemies", key);
	}

	public unsafe static string GetRarity(ERarity rarity)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string key = ((Enum)(&obj)).ToString();
		return GetLocalizedString("Rarities", key);
	}

	public unsafe static string GetRarity(EItemRarity rarity)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string key = ((Enum)(&obj)).ToString();
		return GetLocalizedString("Rarities", key);
	}

	public unsafe static string GetAchievementType(EAchievementType achievementType)
	{
		//IL_002e: Expected O, but got Ref
		object obj = default(object);
		string key = ((Enum)(&obj)).ToString();
		LocalizedString localizedStringReference = GetLocalizedStringReference("QuestsUi", key);
		if (localizedStringReference != null)
		{
			return localizedStringReference.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public static string GetLanguageName(Locale locale)
	{
		if ((object)locale != null)
		{
			return GetLanguageName((string)locale.m_Identifier);
		}
		return (string)(object)new NullReferenceException();
	}

	public static string GetLanguageName(string code)
	{
		//IL_0668: Expected O, but got I
		//IL_0678: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172522]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804BF510");
		object obj = default(object);
		if ((nint)obj > 1177122803)
		{
			if ((nint)obj > 1461901041)
			{
				if ((nint)obj > 1565420801)
				{
					if ((nint)obj == 1581462945)
					{
						if (code == "uk")
						{
							return "Українська";
						}
					}
					else if ((nint)obj == 1816099348)
					{
						if (code == "ja")
						{
							return "日本語";
						}
					}
					else if ((long)obj == 3436621126L && code == "es-419")
					{
						return "Español (Latinoamérica)";
					}
				}
				else if ((nint)obj == 1545391778)
				{
					if (code == "de")
					{
						return "Deutsch";
					}
				}
				else if ((nint)obj == 1565420801 && code == "pt")
				{
					return "Português";
				}
			}
			else if ((nint)obj > 1195724803)
			{
				if ((nint)obj == 1213488160)
				{
					if (code == "ru")
					{
						return "Русский";
					}
				}
				else if ((nint)obj == 1461901041 && code == "fr")
				{
					return "Français";
				}
			}
			else if ((nint)obj == 1194886160)
			{
				if (code == "it")
				{
					return "Italiano";
				}
			}
			else if ((nint)obj == 1195724803 && code == "tr")
			{
				return "Türkçe";
			}
		}
		else if ((nint)obj > 1095059089)
		{
			if ((nint)obj > 1162757945)
			{
				if ((nint)obj == 1176137065)
				{
					if (code == "es")
					{
						return "Español";
					}
				}
				else if ((nint)obj == 1177122803 && code == "cs")
				{
					return "Čeština";
				}
			}
			else if ((nint)obj == 1111292255)
			{
				if (code == "ko")
				{
					return "한국어";
				}
			}
			else if ((nint)obj == 1162757945 && code == "pl")
			{
				return "Polski";
			}
		}
		else if ((nint)obj > 89862570)
		{
			if ((nint)obj == 1092248970)
			{
				if (code == "en")
				{
					return "English";
				}
			}
			else if ((nint)obj == 1095059089 && code == "th")
			{
				return "ไทย";
			}
		}
		else if ((nint)obj == 5974475)
		{
			if (code == "zh-Hant")
			{
				return "中文 (繁體)";
			}
		}
		else if ((nint)obj == 89862570 && code == "zh-Hans")
		{
			return "中文 (简体)";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ rax_v4+B8]");
		return (string)0;
	}
}
