using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class GameProgressResetter
{
	private static string savegameDirectoryPath => Application.persistentDataPath;

	public static void ResetAndBackupAllGameProgress()
	{
		string text = Path.Combine(savegameDirectoryPath, "Before Reset Backup " + GetTimestamp());
		Directory.CreateDirectory(text);
		DirectoryInfo directoryInfo = new DirectoryInfo(savegameDirectoryPath);
		string[] fileNamesToSkip = GetFileNamesToSkip();
		FileInfo[] files = directoryInfo.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			if (!fileNamesToSkip.Contains(fileInfo.Name))
			{
				try
				{
					fileInfo.CopyTo(Path.Combine(text, fileInfo.Name));
					fileInfo.Delete();
				}
				catch (Exception ex)
				{
					Debug.LogError("The following file could not be copied or deleted: " + text + "/" + fileInfo.Name + " because: " + ex.Message);
				}
			}
		}
		LevelProgressManager.instance.SceneNameToLevelData.Clear();
		if ((bool)PerkManager.instance)
		{
			PerkManager.ClearAllEquipped();
			PerkManager.instance.level = 1;
			PerkManager.instance.xp = 0;
		}
		if (SceneTransitionManager.instance.CurrentSceneState != SceneTransitionManager.SceneState.MainMenu)
		{
			SceneTransitionManager.instance.TransitionToMainMenu();
		}
	}

	public static string[] GetFileNamesToBackUp()
	{
		List<string> list = new List<string>
		{
			SaveLoadManager.instance.SaveFileName,
			"EternalTrials_V4.json",
			"ET_CurrentLevel.json"
		};
		string[] array = Resources.Load<TextAsset>("scenes").text.Split('\n');
		foreach (string text in array)
		{
			list.Add(text + ".json");
		}
		return list.ToArray();
	}

	public static string[] GetFileNamesToSkip()
	{
		return new List<string> { "ControlsConfig_v2.json" }.ToArray();
	}

	public static string GetTimestamp()
	{
		return DateTime.Now.ToString("yyyyMMdd_HHmmss");
	}
}
