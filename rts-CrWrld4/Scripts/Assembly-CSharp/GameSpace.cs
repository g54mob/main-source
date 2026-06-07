using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using ClockStone;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using mattmc3.dotmore.Collections.Generic;

public class GameSpace : MonoBehaviour
{
	public enum CATEGORY
	{
		FARSITE = 0,
		MARKV = 1,
		SPAN = 2,
		COLONIES = 3,
		CHRONOM = 4,
		EDITOR = 5,
		FINALIZED = 6,
		DEMO = 7,
		NONE = 8,
		MVERSEMAIN = 9,
		MVERSE = 10
	}

	public static string version;

	public static int VERSION4RPL;

	public static GameSpace instance;

	public static long appStartTime;

	public static string fileToLoad;

	public static bool embeddedLoad;

	public static bool editMode;

	public static bool importMap;

	public static string guidToApply;

	public static string editorDirName;

	public static string titleToApply;

	public static string specifierToApply;

	[NonSerialized]
	public bool fix1319;

	public List<long[]> mversePrevSectorList;

	public List<int[]> mversePrevDigSectorList;

	public List<long> mversePrevSectorTimes;

	public MVerseHosting mverseHosting;

	public MVerseLobby mverseLobby;

	[NonSerialized]
	public bool mverseBeginGame;

	[NonSerialized]
	public List<MVersePlayerPrefab> mversePlayersServer;

	[NonSerialized]
	public HashSet<MVersePlayerPrefab> mversePlayers;

	[NonSerialized]
	public MVersePlayerPrefab mversePlayer;

	public MVersePlayerBadges mversePlayerBadges;

	public GameObject mverseUnitRoot;

	public MVerseEvents mverseEvents;

	public MVerseChatPane mverseChatPane;

	public GameObject mverseChatButton;

	public GameObject mverseActiveButton;

	public GameObject exitGameDialog;

	public CustomButtonPane customButtonPane;

	public Material towerIndicatorMaterial;

	public GameObject intro;

	public GameObject outro;

	public StockAssets stockAssets;

	public InGameMessage inGameMessage;

	[NonSerialized]
	public BuildUnitManager buildUnitManager;

	public Transform uiIndicatorContainer;

	public Dictionary<string, UIIndicator> uiIndicatorTable;

	[NonSerialized]
	public Dictionary<string, RplCore.Data> globalHeap;

	[NonSerialized]
	public OrderedDictionary2<string, RplCore.Data> globalTable;

	[NonSerialized]
	public List<RplCore.Data> globalList;

	private static bool procedural;

	private bool _editedEver;

	[NonSerialized]
	public bool mverseEver;

	public static CATEGORY category;

	private string _title;

	[NonSerialized]
	public MVerseStash mverseStashSend;

	[NonSerialized]
	public MVerseStash mverseStashRecv;

	[NonSerialized]
	public string specifier;

	[NonSerialized]
	public bool suppressTotemActivation;

	[NonSerialized]
	public string desc;

	[NonSerialized]
	public bool showFinalSequence;

	[NonSerialized]
	public bool efficiencyDistanceMax;

	[NonSerialized]
	public bool efficiencyMapSizeMax;

	[NonSerialized]
	public float MAX_GEN_RATE;

	public GameObject savedPopup;

	public GameObject objectiveObtainedPopup;

	public GameObject objectiveFailedPopup;

	public GameObject spanObjectiveObtainedPopup;

	public GameObject soylentOfflineIndicator;

	public FadeCanvas fadeCanvas;

	public static int colonyID;

	public GameObject audioControllerRef;

	public GameObject fileBrowserPanelPrefab;

	public Light directionalLight;

	public Canvas[] canvases;

	public RectTransform selectionBox;

	public PostProcessVolume postProcessVolume;

	public Material base_landOverlayMaterial0;

	public Material base_landOverlayMaterial1;

	public Texture[] landOverlayTextures;

	public GameObject planetSphere;

	public Camera mainCamera;

	public Camera uiCamera;

	public Camera cpackPreviewCamera;

	public PanelsViewer panelsViewer;

	public Material creeperPanelMaterial;

	public Material landPanelMaterial;

	public Material shieldPanelMaterial;

	public Material shieldFlatPanelMaterial;

	public Material mapBackgroundMaterial;

