using System;
using System.Collections.Generic;
using System.Threading;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering;

public class Game : MonoBehaviour
{
	public enum BuildConfig
	{
		PCSteam = 0,
		PCEpic = 1,
		PCGog = 2,
		PCMicrosoftStore = 3,
		PCNoStorefrontFeatures = 4,
		ConsolePlaystation5 = 5,
		ConsoleXboxSeriesS = 6,
		ConsoleXboxSeriesX = 7
	}

	[Serializable]
	public class DebugCitizenWeapons
	{
		public MurderWeaponPreset weapon;

		public int count;

		public float percentage;
	}

	[Header("Build")]
	[OnValueChanged("OnBuildValueChanged")]
	[Tooltip("Build version")]
	public string buildID;

	[Space(7f)]
	public string buildDescription;

	public string customTags;

	public string steamScriptPath;

	[OnValueChanged("OnBuildValueChanged")]
	public bool updateAbove;

	public string lastCompatibleCities;

	[Tooltip("Controls a bunch of settings like options available to the player and default settings")]
	[Header("Build Settings")]
	public BuildConfig buildConfiguration;

	[Tooltip("Will automatically set the above build config depending on the platform running. This will only work for detecting consoles and won't detect different PC versions.")]
	public bool autodetectBuildConfig;

	[Tooltip("Forces the low end hardware flag")]
	public bool forceLowEndHardware;

	[Tooltip("Enable dev options on main menu & collect debugging info on a range of gameobjects")]
	[OnValueChanged("OnBuildValueChanged")]
	[Space(7f)]
	public bool devMode;

	[Tooltip("Print to console")]
	[OnValueChanged("OnBuildValueChanged")]
	public bool printDebug;

	[DisableIf("printDebug")]
	[Tooltip("Allow errors to be printed even if the above is false")]
	public bool alwaysPrintErrors;

	[Tooltip("Collect debug data")]
	[OnValueChanged("OnBuildValueChanged")]
	public bool collectDebugData;

	[EnableIf("printDebug")]
	[Range(0f, 2f)]
	[Tooltip("Set the debug prints level: 0 is nothing, 2 is maximum")]
	public int debugPrintLevel;

	[OnValueChanged("OnBuildValueChanged")]
	[Tooltip("Enable bug reporting")]
	public bool enableBugReporting;

	[Tooltip("Force the game to be english")]
	[OnValueChanged("OnBuildValueChanged")]
	public bool forceEnglish;

	[Tooltip("Skip intro")]
	[OnValueChanged("OnBuildValueChanged")]
	public bool skipIntro;

	[Tooltip("Allows mod button in the main menu; only if this is NOT a console version")]
	[OnValueChanged("OnBuildValueChanged")]
	public bool allowMods;

	[Tooltip("Force medium sized cities on console")]
	public bool forceMediumCitiesOnConsole;

	[Space(7f)]
	[Tooltip("If true and in dev mode and collect debug data, will ensure dictionaries have names for all items")]
	public bool ensureItemNamesInDictionaries;

	[Tooltip("Low end hardware detected; this includes steam deck. Will provide alternate default settings.")]
	[Space(7f)]
	public bool isLowEndHardware;

	[Space(7f)]
	[Tooltip("Boosts minimum font sizes when running at 1280x800 or below")]
	public bool boostMinimumFontSize;

	[Header("Console Limitations")]
	public List<GameObject> removeOnConsoleVersions;

	[Header("Demo Limitations")]
	[OnValueChanged("OnBuildValueChanged")]
	[Tooltip("Is this a demo build? Limit time")]
	public bool timeLimited;

	[OnValueChanged("OnBuildValueChanged")]
	[Tooltip("Limit time to this in minutes")]
	public float timeLimit;

	[OnValueChanged("OnBuildValueChanged")]
	[Tooltip("Start the timer after exit of apartment in story mode")]
	public bool startTimerAfterApartmentExit;

	[OnValueChanged("OnBuildValueChanged")]
	[Tooltip("Pause the timer on caseboard or menu")]
	public bool pauseTimerOnGamePause;

	[OnValueChanged("OnBuildValueChanged")]
	[Tooltip("Disable save games")]
	public bool disableSaveLoadGames;

