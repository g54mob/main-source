using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Drone : MonoBehaviour, IAffectedBySlime, IBreakable, ICombatTarget, IDamagableObject, IHasHitpoints, IOverrideHitpoints, ITargetLocation, IToggleVisibilityInSchematic, ICommandable, IDrone, ITowItem, IHasVideoThatCanFail
{
	private const float damageWarningTimerDuration = 10f;

	private const float DELAY_BETWEEN_COLLISION = 1f;

	private const float DRONE_UPGRADE_BREAK_CHECK_PERIOD = 1f;

	private const float _mass = 0.5f;

	private const float SELF_DESTRUCT_DELAY = 3f;

	private const float NON_PENETRATION_COOLDOWN = 0.08f;

	private const string NON_PENETRATION_KEY = "collisionFriction";

	private const float PILOT_COLISION_SLOWDOWN_FACTOR = 0.7f;

	private const float MIN_SHARP_ANGLE = 30f;

	private const float MAX_SHARP_ANGLE = 150f;

	private const float MIN_NO_SLOW_ANGLE = 80f;

	private const float MAX_NO_SLOW_ANGLE = 100f;

	private const float TEMP_COLLIDE_STOP_TIME = 0.1f;

	private const float TEMP_COLLIDE_COOLDOWN = 0.15f;

	private const float DIRECTIONAL_BRAKES_DELAY = 0.35f;

	private const string SLIME_MODIFIER_KEY = "slime";

	public const float ROTATION_SPEED = 180f;

	public const float MinimumUsefulMoveSpeed = 0.001f;

	public static bool NagivateHintNotNeeded = false;

	public GameObject TurretUIObject;

	public GameObject TurretCollisionObject;

	public GameObject ShieldUIObject;

	public GameObject OverlayLabelObject;

	public GameObject Swival;

	public Material DroneViewTurretOffMtl;

	public Material DroneViewTurretOnMtl;

	public Material DroneViewTurretSafteyMtl;

	public Material DroneViewGatGunOnMtl;

	public Material DroneViewGatGunOffMtl;

	public Material DroneViewGatGunSafteyMtl;

	public Material DroneViewShieldOnMtl;

	public Material DroneViewShieldOffMtl;

	public Material DroneViewShieldBrokenMtl;

	public Material SchematicViewTurretOffMtl;

	public Material SchematicViewTurretOnMtl;

	public Material SchematicViewTurretSafteyMtl;

	public Material SchematicViewGatGunOnMtl;

	public Material SchematicViewGatGunOffMtl;

	public Material SchematicViewGatGunSafteyMtl;

	public Material SchematicViewShieldOnMtl;

	public Material SchematicViewShieldOffMtl;

	public Material SchematicViewShieldBrokenMtl;

	public Material DeathMtl;

	public Material DeathMtlSV;

	public Material DeathMtl_02;

	public Material DeathMtl_03;

	public Material DeathMtl_04;

	public Material DeathMtl_05;

	public Material DeathMtl_06;

	public Material DisabledMaterialDV;

	public Material DisabledMaterialSV;

	public Material DisabledMaterialDV_02;

	public Material DisabledMaterialDV_03;

	public Material DisabledMaterialDV_04;

	public Material DisabledMaterialDV_05;

	public Material DisabledMaterialDV_06;

	public Material StunMtl;

	public Material StunMtlSV;

	public Material StunMtl_02;

	public Material StunMtl_03;

	public Material StunMtl_04;

	public Material StunMtl_05;

	public Material StunMtl_06;

	public Color AliveColor = Color.blue;

	public Color HitColor = Color.red;

	public Color DisabledColor = Color.gray;

	public Color DeadColor = Color.red;

	public Color LowStealthColor = Color.blue;

	public Color DisabledNumberColor = new Color(1f, 0.5f, 0f, 1f);

	public Color DeadNumberColor = Color.red;

	public Color DisabledNameColor = Color.gray;

	public Color DeadNameColor = Color.gray;

	public AudioSource turretSound;

	public AudioSource fuelGatherSound;

	public AudioSource motionSensorSound;

	public AudioSource teleportSound;

	public AudioSource transportSound;

	public AudioSource sonicSound;

	public AudioSource stealthSound;

	public AudioSource shieldSound;

	public AudioSource dropSound;

	public AudioSource towLatchSound;

	public AudioSource towMoveSound;

	public AudioSource prySound;

	public AudioSource explosionSound;

	protected Material _imagePlaneMat;

	private bool _isVisible = true;

	public SteeringType steeringType;

	public bool isMoving;

	public bool isMovingForwardBack;

	private bool isMovingBackwards;

	private bool isRotating;

	private bool canPlayCollisionSound = true;

	private float timerDelayUntilNextCollisionPlay;

	private float _velocityScale = 2.4f;

	private string _droneName = string.Empty;

	private string _guiDroneNote = string.Empty;

	private Vector3 lastPosition = Vector3.zero;

	private float guiHitPoints;

	private float guiSpeed;

	private string _guiDroneStatus = string.Empty;

	public int _droneNumber;

	private bool _isDead;

	public List<BaseEnemy> enemies;

	private ColorBlinkManager blinkManager = new ColorBlinkManager();

	private bool _isHidden;

	private Material startMtl;

	private Material startMtlSV;

	private Color startColor;

	private DroneItemDropper itemDropper;

	private float damageWarningTimer;

	private float currentHitPoints;

	private Dictionary<string, float> _speedModifiers = new Dictionary<string, float>();

	protected static System.Random _random = new System.Random();

	private Bounds missFireBounds = new Bounds(Vector3.zero, new Vector3(4f, 4f, 2f));

	private bool _underPlayerControl = true;

	private DroneBrain _brain;

	private GameObject _imagePlane;

	private GameObject _imagePlaneSV;

	private Renderer _imagePlaneRenderer;

	private Renderer _imagePlaneSVRenderer;

	private bool isInSelfDestructMode;

	private float _selfDestructTimer;

	private int timerIntPrev;

	private Light[] droneLights;

	private bool scanned;

	private bool firstUpdate = true;

	private VideoFailManager _videoFailManager;

	private ModificationStorageIdEnum _appliedModifications;

	private bool inLowUpgradeMode;

	private bool flashingStealth;

	private float delayUntilNextFlash;

	private float delayForFlash;

	private AudioSource asREngineSustain;

	private AudioSource asRCallSign;

	private AudioSource asRCollision;

	private AudioSource asRPickup;

	private GameAudio.SoundEnum soundREngineSustain;

	private GameAudio.SoundEnum soundRCallSign;

	private float engineNormalPitch;

	private bool isREngineSustainPaused;

	private bool isRMotionPaused;

	private bool isRTurretPaused;

	private bool isRTowMovePaused;

	private Vector3 pulledDestPoint = Vector3.zero;

	private Vector3 distPerFrame = Vector3.zero;

	private float remainingDistToDestPoint;

	public Corridor airlockSuckingOut;

	private bool isOverlayOutofSync;

	private float timeUntilOverlaySnapBack;

	private DroneCollisionCube _collisionCube;

	private DroneFeelers _frontFeelers;

	private GameObject _rearFeeler;

	private List<GameObject> _collidingWallsLeft = new List<GameObject>(5);

	private List<GameObject> _collidingWallsMiddle = new List<GameObject>(5);

	private List<GameObject> _collidingWallsRight = new List<GameObject>(5);

	private List<GameObject> _collidingWallsRear = new List<GameObject>(5);

	private GameObject _labelSV;

	private GameObject _imagePlaneSV_Reference;

	private GameObject _labelSV_Reference;

	private GameObject _shieldOverlay;

	private GameObject _turretOverlay;

	private GameObject _shieldOverlay_Reference;

	private GameObject _turretOverlay_Reference;

	private GameObject _overlaysRoot;

	private float _nonPenetrationTimer;

	private float _gradedPilotColisionSlowdown = 0.7f;

	private bool _sharpCollisionForward;

	private bool _sharpCollisionReverse;

	private bool _tempCollideStop;

	private float _tempCollideTimer;

	private float _tempCollideCooldown;

	private bool isShaking;

	private float timerShakeDelayPitch;

	private float timerShakeDelayRoll;

	private float timerShakeDelayYaw;

	private float timerShakeLength;

	private float shakeDistPerUpdatePitch;

	private float shakeDistPerUpdateRoll;

	private float shakeDistPerUpdateYaw;

	private short lastShakeDirPitch;

	private short lastShakeDirRoll;

	private short lastShakeDirYaw;

	private float timerTillTestShowNoise;

	private Renderer droneRenderer;

	private Renderer shieldRenderer;

	private Renderer turretRenderer;

	private TextMesh overlayTextMesh;

	private bool hasSpeedBoost;

	private BaseDroneUpgrade speedBoostUpgrade;

	private bool isDelayUntilNextMicSound;

	private float timerDelayUntilNextMicSound;

	private bool _alreadyEnabledHelpText;

	private List<CommandDefinition> commandList;

	private List<CommandDefinition> baseCommandList;

	private List<ExecutedCommand> queuedCommands = new List<ExecutedCommand>();

	private bool currentlyProcessingACommand;

	private float _totalHitpoints;

	private Room _currentRoom;

	private float guiCurrentHitpoints;

	private string _guiString = string.Empty;

	private Vector3 _directionalForce = Vector3.zero;

	private float _directionalBrakesDelayTimer;

	private string _TowId = string.Empty;

	private string _TowFriendlyId = string.Empty;

	private Vector3 _heading;

	private float _slimeSnareTimer;

	public List<GameObject> CollidingObjects = new List<GameObject>(10);

	public List<BaseDroneUpgrade> Upgrades { get; set; }

	public DroneViewProcessor DVP { get; set; }

	public bool Found
	{
		get
		{
			if (droneUIObject != null)
			{
				return droneUIObject.Visible;
			}
			return false;
		}
	}

	public GameObject droneViewModel { get; private set; }

	public bool ignoreOnExit { get; set; }

	public bool IsUnderShipControl { get; private set; }

	public Light spotlight { get; set; }

	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		set
		{
			if (droneUIObject == null || droneUIObject.Visible)
			{
				_isVisible = value;
			}
		}
	}

	public bool IsOverlayVisible
	{
		get
		{
			if (droneUIObject != null)
			{
				return droneUIObject.Visible;
			}
			return false;
		}
	}

	public bool IsBraking { get; private set; }

	public DungeonInfo DungeonLeftIn { get; set; }

	public Vector3 LastPosition { get; set; }

	public Quaternion LastRotation { get; set; }

	public float CurrentMaxSpeed { get; set; }

	public float CurrentRawSpeed { get; set; }

	public float OriginalSpeed { get; set; }

	public float CurrentMaxRawSpeed
	{
		get
		{
			return CurrentMaxSpeed * _velocityScale;
		}
	}

	public float FixedMaxRawSpeed
	{
		get
		{
			return OriginalSpeed * _velocityScale;
		}
	}

	public int NumberOfUpgradeSlots { get; set; }

	public ITowItem ItemBeingTowed { get; private set; }

	public string DroneName
	{
		get
		{
			return _droneName;
		}
		set
		{
			_droneName = value;
			DroneNameLower = value.ToLower();
			if (OverlayLabelObject != null)
			{
				overlayTextMesh.text = value;
			}
		}
	}

	public string DroneNameLower { get; private set; }

	public string guiDroneNote
	{
		get
		{
			if (string.IsNullOrEmpty(_guiDroneNote))
			{
				_guiDroneNote = string.Format(" ({0})", DroneName);
			}
			return _guiDroneNote;
		}
	}

	public string guiDroneStatus
	{
		get
		{
			if (guiHitPoints != CurrentHitPoints || guiSpeed != OriginalSpeed)
			{
				_guiDroneStatus = "HP: " + CurrentHitPoints + ", SPD: " + OriginalSpeed;
				guiHitPoints = CurrentHitPoints;
				guiSpeed = OriginalSpeed;
			}
			return _guiDroneStatus;
		}
	}

	public bool HasMoved { get; private set; }

	public EngineTypeEnum engineType { get; set; }

	public int InternalID { get; set; }

	public int DVPSeed { get; set; }

	public string DVPName { get; set; }

	public float TraitVeer { get; set; }

	public float TraitPermVeer { get; set; }

	public float TraitPitchOffset { get; set; }

	public int CSID { get; set; }

	public int DroneNumber
	{
		get
		{
			return _droneNumber;
		}
		set
		{
			_droneNumber = value;
			if (OverlayLabelObject != null)
			{
				Transform transform = OverlayLabelObject.transform.Find("DroneNumber");
				if (transform != null)
				{
					string text = value.ToString();
					transform.GetComponent<TextMesh>().text = text.PadLeft(2, '0');
				}
			}
		}
	}

	public bool InterfaceDisconnected { get; set; }

	public bool CanBeFullyRepaired { get; set; }

	public bool IsInSpace { get; private set; }

	public float RotationRate
	{
		get
		{
			return 180f * Time.deltaTime;
		}
	}

	public int DaysTraveledWhileDead { get; set; }

	public bool IsUnderPlayerControl
	{
		get
		{
			return _underPlayerControl;
		}
	}

	public DroneBrain brain
	{
		get
		{
			return _brain;
		}
	}

	public bool isGatheringLoot { get; set; }

	public bool isPumpingFuel { get; set; }

	public float timerLastPumpingFuelNotification { get; set; }

	public DroneUIObject droneUIObject { get; private set; }

	public float TimeInMission { get; set; }

	public float TimePassed
	{
		get
		{
			return TimeInMission;
		}
	}

	public bool VideoSignalLost { get; set; }

	public float TimeOfNextVideoLoss { get; set; }

	public float TimeOfNextWarningVideoLoss { get; set; }

	public float VideoLossDuration { get; set; }

	public float TimeOfNextVideoRestore { get; set; }

	public float TimeTilNextFailMin { get; set; }

	public float TimeTilNextFailMax { get; set; }

	public ModificationStorageIdEnum AppliedModifications
	{
		get
		{
			return _appliedModifications;
		}
		set
		{
			_appliedModifications = value;
		}
	}

	public int DroneVisualIndex { get; set; }

	public bool WasScanned { get; private set; }

	public bool isMicGlitching { get; private set; }

	public AudioListener listener { get; set; }

	public bool isBeingPulledOut { get; private set; }

	public bool IsBeingSwapped { get; set; }

	public Transform dvOverlayTrans { get; private set; }

	public bool CollidingWallLeft
	{
		get
		{
			return _collidingWallsLeft.Count > 0;
		}
	}

	public bool CollidingWallMiddle
	{
		get
		{
			return _collidingWallsMiddle.Count > 0;
		}
	}

	public bool CollidingWallRight
	{
		get
		{
			return _collidingWallsRight.Count > 0;
		}
	}

	public bool CollidingWallRear
	{
		get
		{
			return _collidingWallsRear.Count > 0;
		}
	}

	public bool IsPrimaryCommandContext { get; set; }

	public string CommandHeader
	{
		get
		{
			return "Active Drone: " + DroneNumber;
		}
	}

	public Vector3 Position
	{
		get
		{
			return base.transform.position;
		}
	}

	public Collider ObjectCollider
	{
		get
		{
			return GetComponent<Collider>();
		}
	}

	public bool CanCollide
	{
		get
		{
			return true;
		}
	}

	public List<ICombatTarget> SubordinateTargets { get; set; }

	public bool IsHidden
	{
		get
		{
			return _isHidden;
		}
	}

	public Room CurrentRoom
	{
		get
		{
			return _currentRoom;
		}
		set
		{
			_currentRoom = value;
			if (droneUIObject != null)
			{
				droneUIObject.roomLst = new List<Room>();
				droneUIObject.roomLst.Add(value);
			}
		}
	}

	public Corridor CurrentCorridor { get; set; }

	public float CurrentHitPoints
	{
		get
		{
			return currentHitPoints;
		}
	}

	public float TotalHitpoints
	{
		get
		{
			return _totalHitpoints;
		}
	}

	public float TimeStunned { get; private set; }

	public bool IsDead
	{
		get
		{
			return _isDead;
		}
	}

	public bool IsStunned { get; private set; }

	public Vector3 StunPosition { get; private set; }

	public bool IsDisabledButAlive { get; set; }

	public string guiStatus
	{
		get
		{
			if (guiCurrentHitpoints != CurrentHitPoints)
			{
				_guiString = " (" + Math.Round(CurrentHitPoints, 0) + ") ";
				guiCurrentHitpoints = CurrentHitPoints;
			}
			return _guiString;
		}
	}

	public BrokenStateEnum BrokenState
	{
		get
		{
			if (IsDead)
			{
				return BrokenStateEnum.Broken;
			}
			return BrokenStateEnum.OK;
		}
	}

	public string RepairId
	{
		get
		{
			return "drone" + DroneNumber;
		}
	}

	public string TowId
	{
		get
		{
			if (_TowId == string.Empty)
			{
				_TowId = string.Format("{0}", DroneName);
			}
			return _TowId;
		}
	}

	public string TowFriendlyId
	{
		get
		{
			if (_TowFriendlyId == string.Empty)
			{
				_TowFriendlyId = string.Format("drone '{0}'", DroneName);
			}
			return _TowFriendlyId;
		}
	}

	public GameObject UnderlyingGameObject
	{
		get
		{
			return base.gameObject;
		}
	}

	public bool CanBeTowed { get; set; }

	public string CantTowReason
	{
		get
		{
			string result = string.Empty;
			if (!IsDead)
			{
				result = string.Format("Cannot tow drone '{0}' because it is not dead", DroneName);
			}
			else if (!CanBeFullyRepaired)
			{
				result = string.Format("Cannot tow drone '{0}' because it is destroyed", DroneName);
			}
			return result;
		}
	}

	public bool IsBeingTowed { get; set; }

	public Transform TowItemTransform
	{
		get
		{
			return base.transform;
		}
	}

	public Color TowColor
	{
		get
		{
			return Color.blue;
		}
	}

	public float SlimeDamageTimer { get; set; }

	public bool IsInvisibleDueToToggle { get; set; }

	public event ReceivedDamageDelegate OnReceivedDamage;

	private void Awake()
	{
		Upgrades = new List<BaseDroneUpgrade>();
		currentHitPoints = TotalHitpoints;
		Upgrades.Clear();
		for (int i = 0; i < 4; i++)
		{
			Upgrades.Add(null);
		}
		SubordinateTargets = new List<ICombatTarget>();
		SlimeDamageTimer = 0f;
		droneLights = GetComponentsInChildren<Light>();
		_videoFailManager = new VideoFailManager(this, 1200f, 6000f, 900f, 1800f, 15f, 30f, 0f, 0f);
		listener = (AudioListener)base.gameObject.GetComponentInChildren(typeof(AudioListener));
		listener.enabled = false;
		droneRenderer = GetComponent<Renderer>();
		shieldRenderer = ShieldUIObject.GetComponent<Renderer>();
		turretRenderer = TurretUIObject.GetComponent<Renderer>();
		overlayTextMesh = OverlayLabelObject.GetComponent<TextMesh>();
	}

	private void Start()
	{
		Transform transform = base.transform.Find("Label");
		if (transform != null)
		{
			_labelSV = transform.gameObject;
			TextMesh component = transform.GetComponent<TextMesh>();
			int result = 0;
			if (component != null && int.TryParse(component.text, out result))
			{
				DroneNumber = result;
			}
		}
		transform = base.transform.Find("Label_Reference");
		if (transform != null)
		{
			_labelSV_Reference = transform.gameObject;
		}
		Transform transform2 = base.transform.Find("Overlays");
		if (transform2 != null)
		{
			_overlaysRoot = transform2.gameObject;
			_turretOverlay = transform2.Find("TurretUI").gameObject;
			_turretOverlay_Reference = transform2.Find("TurretUI_Reference").gameObject;
			_shieldOverlay = transform2.Find("ShieldUI").gameObject;
			_shieldOverlay_Reference = transform2.Find("ShieldUI_Reference").gameObject;
		}
		Transform transform3 = base.transform.Find("CollisionCube");
		if (transform3 != null)
		{
			_collisionCube = transform3.GetComponent<DroneCollisionCube>();
			_collisionCube.SetMyDrone(this);
		}
		Transform transform4 = base.transform.Find("FrontFeelers");
		if (transform4 != null)
		{
			_frontFeelers = transform4.GetComponent<DroneFeelers>();
			_frontFeelers.SetMyDrone(this);
		}
		transform4 = base.transform.Find("RearFeeler");
		if (transform4 != null)
		{
			_rearFeeler = transform4.gameObject;
		}
		itemDropper = (DroneItemDropper)GetComponent(typeof(DroneItemDropper));
		_brain = new DroneBrain(this);
		_brain.Initialize();
		if (droneUIObject == null)
		{
			Transform transform5 = base.transform.Find("DroneUI");
			if (transform5 != null)
			{
				droneUIObject = (DroneUIObject)transform5.gameObject.GetComponent(typeof(DroneUIObject));
			}
			else
			{
				Debug.LogWarning("hmmmm could not find DronUIObject on " + DroneName);
			}
		}
		AddSoundSources();
		timerTillTestShowNoise = UnityEngine.Random.Range(55f, 65f);
		TowManager.Instance.RegisterTowableItem(this);
	}

	private void OnDestroy()
	{
		RemoveSoundSources();
		if (DVP != null)
		{
			DVP.Unload();
		}
		shieldRenderer = null;
		droneRenderer = null;
		DroneViewTurretOffMtl = null;
		DroneViewTurretOnMtl = null;
		DroneViewTurretSafteyMtl = null;
		DroneViewGatGunOnMtl = null;
		DroneViewGatGunOffMtl = null;
		DroneViewGatGunSafteyMtl = null;
		DroneViewShieldOnMtl = null;
		DroneViewShieldOffMtl = null;
		DroneViewShieldBrokenMtl = null;
		SchematicViewTurretOffMtl = null;
		SchematicViewTurretOnMtl = null;
		SchematicViewTurretSafteyMtl = null;
		SchematicViewGatGunOnMtl = null;
		SchematicViewGatGunOffMtl = null;
		SchematicViewGatGunSafteyMtl = null;
		SchematicViewShieldOnMtl = null;
		SchematicViewShieldOffMtl = null;
		SchematicViewShieldBrokenMtl = null;
		DeathMtl = null;
		DeathMtlSV = null;
		DeathMtl_02 = null;
		DeathMtl_03 = null;
		DeathMtl_04 = null;
		DeathMtl_05 = null;
		DeathMtl_06 = null;
		DisabledMaterialDV = null;
		DisabledMaterialSV = null;
		DisabledMaterialDV_02 = null;
		DisabledMaterialDV_03 = null;
		DisabledMaterialDV_04 = null;
		DisabledMaterialDV_05 = null;
		DisabledMaterialDV_06 = null;
		StunMtl = null;
		StunMtlSV = null;
		StunMtl_02 = null;
		StunMtl_03 = null;
		StunMtl_04 = null;
		StunMtl_05 = null;
		StunMtl_06 = null;
		TurretUIObject = null;
		TurretCollisionObject = null;
		ShieldUIObject = null;
		OverlayLabelObject = null;
		Swival = null;
		turretSound = null;
		fuelGatherSound = null;
		motionSensorSound = null;
		teleportSound = null;
		transportSound = null;
		towLatchSound = null;
		towMoveSound = null;
		prySound = null;
		UnityEngine.Object.DestroyImmediate(_imagePlaneMat);
	}

	public void PullOutOfRoom(Vector3 destinationPoint, Corridor airlockSuckingOut)
	{
		isBeingPulledOut = true;
		pulledDestPoint = destinationPoint;
		remainingDistToDestPoint = Vector3.Distance(base.transform.position, destinationPoint);
		distPerFrame = base.transform.position - destinationPoint;
		distPerFrame.Normalize();
		distPerFrame *= 0.2f;
		this.airlockSuckingOut = airlockSuckingOut;
		isMicGlitching = true;
		timerDelayUntilNextMicSound = UnityEngine.Random.Range(1, 3);
	}

	public void CancelSuckOutOfRoom()
	{
		isBeingPulledOut = false;
		pulledDestPoint = Vector3.zero;
		remainingDistToDestPoint = 0f;
		distPerFrame = Vector3.zero;
		airlockSuckingOut = null;
		isMicGlitching = false;
		if (DroneManager.Instance.CurrentDrone == this)
		{
			listener.enabled = true;
		}
	}

	public void SetSelectedDroneVisual()
	{
		Transform transform = null;
		transform = ((!DroneManager.Instance.DebugUseTestSpotlight && !DroneManager.Instance.DebugUseCameraArraySpotlight) ? base.transform.Find("Spotlight") : ((!DroneManager.Instance.DebugUseCameraArraySpotlight) ? Swival.transform.Find("SpotlightTest") : base.transform.Find("SpotlightTestCameraArray")));
		spotlight = transform.GetComponent<Light>();
		Vector3 zero = Vector3.zero;
		zero.z = -0.025f;
		bool isTutorial = GlobalSettings.IsTutorial;
		string dVPName = string.Empty;
		switch (DroneVisualIndex)
		{
		case 0:
			droneViewModel = (GameObject)UnityEngine.Object.Instantiate(ResourceManager.LoadAsset<GameObject>("Prefabs/Models/drone01"), Vector3.zero, Quaternion.identity);
			droneViewModel.SetActive(isTutorial);
			droneViewModel.transform.parent = Swival.transform;
			droneViewModel.transform.localPosition = zero;
			dVPName = "default";
			transform.transform.position = new Vector3(transform.transform.position.x, transform.transform.position.y + 0.5f, transform.transform.position.z);
			break;
		case 1:
			droneViewModel = (GameObject)UnityEngine.Object.Instantiate(ResourceManager.LoadAsset<GameObject>("Prefabs/Models/drone02"), Vector3.zero, Quaternion.identity);
			droneViewModel.SetActive(isTutorial);
			droneViewModel.transform.parent = Swival.transform;
			droneViewModel.transform.localPosition = zero;
			dVPName = "matrix green";
			transform.transform.position = new Vector3(transform.transform.position.x, transform.transform.position.y + 0.54f, transform.transform.position.z);
			DeathMtl = DeathMtl_02;
			StunMtl = StunMtl_02;
			DisabledMaterialDV = DisabledMaterialDV_02;
			break;
		case 2:
			droneViewModel = (GameObject)UnityEngine.Object.Instantiate(ResourceManager.LoadAsset<GameObject>("Prefabs/Models/drone03"), Vector3.zero, Quaternion.identity);
			droneViewModel.SetActive(isTutorial);
			droneViewModel.transform.parent = Swival.transform;
			droneViewModel.transform.localPosition = zero;
			dVPName = "dot scanner";
			transform.transform.position = new Vector3(transform.transform.position.x, transform.transform.position.y + 0.57f, transform.transform.position.z);
			DeathMtl = DeathMtl_03;
			StunMtl = StunMtl_03;
			DisabledMaterialDV = DisabledMaterialDV_03;
			break;
		case 3:
			droneViewModel = (GameObject)UnityEngine.Object.Instantiate(ResourceManager.LoadAsset<GameObject>("Prefabs/Models/drone04"), Vector3.zero, Quaternion.identity);
			droneViewModel.SetActive(isTutorial);
			droneViewModel.transform.parent = Swival.transform;
			droneViewModel.transform.localPosition = zero;
			dVPName = "apple IIe";
			transform.transform.position = new Vector3(transform.transform.position.x, transform.transform.position.y + 0.68f, transform.transform.position.z);
			DeathMtl = DeathMtl_04;
			StunMtl = StunMtl_04;
			DisabledMaterialDV = DisabledMaterialDV_04;
			break;
		case 4:
			droneViewModel = (GameObject)UnityEngine.Object.Instantiate(ResourceManager.LoadAsset<GameObject>("Prefabs/Models/drone05"), Vector3.zero, Quaternion.identity);
			droneViewModel.SetActive(isTutorial);
			droneViewModel.transform.parent = Swival.transform;
			droneViewModel.transform.localPosition = zero;
			dVPName = ((UnityEngine.Random.Range(0, 100) >= 50) ? "tron1.0" : "tron2.0");
			transform.transform.position = new Vector3(transform.transform.position.x, transform.transform.position.y + 0.54f, transform.transform.position.z);
			DeathMtl = DeathMtl_05;
			StunMtl = StunMtl_05;
			DisabledMaterialDV = DisabledMaterialDV_05;
			break;
		case 5:
			droneViewModel = (GameObject)UnityEngine.Object.Instantiate(ResourceManager.LoadAsset<GameObject>("Prefabs/Models/drone06"), Vector3.zero, Quaternion.identity);
			droneViewModel.SetActive(isTutorial);
			droneViewModel.transform.parent = Swival.transform;
			droneViewModel.transform.localPosition = zero;
			dVPName = "terminator";
			transform.transform.position = new Vector3(transform.transform.position.x, transform.transform.position.y + 0.54f, transform.transform.position.z);
			DeathMtl = DeathMtl_06;
			StunMtl = StunMtl_06;
			DisabledMaterialDV = DisabledMaterialDV_06;
			break;
		}
		if (DVP == null)
		{
			if (string.IsNullOrEmpty(DVPName))
			{
				DVPName = dVPName;
			}
			if (DVPSeed <= 0)
			{
				DVPSeed = UnityEngine.Random.seed;
			}
			DVP = new DroneViewProcessor(DVPName);
			DVP.Initialize(DVPSeed);
			float num = DVPConfigurationManager.GetRandomNumeric(DVPName, "light", "range", 4);
			float num2 = num / 4f;
			Transform transform2 = null;
			transform2 = ((!DroneManager.Instance.DebugUseTestSpotlight && !DroneManager.Instance.DebugUseCameraArraySpotlight) ? base.transform.Find("Spotlight") : ((!DroneManager.Instance.DebugUseCameraArraySpotlight) ? Swival.transform.Find("SpotlightTest") : base.transform.Find("SpotlightTestCameraArray")));
			Light component = transform2.GetComponent<Light>();
			component.range = num;
			float randomNumeric = DVPConfigurationManager.GetRandomNumeric(DVPName, "light", "anglePer", 1f);
			float num3 = DVPConfigurationManager.GetNumeric(DVPName, "light", "angleCapMin", 110);
			float num4 = DVPConfigurationManager.GetNumeric(DVPName, "light", "angleCapMax", 110);
			float num5 = 110f * num2 * randomNumeric;
			if (num5 < num3)
			{
				num5 = num3;
			}
			else if (num5 > num4)
			{
				num5 = num4;
			}
			component.spotAngle = num5;
			Vector3 localPosition = component.transform.localPosition;
			if (component.spotAngle < 110f)
			{
				localPosition.y *= num2;
				if (localPosition.y <= 0f)
				{
					localPosition.y = 1f;
				}
			}
			component.transform.localPosition = localPosition;
			string cameraGroup = DVPConfigurationManager.GetCameraGroup(DVPName);
			if (!string.IsNullOrEmpty(cameraGroup))
			{
				foreach (Camera dvpCamera in DroneManager.Instance.dvpCameras)
				{
					if (dvpCamera.name == cameraGroup)
					{
						DVP.cameraGroup = dvpCamera;
						break;
					}
				}
			}
			if (DVP.cameraGroup != null)
			{
				DVP.SetDVPCamera(DVP.cameraGroup);
			}
			else
			{
				DVP.SetDVPCamera(DroneManager.Instance.DroneCamera);
			}
		}
		if (!GlobalSettings.IsTutorial && DroneManager.Instance.dronesList.Contains(this))
		{
			switch (DroneNumber)
			{
			case 1:
			{
				Transform[] componentsInChildren3 = droneViewModel.GetComponentsInChildren<Transform>(true);
				foreach (Transform transform5 in componentsInChildren3)
				{
					transform5.gameObject.layer = 19;
				}
				transform.GetComponent<Light>().cullingMask &= ~LayerMask.GetMask("Spotlight1Ignore");
				break;
			}
			case 2:
			{
				Transform[] componentsInChildren2 = droneViewModel.GetComponentsInChildren<Transform>(true);
				foreach (Transform transform4 in componentsInChildren2)
				{
					transform4.gameObject.layer = 20;
				}
				transform.GetComponent<Light>().cullingMask &= ~LayerMask.GetMask("Spotlight2Ignore");
				break;
			}
			case 3:
			{
				Transform[] componentsInChildren4 = droneViewModel.GetComponentsInChildren<Transform>(true);
				foreach (Transform transform6 in componentsInChildren4)
				{
					transform6.gameObject.layer = 21;
				}
				transform.GetComponent<Light>().cullingMask &= ~LayerMask.GetMask("Spotlight3Ignore");
				break;
			}
			case 4:
			{
				Transform[] componentsInChildren = droneViewModel.GetComponentsInChildren<Transform>(true);
				foreach (Transform transform3 in componentsInChildren)
				{
					transform3.gameObject.layer = 22;
				}
				transform.GetComponent<Light>().cullingMask &= ~LayerMask.GetMask("Spotlight4Ignore");
				break;
			}
			}
		}
		else
		{
			Transform[] componentsInChildren5 = droneViewModel.GetComponentsInChildren<Transform>(true);
			foreach (Transform transform7 in componentsInChildren5)
			{
				transform7.gameObject.layer = 0;
			}
		}
		try
		{
			dvOverlayTrans = base.transform.FindChild("Overlays");
			switch (DroneVisualIndex)
			{
			case 0:
			{
				_imagePlane = dvOverlayTrans.FindChild("ImagePlane").gameObject;
				string text = "default";
				SkinEnum currentSkin = GlobalSettings.GameState.CurrentSkin;
				if (currentSkin == SkinEnum.Halloween)
				{
					text = "halloween";
				}
				Texture2D mainTexture = ResourceManager.LoadAsset<Texture2D>("skins/" + text + "/ui/droneview/DroneSpriteWhite");
				if (!_imagePlaneMat)
				{
					_imagePlaneMat = _imagePlane.GetComponent<Renderer>().material;
				}
				_imagePlaneMat.mainTexture = mainTexture;
				break;
			}
			case 1:
				_imagePlane = dvOverlayTrans.FindChild("ImagePlane2").gameObject;
				break;
			case 2:
				_imagePlane = dvOverlayTrans.FindChild("ImagePlane3").gameObject;
				break;
			case 3:
				_imagePlane = dvOverlayTrans.FindChild("ImagePlane4").gameObject;
				break;
			case 4:
				_imagePlane = dvOverlayTrans.FindChild("ImagePlane5").gameObject;
				break;
			case 5:
				_imagePlane = dvOverlayTrans.FindChild("ImagePlane6").gameObject;
				break;
			}
			_imagePlaneRenderer = _imagePlane.GetComponent<Renderer>();
			_imagePlaneRenderer.enabled = false;
			_imagePlaneSV = base.transform.FindChild("SVImagePlane").gameObject;
			_imagePlaneSVRenderer = _imagePlaneSV.GetComponent<Renderer>();
			_imagePlaneSV_Reference = base.transform.FindChild("SVImagePlane_Reference").gameObject;
		}
		catch
		{
			Debug.LogError("Drone has no ImagePlane or SVImagePlane!!! (or label or shield UI)");
		}
		startMtl = _imagePlaneRenderer.material;
		startMtlSV = _imagePlaneSVRenderer.material;
		startColor = _imagePlaneRenderer.material.color;
		if (StunMtlSV == null)
		{
			StunMtlSV = StunMtl;
		}
		if (DeathMtlSV == null)
		{
			DeathMtlSV = DeathMtl;
		}
		if (DisabledMaterialSV == null)
		{
			DisabledMaterialSV = DisabledMaterialDV;
		}
		if (droneUIObject == null)
		{
			Transform transform8 = base.transform.Find("DroneUI");
			if (transform8 != null)
			{
				droneUIObject = (DroneUIObject)transform8.gameObject.GetComponent(typeof(DroneUIObject));
			}
			else
			{
				Debug.LogWarning("hmmmm could not find DronUIObject on " + DroneName);
			}
		}
		if (!(droneUIObject != null))
		{
			return;
		}
		string text2 = "ImagePlane";
		if (DroneVisualIndex > 0)
		{
			text2 += DroneVisualIndex + 1;
		}
		List<GameObject> list = droneUIObject.UIObjects.ToList();
		GameObject[] uIObjects = droneUIObject.UIObjects;
		foreach (GameObject gameObject in uIObjects)
		{
			if (gameObject.name.Contains("ImagePlane") && gameObject.name != text2)
			{
				list.Remove(gameObject);
			}
		}
		droneUIObject.UIObjects = list.ToArray();
	}

	public void EnableHelpText()
	{
		if (_alreadyEnabledHelpText)
		{
			return;
		}
		_alreadyEnabledHelpText = true;
		if (droneUIObject == null)
		{
			Transform transform = base.transform.Find("DroneUI");
			if (transform != null)
			{
				droneUIObject = (DroneUIObject)transform.gameObject.GetComponent(typeof(DroneUIObject));
			}
		}
		if (droneUIObject != null)
		{
			droneUIObject.InitHelpTextInfo("Drone", HelpTextTypeEnum.Drone, true);
			droneUIObject.AddInfoCommand("info");
			if (InterfaceDisconnected)
			{
				droneUIObject.AdjustInfoLabelPos(1f, 0f);
			}
			else
			{
				droneUIObject.AdjustInfoLabelPos(0.1f, -0.1f);
			}
			droneUIObject.RefreshInfoLabelPos();
		}
		else
		{
			Debug.LogWarning("EnableHelpText - tried to set help text info for drone and failed. - " + DroneName);
		}
	}

	private void Update()
	{
		if (firstUpdate)
		{
			if (droneUIObject != null && droneUIObject.roomLst == null && CurrentRoom != null)
			{
				droneUIObject.roomLst = new List<Room>();
				droneUIObject.roomLst.Add(CurrentRoom);
				CurrentRoom.AddDroneOverlayUI(droneUIObject);
			}
			if (!IsDead)
			{
				int count = Upgrades.Count;
				for (int i = 0; i < count; i++)
				{
					BaseDroneUpgrade baseDroneUpgrade = Upgrades[i];
					if (baseDroneUpgrade != null)
					{
						HelpTextManager.Instance.ProcessInstalledDroneUpgrade(baseDroneUpgrade);
					}
				}
			}
			firstUpdate = false;
		}
		if (!GlobalSettings.IsGamePaused && !isBeingPulledOut && !AliasUI.Instance.IsShowing)
		{
			timerTillTestShowNoise -= Time.deltaTime;
			if (timerTillTestShowNoise <= 0f)
			{
				if (UnityEngine.Random.Range(0, 100) < 20)
				{
					HUDOnlyCameraController.Instance.FireStaticOnDisabled(DroneNumber);
				}
				timerTillTestShowNoise = UnityEngine.Random.Range(55f, 65f);
			}
			if (GlobalSettings.cheatMode && Input.GetKeyDown(KeyCode.Return))
			{
				OverlayLabelObject.transform.parent = null;
				dvOverlayTrans.transform.Rotate(Vector3.forward, 1f);
				OverlayLabelObject.transform.parent = dvOverlayTrans.transform;
			}
			if (isDelayUntilNextMicSound)
			{
				timerDelayUntilNextMicSound -= Time.deltaTime;
				if (timerDelayUntilNextMicSound <= 0f)
				{
					isDelayUntilNextMicSound = false;
					timerDelayUntilNextMicSound = 0f;
				}
			}
			if (isMicGlitching)
			{
				timerDelayUntilNextMicSound -= Time.deltaTime;
				if (timerDelayUntilNextMicSound <= 0f)
				{
					if (GlobalSettings.cameraMode == CameraMode.Drone && DroneManager.Instance.CurrentDrone == this)
					{
						PlayRandomMicSound();
					}
					timerDelayUntilNextMicSound = UnityEngine.Random.Range(1f, 3f);
				}
			}
			if (isOverlayOutofSync)
			{
				timeUntilOverlaySnapBack -= Time.deltaTime;
				if (timeUntilOverlaySnapBack <= 0f)
				{
					SnapOverlaysBack();
				}
			}
			if (_nonPenetrationTimer > 0f)
			{
				_nonPenetrationTimer -= Time.deltaTime;
				if (_nonPenetrationTimer <= 0f)
				{
					RemoveSpeedModifier("collisionFriction");
					_gradedPilotColisionSlowdown = 0.7f;
				}
			}
			if (_tempCollideCooldown > 0f)
			{
				_tempCollideCooldown -= Time.deltaTime;
			}
			if (_tempCollideTimer > 0f)
			{
				_tempCollideTimer -= Time.deltaTime;
				if (_tempCollideTimer <= 0f)
				{
					_tempCollideStop = false;
					_tempCollideCooldown = 0.15f;
				}
			}
			if (!IsUnderShipControl)
			{
				isMovingForwardBack = false;
				isMovingBackwards = false;
				isRotating = false;
				isMoving = false;
				if (scanned)
				{
					if (droneUIObject != null)
					{
						droneUIObject.MakeVisible();
					}
					scanned = false;
				}
				if (isInSelfDestructMode)
				{
					int num = Mathf.CeilToInt(_selfDestructTimer);
					if (num != timerIntPrev && timerIntPrev != 0)
					{
						SystemMessageManager.ShowSystemMessage(string.Format("Drone {0} will self destruct in {1} seconds", DroneNumber, num), ConsoleMessageType.Warning);
					}
					timerIntPrev = num;
					_selfDestructTimer -= Time.deltaTime;
					if (_selfDestructTimer <= 0f)
					{
						SelfDestruct();
					}
					else if (IsDead)
					{
						isInSelfDestructMode = false;
					}
				}
				if (_isHidden && inLowUpgradeMode)
				{
					if (!flashingStealth)
					{
						delayUntilNextFlash -= Time.deltaTime;
						if (delayUntilNextFlash <= 0f)
						{
							flashingStealth = true;
							delayForFlash = 0.25f;
						}
					}
					else
					{
						delayForFlash -= Time.deltaTime;
						if (delayForFlash <= 0f)
						{
							flashingStealth = false;
							delayUntilNextFlash = 2f;
							_imagePlaneRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0.5f);
							_imagePlaneSVRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0.5f);
						}
					}
				}
				if (!IsDead)
				{
					if (SlimeDamageTimer >= 0f)
					{
						SlimeDamageTimer -= Time.deltaTime;
					}
					if (_slimeSnareTimer > 0f)
					{
						_slimeSnareTimer -= Time.deltaTime;
						if (_slimeSnareTimer <= 0f)
						{
							RemoveSpeedModifier("slime");
						}
					}
					if (!_underPlayerControl && (HasMoved || CollidingObjects.Count > 0 || CollidingWallLeft || CollidingWallMiddle || CollidingWallRight || CollidingWallRear))
					{
						CheckForObjectCollisions();
						CheckForWallCollisions();
					}
				}
				HasMoved = false;
				if (IsStunned)
				{
					TimeStunned -= Time.deltaTime;
					if (TimeStunned <= 0f)
					{
						ClearStun();
						GameplayManager.ShowConsoleMessage("Drone " + DroneNumber + " no longer stunned", ConsoleMessageType.Benefit);
					}
					else
					{
						Jitter();
					}
				}
				else
				{
					if ((GlobalSettings.cameraMode == CameraMode.Drone || GlobalSettings.cheatMode) && DroneManager.Instance.CurrentDrone == this && !IsUnderShipControl && !GlobalSettings.ShowingGameOverlayWindow && GameplayManager.Instance.WindowState != GameWindowStates.ShowHelpManual && !DialogUI.Instance.IsShowing && ((GlobalSettings.cameraMode == CameraMode.Drone && !CommonMethods.AnyModifierKeysPressed() && !IsBeingSwapped) || (GlobalSettings.cameraMode == CameraMode.Schematic && GlobalSettings.cheatMode && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))))
					{
						bool flag = false;
						if (_sharpCollisionForward && !Input.GetButton("Up"))
						{
							_sharpCollisionForward = false;
						}
						if (_sharpCollisionReverse && !Input.GetButton("Down"))
						{
							_sharpCollisionReverse = false;
						}
						if (!_sharpCollisionForward && !_tempCollideStop && Input.GetButton("Up") && _directionalForce.magnitude <= 0.001f)
						{
							moveForward();
							isMoving = true;
							isMovingForwardBack = true;
							if (ItemBeingTowed != null && GlobalSettings.cameraMode == CameraMode.Drone && !towMoveSound.isPlaying && !IsBraking)
							{
								towMoveSound.Play();
								towMoveSound.volume = GameAudio.RemoteVolume * 1f;
							}
						}
						if (!_sharpCollisionReverse && !_tempCollideStop && Input.GetButton("Down") && _directionalForce.magnitude <= 0.001f)
						{
							moveBackwards();
							isMovingBackwards = true;
							isMoving = true;
							isMovingForwardBack = true;
							flag = true;
							if (ItemBeingTowed != null && GlobalSettings.cameraMode == CameraMode.Drone && !towMoveSound.isPlaying)
							{
								towMoveSound.Play();
								towMoveSound.volume = GameAudio.RemoteVolume * 1f;
							}
						}
						if (Input.GetButton("Right"))
						{
							_sharpCollisionForward = false;
							_sharpCollisionReverse = false;
							rotate(0f - RotationRate);
							isMoving = true;
							isRotating = true;
						}
						if (Input.GetButton("Left"))
						{
							_sharpCollisionForward = false;
							_sharpCollisionReverse = false;
							rotate(RotationRate);
							isMoving = true;
							isRotating = true;
						}
						if (isRotating || flag)
						{
							PostMoveStep();
						}
						else if ((!_brain.PlayingSound || CurrentRawSpeed < 0.001f) && !_brain.IsRotating)
						{
							PostMovement();
						}
						if (!isMovingForwardBack && ItemBeingTowed != null && GlobalSettings.cameraMode == CameraMode.Drone && towMoveSound.isPlaying && _underPlayerControl)
						{
							towMoveSound.Stop();
						}
					}
					if (lastPosition != base.transform.position)
					{
						HasMoved = true;
						DroneManager.Instance.CalcDroneCurrentRoom(this);
						if (CurrentRoom == null)
						{
							DroneManager.Instance.CalcDroneCurrentCorridor(this);
						}
						else
						{
							CurrentCorridor = null;
						}
					}
					lastPosition = base.transform.position;
					if (!IsDead)
					{
						_brain.Update();
					}
					else if ((IsDead || _underPlayerControl) && _brain != null && _brain.CurrentState != "Idle")
					{
						_brain.StopNavigating();
					}
				}
				bool flag2 = true;
				Color color = Color.white;
				if (blinkManager.IsActive)
				{
					color = blinkManager.Update(Time.deltaTime);
				}
				else if (IsDead)
				{
					color = (CanBeFullyRepaired ? DisabledColor : DeadColor);
				}
				else if (IsStunned)
				{
					color = DisabledColor;
				}
				else if (!IsHidden)
				{
					color = AliveColor;
				}
				else if (flashingStealth)
				{
					color = LowStealthColor;
				}
				else
				{
					flag2 = false;
				}
				if (flag2)
				{
					if (GlobalSettings.cameraMode == CameraMode.Drone)
					{
						_imagePlaneRenderer.material.color = color;
					}
					else
					{
						_imagePlaneSVRenderer.material.color = color;
					}
				}
				if (Upgrades != null)
				{
					int count2 = Upgrades.Count;
					bool flag3 = false;
					for (int j = 0; j < count2; j++)
					{
						BaseDroneUpgrade baseDroneUpgrade2 = Upgrades[j];
						if (baseDroneUpgrade2 == null)
						{
							continue;
						}
						if (baseDroneUpgrade2 is GathererUpgrade)
						{
							if (flag3)
							{
								continue;
							}
							flag3 = true;
						}
						baseDroneUpgrade2.Update();
					}
				}
				if (damageWarningTimer > 0f)
				{
					damageWarningTimer -= Time.deltaTime;
				}
				if (GlobalSettings.MissionStarted && !IsDead)
				{
					TimeInMission += Time.deltaTime;
					if (!GlobalSettings.IsTutorial)
					{
						bool videoSignalLost = VideoSignalLost;
						_videoFailManager.Update();
						if (!VideoSignalLost && videoSignalLost)
						{
							SystemMessageManager.ShowSystemMessage(string.Format("Video signal restored for Drone {0}", DroneNumber), ConsoleMessageType.Benefit);
						}
						else if (VideoSignalLost && !videoSignalLost)
						{
							SystemMessageManager.ShowSystemMessage(string.Format("Lost video signal for Drone {0}", DroneNumber), ConsoleMessageType.Warning);
						}
					}
				}
			}
			else
			{
				droneUIObject.SetOverlayAlpha(DungeonManager.Instance.BoardingVessel.ShipAlpha);
			}
			if (_directionalForce.magnitude > 0.001f)
			{
				Vector3 vector = _directionalForce * Time.deltaTime;
				Vector3 position = base.transform.parent.position;
				base.transform.parent.position = new Vector3(base.transform.parent.position.x + vector.x * Time.deltaTime, base.transform.parent.position.y + vector.y * Time.deltaTime, 0f);
				if (_directionalBrakesDelayTimer > 0f)
				{
					_directionalBrakesDelayTimer -= Time.deltaTime;
				}
				if (_directionalBrakesDelayTimer <= 0f)
				{
					_directionalForce -= _directionalForce * Time.deltaTime * 22f;
				}
				if (!GlobalSettings.cheatMode)
				{
					EnforceNonPenetrationConstraint();
					if (IsInOuterSpace())
					{
						base.transform.parent.position = position;
					}
				}
			}
			if (isShaking)
			{
				timerShakeLength -= Time.deltaTime;
				if (timerShakeLength <= 0f)
				{
					EndShake();
				}
				else
				{
					timerShakeDelayPitch -= Time.deltaTime;
					timerShakeDelayRoll -= Time.deltaTime;
					timerShakeDelayYaw -= Time.deltaTime;
					if (timerShakeDelayPitch <= 0f)
					{
						ShakeX();
						timerShakeDelayPitch = 0.2f;
					}
					else
					{
						Swival.transform.Rotate(0f - shakeDistPerUpdatePitch * Time.deltaTime, 0f, 0f);
					}
					if (timerShakeDelayRoll <= 0f)
					{
						ShakeY();
						timerShakeDelayRoll = 0.1f;
					}
					else
					{
						Swival.transform.Rotate(0f, 0f - shakeDistPerUpdateRoll * Time.deltaTime, 0f);
					}
					if (timerShakeDelayYaw <= 0f)
					{
						ShakeZ();
						timerShakeDelayYaw = 0.2f;
					}
					else
					{
						Swival.transform.Rotate(0f, 0f, 0f - shakeDistPerUpdateYaw * Time.deltaTime);
					}
				}
			}
			if (!canPlayCollisionSound)
			{
				timerDelayUntilNextCollisionPlay -= Time.deltaTime;
				if (timerDelayUntilNextCollisionPlay <= 0f)
				{
					timerDelayUntilNextCollisionPlay = 0f;
					canPlayCollisionSound = true;
				}
			}
		}
		else
		{
			if (GlobalSettings.IsGamePaused || !isBeingPulledOut)
			{
				return;
			}
			base.transform.parent.position -= distPerFrame;
			TakeDamage(UnityEngine.Random.Range(0, 3), DamageType.Physical, null);
			float num2 = Vector3.Distance(base.transform.position, pulledDestPoint);
			if (num2 > remainingDistToDestPoint)
			{
				bool flag4 = false;
				if (CurrentRoom != null)
				{
					if (!CurrentRoom.IsPendingPressurize && CurrentRoom.openAirlock != null && (CurrentRoom.IsPendingDepressure || CurrentRoom.IsDepressurized))
					{
						List<Corridor> corridorList = new List<Corridor>();
						List<Room> testedRooms = new List<Room>();
						testedRooms.Add(CurrentRoom);
						if (CurrentRoom.GetCorridorToAirlockPath(ref testedRooms, CurrentRoom.openAirlock, ref corridorList))
						{
							flag4 = true;
						}
					}
				}
				else
				{
					flag4 = true;
				}
				if (flag4)
				{
					bool flag5 = false;
					if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector))
					{
						flag5 = CollectorPermUpgrade.Instance.CollectFleetDrone(this);
					}
					Vaporize(flag5);
					if (!flag5)
					{
						SystemMessageManager.ShowSystemMessage(string.Format("Drone {0} has gone tumbling out into space", DroneNumber), ConsoleMessageType.Error);
					}
					isBeingPulledOut = false;
				}
				else
				{
					CancelSuckOutOfRoom();
				}
			}
			if (GlobalSettings.cameraMode == CameraMode.Drone && DroneManager.Instance.CurrentDrone == this)
			{
				DroneManager.Instance.positionDroneCamera();
			}
			remainingDistToDestPoint = num2;
		}
	}

	public void Jitter()
	{
		float num = UnityEngine.Random.Range(-1f, 1f);
		switch (UnityEngine.Random.Range(0, 2))
		{
		case 0:
		{
			Vector3 vector = base.transform.forward * (0.25f * num) * Time.deltaTime;
			Vector3 a = base.transform.position + vector;
			float num2 = Vector3.Distance(base.transform.position, StunPosition);
			float num3 = Vector3.Distance(a, StunPosition);
			if (num3 > num2 && num3 >= 0.25f)
			{
				num *= -1f;
			}
			base.transform.position += new Vector3(1f, 1f, 0f) * (0.25f * num) * Time.deltaTime;
			break;
		}
		case 1:
			if (OverlayLabelObject != null)
			{
				OverlayLabelObject.transform.parent = null;
			}
			base.transform.Rotate(0f, 0f, 0f - num);
			if (OverlayLabelObject != null)
			{
				OverlayLabelObject.transform.parent = dvOverlayTrans;
			}
			break;
		}
		if (UnityEngine.Random.Range(0, 2) == 0)
		{
			Transform transform = null;
			transform = ((!DroneManager.Instance.DebugUseTestSpotlight && !DroneManager.Instance.DebugUseCameraArraySpotlight) ? base.transform.Find("Spotlight") : ((!DroneManager.Instance.DebugUseCameraArraySpotlight) ? Swival.transform.Find("SpotlightTest") : base.transform.Find("SpotlightTestCameraArray")));
			if (transform != null)
			{
				transform.gameObject.SetActive(!(num <= 0f));
			}
		}
	}

	public void StartShake()
	{
		if (!isShaking)
		{
			isShaking = true;
			timerShakeLength = 0.5f;
			timerShakeDelayPitch = 0.2f;
			timerShakeDelayRoll = 0.1f;
			timerShakeDelayYaw = 0.2f;
			lastShakeDirPitch = (short)UnityEngine.Random.Range(0, 2);
			lastShakeDirRoll = (short)UnityEngine.Random.Range(0, 2);
			lastShakeDirYaw = (short)UnityEngine.Random.Range(0, 2);
			ShakeX();
			ShakeY();
			ShakeZ();
		}
	}

	private void EndShake()
	{
		isShaking = false;
		timerShakeLength = 0f;
		timerShakeDelayYaw = 0f;
		Swival.transform.localRotation = Quaternion.identity;
	}

	private void ShakeX()
	{
		float num = UnityEngine.Random.Range(4f, 16f);
		if (lastShakeDirPitch == 0)
		{
			num *= -1f;
			lastShakeDirPitch = 1;
		}
		else
		{
			lastShakeDirPitch = 0;
		}
		float num2 = 5f;
		shakeDistPerUpdatePitch = num * num2;
	}

	private void ShakeY()
	{
		float num = UnityEngine.Random.Range(4f, 16f);
		if (lastShakeDirRoll == 0)
		{
			num *= -1f;
			lastShakeDirRoll = 1;
		}
		else
		{
			lastShakeDirRoll = 0;
		}
		float num2 = 5f;
		shakeDistPerUpdateRoll = num * num2;
	}

	private void ShakeZ()
	{
		float num = UnityEngine.Random.Range(4f, 16f);
		if (lastShakeDirYaw == 0)
		{
			num *= -1f;
			lastShakeDirYaw = 1;
		}
		else
		{
			lastShakeDirYaw = 0;
		}
		float num2 = 5f;
		shakeDistPerUpdateYaw = num * num2;
	}

	public void PostMoveStep()
	{
		if (BrokenState == BrokenStateEnum.Broken)
		{
			return;
		}
		if (CurrentRoom != null)
		{
			CurrentRoom.TestEdge(this);
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (!asREngineSustain.isPlaying)
			{
				if (!asREngineSustain.enabled)
				{
					asREngineSustain.enabled = true;
				}
				asREngineSustain.Play();
			}
			if (isMovingForwardBack && !isMovingBackwards)
			{
				asREngineSustain.pitch = engineNormalPitch * (CurrentRawSpeed / FixedMaxRawSpeed);
				if (IsUnderPlayerControl && isRotating)
				{
					asREngineSustain.pitch *= 0.9f;
				}
			}
			else if (isMovingForwardBack && isMovingBackwards)
			{
				asREngineSustain.pitch = engineNormalPitch * (CurrentMaxRawSpeed / FixedMaxRawSpeed);
			}
			else
			{
				asREngineSustain.pitch = engineNormalPitch * ((!IsUnderPlayerControl) ? 1f : 0.75f);
			}
			asREngineSustain.volume = GameAudio.VolumeMultiplier(soundREngineSustain, GameAudio.RemoteVolume);
			if (DroneManager.Instance.EnableStaleData && !IsBraking && !isPumpingFuel && (!DroneManager.Instance.EnableStaleDataOnCurrentOnly || DroneManager.Instance.CurrentDrone == this))
			{
				Transform transform = null;
				transform = ((!DroneManager.Instance.DebugUseTestSpotlight && !DroneManager.Instance.DebugUseCameraArraySpotlight) ? base.transform.Find("Spotlight") : ((!DroneManager.Instance.DebugUseCameraArraySpotlight) ? Swival.transform.Find("SpotlightTest") : base.transform.Find("SpotlightTestCameraArray")));
				DroneManager.Instance.DropLight(this, transform.GetComponent<Light>());
			}
		}
		else
		{
			DroneManager.Instance.PlaySingleSVDroneSound();
		}
	}

	public void PostMovement()
	{
		if (asREngineSustain.isPlaying)
		{
			asREngineSustain.Stop();
		}
	}

	public void BeginMoveWithBoardingVessel()
	{
		IsUnderShipControl = true;
		if (ShieldUIObject.activeSelf)
		{
			ShieldUIObject.SetActive(false);
		}
		if (TurretUIObject.activeSelf)
		{
			TurretUIObject.SetActive(false);
		}
	}

	public void EndMoveWithBoardingVessel()
	{
		IsUnderShipControl = false;
		droneUIObject.SetOverlayAlpha(1f);
		int count = Upgrades.Count;
		for (int i = 0; i < count; i++)
		{
			if (Upgrades[i] is ShieldUpgrade)
			{
				ShieldUIObject.SetActive(true);
			}
			else if (Upgrades[i] is BruteTurretUpgrade)
			{
				TurretUIObject.SetActive(true);
			}
		}
	}

	public void Vaporize(bool preserve)
	{
		if (droneUIObject != null)
		{
			droneUIObject.Deactivate();
		}
		DroneManager.Instance.ForgetDrone(this);
		if (!preserve)
		{
			Kill();
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			IsInSpace = true;
		}
		DroneManager.Instance.isInLostVideoState = true;
		VideoSignalLost = true;
	}

	public void Scanned()
	{
		if (droneUIObject != null)
		{
			droneUIObject.MakeVisible();
		}
		else
		{
			scanned = true;
		}
		WasScanned = true;
	}

	public void SetDroneNumber(int newDroneNumber)
	{
		Transform transform = base.transform.Find("Label");
		if (transform != null)
		{
			TextMesh component = transform.GetComponent<TextMesh>();
			component.text = newDroneNumber.ToString();
		}
		DroneNumber = newDroneNumber;
	}

	private void CheckForUpgradeBreak()
	{
		if (!IsDead && IsVisible)
		{
		}
	}

	private List<BaseDroneUpgrade> GetUpgradesThatCanFail()
	{
		List<BaseDroneUpgrade> list = new List<BaseDroneUpgrade>();
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade.PoweredUp && upgrade.BrokenState != BrokenStateEnum.Broken)
			{
				list.Add(upgrade);
			}
		}
		int num = list.Where((BaseDroneUpgrade x) => x.PoweredUp && x.Definition.Type == DroneUpgradeType.Generator).Count();
		int num2 = list.Where((BaseDroneUpgrade x) => x.PoweredUp && x.Definition.Type == DroneUpgradeType.Gatherer).Count();
		BaseDroneUpgrade baseDroneUpgrade = list.FirstOrDefault((BaseDroneUpgrade x) => x.PoweredUp && x.Definition.Type == DroneUpgradeType.Generator);
		if (num > 1)
		{
			BaseDroneUpgrade baseDroneUpgrade2 = list.FirstOrDefault((BaseDroneUpgrade x) => x.PoweredUp && x.BrokenState == BrokenStateEnum.OK && x.Definition.Type == DroneUpgradeType.Generator);
			if (baseDroneUpgrade2 != null)
			{
				baseDroneUpgrade = baseDroneUpgrade2;
			}
		}
		if (baseDroneUpgrade != null)
		{
			list.Remove(baseDroneUpgrade);
		}
		BaseDroneUpgrade baseDroneUpgrade3 = list.FirstOrDefault((BaseDroneUpgrade x) => x.PoweredUp && x.Definition.Type == DroneUpgradeType.Gatherer);
		if (num2 > 1)
		{
			BaseDroneUpgrade baseDroneUpgrade4 = list.FirstOrDefault((BaseDroneUpgrade x) => x.PoweredUp && x.BrokenState == BrokenStateEnum.OK && x.Definition.Type == DroneUpgradeType.Gatherer);
			if (baseDroneUpgrade4 != null)
			{
				baseDroneUpgrade3 = baseDroneUpgrade4;
			}
		}
		if (baseDroneUpgrade3 != null)
		{
			list.Remove(baseDroneUpgrade3);
		}
		return list;
	}

	public void SetEnemyList(List<BaseEnemy> enemyList)
	{
		enemies = enemyList;
	}

	public Vector3 GetVelocityVector(float adjustedSpeed)
	{
		return _heading * _velocityScale * adjustedSpeed * Time.deltaTime;
	}

	public Vector3 GetVelocityVectorRawSpeed(float rawSpeed)
	{
		return _heading * rawSpeed * Time.deltaTime;
	}

	public Vector3 GetVelocityVectorRawNoDelta(float rawSpeed)
	{
		return _heading * rawSpeed;
	}

	public void moveForward()
	{
		if (_isDead)
		{
			return;
		}
		if (isPumpingFuel)
		{
			if (timerLastPumpingFuelNotification <= 0f)
			{
				GameplayManager.ShowConsoleMessage("   Drone " + DroneNumber + " is gathering fuel - cannot move", ConsoleMessageType.Warning);
				timerLastPumpingFuelNotification = 1f;
			}
			return;
		}
		_underPlayerControl = true;
		_brain.SetAiIdle();
		ClearCommandHistory();
		if (!WouldBeLostInSpace(GetVelocityVector(CurrentMaxSpeed * 4f), base.transform.parent.position) || GlobalSettings.cheatMode)
		{
			_heading = base.transform.up;
			_brain.MoveForwardFull();
		}
		Door[] doors = DungeonManager.Instance.doors;
		foreach (Door door in doors)
		{
			if (door.state == DoorState.Closed && (door.sliderA.GetComponent<Collider>().bounds.Contains(DroneManager.Instance.CurrentDrone.transform.position) || door.sliderB.GetComponent<Collider>().bounds.Contains(DroneManager.Instance.CurrentDrone.transform.position)))
			{
				base.transform.parent.Translate(-GetVelocityVector(CurrentMaxSpeed));
				break;
			}
		}
		if (hasSpeedBoost)
		{
			speedBoostUpgrade.UpgradeUsed();
		}
	}

	public void moveBackwards()
	{
		_heading = base.transform.up;
		if (_isDead)
		{
			return;
		}
		if (isPumpingFuel)
		{
			if (timerLastPumpingFuelNotification <= 0f)
			{
				GameplayManager.ShowConsoleMessage("   Drone " + DroneNumber + " is gathering fuel - cannot move", ConsoleMessageType.Warning);
				timerLastPumpingFuelNotification = 1f;
			}
			return;
		}
		_underPlayerControl = true;
		_brain.SetAiIdle();
		ClearCommandHistory();
		if (!WouldBeLostInSpace(-GetVelocityVector(CurrentMaxSpeed * 4f), base.transform.parent.position) || GlobalSettings.cheatMode)
		{
			base.transform.parent.Translate(-GetVelocityVector(CurrentMaxSpeed));
			if (ItemBeingTowed is Drone && ((Drone)ItemBeingTowed).ForceNonPenetration())
			{
				RestartPilotColisionSlowdown();
			}
			EnforceNonPenetrationConstraint();
		}
		Door[] doors = DungeonManager.Instance.doors;
		foreach (Door door in doors)
		{
			if (door.state == DoorState.Closed && (door.sliderA.GetComponent<Collider>().bounds.Contains(DroneManager.Instance.CurrentDrone.transform.position) || door.sliderB.GetComponent<Collider>().bounds.Contains(DroneManager.Instance.CurrentDrone.transform.position)))
			{
				base.transform.parent.Translate(GetVelocityVector(CurrentMaxSpeed));
			}
		}
	}

	public void rotate(float rotationRate)
	{
		if (_isDead)
		{
			return;
		}
		if (isPumpingFuel)
		{
			if (timerLastPumpingFuelNotification <= 0f)
			{
				GameplayManager.ShowConsoleMessage("   Drone " + DroneNumber + " is gathering fuel - cannot move", ConsoleMessageType.Warning);
				timerLastPumpingFuelNotification = 1f;
			}
			return;
		}
		_underPlayerControl = true;
		_brain.SetAiIdle();
		ClearCommandHistory();
		if (OverlayLabelObject != null)
		{
			OverlayLabelObject.transform.parent = null;
		}
		base.transform.Rotate(0f, 0f, rotationRate);
		if (OverlayLabelObject != null)
		{
			OverlayLabelObject.transform.parent = dvOverlayTrans;
		}
		_heading = base.transform.up;
	}

	public void ForcedRotate(float rotationRate)
	{
		if (OverlayLabelObject != null)
		{
			OverlayLabelObject.transform.parent = null;
		}
		base.transform.Rotate(0f, 0f, rotationRate);
		if (OverlayLabelObject != null)
		{
			OverlayLabelObject.transform.parent = dvOverlayTrans;
		}
	}

	public void RotateDeg(float zAxis)
	{
		if (!_isDead)
		{
			_underPlayerControl = true;
			_brain.SetAiIdle();
			ClearCommandHistory();
			if (OverlayLabelObject != null)
			{
				OverlayLabelObject.transform.parent = null;
			}
			base.transform.Rotate(0f, 0f, zAxis);
			if (OverlayLabelObject != null)
			{
				OverlayLabelObject.transform.parent = dvOverlayTrans;
			}
			_heading = base.transform.up;
		}
	}

	public void MoveToPosition(Vector3 newPosition)
	{
		base.transform.parent.transform.position = new Vector3(newPosition.x, newPosition.y, 0f);
		if (InterfaceDisconnected)
		{
			droneUIObject.RefreshInfoLabelPos();
		}
	}

	public void SetRotation(Quaternion rotation)
	{
		base.transform.rotation = rotation;
	}

	public Vector3 GetDronePosition()
	{
		return base.transform.parent.transform.position;
	}

	public Quaternion GetDroneRotation()
	{
		return base.transform.rotation;
	}

	public void AddSpeedModifier(string modifierKey, float modifierValue)
	{
		bool flag = false;
		float value;
		if (!_speedModifiers.TryGetValue(modifierKey, out value) || value != modifierValue)
		{
			_speedModifiers[modifierKey] = modifierValue;
			UpdateSpeed();
		}
	}

	public void RemoveSpeedModifier(string modifierKey)
	{
		if (_speedModifiers.ContainsKey(modifierKey))
		{
			_speedModifiers.Remove(modifierKey);
			UpdateSpeed();
		}
	}

	private void SnapOverlaysBack()
	{
		dvOverlayTrans.transform.localPosition = Vector3.zero;
		OverlayLabelObject.transform.parent = null;
		dvOverlayTrans.transform.localRotation = Quaternion.identity;
		OverlayLabelObject.transform.parent = dvOverlayTrans.transform;
		isOverlayOutofSync = false;
		timeUntilOverlaySnapBack = 0f;
	}

	private void TestForOverlayoutOfSyncState()
	{
		SnapOverlaysBack();
	}

	private void UpdateSpeed()
	{
		float num = OriginalSpeed;
		foreach (float value in _speedModifiers.Values)
		{
			float num2 = value;
			num *= num2;
		}
		CurrentMaxSpeed = num;
	}

	public int NumberOfUpgradesInstalled()
	{
		int num = 0;
		int count = Upgrades.Count;
		for (int i = 0; i < count; i++)
		{
			if (Upgrades[i] != null)
			{
				num++;
			}
		}
		return num;
	}

	public bool CanAddDroneUpgrade(DroneUpgradeDefinition potentialDroneDefinition)
	{
		if (NumberOfUpgradesInstalled() >= NumberOfUpgradeSlots || _isDead)
		{
			return false;
		}
		return true;
	}

	public bool AddDroneUpgrade(BaseDroneUpgrade upgrade)
	{
		int num = 0;
		int count = Upgrades.Count;
		for (int i = 0; i < count; i++)
		{
			BaseDroneUpgrade baseDroneUpgrade = Upgrades[i];
			if (num >= NumberOfUpgradeSlots)
			{
				return false;
			}
			if (baseDroneUpgrade == null)
			{
				break;
			}
			num++;
		}
		if (num < Upgrades.Count)
		{
			return AddDroneUpgrade(num, upgrade);
		}
		return false;
	}

	public bool AddDroneUpgrade(int slotNumber, BaseDroneUpgrade upgrade)
	{
		if (upgrade == null)
		{
			Debug.LogWarning("Upgrade is NULL!");
			return false;
		}
		if (Upgrades[slotNumber] != null)
		{
			RemoveDroneUpgrade(slotNumber);
		}
		if (Upgrades[slotNumber] != null)
		{
			Upgrades[slotNumber].StopBlinkForUI();
		}
		Upgrades[slotNumber] = upgrade;
		Upgrades[slotNumber].StartBlinkForUI();
		if (GlobalSettings.UseCommandTree)
		{
			upgrade.RegisterCommands();
		}
		upgrade.drone = this;
		upgrade.DroneUpgradeEvent += OnDroneUpgradeEvent;
		if (!IsDead)
		{
			bool flag = false;
			if (upgrade is SpeedBoostUpgrade && upgrade.PoweredUp)
			{
				flag = true;
			}
			upgrade.PowerUp();
			if (flag)
			{
				OnDroneUpgradeEvent(DroneUpgradeEventType.UpgradePoweredUp, upgrade);
			}
			MarkUpgradeAsFound(upgrade.Definition.Type);
			if (upgrade is IDropperUpgrade)
			{
				IDropperUpgrade dropperUpgrade = (IDropperUpgrade)upgrade;
				DropItemType dropType = dropperUpgrade.DropType;
				if (DroneItemDropper.DroppedItemDict.ContainsKey(dropType))
				{
					foreach (DropableItem item in DroneItemDropper.DroppedItemDict[dropType])
					{
						if (item.DroppingUpgrade == upgrade)
						{
							upgrade.ActivateAbility();
							break;
						}
					}
				}
			}
		}
		else if (UnityEngine.Random.Range(1f, 100f) < 0f)
		{
			upgrade.Break();
			Debug.Log("Upgrade broke during install");
		}
		if (!IsDead)
		{
			HelpTextManager.Instance.ProcessInstalledDroneUpgrade(upgrade);
		}
		return true;
	}

	public static void MarkUpgradeAsFound(DroneUpgradeType upgradeType)
	{
		if (GlobalSettings.Constants.EXPLORE_UPGRADE_TYPES.Contains(upgradeType))
		{
			if (!GlobalSettings.DiscoveredUpgrades_Exploring.Contains(upgradeType))
			{
				GlobalSettings.DiscoveredUpgrades_Exploring.Add(upgradeType);
				GameSaveFile.SaveDiscoveredUpgradesExploringList(GlobalSettings.DiscoveredUpgrades_Exploring);
				if (HelpManualScript.Instance != null && HelpManual.Instance != null && HelpManualScript.Instance.IsInitialized && HelpManual.Instance.helper != null)
				{
					HelpManual.Instance.helper.RefreshDroneUpdadeMenu();
				}
			}
		}
		else if (!GlobalSettings.DiscoveredUpgrades.Contains(upgradeType))
		{
			GlobalSettings.DiscoveredUpgrades.Add(upgradeType);
			GameSaveFile.SaveDiscoveredUpgradesList(GlobalSettings.DiscoveredUpgrades);
			if (HelpManualScript.Instance != null && HelpManualScript.Instance.IsInitialized && HelpManual.Instance != null && HelpManual.Instance.helper != null)
			{
				HelpManual.Instance.helper.RefreshDroneUpdadeMenu();
			}
		}
	}

	public void RemoveDroneUpgrade(BaseDroneUpgrade upgrade)
	{
		int num = 0;
		foreach (BaseDroneUpgrade upgrade2 in Upgrades)
		{
			if (upgrade2 == upgrade)
			{
				break;
			}
			num++;
		}
		if (num < Upgrades.Count)
		{
			RemoveDroneUpgrade(num);
		}
	}

	public void RemoveDroneUpgrade(int slotNumber)
	{
		RemoveDroneUpgrade(slotNumber, true);
	}

	public void RemoveDroneUpgrade(int slotNumber, bool showWarnings)
	{
		BaseDroneUpgrade baseDroneUpgrade = Upgrades[slotNumber];
		if (baseDroneUpgrade != null)
		{
			if (showWarnings && baseDroneUpgrade == null)
			{
				Debug.Log("Attempting to remove an upgrade from an empty slot!!!");
				return;
			}
			baseDroneUpgrade.PowerDown();
			baseDroneUpgrade.DroneUpgradeEvent -= OnDroneUpgradeEvent;
			Upgrades[slotNumber] = null;
		}
	}

	public void RemoveAllUpgrades()
	{
		for (int i = 0; i < Upgrades.Count; i++)
		{
			RemoveDroneUpgrade(i, false);
		}
	}

	public BaseDroneUpgrade PullUpgrade(int slotNumber)
	{
		if (Upgrades.Count > slotNumber && Upgrades[slotNumber] != null)
		{
			BaseDroneUpgrade result = Upgrades[slotNumber];
			RemoveDroneUpgrade(slotNumber);
			return result;
		}
		return null;
	}

	public BaseDroneUpgrade PullUpgrade(DroneUpgradeType upgradeType)
	{
		for (int num = Upgrades.Count - 1; num >= 0; num--)
		{
			if (Upgrades[num] != null && Upgrades[num].Definition.Type == upgradeType)
			{
				BaseDroneUpgrade result = Upgrades[num];
				RemoveDroneUpgrade(num);
				return result;
			}
		}
		return null;
	}

	public BaseDroneUpgrade PullLastUpgrade()
	{
		for (int num = Upgrades.Count - 1; num >= 0; num--)
		{
			if (Upgrades[num] != null)
			{
				BaseDroneUpgrade result = Upgrades[num];
				RemoveDroneUpgrade(num);
				return result;
			}
		}
		return null;
	}

	public void UnsubscribeFromUpgradesEvents()
	{
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null)
			{
				upgrade.DroneUpgradeEvent -= OnDroneUpgradeEvent;
			}
		}
	}

	private void OnDroneUpgradeEvent(DroneUpgradeEventType eventType, BaseDroneUpgrade upgrade)
	{
		inLowUpgradeMode = false;
		switch (eventType)
		{
		case DroneUpgradeEventType.UpgradePoweredUp:
			if (upgrade != null && upgrade.Definition != null)
			{
				DroneUpgradeType type = upgrade.Definition.Type;
				if (type == DroneUpgradeType.SpeedBoost)
				{
					hasSpeedBoost = true;
					speedBoostUpgrade = upgrade;
					AddSpeedModifier("upgrade-" + upgrade.Id, upgrade.Definition.ModifierValue);
				}
			}
			break;
		case DroneUpgradeEventType.UpgradePoweredDown:
			if (upgrade != null && upgrade.Definition != null)
			{
				DroneUpgradeType type = upgrade.Definition.Type;
				if (type == DroneUpgradeType.SpeedBoost)
				{
					hasSpeedBoost = false;
					speedBoostUpgrade = null;
					RemoveSpeedModifier("upgrade-" + upgrade.Id);
				}
			}
			break;
		case DroneUpgradeEventType.ActivateAbility:
		{
			UnStealthIfHidden();
			if (upgrade == null || upgrade.Definition == null)
			{
				break;
			}
			if (upgrade.Definition.Type != DroneUpgradeType.Sonic)
			{
				DeactivateSonicPulseIfOn();
			}
			DroneUpgradeType type = upgrade.Definition.Type;
			if (type != DroneUpgradeType.StealthField)
			{
				break;
			}
			_isHidden = true;
			flashingStealth = false;
			delayUntilNextFlash = 0f;
			if (_imagePlane == null || _imagePlaneRenderer == null || _imagePlaneSV == null || _imagePlaneSVRenderer == null)
			{
				Debug.LogWarning(string.Format("Image plane is null, possibly destroyed -- is this an old event subscription?? (Drone {0}, {1}, dead: {2})", DroneNumber, DroneName, IsDead));
			}
			else
			{
				_imagePlaneRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0.5f);
				_imagePlaneSVRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0.5f);
			}
			{
				foreach (BaseDroneUpgrade upgrade2 in Upgrades)
				{
					if (upgrade2 != null && upgrade2 != upgrade && upgrade2.IsActivated)
					{
						upgrade2.CancelAbility();
					}
				}
				break;
			}
		}
		case DroneUpgradeEventType.CancelAbility:
			if (upgrade == null || upgrade.Definition == null)
			{
				break;
			}
			switch (upgrade.Definition.Type)
			{
			case DroneUpgradeType.StealthField:
				_isHidden = false;
				if (_imagePlane == null || _imagePlaneRenderer == null || _imagePlaneSV == null || _imagePlaneSVRenderer == null)
				{
					Debug.LogWarning(string.Format("Image plane is null, possibly destroyed -- is this an old event subscription?? (Drone {0}, {1}, dead: {2})", DroneNumber, DroneName, IsDead));
					break;
				}
				_imagePlaneRenderer.material.color = startColor;
				_imagePlaneSVRenderer.material.color = startColor;
				break;
			case DroneUpgradeType.BruteTurret:
				if (turretSound != null && turretSound.isPlaying)
				{
					turretSound.Stop();
				}
				break;
			}
			break;
		case DroneUpgradeEventType.ActiveUpgradeLow:
			if (upgrade != null && upgrade.Definition != null && upgrade.Definition.Type == DroneUpgradeType.StealthField)
			{
				inLowUpgradeMode = true;
				flashingStealth = true;
				delayForFlash = 0.1f;
			}
			break;
		case DroneUpgradeEventType.AbilityExpired:
			break;
		}
	}

	private void SetColor(Color color)
	{
	}

	public bool HasUpgrade(DroneUpgradeType upgradeType)
	{
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade.Definition.Type == upgradeType)
			{
				return true;
			}
		}
		return false;
	}

	public int GetUpgradeInstanceCount(DroneUpgradeType upgradeType)
	{
		int num = 0;
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade.Definition.Type == upgradeType)
			{
				num++;
			}
		}
		return num;
	}

	public BaseDroneUpgrade GetUpgrade(DroneUpgradeType upgradeType)
	{
		return Upgrades.FirstOrDefault((BaseDroneUpgrade x) => x != null && x.Definition.Type == upgradeType);
	}

	public List<BaseDroneUpgrade> GetUpgrades(DroneUpgradeType upgradeType)
	{
		return Upgrades.FindAll((BaseDroneUpgrade x) => x != null && x.Definition.Type == upgradeType);
	}

	public int StorageUpgradeTotalQuantity(DroneUpgradeType upgradeType)
	{
		int num = 0;
		List<BaseDroneUpgrade> upgrades = GetUpgrades(upgradeType);
		if (upgrades.Count > 0)
		{
			Type[] array = upgrades[0].GetType().FindInterfaces(CommonMethods.SystemTypeFilter, "IStorageUpgrade");
			if (array.Length > 0)
			{
				foreach (BaseDroneUpgrade item in upgrades)
				{
					IStorageUpgrade storageUpgrade = (IStorageUpgrade)item;
					num += storageUpgrade.Quantity;
				}
			}
		}
		return num;
	}

	public int StorageUpgradeMaxCapacity(DroneUpgradeType upgradeType)
	{
		int num = 0;
		List<BaseDroneUpgrade> upgrades = GetUpgrades(upgradeType);
		if (upgrades.Count > 0)
		{
			Type[] array = upgrades[0].GetType().FindInterfaces(CommonMethods.SystemTypeFilter, "IStorageUpgrade");
			if (array.Length > 0)
			{
				foreach (BaseDroneUpgrade item in upgrades)
				{
					IStorageUpgrade storageUpgrade = (IStorageUpgrade)item;
					num += storageUpgrade.Capacity;
				}
			}
		}
		return num;
	}

	public bool isCurrentDrone()
	{
		return DroneManager.Instance.CurrentDrone == this;
	}

	public void switchCameraView()
	{
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade is IUpdateCameraView)
			{
				((IUpdateCameraView)upgrade).UpdateCameraView();
				if (GlobalSettings.cameraMode == CameraMode.Drone && upgrade is StealthUpgrade && upgrade.IsActivated)
				{
					_imagePlaneRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0.5f);
				}
			}
		}
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			DisconnectSvVisuals();
			_imagePlaneRenderer.enabled = false;
		}
		else
		{
			ReconnectSvVisuals();
			_imagePlaneRenderer.enabled = true;
		}
		Light[] array = droneLights;
		foreach (Light light in array)
		{
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				light.enabled = false;
			}
			else if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				light.enabled = true;
			}
		}
		if (droneViewModel != null)
		{
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				if (CurrentRoom == null || CurrentRoom.boardingVessel || CurrentRoom == DroneManager.Instance.CurrentDrone.CurrentRoom)
				{
					droneViewModel.SetActive(true);
				}
				else
				{
					droneViewModel.SetActive(false);
				}
			}
			else
			{
				droneViewModel.SetActive(false);
			}
		}
		if (IsInvisibleDueToToggle)
		{
			bool flag = GlobalSettings.cameraMode == CameraMode.Drone;
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				if (GetUpgradeInstanceCount(DroneUpgradeType.BruteTurret) > 0 || GetUpgradeInstanceCount(DroneUpgradeType.SwarmTurret) > 0)
				{
					Transform transform = dvOverlayTrans.Find("TurretUI");
					transform.GetComponent<Renderer>().enabled = true;
				}
				if (GetUpgradeInstanceCount(DroneUpgradeType.Shield) > 0)
				{
					Transform transform2 = dvOverlayTrans.Find("ShieldUI");
					if (!IsDead)
					{
						transform2.GetComponent<Renderer>().enabled = true;
					}
					else
					{
						transform2.GetComponent<Renderer>().enabled = false;
					}
				}
			}
			else
			{
				Transform transform3 = dvOverlayTrans.Find("TurretUI");
				if (transform3 != null)
				{
					transform3.GetComponent<Renderer>().enabled = flag;
				}
				transform3 = dvOverlayTrans.Find("ShieldUI");
				if (transform3 != null)
				{
					if (!IsDead)
					{
						transform3.GetComponent<Renderer>().enabled = flag;
					}
					else
					{
						transform3.GetComponent<Renderer>().enabled = false;
					}
				}
			}
		}
		if (isPumpingFuel)
		{
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				fuelGatherSound.Play();
				fuelGatherSound.volume = GameAudio.RemoteVolume * 1f;
			}
			else
			{
				fuelGatherSound.Pause();
			}
		}
		if (teleportSound.isPlaying && GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			teleportSound.Stop();
		}
		if (ItemBeingTowed == null)
		{
			return;
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone && !IsBraking)
		{
			if (isMovingForwardBack && ItemBeingTowed != null && !towMoveSound.isPlaying)
			{
				towMoveSound.Play();
				towMoveSound.volume = GameAudio.RemoteVolume * 1f;
			}
		}
		else
		{
			towMoveSound.Stop();
		}
	}

	public bool isArmed()
	{
		bool flag = false;
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade is IWeapon)
			{
				flag = flag || ((IWeapon)upgrade).isArmed();
			}
		}
		return flag;
	}

	public bool isSaftey()
	{
		bool flag = false;
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade is IWeapon)
			{
				flag = flag || ((IWeapon)upgrade).isSaftey();
			}
		}
		return flag;
	}

	public void arm()
	{
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade.PoweredUp && upgrade is IWeapon)
			{
				((IWeapon)upgrade).Arm();
			}
		}
	}

	public void disarm()
	{
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade is IWeapon && upgrade.IsActivated)
			{
				((IWeapon)upgrade).Disarm();
			}
		}
	}

	public void engageSaftey(bool engageSaftey)
	{
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade is IWeapon)
			{
				((IWeapon)upgrade).EngageSaftey(engageSaftey);
			}
		}
	}

	public bool hasUpgradeActivated(DroneUpgradeType upgradeType)
	{
		bool result = false;
		if (HasUpgrade(upgradeType))
		{
			foreach (BaseDroneUpgrade upgrade in Upgrades)
			{
				if (upgrade != null && upgrade.Definition.Type == upgradeType && upgrade.IsActivated)
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	public void generatorOn()
	{
		if (!HasUpgrade(DroneUpgradeType.Generator))
		{
			return;
		}
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade.PoweredUp && upgrade is GeneratorUpgrade && upgrade.ActivateAbility())
			{
				DroneManager.Instance.UpdateCameraView();
			}
		}
	}

	public void generatorOff()
	{
		if (!HasUpgrade(DroneUpgradeType.Generator))
		{
			return;
		}
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade is GeneratorUpgrade)
			{
				upgrade.CancelAbility();
				DroneManager.Instance.UpdateCameraView();
			}
		}
	}

	private void ClearCommandHistory()
	{
		currentlyProcessingACommand = false;
		queuedCommands.Clear();
	}

	public void ArrivedAtDestination()
	{
		currentlyProcessingACommand = false;
		if (queuedCommands.Count <= 0)
		{
			return;
		}
		List<ExecutedCommand> list = new List<ExecutedCommand>(queuedCommands);
		queuedCommands.Clear();
		foreach (ExecutedCommand item in list)
		{
			ExecuteCommand(item, true);
		}
	}

	public void NavigateTo(Room room)
	{
		currentlyProcessingACommand = true;
		_underPlayerControl = false;
		_heading = base.transform.up;
		_brain.NavigateToRoom(room);
	}

	public void NavigateToAndExecuteCommand(RoomItem roomItem, ExecutedCommand command, CollisionType collisionType)
	{
		PlayCallSign();
		currentlyProcessingACommand = true;
		_underPlayerControl = false;
		_heading = base.transform.up;
		_brain.SetProximity(0f);
		_brain.NavigateToObjectAndExecuteCommand(roomItem.gameObject, command, collisionType);
	}

	public void NavigateToAndExecuteCommand(GameObject gameObject, ExecutedCommand command, CollisionType collisionType)
	{
		NavigateToAndExecuteCommand(gameObject, command, collisionType, 0f);
	}

	public void NavigateToAndExecuteCommand(GameObject gameObject, ExecutedCommand command, CollisionType collisionType, float proximity)
	{
		_brain.SetProximity(proximity);
		if (!isPumpingFuel)
		{
			PlayCallSign();
			currentlyProcessingACommand = true;
			_underPlayerControl = false;
			_heading = base.transform.up;
			_brain.NavigateToObjectAndExecuteCommand(gameObject, command, collisionType);
		}
		else if (timerLastPumpingFuelNotification <= 0f)
		{
			GameplayManager.ShowConsoleMessage("   Drone " + DroneNumber + " is gathering fuel - cannot move", ConsoleMessageType.Warning);
			timerLastPumpingFuelNotification = 1f;
		}
	}

	public void StopPriorNavigation()
	{
		currentlyProcessingACommand = false;
		queuedCommands.Clear();
		_brain.StopNavigating();
	}

	public List<CommandDefinition> QueryAvailableCommands()
	{
		if (baseCommandList == null)
		{
			baseCommandList = new List<CommandDefinition>(40);
			baseCommandList.AddRange(CommandHelper.GetCommands("Drone"));
			baseCommandList.Add(new CommandDefinition(string.Empty, "\nDrone Upgrade-Specific Commands:\n"));
		}
		if (commandList == null)
		{
			commandList = new List<CommandDefinition>(baseCommandList.Count * 2);
			commandList.AddRange(baseCommandList);
		}
		else
		{
			commandList.Clear();
			commandList.AddRange(baseCommandList);
		}
		int count = Upgrades.Count;
		for (int i = 0; i < count; i++)
		{
			BaseDroneUpgrade baseDroneUpgrade = Upgrades[i];
			if (baseDroneUpgrade != null)
			{
				List<CommandDefinition> list = baseDroneUpgrade.QueryAvailableCommands();
				if (list != null && list.Count > 0)
				{
					commandList.AddRange(list);
				}
			}
		}
		return commandList;
	}

	public List<CommandDefinition> QueryContextCommands()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			return QueryAvailableCommands();
		}
		return new List<CommandDefinition>();
	}

	public virtual List<CommandDefinition> QueryDeveloperSpecialCaseCommands()
	{
		return new List<CommandDefinition>();
	}

	public void ExecuteCommandAfterState(ExecutedCommand command)
	{
		currentlyProcessingACommand = false;
		if (queuedCommands.Count > 0)
		{
			List<ExecutedCommand> list = new List<ExecutedCommand>(queuedCommands);
			queuedCommands.Clear();
			ExecuteCommand(command, false);
			{
				foreach (ExecutedCommand item in list)
				{
					ExecuteCommand(item, true);
				}
				return;
			}
		}
		ExecuteCommand(command, false);
	}

	public void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		if (IsDead || (command.DroneNumbers != null && command.DroneNumbers.Count > 0 && command.Command.CommandTarget != ConsoleCommandTarget.OtherDrone))
		{
			return;
		}
		if (isGatheringLoot && command.Command.CommandName != "gather" && command.Command.CommandName != "pickup")
		{
			isGatheringLoot = false;
		}
		if (IsStunned)
		{
			switch (command.Command.CommandName)
			{
			case "loot":
			case "swap":
			case "discard":
			case "pickup":
			case "list":
				SendConsoleMessage("Done " + DroneNumber + " is not responding", ConsoleMessageType.Warning);
				command.Handled = true;
				return;
			}
		}
		if (partOfMultiCommand && currentlyProcessingACommand)
		{
			if (QueryAvailableCommands().Any((CommandDefinition x) => x != null && x.CommandName == command.Command.CommandName))
			{
				ExecutedCommand item = new ExecutedCommand(command);
				queuedCommands.Add(item);
				command.Handled = true;
				command.Queued = true;
			}
			return;
		}
		if (!partOfMultiCommand && queuedCommands.Count > 0)
		{
			queuedCommands.Clear();
		}
		switch (command.Command.CommandName)
		{
		case "navigate":
		{
			command.Handled = true;
			if (isPumpingFuel)
			{
				GameplayManager.ShowConsoleMessage("   Drone " + DroneNumber + " is gathering fuel - cannot move", ConsoleMessageType.Warning);
				break;
			}
			PlayCallSign();
			string text2 = string.Empty;
			if (command.Arguments.Count == 2)
			{
				text2 = command.Arguments[1];
			}
			else if (command.Arguments.Count == 1)
			{
				text2 = command.Arguments[0];
			}
			if (!string.IsNullOrEmpty(text2))
			{
				string text3 = text2.ToLower();
				DungeonManager instance = DungeonManager.Instance;
				Room room = null;
				Door door = null;
				int num5 = instance.doors.Length;
				for (int num6 = 0; num6 < num5; num6++)
				{
					Door door2 = instance.doors[num6];
					if (door2.onSchematic && door2.LabelSimple == text3)
					{
						door = door2;
						break;
					}
				}
				if (text3[0] == 'h' && "home".StartsWith(text3))
				{
					room = DungeonManager.Instance.BoardingVessel;
				}
				if (room == null)
				{
					num5 = instance.rooms.Length;
					for (int num7 = 0; num7 < num5; num7++)
					{
						Room room2 = instance.rooms[num7];
						if (room2.onSchematic && room2.LabelSimple != null && room2.LabelSimple == text3)
						{
							room = room2;
							break;
						}
					}
				}
				if (room != null)
				{
					if (room != CurrentRoom)
					{
						NavigateTo(room);
						SendConsoleMessage(string.Format("navigating Drone {0} to {1}", DroneNumber, room.Label), ConsoleMessageType.Info);
						if (GlobalSettings.cameraMode == CameraMode.Schematic)
						{
							HintManager.HintCompleted(typeof(NavigateHint));
							if (!NagivateHintNotNeeded && !GlobalSettings.IsTutorial && !GameSaveFile.Get("HNT_NAVIGATE", false))
							{
								GameSaveFile.Save("HNT_NAVIGATE", true);
								NagivateHintNotNeeded = true;
							}
						}
					}
					else
					{
						SendConsoleMessage("already in specified room.\r\n'help navigate' for usage.", ConsoleMessageType.Info);
					}
				}
				else if (CurrentRoom != null && (room != null || door != null))
				{
					bool flag3 = false;
					int count5 = CurrentRoom.corridors.Count;
					for (int num8 = 0; num8 < count5; num8++)
					{
						if (CurrentRoom.corridors[num8].door == door)
						{
							flag3 = true;
							break;
						}
					}
					if (flag3)
					{
						AdjacentRoomData adjacentRoomData = NavigationHelper.GetAdjacentRoomData(door);
						if (adjacentRoomData != null)
						{
							Room room3 = ((!(adjacentRoomData.Room1 == CurrentRoom)) ? adjacentRoomData.Room1 : adjacentRoomData.Room2);
							NavigateTo(room3);
							if (!NagivateHintNotNeeded && GlobalSettings.cameraMode == CameraMode.Schematic && !GlobalSettings.IsTutorial)
							{
								if (!GameSaveFile.Get("HNT_NAVIGATE", false))
								{
									GameSaveFile.Save("HNT_NAVIGATE", true);
								}
								NagivateHintNotNeeded = true;
							}
							SendConsoleMessage("navigating Drone " + DroneNumber + " to " + room3.Label, ConsoleMessageType.Info);
						}
						else
						{
							SendConsoleMessage(string.Format("Not able to navigate Drone {0} to that destination.\r\n'help navigate' for usage.", DroneNumber), ConsoleMessageType.Info);
						}
					}
					else
					{
						SendConsoleMessage(string.Format("Door {0} is not connected to the current room.\r\n'help navigate' for usage.", door.Label), ConsoleMessageType.Info);
					}
				}
				else
				{
					string arg = command.Arguments.First();
					if (command.Arguments.Count == 2)
					{
						arg = command.Arguments[1];
					}
					SendConsoleMessage(string.Format("could not locate room/door {0}.\r\n'help navigate' for usage.", arg), ConsoleMessageType.Info);
				}
			}
			else
			{
				SendConsoleMessage("invalid parameter count (expecting one).\r\n'help navigate' for usage.", ConsoleMessageType.Info);
			}
			break;
		}
		case "destruct":
			command.Handled = true;
			if (IsDead)
			{
				SendConsoleMessage(string.Format("Drone {0} is already destroyed.", DroneNumber), ConsoleMessageType.Info);
			}
			else if (IsStunned)
			{
				SendConsoleMessage(string.Format("Drone {0} is currently stunned.", DroneNumber), ConsoleMessageType.Info);
			}
			else if (!isInSelfDestructMode)
			{
				if (!command.RequestConfirmed)
				{
					command.RequestConfirmation = true;
					SystemMessageManager.ShowSystemMessage(string.Format("   Safety precaution:\r\n     <color=\"#FF0000\">re-enter the 'destruct' command</color> to confirm\n     executing it."), ConsoleMessageType.Info);
					GameAudio.Play2DSFX(GameAudio.SoundEnum.Notification);
					return;
				}
				float num23 = 3f;
				if (command.Arguments != null && command.Arguments.Count == 1)
				{
					int result = 0;
					string text8 = command.Arguments[0];
					if (text8.Length > 1)
					{
						text8 = text8.Substring(1);
					}
					if (!int.TryParse(text8, out result))
					{
						SystemMessageManager.ShowSystemMessage(string.Format("Invalid use of 'destruct' command.  ex: 'destruct t3'"), ConsoleMessageType.Error);
						return;
					}
					bool flag7 = false;
					if (result < 1)
					{
						result = 1;
						flag7 = true;
					}
					else if (result > 60)
					{
						result = 60;
						flag7 = true;
					}
					if (flag7)
					{
						SystemMessageManager.ShowSystemMessage(string.Format("Invalid value provided for 'destruct' command.\r\nMust be in the range of 1 to 60.  Set to: {0}", result), ConsoleMessageType.Warning);
					}
					num23 = result;
				}
				float num24 = 0.2f;
				int numberOfCycles = Mathf.Max((int)(num23 / num24) / 2, 1);
				blinkManager.Start(startColor, HitColor, num24, numberOfCycles);
				_selfDestructTimer = num23;
				isInSelfDestructMode = true;
				timerIntPrev = 0;
				SystemMessageManager.ShowSystemMessage("Drone " + DroneNumber + " will self destruct in " + (int)num23 + " seconds", ConsoleMessageType.Warning);
			}
			else
			{
				isInSelfDestructMode = false;
				_selfDestructTimer = 0f;
				SystemMessageManager.ShowSystemMessage("Canceled self destruct on Drone " + DroneNumber, ConsoleMessageType.Healthy);
				blinkManager.Stop();
			}
			break;
		case "die":
			command.Handled = true;
			Kill();
			break;
		case "damage":
			command.Handled = true;
			TakeDamage(50f, DamageType.Physical, null);
			break;
		case "breakall":
		{
			command.Handled = true;
			int count3 = Upgrades.Count;
			for (int num3 = 0; num3 < count3; num3++)
			{
				BaseDroneUpgrade baseDroneUpgrade3 = Upgrades[num3];
				if (baseDroneUpgrade3 != null)
				{
					baseDroneUpgrade3.ReduceQuality();
				}
			}
			break;
		}
		case "loot":
		{
			List<Drone> list = new List<Drone>();
			list.AddRange(DroneManager.Instance.dronesList);
			list.AddRange(DroneManager.Instance.LootableDronesList);
			int num9 = -1;
			if (NumberOfUpgradesInstalled() >= NumberOfUpgradeSlots)
			{
				SendConsoleMessage("No slots free on Drone " + DroneNumber + " - unable to loot.", ConsoleMessageType.Warning);
				command.Handled = true;
				return;
			}
			if (command.DroneNumbers.Count > 1)
			{
				SendConsoleMessage("Only 1 drone can be looted at a time", ConsoleMessageType.Warning);
				command.Handled = true;
				return;
			}
			if (command.DroneNumbers.Count == 1)
			{
				num9 = command.DroneNumbers[0];
			}
			else
			{
				List<int> list2 = new List<int>();
				int count6 = list.Count;
				for (int num10 = 0; num10 < count6; num10++)
				{
					Drone drone = list[num10];
					if (drone.DroneNumber != DroneNumber && drone.CurrentRoom == CurrentRoom)
					{
						list2.Add(drone.DroneNumber);
					}
				}
				if (list2.Count > 1)
				{
					SendConsoleMessage("There are " + list2.Count + " drones nearby.  Specify one...", ConsoleMessageType.Warning);
					SendConsoleMessage("\tUsage: loot [target]", ConsoleMessageType.Info);
					count6 = list2.Count;
					for (int num11 = 0; num11 < count6; num11++)
					{
						SendConsoleMessage("\t\tDone #" + list2[num11], ConsoleMessageType.Info);
					}
					command.Handled = true;
					return;
				}
			}
			int count7 = list.Count;
			for (int num12 = 0; num12 < count7; num12++)
			{
				Drone drone2 = list[num12];
				if (drone2.DroneNumber == DroneNumber)
				{
					continue;
				}
				if (drone2.CurrentRoom == CurrentRoom)
				{
					if (num9 != -1 && drone2.DroneNumber != num9)
					{
						continue;
					}
					if (command.Arguments.Count >= 1 && command.Arguments.Count <= 2)
					{
						string text4 = command.Arguments[0];
						bool flag4 = false;
						List<string> matchingUpgradeList2 = new List<string>();
						DroneUpgradeType upgradeType2 = DroneUpgradeType.Undefined;
						flag4 = ParseStringAsUpgrade(drone2, text4, out upgradeType2, out matchingUpgradeList2);
						if (!flag4 && matchingUpgradeList2.Count == 1)
						{
							flag4 = true;
						}
						if (!flag4 && matchingUpgradeList2.Count > 1)
						{
							SendConsoleMessage("Target Drone (" + drone2.DroneNumber + ") has more than 1 matching item:", ConsoleMessageType.Info);
							int count8 = matchingUpgradeList2.Count;
							for (int num13 = 0; num13 < count8; num13++)
							{
								SendConsoleMessage("\t" + matchingUpgradeList2[num13], ConsoleMessageType.Info);
							}
							command.Handled = true;
							return;
						}
						if (flag4)
						{
							BaseDroneUpgrade baseDroneUpgrade5 = null;
							baseDroneUpgrade5 = drone2.PullUpgrade(upgradeType2);
							AddDroneUpgrade(baseDroneUpgrade5);
							SendConsoleMessage("Looted a " + baseDroneUpgrade5.CommandValue + " from Drone " + drone2.DroneNumber + ".", ConsoleMessageType.Benefit);
						}
						else
						{
							SendConsoleMessage("No upgrade items matching '" + text4 + "' found", ConsoleMessageType.Warning);
						}
						command.Handled = true;
						return;
					}
					if (drone2.NumberOfUpgradesInstalled() > 0)
					{
						SendConsoleMessage("Usage: loot [item] [drone]", ConsoleMessageType.Info);
						SendConsoleMessage("\tAvailable Items on Drone " + drone2.DroneNumber + ":", ConsoleMessageType.Info);
						if (drone2.NumberOfUpgradesInstalled() > 0)
						{
							int count9 = drone2.Upgrades.Count;
							for (int num14 = 0; num14 < count9; num14++)
							{
								BaseDroneUpgrade baseDroneUpgrade6 = drone2.Upgrades[num14];
								if (baseDroneUpgrade6 != null)
								{
									SendConsoleMessage("\t\t" + baseDroneUpgrade6.CommandValue, ConsoleMessageType.Info);
								}
							}
						}
						else
						{
							SendConsoleMessage("nothing to loot...", ConsoleMessageType.Info);
						}
					}
					else
					{
						SendConsoleMessage("Drone's slots are empty...", ConsoleMessageType.Warning);
					}
					command.Handled = true;
					return;
				}
				if (drone2.DroneNumber == num9)
				{
					SendConsoleMessage("Drone " + num9 + " is not in this room", ConsoleMessageType.Warning);
					command.Handled = true;
					return;
				}
			}
			if (num9 == -1)
			{
				SendConsoleMessage("No drones nearby...", ConsoleMessageType.Warning);
			}
			else
			{
				SendConsoleMessage("Drone " + num9 + " is not dead, yet!", ConsoleMessageType.Warning);
			}
			command.Handled = true;
			return;
		}
		case "swap":
		{
			List<Drone> list3 = new List<Drone>();
			list3.AddRange(DroneManager.Instance.dronesList);
			list3.AddRange(DroneManager.Instance.LootableDronesList);
			int num15 = -1;
			if (command.DroneNumbers.Count > 1)
			{
				SendConsoleMessage("Invalid use of 'swap'.\r\n" + command.Command.Example, ConsoleMessageType.Warning);
				command.Handled = true;
				return;
			}
			if (command.DroneNumbers.Count == 1)
			{
				num15 = command.DroneNumbers[0];
			}
			else
			{
				bool flag5 = false;
				if (command.Arguments != null && command.Arguments.Count > 0)
				{
					int count10 = list3.Count;
					for (int num16 = 0; num16 < count10; num16++)
					{
						Drone drone3 = list3[num16];
						if (drone3.DroneNumber != DroneNumber && drone3.CurrentRoom == CurrentRoom && drone3.DroneNameLower.StartsWith(command.Arguments[0]))
						{
							flag5 = true;
							if (GameplayManager.Instance.AddUI(GameWindowIds.UpgradeSwapWindow, drone3.DroneNumber))
							{
								command.Handled = true;
								return;
							}
							break;
						}
					}
				}
				if (!flag5)
				{
					List<int> list4 = new List<int>();
					int count11 = list3.Count;
					for (int num17 = 0; num17 < count11; num17++)
					{
						Drone drone4 = list3[num17];
						if (drone4.DroneNumber != DroneNumber && drone4.CurrentRoom == CurrentRoom && drone4.scanned)
						{
							list4.Add(drone4.DroneNumber);
						}
					}
					if (list4.Count > 1)
					{
						SendConsoleMessage("There are " + list4.Count + " drones nearby.  Specify one...", ConsoleMessageType.Warning);
						SendConsoleMessage("\t" + command.Command.Example, ConsoleMessageType.Info);
						int count12 = list4.Count;
						for (int num18 = 0; num18 < count12; num18++)
						{
							SendConsoleMessage("\t\tDone #" + list4[num18], ConsoleMessageType.Info);
						}
						command.Handled = true;
						return;
					}
				}
			}
			int count13 = list3.Count;
			for (int num19 = 0; num19 < count13; num19++)
			{
				Drone drone5 = list3[num19];
				if (drone5.DroneNumber == DroneNumber)
				{
					continue;
				}
				if (drone5.CurrentRoom == CurrentRoom)
				{
					if (num15 != -1 && drone5.DroneNumber != num15)
					{
						continue;
					}
					if (command.Arguments.Count >= 1 && command.Arguments.Count <= 2)
					{
						string text5 = command.Arguments[0];
						string text6 = command.Arguments[1];
						if (text5 == string.Empty)
						{
							SendConsoleMessage("Must choose an upgrade to swap out.", ConsoleMessageType.Info);
							SendConsoleMessage("Usage: " + command.Command.Example, ConsoleMessageType.Info);
							command.Handled = true;
							return;
						}
						bool flag6 = false;
						List<string> matchingUpgradeList3 = new List<string>();
						DroneUpgradeType upgradeType3 = DroneUpgradeType.Undefined;
						DroneUpgradeType upgradeType4 = DroneUpgradeType.Undefined;
						flag6 = ParseStringAsUpgrade(drone5, text6, out upgradeType3, out matchingUpgradeList3);
						if (!flag6 && matchingUpgradeList3.Count == 0)
						{
							flag6 = ParseStringAsUpgrade(drone5, text5, out upgradeType3, out matchingUpgradeList3);
							if (flag6 || matchingUpgradeList3.Count > 0)
							{
								string text7 = text6;
								text6 = text5;
								text5 = text7;
							}
						}
						if (!flag6 && matchingUpgradeList3.Count == 1)
						{
							flag6 = true;
						}
						if (!flag6 && matchingUpgradeList3.Count > 1)
						{
							SendConsoleMessage("Target Drone (" + drone5.DroneNumber + ") has more than 1 matching item:", ConsoleMessageType.Info);
							int count14 = matchingUpgradeList3.Count;
							for (int num20 = 0; num20 < count14; num20++)
							{
								SendConsoleMessage("\t" + matchingUpgradeList3[num20], ConsoleMessageType.Info);
							}
							command.Handled = true;
						}
						else if (flag6)
						{
							flag6 = ParseStringAsUpgrade(this, text5, out upgradeType4, out matchingUpgradeList3);
							if (!flag6 && matchingUpgradeList3.Count == 1)
							{
								flag6 = true;
							}
							else if (!flag6 && matchingUpgradeList3.Count > 1)
							{
								SendConsoleMessage("Source Drone (" + DroneNumber + ") has more than 1 matching items:", ConsoleMessageType.Info);
								int count15 = matchingUpgradeList3.Count;
								for (int num21 = 0; num21 < count15; num21++)
								{
									SendConsoleMessage("\t" + matchingUpgradeList3[num21], ConsoleMessageType.Info);
								}
								command.Handled = true;
								return;
							}
							if (flag6)
							{
								BaseDroneUpgrade baseDroneUpgrade7 = null;
								BaseDroneUpgrade baseDroneUpgrade8 = null;
								baseDroneUpgrade8 = PullUpgrade(upgradeType4);
								baseDroneUpgrade7 = drone5.PullUpgrade(upgradeType3);
								drone5.AddDroneUpgrade(baseDroneUpgrade8);
								AddDroneUpgrade(baseDroneUpgrade7);
								SendConsoleMessage("Swapped " + baseDroneUpgrade8.CommandValue + " with " + baseDroneUpgrade7.CommandValue + " on Drone " + drone5.DroneNumber + ".", ConsoleMessageType.Benefit);
							}
							else
							{
								SendConsoleMessage("Drone " + DroneNumber + " doesn't have any items matching '" + text5 + "'", ConsoleMessageType.Warning);
							}
							command.Handled = true;
						}
						else
						{
							SendConsoleMessage("No upgrade items matching '" + text6 + "' found on Drone " + drone5.DroneNumber, ConsoleMessageType.Warning);
							command.Handled = true;
						}
						return;
					}
					if (drone5.NumberOfUpgradesInstalled() > 0)
					{
						SendConsoleMessage("Usage: " + command.Command.Example, ConsoleMessageType.Info);
						SendConsoleMessage("\tAvailable Items on Drone " + drone5.DroneNumber + ":", ConsoleMessageType.Info);
						int count16 = drone5.Upgrades.Count;
						for (int num22 = 0; num22 < count16; num22++)
						{
							BaseDroneUpgrade baseDroneUpgrade9 = drone5.Upgrades[num22];
							if (baseDroneUpgrade9 != null)
							{
								SendConsoleMessage("\t\t" + baseDroneUpgrade9.CommandValue, ConsoleMessageType.Info);
							}
						}
					}
					else
					{
						SendConsoleMessage("Drone's slots are empty...", ConsoleMessageType.Warning);
					}
					command.Handled = true;
					return;
				}
				if (drone5.DroneNumber == num15)
				{
					SendConsoleMessage("Drone " + num15 + " is not in this room", ConsoleMessageType.Warning);
					command.Handled = true;
					return;
				}
			}
			if (num15 == -1)
			{
				SendConsoleMessage("No drones nearby...", ConsoleMessageType.Warning);
			}
			command.Handled = true;
			return;
		}
		case "list":
		{
			if (GlobalSettings.cameraMode != CameraMode.Drone)
			{
				return;
			}
			List<Drone> list5 = new List<Drone>();
			list5.AddRange(DroneManager.Instance.dronesList);
			list5.AddRange(DroneManager.Instance.LootableDronesList);
			if (command.Arguments.Count == 1)
			{
				string text9 = command.Arguments[0].ToLower();
				if (text9 == "me" && !command.DroneNumbers.Contains(DroneNumber))
				{
					command.DroneNumbers.Add(DroneNumber);
				}
			}
			int count17 = list5.Count;
			for (int num25 = 0; num25 < count17; num25++)
			{
				Drone drone6 = list5[num25];
				if (!(drone6 != null) || ((command.DroneNumbers.Count != 0 || !(drone6 != this)) && !command.DroneNumbers.Contains(drone6.DroneNumber)) || (!(drone6.CurrentRoom == null) && !drone6.CurrentRoom.isExplored))
				{
					continue;
				}
				string text10 = "\r\n<b>Drone " + drone6.DroneNumber + "</b> Upgrades:";
				if (drone6.IsDead)
				{
					text10 = ((!drone6.CanBeFullyRepaired) ? (text10 + string.Format(" ({0})", "Destroyed")) : (text10 + string.Format(" ({0})", "Disabled")));
				}
				SendConsoleMessage(text10, ConsoleMessageType.Benefit);
				if (drone6.NumberOfUpgradesInstalled() > 0)
				{
					int count18 = drone6.Upgrades.Count;
					for (int num26 = 0; num26 < count18; num26++)
					{
						BaseDroneUpgrade baseDroneUpgrade10 = drone6.Upgrades[num26];
						if (baseDroneUpgrade10 == null)
						{
							continue;
						}
						string text11 = "\t" + baseDroneUpgrade10.Definition.Name;
						ConsoleMessageType type = ConsoleMessageType.Info;
						if (baseDroneUpgrade10.BrokenState == BrokenStateEnum.Broken)
						{
							text11 += " (broken)";
							type = ConsoleMessageType.Warning;
						}
						else
						{
							Type[] array = baseDroneUpgrade10.GetType().FindInterfaces(CommonMethods.SystemTypeFilter, "IStorageUpgrade");
							if (array.Length > 0)
							{
								IStorageUpgrade storageUpgrade3 = (IStorageUpgrade)baseDroneUpgrade10;
								if (storageUpgrade3.Capacity > 0)
								{
									string text12 = text11;
									text11 = text12 + " (" + storageUpgrade3.Quantity + "/" + storageUpgrade3.Capacity + ") ";
								}
							}
							else
							{
								array = baseDroneUpgrade10.GetType().FindInterfaces(CommonMethods.SystemTypeFilter, "IDamagableObject");
								if (array.Length > 0)
								{
									IDamagableObject damagableObject = (IDamagableObject)baseDroneUpgrade10;
									if (damagableObject.TotalHitpoints > 0f)
									{
										text11 = text11 + " (" + Math.Round(damagableObject.CurrentHitPoints, 0) + ") ";
									}
								}
							}
							if (baseDroneUpgrade10.IsActivated)
							{
								type = ConsoleMessageType.Healthy;
							}
						}
						text11 = text11 + " [<i>" + baseDroneUpgrade10.CommandValue + "</i>]";
						GameplayManager.ShowConsoleMessage(text11, type);
					}
				}
				else
				{
					SendConsoleMessage("\tNo installed upgrades", ConsoleMessageType.Info);
				}
			}
			command.Handled = true;
			return;
		}
		case "discard":
			if (NumberOfUpgradesInstalled() == 0)
			{
				SendConsoleMessage("Nothing to discard", ConsoleMessageType.Warning);
			}
			else if (command.Arguments.Count != 1)
			{
				SendConsoleMessage("Usage: discard [item]", ConsoleMessageType.Info);
			}
			else if (CurrentRoom != null)
			{
				DroneUpgradeType upgradeType = DroneUpgradeType.Undefined;
				List<string> matchingUpgradeList = new List<string>();
				if (ParseStringAsUpgrade(this, command.Arguments[0], out upgradeType, out matchingUpgradeList) || matchingUpgradeList.Count == 1)
				{
					BaseDroneUpgrade baseDroneUpgrade4 = PullUpgrade(upgradeType);
					UpgradePickupItem upgradePickupItem = (UpgradePickupItem)UnityEngine.Object.Instantiate(DungeonManager.Instance.PickupItemTemplate, base.transform.position, Quaternion.identity);
					upgradePickupItem.SetUpgradeItem(baseDroneUpgrade4);
					upgradePickupItem.gameObject.GetComponent<Renderer>().enabled = true;
					CurrentRoom.roomItems.Add(upgradePickupItem);
					SendConsoleMessage("Discarded: " + baseDroneUpgrade4.Name, ConsoleMessageType.Info);
				}
				else if (matchingUpgradeList.Count > 1)
				{
					SendConsoleMessage("More than 1 matching items:", ConsoleMessageType.Info);
					int count4 = matchingUpgradeList.Count;
					for (int num4 = 0; num4 < count4; num4++)
					{
						SendConsoleMessage("\t" + matchingUpgradeList[num4], ConsoleMessageType.Info);
					}
				}
				else
				{
					SendConsoleMessage("You don't have any matching items", ConsoleMessageType.Warning);
				}
			}
			else
			{
				Debug.Log("Current Room is NULL");
			}
			command.Handled = true;
			break;
		case "pickup":
			if (command.Arguments.Count == 0 || (command.Arguments[0].ToLower() == "all" && command.Arguments.Count == 1))
			{
				bool flag = false;
				int count = Upgrades.Count;
				for (int num = 0; num < count; num++)
				{
					BaseDroneUpgrade baseDroneUpgrade = Upgrades[num];
					if (baseDroneUpgrade == null)
					{
						continue;
					}
					if (baseDroneUpgrade.GetType().FindInterfaces(CommonMethods.SystemTypeFilter, "IStorageUpgrade").Length > 0 && baseDroneUpgrade.GetType().FindInterfaces(CommonMethods.SystemTypeFilter, "IDropperUpgrade").Length > 0)
					{
						IStorageUpgrade storageUpgrade = (IStorageUpgrade)baseDroneUpgrade;
						if (storageUpgrade.Capacity > 0)
						{
							IDropperUpgrade dropperUpgrade = (IDropperUpgrade)baseDroneUpgrade;
							if (dropperUpgrade.Pickup() > 0)
							{
								flag = true;
							}
						}
					}
					else if (baseDroneUpgrade.GetType() == typeof(GathererUpgrade))
					{
						ExecutedCommand executedCommand = new ExecutedCommand(command);
						executedCommand.Command.CommandName = "gather";
						((GathererUpgrade)baseDroneUpgrade).ExecuteCommand(executedCommand, partOfMultiCommand);
						executedCommand.Command.CommandName = "pickup";
						flag = true;
					}
				}
				if (!flag)
				{
					SendConsoleMessage("Nothing to pickup", ConsoleMessageType.Warning);
				}
			}
			else
			{
				bool flag2 = false;
				string text = command.Arguments[0].ToLower();
				if (text == "all")
				{
					text = command.Arguments[1].ToLower();
				}
				int count2 = Upgrades.Count;
				for (int num2 = 0; num2 < count2; num2++)
				{
					BaseDroneUpgrade baseDroneUpgrade2 = Upgrades[num2];
					if (baseDroneUpgrade2 == null || baseDroneUpgrade2.GetType().FindInterfaces(CommonMethods.SystemTypeFilter, "IStorageUpgrade").Length <= 0 || baseDroneUpgrade2.GetType().FindInterfaces(CommonMethods.SystemTypeFilter, "IDropperUpgrade").Length <= 0)
					{
						continue;
					}
					IStorageUpgrade storageUpgrade2 = (IStorageUpgrade)baseDroneUpgrade2;
					if (storageUpgrade2.Capacity > 0 && baseDroneUpgrade2.CommandValue.StartsWith(text))
					{
						IDropperUpgrade dropperUpgrade2 = (IDropperUpgrade)baseDroneUpgrade2;
						flag2 = true;
						if (dropperUpgrade2.Pickup() != -1)
						{
							command.Handled = true;
							return;
						}
					}
				}
				if (!flag2)
				{
					SendConsoleMessage("Drone cannot store that kind of item", ConsoleMessageType.Warning);
					command.Handled = true;
					break;
				}
			}
			command.Handled = true;
			break;
		}
		int count19 = Upgrades.Count;
		for (int num27 = 0; num27 < count19; num27++)
		{
			BaseDroneUpgrade baseDroneUpgrade11 = Upgrades[num27];
			if (command.Handled)
			{
				break;
			}
			if (baseDroneUpgrade11 == null)
			{
				continue;
			}
			if (IsStunned && baseDroneUpgrade11.CommandValue == command.Command.CommandName)
			{
				SendConsoleMessage("Drone " + DroneNumber + " is not responding", ConsoleMessageType.Warning);
				continue;
			}
			IStorageUpgrade storageUpgrade4 = null;
			bool flag8 = false;
			int num28 = 0;
			if (baseDroneUpgrade11 is IStorageUpgrade)
			{
				storageUpgrade4 = (IStorageUpgrade)baseDroneUpgrade11;
				if (storageUpgrade4.Capacity > 0)
				{
					flag8 = true;
					num28 = storageUpgrade4.Quantity;
				}
			}
			if (baseDroneUpgrade11.PoweredUp)
			{
				baseDroneUpgrade11.ExecuteCommand(command, partOfMultiCommand);
			}
			if (flag8 && storageUpgrade4 != null && storageUpgrade4.Quantity != num28 && command.Handled)
			{
				return;
			}
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone && !command.Handled && (command.Command.CommandName == "generator" || command.Command.CommandName == "motion" || command.Command.CommandName == "turret" || command.Command.CommandName == "stealth" || command.Command.CommandName == "gather" || command.Command.CommandName == "pickup" || command.Command.CommandName == "interface" || command.Command.CommandName == "lure" || command.Command.CommandName == "probe" || command.Command.CommandName == "mine" || command.Command.CommandName == "scan" || command.Command.CommandName == "sensor" || command.Command.CommandName == "shield" || command.Command.CommandName == "stun" || command.Command.CommandName == "theupgradeformerlyknownasturret" || command.Command.CommandName == "teleport" || command.Command.CommandName == "trap" || command.Command.CommandName == "sonic" || command.Command.CommandName == "tow" || command.Command.CommandName == "pry"))
		{
			SendConsoleMessage(string.Format("No '{0}' upgrade on drone {1} ({2}).\r\nPlease select a drone with a '{0}' upgrade", command.Command.CommandName, DroneNumber, DroneName), ConsoleMessageType.Warning);
			if (GlobalSettings.cameraMode == CameraMode.Drone && GameSaveFile.Get("HNT_NOUPGRADE", 0) < 3)
			{
				DroneManager.Instance.EnableUpgradeHintLines();
				GameSaveFile.Save("HNT_NOUPGRADE", GameSaveFile.Get("HNT_NOUPGRADE", 0) + 1);
			}
			command.Handled = true;
		}
	}

	private bool ParseStringAsUpgrade(Drone drone, string cmd, out DroneUpgradeType upgradeType, out List<string> matchingUpgradeList)
	{
		bool result = false;
		matchingUpgradeList = new List<string>();
		upgradeType = DroneUpgradeType.Undefined;
		int num = 0;
		foreach (BaseDroneUpgrade upgrade in drone.Upgrades)
		{
			if (upgrade == null || cmd.Length > upgrade.CommandValue.Length)
			{
				continue;
			}
			if (cmd == upgrade.CommandValue)
			{
				result = true;
				upgradeType = upgrade.Definition.Type;
				break;
			}
			if (upgrade.CommandValue.StartsWith(cmd))
			{
				if (upgradeType == DroneUpgradeType.Undefined)
				{
					num++;
					upgradeType = upgrade.Definition.Type;
					matchingUpgradeList.Add(upgrade.CommandValue);
				}
				else if (upgradeType != upgrade.Definition.Type)
				{
					num++;
					matchingUpgradeList.Add(upgrade.CommandValue);
				}
			}
		}
		return result;
	}

	public void Kill()
	{
		Kill(_random);
	}

	public void Kill(System.Random rnd)
	{
		bool canBeFullyRepaired = false;
		if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty != null && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasDroneDisabledChanceSet)
		{
			if (rnd.Next(1, 101) <= GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.droneDisabledChance)
			{
				canBeFullyRepaired = true;
			}
		}
		else
		{
			int num = rnd.Next(1, 101);
			canBeFullyRepaired = ((!InterfaceDisconnected) ? (num <= 80) : (num <= 25));
		}
		Kill(canBeFullyRepaired, false);
	}

	public void Kill(bool canBeFullyRepaired, bool isLootableDrone)
	{
		currentHitPoints = 0f;
		_isDead = true;
		CanBeFullyRepaired = canBeFullyRepaired;
		if (CanBeFullyRepaired)
		{
			CanBeTowed = true;
			if (!isLootableDrone && DroneManager.Instance.isGeneralGlitchEffectsInUse)
			{
				HUDCameraController.Instance.FireStaticOnDisabled(DroneNumber);
			}
		}
		int count = Upgrades.Count;
		for (int i = 0; i < count; i++)
		{
			BaseDroneUpgrade baseDroneUpgrade = Upgrades[i];
			if (baseDroneUpgrade != null)
			{
				baseDroneUpgrade.PowerDown();
			}
		}
		UnsubscribeFromUpgradesEvents();
		ConsoleWindow3.Instance.RemoveCommandableObject(this);
		TextMesh textMesh = null;
		if (OverlayLabelObject != null)
		{
			Transform transform = OverlayLabelObject.transform.Find("DroneNumber");
			if (transform != null)
			{
				textMesh = transform.GetComponent<TextMesh>();
			}
		}
		if (!CanBeFullyRepaired)
		{
			_imagePlaneRenderer.material = DeathMtl;
			_imagePlaneSVRenderer.material = DeathMtlSV;
			_imagePlaneRenderer.material.color = DeadColor;
			_imagePlaneSVRenderer.material.color = DeadColor;
			overlayTextMesh.color = DeadNameColor;
			if (!DroneManager.Instance.dronesList.Contains(this))
			{
				Transform transform2 = OverlayLabelObject.transform.Find("DroneNumber");
				if (transform2 != null)
				{
					transform2.gameObject.SetActive(false);
				}
				transform2 = base.transform.Find("Label");
				if (transform2 != null)
				{
					transform2.gameObject.SetActive(false);
				}
			}
			if (textMesh != null)
			{
				textMesh.color = DeadNumberColor;
			}
		}
		else
		{
			_imagePlaneRenderer.material = DisabledMaterialDV;
			_imagePlaneSVRenderer.material = DisabledMaterialSV;
			_imagePlaneRenderer.material.color = DisabledColor;
			_imagePlaneSVRenderer.material.color = DisabledColor;
			overlayTextMesh.color = DisabledNameColor;
			if (!DroneManager.Instance.dronesList.Contains(this))
			{
				Transform transform3 = OverlayLabelObject.transform.Find("DroneNumber");
				if (transform3 != null)
				{
					transform3.gameObject.SetActive(false);
				}
				transform3 = base.transform.Find("Label");
				if (transform3 != null)
				{
					transform3.gameObject.SetActive(false);
				}
			}
			if (textMesh != null)
			{
				textMesh.color = DisabledNumberColor;
			}
		}
		if (turretSound.isPlaying)
		{
			turretSound.Stop();
		}
		EnableHelpText();
		isMicGlitching = true;
		timerDelayUntilNextMicSound = UnityEngine.Random.Range(1f, 3f);
	}

	public void SendConsoleMessage(string message)
	{
		SendConsoleMessage(message, ConsoleMessageType.Info);
	}

	public void SendConsoleMessage(string message, ConsoleMessageType messageType)
	{
		ConsoleWindow3.SendConsoleResponse(message, messageType);
	}

	public void Stun(float durationMin, float durationMax)
	{
		if (IsDead)
		{
			return;
		}
		float num = UnityEngine.Random.Range(durationMin, durationMax);
		if (!IsStunned)
		{
			UnStealthIfHidden();
			StunPosition = base.transform.parent.position;
			TimeStunned = num;
			if (NumberOfUpgradesInstalled() > 0)
			{
				foreach (BaseDroneUpgrade upgrade in Upgrades)
				{
					if (upgrade != null && upgrade.IsActivated)
					{
						upgrade.CancelAbility();
					}
				}
			}
		}
		else
		{
			TimeStunned += num;
		}
		if (StunMtl != null)
		{
			_imagePlaneRenderer.material = StunMtl;
			_imagePlaneSVRenderer.material = StunMtlSV;
		}
		SystemMessageManager.ShowSystemMessage("Drone " + DroneNumber + " stunned", ConsoleMessageType.Warning);
		IsStunned = true;
	}

	public void ClearStun()
	{
		TimeStunned = 0f;
		IsStunned = false;
		if (!IsDead && startMtl != null)
		{
			_imagePlaneRenderer.material = startMtl;
			_imagePlaneSVRenderer.material = startMtlSV;
			_imagePlaneRenderer.material.color = startColor;
		}
		Transform transform = null;
		transform = ((!DroneManager.Instance.DebugUseTestSpotlight && !DroneManager.Instance.DebugUseCameraArraySpotlight) ? base.transform.Find("Spotlight") : ((!DroneManager.Instance.DebugUseCameraArraySpotlight) ? Swival.transform.Find("SpotlightTest") : base.transform.Find("SpotlightTestCameraArray")));
		if (transform != null && GlobalSettings.cameraMode == CameraMode.Drone)
		{
			transform.gameObject.SetActive(true);
		}
	}

	public void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (IsDead)
		{
			return;
		}
		UnStealthIfHidden();
		float num = AdjustDamage(damage, type);
		if (!(num > 0f))
		{
			return;
		}
		num = Mathf.Round(num);
		if (type == DamageType.Radiation && DroneManager.Instance.isGeneralGlitchEffectsInUse)
		{
			HUDCameraController.Instance.FireCompression(DroneNumber);
		}
		blinkManager.Start(startColor, HitColor, 0.2f, 2);
		if (damageWarningTimer <= 0f)
		{
			SystemMessageManager.ShowSystemMessage("Drone " + DroneNumber + " taking damage", ConsoleMessageType.Error);
			damageWarningTimer = 10f;
		}
		if (this.OnReceivedDamage != null)
		{
			this.OnReceivedDamage(this, num, type);
		}
		if (num < currentHitPoints)
		{
			GameplayManager.Instance.missionProfitLoss -= (int)num;
		}
		else
		{
			GameplayManager.Instance.missionProfitLoss -= (int)currentHitPoints;
		}
		currentHitPoints -= num;
		if (currentHitPoints <= 0f)
		{
			ClearStun();
			Kill();
			string message = string.Format("Drone {0} was {1}", DroneNumber, (!CanBeFullyRepaired) ? "Destroyed" : "Disabled");
			SystemMessageManager.ShowSystemMessage(message, ConsoleMessageType.Error);
			GameplayManager.Instance.missionProfitLoss -= 400;
			return;
		}
		if (!GlobalSettings.IsTutorial && (GlobalSettings.GameState.ThePlayer.CurrentStarSystem == null || !GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery) && TraitVeer == 0f && damage >= 40f && UnityEngine.Random.Range(0, 100) < 40)
		{
			if (TraitPermVeer == 0f)
			{
				float num2 = UnityEngine.Random.Range(0.5f, 3f);
				if (UnityEngine.Random.Range(0, 2) == 0)
				{
					num2 = -1f * num2;
				}
				TraitVeer = num2;
				if (UnityEngine.Random.Range(0, 100) < 20)
				{
					TraitPermVeer = UnityEngine.Random.Range(0.5f, 1f);
					if (TraitVeer < 0f)
					{
						TraitPermVeer *= -1f;
					}
				}
			}
			else
			{
				float num3 = TraitPermVeer * UnityEngine.Random.Range(2f, 3f);
				float num4 = Mathf.Abs(num3);
				if (num4 < 0.5f)
				{
					num3 = ((!(num3 < 0f)) ? 0.5f : (-0.5f));
				}
				else if (num4 > 3f)
				{
					num3 = ((!(num3 < 0f)) ? 3f : (-3f));
				}
				TraitVeer = num3;
			}
		}
		if (DroneManager.Instance.isGeneralGlitchEffectsInUse)
		{
			HUDCameraController.Instance.FireStaticOnDamage(DroneNumber, damage * 0.01f);
			if (damage >= 25f && UnityEngine.Random.Range(0, 100) < 30)
			{
				HUDCameraController.Instance.FireGlitchOnDamage(DroneNumber);
			}
		}
		if (!isDelayUntilNextMicSound)
		{
			isDelayUntilNextMicSound = true;
			timerDelayUntilNextMicSound = 0.1f;
			PlayRandomMicSound();
		}
	}

	private void PlayRandomMicSound()
	{
		switch (UnityEngine.Random.Range(0, 21))
		{
		case 0:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchA, GameAudio.RemoteVolume);
			break;
		case 1:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchB, GameAudio.RemoteVolume);
			break;
		case 2:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchC, GameAudio.RemoteVolume);
			break;
		case 3:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchD, GameAudio.RemoteVolume);
			break;
		case 4:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchE, GameAudio.RemoteVolume);
			break;
		case 5:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchF, GameAudio.RemoteVolume);
			break;
		case 6:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchG, GameAudio.RemoteVolume);
			break;
		case 7:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchH, GameAudio.RemoteVolume);
			break;
		case 8:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchJ, GameAudio.RemoteVolume);
			break;
		case 9:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchK, GameAudio.RemoteVolume);
			break;
		case 10:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchL, GameAudio.RemoteVolume);
			break;
		case 11:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchM, GameAudio.RemoteVolume);
			break;
		case 12:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchN, GameAudio.RemoteVolume);
			break;
		case 13:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchO, GameAudio.RemoteVolume);
			break;
		case 14:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchP, GameAudio.RemoteVolume);
			break;
		case 15:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchQ, GameAudio.RemoteVolume);
			break;
		case 16:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchR, GameAudio.RemoteVolume);
			break;
		case 17:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchS, GameAudio.RemoteVolume);
			break;
		case 18:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicGlitchT, GameAudio.RemoteVolume);
			break;
		case 19:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicStaticA, GameAudio.RemoteVolume);
			break;
		case 20:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Remote_MicStaticE, GameAudio.RemoteVolume);
			break;
		}
	}

	public void MissedTarget(ICombatTarget target, float attackDamage)
	{
		if (CurrentRoom != null)
		{
			missFireBounds.center = target.Position;
			CurrentRoom.DamageItemsInArea(missFireBounds, attackDamage);
		}
	}

	public void RegisterDirectionalHit(Vector3 force)
	{
		_directionalForce = force;
		_directionalBrakesDelayTimer = 0.35f;
	}

	public void UnStealthIfHidden()
	{
		if (!IsHidden)
		{
			return;
		}
		inLowUpgradeMode = false;
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade.Definition.Type == DroneUpgradeType.StealthField && upgrade.IsActivated)
			{
				upgrade.CancelAbility();
				SystemMessageManager.ShowSystemMessage(string.Format("Stealth terminated on '{0}' Drone", DroneName), ConsoleMessageType.UpgradeStateChange);
			}
		}
	}

	private void CancelOtherShields(BaseDroneUpgrade upgrade)
	{
		foreach (BaseDroneUpgrade upgrade2 in Upgrades)
		{
			if (upgrade2 != null && upgrade2.Definition.Type == DroneUpgradeType.Shield && upgrade.Id != upgrade2.Id && upgrade2.IsActivated)
			{
				upgrade2.CancelAbility();
			}
		}
	}

	private void DeactivateSonicPulseIfOn()
	{
		int count = Upgrades.Count;
		for (int i = 0; i < count; i++)
		{
			BaseDroneUpgrade baseDroneUpgrade = Upgrades[i];
			if (baseDroneUpgrade != null && baseDroneUpgrade.Definition.Type == DroneUpgradeType.Sonic && baseDroneUpgrade.IsActivated)
			{
				baseDroneUpgrade.CancelAbility();
				SystemMessageManager.ShowSystemMessage(string.Format("Sonic terminated on '{0}' Drone", DroneName), ConsoleMessageType.UpgradeStateChange);
			}
		}
	}

	protected float AdjustDamage(float damage, DamageType type)
	{
		bool flag = false;
		float num = 0f;
		IDamagableObject damagableObject = null;
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade == null || upgrade.Definition.Type != DroneUpgradeType.Shield || !upgrade.IsActivated)
			{
				continue;
			}
			IDamagableObject damagableObject2 = (IDamagableObject)upgrade;
			if (!damagableObject2.IsDead)
			{
				flag = true;
				if (damagableObject == null)
				{
					damagableObject = damagableObject2;
				}
				float num2 = damagableObject2.CurrentHitPoints / damagableObject2.TotalHitpoints;
				num += num2;
				if (num > 1f)
				{
					num = 0f;
				}
				else if (num < 0f)
				{
					num = 0f;
				}
			}
		}
		if (flag)
		{
			float num3 = damage;
			float num4 = 0f;
			damage = ((!(num < 0.1f)) ? 0f : (damage * (0.1f * num)));
			num4 = num3 - damage;
			if (damagableObject != null)
			{
				if (type == DamageType.Physical)
				{
					damagableObject.TakeDamage((float)Math.Round(num4, 0), DamageType.Physical, null);
				}
				else if ((((ShieldUpgrade)damagableObject).AppliedModifications & ModificationStorageIdEnum.ShieldRadiation) != ModificationStorageIdEnum.ShieldRadiation)
				{
					damagableObject.TakeDamage((float)Math.Round(num4, 0), DamageType.Physical, null);
				}
			}
		}
		return damage;
	}

	public bool HasActivatedShields()
	{
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade.Definition.Type == DroneUpgradeType.Shield && upgrade.IsActivated)
			{
				return true;
			}
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format("Drone {0}", DroneNumber);
	}

	private bool WouldBeLostInSpace(Vector3 velocity, Vector3 startingPosition)
	{
		Vector3 position = (startingPosition += velocity);
		return DroneManager.Instance.WouldBeLostInSpace(position);
	}

	public DropableItem Drop(DropItemType dropItemType, IDropperUpgrade dropperUpgrade)
	{
		DropableItem dropableItem = itemDropper.Drop(dropItemType, dropperUpgrade, Vector3.zero, null);
		if (dropableItem != null && GlobalSettings.cameraMode == CameraMode.Drone)
		{
			switch (UnityEngine.Random.Range(0, 2))
			{
			case 0:
				dropSound.clip = GameAudio.GetClip(GameAudio.SoundEnum.Remote_ItemDropped1);
				dropSound.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Remote_ItemDropped1, dropSound.volume);
				break;
			case 1:
				dropSound.clip = GameAudio.GetClip(GameAudio.SoundEnum.Remote_ItemDropped2);
				dropSound.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Remote_ItemDropped2, dropSound.volume);
				break;
			}
			dropSound.Play();
		}
		return dropableItem;
	}

	public DropableItem Drop(DropItemType dropItemType, IDropperUpgrade dropperUpgrade, Vector3 dropPosition, Room destRoom)
	{
		DropableItem dropableItem = itemDropper.Drop(dropItemType, dropperUpgrade, dropPosition, destRoom);
		if (dropableItem != null && GlobalSettings.cameraMode == CameraMode.Drone)
		{
			switch (UnityEngine.Random.Range(0, 2))
			{
			case 0:
				dropSound.clip = GameAudio.GetClip(GameAudio.SoundEnum.Remote_ItemDropped1);
				dropSound.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Remote_ItemDropped1, dropSound.volume);
				break;
			case 1:
				dropSound.clip = GameAudio.GetClip(GameAudio.SoundEnum.Remote_ItemDropped2);
				dropSound.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Remote_ItemDropped2, dropSound.volume);
				break;
			}
			dropSound.Play();
		}
		return dropableItem;
	}

	public int Pickup(DropItemType dropItemType, IDropperUpgrade dropperUpgrade, out List<DropableItem> pickedUpItems)
	{
		return itemDropper.Pickup(dropItemType, dropperUpgrade, out pickedUpItems);
	}

	public int Pickup(DropItemType dropItemType, IDropperUpgrade dropperUpgrade, out List<DropableItem> pickedUpItems, Predicate<DropableItem> canPickupItem, out int failedPickupTest)
	{
		return itemDropper.Pickup(dropItemType, dropperUpgrade, out pickedUpItems, canPickupItem, out failedPickupTest);
	}

	public bool AnyPickupableItemsNearby(DropItemType dropItemType, IDropperUpgrade dropperUpgrade)
	{
		return itemDropper.AnyItemsInRange(dropItemType, dropperUpgrade);
	}

	public bool PickupAndTeleport(DropItemType dropType, Room destRoom, out bool noRoomError)
	{
		noRoomError = false;
		if (DroneItemDropper.DroppedItemDict.ContainsKey(dropType))
		{
			foreach (DropableItem item in DroneItemDropper.DroppedItemDict[dropType].ToList())
			{
				if (item == null)
				{
					Debug.Log("Early null error");
					continue;
				}
				DropableItem dropableItem = item;
				if (dropableItem.Destroyed)
				{
					continue;
				}
				float num = Vector3.Distance(base.transform.position, item.transform.position);
				if (!(num < 4f))
				{
					continue;
				}
				Bounds destBounds = new Bounds(Vector3.zero, DroneItemDropper.Instance.sensorPrefab.GetComponent<Collider>().bounds.size);
				Vector3 safePos = Vector3.zero;
				Waypoint mainRoomWaypoint = NavigationHelper.GetMainRoomWaypoint(destRoom);
				destBounds.center = mainRoomWaypoint.transform.position;
				if (destRoom.PickSafeLocationForBounds(destBounds, out safePos))
				{
					item.SetDeactivated();
					if (item is ICombatTarget)
					{
						((ICombatTarget)item).TakeDamage(1000000f, DamageType.Physical, null);
					}
					DroneItemDropper.DroppedItemDict[dropType].Remove(item);
					item.DroneItemDropperUpgrade.Drop(dropType, item.DroppingUpgrade, safePos, destRoom);
					noRoomError = false;
					return true;
				}
				noRoomError = true;
			}
		}
		return false;
	}

	public bool IsSonicPulseActive()
	{
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade.Definition.Type == DroneUpgradeType.Sonic && upgrade.IsActivated)
			{
				return true;
			}
		}
		return false;
	}

	public void StartColorBlink(Color colorToFadeTo, float cycleTime, int numberOfCycles)
	{
		blinkManager.Start(startColor, colorToFadeTo, cycleTime, numberOfCycles);
	}

	public void ReduceQuality()
	{
		Break();
	}

	public void Break()
	{
	}

	public bool Fix(out string fixMessage)
	{
		fixMessage = string.Empty;
		bool result = false;
		if (BrokenState == BrokenStateEnum.Broken && InterfaceDisconnected)
		{
			if (!DroneManager.Instance.DebugUseTestSpotlight && !DroneManager.Instance.DebugUseCameraArraySpotlight)
			{
				base.transform.Find("Spotlight").gameObject.SetActive(true);
			}
			else if (DroneManager.Instance.DebugUseCameraArraySpotlight)
			{
				base.transform.Find("SpotlightTestCameraArray").gameObject.SetActive(true);
			}
			else
			{
				Swival.transform.Find("SpotlightTest").gameObject.SetActive(true);
			}
			InterfaceDisconnected = false;
			fixMessage = "Communication repaired on Drone " + DroneNumber;
			result = true;
		}
		else if (!IsDead && IsStunned)
		{
			TimeStunned = 0f;
			IsStunned = false;
			fixMessage = "Drone " + DroneNumber + " is no longer stunned";
			result = true;
		}
		return result;
	}

	public void OverrideBrokenState(BrokenStateEnum state)
	{
	}

	public void OverrideCurrentHitpoints(float hitpoints)
	{
		currentHitPoints = hitpoints;
	}

	public void OverrideTotalHitpoints(float hitpoints)
	{
		_totalHitpoints = hitpoints;
	}

	public void OverrideIsDead(bool isDead)
	{
		_isDead = isDead;
	}

	public int GetLootCount(bool clearLoot)
	{
		int num = 0;
		int count = Upgrades.Count;
		for (int i = 0; i < count; i++)
		{
			BaseDroneUpgrade baseDroneUpgrade = Upgrades[i];
			if (baseDroneUpgrade != null && baseDroneUpgrade.Definition.Type == DroneUpgradeType.Gatherer)
			{
				num += ((GathererUpgrade)baseDroneUpgrade).GetLootCount();
				if (clearLoot)
				{
					((GathererUpgrade)baseDroneUpgrade).ClearLoot();
				}
			}
		}
		return num;
	}

	public int GetLootCount()
	{
		return GetLootCount(false);
	}

	public int GetPropulsionFuelCount()
	{
		return GetPropulsionFuelCount(false);
	}

	public int GetPropulsionFuelCount(bool clearLoot)
	{
		int num = 0;
		int count = Upgrades.Count;
		for (int i = 0; i < count; i++)
		{
			BaseDroneUpgrade baseDroneUpgrade = Upgrades[i];
			if (baseDroneUpgrade != null && baseDroneUpgrade.Definition.Type == DroneUpgradeType.Gatherer)
			{
				num += ((GathererUpgrade)baseDroneUpgrade).propulsionFuel;
				if (clearLoot)
				{
					((GathererUpgrade)baseDroneUpgrade).propulsionFuel = 0;
				}
			}
		}
		return num;
	}

	public int GetJumpFuelCount()
	{
		return GetJumpFuelCount(false);
	}

	public int GetJumpFuelCount(bool clearLoot)
	{
		int num = 0;
		int count = Upgrades.Count;
		for (int i = 0; i < count; i++)
		{
			BaseDroneUpgrade baseDroneUpgrade = Upgrades[i];
			if (baseDroneUpgrade != null && baseDroneUpgrade.Definition.Type == DroneUpgradeType.Gatherer)
			{
				num += ((GathererUpgrade)baseDroneUpgrade).jumpFuel;
				if (clearLoot)
				{
					((GathererUpgrade)baseDroneUpgrade).jumpFuel = 0;
				}
			}
		}
		return num;
	}

	public void MoveForwardForced(float speed)
	{
		_heading = base.transform.up;
		if (isPumpingFuel)
		{
			GameplayManager.ShowConsoleMessage("   Drone " + DroneNumber + " is gathering fuel - cannot move", ConsoleMessageType.Warning);
			return;
		}
		if (base.transform.parent != null)
		{
			isMoving = true;
			isMovingForwardBack = true;
			if (ItemBeingTowed != null && GlobalSettings.cameraMode == CameraMode.Drone && !towMoveSound.isPlaying && !IsBraking)
			{
				towMoveSound.Play();
				towMoveSound.volume = GameAudio.RemoteVolume * 1f;
			}
			if (IsBeingSwapped)
			{
				DroneManager.Instance.HideUpgradeSwapUI();
			}
			Vector3 velocityVector = GetVelocityVector(speed);
			base.transform.parent.position += velocityVector;
			base.transform.parent.position = new Vector3(base.transform.parent.position.x, base.transform.parent.position.y, 0f);
			EnforceNonPenetrationConstraint();
		}
		if (InterfaceDisconnected)
		{
			droneUIObject.RefreshInfoLabelPos();
		}
		if (isMoving)
		{
			PostMoveStep();
		}
	}

	public void RotateForced(Quaternion rotQ)
	{
		base.transform.rotation = rotQ;
		_heading = base.transform.up;
	}

	public void SwitchToRemoteSounds()
	{
		DroneManager.Instance.StopMovement();
		if (isMoving)
		{
			asREngineSustain.Play();
		}
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade is GeneratorUpgrade)
			{
				((GeneratorUpgrade)upgrade).SwitchToRemoteSounds();
			}
		}
	}

	public void SwitchToSchematicSounds()
	{
		if (asREngineSustain != null && asREngineSustain.isPlaying)
		{
			asREngineSustain.Stop();
		}
		if (asRCollision != null && asRCollision.isPlaying)
		{
			asRCollision.Stop();
		}
		if (isMoving && !IsBraking)
		{
			DroneManager.Instance.PlaySingleSVDroneSound();
		}
		if (asRPickup != null && asRPickup.isPlaying)
		{
			asRPickup.Stop();
		}
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade is GeneratorUpgrade)
			{
				((GeneratorUpgrade)upgrade).SwitchToSchematicSounds();
			}
		}
	}

	public void StopRemoteSounds()
	{
		if (asREngineSustain.isPlaying)
		{
			asREngineSustain.Stop();
		}
		if (asRPickup.isPlaying)
		{
			asRPickup.Stop();
		}
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade is GeneratorUpgrade)
			{
				((GeneratorUpgrade)upgrade).StopRemoteSounds();
			}
		}
	}

	public void PauseSoundsOnMenuOpen()
	{
		if (asREngineSustain.isPlaying)
		{
			isREngineSustainPaused = true;
			asREngineSustain.Pause();
		}
		if (motionSensorSound.isPlaying)
		{
			isRMotionPaused = true;
			motionSensorSound.Pause();
		}
		if (turretSound.isPlaying)
		{
			isRTurretPaused = true;
			turretSound.Pause();
		}
		if (towMoveSound.isPlaying)
		{
			isRTowMovePaused = true;
			towMoveSound.Pause();
		}
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade is GeneratorUpgrade)
			{
				((GeneratorUpgrade)upgrade).PauseSoundsOnMenuOpen();
			}
		}
	}

	public void ResumeSoundsOnMenuClose()
	{
		if (isREngineSustainPaused)
		{
			isREngineSustainPaused = false;
			asREngineSustain.Play();
		}
		if (isRMotionPaused)
		{
			isRMotionPaused = false;
			motionSensorSound.Play();
			motionSensorSound.volume = GameAudio.RemoteVolume * 1f;
		}
		if (isRTurretPaused)
		{
			isRTurretPaused = false;
			turretSound.Play();
			turretSound.volume = GameAudio.RemoteVolume * 1f;
		}
		if (isRTowMovePaused)
		{
			isRTowMovePaused = false;
			towMoveSound.Play();
			towMoveSound.volume = GameAudio.RemoteVolume * 1f;
		}
		foreach (BaseDroneUpgrade upgrade in Upgrades)
		{
			if (upgrade != null && upgrade is GeneratorUpgrade)
			{
				((GeneratorUpgrade)upgrade).ResumeSoundsOnMenuClose();
			}
		}
	}

	public void ApplyForce(Vector3 force, bool playSound, bool isBraking)
	{
		Vector3 heading = _heading;
		Vector3 position = base.transform.parent.position;
		Quaternion rotation = base.transform.rotation;
		IsBraking = isBraking;
		if (IsBraking && ItemBeingTowed != null && towMoveSound.isPlaying && !isMovingBackwards)
		{
			towMoveSound.Stop();
		}
		if (isPumpingFuel)
		{
			Debug.LogError("   Drone " + DroneNumber + " is gathering fuel - cannot move");
			return;
		}
		isMoving = true;
		isMovingForwardBack = true;
		if (IsBeingSwapped && !isBraking)
		{
			DroneManager.Instance.HideUpgradeSwapUI();
		}
		Vector3 velocityVectorRawNoDelta = GetVelocityVectorRawNoDelta(CurrentRawSpeed);
		Vector3 vector = force / 0.5f;
		velocityVectorRawNoDelta += vector * Time.deltaTime;
		velocityVectorRawNoDelta = Vector3.ClampMagnitude(velocityVectorRawNoDelta, CurrentMaxRawSpeed);
		CurrentRawSpeed = velocityVectorRawNoDelta.magnitude;
		if (CurrentRawSpeed > 0.001f && velocityVectorRawNoDelta != Vector3.zero && !isBraking)
		{
			Quaternion to = Quaternion.LookRotation(velocityVectorRawNoDelta, Vector3.back);
			to.x = 0f;
			to.y = 0f;
			PreRotation();
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, 500f * Time.deltaTime);
			PostRotation();
		}
		_heading = velocityVectorRawNoDelta.normalized;
		base.transform.parent.position = new Vector3(base.transform.parent.position.x + velocityVectorRawNoDelta.x * Time.deltaTime, base.transform.parent.position.y + velocityVectorRawNoDelta.y * Time.deltaTime, 0f);
		if (ItemBeingTowed is Drone && ((Drone)ItemBeingTowed).ForceNonPenetration())
		{
			RestartPilotColisionSlowdown();
		}
		if (!GlobalSettings.cheatMode)
		{
			EnforceNonPenetrationConstraint();
			if (IsInOuterSpace())
			{
				_heading = heading;
				base.transform.parent.position = position;
				PreRotation();
				base.transform.rotation = rotation;
				PostRotation();
			}
		}
		if (isMoving && playSound)
		{
			PostMoveStep();
		}
	}

	private bool IsInOuterSpace()
	{
		if (CurrentRoom != null)
		{
			if (CurrentRoom.GetComponent<Collider>().bounds.Contains(Position))
			{
				return false;
			}
			for (int i = 0; i < CurrentRoom.corridors.Count; i++)
			{
				Corridor corridor = CurrentRoom.corridors[i];
				if (corridor.GetComponent<Collider>().bounds.Contains(Position))
				{
					return false;
				}
			}
		}
		else if (CurrentCorridor != null && CurrentCorridor.GetComponent<Collider>().bounds.Contains(Position))
		{
			return false;
		}
		return true;
	}

	public void PreRotation()
	{
		if (OverlayLabelObject != null)
		{
			OverlayLabelObject.transform.parent = null;
		}
	}

	public void PostRotation()
	{
		if (OverlayLabelObject != null)
		{
			OverlayLabelObject.transform.parent = dvOverlayTrans;
		}
	}

	public void RestartPilotColisionSlowdown()
	{
		if (IsUnderPlayerControl && !IsBeingTowed)
		{
			AddSpeedModifier("collisionFriction", _gradedPilotColisionSlowdown);
			_nonPenetrationTimer = 0.08f;
		}
	}

	public bool ForceNonPenetration()
	{
		_heading = base.transform.up;
		isMoving = true;
		isMovingForwardBack = true;
		if (IsBeingSwapped)
		{
			DroneManager.Instance.HideUpgradeSwapUI();
		}
		bool result = EnforceNonPenetrationConstraint();
		if (InterfaceDisconnected)
		{
			droneUIObject.RefreshInfoLabelPos();
		}
		if (isMoving)
		{
			PostMoveStep();
		}
		return result;
	}

	private bool EnforceNonPenetrationConstraint()
	{
		bool flag = false;
		SphereCollider component = base.transform.GetComponent<SphereCollider>();
		int count = DroneManager.Instance.dronesList.Count;
		for (int i = 0; i < count; i++)
		{
			Drone drone = DroneManager.Instance.dronesList[i];
			if (!(drone == null) && !(drone == this) && !(drone == _brain.Target))
			{
				Vector3 vector = Position - drone.Position;
				float magnitude = vector.magnitude;
				SphereCollider component2 = drone.transform.GetComponent<SphereCollider>();
				float num = component.radius + component2.radius - magnitude;
				if (num > 0f)
				{
					flag = true;
					Vector3 vector2 = vector / magnitude * num;
					ProcessCollisionBasedOnAngle(vector2);
					base.transform.parent.position = base.transform.parent.position + vector2;
					base.transform.parent.position = new Vector3(base.transform.parent.position.x, base.transform.parent.position.y, 0f);
				}
			}
		}
		count = DroneManager.Instance.LootableDronesList.Count;
		for (int j = 0; j < count; j++)
		{
			Drone drone2 = DroneManager.Instance.LootableDronesList[j];
			if (!(drone2 == null) && !(drone2 == this))
			{
				Vector3 vector3 = Position - drone2.Position;
				float magnitude2 = vector3.magnitude;
				SphereCollider component3 = drone2.transform.GetComponent<SphereCollider>();
				float num2 = component.radius + component3.radius - magnitude2;
				if (num2 > 0f)
				{
					flag = true;
					Vector3 vector4 = vector3 / magnitude2 * num2;
					ProcessCollisionBasedOnAngle(vector4);
					base.transform.parent.position = base.transform.parent.position + vector4;
					base.transform.parent.position = new Vector3(base.transform.parent.position.x, base.transform.parent.position.y, 0f);
				}
			}
		}
		count = EnemyManager.Instance.CollidingEnemies.Count;
		for (int k = 0; k < count; k++)
		{
			BaseEnemy baseEnemy = EnemyManager.Instance.CollidingEnemies[k];
			if (!(baseEnemy == null) && !baseEnemy.IsDead)
			{
				Vector3 vector5 = Position - baseEnemy.Position;
				float magnitude3 = vector5.magnitude;
				SphereCollider component4 = baseEnemy.transform.GetComponent<SphereCollider>();
				float num3 = component.radius + component4.radius - magnitude3;
				if (num3 > 0f)
				{
					baseEnemy.NotifyCollision(this);
					flag = true;
					Vector3 vector6 = vector5 / magnitude3 * num3;
					ProcessCollisionBasedOnAngle(vector6);
					base.transform.parent.position = base.transform.parent.position + vector6;
					base.transform.parent.position = new Vector3(base.transform.parent.position.x, base.transform.parent.position.y, 0f);
				}
			}
		}
		if (CurrentRoom != null)
		{
			count = CurrentRoom.StaticCollisionObjects.Count;
			for (int l = 0; l < count; l++)
			{
				GameObject gameObject = CurrentRoom.StaticCollisionObjects[l];
				if (gameObject != null)
				{
					bool flag2 = false;
					ChildSphereColliders component5 = gameObject.GetComponent<ChildSphereColliders>();
					if ((!(component5 == null)) ? ProcessChildSphereObjectForZeroPenetration(component5, component) : ProcessNonSphereObjectForZeroPenetration(gameObject, component))
					{
						flag = true;
					}
				}
			}
			count = CurrentRoom.roomItems.Count;
			for (int m = 0; m < count; m++)
			{
				GameObject gameObject2 = null;
				if (CurrentRoom.roomItems[m] != null && (CurrentRoom.roomItems[m] is DungeonTerminal || CurrentRoom.roomItems[m] is DungeonDefense))
				{
					gameObject2 = CurrentRoom.roomItems[m].gameObject;
				}
				if (gameObject2 != null && ProcessNonSphereObjectForZeroPenetration(gameObject2, component))
				{
					flag = true;
				}
			}
			count = CurrentRoom.corridors.Count;
			for (int n = 0; n < count; n++)
			{
				Corridor corridor = CurrentRoom.corridors[n];
				if (ProcessNonSphereObjectForZeroPenetration(corridor.door.sliderA.gameObject, component))
				{
					flag = true;
				}
				if (ProcessNonSphereObjectForZeroPenetration(corridor.door.sliderB.gameObject, component))
				{
					flag = true;
				}
			}
			if (CurrentRoom.wallModels != null)
			{
				count = CurrentRoom.wallModels.Count;
				for (int num4 = 0; num4 < count; num4++)
				{
					GameObject objectToCheck = CurrentRoom.wallModels[num4];
					if (ProcessNonSphereObjectForZeroPenetration(objectToCheck, component))
					{
						flag = true;
					}
				}
			}
		}
		else if (CurrentCorridor != null)
		{
			if (ProcessNonSphereObjectForZeroPenetration(CurrentCorridor.door.sliderA.gameObject, component))
			{
				flag = true;
			}
			if (ProcessNonSphereObjectForZeroPenetration(CurrentCorridor.door.sliderB.gameObject, component))
			{
				flag = true;
			}
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone && flag && CurrentRawSpeed >= FixedMaxRawSpeed * 0.95f && canPlayCollisionSound && !asRCollision.isPlaying)
		{
			GameAudio.SoundEnum key = GameAudio.SoundEnum.None;
			switch (UnityEngine.Random.Range(0, 3))
			{
			case 0:
				key = GameAudio.SoundEnum.Remote_DroneCollide1;
				break;
			case 1:
				key = GameAudio.SoundEnum.Remote_DroneCollide2;
				break;
			case 2:
				key = GameAudio.SoundEnum.Remote_DroneCollide3;
				break;
			}
			asRCollision.clip = GameAudio.GetClip(key);
			asRCollision.volume = GameAudio.VolumeMultiplier(key, GameAudio.RemoteVolume);
			asRCollision.Play();
			canPlayCollisionSound = false;
			timerDelayUntilNextCollisionPlay = 1f;
		}
		return flag;
	}

	public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
	{
		Vector3 vector = point - pivot;
		vector = Quaternion.Euler(angles) * vector;
		point = vector + pivot;
		return point;
	}

	private bool ProcessNonSphereObjectForZeroPenetration(GameObject objectToCheck, SphereCollider droneSphereCollider)
	{
		if (objectToCheck == null || objectToCheck.GetComponent<Collider>() == null)
		{
			return false;
		}
		bool result = false;
		Vector3 vector = objectToCheck.GetComponent<Collider>().ClosestPointOnBounds(Position);
		Vector3 vector2 = Position - vector;
		float num = Mathf.Max(vector2.magnitude, 0.0001f);
		float num2 = droneSphereCollider.radius - num;
		if (num2 > 0f)
		{
			result = true;
			Vector3 vector3 = vector2 / num * num2;
			ProcessCollisionBasedOnAngle(vector3);
			base.transform.parent.position = base.transform.parent.position + vector3;
			base.transform.parent.position = new Vector3(base.transform.parent.position.x, base.transform.parent.position.y, 0f);
		}
		return result;
	}

	private bool ProcessNonSphereObjectForZeroPenetrationMesh(BoundsTestableItem objectToCheck, SphereCollider droneSphereCollider)
	{
		if (objectToCheck == null || objectToCheck.GetComponent<Collider>() == null)
		{
			return false;
		}
		BaryCentricDistance.Result closestTriangleAndPoint = objectToCheck.closestPointCalculator.GetClosestTriangleAndPoint(Position);
		bool result = false;
		Vector3 closestPoint = closestTriangleAndPoint.closestPoint;
		Vector3 vector = Position - closestPoint;
		float num = Mathf.Max(vector.magnitude, 0.0001f);
		float num2 = droneSphereCollider.radius - num;
		if (num2 > 0f)
		{
			result = true;
			Vector3 vector2 = vector / num * num2;
			ProcessCollisionBasedOnAngle(vector2);
			base.transform.parent.position = base.transform.parent.position + vector2;
			base.transform.parent.position = new Vector3(base.transform.parent.position.x, base.transform.parent.position.y, 0f);
		}
		return result;
	}

	private bool ProcessChildSphereObjectForZeroPenetration(ChildSphereColliders objectToCheck, SphereCollider droneSphereCollider)
	{
		if (objectToCheck == null || objectToCheck.GetComponent<Collider>() == null || objectToCheck.ChildColliders == null)
		{
			return false;
		}
		Collider component = objectToCheck.GetComponent<Collider>();
		if (!component.bounds.Intersects(droneSphereCollider.bounds))
		{
			return false;
		}
		bool result = false;
		for (int i = 0; i < objectToCheck.ChildColliders.Length; i++)
		{
			SphereCollider sphereCollider = objectToCheck.ChildColliders[i];
			Vector3 vector = Position - sphereCollider.transform.position;
			float magnitude = vector.magnitude;
			float num = droneSphereCollider.radius + sphereCollider.radius - magnitude;
			if (num > 0f)
			{
				result = true;
				Vector3 vector2 = vector / magnitude * num;
				ProcessCollisionBasedOnAngle(vector2);
				base.transform.parent.position = base.transform.parent.position + vector2;
				base.transform.parent.position = new Vector3(base.transform.parent.position.x, base.transform.parent.position.y, 0f);
			}
		}
		return result;
	}

	private void ProcessCollisionBasedOnAngle(Vector3 adjustment)
	{
		float num = Vector3.Angle(_heading, adjustment);
		if (Input.GetButton("Down") && !Input.GetButton("Up"))
		{
			_sharpCollisionReverse = num <= 30f || num >= 150f;
			_sharpCollisionForward = false;
		}
		else
		{
			_sharpCollisionForward = num <= 30f || num >= 150f;
			_sharpCollisionReverse = false;
		}
		if (!_sharpCollisionForward && !_sharpCollisionReverse && _underPlayerControl && (num < 80f || num > 100f))
		{
			float num2 = num;
			if (num2 > 90f)
			{
				num2 = 180f - num2;
			}
			_gradedPilotColisionSlowdown = num2 / 80f * 0.7f;
			RestartPilotColisionSlowdown();
			if (_tempCollideCooldown <= 0f && _tempCollideTimer <= 0f)
			{
				_tempCollideTimer = 0.1f;
				_tempCollideStop = true;
			}
		}
	}

	public void ApplySlimeSnare()
	{
		_slimeSnareTimer = 2f;
		AddSpeedModifier("slime", 0.3f);
	}

	public void SelfDestruct()
	{
		isInSelfDestructMode = false;
		SystemMessageManager.ShowSystemMessage("Drone " + DroneNumber + " self destructing", ConsoleMessageType.Warning);
		if (!IsDead)
		{
			Kill();
		}
		float damage = 1000f;
		foreach (BaseEnemy enemy in enemies)
		{
			if (((CurrentRoom != null && enemy.CurrentRoom == CurrentRoom) || (CurrentCorridor != null && enemy.CurrentCorridor == CurrentCorridor)) && UnityEngine.Random.Range(0f, 1f) < 1f)
			{
				enemy.TakeDamage(damage, DamageType.Physical, this);
			}
		}
		foreach (Drone drones in DroneManager.Instance.dronesList)
		{
			if (((CurrentRoom != null && drones.CurrentRoom == CurrentRoom) || (CurrentCorridor != null && drones.CurrentCorridor == CurrentCorridor)) && UnityEngine.Random.Range(0f, 1f) < 1f)
			{
				drones.TakeDamage(damage, DamageType.Physical, this);
			}
		}
		if (CurrentRoom != null)
		{
			CurrentRoom.ExplosionInRoom(damage);
		}
		explosionSound.volume = GameAudio.RemoteVolume * 1f;
		explosionSound.Play();
	}

	public void SetSchematicVisibility(bool show)
	{
		if (!(droneUIObject != null))
		{
			return;
		}
		Transform transform = base.transform.Find("Overlays");
		if (!show && !IsInvisibleDueToToggle)
		{
			IsInvisibleDueToToggle = true;
			droneUIObject.HideOnSchematic();
			if (TurretUIObject != null)
			{
				TurretUIObject.GetComponent<Renderer>().enabled = false;
			}
			if (shieldRenderer != null)
			{
				shieldRenderer.enabled = false;
			}
		}
		else if (show && IsInvisibleDueToToggle)
		{
			IsInvisibleDueToToggle = false;
			droneUIObject.RevealOnSchematic();
			if ((GetUpgradeInstanceCount(DroneUpgradeType.BruteTurret) > 0 || GetUpgradeInstanceCount(DroneUpgradeType.SwarmTurret) > 0) && TurretUIObject != null)
			{
				TurretUIObject.GetComponent<Renderer>().enabled = true;
			}
			if (GetUpgradeInstanceCount(DroneUpgradeType.Shield) > 0 && shieldRenderer != null)
			{
				shieldRenderer.enabled = true;
			}
		}
	}

	public void BeginTowItem(ITowItem item)
	{
		ItemBeingTowed = item;
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			towLatchSound.Play();
			towLatchSound.volume = 1f;
		}
	}

	public void EndTowItem()
	{
		ItemBeingTowed = null;
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			towLatchSound.Play();
			towLatchSound.volume = 1f;
		}
		if (towMoveSound.isPlaying)
		{
			towMoveSound.Stop();
		}
	}

	public void PlayCallSign()
	{
		if (asRCallSign != null && !asRCallSign.isPlaying)
		{
			asRCallSign.Play();
			asRCallSign.volume = GameAudio.VolumeMultiplier(soundRCallSign, GameAudio.DroneCallSignalVolume);
		}
	}

	public void PlayPickupSound()
	{
		if (!asRPickup.isPlaying)
		{
			asRPickup.Play();
		}
	}

	private void AddSoundSources()
	{
		asREngineSustain = base.gameObject.AddComponent<AudioSource>();
		asREngineSustain.spatialBlend = 1f;
		switch (engineType)
		{
		case EngineTypeEnum.EngineA:
			soundREngineSustain = GameAudio.SoundEnum.Remote_DroneMoveSustain;
			break;
		case EngineTypeEnum.EngineB:
			soundREngineSustain = GameAudio.SoundEnum.Remote_DroneEngineLoop;
			break;
		}
		asREngineSustain.clip = GameAudio.GetClip(soundREngineSustain);
		asREngineSustain.volume = GameAudio.VolumeMultiplier(soundREngineSustain, GameAudio.RemoteVolume);
		engineNormalPitch = asREngineSustain.pitch;
		engineNormalPitch += TraitPitchOffset;
		asREngineSustain.playOnAwake = false;
		asRCallSign = base.gameObject.AddComponent<AudioSource>();
		switch (CSID)
		{
		case 0:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_1;
			break;
		case 1:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_2;
			break;
		case 2:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_3;
			break;
		case 3:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_4;
			break;
		case 4:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_5;
			break;
		case 5:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_6;
			break;
		case 6:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_7;
			break;
		case 7:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_8;
			break;
		case 8:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_9;
			break;
		case 9:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_10;
			break;
		case 10:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_11;
			break;
		case 11:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_12;
			break;
		case 12:
			soundRCallSign = GameAudio.SoundEnum.DroneCS_13;
			break;
		default:
		{
			int num = 0;
			num++;
			break;
		}
		}
		asRCallSign.clip = GameAudio.GetClip(soundRCallSign);
		asRCallSign.volume = GameAudio.VolumeMultiplier(soundRCallSign, GameAudio.DroneCallSignalVolume);
		asRCallSign.playOnAwake = false;
		asRCallSign.spatialBlend = 0f;
		asRCollision = base.gameObject.AddComponent<AudioSource>();
		asRCollision.spatialBlend = 1f;
		asRCollision.playOnAwake = false;
		asRPickup = base.gameObject.AddComponent<AudioSource>();
		asRPickup.clip = GameAudio.GetClip(GameAudio.SoundEnum.Remote_ItemPickedUp);
		asRPickup.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Remote_ItemPickedUp, GameAudio.InterfaceVolume);
		asRPickup.spatialBlend = 1f;
		asRPickup.playOnAwake = false;
		asRPickup.loop = false;
	}

	private void RemoveSoundSources()
	{
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_DroneCollide1);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_DroneCollide2);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_DroneCollide3);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_DroneMoveSustain);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_DroneEngineLoop);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_ItemPickedUp);
		GameAudio.RemoveClip(GameAudio.SoundEnum.DroneCS_1);
		GameAudio.RemoveClip(GameAudio.SoundEnum.DroneCS_2);
		GameAudio.RemoveClip(GameAudio.SoundEnum.DroneCS_3);
		GameAudio.RemoveClip(GameAudio.SoundEnum.DroneCS_4);
		GameAudio.RemoveClip(GameAudio.SoundEnum.DroneCS_5);
		GameAudio.RemoveClip(GameAudio.SoundEnum.DroneCS_6);
		GameAudio.RemoveClip(GameAudio.SoundEnum.DroneCS_7);
		GameAudio.RemoveClip(GameAudio.SoundEnum.DroneCS_8);
		GameAudio.RemoveClip(GameAudio.SoundEnum.DroneCS_9);
	}

	private void CheckForObjectCollisions()
	{
		RemoveItemsNoLongerColliding(_collisionCube.gameObject, CollidingObjects);
		int count = DroneManager.Instance.dronesList.Count;
		for (int i = 0; i < count; i++)
		{
			Drone drone = DroneManager.Instance.dronesList[i];
			if (!(drone == this) && (!(ItemBeingTowed is Drone) || !(drone == (Drone)ItemBeingTowed)))
			{
				CheckForObjectColliding(drone.gameObject, _collisionCube.gameObject, CollidingObjects);
			}
		}
		count = DroneManager.Instance.LootableDronesList.Count;
		for (int j = 0; j < count; j++)
		{
			Drone drone2 = DroneManager.Instance.LootableDronesList[j];
			if (!(ItemBeingTowed is Drone) || !(drone2 == (Drone)ItemBeingTowed))
			{
				CheckForObjectColliding(drone2.gameObject, _collisionCube.gameObject, CollidingObjects);
			}
		}
		if (CurrentRoom != null)
		{
			count = CurrentRoom.roomItems.Count;
			for (int k = 0; k < count; k++)
			{
				RoomItem roomItem = CurrentRoom.roomItems[k];
				if (roomItem is DungeonTerminal || roomItem is DungeonDefense)
				{
					CheckForObjectColliding(roomItem.gameObject, _collisionCube.gameObject, CollidingObjects);
				}
			}
			count = CurrentRoom.StaticCollisionObjects.Count;
			for (int l = 0; l < count; l++)
			{
				GameObject gameObject = CurrentRoom.StaticCollisionObjects[l];
				if (!(gameObject == null) && !(gameObject.GetComponent<Collider>() == null))
				{
					CheckForObjectColliding(gameObject, _collisionCube.gameObject, CollidingObjects);
				}
			}
		}
		count = EnemyManager.Instance.CollidingEnemies.Count;
		for (int m = 0; m < count; m++)
		{
			BaseEnemy baseEnemy = EnemyManager.Instance.CollidingEnemies[m];
			if (!baseEnemy.IsDead)
			{
				CheckForObjectColliding(baseEnemy.gameObject, _collisionCube.gameObject, CollidingObjects);
			}
		}
	}

	private void RemoveItemsNoLongerColliding(GameObject colliderObject, List<GameObject> itemsColliding)
	{
		if (colliderObject == null)
		{
			return;
		}
		for (int num = itemsColliding.Count - 1; num >= 0; num--)
		{
			GameObject gameObject = itemsColliding[num];
			if (gameObject != null && !colliderObject.GetComponent<Collider>().bounds.Intersects(gameObject.GetComponent<Collider>().bounds))
			{
				itemsColliding.RemoveAt(num);
			}
			else if (gameObject != null && ItemBeingTowed != null && ItemBeingTowed.UnderlyingGameObject == gameObject)
			{
				itemsColliding.RemoveAt(num);
			}
		}
	}

	private void CheckForObjectColliding(GameObject testObject, GameObject colliderObject, List<GameObject> itemsColliding)
	{
		if (!itemsColliding.Contains(testObject) && colliderObject.GetComponent<Collider>().bounds.Intersects(testObject.GetComponent<Collider>().bounds))
		{
			itemsColliding.Add(testObject);
		}
	}

	private void CheckForWallCollisions()
	{
		for (int num = _collidingWallsLeft.Count - 1; num >= 0; num--)
		{
			GameObject gameObject = _collidingWallsLeft[num];
			if (!_frontFeelers.LeftFeeler.GetComponent<Collider>().bounds.Intersects(gameObject.GetComponent<Collider>().bounds))
			{
				_collidingWallsLeft.RemoveAt(num);
			}
		}
		for (int num2 = _collidingWallsMiddle.Count - 1; num2 >= 0; num2--)
		{
			GameObject gameObject2 = _collidingWallsMiddle[num2];
			if (!_frontFeelers.MiddleFeeler.GetComponent<Collider>().bounds.Intersects(gameObject2.GetComponent<Collider>().bounds))
			{
				_collidingWallsMiddle.RemoveAt(num2);
			}
		}
		for (int num3 = _collidingWallsRight.Count - 1; num3 >= 0; num3--)
		{
			GameObject gameObject3 = _collidingWallsRight[num3];
			if (!_frontFeelers.RightFeeler.GetComponent<Collider>().bounds.Intersects(gameObject3.GetComponent<Collider>().bounds))
			{
				_collidingWallsRight.RemoveAt(num3);
			}
		}
		for (int num4 = _collidingWallsRear.Count - 1; num4 >= 0; num4--)
		{
			GameObject gameObject4 = _collidingWallsRear[num4];
			if (!_rearFeeler.GetComponent<Collider>().bounds.Intersects(gameObject4.GetComponent<Collider>().bounds))
			{
				_collidingWallsRear.RemoveAt(num4);
			}
		}
		if (CurrentRoom != null)
		{
			CheckRoomForSingleFeelerCollision(_frontFeelers.LeftFeeler, _currentRoom, _collidingWallsLeft, true);
			CheckRoomForSingleFeelerCollision(_frontFeelers.MiddleFeeler, _currentRoom, _collidingWallsMiddle, true);
			CheckRoomForSingleFeelerCollision(_frontFeelers.RightFeeler, _currentRoom, _collidingWallsRight, true);
			CheckRoomForSingleFeelerCollision(_rearFeeler, _currentRoom, _collidingWallsRear, true);
		}
		else if (CurrentCorridor != null)
		{
			CheckCorridorForSingleFeelerCollision(_frontFeelers.LeftFeeler, CurrentCorridor, _collidingWallsLeft);
			CheckCorridorForSingleFeelerCollision(_frontFeelers.MiddleFeeler, CurrentCorridor, _collidingWallsMiddle);
			CheckCorridorForSingleFeelerCollision(_frontFeelers.RightFeeler, CurrentCorridor, _collidingWallsRight);
			CheckCorridorForSingleFeelerCollision(_rearFeeler, CurrentCorridor, _collidingWallsRear);
			int num5 = CurrentCorridor.rooms.Length;
			for (int i = 0; i < num5; i++)
			{
				Room room = CurrentCorridor.rooms[i];
				CheckRoomForSingleFeelerCollision(_frontFeelers.LeftFeeler, room, _collidingWallsLeft, false);
				CheckRoomForSingleFeelerCollision(_frontFeelers.MiddleFeeler, room, _collidingWallsMiddle, false);
				CheckRoomForSingleFeelerCollision(_frontFeelers.RightFeeler, room, _collidingWallsRight, false);
				CheckRoomForSingleFeelerCollision(_rearFeeler, room, _collidingWallsRear, false);
			}
		}
	}

	private void CheckRoomForSingleFeelerCollision(GameObject feeler, Room room, List<GameObject> collidingWalls, bool checkCorridors)
	{
		if (room == null)
		{
			return;
		}
		Bounds bounds = feeler.GetComponent<Collider>().bounds;
		int count;
		if (room.wallModels != null)
		{
			count = room.wallModels.Count;
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = room.wallModels[i];
				if (!ContainsLoop(collidingWalls, gameObject) && bounds.Intersects(gameObject.GetComponent<Collider>().bounds))
				{
					collidingWalls.Add(gameObject);
				}
			}
		}
		count = room.StaticCollisionObjects.Count;
		for (int j = 0; j < count; j++)
		{
			GameObject gameObject2 = room.StaticCollisionObjects[j];
			if (!(gameObject2 == null) && !(gameObject2.GetComponent<Collider>() == null) && !ContainsLoop(collidingWalls, gameObject2) && bounds.Intersects(gameObject2.GetComponent<Collider>().bounds))
			{
				collidingWalls.Add(gameObject2);
			}
		}
		if (checkCorridors)
		{
			count = room.corridors.Count;
			for (int k = 0; k < count; k++)
			{
				CheckCorridorForSingleFeelerCollision(feeler, room.corridors[k], collidingWalls);
			}
		}
	}

	private void CheckCorridorForSingleFeelerCollision(GameObject feeler, Corridor corridor, List<GameObject> collidingWalls)
	{
		Bounds bounds = feeler.GetComponent<Collider>().bounds;
		GameObject gameObject = corridor.door.sliderA.gameObject;
		if (!ContainsLoop(collidingWalls, gameObject) && bounds.Intersects(gameObject.GetComponent<Collider>().bounds))
		{
			collidingWalls.Add(gameObject);
		}
		gameObject = corridor.door.sliderB.gameObject;
		if (!ContainsLoop(collidingWalls, gameObject) && bounds.Intersects(gameObject.GetComponent<Collider>().bounds))
		{
			collidingWalls.Add(gameObject);
		}
	}

	private bool ContainsLoop(List<GameObject> lst, GameObject obj)
	{
		int count = lst.Count;
		for (int i = 0; i < count; i++)
		{
			if (lst[i] == obj)
			{
				return true;
			}
		}
		return false;
	}

	public void DisconnectSvVisuals()
	{
		if (_labelSV != null)
		{
			_labelSV.transform.parent = null;
		}
		if (_imagePlaneSV != null)
		{
			_imagePlaneSV.transform.parent = null;
		}
		if (_turretOverlay != null)
		{
			_turretOverlay.transform.parent = null;
			Vector3 position = _turretOverlay.transform.position;
			position.z -= 3f;
			_turretOverlay.transform.position = position;
		}
		if (_shieldOverlay != null)
		{
			_shieldOverlay.transform.parent = null;
		}
		if (ItemBeingTowed != null && ItemBeingTowed is ShipUpgradeInGameObject)
		{
			((ShipUpgradeInGameObject)ItemBeingTowed).DisconnectSvVisuals();
		}
	}

	public void ReconnectSvVisuals()
	{
		if (_labelSV != null)
		{
			_labelSV.transform.parent = base.transform;
			_labelSV.transform.position = _labelSV_Reference.transform.position;
			_labelSV.transform.rotation = _labelSV_Reference.transform.rotation;
			_labelSV.transform.localScale = _labelSV_Reference.transform.localScale;
		}
		if (_imagePlaneSV != null)
		{
			_imagePlaneSV.transform.parent = base.transform;
			_imagePlaneSV.transform.position = _imagePlaneSV_Reference.transform.position;
			_imagePlaneSV.transform.rotation = _imagePlaneSV_Reference.transform.rotation;
			_imagePlaneSV.transform.localScale = _imagePlaneSV_Reference.transform.localScale;
		}
		if (_turretOverlay != null)
		{
			_turretOverlay.transform.parent = _overlaysRoot.transform;
			_turretOverlay.transform.position = _turretOverlay_Reference.transform.position;
			_turretOverlay.transform.rotation = _turretOverlay_Reference.transform.rotation;
			_turretOverlay.transform.localScale = _turretOverlay_Reference.transform.localScale;
		}
		if (_shieldOverlay != null)
		{
			_shieldOverlay.transform.parent = _overlaysRoot.transform;
			_shieldOverlay.transform.position = _shieldOverlay_Reference.transform.position;
			_shieldOverlay.transform.rotation = _shieldOverlay_Reference.transform.rotation;
			_shieldOverlay.transform.localScale = _shieldOverlay_Reference.transform.localScale;
		}
		if (ItemBeingTowed != null && ItemBeingTowed is ShipUpgradeInGameObject)
		{
			((ShipUpgradeInGameObject)ItemBeingTowed).ReconnectSvVisuals();
		}
	}

	public void ClearBraking()
	{
		IsBraking = false;
	}

	public void SetUnderPlayerControl()
	{
		_underPlayerControl = true;
	}
}