	public Shader landStochasticShader;

	public Shader landNoStochasticShader;

	public MiniMap minimap;

	public UnitHelpPane unitHelpPane;

	public GameObject singletonUnits;

	public GameObject mapBackground;

	public GameObject skyboxAnimator;

	public FadeText fadeText;

	public Material collectorZoneMaterial;

	public Material collectorZoneIndicatorMaterial;

	public TimeScorePane timeScorePane;

	public TerraformPanel terraformPanel;

	public TerrainModPanel terrainModPanel;

	public GameObject terraformButton;

	public ShieldPanel shieldPanel;

	public ScapePanel scapePanel;

	public GreenarPanel greenarPanel;

	public LandBasePanel landBasePanel;

	public FinalDialog finalDialog;

	public GameObject popupCanvas;

	public GameObject uiCanvas;

	public LeftPane leftPane;

	public TopRightPane topRightPane;

	public PauseButtonMgmt pauseButtonMgmt;

	public BottomPane bottomPane;

	public CModControls cmodControls;

	public TerraformPane terraformPane;

	public TopPane topPane;

	public CommandBaseButtonMgmt commandBaseButtonMgmt;

	public MenuPane menuPane;

	public SettingsPane settingsPane;

	public Helpometer helpometerPane;

	public GameObject editorButton;

	public FabricatorPane fabricatorPane;

	public FabPane fabPane;

	public FactoryPane factoryPane;

	public ERNInterfacePane ernInterfacePane;

	public OrbitalPane orbitalPane;

	public ERNPane ernPane;

	public ADAMessageLog adaMessageLog;

	public ADAMessageEditor adaMessageEditor;

	public InfoGraph infoGraph;

	public CPackManager cPackManager;

	public BeamManager beamManager;

	public Material blobMaterial;

	public Material sporeMaterial;

	public Material airSacMaterial;

	[NonSerialized]
	public string GUID;

	[NonSerialized]
	public double randSeed;

	[NonSerialized]
	public UnitData unitData;

	public PlayLogStats playLogStats;

	[NonSerialized]
	public int maxMustCollect;

	[NonSerialized]
	public Dictionary<string, Dictionary<RplCore, string>> msgCallbackTable;

	[NonSerialized]
	public int surfaceVictoryCharge;

	[NonSerialized]
	public int surfaceVictoryMaxTime;

	[NonSerialized]
	public bool braveMode;

	[NonSerialized]
	public int braveModeCount;

	[NonSerialized]
	public int braveModeQuellCounter;

	[NonSerialized]
	public int braveModeQuellTime;

	[NonSerialized]
	public World world;

	public InputManager inputManager;

	[NonSerialized]
	public MaterialsManager materialsManager;

	[NonSerialized]
	public DecalMaterialsManager decalMaterialsManager;

	[NonSerialized]
	public ADAMessages adaMessages;

	[NonSerialized]
	public OrderedDictionary cpacks;

	[NonSerialized]
	public Dictionary<string, CMod> cmods;

	[NonSerialized]
	public Stack<RplCore> corePool;

	[NonSerialized]
	public WaresManager waresManager;

	public GameObject gameRecorderViewerPane;

	public RasterDisplay rasterDisplay;

	[NonSerialized]
	public HashSet<UnitManager>[] wareHolders;

	[NonSerialized]
	public HashSet<UnitManager> shieldDeployedUnits;

	public MapEditor mapEditor;

	public RPLRunnerPane rplRunnerPane;

	[NonSerialized]
	public ManagerPool<MistManager> mistPool;

	[NonSerialized]
	public ManagerPool<Shot> shotPool;

	[NonSerialized]
	public ManagerPool<ACShot> acShotPool;

	[NonSerialized]
	public ManagerPool<MortarShot> mortarShotPool;

	[NonSerialized]
	public ManagerPool<Missile> missilePool;

	[NonSerialized]
	public ManagerPool<StraferMissile> straferMissilePool;

	[NonSerialized]
	public ManagerPool<Bomb> bombPool;

	[NonSerialized]
	public ManagerPool<ACBomb> acBombPool;

	[NonSerialized]
	public ManagerPool<MVerseEventIndicator> mverseEventIndicatorPool;

	[NonSerialized]
	public ManagerPool<Packet> packetPool;