	[Tooltip("Disable sandbox mode")]
	[OnValueChanged("OnBuildValueChanged")]
	public bool disableSandbox;

	[Tooltip("Disable city generation")]
	[OnValueChanged("OnBuildValueChanged")]
	public bool disableCityGeneration;

	[OnValueChanged("OnBuildValueChanged")]
	public bool smallCitiesOnly;

	[OnValueChanged("OnBuildValueChanged")]
	public bool displayBetaMessage;

	[Tooltip("Use compression to store save games")]
	[Header("Game")]
	public bool useSaveGameCompression;

	[EnableIf("useSaveGameCompression")]
	[Range(0f, 10f)]
	public int saveGameCompressionQuality;

	[Tooltip("Use compression to store generated city data")]
	public bool useCityDataCompression;

	[EnableIf("useCityDataCompression")]
	[Range(0f, 10f)]
	public int cityDataCompressionQuality;

	[Tooltip("How many threads to spawn on certain loading/generation routines")]
	public int maxThreads;

	[Tooltip("Automatically write unfound text entries to .csv files")]
	public bool writeUnfoundToTextFiles;

	[Tooltip("Start the game without loading a story chapter")]
	public bool sandboxMode;

	[DisableIf("sandboxMode")]
	[Tooltip("Load this chapter")]
	public int loadChapter;

	[Tooltip("If true, the player movement will update in the regular Update() loop, if false it will update in FixedUpdate()")]
	public bool updateMovementEveryFrame;

	[Tooltip("Default amount of saturation: Needed as we modify it with loosing health etc")]
	public float defaultSaturationAmount;

	[Tooltip("If true this will display control tips")]
	public bool displayExtraControlHints;

	[Tooltip("If true this will display objective markers")]
	public bool objectiveMarkers;

	[Tooltip("General game difficulty")]
	[Range(0f, 3f)]
	public int gameDifficulty;

	public List<float> difficultyIncomingDamageMultipliers;

	[Tooltip("Game length")]
	[Range(0f, 4f)]
	public int gameLength;

	public List<int> gameLengthMaxLevels;

	[Tooltip("Force side missions to be a certain difficulty")]
	public bool forceSideJobDifficulty;

	[Range(0f, 6f)]
	public int forcedJobDifficulty;

	[Tooltip("Resume the game after pinning evidence item")]
	public bool resumeAfterPin;

	[Tooltip("Close windows with world interaction status on resume game")]
	public bool closeInteractionsOnResume;

	[Tooltip("Enables the directional arrow")]
	public bool enableDirectionalArrow;

	public float sandboxStartTime;

	[Tooltip("Enables the murderer in sandbox mode")]
	public bool enableMurdererInSandbox;

	public float weatherChangeFrequency;

	public bool disableSnow;

	public bool disableTrespass;

	public bool debugMurdererOnStart;

	[Tooltip("Starts the game outside the door of the apartment in story mode")]
	public bool demoChapterSkip;

	public bool demoMode;

	[Tooltip("Gives access to all hospital doors")]
	public bool allHospitalAccess;

	[Tooltip("Auto pause the game after x seconds of no input")]
	public bool autoPause;

	[EnableIf("autoPause")]
	public int autoPauseSeconds;

	[Tooltip("Ask to restart the game from this save game if left for x seconds of no input")]
	public bool demoAutoReset;

	[EnableIf("demoAutoReset")]
	public int resetSeconds;

	[EnableIf("demoAutoReset")]
	public int resetChapterPart;

	[EnableIf("demoAutoReset")]
	public string resetSaveGameName;

	public float textSpeed;

	[Tooltip("Disables closing of case board: Used sometimes by the tutorial")]
	[ReadOnly]
	public bool disableCaseBoardClose;

	[Tooltip("Allows/disables licensed music")]
	public bool allowLicensedMusic;

	[Tooltip("Override all passcodes")]
	public bool overridePasscodes;

	public int overriddenPasscode;

	[Tooltip("Max delta time")]
	public float maxDeltaTime;

	public int aaMode;

	public int playerPasscode;

	[Tooltip("Attempt to save/load captured scenes to disk")]
	public bool enableDiskSavedCaptures;

	[NonSerialized]
	public Thread mainThread;

	[Header("Statuses")]
	public bool coldStatusEnabled;

	public bool smellyStatusEnabled;

