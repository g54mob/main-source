using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using FullSerializer;
using UnityEngine;

public static class FileManager
{
	public delegate void OnResult(LoadResult loadResult);

	public delegate void OnCompleted();

	public static fsSerializer serializer;

	public const string SaveFileExtension = ".idlesav";

	public static void ConfigureProcessor()
	{
		if (serializer == null)
		{
			serializer = new fsSerializer();
			serializer.AddConverter(new VictoryConditionsConverter());
			serializer.AddConverter(new FlexDataConverter());
		}
	}

	public static void Save()
	{
		ConfigureProcessor();
		string fileString = SaveFile.GameStateAsString();
		string text = GameManager.Instance.overrideFileName + ".idlesav";
		Platform.Instance.WriteToPlatformFiles(text, FileType.SaveFile, fileString);
		PlayerPrefs.SetString("lastFileName", text);
		PlayerPrefs.SetInt("lastFileSource", (int)Platform.Instance.GetFileSource());
		TimeManager.timeSinceAutosave = 0f;
	}

	public static void SaveUtility()
	{
	}

	public static string FileNameForSlotAndTown(int slotIndex, int townIndex)
	{
		string text = slotIndex.ToString(CultureInfo.InvariantCulture);
		return "slot" + text + ".idlesav";
	}

	public static void LoadContinuedGame()
	{
		int slotIndex = 0;
		int townIndex = 0;
		ClearAndLoadCurrent(Platform.Instance.CreateFileMetadata(slotIndex, townIndex), OnLoadResult);
	}

	public static GameDataContainer GetGameDataFromContents(FileMetadata file, string fileContents)
	{
		GameDataContainer gameDataContainer = new GameDataContainer();
		string text = "\"TownLevel\":";
		int num = fileContents.IndexOf(text, StringComparison.InvariantCulture);
		if (num > 0)
		{
			int num2 = num + text.Length;
			int num3 = fileContents.IndexOf(",", num2, StringComparison.InvariantCulture);
			if (num3 > num2 && int.TryParse(fileContents.Substring(num2, num3 - num2), out var result))
			{
				gameDataContainer.townLevel = result;
			}
		}
		string text2 = "\"name\":\"";
		int num4 = fileContents.IndexOf(text2, StringComparison.InvariantCulture);
		if (num4 > 0)
		{
			int num5 = num4 + text2.Length;
			int num6 = fileContents.IndexOf("\"", num5, StringComparison.InvariantCulture);
			if (num6 > num5)
			{
				string townName = fileContents.Substring(num5, num6 - num5);
				gameDataContainer.townName = townName;
			}
		}
		return gameDataContainer;
	}

	public static LoadResultStatus TryPushToGameState(FileMetadata file, string fileContents)
	{
		ConfigureProcessor();
		fsData data;
		try
		{
			data = fsJsonParser.Parse(fileContents);
		}
		catch (Exception ex)
		{
			Debug.LogError("Load Exception: " + ex);
			return LoadResultStatus.Error;
		}
		if (file.fileType == FileType.SaveFile)
		{
			SaveFile.RestoreGameStateFromData(data);
		}
		else
		{
			Debug.LogError("unspecified file type for " + file);
		}
		return LoadResultStatus.OK;
	}

	public static void OnLoadResult(LoadResult result)
	{
		if (result.status != LoadResultStatus.OK)
		{
			if (result.status == LoadResultStatus.NoSaveFileFound)
			{
				MenuManager.Instance.loadingCover.gameObject.SetActive(value: false);
				MenuManager.Instance.ShowMessage("CouldNotFindFile".Localized());
			}
			else
			{
				MenuManager.Instance.loadingCover.gameObject.SetActive(value: false);
				MenuManager.Instance.ShowMessage(result.status.ToString());
			}
		}
	}

	public static T DeepCopy<T>(T objectToCopy)
	{
		if (objectToCopy == null)
		{
			return default(T);
		}
		ConfigureProcessor();
		if (serializer.TrySerialize(typeof(T), objectToCopy, out var data).Failed)
		{
			T val = objectToCopy;
			Debug.LogError("Could not deep copy " + val);
			return default(T);
		}
		object result = null;
		if (serializer.TryDeserialize(data, typeof(T), ref result).Failed)
		{
			T val = objectToCopy;
			Debug.LogError("Could not deep copy deserialize " + val);
			return default(T);
		}
		return (T)result;
	}

	public static string GetPersistentLocalDirectory(FileType fileType)
	{
		string path = FolderForType(fileType);
		string text = Path.Combine(Application.persistentDataPath, path);
		ConfirmDirectory(text);
		return text;
	}

	public static void ConfirmDirectory(string path)
	{
		if (!new DirectoryInfo(path).Exists)
		{
			Debug.Log("Creating directory: " + path);
			Directory.CreateDirectory(path);
		}
	}

	public static string FolderForType(FileType fileType)
	{
		if (fileType == FileType.SaveFile)
		{
			return "Saved Games";
		}
		Debug.LogError("No folder specified for file type: " + fileType);
		return null;
	}

	public static void ClearAndLoadCurrent(FileMetadata f, OnResult resultDelegate)
	{
		InitializeAndReset();
		TryLoad(f, resultDelegate);
	}

	public static void InitializeAndReset()
	{
		GameManager.GameState = GameState.Clearing;
		GameManager instance = GameManager.Instance;
		MenuManager instance2 = MenuManager.Instance;
		if (!instance.isInitialized)
		{
			instance.Initialize();
			instance2.CreatePanelContents();
		}
		instance.ResetGameMetadata();
	}

	public static async void TryLoad(FileMetadata file, OnResult resultDelegate)
	{
		GameManager.GameState = GameState.Loading;
		LoadResult loadResult = await TryLoadSaveFileAsync(file);
		resultDelegate?.Invoke(loadResult);
		PlayerPrefs.SetString("lastFileName", Path.GetFileName(file.platformRootedPath));
		PlayerPrefs.SetInt("lastFileSource", (int)file.fileSource);
	}

	private static async Task<LoadResult> TryLoadSaveFileAsync(FileMetadata file)
	{
		await Task.Delay(20);
		GameManager.Instance.loadErrorMessage = null;
		LoadResultStatus status = Platform.Instance.TryLoadSaveFileFromPath(file);
		return new LoadResult(status, file.displayName, file.fileSource, file.fileType);
	}

	public static string AddExtension(string displayName, FileType fileType)
	{
		if (fileType == FileType.SaveFile)
		{
			Path.GetExtension(displayName);
			if (false)
			{
				return Path.ChangeExtension(displayName, ".idlesav");
			}
			return displayName + ".idlesav";
		}
		Debug.LogError("Did not specify extension for file type " + fileType);
		return displayName;
	}
}
