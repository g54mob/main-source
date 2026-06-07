#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_WARNINGS
#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.IO;
using System.Threading.Tasks;
using Data.SaveData;
using Data.SaveData.PersistentSOs;
using Newtonsoft.Json;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using SaveData.FactoryFloor.SaveStates.Versions;
using SaveData.FactoryFloor.Versions;
using Steamworks;
using UnityEngine;
using Utils;
using Utils.JsonConverterUtils;

public static class SaveSystem
{
	private static string _currentJsonSaveString;

	private static string _cachedGameSavePath;

	private static string _cachedGameSaveBackupPath;

	public static string GameSavePath
	{
		get
		{
			if (string.IsNullOrEmpty(_cachedGameSavePath))
			{
				if (Application.isEditor)
				{
					_cachedGameSavePath = Application.dataPath.Replace("/Assets", "/EditorSaveData");
				}
				else if (DemoUtils.IsDemo())
				{
					_cachedGameSavePath = Application.persistentDataPath.Replace("Modulus Demo", "Modulus");
				}
				else
				{
					_cachedGameSavePath = Application.persistentDataPath;
				}
			}
			return _cachedGameSavePath;
		}
	}

	public static string GameSaveBackupPath
	{
		get
		{
			if (string.IsNullOrEmpty(_cachedGameSaveBackupPath))
			{
				string text = (SteamManager.Initialized ? SteamUser.GetSteamID().ToString() : "UnityEditor");
				_cachedGameSaveBackupPath = (Application.isEditor ? Application.dataPath.Replace("/Assets", string.Empty) : Application.dataPath) + "/GameSaveBackups/" + text;
				Debug.Log("Setting game save backup path: " + _cachedGameSaveBackupPath);
			}
			return _cachedGameSaveBackupPath;
		}
	}

	public static string AutoSavePath => GameSavePath + "\\AutoSave";

	public static string StreamingAssetsPath => Application.streamingAssetsPath;

	public static string ConvertToGameSaveBackupDirectory(string directoryPath)
	{
		string text = directoryPath.Split('/', '\\')[^1];
		return GameSaveBackupPath + "/" + text;
	}

