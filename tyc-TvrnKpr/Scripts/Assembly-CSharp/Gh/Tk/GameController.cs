using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk.Story;
using UnityEngine;

namespace Gh.Tk
{
	public class GameController : SingletonMonoBehaviour<GameController>
	{
		public enum MODE
		{
			NONE = 0,
			PROPBUILD = 1,
			PROPEDIT = 2,
			ASSIGNSTAFF = 3,
			ASSIGNROOM = 4,
			ASSIGNBEDS = 5,
			CLONETOOL = 6
		}

		private static bool _isQuitPending;

		public static ushort frameNumber;

		public TemplateUnlockConfigAsset[] templateUnlockConfigs;

		[SerializeField]
		private MODE _mouseMode;

		public LayerMask clickableLayers;

		private GameObject _clickedObject;

		public GameObject BrokenParticleAnimation;

		private readonly int currentFloorLevel;

		public AnimationCurve defaultHungerChance;

		public Gradient DamageGradient;

		public Gradient FilthGradient;

		public bool printDebugStatsForUpdateLoop;

		private bool _aStarDirty;

		private bool _statReportEnabled;

		private GameObjectX _possibleCloneGOX;

		private EntityObject _possibleCloneEO;

		public static EventHandler<EventArgs> CloneDecorationHappened;

		private bool _isHoveringAssignableObject;

		private static bool _hasBeenDestroyed;

		private bool _readyToQuit;

		public GameObject InnerWallLowPrefab;

		public GameObject OuterWallLowPrefab;

		public GameObject OuterWallFullPrefab;

		public GameObject OuterWallPostFullPrefab;

		public GameObject OuterWallPostLowPrefab;

		public GameObject InnerWallPostPrefab;

		public GameObject WallZoningPrefab;

		public GameObject WallPostZoningPrefab;

		public GameObject ZoningTileVisual;

		public GameObject DoorVisual;

		public const float GDTPirateRatio = 0.936f;

		public static bool IsGameReady { get; private set; }

		public static bool IsApplicationQuitting => false;

		public static string VERSION => null;

		public Transform StaffToHireParent { get; private set; }

		public UIController UI { get; private set; }

		public AudioController Audio { get; private set; }

		public Tavern Tavern { get; private set; }

		public GlobalTimeController TimeController { get; private set; }

		public SpawnPatron SpawnPatron { get; private set; }

		public GameItemVisualFactory VisualFactory { get; private set; }

		public LevelConfig LevelConfig { get; private set; }

		public ActorVisualController ActorVisualController { get; private set; }

		public TavernMenu TavernMenu { get; private set; }

		public GridController GridController { get; private set; }

		public RoomController RoomController { get; private set; }

		public AtmosphereController AtmosphereController { get; private set; }

		public LarderController LarderController { get; private set; }

		public EntertainmentController EntertainmentController { get; private set; }

		public WeatherController WeatherController { get; private set; }

		public LaundryController LaundryController { get; private set; }

		public ResearchController ResearchController { get; private set; }

		public Sun TavernSun { get; private set; }

		public CharacterColorVariator CharacterColorVariator { get; private set; }

		public PropStatusObserver PropStatusObserver { get; private set; }

		public DirtSettings DirtSettings { get; private set; }

		public LevelEditor LevelEditor { get; private set; }

		public Narrator Narrator { get; private set; }

		public WorldmapController WorldMapController { get; private set; }

		public MODE MouseMode
		{
			get
			{
				return default(MODE);
			}
			set
			{
			}
		}

		public Dictionary<string, GameItemType> GameItemTypes { get; private set; }

		public List<MerchantData> Merchants { get; set; }

		public bool IsStartUpFinished { get; set; }

		public bool IsAssigningStaffActive => false;

		public bool IsAssigningRoomsActive => false;

		public bool IsAssigningBedsActive => false;

		public bool IsHoveringAssignableObject
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector3 LastRightClickPosition { get; private set; }

		public static event EventHandler MouseModeChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler LongLeftClickHappened
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler LevelReady
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler TavernGrandOpening
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void UpdateIsGameReady()
		{
		}

		public override void Awake()
		{
		}

		private void Start()
		{
		}

		public void Init()
		{
		}

