using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DV.UserManagement;
using DV.Utils;
using IniParser.Model;
using IniParser.Model.Configuration;
using IniParser.Parser;
using UnityEngine;

public class PreferencesPersistence : IPreferencesPersistence
{
	public const int PREFERENCES_VERSION = 8;

	private const string PARSING_FAILED = "Couldn't parse entry '{0}' for preference '{1}'. Trying to set default value.";

	private const string ENUM_PARSING_FAILED = "Failed to parse enum entry '{0}' for preference '{1}'. Trying to set default value. Exception: '{2}'.";

	private const string READING_FAILED = "Failed to load '{0}' preferences file. Game will use default preferences values";

	private const string UNHANDLED_TYPE = "Unhandled type for preference '{0}', an empty value will be written to the file!";

	private const string SECTION_PREFIX_NONVR = "Non-VR";

	private const string SECTION_PREFIX_VR = "VR";

	private const string SECTION_SEPARATOR = "_";

	private const string SECTION_DEV = "Do not modify";

	private const string KEY_VERSION = "PreferencesVersion";

	private readonly Type preferenceType = typeof(Preferences);

	private readonly PreferencesExclusivity exclusivity;

	private readonly IPreferencesStore preferencesStore;

	private readonly IniDataParser parser;

	private readonly IPreferenceTypeResolver typeResolver;

	private HashSet<Preferences> preferencesLoadedAsDefaultValue = new HashSet<Preferences>();

	private Dictionary<string, string> incompatiblePreferences = new Dictionary<string, string>();

	private HashSet<string> preferencesToDelete = new HashSet<string>();

	private APreferencesProvider provider;

	public int WrittenPreferencesVersion { get; private set; }

	public PreferencesPersistence(IPreferencesStore preferencesStore, PreferencesExclusivity exclusivity, APreferencesProvider provider)
	{
		this.exclusivity = exclusivity;
		this.provider = provider;
		if (exclusivity != PreferencesExclusivity.NonVR && exclusivity != PreferencesExclusivity.VR)
		{
			throw new Exception(string.Format("'{0}' expects initial exclusivity to be either '{1}' or '{2}' but the given value is '{3}'", "PreferencesPersistence", PreferencesExclusivity.NonVR, PreferencesExclusivity.VR, exclusivity));
		}
		typeResolver = new PreferencesTypeResolver();
		this.preferencesStore = preferencesStore;
		parser = CreateParser();
	}

	private IniDataParser CreateParser()
	{
		return new IniDataParser(new IniParserConfiguration
		{
			AllowCreateSectionsOnFly = true,
			AllowDuplicateKeys = true,
			AssigmentSpacer = " ",
			OverrideDuplicateKeys = true,
			SkipInvalidLines = true
		});
	}

	private void CustomizeNewPreferences(IniData data, PreferencesExclusivity currentExclusivity)
	{
		APreferencesCustomizer[] customizers = provider.GetCustomizers();
		foreach (APreferencesCustomizer aPreferencesCustomizer in customizers)
		{
			try
			{
				aPreferencesCustomizer.Customize(this, data, currentExclusivity);
			}
			catch (Exception ex)
			{
				Debug.LogError("Customizer '" + aPreferencesCustomizer.GetType().Name + "' failed to customize preferences. Exception: " + ex.Message);
				Debug.LogException(ex);
			}
		}
	}

