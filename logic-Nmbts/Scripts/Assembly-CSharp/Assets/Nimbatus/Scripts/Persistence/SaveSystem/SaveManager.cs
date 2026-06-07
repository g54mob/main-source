using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence.SaveSystem
{
	public class SaveManager : MonoBehaviour
	{
		public static SaveData SelectedSave;

		public static PriorityEvent GameLoaded = new PriorityEvent();

		public static PriorityEvent GameSaved = new PriorityEvent();

		public static readonly string LatestCompatibleVersion = "0.9.0";

		public static readonly string SavefileExtension = ".nimbSave";

		private static float _startTime;

		public static string CurrentGameVersion { get; private set; }

		public static SaveData LoadedSave { get; private set; }

		public static string GlobalFilePath
		{
			get
			{
				return Application.persistentDataPath + "/Saves/Global";
			}
		}

		public static string SavefileFolderPath
		{
			get
			{
				return Application.persistentDataPath + "/Saves/Savefiles";
			}
		}

		public static string ActiveDataFolderPath
		{
			get
			{
				return Application.persistentDataPath + "/Saves/Savefiles/LoadedSaveData";
			}
		}

		public static string ActiveDroneFolderPath
		{
			get
			{
				return Application.persistentDataPath + "/Saves/Drones";
			}
		}

		public void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			CurrentGameVersion = Application.version;
			if (!Directory.Exists(SavefileFolderPath))
			{
				Directory.CreateDirectory(SavefileFolderPath);
			}
			if (!Directory.Exists(ActiveDroneFolderPath))
			{
				Directory.CreateDirectory(ActiveDroneFolderPath);
			}
			RestoreDronesFromOldSaves(Application.persistentDataPath + "/Saves");
			RestoreDronesFromOldSaves(Application.persistentDataPath + "/Saves/Campaign");
			RestoreDronesFromOldSaves(Application.persistentDataPath + "/Saves/Creative");
			RestoreDronesFromOldSaves(Application.persistentDataPath + "/Saves/Competitive");
			DeleteDirectoryIfExists(Application.persistentDataPath + "/Saves/Creative");
			DeleteDirectoryIfExists(Application.persistentDataPath + "/Saves/Competitive");
			DeleteDirectoryIfExists(Application.persistentDataPath + "/Saves/Campaign");
			DeleteDirectoryIfExists(Application.persistentDataPath + "/Saves/Tutorial");
		}

		public void OnApplicationQuit()
		{
			RuntimeGlobals.Settings.Save();
			StoreSaveGame(false, true, false);
		}

		public static List<SaveData> GetAllSaves()
		{
			List<SaveData> list = new List<SaveData>();
			foreach (string item in Directory.GetFiles(SavefileFolderPath, "*" + SavefileExtension).OrderByDescending(File.GetLastWriteTimeUtc))
			{
				try
				{
					SaveData saveData = SaveData.ExtractFromSavefile(item);
					if (saveData != null)
					{
						list.Add(saveData);
					}
				}
				catch (Exception exception)
				{
					Debug.LogError("Could not load savefile" + item);
					Debug.LogException(exception);
				}
			}
			return list;
		}

		public static void DeleteSave(SaveData save)
		{
			if (File.Exists(save.FilePath))
			{
				File.Delete(save.FilePath);
			}
		}

		public static void Reset()
		{
			LoadedSave = null;
		}

		public static void ResetAndDeleteCurrentSave()
		{
			DeleteSave(LoadedSave);
			LoadedSave = null;
		}

		private static void DeleteDirectoryIfExists(string path)
		{
			try
			{
				if (Directory.Exists(path))
				{
					Directory.Delete(path, true);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public static void LoadSaveGame(SaveData saveData)
		{
			if (LoadedSave != null)
			{
				StoreSaveGame(false, true);
			}
			CleanUpDataFolder();
			LoadedSave = saveData;
			ExtractZipIntoFolder(saveData.FilePath, ActiveDataFolderPath);
			RuntimeGlobals.GameMode = saveData.Mode;
			RuntimeGlobals.GameModeSettings = saveData.Settings;
			RuntimeGlobals.GameModeSettings.ValidateSettingsAfterLoad(saveData.Mode);
			GameLoaded.Invoke();
			_startTime = Time.time;
		}

		public static void StartEmptyGame(EGameMode mode)
		{
			if (LoadedSave != null)
			{
				StoreSaveGame(false, true);
			}
			SaveData obj = (LoadedSave = CreateNewSaveGame("", mode, EGameModeDifficulty.None));
			CleanUpDataFolder();
			RuntimeGlobals.GameMode = obj.Mode;
			RuntimeGlobals.GameModeSettings = obj.Settings;
			GameLoaded.Invoke();
			_startTime = Time.time;
		}

		public static void StoreSaveGame(bool incremental, bool reset, bool updateSaveFileTime = true)
		{
			if (LoadedSave == null)
			{
				return;
			}
			if (LoadedSave.Mode == EGameMode.Tutorial || LoadedSave.Mode == EGameMode.Competitive || LoadedSave.Mode == EGameMode.Demo)
			{
				if (reset)
				{
					LoadedSave = null;
					CleanUpDataFolder();
				}
				return;
			}
			if (!incremental)
			{
				GameSaved.Invoke();
			}
			float num = Time.time - _startTime;
			string filePath = LoadedSave.FilePath;
			string text = LoadedSave.FilePath + "_backup";
			if (File.Exists(LoadedSave.FilePath))
			{
				File.Move(LoadedSave.FilePath, text);
			}
			try
			{
				CompressFolder(filePath, ActiveDataFolderPath);
				if (File.Exists(text))
				{
					File.Delete(text);
				}
			}
			catch (Exception)
			{
				if (File.Exists(text))
				{
					File.Move(text, LoadedSave.FilePath);
				}
			}
			try
			{
				LoadedSave.LastPlayedTime = DateTime.Now;
			}
			catch (TimeZoneNotFoundException)
			{
				LoadedSave.LastPlayedTime = DateTime.UtcNow;
			}
			LoadedSave.TimePlayed += num;
			LoadedSave.StoreIntoSavefile();
			if (reset)
			{
				LoadedSave = null;
				CleanUpDataFolder();
			}
		}

		public static SaveData CreateNewSaveGame(string saveName, EGameMode mode, EGameModeDifficulty difficulty)
		{
			return new SaveData(saveName, mode, difficulty, Path.Combine(SavefileFolderPath, string.Concat(Guid.NewGuid(), SavefileExtension)));
		}

		public static string GetActiveDroneFolderPath()
		{
			if (LoadedSave != null && !LoadedSave.Settings.SharedDroneList)
			{
				return ActiveDataFolderPath;
			}
			return ActiveDroneFolderPath;
		}

		public static void RestoreDronesFromOldSaves(string oldPath)
		{
			if (!Directory.Exists(oldPath))
			{
				return;
			}
			string text = Path.Combine(oldPath, "Temp");
			if (Directory.Exists(text))
			{
				try
				{
					Directory.Delete(text, true);
				}
				catch (Exception message)
				{
					Debug.Log(message);
				}
			}
			string[] files = Directory.GetFiles(oldPath, "*.nSave");
			foreach (string text2 in files)
			{
				Directory.CreateDirectory(text);
				string text3 = Application.persistentDataPath + "/Saves/Drones";
				if (!Directory.Exists(text3))
				{
					Directory.CreateDirectory(text3);
				}
				ExtractZipIntoFolder(text2, text);
				foreach (FileInfo item in new DirectoryInfo(text).GetFiles("*.drn").ToList())
				{
					string text4 = Path.Combine(text3, item.Name);
					if (!File.Exists(text4))
					{
						File.Copy(item.FullName, text4);
					}
				}
				try
				{
					File.Delete(text2);
					File.Delete(text2 + ".Meta");
					Directory.Delete(text, true);
				}
				catch
				{
				}
			}
		}

		public static void ExportDronesToGlobalList()
		{
			if (!Directory.Exists(ActiveDataFolderPath) || (LoadedSave != null && LoadedSave.Settings.SharedDroneList))
			{
				return;
			}
			foreach (FileInfo item in new DirectoryInfo(ActiveDataFolderPath).GetFiles("*.drn").ToList())
			{
				string text = Path.Combine(ActiveDroneFolderPath, item.Name);
				if (!File.Exists(text))
				{
					File.Copy(item.FullName, text);
				}
			}
		}

		private static void ExtractZipIntoFolder(string saveFilePath, string folderPath)
		{
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}
			if (File.Exists(saveFilePath))
			{
				ZipHelper.ExtractZipFile(saveFilePath, folderPath);
			}
		}

		private static void CompressFolder(string saveFilePath, string saveGameFolderPath)
		{
			ZipHelper.CompressFolder(saveGameFolderPath, saveFilePath);
		}

		private static void CleanUpDataFolder()
		{
			if (Directory.Exists(ActiveDataFolderPath))
			{
				Directory.Delete(ActiveDataFolderPath, true);
			}
			Directory.CreateDirectory(ActiveDataFolderPath);
		}

		public static float GetTotalPlaytime()
		{
			float num = 0f;
			foreach (SaveData item in from s in GetAllSaves()
				where s != null
				select s)
			{
				num += item.TimePlayed;
			}
			return num;
		}

		public static bool IsCompatible(string version)
		{
			Version version2 = new Version(version);
			Version version3 = new Version(LatestCompatibleVersion);
			Version version4 = new Version(CurrentGameVersion);
			int num = version3.CompareTo(version2);
			if (version2 > version4)
			{
				return false;
			}
			return num <= 0;
		}

		public static bool IsLoadedVersionEqualOrHigher(string version)
		{
			if (LoadedSave == null)
			{
				return true;
			}
			Version version2 = new Version(version);
			Version value = new Version(LoadedSave.SaveGameVersion);
			return version2.CompareTo(value) <= 0;
		}
	}
}