	public bool headacheStatusEnabled;

	public bool injuryStatusEnabled;

	public bool tiredStatusEnabled;

	public bool hungerStatusEnabled;

	public bool hydrationStatusEnabled;

	public bool numbStatusEnabled;

	public bool bleedingStatusEnabled;

	public bool wetStatusEnabled;

	public bool sickStatusEnabled;

	public bool drunkStatusEnabled;

	public bool starchAddictionEnabled;

	public bool poisonStatusEnabled;

	public bool blindedStatusEnabled;

	[Space(7f)]
	public bool energizedStatusEnabled;

	public bool hydratedStatusEnabled;

	public bool focusedStatusEnabled;

	public bool wellRestedStatusEnabled;

	[Tooltip("Enables mouse/keyboard control by default on startup; disable for console builds")]
	[Header("Controls")]
	public Vector2 mouseSensitivity;

	public Vector2 controllerSensitivity;

	public float virtualCursorSensitivity;

	public Vector2 axisMP;

	public bool controlAutoSwitch;

	public int mouseSmoothing;

	public int controllerSmoothing;

	public float movementSpeed;

	public int scrollSensitivity;

	public float forceFeedbackMultiplier;

	[Header("Player")]
	public string playerFirstName;

	public string playerSurname;

	public Human.Gender playerGender;

	public Human.Gender partnerGender;

	public Color playerSkinColour;

	public int playerBirthDay;

	public int playerBirthMonth;

	public int playerBirthYear;

	[Header("Words")]
	[Tooltip("The game's language reference string")]
	public string language;

	public int wordCountTotal;

	[Header("Streets")]
	public bool displayStreetChunks;

	public bool displayStreetAndJunctionChunks;

	[EnableIf("displayStreetAndJunctionChunks")]
	public bool displayTrafficSimulationResults;

	public Material debugtrafficSimMaterial;

	[DisableIf("displayStreetAndJunctionChunks")]
	public bool displayStreets;

	public Material debugStreetMaterial;

	public List<Color> streetDebugColours;

	[Header("City")]
	[Tooltip("Display roads")]
	public bool debugDisplayRoads;

	[Tooltip("Player can open any door")]
	public bool keysToTheCity;

	[Tooltip("Disable generation of furniture")]
	public bool disableFurniture;

	[Tooltip("Destroy this when the game is started")]
	public Transform debugContainer;

	[Tooltip("Enable culling debug for new cull system")]
	public bool enableCullingDebug;

	[Tooltip("When generating a new city, use the city editor")]
	public bool enableCityEditor;

	[Header("Citizens")]
	[Tooltip("Statistic for keeping track of how early/late citizens are on average compared with due time. Records guess accuracy.")]
	public bool collectRoutineTimingInfo;

	public float guessAverageOnTime;

	public int guessDataEntries;

	public float guessEarlyPercent;

	public float guessLatePercent;

	[NonSerialized]
	public float guessCumulativeOnTime;

	[NonSerialized]
	public int guessEarlyEntries;

	[NonSerialized]
	public int guessLateEntries;

	public Vector2 boundaries;

	[Tooltip("If enabled, citizens won't react to getting attacked by the player")]
	public bool noReactOnAttack;

	[Header("Pathfinding")]
	[Tooltip("If pathfinding fails, load objects to present the closed set for debugging")]
	public bool debugPathfinding;

	[Tooltip("Use the job system for pathfinding")]
	public bool useJobSystem;

	[Tooltip("Cache external routes for the pathfinding system")]
	public bool useExternalRouteCaching;

	[Tooltip("Cache internal routes for the pathfinding system")]
	public bool useInternalRouteCaching;

	[Tooltip("Force street pathing to be run on the main thread, this appears to be faster due to the data passed to the worker?")]
	public bool forceStreetPathsOnMainThread;

	[Tooltip("If true the maximum cached path numbers will be ignored. The game could run out of memory eventually, so be careful!")]
	public bool unlimitedPathCaching;

	[Tooltip("The maximum number of cached external paths")]
	public int maxExternalCachedPaths;

	[Tooltip("The maximum number of cached paths in an internal address")]
	public int maxInternalCachedPaths;

	[Tooltip("The maximum number of cached street paths")]
	public int maxStreetCachedPaths;

