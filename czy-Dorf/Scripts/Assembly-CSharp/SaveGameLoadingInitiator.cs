using Dorfromantik;
using Dorfromantik.UI.MainMenu;
using UnityEngine;

public class SaveGameLoadingInitiator : ScriptableObject
{
	[SerializeField]
	private SaveFileManager saveFileManager;

	[SerializeField]
	private SceneLoader sceneLoader;

	private GameMode selectedGameMode;

	private SaveGameData_003 selectedSaveGame;

	private SaveGameData_003 selectedSaveGameToOverwrite;

	private SaveLoadOnCompleteAction onCompleteAction;

	private bool LoadingWouldOverwriteAutoSave
	{
		get
		{
			if (selectedGameMode.DoesAutoSave && saveFileManager.autoSaveGames[selectedGameMode] != null && saveFileManager.autoSaveGames[selectedGameMode].HasStarted)
			{
				return !saveFileManager.autoSaveGames[selectedGameMode].HasSaveFile;
			}
			return false;
		}
	}

	public GameMode SelectedGameMode => selectedGameMode;

	public SaveGameData_003 SelectedSaveGame => selectedSaveGame;

	public SaveGameData_003 SelectedSaveGameToOverwrite => selectedSaveGameToOverwrite;

	public void SetSelectedGameMode(GameMode gameModeToSelect)
	{
		selectedGameMode = gameModeToSelect;
	}

	public void SetCurrentModeAsSelectedGameMode()
	{
		SetSelectedGameMode(OverwritingSingleton<GameSession>.Instance.GameMode);
	}

	public void SetSelectedSaveGame(SaveGameData_003 saveGameToSelect)
	{
		selectedSaveGame = saveGameToSelect;
	}