	public bool ReadPreferences()
	{
		preferencesLoadedAsDefaultValue.Clear();
		IniData iniData;
		if (SingletonBehaviour<UserManager>.Instance.CurrentUser.Preferences.StartedEmpty)
		{
			string arg = ((exclusivity == PreferencesExclusivity.VR) ? "VR" : "Non-VR");
			Debug.LogWarning($"Failed to load '{arg}' preferences file. Game will use default preferences values");
			preferencesLoadedAsDefaultValue = new HashSet<Preferences>(PreferencesUtils.GetPreferencesByExclusivity(exclusivity));
			iniData = new IniData();
			CustomizeNewPreferences(iniData, exclusivity);
			WrittenPreferencesVersion = 8;
		}
		else
		{
			iniData = parser.Parse(SingletonBehaviour<UserManager>.Instance.CurrentUser.Preferences.RawData);
			if (int.TryParse(iniData["Do not modify"]["PreferencesVersion"], out var result))
			{
				if (result < 0)
				{
					result = 0;
				}
				WrittenPreferencesVersion = result;
			}
			else
			{
				WrittenPreferencesVersion = 0;
			}
		}
		bool result2 = false;
		HashSet<string> hashSet = new HashSet<string>();
		foreach (Preferences item in PreferencesUtils.GetNonFixedPreferencesByExclusivity(exclusivity))
		{
			PreferenceAttribute customAttribute = preferenceType.GetField(item.ToString()).GetCustomAttribute<PreferenceAttribute>(inherit: true);
			if (customAttribute == null)
			{
				Debug.LogError(string.Format("Preference '{0}' doesn't have '{1}' attached. Unable to resolve value from file.", item, "PreferenceAttribute"));
				continue;
			}
			string text = item.ToString();
			string text2 = iniData[GetSection(customAttribute, exclusivity)][text];
			if (typeResolver.IsOfType<bool>(item))
			{
				if (bool.TryParse(text2, out var result3))
				{
					hashSet.Add(text);
					preferencesStore.Set(item, result3);
					result2 = true;
				}
				else
				{
					Debug.LogWarning($"Couldn't parse entry '{text2}' for preference '{item}'. Trying to set default value.");
					preferencesStore.Set(item, PreferencesUtils.GetTypeStrictDefaultPreferenceValue<bool>(item, exclusivity == PreferencesExclusivity.VR));
					preferencesLoadedAsDefaultValue.Add(item);
				}
			}
			else if (typeResolver.IsOfType<int>(item))
			{
				int result4;
				if (provider.GetEnumerablePreferencesMapping().TryGetValue(item, out var value))
				{
					bool flag = false;
					int? num = null;
					try
					{
						num = (int)Enum.Parse(value, text2);
						if (!Enum.IsDefined(value, num))
						{
							throw new ArgumentOutOfRangeException($"Given value '{num}' is not supported by '{value}'.");
						}
						flag = true;
					}
					catch (Exception arg2)
					{
						Debug.LogWarning($"Failed to parse enum entry '{text2}' for preference '{item}'. Trying to set default value. Exception: '{arg2}'.");
						num = PreferencesUtils.GetTypeStrictDefaultPreferenceValue<int>(item, exclusivity == PreferencesExclusivity.VR);
					}
					preferencesStore.Set(item, num.Value);
					if (flag)
					{
						hashSet.Add(text);
					}
					if (flag)
					{
						result2 = true;
					}
					else
					{
						preferencesLoadedAsDefaultValue.Add(item);
					}
				}
				else if (int.TryParse(text2, out result4))
				{
					hashSet.Add(text);
					preferencesStore.Set(item, result4);
					result2 = true;
				}
				else
				{
					Debug.LogWarning($"Couldn't parse entry '{text2}' for preference '{item}'. Trying to set default value.");
					preferencesStore.Set(item, PreferencesUtils.GetTypeStrictDefaultPreferenceValue<int>(item, exclusivity == PreferencesExclusivity.VR));
					preferencesLoadedAsDefaultValue.Add(item);
				}
			}
			else if (typeResolver.IsOfType<float>(item))
			{
				if (float.TryParse(text2, out var result5))
				{
					hashSet.Add(text);
					preferencesStore.Set(item, result5);
					result2 = true;
				}
				else
				{
					Debug.LogWarning($"Couldn't parse entry '{text2}' for preference '{item}'. Trying to set default value.");
					preferencesStore.Set(item, PreferencesUtils.GetTypeStrictDefaultPreferenceValue<float>(item, exclusivity == PreferencesExclusivity.VR));
					preferencesLoadedAsDefaultValue.Add(item);
				}
			}
			else if (typeResolver.IsOfType<string>(item))
			{
				if (text2 != null)
				{
					hashSet.Add(text);
					preferencesStore.Set(item, text2);
					result2 = true;
				}
				else
				{
					Debug.LogWarning(string.Format("Couldn't parse entry '{0}' for preference '{1}'. Trying to set default value.", "null", item));
					preferencesStore.Set(item, PreferencesUtils.GetTypeStrictDefaultPreferenceValue<string>(item, exclusivity == PreferencesExclusivity.VR));
					preferencesLoadedAsDefaultValue.Add(item);
				}
			}
			else
			{
				Debug.LogError($"Unhandled type for preference '{item}', an empty value will be written to the file!");
			}
		}
		foreach (SectionData section in iniData.Sections)
		{
			foreach (KeyData key in section.Keys)
			{
				if (!hashSet.Contains(key.KeyName))
				{
					incompatiblePreferences[key.KeyName] = key.Value;
				}
			}
		}
		return result2;
	}

