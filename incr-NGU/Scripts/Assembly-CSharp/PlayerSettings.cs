using System;

[Serializable]
public class PlayerSettings
{
	public int numberDisplay;

	public bool tooltipsOn;

	public bool special1Bought;

	public bool special2Bought;

	public bool special3Bought;

	public bool specialAdvHpBars = true;

	public bool filterOn = true;

	public bool wandoos98On;

	public long customEnergy1;

	public long customEnergy2;

	public long customMagic1;

	public long customMagic2;

	public bool yggdrasilOn;

	public bool filterHead;

	public bool filterChest;

	public bool filterLegs;

	public bool filterBoots;

	public bool filterWeapon;

	public bool filterAccessory;

	public bool filterBoosts;

	public bool filterBoostAtk;

	public bool filterBoostDef;

	public bool filterBoostSpec;

	public bool filterMisc;

	public bool filterTitan;

	public bool syncTraining;

	public bool hasHyperRegen;

	public difficulty rebirthDifficulty;

	public long rebirthLevels;

	public int speedrunCount;

	public bool gotSpeedrunSecret;

	public bool nguOn;

	public bool inventoryOn;

	public bool antiFlickerBars;

	public bool autoAssignOn;

	public float autoAssignTime;

	public long machineEnergyAmount;

	public long machineGoldMultiAmount;

	public int tutorialState = -1;

	public bool tutorialOffForever;

	public bool tutorial1Complete;

	public bool expPopups = true;

	public PlayerTime dailySaveRewardTime = new PlayerTime();

	public bool submitHighscores = true;

	public bool timedTooltipsOn = true;

	public bool autoMergeOn;

	public long inputAmount = 1000L;

	public bool autoKillTitans;

	public bool autoBoostOn;

	public float customEnergyPercent1;

	public float customEnergyPercent2;

	public float customMagicPercent1;

	public float customMagicPercent2;

	public float customRes3Percent1;

	public float customRes3Percent2;

	public float customIdleEnergyPercent1;

	public float customIdleEnergyPercent2;

	public float customIdleMagicPercent1;

	public float customIdleMagicPercent2;

	public float customIdleRes3Percent1;

	public float customIdleRes3Percent2;

	public bool autoboostRecycledBoosts;

	public bool unassignWhenSwapping;

	public bool shakeySales;

	public bool beardsOn;

	public bool beardPopup;

	public bool checkForUpdates = true;

	public bool fancyYggBars = true;

	public int autoTransform;

	public bool simpleInvShortcuts;

	public bool poopOnlyMaxTier;

	public bool itopodOn;

	public bool itopodConfirmation = true;

	public bool buffedKillsOn;

	public int customPowerAmount = 1;

	public int customBarAmount = 1;

	public long customCapAmount = 10000L;

	public int customMagicPowerAmount = 1;

	public int customMagicBarAmount = 1;

	public long customMagicCapAmount = 10000L;

	public int customRes3PowerAmount = 1;

	public int customRes3BarAmount = 1;

	public long customRes3CapAmount = 10000L;

	public long customAttackInput = 100L;

	public long customDefenseInput = 100L;

	public long customPowerInput = 10000L;

	public long customToughnessInput = 10000L;

	public long customHPInput = 100000L;

	public long customRegenInput = 10000L;

	public bool beastModeUnlocked;

	public bool diggersOn;

	public difficulty nguLevelTrack;

	public bool pitUnlocked;

	public int themeID;

	public int genericRes3ColourID;

	public bool beastConfirmation = true;

	public bool beastOn;

	public bool useMajorQuests = true;

	public bool autoNukeOn;

	public float nguCapModifier = 1f;

	public bool idleQuestAutocycle = true;

	public bool res3NameGeneratorOn;

	public bool claimedKartPromo;

	public bool claimedSteamPromo;

	public bool assholeSetting = true;

	public bool badge1Complete;

	public bool badge2Started;

