using System;
using System.Collections.Generic;

namespace Infrastructure.Services.PersistentProgress
{
	[Serializable]
	public class PlayerProgress
	{
		public string version;

		public bool CreativeMode;

		public bool IsTutorial;

		public int TutorialStep;

		public bool IsFirstLaunch;

		public bool IsFirstLaunchCreativeMode;

		public string currentLevel;

		public List<InfoForPlantConstructor> infoForPlants;

		public List<InfoForObjectsOnLevel> infoForObjects;

		public List<MovableItems> movableItems;

		public List<string> RemovedTrash;

		public List<string> PlantsOnButton_new;

		public Dictionary<int, string> PlantsOnButton;

		public int Score;

		public int MaxScore;

		public int PlantButtonCounter;

		public int BalanceScoreCounter;

		public Dictionary<string, string> userCollection;

		public List<string> userFirstPlantCollection;

		public List<string> userSkinsCollection;

		public int Language;

		public int WindowMode;

		public bool MuteMusic;

		public bool MuteSound;

		public float MusicVolume;

		public float SoundVolume;

		public bool IsShowJournal;

		public bool IsSpawnButtonVisible;

		public List<bool> TasksOnLevel;

		public int Coins;

		public int LevelStartCoins;

		public List<int> OpenedLevels;

		public Dictionary<string, int> BoxesOnLevel;

		public Dictionary<string, CreativeModeProgress> CreativeModeProgresses;

		public Dictionary<string, bool> DialogsStart;

		public List<int> CreativeModeNewLevels;

		public bool showNewCreativeModeLevel;

		public int ACH_ExtractCoins;

		public int ACH_Cat;

		public int ACH_Dog;

		public int ACH_ItemsCount;

		public List<int> ACH_TaskDoneList;

		public List<int> AchievementList;

		public bool ShowCurtain;
	}
}