	[Tooltip("Enable dynamic rerouting")]
	public bool dynamicReRouting;

	[Space(7f)]
	public List<string> pathfinderDebugLog;

	[Header("Evidence")]
	[Tooltip("Discover all evidence as soon as it is created")]
	public bool discoverAllEvidence;

	[Header("Map")]
	[Tooltip("Discover all rooms")]
	public bool discoverAllRooms;

	[Tooltip("Maximum number of drawn map icons in memory")]
	public int maxDrawnMapIcons;

	[Header("Gameplay")]
	[Tooltip("Player is always in illegal area")]
	public bool everywhereIllegal;

	[Tooltip("Player is always hidden for AI")]
	public bool invisiblePlayer;

	[Tooltip("Player cannot be heard by AI")]
	public bool inaudiblePlayer;

	[Tooltip("Player cannot be killed")]
	public bool invinciblePlayer;

	[Tooltip("Plotting a route will teleport the player to that location isntead")]
	public bool routeTeleport;

	[Tooltip("Give all upgrades available in the city")]
	public bool giveAllUpgrades;

	[Tooltip("Disable fall damage")]
	public bool disableFallDamage;

	[Tooltip("Pause the AI completely")]
	public bool pauseAI;

	[Tooltip("Free camera mode")]
	public bool freeCam;

	[Tooltip("Fast forward")]
	public bool fastForward;

	[Tooltip("Disable negatives statuses while in story mode")]
	public bool disableSurvivalStatusesInStory;

	public bool sandboxStartingApartment;

	public int playerFixedPasscode;

	public int sandboxStartingMoney;

	public int sandboxStartingLockpicks;

	[Tooltip("Build types where the player apartment will be located")]
	public List<BuildingPreset> preferredStartingBuildings;

	[Tooltip("Will always run and sprint control will walk")]
	public bool alwaysRun;

	[Tooltip("Toggles run instead of having to hold it down")]
	public bool toggleRun;

	[Tooltip("If you get KO'd in game, the game ends")]
	public bool permaDeath;

	[Tooltip("If true, the game will pause while auto travelling")]
	public bool autoTravelPause;

	[Tooltip("Allow echelon gated communities")]
	public bool allowEchelons;

	[Tooltip("Allow loitering")]
	public bool allowLoitering;

	[Tooltip("Allow auto travel")]
	public bool allowAutoTravel;

	[Tooltip("Allow social credit perks")]
	public bool allowSocialCreditPerks;

	[Tooltip("Allow draggable bodies")]
	public bool allowDraggableRagdolls;

	[Tooltip("Enables a quick way of testing cover-up offers: DISABLE FOR RELEASE!")]
	public bool forceCoverUpOffers;

	[Tooltip("Enabled Cole's code check for falling through a floor; possible conflict with Austin's attached to the player controller")]
	public bool enableColesFallingThroughFloorCheck;

	[Tooltip("Force the killer to leave taunts at the player's apartment")]
	public bool forcePlayerTaunts;

	[Tooltip("Use the newer, simpler version of killer monikers system")]
	public bool useSimplifiedKillerMonikers;

	[Tooltip("Spawn Bas Boule Cards")]
	public bool spawnBasBouleCards;

	[Header("Difficulty: Prices")]
	public float jobRewardMultiplier;

	public float jobPenaltyMultiplier;

	public float housePriceMultiplier;

	[Tooltip("Switch indoor lights to non-shadow casting when player is in a different groundmap area")]
	[Header("Graphics")]
	public bool noShadowsWhenPlayerIsInDifferentGoundmapLocation;

	[Tooltip("Use a special raindrop material/shader on the streets")]
	public bool enableRaindrops;

	[Tooltip("Use a special raindrop material/shader on the windows")]
	public bool enableRainyWindows;

	public int fov;

	public bool depthBlur;

	public float motionBlurIntensity;

	public float motionBlurGameSpeedModifier;

	public float bloomIntensity;

	public bool shadowsOnCitizenLOD;

	public bool vsync;

	public bool enableFrameCap;

	public int frameCap;

	public bool flickeringLights;

	public bool enableRuntimeStaticBatching;

	[Tooltip("Use quads instead of decal projectors for footprints")]
	public bool useQuadsForFootprints;