	public bool badge2Part1Complete;

	public bool badge2Part2Complete;

	public bool badge2Part3Complete;

	public bool badge2Part4Complete;

	public bool invAutoMergeOn = true;

	public bool invAutoBoostOn = true;

	public bool exilev4Defeated;

	public int prizePicked;

	public bool picked2ndPrize;

	public bool isNaughty;

	public bool foilsOn = true;

	public PlayerSettings()
	{
		numberDisplay = 0;
		tooltipsOn = true;
		special1Bought = false;
		special2Bought = false;
		special3Bought = false;
		filterTitan = false;
		specialAdvHpBars = true;
		filterOn = true;
		wandoos98On = false;
		yggdrasilOn = false;
		customEnergy1 = 0L;
		customEnergy2 = 0L;
		customMagic1 = 0L;
		customMagic2 = 0L;
		hasHyperRegen = false;
		syncTraining = false;
		rebirthDifficulty = difficulty.normal;
		rebirthLevels = 0L;
		speedrunCount = 0;
		gotSpeedrunSecret = false;
		nguOn = false;
		inventoryOn = false;
		antiFlickerBars = false;
		autoAssignOn = false;
		autoAssignTime = 0f;
		machineEnergyAmount = 0L;
		machineGoldMultiAmount = 0L;
		tutorialState = -1;
		tutorialOffForever = false;
		tutorial1Complete = false;
		expPopups = true;
		dailySaveRewardTime = new PlayerTime();
		submitHighscores = true;
		timedTooltipsOn = true;
		inputAmount = 250L;
		autoKillTitans = true;
		autoMergeOn = false;
		autoBoostOn = false;
		invAutoMergeOn = true;
		invAutoBoostOn = true;
		customEnergyPercent1 = 1f;
		customEnergyPercent2 = 1f;
		customMagicPercent1 = 1f;
		customMagicPercent2 = 1f;
		customRes3Percent1 = 1f;
		customRes3Percent2 = 1f;
		customIdleEnergyPercent1 = 1f;
		customIdleEnergyPercent2 = 1f;
		customIdleMagicPercent1 = 1f;
		customIdleMagicPercent2 = 1f;
		customIdleRes3Percent1 = 1f;
		customIdleRes3Percent2 = 1f;
		autoboostRecycledBoosts = false;
		unassignWhenSwapping = false;
		shakeySales = false;
		beardsOn = false;
		beardPopup = false;
		checkForUpdates = true;
		fancyYggBars = true;
		autoTransform = 0;
		simpleInvShortcuts = false;
		poopOnlyMaxTier = false;
		itopodOn = false;
		itopodConfirmation = true;
		buffedKillsOn = false;
		customPowerAmount = 1;
		customBarAmount = 1;
		customCapAmount = 10000L;
		customMagicPowerAmount = 1;
		customMagicBarAmount = 1;
		customMagicCapAmount = 10000L;
		customRes3PowerAmount = 1;
		customRes3BarAmount = 1;
		customRes3CapAmount = 10000L;
		customAttackInput = 100L;
		customDefenseInput = 100L;
		beastModeUnlocked = false;
		diggersOn = false;
		nguLevelTrack = difficulty.normal;
		themeID = 0;
		genericRes3ColourID = 0;
		beastConfirmation = true;
		beastOn = false;
		useMajorQuests = true;
		autoNukeOn = false;
		nguCapModifier = 1f;
		idleQuestAutocycle = true;
		res3NameGeneratorOn = false;
		claimedKartPromo = false;
		claimedSteamPromo = false;
		assholeSetting = true;
		badge1Complete = false;
		badge2Started = false;
		badge2Part1Complete = false;
		badge2Part2Complete = false;
		badge2Part3Complete = false;
		badge2Part4Complete = false;
		exilev4Defeated = false;
		prizePicked = 0;
		foilsOn = true;
	}

	public void updateSettings()
	{
	}
}