	[NonSerialized]
	public ManagerPool<Packet> packetWarePool;

	[NonSerialized]
	public ManagerPool<ParticleTrailManager> particleTrailPool;

	[NonSerialized]
	public ManagerPool<ParticleTrailManager> particleTrailSmokePool;

	[NonSerialized]
	public int GAME_SPEED;

	[NonSerialized]
	public int updateCount;

	[NonSerialized]
	public float scapeLoss;

	[NonSerialized]
	public float treeCount;

	[NonSerialized]
	public float stumpCount;

	[NonSerialized]
	public float commandScore;

	[NonSerialized]
	public float creeperPerEnemyCell;

	[NonSerialized]
	public long creeperTotal;

	[NonSerialized]
	public long anticreeperTotal;

	[NonSerialized]
	public int creeperCoverTotal;

	[NonSerialized]
	public int anticreeperCoverTotal;

	[NonSerialized]
	public Chronat[] chronatArray;

	[NonSerialized]
	public int[] unitSelectionFootprintCounts;

	[NonSerialized]
	public int[] mverseUnitFootprintCounts;

	[NonSerialized]
	public int[] unitFootprintCounts;

	[NonSerialized]
	public List<UnitManager>[] unitFootprints;

	[NonSerialized]
	public HashSet<UnitManager>[] unitFootprintsBigBlock;

	[NonSerialized]
	public int[] powerZoneCounts;

	[NonSerialized]
	public HashSet<ParticleSystemManager> particleSystems;

	[NonSerialized]
	public HashSet<ParticleTrailManager> particleTrails;

	[NonSerialized]
	public HashSet<Animus> animi;

	[NonSerialized]
	public HashSet<Packet> packets;

	[NonSerialized]
	public HashSet<UnitManager> units;

	[NonSerialized]
	public HashSet<UnitManager> unfreezingUnits;

	[NonSerialized]
	public Dictionary<string, HashSet<UnitManager>> cmodUnits;

	[NonSerialized]
	public HashSet<UnitManager> cmodPacketPassUnits;

	[NonSerialized]
	public Dictionary<string, UnitManager> trueGUIDUnits;

	[NonSerialized]
	public HashSet<UnitManager>[] blobMap;

	[NonSerialized]
	public List<Vine>[] vinesMap;

	[NonSerialized]
	public int redBlobLimit;

	[NonSerialized]
	public int redBlobCount;

	[NonSerialized]
	public int ampGems;

	[NonSerialized]
	public string adaStartMessage;

	[NonSerialized]
	public string adaEndMessage;

	[NonSerialized]
	public HashSet<MVerseUnit> mverseUnits;

	[NonSerialized]
	public HashSet<MVerseEventIndicator> mverseEventIndicators;

	[NonSerialized]
	public HashSet<CommandBase> commandBases;

	[NonSerialized]
	public CommandBase commandBase;

	[NonSerialized]
	public int commandBaseCoolDownTime;

	[NonSerialized]
	public ERNInterface ERNInterface;

	[NonSerialized]
	public HashSet<TerrainDecal> terrainDecals;

	[NonSerialized]
	public HashSet<UnitManager> nullifiableUnits;

	[NonSerialized]
	public HashSet<UnitManager>[] specialTargets;

	[NonSerialized]
	public HashSet<UnitManager> growMeshUnits;

	[NonSerialized]
	public HashSet<Emitter> emitters;

	[NonSerialized]
	public HashSet<Crystal> crystals;

	[NonSerialized]
	public HashSet<PowerZone> powerZones;

	[NonSerialized]
	public HashSet<Chronat> chronats;

	[NonSerialized]
	public HashSet<Tower> towers;

	[NonSerialized]
	public HashSet<Transformer> transformers;

	[NonSerialized]
	public HashSet<Collector> collectors;

	[NonSerialized]
	public HashSet<Microrift> microrifts;

	[NonSerialized]
	public HashSet<Monolith> monoliths;

	[NonSerialized]
	public HashSet<SuperTower> superTowers;

	[NonSerialized]
	public HashSet<TowerBridge> towerBridges;

	[NonSerialized]
	public HashSet<CollectorPanel5> collectorPanel5s;

	[NonSerialized]
	public HashSet<CollectorPanel3> collectorPanel3s;

