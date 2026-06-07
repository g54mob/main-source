using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using QFSW.MOP2;
using Rewired;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Scripts.Framework;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Scripts.Objects.VFX;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.Cheats;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;
using VampireSurvivors.Spells;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors.Framework
{
	public class GameManager : GameMonoBehaviour
	{
		public class ZoomSize
		{
			public float _currentSize;
		}

		[CompilerGenerated]
		private sealed class _003CFirePlayerXpUpdatedFromOnlineRoutine_003Ed__608 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFirePlayerXpUpdatedFromOnlineRoutine_003Ed__608(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CInitRemoteCharacterWhenGameplayLoaded_003Ed__574 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameManager _003C_003E4__this;

			public GameObject characterInstance;

			public CharacterType characterType;

			private PlayerInfo _003CmyPlayerInfo_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CInitRemoteCharacterWhenGameplayLoaded_003Ed__574(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CReenableBrokenShadowCasterGroup2DsBecauseUnity_003Ed__642 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CReenableBrokenShadowCasterGroup2DsBecauseUnity_003Ed__642(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CRemoveManualCameraControl_003Ed__455 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameManager _003C_003E4__this;

			private VampireSurvivors.Objects.Characters.CharacterController _003CmyPlayer_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRemoveManualCameraControl_003Ed__455(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CSignalGameplayLoaded_003Ed__584 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSignalGameplayLoaded_003Ed__584(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CSnapshotRecap_003Ed__449 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameManager _003C_003E4__this;

			public Action onComplete;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSnapshotRecap_003Ed__449(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWaitForAllCharactersToBeLoaded_003Ed__578 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitForAllCharactersToBeLoaded_003Ed__578(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWaitForEveryoneToResetGameSession_003Ed__446 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			private bool _003CeveryoneResetSession_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitForEveryoneToResetGameSession_003Ed__446(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public const float BASE_PLAYER_PX_SPEED = 0.82500005f;

		public const float BASE_ENEMY_SPEED = 0.231f;

		public const float BASE_PROJECTILE_SPEED = 1.6500001f;

		public const int BASE_GOLD_MULTIPLIER = 1;

		public const float BASE_ENEMY_HEALTH_MULTIPLIER = 1f;

		public const float BASE_EXPERIENCE_MULTIPLIER = 1f;

		public const float BASE_MARKUP = 0.1f;

		public const float PPU = 100f;

		public const float UNITY_SCALE = 0.01f;

		public const double INVERSE_UNITY_SCALE = 100.0;

		public const float PIXEL_SCALE = 1f;

		public const float R_PIXEL_SCALE = 1f;

		public const float PPU_MUL = 0.01f;

		public const float MS_PER_SEC = 1000f;

		public const float MS_PER_SEC_MUL = 0.001f;

		public const int MAX_GEMS = 400;

		public const int MAX_COINS = 200;

		public const int MAX_REDCOINBAGS = 200;

		public const int MAX_FROZENSOULS = 200;

		public const int FIRST_ASCENSION_POINT_BONUS = 25;

		public const int SECOND_ASCENSION_POINT_BONUS = 25;

		public const int THIRD_ASCENSION_POINT_BONUS = 25;

		public const int MIN_SORTING_ORDER = -32768;

		public const int MAX_SORTING_ORDER = 32767;

		public const int Z_DAMAGE_NUMBER = 22767;

		public const int Z_IN_GAME_UI = 31767;

		public const string DEFAULT_GAME_TWEEN_ID = "DefaultGameTweenId";

		public const string PAUSED_GAME_TWEEN_ID = "PausedGameTweenId";

		public static float PlayerPxSpeed;

		public static float EnemySpeed;

		public static float ProjectileSpeed;

		public static float GoldMultiplier;

		public static float EnemyHealthMultiplier;

		public static float ExperienceMultiplier;

		public static float BaseMarkup;

		public static float SfxVolumeFactor;

		public static float DifficultyAdjustmentEnemyHPMultiplier;

		public static float DifficultyAdjustmentEnemyDamageMultiplier;

		public static uint Tflag;

		public static DamageNumberManager DamageNumberManager;

		[SerializeField]
		private GameObject _Preloader;

		[SerializeField]
		private MagnetZone _MagnetZonePrefab;

		[SerializeField]
		private TouchControlCustomiser _TouchJoystick;

		[SerializeField]
		private WhiteHandManager _WhiteHandManager;

		[SerializeField]
		private Light2D _GlobalLight;

		[SerializeField]
		private Light2D _BackgroundLight;

		[SerializeField]
		private Light2D _Spotlight2D;

		[SerializeField]
		private Light2D _Light2DPrefab;

		[SerializeField]
		private Light2D _Light2DForTilemapPrefab;

		[SerializeField]
		private Renderer2DData _Renderer2DData;

		[SerializeField]
		private Canvas _GameCanvas;

		private SignalBus _signalBus;

		private DiContainer _diContainer;

		private PlayerOptions _playerOptions;

		private AssetReferenceLibrary _assetReferenceLibrary;

		private LootManager _lootManager;

		private WeaponsFacade _weaponsFacade;

		private AccessoriesFacade _accessoriesFacade;

		private Stage _stage;

		private AdventureManager _adventureManager;

		private GameplayLoader _gameplayLoader;

		private ShopFactory _shopFactory;

		private ParticleManager _particleManager;

		private GameSessionData _gameSessionData;

		private LevelUpFactory _levelUpFactory;

		private CharacterFactory _characterFactory;

		private TreasureFactory _treasureFactory;

		private LimitBreakManager _limitBreakManager;

		private DataManager _dataManager;

		private PlayerStats _playerStats;

		private ArcanaManager _arcanaManager;

		private PhysicsManager _physicsManager;

		private ExplosionManager _explosionManager;

		private EggManager _eggManager;

		private ProjectileFactory _projectileFactory;

		private GameplayCheatCodeManager _gameplayCheatCodeManager;

		private GizmoManager _gizmoManager;

		private CanvasGroup _touchJoystickCanvasGroup;

		private SpellsManager _spellsManager;

		private AchievementManager _achievementManager;

		private MultiplayerManager _multiplayer;

		private FontFactory _fontFactory;

		private int _defangIndex;

		private List<float> _defangChancesArray;

		private CommonVfxManager _commonVfxManager;

		private ParticleSystem _pickupVfx;

		private ParticleSystem _jewelPickupVfx;

		private Transform _blittersParent;

		private bool _canRunTickerTimer;

		private float _secondsTickerTimer;

		private int _updateTicks;

		private const int UpdateFreq = 4;

		private float _targetTick;

		private float? _preZoomOrthoSize;

		private Timer _stopTimeTimer;

		public List<PickupToSpawn> _gemsToSpawn;

		public List<PickupToSpawn> _coinsToSpawn;

		public List<PickupToSpawn> _redCoinBagsToSpawn;

		public List<PickupToSpawn> _frozenSoulsToSpawn;

		private bool _isPaused;

		private bool _isGameRunning;

		private readonly List<UiTransition> _queuedUiTransitions;

		private List<Pickup> _stagePickups;

		private List<MapToken> _mapTokens;

		private Transform _candleLightsParent;

		private Queue<Light2D> _candleLights;

		private Dictionary<Destructible, Light2D> _candleLightsMapping;

		private ObjectPool _gemPool;

		private HashSet<Pickup> _gems;

		private ObjectPool _coinPool;

		private HashSet<Coin> _coins;

		private float _defaultCoinValue;

		private ObjectPool _redCoinBagPool;

		private HashSet<CoinBag1> _redCoinBags;

		private float _defaultRedCoinBagValue;

		private ObjectPool _frozenSoulPool;

		private HashSet<Pickup_Bonus_FrozenSoul> _frozenSouls;

		private float _defaultFrozenSoulValue;

		private TilingBackground _bgMan;

		private Timer _safetyPause;

		private bool _restartingGameScene;

		private bool _inGameOverState;

		private bool _inOnlineErrorState;

		private bool _hideLoadingVisuals;

		private Texture2D _recapTex;

		private List<VampireSurvivors.Objects.Characters.CharacterController> _characters;

		private List<VampireSurvivors.Objects.Characters.CharacterController> _mainCharacters;

		private List<VampireSurvivors.Objects.Characters.CharacterController> _charactersLevelingUp;

		private Coroutine _signalGameplayLoadedRoutine;

		private bool _waitingForLevelUp;

		private List<int> _coopChestRandomness;

		private int _coopChestRandomnessIndex;

		private Transform _coopCameraTarget;

		private Coherence.Log.Logger _logger;

		private EnemyType _latestKilledEnemyThatCanBeFollowerType;

		private EnemyData _latestKilledEnemyThatCanBeFollowerData;

		private bool _latestKilledEnemyWasCartRider;

		private int _nextLevelUpAtLevel;

		private int _batchedOnlineLevelUpSkips;

		private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, List<FollowerEnemy_CharacterController>> m_EnemyFollowerPools;

		private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, int> m_NumAliveEnemyFollowers;

		[NonSerialized]
		public bool BlockConnectionErrorPopups;

		public CoopConfig CoopConfig;

		public PhysicsGroup Enemies;

		public PhysicsGroup EnemiesThatIgnoreProjectiles;

		private UiTransition _latestUITransition;

		private List<bool> _cachedCharacterValidity;

		private List<VampireSurvivors.Objects.Characters.CharacterController> _followerCache;

		[SerializeField]
		private float _bossHealthMultiplier;

		[SerializeField]
		private float _bossAttacksTriggerChance;

		public float? PreZoomOrthoSize => null;

		public Transform CoopCameraTarget => null;

		public Action ManualCameraTargetControl { get; set; }

		public GoldFingerManager GoldFingerManager { get; set; }

		public bool HasGfBonus { get; set; }

		public Stage Stage => null;

		public ArcanaManager ArcanaManager => null;

		public PhysicsManager PhysicsManager => null;

		public Renderer2DData Renderer2DData => null;

		public DataManager DataManager => null;

		public GameSessionData GameSessionData => null;

		public LevelUpFactory LevelUpFactory => null;

		public PlayerOptions PlayerOptions => null;

		public AssetReferenceLibrary AssetReferenceLibrary => null;

		public EggManager EggManager => null;

		public TreasureFactory TreasureFactory => null;

		public SignalBus SignalBus => null;

		public DiContainer DiContainer => null;

		public TilingBackground BGMan => null;

		public ProjectileFactory ProjectileFactory => null;

		public SpellsManager SpellsManager => null;

		public GizmoManager GizmoManager => null;

		public AchievementManager AchievementManager => null;

		public WeaponsFacade WeaponsFacade => null;

		public AccessoriesFacade AccessoriesFacade => null;

		public AdventureManager AdventureManager => null;

		public ShopFactory ShopFactory => null;

		public FontFactory FontFactory => null;

		public CharacterFactory CharacterFactory => null;

		public OpenTreasurePage OpenTreasurePage { get; set; }

		public ConnectionException ConnectionException { get; private set; }

		public ParticleManager ParticleManager => null;

		public Light2D Spotlight2D => null;

		public bool IsPaused => false;

		public bool IsInPauseGameState { get; set; }

		public bool RestartingGameScene
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool InGameOverState
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool InOnlineErrorState
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool HideLoadingVisuals
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Texture2D RecapTex
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool CanInterrupt { get; set; }

		public bool CanPause { get; set; }

		public bool FreezingFrame { get; set; }

		public VampireSurvivors.Objects.Characters.CharacterController PausingPlayer { get; set; }

		public float BossAttacksTriggerChance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float BossHealthMultiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool StartedAsOnlineMultiplayerRun { get; set; }

		public VampireSurvivors.Objects.Characters.CharacterController ChestWinnerPlayer { get; set; }

		public int SurvarotsCardsToShow { get; set; }

		public bool CanShowGameOverRewardAd { get; set; }

		public bool CanShowArcadeReviveButton { get; set; }

		public string WeaponSelectionType { get; set; }

		public ArcanaUiType ArcanaUiType { get; set; }

		public Transform WorldSpritesTransform { get; private set; }

		public Rect? HardBounds { get; set; }

		public List<Pickup> StagePickups => null;

		public List<MapToken> MapTokens => null;

		public LootManager LootManager => null;

		public HashSet<Pickup> Gems => null;

		public HashSet<Coin> Coins => null;

		public HashSet<CoinBag1> RedCoinBags => null;

		public HashSet<Pickup_Bonus_FrozenSoul> FrozenSouls => null;

		public ParticleSystem PickupVfx => null;

		public ParticleSystem JewelPickupVfx => null;

		public MerchantInventoryType MerchantInventory { get; set; }

		public PickupCustomMerchant CurrentCustomMerchant { get; private set; }

		public bool IsTimeStopped { get; set; }

		public bool IgnoreMovementFreezeFromTimeStop { get; set; }

		public bool IsAllDefanged { get; set; }

		public VampireSurvivors.Objects.Characters.CharacterController EnterWeaponSelectionPlayer { get; set; }

		public VampireSurvivors.Objects.Characters.CharacterController EnterBonusSelectionPlayer { get; private set; }

		public ItemType CurrentFoundRelic { get; set; }

		public bool IsHalloween { get; set; }

		public bool IsLocalMultiplayer => false;

		public bool IsOnlineMultiplayer => false;

		public bool IsMultiplayer => false;

		public bool IsStageHost => false;

		public bool HasMultipleMainCharacters => false;

		public List<VampireSurvivors.Objects.Characters.CharacterController> AllPlayers => null;

		public List<VampireSurvivors.Objects.Characters.CharacterController> MainPlayers => null;

		public VampireSurvivors.Objects.Characters.CharacterController Player => null;

		public VampireSurvivors.Objects.Characters.CharacterController PlayerOne => null;

		public VampireSurvivors.Objects.Characters.CharacterController MyOnlinePlayer => null;

		public PhaserScene scene => null;

		public PhysicsGroup EnemyGroup => null;

		public PhysicsGroup PlayerGroup => null;

		public PhysicsGroup Destructibles => null;

		public PhysicsGroup PickupGroup => null;

		public GameEquipmentPanel GameEquipmentPanel { get; private set; }

		public MainGamePage MainUI { get; private set; }

		public float SurvivedSeconds { get; set; }

		public List<Action<float>> OnCoinPickup { get; set; }

		public bool IsGameRunning => false;

		public CommonVfxManager CommonVfxManager => null;

		private ObjectPool GemPool => null;

		private ObjectPool CoinPool => null;

		private ObjectPool RedCoinBagPool => null;

		private ObjectPool FrozenSoulPool => null;

		public VampireSurvivors.Objects.Characters.CharacterController InteractingPlayer => null;

		public int FreeRoamCameraTargetWhenDead { get; set; }

		public bool IsStageVisuallyInverted()
		{
			return false;
		}

		[Inject]
		private void Construct(SignalBus signalBus, DiContainer diContainer, PlayerOptions playerOptions, LootManager lootManager, WeaponsFacade weaponsFacade, Stage stage, GameSessionData gameSessionData, LevelUpFactory levelUpFactory, CharacterFactory characterFactory, AccessoriesFacade accessoriesFacade, DataManager dataManager, PlayerStats playerStats, ArcanaManager arcanaManager, PhysicsManager physicsManager, EggManager egg, LimitBreakManager limitBreakManager, GizmoManager gizmoManager, TreasureFactory treasureFactory, ProjectileFactory projectileFactory, SpellsManager spellsManager, AchievementManager achievementManager, MainGamePage mainGamePage, MultiplayerManager multiplayer, AdventureManager adventureManager, FontFactory fontFactory, AssetReferenceLibrary assetReferenceLibrary, ParticleManager particleManager, ShopFactory shopFactory)
		{
		}

		private void Awake()
		{
		}

		private void InitializeGame()
		{
		}

		private void InitiateGameplayPreload()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void OverrideLatestUIPlayer(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		private void HandleIngamePopup()
		{
		}

		private void ProcessUITransition(UiTransition uiTransition)
		{
		}

		public bool ShouldShowArcanaPanel()
		{
			return false;
		}

		public void MovePickupsAndDestructibles(float2 offset)
		{
		}

		private void RunLocalOrOnlineLevelUp()
		{
		}

		private void AdjustNextLevelUpAtLevel()
		{
		}

		private void OnlineLevelUp(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
		{
		}

		private void RunOnlineLevelUpLogic(bool shouldSwapToLevelUpUi, bool adjustXpFactors, VampireSurvivors.Objects.Characters.CharacterController characterController)
		{
		}

		private void GrantSkipsExperience(VampireSurvivors.Objects.Characters.CharacterController characterController)
		{
		}

		private void RunLocalLevelUpLogic()
		{
		}

		private void SwapToLevelUpScreenOnline(bool shouldSwapToLevelUpUi, VampireSurvivors.Objects.Characters.CharacterController characterController)
		{
		}

		public void HandleLevelUp()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void DeactivatePreloader()
		{
		}

		public void PauseGame()
		{
		}

		public void ResumeGame()
		{
		}

		public void RemoveTickerTimer()
		{
		}

		public void ResumeTickerTimer()
		{
		}

		public void SummonWhiteHand(bool forceStageTimerEnd = false)
		{
		}

		public void ForceStageTimerEnd()
		{
		}

		public void TransitionToFoscari2()
		{
		}

		public void TransitionToTP_ADV_001_Stage_DEATHFIGHT()
		{
		}

		public void RestartGameScene(bool shouldShowTransition = false)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForEveryoneToResetGameSession_003Ed__446))]
		private static IEnumerator WaitForEveryoneToResetGameSession()
		{
			return null;
		}

		public void ResetGameToMenu()
		{
		}

		private void GoToPreloadScene()
		{
		}

		[IteratorStateMachine(typeof(_003CSnapshotRecap_003Ed__449))]
		public IEnumerator SnapshotRecap(Action onComplete)
		{
			return null;
		}

		public void ClearRecapScreenshot()
		{
		}

		public void EnterCreditEndingScene()
		{
		}

		public void EnterGameEndScene()
		{
		}

		public bool TeleportMyPlayerToRemotePlayer(VampireSurvivors.Objects.Characters.CharacterController remotePlayer, Action onYoyo)
		{
			return false;
		}

		public void TeleportPlayers(float2 position, float2 offsetForEachPlayer, bool centered = false, bool focusCameraOnPlayer = true)
		{
		}

		[IteratorStateMachine(typeof(_003CRemoveManualCameraControl_003Ed__455))]
		private IEnumerator RemoveManualCameraControl()
		{
			return null;
		}

		private bool IsAnyPlayerOutsideBounds(ArcadeBodyBounds bounds)
		{
			return false;
		}

		private void OnlineFocusCameraOnMyPlayer()
		{
		}

		public VampireSurvivors.Objects.Characters.CharacterController GetClosestPlayer(float2 position, PlayerInclusionMode inclusionMode = PlayerInclusionMode.AliveOrDead, float maxRangeSqrd = 3.4028235E+38f, bool includeFollowers = true)
		{
			return null;
		}

		public int GetAlivePlayerCount(bool countRevivingPlayerAsAlive = false, bool includeOnlyMainCharacters = false)
		{
			return 0;
		}

		public void UpdateMainPlayersEligibleForLevelUp()
		{
		}

		public int GetNonFollowerMainCharacterCount()
		{
			return 0;
		}

		public int GetNonFollowerMainCharacterInCoffinCount()
		{
			return 0;
		}

		public void ClearAllPlayerRevives()
		{
		}

		public void RosaryDamage(bool showVfx = true, float volume = 1.8f, WeaponType damageType = WeaponType.ROSARY, bool setDark = false)
		{
		}

		private void StopTime(GameplaySignals.TimeStopSignal signal)
		{
		}

		private void StopTimeForMilliseconds(float milliseconds)
		{
		}

		public void SpawnPickupEffectsParticles(Vector2 pos)
		{
		}

		public void ShowHitVfxAt(Vector2 pos, HitVfxType showHitVfx)
		{
		}

		public void ShowDamageAt(Vector2 pos, float value)
		{
		}

		public void ShowRecoveryAt(Vector2 pos, float value)
		{
		}

		public Transform FindClosestEnemyToPlayer(VampireSurvivors.Objects.Characters.CharacterController character)
		{
			return null;
		}

		public void AddOnlineLevelUpToQueue(OnlineLevelUpData levelUpData)
		{
		}

		public void AddTreasureToQueue(Treasure treasure)
		{
		}

		public void AddCharacterTypeToQueue(CharacterType characterType, VampireSurvivors.Objects.Characters.CharacterController targetPlayer)
		{
		}

		public void AddRelicToQueue(ItemType itemType, VampireSurvivors.Objects.Characters.CharacterController targetPlayer)
		{
		}

		public void AddFoundWeaponToQueue(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController targetPlayer)
		{
		}

		public void MakeExplosion(Vector2 spawnPos, int moreX, int moreY)
		{
		}

		public Pickup MakeStagePickup(Vector2 pos, ItemType itemType = ItemType.COIN, WeaponType weaponType = WeaponType.VOID, float value = 0f, ItemType relicType = ItemType.VOID, bool validatePickups = true)
		{
			return null;
		}

		public void RegisterStagePickup(Pickup pickup)
		{
		}

		public void MakeGem(Vector2 pos, float xp, Action<Pickup> callback = null)
		{
		}

		public void MakeCoin(Vector2 pos, float value = 0f, Action<Pickup> callback = null)
		{
		}

		public void MakeRedCoinBag(Vector2 pos, float value = 0f, Action<Pickup> callback = null)
		{
		}

		public void MakeFrozenSoul(Vector2 pos, float value = 0f, Action<Pickup> callback = null)
		{
		}

		public Gem MakeGemIgnoreAllTheLimits(Vector2 pos, float xp)
		{
			return null;
		}

		public TreasureChest MakeTreasure(Vector2 pos, Treasure treasure, bool isRemote = false)
		{
			return null;
		}

		public void MakeAndActivatePickup(ItemType itemType, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter)
		{
		}

		public Pickup MakePickup(Vector2 pos, ItemType itemType = ItemType.COIN, WeaponType weaponType = WeaponType.VOID, float value = 0f, ItemType relicType = ItemType.VOID, bool shouldCallValidatePickups = true, bool isRemote = false, bool onlineSynchronization = true)
		{
			return null;
		}

		public void ReturnGem(Gem gem)
		{
		}

		public void ReturnCoin(Coin coin)
		{
		}

		public void ReturnRedCoinBag(CoinBag1 coinBag)
		{
		}

		public void ReturnFrozenSoul(Pickup_Bonus_FrozenSoul soul)
		{
		}

		public void StopTrackingFrozenSoul(Pickup_Bonus_FrozenSoul soul)
		{
		}

		public void TurnOnVacuum(VampireSurvivors.Objects.Characters.CharacterController target = null)
		{
		}

		public void TurnOnVacuumForGold()
		{
		}

		public void ZoomOnPlayer()
		{
		}

		public void ZoomZoomOnPlayer()
		{
		}

		public void ZoomCamera(float zoomAmount, float duration, EaseType easeType = EaseType.Linear)
		{
		}

		public void SetCanvasRenderMode(RenderMode renderMode)
		{
		}

		public void RemoveAllPlayersAsCameraTargets(float removePlayerTargetDuration)
		{
		}

		public void AddAllPlayersAsCameraTargets(float transitionDuration = 0f)
		{
		}

		public void SetPlayerWorldBoundCollision(bool on)
		{
		}

		public void StopCamera(Vector2 center, float removePlayerTargetDuration = 1f)
		{
		}

		public void ResumeCamera()
		{
		}

		public void SetHardBoundsMinMax(float xMin, float yMin, float xMax, float yMax, bool skipInverseCalculation = false)
		{
		}

		public void RemoveHardBounds()
		{
		}

		public void CoinPickedup(Pickup pickup)
		{
		}

		public Blitter CreateBlitter(Vector2 pos, string blitterName = null)
		{
			return null;
		}

		public void SetLatestKilledEnemy(EnemyController _enemyController)
		{
		}

		private bool CheckIfFrameListIsValid(List<string> frameList)
		{
			return false;
		}

		public EnemyData GetLatestKilledEnemyThatCanBeFollower()
		{
			return null;
		}

		public EnemyType GetLatestKilledEnemyThatCanBeFollowerType()
		{
			return default(EnemyType);
		}

		public bool GetLatestKilledEnemyWasCartRider()
		{
			return false;
		}

		public void EraseEnemies(bool showVfx = true)
		{
		}

		public void EnterTheBossi()
		{
		}

		public void SetupMusicBanger(bool loop = true)
		{
		}

		public SoundManager.SoundConfig BuildSoundConfigWithModifiers(bool loop = true)
		{
			return null;
		}

		public VampireSurvivors.Objects.Characters.CharacterController PullRandomChestWinner()
		{
			return null;
		}

		public void OnCharacterDestroyed(VampireSurvivors.Objects.Characters.CharacterController characterController)
		{
		}

		private void RedistributeEquipment(VampireSurvivors.Objects.Characters.CharacterController characterController)
		{
		}

		public void InitializeCharacterSpawnedRemotely(GameObject characterInstance, CharacterType characterType)
		{
		}

		public void AddPlayerXp(float xp, XPMultiplierMode multiplierMode = XPMultiplierMode.Normal)
		{
		}

		public void UpdatePlayerUI()
		{
		}

		public void TogglePlayerHealthBar(bool visible)
		{
		}

		public List<Weapon> RemoveAllWeaponsFromPlayer(VampireSurvivors.Objects.Characters.CharacterController owner)
		{
			return null;
		}

		public void SetAllPlayersWeaponsActive(bool active)
		{
		}

		public void SetOnlySomePlayersWeaponsActive(int maxActive)
		{
		}

		public List<EquipmentInfo> RemoveAllEquipmentFromPlayers(bool addToRemovedList = false)
		{
			return null;
		}

		public void GiveBackAllEquipmentToPlayers(List<EquipmentInfo> playerEquipment)
		{
		}

		public Weapon RemoveWeaponFromPlayer(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController owner)
		{
			return null;
		}

		public void RemoveHiddenWeaponFromPlayer(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController owner)
		{
		}

		public void FinishLevelUp(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public void OnlineFinishLevelUp(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter)
		{
		}

		public void LevelWeaponUp(WeaponType weaponType, bool removeFromStore = true, VampireSurvivors.Objects.Characters.CharacterController player = null)
		{
		}

		public void OnReRollLevelUp()
		{
		}

		public void OnLevelUpBanish()
		{
		}

		public int GetWeaponLevel(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController character)
		{
			return 0;
		}

		public Weapon GetWeapon(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController character)
		{
			return null;
		}

		public int GetAccessoryLevel(WeaponType accessoryType, VampireSurvivors.Objects.Characters.CharacterController character)
		{
			return 0;
		}

		public bool HasCharacterInPlay(CharacterType characterType)
		{
			return false;
		}

		public bool HasWeaponInPlay(WeaponType weaponType)
		{
			return false;
		}

		public PickupWeapon TryGiveWeaponToPlayer(WeaponType weaponToGive, VampireSurvivors.Objects.Characters.CharacterController character)
		{
			return null;
		}

		public void DoPraise(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public Light2D GetLight(Destructible destructible)
		{
			return null;
		}

		public void ReturnLight(Destructible destructible)
		{
		}

		public bool LimitBreakWeaponUp(WeightedLimitBreak limitBreakData, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter)
		{
			return false;
		}

		public void FrameFreeze(Action onComplete = null, float milliseconds = 120f, bool pauseTweens = false)
		{
		}

		public void TriggerGoldFever(float durationMillis)
		{
		}

		public void TriggerFakeGoldFever(float durationMillis)
		{
		}

		public void QueueEnterPianoScene(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public void EnterPianoScene(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
		{
		}

		public void ExitPianoScene()
		{
		}

		public bool CheckValidToastieInputs()
		{
			return false;
		}

		public bool HasAnimaWeapon(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			return false;
		}

		public void CheckAllWeaponsForTeleport(float2 destinationPos)
		{
		}

		public FollowerEnemy_CharacterController AddLastEnemyFollower(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
		{
			return null;
		}

		public int GetNumAliveEnemyFollowers(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
		{
			return 0;
		}

		public void RefreshEnemyFollowersList(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
		{
		}

		public void FromOnlineSetEnemyFollowerDataOnly(short enemyType, bool wasCartRider)
		{
		}

		public void FromOnlineSetRecycledEnemyFollowerData(short enemyType, bool wasCartRider, CoherenceSync newFollowerSync)
		{
		}

		public FollowerEnemy_CharacterController AddNewEnemyFollower(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
		{
			return null;
		}

		public void KillAllFollowers(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
		{
		}

		public bool IsWeaponTypeAvailable(WeaponType element)
		{
			return false;
		}

		public void DebugCharShowcase()
		{
		}

		public void DebugCoopShowcase(bool prioritiseEvolvablePairings, long seed = -1L, int minusMaxLevel = 0)
		{
		}

		public void DebugGiveAllWeapons(bool includeSealedWeapons = true)
		{
		}

		public void DestroyOnlineConfigs()
		{
		}

		public void InitializeStageLogicOnline()
		{
		}

		private void LoadRestOfStageOnline()
		{
		}

		public void StartOnlineGame()
		{
		}

		public void LevelUpWithoutScreen()
		{
		}

		public static bool IsOnMobile()
		{
			return false;
		}

		public static int GetAscensionBonusPercentage(int assignedPoints)
		{
			return 0;
		}

		[IteratorStateMachine(typeof(_003CInitRemoteCharacterWhenGameplayLoaded_003Ed__574))]
		private IEnumerator InitRemoteCharacterWhenGameplayLoaded(GameObject characterInstance, CharacterType characterType)
		{
			return null;
		}

		private void GeneratePickupVfx()
		{
		}

		private void InitializeGameSession()
		{
		}

		private void InitializeGameSessionPostLoad()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForAllCharactersToBeLoaded_003Ed__578))]
		private IEnumerator WaitForAllCharactersToBeLoaded()
		{
			return null;
		}

		private void AddStartingWeaponsForAllCharacters()
		{
		}

		private List<VampireSurvivors.Objects.Characters.CharacterController> GetCharactersToAddStartingWeapon()
		{
			return null;
		}

		private void StageInit(StageType stageType)
		{
		}

		private void PostStageInit()
		{
		}

		private void InitCoopChestRandomness()
		{
		}

		[IteratorStateMachine(typeof(_003CSignalGameplayLoaded_003Ed__584))]
		private IEnumerator SignalGameplayLoaded()
		{
			return null;
		}

		private void AddLocalCharacter(VampireSurvivors.Objects.Characters.CharacterController playerOne)
		{
		}

		private void RefreshCoopChestRandomisation()
		{
		}

		private VampireSurvivors.Objects.Characters.CharacterController FindNextValidWinner(Predicate<VampireSurvivors.Objects.Characters.CharacterController> isValid, bool saveChances)
		{
			return null;
		}

		private void SetupGattiCustomBgmRate()
		{
		}

		private void Cleanup()
		{
		}

		public void FastForwardOneDay()
		{
		}

		private void OnTickerCallback()
		{
		}

		private void ResetGameSessionCallback()
		{
		}

		private void ResetGameSession(bool disconnectFromCoherence = true)
		{
		}

		public void ReleaseGameplayLoader()
		{
		}

		private void FinishLevelUpActions(WeaponType weaponType, bool setInvincibility, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter = null)
		{
		}

		private ArcadeSprite InitPlayerPhysics(GameObject characterInstance)
		{
			return null;
		}

		private VampireSurvivors.Objects.Characters.CharacterController GeneratePlayerCharacter(CharacterType characterType, int playerIndex)
		{
			return null;
		}

		public void RemoveWallCollisionFromCharacter(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		private void ApplyStatModifiers(VampireSurvivors.Objects.Characters.CharacterController newCharacter)
		{
		}

		public VampireSurvivors.Objects.Characters.CharacterController AddFollower(CharacterType characterType, VampireSurvivors.Objects.Characters.CharacterController followedCharacter, AIType aiType, bool manualLevelups = false, int EveryXLevels = 1, bool spawnWithoutAuthority = false)
		{
			return null;
		}

		private void InitFollower(VampireSurvivors.Objects.Characters.CharacterController newCharacter)
		{
		}

		private void AddMainCharacter(VampireSurvivors.Objects.Characters.CharacterController newCharacter)
		{
		}

		private void AddInitialPresetLoadout(VampireSurvivors.Objects.Characters.CharacterController newCharacter)
		{
		}

		private void AddStartingWeapon(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		private void GenerateMagnetZone(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void FirePlayerXpUpdatedFromOnline()
		{
		}

		[IteratorStateMachine(typeof(_003CFirePlayerXpUpdatedFromOnlineRoutine_003Ed__608))]
		private IEnumerator FirePlayerXpUpdatedFromOnlineRoutine()
		{
			return null;
		}

		public void FirePlayerXpUpdated()
		{
		}

		private void AddWeaponToPlayer(GameplaySignals.AddWeaponToCharacterSignal signal)
		{
		}

		private void AddAccessoryToPlayer(GameplaySignals.AddAccessoryToCharacterSignal signal)
		{
		}

		public void SetSeenWeapon(WeaponType weaponType)
		{
		}

		public Weapon AddWeapon(WeaponType weapon, VampireSurvivors.Objects.Characters.CharacterController character)
		{
			return null;
		}

		private void RemoveWeaponFromPlayer(GameplaySignals.RemoveWeaponFromCharacterSignal signal)
		{
		}

		public Weapon AddHiddenWeapon(WeaponType weapon, VampireSurvivors.Objects.Characters.CharacterController character, bool allowDuplicates = false)
		{
			return null;
		}

		private void AddHiddenWeaponToPlayer(GameplaySignals.AddHiddenWeaponToCharacterSignal signal)
		{
		}

		private void RemoveHiddenWeaponFromPlayer(GameplaySignals.RemoveHiddenWeaponFromCharacterSignal signal)
		{
		}

		public void SetPlayersVisible(bool visible)
		{
		}

		public void SetPlayersInvulForMillisecondsAndRestoreTints(float milliseconds)
		{
		}

		public void SetPlayersInvulForMilliSecondsNonCumulative(float milliseconds)
		{
		}

		private void SetPlayerInvincibility(GameplaySignals.SetCharacterInvincibilityForMillisSignal signal)
		{
		}

		private void SetPlayerInvincibilityNonCumulative(GameplaySignals.SetCharacterInvincibilityForMillisNonCumulativeSignal signal)
		{
		}

		private void LetPlayersGetTheirBearings()
		{
		}

		private void OnReviveCharacter(GameplaySignals.ReviveCharacterSignal signal)
		{
		}

		public void RunAllPostRevivialActions(VampireSurvivors.Objects.Characters.CharacterController revived, bool instantRevival = false)
		{
		}

		private void ApplyAscensionPoints(VampireSurvivors.Objects.Characters.CharacterController characterController)
		{
		}

		private void ApplyPurchasedPowerUpData(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		private void ApplyPlayerStat(PlayerStat playerStat, VampireSurvivors.Objects.Characters.CharacterController characterController)
		{
		}

		private void OnLevelUpSkipped(GameplaySignals.SkipLevelUpSignal signal)
		{
		}

		private float GetLevelUpSkipXpToGrant(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			return 0f;
		}

		private void OnLevelUpCompleted()
		{
		}

		public void CycleActivePlayer()
		{
		}

		private void UpdateTouchControls(bool isOn)
		{
		}

		private void OnJoystickOptionsChanged(UISignals.SetVisibleJoysticksSignal signal)
		{
		}

		private void SetupMusicNormal()
		{
		}

		private bool SetupCharacterMusic()
		{
			return false;
		}

		private bool GetMusicData(BgmType bgmType, out MusicData musicData)
		{
			musicData = null;
			return false;
		}

		public void DisableBuiltInLighting()
		{
		}

		public bool HasSpecialStageLighting()
		{
			return false;
		}

		public Light2D GetGlobalLight()
		{
			return null;
		}

		public void SetSpecialStageLightingEnabled(bool enabled)
		{
		}

		[IteratorStateMachine(typeof(_003CReenableBrokenShadowCasterGroup2DsBecauseUnity_003Ed__642))]
		private IEnumerator ReenableBrokenShadowCasterGroup2DsBecauseUnity()
		{
			return null;
		}

		private void SetupLighting()
		{
		}

		private void AddLightsToPool(int count)
		{
		}

		private Light2D AddLight(Vector2 pos, float radius, float intensity)
		{
			return null;
		}

		private void OnFireEnemyBullet(GameplaySignals.FireEnemyBulletSignal signal)
		{
		}

		public void OnStagePickupCallback(Pickup pickup)
		{
		}

		private void SpawnGems()
		{
		}

		private void CondenseGems(int maxGems = 400)
		{
		}

		private void SpawnPickups<T>(List<PickupToSpawn> toSpawn, HashSet<T> pickupSet, int MAX_COUNT, float defaultValue, ObjectPool pool, ItemType itemType) where T : Pickup, ICountedPickup
		{
		}

		private void CondensePickups<T>(HashSet<T> pickupSet, int maxPickups) where T : Pickup, ICountedPickup
		{
		}

		public void QueueGenericResume(VampireSurvivors.Objects.Characters.CharacterController pausingPlayer)
		{
		}

		private void PerformGenericResume(VampireSurvivors.Objects.Characters.CharacterController pausingPlayer, Dictionary<string, object> args)
		{
		}

		public void QueueGenericPause(VampireSurvivors.Objects.Characters.CharacterController pausingPlayer)
		{
		}

		private void GenericOnlinePause(VampireSurvivors.Objects.Characters.CharacterController pausingPlayer, Dictionary<string, object> args)
		{
		}

		public void QueueOpenWeaponSelection(VampireSurvivors.Objects.Characters.CharacterController player, string weaponSelectionType)
		{
		}

		private void OpenWeaponSelection(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
		{
		}

		public void QueueEnterSkillSelection(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		private void EnterSkillSelection(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
		{
		}

		public void QueueEnterShop(VampireSurvivors.Objects.Characters.CharacterController player, MerchantInventoryType inventoryType, PickupCustomMerchant customMerchant)
		{
		}

		private void EnterShop(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
		{
		}

		public void QueueEnterHealer(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		private void EnterHealer(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
		{
		}

		public void QueueEnterDirecter(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		private void EnterDirecter(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
		{
		}

		public void QueueOpenArcana(ArcanaUiType type, VampireSurvivors.Objects.Characters.CharacterController chestWinner = null)
		{
		}

		private void OpenMainArcana(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
		{
		}

		public void QueueOpenSurvarots(int cardsToShow, VampireSurvivors.Objects.Characters.CharacterController chestWinner)
		{
		}

		private void OpenSurvarots(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
		{
		}

		public void QueueReportBody(VampireSurvivors.Objects.Characters.CharacterController reporter, VampireSurvivors.Objects.Characters.CharacterController reportedPlayer)
		{
		}

		private void TransitionToReportBody(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
		{
		}

		private void SwapToRelicFoundScreen(VampireSurvivors.Objects.Characters.CharacterController targetPlayer, Dictionary<string, object> args)
		{
		}

		private void SwapToItemFoundScreen(VampireSurvivors.Objects.Characters.CharacterController targetPlayer, Dictionary<string, object> args)
		{
		}

		private void SwapToCharFoundScreen(VampireSurvivors.Objects.Characters.CharacterController targetPlayer, Dictionary<string, object> args)
		{
		}

		public void PreManipulateLevelUpOptionsForSpecialWeapons()
		{
		}

		public void PostManipulateLevelUpOptionsForSpecialWeapons()
		{
		}

		private void SwapToLevelUpScreen(bool adjustXpFactors)
		{
		}

		private void StartOnlineLevelUpFromHost(bool shouldSendLevelUpSignal, bool adjustXpFactors, WeaponType? randomWeapon, WeightedLimitBreak randomLimitBreak, bool roastLevelUp, bool coinBagLevelUp)
		{
		}

		private bool CanLimitBreak()
		{
			return false;
		}

		private void GetLevelUpChoices(out List<WeaponType> chosenWeapons, out List<VampireSurvivors.Objects.Characters.CharacterController> amuletTargets, out List<WeightedLimitBreak> limitBreaks, out List<ItemType> chosenItems)
		{
			chosenWeapons = null;
			amuletTargets = null;
			limitBreaks = null;
			chosenItems = null;
		}

		private bool ApplyOfflineLevelUp(WeaponType? randomWeapon, VampireSurvivors.Objects.Characters.CharacterController player, WeightedLimitBreak randomLimitBreak, bool shouldSendLevelUpSignal, bool roastLevelUp, bool coinBagLevelUp)
		{
			return false;
		}

		private void ApplyCoinBagLevelUp(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		private void ApplyRoastLevelUp(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		private bool ApplyRandomLevelUpLimitBreak(WeightedLimitBreak lBreakData, VampireSurvivors.Objects.Characters.CharacterController player)
		{
			return false;
		}

		private void ApplyRandomLevelUpWeapon(WeaponType choice, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		private void SwapToTreasureScreen(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
		{
		}

		public bool CanPlayQuickTreasureAnim(List<TreasurePrizeTypePair> prizes)
		{
			return false;
		}

		private void PlayQuickTreasureAnim(Treasure treasure, VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		private bool CanSkipTreasureLevel3(PlayerOptionsData config)
		{
			return false;
		}

		private bool AllPrizesAreFillerOrArcana(List<TreasurePrizeTypePair> prizes)
		{
			return false;
		}

		private void GenerateCheatCodeManager()
		{
		}

		private void ClearTimeStop()
		{
		}

		public void OnConnectionError(CoherenceBridge _, ConnectionException connectionException)
		{
		}

		public void HandleCameraUpdate()
		{
		}

		public bool IsNormalCameraTarget()
		{
			return false;
		}

		private Transform GetFreeRoamCameraTarget()
		{
			return null;
		}

		private void UpdateCameraTarget()
		{
		}

		public float AveragePlayerCurse()
		{
			return 0f;
		}

		public bool HasAPlayerGotRevivals()
		{
			return false;
		}

		public double GetMaxReviveCount()
		{
			return 0.0;
		}

		public float GetDefangChanceFromArray()
		{
			return 0f;
		}

		public bool HasRandomazzoEnabled()
		{
			return false;
		}

		public float GetKillRatio()
		{
			return 0f;
		}

		public List<VampireSurvivors.Objects.Characters.CharacterController> GetFollowers(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
		{
			return null;
		}

		public void DoRemovePowersEffect(List<string> frames, List<string> textureNames = null, float scale = 1f, float2? center = null)
		{
		}

		public void ClearCurrentCustomMerchant()
		{
		}

		public VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllerFromType(CharacterType type)
		{
			return null;
		}

		public VampireSurvivors.Objects.Characters.CharacterController GetCharacterFromRewiredPlayer(Player player)
		{
			return null;
		}
	}
}
