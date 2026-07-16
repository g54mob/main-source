using System.Collections.Generic;

public class MetaSavefile : Savefile
{
	public float cores;

	public float totalCores;

	public List<int> radarUpgradesBought;

	public List<int> radarUpgradesToggledOff;

	public bool isTutorialCompleted;

	public List<string> savedMilestoneNames;

	public List<bool> savedMilestoneCompleted;

	public List<float> savedMilestoneProgress;

	public bool coresGainedFromMilestones;

	public List<int> timesDialoguesPlayed;

	public bool isOverfillStationConditionMet;

	public float mostEnemiesKilled;

	public float mostDamageDealt;

	public float totalEnemiesKilled;

	public float totalKilometersTraveled;

	public float totalJourneys;

	public bool isRadarFixed;

	public bool isNoticeBoardFixed;

	public bool isPaintStationFixed;

	public bool isDifficultyStationFixed;

	public bool isReadyUpStationFixed;

	public bool isOverfillStationFixed;

	public bool isOverfillOn;

	public bool isDifficultyStationReadyToUnlock;

	public bool isOverfillStationReadyToUnlock;

	public bool isToolboxReadyToUnlock;

	public bool isNoticeBoardReadyToUnlock;

	public int currentDifficultyIndex;

	public List<int> unlockedDifficultyIndexes;

	public bool isToolboxFixed;

	public bool isTimingMinigameOn;

	public int unlockedWorlds;

	public int lastUnlockedWorld;

	public int lastDiscoveredWorld;

	public int currentTrain;

	public int cannonDamageIncreaseCounter;

	public int playerRepairSpeedIncreaseCounter;

	public List<string> trainNames;

	public List<bool> isTrainUnlocked;

	public List<int> trainWorldBeaten;

	public List<string> difficultyScalingConditions;

	public List<int> scalingConditionStackAmount;

	public List<string> difficultyToggledConditions;

	public List<bool> toggledConditionIsOn;

	public List<bool> isScalingLocked;

	public List<bool> isToggleLocked;

	public float maxAllowedWeight;

	public bool sandstormTutorialFinished;

	public bool isFirstLoad = true;

	public MetaSavefile()
	{
		version = GameManager.Instance.Version;
		cores = 0f;
		totalCores = 0f;
		radarUpgradesBought = new List<int>();
		radarUpgradesToggledOff = new List<int>();
		isTutorialCompleted = false;
		savedMilestoneNames = new List<string>();
		savedMilestoneCompleted = new List<bool>();
		savedMilestoneProgress = new List<float>();
		coresGainedFromMilestones = false;
		timesDialoguesPlayed = new List<int>();
		mostEnemiesKilled = 0f;
		mostDamageDealt = 0f;
		totalEnemiesKilled = 0f;
		totalKilometersTraveled = 0f;
		totalJourneys = 0f;
		isRadarFixed = false;
		isPaintStationFixed = false;
		currentDifficultyIndex = 0;
		unlockedDifficultyIndexes = new List<int> { 0 };
		isOverfillStationFixed = false;
		isOverfillOn = false;
		isToolboxFixed = false;
		isTimingMinigameOn = false;
		difficultyScalingConditions = new List<string>();
		scalingConditionStackAmount = new List<int>();
		difficultyToggledConditions = new List<string>();
		toggledConditionIsOn = new List<bool>();
		isScalingLocked = new List<bool>();
		isToggleLocked = new List<bool>();
		maxAllowedWeight = DifficultyManager.Instance.WeightTresholds[0];
		isReadyUpStationFixed = false;
		currentTrain = 0;
		cannonDamageIncreaseCounter = 0;
		playerRepairSpeedIncreaseCounter = 0;
		unlockedWorlds = 1;
		lastUnlockedWorld = 0;
		lastDiscoveredWorld = 0;
		trainNames = new List<string>();
		isTrainUnlocked = new List<bool>();
		trainWorldBeaten = new List<int>();
		isOverfillStationConditionMet = true;
		sandstormTutorialFinished = false;
	}
}