	[NonSerialized]
	public HashSet<Nullifier> nullifiers;

	[NonSerialized]
	public HashSet<Cannon> cannons;

	[NonSerialized]
	public HashSet<Mortar> mortars;

	[NonSerialized]
	public HashSet<Sprayer> sprayers;

	[NonSerialized]
	public HashSet<Shot> shots;

	[NonSerialized]
	public HashSet<ACShot> acShots;

	[NonSerialized]
	public HashSet<MortarShot> mortarShots;

	[NonSerialized]
	public HashSet<Missile> missiles;

	[NonSerialized]
	public HashSet<StraferMissile> straferMissiles;

	[NonSerialized]
	public HashSet<Bomb> bombs;

	[NonSerialized]
	public HashSet<ACBomb> acbombs;

	[NonSerialized]
	public HashSet<Wall> walls;

	[NonSerialized]
	public HashSet<Resource> resources;

	[NonSerialized]
	public HashSet<Workall> workalls;

	[NonSerialized]
	public HashSet<Fabricator> fabricators;

	[NonSerialized]
	public HashSet<StoragePad> storagePads;

	[NonSerialized]
	public HashSet<FatMan> fatMans;

	[NonSerialized]
	public HashSet<Driver> drivers;

	[NonSerialized]
	public HashSet<Sparker> sparkers;

	[NonSerialized]
	public HashSet<Strider> striders;

	[NonSerialized]
	public HashSet<Forb> forbs;

	[NonSerialized]
	public HashSet<Pterosaur> pterosaurs;

	[NonSerialized]
	public HashSet<PterosaurNest> pterosaurNests;

	[NonSerialized]
	public HashSet<MissileLauncher> missileLaunchers;

	[NonSerialized]
	public HashSet<Blob> blobs;

	[NonSerialized]
	public HashSet<Spore> spores;

	[NonSerialized]
	public HashSet<Sniper> snipers;

	[NonSerialized]
	public HashSet<AirSac> airsacs;

	[NonSerialized]
	public HashSet<AirSacBubble> airSacBubbles;

	[NonSerialized]
	public HashSet<AirSacBubble> eggs;

	[NonSerialized]
	public HashSet<Pod> pods;

	[NonSerialized]
	public HashSet<DeliveryPad> deliveryPads;

	[NonSerialized]
	public HashSet<DeliveryDrone> deliveryDrones;

	[NonSerialized]
	public HashSet<Shrapnel> shrapnel;

	[NonSerialized]
	public HashSet<Fab> fabs;

	[NonSerialized]
	public HashSet<Totem> totems;

	[NonSerialized]
	public HashSet<Factory> factories;

	[NonSerialized]
	public HashSet<ERNInterface> ernInterfaces;

	[NonSerialized]
	public HashSet<ERN> erns;

	[NonSerialized]
	public HashSet<Flope> flopes;

	[NonSerialized]
	public HashSet<Stash> stashes;

	[NonSerialized]
	public HashSet<SporeLauncher> sporeLaunchers;

	[NonSerialized]
	public HashSet<BlobNest> blobNests;

	[NonSerialized]
	public HashSet<SkimmerFactory> skimmerFactories;

	[NonSerialized]
	public HashSet<AirSacCauldron> airSacCauldrons;

	[NonSerialized]
	public HashSet<Denier> deniers;

	[NonSerialized]
	public HashSet<VineRoot> vineRoots;

	[NonSerialized]
	public HashSet<Terp> terps;

	[NonSerialized]
	public HashSet<TerpDrone> terpDrones;

	[NonSerialized]
	public HashSet<StraferPad> straferPads;

	[NonSerialized]
	public HashSet<BomberPad> bomberPads;

	[NonSerialized]
	public HashSet<ACBomberPad> acBomberPads;

	[NonSerialized]
	public HashSet<FlyingUnitManager> flyingUnits;

	[NonSerialized]
	public HashSet<Runway> runways;

	[NonSerialized]
	public HashSet<Reactor> reactors;

	[NonSerialized]
	public HashSet<RocketPad> rocketPads;

	[NonSerialized]
	public HashSet<Rocket> rockets;

	[NonSerialized]
	public HashSet<PayloadPad> payloadPads;

	[NonSerialized]
	public HashSet<Payload> payloads;

