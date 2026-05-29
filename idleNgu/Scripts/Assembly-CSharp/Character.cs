using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
	public platform platform;

	public HoverTooltip tooltip;

	public ImportExport importExport;

	public OpenFileDialog saveLoad;

	public BossController bossController;

	public InventoryController inventoryController;

	public AdventureController adventureController;

	public AllAugsController augmentsController;

	public AllAdvancedTraining advancedTrainingController;

	public TimeMachineController timeMachineController;

	public AllBloodMagicController bloodMagicController;

	public AllOffenseTraining allOffenseController;

	public AllDefenseTraining allDefenseController;

	public Wandoos98Controller wandoos98Controller;

	public AllYggdrasil yggdrasilController;

	public AllNGUController NGUController;

	public PitController pitController;

	public ItemNameDesc itemInfo;

	public AllChallengesController allChallenges;

	public AllArbitraryController allArbitrary;

	public AllItemListController allItemList;

	public AllSettingsController allSettings;

	public EnergyInputController energyMagicPanel;

	public AllAchievementsController allAchievements;

	public AllBeardsController allBeards;

	public AllGoldDiggerController allDiggers;

	public StatsDisplay statDisplay;

	public MiscStatsDisplay miscDisplay;

	public DailyRewardController dailyController;

	public KongregateAPIBehaviour API;

	public AGAPI AGAPI;

	public KartridgeAPI KartridgeAPI;

	public SteamManager steamAPI;

	public UIThemeController uiThemes;

	public ItopodNameListController itopodNames;

	public BeastQuestController beastQuestController;

	public BeastQuestPerkController beastQuestPerkController;

	public Resource3Display res3Display;

	public HacksController hacksController;

	public InfonStuffController InfonStuffController;

	public WishesController wishesController;

	public RebirthPowerSpell bloodSpells;

	public MainMenuController mainMenu;

	public NGUResolutions nguResolutions;

	public VersionNumbering versionNumbering;

	public OfflineProgressSplashScreen splashScreen;

	public InputField requested;

	public NumberFormat format;

	public Rebirth rebirth;

	public MagicPurchases magicPurchases;

	public EnergyPurchases energyPurchases;

	public StatBoostPurchases statBoostPurchases;

	public MiscPurchases miscPurchases;

	public Resource3Purchases res3Purchases;

	public AdventurePurchases adventurePurchases;

	public YggdrasilEXPPurchases yggdrasilPurchases;

	public SpendExpButtons expButtons;

	public ButtonShower buttons;

	public StartMenu introMenu;

	public MenuSwapper menuSwapper;

	public WaldoSaysUnlocker waldoUnlocker;

	public ApPackDisplay APPackDisplay;

	public InfoDisplay wtfPage;

	public SpecialController specialprize;

	public BestiaryController bestiaryController;

	public XmasController xmas;

	public CardsController cardsController;

	public CookingController cookingController;

	public InputField loadoutLabels;

	public InputField EMInputBox;

	public InputField res3NameInput;

	public EnergyInputController input;

	public List<GameObject> endPanels;

	public static bool testing;

	public int version;

	public string playerName;

	public bool firstTimePlaying;

	public int playerID;

	public string message;

	public int lastTime;

	public int menuID;

	public difficulty nextRebirthDifficulty;

	public double curHP;

	public double maxHP;

	public double hpRegen;

	public double attack;

	public double defense;

	public float gold;

	public double realGold;

	public double attackMulti;

	public double defenseMulti;

	public double nextAttackMulti;

	public double nextDefenseMulti;

	public double oldBossMulti;

	public double timeMulti;

	public double oldTimeMulti;

	public int exp;

	public long realExp;

	public float attackBoost;

	public float defenseBoost;

	public float energySpeed;

	public long capEnergy;

	public long curEnergy;

	public long idleEnergy;

	public long energyGained;

	public int energyPerBar;

	public long energyBars;

	public float energyPower;

	public float energyBarProgress;

	public Training training = new Training();

	public int bossID;

	public double bossAttack;

	public double bossDefense;

	public double bossRegen;

	public double bossCurHP;

	public double bossMaxHP;

	public double bossMulti;

	public int highestBoss;

	public int highestHardBoss;

	public int highestSadisticBoss;

	public Adventure adventure;

	public Inventory inventory;

	public AdvancedTraining advancedTraining;

	public Augmentation augments;

	public Magic magic;

	public TimeMachine machine;

	public BloodMagic bloodMagic;

	public PlayerTime rebirthTime;

	public PlayerTime totalPlaytime;

	public UnityEngine.Random.State adventureState;

	public UnityEngine.Random.State lootState;

	public UnityEngine.Random.State boostState;

	public Purchases purchases;

	public Stats stats;

	public Perks perks;

	public Bestiary bestiary;

	public PlayerSettings settings;

	public Challenges challenges;

	public Pit pit;

	public LootBoxes lootBoxes;

	public Wandoos98 wandoos98;

	public Yggdrasil yggdrasil;

	public NUMBERSSGOUP NGU;

	public Arbitrary arbitrary;

	public AchievementList achievements;

	public DailyReward daily;

	public Beards beards;

	public GoldDiggers diggers;

	public BeastQuest beastQuest;

	public Resource3 res3;

	public Hacks hacks;

	public Wishes wishes;

	public PlayerPortraits portraits;

	public Cards cards;

	public Cooking cooking;

	public float barProgressAdded;

	public long levelsAdded;

	public long secondsIdleBeast;

	public double hardModifier = 1E+25;

	public double sadisticModifier = 1E+50;

	public bool ignoreOfflineProgress;

	public bool firstBossEver;

	public int currentHighestBoss;

	public void Awake()
	{
		QualitySettings.vSyncCount = 1;
		playerName = "Bob";
		firstTimePlaying = true;
		menuID = 0;
		curHP = 10.0;
		maxHP = 10.0;
		hpRegen = 1.0;
		attack = 100.0;
		defense = 100.0;
		gold = 0f;
		attackMulti = 1.0;
		defenseMulti = 1.0;
		nextAttackMulti = 1.0;
		nextDefenseMulti = 1.0;
		oldBossMulti = 1.0;
		oldTimeMulti = 1.0;
		exp = 0;
		realExp = 0L;
		attackBoost = 1f;
		defenseBoost = 1f;
		energySpeed = 1f;
		capEnergy = 500L;
		curEnergy = 250L;
		idleEnergy = 250L;
		energyGained = 0L;
		energyPerBar = 1;
		energyBars = 1L;
		energyPower = 1f;
		bossID = 0;
		bossAttack = 50000.0;
		bossDefense = 40000.0;
		bossRegen = 40.0;
		bossCurHP = 500000.0;
		bossMaxHP = 500000.0;
		bossMulti = 1.0;
		highestBoss = 1;
		highestHardBoss = 1;
		highestSadisticBoss = 1;
		firstBossEver = true;
		currentHighestBoss = 1;
		adventure = new Adventure();
		inventory = new Inventory();
		advancedTraining = new AdvancedTraining();
		augments = new Augmentation();
		magic = new Magic();
		res3 = new Resource3();
		machine = new TimeMachine();
		bloodMagic = new BloodMagic();
		rebirthTime = new PlayerTime();
		totalPlaytime = new PlayerTime();
		purchases = new Purchases();
		stats = new Stats();
		perks = new Perks();
		bestiary = new Bestiary();
		settings = new PlayerSettings();
		challenges = new Challenges();
		wandoos98 = new Wandoos98();
		yggdrasil = new Yggdrasil();
		NGU = new NUMBERSSGOUP();
		arbitrary = new Arbitrary();
		achievements = new AchievementList();
		daily = new DailyReward();
		beards = new Beards();
		diggers = new GoldDiggers();
		beastQuest = new BeastQuest();
		hacks = new Hacks();
		wishes = new Wishes();
		portraits = new PlayerPortraits();
		cards = new Cards();
		cooking = new Cooking();
		cookingController.assignNewDish();
		UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
		lootState = UnityEngine.Random.state;
		adventureState = UnityEngine.Random.state;
		boostState = UnityEngine.Random.state;
		pit.pitState = UnityEngine.Random.state;
		inventory.boostCombineState = UnityEngine.Random.state;
		daily.dailyRewardState = UnityEngine.Random.state;
		beastQuest.questState = UnityEngine.Random.state;
		cards.cardState = UnityEngine.Random.state;
		cards.chonkerState = UnityEngine.Random.state;
		NGU.checkNGU();
		yggdrasil.checkYggdrasil();
		setVersion();
		setPlatform();
		if (platform == platform.Kartridge && Screen.width < 640 && Screen.height < 400)
		{
			Screen.SetResolution(960, 600, fullscreen: false);
			nguResolutions.setResID();
		}
		if (platform == platform.Steam && Screen.width < 640 && Screen.height < 400)
		{
			Screen.SetResolution(960, 600, fullscreen: false);
			nguResolutions.setResID();
		}
		foreach (specType value in Enum.GetValues(typeof(specType)))
		{
			inventoryController.bonuses.Add(value, 0f);
		}
		inventoryController.startBonuses();
		itemInfo.constructItemInfo();
		inventoryController.updateItemStats();
		inventoryController.updateInventory();
		inventoryController.updateBonuses();
		levelsAdded = 0L;
		barProgressAdded = 0f;
		if (PlayerPrefs.GetInt("stupidThing", 0) != 1)
		{
			Screen.SetResolution(960, 600, fullscreen: false);
			nguResolutions.setResID();
			PlayerPrefs.SetInt("stupidThing", 1);
		}
	}

	public int getVersion()
	{
		return 1260;
	}

	public string getVersionAsString()
	{
		return getVersion() / 1000 + "." + (getVersion() % 1000).ToString("000") + " " + versionNumbering.curBeta;
	}

	public string getVersionAsString(int version)
	{
		return version / 1000 + "." + (version % 1000).ToString("000");
	}

	public void setPlatform()
	{
		platform = platform.Steam;
	}

	public void publicTest()
	{
	}

	public void testZone()
	{
	}

	public void setVersion()
	{
		version = getVersion();
	}

	private void Start()
	{
		inventoryController.updateItemStats();
		inventoryController.updateInventory();
		_ = Application.platform;
		_ = 17;
		Invoke("initialStart", 0.5f);
		if (Application.platform == RuntimePlatform.WindowsEditor)
		{
			Invoke("testZone", 5.1f);
		}
		Invoke("publicTest", 10f);
		InvokeRepeating("updateCharacter", 0f, 0.5f);
		InvokeRepeating("updateHP", 0f, 0.02f);
		buttons.updateButtons();
		refreshMenus();
	}

	public void initialStart()
	{
		mainMenu.startMainMenu();
		saveLoad.setAutosave();
		if (platform == platform.Kartridge)
		{
			saveLoad.setCloudSave();
		}
		else if (platform == platform.Steam)
		{
			saveLoad.setCloudSave();
		}
		else if (platform == platform.Kong)
		{
			Invoke("cloudSaveCheck", 5f);
		}
	}

	public void cloudSaveCheck()
	{
		mainMenu.cloudSaveCheck();
	}

	public void Update()
	{
		if (menuID == 3)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				adventureController.idleAttackMove.setToggle();
			}
			else if (Input.GetKeyDown(KeyCode.W))
			{
				adventureController.regularAttackMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				adventureController.strongAttackMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.R))
			{
				adventureController.parryMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.T))
			{
				adventureController.pierceMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.Y))
			{
				adventureController.ultimateAttackMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.A))
			{
				adventureController.blockMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.S))
			{
				adventureController.defenseBuffMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.D))
			{
				adventureController.healMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.F))
			{
				adventureController.offenseBuffMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.G))
			{
				adventureController.chargeMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.H))
			{
				adventureController.ultimateBuffMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.Z))
			{
				adventureController.paralyzeMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.X))
			{
				adventureController.hyperRegenMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.C) && settings.beastModeUnlocked)
			{
				adventureController.beastModeMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.V) && training.defenseTraining[4] >= 25000 && wishes.wishes[8].level >= 1)
			{
				adventureController.megaBuffMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.B) && wishes.wishes[58].level >= 1 && allChallenges.hasParalyze() && training.defenseTraining[1] >= 10000 && settings.hasHyperRegen)
			{
				adventureController.ohShitMove.doMove();
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				adventureController.zoneBackwards.zoneBack();
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				adventureController.zoneForward.tryZoneForward();
			}
		}
		if (menuID == 4)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				inventoryController.changePage(0);
			}
			if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryController.curPages() >= 2)
			{
				inventoryController.changePage(1);
			}
			if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryController.curPages() >= 3)
			{
				inventoryController.changePage(2);
			}
			if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryController.curPages() >= 4)
			{
				inventoryController.changePage(3);
			}
			if (Input.GetKeyDown(KeyCode.Alpha5) && inventoryController.curPages() >= 5)
			{
				inventoryController.changePage(4);
			}
			if (Input.GetKeyDown(KeyCode.Alpha6) && inventoryController.curPages() >= 6)
			{
				inventoryController.changePage(5);
			}
			if (Input.GetKeyDown(KeyCode.Alpha7) && inventoryController.curPages() >= 7)
			{
				inventoryController.changePage(6);
			}
			if (Input.GetKeyDown(KeyCode.Alpha8) && inventoryController.curPages() >= 8)
			{
				inventoryController.changePage(7);
			}
			if (Input.GetKeyDown(KeyCode.Alpha9) && inventoryController.curPages() >= 9)
			{
				inventoryController.changePage(8);
			}
			if (Input.GetKeyDown(KeyCode.Alpha0) && inventoryController.curPages() >= 10)
			{
				inventoryController.changePage(9);
			}
		}
		if (menuID == 55)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				cardsController.deckPageBack();
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				cardsController.deckPageForward();
			}
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				cardsController.trySetPage(0);
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				cardsController.trySetPage(1);
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				cardsController.trySetPage(2);
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				cardsController.trySetPage(3);
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				cardsController.trySetPage(4);
			}
			if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				cardsController.trySetPage(5);
			}
			if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				cardsController.trySetPage(6);
			}
			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				cardsController.trySetPage(7);
			}
			if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				cardsController.trySetPage(8);
			}
			if (Input.GetKeyDown(KeyCode.Alpha0))
			{
				cardsController.trySetPage(9);
			}
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			if (adventure.titan7questStarted && !adventure.titan7questComplete && menuID == 15 && bossID == 24 && adventure.titan7QuestSequence == 0)
			{
				adventure.titan7QuestSequence = 1;
				tooltip.showOverrideTooltip("COMBINATION LOCK 1 DISENGAGED!", 1f);
			}
			else if (menuID != 3 && !loadoutLabels.isFocused && !EMInputBox.isFocused && !res3NameInput.isFocused && res3.res3On)
			{
				removeAllRes3();
				tooltip.showTooltip(res3.res3Name + " reclaimed from all features!", 1f);
				refreshMenus();
			}
		}
		if (Input.GetKeyDown(KeyCode.A) && adventure.titan7questStarted && !adventure.titan7questComplete && menuID == 15 && bossID == 41 && adventure.titan7QuestSequence == 1)
		{
			adventure.titan7QuestSequence = 2;
			tooltip.showOverrideTooltip("COMBINATION LOCK 2 DISENGAGED!", 1f);
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			if (adventure.titan7questStarted && !adventure.titan7questComplete && menuID == 15 && bossID == 62 && adventure.titan7QuestSequence == 2)
			{
				adventure.titan7QuestSequence = 3;
				tooltip.showOverrideTooltip("COMBINATION LOCK 3 DISENGAGED!", 1f);
			}
			else if (menuID != 3 && !loadoutLabels.isFocused && !EMInputBox.isFocused && !res3NameInput.isFocused)
			{
				removeMostEnergy();
				tooltip.showTooltip("Energy reclaimed from all features except training!", 1f);
				refreshMenus();
			}
		}
		if (Input.GetKeyDown(KeyCode.T))
		{
			if (adventure.titan7questStarted && !adventure.titan7questComplete && menuID == 15 && bossID == 81 && adventure.titan7QuestSequence == 3)
			{
				adventure.titan7QuestSequence = 4;
				tooltip.showOverrideTooltip("COMBINATION LOCK 4 DISENGAGED", 1f);
			}
			else if (menuID != 3 && !loadoutLabels.isFocused && !EMInputBox.isFocused && !res3NameInput.isFocused)
			{
				removeMostMagic();
				tooltip.showTooltip("Magic reclaimed from all features!", 1f);
				refreshMenus();
			}
		}
		if (Input.GetKeyDown(KeyCode.S) && adventure.titan7questStarted && !adventure.titan7questComplete && menuID == 15 && bossID == 120 && adventure.titan7QuestSequence == 4)
		{
			adventure.titan7QuestSequence = 5;
			adventure.titan7Unlocked = true;
			adventure.titan7questComplete = true;
			tooltip.showOverrideTooltip("COMBINATION LOCK 5 DISENGAGED! GREASY NERD TITAN UNLOCKED!", 1f);
		}
		if (settings.tutorialState >= 0)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				tooltip.advance();
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				tooltip.back();
			}
		}
		if (menuID == 39)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				allBeards.beard.beardBack();
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				allBeards.beard.beardForward();
			}
		}
	}

	public bool shouldUpdateBar(float barValue, float newValue)
	{
		return Mathf.Abs(barValue - newValue) >= 0.001f;
	}

	public void hardReset()
	{
		rebirth.hardReset();
		bool hasSpecialPrize = purchases.hasSpecialPrize1;
		QualitySettings.vSyncCount = 1;
		firstTimePlaying = true;
		menuID = 0;
		curHP = 10.0;
		maxHP = 10.0;
		hpRegen = 1.0;
		attack = 100.0;
		defense = 100.0;
		gold = 0f;
		realGold = 0.0;
		attackMulti = 1.0;
		defenseMulti = 1.0;
		nextAttackMulti = 1.0;
		nextDefenseMulti = 1.0;
		oldBossMulti = 1.0;
		oldTimeMulti = 1.0;
		exp = 0;
		realExp = 0L;
		attackBoost = 1f;
		defenseBoost = 1f;
		energySpeed = 1f;
		capEnergy = 500L;
		curEnergy = 250L;
		idleEnergy = 250L;
		energyGained = 0L;
		energyPerBar = 1;
		energyBars = 1L;
		energyPower = 1f;
		bossID = 0;
		bossAttack = 50000.0;
		bossDefense = 40000.0;
		bossRegen = 40.0;
		bossCurHP = 500000.0;
		bossMaxHP = 500000.0;
		bossMulti = 1.0;
		highestBoss = 1;
		highestHardBoss = 1;
		highestSadisticBoss = 1;
		firstBossEver = true;
		currentHighestBoss = 1;
		training = new Training();
		adventure = new Adventure();
		inventory = new Inventory();
		advancedTraining = new AdvancedTraining();
		augments = new Augmentation();
		magic = new Magic();
		res3 = new Resource3();
		machine = new TimeMachine();
		bloodMagic = new BloodMagic();
		rebirthTime = new PlayerTime();
		totalPlaytime = new PlayerTime();
		purchases = new Purchases();
		stats = new Stats();
		perks = new Perks();
		settings = new PlayerSettings();
		challenges = new Challenges();
		wandoos98 = new Wandoos98();
		yggdrasil = new Yggdrasil();
		NGU = new NUMBERSSGOUP();
		beards = new Beards();
		diggers = new GoldDiggers();
		beastQuest = new BeastQuest();
		hacks = new Hacks();
		wishes = new Wishes();
		achievements = new AchievementList();
		UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
		lootState = UnityEngine.Random.state;
		adventureState = UnityEngine.Random.state;
		boostState = UnityEngine.Random.state;
		pit.pitState = UnityEngine.Random.state;
		inventory.boostCombineState = UnityEngine.Random.state;
		refreshMenus();
		purchases.hasSpecialPrize1 = hasSpecialPrize;
		menuSwapper.swapMenu(0);
	}

	public void refreshMenus()
	{
		allOffenseController.refresh();
		allDefenseController.refresh();
		inventoryController.updateBonuses();
		bossController.updateMenu();
		adventureController.updateAdventureStats();
		adventureController.updateMenu();
		augmentsController.updateMenu();
		timeMachineController.updateMenu();
		bloodMagicController.updateMenu();
		adventurePurchases.refresh();
		statBoostPurchases.refresh();
		energyPurchases.refresh();
		magicPurchases.refresh();
		miscPurchases.refresh();
		res3Purchases.refresh();
		yggdrasilPurchases.refresh();
		expButtons.refresh();
		advancedTrainingController.refresh();
		NGUController.refreshMenu();
		inventoryController.updateInventory();
		pitController.refreshMenu();
		wandoos98Controller.refreshMenu();
		allItemList.refreshMenu();
		allSettings.updateMenu();
		energyMagicPanel.updateMenu();
		allArbitrary.updateMenu();
		statDisplay.refreshMenu();
		yggdrasilController.refreshMenu();
		dailyController.refreshMenu();
		allBeards.refreshMenu();
		allDiggers.refreshMenu();
		adventureController.itopod.updateMenu();
		APPackDisplay.refreshMenu();
		wtfPage.refreshMenu();
		rebirth.updateDifficultyButtons();
		specialprize.refreshMenu();
		itopodNames.updateMenu();
		beastQuestController.refreshMenu();
		beastQuestPerkController.refreshMenu();
		hacksController.refreshMenu();
		InfonStuffController.updateMenu();
		wishesController.updateMenu();
		dailyController.reConstructRewardNames();
		bestiaryController.updateMenu();
		xmas.updateMenu();
		cardsController.updateMenu();
		cookingController.updateMenu();
	}

	public string display(double number)
	{
		return NumberOutput.suffixFormat(number, settings.numberDisplay);
	}

	public long hardCap()
	{
		return 9000000000000000000L;
	}

	public long hardCapPowBar()
	{
		return 1000000000000000000L;
	}

	public void resetAll()
	{
		if (challenges.trollChallenge.inChallenge)
		{
			allChallenges.trollChallenge.resetTrolls();
		}
		allOffenseController.reset();
		allDefenseController.reset();
		inventoryController.reset();
		wandoos98Controller.reset();
		adventureController.reset();
		augmentsController.reset();
		timeMachineController.reset();
		bloodMagicController.reset();
		advancedTrainingController.reset();
		yggdrasilController.reset();
		NGUController.reset();
		allArbitrary.reset();
		allBeards.reset();
		allDiggers.reset();
		hacksController.reset();
		wishesController.reset();
	}

	public void removeMostEnergy()
	{
		wandoos98Controller.removeAllEnergy();
		augmentsController.removeAllEnergy();
		timeMachineController.removeAllEnergy();
		advancedTrainingController.removeAllEnergy();
		NGUController.removeAllEnergy();
		wishesController.removeAllEnergy();
		if (idleEnergy < 0)
		{
			idleEnergy = 0L;
		}
	}

	public void removeMostMagic()
	{
		wandoos98Controller.removeAllMagic();
		timeMachineController.removeAllMagic();
		bloodMagicController.removeAllMagic();
		wandoos98Controller.removeAllMagic();
		NGUController.removeAllMagic();
		wishesController.removeAllMagic();
	}

	public void removeAllEnergy()
	{
		allOffenseController.removeAllEnergy();
		allDefenseController.removeAllEnergy();
		wandoos98Controller.removeAllEnergy();
		augmentsController.removeAllEnergy();
		timeMachineController.removeAllEnergy();
		advancedTrainingController.removeAllEnergy();
		NGUController.removeAllEnergy();
		wishesController.removeAllEnergy();
	}

	public void removeAllMagic()
	{
		wandoos98Controller.removeAllMagic();
		timeMachineController.removeAllMagic();
		bloodMagicController.removeAllMagic();
		wandoos98Controller.removeAllMagic();
		NGUController.removeAllMagic();
		wishesController.removeAllMagic();
	}

	public void removeAllRes3()
	{
		hacksController.removeAllR3();
		wishesController.removeAllRes3();
	}

	public void removeAllEnergyAndMagic()
	{
		wandoos98Controller.removeAllEnergy();
		augmentsController.removeAllEnergy();
		timeMachineController.removeAllEnergy();
		advancedTrainingController.removeAllEnergy();
		NGUController.removeAllEnergy();
		wishesController.removeAllEnergy();
		wandoos98Controller.removeAllMagic();
		timeMachineController.removeAllMagic();
		bloodMagicController.removeAllMagic();
		wandoos98Controller.removeAllMagic();
		NGUController.removeAllMagic();
		wishesController.removeAllMagic();
		allOffenseController.removeAllEnergy();
		allDefenseController.removeAllEnergy();
		hacksController.removeAllR3();
		wishesController.removeAllRes3();
	}

	public void doInstaTrainingCap()
	{
		if (idleEnergy >= 12)
		{
			idleEnergy -= 12L;
			training.attackEnergy[0] = 6L;
			training.defenseEnergy[0] = 6L;
		}
	}

	public long machineBossMulti()
	{
		return Mathf.Max(highestBoss - 27, 1);
	}

	private void updateCharacter()
	{
		attack = 100.0 + training.getTotalAttack() * attackMulti * adventureController.itopod.totalStatBonus() * (double)(1f + inventoryController.attackBonus() / 100f) * (double)attackBoost;
		attack /= difficultyModifier();
		attack *= augmentsController.totalBonus() * wandoos98Controller.wandoosBonus();
		attack *= (1.0 + yggdrasil.totalStatBonus()) * NGUController.statBonus() * yggdrasilController.permStatBonus() * yggdrasilController.permStatBonus2();
		attack *= allBeards.statBonus() * allDiggers.totalStatBonus();
		attack *= beastQuestPerkController.totalStatBonus();
		attack *= hacksController.totalStatBonus();
		attack *= wishesController.totalStatBonus();
		attack *= cardsController.getBonus(cardBonus.atkDefStats);
		attack *= inventory.macguffinBonuses[13];
		defense = 100.0 + training.getTotalDefense() * defenseMulti * adventureController.itopod.totalStatBonus() * (double)(1f + inventoryController.defenseBonus() / 100f) * (double)defenseBoost;
		defense /= difficultyModifier();
		defense *= augmentsController.totalBonus() * wandoos98Controller.wandoosBonus();
		defense *= (1.0 + yggdrasil.totalStatBonus()) * NGUController.statBonus() * yggdrasilController.permStatBonus() * yggdrasilController.permStatBonus2();
		defense *= allBeards.statBonus() * allDiggers.totalStatBonus();
		defense *= beastQuestPerkController.totalStatBonus();
		defense *= hacksController.totalStatBonus();
		defense *= wishesController.totalStatBonus();
		defense *= cardsController.getBonus(cardBonus.atkDefStats);
		defense *= inventory.macguffinBonuses[13];
		maxHP = 10.0 + attack * 10.0;
		if (double.IsInfinity(attack) || double.IsPositiveInfinity(attack))
		{
			attack = double.MaxValue;
		}
		if (double.IsInfinity(defense) || double.IsPositiveInfinity(defense))
		{
			defense = double.MaxValue;
		}
		if (double.IsInfinity(maxHP) || double.IsPositiveInfinity(maxHP))
		{
			maxHP = double.MaxValue;
		}
		testMode();
	}

	public double totalAttack()
	{
		double num = 100.0 + training.getTotalAttack() * attackMulti * adventureController.itopod.totalStatBonus() * (double)(1f + inventoryController.attackBonus() / 100f) * (double)attackBoost;
		num /= difficultyModifier();
		num *= augmentsController.totalBonus() * wandoos98Controller.wandoosBonus();
		num *= (1.0 + yggdrasil.totalStatBonus()) * NGUController.statBonus() * yggdrasilController.permStatBonus() * yggdrasilController.permStatBonus2();
		num *= allBeards.statBonus() * allDiggers.totalStatBonus();
		num *= (double)beastQuestPerkController.totalStatBonus();
		num *= (double)hacksController.totalStatBonus();
		num *= (double)wishesController.totalStatBonus();
		num *= (double)cardsController.getBonus(cardBonus.atkDefStats);
		num *= (double)inventory.macguffinBonuses[13];
		if (num < 100.0)
		{
			return 100.0;
		}
		return num;
	}

	public double totalDefense()
	{
		double num = 100.0 + training.getTotalDefense() * defenseMulti * adventureController.itopod.totalStatBonus() * (double)(1f + inventoryController.defenseBonus() / 100f) * (double)defenseBoost;
		num /= difficultyModifier();
		num *= augmentsController.totalBonus() * wandoos98Controller.wandoosBonus();
		num *= (1.0 + yggdrasil.totalStatBonus()) * NGUController.statBonus() * yggdrasilController.permStatBonus() * yggdrasilController.permStatBonus2();
		num *= allBeards.statBonus() * allDiggers.totalStatBonus();
		num *= (double)beastQuestPerkController.totalStatBonus();
		num *= (double)hacksController.totalStatBonus();
		num *= (double)wishesController.totalStatBonus();
		num *= (double)cardsController.getBonus(cardBonus.atkDefStats);
		num *= (double)inventory.macguffinBonuses[13];
		if (num < 100.0)
		{
			return 100.0;
		}
		return num;
	}

	private void updateHP()
	{
		curHP = curHP + 0.001 + 0.001 * defense;
		if (curHP >= maxHP)
		{
			curHP = maxHP;
		}
		if (double.IsNaN(curHP))
		{
			curHP = 0.0;
		}
	}

	public void OnApplicationQuit()
	{
		if (allSettings.resolutions.midChange)
		{
			tooltip.showOverrideTooltip("boogywoogy");
			allSettings.resolutions.revertResolution();
		}
	}

	public long addEnergy()
	{
		if (idleEnergy == 0L)
		{
			return 0L;
		}
		long val = long.Parse(requested.text);
		val = Math.Min(val, idleEnergy);
		idleEnergy -= val;
		return val;
	}

	public long addMagic()
	{
		if (magic.idleMagic == 0L)
		{
			return 0L;
		}
		long val = long.Parse(requested.text);
		val = Math.Min(val, magic.idleMagic);
		magic.idleMagic -= val;
		return val;
	}

	public double difficultyModifier()
	{
		if (settings.rebirthDifficulty == difficulty.evil)
		{
			return hardModifier;
		}
		if (settings.rebirthDifficulty == difficulty.sadistic)
		{
			return sadisticModifier;
		}
		return 1.0;
	}

	public float totalEnergySpeed()
	{
		float num = energySpeed * (1f + inventoryController.bonuses[specType.EnergySpeed]);
		if (num < 1f)
		{
			num = 1f;
		}
		if (num > 50f)
		{
			num = 50f;
		}
		return num;
	}

	public float energyPerSecond()
	{
		float num = totalEnergySpeed();
		return 50f / (float)Mathf.CeilToInt(50f / num) * (float)totalEnergyBar();
	}

	public float totalEnergyPower()
	{
		double num = energyPower * adventureController.itopod.totalEnergyPowerBonus() * (1f + inventoryController.bonuses[specType.EnergyPower] + inventoryController.bonuses[specType.EnergyPower2] + inventoryController.bonuses[specType.EnergyPower3] + inventoryController.bonuses[specType.AllPower]);
		num *= (double)inventory.macguffinBonuses[0];
		num *= (double)beastQuestPerkController.totalEnergyPowerBonus();
		num *= (double)wishesController.totalEnergyPowerBonus();
		if (num < 1.0)
		{
			num = 1.0;
		}
		if (num >= (double)hardCapPowBar())
		{
			num = hardCapPowBar();
		}
		if (arbitrary.energyPotion1Time.totalseconds > 0.0)
		{
			num *= (double)allArbitrary.potionModifier();
		}
		if (arbitrary.energyPotion2InUse)
		{
			num *= (double)allArbitrary.potionModifier();
		}
		return (float)num;
	}

	public long totalEnergyBar()
	{
		double num = (float)energyBars * adventureController.itopod.totalEnergyBarBonus() * beastQuestPerkController.totalEnergyBarBonus() * wishesController.totalEnergyBarBonus() * inventory.macguffinBonuses[6] * (1f + inventoryController.bonuses[specType.EnergyPerBar] + inventoryController.bonuses[specType.EnergyPerBar2] + inventoryController.bonuses[specType.EnergyPerBar3] + inventoryController.bonuses[specType.AllPerBar]);
		if (num > (double)hardCapPowBar())
		{
			num = hardCapPowBar();
		}
		if (arbitrary.energyBarBar1Time.totalseconds > 0.0)
		{
			num = (long)(num * (double)allArbitrary.potionModifier());
		}
		if (num < 1.0)
		{
			num = 1.0;
		}
		return (long)num;
	}

	public long totalCapEnergy()
	{
		double num = (double)((float)capEnergy * adventureController.itopod.totalEnergyCapBonus() * inventory.macguffinBonuses[1]) * (1.0 + (double)inventoryController.bonuses[specType.EnergyCap] + (double)inventoryController.bonuses[specType.EnergyCap3] + (double)inventoryController.bonuses[specType.AllCap]);
		num *= (double)beastQuestPerkController.totalEnergyCapBonus();
		num *= (double)wishesController.totalEnergyCapBonus();
		if (num >= (double)hardCap())
		{
			num = hardCap();
		}
		if (num < 1.0)
		{
			num = 1.0;
		}
		long num2 = Convert.ToInt64(num);
		if (num2 >= hardCap())
		{
			num2 = hardCap();
		}
		if (num2 < 1)
		{
			num2 = 1L;
		}
		return num2;
	}

	public long totalCapEnergy(float invBonus)
	{
		float num = 1f;
		long num2 = Convert.ToInt64((float)capEnergy * num * invBonus);
		if (num2 < 1)
		{
			num2 = 1L;
		}
		return num2;
	}

	public float totalMagicPower()
	{
		double num = magic.magicPower * adventureController.itopod.totalMagicPowerBonus() * inventory.macguffinBonuses[2] * (1f + inventoryController.bonuses[specType.MagicPower] + inventoryController.bonuses[specType.MagicPower2] + inventoryController.bonuses[specType.MagicPower3] + inventoryController.bonuses[specType.AllPower]);
		num *= (double)beastQuestPerkController.totalMagicPowerBonus();
		num *= (double)wishesController.totalMagicPowerBonus();
		if (num < 1.0)
		{
			num = 1.0;
		}
		if (num >= (double)hardCapPowBar())
		{
			num = hardCapPowBar();
		}
		if (arbitrary.magicPotion1Time.totalseconds > 0.0)
		{
			num *= (double)allArbitrary.potionModifier();
		}
		if (arbitrary.magicPotion2InUse)
		{
			num *= (double)allArbitrary.potionModifier();
		}
		return (float)num;
	}

	public long totalMagicBar()
	{
		double num = (float)magic.magicPerBar * adventureController.itopod.totalMagicBarBonus() * beastQuestPerkController.totalMagicBarBonus() * wishesController.totalMagicBarBonus() * inventory.macguffinBonuses[7] * (1f + inventoryController.bonuses[specType.MagicPerBar] + inventoryController.bonuses[specType.MagicPerBar2] + inventoryController.bonuses[specType.MagicPerBar3] + inventoryController.bonuses[specType.AllPerBar]);
		if (num > (double)hardCapPowBar())
		{
			num = hardCapPowBar();
		}
		if (arbitrary.magicBarBar1Time.totalseconds > 0.0)
		{
			num = (long)(num * (double)allArbitrary.potionModifier());
		}
		if (num > 9.223372036854776E+18)
		{
			num = 9.223372036854776E+18;
		}
		if (num < 1.0)
		{
			num = 1.0;
		}
		return (long)num;
	}

	public long totalCapMagic()
	{
		double num = (float)magic.capMagic * adventureController.itopod.totalMagicCapBonus() * inventory.macguffinBonuses[3] * (1f + inventoryController.bonuses[specType.MagicCap] + inventoryController.bonuses[specType.MagicCap3] + inventoryController.bonuses[specType.AllCap]);
		num *= (double)beastQuestPerkController.totalMagicCapBonus();
		num *= (double)wishesController.totalMagicCapBonus();
		if (num >= (double)hardCap())
		{
			num = hardCap();
		}
		if (num < 1.0)
		{
			num = 1.0;
		}
		long num2 = Convert.ToInt64(num);
		if (num2 >= hardCap())
		{
			num2 = hardCap();
		}
		if (num2 < 1)
		{
			num2 = 1L;
		}
		return num2;
	}

	public long totalCapMagic(float invBonus)
	{
		long num = Convert.ToInt64((float)magic.capMagic * adventureController.itopod.totalMagicCapBonus() * invBonus);
		if (num < 1)
		{
			num = 1L;
		}
		return num;
	}

	public float totalRes3Power()
	{
		double num = res3.res3Power * (1f + inventoryController.bonuses[specType.Res3Power]) * inventory.macguffinBonuses[20];
		num *= (double)adventureController.itopod.totalRes3PowerBonus();
		num *= (double)beastQuestPerkController.totalRes3PowerBonus();
		num *= (double)wishesController.totalRes3PowerBonus();
		if (num >= (double)hardCapPowBar())
		{
			num = hardCapPowBar();
		}
		if (arbitrary.res3Potion1Time.totalseconds > 0.0)
		{
			num *= (double)allArbitrary.res3PotionModifier();
		}
		if (arbitrary.res3Potion2InUse)
		{
			num *= (double)allArbitrary.potionModifier();
		}
		if (num < 1.0)
		{
			num = 1.0;
		}
		return (float)num;
	}

	public long totalRes3Bar()
	{
		double num = (float)res3.res3PerBar * (1f + inventoryController.bonuses[specType.Res3Bar]) * inventory.macguffinBonuses[22] * adventureController.itopod.totalRes3BarBonus() * beastQuestPerkController.totalRes3BarBonus() * wishesController.totalRes3BarBonus();
		if (num >= (double)hardCapPowBar())
		{
			num = hardCapPowBar();
		}
		if (num < 1.0)
		{
			num = 1.0;
		}
		return (long)num;
	}

	public long totalCapRes3()
	{
		double num = (double)res3.capRes3 * (1.0 + (double)inventoryController.bonuses[specType.Res3Cap]) * (double)inventory.macguffinBonuses[21];
		num *= (double)adventureController.itopod.totalRes3CapBonus();
		num *= (double)beastQuestPerkController.totalRes3CapBonus();
		num *= (double)wishesController.totalRes3CapBonus();
		if (num >= (double)hardCap())
		{
			num = hardCap();
		}
		if (num < 1.0)
		{
			num = 1.0;
		}
		long num2 = Convert.ToInt64(num);
		if (num2 >= hardCap())
		{
			num2 = hardCap();
		}
		if (num2 < 1)
		{
			num2 = 1L;
		}
		return num2;
	}

	public float lootFactor()
	{
		float num = 1f;
		num = num * adventureController.itopod.totalDropChanceBonus() * inventory.macguffinBonuses[10] * (1f + inventoryController.bonuses[specType.Looting] + inventoryController.bonuses[specType.Looting2] + inventoryController.cubeLootBonus()) * bloodMagicController.lootBonus() * yggdrasilController.luckBonus() * NGUController.lootBonus() * allBeards.lootBonus() * allDiggers.totalDropChanceBonus() * hacksController.totalDropChanceBonus() * cardsController.getBonus(cardBonus.dropChance);
		if (inventory.itemList.twoDComplete)
		{
			num *= 1.0743f;
		}
		if (inventory.itemList.normalBonusAccComplete)
		{
			num *= 1.25f;
		}
		if (arbitrary.lootcharm1Time.totalseconds > 0.0)
		{
			num *= allArbitrary.potionModifier();
		}
		return num;
	}

	public float lootFactorRooted()
	{
		return Mathf.Pow(lootFactor(), 0.3333333f);
	}

	public float actualLootChancePercentRooted(float baseChance)
	{
		return baseChance * lootFactorRooted() * 100f;
	}

	public float actualLootChance(float baseChance)
	{
		return baseChance * lootFactor();
	}

	public float actualLootChancePercent(float baseChance)
	{
		return baseChance * lootFactor() * 100f;
	}

	public string lootChanceDisplayRooted(float baseChance, float cap)
	{
		if (cap > 100f)
		{
			cap = 100f;
		}
		float num = actualLootChancePercentRooted(baseChance);
		if (num >= cap)
		{
			return "<color=green>" + cap.ToString("##0.##") + "%</color>";
		}
		return num.ToString("##0.##") + "%";
	}

	public string lootChanceDisplay(float baseChance, float cap)
	{
		if (cap > 100f)
		{
			cap = 100f;
		}
		float num = actualLootChancePercent(baseChance);
		if (num >= cap)
		{
			return "<color=green>" + cap.ToString("##0.##") + "%</color>";
		}
		return num.ToString("##0.##") + "%";
	}

	public string lootChanceDisplay(float baseChance, float cap, float flatchance)
	{
		if (cap > 100f)
		{
			cap = 100f;
		}
		float num = flatchance * 100f + actualLootChancePercent(baseChance);
		if (num >= cap)
		{
			return "<color=green>" + cap.ToString("##0.##") + "%</color>";
		}
		return num.ToString("##0.##") + "%";
	}

	public string lootChanceDisplay(float baseChance)
	{
		return lootChanceDisplay(baseChance, 100f);
	}

	public float totalAdvAttack()
	{
		float num = (adventure.attack + inventoryController.adventureAttackBonus() + inventoryController.cubePower()) * (1f + advancedTrainingController.adventurePowerBonus(0)) * NGUController.adventureBonus() * NGUController.adventureBonus2() * allBeards.adventureBonus() * allDiggers.totalAdventureBonus();
		num *= allChallenges.adventureBonus();
		num *= adventureController.itopod.totalAdventureBonus();
		num *= adventureController.beastModeBonus();
		num *= beastQuestPerkController.totalAdventureBonus();
		num *= inventory.macguffinBonuses[19];
		num *= hacksController.totalAdventureBonus();
		num *= wishesController.totalAdventureBonus();
		num *= cardsController.getBonus(cardBonus.adventureStat);
		if (inventory.itemList.evilBonusAccComplete)
		{
			num *= 1.2f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		if (float.IsInfinity(num))
		{
			return 1E+36f;
		}
		if (float.IsNaN(num))
		{
			return 0f;
		}
		if (num > 1E+36f)
		{
			return 1E+36f;
		}
		return num;
	}

	public float totalAdvDefense()
	{
		float num = (adventure.defense + inventoryController.adventureDefenseBonus() + inventoryController.cubeToughness()) * (1f + advancedTrainingController.adventureToughnessBonus(0)) * NGUController.adventureBonus() * NGUController.adventureBonus2() * allBeards.adventureBonus() * allDiggers.totalAdventureBonus();
		num *= allChallenges.adventureBonus();
		num *= adventureController.itopod.totalAdventureBonus();
		num *= beastQuestPerkController.totalAdventureBonus();
		num *= inventory.macguffinBonuses[19];
		num *= hacksController.totalAdventureBonus();
		num *= wishesController.totalAdventureBonus();
		num *= cardsController.getBonus(cardBonus.adventureStat);
		if (inventory.itemList.evilBonusAccComplete)
		{
			num *= 1.2f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		if (float.IsInfinity(num))
		{
			return 1E+36f;
		}
		if (float.IsNaN(num))
		{
			return 0f;
		}
		if (num > 1E+36f)
		{
			return 1E+36f;
		}
		return num;
	}

	public float totalAdvHP()
	{
		float num = (adventure.maxHP + inventoryController.adventureHPBonus() + inventoryController.cubePower() * 3f) * (1f + advancedTrainingController.adventurePowerBonus(0)) * NGUController.adventureBonus() * NGUController.adventureBonus2() * allBeards.adventureBonus() * allDiggers.totalAdventureBonus();
		num *= allChallenges.adventureBonus();
		num *= adventureController.itopod.totalAdventureBonus();
		num *= beastQuestPerkController.totalAdventureBonus();
		num *= inventory.macguffinBonuses[19];
		num *= hacksController.totalAdventureBonus();
		num *= wishesController.totalAdventureBonus();
		num *= cardsController.getBonus(cardBonus.adventureStat);
		if (inventory.itemList.evilBonusAccComplete)
		{
			num *= 1.2f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		if ((double)num >= 1E+37)
		{
			return 1E+37f;
		}
		if (float.IsInfinity(num))
		{
			return 3E+38f;
		}
		if (float.IsNaN(num))
		{
			return 0f;
		}
		return num;
	}

	public float totalAdvHPRegen()
	{
		float num = (adventure.regen + inventoryController.adventureHPRegenBonus() + inventoryController.cubeToughness() * 0.03f) * (1f + advancedTrainingController.adventureToughnessBonus(0)) * NGUController.adventureBonus() * NGUController.adventureBonus2() * allBeards.adventureBonus() * allDiggers.totalAdventureBonus();
		num *= allChallenges.adventureBonus();
		num *= adventureController.itopod.totalAdventureBonus();
		num *= beastQuestPerkController.totalAdventureBonus();
		num *= inventory.macguffinBonuses[19];
		num *= hacksController.totalAdventureBonus();
		num *= wishesController.totalAdventureBonus();
		num *= cardsController.getBonus(cardBonus.adventureStat);
		if (inventory.itemList.evilBonusAccComplete)
		{
			num *= 1.2f;
		}
		if (num < 0.1f)
		{
			num = 0.1f;
		}
		if ((double)num >= 1E+36)
		{
			return 1E+36f;
		}
		if (float.IsInfinity(num))
		{
			return 1E+36f;
		}
		if (float.IsNaN(num))
		{
			return 0f;
		}
		return num;
	}

	public float totalDiscount()
	{
		return 1f;
	}

	public float augDiscount()
	{
		float result = 1f;
		if (allChallenges.noAugsChallenge.completions() >= allChallenges.noAugsChallenge.maxCompletions)
		{
			result = 0.5f;
		}
		return result;
	}

	public float totalCooldownBonus()
	{
		return 1f * (1f / (1f + inventoryController.bonuses[specType.Cooldown]));
	}

	public float idleAttackCooldown()
	{
		return adventureController.idleAttackCooldown * totalCooldownBonus();
	}

	public float idleAttackPower()
	{
		float num = 1f;
		num = ((!inventory.itemList.ghostComplete) ? adventureController.idleAttackMulti : adventureController.regAttackMulti);
		float num2 = 1f + 0.02f * (float)allChallenges.noEquipmentChallenge.sadisticCompletions();
		if (challenges.noEquipmentChallenge.curSadisticCompletions >= allChallenges.noEquipmentChallenge.maxCompletions)
		{
			num2 += 0.1f;
		}
		return num * num2;
	}

	public float regAttackCooldown()
	{
		return adventureController.regAttackCooldown * totalCooldownBonus();
	}

	public float regAttackPower()
	{
		return adventureController.regAttackMulti;
	}

	public float strongAttackCooldown()
	{
		return adventureController.strongAttackCooldown * totalCooldownBonus();
	}

	public float strongAttackPower()
	{
		return adventureController.strongAttackMulti;
	}

	public float pierceAttackCooldown()
	{
		return adventureController.pierceAttackCooldown * totalCooldownBonus();
	}

	public float pierceAttackPower()
	{
		return adventureController.pierceAttackMulti;
	}

	public float ultimateAttackCooldown()
	{
		return adventureController.ultimateAttackCooldown * totalCooldownBonus();
	}

	public float ultimateAttackPower()
	{
		float num = 2f + (float)highestBoss * 0.01f;
		if (inventory.itemList.jrpgComplete)
		{
			num += 2f;
		}
		return num;
	}

	public float offenseBuffCooldown()
	{
		return adventureController.offenseBuffCooldown * totalCooldownBonus();
	}

	public float offenseBuffPower()
	{
		return adventureController.offenseBuffMulti;
	}

	public float offenseBuffDuration()
	{
		return adventureController.offenseBuffDuration;
	}

	public float defenseBuffCooldown()
	{
		return adventureController.defenseBuffCooldown * totalCooldownBonus();
	}

	public float defenseBuffPower()
	{
		return adventureController.defenseBuffMulti;
	}

	public float defenseBuffDuration()
	{
		return adventureController.defenseBuffDuration;
	}

	public float ultimateBuffCooldown()
	{
		return adventureController.ultimateBuffCooldown * totalCooldownBonus();
	}

	public float megaBuffCooldown()
	{
		return 50f * totalCooldownBonus();
	}

	public float move69Cooldown()
	{
		return 3600f;
	}

	public float ohShitCooldown()
	{
		return 50f * totalCooldownBonus();
	}

	public float ultimateBuffPower()
	{
		return adventureController.ultimateBuffMulti;
	}

	public float ultimateBuffDuration()
	{
		return adventureController.ultimateBuffDuration;
	}

	public float megaBuffDuration()
	{
		return 15f;
	}

	public float chargeCooldown()
	{
		return adventureController.chargeCooldown * totalCooldownBonus();
	}

	public float chargePower()
	{
		float result = adventureController.chargeMulti;
		if (inventory.itemList.megaComplete)
		{
			result = 2.2f;
		}
		return result;
	}

	public float blockCooldown()
	{
		return adventureController.blockCooldown * totalCooldownBonus();
	}

	public float blockPower()
	{
		return adventureController.blockMulti;
	}

	public float blockDuration()
	{
		return adventureController.blockDuration;
	}

	public float parryCooldown()
	{
		return adventureController.parryCooldown * totalCooldownBonus();
	}

	public float parryPower()
	{
		return adventureController.parryMulti;
	}

	public float healCooldown()
	{
		return adventureController.healCooldown * totalCooldownBonus();
	}

	public float healPower()
	{
		return adventureController.healMulti;
	}

	public float paralyzeCooldown()
	{
		return adventureController.paralyzeCooldown * totalCooldownBonus();
	}

	public float paralyzePower()
	{
		return adventureController.paralyzeMulti;
	}

	public float hyperRegenCooldown()
	{
		return adventureController.hyperRegenCooldown * totalCooldownBonus();
	}

	public float beastModeCooldown()
	{
		return 15f * totalCooldownBonus();
	}

	public float totalMagicSpeed()
	{
		float num = magic.magicBarSpeed * (1f + inventoryController.bonuses[specType.MagicSpeed]);
		if (magic.magicBarSpeed >= 49.99f)
		{
			magic.magicBarSpeed = 50f;
		}
		if (num > 49.99f)
		{
			num = 50f;
		}
		return num;
	}

	public float magicPerSecond()
	{
		float num = totalMagicSpeed();
		return 50f / (float)Mathf.CeilToInt(50f / num) * (float)totalMagicBar();
	}

	public float totalRes3Speed()
	{
		return res3.res3BarSpeed;
	}

	public float res3PerSecond()
	{
		float num = totalRes3Speed();
		return 50f / (float)Mathf.CeilToInt(50f / num) * (float)totalRes3Bar();
	}

	public float totalGoldbonus()
	{
		float num = 1f * adventureController.itopod.totalGoldDropBonus() * inventory.macguffinBonuses[11] * beastQuestPerkController.totalGoldBonus() * (1f + inventoryController.bonuses[specType.GoldDropAmount] + inventoryController.bonuses[specType.GoldDrop2] + inventoryController.cubeGoldBonus()) * NGUController.goldBonus() * cardsController.getBonus(cardBonus.goldDrop);
		if (allChallenges.timeMachineChallenge.evilCompletions() >= 1)
		{
			num *= 2f;
		}
		return num;
	}

	public float totalRecycleBonus()
	{
		return purchases.boost + (float)challenges.basicChallenge.curCompletions * 0.1f;
	}

	public float totalWandoosEnergySpeed()
	{
		float num = wandoos98Controller.OSFactor() * wandoos98Controller.bootupSpeedFactor() * (1f + inventoryController.bonuses[specType.Wandoos98] + inventoryController.bonuses[specType.Wandoos2]) * (1f + advancedTrainingController.wandoosEnergy.trainingBonus(0));
		num = num * allChallenges.wandoosBonus() * allBeards.wandoosBonus();
		if (settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= wandoos98Controller.sadisticModifier();
		}
		num *= NGUController.wandoosBonus() * allDiggers.totalWandoosSpeedBonus();
		num *= inventory.macguffinBonuses[15];
		num *= beastQuestPerkController.totalEnergyWandoosBonus();
		return num * cardsController.getBonus(cardBonus.wandoosSpeed);
	}

	public float totalWandoosMagicSpeed()
	{
		float num = wandoos98Controller.OSFactor() * wandoos98Controller.bootupSpeedFactor() * (1f + inventoryController.bonuses[specType.Wandoos98] + inventoryController.bonuses[specType.Wandoos2]) * (1f + advancedTrainingController.wandoosMagic.trainingBonus(0));
		num = num * allChallenges.wandoosBonus() * allBeards.wandoosBonus();
		if (settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= wandoos98Controller.sadisticModifier();
		}
		num *= NGUController.wandoosBonus() * allDiggers.totalWandoosSpeedBonus();
		num *= inventory.macguffinBonuses[16];
		num *= beastQuestPerkController.totalMagicWandoosBonus();
		return num * cardsController.getBonus(cardBonus.wandoosSpeed);
	}

	public float wandoosDifficultyModifier()
	{
		float result = 1f;
		if (settings.rebirthDifficulty >= difficulty.evil)
		{
			result = 1E+18f;
		}
		if (settings.rebirthDifficulty >= difficulty.sadistic)
		{
			result = 1E+36f;
		}
		return result;
	}

	public float totalAdvancedTrainingSpeedBonus()
	{
		return 1f * (1f + inventoryController.bonuses[specType.AdvTraining] + inventoryController.bonuses[specType.AdvTraining2]);
	}

	public float totalNGUSpeedBonus()
	{
		float num = 1f + inventoryController.bonuses[specType.NGU] + inventoryController.bonuses[specType.NGU2];
		if (inventory.itemList.numberComplete)
		{
			num *= 1.1f;
		}
		if (inventory.itemList.metaComplete)
		{
			num *= 1.2f;
		}
		if (inventory.itemList.schoolComplete)
		{
			num *= 1.15f;
		}
		num *= adventureController.itopod.totalBothNGUSpeedBonus();
		num *= allChallenges.nguBonus();
		return num * allBeards.nguBonus();
	}

	public double grossGoldPerSecond()
	{
		if (challenges.timeMachineChallenge.inChallenge)
		{
			return 0.0;
		}
		return machine.realBaseGold * (double)machineBossMulti() * (double)timeMachineController.barFillsPerSecond() * (double)timeMachineController.speedGoldMultiBonus() * (double)timeMachineController.goldMultiBonus() * (double)bloodMagicController.goldBonus() * (double)allBeards.goldBonus() * NGUController.timeMachineBonus() * allChallenges.timeMachineChallenge.totalGPSbonus();
	}

	public double goldPerSecond()
	{
		double num = grossGoldPerSecond() - totalGPSDrain();
		if (num < 0.0)
		{
			num = 0.0;
		}
		return num;
	}

	public double totalGPSDrain()
	{
		return allDiggers.totalGPSDrain();
	}

	public bool canIncreaseDiggerLevel(double cost)
	{
		return goldPerSecond() - cost > 0.0;
	}

	public float yggdrasilYieldBonus()
	{
		return (1f + inventoryController.bonuses[specType.Yggdrasil]) * beastQuestPerkController.totalYggYieldBonus();
	}

	public long addExp(long rexp)
	{
		if (rexp < 0)
		{
			rexp = 0L;
		}
		float num = (float)rexp * NGUController.expBonus();
		num = ((!inventory.itemList.itemMaxxed[119]) ? (num * (1f + inventoryController.bonuses[specType.EXP])) : (num * 1.1f));
		if (adventure.itopod.perkLevel[94] >= 987)
		{
			num *= 1.05f;
		}
		num *= allDiggers.totalEXPBonus();
		num *= hacksController.totalEXPBonus();
		num *= wishesController.totalExpBonus();
		num *= cookingController.totalExpBonus();
		long num2 = (long)Math.Floor(num);
		if (num2 < 0)
		{
			num2 = 0L;
		}
		if (!((double)realExp + (double)num2 >= 9.223372036854776E+18))
		{
			realExp += num2;
			stats.totalExp += num2;
		}
		return num2;
	}

	public long addExp(float exp)
	{
		if (exp < 0f)
		{
			exp = 0f;
		}
		float num = exp * NGUController.expBonus();
		num = ((!inventory.itemList.itemMaxxed[119]) ? (num * (1f + inventoryController.bonuses[specType.EXP])) : (num * 1.1f));
		if (adventure.itopod.perkLevel[94] >= 987)
		{
			num *= 1.05f;
		}
		num *= allDiggers.totalEXPBonus();
		num *= hacksController.totalEXPBonus();
		num *= wishesController.totalExpBonus();
		num *= cookingController.totalExpBonus();
		long num2 = (long)Math.Floor(num);
		if (num2 < 0)
		{
			num2 = 0L;
		}
		if (!((double)realExp + (double)num2 >= 9.223372036854776E+18))
		{
			realExp += num2;
			stats.totalExp += num2;
		}
		return num2;
	}

	public long checkExpAdded(long rexp)
	{
		if (rexp < 0)
		{
			rexp = 0L;
		}
		float num = (float)rexp * NGUController.expBonus();
		num = ((!inventory.itemList.itemMaxxed[119]) ? (num * (1f + inventoryController.bonuses[specType.EXP])) : (num * 1.1f));
		if (adventure.itopod.perkLevel[94] >= 987)
		{
			num *= 1.05f;
		}
		num *= allDiggers.totalEXPBonus();
		num *= hacksController.totalEXPBonus();
		num *= wishesController.totalExpBonus();
		num *= cookingController.totalExpBonus();
		long num2 = (long)Math.Floor(num);
		if (num2 < 0)
		{
			num2 = 0L;
		}
		return num2;
	}

	public double addGold(double amount)
	{
		if (amount <= 0.0)
		{
			amount = 0.0;
		}
		if (realGold < double.MaxValue - amount)
		{
			realGold += amount;
		}
		if (stats.totalGold < double.MaxValue - amount)
		{
			stats.totalGold += amount;
		}
		if (!settings.pitUnlocked && realGold >= 100000.0)
		{
			settings.pitUnlocked = true;
			buttons.updateButtons();
		}
		return amount;
	}

	public long addAP(int amount)
	{
		float num = (float)amount * allAchievements.bonusAP();
		if (num < 0f)
		{
			num = 0f;
		}
		num = ((!inventory.itemList.itemMaxxed[129]) ? (num * (1f + inventoryController.bonuses[specType.AP])) : (num * 1.2f));
		if (adventure.itopod.perkLevel[94] >= 89)
		{
			num *= 1.02f;
		}
		if (num < 0f)
		{
			num = 0f;
		}
		long num2 = (long)Math.Floor(num);
		arbitrary.curArbitraryPoints += num2;
		arbitrary.curLifetimePoints += num2;
		return num2;
	}

	public long addAP(long amount)
	{
		float num = (float)amount * allAchievements.bonusAP();
		if (num < 0f)
		{
			num = 0f;
		}
		num = ((!inventory.itemList.itemMaxxed[129]) ? (num * (1f + inventoryController.bonuses[specType.AP])) : (num * 1.2f));
		if (adventure.itopod.perkLevel[94] >= 89)
		{
			num *= 1.02f;
		}
		if (num < 0f)
		{
			num = 0f;
		}
		long num2 = (long)Math.Floor(num);
		arbitrary.curArbitraryPoints += num2;
		arbitrary.curLifetimePoints += num2;
		return num2;
	}

	public long checkAPAdded(long amount)
	{
		float num = (float)amount * allAchievements.bonusAP();
		if (num < 0f)
		{
			num = 0f;
		}
		num = ((!inventory.itemList.itemMaxxed[129]) ? (num * (1f + inventoryController.bonuses[specType.AP])) : (num * 1.2f));
		if (adventure.itopod.perkLevel[94] >= 89)
		{
			num *= 1.02f;
		}
		if (num < 0f)
		{
			num = 0f;
		}
		return (long)Math.Floor(num);
	}

	public bool testMode()
	{
		if (testing && Application.platform == RuntimePlatform.WindowsEditor)
		{
			return true;
		}
		return false;
	}

	public bool canLevel()
	{
		if (challenges.levelChallenge10k.inChallenge && settings.rebirthLevels >= 100)
		{
			return false;
		}
		return true;
	}

	public long levelsRemaining()
	{
		long num = 0L;
		if (challenges.levelChallenge10k.inChallenge)
		{
			num = Math.Max(1L, 100 - settings.rebirthLevels);
			if (num > 100)
			{
				num = 100L;
			}
			if (num < 0)
			{
				num = 0L;
			}
		}
		return num;
	}

	public void addOfflineProgress(int timeElapsed)
	{
		int num = timeElapsed - Mathf.CeilToInt((float)(totalCapEnergy() - curEnergy) / energyPerSecond());
		int num2 = timeElapsed - Mathf.CeilToInt((float)(totalCapMagic() - magic.curMagic) / energyPerSecond());
		if (num < 0)
		{
			num = 0;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num > timeElapsed)
		{
			num = timeElapsed;
		}
		if (num2 > timeElapsed)
		{
			num2 = timeElapsed;
		}
		daily.spinTime.advanceTime(timeElapsed);
		arbitrary.macGuffinBooster1Time.removeTime(timeElapsed);
		if (arbitrary.macGuffinBooster1Time.totalseconds < 0.0)
		{
			arbitrary.macGuffinBooster1Time.setTime(0f);
		}
		if (daily.spinTime.totalseconds > (double)dailyController.maxSpinTime())
		{
			daily.spinTime.setTime(dailyController.maxSpinTime());
		}
		if (challenges.levelChallenge10k.inChallenge)
		{
			splashScreen.message = "No Offline Progress in a 100 level challenge (for now)\n\n";
			splashScreen.openScreen();
			return;
		}
		if (challenges.trollChallenge.inChallenge)
		{
			splashScreen.message = "No Offline Progress in a Troll Challenge!\n\n";
			splashScreen.openScreen();
			return;
		}
		if (challenges.hour24Challenge.inChallenge)
		{
			splashScreen.message = "No Offline Progress in a 24 hour challenge!\n\n";
			splashScreen.openScreen();
			return;
		}
		levelsAdded = 0L;
		barProgressAdded = 0f;
		if (timeElapsed > 0)
		{
			rebirthTime.advanceTime(timeElapsed);
			totalPlaytime.advanceTime(timeElapsed);
			settings.dailySaveRewardTime.advanceTime(timeElapsed);
			pit.pitTime.advanceTime(timeElapsed);
			splashScreen.message = "You were offline for " + NumberOutput.timeOutput(timeElapsed) + ". In that time, the Depressed Offline Progress Robot:\n\n";
			makeOfflineEnergy(timeElapsed);
			splashScreen.message += message;
			makeOfflineMagic(timeElapsed);
			splashScreen.message += message;
			makeOfflineRes3(timeElapsed);
			splashScreen.message += message;
			makeOfflineGold(timeElapsed);
			splashScreen.message += message;
			trainingOfflineProgress(timeElapsed);
			splashScreen.message += message;
			wandoosOfflineProgress(timeElapsed);
			splashScreen.message += message;
			levelsAdded = 0L;
			barProgressAdded = 0f;
			augmentOfflineProgress(timeElapsed);
			splashScreen.message += message;
			levelsAdded = 0L;
			barProgressAdded = 0f;
			bloodMagicOfflineProgress(timeElapsed);
			splashScreen.message += message;
			levelsAdded = 0L;
			barProgressAdded = 0f;
			advancedTrainingOfflineProgress(timeElapsed);
			splashScreen.message += message;
			levelsAdded = 0L;
			barProgressAdded = 0f;
			timeMachineOfflineProgress(timeElapsed);
			splashScreen.message += message;
			levelsAdded = 0L;
			barProgressAdded = 0f;
			questingOfflineProgress(timeElapsed);
			splashScreen.message += message;
			adventureOfflineProgress(timeElapsed);
			inventoryOfflineProgress(timeElapsed);
			splashScreen.message += message;
			levelsAdded = 0L;
			barProgressAdded = 0f;
			yggdrasilOfflineProgress(timeElapsed);
			splashScreen.message += message;
			nguOfflineProgress(timeElapsed);
			splashScreen.message += message;
			beardOfflineProgress(num, num2);
			splashScreen.message += message;
			hacksOfflineProgress(timeElapsed);
			splashScreen.message += message;
			wishOfflineProgress(timeElapsed);
			splashScreen.message += message;
			cardsOfflineProgress(timeElapsed);
			splashScreen.message += message;
			cookingOfflineProgress(timeElapsed);
			splashScreen.message += message;
			if (challenges.basicChallenge.inChallenge)
			{
				challenges.basicChallenge.challengeTime.advanceTime(timeElapsed);
			}
			if (challenges.noAugsChallenge.inChallenge)
			{
				challenges.noAugsChallenge.challengeTime.advanceTime(timeElapsed);
			}
			if (challenges.noEquipmentChallenge.inChallenge)
			{
				challenges.noEquipmentChallenge.challengeTime.advanceTime(timeElapsed);
			}
			if (challenges.noRebirthChallenge.inChallenge)
			{
				challenges.noRebirthChallenge.challengeTime.advanceTime(timeElapsed);
			}
			if (challenges.laserSwordChallenge.inChallenge)
			{
				challenges.laserSwordChallenge.challengeTime.advanceTime(timeElapsed);
			}
			if (challenges.nguChallenge.inChallenge)
			{
				challenges.nguChallenge.challengeTime.advanceTime(timeElapsed);
			}
			if (challenges.timeMachineChallenge.inChallenge)
			{
				challenges.timeMachineChallenge.challengeTime.advanceTime(timeElapsed);
			}
			splashScreen.openScreen();
		}
	}

	public void makeOfflineEnergy(int seconds)
	{
		message = "";
		long num = 0L;
		num = ((!((double)((float)seconds * energyPerSecond()) > 9.223372036854776E+18)) ? ((long)((float)seconds * energyPerSecond())) : long.MaxValue);
		if (energyGained < 3000000)
		{
			energyGained += num;
		}
		if (num > totalCapEnergy() - curEnergy)
		{
			num = totalCapEnergy() - curEnergy;
		}
		if (num < 0)
		{
			num = 0L;
		}
		if (curEnergy != totalCapEnergy())
		{
			idleEnergy += num;
			curEnergy += num;
			message = "Gained " + format.suffixFormat(num) + " Energy!\n\n";
		}
	}

	public void makeOfflineMagic(int seconds)
	{
		message = "";
		if (magic.curMagic != totalCapMagic())
		{
			long num = (long)((float)seconds * magicPerSecond());
			if (num > totalCapMagic() - magic.curMagic)
			{
				num = totalCapMagic() - magic.curMagic;
			}
			if (num < 0)
			{
				num = 0L;
			}
			magic.idleMagic += num;
			magic.curMagic += num;
			message = "Gained " + format.suffixFormat(num) + " Magic!\n\n";
		}
	}

	public void makeOfflineRes3(int seconds)
	{
		message = "";
		if (res3.res3On && res3.curRes3 != totalCapRes3())
		{
			long num = (long)((float)seconds * res3PerSecond());
			if (num > totalCapRes3() - res3.curRes3)
			{
				num = totalCapRes3() - res3.curRes3;
			}
			if (num < 0)
			{
				num = 0L;
			}
			res3.idleRes3 += num;
			res3.curRes3 += num;
			message = "Gained " + format.suffixFormat(num) + " " + res3.res3Name + "!\n\n";
		}
	}

	public void makeOfflineGold(int seconds)
	{
		message = "";
		if (bossID < 30)
		{
			return;
		}
		double num = goldPerSecond();
		if (!(num <= 0.0))
		{
			num *= (double)seconds;
			if (!(num <= 0.0))
			{
				addGold(num);
				message = message + "Made " + format.suffixFormat(num) + " gold!\n";
			}
		}
	}

	public void trainingOfflineProgress(int seconds)
	{
		message = "";
		for (int i = 0; i < training.attackTraining.Length; i++)
		{
			long num = training.attackEnergy[i];
			long num2 = training.defenseEnergy[i];
			long num3 = training.attackCaps[i];
			long num4 = training.defenseCaps[i];
			float currentProgress = training.attackBarProgress[i];
			float currentProgress2 = training.defenseBarProgress[i];
			if (num > 0)
			{
				float toAdd = Mathf.Min(num, num3) / (float)num3;
				constantLevelGain(currentProgress, toAdd, seconds);
				if (levelsAdded < 0)
				{
					return;
				}
				long num5 = levelsAdded;
				if (adventure.itopod.perkLevel[15] >= 1)
				{
					num5 += levelsAdded;
				}
				if (beastQuest.quirkLevel[17] >= 1)
				{
					num5 += levelsAdded;
				}
				if (wishes.wishes[23].level >= 1)
				{
					num5 += levelsAdded;
				}
				training.attackTraining[i] += num5;
				training.totalAttackLevels += num5;
				training.attackBarProgress[i] = barProgressAdded;
				message = message + "\nGained " + format.suffixFormat(num5) + " levels in " + training.attackName(i) + "!";
			}
			if (num2 > 0)
			{
				float toAdd2 = Mathf.Min(num2, num4) / (float)num4;
				constantLevelGain(currentProgress2, toAdd2, seconds);
				if (levelsAdded < 0)
				{
					return;
				}
				long num6 = levelsAdded;
				if (adventure.itopod.perkLevel[15] >= 1)
				{
					num6 += levelsAdded;
				}
				if (beastQuest.quirkLevel[17] >= 1)
				{
					num6 += levelsAdded;
				}
				if (wishes.wishes[23].level >= 1)
				{
					num6 += levelsAdded;
				}
				training.defenseTraining[i] += num6;
				training.totalDefenseLevels += num6;
				training.defenseBarProgress[i] = barProgressAdded;
				message = message + "\nGained " + format.suffixFormat(num6) + " levels in " + training.defenseName(i) + "!";
			}
		}
		if (message != "")
		{
			message += "\n";
		}
	}

	public int effectiveBossID()
	{
		int num = bossID;
		if (settings.rebirthDifficulty >= difficulty.evil)
		{
			num += 301;
		}
		if (settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num += 301;
		}
		return num;
	}

	private void questingOfflineProgress(int seconds)
	{
		message = "";
		if (!settings.beastOn)
		{
			return;
		}
		beastQuest.dailyQuestTimer.advanceTime(seconds);
		int num = beastQuestController.resolveDailyTimer();
		secondsIdleBeast = 0L;
		long num2 = 0L;
		if (beastQuest.inQuest && beastQuest.curDrops < beastQuest.targetDrops && beastQuest.idleMode && (adventure.itopod.perkLevel[104] <= 0 || !settings.idleQuestAutocycle))
		{
			long num3 = seconds * 50;
			long num4 = (long)((1f - beastQuest.idleProgress) / beastQuestController.idleProgressPerTick());
			if (num4 > num3)
			{
				beastQuest.idleProgress += (float)num3 * beastQuestController.idleProgressPerTick();
			}
			else
			{
				beastQuest.idleProgress = 0f;
				beastQuest.curDrops++;
				beastQuest.allActive = false;
				num3 -= num4;
				num2++;
				int num5 = beastQuest.targetDrops - beastQuest.curDrops;
				while (num5 > 0)
				{
					long num6 = (long)(1f / beastQuestController.idleProgressPerTick());
					if (num6 > num3)
					{
						beastQuest.idleProgress += (float)num3 * beastQuestController.idleProgressPerTick();
						break;
					}
					num5--;
					beastQuest.curDrops++;
					num3 -= num6;
					num2++;
				}
				if (beastQuest.curDrops >= beastQuest.targetDrops)
				{
					beastQuest.idleMode = false;
				}
			}
			if (num2 > 0)
			{
				message = message + "\n\nGained " + num2 + " Quest items for the Beast!";
			}
		}
		else if (beastQuest.inQuest && beastQuest.curDrops < beastQuest.targetDrops && beastQuest.idleMode && adventure.itopod.perkLevel[104] >= 1 && settings.idleQuestAutocycle)
		{
			long num7 = seconds * 50;
			long num8 = (long)((1f - beastQuest.idleProgress) / beastQuestController.idleProgressPerTick());
			if (num8 > num7)
			{
				beastQuest.idleProgress += (float)num7 * beastQuestController.idleProgressPerTick();
			}
			else
			{
				beastQuest.idleProgress = 0f;
				beastQuest.curDrops++;
				beastQuest.allActive = false;
				num7 -= num8;
				num2++;
				long num9 = (long)(1f / beastQuestController.idleProgressPerTick());
				int num10 = 0;
				float num11 = num7 / num9;
				if (beastQuest.curDrops + (int)num11 < beastQuest.targetDrops)
				{
					beastQuest.curDrops += (int)num11;
					num2 += (int)num11;
					beastQuest.idleProgress = num11 - (float)(int)num11;
					if (beastQuest.idleProgress < 0f)
					{
						beastQuest.idleProgress = 0f;
					}
					if (beastQuest.idleProgress > 1f)
					{
						beastQuest.idleProgress = 1f;
					}
					if (num2 > 0)
					{
						message = message + "\n\nGained " + num2 + " Quest items for the Beast!";
					}
				}
				else
				{
					num10++;
					num11 -= (float)(beastQuest.targetDrops - beastQuest.curDrops);
					beastQuest.curDrops = beastQuest.targetDrops;
					beastQuestController.giveRewardsAndClear(silent: true);
					beastQuestController.startQuest();
					beastQuestController.toggleIdleMode();
					while (num11 >= 60f)
					{
						beastQuest.allActive = false;
						num11 -= 60f;
						num10++;
						beastQuest.curDrops = beastQuest.targetDrops;
						beastQuestController.giveRewardsAndClear(silent: true);
						beastQuestController.startQuest();
						beastQuestController.toggleIdleMode();
					}
					if (num11 >= 1f)
					{
						beastQuest.allActive = false;
						beastQuest.curDrops = (int)num11;
						beastQuest.idleProgress = num11 - (float)(int)num11;
					}
					else
					{
						beastQuest.idleProgress = num11 - (float)(int)num11;
					}
					if (num10 > 0)
					{
						message = message + "\n\nCompleted " + num10 + " Quests for the Beast!";
					}
				}
			}
		}
		if (num > 0)
		{
			message = message + "\n\nGained " + num + " Major Quests for the Beast!";
		}
		if (message != "")
		{
			message += "\n";
		}
	}

	private void adventureOfflineProgress(int seconds)
	{
		message = "";
		long num = 0L;
		long num2 = 0L;
		long num3 = 0L;
		double num4 = adventure.boss1Spawn.totalseconds + (double)seconds;
		double time = Math.Min(adventure.boss1Spawn.totalseconds + (double)seconds, adventureController.boss1SpawnTime());
		int num5 = (int)(num4 / (double)adventureController.boss1SpawnTime());
		double time2 = Math.Floor(num4 % (double)adventureController.boss1SpawnTime());
		long num6 = 0L;
		if (effectiveBossID() >= 58 && totalAdvAttack() >= 3000f && totalAdvDefense() >= 2500f)
		{
			num = addExp(adventureController.boss1Exp() * num5);
			num2 = addAP(adventureController.boss1AP() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan1Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss1Exp() / 2 * num6);
			}
			adventure.titan1Kills += num5;
			if (num5 >= 1)
			{
				message = message + "\nDefeated Gordon Ramsay Bolton " + num5 + " times and earned " + display(num) + " EXP and " + display(num2) + " AP!";
				bestiaryController.addKills(302, num5);
			}
			adventure.boss1Spawn.setTime(time2);
		}
		else
		{
			adventure.boss1Spawn.setTime(time);
		}
		double num7 = adventure.boss2Spawn.totalseconds + (double)seconds;
		time = Math.Min(adventure.boss2Spawn.totalseconds + (double)seconds, adventureController.boss2SpawnTime());
		num5 = (int)(num7 / (double)adventureController.boss2SpawnTime());
		time2 = Math.Floor(num7 % (double)adventureController.boss2SpawnTime());
		adventure.boss2Spawn.setTime(time2);
		if (effectiveBossID() >= 66 && totalAdvAttack() >= 9000f && totalAdvDefense() >= 7000f)
		{
			num = addExp(adventureController.boss2Exp() * num5);
			num2 = addAP(adventureController.boss2AP() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan2Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss2Exp() / 2 * num6);
			}
			adventure.titan2Kills += num5;
			if (num5 >= 1)
			{
				message = message + "\nDefeated Grand Corrupted Tree " + num5 + " times and earned " + display(num) + " EXP and " + display(num2) + " AP!";
				bestiaryController.addKills(303, num5);
			}
		}
		else
		{
			adventure.boss2Spawn.setTime(time);
		}
		double num8 = adventure.boss3Spawn.totalseconds + (double)seconds;
		time = Math.Min(adventure.boss3Spawn.totalseconds + (double)seconds, adventureController.boss3SpawnTime());
		num5 = (int)(num8 / (double)adventureController.boss3SpawnTime());
		time2 = Math.Floor(num8 % (double)adventureController.boss3SpawnTime());
		adventure.boss3Spawn.setTime(time2);
		if (effectiveBossID() >= 82 && totalAdvAttack() >= 25000f && totalAdvDefense() >= 15000f)
		{
			num = addExp(adventureController.boss3Exp() * num5);
			num2 = addAP(adventureController.boss3AP() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan3Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss3Exp() / 2 * num6);
			}
			adventure.titan3Kills += num5;
			if (num5 >= 1)
			{
				message = message + "\nDefeated Jake From Accounting " + num5 + " times and earned " + display(num) + " EXP and " + display(num2) + " AP!";
				bestiaryController.addKills(304, num5);
			}
		}
		else
		{
			adventure.boss3Spawn.setTime(time);
		}
		double num9 = adventure.boss4Spawn.totalseconds + (double)seconds;
		time = Math.Min(adventure.boss4Spawn.totalseconds + (double)seconds, adventureController.boss4SpawnTime());
		num5 = (int)(num9 / (double)adventureController.boss4SpawnTime());
		time2 = Math.Floor(num9 % (double)adventureController.boss4SpawnTime());
		adventure.boss4Spawn.setTime(time2);
		if (effectiveBossID() >= 100 && totalAdvAttack() >= 800000f && totalAdvDefense() >= 400000f && totalAdvHPRegen() >= 14000f && inventory.itemList.itemMaxxed[135])
		{
			num = addExp(adventureController.boss4Exp() * num5);
			num2 = addAP(adventureController.boss4AP() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan4Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss4Exp() / 2 * num6);
			}
			adventure.titan4Kills += num5;
			if (num5 >= 1)
			{
				message = message + "\nDefeated UUG the Unmentionable " + num5 + " times and earned " + display(num) + " EXP and " + display(num2) + " AP!";
				bestiaryController.addKills(305, num5);
			}
		}
		else
		{
			adventure.boss4Spawn.setTime(time);
		}
		double num10 = adventure.boss5Spawn.totalseconds + (double)seconds;
		time = Math.Min(adventure.boss5Spawn.totalseconds + (double)seconds, adventureController.boss5SpawnTime());
		num5 = (int)(num10 / (double)adventureController.boss5SpawnTime());
		time2 = Math.Floor(num10 % (double)adventureController.boss5SpawnTime());
		adventure.boss5Spawn.setTime(time2);
		if (effectiveBossID() >= 116 && totalAdvAttack() >= 13000000f && totalAdvDefense() >= 7000000f && totalAdvHPRegen() >= 150000f && adventure.boss5Kills >= 3)
		{
			num = addExp(adventureController.boss5Exp() * num5);
			num2 = addAP(adventureController.boss5AP() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan5Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss5Exp() / 2 * num6);
			}
			adventure.titan5Kills += num5;
			if (num5 >= 1)
			{
				message = message + "\nDefeated Walderp " + num5 + " times and earned " + display(num) + " EXP and " + display(num2) + " AP!";
				bestiaryController.addKills(310, num5);
			}
		}
		else
		{
			adventure.boss5Spawn.setTime(time);
		}
		double num11 = adventure.boss6Spawn.totalseconds + (double)seconds;
		time = Math.Min(adventure.boss6Spawn.totalseconds + (double)seconds, adventureController.boss6SpawnTime());
		num5 = (int)(num11 / (double)adventureController.boss6SpawnTime());
		time2 = Math.Floor(num11 % (double)adventureController.boss6SpawnTime());
		adventure.boss6Spawn.setTime(time2);
		if (effectiveBossID() >= 132 && adventureController.autokillTitan6V1Achieved() && adventure.titan6Unlocked)
		{
			num = addExp(adventureController.boss6Exp() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan6Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss6Exp() / 2 * num6);
			}
			adventure.titan6Kills += num5;
			num3 = num5 * adventureController.boss6PP();
			adventureController.itopod.addProgress(num3);
			if (num5 >= 1)
			{
				message = message + "\nDefeated THE BEAST " + num5 + " times and earned " + display(num) + " EXP! You also gained " + display(adventureController.itopod.progressToPP(num3)) + " PP and " + display(adventureController.itopod.progressToRemainder(num3)) + " Progress to your Next PP!";
				switch (adventure.titan6Version)
				{
				case 0:
					bestiaryController.addKills(312, num5);
					break;
				case 1:
					bestiaryController.addKills(313, num5);
					break;
				case 2:
					bestiaryController.addKills(314, num5);
					break;
				case 3:
					bestiaryController.addKills(315, num5);
					break;
				}
				if (wishes.wishes[73].level >= 1)
				{
					long num12 = adventureController.boss6QP() * num5;
					beastQuest.quirkPoints += num12;
					message = message + "\nYou gained " + num12 + "QP thanks to your Wish!";
				}
			}
		}
		else
		{
			adventure.boss6Spawn.setTime(time);
		}
		double num13 = adventure.boss7Spawn.totalseconds + (double)seconds;
		time = Math.Min(adventure.boss7Spawn.totalseconds + (double)seconds, adventureController.boss7SpawnTime());
		num5 = (int)(num13 / (double)adventureController.boss7SpawnTime());
		time2 = Math.Floor(num13 % (double)adventureController.boss7SpawnTime());
		adventure.boss7Spawn.setTime(time2);
		if (effectiveBossID() >= 426 && adventureController.autokillTitan7V1Achieved() && adventure.titan7Unlocked)
		{
			num = addExp(adventureController.boss7Exp() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan7Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss7Exp() / 2 * num6);
			}
			adventure.titan7Kills += num5;
			num3 = num5 * adventureController.boss7PP();
			adventureController.itopod.addProgress(num3);
			if (num5 >= 1)
			{
				message = message + "\nDefeated GREASY NERD " + num5 + " times and earned " + display(num) + " EXP! You also gained " + display(adventureController.itopod.progressToPP(num3)) + " PP and " + display(adventureController.itopod.progressToRemainder(num3)) + " Progress to your Next PP!";
				bestiaryController.addKills(334, num5);
				if (wishes.wishes[74].level >= 1)
				{
					long num14 = adventureController.boss7QP() * num5;
					beastQuest.quirkPoints += num14;
					message = message + "\nYou gained " + num14 + "QP thanks to your Wish!";
				}
			}
		}
		else
		{
			adventure.boss7Spawn.setTime(time);
		}
		double num15 = adventure.boss8Spawn.totalseconds + (double)seconds;
		time = Math.Min(adventure.boss8Spawn.totalseconds + (double)seconds, adventureController.boss8SpawnTime());
		num5 = (int)(num15 / (double)adventureController.boss8SpawnTime());
		time2 = Math.Floor(num15 % (double)adventureController.boss8SpawnTime());
		adventure.boss8Spawn.setTime(time2);
		if (effectiveBossID() >= 467 && adventureController.autokillTitan8V1Achieved() && adventure.titan8Unlocked)
		{
			num = addExp(adventureController.boss8Exp() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan8Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss8Exp() / 2 * num6);
			}
			adventure.titan8Kills += num5;
			num3 = num5 * adventureController.boss8PP();
			adventureController.itopod.addProgress(num3);
			if (num5 >= 1)
			{
				message = message + "\nDefeated THE GODMOTHER " + num5 + " times and earned " + display(num) + " EXP! You also gained " + display(adventureController.itopod.progressToPP(num3)) + " PP and " + display(adventureController.itopod.progressToRemainder(num3)) + " Progress to your Next PP!";
				bestiaryController.addKills(339, num5);
				if (wishes.wishes[40].level >= 1)
				{
					long num16 = adventureController.boss8QP() * num5;
					beastQuest.quirkPoints += num16;
					message = message + "\nYou gained " + num16 + "QP thanks to your Wish!";
				}
			}
		}
		else
		{
			adventure.boss8Spawn.setTime(time);
		}
		double num17 = adventure.boss9Spawn.totalseconds + (double)seconds;
		time = Math.Min(adventure.boss9Spawn.totalseconds + (double)seconds, adventureController.boss9SpawnTime());
		num5 = (int)(num17 / (double)adventureController.boss9SpawnTime());
		time2 = Math.Floor(num17 % (double)adventureController.boss9SpawnTime());
		adventure.boss9Spawn.setTime(time2);
		if (effectiveBossID() >= 491 && adventureController.autokillTitan9V1Achieved() && adventure.titan9Unlocked)
		{
			num = addExp(adventureController.boss9Exp() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan9Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss9Exp() / 2 * num6);
			}
			adventure.titan9Kills += num5;
			num3 = num5 * adventureController.boss9PP();
			adventureController.itopod.addProgress(num3);
			if (num5 >= 1)
			{
				message = message + "\nDefeated THE EXILE " + num5 + " times and earned " + display(num) + " EXP! You also gained " + display(adventureController.itopod.progressToPP(num3)) + " PP and " + display(adventureController.itopod.progressToRemainder(num3)) + " Progress to your Next PP!";
				bestiaryController.addKills(344, num5);
				if (wishes.wishes[41].level >= 1)
				{
					long num18 = adventureController.boss9QP() * num5;
					beastQuest.quirkPoints += num18;
					message = message + "\nYou gained " + num18 + "QP thanks to your Wish!";
				}
			}
		}
		else
		{
			adventure.boss9Spawn.setTime(time);
		}
		double num19 = adventure.boss10Spawn.totalseconds + (double)seconds;
		time = Math.Min(adventure.boss10Spawn.totalseconds + (double)seconds, adventureController.boss10SpawnTime());
		num5 = (int)(num19 / (double)adventureController.boss10SpawnTime());
		time2 = Math.Floor(num19 % (double)adventureController.boss10SpawnTime());
		adventure.boss10Spawn.setTime(time2);
		if (effectiveBossID() >= 777 && adventureController.autokillTitan10V1Achieved() && adventure.titan10Unlocked)
		{
			num = addExp(adventureController.boss10Exp() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan10Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss10Exp() / 2 * num6);
			}
			adventure.titan10Kills += num5;
			num3 = num5 * adventureController.boss10PP();
			adventureController.itopod.addProgress(num3);
			if (num5 >= 1)
			{
				message = message + "\nDefeated IT HUNGERS " + num5 + " times and earned " + display(num) + " EXP! You also gained " + display(adventureController.itopod.progressToPP(num3)) + " PP and " + display(adventureController.itopod.progressToRemainder(num3)) + " Progress to your Next PP!";
				bestiaryController.addKills(365, num5);
				if (wishes.wishes[100].level >= 1)
				{
					long num20 = adventureController.boss10QP() * num5;
					beastQuest.quirkPoints += num20;
					message = message + "\nYou gained " + num20 + "QP thanks to your Wish!";
				}
			}
		}
		else
		{
			adventure.boss10Spawn.setTime(time);
		}
		double num21 = adventure.boss11Spawn.totalseconds + (double)seconds;
		time = Math.Min(adventure.boss11Spawn.totalseconds + (double)seconds, adventureController.boss11SpawnTime());
		num5 = (int)(num21 / (double)adventureController.boss11SpawnTime());
		time2 = Math.Floor(num21 % (double)adventureController.boss11SpawnTime());
		adventure.boss11Spawn.setTime(time2);
		if (effectiveBossID() >= 826 && adventureController.autokillTitan11V1Achieved() && adventure.titan11Unlocked)
		{
			num = addExp(adventureController.boss11Exp() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan11Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss11Exp() / 2 * num6);
			}
			adventure.titan11Kills += num5;
			num3 = num5 * adventureController.boss11PP();
			adventureController.itopod.addProgress(num3);
			if (num5 >= 1)
			{
				message = message + "\nDefeated ROCK LOBSTER " + num5 + " times and earned " + display(num) + " EXP! You also gained " + display(adventureController.itopod.progressToPP(num3)) + " PP and " + display(adventureController.itopod.progressToRemainder(num3)) + " Progress to your Next PP!";
				bestiaryController.addKills(369, num5);
				if (wishes.wishes[187].level >= 1)
				{
					long num22 = adventureController.boss11QP() * num5;
					beastQuest.quirkPoints += num22;
					message = message + "\nYou gained " + num22 + "QP thanks to your Wish!";
				}
			}
		}
		else
		{
			adventure.boss11Spawn.setTime(time);
		}
		double num23 = adventure.boss12Spawn.totalseconds + (double)seconds;
		time = Math.Min(adventure.boss12Spawn.totalseconds + (double)seconds, adventureController.boss12SpawnTime());
		num5 = (int)(num23 / (double)adventureController.boss12SpawnTime());
		time2 = Math.Floor(num23 % (double)adventureController.boss12SpawnTime());
		adventure.boss12Spawn.setTime(time2);
		if (effectiveBossID() >= 850 && adventureController.autokillTitan12V1Achieved() && adventure.titan12Unlocked)
		{
			num = addExp(adventureController.boss12Exp() * num5);
			stats.titansDefeated += num5;
			num6 = Math.Min(Math.Max(adventure.itopod.perkLevel[34] * 3 - adventure.titan12Kills, 0L), num5);
			if (num6 > 0 && num6 <= 9)
			{
				num += addExp(adventureController.boss12Exp() / 2 * num6);
			}
			adventure.titan12Kills += num5;
			num3 = num5 * adventureController.boss12PP();
			adventureController.itopod.addProgress(num3);
			if (num5 >= 1)
			{
				message = message + "\nDefeated AMALGAMATE " + num5 + " times and earned " + display(num) + " EXP! You also gained " + display(adventureController.itopod.progressToPP(num3)) + " PP and " + display(adventureController.itopod.progressToRemainder(num3)) + " Progress to your Next PP!";
				bestiaryController.addKills(373, num5);
				if (wishes.wishes[204].level >= 1)
				{
					long num24 = adventureController.boss12QP() * num5;
					beastQuest.quirkPoints += num24;
					message = message + "\nYou gained " + num24 + "QP thanks to your Wish!";
				}
			}
		}
		else
		{
			adventure.boss12Spawn.setTime(time);
		}
		adventure.boss13Spawn.totalseconds += seconds;
		if (adventure.boss13Spawn.totalseconds >= (double)adventureController.boss13SpawnTime())
		{
			adventure.boss13Spawn.totalseconds = adventureController.boss13SpawnTime();
		}
		adventure.boss14Spawn.totalseconds += seconds;
		if (adventure.boss14Spawn.totalseconds >= (double)adventureController.boss14SpawnTime())
		{
			adventure.boss14Spawn.totalseconds = adventureController.boss14SpawnTime();
		}
		if (settings.itopodOn && totalAdvAttack() >= 650f)
		{
			int num25 = calculateBestItopodLevel();
			int num26 = adventureController.lootDrop.itopodTier(num25);
			if (num25 > 0)
			{
				int num27 = 1;
				if (num26 > 0)
				{
					num27 = Mathf.Min(num26, 24);
				}
				if (num27 < 1)
				{
					num27 = 1;
				}
				if (num27 >= 24)
				{
					num27 = 13;
				}
				else if (num27 >= 18)
				{
					num27 = 12;
				}
				else if (num27 >= 15)
				{
					num27 = 11;
				}
				else if (num27 > 10)
				{
					num27 = 10;
				}
				if (num27 > 13)
				{
					num27 = 13;
				}
				float num28 = 1f + adventureController.respawnTime();
				if (inventory.itemList.redLiquidComplete)
				{
					num28 = 0.8f + adventureController.respawnTime();
				}
				int num29 = Mathf.FloorToInt((float)seconds / num28);
				long num30 = Math.Min(num29, adventure.itopod.buffedKills);
				if (!settings.buffedKillsOn)
				{
					num30 = 0L;
				}
				long num31 = num29 - num30;
				int num32 = adventureController.lootDrop.killsPerAP(num26);
				int num33 = adventureController.lootDrop.killsPerEXP(num26);
				long num34 = num29 / num32;
				long rexp = num29 / num33 * adventureController.lootDrop.itopodEXPAwarded(num26);
				adventure.itopod.enemiesKilled += num29;
				arbitrary.curArbitraryPoints += num34;
				arbitrary.curLifetimePoints += num34;
				long num35 = 0L;
				long num36 = 0L;
				long num37 = 0L;
				if (arbitrary.hasCubeFilter)
				{
					float num38 = itemInfo.capAttack[num27] * ((float)num29 / 8f);
					if (num38 < 0f)
					{
						num38 = 0f;
					}
					float num39 = 100f;
					if (adventure.itopod.perkLevel[26] >= 1)
					{
						num39 = 50f;
					}
					num39 /= wishesController.totalBoostRatioDivider();
					float num40 = num38 * allItemList.boostBonus() / (num39 * 2f);
					inventory.cubePower += num40;
					inventory.cubeToughness += num40;
					message = message + "\n\nGained " + display(num40) + " Boost to your Infinity Cube!";
				}
				if (!settings.buffedKillsOn)
				{
					long num41 = adventureController.itopod.progressGained(num25);
					num36 = num29 * num41;
					num37 = adventureController.itopod.addProgress(num36);
				}
				else
				{
					long num42 = adventureController.itopod.progressGained(num25);
					num35 = num30 * num42;
					num37 += adventureController.itopod.addProgress(num35);
					adventure.itopod.buffedKills -= num30;
					num42 = adventureController.itopod.progressGained(num25);
					num36 = num31 * num42;
					num37 += adventureController.itopod.addProgress(num36);
				}
				long num43 = 0L;
				long num44 = 0L;
				if (adventure.itopod.perkLevel[30] >= 1)
				{
					num43 = num29;
					num44 = adventureController.itopod.addPoopProgress(num43);
				}
				if (num26 >= 1 && num25 > 1)
				{
					message = message + "\n\nKilled " + display(num29) + " Pissed off Dudes on floor " + num25 + " of the I.T.O.P.O.D and gained " + display(addExp(rexp)) + " EXP, " + display(num34) + " AP, and " + display(num37) + " PP!";
				}
				else
				{
					message = message + "\nKilled " + display(num29) + " Pissed off Dudes on floor " + num25 + " of the I.T.O.P.O.D and gained " + display(num34) + " AP and " + display(num37) + " PP!";
				}
				message = message + "\nYou are now at " + display(adventure.itopod.pointProgress) + " Progress (" + ((float)adventure.itopod.pointProgress / (float)adventureController.itopod.pointThreshold() * 100f).ToString("#0.##") + "%) towards your next PP!";
				if (num30 > 0)
				{
					message = message + "\nYou also used up " + display(num30) + " stacks of your Little Blue Pill.";
				}
				if (num44 > 0)
				{
					message = message + "\nYou also gained " + num44 + " Poops thanks to your Crappy Perk!";
				}
				if (achievements.achievementComplete[145] && adventure.itopod.perkLevel[68] >= 1)
				{
					int num45 = num29 / adventureController.lootDrop.killsPerMacguffin();
					if (num45 < 0)
					{
						num45 = 0;
					}
					if (num45 > inventory.inventory.Count)
					{
						num45 = inventory.inventory.Count;
					}
					for (int i = 0; i < num45; i++)
					{
						adventureController.lootDrop.dropRandomMacguffin(0);
					}
					if (num45 > 0)
					{
						message = message + "\nYou also gained " + num45 + " MacGuffin drops! Oh my yes!";
					}
				}
			}
		}
		if (message != "")
		{
			message += "\n";
		}
	}

	public int calculateBestItopodLevel()
	{
		float num = totalAdvAttack() / 765f;
		num *= idleAttackPower();
		if (totalAdvAttack() < 700f)
		{
			return 0;
		}
		int num2 = Convert.ToInt32(Math.Floor(Math.Log(num, 1.05)));
		if (num2 < 1)
		{
			return 1;
		}
		if (num2 > adventure.highestItopodLevel)
		{
			num2 = adventure.highestItopodLevel;
		}
		return num2;
	}

	private void inventoryOfflineProgress(int seconds)
	{
		for (int i = 0; i < inventory.daycareTimers.Count; i++)
		{
			if (i <= inventory.daycare.Count && inventory.daycare[i].id > 0)
			{
				int num = inventoryController.daycares[i].levelsAdded();
				inventory.daycareTimers[i].advanceTime((float)seconds * allDiggers.totalDaycareBonus());
				int num2 = inventoryController.daycares[i].levelsAdded();
				if (num2 - num == 1)
				{
					message = message + "\nGained " + (num2 - num) + " level on your " + itemInfo.itemName[inventory.daycare[i].id] + "!";
				}
				else
				{
					message = message + "\nGained " + (num2 - num) + " levels on your " + itemInfo.itemName[inventory.daycare[i].id] + "!";
				}
			}
		}
		if (message != "")
		{
			message += "\n";
		}
	}

	private void wandoosOfflineProgress(int seconds)
	{
		message = "";
		if (!settings.wandoos98On || wandoos98.installTime.totalseconds < 86400.0)
		{
			return;
		}
		wandoos98.bootupTime.advanceTime(seconds);
		if (wandoos98.wandoosEnergy > 0)
		{
			float num = wandoos98Controller.energyProgressToAdd();
			if (!(num <= 1E-09f))
			{
				constantLevelGain(wandoos98.energyProgress, num, seconds);
				wandoos98.energyProgress = barProgressAdded;
				wandoos98.energyLevel += levelsAdded;
				message = message + "Gained " + format.suffixFormat(levelsAdded) + " levels for Wandoos' Energy Bonus!\n";
			}
		}
		if (wandoos98.wandoosMagic > 0)
		{
			float num2 = wandoos98Controller.magicProgressToAdd();
			if (!(num2 <= 1E-09f))
			{
				constantLevelGain(wandoos98.magicProgress, num2, seconds);
				wandoos98.magicProgress = barProgressAdded;
				wandoos98.magicLevel += levelsAdded;
				message = message + "Gained " + format.suffixFormat(levelsAdded) + " levels for Wandoos' Magic Bonus!\n";
			}
		}
		if (message != "")
		{
			message += "\n";
		}
	}

	private void augmentOfflineProgress(int seconds)
	{
		message = "";
		for (int i = 0; i < augments.augs.Length; i++)
		{
			if (augments.augs[i].augEnergy > 0)
			{
				float baseAugCost = augmentsController.augments[i].getBaseAugCost();
				float num = augmentsController.augments[i].getAugProgressPerTick();
				if (arbitrary.energyPotion1Time.totalseconds > 0.0)
				{
					num /= allArbitrary.potionModifier();
				}
				if (!(num <= 1E-09f))
				{
					scaledLevelGain(augments.augs[i].augProgress, num, seconds, augments.augs[i].augLevel);
					long num2 = levelsAdded;
					float augProgress = barProgressAdded;
					if (augments.augs[i].augProgress > 0f)
					{
						levelsAfforded(baseAugCost, realGold + (double)augmentsController.augments[i].getAugCost(), augments.augs[i].augLevel);
					}
					else
					{
						levelsAfforded(baseAugCost, realGold, augments.augs[i].augLevel);
					}
					long num3 = levelsAdded;
					if (num2 < 0)
					{
						num2 = 0L;
					}
					if (num3 < 0)
					{
						num3 = 0L;
					}
					long num4 = (levelsAdded = (long)Mathf.Min(num2, num3));
					double num5 = 0.0;
					num5 = ((num4 == 0L) ? 0.0 : ((!(augments.augs[i].augProgress > 0f)) ? goldUsedLevels(augments.augs[i].augLevel, augments.augs[i].augLevel + num4, baseAugCost, countFirst: true) : goldUsedLevels(augments.augs[i].augLevel, augments.augs[i].augLevel + num4, baseAugCost, countFirst: false)));
					if (num5 > realGold)
					{
						return;
					}
					realGold -= num5;
					augments.augs[i].augLevel += num4;
					augments.augs[i].augProgress = barProgressAdded;
					if (num2 <= num3)
					{
						augments.augs[i].augProgress = augProgress;
					}
					else
					{
						augments.augs[i].augProgress = 0f;
					}
					if (augments.augs[i].augLevel < 0)
					{
						augments.augs[i].augLevel = 0L;
					}
					message = message + "Gained " + num4 + " levels in " + augmentsController.augments[i].augName + "!\n";
				}
			}
			if (augments.augs[i].upgradeEnergy <= 0)
			{
				continue;
			}
			float baseUpgradeCost = augmentsController.augments[i].getBaseUpgradeCost();
			float num6 = augmentsController.augments[i].getUpgradeProgressPerTick();
			if (arbitrary.energyPotion1Time.totalseconds > 0.0)
			{
				num6 /= allArbitrary.potionModifier();
			}
			if (!(num6 <= 1E-09f))
			{
				scaledLevelGain(augments.augs[i].upgradeProgress, num6, seconds, augments.augs[i].upgradeLevel);
				long num7 = levelsAdded;
				float upgradeProgress = barProgressAdded;
				if (augments.augs[i].upgradeProgress > 0f)
				{
					upgradesAfforded(baseUpgradeCost, realGold + (double)augmentsController.augments[i].getUpgradeCost(), augments.augs[i].upgradeLevel);
				}
				else
				{
					upgradesAfforded(baseUpgradeCost, realGold, augments.augs[i].upgradeLevel);
				}
				long num8 = levelsAdded;
				if (num7 < 0)
				{
					num7 = 0L;
				}
				if (num8 < 0)
				{
					num8 = 0L;
				}
				long num9 = (long)Mathf.Min(num7, num8);
				double num10 = 0.0;
				num10 = ((num9 == 0L) ? 0.0 : ((!(augments.augs[i].upgradeProgress > 0f)) ? goldUsedUpgrades(augments.augs[i].upgradeLevel, augments.augs[i].upgradeLevel + num9, baseUpgradeCost, countFirst: true) : goldUsedUpgrades(augments.augs[i].upgradeLevel, augments.augs[i].upgradeLevel + num9, baseUpgradeCost, countFirst: false)));
				if (num10 > realGold)
				{
					return;
				}
				realGold -= num10;
				augments.augs[i].upgradeLevel += (long)Mathf.Min(num7, num8);
				if (num7 <= num8)
				{
					augments.augs[i].upgradeProgress = upgradeProgress;
				}
				else
				{
					augments.augs[i].upgradeProgress = 0f;
				}
				if (augments.augs[i].upgradeLevel < 0)
				{
					augments.augs[i].upgradeLevel = 0L;
				}
				message = message + "Gained " + num9 + " levels in " + augmentsController.augments[i].upgradeName + "!\n";
			}
		}
		if (message != "")
		{
			message += "\n";
		}
		levelsAdded = 0L;
		barProgressAdded = 0f;
	}

	private void bloodMagicOfflineProgress(int seconds)
	{
		message = "";
		double num = 0.0;
		bloodMagic.adventureSpellTime.advanceTime(seconds);
		if (adventure.itopod.perkLevel[72] >= 1)
		{
			bloodMagic.macguffin1Time.advanceTime(seconds);
		}
		if (adventure.itopod.perkLevel[73] >= 1)
		{
			bloodMagic.macguffin2Time.advanceTime(seconds);
		}
		for (int i = 0; i < bloodMagic.ritual.Count; i++)
		{
			if (bloodMagic.ritual[i].magic <= 0)
			{
				continue;
			}
			float num2 = bloodMagicController.bloodMagics[i].currentCost();
			float num3 = bloodMagicController.bloodMagics[i].progressPerTick();
			if (arbitrary.magicPotion1Time.totalseconds > 0.0)
			{
				num3 /= allArbitrary.potionModifier();
			}
			if (!(num3 <= 1E-09f))
			{
				constantLevelGain(bloodMagic.ritual[i].progress, num3, seconds);
				long num4 = levelsAdded;
				if (bloodMagic.ritual[i].progress > 0f)
				{
					constantlevelsAfforded(num2, realGold + (double)bloodMagicController.bloodMagics[i].currentCost());
				}
				else
				{
					constantlevelsAfforded(num2, realGold);
				}
				long num5 = levelsAdded;
				if (num4 < 0)
				{
					num4 = 0L;
				}
				if (num5 < 0)
				{
					num5 = 0L;
				}
				long num6 = (long)Mathf.Min(num4, num5);
				if (num6 < 0)
				{
					num6 = 0L;
				}
				double num7 = 0.0;
				num7 = ((num6 == 0L) ? 0.0 : ((!(bloodMagic.ritual[i].progress > 0f)) ? constantGoldCost(num2, num6, countFirst: true) : constantGoldCost(num2, num6, countFirst: false)));
				if (num7 > realGold)
				{
					return;
				}
				realGold -= num7;
				bloodMagic.ritual[i].level += num6;
				bloodMagic.bloodPoints += (double)num6 * bloodMagicController.bloodAdded(i);
				num += (double)num6 * bloodMagicController.bloodAdded(i);
			}
		}
		message = message + "Gained " + display(num) + " Blood!\n";
		if (num == 0.0)
		{
			message = "";
		}
		if (message != "")
		{
			message += "\n";
		}
		levelsAdded = 0L;
		barProgressAdded = 0f;
	}

	private void timeMachineOfflineProgress(int seconds)
	{
		message = "";
		if (machine.speedEnergy > 0)
		{
			float num = timeMachineController.getBaseSpeedCost() * totalDiscount();
			float num2 = timeMachineController.speedProgressPerTick();
			if (arbitrary.energyPotion1Time.totalseconds > 0.0)
			{
				num2 /= allArbitrary.potionModifier();
			}
			if (!(num2 <= 1E-09f))
			{
				scaledLevelGain(machine.speedProgress, num2, seconds, machine.levelSpeed);
				long num3 = levelsAdded;
				if (machine.speedProgress > 0f)
				{
					levelsAfforded(num, realGold + (double)timeMachineController.machineSpeedGoldCost(), machine.levelSpeed);
				}
				else
				{
					levelsAfforded(num, realGold, machine.levelSpeed);
				}
				long num4 = levelsAdded;
				if (num3 < 0)
				{
					num3 = 0L;
				}
				if (num4 < 0)
				{
					num4 = 0L;
				}
				long num5 = (long)Mathf.Min(num3, num4);
				double num6 = 0.0;
				num6 = ((num5 == 0L) ? 0.0 : ((!(machine.speedProgress > 0f)) ? goldUsedLevels(machine.levelSpeed, machine.levelSpeed + num5, num, countFirst: true) : goldUsedLevels(machine.levelSpeed, machine.levelSpeed + num5, num, countFirst: false)));
				if (num6 > realGold)
				{
					return;
				}
				realGold -= num6;
				machine.levelSpeed += num5;
				machine.speedProgress = barProgressAdded;
				message = message + "Gained " + num5 + " levels in Time Machine Speed!";
			}
		}
		if (machine.goldMultiMagic > 0)
		{
			float num7 = timeMachineController.getBaseMultiCost() * totalDiscount();
			float num8 = timeMachineController.goldMultiProgressPerTick();
			if (arbitrary.magicPotion1Time.totalseconds > 0.0)
			{
				num8 /= allArbitrary.potionModifier();
			}
			if (!(num8 < 1E-09f))
			{
				scaledLevelGain(machine.goldMultiProgress, num8, seconds, machine.levelGoldMulti);
				long num9 = levelsAdded;
				if (machine.goldMultiProgress > 0f)
				{
					levelsAfforded(num7, realGold + (double)timeMachineController.machineGoldMultiCost(), machine.levelGoldMulti);
				}
				else
				{
					levelsAfforded(num7, realGold, machine.levelGoldMulti);
				}
				long num10 = levelsAdded;
				if (num9 < 0)
				{
					num9 = 0L;
				}
				if (num10 < 0)
				{
					num10 = 0L;
				}
				long num11 = Math.Min(num9, num10);
				double num12 = 0.0;
				num12 = ((num11 == 0L) ? 0.0 : ((!(machine.goldMultiProgress > 0f)) ? goldUsedLevels(machine.levelGoldMulti, machine.levelGoldMulti + num11, num7, countFirst: true) : goldUsedLevels(machine.levelGoldMulti, machine.levelGoldMulti + num11, num7, countFirst: false)));
				if (num12 > realGold)
				{
					return;
				}
				realGold -= num12;
				machine.levelGoldMulti += num11;
				if (num10 >= num9)
				{
					machine.goldMultiProgress = barProgressAdded;
				}
				else
				{
					machine.goldMultiProgress = 0f;
				}
				message = message + "\nGained " + num11 + " levels in Time Machine Gold Multiplier!";
			}
		}
		if (message != "")
		{
			message += "\n";
		}
		levelsAdded = 0L;
		barProgressAdded = 0f;
	}

	private void advancedTrainingOfflineProgress(int seconds)
	{
		message = "";
		for (int i = 0; i < advancedTraining.training.Length; i++)
		{
			float divisor = advancedTrainingController.getDivisor(i);
			if (divisor > 0f && wishes.wishes[190].level >= 1)
			{
				double num = seconds * 50;
				if (num < 0.0)
				{
					num = 0.0;
				}
				if (num > 1E+18)
				{
					num = 1E+18;
				}
				advancedTraining.level[i] += (long)num;
				advancedTraining.barProgress[i] = 0f;
				message = message + "Gained " + display(num) + " levels in " + advancedTrainingController.trainingName(i) + "!\n";
			}
			else
			{
				if (!(divisor > 0f) || advancedTraining.targetLevel(i) <= advancedTraining.training[i])
				{
					continue;
				}
				float num2 = advancedTrainingController.getProgressPerTick(i);
				if (arbitrary.energyPotion1Time.totalseconds > 0.0)
				{
					num2 /= Mathf.Sqrt(allArbitrary.potionModifier());
				}
				if (!(num2 <= 1E-09f))
				{
					float curBarProgress = advancedTraining.barProgress[i];
					long num3 = advancedTraining.level[i];
					long num4 = advancedTraining.targetLevel(i) - num3;
					scaledLevelGain(curBarProgress, num2, seconds, num3);
					long num5 = (long)Mathf.Min(levelsAdded, num4);
					if (num5 < 0)
					{
						num5 = 0L;
					}
					advancedTraining.level[i] += num5;
					advancedTraining.barProgress[i] = barProgressAdded;
					message = message + "Gained " + display(num5) + " levels in " + advancedTrainingController.trainingName(i) + "!\n";
				}
			}
		}
		if (message != "")
		{
			message += "\n";
		}
	}

	public void yggdrasilOfflineProgress(int seconds)
	{
		message = "";
		for (int i = 0; i < yggdrasilController.activationCost.Count; i++)
		{
			if (yggdrasil.fruits[i].activated)
			{
				float seconds2 = yggdrasil.fruits[i].seconds;
				yggdrasil.fruits[i].addTime(seconds);
				float num = Mathf.Min(seconds, (float)yggdrasil.fruits[i].maxTier * yggdrasilController.fruits[0].tierThreshold() - seconds2);
				if (num >= 1f)
				{
					message = message + "\n" + yggdrasilController.fruitName[i] + " grew for " + NumberOutput.timeOutput(num) + "!";
				}
			}
		}
		if (message != "")
		{
			message += "\n";
		}
	}

	public void nguOfflineProgress(int seconds)
	{
		message = "";
		for (int i = 0; i < NGU.skills.Count; i++)
		{
			if (NGU.skills[i].energy <= 0 || (NGU.skills[i].level >= NGUController.hardCapNormalLevel() && settings.nguLevelTrack == difficulty.normal) || (NGU.skills[i].evilLevel >= NGUController.hardCapNormalLevel() && settings.nguLevelTrack == difficulty.evil) || (NGU.skills[i].sadisticLevel >= NGUController.hardCapNormalLevel() && settings.nguLevelTrack == difficulty.sadistic))
			{
				continue;
			}
			float num = NGUController.NGU[i].progressPerTick();
			if (arbitrary.energyPotion1Time.totalseconds > 0.0)
			{
				num /= allArbitrary.potionModifier();
			}
			long num2 = 0L;
			if (settings.nguLevelTrack == difficulty.normal)
			{
				num2 = Math.Max(NGU.skills[i].targetLevel() - NGU.skills[i].level, 0L);
				scaledLevelGain(NGU.skills[i].progress, num, seconds, NGU.skills[i].level);
				long num3 = Math.Min(levelsAdded, num2);
				float num4 = barProgressAdded;
				float progress = NGU.skills[i].progress;
				if (num3 <= 0)
				{
					num3 = 0L;
				}
				if (NGU.skills[i].level + num3 >= NGUController.hardCapNormalLevel())
				{
					num3 = NGUController.hardCapNormalLevel() - NGU.skills[i].level;
				}
				if (num4 <= 0f)
				{
					num4 = 0f;
				}
				if (num4 >= 1f)
				{
					num4 = 0.99f;
				}
				NGU.skills[i].level += num3;
				NGU.skills[i].progress = num4;
				if (num3 == 0L)
				{
					message = message + "Gained " + ((num4 - progress) * 100f).ToString("#0.00") + "% of a level in " + NGUController.NGU[i].NGUName + "!\n";
				}
				else
				{
					NGU.skills[i].progress = barProgressAdded;
					message = message + "Gained " + display(num3) + " levels in " + NGUController.NGU[i].NGUName + "!\n";
				}
				if (NGU.skills[i].level > NGUController.hardCapNormalLevel())
				{
					NGU.skills[i].level = NGUController.hardCapNormalLevel();
				}
			}
			else if (settings.nguLevelTrack == difficulty.evil)
			{
				num2 = Math.Max(NGU.skills[i].evilTargetLevel() - NGU.skills[i].evilLevel, 0L);
				scaledLevelGain(NGU.skills[i].evilProgress, num, seconds, NGU.skills[i].evilLevel);
				long num5 = Math.Min(levelsAdded, num2);
				float num6 = barProgressAdded;
				float evilProgress = NGU.skills[i].evilProgress;
				if (num5 <= 0)
				{
					num5 = 0L;
				}
				if (NGU.skills[i].evilLevel + num5 >= NGUController.hardCapNormalLevel())
				{
					num5 = NGUController.hardCapNormalLevel() - NGU.skills[i].evilLevel;
				}
				if (num6 <= 0f)
				{
					num6 = 0f;
				}
				if (num6 >= 1f)
				{
					num6 = 0.99f;
				}
				NGU.skills[i].evilLevel += num5;
				NGU.skills[i].evilProgress = num6;
				if (num5 == 0L)
				{
					message = message + "Gained " + ((num6 - evilProgress) * 100f).ToString("#0.00") + "% of a level in (EVIL) " + NGUController.NGU[i].NGUName + "!\n";
				}
				else
				{
					NGU.skills[i].evilProgress = barProgressAdded;
					message = message + "Gained " + display(num5) + " levels in (EVIL) " + NGUController.NGU[i].NGUName + "!\n";
				}
				if (NGU.skills[i].evilLevel > NGUController.hardCapNormalLevel())
				{
					NGU.skills[i].evilLevel = NGUController.hardCapNormalLevel();
				}
				if (beastQuest.quirkLevel[14] > 0)
				{
					long level = NGU.skills[i].level;
					NGU.skills[i].level += num5;
					if (NGU.skills[i].level > NGUController.hardCapNormalLevel())
					{
						NGU.skills[i].level = NGUController.hardCapNormalLevel();
					}
					long level2 = NGU.skills[i].level;
					message = message + "You also gained " + display(level2 - level) + " levels in (normal)" + NGUController.NGU[i].NGUName + " thanks to your Quirk!\n";
				}
			}
			else
			{
				if (settings.nguLevelTrack != difficulty.sadistic)
				{
					continue;
				}
				num2 = Math.Max(NGU.skills[i].sadisticTargetLevel() - NGU.skills[i].sadisticLevel, 0L);
				scaledLevelGain(NGU.skills[i].sadisticProgress, num, seconds, NGU.skills[i].sadisticLevel);
				long num7 = Math.Min(levelsAdded, num2);
				float num8 = barProgressAdded;
				float sadisticProgress = NGU.skills[i].sadisticProgress;
				if (num7 <= 0)
				{
					num7 = 0L;
				}
				if (NGU.skills[i].sadisticLevel + num7 >= NGUController.hardCapNormalLevel())
				{
					num7 = NGUController.hardCapNormalLevel() - NGU.skills[i].sadisticLevel;
				}
				if (num8 <= 0f)
				{
					num8 = 0f;
				}
				if (num8 >= 1f)
				{
					num8 = 0.99f;
				}
				NGU.skills[i].sadisticLevel += num7;
				NGU.skills[i].sadisticProgress = num8;
				if (num7 == 0L)
				{
					message = message + "Gained " + ((num8 - sadisticProgress) * 100f).ToString("#0.00") + "% of a level in (SADISTIC) " + NGUController.NGU[i].NGUName + "!\n";
				}
				else
				{
					NGU.skills[i].sadisticProgress = barProgressAdded;
					message = message + "Gained " + display(num7) + " levels in (SADISTIC)" + NGUController.NGU[i].NGUName + "!\n";
				}
				if (NGU.skills[i].sadisticLevel > NGUController.hardCapNormalLevel())
				{
					NGU.skills[i].sadisticLevel = NGUController.hardCapNormalLevel();
				}
				if (beastQuest.quirkLevel[89] > 0)
				{
					long evilLevel = NGU.skills[i].evilLevel;
					NGU.skills[i].evilLevel += num7;
					if (NGU.skills[i].evilLevel > NGUController.hardCapNormalLevel())
					{
						NGU.skills[i].evilLevel = NGUController.hardCapNormalLevel();
					}
					long evilLevel2 = NGU.skills[i].evilLevel;
					message = message + "You also gained " + display(evilLevel2 - evilLevel) + " levels in (EVIL)" + NGUController.NGU[i].NGUName + " thanks to your Quirk!\n";
				}
				if (beastQuest.quirkLevel[89] > 0 && beastQuest.quirkLevel[14] > 0)
				{
					long level3 = NGU.skills[i].level;
					NGU.skills[i].level += num7;
					if (NGU.skills[i].level > NGUController.hardCapNormalLevel())
					{
						NGU.skills[i].level = NGUController.hardCapNormalLevel();
					}
					long level4 = NGU.skills[i].level;
					message = message + "You also gained " + display(level4 - level3) + " levels in (normal)" + NGUController.NGU[i].NGUName + " thanks to your Quirk!\n";
				}
			}
		}
		for (int j = 0; j < NGU.magicSkills.Count; j++)
		{
			if (NGU.magicSkills[j].magic <= 0 || (NGU.magicSkills[j].level >= NGUController.hardCapNormalLevel() && settings.nguLevelTrack == difficulty.normal) || (NGU.magicSkills[j].evilLevel >= NGUController.hardCapNormalLevel() && settings.nguLevelTrack == difficulty.evil) || (NGU.magicSkills[j].sadisticLevel >= NGUController.hardCapNormalLevel() && settings.nguLevelTrack == difficulty.sadistic))
			{
				continue;
			}
			float num9 = NGUController.NGUMagic[j].progressPerTick();
			if (arbitrary.magicPotion1Time.totalseconds > 0.0)
			{
				num9 /= allArbitrary.potionModifier();
			}
			long num10 = 0L;
			if (settings.nguLevelTrack == difficulty.normal)
			{
				scaledLevelGain(NGU.magicSkills[j].progress, num9, seconds, NGU.magicSkills[j].level);
				num10 = Math.Max(NGU.magicSkills[j].targetLevel() - NGU.magicSkills[j].level, 0L);
				long num11 = Math.Min(levelsAdded, num10);
				if (NGU.magicSkills[j].level + num11 >= NGUController.hardCapNormalLevel())
				{
					num11 = NGUController.hardCapNormalLevel() - NGU.magicSkills[j].level;
				}
				float num12 = barProgressAdded;
				float progress2 = NGU.magicSkills[j].progress;
				if (num11 <= 0)
				{
					num11 = 0L;
				}
				if (num12 <= 0f)
				{
					num12 = 0f;
				}
				if (num12 >= 1f)
				{
					num12 = 0.99f;
				}
				NGU.magicSkills[j].level += num11;
				NGU.magicSkills[j].progress = num12;
				if (num11 == 0L)
				{
					message = message + "Gained " + ((num12 - progress2) * 100f).ToString("#0.00") + "% of a level in " + NGUController.NGUMagic[j].NGUName + "!\n";
				}
				else
				{
					NGU.magicSkills[j].progress = barProgressAdded;
					message = message + "Gained " + display(num11) + " levels in " + NGUController.NGUMagic[j].NGUName + "!\n";
				}
				if (NGU.magicSkills[j].level > NGUController.hardCapNormalLevel())
				{
					NGU.magicSkills[j].level = NGUController.hardCapNormalLevel();
				}
			}
			else if (settings.nguLevelTrack == difficulty.evil)
			{
				scaledLevelGain(NGU.magicSkills[j].evilProgress, num9, seconds, NGU.magicSkills[j].evilLevel);
				num10 = Math.Max(NGU.magicSkills[j].evilTargetLevel() - NGU.magicSkills[j].evilLevel, 0L);
				long num13 = Math.Min(levelsAdded, num10);
				if (NGU.magicSkills[j].evilLevel + num13 >= NGUController.hardCapNormalLevel())
				{
					num13 = NGUController.hardCapNormalLevel() - NGU.magicSkills[j].evilLevel;
				}
				float num14 = barProgressAdded;
				float evilProgress2 = NGU.magicSkills[j].evilProgress;
				if (num13 <= 0)
				{
					num13 = 0L;
				}
				if (num14 <= 0f)
				{
					num14 = 0f;
				}
				if (num14 >= 1f)
				{
					num14 = 0.99f;
				}
				NGU.magicSkills[j].evilLevel += num13;
				NGU.magicSkills[j].evilProgress = num14;
				if (num13 == 0L)
				{
					message = message + "Gained " + ((num14 - evilProgress2) * 100f).ToString("#0.00") + "% of a level in (EVIL) " + NGUController.NGUMagic[j].NGUName + "!\n";
				}
				else
				{
					NGU.magicSkills[j].evilProgress = barProgressAdded;
					message = message + "Gained " + display(num13) + " levels in (EVIL) " + NGUController.NGUMagic[j].NGUName + "!\n";
				}
				if (NGU.magicSkills[j].evilLevel > NGUController.hardCapNormalLevel())
				{
					NGU.magicSkills[j].evilLevel = NGUController.hardCapNormalLevel();
				}
				if (beastQuest.quirkLevel[14] > 0)
				{
					long level5 = NGU.magicSkills[j].level;
					NGU.magicSkills[j].level += num13;
					if (NGU.magicSkills[j].level > NGUController.hardCapNormalLevel())
					{
						NGU.magicSkills[j].level = NGUController.hardCapNormalLevel();
					}
					long level6 = NGU.magicSkills[j].level;
					message = message + "You also gained " + display(level6 - level5) + " levels in (normal)" + NGUController.NGUMagic[j].NGUName + " thanks to your Quirk!\n";
				}
			}
			else
			{
				if (settings.nguLevelTrack != difficulty.sadistic)
				{
					continue;
				}
				scaledLevelGain(NGU.magicSkills[j].sadisticProgress, num9, seconds, NGU.magicSkills[j].sadisticLevel);
				num10 = Math.Max(NGU.magicSkills[j].sadisticTargetLevel() - NGU.magicSkills[j].sadisticLevel, 0L);
				long num15 = Math.Min(levelsAdded, num10);
				if (NGU.magicSkills[j].sadisticLevel + num15 >= NGUController.hardCapNormalLevel())
				{
					num15 = NGUController.hardCapNormalLevel() - NGU.magicSkills[j].sadisticLevel;
				}
				float num16 = barProgressAdded;
				float sadisticProgress2 = NGU.magicSkills[j].sadisticProgress;
				if (num15 <= 0)
				{
					num15 = 0L;
				}
				if (num16 <= 0f)
				{
					num16 = 0f;
				}
				if (num16 >= 1f)
				{
					num16 = 0.99f;
				}
				NGU.magicSkills[j].sadisticLevel += num15;
				NGU.magicSkills[j].sadisticProgress = num16;
				if (num15 == 0L)
				{
					message = message + "Gained " + ((num16 - sadisticProgress2) * 100f).ToString("#0.00") + "% of a level in (SADISTIC) " + NGUController.NGUMagic[j].NGUName + "!\n";
				}
				else
				{
					NGU.magicSkills[j].sadisticProgress = barProgressAdded;
					message = message + "Gained " + display(num15) + " levels in (SADISTIC) " + NGUController.NGUMagic[j].NGUName + "!\n";
				}
				if (NGU.magicSkills[j].sadisticLevel > NGUController.hardCapNormalLevel())
				{
					NGU.magicSkills[j].sadisticLevel = NGUController.hardCapNormalLevel();
				}
				if (beastQuest.quirkLevel[89] > 0)
				{
					long evilLevel3 = NGU.magicSkills[j].evilLevel;
					NGU.magicSkills[j].evilLevel += num15;
					if (NGU.magicSkills[j].evilLevel > NGUController.hardCapNormalLevel())
					{
						NGU.magicSkills[j].evilLevel = NGUController.hardCapNormalLevel();
					}
					long evilLevel4 = NGU.magicSkills[j].evilLevel;
					message = message + "You also gained " + display(evilLevel4 - evilLevel3) + " levels in (EVIL)" + NGUController.NGUMagic[j].NGUName + " thanks to your Quirk!\n";
				}
				if (beastQuest.quirkLevel[89] > 0 && beastQuest.quirkLevel[14] > 0)
				{
					long level7 = NGU.magicSkills[j].level;
					NGU.magicSkills[j].level += num15;
					if (NGU.magicSkills[j].level > NGUController.hardCapNormalLevel())
					{
						NGU.magicSkills[j].level = NGUController.hardCapNormalLevel();
					}
					long level8 = NGU.magicSkills[j].level;
					message = message + "You also gained " + display(level8 - level7) + " levels in (normal)" + NGUController.NGUMagic[j].NGUName + " thanks to your Quirk!\n";
				}
			}
		}
		if (message != "")
		{
			message += "\n";
		}
	}

	public void beardOfflineProgress(int energyBeardTime, int magicBeardTime)
	{
		message = "";
		for (int i = 0; i < beards.activeBeards.Count; i++)
		{
			int num = beards.activeBeards[i];
			if (allBeards.usesEnergy[num] && energyBeardTime > 0)
			{
				float num2 = allBeards.beardProgressPerTick(num);
				if (arbitrary.energyPotion1Time.totalseconds > 0.0)
				{
					num2 /= Mathf.Sqrt(allArbitrary.potionModifier());
				}
				if (arbitrary.energyBarBar1Time.totalseconds > 0.0)
				{
					num2 /= allArbitrary.potionModifier();
				}
				scaledLevelGain(beards.beards[num].progress, num2, energyBeardTime, beards.beards[num].beardLevel);
			}
			else
			{
				if (allBeards.usesEnergy[num] || magicBeardTime <= 0)
				{
					continue;
				}
				float num3 = allBeards.beardProgressPerTick(num);
				if (arbitrary.magicPotion1Time.totalseconds > 0.0)
				{
					num3 /= Mathf.Sqrt(allArbitrary.potionModifier());
				}
				if (arbitrary.magicBarBar1Time.totalseconds > 0.0)
				{
					num3 /= allArbitrary.potionModifier();
				}
				scaledLevelGain(beards.beards[num].progress, num3, magicBeardTime, beards.beards[num].beardLevel);
			}
			long num4 = levelsAdded;
			if (num4 < 0)
			{
				num4 = 0L;
			}
			if ((float)num4 > (float)Mathf.Max(energyBeardTime * 50, magicBeardTime * 50) * 1.01f)
			{
				num4 = 0L;
			}
			beards.beards[num].beardLevel += num4;
			float num5 = barProgressAdded;
			float progress = beards.beards[num].progress;
			if (num5 <= 0f)
			{
				num5 = 0f;
			}
			if (num5 >= 1f)
			{
				num5 = 0.99f;
			}
			beards.beards[num].progress = num5;
			if (num4 == 0L)
			{
				message = message + "\nGained " + ((num5 - progress) * 100f).ToString("#0.00") + "% of a level in " + allBeards.beard.beardNames[num] + "!";
			}
			else
			{
				message = message + "\nGained " + display(num4) + " levels in " + allBeards.beard.beardNames[num] + "!";
			}
		}
		if (message != "")
		{
			message += "\n";
		}
	}

	public void hacksOfflineProgress(int seconds)
	{
		message = "";
		for (int i = 0; i < hacks.hacks.Count; i++)
		{
			if (i == 15 && hacksController.endHackAvailable() && hacks.hacks[15].level < 1)
			{
				hacks.hacks[i].progress += hacksController.endHackSpeed() * (float)(seconds * 50) / 2f;
				if (hacks.hacks[i].progress >= 1f)
				{
					hacks.hacks[i].progress = 0f;
					hacks.hacks[i].level++;
				}
			}
			else if (i == 15)
			{
				continue;
			}
			if (hacks.hacks[i].res3 <= 0 || (double)hacksController.progressPerTick(i) < 1E-09 || hacks.hacks[i].level >= hacksController.hardCapLevel(i))
			{
				continue;
			}
			int num = seconds * 50;
			int num2 = 0;
			if (num < 0)
			{
				continue;
			}
			float num3 = hacksController.progressPerTick(i);
			if (arbitrary.res3Potion1Time.totalseconds > 0.0)
			{
				num3 /= allArbitrary.res3PotionModifier();
			}
			int num4 = Mathf.CeilToInt((1f - hacks.hacks[i].progress) / num3);
			if (num4 >= num)
			{
				hacks.hacks[i].progress += num3 * (float)num;
				message = message + "\nGained " + (num3 * (float)num * 100f).ToString("#0.##") + " % progress in " + hacksController.properties[i].hackName + "!";
				continue;
			}
			hacks.hacks[i].progress = 0f;
			hacks.hacks[i].level++;
			num2++;
			num -= num4;
			while (num > 0 && hacks.hacks[i].level < hacksController.hardCapLevel(i))
			{
				num3 = hacksController.progressPerTick(i);
				if (arbitrary.res3Potion1Time.totalseconds > 0.0)
				{
					num3 /= allArbitrary.res3PotionModifier();
				}
				num4 = Mathf.CeilToInt(1f / num3);
				if (num4 >= num)
				{
					hacks.hacks[i].progress += num3 * (float)num;
					num = 0;
					message = message + "\nGained " + num2 + " levels in " + hacksController.properties[i].hackName + "!";
					break;
				}
				hacks.hacks[i].level++;
				num2++;
				num -= num4;
			}
		}
		if (message != "")
		{
			message += "\n";
		}
	}

	public void wishOfflineProgress(int seconds)
	{
		message = "";
		if (!wishes.wishesOn)
		{
			return;
		}
		for (int i = 0; i < wishes.wishes.Count; i++)
		{
			if (wishesController.rawProgressPerTick(i) <= 0f || (double)wishesController.rawProgressPerTick(i) < 1E-09 || wishes.wishes[i].level >= wishesController.maxWishLevel(i))
			{
				continue;
			}
			int num = seconds * 50;
			int num2 = 0;
			if (num < 0)
			{
				continue;
			}
			float num3 = wishesController.rawProgressPerTick(i);
			if (arbitrary.energyPotion1Time.totalseconds > 0.0)
			{
				num3 /= Mathf.Pow(allArbitrary.potionModifier(), wishesController.energyBias(i));
			}
			if (arbitrary.magicPotion1Time.totalseconds > 0.0)
			{
				num3 /= Mathf.Pow(allArbitrary.potionModifier(), wishesController.magicBias(i));
			}
			if (arbitrary.res3Potion1Time.totalseconds > 0.0)
			{
				num3 /= Mathf.Pow(allArbitrary.res3PotionModifier(), wishesController.res3Bias(i));
			}
			num3 = Mathf.Min(wishesController.minimumWishTime(), num3);
			if ((double)num3 <= 1E-08)
			{
				num3 = 0f;
			}
			if (num3 <= 0f)
			{
				continue;
			}
			int num4 = Mathf.CeilToInt((1f - wishes.wishes[i].progress) / num3);
			if (num4 >= num)
			{
				wishes.wishes[i].progress += num3 * (float)num;
				message = message + "\nGained " + (num3 * (float)num * 100f).ToString("#0.##") + " % progress in " + wishesController.properties[i].wishName + "!";
				continue;
			}
			wishes.wishes[i].progress = 0f;
			wishes.wishes[i].level++;
			num2++;
			wishesController.doLevelupEffect(i, wishes.wishes[i].level);
			num -= num4;
			while (num > 0 && wishes.wishes[i].level < wishesController.maxWishLevel(i))
			{
				num3 = wishesController.rawProgressPerTick(i);
				if (arbitrary.energyPotion1Time.totalseconds > 0.0)
				{
					num3 /= Mathf.Pow(allArbitrary.potionModifier(), wishesController.energyBias(i));
				}
				if (arbitrary.magicPotion1Time.totalseconds > 0.0)
				{
					num3 /= Mathf.Pow(allArbitrary.potionModifier(), wishesController.magicBias(i));
				}
				if (arbitrary.res3Potion1Time.totalseconds > 0.0)
				{
					num3 /= Mathf.Pow(allArbitrary.res3PotionModifier(), wishesController.res3Bias(i));
				}
				num3 = Mathf.Min(wishesController.minimumWishTime(), num3);
				if ((double)num3 <= 1E-08)
				{
					num3 = 0f;
				}
				if (num3 <= 0f)
				{
					message = message + "\nGained " + num2 + " levels in " + wishesController.properties[i].wishName + "!";
					break;
				}
				num4 = Mathf.CeilToInt(1f / num3);
				if (num4 >= num)
				{
					wishes.wishes[i].progress += num3 * (float)num;
					num = 0;
					message = message + "\nGained " + num2 + " levels in " + wishesController.properties[i].wishName + "!";
					break;
				}
				wishes.wishes[i].level++;
				num2++;
				wishesController.doLevelupEffect(i, wishes.wishes[i].level);
				num -= num4;
			}
			if (wishes.wishes[i].level >= wishesController.maxWishLevel(i))
			{
				wishesController.removeAllEnergy(i);
				wishesController.removeAllMagic(i);
				wishesController.removeAllRes3(i);
			}
		}
		if (message != "")
		{
			message += "\n";
		}
	}

	public void cardsOfflineProgress(int seconds)
	{
		message = "";
		if (!cards.cardsOn)
		{
			return;
		}
		long num = seconds * 50;
		long num2 = 50 * (long)Mathf.Min(seconds, Mathf.Max((float)arbitrary.mayoSpeedPotTime.totalseconds, 0f));
		long num3 = (long)Mathf.Max(num - num2, 0f);
		float num4 = cardsController.manaGenProgressPerTick() * (float)num2;
		if (num2 > 0)
		{
			arbitrary.mayoSpeedPotTime.removeTime((float)num2 / 50f);
			if (arbitrary.mayoSpeedPotTime.totalseconds < 5.0)
			{
				arbitrary.mayoSpeedPotTime.reset();
			}
		}
		float num5 = cardsController.manaGenProgressPerTick() * (float)num3;
		float toAdd = num4 + num5;
		for (int i = 0; i < cards.manas.Count; i++)
		{
			if (cards.manas[i].running)
			{
				int amount = cards.manas[i].amount;
				float progress = cards.manas[i].progress;
				cardsController.addBigManaProgress(toAdd, i);
				int amount2 = cards.manas[i].amount;
				float progress2 = cards.manas[i].progress;
				if (amount2 - amount >= 1)
				{
					message = message + "\nGained " + (amount2 - amount) + " " + cardsController.getManaName(i) + "!";
				}
				else
				{
					message = message + "\nGained " + ((progress2 - progress) * 100f).ToString("#0.##") + "% progress for " + cardsController.getManaName(i) + "!";
				}
			}
		}
		if (cardsController.unlockedChonkers())
		{
			double num6 = cards.chonkerSpawnTimer.totalseconds + (double)((float)seconds * cardsController.totalCardSpeed());
			int num7 = (int)(num6 / (double)cardsController.chonkerSpawnTime());
			int num8 = 0;
			if (num7 > cardsController.maxDeckSize() - cards.cards.Count)
			{
				cards.chonkerSpawnTimer.setTime(cardsController.chonkerSpawnTime());
			}
			else
			{
				cards.chonkerSpawnTimer.setTime(num6 % (double)cardsController.chonkerSpawnTime());
			}
			while (cards.cards.Count < cardsController.maxDeckSize() && num7 > 0)
			{
				cardsController.addChonkerCard();
				num7--;
				num8++;
			}
			if (num8 > 0)
			{
				message = message + "\nGenerated " + num8 + " BIG CHONKER Cards!";
			}
		}
		double num9 = cards.cardSpawnTimer.totalseconds + (double)((float)seconds * cardsController.totalCardSpeed());
		int num10 = (int)(num9 / (double)cardsController.cardSpawnTime());
		int num11 = 0;
		if (num10 > cardsController.maxDeckSize() - cards.cards.Count)
		{
			cards.cardSpawnTimer.setTime(cardsController.cardSpawnTime());
		}
		else
		{
			cards.cardSpawnTimer.setTime(num9 % (double)cardsController.cardSpawnTime());
		}
		while (cards.cards.Count < cardsController.maxDeckSize() && num10 > 0)
		{
			cardsController.addCard();
			num10--;
			num11++;
		}
		if (num11 > 0)
		{
			message = message + "\nGenerated " + num11 + " Cards!";
		}
	}

	public void cookingOfflineProgress(int seconds)
	{
		if (cooking.unlocked)
		{
			bool flag = false;
			if (cooking.cookTimer >= cookingController.eatRate())
			{
				flag = true;
			}
			cooking.cookTimer += seconds;
			string text = "";
			if (cooking.cookTimer > cookingController.maxBankedtime())
			{
				cooking.cookTimer = cookingController.maxBankedtime();
			}
			if (cooking.cookTimer >= cookingController.eatRate())
			{
				flag = true;
			}
			if (flag)
			{
				text += "\n\nYou feel hungry now!";
			}
		}
	}

	private void scaledLevelGain(float curBarProgress, float progressPerTick, int seconds, long startLevel)
	{
		levelsAdded = 0L;
		barProgressAdded = 0f;
		long num = seconds * 50;
		long num2 = num;
		long num3 = startLevel;
		if (progressPerTick < 1E-09f)
		{
			return;
		}
		if ((float)num / (float)Mathf.CeilToInt(1f / progressPerTick) < 100f)
		{
			long num4 = Mathf.CeilToInt((1f - curBarProgress) / progressPerTick);
			if (num < num4)
			{
				barProgressAdded = (float)num * progressPerTick + curBarProgress;
				levelsAdded = num3 - startLevel;
				return;
			}
			num3++;
			num -= num4;
			barProgressAdded = 0f;
			while (true)
			{
				num4 = Mathf.CeilToInt(Mathf.CeilToInt(1f / progressPerTick * (float)((num3 + 1) / (startLevel + 1))));
				if (num < num4)
				{
					break;
				}
				num3++;
				num -= num4;
			}
			barProgressAdded = (float)num / (float)num4;
			if (barProgressAdded >= 1f)
			{
				barProgressAdded = 0.99f;
			}
			levelsAdded = num3 - startLevel;
			return;
		}
		if (progressPerTick > 1f)
		{
			long num5 = Mathf.FloorToInt((float)(startLevel + 1) * progressPerTick - (float)startLevel);
			progressPerTick = 1f;
			if (num5 > num)
			{
				levelsAdded = Mathf.FloorToInt(num);
				barProgressAdded = 0f;
				return;
			}
			num -= num5;
			progressPerTick = 1f;
			num3 += num5;
		}
		float num6 = 1f / (progressPerTick * (float)(startLevel + 1));
		float num7 = num3 + 1;
		float num8 = num;
		long num9 = (long)Mathf.Floor((Mathf.Sqrt(4f * num6 * Mathf.Pow(num7, 2f) - 4f * num6 * num7 + num6 + 8f * num8) - Mathf.Sqrt(num6)) / (2f * Mathf.Sqrt(num6)));
		levelsAdded = num9 - startLevel;
		if (levelsAdded < 0)
		{
			levelsAdded = 0L;
		}
		if (levelsAdded > num2)
		{
			levelsAdded = num2;
		}
		barProgressAdded = 0f;
		if (levelsAdded < 0)
		{
			levelsAdded = 0L;
		}
		if (barProgressAdded < 0f)
		{
			barProgressAdded = 0f;
		}
	}

	public void constantLevelGain(float currentProgress, float toAdd, int seconds)
	{
		if (toAdd > 1f)
		{
			toAdd = 1f;
		}
		if (toAdd < 1E-09f)
		{
			return;
		}
		long num = seconds * 50;
		int num2 = Mathf.CeilToInt(1f / toAdd);
		if (num < Mathf.CeilToInt((float)num2 * currentProgress))
		{
			barProgressAdded = currentProgress + toAdd * (float)num;
			levelsAdded = 0L;
			return;
		}
		levelsAdded = (long)Math.Floor((double)(num / num2));
		if (levelsAdded < 0)
		{
			levelsAdded = 0L;
		}
		if (barProgressAdded < 0f)
		{
			barProgressAdded = 0f;
		}
	}

	private void constantlevelsAfforded(double baseGoldCost, double currentGold)
	{
		if (baseGoldCost > currentGold)
		{
			levelsAdded = 0L;
			return;
		}
		if (Math.Floor(currentGold / baseGoldCost) > 9.223372036854776E+18)
		{
			levelsAdded = long.MaxValue;
		}
		else
		{
			levelsAdded = (long)Math.Floor(currentGold / baseGoldCost);
		}
		if (levelsAdded < 0)
		{
			levelsAdded = 0L;
		}
	}

	private double constantGoldCost(double baseGoldCost, long levelsAdded, bool countFirst)
	{
		if (levelsAdded == 0L)
		{
			return 0.0;
		}
		double num = baseGoldCost * (double)levelsAdded;
		if (!countFirst)
		{
			num -= baseGoldCost;
		}
		return num;
	}

	private void levelsAfforded(double baseGoldCost, double currentGold, long startLevel)
	{
		double num = startLevel + 1;
		if (baseGoldCost * num > currentGold)
		{
			levelsAdded = 0L;
			return;
		}
		double num2 = Math.Floor((Math.Sqrt(4.0 * baseGoldCost * Math.Pow(num, 2.0) - 4.0 * baseGoldCost * num + baseGoldCost + 8.0 * currentGold) - Math.Sqrt(baseGoldCost)) / (2.0 * Math.Sqrt(baseGoldCost)));
		long num3 = ((!(num2 >= 9.223372036854776E+18)) ? ((long)num2) : long.MaxValue);
		levelsAdded = num3 - startLevel;
	}

	private double goldUsedLevels(long m, long n, double b, bool countFirst)
	{
		if (m == n)
		{
			return 0.0;
		}
		if (b <= 0.0)
		{
			return 0.0;
		}
		double num = 0.5 * b * (0.0 - Math.Pow(m, 2.0) + (double)m + Math.Pow(n, 2.0) + (double)n);
		if (!countFirst)
		{
			num -= b * (double)m;
		}
		if (num <= 0.0)
		{
			num = 0.0;
		}
		return num;
	}

	private void upgradesAfforded(double baseGoldCost, double currentGold, long startLevel)
	{
		if (baseGoldCost * Math.Pow(startLevel + 1, 2.0) >= currentGold || currentGold == 0.0 || baseGoldCost == 0.0)
		{
			levelsAdded = 0L;
			return;
		}
		double num = Math.Floor(Math.Pow(2.0, 1.0 / 3.0) * baseGoldCost / Math.Pow(1728.0 * Math.Pow(baseGoldCost, 3.0) * Math.Pow(startLevel, 3.0) - 2592.0 * Math.Pow(baseGoldCost, 3.0) * Math.Pow(startLevel, 2.0) + 864.0 * Math.Pow(baseGoldCost, 3.0) * (double)startLevel + 5184.0 * Math.Pow(baseGoldCost, 2.0) * currentGold + Math.Sqrt(Math.Pow(1728.0 * Math.Pow(baseGoldCost, 3.0) * Math.Pow(startLevel, 3.0) - 2592.0 * Math.Pow(baseGoldCost, 3.0) * Math.Pow(startLevel, 2.0) + 864.0 * Math.Pow(baseGoldCost, 3.0) * (double)startLevel + 5184.0 * Math.Pow(baseGoldCost, 2.0) * currentGold, 2.0) - 6912.0 * Math.Pow(baseGoldCost, 6.0)), 1.0 / 3.0) + 1.0 / (12.0 * Math.Pow(2.0, 1.0 / 3.0) * baseGoldCost) * Math.Pow(1728.0 * Math.Pow(baseGoldCost, 3.0) * Math.Pow(startLevel, 3.0) - 2592.0 * Math.Pow(baseGoldCost, 3.0) * Math.Pow(startLevel, 2.0) + 864.0 * Math.Pow(baseGoldCost, 3.0) * (double)startLevel + 5184.0 * Math.Pow(baseGoldCost, 2.0) * currentGold + Math.Sqrt(Math.Pow(1728.0 * Math.Pow(baseGoldCost, 3.0) * Math.Pow(startLevel, 3.0) - 2592.0 * Math.Pow(baseGoldCost, 3.0) * Math.Pow(startLevel, 2.0) + 864.0 * Math.Pow(baseGoldCost, 3.0) * (double)startLevel + 5184.0 * Math.Pow(baseGoldCost, 2.0) * currentGold, 2.0) - 6912.0 * Math.Pow(baseGoldCost, 6.0)), 1.0 / 3.0) - 0.5);
		long num2 = ((!(num >= 9.223372036854776E+18)) ? ((long)num) : long.MaxValue);
		if (num2 < startLevel)
		{
			num2 = startLevel;
		}
		levelsAdded = num2 - startLevel;
	}

	private double goldUsedUpgrades(long m, long n, double b, bool countFirst)
	{
		if (m == n)
		{
			return 0.0;
		}
		if (b <= 0.0)
		{
			return 0.0;
		}
		double num = b / 6.0 * (0.0 - 2.0 * Math.Pow(m, 3.0) + 3.0 * Math.Pow(m, 2.0) - (double)m + 2.0 * Math.Pow(n, 3.0) + 3.0 * Math.Pow(n, 2.0) + (double)n);
		if (!countFirst)
		{
			num -= b * Math.Pow(m, 2.0);
		}
		if (num <= 0.0)
		{
			num = 0.0;
		}
		return num;
	}

	public void squaredLevelGain(float curBarProgress, float progressPerTick, int seconds, long startLevel)
	{
		long num = seconds * 50;
		long num2 = startLevel;
		if (progressPerTick == 0f)
		{
			return;
		}
		long num3 = Mathf.CeilToInt((1f - curBarProgress) * (1f / progressPerTick));
		if (num < num3)
		{
			barProgressAdded = (float)num / (float)num3 * (1f - curBarProgress) + curBarProgress;
			levelsAdded = num2 - startLevel;
			return;
		}
		num2++;
		num -= num3;
		barProgressAdded = 0f;
		while (true)
		{
			num3 = Mathf.CeilToInt(Mathf.CeilToInt(1f / progressPerTick * (Mathf.Pow(num2 + 1, 2f) / Mathf.Pow(startLevel + 1, 2f))));
			if (num < num3)
			{
				break;
			}
			num2++;
			num -= num3;
		}
		barProgressAdded = num / num3;
		if (barProgressAdded >= 1f)
		{
			barProgressAdded = 0.99f;
		}
		levelsAdded = num2 - startLevel;
	}

	public void linearLevelGain(float curBarProgress, float progressPerTick, int seconds, long startLevel)
	{
		long num = seconds * 50;
		long num2 = startLevel;
		if (progressPerTick < 1E-09f)
		{
			levelsAdded = 0L;
			barProgressAdded = 0f;
			return;
		}
		long num3 = Mathf.CeilToInt((1f - curBarProgress) * (1f / progressPerTick));
		if (num < num3)
		{
			barProgressAdded = (float)num / (float)num3 * (1f - curBarProgress) + curBarProgress;
			levelsAdded = num2 - startLevel;
			return;
		}
		num2++;
		num -= num3;
		barProgressAdded = 0f;
		while (true)
		{
			num3 = Mathf.CeilToInt(Mathf.CeilToInt(1f / progressPerTick * (float)((num2 + 1) / (startLevel + 1))));
			if (num < num3)
			{
				break;
			}
			num2++;
			num -= num3;
		}
		barProgressAdded = num / num3;
		if (barProgressAdded >= 1f)
		{
			barProgressAdded = 0.99f;
		}
		levelsAdded = num2 - startLevel;
	}

	public void showEndSequence(int id)
	{
		foreach (GameObject endPanel in endPanels)
		{
			endPanel.transform.localPosition = new Vector3(-5000f, -5000f);
		}
		endPanels[id].transform.localPosition = new Vector3(0f, 0f);
	}

	public void endFinish()
	{
		foreach (GameObject endPanel in endPanels)
		{
			endPanel.transform.localPosition = new Vector3(-5000f, -5000f);
		}
	}
}