	[InfoBox("The below is an experimental light culling system involving jobified raycasts. It doesn't seem to increase performance much and has some slightly noticable glitches. I've chosen to keep it in the code base as a potential thing to return to but will probably keep it disabled for the forseeable future", EInfoBoxType.Normal)]
	public bool enableCustomLightCulling;

	[InfoBox("The below is an experimental real time culling system that is being experimented with. If successful this would allow us to ditch any pre-baked culling trees; resulting in faster generation times and more memory (hopefully!)", EInfoBoxType.Normal)]
	public bool enableNewRealtimeTimeCullingSystem;

	[Tooltip("If true, the game will generate culling trees using the legacy system, previously used at generation-time only")]
	[DisableIf("enableNewRealtimeTimeCullingSystem")]
	public bool generateCullingInGame;

	public bool screenSpaceReflection;

	[Header("Audio")]
	public int hyperacusisFilter;

	public int bassReduction;

	[Space(7f)]
	[Range(0.4f, 2f)]
	public float lightFadeDistanceMultiplier;

	[Range(0.4f, 2f)]
	public float shadowFadeDistanceMultiplier;

	[Header("Shadows")]
	[Tooltip("Same as above but for the sun")]
	public int sunShadowUpdateFrequency;

	[ReadOnly]
	public int lastShadowsUpdatedCount;

	[Tooltip("Override shadow mode on all light controllers...")]
	public bool overrideLightControllerShadowMode;

	[EnableIf("overrideLightControllerShadowMode")]
	public LightingPreset.ShadowMode shadowModeOverride;

	public int dynamicShadowUpdateFrames;

	public int maxUpdateDynamicShadowsPerFrame;

	[Header("Meshes")]
	[Tooltip("Combining meshes will take longer on load and increase memory, but also increase performance...")]
	public bool combineAirDuctMeshes;

	[Tooltip("Combining meshes will take longer on load and increase memory, but also increase performance...")]
	public bool combineRoomMeshes;

	public ShadowCastingMode roomWallShadowMode;

	public ShadowCastingMode roomFloorShadowMode;

	public ShadowCastingMode roomCeilingShadowMode;

	public ShadowCastingMode airDuctShadowMode;

	[Tooltip("Enables job based mesh creation")]
	public bool useJobSystemForMeshCombination;

	public bool optimizeCombinedMeshes;

	[Tooltip("Automatically weld vertices together if they share the same space")]
	public bool autoWeldVertices;

	[Header("Interface")]
	public int uiScale;

	[Tooltip("Reveals text on a word-by-word basis as opposed to letter-by-letter")]
	public bool wordByWordText;

	[Header("Editor")]
	public bool selectCitizenOnLookAt;

	public int base26Test;

	public bool screenshotMode;

	public bool screenshotModeAllowDialog;

	[Header("Debug")]
	public List<Actor> debugHuman;

	public bool debugHumanMovement;

	public bool debugHumanActions;

	public bool debugHumanAttacks;

	public bool debugHumanUpdates;

	public bool debugHumanMisc;

	public bool debugHumanSight;

	public int debugFindWall;

	public int debugAddressID;

	public int debugCitizenID;

	public int debugPhotoTestID;

	public MurderWeaponPreset debugTestWeapon;

	public List<DebugCitizenWeapons> debugWeaponsSurvey;

	private static Game _instance;

	public static Game Instance => null;

	[Button(null, EButtonEnableMode.Always)]
	public void WordCount()
	{
	}