	[NonSerialized]
	public HashSet<Damper> dampers;

	[NonSerialized]
	public HashSet<Singularity> singularities;

	[NonSerialized]
	public HashSet<Rain> rains;

	[NonSerialized]
	public HashSet<Conversion> conversions;

	[NonSerialized]
	public HashSet<RainDrop> rainDrops;

	[NonSerialized]
	public HashSet<GreenarMother> greenarMothers;

	[NonSerialized]
	public HashSet<GreenarRefinery> greenarRefineries;

	[NonSerialized]
	public HashSet<GreenarDrone> greenarDrones;

	[NonSerialized]
	public HashSet<Ultrac> ultracs;

	[NonSerialized]
	public HashSet<CytocreepLauncher> cytocreepLaunchers;

	[NonSerialized]
	public HashSet<Shield> shields;

	[NonSerialized]
	public HashSet<Max> maxs;

	[NonSerialized]
	public HashSet<InfoCache> infocaches;

	[NonSerialized]
	public HashSet<ActivationAntenna> activationAntennas;

	[NonSerialized]
	public HashSet<Platform> platforms;

	[NonSerialized]
	public HashSet<SurviveBase> survivebases;

	[NonSerialized]
	public HashSet<UnitManager> mustCollect;

	public HashSet<int> greenarDroneFireTargets;

	private Dictionary<int, int> terpFireTargets;

	[NonSerialized]
	public HashSet<Vine> vines;

	[NonSerialized]
	public HashSet<Ware> wares;

	[NonSerialized]
	public int[] factoryInventoryCounts;

	[NonSerialized]
	public GameEventLog gameEventLog;

	[NonSerialized]
	public GameEventRollingData gameEventRollingData;

	[NonSerialized]
	public float avg_energyUse;

	[NonSerialized]
	public float avg_energyDeficit;

	[NonSerialized]
	public float avg_anticreeperUse;

	[NonSerialized]
	public float avg_anticreeperDeficit;

	[NonSerialized]
	public float avg_argUse;

	[NonSerialized]
	public float avg_argDeficit;

	[NonSerialized]
	public float avg_lifticUse;

	[NonSerialized]
	public float avg_lifticDeficit;

	[NonSerialized]
	public int supplyMax;

	[NonSerialized]
	public int supplyUsed;

	[NonSerialized]
	public float energyStore;

	[NonSerialized]
	public float ultracStore;

	[NonSerialized]
	public float anticreeperStore;

	[NonSerialized]
	public float argStore;

	[NonSerialized]
	public float lifticStore;

	[NonSerialized]
	public float soylentCount;

	[NonSerialized]
	public float energyProduction;

	[NonSerialized]
	public float energyProductionUnClamped;

	[NonSerialized]
	public float treeProduction;

	[NonSerialized]
	public float energyUse;

	[NonSerialized]
	public float energyDeficit;

	[NonSerialized]
	public float lastAnticreeperProduction;

	[NonSerialized]
	public float lastArgProduction;

	[NonSerialized]
	public float anticreeperProduction;

	[NonSerialized]
	public float anticreeperUse;

	[NonSerialized]
	public float anticreeperDeficit;

	[NonSerialized]
	public float argProduction;

	[NonSerialized]
	public float argUse;

	[NonSerialized]
	public float argDeficit;

	[NonSerialized]
	public FPS fps1;

	[NonSerialized]
	public FPS fps2;

	public Text fpsText;

	public UndoManager undo;

	[NonSerialized]
	public int currentUID;

	[NonSerialized]
	public bool step;

	[NonSerialized]
	public int mouseDown0Count;

	[NonSerialized]
	public int mouseDown1Count;

	[NonSerialized]
	public int mouseDown2Count;

	[NonSerialized]
	public int mouseDown3Count;

	[NonSerialized]
	public int mouseDown4Count;

	[NonSerialized]
	public int mouseUp0Count;

	[NonSerialized]
	public int mouseUp1Count;

	[NonSerialized]
	public int mouseUp2Count;

	[NonSerialized]
	public int mouseUp3Count;

	[NonSerialized]
	public int mouseUp4Count;

	[NonSerialized]
	public float mouseScrollDelta;

	[NonSerialized]
	public GameRecorder gameRecorder;

	private bool _paused;

