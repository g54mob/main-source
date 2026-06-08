using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dorfromantik;
using UnityEngine;

public class SaveFileManager : ScriptableObject
{
	public Dictionary<GameMode, Dictionary<string, SaveGameData_003>> loadedSaveGames;

	public Dictionary<GameMode, SaveGameData_003> autoSaveGames;

	private Dictionary<GameModeId, GameMode> gameModeById;

	private bool areSaveGamesLoaded;

	public SaveGameData_003 ActiveSaveGame = new SaveGameData_003();

	public List<SaveFileLimitByGameMode> saveFileLimits;

	[SerializeField]
	private List<GameMode> gameModes;

	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	[SerializeField]
	private RewardLibrary rewardLibrary;

	[SerializeField]
	private LeaderboardManager leaderboardManager;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private List<SaveGameData_003> debug_loadedSaveGames;

	private Dictionary<GameModeId, int> fileLimitByGameMode = new Dictionary<GameModeId, int>();

	public GameMode CreativeMode => gameModeById[GameModeId.Creative];

	public bool SetupSaveGameScreenshotsOnAwake => settingsRouter.defaultSettings.setupScreenshotsOnAwake;

	public event Action<GameMode> OnSaveGamesChanged;

	public event Action<GameMode> OnAutoSaveChanged;

	public GameMode GameModeById(GameModeId id)
	{
		return gameModeById[id];
	}

	public void Setup()
	{
		gameModeById = new Dictionary<GameModeId, GameMode>();
		loadedSaveGames = new Dictionary<GameMode, Dictionary<string, SaveGameData_003>>();
		autoSaveGames = new Dictionary<GameMode, SaveGameData_003>();
		debug_loadedSaveGames = new List<SaveGameData_003>();
		fileLimitByGameMode = new Dictionary<GameModeId, int>();
		foreach (GameMode gameMode2 in gameModes)
		{
			gameModeById.Add(gameMode2.id, gameMode2);
			loadedSaveGames.Add(gameMode2, new Dictionary<string, SaveGameData_003>());
			if (gameMode2.DoesAutoSave)
			{
				autoSaveGames.Add(gameMode2, null);
			}
		}
		foreach (SaveFileLimitByGameMode saveFileLimit in saveFileLimits)
		{
			fileLimitByGameMode.Add(saveFileLimit.gameMode, saveFileLimit.limit);
		}
		LoadAllSaveFiles();
		GameMode gameMode = ((OverwritingSingleton<GameSession>.Instance != null) ? OverwritingSingleton<GameSession>.Instance.GameMode : gameModeById[(GameModeId)PlayerPrefsAccessor.GetInt("LastPlayedGameMode", 0)]);
		ActiveSaveGame = (gameMode.DoesAutoSave ? autoSaveGames[gameMode] : null);
		foreach (KeyValuePair<GameMode, Dictionary<string, SaveGameData_003>> loadedSaveGame in loadedSaveGames)
		{
			_ = loadedSaveGame;
		}
	}

