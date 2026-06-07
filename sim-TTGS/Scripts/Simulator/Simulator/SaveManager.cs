using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using Dhs5.Utility.Updates;
using Simulator.GameWorld;
using Steamworks;
using UnityEngine;

namespace Simulator
{
	public static class SaveManager
	{
		private const string SaveDirectoryName = "Saves";

		private const string SaveFilePrefix = "SAVE_";

		private const string TextExtension = ".txt";

		private const string ArchiveEntryName = "save";

		private static List<SaveFileInfo> m_saveFiles = new List<SaveFileInfo>();

		private static string SaveDirectoryPath => Application.persistentDataPath + "/Saves/";

		private static string GuestSaveDirectoryPath => Application.persistentDataPath + "/Saves/Guest/";

		private static DirectoryInfo SaveDirectoryInfo { get; set; }

		public static int SaveFilesCount => m_saveFiles.Count;

		private static string SelectedSaveFile { get; set; }

		public static Save CurrentSave { get; private set; }

		public static ISaveManagerModifier Modifier { get; set; }

		private static void GetOrCreateSaveDirectory()
		{
			if (SaveDirectoryInfo != null)
			{
				return;
			}
			if (!Directory.Exists(SaveDirectoryPath))
			{
				Directory.CreateDirectory(SaveDirectoryPath);
			}
			string path = GuestSaveDirectoryPath;
			if (SteamManager.Initialized)
			{
				path = SaveDirectoryPath + SteamFriends.GetPersonaName() + "/";
			}
			if (!Directory.Exists(path))
			{
				SaveDirectoryInfo = Directory.CreateDirectory(path);
			}
			else
			{
				SaveDirectoryInfo = Directory.GetParent(path);
			}
			Debug.Log(SaveDirectoryInfo.FullName);
			DirectoryInfo parent = Directory.GetParent(SaveDirectoryPath);
			if (parent == null)
			{
				return;
			}
			foreach (FileInfo item in parent.EnumerateFiles())
			{
				if (item.Exists && item.Name.StartsWith("SAVE_"))
				{
					string saveFileFullName = GetSaveFileFullName(GetSaveFilenameFromFileInfo(item));
					if (!File.Exists(saveFileFullName))
					{
						Debug.Log("move " + item.FullName + " to " + saveFileFullName);
						item.MoveTo(saveFileFullName);
					}
				}
			}
		}

		private static void FetchSaveFiles()
		{
			if (SaveDirectoryInfo == null)
			{
				return;
			}
			m_saveFiles.Clear();
			foreach (FileInfo item3 in SaveDirectoryInfo.EnumerateFiles())
			{
				if (!item3.Exists || !item3.Name.StartsWith("SAVE_"))
				{
					continue;
				}
				if (string.IsNullOrEmpty(item3.Extension))
				{
					SaveFileInfo item = new SaveFileInfo(item3);
					if (item.isValid)
					{
						m_saveFiles.Add(item);
					}
				}
				else if (item3.Extension == ".txt")
				{
					string path = item3.FullName.Replace(".txt", "");
					string content = File.ReadAllText(item3.FullName);
					item3.Delete();
					FileInfo fileInfo = CreateNewSaveFile(path, content, setCurrent: false);
					SaveFileInfo item2 = new SaveFileInfo(fileInfo);
					if (item2.isValid)
					{
						m_saveFiles.Add(item2);
					}
				}
			}
			m_saveFiles.Sort((SaveFileInfo f1, SaveFileInfo f2) => -f1.fileInfo.LastWriteTime.CompareTo(f2.fileInfo.LastWriteTime));
		}

		private static FileInfo CreateNewSaveFile(string content)
		{
			DateTime now = DateTime.Now;
			return CreateNewSaveFile(GetSaveFileFullName(now.Year.ToString() + now.Month + now.Day + now.Hour + now.Minute + now.Second), content, setCurrent: true);
		}

