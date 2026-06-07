using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public enum GameState
	{
		Intro = 0,
		Playing = 1,
		Cutscene = 2,
		PreRoundSetup = 3,
		RoundOverShop = 4
	}

	public static GameManager Singleton;

	public Player localPlayerScript;

	public GameObject playerObject;

	public GameObject playerCamera;

	public Camera mainCamera;

	public const bool IS_DEMO_VERSION = true;

	public PrefabBank prefabBank;

	public TurtleEatAoe turtleCoinHandler;

	public const float GROUND_Y_HEIGHT = 1.23f;

	[Header("Scene Lighting")]
	[SerializeField]
	private Color ambientLightColor_Default;

	[SerializeField]
	private Color ambientLightColor_Dark;

	[SerializeField]
	private Color ambientLightColor_BelladonnaEnding;

	[Header("Plant Beds")]
	public List<PlantBed> allPlantBeds = new List<PlantBed>();

	private bool allPlantBedsAreHalted;

	public bool updatePlantBedSidingsNextFrame;

	public BerryPicker berryPickerInScene;

	[Header("Tiles")]
	public float globalTileSize;

	public float soilTileHeight;

	[Header("Player Build State")]
	public PlayerBuildModeState buildModeState;

	public bool buildMode_SnapToGrid;

	public BuildModeRotationMode buildMode_RotationMode;

	public float buildMode_YOffset;

	public GameObject buildMode_PlacementPrefab;

	public GameObject buildMode_BuildablePrefab;

	public bool buildMode_CancelModeAfterPlacement;

	public int buildMode_CurrentMoneyPrice;

	public BuildableIdentity buildMode_BuildableIdentity;

	public Action OnBuildModeEntered_Action;

	public Action OnBuildablePlaced_Action;

	public Action OnNightTime_Action;

	public Action OnRoundStart_Action;

	public GameObject buildModeGridDisplay;

	public GameObject grassRenderers;

	public float globalBerryGrowthRate;

	public GameState gameState;

	[Header("Conveyor Belts")]
	public float conveyorBelt_ForcePower;

	[Header("Trampolines")]
	public Vector3 trampoline_Force_Direction;

	public float trampoline_Force_Power;

	[Header("Blender/Smoothies")]
	public Vector3 SmoothieSpawn_Force_Direction;

	public float SmoothieSpawn_Force_Power;

	[Header("Gold Rush")]
	public bool goldRushIsActive;

	public float goldRush_Time_Current;

	public float goldRush_Cooldown_Curr;

	public bool canUseGoldRush;

	public float goldRush_growthSpeedBoost_Curr;

	[Header("Big Hole Powerup")]
	public bool bigHoleIsActive;

	public float bigHole_Time_Current;

	public float bigHole_Cooldown_Curr;

	public bool canUseBigHole;

	public float bigHole_SizeBoost_Curr;

	[SerializeField]
	private GameObject bigHole_BerryLauncherTrigger;

	private bool bigHole_BerryLauncher_IsSizeGrowing;

	private const float BIGHOLE_BERRYLAUNCHER_MAXSIZE = 240f;

	[SerializeField]
	private float bigHole_BerryLauncher_SizeGrowthSpeed;

	[Header("Build Spots")]
	public Dictionary<string, BuildSpot> buildSpotsDict = new Dictionary<string, BuildSpot>();

	public List<BuildSpot> availableBuildSpotsToBonusTileify = new List<BuildSpot>();

	public List<Buildable> allSpawnedBuildables = new List<Buildable>();

	[Header("Yard/Hole Scaling")]
	[SerializeField]
	private GameObject yardAndHoleObject;

	[SerializeField]
	private float holeScaleLerpSpeed;

	[SerializeField]
	private float currentYardAndHoleScale;

	[SerializeField]
	private float desiredYardAndHoleScale;

	[SerializeField]
	private float startingHoleScale;

	[SerializeField]
	private float holeScalePerAnomalousMaterial;

	private const int HOLEGROWTHLEVEL_FORMAXHOLESIZE = 100;

	public const int CANDY_HOLEGWORTHPOINTSONDEPOSIT = 1;

	[SerializeField]
	private float tempHoleSizeJuice_Curr;

	[SerializeField]
	private float tempHoleSizeJuice_DecayRate;

	[SerializeField]
	private float tempHoleSizeJuice_PerDeposit;

	[SerializeField]
	private float tempHoleSizeJuice_MaxGainAboveLevel;

	[Header("Hole Leveling")]
	public int holeLevel;

	[SerializeField]
	private float holeGrowthPoints_Curr;

	[SerializeField]
	private AnimationCurve antiJuiceCurve;

	[SerializeField]
	private float antiJuice_GrowthPointMinBeforeReduction;

	public const float HOLE_MAXSCALE = 3.5f;

	[SerializeField]
	private float[] holeLevelRequirements;

	private float holeLevel_CurrentProgress;

	[SerializeField]
	private float[] holeLevel_MinimumSizesPerLevel;

	[SerializeField]
	private float[] holeLevel_MaximumSizesPerLevel;

	[SerializeField]
	private float[] holeAntiProgress_PerLevel;

	[SerializeField]
	private float holeAntiProgress_ProgressMulti;

	[SerializeField]
	private float holeJuice_Min;

	[SerializeField]
	private float holeJuice_Max;

	[Header("Debug and Testing")]
	private float escapeHeld_QuitTimer_Curr;

	private float escapeHeld_QuitTimer_Threshold = 3f;

	[SerializeField]
	public GameObject playerSpawnPoint;

	[Header("Object Limits")]
	[SerializeField]
	private int spawnedBerryLimit;

	[SerializeField]
	private int spawnedCoinLimit;

	public List<GameObject> spawnedBerries;

	public List<GameObject> spawnedCoins;

	[Header("Misc Holders")]
	public List<GameObject> allSpawnedBonusTileParticles = new List<GameObject>();

	public Transform backupSeed_SpawnPoint;

	public GameObject backupSeed_SpawnedGameobject;

	private bool canCheckForNoSeedOrPlantSoftLock;

	[SerializeField]
	private GameObject playerOnlyHoleCollider_ForLevel0Hole;

	private int moneyDroppedInHoleThisRound;

	[Header("Berry Cultists")]
	public int cultistBerryGrownRequirement;

	[SerializeField]
	private GameObject cultistsSpawnPoint;

	public List<BerryCultist_AI> spawnedCultists = new List<BerryCultist_AI>();

	[Header("Hole Moving")]
	[SerializeField]
	private float holeMoveSpeed_ReturnToStarting_SpeedMulti;

	private Vector3 holeStartingPOS;

	public bool playerMovingHole;

	public GameObject holeDestination_VisualIndicator;

	private Vector3 desiredHoleDestination;

	public float holeMoveJuice_Curr;

	public float holeMoveJuice_UseRate;

	public GameObject holeMove_DynamicRadiusIndicator;

	private float holeMove_DynamicRadiusIndicator_StartingXZScale;

	private float holeMove_DynamicRadiusIndicator_YPos;

	private bool forceHide_HoleDynamicRadiusVisual;

	[Header("Blender Bot")]
	public Transform gadgetsSpawnPoint;

	[Header("Round Timer")]
	public float roundTimer_Curr;

	private bool hasPlayedLowTimeWarningChimeThisRound;

	public bool shouldTickDownRoundTime = true;

	public float totalPlayTimeForStats;

	public bool stopCountingSpeedrunTime;

	[Header("Milestone Objects")]
	public List<PickUppable> milestoneObjects_MasterList;

	public List<bool> milestoneObjects_MasterList_Bools = new List<bool>();

	public List<PickUppable> allGnomeMilestones;

	public int numOfGnomesRemaining;

	public int numOfRemainingMilestones;

	[Header("Star Orb Generator")]
	public StarOrbGenerator starOrbGenerator;

	[Header("Diggables")]
	public List<Diggable> diggablesMasterList = new List<Diggable>();

	[Header("Ceiling Related")]
	public GameObject ceilingObject;

	[Header("Camera Bubble")]
	[SerializeField]
	private GameObject cameraBubbleVisual;

	public bool hardDisableBubble;

	[Header("Hole Growth Prestige")]
	private bool hasHolePrestigedThisRound;

	public List<int> holePrestigeValues_HoleSizePerRank;

	public List<int> holePrestigeValues_RequiredJuicePerRank;

	public int holePrestigeJuice_Curr;

	public float holePrestigeCurrPercent;

	public static float SMOOTHIE_HOLEPRESTIGE_MULTIPLIER = 1.2f;

	[Header("Milestone Groupers")]
	public List<MilestoneGrouper> allMilestoneGroupers = new List<MilestoneGrouper>();

	[Header("Tools")]
	[SerializeField]
	private GameObject tool_StarWand;

	[SerializeField]
	private SledgeHammer tool_SledgeHammer;

	[SerializeField]
	private GameObject tool_Chainsaw;

	[SerializeField]
	private List<MeshRenderer> tool_ChainsawTeethRends;

	[SerializeField]
	private GameObject tool_Trampoline;

	[SerializeField]
	private GameObject tool_StarKey;

	[Header("Walls")]
	public List<BreakableWall> walls_MasterList;

	public List<bool> walls_MasterList_Bools = new List<bool>();

	[Header("Rewind")]
	public List<int> rewind_TierPrices;

	[Header("Sugar Rush")]
	public float sugarRush_AdditionalGrowthRate;

	public float sugarRush_AdditionalGrowthRate_Curr;

	public float sugarRush_AdditionalRoundTime;

	public float sugarRush_Duration;

	public float sugarRush_Duration_Curr;

	[Header("Radio")]
	public Radio radioInScene;

	public List<PickUppable> allSpawnedPickuppables = new List<PickUppable>();

	[Header("Nighttime")]
	public bool hasTimerElapsed_IsNighttime;

	[SerializeField]
	private GameObject sunLight;

	[SerializeField]
	private List<GameObject> nighttime_Lights;

	[SerializeField]
	private GameObject nighttime_BedObject;

	[SerializeField]
	private List<GameObject> objectsToHideAtNight;

	[Header("Nighttime Hole Hunting")]
	[SerializeField]
	private float nighttime_HoleMoveSpeed_Curr;

	[SerializeField]
	private float nighttime_HoleMoveSpeed_Max;

	[SerializeField]
	private float nighttime_HoleMoveSpeed_Accel;

	[SerializeField]
	private float nighttime_HoleGrowth_Curr;

	[SerializeField]
	private float nighttime_HoleGrowth_Max;

	[SerializeField]
	private float nighttime_HoleGrowth_Accel;

	[SerializeField]
	private GameObject postProc_FellInHole_gameObject;

	[Header("Skyboxes")]
	[SerializeField]
	private Material skyboxMat_Day;

	[SerializeField]
	private Material skyboxMat_Night;

	[SerializeField]
	private Material skyboxMat_BelladonnaEnding;

	[Header("Demo Specific")]
	public bool demo_HasBrokenTier2Wall;

	[Header("Pop Gun Bullets")]
	public List<GameObject> popgun_SpawnedBullets = new List<GameObject>();

	private const int popgun_SpawnedBullet_Limit = 12;

	[Header("JUICED")]
	public float juiced_Amount_Curr;

	public float juiced_Amount_Limit;

	public float juiced_DrainRate;

	public float juiced_GrowthMultiplier_Curr;

	public bool isInsideBellaDonnaTunnel;

	public bool playHardSurfaceFootsteps;

	public bool isLookingAtPC;

	[Header("Hatch Door Related")]
	public bool hatchDoorEnvironment_IsActive;

	[SerializeField]
	private GameObject hatchDoor_EnvironmentParent;

	[SerializeField]
	private List<GameObject> miscObjectsToHideInHatchEnvironment;

	[Header("Burned Office")]
	[SerializeField]
	private Material mat_Burned;

	[SerializeField]
	private List<Renderer> rendsToSwapToBurned;

	[SerializeField]
	private List<GameObject> officeItems_HideWhenBurned;

	[Header("Belladonna Buddy Ending")]
	public bool belladonnaBuddyEnding_IsActive;

	[SerializeField]
	private GameObject poisonWaterPlane;

	[SerializeField]
	private float poisonWater_RiseSpeed;

	[SerializeField]
	private float poisonWater_DrownTimer;

	private float poisonWater_DrownTimer_Curr;

	[SerializeField]
	private Material blackOutEyes_Material;

	[SerializeField]
	private List<Renderer> characterEyesToBlackOut;

	[SerializeField]
	private List<GameObject> characterCryingParticleEffects;

	[SerializeField]
	private List<EyesHandler> characterCrying_EyeHandlers;

	[SerializeField]
	private Animator starDoor_Anim;

	public Mesh purpleFlower_Mesh;

	private float poisonWater_SurvivalTimer;

	[Header("Gnome Ending")]
	[SerializeField]
	private List<GameObject> objectsToHideForGnomeEnding;

	public bool gnomeEnding_IsActive;

	[SerializeField]
	private GameObject gnomeEnding_Parent;

	public List<GnomeDuplicator> gnomeEnding_SpawnedGnomes = new List<GnomeDuplicator>();

	public List<GameObject> gnomeEnding_GnomePrefabs;

	[SerializeField]
	private GameObject gnomeEnding_TrappingWall;

	public const int gnomeEnding_MaxNumOfGnomes = 500;

	[SerializeField]
	private GameObject disk_Gnome;

	[SerializeField]
	private GameObject officeGnome;

	public bool isLoadingCreditsScreen;

	public int achievement_coinsPickedUpManuallyDespiteAutoPickUpEnabled;

	public bool achievement_coinsPickedUpAchivementUnlockedThisRound;

	public bool achievement_HasCheckedForBerriesGrownThisRound_Hundred;

	public bool achievement_HasCheckedForBerriesGrownThisRound_Thousand;

	public bool achievement_HasCheckedForBerriesGrownThisRound_HundoThousand;

	public bool achievement_HasCheckedForMilestonesThisRound_One;

	public bool achievement_HasCheckedForMilestonesThisRound_Ten;

	public bool achievement_HasCheckedForMilestonesThisRound_Hundred;

	public bool achievement_HasCheckedForMilestonesThisRound_FiveHundo;

	public bool achievement_HasCheckedForMilestonesThisRound_All;

	public GameObject smallBedForInfiniteDaytimeMod;

	[Header("Additional Ms Rainbow Moments")]
	[SerializeField]
	private List<GameObject> additionalMsRainbowMomentPoses;

	[SerializeField]
	private GameObject sittingOnWall_Wall;

	public bool audioduck_BlipsAndBloops;

	[SerializeField]
	private GameObject nighttimeOnly_StarDoorBlockingWall;

	public bool isStarDoorOpen;

	public Action OnBerryBuddyUpgraded_Action;

	private void Awake()
	{
		if (!Singleton)
		{
			Singleton = this;
			InitialSetup();
			ChangeGameState(GameState.PreRoundSetup);
		}
	}

	private void InitialSetup()
	{
		holeStartingPOS = yardAndHoleObject.transform.position;
	}

	private void Start()
	{
		RenderSettings.skybox = skyboxMat_Day;
		ceilingObject.SetActive(value: true);
		HideCameraBubble();
		holeMove_DynamicRadiusIndicator_StartingXZScale = holeMove_DynamicRadiusIndicator.transform.localScale.x;
		holeMove_DynamicRadiusIndicator_YPos = holeMove_DynamicRadiusIndicator.transform.position.y;
		StartCoroutine(WaitASec_ThenAllowSoftLockChecks());
		currentYardAndHoleScale = (desiredYardAndHoleScale = startingHoleScale);
		prefabBank.plantBed_SpawnedInScene.UpgradeToFlower();
		prefabBank.plantBed_SpawnedInScene.ChangeBerryProfile(prefabBank.berryProfiles[0]);
		SetupMilestoneObjectMasterBoolList();
		NighttimeLights_TurnOff();
		nighttime_BedObject.SetActive(value: false);
		DisableBigHoleLauncherTrigger();
		belladonnaBuddyEnding_IsActive = false;
		poisonWaterPlane.SetActive(value: false);
		HideAllAdditionalMsRainbowPoses();
		AudioManager.Singleton.ResetDuckedVolume();
		nighttimeOnly_StarDoorBlockingWall.SetActive(value: false);
		audioduck_BlipsAndBloops = false;
	}

	private IEnumerator WaitASec_ThenAllowSoftLockChecks()
	{
		canCheckForNoSeedOrPlantSoftLock = false;
		yield return new WaitForSeconds(1f);
		canCheckForNoSeedOrPlantSoftLock = true;
	}

	private void HandleSoftLockingByHavingNoPlantsOrSeeds()
	{
		if (PlayerStats.Singleton.seeds > 0 || !(backupSeed_SpawnedGameobject == null))
		{
			return;
		}
		bool flag = true;
		foreach (PlantBed allPlantBed in allPlantBeds)
		{
			if (allPlantBed.currentBerryTier > -1)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			backupSeed_SpawnedGameobject = UnityEngine.Object.Instantiate(prefabBank.seedPrefab, backupSeed_SpawnPoint.position, Quaternion.identity);
		}
	}

	private void Update()
	{
		HandleGameState();
		HandleBerryBlitz();
		HandleBigHolePowerUp();
		HandleBigHole_GrowingSizeLauncher();
		HandleHoleMoving();
		HandleTempHoleSizeJuice();
		HandleSugarRush();
		HandlePopGunBulletDespawning();
		HandleJUICED();
		HandleBelladonnaBuddyEnding();
		HandleGnomeEnding();
		if (canCheckForNoSeedOrPlantSoftLock)
		{
			HandleSoftLockingByHavingNoPlantsOrSeeds();
		}
		if (updatePlantBedSidingsNextFrame)
		{
			updatePlantBedSidingsNextFrame = false;
			UpdateAllPlantBedSidings();
		}
		_ = Application.isEditor;
		HandleTimePlayed();
	}

	private void FixedUpdate()
	{
		UpdateGlobalBerryGrowthRate();
		HandleLevelingUpHole();
		HandleHolePrestige();
		HandleScalingYardAndHole();
	}

	private void UpdateGlobalBerryGrowthRate()
	{
		if (goldRush_growthSpeedBoost_Curr > 0f)
		{
			globalBerryGrowthRate = sugarRush_AdditionalGrowthRate_Curr * (PlayerStats.Singleton.berryGrowthRate_Multiplier * juiced_GrowthMultiplier_Curr + goldRush_growthSpeedBoost_Curr);
			return;
		}
		float num = PlayerStats.Singleton.berryGrowthRate_Multiplier;
		float num2 = (float)spawnedBerryLimit * 0.5f;
		if ((float)spawnedBerries.Count > num2)
		{
			float num3 = ((float)Mathf.Clamp(spawnedBerries.Count, 0, spawnedBerryLimit) - num2) / num2;
			float num4 = 1f - num3;
			num *= num4;
		}
		globalBerryGrowthRate = sugarRush_AdditionalGrowthRate_Curr * (num * juiced_GrowthMultiplier_Curr + goldRush_growthSpeedBoost_Curr);
	}

	private void HandleGameState()
	{
		switch (gameState)
		{
		case GameState.Playing:
			HandleRoundTimer();
			break;
		case GameState.Intro:
		case GameState.Cutscene:
		case GameState.PreRoundSetup:
		case GameState.RoundOverShop:
			break;
		}
	}

	public void InShop_CloseShopAndStartNextRound()
	{
		HudManager.Singleton.ShowWakingUpPopupInShop();
		AnomalousMaterial_Manager.Singleton.AddRemainingUnspawnedOrbsInQueueToSpawnsOrbsForSaving();
		StoreThisRoundsPlaytimeIntoStats();
		SaveLoadManager.Singleton.SaveDataAndStartNextRound();
		AudioManager.Singleton.StopShopMusic();
	}

	public void ChangeGameState(GameState _newState)
	{
		gameState = _newState;
		switch (_newState)
		{
		case GameState.Intro:
			VcrIntroManager.Singleton.StartIntro();
			break;
		case GameState.Playing:
			OnRoundStart();
			break;
		case GameState.Cutscene:
			audioduck_BlipsAndBloops = true;
			break;
		case GameState.RoundOverShop:
			try
			{
				if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
				{
					InputManager.Singleton.WarpMouseToBottom();
					Cursor.visible = false;
				}
			}
			catch
			{
			}
			HudManager.Singleton.ShopMenu_Open();
			AudioManager.Singleton.PlayShopMusic();
			radioInScene.StopRadioMusic();
			postProc_FellInHole_gameObject.SetActive(value: false);
			VcrIntroManager.Singleton.SetVcrPostEffect(1f);
			ChangeCameraLayerToOnlyUIForShop();
			break;
		case GameState.PreRoundSetup:
			break;
		}
	}

	private void OnRoundStart()
	{
		tool_StarWand.SetActive(PlayerStats.Singleton.StarWand_Unlocked);
		tool_SledgeHammer.gameObject.SetActive(PlayerStats.Singleton.SledgeHammer_Unlocked);
		if (tool_SledgeHammer.gameObject.activeSelf)
		{
			tool_SledgeHammer.SetHammerMaterialFromTier();
		}
		tool_Chainsaw.gameObject.SetActive(PlayerStats.Singleton.blenderBot_Unlocked);
		if (tool_Chainsaw.activeSelf)
		{
			List<Material> hammerMaterialList = tool_SledgeHammer.GetHammerMaterialList();
			foreach (MeshRenderer tool_ChainsawTeethRend in tool_ChainsawTeethRends)
			{
				bool activeSelf = tool_ChainsawTeethRend.gameObject.activeSelf;
				tool_ChainsawTeethRend.gameObject.SetActive(value: true);
				Material[] materials = tool_ChainsawTeethRend.materials;
				materials[0] = hammerMaterialList[PlayerStats.Singleton.SledgeHammer_Tier];
				tool_ChainsawTeethRend.materials = materials;
				tool_ChainsawTeethRend.gameObject.SetActive(activeSelf);
			}
		}
		tool_StarKey.SetActive(PlayerStats.Singleton.starKey_Unlocked);
		tool_Trampoline.SetActive(PlayerStats.Singleton.trampoline_Unlocked);
		berryPickerInScene.gameObject.SetActive(PlayerStats.Singleton.berryPicker_IsUnlocked);
		AudioManager.Singleton.PlayAmbientTrack(0, 0f, _fadeIn: false);
		radioInScene.gameObject.SetActive(PlayerStats.Singleton.radio_IsUnlocked);
		if (radioInScene.gameObject.activeSelf)
		{
			radioInScene.OnRoundStart_CheckIfWeShouldPlayMusic();
		}
		TutorialManager.Singleton.OnRoundStart_TutorialCheck();
		AnomalousMaterial_Manager.Singleton.CalculateRollTarget();
		PuzzleManager.Singleton.UpdateActiveNarrativeObjectsFromPuzzlesSolved();
		playerOnlyHoleCollider_ForLevel0Hole.SetActive(PlayerStats.Singleton.holeGrowth_Level <= 0);
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_InfiniteHoleMove)
		{
			forceHide_HoleDynamicRadiusVisual = true;
		}
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_InfiniteDaytime)
		{
			shouldTickDownRoundTime = false;
			smallBedForInfiniteDaytimeMod.SetActive(value: true);
		}
		else
		{
			smallBedForInfiniteDaytimeMod.SetActive(value: false);
		}
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_NoWalls)
		{
			for (int i = 0; i < walls_MasterList.Count; i++)
			{
				walls_MasterList[i].gameObject.SetActive(value: false);
			}
		}
		UpdateSteamRichPresence();
		RecalculateNumberOfMilestonesRemaining();
		HolePrestiged_AchievementCheck();
		RoundStart_DecideWhichAdditionalMsRainbowPoseToShow();
		OnRoundStart_Action?.Invoke();
	}

	public static string ConvertToMinutesAndSeconds(float totalSeconds)
	{
		int num = Mathf.FloorToInt(totalSeconds / 60f);
		int num2 = Mathf.FloorToInt(totalSeconds % 60f);
		return $"{num:00}:{num2:00}";
	}

	public void EnterBuildMode(BuildableInfo _buildableInfo, bool _snapToGrid, BuildModeRotationMode _rotationMode, bool _cancelAfterPlacement, BuildableIdentity _buildableIdentity, int _moneyCost = 0)
	{
		buildModeState = PlayerBuildModeState.BuildMode;
		buildMode_PlacementPrefab = _buildableInfo.placementPrefab;
		buildMode_BuildablePrefab = _buildableInfo.prefabToSpawn;
		buildMode_YOffset = _buildableInfo.yOffset;
		buildMode_SnapToGrid = _snapToGrid;
		buildMode_RotationMode = _rotationMode;
		buildMode_CancelModeAfterPlacement = _cancelAfterPlacement;
		buildMode_BuildableIdentity = _buildableIdentity;
		HudManager.Singleton.ShowUiGroup_Playing();
		buildModeGridDisplay.SetActive(value: true);
		grassRenderers.transform.position = new Vector3(grassRenderers.transform.position.x, -50f, grassRenderers.transform.position.z);
		if (OnBuildModeEntered_Action != null)
		{
			OnBuildModeEntered_Action();
		}
	}

	public void ExitBuildMode()
	{
		buildModeGridDisplay.SetActive(value: false);
		grassRenderers.transform.position = new Vector3(grassRenderers.transform.position.x, 0f, grassRenderers.transform.position.z);
		buildModeState = PlayerBuildModeState.Default;
		buildMode_PlacementPrefab = null;
	}

	public void BuildCurrentBuildable(Vector3 _pos, Quaternion _rot, bool _isGridSnapped)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(buildMode_BuildablePrefab, _pos, _rot);
		if (buildMode_BuildableIdentity == BuildableIdentity.DirtPatch)
		{
			gameObject.GetComponent<PlantBed>();
		}
		HandleSpecialLogicOfBuildableOnBuilt(buildMode_BuildableIdentity);
		if (OnBuildablePlaced_Action != null)
		{
			OnBuildablePlaced_Action();
		}
		if (_isGridSnapped)
		{
			buildSpotsDict[GetGridDictFromPos(_pos)].OnBuiltOn(buildMode_BuildableIdentity, gameObject);
		}
	}

	private void HandleSpecialLogicOfBuildableOnBuilt(BuildableIdentity _buildableIdentity)
	{
		if (buildMode_BuildableIdentity == BuildableIdentity.DirtPatch)
		{
			PlayerStats.Singleton.dirtPatch_NumPlaced++;
			if (buildMode_CancelModeAfterPlacement && PlayerStats.Singleton.dirtPatch_NumOfPurchased - PlayerStats.Singleton.dirtPatch_NumPlaced <= 0)
			{
				ExitBuildMode();
			}
		}
		else if (buildMode_BuildableIdentity == BuildableIdentity.ConveyorBelt)
		{
			PlayerStats.Singleton.conveyorBelt_NumPlaced++;
			if (buildMode_CancelModeAfterPlacement)
			{
				PlayerStats.Singleton.CalculateNumberOfIndividualConveyorBeltsOwned();
				if (PlayerStats.Singleton.conveyorBelt_NumOfIndividualConveyorBeltsOwned - PlayerStats.Singleton.conveyorBelt_NumPlaced <= 0)
				{
					ExitBuildMode();
				}
			}
		}
		else if (buildMode_BuildableIdentity == BuildableIdentity.Trampoline)
		{
			PlayerStats.Singleton.trampolines_NumPlaced++;
			if (buildMode_CancelModeAfterPlacement && PlayerStats.Singleton.trampolines_NumOfPurchased - PlayerStats.Singleton.trampolines_NumPlaced <= 0)
			{
				ExitBuildMode();
			}
		}
		else if (buildMode_BuildableIdentity == BuildableIdentity.Blender)
		{
			PlayerStats.Singleton.blenders_NumPlaced++;
			if (buildMode_CancelModeAfterPlacement && PlayerStats.Singleton.blenders_NumOfPurchased - PlayerStats.Singleton.blenders_NumPlaced <= 0)
			{
				ExitBuildMode();
			}
		}
	}

	public List<CoinPrefabValueSet> GetCoinPrefabsFromAmount(int _totalAmount)
	{
		if (_totalAmount == 0)
		{
			return null;
		}
		List<CoinPrefabValueSet> list = new List<CoinPrefabValueSet>();
		int num = _totalAmount;
		for (int num2 = prefabBank.coinValueAmounts.Count - 1; num2 >= 0; num2--)
		{
			int num3 = num / prefabBank.coinValueAmounts[num2];
			num %= prefabBank.coinValueAmounts[num2];
			for (int i = 0; i < num3; i++)
			{
				list.Add(new CoinPrefabValueSet(prefabBank.coinPrefabs[num2], prefabBank.coinValueAmounts[num2]));
			}
		}
		return list;
	}

	private void HandleBerryBlitz()
	{
		if (goldRushIsActive)
		{
			if (goldRush_Time_Current > 0f)
			{
				goldRush_Time_Current -= Time.deltaTime;
			}
			else
			{
				DisableBerryBlitz();
			}
		}
		else
		{
			if (gameState != GameState.Playing || hasTimerElapsed_IsNighttime)
			{
				return;
			}
			if (goldRush_Cooldown_Curr > 0f)
			{
				if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FastAbilityCooldowns)
				{
					goldRush_Cooldown_Curr -= Time.deltaTime * 3f;
				}
				else
				{
					goldRush_Cooldown_Curr -= Time.deltaTime;
				}
			}
			canUseGoldRush = goldRush_Cooldown_Curr <= 0f;
		}
	}

	public void ActivateBerryBlitz()
	{
		goldRushIsActive = true;
		goldRush_Cooldown_Curr = PlayerStats.Singleton.goldRush_Cooldown_Max;
		goldRush_Time_Current = PlayerStats.Singleton.goldRush_Duration_Max;
		goldRush_growthSpeedBoost_Curr = PlayerStats.Singleton.goldRush_BonusGrowthRate;
		PlayerStats.Singleton.UsedBerryBlitz_SetCooldownToMax();
	}

	public void DisableBerryBlitz()
	{
		goldRushIsActive = false;
		goldRush_growthSpeedBoost_Curr = 0f;
	}

	private void HandleBigHolePowerUp()
	{
		if (bigHoleIsActive)
		{
			if (bigHole_Time_Current > 0f)
			{
				bigHole_Time_Current -= Time.deltaTime;
			}
			else
			{
				DisableBigHolePowerup();
			}
		}
		else
		{
			if (gameState != GameState.Playing || hasTimerElapsed_IsNighttime)
			{
				return;
			}
			if (bigHole_Cooldown_Curr > 0f)
			{
				if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FastAbilityCooldowns)
				{
					bigHole_Cooldown_Curr -= Time.deltaTime * 3f;
				}
				else
				{
					bigHole_Cooldown_Curr -= Time.deltaTime;
				}
			}
			canUseBigHole = bigHole_Cooldown_Curr <= 0f;
		}
	}

	public void ActivateBigHolePowerup()
	{
		EnableBigHoleLauncherTrigger();
		bigHole_BerryLauncherTrigger.transform.localScale = Vector3.zero;
		bigHoleIsActive = true;
		bigHole_Cooldown_Curr = PlayerStats.Singleton.bigHole_Cooldown_Max;
		bigHole_Time_Current = PlayerStats.Singleton.bigHole_Duration_Max;
		bigHole_SizeBoost_Curr = PlayerStats.Singleton.bigHole_Size;
		PlayerStats.Singleton.UsedBigHole_SetCooldownToMax();
		StartCoroutine(WaitThen_BigHoleLauncher_Start(1f));
	}

	private IEnumerator WaitThen_BigHoleLauncher_Start(float _delay)
	{
		yield return new WaitForSeconds(_delay);
		bigHole_BerryLauncher_IsSizeGrowing = true;
	}

	private void HandleBigHole_GrowingSizeLauncher()
	{
		if (bigHole_BerryLauncher_IsSizeGrowing)
		{
			bigHole_BerryLauncherTrigger.transform.position = new Vector3(yardAndHoleObject.transform.position.x, 1.2f, yardAndHoleObject.transform.position.z);
			if (bigHole_BerryLauncherTrigger.transform.localScale.x < 240f)
			{
				bigHole_BerryLauncherTrigger.transform.localScale += Vector3.one * (bigHole_BerryLauncher_SizeGrowthSpeed * Time.deltaTime);
				return;
			}
			bigHole_BerryLauncherTrigger.transform.localScale = Vector3.zero;
			bigHole_BerryLauncher_IsSizeGrowing = false;
			DisableBigHoleLauncherTrigger();
		}
	}

	private void EnableBigHoleLauncherTrigger()
	{
		bigHole_BerryLauncherTrigger.gameObject.SetActive(value: true);
	}

	private void DisableBigHoleLauncherTrigger()
	{
		bigHole_BerryLauncherTrigger.gameObject.SetActive(value: false);
	}

	public void DisableBigHolePowerup()
	{
		bigHoleIsActive = false;
		bigHole_SizeBoost_Curr = 0f;
	}

	public void ToggleHaltedBerryProduction_ButtonClick()
	{
		HudManager.Singleton.selectedPlantBed.ToggleBerryHaltProduction();
		HudManager.Singleton.ShowUIGroup_SubGroup_PlantBedInfo();
	}

	public void DisableAllBerryProduction()
	{
		foreach (PlantBed allPlantBed in allPlantBeds)
		{
			allPlantBed.HaltBerryProduction();
		}
	}

	public void EnableAllBerryProduction()
	{
		foreach (PlantBed allPlantBed in allPlantBeds)
		{
			allPlantBed.EnableBerryProduction();
		}
	}

	public string GetGridDictFromPos(Vector3 _pos)
	{
		return Mathf.RoundToInt(_pos.x * 10f) + "," + Mathf.RoundToInt(_pos.z * 10f);
	}

	public void SpawnNewBonusXPTile()
	{
		if (availableBuildSpotsToBonusTileify.Count <= 0)
		{
			Debug.Log("No tiles available to bonus tile-ify, ignoring.");
			return;
		}
		int index = UnityEngine.Random.Range(0, availableBuildSpotsToBonusTileify.Count);
		availableBuildSpotsToBonusTileify[index].MakeBonusTile();
	}

	public void OnGoldRushCooldownLevelUp()
	{
	}

	public void OnGoldRushDurationLevelUp()
	{
	}

	public void AddToSpawnedBerryList(GameObject _berry)
	{
		spawnedBerries.Add(_berry);
		CheckIfOverBerryLimit();
	}

	public void AddToSpawnedCoinList(GameObject _coin)
	{
		spawnedCoins.Add(_coin);
		CheckIfOverCoinLimit();
	}

	public void RemoveFromSpawnedBerryList(GameObject _berry)
	{
		spawnedBerries.Remove(_berry);
	}

	public void RemoveFromSpawnedCoinList(GameObject _coin)
	{
		spawnedCoins.Remove(_coin);
	}

	private void CheckIfOverBerryLimit()
	{
		if (!goldRushIsActive && spawnedBerries.Count > spawnedBerryLimit)
		{
			GameObject obj = spawnedBerries[0];
			spawnedBerries.RemoveAt(0);
			UnityEngine.Object.Destroy(obj);
		}
	}

	private void CheckIfOverCoinLimit()
	{
		if (spawnedCoins.Count > spawnedCoinLimit)
		{
			GameObject obj = spawnedCoins[0];
			spawnedCoins.RemoveAt(0);
			UnityEngine.Object.Destroy(obj);
		}
	}

	public void SetGridTileToAllowBuildingOn(Vector3 _posOfTile)
	{
		try
		{
			BuildSpot buildSpot = buildSpotsDict[GetGridDictFromPos(_posOfTile)];
			buildSpot.isBuiltOn = false;
			buildSpot.buildableIdentity = BuildableIdentity.None;
		}
		catch
		{
		}
	}

	public void OnBuildableDestroyed_RunAdditionalLogic(Buildable _buildable)
	{
		if (_buildable.buildableIdentity == BuildableIdentity.DirtPatch)
		{
			PlayerStats.Singleton.dirtPatch_NumPlaced--;
		}
		else if (_buildable.buildableIdentity == BuildableIdentity.ConveyorBelt)
		{
			PlayerStats.Singleton.conveyorBelt_NumPlaced--;
		}
		else if (_buildable.buildableIdentity == BuildableIdentity.Trampoline)
		{
			PlayerStats.Singleton.trampolines_NumPlaced--;
		}
	}

	public void ToggleHaltAllPlantBedProduction(bool _hideHalfGrownBerries = false)
	{
		if (allPlantBedsAreHalted)
		{
			foreach (PlantBed allPlantBed in allPlantBeds)
			{
				allPlantBed.EnableBerryProduction();
			}
			allPlantBedsAreHalted = false;
			return;
		}
		foreach (PlantBed allPlantBed2 in allPlantBeds)
		{
			allPlantBed2.HaltBerryProduction();
			if (_hideHalfGrownBerries)
			{
				allPlantBed2.HideAllHalfGrownBerries();
			}
		}
		allPlantBedsAreHalted = true;
	}

	public void SwapAllPlantGrowerFlowerVisualsWithBelladonnaPurple()
	{
		foreach (PlantBed allPlantBed in allPlantBeds)
		{
			allPlantBed.SwapAllFlowerVisualsToBelladonnaFlowers();
		}
	}

	public string FormatMoney(long amount)
	{
		if (amount >= 1000000000000L)
		{
			return ((float)amount / 1E+12f).ToString("0.#") + "T";
		}
		if (amount >= 1000000000)
		{
			return ((float)amount / 1E+09f).ToString("0.#") + "B";
		}
		if (amount >= 1000000)
		{
			return ((float)amount / 1000000f).ToString("0.#") + "M";
		}
		if (amount >= 1000)
		{
			return ((float)amount / 1000f).ToString("0.#") + "K";
		}
		return amount.ToString("N0");
	}

	private void UpdateAllPlantBedSidings()
	{
		foreach (PlantBed allPlantBed in allPlantBeds)
		{
			allPlantBed.UpdateDirtPatchSidingVisuals();
		}
	}

	private void HandleLevelingUpHole()
	{
		if (gameState != GameState.Playing)
		{
			return;
		}
		_ = startingHoleScale;
		float p = 0.95f;
		if (hasTimerElapsed_IsNighttime)
		{
			float t = Mathf.Pow(Mathf.Clamp((float)holePrestigeValues_HoleSizePerRank[PlayerStats.Singleton.holeGrowth_Level] + nighttime_HoleGrowth_Curr, 0f, 150f) / 100f * 1.5f, p);
			desiredYardAndHoleScale = Mathf.Lerp(startingHoleScale, 3.5f, t);
			if (nighttime_HoleGrowth_Curr < nighttime_HoleGrowth_Max)
			{
				nighttime_HoleGrowth_Curr += Time.deltaTime * nighttime_HoleGrowth_Accel;
			}
			else
			{
				nighttime_HoleGrowth_Curr = nighttime_HoleGrowth_Max;
			}
		}
		else
		{
			float t2 = Mathf.Pow(Mathf.Clamp((float)holePrestigeValues_HoleSizePerRank[PlayerStats.Singleton.holeGrowth_Level] + bigHole_SizeBoost_Curr, 0f, 100f) / 100f, p);
			desiredYardAndHoleScale = Mathf.Lerp(startingHoleScale, 3.5f, t2);
		}
	}

	private void HandleHolePrestige()
	{
		if (gameState != GameState.Playing)
		{
			return;
		}
		if (PlayerStats.Singleton.holeGrowth_Level < holePrestigeValues_HoleSizePerRank.Count - 1)
		{
			if (!hasHolePrestigedThisRound)
			{
				if (holePrestigeJuice_Curr < holePrestigeValues_RequiredJuicePerRank[PlayerStats.Singleton.holeGrowth_Level])
				{
					float num = (float)holePrestigeJuice_Curr / (float)holePrestigeValues_RequiredJuicePerRank[PlayerStats.Singleton.holeGrowth_Level];
					holePrestigeCurrPercent = num * 100f;
					HudManager.Singleton.UpdateHoleGrowthPrestigeUI(num);
					return;
				}
				int holeGrowth_Level = Mathf.Clamp(PlayerStats.Singleton.holeGrowth_Level + 1, 0, holePrestigeValues_RequiredJuicePerRank.Count - 1);
				PlayerStats.Singleton.holeGrowth_Level = holeGrowth_Level;
				DisableFirstRoundPlayerOnlyHoleCollider();
				HudManager.Singleton.ShowBigTextPopUp(0);
				AudioManager.Singleton.PlaySFX_HoleGrowthVictoryRiff();
				holePrestigeJuice_Curr = 0;
				HolePrestiged_AchievementCheck();
			}
			else
			{
				HudManager.Singleton.UpdateHoleGrowthPrestigeUI(1f);
				holePrestigeCurrPercent = 100f;
			}
		}
		else
		{
			HudManager.Singleton.UpdateHoleGrowthPrestigeUI(1f);
		}
	}

	private void HandleTempHoleSizeJuice()
	{
		if (tempHoleSizeJuice_Curr > 0f)
		{
			tempHoleSizeJuice_Curr -= Time.deltaTime * tempHoleSizeJuice_DecayRate;
		}
		else
		{
			tempHoleSizeJuice_Curr = 0f;
		}
	}

	public void AddTempHoleSizeJuice()
	{
		tempHoleSizeJuice_Curr += tempHoleSizeJuice_PerDeposit;
		tempHoleSizeJuice_Curr = Mathf.Clamp(tempHoleSizeJuice_Curr, 0f, tempHoleSizeJuice_MaxGainAboveLevel);
	}

	private float GetLogarithmicScaleFromHoleJuice(float _holeJuiceCurr)
	{
		_holeJuiceCurr = MathF.Min(_holeJuiceCurr, holeJuice_Max);
		float t = MathF.Log(_holeJuiceCurr + 1f) / MathF.Log(holeJuice_Max + 1f);
		return Mathf.Lerp(startingHoleScale, 3.5f, t);
	}

	private void IncreaseHoleLevel(int _setTo = -1)
	{
		if (_setTo == -1)
		{
			if (holeLevelRequirements.Length > holeLevel + 1)
			{
				holeLevel++;
			}
		}
		else
		{
			holeLevel = _setTo;
			if (holeLevel + 1 >= holeLevelRequirements.Length)
			{
				holeLevel = holeLevelRequirements.Length - 1;
			}
		}
		holeGrowthPoints_Curr = 0f;
	}

	private void HandleScalingYardAndHole()
	{
		currentYardAndHoleScale = Mathf.Lerp(currentYardAndHoleScale, desiredYardAndHoleScale, holeScaleLerpSpeed * Time.fixedDeltaTime);
		yardAndHoleObject.transform.localScale = new Vector3(currentYardAndHoleScale, 1f, currentYardAndHoleScale);
	}

	public void AddHoleGrowthPoints(float _amount)
	{
		holeGrowthPoints_Curr += _amount;
	}

	public void RemoveHoleGrowthPoints(float _amount)
	{
		holeGrowthPoints_Curr -= _amount;
	}

	public GameObject GetCultistPrefabFromBerryTier(int _berryTier)
	{
		return _berryTier switch
		{
			0 => prefabBank.cultistPrefab_BlueBerry, 
			1 => prefabBank.cultistPrefab_Raspberry, 
			2 => prefabBank.cultistPrefab_Strawberry, 
			3 => prefabBank.cultistPrefab_Kiwi, 
			4 => prefabBank.cultistPrefab_Plum, 
			5 => prefabBank.cultistPrefab_Apple, 
			6 => prefabBank.cultistPrefab_Pear, 
			7 => prefabBank.cultistPrefab_Peach, 
			8 => prefabBank.cultistPrefab_Banana, 
			9 => prefabBank.cultistPrefab_Pineapple, 
			10 => prefabBank.cultistPrefab_Watermelon, 
			11 => prefabBank.cultistPrefab_Pumpkin, 
			12 => prefabBank.cultistPrefab_Belladonna, 
			_ => null, 
		};
	}

	public Transform GetCultistsSpawnPoint()
	{
		return cultistsSpawnPoint.transform;
	}

	public void HandleHoleMoving()
	{
		if (gameState != GameState.Playing)
		{
			return;
		}
		if (hasTimerElapsed_IsNighttime)
		{
			holeDestination_VisualIndicator.SetActive(value: false);
			playerMovingHole = false;
			desiredHoleDestination = new Vector3(playerObject.transform.position.x, holeStartingPOS.y, playerObject.transform.position.z);
			yardAndHoleObject.transform.position = Vector3.MoveTowards(yardAndHoleObject.transform.position, desiredHoleDestination, nighttime_HoleMoveSpeed_Curr * Time.deltaTime);
			if (nighttime_HoleMoveSpeed_Curr < nighttime_HoleMoveSpeed_Max)
			{
				nighttime_HoleMoveSpeed_Curr += Time.deltaTime * nighttime_HoleMoveSpeed_Accel;
			}
			else
			{
				nighttime_HoleMoveSpeed_Curr = nighttime_HoleMoveSpeed_Max;
			}
			return;
		}
		if (playerMovingHole)
		{
			holeDestination_VisualIndicator.SetActive(value: true);
			holeDestination_VisualIndicator.transform.position = desiredHoleDestination;
		}
		else
		{
			holeDestination_VisualIndicator.SetActive(value: false);
		}
		if (playerMovingHole && holeMoveJuice_Curr > 0f)
		{
			if (desiredHoleDestination.y != holeStartingPOS.y)
			{
				desiredHoleDestination.y = holeStartingPOS.y;
			}
			yardAndHoleObject.transform.position = Vector3.MoveTowards(yardAndHoleObject.transform.position, desiredHoleDestination, PlayerStats.Singleton.holeMoveSpeed_Curr * Time.deltaTime);
			if (yardAndHoleObject.transform.position != desiredHoleDestination)
			{
				if (!MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_InfiniteHoleMove)
				{
					holeMoveJuice_Curr -= Time.deltaTime * holeMoveJuice_UseRate;
				}
			}
			else
			{
				holeDestination_VisualIndicator.SetActive(value: false);
				playerMovingHole = false;
			}
		}
		if (PlayerStats.Singleton.holeMove_IsUnlocked)
		{
			if (holeMoveJuice_Curr > 0f && !forceHide_HoleDynamicRadiusVisual)
			{
				holeMove_DynamicRadiusIndicator.SetActive(value: true);
				holeMove_DynamicRadiusIndicator.transform.position = new Vector3(yardAndHoleObject.transform.position.x, holeMove_DynamicRadiusIndicator_YPos, yardAndHoleObject.transform.position.z);
				float num = holeMove_DynamicRadiusIndicator_StartingXZScale / startingHoleScale;
				float num2 = GetRangeScale(holeMoveJuice_Curr, PlayerStats.Singleton.holeMoveSpeed_Curr, 0.2f);
				holeMove_DynamicRadiusIndicator.transform.localScale = new Vector3(num2 + num * currentYardAndHoleScale, holeMove_DynamicRadiusIndicator.transform.localScale.y, num2 + num * currentYardAndHoleScale);
			}
			else
			{
				holeMove_DynamicRadiusIndicator.SetActive(value: false);
			}
		}
		else
		{
			holeMove_DynamicRadiusIndicator.SetActive(value: false);
		}
		static float GetRangeScale(float _movementEnergy, float _moveSpeed, float _scalePerUnitDistance)
		{
			return _movementEnergy * PlayerStats.Singleton.holeMoveSpeed_Curr * _scalePerUnitDistance;
		}
	}

	public void SetNewHoleDestination(Vector3 _newDest)
	{
		Vector3 vector = new Vector3(_newDest.x, holeStartingPOS.y, _newDest.z);
		desiredHoleDestination = vector;
	}

	public void AddHoleMoveJuice(float _amount)
	{
		holeMoveJuice_Curr = Mathf.Clamp(holeMoveJuice_Curr + _amount, 0f, PlayerStats.Singleton.holeMoveJuiceCapacity_Curr);
	}

	public GameObject GetYardObject()
	{
		return yardAndHoleObject;
	}

	public Vector3 GetStartingHolePosition()
	{
		return holeStartingPOS;
	}

	public static int GetSafeIntFromLong(long value)
	{
		if (value > int.MaxValue)
		{
			return int.MaxValue;
		}
		if (value < int.MinValue)
		{
			return int.MinValue;
		}
		return (int)value;
	}

	public void InitializeValuesForNewPlaythroughRoundStart()
	{
		ResetRoundTimer();
		ResetRoundStartValues();
		PlayerStats.Singleton.wasPreviousVoidBoxDugUp = true;
		SetNGPlusModifiers_FirstRoundOnly();
	}

	public void ResetRoundStartValues()
	{
		holeMoveJuice_Curr = PlayerStats.Singleton.holeMoveJuiceCapacity_Curr;
		if (PlayerStats.Singleton.starOrbGen_IsUnlocked)
		{
			starOrbGenerator.gameObject.SetActive(value: true);
			starOrbGenerator.CalculateOrbSpawnTimesThisRound(PlayerStats.Singleton.starOrbGen_SpawnsPerRound);
		}
		else
		{
			starOrbGenerator.gameObject.SetActive(value: false);
		}
		PlayerStats.Singleton.RoundStarted_TickAbilityCooldownsByOne();
		for (int i = 0; i < milestoneObjects_MasterList_Bools.Count; i++)
		{
			try
			{
				if (!milestoneObjects_MasterList_Bools[i])
				{
					milestoneObjects_MasterList[i].gameObject.SetActive(value: false);
				}
			}
			catch
			{
				Debug.Log("Failed to find associated Milestone object. THIS SHOULDN'T HAPPEN. Ignoring!");
			}
		}
		for (int j = 0; j < walls_MasterList_Bools.Count; j++)
		{
			try
			{
				if (!walls_MasterList_Bools[j])
				{
					walls_MasterList[j].gameObject.SetActive(value: false);
				}
			}
			catch
			{
				Debug.Log("Failed to find associated Wall object. THIS SHOULDN'T HAPPEN. Ignoring!");
			}
		}
		foreach (MilestoneGrouper allMilestoneGrouper in allMilestoneGroupers)
		{
			allMilestoneGrouper.ActivateGroupIfMissingMilestone();
		}
		RecalculateNumberOfGnomesLeft();
	}

	public void ResetRoundTimer()
	{
		roundTimer_Curr = PlayerStats.Singleton.roundTimerLength;
	}

	public void HandleRoundTimer()
	{
		if (gameState != GameState.Playing)
		{
			return;
		}
		if (roundTimer_Curr > 0f)
		{
			if (shouldTickDownRoundTime)
			{
				roundTimer_Curr -= Time.deltaTime;
			}
		}
		else if (!hasTimerElapsed_IsNighttime)
		{
			hasTimerElapsed_IsNighttime = true;
			FreezeAllPickUppablesForNighttime();
			SwitchToNightTime();
		}
		if (!hasPlayedLowTimeWarningChimeThisRound && roundTimer_Curr <= 10f)
		{
			AudioManager.Singleton.PlaySFX_TimeAlmostUpWarning();
			hasPlayedLowTimeWarningChimeThisRound = true;
		}
	}

	public Vector3 GetStarOrbSpawnPosition()
	{
		return yardAndHoleObject.transform.position - Vector3.up * 0f;
	}

	public void ForceEndRound(bool _fromBed)
	{
		if (_fromBed)
		{
			PlayerStats.Singleton.IncreaseMoney_Banked(PlayerStats.Singleton.money_Held);
		}
		else
		{
			PlayerStats.Singleton.fellInHoleThisRound = true;
			if (PlayerStats.Singleton.money_Held > 1)
			{
				moneyDroppedInHoleThisRound = Mathf.RoundToInt((float)PlayerStats.Singleton.money_Held * 0.5f);
				PlayerStats.Singleton.IncreaseMoney_Banked(moneyDroppedInHoleThisRound);
				PlayerStats.Singleton.totalMoney_Dropped += moneyDroppedInHoleThisRound;
				HudManager.Singleton.ShowDroppedMoneyEffects(moneyDroppedInHoleThisRound);
			}
		}
		PlayerStats.Singleton.money_Held = 0;
		ChangeGameState(GameState.RoundOverShop);
	}

	public void SetupMilestoneObjectMasterBoolList()
	{
		milestoneObjects_MasterList_Bools = new List<bool>();
		foreach (PickUppable milestoneObjects_Master in milestoneObjects_MasterList)
		{
			_ = milestoneObjects_Master;
			milestoneObjects_MasterList_Bools.Add(item: true);
		}
		walls_MasterList_Bools = new List<bool>();
		foreach (BreakableWall walls_Master in walls_MasterList)
		{
			_ = walls_Master;
			walls_MasterList_Bools.Add(item: true);
		}
	}

	public void ShowCameraBubble()
	{
		cameraBubbleVisual.SetActive(value: true);
	}

	public void HideCameraBubble()
	{
		cameraBubbleVisual.SetActive(value: false);
	}

	public void SpawnStarOrbsFromHoleDeposit(PickUppable _pickUp)
	{
		if (_pickUp.GetNumOfOrbsToSpawnAtDeposited() != StarOrbsToSpawnWhenDeposited.None)
		{
			AnomalousMaterial_Manager.Singleton.SpawnAnomalousMaterial(_pickUp.GetNumOfOrbsToSpawnAtDeposited(), _increaseRollChance: false, Singleton.GetStarOrbSpawnPosition(), 0.25f, 2f, _fromMilestone: true);
		}
		if (_pickUp.additionalOneStarOrbsToSpawnWhenDeposited > 0)
		{
			for (int i = 0; i < _pickUp.additionalOneStarOrbsToSpawnWhenDeposited; i++)
			{
				AnomalousMaterial_Manager.Singleton.SpawnAnomalousMaterial(StarOrbsToSpawnWhenDeposited.One, _increaseRollChance: false, Singleton.GetStarOrbSpawnPosition(), 0.25f, 2f, _fromMilestone: true);
			}
		}
		if (!_pickUp.isFunPhysicsFakeMilestone)
		{
			try
			{
				SetMilestoneFlagToFalse(_pickUp);
			}
			catch
			{
				Debug.Log("FAILED to find this milestone in the master list, Check to make sure this milestone is included in the master list");
			}
		}
	}

	public void SetMilestoneFlagToFalse(PickUppable _pickUp)
	{
		int index = milestoneObjects_MasterList.IndexOf(_pickUp);
		milestoneObjects_MasterList_Bools[index] = false;
		milestoneObjects_MasterList_Bools[778] = false;
		RecalculateNumberOfMilestonesRemaining();
	}

	public void ActivateRewind()
	{
		ResetAbilityCooldowns();
		PlayerStats.Singleton.rewind_TimesUsed++;
		PlayerStats.Singleton.money = 0;
		PlayerStats.Singleton.berryGrowthRate_Multiplier = 1f;
		PlayerStats.Singleton.berryCoinValue_Multiplier = 1f;
		PlayerStats.Singleton.goldenBerryChance_Curr = 2f;
		PlayerStats.Singleton.goldenBerry_ValueMultiplier_Curr = 5f;
		PlayerStats.Singleton.goldRush_Unlocked = false;
		PlayerStats.Singleton.goldRush_Duration_Max = 5f;
		PlayerStats.Singleton.goldRush_Cooldown_Max = 600f;
		PlayerStats.Singleton.goldRush_BonusGrowthRate = 20f;
		PlayerStats.Singleton.bigHole_Unlocked = false;
		PlayerStats.Singleton.bigHole_Duration_Max = 8f;
		PlayerStats.Singleton.bigHole_Cooldown_Max = 600f;
		PlayerStats.Singleton.bigHole_Size = 25f;
		PlayerStats.Singleton.holeGrowth_Level = 0;
		PlayerStats.Singleton.vacuum_Unlocked = false;
		PlayerStats.Singleton.vacuumCapacity = 6;
		PlayerStats.Singleton.bushUpgrade_Unlocked = false;
		PlayerStats.Singleton.treeUpgrade_Unlocked = false;
		PlayerStats.Singleton.conveyorBelt_Unlocked = false;
		PlayerStats.Singleton.autoCoinPickup_Unlocked = false;
		PlayerStats.Singleton.autoCoinPickUp_RadiusLevel = 0;
		PlayerStats.Singleton.autoCoinPickUp_Radius_Current = 4.5f;
		PlayerStats.Singleton.holeMove_IsUnlocked = false;
		PlayerStats.Singleton.holeMoveJuiceCapacity_Curr = 25;
		PlayerStats.Singleton.holeMoveSpeed_Curr = 0.8f;
		PlayerStats.Singleton.blenderBot_Unlocked = false;
		PlayerStats.Singleton.roundTimerLength = 60f;
		PlayerStats.Singleton.starOrbGen_IsUnlocked = false;
		PlayerStats.Singleton.starOrbGen_SpawnsPerRound = 1;
		PlayerStats.Singleton.bubbleJetpack_Unlocked = false;
		PlayerStats.Singleton.pinata_Unlocked = false;
		PlayerStats.Singleton.pinata_ZoneSpawnTier = 0;
		PlayerStats.Singleton.autoPopStarOrbs_Unlocked = false;
		for (int i = 0; i < PlayerStats.Singleton.starOrbTypes_SpawnedButNotDeposited.Count; i++)
		{
			PlayerStats.Singleton.starOrbTypes_SpawnedButNotDeposited[i] = 0;
		}
		for (int j = 0; j < milestoneObjects_MasterList_Bools.Count; j++)
		{
			milestoneObjects_MasterList_Bools[j] = true;
		}
		for (int k = 0; k < walls_MasterList_Bools.Count; k++)
		{
			walls_MasterList_Bools[k] = true;
		}
		for (int l = 0; l < UpgradeTreeManager.Singleton.allUpgradeTreeButtons.Count; l++)
		{
			if (!UpgradeTreeManager.Singleton.allUpgradeTreeButtons[l].DISABLED_DO_NOT_INCLUDE_IN_TREE && !UpgradeTreeManager.Singleton.allUpgradeTreeButtons[l].DO_NOT_RESET_WITH_REWIND)
			{
				UpgradeTreeManager.Singleton.allUpgradeTreeButtons[l].isUnlocked = false;
			}
		}
		if (!AchievementHelper.IsAchievementUnlocked("ACH_Rewind"))
		{
			AchievementHelper.UnlockAchievement("ACH_Rewind");
		}
		SetNGPlusModifiers_FirstRoundOnly();
		InShop_CloseShopAndStartNextRound();
		radioInScene.StopRadioMusic();
	}

	public void ActivateSugarRush()
	{
		sugarRush_Duration_Curr += sugarRush_Duration;
		roundTimer_Curr += sugarRush_AdditionalRoundTime;
		HudManager.Singleton.ShowBigTextPopUp(1);
	}

	private void HandleSugarRush()
	{
		if (sugarRush_Duration_Curr > 0f)
		{
			sugarRush_Duration_Curr -= Time.deltaTime;
			sugarRush_AdditionalGrowthRate_Curr = sugarRush_AdditionalGrowthRate;
		}
		else
		{
			sugarRush_AdditionalGrowthRate_Curr = 1f;
		}
	}

	public void FreezeAllPickUppablesForNighttime()
	{
		foreach (PickUppable allSpawnedPickuppable in allSpawnedPickuppables)
		{
			if (!allSpawnedPickuppable.doNotFreezeAtNight)
			{
				allSpawnedPickuppable.MakeKinematic();
				allSpawnedPickuppable.DisableColliders_Local();
			}
		}
	}

	public void HideAllCoins()
	{
		try
		{
			foreach (GameObject spawnedCoin in spawnedCoins)
			{
				if ((bool)spawnedCoin)
				{
					spawnedCoin.SetActive(value: false);
				}
			}
		}
		catch
		{
		}
	}

	public void SwitchToNightTime()
	{
		RenderSettings.skybox = skyboxMat_Night;
		AudioManager.Singleton.StopAmbientMusic();
		AudioManager.Singleton.PlayAmbientTrack(5, 0.25f, _fadeIn: true);
		AudioManager.Singleton.PlayNightTimeHeavyLeverSFX();
		RenderSettings.ambientLight = ambientLightColor_Dark;
		RenderSettings.fog = true;
		Player.Singleton.Flashlight_TurnOn();
		sunLight.SetActive(value: false);
		NighttimeLights_TurnOn();
		nighttime_HoleMoveSpeed_Curr = 0f;
		nighttime_HoleGrowth_Curr = 0f;
		nighttime_BedObject.SetActive(value: true);
		HideNightimeOnlyObjects();
		holeMove_DynamicRadiusIndicator.SetActive(value: false);
		OnNightTime_Action?.Invoke();
	}

	public void PiggyEndingCutscene_SwitchToNightVisuals()
	{
		RenderSettings.skybox = skyboxMat_Night;
		AudioManager.Singleton.StopAmbientMusic();
		sunLight.SetActive(value: false);
		NighttimeLights_TurnOn();
		RenderSettings.ambientLight = ambientLightColor_Dark;
		RenderSettings.fog = true;
	}

	public void SwitchToHatchDoorEnvironment()
	{
		AudioManager.Singleton.PlaySFX_MouseClick();
		if (!hatchDoorEnvironment_IsActive)
		{
			HideAllAdditionalMsRainbowPoses();
			HideAllCoins();
			HideAllPickUppables();
			HideAllBreakableWalls();
			HideMiscHatchSceneObjects();
			hatchDoorEnvironment_IsActive = true;
			hardDisableBubble = true;
			playHardSurfaceFootsteps = true;
			TutorialManager.Singleton.HideAllTutorialGroups();
			RenderSettings.skybox = skyboxMat_Night;
			AudioManager.Singleton.StopAmbientMusic();
			AudioManager.Singleton.PlayNightTimeHeavyLeverSFX();
			RenderSettings.ambientLight = ambientLightColor_Dark;
			RenderSettings.fog = false;
			Player.Singleton.Flashlight_TurnOn();
			sunLight.SetActive(value: false);
			NighttimeLights_TurnOn();
			nighttime_HoleMoveSpeed_Curr = 0f;
			nighttime_HoleGrowth_Curr = 0f;
			HideNightimeOnlyObjects();
			hatchDoor_EnvironmentParent.SetActive(value: true);
			yardAndHoleObject.SetActive(value: false);
			SwapToBurnedOfficeMaterials();
			holeMove_DynamicRadiusIndicator.SetActive(value: false);
			forceHide_HoleDynamicRadiusVisual = true;
			shouldTickDownRoundTime = false;
		}
	}

	public void HideMiscHatchSceneObjects()
	{
		foreach (GameObject item in miscObjectsToHideInHatchEnvironment)
		{
			if ((bool)item)
			{
				item.SetActive(value: false);
			}
		}
	}

	public void SwapToBurnedOfficeMaterials()
	{
		foreach (Renderer item in rendsToSwapToBurned)
		{
			Material[] materials = item.materials;
			for (int i = 0; i < materials.Length; i++)
			{
				materials[i] = mat_Burned;
			}
			item.materials = materials;
		}
		foreach (GameObject item2 in officeItems_HideWhenBurned)
		{
			item2.SetActive(value: false);
		}
	}

	public void HideAllPickUppables()
	{
		foreach (PickUppable allSpawnedPickuppable in allSpawnedPickuppables)
		{
			allSpawnedPickuppable.gameObject.SetActive(value: false);
		}
	}

	public void HideAllBreakableWalls()
	{
		foreach (BreakableWall walls_Master in walls_MasterList)
		{
			if (!(walls_Master == null))
			{
				walls_Master.gameObject.SetActive(value: false);
			}
		}
	}

	public void NighttimeLights_TurnOn()
	{
		if (hatchDoorEnvironment_IsActive)
		{
			return;
		}
		foreach (GameObject nighttime_Light in nighttime_Lights)
		{
			nighttime_Light.SetActive(value: true);
		}
	}

	public void NighttimeLights_TurnOff()
	{
		foreach (GameObject nighttime_Light in nighttime_Lights)
		{
			nighttime_Light.SetActive(value: false);
		}
	}

	public void HideNightimeOnlyObjects()
	{
		foreach (GameObject item in objectsToHideAtNight)
		{
			item.SetActive(value: false);
		}
	}

	private void HandlePopGunBulletDespawning()
	{
		if (popgun_SpawnedBullets.Count > 12)
		{
			GameObject obj = popgun_SpawnedBullets[0];
			popgun_SpawnedBullets.RemoveAt(0);
			UnityEngine.Object.Destroy(obj);
		}
	}

	public void ResetAbilityCooldowns()
	{
		bigHole_Cooldown_Curr = 0f;
		goldRush_Cooldown_Curr = 0f;
		PlayerStats.Singleton.hasUsedThisRound_BigHole = false;
		PlayerStats.Singleton.hasUsedThisRound_GoldRush = false;
	}

	public void Debug_SpawnHammer()
	{
		PlayerStats.Singleton.SledgeHammer_Unlocked = true;
		PlayerStats.Singleton.SledgeHammer_Tier = 3;
		tool_SledgeHammer.gameObject.SetActive(PlayerStats.Singleton.SledgeHammer_Unlocked);
		if (tool_SledgeHammer.gameObject.activeSelf)
		{
			tool_SledgeHammer.SetHammerMaterialFromTier();
		}
	}

	public void Debug_SpawnStarKey()
	{
		PlayerStats.Singleton.starKey_Unlocked = true;
		tool_StarKey.SetActive(value: true);
	}

	public void HandleJUICED()
	{
		if (juiced_Amount_Curr > 0f)
		{
			juiced_GrowthMultiplier_Curr = PlayerStats.Singleton.juiced_GrowthMultiplier;
		}
		else
		{
			juiced_GrowthMultiplier_Curr = 1f;
		}
		if (gameState == GameState.Playing && !hasTimerElapsed_IsNighttime && juiced_Amount_Curr > 0f)
		{
			juiced_Amount_Curr -= Time.deltaTime * juiced_DrainRate;
		}
	}

	public void AddJUICEDJuice(float _amt)
	{
		juiced_Amount_Curr = Mathf.Clamp(juiced_Amount_Curr + _amt, 0f, juiced_Amount_Limit);
	}

	public float GetBlitzCurrentTimer()
	{
		return goldRush_Time_Current;
	}

	public float GetJuicedCurrentAmt()
	{
		return juiced_Amount_Curr;
	}

	public float GetJuicedMaxAmt()
	{
		return juiced_Amount_Limit;
	}

	public void DisableFirstRoundPlayerOnlyHoleCollider()
	{
		playerOnlyHoleCollider_ForLevel0Hole.SetActive(value: false);
	}

	public void EnteredBellaDonnaTunnel()
	{
		AudioManager.Singleton.PauseAmbientTrack();
		isInsideBellaDonnaTunnel = true;
		playHardSurfaceFootsteps = true;
	}

	public void ExitedBellaDonnaTunnel()
	{
		if (isInsideBellaDonnaTunnel)
		{
			AudioManager.Singleton.UnPauseAmbientTrack();
			isInsideBellaDonnaTunnel = false;
			playHardSurfaceFootsteps = false;
		}
	}

	public void EnteredStarRoom()
	{
		playHardSurfaceFootsteps = true;
		audioduck_BlipsAndBloops = true;
		if (!MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_InfiniteDaytime)
		{
			DisableRoundTimer();
		}
		if (!isStarDoorOpen)
		{
			TeleportPlayerOutsideOfStarRoom();
		}
	}

	private void TeleportPlayerOutsideOfStarRoom()
	{
		playerObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
		playerObject.GetComponent<Rigidbody>().position = new Vector3(0f, 5f, -100f);
		ExitedStarRoom();
	}

	public void ExitedStarRoom()
	{
		playHardSurfaceFootsteps = false;
		audioduck_BlipsAndBloops = false;
		if (!MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_InfiniteDaytime)
		{
			EnableRoundTimer();
		}
	}

	private void UpdateSteamRichPresence()
	{
	}

	public void EnableRoundTimer()
	{
		shouldTickDownRoundTime = true;
	}

	public void DisableRoundTimer()
	{
		shouldTickDownRoundTime = false;
	}

	private void HandleTimePlayed()
	{
		if ((gameState == GameState.Playing || gameState == GameState.RoundOverShop) && HudManager.Singleton.activeUiGroup != HudManager.ActiveUiGroup.Paused && !stopCountingSpeedrunTime)
		{
			totalPlayTimeForStats += Time.deltaTime;
		}
	}

	public void StoreThisRoundsPlaytimeIntoStats()
	{
		PlayerStats.Singleton.totalTimePlayed += totalPlayTimeForStats;
		totalPlayTimeForStats = 0f;
		stopCountingSpeedrunTime = true;
		SaveLoadManager.Singleton.SaveGame();
	}

	public float GetCurrentTotalTime_ForSpeedrunTimer()
	{
		return PlayerStats.Singleton.totalTimePlayed + totalPlayTimeForStats;
	}

	public void SwitchToBelladonnaBuddyEndingEnvironment()
	{
		audioduck_BlipsAndBloops = true;
		belladonnaBuddyEnding_IsActive = true;
		shouldTickDownRoundTime = false;
		hardDisableBubble = true;
		playerOnlyHoleCollider_ForLevel0Hole.SetActive(value: true);
		radioInScene.PlaySpookyStaticIndefinitely();
		starDoor_Anim.Play("StarDoor_Closed");
		AudioManager.Singleton.PlaySFX_MsRainbowMoveJitter(playerObject.transform.position);
		VcrIntroManager.Singleton.StartGlitchedOutBlackStarOrbEffect(1.2f);
		poisonWaterPlane.SetActive(value: true);
		AudioManager.Singleton.PlayAmbientTrack(9, 2f, _fadeIn: false, 0.3f);
		ToggleHaltAllPlantBedProduction(_hideHalfGrownBerries: true);
		SwapAllPlantGrowerFlowerVisualsWithBelladonnaPurple();
		SwapCharacterEyesToBlackOutAndCrying();
		RenderSettings.ambientLight = ambientLightColor_BelladonnaEnding;
		RenderSettings.skybox = skyboxMat_BelladonnaEnding;
		sunLight.SetActive(value: false);
		poisonWater_SurvivalTimer = 0f;
	}

	private void HandleBelladonnaBuddyEnding()
	{
		if (!belladonnaBuddyEnding_IsActive)
		{
			return;
		}
		if (poisonWaterPlane.transform.position.y < 10f)
		{
			poisonWaterPlane.transform.Translate(Vector3.up * (poisonWater_RiseSpeed * Time.deltaTime));
		}
		poisonWater_SurvivalTimer += Time.deltaTime;
		if (poisonWater_SurvivalTimer > 90f && !isLoadingCreditsScreen)
		{
			isLoadingCreditsScreen = true;
			if (!AchievementHelper.IsAchievementUnlocked("ACH_SurviveBelladonna"))
			{
				AchievementHelper.UnlockAchievement("ACH_SurviveBelladonna");
			}
			AudioManager.Singleton.StopAmbientMusic();
			MenuToGameBridger.Singleton.comingBackToMainMenuFromBelladonnaEnding = true;
			PlayerStats.Singleton.ending_BelladonnaBuddy = true;
			StoreThisRoundsPlaytimeIntoStats();
			MenuToGameBridger.Singleton.GrabAndStoreSavedPlayerData();
			if (LocalizationSettings.SelectedLocale.Identifier.Code == "en")
			{
				MenuToGameBridger.Singleton.endingCompletedString = "Belladonna";
			}
			else
			{
				MenuToGameBridger.Singleton.endingCompletedString = "C";
			}
			SceneManager.LoadScene("Credits");
		}
		if (playerCamera.transform.position.y < poisonWaterPlane.transform.position.y)
		{
			poisonWater_DrownTimer_Curr += Time.deltaTime;
			if (poisonWater_DrownTimer_Curr >= poisonWater_DrownTimer && !isLoadingCreditsScreen)
			{
				isLoadingCreditsScreen = true;
				AudioManager.Singleton.StopAmbientMusic();
				MenuToGameBridger.Singleton.comingBackToMainMenuFromBelladonnaEnding = true;
				PlayerStats.Singleton.ending_BelladonnaBuddy = true;
				StoreThisRoundsPlaytimeIntoStats();
				MenuToGameBridger.Singleton.GrabAndStoreSavedPlayerData();
				if (LocalizationSettings.SelectedLocale.Identifier.Code == "en")
				{
					MenuToGameBridger.Singleton.endingCompletedString = "Belladonna";
				}
				else
				{
					MenuToGameBridger.Singleton.endingCompletedString = "C";
				}
				SceneManager.LoadScene("Credits");
			}
		}
		else
		{
			poisonWater_DrownTimer_Curr = 0f;
		}
	}

	private void SwapCharacterEyesToBlackOutAndCrying()
	{
		foreach (GameObject characterCryingParticleEffect in characterCryingParticleEffects)
		{
			characterCryingParticleEffect.SetActive(value: true);
		}
		for (int i = 0; i < characterEyesToBlackOut.Count; i++)
		{
			Material material = characterEyesToBlackOut[i].material;
			material = blackOutEyes_Material;
			characterEyesToBlackOut[i].material = material;
		}
		foreach (EyesHandler characterCrying_EyeHandler in characterCrying_EyeHandlers)
		{
			characterCrying_EyeHandler.ChangeEyeState(EyesHandler.EyeState.Open);
			characterCrying_EyeHandler.disableBlinking = true;
		}
	}

	public void SwitchToGnomeEndingEnvironment()
	{
		if (gnomeEnding_IsActive)
		{
			return;
		}
		audioduck_BlipsAndBloops = false;
		HideAllCoins();
		HideAllAdditionalMsRainbowPoses();
		RenderSettings.ambientLight = ambientLightColor_Default;
		RenderSettings.fog = false;
		Player.Singleton.Flashlight_TurnOff();
		sunLight.SetActive(value: true);
		NighttimeLights_TurnOff();
		gnomeEnding_IsActive = true;
		shouldTickDownRoundTime = false;
		hardDisableBubble = true;
		AudioManager.Singleton.PlaySFX_MouseClick();
		TutorialManager.Singleton.HideAllTutorialGroups();
		forceHide_HoleDynamicRadiusVisual = true;
		HideAllPickUppables();
		HideAllBreakableWalls();
		HideMiscHatchSceneObjects();
		gnomeEnding_Parent.SetActive(value: true);
		foreach (GameObject item in objectsToHideForGnomeEnding)
		{
			item.SetActive(value: false);
		}
		yardAndHoleObject.SetActive(value: false);
		starDoor_Anim.Play("StarDoor_Closed");
		AudioManager.Singleton.PlayAmbientTrack(2, 0f, _fadeIn: false, 0.425f);
	}

	private void HandleGnomeEnding()
	{
		if (gnomeEnding_IsActive && gnomeEnding_SpawnedGnomes.Count >= 500 && !isLoadingCreditsScreen)
		{
			isLoadingCreditsScreen = true;
			AudioManager.Singleton.StopAmbientMusic();
			MenuToGameBridger.Singleton.comingBackToMainMenuFromGnomeEnding = true;
			PlayerStats.Singleton.ending_Gnome = true;
			StoreThisRoundsPlaytimeIntoStats();
			MenuToGameBridger.Singleton.GrabAndStoreSavedPlayerData();
			if (LocalizationSettings.SelectedLocale.Identifier.Code == "en")
			{
				MenuToGameBridger.Singleton.endingCompletedString = "Gnome";
			}
			else
			{
				MenuToGameBridger.Singleton.endingCompletedString = "D";
			}
			SceneManager.LoadScene("Credits");
		}
	}

	private IEnumerator WaitThenTellTheEndingGnomesTheyCanDuplicate()
	{
		yield return new WaitForSeconds(10f);
		foreach (GnomeDuplicator gnomeEnding_SpawnedGnome in gnomeEnding_SpawnedGnomes)
		{
			gnomeEnding_SpawnedGnome.duplicateActive = true;
		}
	}

	public void ShutGnomeWallBehindPlayer()
	{
		if (!gnomeEnding_TrappingWall.activeSelf)
		{
			gnomeEnding_TrappingWall.SetActive(value: true);
			StartCoroutine(WaitThenTellTheEndingGnomesTheyCanDuplicate());
		}
	}

	public void RecalculateNumberOfGnomesLeft()
	{
		int num = 0;
		foreach (PickUppable allGnomeMilestone in allGnomeMilestones)
		{
			if (!(allGnomeMilestone == null) && allGnomeMilestone.gameObject.activeSelf)
			{
				num++;
			}
		}
		numOfGnomesRemaining = num;
		Debug.Log("Gnomes Left: " + numOfGnomesRemaining + "/" + allGnomeMilestones.Count);
		Gnomes_AchievementCheck(numOfGnomesRemaining, allGnomeMilestones.Count);
	}

	public void RecalculateNumberOfMilestonesRemaining()
	{
		int num = 0;
		foreach (bool milestoneObjects_MasterList_Bool in milestoneObjects_MasterList_Bools)
		{
			if (milestoneObjects_MasterList_Bool)
			{
				num++;
			}
		}
		numOfRemainingMilestones = num;
		MilestonesRelatedAchievementCheck(numOfRemainingMilestones, milestoneObjects_MasterList_Bools.Count);
	}

	public IEnumerator WaitAFrameThenCheckHowManyGnomesWeHaveLeft()
	{
		yield return null;
		yield return null;
		yield return null;
		RecalculateNumberOfGnomesLeft();
	}

	public void ChangeCameraLayerToOnlyUIForShop()
	{
		mainCamera.cullingMask = 1 << LayerMask.NameToLayer("UI");
	}

	private void ShopEntered_AchievementCheck()
	{
		if (moneyDroppedInHoleThisRound >= 1000000 && !AchievementHelper.IsAchievementUnlocked("ACH_DropAMillion"))
		{
			AchievementHelper.UnlockAchievement("ACH_DropAMillion");
		}
		if (PlayerStats.Singleton.money >= 9 && PlayerStats.Singleton.totalRounds == 0 && !AchievementHelper.IsAchievementUnlocked("ACH_Gain9Dollars"))
		{
			AchievementHelper.UnlockAchievement("ACH_Gain9Dollars");
		}
		if (PlayerStats.Singleton.totalMoneyEarned >= 100 && !AchievementHelper.IsAchievementUnlocked("ACH_MoneyEarn_Hundred"))
		{
			AchievementHelper.UnlockAchievement("ACH_MoneyEarn_Hundred");
		}
		if (PlayerStats.Singleton.totalMoneyEarned >= 1000 && !AchievementHelper.IsAchievementUnlocked("ACH_MoneyEarn_Thousand"))
		{
			AchievementHelper.UnlockAchievement("ACH_MoneyEarn_Thousand");
		}
		if (PlayerStats.Singleton.totalMoneyEarned >= 10000 && !AchievementHelper.IsAchievementUnlocked("ACH_MoneyEarn_TenThousand"))
		{
			AchievementHelper.UnlockAchievement("ACH_MoneyEarn_TenThousand");
		}
		if (PlayerStats.Singleton.totalMoneyEarned >= 100000 && !AchievementHelper.IsAchievementUnlocked("ACH_MoneyEarn_HundredThousand"))
		{
			AchievementHelper.UnlockAchievement("ACH_MoneyEarn_HundredThousand");
		}
		if (PlayerStats.Singleton.totalMoneyEarned >= 1000000 && !AchievementHelper.IsAchievementUnlocked("ACH_MoneyEarn_Million"))
		{
			AchievementHelper.UnlockAchievement("ACH_MoneyEarn_Million");
		}
		if (PlayerStats.Singleton.totalMoneyEarned >= 100000000 && !AchievementHelper.IsAchievementUnlocked("ACH_MoneyEarn_HundredMillion"))
		{
			AchievementHelper.UnlockAchievement("ACH_MoneyEarn_HundredMillion");
		}
		if (PlayerStats.Singleton.totalMoneyEarned >= 1000000000 && !AchievementHelper.IsAchievementUnlocked("ACH_MoneyEarn_Billion"))
		{
			AchievementHelper.UnlockAchievement("ACH_MoneyEarn_Billion");
		}
	}

	private void HolePrestiged_AchievementCheck()
	{
		if (PlayerStats.Singleton.holeGrowth_Level == 19 && !AchievementHelper.IsAchievementUnlocked("ACH_MaxHoleSize"))
		{
			AchievementHelper.UnlockAchievement("ACH_MaxHoleSize");
			MenuToGameBridger.Singleton.HundoPercentCompletionAchievementCheck();
		}
	}

	private void Gnomes_AchievementCheck(int _numRemaining, int _totalGnomes)
	{
		if (_numRemaining < _totalGnomes && !AchievementHelper.IsAchievementUnlocked("ACH_Gnomes_One"))
		{
			AchievementHelper.UnlockAchievement("ACH_Gnomes_One");
		}
		if (_totalGnomes - _numRemaining >= 10 && !AchievementHelper.IsAchievementUnlocked("ACH_Gnomes_Ten"))
		{
			AchievementHelper.UnlockAchievement("ACH_Gnomes_Ten");
		}
		if (_totalGnomes - _numRemaining >= 100 && !AchievementHelper.IsAchievementUnlocked("ACH_Gnomes_Hundred"))
		{
			AchievementHelper.UnlockAchievement("ACH_Gnomes_Hundred");
		}
		if (_numRemaining == 0 && !AchievementHelper.IsAchievementUnlocked("ACH_Gnomes_All"))
		{
			AchievementHelper.UnlockAchievement("ACH_Gnomes_All");
		}
	}

	private void MilestonesRelatedAchievementCheck(int _remaining, int _total)
	{
		int num = _total - _remaining;
		Debug.Log("Remaining: " + _remaining);
		Debug.Log("Total: " + _total);
		Debug.Log("Deposited: " + num);
		if (!achievement_HasCheckedForMilestonesThisRound_One && num > 0)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_DepositProps_One"))
			{
				AchievementHelper.UnlockAchievement("ACH_DepositProps_One");
			}
			achievement_HasCheckedForMilestonesThisRound_One = true;
		}
		if (!achievement_HasCheckedForMilestonesThisRound_Ten && num >= 10)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_DepositProps_Ten"))
			{
				AchievementHelper.UnlockAchievement("ACH_DepositProps_Ten");
			}
			achievement_HasCheckedForMilestonesThisRound_Ten = true;
		}
		if (!achievement_HasCheckedForMilestonesThisRound_Hundred && num >= 100)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_DepositProps_Hundred"))
			{
				AchievementHelper.UnlockAchievement("ACH_DepositProps_Hundred");
			}
			achievement_HasCheckedForMilestonesThisRound_Hundred = true;
		}
		if (!achievement_HasCheckedForMilestonesThisRound_FiveHundo && num >= 500)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_DepositProps_FiveHundo"))
			{
				AchievementHelper.UnlockAchievement("ACH_DepositProps_FiveHundo");
			}
			achievement_HasCheckedForMilestonesThisRound_FiveHundo = true;
		}
		if (!achievement_HasCheckedForMilestonesThisRound_All && _remaining <= 0)
		{
			if (!AchievementHelper.IsAchievementUnlocked("ACH_DepositProps_All"))
			{
				AchievementHelper.UnlockAchievement("ACH_DepositProps_All");
				MenuToGameBridger.Singleton.HundoPercentCompletionAchievementCheck();
			}
			achievement_HasCheckedForMilestonesThisRound_All = true;
		}
	}

	public void NewBerryBuddy_CheckForAchievements()
	{
		if (spawnedCultists.Count < 7)
		{
			return;
		}
		foreach (BerryCultist_AI spawnedCultist in spawnedCultists)
		{
			if (spawnedCultist.GetBerryTier() != 11)
			{
				return;
			}
		}
		if (!AchievementHelper.IsAchievementUnlocked("ACH_FullPumpkins"))
		{
			AchievementHelper.UnlockAchievement("ACH_FullPumpkins");
		}
	}

	private void SetNGPlusModifiers_FirstRoundOnly()
	{
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartStarPopper)
		{
			UpgradeTreeManager.Singleton.UnlockUpgrade(UpgradeTreeManager.Singleton.allUpgradeTreeButtons[141]);
		}
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartAutoCoinPickUp)
		{
			UpgradeTreeManager.Singleton.UnlockUpgrade(UpgradeTreeManager.Singleton.allUpgradeTreeButtons[105]);
		}
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartAbilities)
		{
			UpgradeTreeManager.Singleton.UnlockUpgrade(UpgradeTreeManager.Singleton.allUpgradeTreeButtons[29]);
			UpgradeTreeManager.Singleton.UnlockUpgrade(UpgradeTreeManager.Singleton.allUpgradeTreeButtons[44]);
		}
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartTrampoline)
		{
			UpgradeTreeManager.Singleton.UnlockUpgrade(UpgradeTreeManager.Singleton.allUpgradeTreeButtons[154]);
		}
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartHammerAndChainsaw)
		{
			UpgradeTreeManager.Singleton.UnlockUpgrade(UpgradeTreeManager.Singleton.allUpgradeTreeButtons[87]);
			UpgradeTreeManager.Singleton.UnlockUpgrade(UpgradeTreeManager.Singleton.allUpgradeTreeButtons[143]);
			UpgradeTreeManager.Singleton.UnlockUpgrade(UpgradeTreeManager.Singleton.allUpgradeTreeButtons[142]);
		}
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_InfiniteHoleMove)
		{
			UpgradeTreeManager.Singleton.UnlockUpgrade(UpgradeTreeManager.Singleton.allUpgradeTreeButtons[114]);
		}
	}

	public void HideAllAdditionalMsRainbowPoses()
	{
		foreach (GameObject additionalMsRainbowMomentPose in additionalMsRainbowMomentPoses)
		{
			if ((bool)additionalMsRainbowMomentPose)
			{
				additionalMsRainbowMomentPose.SetActive(value: false);
			}
		}
	}

	public void ShowAdditionalMsRainbowPose(int _index)
	{
		HideAllAdditionalMsRainbowPoses();
		additionalMsRainbowMomentPoses[_index].SetActive(value: true);
	}

	public void RoundStart_DecideWhichAdditionalMsRainbowPoseToShow()
	{
		if (PlayerStats.Singleton.totalRounds > 1)
		{
			if (sittingOnWall_Wall.activeSelf)
			{
				ShowAdditionalMsRainbowPose(0);
			}
			else
			{
				ShowAdditionalMsRainbowPose(1);
			}
		}
	}

	public void OnBerryBuddyUpgraded_CallEvent()
	{
		OnBerryBuddyUpgraded_Action?.Invoke();
	}
}