	private void LoadAllSaveFiles()
	{
		string path = Path.Combine(Constants.persistentDataPath, "Saves");
		if (!Directory.Exists(path))
		{
			return;
		}
		string[] files = Directory.GetFiles(path, "*.sav");
		foreach (string text in files)
		{
			string text2 = text;
			SuccessStatus successStatus;
			SaveGameData saveGameData = BinarySaveLoad.LoadFromBinary<SaveGameData>(text2, out successStatus);
			if (successStatus != SuccessStatus.Success && File.Exists(text2 + ".bac"))
			{
				Debug.Log("loading backup file");
				text2 += ".bac";
				saveGameData = BinarySaveLoad.LoadFromBinary<SaveGameData>(text2, out successStatus);
			}
			if (successStatus != SuccessStatus.Success)
			{
				Debug.LogError("failed to load save file " + text + " and backup");
				continue;
			}
			if (saveGameData == null)
			{
				Debug.LogError($"no loaded data at {text2} {successStatus}");
				continue;
			}
			SaveGameData_003 saveGameData_ = (SaveGameData_003)SaveGameConverter.LoadCurrentVersionSavegame(saveGameData.version, text2);
			debug_loadedSaveGames.Add(saveGameData_);
			if (!gameModeById.ContainsKey(saveGameData_.gameMode))
			{
				Debug.LogError($"tries to load savegame for game mode {saveGameData_.gameMode}, which isn't implemented");
				continue;
			}
			GameMode gameMode = gameModeById[saveGameData_.gameMode];
			if (gameMode.configType == CustomConfigType.PredefinedWithRandomSeed && saveGameData_.customModeData != null && saveGameData_.customModeData.configString != gameMode.configurationString)
			{
				Debug.Log($"save game no longer in gameMode {gameMode} - config string has changed, no longer {saveGameData_.customModeData.configString} but {gameMode.configurationString}");
				gameMode = gameModeById[GameModeId.Custom];
				saveGameData_.gameMode = GameModeId.Custom;
			}
			string fileName = Path.GetFileName(text);
			if (fileName == PlayerPrefsAccessor.GetString(gameMode.playerPrefsActiveGame ?? "", gameMode.autosaveName + ".sav"))
			{
				autoSaveGames[gameMode] = saveGameData_;
			}
			if (fileName != gameMode.autosaveName + ".sav")
			{
				loadedSaveGames[gameMode].Add(fileName, saveGameData_);
				saveGameData_.fileName = fileName;
			}
		}
		foreach (GameMode gameMode2 in gameModes)
		{
			this.OnSaveGamesChanged?.Invoke(gameMode2);
			this.OnAutoSaveChanged?.Invoke(gameMode2);
		}
	}

	public void CreateNewSaveFileForAutosave(GameModeId gameModeId, bool shouldClearAutosaveGameSlot)
	{
		CreateNewSaveFileForAutosave(gameModeById[gameModeId], shouldClearAutosaveGameSlot);
	}

	public void CreateNewSaveFileForAutosave(GameMode targetGameMode, bool shouldClearAutosaveGameSlot)
	{
		if (!string.IsNullOrWhiteSpace(autoSaveGames[targetGameMode].fileName))
		{
			Debug.LogError("active game already saved as " + autoSaveGames[targetGameMode].fileName);
			return;
		}
		CreateNewSaveFileFor(autoSaveGames[targetGameMode], targetGameMode);
		DeleteAutosaveForGameMode(targetGameMode, shouldClearAutosaveGameSlot);
	}

	public void CreateNewSaveFileFor(SaveGameData_003 saveGameData, GameMode targetGameMode = null)
	{
		if (targetGameMode == null)
		{
			targetGameMode = gameModeById[saveGameData.gameMode];
		}
		else
		{
			saveGameData.gameMode = targetGameMode.id;
		}
		saveGameData.fileName = targetGameMode.FullSaveFileName;
		loadedSaveGames[targetGameMode].Add(saveGameData.fileName, saveGameData);
		PlayerPrefsAccessor.SetString(targetGameMode.playerPrefsActiveGame ?? "", saveGameData.fileName);
		SaveGameFile(saveGameData);
		this.OnSaveGamesChanged?.Invoke(targetGameMode);
		this.OnAutoSaveChanged?.Invoke(targetGameMode);
	}

	public void DeleteAutosaveForGameMode(GameMode gameMode, bool shouldClearAutoSaveGameSlot)
	{
		if (gameMode.DoesAutoSave)
		{
			if (shouldClearAutoSaveGameSlot)
			{
				autoSaveGames[gameMode] = null;
			}
			DeleteFileAtPath(gameMode.FullAutoSavePath);
			this.OnAutoSaveChanged?.Invoke(gameMode);
		}
	}

	private void DeleteFileAtPath(string path)
	{
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		else
		{
			Debug.LogError("trying to dele file, but file at path " + path + " doesn't exist!");
		}
	}

	public void SaveGameFile(SaveGameData_003 dataToSave)
	{
		GameMode gameMode = gameModeById[dataToSave.gameMode];
		if (!string.IsNullOrWhiteSpace(dataToSave.fileName))
		{
			BinarySaveLoad.SaveAsBinary(dataToSave, Constants.SaveLoad.SaveGamePathWithinPersistentDataPath(dataToSave.fileName));
			this.OnSaveGamesChanged?.Invoke(gameMode);
		}
		else
		{
			BinarySaveLoad.SaveAsBinary(dataToSave, gameMode.FullAutoSavePath);
		}
		this.OnAutoSaveChanged?.Invoke(gameMode);
	}

