using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class Saver
{
	private static FileSystemWatcher watcher;

	private static List<(string, string)> codeToUpdate = new List<(string, string)>();

	private static object codeToUpdateLock = new object();

	private const int version = 3;

	public static void Save(MainSim mainSim)
	{
		SaveProgress(mainSim);
		SaveCode(mainSim);
	}

	public static void SaveProgress(MainSim mainSim)
	{
		if (!(mainSim == null))
		{
			bool num = mainSim.MightBeSimulating();
			SaveGame saveGame = new SaveGame();
			if (num)
			{
				saveGame.items = new ItemBlock(mainSim.storedSim.farm.Items);
			}
			else
			{
				saveGame.items = mainSim.GetInventory();
			}
			saveGame.items.Serialize();
			Vector2 farmPos = ((RectTransform)mainSim.workspace.container.GetChild(0)).anchoredPosition;
			Dictionary<string, Window>.ValueCollection values = mainSim.workspace.openWindows.Values;
			saveGame.openFilePositions = values.Select((Window f) => new Pair<string, Vector2>(f.windowName, ((RectTransform)f.transform).anchoredPosition - farmPos)).ToList();
			saveGame.openFileSizes = values.Select((Window f) => new Pair<string, Vector2>(f.windowName, f.playerSetSize)).ToList();
			saveGame.openFileScrollPositions = (from w in values
				where w.TryGetComponent<CodeWindow>(out var _)
				select new Pair<string, float>(w.windowName, ((RectTransform)w.GetComponent<CodeWindow>().CodeInput.transform).anchoredPosition.y)).ToList();
			saveGame.dockedFiles = (from f in values
				where f.dockedParent != null
				select new Pair<string, string>(f.windowName, f.dockedParent.windowName)).ToList();
			saveGame.minimizedFiles = (from f in values
				where f.isMinimized
				select f.windowName).ToList();
			saveGame.openDocPages = (from w in values
				where w.GetComponent<DocsWindow>() != null
				select new Pair<string, string>(w.windowName, w.GetComponent<DocsWindow>().openDoc)).ToList();
			if (num)
			{
				saveGame.unlocks = mainSim.storedSim.farm.SerializeUnlocks();
			}
			else
			{
				saveGame.unlocks = mainSim.GetSerializedUnlocks();
			}
			saveGame.version = 3;
			string text = OptionHolder.GetString("activeSave", "Save0");
			try
			{
				string backupPath = CreateBackupPath(text);
				string pathOfSaveDirectory = GetPathOfSaveDirectory(text);
				WriteSaveGame(saveGame, pathOfSaveDirectory, backupPath);
			}
			catch (IOException ex)
			{
				Debug.LogError(ex.Message);
				List<WarningPopup.ButtonData> buttonsToAdd = new List<WarningPopup.ButtonData>
				{
					new WarningPopup.ButtonData("ok", mainSim.warningPopup.Close)
				};
				mainSim.warningPopup.ShowPopup(CodeUtilities.LocalizeAndFormat("popup_warning_failed_write_save", text), buttonsToAdd);
			}
			mainSim.dirty = false;
		}
	}

	public static void SaveCode(MainSim mainSim)
	{
		string text = OptionHolder.GetString("activeSave", "Save0");
		try
		{
			string backupPath = CreateBackupPath(text);
			string pathOfSaveDirectory = GetPathOfSaveDirectory(text);
			WriteCodeFiles(mainSim.workspace, pathOfSaveDirectory, backupPath);
		}
		catch (IOException ex)
		{
			Debug.LogError(ex.Message);
			List<WarningPopup.ButtonData> buttonsToAdd = new List<WarningPopup.ButtonData>
			{
				new WarningPopup.ButtonData("ok", mainSim.warningPopup.Close)
			};
			mainSim.warningPopup.ShowPopup(CodeUtilities.LocalizeAndFormat("popup_warning_failed_write_save", text), buttonsToAdd);
		}
	}

	private static void WriteSaveGame(SaveGame sg, string savePath, string backupPath)
	{
		string content = JsonUtility.ToJson(sg);
		FileInfo destinationFile = new FileInfo(savePath + "/save.json");
		WriteFilesSafely(new FileInfo(backupPath + "/save.json"), destinationFile, content);
	}

	private static void WriteCodeFiles(Workspace workspace, string savePath, string backupPath)
	{
		foreach (CodeWindow value in workspace.codeWindows.Values)
		{
			FileInfo destinationFile = new FileInfo($"{savePath}/{value.fileName}.py");
			WriteFilesSafely(new FileInfo($"{backupPath}/{value.fileName}.py"), destinationFile, value.CodeInput.text);
		}
		foreach (string item in from f in Directory.GetFiles(savePath)
			where Path.GetExtension(f) == ".py" && !workspace.openWindows.ContainsKey(Path.GetFileNameWithoutExtension(f)) && !f.EndsWith("__builtins__.py")
			select f)
		{
			try
			{
				File.Delete(item);
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.Message);
			}
		}
		FileInfo fileInfo = new FileInfo(savePath + "/__builtins__.py");
		if (!fileInfo.Exists)
		{
			string contents = Localizer.LoadBuiltins();
			try
			{
				File.WriteAllText(fileInfo.FullName, contents);
			}
			catch (Exception ex2)
			{
				Debug.LogError(ex2.Message);
			}
		}
	}

	private static string CreateBackupPath(string fileName)
	{
		string text = Helper.persistentDataPath + "/Backup";
		Directory.CreateDirectory(text);
		List<(int, string)> list = Directory.GetDirectories(text, fileName + "*", SearchOption.TopDirectoryOnly).Select(delegate(string s)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(s);
			int num7 = fileName.Length + "_backup".Length;
			if (directoryInfo.Name.Length <= num7)
			{
				return (0, "");
			}
			int result;
			return int.TryParse(directoryInfo.Name.Substring(num7), out result) ? (result, s) : (0, "");
		}).ToList();
		list.Sort();
		while (true)
		{
			int num = -1;
			int num2 = int.MaxValue;
			int num3 = int.MaxValue;
			for (int num4 = 1; num4 < list.Count; num4++)
			{
				int num5 = list[num4].Item1 - list[num4 - 1].Item1;
				if (num3 <= num5 && num3 <= num2)
				{
					num = num4 - 2;
					break;
				}
				num3 = num2;
				num2 = num5;
			}
			if (num < 0)
			{
				break;
			}
			try
			{
				Directory.Delete(list[num].Item2, recursive: true);
			}
			catch (Exception)
			{
			}
			list.RemoveAt(num);
		}
		int num6 = ((list.Count > 0) ? (list.Last().Item1 + 1) : 0);
		return $"{text}/{fileName}_backup{num6}";
	}

	private static void WriteFilesSafely(FileInfo backupFile, FileInfo destinationFile, string content)
	{
		backupFile.Directory.Create();
		destinationFile.Directory.Create();
		try
		{
			File.WriteAllText(backupFile.FullName, content);
			File.Copy(backupFile.FullName, destinationFile.FullName, overwrite: true);
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
		}
	}

	public static void Load(MainSim mainSim)
	{
		SaveGame currentSaveGame = GetCurrentSaveGame();
		if (currentSaveGame != null)
		{
			currentSaveGame.items.Deserialize();
			mainSim.SetupSim(currentSaveGame.unlocks, new ItemBlock(currentSaveGame.items), null, null, currentSaveGame.version < 3);
			Vector2 anchoredPosition = ((RectTransform)mainSim.workspace.container.GetChild(0)).anchoredPosition;
			DirectoryInfo directoryInfo = new DirectoryInfo(GetPathOfSaveDirectory(OptionHolder.GetString("activeSave", "Save0")));
			directoryInfo.Create();
			IEnumerable<string> source = from f in Directory.GetFiles(directoryInfo.FullName)
				where Path.GetExtension(f) == ".py" && Path.GetFileName(f) != "__builtins__.py"
				select f;
			IEnumerable<string> first = source.Select((string f) => Path.GetFileNameWithoutExtension(f));
			IEnumerable<string> second = source.Select((string f) => File.ReadAllText(f).Replace("\r", ""));
			Dictionary<string, Vector2> dictionary = currentSaveGame.openFilePositions.ToDictionary((Pair<string, Vector2> x) => x.key, (Pair<string, Vector2> x) => x.value);
			Dictionary<string, Vector2> dictionary2 = currentSaveGame.openFileSizes.ToDictionary((Pair<string, Vector2> x) => x.key, (Pair<string, Vector2> x) => x.value);
			foreach (var item in first.Zip(second, (string file, string code) => (file: file, code: code)))
			{
				mainSim.workspace.OpenCodeWindow(item.file, item.code, dictionary.GetValueOrDefault(item.file) + anchoredPosition, dictionary2.GetValueOrDefault(item.file));
			}
			foreach (Pair<string, string> openDocPage in currentSaveGame.openDocPages)
			{
				mainSim.workspace.OpenDocsWindow(openDocPage.key, openDocPage.value, dictionary.GetValueOrDefault(openDocPage.key) + anchoredPosition, dictionary2.GetValueOrDefault(openDocPage.key));
			}
			foreach (Pair<string, float> openFileScrollPosition in currentSaveGame.openFileScrollPositions)
			{
				if (mainSim.workspace.openWindows.TryGetValue(openFileScrollPosition.key, out var value) && value.TryGetComponent<CodeWindow>(out var component))
				{
					((RectTransform)component.CodeInput.transform).anchoredPosition += new Vector2(0f, openFileScrollPosition.value);
				}
			}
			foreach (string minimizedFile in currentSaveGame.minimizedFiles)
			{
				if (mainSim.workspace.openWindows.ContainsKey(minimizedFile))
				{
					mainSim.workspace.openWindows[minimizedFile].SetMinmized(minimized: true);
				}
			}
			for (int num = 0; num < currentSaveGame.dockedFiles.Count; num++)
			{
				if (mainSim.workspace.openWindows.ContainsKey(currentSaveGame.dockedFiles[num].key) && mainSim.workspace.openWindows.ContainsKey(currentSaveGame.dockedFiles[num].value))
				{
					Window component2 = mainSim.workspace.openWindows[currentSaveGame.dockedFiles[num].value].GetComponent<Window>();
					mainSim.workspace.openWindows[currentSaveGame.dockedFiles[num].key].GetComponent<Window>()?.DockOnto(component2);
				}
			}
			if (currentSaveGame.version < 3)
			{
				mainSim.workspace.AddNewDocsWindow("docs/patchnotes.md");
				List<WarningPopup.ButtonData> buttonsToAdd = new List<WarningPopup.ButtonData>
				{
					new WarningPopup.ButtonData("ok", mainSim.warningPopup.Close)
				};
				mainSim.warningPopup.ShowPopup("popup_warning_old_save", buttonsToAdd);
			}
		}
		else
		{
			mainSim.SetupSim(Enumerable.Empty<string>(), ItemBlock.CreateEmpty());
			mainSim.workspace.OpenCodeWindow("main", "", new Vector2(300f, -150f));
			mainSim.workspace.AddNewDocsWindow("docs/getting_started.md", new Vector2(-300f, 100f));
		}
		mainSim.researchMenu.Setup();
		mainSim.inv.SetUp(mainSim.GetInventory);
		LeanTween.init(1600);
		mainSim.dirty = false;
		StartFileWatcher();
	}

	public static void StartFileWatcher()
	{
		string pathOfSaveDirectory = GetPathOfSaveDirectory(OptionHolder.GetString("activeSave", "Save0"));
		if (!Directory.Exists(pathOfSaveDirectory))
		{
			Directory.CreateDirectory(pathOfSaveDirectory);
		}
		if (watcher != null)
		{
			watcher.Dispose();
		}
		watcher = new FileSystemWatcher(pathOfSaveDirectory);
		watcher.NotifyFilter = watcher.NotifyFilter | NotifyFilters.LastWrite | NotifyFilters.FileName;
		watcher.EnableRaisingEvents = true;
		EnableDisableFileWatcher("file watcher");
		OptionHolder.OnOptionChanged -= EnableDisableFileWatcher;
		OptionHolder.OnOptionChanged += EnableDisableFileWatcher;
	}

	public static void StopFileWatcher()
	{
		if (watcher != null)
		{
			watcher.Dispose();
			watcher = null;
		}
	}

	private static void EnableDisableFileWatcher(string optionName)
	{
		if (optionName == "autosave")
		{
			if (OptionHolder.GetString("autosave") == "enabled" && OptionHolder.GetString("file watcher") == "enabled")
			{
				OptionHolder.SetOption("file watcher", "disabled");
			}
		}
		else
		{
			if (optionName != "file watcher")
			{
				return;
			}
			if (OptionHolder.GetString("file watcher") == "enabled")
			{
				if (OptionHolder.GetString("autosave") == "enabled")
				{
					OptionHolder.SetOption("autosave", "disabled");
				}
				watcher.Changed -= OnFileChanged;
				watcher.Changed += OnFileChanged;
			}
			else
			{
				watcher.Changed -= OnFileChanged;
			}
		}
	}

	private static void OnFileChanged(object sender, FileSystemEventArgs e)
	{
		if (!e.Name.EndsWith(".py"))
		{
			return;
		}
		string item = e.Name.Substring(0, e.Name.Length - 3);
		lock (codeToUpdateLock)
		{
			codeToUpdate.Add((item, File.ReadAllText(e.FullPath)));
		}
	}

	public static void ApplyCodeChanges(Workspace workspace)
	{
		if (codeToUpdate.Count <= 0)
		{
			return;
		}
		lock (codeToUpdateLock)
		{
			foreach (var item in codeToUpdate)
			{
				if (workspace.codeWindows.TryGetValue(item.Item1, out var value))
				{
					value.CodeInput.text = item.Item2;
				}
			}
			codeToUpdate.Clear();
		}
	}

	public static void UpdateFromOldSaveGame(OldSaveGame oldSaveGame)
	{
		string text = OptionHolder.GetString("activeSave", "Save0");
		SaveGame saveGame = new SaveGame();
		saveGame.unlocks = oldSaveGame.unlocks;
		saveGame.items = oldSaveGame.items;
		saveGame.openDocPages = new List<Pair<string, string>>();
		saveGame.minimizedFiles = oldSaveGame.minimized;
		saveGame.openFilePositions = new List<Pair<string, Vector2>>();
		saveGame.openFileSizes = new List<Pair<string, Vector2>>();
		saveGame.dockedFiles = new List<Pair<string, string>>();
		for (int i = 0; i < oldSaveGame.functionNames.Count; i++)
		{
			FileInfo fileInfo = new FileInfo(Helper.persistentDataPath + $"/Saves/{text}/{oldSaveGame.functionNames[i]}.py");
			fileInfo.Directory.Create();
			File.WriteAllText(fileInfo.FullName, oldSaveGame.functionCode[i]);
			saveGame.openFilePositions.Add(new Pair<string, Vector2>(oldSaveGame.functionNames[i], oldSaveGame.openFunctionPositions[i]));
			if (i < oldSaveGame.functionDocked.Count && oldSaveGame.functionDocked[i] != "")
			{
				saveGame.dockedFiles.Add(new Pair<string, string>(oldSaveGame.functionNames[i], oldSaveGame.functionDocked[i]));
			}
		}
		_ = Helper.persistentDataPath + "/Backup";
		WriteSaveGame(saveGame, GetPathOfSaveDirectory(text), CreateBackupPath(text));
	}

	private static SaveGame GetCurrentSaveGame()
	{
		string currentSaveGameJson = GetCurrentSaveGameJson();
		if (!string.IsNullOrEmpty(currentSaveGameJson))
		{
			SaveGame saveGame = JsonUtility.FromJson<SaveGame>(currentSaveGameJson);
			if (saveGame.openFilePositions.Count > 0)
			{
				return saveGame;
			}
			OldSaveGame oldSaveGame = JsonUtility.FromJson<OldSaveGame>(currentSaveGameJson);
			if (oldSaveGame.functionNames.Count > 0)
			{
				UpdateFromOldSaveGame(oldSaveGame);
				currentSaveGameJson = GetCurrentSaveGameJson();
				return JsonUtility.FromJson<SaveGame>(currentSaveGameJson);
			}
			if (saveGame.unlocks.Count > 0 || !saveGame.items.IsEmpty())
			{
				return saveGame;
			}
			return null;
		}
		return null;
	}

	private static string GetCurrentSaveGameJson()
	{
		string saveName = OptionHolder.GetString("activeSave", "Save0");
		FileInfo fileInfo = new FileInfo(GetPathOfSaveFile(saveName));
		if (!File.Exists(fileInfo.FullName))
		{
			CreateNewSaveGame(saveName);
		}
		return File.ReadAllText(fileInfo.FullName);
	}

	public static bool RenameSave(string saveName, string newSaveName)
	{
		if (string.IsNullOrEmpty(newSaveName) || newSaveName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0 || Directory.Exists(GetPathOfSaveDirectory(newSaveName)))
		{
			return false;
		}
		try
		{
			Directory.Move(GetPathOfSaveDirectory(saveName), GetPathOfSaveDirectory(newSaveName));
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	public static bool DeleteSave(string saveName)
	{
		try
		{
			Directory.Delete(GetPathOfSaveDirectory(saveName), recursive: true);
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	public static void CreateNewSaveGame(string saveName)
	{
		FileInfo fileInfo = new FileInfo(GetPathOfSaveFile(saveName));
		if (!fileInfo.Exists)
		{
			Directory.CreateDirectory(fileInfo.Directory.FullName);
		}
		File.Create(fileInfo.FullName).Dispose();
		new DirectoryInfo(GetPathOfSaveDirectory(saveName)).Create();
	}

	public static string GetPathOfSaveFile(string saveName)
	{
		string text = $"{Helper.persistentDataPath}/Saves/{saveName}/save.json";
		if (!File.Exists(text))
		{
			text = $"{Helper.persistentDataPath}/Saves/{saveName}.json";
		}
		return text;
	}

	public static string GetPathOfSaveDirectory(string saveName)
	{
		return $"{Helper.persistentDataPath}/Saves/{saveName}";
	}
}