	public void InitiateStartNewGame()
	{
		GameMode gameMode = OverwritingSingleton<GameSession>.Instance.GameMode;
		Debug.Log($"Initiate startNewGame in {selectedGameMode}");
		SetSelectedSaveGame(null);
		if (gameMode.IsTutorial)
		{
			if (selectedGameMode.IsTutorial)
			{
				Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.RestartTutorial);
			}
			else if (LoadingWouldOverwriteAutoSave)
			{
				Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.NewGame_DifferentGameMode_DiscardOrSaveAutosave);
			}
			else
			{
				Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.SkipTutorial);
			}
		}
		else if (LoadingWouldOverwriteAutoSave)
		{
			if (gameMode == selectedGameMode)
			{
				Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.NewGame_SameGameMode_DiscardOrSaveAutosave);
			}
			else
			{
				Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.NewGame_DifferentGameMode_DiscardOrSaveAutosave);
			}
		}
		else
		{
			NewGameInSelectedGameMode();
		}
	}

	public void InitiateLoadGame(SaveGameData_003 targetSaveGame)
	{
		GameMode gameMode = OverwritingSingleton<GameSession>.Instance.GameMode;
		SetSelectedSaveGame(targetSaveGame);
		if (gameMode.IsTutorial)
		{
			if (LoadingWouldOverwriteAutoSave)
			{
				Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.LoadGame_DifferentGameMode_DiscardOrSaveAutosave);
			}
			else if (PlayerPrefsAccessor.GetInt("TutorialPlayed", 0) == 0)
			{
				Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.SkipTutorial);
			}
			else
			{
				LoadSelectedGame();
			}
		}
		else if (LoadingWouldOverwriteAutoSave)
		{
			if (gameMode == selectedGameMode)
			{
				Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.LoadGame_SameGameMode_DiscardOrSaveAutosave);
			}
			else
			{
				Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.LoadGame_DifferentGameMode_DiscardOrSaveAutosave);
			}
		}
		else
		{
			LoadSelectedGame();
		}
	}

	public void InitiateTransferActiveGameToCreativeMode()
	{
		SetSelectedSaveGame(saveFileManager.ActiveSaveGame);
		SetSelectedGameMode(saveFileManager.CreativeMode);
		if (LoadingWouldOverwriteAutoSave)
		{
			Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.TransferToCreative_DiscardOrSaveAutosave);
		}
		else
		{
			TransferSelectedGameToCreativeMode();
		}
	}

	public void InitiateCreateNewSaveFileForAutosaveInSelectedGameMode(int onCompleteActionIndex)
	{
		int saveFileLimit = saveFileManager.GetSaveFileLimit(selectedGameMode);
		onCompleteAction = (SaveLoadOnCompleteAction)onCompleteActionIndex;
		if (saveFileLimit <= 0 || saveFileManager.loadedSaveGames[selectedGameMode].Count < saveFileLimit)
		{
			CreateNewSaveFileForAutosaveInSelectedGameMode();
			switch (onCompleteAction)
			{
			case SaveLoadOnCompleteAction.StartNewGame:
				NewGameInSelectedGameMode();
				break;
			case SaveLoadOnCompleteAction.LoadGame:
				LoadSelectedGame();
				break;
			}
		}
		else
		{
			Debug.Log($"wants to create new SaveFile, but file limit was reached! File Limit: {saveFileLimit}, File Count: {saveFileManager.loadedSaveGames[selectedGameMode].Count}");
			Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.SelectSaveFileToOverwrite);
		}
	}

	public void CreateNewSaveFileForAutosaveInSelectedGameMode()
	{
		saveFileManager.CreateNewSaveFileForAutosave(selectedGameMode, shouldClearAutosaveGameSlot: false);
	}

	public void DeleteAutosaveOfSelectedGameMode()
	{
		saveFileManager.DeleteAutosaveForGameMode(selectedGameMode, shouldClearAutoSaveGameSlot: true);
	}

	public void NewGameInSelectedGameMode()
	{
		PlayerPrefsAccessor.DeleteKey(selectedGameMode.playerPrefsActiveGame ?? "");
		PlayerPrefsAccessor.SetInt("LastPlayedGameMode", (int)selectedGameMode.id);
		saveFileManager.SetActiveGame(null, selectedGameMode);
		sceneLoader.UnloadCurrentSceneAndLoad(selectedGameMode);
	}

	public void LoadAutosaveInSelectedGameMode()
	{
		PlayerPrefsAccessor.SetInt("LastPlayedGameMode", (int)selectedGameMode.id);
		if (selectedGameMode.DoesAutoSave)
		{
			saveFileManager.SetActiveGame(saveFileManager.autoSaveGames[selectedGameMode], selectedGameMode);
		}
		sceneLoader.UnloadCurrentSceneAndLoad(selectedGameMode);
	}

	public void LoadSelectedGame()
	{
		saveFileManager.SetActiveGame(selectedSaveGame, selectedGameMode);
		saveFileManager.UpdateSaveGamesUi(selectedGameMode);
		sceneLoader.UnloadCurrentSceneAndLoad(selectedGameMode);
	}

	public void TransferSelectedGameToCreativeMode()
	{
		GameMode creativeMode = saveFileManager.CreativeMode;
		saveFileManager.DeleteSaveGame(selectedSaveGame);
		selectedSaveGame.fileName = creativeMode.FullSaveFileName;
		selectedSaveGame.score = 0;
		saveFileManager.CreateNewSaveFileFor(selectedSaveGame, creativeMode);
		saveFileManager.SetActiveGame(selectedSaveGame, creativeMode);
		sceneLoader.UnloadCurrentSceneAndLoad(creativeMode);
	}

	public void DeleteSelectedSaveGame()
	{
		saveFileManager.DeleteSaveGame(selectedSaveGame);
		if (selectedSaveGame == saveFileManager.ActiveSaveGame)
		{
			SetSelectedGameMode(OverwritingSingleton<GameSession>.Instance.GameMode);
			NewGameInSelectedGameMode();
		}
		selectedSaveGame = null;
	}

	public void InitiateTryAgain()
	{
		SetCurrentModeAsSelectedGameMode();
		if (saveFileManager.GetSaveFileLimit(selectedGameMode) <= 0)
		{
			NewGameInSelectedGameMode();
		}
	}

	public void InitiateOverwriteSaveGame(SaveGameData_003 saveGameToOverwrite)
	{
		selectedSaveGameToOverwrite = saveGameToOverwrite;
		Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(ConfirmationScreenType.ConfirmOverwritingSaveFile);
	}

	public void OverwriteSelectedSaveGameWithActiveGame()
	{
		saveFileManager.DeleteSaveGame(selectedSaveGameToOverwrite);
		selectedSaveGameToOverwrite = null;
		CreateNewSaveFileForAutosaveInSelectedGameMode();
		switch (onCompleteAction)
		{
		case SaveLoadOnCompleteAction.StartNewGame:
			NewGameInSelectedGameMode();
			break;
		case SaveLoadOnCompleteAction.LoadGame:
			LoadSelectedGame();
			break;
		}
	}
}