	public void SetScreenshotMode(bool val, bool allowDialog = false)
	{
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void AddOnTimeEntry(Actor cc, float newOnTime)
	{
	}

	public void AIInAddressFullyRested()
	{
	}

	public void AIInAddressNeedShower()
	{
	}

	public void AIInAddressNeedFun()
	{
	}

	public void DebugButton()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ResetRoutineCollectionData()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void AddRandomCitizenToAwareness()
	{
	}

	public void ForceEnableMovement()
	{
	}

	public void SetRaindrops(bool val)
	{
	}

	public void SetRainWindows(bool val)
	{
	}

	public void SetFOV(int val)
	{
	}

	public void SetObjectiveMarkers(bool val)
	{
	}

	public void SetDirectionalArrow(bool val)
	{
	}

	public void SetAwarenessIndicator(bool val)
	{
	}

	public void SetDepthBlur(bool val)
	{
	}

	public void SetSandboxStartTime(float val)
	{
	}

	public void SetGameDifficulty(int val)
	{
	}

	public void SetGameLength(int val, bool updateSocialCredits, bool updateDropdown, bool updateSavedValue)
	{
	}

	public void SetEnableColdStatus(bool val)
	{
	}

	public void SetEnableSmellyStatus(bool val)
	{
	}

	public void SetEnableHeadacheStatus(bool val)
	{
	}

	public void SetEnableBleedingStatus(bool val)
	{
	}

	public void SetEnableInjuryStatus(bool val)
	{
	}

	public void SetEnableHungerStatus(bool val)
	{
	}

	public void SetEnableHydrationStatus(bool val)
	{
	}

	public void SetEnableWetStatus(bool val)
	{
	}

	public void SetEnableSickStatus(bool val)
	{
	}

	public void SetEnableNumbStatus(bool val)
	{
	}

	public void SetEnableTiredStatus(bool val)
	{
	}

	public void SetEnableDrunkStatus(bool val)
	{
	}

	public void SetEnableEnergizedStatus(bool val)
	{
	}

	public void SetEnableHydratedStatus(bool val)
	{
	}

	public void SetEnableFocusedStatus(bool val)
	{
	}

	public void SetEnableWellRestedStatus(bool val)
	{
	}

	public void SetSandboxStartingApartment(bool val)
	{
	}

	public void SetFixedPasscode(int val)
	{
	}

	public void SetSandboxStartingMoney(int val)
	{
	}

	public void SetSandboxStartingLockpicks(int val)
	{
	}

	public void SetForceSideJobDifficulty(bool val)
	{
	}

	public void SetForcedSideJobDifficulty(int val)
	{
	}

	public void SetPauseAI(bool val)
	{
	}

	public void SetFreeCamMode(bool val)
	{
	}

	public void SetFastForward(bool val)
	{
	}

	public void SetDrawDistance(float val)
	{
	}

	public void SetLightDistance(float val)
	{
	}

	public void SetMurders(bool val)
	{
	}

	public void SetUIScale(int val)
	{
	}

	public void SetAAMode(int newMode)
	{
	}

	public void SetAAQuality(int newQuality)
	{
	}

	public void SetDithering(bool newVal)
	{
	}

	public void SetVsync(bool newVal)
	{
	}

	public void SetEnableFrameCap(bool newVal)
	{
	}

	public void SetFrameCap(int newVal)
	{
	}

	public void SetPasscodeOverrideToggle(bool newVal)
	{
	}

	public void SetPasscodeOverride(int newPasscode)
	{
	}

	public void SetFlickingLights(bool newVal)
	{
	}

	public static void Log(object print, int level = 2)
	{
	}

	public static void LogError(object print, int level = 2)
	{
	}

	public void SetAllowLicensedMusic(bool val)
	{
	}

	public void SetScreenSpaceReflection(bool val)
	{
	}

	public void SetHyperacusisFilter(int val)
	{
	}

	public void SetBassReduction(int val)
	{
	}

	public void SetPlayerPasscode(int val)
	{
	}

	public List<int> GetPlayerPasscodeDigits()
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void Base26Test()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void Give1000Crows()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void Give100Lockpicks()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ResetHealth()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void KOPlayer()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TestCurrentDetainedStatus()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void VictimsRankTest()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GiveAllUpgrades()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GiveSocialCredit()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CompleteSideJob()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplayAnswersToCurrentSideJob()
	{
	}

	public void OnBuildValueChanged()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugFindWall()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugAddressID()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugCitizenID()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ShotgunTest()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void MissionPhotoTest()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void FindProsthetics()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TeleportPlayerStreetStart()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ToggleCitizenColliders()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GiveRandomJolt()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TripPlayer()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TestTimeRange()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DeletePlayerPrefs()
	{
	}

	public void DeletePlayerPrefsConfirm()
	{
	}

	public void DeletePlayerPrefsCancel()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ForcePlayerDirtyDeath()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TurnOffAllDynamicOcclusion()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TurnOffAllLODS()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ShootFromPlayer()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UnloadUnusedAssets()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListSelfEmployed()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ExportGameContentLists()
	{
	}
}
