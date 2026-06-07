using System.Collections.Generic;
using CodeBase.Infrastructure.States;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;

namespace Infrastructure.States
{
	public class LoadProgressState : IPayloadedState<bool>, IExitableState
	{
		private const string START_LEVEL = "Level_0_New";

		private readonly GameStateMachine _gameStateMachine;

		private readonly IPersistentProgressService _progressService;

		private readonly ISaveLoadService _saveLoadService;

		public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
		{
			_gameStateMachine = gameStateMachine;
			_progressService = progressService;
			_saveLoadService = saveLoadService;
		}

		public void Enter(bool isNewGame)
		{
			if (isNewGame)
			{
				ClearProgress();
				_gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.currentLevel);
			}
			else
			{
				LoadProgressOrInitNew();
				_gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.currentLevel);
			}
		}

		public void Exit()
		{
		}

		private void LoadProgressOrInitNew()
		{
			_progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
		}

		private PlayerProgress NewProgress()
		{
			return new PlayerProgress
			{
				version = _saveLoadService.Version,
				IsTutorial = true,
				TutorialStep = 0,
				IsFirstLaunch = true,
				IsFirstLaunchCreativeMode = true,
				currentLevel = "Level_0_New",
				infoForPlants = new List<InfoForPlantConstructor>(),
				PlantsOnButton_new = new List<string> { "67c36571-be82-4f35-a57a-fb5ff3b22739", "1c95b5c6-3c01-43d4-98f2-cf5cabf67a87" },
				PlantsOnButton = new Dictionary<int, string>(),
				Score = 0,
				MaxScore = 0,
				PlantButtonCounter = 0,
				BalanceScoreCounter = 0,
				infoForObjects = new List<InfoForObjectsOnLevel>(),
				movableItems = new List<MovableItems>(),
				RemovedTrash = new List<string>(),
				userCollection = new Dictionary<string, string>(),
				userFirstPlantCollection = new List<string>(),
				userSkinsCollection = new List<string>(),
				Language = 0,
				WindowMode = 0,
				MuteMusic = false,
				MuteSound = false,
				MusicVolume = 0.3f,
				SoundVolume = 0.9f,
				IsShowJournal = false,
				IsSpawnButtonVisible = true,
				TasksOnLevel = new List<bool>(),
				Coins = 3,
				LevelStartCoins = 3,
				OpenedLevels = new List<int>(),
				CreativeModeNewLevels = new List<int>
				{
					0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
					10
				},
				BoxesOnLevel = new Dictionary<string, int>(),
				CreativeModeProgresses = new Dictionary<string, CreativeModeProgress>
				{
					{
						"Level_0_CreativeMode",
						new CreativeModeProgress(0)
					},
					{
						"Level_1_CreativeMode",
						new CreativeModeProgress(1)
					},
					{
						"Level_2_CreativeMode",
						new CreativeModeProgress(2)
					},
					{
						"Level_3_CreativeMode",
						new CreativeModeProgress(3)
					},
					{
						"Level_4_CreativeMode",
						new CreativeModeProgress(4)
					},
					{
						"Level_5_CreativeMode",
						new CreativeModeProgress(5)
					},
					{
						"Level_6_CreativeMode",
						new CreativeModeProgress(6)
					},
					{
						"Level_7_CreativeMode",
						new CreativeModeProgress(7)
					},
					{
						"Level_8_CreativeMode",
						new CreativeModeProgress(8)
					},
					{
						"Level_9_CreativeMode",
						new CreativeModeProgress(9)
					},
					{
						"Level_10_CreativeMode",
						new CreativeModeProgress(10)
					}
				},
				DialogsStart = new Dictionary<string, bool>
				{
					{ "Level_0_New0", true },
					{ "Level_0_New1", true },
					{ "Level_0_New2", true },
					{ "Level_1_New0", true },
					{ "Level_1_New1", true },
					{ "Level_1_New2", true },
					{ "Level_2_New0", true },
					{ "Level_2_New1", true },
					{ "Level_2_New2", true },
					{ "Level_3_New0", true },
					{ "Level_3_New1", true },
					{ "Level_3_New2", true },
					{ "Level_4_New0", true },
					{ "Level_4_New1", true },
					{ "Level_4_New2", true },
					{ "Level_5_New0", true },
					{ "Level_5_New1", true },
					{ "Level_5_New2", true },
					{ "Level_6_New0", true },
					{ "Level_6_New1", true },
					{ "Level_6_New2", true },
					{ "Level_7_New0", true },
					{ "Level_7_New1", true },
					{ "Level_7_New2", false },
					{ "Level_8_New0", true },
					{ "Level_8_New1", true },
					{ "Level_8_New2", true },
					{ "Level_9_New0", true },
					{ "Level_9_New1", true },
					{ "Level_9_New2", true },
					{ "Level_10_New0", true },
					{ "Level_10_New1", true },
					{ "Level_10_New2", true }
				},
				showNewCreativeModeLevel = false,
				ACH_ExtractCoins = 0,
				ACH_Cat = 0,
				ACH_Dog = 0,
				ACH_ItemsCount = 0,
				AchievementList = new List<int>(),
				ACH_TaskDoneList = new List<int>(),
				ShowCurtain = true
			};
		}

		private void ClearProgress()
		{
			_progressService.Progress.IsTutorial = true;
			_progressService.Progress.TutorialStep = 0;
			_progressService.Progress.currentLevel = "Level_0_New";
			_progressService.Progress.infoForPlants = new List<InfoForPlantConstructor>();
			_progressService.Progress.PlantsOnButton_new = new List<string> { "1c95b5c6-3c01-43d4-98f2-cf5cabf67a87", "67c36571-be82-4f35-a57a-fb5ff3b22739" };
			_progressService.Progress.Score = 0;
			_progressService.Progress.MaxScore = 0;
			_progressService.Progress.PlantButtonCounter = 0;
			_progressService.Progress.BalanceScoreCounter = 0;
			_progressService.Progress.infoForObjects = new List<InfoForObjectsOnLevel>();
			_progressService.Progress.movableItems = new List<MovableItems>();
			_progressService.Progress.RemovedTrash = new List<string>();
			_progressService.Progress.IsShowJournal = false;
			_progressService.Progress.IsSpawnButtonVisible = true;
			_progressService.Progress.TasksOnLevel = new List<bool>();
			_progressService.Progress.Coins = 3;
			_progressService.Progress.LevelStartCoins = 3;
			_progressService.Progress.BoxesOnLevel = new Dictionary<string, int>();
			_progressService.Progress.ShowCurtain = true;
			_progressService.Progress.DialogsStart = new Dictionary<string, bool>
			{
				{ "Level_0_New0", true },
				{ "Level_0_New1", true },
				{ "Level_0_New2", true },
				{ "Level_1_New0", true },
				{ "Level_1_New1", true },
				{ "Level_1_New2", true },
				{ "Level_2_New0", true },
				{ "Level_2_New1", true },
				{ "Level_2_New2", true },
				{ "Level_3_New0", true },
				{ "Level_3_New1", true },
				{ "Level_3_New2", true },
				{ "Level_4_New0", true },
				{ "Level_4_New1", true },
				{ "Level_4_New2", true },
				{ "Level_5_New0", true },
				{ "Level_5_New1", true },
				{ "Level_5_New2", true },
				{ "Level_6_New0", true },
				{ "Level_6_New1", true },
				{ "Level_6_New2", true },
				{ "Level_7_New0", true },
				{ "Level_7_New1", true },
				{ "Level_7_New2", false },
				{ "Level_8_New0", true },
				{ "Level_8_New1", true },
				{ "Level_8_New2", true },
				{ "Level_9_New0", true },
				{ "Level_9_New1", true },
				{ "Level_9_New2", true },
				{ "Level_10_New0", true },
				{ "Level_10_New1", true },
				{ "Level_10_New2", true }
			};
		}
	}
}