	private HashSet<string> pauseOwner;

	[NonSerialized]
	public bool _mversePaused;

	[NonSerialized]
	public bool superPause;

	public static bool import2xHeight;

	private int lastScreenWidth;

	private int lastScreenHeight;

	private int lastScreenResolutionWidth;

	private int lastScreenResolutionHeight;

	private static int insertedCount;

	private AudioObject ambientSound;

	public MissionScanner missionScanner;

	private long missionStartTime;

	[NonSerialized]
	public long missionRealTime;

	[NonSerialized]
	public long missionLastRealTime;

	private bool halfRate;

	[NonSerialized]
	public int frameUpdateCount;

	private int tfrCount;

	[NonSerialized]
	public bool throttledFrameRate;

	[NonSerialized]
	public HashSet<Texture2D> texturesToApply;

	private int throttleLag;

	private int PREVSECTORCOUNT;

	private int PREVSECTORLOC;

	[NonSerialized]
	public bool creeperPanelsUpdated;

	private long lastCreeperTotal;

	private int skipPanelCount;

	private long lastFixedTime;

	private UnitManager[] transientUnitArray;

	private UnitManager[] transientLateUnitArray;

	private Vine[] transientVineArray;

	private Packet[] transientPacketArray;

	private ParticleSystemManager[] transientParticleSystemManagerArray;

	private ParticleTrailManager[] transientParticleTrailManagerArray;

	private Animus[] transientAnimusArray;

	private int searcherID;

	[NonSerialized]
	public bool speedFrame;

	private Dictionary<KeyCode, int> keyCodesDown;

	private Dictionary<string, int> mappedKeyCodesDown;

	[NonSerialized]
	public int myFixedUpdateCount;

	[NonSerialized]
	public int tickCount;

	private ManualResetEvent resetEvent;

	private List<UnitManager> packetRequesters;

	private List<UnitManager> packetWareRequesters;

	private int MAX_DELTATIME;

	private long creeperIntervalTotal;

	private Queue<double> creeperHistory;

	private float rollingAmbientPitch;

	[NonSerialized]
	public int[] currentStoredWares;

	[NonSerialized]
	public int[] currentPlanWares;

	[NonSerialized]
	public bool shouldRefreshCollectors;

	[NonSerialized]
	public int jimmyUID;

	[NonSerialized]
	public bool gameComplete;

	private int sendMSGCount;

	[NonSerialized]
	public bool showFinalDialog;

	private bool cameraAtGameEndMoved;

	[NonSerialized]
	public Dictionary<int, TerrainDecal> decalUIDTable;

	private Dictionary<string, RplCore> registeredCores;

	[NonSerialized]
	public Dictionary<int, UnitManager> unitUIDTable;

	public bool gameSpaceDestroyed;

	private StreamWriter sw;

	private static bool ALLOWQUIT;

	public bool editedEver
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public string title
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool paused => false;

	public void AddTerpFireTarget(int x, int y, bool ignoreMVerse = false)
	{
	}

	public void RemoveTerpFireTarget(int x, int y, bool ignoreMVerse = false)
	{
	}

	public bool ContainsTerpFireTarget(int x, int y)
	{
		return false;
	}

	public void OnUIScaleChanged(float scale)
	{
	}

	public void Pause(string owner, bool value)
	{
	}

	public bool GetPauseByOwner(string owner)
	{
		return false;
	}

	public void ReturnAmpGem(int amt)
	{
	}

	public bool TakeAmpGem()
	{
		return false;
	}

	private void ImportCW3Map()
	{
	}

	private void OnDisable()
	{
	}

	private void CheckForResolutionChange()
	{
	}

	public void ClearPrintLog()
	{
	}

	public static void InsertDocs(string fileFrom, string fileTo)
	{
	}

	public static string GetLeadingWhitespace(string line)
	{
		return null;
	}

	private static void InsertBlock(List<string> block, string fileTo)
	{
	}

	public void CreateGameRecorder()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void StartMission()
	{
	}

	private void CreateProceduralGame(ProceduralMap map)
	{
	}

	private void GetSectorTotalsNow(long[] data, int[] digData)
	{
	}

	private long[] GetSectorTotalsForOffset(int offset)
	{
		return null;
	}

	private int[] GetSectorDigTotalsForOffset(int offset)
	{
		return null;
	}