		private void OnBuildableChanged(object sender, EventArgs<Buildable> e)
		{
		}

		private void OnGreenbackLogin(object sender, EventArgs e)
		{
		}

		private void OnGraphsUpdated(AstarPath script)
		{
		}

		private void HandleUIRightClick()
		{
		}

		private static void ClearStartupChecksFlag()
		{
		}

		private static bool AreStartupChecksEnabled()
		{
			return false;
		}

		private void CheckCraftProcesses()
		{
		}

		private void CheckItemTypesForCraftingProcesses()
		{
		}

		private void EnableStatReport()
		{
		}

		public void SetInitialForward(int hours)
		{
		}

		public Vector2 GetMousePositionOnFloorGrid()
		{
			return default(Vector2);
		}

		public void StartLevel(string levelName)
		{
		}

		public void Update()
		{
		}

		private void SetupInputMethods()
		{
		}

		private void OnEscape()
		{
		}

		private void UpdateCloneToolHighlight()
		{
		}

		private void ClonePropUnderMouse()
		{
		}

		private void CloneDecorationUnderMouse()
		{
		}

		public void UpdateControls()
		{
		}

		private void ClearStaticLists()
		{
		}

		public void StartUpFinished()
		{
		}

		private void LateUpdate()
		{
		}

		private bool IsHoveringAssignableObjectCheck(GameObject hoveredObj)
		{
			return false;
		}

		private void UpdateStaffAssignment()
		{
		}

		private void UpdateRoomAssignment()
		{
		}

		private void UpdateBedAssignment()
		{
		}

		public void InitComponentsAfterLevelsLoaded()
		{
		}

		public void SetTavernData(Tavern tavern)
		{
		}

		private void CheckLevelConfig()
		{
		}

		public void InitComponentsPostLoad()
		{
		}

		public void InitComponentsFinishedLoading(bool isNewGame)
		{
		}

		private void PreFirstUpdateAfterLoad(object sender, EventArgs eventArgs)
		{
		}

		public void ObjectClicked(GameObject clickedObject)
		{
		}

		public GameObject GetClickableObjectUnderMousePointer()
		{
			return null;
		}

		public void AdjustMoney(int adjustment, string category, string reasonKey, bool unscaledTime = false, bool showFloatingText = true, bool triggerCashAudio = true)
		{
		}

		public void AdjustMoney(int adjustment, string category, string reasonKey, Vector3 spawnPosition, bool unscaledTime, bool showFloatingText = true, bool triggerCashAudio = true)
		{
		}

		public void AdjustMoneyUI(int adjustment, string category, string reasonKey, Vector2 screenPoint, bool unscaledTime = true)
		{
		}

		private void AdjustMoneyInternal(int adjustment, string category, string reasonKey)
		{
		}

		public void SpawnMoneyAdjustmentFloatingText(int adjustment, Vector3 spawnPosition, bool unscaledTime, bool useUIText, bool triggerCashAudio = true)
		{
		}

		public GameObject SpawnActor(Type type, Vector3 pos, Quaternion rotation, ActorData actorData = null)
		{
			return null;
		}

		public void ResetMouseMode()
		{
		}

		private void ResetMultiSelection()
		{
		}

		public void ToggleStaffAssignmentMode()
		{
		}

		public void ToggleRoomAssignmentMode()
		{
		}

		public void ToggleBedAssignmentMode()
		{
		}

		public void OpenTavernFirstTime(bool suspendMarketingEffect = false)
		{
		}

		public void OnDestroy()
		{
		}

		public void QuitGame()
		{
		}

		private bool OnWantsToQuit()
		{
			return false;
		}

		private bool PrepareGameReadyToQuit(bool allowInterrupts)
		{
			return false;
		}

		private bool TryShowEndOfSessionNewsletter()
		{
			return false;
		}

		internal void ClearAll()
		{
		}

		public void CycleSelectedObject(GameObjectX[] objects, bool reverseDirection = false, Action<GameObjectX> customAction = null)
		{
		}

		public void RefreshLevelBasedPrefabs(string levelName)
		{
		}

		public void TryUnlockSpecialContent(string contentUnlocks)
		{
		}

		public void EnsureGameNotBusy()
		{
		}

		public void ExitToMainMenu(string viewId = "mainMenu")
		{
		}
	}
}
