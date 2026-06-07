using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Log;
using DG.Tweening;
using Newtonsoft.Json.Linq;
using QFSW.MOP2;
using SuperTiled2Unity;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using VampireSurvivors.App.Data;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Scripts.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects
{
	[BurstCompile]
	public class Stage : GameMonoBehaviour
	{
		[SerializeField]
		private TilingBackground _TilingBackgroundPrefab;

		[SerializeField]
		private TilingTileset _TilingTilesetPrefab;

		[SerializeField]
		private Transform _LevelTransform;

		private static List<CharacterType> _validStageCharacters;

		private StageType _stageType;

		private int _currentMinute;

		private int _maxStageDataMinute;

		private int _maximum;

		private int _lastMinimum;

		private int _lastMaximum;

		private int _defaultMaximum;

		private float _minMultiplier;

		private float _onlineEnemyMultiplier;

		private float _effectiveSpawnFrequency;

		private JObject _stageJsonData;

		private StageData _stageData;

		private StageData _baseStageData;

		private Dictionary<int, JArray> _stageDataByBiome;

		private bool _hasTileSet;

		private SpawnType _spawnType;

		private bool _hasAttachedTreasure;

		private bool _compressTime;

		private float _pizzaDelay;

		private const float PizzaIntervalMillis = 20000f;

		private const int BulletAllowance = 50;

		private Timer _pauseTimer;

		private Timer _spawnTimer;

		private Timer _destructibleTimer;

		private Timer _checkPizzasTimer;

		private readonly List<Vector2> _enemySpawnLocations;

		private readonly List<Vector2> _destructibleLocations;

		private List<Vector2> _cartLocations;

		private List<Vector2> _windowLocations;

		private List<Vector2> _pizzaLocations;

		private readonly List<PizzaCircle> _pizzaCircles;

		private List<Vector2> _tiledPositions;

		private List<Rectangle> _noShadowLocations;

		private Timer _noShadowsTimer;

		private bool _shadowsVisible;

		private MultiTargetTween _shadowsTween;

		private Rect _spawnOuterRect;

		private Rect _spawnInnerRect;

		private Rect _containmentScreenRect;

		private Rect _containmentExactRect;

		private Rect _tiledOuterRect;

		private Rect _tiledInnerRect;

		private float _widthRect;

		private float _heightRect;

		private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> _spawnOuterRects;

		private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> _spawnInnerRects;

		private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, Rect> _playerRects;

		private readonly List<EnemyController> _spawnedEnemies;

		private readonly HashSet<EnemyController> _authoritativePermanentEnemies;

		private static Coherence.Log.Logger _logger;

		private bool _hasWallsCheckDestructibleLogic;

		private bool _isCharmApplied;

		private bool _disableMinueteSpawning;

		private Transform _cachedTransform;

		private Camera _mainCamera;

		private SignalBus _signalBus;

		private DataManager _dataManager;

		private PlayerOptions _playerOptions;

		private StageEventManager _stageEventManager;

		private StageEventTrisectionManager _trisection;

		private GlimmerManager _glimmerManager;

		private StageEventTwitchManager _stageEventTwitchManager;

		private GameSessionData _gameSessionData;

		private DiContainer _diContainer;

		private TilingBackground _tilingBackground;

		private TilingTileset _tilingTileset;

		private EnemyFactory _enemyFactory;

		private DestructibleFactory _destructibleFactory;

		private ArcanaManager _arcanaManager;

		private BackgroundManager _fancyBg;

		private GameManager _gameManager;

		private LobbiesManager _lobbiesManager;

		private PhaserSprite _beam;

		private PhaserSprite _whiteFader;

		private List<EnemyType?> _enemyTypes;

		private List<EnemyType?> _bossTypes;

		private readonly Dictionary<EnemyType, bool> _enemyPoolStates;

		private readonly Dictionary<EnemyType, bool> _bossPoolStates;

		public float _ShadowAlpha;

		public float _SoleShadowAlpha;

		private StageData _tmpStageData;

		private MultiTargetTween _teleportVfxTween;

		private static readonly ProfilerMarker MarkerSpawnEnemy;

		private static readonly ProfilerMarker MarkerFindClosestEnemy;

		private SortedList<uint, EnemyController> _queryEnemiesCache;

		private List<EnemyController> _unsortedEnemiesCache;

		private List<Pickup> _onScreenPickupsCache;

		private static readonly ProfilerMarker MarkerHandleSpawning;

		private static readonly ProfilerMarker MarkerSpawnEnemyUnit;

		private static readonly ProfilerMarker MarkerSpawnEnemyResolve;

		private static readonly ProfilerMarker MarkerUpdateCulling;

		private int _cullIterator;

		private List<EnemyController> _enemiesToCull;

		private static readonly ProfilerMarker MarkerDespawnEnemyIfOutsideRect;

		public PickupMerchant TrouserMerchant;

		public static List<CharacterType> ValidStageCharacters => null;

		public float OnlineEnemyMultiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool DisableMinueteSpawning
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<Weapon> StageHazardWeapons { get; set; }

		public DestructibleFactory DestructibleFactory => null;

		public StageEventTrisectionManager Trisection => null;

		public GlimmerManager GlimmerManager => null;

		public Rect ContainmentExactRect => default(Rect);

		public bool HasInitialized { get; private set; }

		public List<EnemyController> SpawnedEnemies => null;

		public int EnemiesCount => 0;

		public SpawnType SpawnType
		{
			get
			{
				return default(SpawnType);
			}
			set
			{
			}
		}

		public int PermanentEnemiesNumber => 0;

		public StageData ActiveStageData => null;

		public Rect SpawnOuterRect => default(Rect);

		public Rect SpawnInnerRect => default(Rect);

		public Rect ContainmentScreenRect => default(Rect);

		public List<Vector2> EnemySpawnLocations => null;

		public bool HasTileSet => false;

		public StageEventManager StageEventManager => null;

		public StageEventTwitchManager StageEventTwitchManager => null;

		public GameSessionData GameSessionData => null;

		public TilingTileset TilingTileset => null;

		public TilingBackground TilingBackground => null;

		public float EnemyHealthMultiplier { get; set; }

		public float EnemySpeedMultiplier { get; set; }

		public List<ItemType> LootTable => null;

		public BackgroundManager FancyBg => null;

		public LobbiesManager LobbiesManager => null;

		public List<Vector2> DestructibleLocations => null;

		public int MaxDestructibles { get; set; }

		public float Pause { get; set; }

		public bool HasLights => false;

		public bool HasCharacterSpotlight => false;

		public bool StopCheckingMinutes { get; set; }

		public List<PizzaCircle> PizzaCircles => null;

		public StageType StageType => default(StageType);

		public PropType DestructibleType => default(PropType);

		public StageModifiers StageMods { get; set; }

		public List<EnemyType?> BossTypes => null;

		public List<EnemyType?> EnemyTypes
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Maximum
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int LastMinimum
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int LastMaximum
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float? MinTreasureY { get; set; }

		public float? MaxTreasureY { get; set; }

		public float? MinTreasureX { get; set; }

		public float? MaxTreasureX { get; set; }

		public Rect EnemiesDespawnRect => default(Rect);

		public EnemyFactory EnemyFactory => null;

		public bool PoolsInitialized { get; private set; }

		private float Frequency => 0f;

		private float DestructibleFrequency => 0f;

		private bool IsMerchantBanned => false;

		public int CurrentMinute => 0;

		private int StartingSpawns => 0;

		[Inject]
		private void Construct(DataManager dataManager, PlayerOptions playerOptions, SignalBus signalBus, GameSessionData gameSessionData, DiContainer diContainer, EnemyFactory enemyFactory, DestructibleFactory destructibleFactory, ArcanaManager arcanaManager, GameManager gameManager, LobbiesManager lobbiesManager)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public static List<CharacterType> GetValidStageXCharacters()
		{
			return null;
		}

		public static bool HasValidStageXCharacters()
		{
			return false;
		}

		public static bool HasAllNonVoidCharacters()
		{
			return false;
		}

		public static List<CharacterType> GetValidAnyStageCharacters()
		{
			return null;
		}

		public static List<StageType> GetValidUnlockedHypers()
		{
			return null;
		}

		public static List<StageType> GetValidUnlockedStages()
		{
			return null;
		}

		public void InitStage(StageType stageType)
		{
		}

		public void DoTeleportVfx(float2 position, TweenCallback onComplete, Action onYoyo)
		{
		}

		private void MakeDoorVfx()
		{
		}

		private static int AddFollower(FollowerData followerData, VampireSurvivors.Objects.Characters.CharacterController playerOne, int lastPlayerindex)
		{
			return 0;
		}

		private void SetupStageDataByBiome(StageType stageType)
		{
		}

		private void SetupStageDataByBiomeInternal<TBiome>(StageType stageType) where TBiome : struct, Enum
		{
		}

		public void InitStagePostLoad()
		{
		}

		public SuperObject GetHardBoundsObjFromTMX()
		{
			return null;
		}

		private void SetHardBoundsFromTMX()
		{
		}

		private void SetHardBoundsFromStageData()
		{
		}

		public void CheckHalfMinute()
		{
		}

		public void CheckMinute()
		{
		}

		public void OnCycleComplete()
		{
		}

		public void DebugNextMinute()
		{
		}

		public void DebugNextHalfMinute()
		{
		}

		public void DebugLastMinute()
		{
		}

		public void Cleanup()
		{
		}

		public void CancelSpawnTimer()
		{
		}

		public Weapon AddStageHazardWeapon(WeaponType weaponType)
		{
			return null;
		}

		public GameObject SpawnEnemy(EnemyType enemyType, Vector2 spawnPos, bool asRemote = false, bool forceSpawn = false)
		{
			return null;
		}

		public GameObject SpawnEnemyInOuterRect(EnemyType enemyType, bool checkWalls = false, bool forceSpawn = false)
		{
			return null;
		}

		public T SpawnEnemy<T>(EnemyType enemyType, Vector2 spawnPos, bool asRemote = false, bool forceSpawn = false) where T : EnemyController
		{
			return null;
		}

		public void DebugSpawnMaxEnemies()
		{
		}

		public void DebugSpawnAllEnemies()
		{
		}

		public void CalculateEnemySpeed()
		{
		}

		public void RecalculateCurseAndCharm()
		{
		}

		public void ResetStageMinimumSpawnToDefault()
		{
		}

		public void ResetStageMaximumSpawnToDefault()
		{
		}

		public void SetSpawnType(SpawnType type)
		{
		}

		public void SetWallsCheckDestructibleAndEnemiesLogic(bool value)
		{
		}

		public void StartTimers()
		{
		}

		public void CancelTimers()
		{
		}

		public EnemyController ClosestAlive(Vector3 queryPos, float maxRange = 3.4028235E+38f)
		{
			return null;
		}

		public EnemyController FindClosestEnemy(Vector3 queryPos, bool excludeDead = false, float maxRange = 3.4028235E+38f)
		{
			return null;
		}

		public EnemyController FindClosestLateralEnemy(Vector3 queryPos, bool excludeDead = false, float maxRange = 3.4028235E+38f, bool checkLeft = true)
		{
			return null;
		}

		public List<EnemyController> GetClosestEnemiesSorted(Vector3 queryPos, bool excludeDead = false, float maxRange = 3.4028235E+38f)
		{
			return null;
		}

		public EnemyController PickRandomEnemyController(ref Unity.Mathematics.Random rng)
		{
			return null;
		}

		public Transform PickRandomEnemy(ref Unity.Mathematics.Random rng)
		{
			return null;
		}

		public Transform PickRandomEnemyInScreenBounds(ref Unity.Mathematics.Random rng)
		{
			return null;
		}

		public Transform PickRandomEnemyInRectBounds(Rectangle _rect, ref Unity.Mathematics.Random rng)
		{
			return null;
		}

		public void GetEnemyBodiesInRect(Rectangle _rect, ref List<BaseBody> list)
		{
		}

		private EnemyController PickRandomEnemyFromList(IList<EnemyController> enemiesList, ref Unity.Mathematics.Random rng)
		{
			return null;
		}

		public Transform PickRandomEnemyInCircle(float2 position, float radius, ref Unity.Mathematics.Random rng)
		{
			return null;
		}

		public List<EnemyController> GetEnemiesInCircle(float2 position, float radius)
		{
			return null;
		}

		public List<EnemyController> GetAllEnemiesInScreenBounds()
		{
			return null;
		}

		public List<EnemyController> GetAllEnemiesInScreenBounds(float excludedBorderPercentage01)
		{
			return null;
		}

		public void DebugSpawnDestructibles(float percentage = 1f)
		{
		}

		public Destructible MakeDestructible(PropType destructibleType, Vector2 pos)
		{
			return null;
		}

		public List<Destructible> GetAllDestructiblesInScreenBounds()
		{
			return null;
		}

		public List<Pickup> GetAllPickupsInScreenBounds()
		{
			return null;
		}

		public List<Pickup> GetAllGemsInScreenBounds()
		{
			return null;
		}

		public List<Pickup> GetAllFrozenSoulsInScreenBounds()
		{
			return null;
		}

		public void FireEnemyBulletAt(Vector2 spawnPos, EnemyType bulletType = EnemyType.BULLET_1)
		{
		}

		private void SpawnEnemyBullet(Vector2 spawnPos, EnemyType bulletType = EnemyType.BULLET_1)
		{
		}

		public Vector2 GetBossyPosition(VampireSurvivors.Objects.Characters.CharacterController player = null)
		{
			return default(Vector2);
		}

		public void SpawnMerchant()
		{
		}

		public PickupCustomMerchant SpawnStaticCustomMerchant(CharacterType merchantType, Vector2 spawnPos)
		{
			return null;
		}

		public void SpawnCustomMerchants(List<CharacterType> merchantTypes)
		{
		}

		private bool ShouldWeSeeShadowLayer()
		{
			return false;
		}

		public void CheckShadows()
		{
		}

		public void ToggleShadows(bool value)
		{
		}

		public int SetTreasureLevelFromChance(Treasure treasure)
		{
			return 0;
		}

		public void SpawnStaticAdventureMerchant(CharacterType merchantType, float2 spawnPos)
		{
		}

		private void InitRects()
		{
		}

		private void LogRectInfo(string rectName, Rect rect)
		{
		}

		private void InitTiledPositions()
		{
		}

		private void UpdateRectPositions()
		{
		}

		private void UpdateRectForPlayer(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		private void PreloadAssets()
		{
		}

		private void UnloadAssets()
		{
		}

		private void SetupFancyBackground()
		{
		}

		private void UpdateTimers()
		{
		}

		private void PlayEvents()
		{
		}

		public bool GetStageDataForMinute(int minute, StageType stageType, out StageData stageData, out JObject stageJsonObject)
		{
			stageData = null;
			stageJsonObject = null;
			return false;
		}

		public bool GetStageDataForMinute(int minute, StageType stageType, out JObject stageJsonObject)
		{
			stageJsonObject = null;
			return false;
		}

		public void RemoveCharm()
		{
		}

		public void ApplyCharm()
		{
		}

		private void UpdateAllData(JObject stageJsonObject)
		{
		}

		private int GetCharmForMinute(int minute)
		{
			return 0;
		}

		private void ResetStageDataForUpdate()
		{
		}

		private void UpdateMinuteData()
		{
		}

		private StageData CompressTime(JObject originalData)
		{
			return null;
		}

		private void ReleasePool()
		{
		}

		public void UpdateNormalEnemyPoolsOnly(List<EnemyType?> enemies)
		{
		}

		public void UpdateEnemyPools(List<EnemyType?> enemies, List<EnemyType?> bosses)
		{
		}

		public Vector2? GetPickupPositionOutOfSight(float _movementAngle = 45f)
		{
			return null;
		}

		private void HandleDestructibleSpawning()
		{
		}

		public void SpawnChosenDestructiblesInClosestLocations(PropType _propType, int number)
		{
		}

		public void SpawnChosenDestructiblesInClosestLocations(PropType _propType, int number, Vector2 position)
		{
		}

		public void SortByDistance(Vector2 position)
		{
		}

		public void SpawnChosenDestructibleInRandomLocation(PropType _propType)
		{
		}

		private void SpawnDestructibleInRandomLocation()
		{
		}

		public void SpawnChosenDestructibleWallsCheck(PropType _propType, bool force = false)
		{
		}

		private void SpawnChosenDestructibleWallsCheckForPlayer(VampireSurvivors.Objects.Characters.CharacterController player, Rect spawnOuterRect, Rect spawnInnerRect, PropType _propType, bool force)
		{
		}

		private void SpawnDestructibleWallsCheck()
		{
		}

		private void SpawnCartInRandomLocation()
		{
		}

		private VampireSurvivors.Objects.Characters.CharacterController GetRandomCharacter()
		{
			return null;
		}

		private void SpawnWindowInRandomLocation()
		{
		}

		public Destructible SpawnPropInRandomLocation(float baseChance, PropType propType, ref List<Vector2> positions)
		{
			return null;
		}

		public List<Destructible> SpawnPropInAllLocations(PropType propType, ref List<Vector2> positions)
		{
			return null;
		}

		public int ActivateProps(PropType propType, ref List<SuperObject> scripts)
		{
			return 0;
		}

		private List<Vector2> GetLocationsOutOfSight(List<Vector2> locations, VampireSurvivors.Objects.Characters.CharacterController character)
		{
			return null;
		}

		public void SpawnChocenDestructibleOutOfSight(PropType propType, bool force = false, float distance = 0f)
		{
		}

		public bool IsCharacterNearYourPlayer(VampireSurvivors.Objects.Characters.CharacterController character)
		{
			return false;
		}

		private List<VampireSurvivors.Objects.Characters.CharacterController> GetGroupedPlayersBasedOnDistance()
		{
			return null;
		}

		private void SpawnDestructibleOutOfSight(bool force = false)
		{
		}

		private void DespawnFarDestructibles(ObjectPool pool)
		{
		}

		private void HandleSpawning(bool checkMaxEnemyCount = true)
		{
		}

		private bool HasReachedMaxEnemies()
		{
			return false;
		}

		private bool SpawnEnemiesInOuterRect()
		{
			return false;
		}

		private bool CanSpawnEnemies()
		{
			return false;
		}

		private void SpawnEnemiesTiled()
		{
		}

		private void SpawnEnemiesMapped()
		{
		}

		private int UpdateCurrentEnemies()
		{
			return 0;
		}

		private int GetSpawnData(out int currentEnemies, out float minimumEnemies)
		{
			currentEnemies = default(int);
			minimumEnemies = default(float);
			return 0;
		}

		private List<EnemyType> GetAllEnabledPools()
		{
			return null;
		}

		private void SpawnEnemiesInRandomLocationHorizontal()
		{
		}

		private void SpawnEnemiesInRandomLocationHorizontalSmoothed()
		{
		}

		private void SpawnEnemiesInRandomLocationVertical()
		{
		}

		public void SwarmCheck()
		{
		}

		private EnemyController SpawnEnemyUnit(ObjectPool pool, EnemyType enemyType, Vector2 spawnPos, bool asRemote)
		{
			return null;
		}

		public void SpawnBoss()
		{
		}

		public void SpawnBatGoblin()
		{
		}

		public EnemyController SpawnMadMoonBlinder()
		{
			return null;
		}

		private GameObject SpawnEnemyUsingSpawnType(EnemyType enemyType)
		{
			return null;
		}

		private GameObject SpawnOneUnitInOuterRect(EnemyType poolName, bool checkWalls = false, bool forceSpawn = false)
		{
			return null;
		}

		private bool IsPointWithinOtherPlayerRects(Vector2 point)
		{
			return false;
		}

		private GameObject SpawnOneUnitInRandomLocationHorizontal(EnemyType poolName, bool forceSpawn = false)
		{
			return null;
		}

		private GameObject SpawnOneUnitInRandomLocationHorizontalSmoothed(EnemyType poolName, bool forceSpawn = false)
		{
			return null;
		}

		private Vector2 GetHorizontalSpawnPosition()
		{
			return default(Vector2);
		}

		private Vector2 GetHorizontalSmoothedSpawnPosition()
		{
			return default(Vector2);
		}

		private GameObject SpawnOneUnitInRandomLocationVertical(EnemyType poolName, bool forceSpawn = false)
		{
			return null;
		}

		private Vector2 GetVerticalSpawnPosition()
		{
			return default(Vector2);
		}

		private GameObject SpawnOneUnitOutOfSight(EnemyType poolName)
		{
			return null;
		}

		private void SpawnArcanaHolder()
		{
		}

		public Vector2 GetPositionWithinSight(VampireSurvivors.Objects.Characters.CharacterController player, float inPlayerDirectionAngle, float distance = 0f)
		{
			return default(Vector2);
		}

		private Vector2 GetPositionOutOfSight(Vector2 playerPos)
		{
			return default(Vector2);
		}

		public Vector2 GetPositionOutOfSight(VampireSurvivors.Objects.Characters.CharacterController player, float inPlayerDirectionAngle, float distance = 0f)
		{
			return default(Vector2);
		}

		private void UpdateCulling()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool ShouldDespawnEnemyOutsideRect(EnemyController element)
		{
			return false;
		}

		private void OnEnemyKilled(GameplaySignals.RemoveEnemyFromStageSignal signal)
		{
		}

		private void GenerateTilingTileset()
		{
		}

		private void InitTilingTileset()
		{
		}

		public IEnumerable<Vector2> GetLocationsFromMapObjectLayer(string objectLayerName)
		{
			return null;
		}

		private void CalcMinMaxTreasures()
		{
		}

		private void HandleCartsAndPizzas()
		{
		}

		private void CheckPizzas()
		{
		}

		private void TriggerPizzaEvent(PizzaCircle pizzaCircle, VampireSurvivors.Objects.Characters.CharacterController triggeringPlayer)
		{
		}

		public void ShowPizzaWarning(PizzaCircle pizzaCircle)
		{
		}

		private void GenerateTilingBackground()
		{
		}

		private void SpawnYellowItems()
		{
		}

		private void SpawnAdventureMerchants()
		{
		}

		private void SpawnCustomAdventureMerchant(CustomMerchantData customMerchantData)
		{
		}

		private bool CheckCanSpawnAdventureMerchant(CustomMerchantData customMerchantData)
		{
			return false;
		}

		public bool ShouldShowCursor(float2 position)
		{
			return false;
		}

		private PickupCustomMerchant SpawnCustomMerchant(CustomMerchantData customMerchantData)
		{
			return null;
		}

		private bool CheckCanSpawnCustomMerchant(CustomMerchantData customMerchantData)
		{
			return false;
		}

		private void ForceRepositionMerchants()
		{
		}

		private void PositionAllCustomMerchants(List<PickupCustomMerchant> spawnedMerchants)
		{
		}

		private bool DoesNewPositionOverlapMerchants(List<float2> positionsToAvoid, float2 newPos)
		{
			return false;
		}
	}
}
