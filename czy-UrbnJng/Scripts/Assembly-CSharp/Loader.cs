using Infrastructure.Services;
using Infrastructure.Services.BoxService;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.States;
using Tasks_for_levels;
using UnityEngine.SceneManagement;

public class Loader : IService
{
	public enum Scene
	{
		Level_0_New = 0,
		Level_1_New = 1,
		Level_2_New = 2,
		Level_3_New = 3,
		Level_4_New = 4,
		Level_5_New = 5,
		Level_6_New = 6,
		Level_7_New = 7,
		Level_8_New = 8,
		Level_9_New = 9,
		Level_10_New = 10,
		LastScene = 11
	}

	private GameStateMachine gameStateMachine;

	private IPersistentProgressService _progressService;

	public int currentCreativeModeSceneNumber;

	public bool showMenu = true;

	public Loader(GameStateMachine _gameStateMachine, IPersistentProgressService progressService)
	{
		gameStateMachine = _gameStateMachine;
		_progressService = progressService;
	}

	public void LoadNextScene()
	{
		int num = (int)(GetNextScene() - 1);
		switch (num)
		{
		case 2:
			if (!_progressService.Progress.OpenedLevels.Contains(num))
			{
				_progressService.Progress.OpenedLevels.Add(num);
				SteamIntegration.Instance.UnlockLevelAchievement(num + 1);
			}
			return;
		case 0:
			_progressService.Progress.IsShowJournal = true;
			break;
		}
		switch (num)
		{
		case 0:
			_progressService.Progress.TutorialStep = 18;
			break;
		case 1:
			_progressService.Progress.TutorialStep = 20;
			break;
		default:
			_progressService.Progress.TutorialStep = 21;
			break;
		}
		_progressService.Progress.currentLevel = GetNextScene().ToString();
		_progressService.Progress.infoForPlants.Clear();
		_progressService.Progress.PlantsOnButton_new.Clear();
		_progressService.Progress.infoForObjects.Clear();
		_progressService.Progress.PlantsOnButton_new.Clear();
		_progressService.Progress.movableItems.Clear();
		_progressService.Progress.RemovedTrash.Clear();
		_progressService.Progress.Score = 0;
		_progressService.Progress.MaxScore = 0;
		_progressService.Progress.LevelStartCoins = _progressService.Progress.Coins;
		_progressService.Progress.PlantButtonCounter = 1;
		_progressService.Progress.BalanceScoreCounter = 0;
		_progressService.Progress.IsSpawnButtonVisible = true;
		_progressService.Progress.TasksOnLevel.Clear();
		_progressService.Progress.BoxesOnLevel.Clear();
		_progressService.Progress.showNewCreativeModeLevel = true;
		if (!_progressService.Progress.OpenedLevels.Contains(num))
		{
			_progressService.Progress.OpenedLevels.Add(num);
		}
		SteamIntegration.Instance.UnlockLevelAchievement(num + 1);
		AllServices.Container.Single<ITaskService>().ClearCurrentTask();
		AllServices.Container.Single<IBoxService>().ClearCurrenBoxes();
		gameStateMachine.Enter<LoadLevelState, string>(GetNextScene().ToString());
	}

	public void LoadStoryModeLevel()
	{
		AllServices.Container.Single<ISaveLoadService>().SaveProgress();
		string currentLevel = AllServices.Container.Single<IPersistentProgressService>().Progress.currentLevel;
		gameStateMachine.Enter<LoadLevelState, string>(currentLevel);
	}

	public void LoadCreativeModeLevel(int levelNumber)
	{
		currentCreativeModeSceneNumber = levelNumber;
		if (_progressService.Progress.CreativeModeNewLevels.Contains(levelNumber))
		{
			_progressService.Progress.CreativeModeNewLevels.Remove(levelNumber);
		}
		AllServices.Container.Single<ISaveLoadService>().SaveProgress();
		AllServices.Container.Single<ITaskService>().ClearCurrentTask();
		AllServices.Container.Single<IBoxService>().ClearCurrenBoxes();
		gameStateMachine.Enter<LoadLevelState, string>(GetCreativeModeScene(levelNumber));
	}

	public void StartLevelOver()
	{
		string name = SceneManager.GetActiveScene().name;
		_progressService.Progress.infoForPlants.Clear();
		_progressService.Progress.PlantsOnButton_new.Clear();
		_progressService.Progress.infoForObjects.Clear();
		_progressService.Progress.PlantsOnButton_new.Clear();
		_progressService.Progress.movableItems.Clear();
		_progressService.Progress.RemovedTrash.Clear();
		_progressService.Progress.DialogsStart[name + 0] = true;
		_progressService.Progress.DialogsStart[name + 1] = true;
		if (name != "Level_7_New")
		{
			_progressService.Progress.DialogsStart[name + 2] = true;
		}
		_progressService.Progress.Score = 0;
		_progressService.Progress.MaxScore = 0;
		_progressService.Progress.Coins = _progressService.Progress.LevelStartCoins;
		_progressService.Progress.PlantButtonCounter = 1;
		_progressService.Progress.BalanceScoreCounter = 0;
		_progressService.Progress.IsSpawnButtonVisible = true;
		_progressService.Progress.TasksOnLevel.Clear();
		_progressService.Progress.BoxesOnLevel.Clear();
		AllServices.Container.Single<ITaskService>().ClearCurrentTask();
		AllServices.Container.Single<IBoxService>().ClearCurrenBoxes();
		gameStateMachine.Enter<LoadLevelState, string>(name);
	}

	private string GetCreativeModeScene(int levelNumber)
	{
		return levelNumber switch
		{
			0 => "Level_0_CreativeMode", 
			1 => "Level_1_CreativeMode", 
			2 => "Level_2_CreativeMode", 
			3 => "Level_3_CreativeMode", 
			4 => "Level_4_CreativeMode", 
			5 => "Level_5_CreativeMode", 
			6 => "Level_6_CreativeMode", 
			7 => "Level_7_CreativeMode", 
			8 => "Level_8_CreativeMode", 
			9 => "Level_9_CreativeMode", 
			10 => "Level_10_CreativeMode", 
			_ => null, 
		};
	}

	public void StartNewGame()
	{
		gameStateMachine.Enter<LoadProgressState, bool>(payload: true);
	}

	private Scene GetNextScene()
	{
		return SceneManager.GetActiveScene().name switch
		{
			"Level_1_New" => Scene.Level_2_New, 
			"Level_2_New" => Scene.Level_3_New, 
			"Level_3_New" => Scene.Level_4_New, 
			"Level_4_New" => Scene.Level_5_New, 
			"Level_5_New" => Scene.Level_6_New, 
			"Level_6_New" => Scene.Level_7_New, 
			"Level_7_New" => Scene.Level_8_New, 
			"Level_8_New" => Scene.Level_9_New, 
			"Level_9_New" => Scene.Level_10_New, 
			"Level_10_New" => Scene.LastScene, 
			_ => Scene.Level_1_New, 
		};
	}
}