	private long GetSectorTimeForOffset(int offset)
	{
		return 0L;
	}

	public long[] GetSectorTotalsForTime(long time)
	{
		return null;
	}

	public int[] GetSectorDigTotalsForTime(long time)
	{
		return null;
	}

	public static long GetMSTime()
	{
		return 0L;
	}

	public void UpdateSectorTotals()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	public bool GetMouseButtonDown(int i)
	{
		return false;
	}

	public bool GetMouseButtonUp(int i)
	{
		return false;
	}

	public bool GetKeyDown(KeyCode kc)
	{
		return false;
	}

	public bool GetMappedKeyDown(string kc)
	{
		return false;
	}

	public MVersePlayerPrefab GetMVersePlayerPrefab(string playerName)
	{
		return null;
	}

	private bool GetMVerseSyncTimePause()
	{
		return false;
	}

	private void SendMVerseExcessEnergy(float amt)
	{
	}

	private void MyFixedUpdate()
	{
	}

	public void PopEggs(float prob, bool depositPayload)
	{
	}

	private double CalculateTrendlineSlope(List<double> graph)
	{
		return 0.0;
	}

	private void RefreshInventoryTotals()
	{
	}

	public void MoveUnitsToMatchTerrain()
	{
	}

	public void UpdateAllUnitsOfTerrainChanges()
	{
	}

	public void UpdateUnitsOfTerrainChanges(int gsx, int gsy, int extraRange)
	{
	}

	public void UpdateUnitsOfTerrainChangesOLD(int cellX, int cellY, int range)
	{
	}

	public void RefreshCollectors()
	{
	}

	public void AddWareHolder(UnitManager um, int wareType)
	{
	}

	public void RemoveWareHolder(UnitManager um, int wareType)
	{
	}

	public HashSet<UnitManager> GetBlobMap(int cellX, int cellY)
	{
		return null;
	}

	public int GetBlobMapCount(int cellX, int cellY)
	{
		return 0;
	}

	public void AddToBlobMap(int cellX, int cellY, Blob b)
	{
	}

	public void RemoveFromBlobMap(int cellX, int cellY, Blob b)
	{
	}

	public Vector3 GetTotemRiftLocation()
	{
		return default(Vector3);
	}

	public Vector3 GetActivationAntennaRiftLocation()
	{
		return default(Vector3);
	}

	public Vector2 GetRandomTarget(int seed = 0)
	{
		return default(Vector2);
	}

	public Vector2 GetPlayerStructureTarget(out bool targetExists, double seed = 0.0)
	{
		targetExists = default(bool);
		return default(Vector2);
	}

	public Vector2 GetPlayerTarget(out bool targetExists, double seed = 0.0)
	{
		targetExists = default(bool);
		return default(Vector2);
	}

	public Vector2 GetDefenseTarget(double seed = 0.0)
	{
		return default(Vector2);
	}

	private void DispatchPacketWares(List<UnitManager> packetWareRequesters)
	{
	}

	private void GetDispatcherForPacketWareOLD(UnitManager um, out UnitManager dispatcher, out int wareNum)
	{
		dispatcher = null;
		wareNum = default(int);
	}

	public bool IsDispatcherAvailable(UnitManager um, int wareType)
	{
		return false;
	}

	private UnitManager GetNearestWareDispatcher(UnitManager um, int wareType)
	{
		return null;
	}

	private void DispatchPackets(List<UnitManager> packetRequesters, List<UnitManager> collectorPacketRequesters)
	{
	}

	private IPacketDispatcher GetDispatcherForPacket(UnitManager u)
	{
		return null;
	}

	private IPacketDispatcher GetNearestConnectedEnergySource(UnitManager um)
	{
		return null;
	}

	public HashSet<UnitManager> GetUnitsFromFootprintBigBlock(int cellX, int cellY)
	{
		return null;
	}

	public List<UnitManager> GetUnitsFromFootprint(int cellX, int cellY)
	{
		return null;
	}

	public UnitManager GetUnitFromFootprint(int cellX, int cellY)
	{
		return null;
	}

	public float GetUnitHeightAtPos(int cellX, int cellY, bool includeTerrain, out List<UnitManager> units)
	{
		units = null;
		return 0f;
	}

