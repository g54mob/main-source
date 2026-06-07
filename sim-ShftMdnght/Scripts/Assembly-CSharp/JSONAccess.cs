using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class JSONAccess : MonoBehaviour
{
	[Serializable]
	public class DialogueEntry
	{
		public string name;

		public List<ValueEntry> values;
	}

	[Serializable]
	public class ValueEntry
	{
		public string key;

		public string value;
	}

	[Serializable]
	public class DialogueData
	{
		public List<DialogueEntry> entries;
	}

	public TMP_FontAsset[] languageFonts;

	private readonly Dictionary<string, DialogueData> _cacheByCategory = new Dictionary<string, DialogueData>();

	private readonly Dictionary<string, string> _cachedLanguageByCategory = new Dictionary<string, string>();

	private readonly HashSet<string> _cacheLoadedCategories = new HashSet<string>();

	public static JSONAccess Instance { get; private set; }

	public string GetMiscText(string id, string key)
	{
		return GetTextFromCategory("MISC", id, key);
	}

	public string GetDialogueText(string id, string key)
	{
		return GetTextFromCategory("DIALOGUE", id, key);
	}

	public string GetCarDatabaseText(string id, string key)
	{
		return GetTextFromCategory("CAR_DB", id, key);
	}

	public string GetIDDatabaseText(string id, string key)
	{
		return GetTextFromCategory("ID_DB", id, key);
	}

	public void PreloadMiscAsync(string lang)
	{
		PreloadCategoryAsync("MISC", lang);
	}

	public void PreloadDialogueAsync(string lang)
	{
		PreloadCategoryAsync("DIALOGUE", lang);
	}

	public void PreloadCarDatabaseAsync(string lang)
	{
		PreloadCategoryAsync("CAR_DB", lang);
	}

	public void PreloadIDDatabaseAsync(string lang)
	{
		PreloadCategoryAsync("ID_DB", lang);
	}

	public string GetShowingName(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			return string.Empty;
		}
		NormalizeNameKey(name);
		((SaveManager.Instance != null) ? SaveManager.Instance.npcsKilled : null)?.Where((string k) => !string.IsNullOrWhiteSpace(k)).Select(NormalizeNameKey).ToHashSet(StringComparer.Ordinal);
		string iDDatabaseText = GetIDDatabaseText(name, "Name");
		if (!(iDDatabaseText == "[TNF]") && !(iDDatabaseText == "[TEXT KEY NOT FOUND IN FILES]"))
		{
			return iDDatabaseText;
		}
		return string.Empty;
	}

	public string GetStatus(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			return string.Empty;
		}
		string item = NormalizeNameKey(name);
		if (SaveManager.Instance != null && SaveManager.Instance.npcsKilled != null && SaveManager.Instance.npcsKilled.Where((string k) => !string.IsNullOrWhiteSpace(k)).Select(NormalizeNameKey).ToHashSet(StringComparer.Ordinal)
			.Contains(item))
		{
			return "Deceased";
		}
		string iDDatabaseText = GetIDDatabaseText(name, "STATUS");
		if (iDDatabaseText == "[TNF]" || iDDatabaseText == "[TEXT KEY NOT FOUND IN FILES]")
		{
			return string.Empty;
		}
		return iDDatabaseText ?? string.Empty;
	}

	public bool TryGetIDDatabaseEntryDict(string id, out Dictionary<string, string> dict)
	{
		dict = null;
		if (string.IsNullOrWhiteSpace(id))
		{
			return false;
		}
		string lang = PlayerPrefs.GetString("Language");
		EnsureCacheLoaded("ID_DB", lang);
		if (!_cacheLoadedCategories.Contains("ID_DB") || !_cacheByCategory.TryGetValue("ID_DB", out var value) || value == null || value.entries == null)
		{
			return false;
		}
		foreach (DialogueEntry entry in value.entries)
		{
			if (entry == null || entry.name == null || !entry.name.Equals(id, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			if (entry.values != null)
			{
				foreach (ValueEntry value2 in entry.values)
				{
					if (value2 != null && value2.key != null)
					{
						dictionary[value2.key] = value2.value ?? string.Empty;
					}
				}
			}
			dict = dictionary;
			return true;
		}
		return false;
	}

	public bool TryGetIDDatabaseNames(out List<string> realNames, out List<string> showingNames)
	{
		realNames = null;
		showingNames = null;
		string lang = PlayerPrefs.GetString("Language");
		EnsureCacheLoaded("ID_DB", lang);
		if (!_cacheLoadedCategories.Contains("ID_DB") || !_cacheByCategory.TryGetValue("ID_DB", out var value) || value == null || value.entries == null)
		{
			return false;
		}
		realNames = new List<string>(value.entries.Count);
		showingNames = new List<string>(value.entries.Count);
		foreach (DialogueEntry entry in value.entries)
		{
			if (entry == null)
			{
				continue;
			}
			if (!string.IsNullOrWhiteSpace(entry.name))
			{
				realNames.Add(entry.name);
			}
			else
			{
				realNames.Add(string.Empty);
			}
			string item = string.Empty;
			if (entry.values != null)
			{
				for (int i = 0; i < entry.values.Count; i++)
				{
					ValueEntry valueEntry = entry.values[i];
					if (valueEntry != null && valueEntry.key == "Name")
					{
						item = valueEntry.value ?? string.Empty;
						break;
					}
				}
			}
			showingNames.Add(item);
		}
		return true;
	}

	private static string NormalizeNameKey(string input)
	{
		return input.ToLowerInvariant().Replace(" ", "");
	}

	public bool TryGetEntryDictionaryFromDialogue(string id, out Dictionary<string, string> dict)
	{
		dict = null;
		string lang = PlayerPrefs.GetString("Language");
		string text = "DIALOGUE";
		EnsureCacheLoaded(text, lang);
		if (!_cacheLoadedCategories.Contains(text) || !_cacheByCategory.TryGetValue(text, out var value) || value == null || value.entries == null)
		{
			return false;
		}
		foreach (DialogueEntry entry in value.entries)
		{
			if (entry == null || entry.name == null || !entry.name.Equals(id, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			if (entry.values != null)
			{
				foreach (ValueEntry value2 in entry.values)
				{
					if (value2 != null && value2.key != null)
					{
						dictionary[value2.key] = value2.value ?? string.Empty;
					}
				}
			}
			dict = dictionary;
			return true;
		}
		return false;
	}

	public void PreloadAllForCurrentLanguage()
	{
		string lang = PlayerPrefs.GetString("Language");
		PreloadMiscAsync(lang);
		PreloadDialogueAsync(lang);
		PreloadCarDatabaseAsync(lang);
		PreloadIDDatabaseAsync(lang);
	}

	private string GetTextFromCategory(string category, string id, string key)
	{
		string lang = PlayerPrefs.GetString("Language");
		EnsureCacheLoaded(category, lang);
		if (!_cacheLoadedCategories.Contains(category) || !_cacheByCategory.TryGetValue(category, out var value) || value == null || value.entries == null)
		{
			return "[TNF]";
		}
		for (int i = 0; i < value.entries.Count; i++)
		{
			DialogueEntry dialogueEntry = value.entries[i];
			if (dialogueEntry == null || dialogueEntry.name == null || !dialogueEntry.name.Equals(id, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			if (dialogueEntry.values != null)
			{
				foreach (ValueEntry value3 in dialogueEntry.values)
				{
					if (value3 != null && value3.key != null)
					{
						dictionary[value3.key] = value3.value ?? string.Empty;
					}
				}
			}
			if (dictionary.TryGetValue(key, out var value2))
			{
				value2 = value2.Replace("<PET NAME>", PlayerPrefs.GetString("PetName", "Pet"));
				value2 = value2.Replace("<CROUCH BIND>", PlayerPrefs.GetString("Keybind5"));
				value2 = value2.Replace("<SECONDARY INTERACT>", PlayerPrefs.GetString("Keybind8"));
				value2 = value2.Replace("<RELOAD>", PlayerPrefs.GetString("Keybind10"));
				if ((bool)StoreManager.Instance)
				{
					value2 = value2.Replace("<NUMBER>", StoreManager.Instance.doppelsLetThru.ToString());
				}
				return value2;
			}
			return "[TEXT KEY NOT FOUND IN FILES]";
		}
		return "[TEXT KEY NOT FOUND IN FILES]";
	}

	private void EnsureCacheLoaded(string category, string lang)
	{
		if (!_cacheLoadedCategories.Contains(category) || !_cachedLanguageByCategory.TryGetValue(category, out var value) || !string.Equals(value, lang, StringComparison.OrdinalIgnoreCase))
		{
			_cacheLoadedCategories.Remove(category);
			_cachedLanguageByCategory[category] = lang;
			string fileName = GetFileName(category, lang);
			if (StreamingAssetsReader.TryReadTextSync(Path.Combine(Application.streamingAssetsPath, fileName), out var text))
			{
				LoadCategoryFromText(category, text);
			}
			else
			{
				Debug.LogWarning("StreamingAssets sync read not supported on this platform. Preload required for: " + fileName);
			}
		}
	}

	private void LoadCategoryFromEncryptedText(string category, string encryptedB64)
	{
		string text = SimpleJsonCrypto.DecryptBase64ToJson(encryptedB64);
		if (string.IsNullOrEmpty(text))
		{
			_cacheByCategory[category] = null;
			_cacheLoadedCategories.Remove(category);
			return;
		}
		DialogueData dialogueData = JsonUtility.FromJson<DialogueData>(text);
		_cacheByCategory[category] = dialogueData;
		if (dialogueData != null)
		{
			_cacheLoadedCategories.Add(category);
		}
		else
		{
			_cacheLoadedCategories.Remove(category);
		}
	}

	private static bool ShouldSkipDecryption()
	{
		return PlayerPrefs.GetInt("DecryptText", 0) == 1;
	}

	private void LoadCategoryFromText(string category, string textFromFile)
	{
		string text = (ShouldSkipDecryption() ? textFromFile : SimpleJsonCrypto.DecryptBase64ToJson(textFromFile));
		if (string.IsNullOrEmpty(text))
		{
			_cacheByCategory[category] = null;
			_cacheLoadedCategories.Remove(category);
			return;
		}
		DialogueData dialogueData = JsonUtility.FromJson<DialogueData>(text);
		_cacheByCategory[category] = dialogueData;
		if (dialogueData != null)
		{
			_cacheLoadedCategories.Add(category);
		}
		else
		{
			_cacheLoadedCategories.Remove(category);
		}
	}

	private void PreloadCategoryAsync(string category, string lang)
	{
		string fileName = GetFileName(category, lang);
		string path = Path.Combine(Application.streamingAssetsPath, fileName);
		StartCoroutine(StreamingAssetsReader.ReadTextAsync(path, delegate(bool ok, string fileText)
		{
			if (!ok)
			{
				Debug.LogWarning("Failed to load StreamingAssets file: " + fileName);
				_cacheByCategory[category] = null;
				_cacheLoadedCategories.Remove(category);
				_cachedLanguageByCategory[category] = lang;
			}
			else
			{
				_cachedLanguageByCategory[category] = lang;
				LoadCategoryFromText(category, fileText);
			}
		}));
	}

	public bool TryGetCarDatabaseEntryDict(string plate, out Dictionary<string, string> dict)
	{
		dict = null;
		if (string.IsNullOrWhiteSpace(plate))
		{
			return false;
		}
		string lang = PlayerPrefs.GetString("Language");
		EnsureCacheLoaded("CAR_DB", lang);
		if (!_cacheLoadedCategories.Contains("CAR_DB") || !_cacheByCategory.TryGetValue("CAR_DB", out var value) || value == null || value.entries == null)
		{
			return false;
		}
		string value2 = plate.Trim();
		foreach (DialogueEntry entry in value.entries)
		{
			if (entry == null)
			{
				continue;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			if (entry.values != null)
			{
				foreach (ValueEntry value4 in entry.values)
				{
					if (value4 != null && !string.IsNullOrWhiteSpace(value4.key))
					{
						dictionary[value4.key] = value4.value ?? string.Empty;
					}
				}
			}
			if (dictionary.TryGetValue("Name", out var value3) && !string.IsNullOrWhiteSpace(value3) && value3.Equals(value2, StringComparison.OrdinalIgnoreCase))
			{
				dict = dictionary;
				return true;
			}
			if (!string.IsNullOrWhiteSpace(entry.name) && entry.name.Equals(value2, StringComparison.OrdinalIgnoreCase))
			{
				if (!dictionary.ContainsKey("Name"))
				{
					dictionary["Name"] = entry.name;
				}
				dict = dictionary;
				return true;
			}
		}
		return false;
	}

	public bool TryGetCarDatabaseNames(out List<string> names)
	{
		names = null;
		string lang = PlayerPrefs.GetString("Language");
		EnsureCacheLoaded("CAR_DB", lang);
		if (!_cacheLoadedCategories.Contains("CAR_DB") || !_cacheByCategory.TryGetValue("CAR_DB", out var value) || value == null || value.entries == null)
		{
			return false;
		}
		names = new List<string>(value.entries.Count);
		foreach (DialogueEntry entry in value.entries)
		{
			if (entry == null)
			{
				continue;
			}
			string text = null;
			if (entry.values != null)
			{
				foreach (ValueEntry value2 in entry.values)
				{
					if (value2 != null && string.Equals(value2.key, "Name", StringComparison.OrdinalIgnoreCase))
					{
						text = value2.value;
						break;
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				names.Add(text);
			}
			else if (!string.IsNullOrWhiteSpace(entry.name))
			{
				names.Add(entry.name);
			}
		}
		return true;
	}

	public string GetCarDatabaseInnerName(string outerName)
	{
		if (string.IsNullOrWhiteSpace(outerName))
		{
			return string.Empty;
		}
		string lang = PlayerPrefs.GetString("Language");
		EnsureCacheLoaded("CAR_DB", lang);
		if (!_cacheLoadedCategories.Contains("CAR_DB") || !_cacheByCategory.TryGetValue("CAR_DB", out var value) || value == null || value.entries == null)
		{
			return string.Empty;
		}
		foreach (DialogueEntry entry in value.entries)
		{
			if (entry == null || string.IsNullOrWhiteSpace(entry.name) || !entry.name.Equals(outerName, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			if (entry.values == null)
			{
				return entry.name;
			}
			foreach (ValueEntry value2 in entry.values)
			{
				if (value2 != null && string.Equals(value2.key, "Name", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(value2.value))
				{
					return value2.value;
				}
			}
			return entry.name;
		}
		return string.Empty;
	}

	private static string GetFileName(string category, string lang)
	{
		return category switch
		{
			"MISC" => "Misc Text " + lang + ".json", 
			"DIALOGUE" => "Dialogue " + lang + ".json", 
			"CAR_DB" => "Car Database " + lang + ".json", 
			"ID_DB" => "ID Database " + lang + ".json", 
			_ => throw new ArgumentOutOfRangeException("category", category, "Unknown JSON category"), 
		};
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}
}