	public void WriteCustomizedPreference(Preferences pref, string value, PreferencesExclusivity prefExclusivity, IniData data)
	{
		PreferenceAttribute customAttribute = preferenceType.GetField(pref.ToString()).GetCustomAttribute<PreferenceAttribute>(inherit: true);
		if (customAttribute == null)
		{
			Debug.LogError(string.Format("'{0}' missing from preference '{1}'. Writing skipped for '{2}'.", "PreferenceAttribute", pref, pref));
			return;
		}
		string keyName = pref.ToString();
		data[GetSection(customAttribute, prefExclusivity)][keyName] = value;
		preferencesLoadedAsDefaultValue.Remove(pref);
	}

	public void WritePreferences()
	{
		IniData iniData = parser.Parse(SingletonBehaviour<UserManager>.Instance.CurrentUser.Preferences.RawData);
		iniData["Do not modify"]["PreferencesVersion"] = 8.ToString();
		foreach (Preferences item in PreferencesUtils.GetNonFixedPreferencesByExclusivity(exclusivity))
		{
			PreferenceAttribute customAttribute = preferenceType.GetField(item.ToString()).GetCustomAttribute<PreferenceAttribute>(inherit: true);
			if (customAttribute == null)
			{
				Debug.LogError(string.Format("'{0}' missing from preference '{1}'. Writing skipped for '{2}'.", "PreferenceAttribute", item, item));
				continue;
			}
			string keyName = item.ToString();
			string value;
			if (typeResolver.IsOfType<bool>(item))
			{
				value = preferencesStore.Get<bool>(item).ToString();
			}
			else if (typeResolver.IsOfType<int>(item))
			{
				string text = preferencesStore.Get<int>(item).ToString();
				value = ((!provider.GetEnumerablePreferencesMapping().TryGetValue(item, out var value2)) ? text : Enum.Parse(value2, text).ToString());
			}
			else if (typeResolver.IsOfType<float>(item))
			{
				value = preferencesStore.Get<float>(item).ToString();
			}
			else
			{
				if (!typeResolver.IsOfType<string>(item))
				{
					Debug.LogError($"Unhandled preference type '{item.GetType()}' for preference '{item}'");
					continue;
				}
				value = preferencesStore.Get<string>(item);
			}
			iniData[GetSection(customAttribute, exclusivity)][keyName] = value;
		}
		if (preferencesToDelete.Count > 0)
		{
			foreach (SectionData section in iniData.Sections)
			{
				section.Keys.Select((KeyData k) => k.KeyName).Intersect(preferencesToDelete).ToList()
					.ForEach(delegate(string k)
					{
						section.Keys.RemoveKey(k);
					});
			}
			preferencesToDelete.Clear();
		}
		SingletonBehaviour<UserManager>.Instance.CurrentUser.Preferences.RawData = iniData.ToString();
		SingletonBehaviour<UserManager>.Instance.CurrentUser.Preferences.Save();
		preferencesStore.IsDirty = false;
		Debug.Log("Wrote game preferences configuration: " + SingletonBehaviour<UserManager>.Instance.Storage.GetFilesystemPath(SingletonBehaviour<UserManager>.Instance.CurrentUser.Preferences.Path));
	}

	public string GetIncompatiblePreferenceRawValue(string key)
	{
		if (incompatiblePreferences.TryGetValue(key, out var value))
		{
			return value;
		}
		return null;
	}

	public void DeleteIncompatiblePreference(string key)
	{
		if (incompatiblePreferences.Remove(key))
		{
			preferencesToDelete.Add(key);
		}
	}

	private static string GetSection(PreferenceAttribute preferenceAttribute, PreferencesExclusivity exclusivity)
	{
		string text = ((exclusivity == PreferencesExclusivity.VR) ? "VR" : "Non-VR");
		return string.Join("_", text, preferenceAttribute.Category.ToString());
	}

	public void PurgeWrittenPreferences()
	{
		SingletonBehaviour<UserManager>.Instance.CurrentUser.Preferences.RawData = "";
		SingletonBehaviour<UserManager>.Instance.CurrentUser.Preferences.Save();
	}

	public void CreateBackupFile(string fileSuffix)
	{
		if (string.IsNullOrWhiteSpace(fileSuffix))
		{
			Debug.LogError("'PreferencesPersistence' failed to create a backup - backup file name must be different than original.");
		}
	}

	public bool LoadedAsDefaultValue(Preferences preference)
	{
		return preferencesLoadedAsDefaultValue.Contains(preference);
	}
}
