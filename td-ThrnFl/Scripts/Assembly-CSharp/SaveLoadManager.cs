using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
	public static SaveLoadManager instance;

	[SerializeField]
	private int saveFileVersionNr = 1;

	[SerializeField]
	private string saveFileName = "ThroneSave.sav";

	private List<string> saveData = new List<string>();

	private string[] loadData;

	private LevelProgressManager levelProgressManager;

	private PerkManager perkManager;

	[SerializeField]
	private List<Equippable> allEquippablesID = new List<Equippable>();

	private int iln;

	private string line;

	private string FullSaveFilePath => Path.Combine(Application.persistentDataPath, saveFileName);

	public string SaveFileName => saveFileName;

	public string GetFullSavePath => FullSaveFilePath;

	private void Awake()
	{
		if ((bool)instance)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		instance = this;
	}

	private void Start()
	{
		LoadGame();
	}

	public void SaveGame()
	{
		if (!DebugController.SaveTheGame)
		{
			DebugLogInEditorOnly("Saving is not enabled!");
			return;
		}
		saveData.Clear();
		levelProgressManager = LevelProgressManager.instance;
		perkManager = PerkManager.instance;
		SaveSingle("Save File Version", saveFileVersionNr.ToString());
		SaveSingle("Perk Level", perkManager.level.ToString());
		SaveSingle("Perk XP", perkManager.xp.ToString());
		SaveSingle("Eternal Trials Score V3", levelProgressManager.EternalTrialsHighscore.ToString());
		SaveList("Tips Shown", levelProgressManager.tipsShown);
		foreach (KeyValuePair<string, LevelData> sceneNameToLevelDatum in levelProgressManager.SceneNameToLevelData)
		{
			string key = sceneNameToLevelDatum.Key;
			LevelData value = sceneNameToLevelDatum.Value;
			if (value.highscoreBest <= 0 && !value.beatenBest)
			{
				continue;
			}
			SaveSingle("Level", key);
			SaveSingle("QuestsCompleteWhenLastOnMap", value.questsCompleteWhenLastVisitingMap.ToString());
			SaveSingle("Beaten", value.beatenBest ? "1" : "0");
			if (value.beatenBest)
			{
				AchievementManager.LevelBeaten(key);
			}
			SaveSingle("HighscoreV2", value.highscoreBest.ToString());
			SaveList("NetworthV2 / Day", value.dayToDayNetworthBest);
			SaveList("ScoreV2 / Day", value.dayToDayScoreBest);
			foreach (List<Equippable> item in value.levelHasBeenBeatenWith)
			{
				List<string> list = new List<string>();
				foreach (Equippable item2 in item)
				{
					if (!(item2 == null))
					{
						list.Add(item2.name);
					}
				}
				SaveList("Beaten With", list);
			}
		}
		SafeFileWriter.FileWriteAllLinesSafe(FullSaveFilePath, saveData);
		DebugLogInEditorOnly("Game Saved to " + FullSaveFilePath);
	}

	public void SaveSingle(string _key, string _data)
	{
		saveData.Add(_key);
		saveData.Add(_data);
		saveData.Add("");
	}

	public void SaveList<Type>(string _key, List<Type> _data)
	{
		saveData.Add(_key);
		saveData.Add(_data.Count.ToString());
		for (int i = 0; i < _data.Count; i++)
		{
			saveData.Add(_data[i].ToString());
		}
		saveData.Add("");
	}

	private void LoadGame()
	{
		levelProgressManager = LevelProgressManager.instance;
		perkManager = PerkManager.instance;
		if (DebugController.SaveLoadModeToUse == DebugController.SaveLoadMode.LoadEmptySaveFileOnStartup)
		{
			loadData = DebugController.instance.emptySaveFile.text.Split(new string[3] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
			DebugLogInEditorOnly("Loading is not enabled!");
		}
		else if (DebugController.SaveLoadModeToUse == DebugController.SaveLoadMode.LoadMaxedOutSaveFileOnStartup)
		{
			loadData = DebugController.instance.maxedSaveFile.text.Split(new string[3] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
			DebugLogInEditorOnly("Loading maxed out save file with everything unlocked!");
		}
		else
		{
			try
			{
				loadData = SafeFileWriter.FileReadAllLinesSafe(FullSaveFilePath);
			}
			catch
			{
				DebugLogInEditorOnly("No save file was found at " + FullSaveFilePath + " so the load process was canceled.");
				return;
			}
		}
		LevelData levelData = null;
		levelProgressManager.SceneNameToLevelData.Clear();
		for (iln = 0; iln < loadData.Length; iln++)
		{
			line = loadData[iln];
			switch (line)
			{
			case "Tips Shown":
			{
				levelProgressManager.tipsShown.Clear();
				int num = int.Parse(ReadNextLn());
				for (int l = 0; l < num; l++)
				{
					levelProgressManager.tipsShown.Add(ReadNextLn());
				}
				break;
			}
			case "Perk Level":
				perkManager.level = int.Parse(ReadNextLn());
				break;
			case "Perk XP":
				perkManager.xp = int.Parse(ReadNextLn());
				break;
			case "Level":
				levelData = levelProgressManager.GetLevelDataForScene(ReadNextLn());
				break;
			case "Eternal Trials Score V3":
				levelProgressManager.EternalTrialsHighscore = int.Parse(ReadNextLn());
				break;
			case "QuestsCompleteWhenLastOnMap":
				if (levelData != null)
				{
					levelData.questsCompleteWhenLastVisitingMap = int.Parse(ReadNextLn());
				}
				break;
			case "Beaten":
				if (levelData != null)
				{
					levelData.beatenBest = ReadNextLn() == "1";
				}
				break;
			case "HighscoreV2":
				if (levelData != null)
				{
					levelData.highscoreBest = int.Parse(ReadNextLn());
				}
				break;
			case "NetworthV2 / Day":
				if (levelData != null)
				{
					int num = int.Parse(ReadNextLn());
					levelData.dayToDayNetworthBest.Clear();
					for (int m = 0; m < num; m++)
					{
						levelData.dayToDayNetworthBest.Add(int.Parse(ReadNextLn()));
					}
				}
				break;
			case "ScoreV2 / Day":
				if (levelData != null)
				{
					int num = int.Parse(ReadNextLn());
					levelData.dayToDayScoreBest.Clear();
					for (int k = 0; k < num; k++)
					{
						levelData.dayToDayScoreBest.Add(int.Parse(ReadNextLn()));
					}
				}
				break;
			case "Beaten With":
			{
				if (levelData == null)
				{
					break;
				}
				int num = int.Parse(ReadNextLn());
				List<Equippable> list = new List<Equippable>();
				for (int i = 0; i < num; i++)
				{
					string text = ReadNextLn();
					Equippable item = null;
					for (int j = 0; j < allEquippablesID.Count; j++)
					{
						if (allEquippablesID[j].name == text)
						{
							item = allEquippablesID[j];
						}
					}
					list.Add(item);
				}
				levelData.levelHasBeenBeatenWith.Add(list);
				break;
			}
			}
		}
		DebugLogInEditorOnly("Loaded Game from " + FullSaveFilePath);
	}

	private string ReadNextLn()
	{
		iln++;
		line = loadData[iln];
		return line;
	}

	private void DebugLogInEditorOnly(string _log)
	{
	}
}
