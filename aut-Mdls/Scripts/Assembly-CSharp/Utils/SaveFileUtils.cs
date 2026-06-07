#define ENABLE_DEBUG_WARNINGS
#define ENABLE_DEBUG_LOGS
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data.SaveData;
using Data.SaveData.PersistentSOs;
using UnityEngine;

namespace Utils
{
	[CreateAssetMenu(menuName = "Utils/SaveFileUtilsSO", fileName = "SaveFileUtilsSO", order = 0)]
	public class SaveFileUtils : ScriptableObject
	{
		[SerializeField]
		private PersistentSOLibrary _persistentSoLibrary;

		[SerializeField]
		private SaveInfoPersistentSO _saveInfoPersistentSo;

		public int GetSaveFileCountInDirectory(string directory)
		{
			return new DirectoryInfo(directory).GetDirectories().Length;
		}

		public List<SaveFile> GetSaveFilesInDirectory(string directory, bool useBackupIfNeeded = false)
		{
			List<SaveFile> list = new List<SaveFile>();
			DirectoryInfo[] directories = new DirectoryInfo(directory).GetDirectories();
			for (int i = 0; i < directories.Length; i++)
			{
				if (useBackupIfNeeded && SteamManager.Initialized)
				{
					if (!File.Exists(directories[i].FullName + "/level.json"))
					{
						string[] array = directories[i].FullName.Split('/', '\\');
						string text = SaveSystem.GameSaveBackupPath + "/" + array[^1];
						if (!Directory.Exists(text))
						{
							this.Log("Found no backup for " + directories[i].FullName + ", skipping", "GetSaveFilesInDirectory", 52);
							continue;
						}
						if (Directory.Exists(directories[i].FullName))
						{
							Directory.Delete(directories[i].FullName, recursive: true);
						}
						FileUtils.CopyDirectoryTo(text, directories[i].FullName, recursive: true);
						this.Log("Found backup, copying " + text, "GetSaveFilesInDirectory", 48);
					}
				}
				else if (!SteamManager.Initialized)
				{
					this.LogWarning("Steam not initialized, cannot check local backups via steam user ID", "GetSaveFilesInDirectory", 59);
				}
				if (TryGetSaveFile(directories[i].Name, directories[i].FullName, out var outSaveFile))
				{
					list.Add(outSaveFile);
				}
			}
			return list.OrderByDescending((SaveFile s) => s.Info).ToList();
		}

		public bool TryGetSaveFile(string saveName, string savePath, out SaveFile outSaveFile)
		{
			string directoryPath = savePath + "/PersistentSOs";
			if (_persistentSoLibrary.LoadCopyOfPersistentSO(directoryPath, _saveInfoPersistentSo, out var outCopy))
			{
				outSaveFile = new SaveFile(saveName, savePath, (SaveInfoPersistentSO)outCopy);
				outSaveFile.Info.SetSupported(SaveDirectoryVersionsHandler.CanHandle(outSaveFile));
				outSaveFile.Info.SetIsMapOld(GetMapGuid(outSaveFile.Info.MapName));
				return true;
			}
			outSaveFile = default(SaveFile);
			return false;
		}

		public List<SaveFile> GetSaveFiles()
		{
			return GetSaveFilesInDirectory(SaveSystem.CreateFullPath(SaveSystem.GetFullSavePathForFileName("Levels")));
		}

		public List<SaveFile> GetSaveFilesOrBackup()
		{
			CopyAutoSaveFromBackupIfNecessary();
			return GetSaveFilesInDirectory(SaveSystem.CreateFullPath(SaveSystem.GetFullSavePathForFileName("Levels")), useBackupIfNeeded: true);
		}

		public List<SaveFile> GetDevSaveFiles()
		{
			return GetSaveFilesInDirectory(SaveSystem.CreateFullPath(SaveSystem.GetFullStreamingAssetPathForFileName("Levels")));
		}

		public Guid GetMapGuid(string mapName)
		{
			string directoryPath = SaveSystem.CreateFullLevelsStreamingAssetPath(mapName) + "/PersistentSOs";
			_persistentSoLibrary.LoadCopyOfPersistentSO(directoryPath, _saveInfoPersistentSo, out var outCopy);
			return (outCopy as SaveInfoPersistentSO).MapGuid;
		}

		public void CopyAutoSaveFromBackupIfNecessary()
		{
			if (!SteamManager.Initialized)
			{
				this.LogWarning("Steam not initialized, cannot check local backups via steam user ID", "CopyAutoSaveFromBackupIfNecessary", 119);
			}
			else
			{
				if (!File.Exists(SaveSystem.AutoSavePath) || File.Exists(SaveSystem.AutoSavePath + "/level.json"))
				{
					return;
				}
				string text = SaveSystem.GameSaveBackupPath + "/AutoSave";
				if (Directory.Exists(text))
				{
					if (Directory.Exists(SaveSystem.AutoSavePath))
					{
						Directory.Delete(SaveSystem.AutoSavePath, recursive: true);
					}
					FileUtils.CopyDirectoryTo(text, SaveSystem.AutoSavePath, recursive: true);
					this.Log("Found autosave backup, copying " + text, "CopyAutoSaveFromBackupIfNecessary", 135);
				}
			}
		}
	}
}