	public int GetUID()
	{
		return 0;
	}

	public int RandRange(int min, int max)
	{
		return 0;
	}

	public float RandFloatRange(float min, float max)
	{
		return 0f;
	}

	public int Rand()
	{
		return 0;
	}

	public double RandDouble()
	{
		return 0.0;
	}

	public float RandFloat()
	{
		return 0f;
	}

	public double RandDoubleInput(double i)
	{
		return 0.0;
	}

	public Vector2 RandCircle(float R)
	{
		return default(Vector2);
	}

	public int RandRangeSeed(double i, int min, int max)
	{
		return 0;
	}

	public double RandDoubleSeed(double i)
	{
		return 0.0;
	}

	public string GetCurrentGameTimeString()
	{
		return null;
	}

	public static string GetTimeString(float sec, bool onlySec = false)
	{
		return null;
	}

	public static string GetTimeStringNoFrac(float sec)
	{
		return null;
	}

	public void ResetTime()
	{
	}

	public void ResetAllData()
	{
	}

	public void OnEvac()
	{
	}

	public void SendMSG(string channel, RplCore.Data data)
	{
	}

	public void AddCoreToMSGCallbackTable(string key, string functionName, RplCore core)
	{
	}

	public void RemoveCoreFromMSGCallbackTable(string key, RplCore core)
	{
	}

	private void HandleMissionCompletionAchievements()
	{
	}

	public static void UpdateStoryCompletion(bool suppressSteam = false)
	{
	}

	public void HandleGameCompletion(bool victory, bool immediate)
	{
	}

	private void ShowFinalDialog()
	{
	}

	private void ExitMouseLook()
	{
	}

	public void ShowCompletionPopups(bool success = true)
	{
	}

	public void CheckForVictory()
	{
	}

	public bool IsProgressiveMode()
	{
		return false;
	}

	public int GetProgressiveMultiplier()
	{
		return 0;
	}

	public int GetProgressionNextTime(out int level)
	{
		level = default(int);
		return 0;
	}

	public Texture2D GetPreviewTexture(float zoom = 4f)
	{
		return null;
	}

	public Texture2D GetScreenShotTexture(bool fullMap, float zoom = 26f)
	{
		return null;
	}

	public Texture2D GetScreenShotTexture(bool fullMap, float zoom, bool preview, bool hideUI)
	{
		return null;
	}

	public void TakeScreenShot(bool fullMap, bool hideUI)
	{
	}

	private HashSet<Resource> GetBlueResources()
	{
		return null;
	}

	private HashSet<Resource> GetRedResources()
	{
		return null;
	}

	private HashSet<Wall> GetWalls(bool crazonium)
	{
		return null;
	}

	public string GetUnitType(UnitManager um)
	{
		return null;
	}

	public IEnumerable GetUnitsByType(string unitType)
	{
		return null;
	}

	public static void LoadGame(string fileToLoad, bool embeddedLoad, bool editMode, bool importMap, CATEGORY category, int colonyID)
	{
	}

	public static void ReassignConstantsC(int w, int h)
	{
	}

	public TerrainDecal GetDecalByUID(int UID)
	{
		return null;
	}

	public void LoadEmbeddedCPack(string cpackName)
	{
	}

	public void UnloadEmbeddedCPack(string cpackName)
	{
	}

	public void RegisterCore(string name, RplCore core)
	{
	}

	public void DeregisterCore(string name)
	{
	}

	public RplCore GetRegisteredCore(string name)
	{
		return null;
	}

	public UnitManager GetUnitByTrueGUID(string trueGUID)
	{
		return null;
	}

	public T GetUnitByTrueGUID<T>(string trueGUID) where T : class
	{
		return null;
	}

	public UnitManager GetUnitByUID(int UID)
	{
		return null;
	}

	public void SetUnitByUID(int UID, UnitManager m)
	{
	}

	public void LeavingGame()
	{
	}

	public void OnDestroy()
	{
	}

	public static bool IsDestroyed()
	{
		return false;
	}

	public void AppendToPrintFile(string val)
	{
	}

	public static void DestroyObj(UnityEngine.Object obj)
	{
	}

	public void AutoSave()
	{
	}

	public bool WantsToQuit()
	{
		return false;
	}

	public void ExitGameConfirmed()
	{
	}
}