		private static FileInfo CreateNewSaveFile(string path, string content, bool setCurrent)
		{
			if (!File.Exists(path))
			{
				using ZipArchive zipArchive = ZipFile.Open(path, ZipArchiveMode.Create);
				using Stream stream = zipArchive.CreateEntry("save").Open();
				stream.Write(Encoding.ASCII.GetBytes(content));
			}
			FileInfo fileInfo = new FileInfo(path);
			if (setCurrent)
			{
				SetCurrentSaveFile(fileInfo);
			}
			Debug.Log("New save file :\n" + fileInfo.FullName);
			return fileInfo;
		}

		private static bool ReadSaveFile(string path, out string content)
		{
			content = null;
			if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
			{
				if (path.EndsWith(".txt"))
				{
					Debug.Log("The file at this path is a text, " + path);
					content = File.ReadAllText(path);
				}
				else
				{
					using FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
					using ZipArchive zipArchive = new ZipArchive(stream, ZipArchiveMode.Read);
					ZipArchiveEntry entry = zipArchive.GetEntry("save");
					if (entry != null)
					{
						using Stream stream2 = entry.Open();
						using MemoryStream memoryStream = new MemoryStream();
						stream2.CopyTo(memoryStream);
						content = Encoding.ASCII.GetString(memoryStream.ToArray());
					}
				}
				if (!string.IsNullOrWhiteSpace(content) && content.StartsWith('{'))
				{
					return content.EndsWith('}');
				}
				return false;
			}
			return false;
		}

		private static bool WriteSaveFile(string path, string content)
		{
			if (!string.IsNullOrWhiteSpace(path))
			{
				using (ZipArchive zipArchive = ZipFile.Open(path, ZipArchiveMode.Update))
				{
					zipArchive.GetEntry("save")?.Delete();
					using Stream stream = zipArchive.CreateEntry("save").Open();
					stream.Write(Encoding.ASCII.GetBytes(content));
				}
				return true;
			}
			return false;
		}