	public void SetActiveGame(SaveGameData_003 newActiveGame, GameMode targetGameMode = null)
	{
		if ((object)targetGameMode == null)
		{
			targetGameMode = OverwritingSingleton<GameSession>.Instance.GameMode;
		}
		ActiveSaveGame = newActiveGame ?? new SaveGameData_003
		{
			gameMode = targetGameMode.id,
			initialVersion = Application.version
		};
		ActiveSaveGame.SetLastPlayedTime(DateTime.Now);
		if (targetGameMode.DoesAutoSave)
		{
			autoSaveGames[targetGameMode] = ActiveSaveGame;
			if (ActiveSaveGame.HasSaveFile)
			{
				PlayerPrefsAccessor.SetString(targetGameMode.playerPrefsActiveGame, ActiveSaveGame.fileName);
			}
			else
			{
				PlayerPrefsAccessor.DeleteKey(targetGameMode.playerPrefsActiveGame);
			}
		}
		this.OnAutoSaveChanged?.Invoke(targetGameMode);
	}

	public void DeleteSaveGame(SaveGameData_003 savegameData)
	{
		GameMode gameMode = gameModeById[savegameData.gameMode];
		if (autoSaveGames[gameMode] == savegameData)
		{
			autoSaveGames[gameMode] = null;
			PlayerPrefsAccessor.DeleteKey(gameMode.playerPrefsActiveGame);
			this.OnAutoSaveChanged?.Invoke(gameMode);
		}
		if (savegameData.HasSaveFile)
		{
			loadedSaveGames[gameMode].Remove(savegameData.fileName);
			DeleteFileAtPath(Path.Combine(Constants.persistentDataPath, Constants.SaveLoad.SaveGamePathWithinPersistentDataPath(savegameData.fileName)));
			this.OnSaveGamesChanged?.Invoke(gameMode);
		}
		else
		{
			DeleteFileAtPath(gameMode.FullAutoSavePath);
		}
	}

	public void HardResetFromMenu()
	{
		HardResetEverything(deleteSaveFiles: true, resetHighscore: true);
	}

	public void HardResetEverything(bool deleteSaveFiles, bool resetHighscore)
	{
		List<string> list = new List<string>
		{
			Constants.SaveLoad.FullRewardDataPath,
			Constants.SaveLoad.FullChallengeDataPath
		};
		if (deleteSaveFiles)
		{
			foreach (GameMode gameMode in gameModes)
			{
				if (gameMode.DoesAutoSave)
				{
					list.Add(gameMode.FullAutoSavePath);
				}
				autoSaveGames[gameMode] = null;
			}
		}
		SetActiveGame(null);
		foreach (string item in list)
		{
			DeleteFileAtPath(item);
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		dictionary.Add("UnitySelectMonitor", PlayerPrefs.GetInt("UnitySelectMonitor", 0));
		dictionary.Add("Language", PlayerPrefs.GetInt("Language", -1));
		dictionary.Add("AnalyticsEnabled", PlayerPrefs.GetInt("AnalyticsEnabled", -1));
		dictionary.Add("AnalyticsOptInShown", PlayerPrefs.GetInt("AnalyticsOptInShown", -1));
		if (!resetHighscore)
		{
			foreach (LeaderboardType allLeaderboard in leaderboardManager.allLeaderboards)
			{
				dictionary.Add(allLeaderboard.GetPlayerPrefsScoreKey(), PlayerPrefs.GetInt(allLeaderboard.GetPlayerPrefsScoreKey(), -1));
			}
		}
		Debug.Log("Delete all Player Prefs, apart from " + ListHelper.ListDebugString(Enumerable.ToList(dictionary.Keys)));
		PlayerPrefs.DeleteAll();
		foreach (KeyValuePair<string, int> item2 in dictionary)
		{
			if (item2.Value != -1)
			{
				PlayerPrefs.SetInt(item2.Key, item2.Value);
			}
		}
		if (Application.isEditor)
		{
			sessionQuestManager.BuildReset();
		}
		rewardLibrary.Setup();
		sessionQuestManager.Setup();
	}

	public void UpdateSaveGamesUi(GameMode selectedGameMode)
	{
		this.OnSaveGamesChanged?.Invoke(selectedGameMode);
	}

	public int GetSaveFileLimit(GameMode gameMode)
	{
		return fileLimitByGameMode[gameMode.id];
	}
}