	public static bool TryReadJson<T>(string json, out T data, params JsonConverter[] converters)
	{
		try
		{
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.Auto,
				DefaultValueHandling = DefaultValueHandling.Ignore
			};
			foreach (JsonConverter item in converters)
			{
				jsonSerializerSettings.Converters.Add(item);
			}
			jsonSerializerSettings.Converters.Add(new ColorConverter());
			jsonSerializerSettings.Converters.Add(new Vector2Converter());
			jsonSerializerSettings.Converters.Add(new Vector3Converter());
			jsonSerializerSettings.Converters.Add(new Vector2IntConverter());
			jsonSerializerSettings.Converters.Add(new Vector3IntConverter());
			jsonSerializerSettings.Converters.Add(new SaveDataGenericConverter<BehaviourSaveStateDto>(new ISaveDataConverter[2]
			{
				new AssemblerBehaviourSaveStateConverter(),
				new OutputTunnelBehaviorSaveStateConverter()
			}));
			jsonSerializerSettings.Converters.Add(new SaveDataGenericConverter<BehaviourConfigurationDto>(new ISaveDataConverter[3]
			{
				new AssemblerBehaviourConfigurationConverter(),
				new StorageDepotBehaviourConfigurationConverter(),
				new SorterBehaviourConfigurationConverter()
			}));
			jsonSerializerSettings.Converters.Add(new UnlockedFactoryObjectsSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new CurrencySaveDataConverter());
			jsonSerializerSettings.Converters.Add(new DisplaySettingsSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new OtherSettingsSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new LockedToolsSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new PinnedModulesSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new QuestsSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new SaveInfoSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new StatisticsSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new ObjectivesSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new TechTreeSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new FactoryShapesSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new FactoryFloorSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new FactoryMapSaveDataConverter());
			jsonSerializerSettings.Converters.Add(new ConveyorBehaviourSaveStateConverter());
			jsonSerializerSettings.Converters.Add(new AccessibilitySettingsSaveDataConverter());
			data = JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
		}
		catch (Exception ex)
		{
			typeof(SaveSystem).LogAssertion("Failed to read json data with exception: " + ex.Message, "TryReadJson", 121);
			typeof(SaveSystem).LogWarning(ex.Message + "\n\n" + ex.StackTrace, "TryReadJson", 122);
			typeof(SaveSystem).LogWarning(json, "TryReadJson", 123);
			data = default(T);
			return false;
		}
		return data != null;
	}

	public static bool TryLoadData<T>(string filePath, out T data, params JsonConverter[] converters) where T : class
	{
		if (!LoadFileData(filePath, out var data2) || !TryReadJson<T>(data2, out data, converters))
		{
			data = null;
			return false;
		}
		return true;
	}

	public static async Task<T> LoadDataAsync<T>(string filePath, params JsonConverter[] converters) where T : class
	{
		string text = await LoadFileDataAsync(filePath);
		if (string.IsNullOrEmpty(text) || !TryReadJson<T>(text, out var data, converters))
		{
			return null;
		}
		return data;
	}

	public static bool TrySaveData<T>(T data, string fullSavePath, params JsonConverter[] converters)
	{
		bool flag;
		try
		{
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.Auto,
				DefaultValueHandling = DefaultValueHandling.Ignore
			};
			foreach (JsonConverter item in converters)
			{
				jsonSerializerSettings.Converters.Add(item);
			}
			jsonSerializerSettings.Converters.Add(new ColorConverter());
			jsonSerializerSettings.Converters.Add(new Vector2Converter());
			jsonSerializerSettings.Converters.Add(new Vector3Converter());
			jsonSerializerSettings.Converters.Add(new Vector4Converter());
			jsonSerializerSettings.Converters.Add(new Vector2IntConverter());
			jsonSerializerSettings.Converters.Add(new Vector3IntConverter());
			_currentJsonSaveString = JsonConvert.SerializeObject(data, jsonSerializerSettings);
			flag = WriteAllText(fullSavePath, _currentJsonSaveString);
		}
		catch (Exception ex)
		{
			typeof(SaveSystem).LogAssertion("Failed to write to save data with exception: " + ex.Message + ": \"" + _currentJsonSaveString + "\"", "TrySaveData", 174);
			return false;
		}
		if (!flag)
		{
			typeof(SaveSystem).LogError("Failed: Write save data to: \"" + fullSavePath + "\"", "TrySaveData", 180);
		}
		else
		{
			typeof(SaveSystem).Log("Success: Wrote save data to: \"" + fullSavePath + "\"", "TrySaveData", 184);
		}
		return flag;
	}

	public static async Task<bool> TrySaveDataAsync<T>(T data, string directoryPath, string fileName, params JsonConverter[] converters)
	{
		CreateFullPath(directoryPath, fileName);
		string fullSavePath = directoryPath + "/" + fileName;
		bool flag;
		try
		{
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.Auto,
				DefaultValueHandling = DefaultValueHandling.Ignore
			};
			foreach (JsonConverter item in converters)
			{
				jsonSerializerSettings.Converters.Add(item);
			}
			jsonSerializerSettings.Converters.Add(new ColorConverter());
			jsonSerializerSettings.Converters.Add(new Vector2Converter());
			jsonSerializerSettings.Converters.Add(new Vector3Converter());
			jsonSerializerSettings.Converters.Add(new Vector4Converter());
			jsonSerializerSettings.Converters.Add(new Vector2IntConverter());
			jsonSerializerSettings.Converters.Add(new Vector3IntConverter());
			_currentJsonSaveString = JsonConvert.SerializeObject(data, jsonSerializerSettings);
			flag = await WriteAllTextAsync(fullSavePath, _currentJsonSaveString);
		}
		catch (Exception ex)
		{
			typeof(SaveSystem).LogAssertion("Failed to write to save data with exception: " + ex.Message + ": \"" + _currentJsonSaveString + "\"", "TrySaveDataAsync", 216);
			return false;
		}
		if (!flag)
		{
			typeof(SaveSystem).LogAssertion("Failed: Write save data to: \"" + fullSavePath + "\"", "TrySaveDataAsync", 223);
		}
		else
		{
			typeof(SaveSystem).Log("Success: Wrote save data to: \"" + fullSavePath + "\"", "TrySaveDataAsync", 227);
		}
		return flag;
	}

	public static bool DoesFileExist(string filePath)
	{
		return File.Exists(filePath);
	}

	public static bool DoesDirectoryExist(string directoryPath)
	{
		return Directory.Exists(directoryPath);
	}

	public static bool LoadFileData(string filePath, out string data)
	{
		data = null;
		if (!DoesFileExist(filePath))
		{
			typeof(SaveSystem).LogWarning("File at '" + filePath + "' does not exist, loading file failed.", "LoadFileData", 249);
			return false;
		}
		if (!ReadAllText(filePath, out data) || string.IsNullOrEmpty(data))
		{
			typeof(SaveSystem).LogWarning("Loading '" + filePath + "' failed.", "LoadFileData", 255);
			return false;
		}
		return true;
	}

	public static async Task<string> LoadFileDataAsync(string filePath)
	{
		string obj = await ReadAllTextAsync(filePath);
		if (string.IsNullOrEmpty(obj))
		{
			typeof(SaveSystem).LogWarning("Loading '" + filePath + "' failed.", "LoadFileDataAsync", 267);
		}
		return obj;
	}

	public static string GetFullSavePathForFileName(string fileName)
	{
		return Path.Combine(GameSavePath, fileName);
	}

	public static string GetFullStreamingAssetPathForFileName(string fileName)
	{
		return Path.Combine(StreamingAssetsPath, fileName);
	}

	public static string CreateFullLevelsSavePath(string editorFolderName)
	{
		return CreateFullPath(GetFullSavePathForFileName("Levels/" + editorFolderName), "");
	}

	public static string CreatePersistentSOSavePath(string directoryPath, string persistentSOName)
	{
		return CreateFullPath(directoryPath, persistentSOName + ".json");
	}

	public static string CreateFullLevelsStreamingAssetPath(string editorFolderName)
	{
		return CreateFullPath(Path.Combine(StreamingAssetsPath, "Levels/" + editorFolderName), "");
	}

	public static string CreateFullPath(string directory, string editorFileName)
	{
		try
		{
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}
		}
		catch (Exception ex)
		{
			typeof(SaveSystem).LogAssertion("Caught an exception while trying to access directories: " + ex.Message, "CreateFullPath", 309);
			return string.Empty;
		}
		return Path.Combine(directory, editorFileName);
	}

	public static string CreateFullPath(string directory)
	{
		try
		{
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}
		}
		catch (Exception ex)
		{
			typeof(SaveSystem).LogAssertion("Caught an exception while trying to access directories: " + ex.Message, "CreateFullPath", 328);
			return string.Empty;
		}
		return directory;
	}

	public static bool WriteAllText(string filePath, string text)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			return false;
		}
		try
		{
			File.WriteAllText(filePath, text);
			return true;
		}
		catch (Exception ex)
		{
			typeof(SaveSystem).LogAssertion($"WriteAllText failed to save file '{filePath}', {ex.Message}", "WriteAllText", 348);
			return false;
		}
	}

	public static async Task<bool> WriteAllTextAsync(string filePath, string text)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			return false;
		}
		try
		{
			await File.WriteAllTextAsync(filePath, text);
			return true;
		}
		catch (Exception ex)
		{
			typeof(SaveSystem).LogAssertion($"WriteAllText failed to save file '{filePath}', {ex.Message}", "WriteAllTextAsync", 366);
			return false;
		}
	}

	public static string ReadAllText(string filePath)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			return null;
		}
		if (!File.Exists(filePath))
		{
			return null;
		}
		try
		{
			return File.ReadAllText(filePath);
		}
		catch (Exception ex)
		{
			typeof(SaveSystem).LogAssertion($"ReadAllText failed to load file '{filePath}', {ex.Message}", "ReadAllText", 387);
			return null;
		}
	}

	public static bool ReadAllText(string filePath, out string text)
	{
		text = ReadAllText(filePath);
		return text != null;
	}

	public static async Task<string> ReadAllTextAsync(string filePath)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			return null;
		}
		if (!File.Exists(filePath))
		{
			return null;
		}
		try
		{
			return await File.ReadAllTextAsync(filePath);
		}
		catch (Exception ex)
		{
			typeof(SaveSystem).LogAssertion($"ReadAllText failed to load file '{filePath}', {ex.Message}", "ReadAllTextAsync", 414);
			return null;
		}
	}

	public static bool DeleteFile(string filePath)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			return false;
		}
		if (!File.Exists(filePath))
		{
			return true;
		}
		try
		{
			File.Delete(filePath);
			return true;
		}
		catch (Exception ex)
		{
			typeof(SaveSystem).LogAssertion($"Delete File '{filePath}' failed, {ex.Message}", "DeleteFile", 436);
			return false;
		}
	}

	public static bool DeleteDirectory(string directoryPath)
	{
		if (string.IsNullOrEmpty(directoryPath))
		{
			return false;
		}
		if (!Directory.Exists(directoryPath))
		{
			return true;
		}
		try
		{
			Directory.Delete(directoryPath, recursive: true);
			return true;
		}
		catch (Exception ex)
		{
			typeof(SaveSystem).LogAssertion($"Delete Directory '{directoryPath}' failed, {ex.Message}", "DeleteDirectory", 458);
			return false;
		}
	}
}