		private static bool DeleteSaveFile(string path)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
				return true;
			}
			return false;
		}

		private static bool RenameSaveFile(string path, string newName)
		{
			if (File.Exists(path))
			{
				string saveFileFullName = GetSaveFileFullName(newName);
				if (!File.Exists(saveFileFullName))
				{
					File.Move(path, saveFileFullName);
					return true;
				}
			}
			return false;
		}

		private static void Refresh()
		{
			GetOrCreateSaveDirectory();
			FetchSaveFiles();
		}

		public static IEnumerable<SaveFileInfo> GetSaveFilesInfos()
		{
			Refresh();
			if (!m_saveFiles.IsValid())
			{
				yield break;
			}
			foreach (SaveFileInfo saveFile in m_saveFiles)
			{
				yield return saveFile;
			}
		}

		public static void SetCurrentSaveFile(FileInfo fileInfo)
		{
			if (fileInfo == null)
			{
				SelectedSaveFile = null;
			}
			else
			{
				SelectedSaveFile = fileInfo.FullName;
			}
		}

		private static int GetAutoSaveFileCount()
		{
			int num = 0;
			foreach (SaveFileInfo saveFilesInfo in GetSaveFilesInfos())
			{
				if (saveFilesInfo.saveType == ESaveType.AUTO)
				{
					num++;
				}
			}
			return num;
		}

		private static void DeleteOldestAutoSave()
		{
			for (int num = m_saveFiles.Count - 1; num >= 0; num--)
			{
				SaveFileInfo saveFileInfo = m_saveFiles[num];
				if (saveFileInfo.saveType == ESaveType.AUTO)
				{
					DeleteSaveFile(saveFileInfo.fileInfo.FullName);
					break;
				}
			}
		}

		private static bool GetQuickSave(out SaveFileInfo saveFileInfo)
		{
			foreach (SaveFileInfo saveFilesInfo in GetSaveFilesInfos())
			{
				if (saveFilesInfo.saveType == ESaveType.QUICK)
				{
					saveFileInfo = saveFilesInfo;
					return true;
				}
			}
			saveFileInfo = default(SaveFileInfo);
			return false;
		}

		private static string GetSaveFileFullName(string filename)
		{
			return SaveDirectoryInfo.FullName + "/SAVE_" + filename;
		}

		public static string GetSaveFilenameFromFileInfo(FileInfo fileInfo)
		{
			string text = fileInfo.Name;
			if (!string.IsNullOrWhiteSpace(fileInfo.Extension))
			{
				text = text.Replace(fileInfo.Extension, "");
			}
			return text.Replace("SAVE_", "");
		}

		public static bool HasSaveFile()
		{
			return GetSaveFilesInfos()?.Any() ?? false;
		}

		public static SaveFileInfo GetLastSaveFill()
		{
			return GetSaveFilesInfos().First();
		}

		public static T GetCurrentSaveAs<T>() where T : Save
		{
			if (CurrentSave is T result)
			{
				return result;
			}
			return null;
		}

		public static bool QuickLoad()
		{
			if (World.Loaded && World.Playing && GetQuickSave(out var saveFileInfo) && LoadSave(saveFileInfo.fileInfo.FullName, out var save))
			{
				CurrentSave = save;
				World.Quit();
				TransientManager<SceneManager>.Instance.ReloadScene(SceneManager.Map.WORLD);
				return true;
			}
			return false;
		}

		public static void LoadSelectedSave()
		{
			Refresh();
			if (LoadSave(SelectedSaveFile, out var save))
			{
				CurrentSave = save;
			}
			else
			{
				CurrentSave = ((Modifier != null) ? Modifier.CreateSave() : new Save());
			}
		}

		public static bool LoadSave(string path, out Save save)
		{
			if (ReadSaveFile(path, out var content))
			{
				try
				{
					save = ((Modifier != null) ? Modifier.ReadSaveFromFile(content) : JsonUtility.FromJson<Save>(content));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					save = null;
				}
				return save != null;
			}
			save = null;
			return false;
		}

		public static void AutoSaveAfterClassicUpdate()
		{
			Updater.OneShotAfterClassicUpdate += AutoSave;
		}

		private static void AutoSave()
		{
			float num = Mathf.Max(0f, (float)GetAutoSaveFileCount() - (float)GameplayApplicationOptions.AutomaticSaveLimit);
			for (int i = 0; (float)i < num; i++)
			{
				DeleteOldestAutoSave();
			}
			CreateNewSaveFile(GetSaveContent(ESaveType.AUTO));
		}

		public static void QuickSave()
		{
			if (World.Loaded && World.Playing)
			{
				if (GetQuickSave(out var saveFileInfo))
				{
					WriteSaveFile(saveFileInfo.fileInfo.FullName, GetSaveContent(ESaveType.QUICK));
				}
				else
				{
					CreateNewSaveFile(GetSaveContent(ESaveType.QUICK));
				}
			}
		}

		public static void ManualSave()
		{
			if (!string.IsNullOrWhiteSpace(SelectedSaveFile))
			{
				WriteSaveFile(SelectedSaveFile, GetSaveContent(ESaveType.MANUAL));
			}
			else
			{
				CreateNewSaveFile(GetSaveContent(ESaveType.MANUAL));
			}
		}

		private static string GetSaveContent(ESaveType saveType)
		{
			World.Save();
			CurrentSave.saveType = saveType;
			if (Modifier == null)
			{
				return JsonUtility.ToJson(CurrentSave);
			}
			return Modifier.GetSaveContent();
		}

		public static void DeleteSelectedSaveFile()
		{
			DeleteSaveFile(SelectedSaveFile);
		}

		public static void CreateNewEmptySaveFile()
		{
			CreateNewSaveFile("");
		}

		public static void RenameSaveFile(FileInfo fileInfo, string newName)
		{
			RenameSaveFile(fileInfo.FullName, newName);
		}
	}
}
