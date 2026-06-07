using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Achievements;
using SINetworking;
using UnityEngine;
using UnityEngine.Rendering;

public class Actor : Selectable, IDistributee, IHasSpeed, IStylable, IFormatColorObject, IHasVector, IBenefitReceiver, IDoorTriggerer
{
	public enum AnimationStates
	{
		Idle = 0,
		Walk = 1,
		Fridge = 2,
		Work = 3,
		SitStill = 4,
		Talk = 5,
		Coffee = 6,
		Relax = 7,
		TurnRight = 8,
		TurnLeft = 9,
		Dust = 10,
		Repair = 11,
		SitHandsdown = 12,
		HappyKeyboard = 13,
		WaterState = 14,
		DrinkWater = 15,
		TalkWater = 16,
		StandUpTalking = 17,
		VehicleOut = 18,
		PickBox = 19,
		OpenVan = 20,
		WashHands = 21,
		Run = 22,
		Panic = 23,
		HandsUp = 24,
		WriteClipboard = 25,
		EatAtTable = 26,
		EatInHands = 27,
		EatStandingUp = 28,
		Steal = 29,
		Sneak = 30,
		FireFight = 31,
		Cycle = 32,
		Shower = 33,
		PowerDown = 34,
		GoToSleep = 35,
		GoToSleepMirror = 36,
		EmptyTrash = 37
	}

	public enum WorkStatus
	{
		Working = 0,
		NoWork = 1,
		NoComputer = 2,
		NotApplicable = 3,
		NoEffectiveness = 4,
		NoActiveWork = 5
	}

	public enum HomeState
	{
		Default = 0,
		Retired = 1,
		Vacation = 2,
		Sick = 3,
		Dead = 4,
		Hospitalized = 5,
		Sleeping = 6
	}

	public enum WorkParticle
	{
		None = -1,
		Binary = 0,
		Shapes = 1,
		Letters = 2,
		ThumbsUp = 3,
		Dollar = 4,
		CourtHammer = 5,
		Research = 6,
		Phone = 7
	}

	public enum Affector
	{
		Slavery = 0,
		Hunger = 1,
		Energy = 2,
		Bladder = 3,
		JobSatisfaction = 4,
		Stress = 5,
		Social = 6,
		Salary = 7,
		Fired = 8,
		TeamCompatibility = 9,
		RoomAura = 10,
		Temperature = 11,
		Lighting = 12,
		Environment = 13,
		Comfort = 14,
		Computer = 15,
		Noise = 16,
		Basement = 17,
		OtherTeams = 18,
		OwnOffice = 19,
		CrunchHangover = 20,
		BadBack = 21,
		TraitNightOwl = 22,
		TraitSuperFocus = 23,
		TraitJustTheFlu = 24,
		TraitUnderTheWeather = 25,
		TraitSunshine = 26,
		TraitSkyscraper = 27,
		AirQuality = 28,
		DemandBreach = 29,
		BestFriend = 30,
		Mentoring = 31,
		TraitClaustrophobic = 32
	}

	public enum ElevatorState
	{
		None = 0,
		Queued = 1,
		Entering = 2,
		InTransit = 3
	}

	public static uint[][] ParticleSeed = new uint[8][]
	{
		new uint[2] { 0u, 7u },
		new uint[3] { 1u, 13u, 25u },
		new uint[3] { 2u, 4u, 16u },
		new uint[1] { 5u },
		new uint[1] { 27u },
		new uint[1] { 10u },
		new uint[1] { 3u },
		new uint[1] { 8u }
	};

	public static int AffectorCount = 33;

	public static float HumanHeight = 1.4f;

	public static float StressRelief = 0.5f;

	public static ObjectPool<List<PathVector>> PathPool = new ObjectPool<List<PathVector>>(() => new List<PathVector>(), delegate(List<PathVector> x)
	{
		x.Clear();
	});

	public WorkParticle EmitType = WorkParticle.None;

	public bool BladderFailCheck;

	public bool HungerFailCheck;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.Full)]
	public float TestVarStand;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.Full)]
	public float TestVarVehicle;

	[SaveField(0f)]
	public float CrunchHangover;

	[SaveField(0f)]
	public float ComplaintLevel;

	[SaveField(0f)]
	public float QuitLevel;

	[NonSerialized]
	[SaveField]
	private string[] _complaintReasons;

	private static float TeamRelationTimerMax = 30f;

	[SaveField(0)]
	private int TeamRelationNum;

	[SaveField(0f)]
	private float TeamRelationTimer;

	[NonSerialized]
	[SaveField(0f)]
	public float ChristmasBonus;

	[NonSerialized]
	public ScissorLift ActiveScissor;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public bool IsOnLift;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public Vector3 LiftStart;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public float LiftHeight;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public float LiftRot;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public bool UsedSubway;

	public int DummyCount;

	[SaveField]
	public bool BadBack;

	[SaveField]
	public bool QuitAmicably;

	[SaveField]
	public bool LeaveWhenDone;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public bool Biking;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, DefaultValue = 1f)]
	public float AirQuality = 1f;

	[NonSerialized]
	public bool DogBlessing;

	[NonSerialized]
	public LeadDesignDemands.Demand BreachedDemands;

	private InteractionPoint _usingPoint;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public ActorStateBehaviour.ActorEvent LastTrigger;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	private float _trashTimer;

	public HashSet<Furniture> Owns = new HashSet<Furniture>();

	private List<PathVector> _currentPath;

	public AudioSource AudioComp;

	public AudioClip[] KeyboardSFX;

	public AudioClip[] TalkSFX;

	public AudioClip[] FemaleTalkSFX;

	public BoxCollider[] Colliders;

	public AudioClip HammerHitSFX;

	public AudioClip[] FeetSFX;

	public SDateTime LastMeeting;

	public SDateTime MeetingTime;

	public SDateTime DriveTime;

	public SDateTime DespawnTime;

	public CarScript MyCar;

	public MeshRenderer VisibilityRenderer;

	public LODGroup LOD;

	public GameObject DataBall;

	public MeshRenderer DataBallRend;

	public Vector3 ActualPosition;

	[NonSerialized]
	public List<AutoDevWorkItem> AutoDevs = new List<AutoDevWorkItem>();

	[NonSerialized]
	private uint _targetActorID;

	[NonSerialized]
	private uint _guardingID;

	[NonSerialized]
	public Actor TargetActor;

	public int CarSpawnID;

	[NonSerialized]
	[SaveField(0f)]
	public float RetirementFund;

	[NonSerialized]
	public float LastCheckWait = -1f;

	public GameObject CensorRend;

	public Renderer[] LOD2UpperBody;

	public Renderer[] LOD2LowerBody;

	public Renderer[] LOD2Head;

	public Renderer[] LOD2Feet;

	public Renderer[] LOD2Hair;

	[NonSerialized]
	public SHashSet<string> AssignedRoomGroups = new SHashSet<string>();

	[NonSerialized]
	public ProductPrintOrder Order = new ProductPrintOrder();

	[NonSerialized]
	private ActorBodyItem _shadow;

	[SaveField(0)]
	public int Boxes;

	[SaveField(0)]
	public int BoxesShipped;

	[SaveField(0)]
	public int LastBoxesShipped;

	[SaveField(-1)]
	public int CarIdx = -1;

	[SaveField(0)]
	public int SickDays;

	public Color CarColor3;

	[SaveField(0)]
	public int CarWheelHubs;

	[SaveField(0, LoadFor = GameReader.NewLoadMode.Full)]
	public int CurrentPathNode;

	public SDateTime LeaveTime;

	public float PathProg;

	public float WalkSpeed = 2f;

	[SaveField]
	public float Timer = -1f;

	public float SocialFactor;

	public float StressFactor;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public bool BO;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.Full)]
	public float GermAdd;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.Full)]
	public float GermCount;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.Full)]
	public float Burnt;

	[SaveField(false)]
	public bool NegotiateSalary = true;

	[SaveField(false)]
	public bool IgnoreOffSalary;

	public SDateTime LastSocial;

	public Holdable coffee;

	public Holdable Food;

	public Vector3 LastWorldPos;

	[SaveField(0, LoadFor = GameReader.NewLoadMode.Full)]
	public int TargetFloor;

	[SaveField(true, LoadFor = GameReader.NewLoadMode.Full)]
	public bool HasMet = true;

	[SaveField(true, LoadFor = GameReader.NewLoadMode.Full)]
	public bool HasMetSub = true;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.Full)]
	public float MeetingDiff;

	[NonSerialized]
	private Employee _employee;

	[NonSerialized]
	private bool _isWalking;

	[SaveField(ElevatorState.None, LoadFor = GameReader.NewLoadMode.Full)]
	public ElevatorState EState;

	[NonSerialized]
	public ElevatorGroup QueuedForElevator;

	[NonSerialized]
	public HashSet<Room> InspectRooms;

	private GameObject HolidayItem;

	[NonSerialized]
	public List<InventoryItem> Stolen;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public SDateTime MentorCooldown;

	[NonSerialized]
	[SaveField]
	public bool IsMentor;

	[NonSerialized]
	[SaveField]
	public bool BeingMentored;

	private bool _allowHoliday = true;

	[NonSerialized]
	public float NightOwlDebuff;

	[NonSerialized]
	public bool WasSick;

	[NonSerialized]
	public SDateTime ForgetfulETA = new SDateTime(0);

	[NonSerialized]
	private Employee.Trait _traitView;

	[NonSerialized]
	private Color? _traitColor;

	[NonSerialized]
	private SDateTime _traitViewExp;

	[NonSerialized]
	[SaveField]
	public HashSet<Employee> HasInteractedWith = new HashSet<Employee>();

	[NonSerialized]
	public float LastWorkTime;

	private Furniture _reserved;

	private Furniture _onHead;

	public Transform NeckBone;

	public Transform LookBone;

	public Transform HeadBone;

	public Transform LeftHand;

	public Transform RightHand;

	public Transform EyePos;

	public SDateTime _vacationMonth;

	public SDateTime AlternateVacation;

	[SaveField(false, LoadFor = GameReader.NewLoadMode.Full)]
	public bool AtFurniture;

	public bool WaitSpawn = true;

	public bool WasOnScreen;

	[SaveField(true)]
	public bool Despawned = true;

	[SaveField(false, LoadFor = GameReader.NewLoadMode.Full)]
	public bool IsIdle;

	[SaveField(false, LoadFor = GameReader.NewLoadMode.Full)]
	public bool WagePaid;

	public WorkStatus IdleStatus;

	public Room CleaningRoom;

	[NonSerialized]
	public Deal deal;

	public Stack<Vector3> CleaningPoints = new Stack<Vector3>();

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full)]
	public Vector2 CurrentCleaningSpot = Vector2.zero;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.Full)]
	public float AvailableDirt;

	private string[] actions = new string[10] { "Dismiss", "Change Team", "Change Role", "Select Team", "Select Owned", "Change Salary", "Send home", "Details", "Pair Use", "Educate" };

	private string[] actionsFounder = new string[8] { "Change Team", "Change Role", "Select Team", "Select Owned", "Send home", "Details", "Pair Use", "Educate" };

	private string[] staffActions = new string[3] { "Dismiss", "Send home", "RoomPair" };

	public Animator anim;

	public Color SkinColor;

	public Color HairColor;

	[NonSerialized]
	public uint[] LastWorkItems = new uint[8];

	public int LastWorkCounter;

	public bool IsTalking;

	[SaveField(false, LoadFor = GameReader.NewLoadMode.Full)]
	public bool GoHomeNow;

	[SaveField(0, LoadFor = GameReader.NewLoadMode.Full)]
	public int StayHome;

	[SaveField(false)]
	public bool OnCall;

	[SaveField(false)]
	public bool HasFridged;

	public float NextParticle = 1f;

	public float NextSmell = 1f;

	public bool IsWorking;

	[SaveField(1f)]
	public float Effectiveness;

	public TableScript LoiterTable;

	[SaveField(8)]
	public int StaffOn = 8;

	[SaveField(16)]
	public int StaffOff = 12;

	public AI.AIType AItype;

	public AI AIScript;

	[NonSerialized]
	public Furniture ReservedFridge;

	[NonSerialized]
	public Furniture ReservedPort;

	[NonSerialized]
	public HashSet<Furniture> ReservedFurniture = new HashSet<Furniture>();

	[SaveField(HomeState.Default)]
	public HomeState SpecialState;

	[SaveField(0)]
	public int CurrentWorkItem;

	[SaveField(100)]
	public int SubWorkItem;

	[SaveField(1)]
	public int WorkCyclesLeft = 1;

	[SaveField(false, LoadFor = GameReader.NewLoadMode.Full)]
	public bool SecondaryWork;

	[SaveField(false, LoadFor = GameReader.NewLoadMode.Full)]
	public bool SecondaryTask;

	public bool Female;

	[NonSerialized]
	public List<KeyValuePair<Employee.EmployeeRole, string>> Courses = new List<KeyValuePair<Employee.EmployeeRole, string>>();

	public SDateTime LastCourse;

	[SaveField(false, LoadFor = GameReader.NewLoadMode.Full)]
	public bool Turn;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.Full)]
	public float TargetRot;

	public Holdable[] Holding = new Holdable[2];

	[NonSerialized]
	private HashSet<uint> _neighbours = new HashSet<uint>();

	[NonSerialized]
	public float NeighbourSocialBoost;

	[NonSerialized]
	public float[] Affactors;

	[NonSerialized]
	public Dictionary<string, InteractionPoint> InQueue = new Dictionary<string, InteractionPoint>();

	[NonSerialized]
	[SaveField]
	public float GuestPatience = 1f;

	private Room _currentRoom;

	public EyeScript Eyes;

	public List<Renderer> Children = new List<Renderer>();

	[NonSerialized]
	private List<ActorBodyItem> _bodyItems = new List<ActorBodyItem>();

	[SerializeField]
	private Transform _rootBone;

	[NonSerialized]
	private RoomSegment _guarding;

	private float _noisiness = 1f;

	private static readonly HashSet<uint> IteratedAssignedRooms = new HashSet<uint>();

	private static readonly List<string> DeletedAssignedRooms = new List<string>();

	private float teamComp = -1f;

	[SaveField(0, LoadFor = GameReader.NewLoadMode.Full)]
	public int LastAnim;

	[NonSerialized]
	private Team team;

	[NonSerialized]
	public bool OnDestroyWasCalled;

	[NonSerialized]
	private Vector3 LastPos;

	[NonSerialized]
	private bool _initialized;

	[NonSerialized]
	private Quaternion? _lastLookAt;

	[NonSerialized]
	private Quaternion? _rndLookAt;

	[NonSerialized]
	private int _lookAtIndex;

	[NonSerialized]
	private float _lookAtCountdown;

	private float _animRandomness;

	private int _currentBlend = -1;

	[NonSerialized]
	public bool LastVisible = true;

	[NonSerialized]
	public float UnusedMeters;

	public static bool UseSimOffset = true;

	public static float SimOffsetEffect = 0.5f;

	public static float SimOffsetSize = 0.35f;

	[NonSerialized]
	public Vector2 PosOffset;

	public static int FilterCheck = 0;

	private static SortedList<float, InteractionPoint> _furnResultCache = new SortedList<float, InteractionPoint>(new Utilities.DuplicateKeyComparer<float>());

	private static List<InteractionPoint> _furnfinalResultCache = new List<InteractionPoint>();

	private static InteractionPoint[] _furnPathCache = new InteractionPoint[1];

	private static HashSet<Room> _failPathIgnore = new HashSet<Room>();

	public float WaitingForQueue = -1f;

	public static Dictionary<Room.RoomLimits, HashSet<int>> ValidLimits = new Dictionary<Room.RoomLimits, HashSet<int>>
	{
		{
			Room.RoomLimits.Canteen,
			new HashSet<int> { -1, -3, -2 }
		},
		{
			Room.RoomLimits.Lounge,
			new HashSet<int> { -1, -2 }
		},
		{
			Room.RoomLimits.Meeting,
			new HashSet<int> { -1, -4 }
		}
	};

	public bool ShouldWork;

	private int _lastJobDiff = 1;

	private static Dictionary<string, float> _problemCache = new Dictionary<string, float>();

	[NonSerialized]
	private bool UpdateStateInfluence;

	[NonSerialized]
	[SaveField(SerializedAs = "CachedBenefits")]
	private Dictionary<string, float> _cachedBenefits = new Dictionary<string, float>();

	[NonSerialized]
	[SaveField("CachedBenefitValue", -1)]
	private float _cachedBenefitValue = -1f;

	public InteractionPoint UsingPoint
	{
		get
		{
			return _usingPoint;
		}
		set
		{
			if (_usingPoint != value)
			{
				OnHead = null;
				if (_usingPoint != null)
				{
					if (_usingPoint.Parent.OnWhenUsed && _usingPoint.Action == InteractionPoint.ActionType.Use)
					{
						_usingPoint.Parent.IsOn = false;
					}
					if (_usingPoint.Parent.MaxQueue > 0 && QueuedFor(_usingPoint.Parent.Type) && InQueue[_usingPoint.Parent.Type].Parent == _usingPoint.Parent)
					{
						InQueue.Remove(_usingPoint.Parent.Type);
						_usingPoint.RemoveFromQueue(this);
					}
					if (AItype == AI.AIType.Employee && _usingPoint.Parent.Type.Equals("Computer"))
					{
						ClearNeighbours();
					}
					_usingPoint.UsedBy = null;
				}
				if (value != null && value.Parent.MaxQueue > 0 && value.QueueLength == 0)
				{
					value.AddToQueue(this);
					InQueue[value.Parent.Type] = value;
				}
				_usingPoint = value;
				if (_usingPoint != null)
				{
					if (AtFurniture && _usingPoint.Parent.OnWhenUsed && _usingPoint.Action == InteractionPoint.ActionType.Use)
					{
						_usingPoint.Parent.IsOn = true;
					}
					_usingPoint.UsedBy = this;
					if (AItype == AI.AIType.Employee && _usingPoint.Parent.Type.Equals("Computer"))
					{
						SetNeighbours(UsingPoint.Parent.GetNeighbours());
					}
				}
			}
			if (_usingPoint == null && SpecialState == HomeState.Sleeping)
			{
				AIScript.currentNode = AIScript.BehaviorNodes["ShouldUseBed"];
				SpecialState = HomeState.Default;
				GoHomeNow = true;
			}
		}
	}

	public List<PathVector> CurrentPath
	{
		get
		{
			return _currentPath;
		}
	}

	public bool HasAssignedRooms
	{
		get
		{
			return AssignedRoomGroups.Count > 0;
		}
	}

	public bool TrappedInToilet
	{
		get
		{
			if (currentRoom.IsAliveNotNull())
			{
				return currentRoom.GetFurniture("Toilet").Count > 0;
			}
			return false;
		}
	}

	public Employee employee
	{
		get
		{
			return _employee;
		}
		set
		{
			if (_employee != null)
			{
				_employee.MyActor = null;
			}
			_employee = value;
			if (_employee != null)
			{
				_employee.MyActor = this;
			}
		}
	}

	public Furniture Reserved
	{
		get
		{
			return _reserved;
		}
		set
		{
			if (value != _reserved)
			{
				if (_reserved != null)
				{
					_reserved.Reserved = null;
				}
				_reserved = value;
				if (_reserved != null)
				{
					_reserved.Reserved = this;
				}
			}
		}
	}

	public Furniture OnHead
	{
		get
		{
			return _onHead;
		}
		set
		{
			if (_onHead != value && (value == null || value.OnHeadOf == null || value.OnHeadOf == this))
			{
				if (_onHead != null && _onHead.OnHeadOf == this)
				{
					_onHead.transform.SetParent(null);
					_onHead.transform.position = _onHead.OriginalOffset;
					_onHead.transform.rotation = Quaternion.Euler(_onHead.OriginalRotation);
					_onHead.transform.localScale = Vector3.one;
					_onHead.OnHeadOf = null;
				}
				_onHead = value;
				if (_onHead != null)
				{
					_onHead.OriginalOffset = _onHead.transform.position;
					_onHead.OriginalRotation = _onHead.transform.rotation.eulerAngles;
					_onHead.transform.SetParent(HeadBone);
					_onHead.transform.localPosition = _onHead.PCAddonOffset;
					_onHead.transform.localRotation = Quaternion.Euler(_onHead.PCAddonRotation);
					_onHead.OnHeadOf = this;
				}
			}
		}
	}

	public SDateTime VacationMonth
	{
		get
		{
			return _vacationMonth;
		}
		set
		{
			_vacationMonth = (AlternateVacation = value);
		}
	}

	public AnimationStates CurrentAnimState
	{
		get
		{
			return (AnimationStates)anim.GetInteger("AnimControl");
		}
	}

	public List<ActorBodyItem> BodyItems
	{
		get
		{
			return _bodyItems;
		}
		set
		{
			_bodyItems = value;
		}
	}

	public Transform RootBone
	{
		get
		{
			return _rootBone;
		}
		set
		{
			_rootBone = value;
		}
	}

	public Dictionary<string, Transform> Rig { get; set; }

	public bool UsesLOD1
	{
		get
		{
			return true;
		}
	}

	public bool NeedsDestruction
	{
		get
		{
			return false;
		}
	}

	public RoomSegment Guarding
	{
		get
		{
			return _guarding;
		}
		set
		{
			if (!(value == _guarding))
			{
				if (_guarding != null)
				{
					_guarding.GuardedBy.Remove(this);
				}
				_guarding = value;
				if (_guarding != null)
				{
					_guarding.LastGuarded = SDateTime.Now();
					_guarding.GuardedBy.Add(this);
				}
			}
		}
	}

	public float Noisiness
	{
		get
		{
			return _noisiness;
		}
		set
		{
			_noisiness = value;
		}
	}

	public int SpawnTime
	{
		get
		{
			if (IsEmployee())
			{
				if (Team != null)
				{
					return GetTeam().WorkStart;
				}
				return 8;
			}
			return StaffOn;
		}
	}

	public bool TakingCourses
	{
		get
		{
			return Courses.Count > 0;
		}
	}

	public int Floor
	{
		get
		{
			return Mathf.FloorToInt((ActualPosition.y + 1f) / 2f);
		}
	}

	public Room currentActualRoom
	{
		get
		{
			return _currentRoom;
		}
	}

	public Room currentRoom
	{
		get
		{
			if (!_currentRoom.IsAliveNotNull())
			{
				return GameSettings.Instance.sRoomManager.Outside;
			}
			return _currentRoom;
		}
		set
		{
			if (!(value != _currentRoom))
			{
				return;
			}
			LastWorldPos = ActualPosition;
			if (_currentRoom.IsAliveNotNull())
			{
				_currentRoom.RemoveOccupant(this);
				GermCount = Mathf.Max(_currentRoom.GermCount, GermCount);
			}
			_currentRoom = value;
			if (_currentRoom.IsAliveNotNull())
			{
				_currentRoom.AddOccupant(this);
				GermCount = Mathf.Max(_currentRoom.GermCount, GermCount);
			}
			if (AItype != AI.AIType.Burglar || GameSettings.Instance.IsReferenceNull())
			{
				return;
			}
			BurglarSecurityCheck();
			if (!value.IsAliveNotNull() || value.Outside)
			{
				return;
			}
			for (int i = 0; i < value.Occupants.Count; i++)
			{
				Actor actor = value.Occupants[i];
				if (actor.AItype == AI.AIType.Employee)
				{
					actor.PanicBurglar();
				}
			}
		}
	}

	public float TeamCompatibility
	{
		get
		{
			if (Team == null)
			{
				return -1f;
			}
			return teamComp;
		}
		set
		{
			teamComp = value;
		}
	}

	public string Team
	{
		get
		{
			Team obj = team;
			if (obj == null)
			{
				return null;
			}
			return obj.Name;
		}
		set
		{
			if (!IsEmployee())
			{
				return;
			}
			Team obj = this.team;
			if (obj != null)
			{
				obj.RemoveEmployee(this, false);
			}
			if (string.IsNullOrEmpty(value))
			{
				this.team = null;
				if (employee.IsRole(Employee.RoleBit.Lead))
				{
					employee.ChangeToNaturalRole(false);
				}
			}
			else
			{
				Team team = GetTeam();
				Team team2 = GameSettings.GetTeam(value);
				if (team2 != null)
				{
					this.team = team2;
					this.team.AddEmployee(this, false);
					ScheduleVacation(false);
					if (team == null || team.WorkStart != team2.WorkStart)
					{
						SDateTime? arriveTime = GameSettings.Instance.sActorManager.GetArriveTime(this);
						if (arriveTime.HasValue)
						{
							SDateTime value2 = arriveTime.Value;
							int num = ((team != null) ? (value2.Hour - team.WorkStart) : (-1));
							SDateTime sDateTime = value2.ChangeHour(team2.WorkStart + num);
							if (sDateTime < SDateTime.Now())
							{
								sDateTime += ((GameSettings.DaysPerMonth > 1) ? SDateTime.GetDay(1) : SDateTime.GetMonth(1));
							}
							GameSettings.Instance.sActorManager.AddToAwaiting(this, sDateTime, true);
						}
					}
				}
				else
				{
					this.team = null;
				}
				if (UsingPoint != null && AtFurniture && "Computer".Equals(UsingPoint.Parent.Type))
				{
					UsingPoint.Parent.CheckUserCanUseInRoom();
				}
			}
			if (HUD.Instance != null)
			{
				(from x in GameSettings.Instance.MyCompany.WorkItems.OfType<DesignDocument>()
					where x.LeadDesigner == employee
					select x).ForEachEnum(delegate(DesignDocument x)
				{
					x.DevTeamChange();
				});
				CalendarWindow.ScheduleRefresh = true;
				if (HUD.Instance.employeeWindow != null && HUD.Instance.employeeWindow.EmployeeList != null)
				{
					HUD.Instance.employeeWindow.UpdateEmployeeList();
				}
			}
			ApplyNewBenefits();
		}
	}

	public bool IsValid
	{
		get
		{
			return this.IsAliveNotNull();
		}
	}

	public bool IsInitialized
	{
		get
		{
			return _initialized;
		}
	}

	public void InteractWith(Actor other)
	{
		if (other.DID == DID || HasInteractedWith.Contains(other.employee))
		{
			return;
		}
		if (other.DID < DID)
		{
			other.InteractWith(this);
			return;
		}
		if ((!employee.InteractedWithBestFriend || !other.employee.InteractedWithBestFriend) && Employee.GetFriendship(employee, other.employee) >= 2f)
		{
			employee.InteractedWithBestFriend = (other.employee.InteractedWithBestFriend = true);
		}
		HasInteractedWith.Add(other.employee);
		other.HasInteractedWith.Add(employee);
	}

	public void SetTraitView(Employee.Trait t, int hours, int minutes = 0, bool overwrite = false, Color? color = null)
	{
		if (overwrite || _traitView == Employee.Trait.None || _traitView == t)
		{
			_traitView = t;
			_traitColor = color;
			_traitViewExp = SDateTime.Now() + new SDateTime(minutes, hours, 0, 0, 0);
		}
	}

	private void SetHeadDeserialize(Furniture furn)
	{
		if (furn != null)
		{
			_onHead = furn;
			_onHead.transform.SetParent(HeadBone);
			_onHead.transform.localPosition = _onHead.PCAddonOffset;
			_onHead.transform.localRotation = Quaternion.Euler(_onHead.PCAddonRotation);
			_onHead.OnHeadOf = this;
		}
	}

	private bool CheckOnHead(Furniture furn)
	{
		if (furn.OnHead)
		{
			OnHead = furn;
			return true;
		}
		for (int i = 0; i < furn.SnapPoints.Length; i++)
		{
			Furniture mainUsedBy = furn.SnapPoints[i].MainUsedBy;
			if (mainUsedBy != null && CheckOnHead(mainUsedBy))
			{
				return true;
			}
		}
		return false;
	}

	public void CheckMeeting(bool sub = false)
	{
		bool flag = (sub ? HasMetSub : HasMet);
		if (!IsEmployee() || flag)
		{
			return;
		}
		SDateTime sDateTime = SDateTime.Now();
		float hours = SDateTime.GetHours(DriveTime, sDateTime);
		if (!HasMetSub)
		{
			if (hours >= 3f)
			{
				employee.SetMood("LongCommute", this, Mathf.Pow(hours.MapRange(2.5f, 4f, 0f, 1f, true), 2f));
			}
			else
			{
				employee.DecreaseMood("LongCommute", this, 1f);
			}
		}
		HasMetSub = true;
		if (!sub)
		{
			HasMet = true;
			MeetingTime = sDateTime;
			MeetingDiff = Mathf.Clamp(hours, -4f, 4f);
			AdjustLeaveTime();
		}
	}

	public Transform GetTransform()
	{
		return base.transform;
	}

	public void UpdateEyes()
	{
		ActorBodyItem actorBodyItem = _bodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
		if (actorBodyItem != null)
		{
			Eyes.Face = actorBodyItem.rend.material;
		}
	}

	public static int GetStaffHours(AI.AIType type)
	{
		if (type != AI.AIType.Security)
		{
			return 4;
		}
		return 8;
	}

	public int GetStaffHours()
	{
		return GetStaffHours(AItype);
	}

	public void UpdateHairColor(Color col)
	{
		HairColor = col;
	}

	public void UpdateSkinColor(Color col)
	{
		SkinColor = col;
	}

	public void ClearPath(bool fixPosition = true)
	{
		if (CurrentPath != null)
		{
			EState = ElevatorState.None;
			if (QueuedForElevator != null)
			{
				QueuedForElevator.Remove(this);
			}
			QueuedForElevator = null;
			PathPool.Release(CurrentPath);
			_currentPath = null;
			if (fixPosition)
			{
				UpdateCurrentRoom(true);
				currentRoom.FixActorPosition(this, false);
			}
		}
	}

	public bool IsAssignedRoom(Room r)
	{
		if (AssignedRoomGroups.Count > 0)
		{
			foreach (string assignedRoomGroup in AssignedRoomGroups)
			{
				RoomGroup roomGroup = GameSettings.Instance.GetRoomGroup(assignedRoomGroup);
				if (roomGroup == null)
				{
					continue;
				}
				List<Room> rooms = roomGroup.GetRooms();
				for (int i = 0; i < rooms.Count; i++)
				{
					if (r == rooms[i])
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public void SetNeighbours(IList<Actor> acs)
	{
		NeighbourSocialBoost = 0f;
		HashSet<uint> hashSet = ((_neighbours.Count > 0) ? _neighbours.ToHashSet() : null);
		for (int i = 0; i < acs.Count; i++)
		{
			Actor actor = acs[i];
			if (_neighbours.Add(actor.DID))
			{
				float num = employee.Compatibility(actor.employee);
				NeighbourSocialBoost = Mathf.Max(NeighbourSocialBoost, num);
				actor.AddNeighbour(this, num);
			}
			if (hashSet != null)
			{
				hashSet.Remove(actor.DID);
			}
		}
		if (hashSet == null || hashSet.Count <= 0)
		{
			return;
		}
		foreach (uint item in hashSet)
		{
			_neighbours.Remove(item);
		}
	}

	public void AddNeighbour(Actor ac)
	{
		if (_neighbours.Add(ac.DID))
		{
			InteractWith(ac);
			NeighbourSocialBoost = Mathf.Max(NeighbourSocialBoost, employee.Compatibility(ac.employee));
		}
	}

	public IEnumerable<Actor> GetNeighbours()
	{
		for (int i = 0; i < GameSettings.Instance.sActorManager.Actors.Count; i++)
		{
			Actor actor = GameSettings.Instance.sActorManager.Actors[i];
			if (_neighbours.Contains(actor.DID))
			{
				yield return actor;
			}
		}
	}

	public void AddNeighbour(Actor ac, float comp)
	{
		if (_neighbours.Add(ac.DID))
		{
			InteractWith(ac);
			NeighbourSocialBoost = Mathf.Max(NeighbourSocialBoost, comp);
		}
	}

	public void RemoveNeighbour(uint id)
	{
		if (_neighbours.Remove(id))
		{
			UpdateNeighbourBoost();
		}
	}

	public void ClearNeighbours()
	{
		NeighbourSocialBoost = 0f;
		foreach (uint neighbour2 in _neighbours)
		{
			uint neighbour1 = neighbour2;
			Actor actor = GameSettings.Instance.sActorManager.Actors.FirstOrDefault((Actor x) => x.DID == neighbour1);
			if (actor != null)
			{
				actor.RemoveNeighbour(DID);
			}
		}
		_neighbours.Clear();
	}

	public void UpdateNeighbourBoost()
	{
		NeighbourSocialBoost = 0f;
		foreach (uint neighbour in _neighbours)
		{
			Actor actor = GameSettings.Instance.sActorManager.Actors.FirstOrDefault((Actor x) => x.DID == neighbour);
			if (actor != null)
			{
				NeighbourSocialBoost = Mathf.Max(NeighbourSocialBoost, employee.Compatibility(actor.employee));
			}
		}
	}

	public IEnumerable<Room> GetAssignedRooms()
	{
		bool any = !HasAssignedRooms;
		IteratedAssignedRooms.Clear();
		DeletedAssignedRooms.Clear();
		foreach (string assignedRoomGroup in AssignedRoomGroups)
		{
			RoomGroup roomGroup = GameSettings.Instance.GetRoomGroup(assignedRoomGroup);
			if (roomGroup != null)
			{
				List<Room> rs = roomGroup.GetRooms();
				for (int i = 0; i < rs.Count; i++)
				{
					if (!IteratedAssignedRooms.Contains(rs[i].DID))
					{
						any = true;
						yield return rs[i];
						IteratedAssignedRooms.Add(rs[i].DID);
					}
				}
			}
			else
			{
				DeletedAssignedRooms.Add(assignedRoomGroup);
			}
		}
		if (!any && !NotificationManager.CheckAggregate<RoomAssignIssueNotification>(this))
		{
			NotificationManager.AddNotification(new RoomAssignIssueNotification(this));
		}
		for (int j = 0; j < DeletedAssignedRooms.Count; j++)
		{
			AssignedRoomGroups.Remove(DeletedAssignedRooms[j]);
		}
	}

	public bool AreRoomsAssignedEmpty()
	{
		if (HasAssignedRooms)
		{
			bool flag = false;
			foreach (string assignedRoomGroup in AssignedRoomGroups)
			{
				RoomGroup roomGroup = GameSettings.Instance.GetRoomGroup(assignedRoomGroup);
				if (roomGroup != null && roomGroup.GetRooms().Count > 0)
				{
					flag = true;
					break;
				}
			}
			return !flag;
		}
		return false;
	}

	private void BurglarSecurityCheck()
	{
		if (AIScript.HasFlag(AI.NodeFlag.GoingHome))
		{
			return;
		}
		Room room = currentRoom;
		for (int i = 0; i < room.Occupants.Count; i++)
		{
			Actor actor = room.Occupants[i];
			if (actor.AItype == AI.AIType.Security && (actor.ActualPosition - ActualPosition).sqrMagnitude < 25f)
			{
				Timer = -1f;
				ClearPath();
				AIScript.currentNode = actor.AIScript.BehaviorNodes["ShouldUseBus"];
			}
		}
	}

	public void SetTeamDeserialize(Team newTeam)
	{
		team = newTeam;
	}

	public void TeamRename(Team newTeam)
	{
		Team obj = team;
		if (obj != null)
		{
			obj.RemoveEmployee(this, true);
		}
		team = newTeam;
		team.AddEmployee(this, true);
		if (HUD.Instance != null)
		{
			CalendarWindow.ScheduleRefresh = true;
		}
	}

	public Team GetTeam()
	{
		return team;
	}

	public override string[] GetActions()
	{
		if (IsEmployee())
		{
			if (!employee.Founder)
			{
				return actions;
			}
			return actionsFounder;
		}
		if (AI.IsStaff(AItype))
		{
			return staffActions;
		}
		return new string[0];
	}

	public void SetCar(int carIdx)
	{
		if (CarIdx != carIdx)
		{
			CarIdx = carIdx;
			NormalCar component = ObjectDatabase.Instance.CarPrefabs[CarIdx].GetComponent<NormalCar>();
			CarWheelHubs = component.Car.ValidWheelHubs.GetRandom();
			if (AItype == AI.AIType.Burglar)
			{
				CarColor3 = Color.black;
			}
			else if (AItype == AI.AIType.Police)
			{
				CarColor3 = new Color(0.3f, 0.3f, 0.3f, 1f);
			}
			else
			{
				CarColor3 = component.Colors.GetRandom();
			}
		}
	}

	public string LimitText(float value, float limit)
	{
		value = ((!(value > limit)) ? (value / limit) : 1f);
		return (value * 100f).ToString("F0");
	}

	public override string GetInfo()
	{
		if (IsEmployee())
		{
			return new StringBuilder(string.Format("{0} - {1}{2}\n{4}: {3}\n{5}", employee.FullName, employee.RoleString, employee.Founder ? (" - " + (employee.MadeCEO ? "CEO".Loc() : "Founder".Loc())) : "", CurrentState(true), "State".Loc(), IsIdle ? ("NotWorkingState".Loc() + ": " + IdleStatus.ToString().Loc()) : ((SecondaryWork && IsWorking) ? "WorkingSecondary".Loc() : ""))).ToString();
		}
		if (AItype == AI.AIType.Guest)
		{
			if (deal == null || !deal.StillValid(false))
			{
				return employee.Name;
			}
			return string.Format("GuestCompany".Loc(), employee.Name, (employee.MyEmployer != null) ? employee.MyEmployer.Name : "");
		}
		if (AI.IsStaff(AItype))
		{
			if (OnCall)
			{
				return string.Format("{0}\n{2}: {1}", employee.Name, CurrentState(true), "State".Loc());
			}
			return string.Format("{0} ({3})\n{2}: {1}", employee.Name, CurrentState(true), "State".Loc(), Utilities.HourToTime(StaffOn, SDateTime.AMPM));
		}
		if (AItype == AI.AIType.FireInspector)
		{
			return "TimeDiffLeft".Loc("Room".LocPlural(InspectRooms.Count));
		}
		return "";
	}

	public bool QueuedFor(string type)
	{
		return InQueue.ContainsKey(type);
	}

	public bool IsUp(string type)
	{
		return InQueue[type].IsUp(this);
	}

	public override string[] GetExtendedInfo()
	{
		if (!IsEmployee())
		{
			return new string[1] { AItype.ToString().Loc() };
		}
		return new string[5]
		{
			string.IsNullOrEmpty(Team) ? "Unassigned".Loc() : Team,
			"Year".LocPlural(employee.GetAgeFlat()),
			GetMonthlySalary().Currency(),
			(Effectiveness * 100f).ToString("F2") + "%",
			(employee.JobSatisfaction * 100f).ToString("F2") + "%"
		};
	}

	public override Color[] GetExtendedColorInfo()
	{
		return new Color[4]
		{
			GetColorStat(1f),
			GetColorStat(1f),
			GetColorStat(Effectiveness),
			GetColorStat(employee.JobSatisfaction * 2f)
		};
	}

	public override string[] GetExtendedIconInfo()
	{
		if (!IsEmployee())
		{
			if (!AI.IsStaff(AItype))
			{
				return new string[1] { "Employee" };
			}
			return new string[1] { "Staff" };
		}
		return new string[5] { "MoreEmployees", "Employee", "Money", "Cogs", "Smiley" };
	}

	public override string[] GetExtendedTooltipInfo()
	{
		if (IsEmployee())
		{
			return new string[4]
			{
				"Age".Loc(),
				"Salary".Loc(),
				"Effectiveness".Loc(),
				"Satisfaction".Loc()
			};
		}
		return null;
	}

	public override IEnumerable<Selectable> GetRelated()
	{
		if (IsEmployee())
		{
			if (Owns == null)
			{
				yield break;
			}
			foreach (Furniture own in Owns)
			{
				yield return own;
			}
		}
		else
		{
			if (!AI.IsStaff(AItype))
			{
				yield break;
			}
			foreach (Room assignedRoom in GetAssignedRooms())
			{
				yield return assignedRoom;
			}
		}
	}

	public void MeetNow()
	{
		Init();
		if (AItype == AI.AIType.Employee)
		{
			employee.DecreaseMood("LongCommute", this, 1f);
		}
		if (HolidayItem != null)
		{
			Children.Remove(HolidayItem.GetComponent<Renderer>());
			UnityEngine.Object.Destroy(HolidayItem);
			HolidayItem = null;
		}
		else if (_allowHoliday && DateTime.Now.Month == 12 && SDateTime.Now().Month == 11 && UnityEngine.Random.value < 0.33f)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(ItemDispenser.Instance.HolidayItems[0]);
			Vector3 position = gameObject.transform.position;
			Quaternion rotation = gameObject.transform.rotation;
			Vector3 localScale = gameObject.transform.localScale;
			gameObject.transform.SetParent(HeadBone);
			gameObject.transform.localPosition = position;
			gameObject.transform.localRotation = rotation;
			gameObject.transform.localScale = localScale;
			HolidayItem = gameObject;
			Children.Add(HolidayItem.GetComponent<Renderer>());
		}
		TestVarStand = 0f;
		AirQuality = 1f;
		LastBoxesShipped = BoxesShipped;
		BoxesShipped = 0;
		LastWorldPos = ActualPosition;
		WagePaid = false;
		Timer = -1f;
		employee.Energy = 1f;
		employee.Stress = Mathf.Clamp01(employee.Stress + SDateTime.GetHours(DespawnTime, SDateTime.Now()) / 24f * StressRelief);
		ComplaintLevel *= 0.75f.SpreadPercentage(GameSettings.DaysPerMonth);
		QuitLevel *= 0.9f.SpreadPercentage(GameSettings.DaysPerMonth);
		if (ComplaintLevel < 1f)
		{
			_complaintReasons = null;
		}
		BadBack = false;
		if (AItype == AI.AIType.Employee)
		{
			employee.SkipMood(SDateTime.GetDays(MeetingTime, SDateTime.Now()) * 24f * 60f);
			if (employee.Posture < 0.75f && UnityEngine.Random.value > employee.Posture)
			{
				BadBack = true;
			}
		}
		if (!IsCrunching() && CrunchHangover > 0f)
		{
			CrunchHangover = Mathf.Max(0f, CrunchHangover - SDateTime.GetMonths(MeetingTime, SDateTime.Now()) * 24f);
		}
		MeetingTime = SDateTime.Now();
		HasMet = false;
		HasMetSub = false;
		AdjustLeaveTime();
		anim.enabled = true;
		GoHomeNow = false;
		UsedSubway = false;
		for (int i = 0; i < Affactors.Length; i++)
		{
			Affactors[i] = -2f;
		}
		AIScript.currentNode = AIScript.BehaviorNodes["Spawn"];
		if (AItype == AI.AIType.Burglar && !NotificationManager.CheckAggregate<BurglarPresentNotification>(this))
		{
			NotificationManager.AddNotification(new BurglarPresentNotification(this));
			WindowManager.Instance.ShowMessageBox("BurglarWarning".Loc(), true, DialogWindow.DialogType.Warning, new KeyValuePair<string, Action>("Follow", delegate
			{
				if (this != null)
				{
					CameraScript.Instance.Follow = base.transform;
					GameSettings.GameSpeed = 1f;
				}
			}), new KeyValuePair<string, Action>("Ignore", delegate
			{
			}));
		}
		BO = AItype == AI.AIType.Employee && MyCar != null && MyCar.IsBike && UnityEngine.Random.value > 0.5f;
		float age = employee.GetAge();
		if (age >= ActorGenerator.AgeWeightStart)
		{
			ActorBodyItem actorBodyItem = BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
			if ((object)actorBodyItem != null)
			{
				actorBodyItem.SetBlendValue("Age", ActorGenerator.GetAgeWeight(age) * 100f);
			}
			ActorGenerator.SetStyleAge(employee.StyleGen, age);
		}
	}

	public void AdjustLeaveTime()
	{
		int workHours = GetWorkHours();
		float f = UnityEngine.Random.Range(-30f, -15f);
		LeaveTime = MeetingTime + new SDateTime(Mathf.RoundToInt(f), workHours, 0, 0, 0);
	}

	public string CurrentState(bool withDetail)
	{
		if (this == null)
		{
			return "";
		}
		if (SpecialState == HomeState.Sleeping)
		{
			return "Sleeping".Loc();
		}
		if (Biking)
		{
			return "Cycling".Loc();
		}
		SDateTime sDateTime = SDateTime.Now();
		if (!base.enabled && sDateTime.Month == 5 && sDateTime.Day == 0 && GameSettings.Instance.ConferenceController.IsInBooth(employee))
		{
			return "Convention".Loc();
		}
		if (!base.enabled && TakingCourses && (SpecialState != HomeState.Vacation || !VacationMonth.EqualsVerySimple(SDateTime.Now())))
		{
			if (withDetail)
			{
				SDateTime? arriveTime = GameSettings.Instance.sActorManager.GetArriveTime(this);
				if (arriveTime.HasValue)
				{
					return string.Format("{0}\n{1}", "Inclass".Loc(), "ReturnDate".Loc(SDateTime.DateDiff(SDateTime.Now(), arriveTime.Value)));
				}
			}
			return "Inclass".Loc();
		}
		if (SpecialState == HomeState.Vacation && withDetail)
		{
			SDateTime? arriveTime2 = GameSettings.Instance.sActorManager.GetArriveTime(this);
			if (arriveTime2.HasValue)
			{
				return string.Format("{0}\n{1}", SpecialState.ToString().Loc(), "ReturnDate".Loc(SDateTime.DateDiff(SDateTime.Now(), arriveTime2.Value)));
			}
		}
		string text = ((withDetail && base.enabled) ? (" (" + AIScript.CurrentNodeLabel.Loc() + ")") : "");
		if (SpecialState != HomeState.Default)
		{
			return SpecialState.ToString().Loc() + text;
		}
		if (employee.Dismissed)
		{
			return "Dismissed".Loc() + text;
		}
		if (base.enabled)
		{
			return "Atwork".Loc() + text;
		}
		return "Athome".Loc();
	}

	public void OnDestroy()
	{
		if (OnDestroyWasCalled || GameSettings.Instance.IsReferenceNull() || ErrorLogging.SceneChanging)
		{
			return;
		}
		GameSettings.Instance.ActorGrid.Remove(this);
		OnDestroyWasCalled = true;
		if (AItype == AI.AIType.Employee && employee != null)
		{
			employee.CleanUp();
			if (!employee.Retired && (employee.MyEmployer == null || employee.MyEmployer == GameSettings.Instance.MyCompany) && employee.CreativityKnown >= 1f && employee.Creativity >= 0.85f)
			{
				employee.PlayerQuarantine = null;
				MarketSimulation.Active.FreeLeads.Add(employee);
				NetworkMessaging.MoveLeadDesigner(employee, null, true, true);
				employee.PlayerQuarantine = SDateTime.Now() + ((QuitLevel > 3f) ? 60 : 6);
			}
			else if (employee.NetworkID != 0)
			{
				NetworkMessaging.MoveLeadDesigner(employee, null, false, false);
			}
			GameSettings.Instance.sActorManager.UpdateActorWindow();
		}
		if (IsEmployee())
		{
			GlobalSearchPanel.Instance.RemoveSearchItem(this);
		}
		if (AItype == AI.AIType.Robot)
		{
			Furniture value;
			if (GetDLCData<Furniture>("ChargingStation", out value) && value != null)
			{
				value.RemoveDLCData("ChargingUse");
				value.InteractEnd();
				value.IsOn = false;
			}
			IStockable value2;
			if (GetDLCData<IStockable>("Robot", out value2))
			{
				value2.PhysicalCopies--;
			}
		}
		ClearNeighbours();
		currentRoom = null;
		ProductPrintOrder order = Order;
		if (order != null)
		{
			order.RemoveFromStorage();
		}
		GameSettings.Instance.sRoomManager.ClearReservations(this);
		GameSettings.Instance.RegisterActor(this, false);
		if (HUD.Instance != null)
		{
			HUD.Instance.Portraits.DestroyActorTex(this);
			NotificationManager.RemoveAggregate<StuckNotification>(this);
			HUD.Instance.CantGetHome.Remove(this);
			HUD.Instance.wageWindow.List.Items.Remove(this);
			HUD.Instance.RemoveFromIdle(this);
			HUD.Instance.complaintWindow.ClearActor(this);
			CalendarWindow.ScheduleRefresh = true;
			if (HUD.Instance.DetailWindow.CurrentEmployee == this)
			{
				HUD.Instance.DetailWindow.Window.Close();
			}
			if (HUD.Instance.docWindow.Window.Shown && HUD.Instance.docWindow.LeadDesigner.CurrentEmployee == employee)
			{
				HUD.Instance.docWindow.PickBestLead(true);
			}
		}
		for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
		{
			GameSettings.Instance.sRoomManager.Rooms[i].RemoveOccupant(this);
		}
		for (int j = 0; j < Holding.Length; j++)
		{
			if (Holding[j] != null)
			{
				Holding[j].DestroyMe();
			}
		}
		if (UsingPoint != null && UsingPoint.UsedBy == this)
		{
			UsingPoint.UsedBy = null;
		}
		if (ReservedFridge != null)
		{
			ReservedFridge.SubtractUnit();
		}
		Owns.ToList().ForEach(delegate(Furniture x)
		{
			if (x != null && x.OwnedBy == this)
			{
				x.OwnedBy = null;
			}
		});
		if (Team != null)
		{
			Team obj = GetTeam();
			team = null;
			obj.RemoveEmployee(this, false);
		}
		if (AItype == AI.AIType.Burglar)
		{
			NotificationManager.RemoveAggregate<BurglarPresentNotification>(this);
		}
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.Instance.sActorManager.Others.Values.ForEachEnum(delegate(HashSet<Actor> x)
			{
				x.Remove(this);
			});
			GameSettings.Instance.sActorManager.Actors.Remove(this);
			GameSettings.Instance.sActorManager.Staff.Remove(this);
			GameSettings.Instance.sActorManager.RemoveFromAwaiting(this);
			GameSettings.Instance.sActorManager.ReadyForBus.Remove(this);
			GameSettings.Instance.sActorManager.ReadyForHome.Remove(this);
		}
		if (SelectorController.Instance != null && SelectorController.Instance.Selected.Contains(this))
		{
			SelectorController.Instance.ToggleRightClickMenu(false);
			SelectorController.Instance.Selected.Remove(this);
		}
	}

	protected override void UpdateOnHighlight()
	{
		UpdateShadowVisibility();
	}

	private void UpdateShadowVisibility()
	{
		Room room = currentRoom;
		bool flag = room == null || room.Outside || room.Outdoors;
		_shadow.gameObject.SetActive(flag || base.IsSelected || IsHover);
		_shadow.rend.shadowCastingMode = (flag ? ShadowCastingMode.On : ShadowCastingMode.Off);
	}

	public void UpdateCurrentRoom(bool force = false)
	{
		Vector3 vector = ActualPosition;
		if ((LastPos != vector || force) && (currentRoom.Dummy || currentRoom.Floor != Floor || currentRoom.Pillar || !currentRoom.IsInside(vector.FlattenVector3(), 0f)))
		{
			if (IsOnSkyRoad() || IsOnSubway())
			{
				currentRoom = GameSettings.Instance.sRoomManager.Outside;
				UpdateShadowVisibility();
			}
			else
			{
				Room room = GameSettings.Instance.sRoomManager.GetRoomFromPoint(vector);
				int i = 0;
				bool flag = false;
				int num = Mathf.FloorToInt((vector.y + 1f) / 2f);
				for (; (room == null || room.Pillar || (i > 0 && room.IsUpperAtrium)) && i < 40; i++)
				{
					if (num == 0)
					{
						break;
					}
					flag = true;
					if (num > 0)
					{
						num--;
					}
					if (num < 0)
					{
						num++;
					}
					vector = new Vector3(vector.x, (float)num * 2f, vector.z);
					room = GameSettings.Instance.sRoomManager.GetRoomFromPoint(vector);
				}
				if (room.IsAliveNotNull() && room.Pillar)
				{
					Vector3? validPointNear = GameSettings.Instance.sRoomManager.Outside.GetValidPointNear(vector, 0f);
					if (validPointNear.HasValue)
					{
						vector = validPointNear.Value;
						room = GameSettings.Instance.sRoomManager.Outside;
						flag = true;
					}
				}
				if (flag)
				{
					IsOnLift = false;
					if (ActiveScissor != null)
					{
						ActiveScissor.Release();
						ActiveScissor = null;
					}
					ActualPosition = vector;
				}
				currentRoom = room;
				UpdateShadowVisibility();
			}
			LastPos = vector;
		}
		if (HUD.Instance != null)
		{
			AudioComp.outputAudioMixerGroup = ((GameSettings.Instance.sRoomManager.CameraRoom == currentRoom) ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
		}
	}

	public bool IsOnSkyRoad()
	{
		int floor = Floor;
		if (floor > 0 && floor <= RoadManager.Floors * 2)
		{
			byte road = RoadManager.Instance.GetRoad(ActualPosition.FlattenVector3(), Mathf.Max(0, floor / 2));
			if (floor % 2 == 1 && (road < 4 || road > 7))
			{
				return false;
			}
			if (road > 0)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsOnSubway()
	{
		if (GameSettings.Instance.HasSubway && ActualPosition.y < 0.5f)
		{
			return GameSettings.Instance.ActiveSubway.GetArea().Contains(ActualPosition.FlattenVector3());
		}
		return false;
	}

	public bool IsOnRoad()
	{
		int floor = Floor;
		if (floor >= 0)
		{
			return RoadManager.Instance.GetRoad(ActualPosition.FlattenVector3(), floor / 2) > 0;
		}
		return false;
	}

	public void ResetState()
	{
		WaitingForQueue = -1f;
		IsOnLift = false;
		if (ActiveScissor != null)
		{
			ActiveScissor.Release();
			ActiveScissor = null;
		}
		ClearPath();
		Timer = -1f;
		SetAnim(AnimationStates.Idle);
		anim.Play("Idle", 0, 0f);
		UsingPoint = null;
		AtFurniture = false;
		ClearLoiterTable();
		CleanUpEating();
		switch (AItype)
		{
		case AI.AIType.Employee:
		case AI.AIType.Robot:
			AIScript.currentNode = AIScript.BehaviorNodes["CanWork"];
			break;
		case AI.AIType.Janitor:
		case AI.AIType.IT:
			AIScript.currentNode = AIScript.BehaviorNodes["FindRepair"];
			break;
		case AI.AIType.Courier:
			AIScript.currentNode = AIScript.BehaviorNodes["HasCopies"];
			break;
		case AI.AIType.Cleaning:
			AIScript.currentNode = AIScript.BehaviorNodes["FindCleanRoom"];
			break;
		case AI.AIType.Receptionist:
		case AI.AIType.Guest:
		case AI.AIType.Burglar:
		case AI.AIType.Security:
			AIScript.currentNode = AIScript.BehaviorNodes["IsOff"];
			break;
		case AI.AIType.Cook:
			AIScript.currentNode = AIScript.BehaviorNodes["CanCook"];
			break;
		case AI.AIType.Police:
			AIScript.currentNode = AIScript.BehaviorNodes["FindBurglar"];
			break;
		case AI.AIType.FireInspector:
			AIScript.currentNode = AIScript.BehaviorNodes["GotoNextRoom"];
			break;
		case AI.AIType.FireFighter:
			AIScript.currentNode = AIScript.BehaviorNodes["FightFires"];
			break;
		case AI.AIType.Parent:
			AIScript.currentNode = AIScript.BehaviorNodes["Loiter"];
			break;
		}
		if (!IsOnSkyRoad())
		{
			ActualPosition = new Vector3(ActualPosition.x, Floor * 2, ActualPosition.z);
		}
		UpdateCurrentRoom(true);
		currentRoom.FixActorPosition(this, false);
	}

	public void FleeNow(bool panic = true)
	{
		ClearPath();
		if (AItype != AI.AIType.Robot && panic)
		{
			Timer = UnityEngine.Random.Range(1f, 5f);
			SetAnim(AnimationStates.Panic);
		}
		else
		{
			Timer = 0f;
		}
		UsingPoint = null;
		ClearLoiterTable();
		CleanUpEating();
		AtFurniture = false;
		AIScript.currentNode = AIScript.BehaviorNodes["Flee"];
	}

	public void PanicBurglar()
	{
		employee.AddInstantMood("BurglarScared", this);
		ClearPath();
		Timer = -1f;
		UsingPoint = null;
		ClearLoiterTable();
		AtFurniture = false;
		AIScript.currentNode = AIScript.BehaviorNodes["BurglarPanic"];
		GameSettings.Instance.SpawnPolice(false);
		NotificationManager.AddNotification("EmployeeCallCop".Loc(), "Burglar", NotificationManager.NotificationType.Neutral, UniqueNotification.MessageID.CallCops);
	}

	public void RunToBurglar(Actor burg)
	{
		ClearPath();
		Timer = -1f;
		if (PathToPoint(burg.ActualPosition, true))
		{
			UsingPoint = null;
			ClearLoiterTable();
			AtFurniture = false;
			AIScript.currentNode = AIScript.BehaviorNodes["RunToBurglar"];
		}
		else
		{
			AIScript.currentNode = AIScript.BehaviorNodes["ValidateEntrance"];
		}
	}

	public void Arrest(bool goNow, CarScript targetCar)
	{
		if (AItype != AI.AIType.Burglar)
		{
			return;
		}
		ClearPath();
		Timer = -1f;
		UsingPoint = null;
		Reserved = null;
		if (Stolen != null && Stolen.Count > 0)
		{
			int num = Mathf.RoundToInt(0.25f * (float)Stolen.Count);
			for (int i = 0; i < num; i++)
			{
				if (Stolen.Count <= 0)
				{
					break;
				}
				int index = UnityEngine.Random.Range(0, Stolen.Count);
				if (string.IsNullOrEmpty(Stolen[index].GetFurn().MetalMarket))
				{
					Stolen.RemoveAt(index);
				}
			}
			GameSettings.Instance.StolenBack += Stolen.Count;
			for (int j = 0; j < Stolen.Count; j++)
			{
				InventoryItem inventoryItem = Stolen[j];
				Furniture furn = inventoryItem.GetFurn();
				if (string.IsNullOrEmpty(furn.MetalMarket))
				{
					GameSettings.AddToInventory(inventoryItem);
					inventoryItem.ReverseInsurance();
				}
				else if (GameSettings.Instance.AddHeat(1.01f, true))
				{
					NotificationManager.AddNotification(new DismissableIssue("PoliceMetalNotification".Loc(furn.GetActualString()), "Money"));
				}
			}
			Stolen = null;
		}
		GameSettings.Instance.Arrested = true;
		if (MyCar != null)
		{
			MyCar.SpawnPoints[CarSpawnID].Occupants.Remove(this);
			MyCar = null;
		}
		if (targetCar != null)
		{
			CarSpawnID = UnityEngine.Random.Range(2, 4);
			targetCar.SpawnPoints[CarSpawnID].Occupants.Add(this);
			MyCar = targetCar;
		}
		if (goNow)
		{
			AIScript.currentNode = AIScript.BehaviorNodes["Arrest"].Success;
		}
		else
		{
			AIScript.currentNode = AIScript.BehaviorNodes["Arrest"];
		}
	}

	public string GetActorGroup()
	{
		switch (AItype)
		{
		case AI.AIType.Guest:
			return "Guests";
		case AI.AIType.Burglar:
			return "Burglars";
		case AI.AIType.Police:
			return "Police";
		case AI.AIType.FireInspector:
			return "FireInspector";
		case AI.AIType.FireFighter:
			return "FireFighter";
		case AI.AIType.Parent:
			return "Parent";
		default:
			return null;
		}
	}

	public void Init()
	{
		if (_initialized)
		{
			return;
		}
		if (AIScript == null)
		{
			AIScript = AI.LoadAI(this, AItype);
		}
		if (employee == null || string.IsNullOrEmpty(employee.Name))
		{
			employee = new Employee(SDateTime.Now(), (Employee.EmployeeRole)UnityEngine.Random.Range(0, 5), Female, Employee.WageBracket.Medium, GameSettings.Instance.IsReferenceNull() ? GameData.AllPersonalities() : GameSettings.Instance.Personalities, "Default", false, null, null, 1f, 0.1f, Employee.Trait.None, Employee.Trait.None);
			employee.Employ(GameSettings.Instance.MyCompany, SDateTime.Now(), false);
		}
		AIScript.Initialize();
		if (AItype == AI.AIType.Employee)
		{
			InitBenefits();
		}
		_shadow = ActorGenerator.Instance.InitShadow(this);
		Children.Add(_shadow.rend);
		employee.StyleGen = ActorGenerator.Instance.ApplySavedStyle((employee.StyleGen != null) ? employee.StyleGen : ActorGenerator.Instance.GenerateStyle(Female, "Default", employee.GetAge()), this);
		if (employee.HasTrait(Employee.Trait.Watch))
		{
			ActorBodyItem actorBodyItem = ActorGenerator.Instance.SetItem(this, false, "AccessoryWatch");
			Children.Add(actorBodyItem.rend);
		}
		if (IsEmployee())
		{
			if (!GameSettings.Instance.sActorManager.Actors.Contains(this))
			{
				GameSettings.Instance.sActorManager.Actors.Add(this);
			}
			if (!GameSettings.Instance.EditMode)
			{
				GlobalSearchPanel.Instance.AddSearchItem(this, employee.ExtraName, delegate
				{
					HUD.Instance.DetailWindow.Show(this);
				}, false, delegate
				{
					Snapshot();
				});
			}
		}
		else if (AI.IsStaff(AItype))
		{
			if (!GameSettings.Instance.sActorManager.Staff.Contains(this))
			{
				GameSettings.Instance.sActorManager.Staff.Add(this);
			}
		}
		else
		{
			string actorGroup = GetActorGroup();
			GameSettings.Instance.sActorManager.Others[actorGroup].Add(this);
		}
		_initialized = true;
	}

	private void Awake()
	{
		Affactors = new float[AffectorCount];
		for (int i = 0; i < Affactors.Length; i++)
		{
			Affactors[i] = -2f;
		}
	}

	private void Start()
	{
		_animRandomness = UnityEngine.Random.Range(10f, 30f);
		if (!Deserialized)
		{
			InitWritable();
			ClearPath(false);
			Init();
			if (GameSettings.Instance.sActorManager.Teams.Count == 1 && Team == null)
			{
				Team = GameSettings.Instance.sActorManager.Teams.Keys.First();
			}
			CalendarWindow.ScheduleRefresh = true;
			ScheduleVacation(true);
			MeetingTime = (DriveTime = (DespawnTime = SDateTime.Now()));
			LastMeeting = employee.Hired;
			LastSocial = employee.Hired;
			if (WaitSpawn)
			{
				if (MyCar == null)
				{
					SDateTime sDateTime = SDateTime.Now();
					SDateTime time = ((team != null) ? new SDateTime(0, team.WorkStart - 1, sDateTime.Day, sDateTime.Month, sDateTime.Year) : sDateTime);
					if (time.SimplifyLess() < sDateTime.SimplifyLess())
					{
						time += new SDateTime(1, 0, 0);
					}
					GameSettings.Instance.sActorManager.AddToAwaiting(this, time);
				}
				base.enabled = false;
				SetVisible(false);
			}
			switch (AItype)
			{
			case AI.AIType.Cleaning:
				GetItem("Broom", true);
				break;
			case AI.AIType.Janitor:
				GetItem("Hammer", true);
				break;
			case AI.AIType.Guest:
				GetItem("Briefcase", true);
				break;
			case AI.AIType.FireInspector:
				GetItem("Clipboard", true);
				break;
			case AI.AIType.Burglar:
				GetItem("Sack", true);
				break;
			case AI.AIType.FireFighter:
				GetItem("FireHose", true);
				break;
			}
		}
		else
		{
			UpdateCurrentRoom(true);
			if (base.enabled && currentRoom.GetNodeAt(new Vector2(ActualPosition.x, ActualPosition.z)) == null)
			{
				currentRoom.FixActorPosition(this);
			}
		}
		GameSettings.Instance.RegisterActor(this, true);
		Deserialized = false;
	}

	public void SetAnim(AnimationStates state, int sub = -1)
	{
		if (anim.GetInteger("AnimControl") != (int)state)
		{
			_currentBlend = -1;
		}
		anim.SetInteger("AnimControl", (int)state);
		if (sub > 0)
		{
			anim.SetInteger("SubAnim", sub);
		}
	}

	public void ResetBlend()
	{
		SetBlend(1f, 0f, 0f, 0f);
	}

	public SVector3 GetBlend()
	{
		return new SVector3(anim.GetFloat("Blend1"), anim.GetFloat("Blend2"), anim.GetFloat("Blend3"), anim.GetFloat("Blend4"));
	}

	public void SetBlend(int id)
	{
		anim.SetFloat("Blend1", (id == 0) ? 1 : 0);
		anim.SetFloat("Blend2", (id == 1) ? 1 : 0);
		anim.SetFloat("Blend3", (id == 2) ? 1 : 0);
		anim.SetFloat("Blend4", (id == 3) ? 1 : 0);
	}

	public void SetBlend(float blend1, float blend2, float blend3, float blend4)
	{
		anim.SetFloat("Blend1", blend1);
		anim.SetFloat("Blend2", blend2);
		anim.SetFloat("Blend3", blend3);
		anim.SetFloat("Blend4", blend4);
	}

	public void BlendFromTo(int from, int to, float inSeconds = 0.5f)
	{
		float num = anim.GetFloat("Blend" + (to + 1));
		if (num >= 1f)
		{
			return;
		}
		if (from == to)
		{
			if (num <= 1f)
			{
				SetBlend(to);
			}
			return;
		}
		float num2 = Time.deltaTime * GameSettings.GameSpeed / inSeconds;
		num = Mathf.Min(1f, num + num2);
		for (int i = 0; i < 4; i++)
		{
			string text = "Blend" + (i + 1);
			if (i == from)
			{
				anim.SetFloat(text, 1f - num);
			}
			else if (i == to)
			{
				anim.SetFloat(text, num);
			}
			else
			{
				anim.SetFloat(text, 0f);
			}
		}
	}

	public int CurrentBlend()
	{
		int result = 0;
		float num = anim.GetFloat("Blend1");
		float num2 = anim.GetFloat("Blend2");
		if (num2 > num)
		{
			num = num2;
			result = 1;
		}
		num2 = anim.GetFloat("Blend3");
		if (num2 > num)
		{
			num = num2;
			result = 2;
		}
		num2 = anim.GetFloat("Blend4");
		if (num2 > num)
		{
			num = num2;
			result = 3;
		}
		return result;
	}

	public void TowardsBlend(int blend, float inSeconds = 0.5f)
	{
		float[] array = new float[4]
		{
			anim.GetFloat("Blend1"),
			anim.GetFloat("Blend2"),
			anim.GetFloat("Blend3"),
			anim.GetFloat("Blend4")
		};
		if (array[blend] >= 1f)
		{
			return;
		}
		float num = Time.deltaTime * GameSettings.GameSpeed / inSeconds;
		array[blend] = Mathf.Min(1f, array[blend] + num);
		float num2 = 1f - array[blend];
		if (num2 == 0f)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (i != blend)
				{
					array[i] = 0f;
				}
			}
		}
		else
		{
			float num3 = 0f;
			for (int j = 0; j < array.Length; j++)
			{
				if (j != blend)
				{
					num3 += array[j];
				}
			}
			if (num3 > 0f)
			{
				for (int k = 0; k < array.Length; k++)
				{
					if (k != blend)
					{
						array[k] = array[k] / num3 * num2;
					}
				}
			}
		}
		anim.SetFloat("Blend1", array[0]);
		anim.SetFloat("Blend2", array[1]);
		anim.SetFloat("Blend3", array[2]);
		anim.SetFloat("Blend4", array[3]);
	}

	public bool MayPlaySound()
	{
		if (!GameSettings.Instance.IsReferenceNull() && Floor == CameraScript.Instance.GetCameraFloor())
		{
			return (CameraScript.Instance.LastListenerPos - ActualPosition).sqrMagnitude < AudioComp.maxDistance * AudioComp.maxDistance;
		}
		return false;
	}

	private bool IsInValidLookState()
	{
		int integer = anim.GetInteger("AnimControl");
		if (integer == 0 || integer == 1 || integer == 7 || integer == 8 || integer == 9)
		{
			return false;
		}
		return true;
	}

	private float IsInRandomLookState()
	{
		if (anim.IsInTransition(0))
		{
			return 0f;
		}
		switch (anim.GetInteger("AnimControl"))
		{
		case 0:
			return 1f;
		case 1:
			return 0.5f;
		default:
			return 0f;
		}
	}

	private void RandomSubAnim(int max)
	{
		_animRandomness -= Time.deltaTime * GameSettings.GameSpeed;
		if (_animRandomness <= 0f || _currentBlend == -1 || _currentBlend >= max)
		{
			_animRandomness = UnityEngine.Random.Range(10f, 30f);
			if (_currentBlend == -1 || _currentBlend >= max)
			{
				_currentBlend = UnityEngine.Random.Range(0, max);
			}
			else
			{
				_currentBlend = (_currentBlend + UnityEngine.Random.Range(1, max)) % max;
			}
		}
		TowardsBlend(_currentBlend);
	}

	private void LateUpdate()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		bool flag = true;
		if (GameSettings.GameSpeed > 0f)
		{
			switch (CurrentAnimState)
			{
			case AnimationStates.Idle:
				if (employee.Energy < 0.25f || employee.Posture < 0.25f || employee.Stress < 0.15f || employee.Social < 0.15f || employee.JobSatisfaction < 0.75f)
				{
					TowardsBlend(3);
					flag = false;
				}
				else
				{
					RandomSubAnim(3);
				}
				break;
			case AnimationStates.Walk:
				if (employee.Energy < 0.25f || employee.Posture < 0.25f || employee.Stress < 0.15f || employee.Social < 0.15f || employee.JobSatisfaction < 0.75f)
				{
					TowardsBlend(2);
				}
				else if (employee.Energy > 0.5f && employee.Posture > 0.5f && employee.Stress > 0.5f && employee.Social > 0.5f && employee.JobSatisfaction > 1.5f)
				{
					TowardsBlend(1);
				}
				else
				{
					TowardsBlend(0);
				}
				break;
			case AnimationStates.Run:
				SetBlend((AItype == AI.AIType.Burglar) ? 1 : 0);
				break;
			case AnimationStates.Work:
				if (employee.Energy < 0.25f || employee.Posture < 0.25f || employee.Stress < 0.15f || employee.Social < 0.15f || employee.JobSatisfaction < 0.75f)
				{
					TowardsBlend(2);
					flag = false;
				}
				else
				{
					RandomSubAnim(2);
				}
				break;
			default:
				ResetBlend();
				break;
			}
		}
		if (LastVisible && flag && WasOnScreen && VisibilityRenderer.isVisible && !Eyes.sleep && !Biking && CameraScript.Instance.mainCam.transform.position.y - ActualPosition.y < 20f)
		{
			if (GameSettings.GameSpeed == 0f)
			{
				if (_lastLookAt.HasValue)
				{
					LookBone.rotation = _lastLookAt.Value;
				}
				return;
			}
			Vector3? vector = null;
			if (AIScript.HasFlag(AI.NodeFlag.InMeeting) && Team != null && GetTeam().Talking.IsAliveNotNull() && GetTeam().Talking != this && GetTeam().Talking.AIScript.HasFlag(AI.NodeFlag.InMeeting))
			{
				vector = GetTeam().Talking.EyePos.position;
				_rndLookAt = null;
			}
			else if (AIScript.HasFlag(AI.NodeFlag.LookAtTarget) && TargetActor.IsAliveNotNull())
			{
				vector = TargetActor.EyePos.position;
				_rndLookAt = null;
			}
			else if (AItype != AI.AIType.Robot && IsInValidLookState() && UsingPoint != null && UsingPoint.Parent.IsAliveNotNull())
			{
				Transform[] lookAtPoints = UsingPoint.Parent.LookAtPoints;
				if (IsMentor && TargetActor.IsAliveNotNull() && TargetActor.UsingPoint != null && "Computer".Equals(TargetActor.UsingPoint.Parent.Type))
				{
					lookAtPoints = TargetActor.UsingPoint.Parent.LookAtPoints;
				}
				if (lookAtPoints != null && lookAtPoints.Length != 0)
				{
					if (lookAtPoints.Length > 1)
					{
						_lookAtCountdown -= Time.deltaTime * GameSettings.GameSpeed;
						if (_lookAtCountdown < 0f)
						{
							_lookAtCountdown = UnityEngine.Random.Range(4, 15);
							_lookAtIndex = (_lookAtIndex + 1) % lookAtPoints.Length;
						}
						vector = lookAtPoints[_lookAtIndex % lookAtPoints.Length].position;
					}
					else
					{
						vector = lookAtPoints[0].position;
					}
				}
				_rndLookAt = null;
			}
			else if (AItype != AI.AIType.Robot)
			{
				float num = IsInRandomLookState();
				if (num > 0f)
				{
					_lookAtCountdown -= Time.deltaTime * GameSettings.GameSpeed;
					if (_lookAtCountdown < 0f || !_rndLookAt.HasValue)
					{
						_lookAtCountdown = UnityEngine.Random.Range(4, 15);
						_rndLookAt = Quaternion.Euler(num * UnityEngine.Random.Range(-50f, 50f), 0f, num * UnityEngine.Random.Range(-20f, currentRoom.Outside ? 40f : 0f));
					}
				}
				else
				{
					_rndLookAt = null;
				}
			}
			else
			{
				_rndLookAt = null;
			}
			bool flag2 = false;
			if (vector.HasValue)
			{
				Vector3 normalized = (vector.Value - EyePos.position).normalized;
				if (Vector3.Angle(EyePos.forward.normalized, normalized) < 90f)
				{
					Vector3 eulerAngles = Quaternion.FromToRotation(EyePos.forward, normalized).eulerAngles;
					Quaternion b = Quaternion.Euler(eulerAngles.x, ClampNeckAngle(eulerAngles.y), Mathf.LerpAngle(eulerAngles.z, 0f, 0.5f)) * LookBone.rotation;
					Quaternion quaternion = Quaternion.Lerp(_lastLookAt ?? LookBone.rotation, b, 5f * Time.deltaTime * GameSettings.GameSpeed);
					Quaternion value = (LookBone.rotation = quaternion);
					_lastLookAt = value;
					_rndLookAt = null;
					flag2 = true;
				}
			}
			if (!flag2 && _rndLookAt.HasValue)
			{
				Quaternion quaternion3 = Quaternion.Lerp(_lastLookAt ?? LookBone.rotation, LookBone.rotation * _rndLookAt.Value, 5f * Time.deltaTime * GameSettings.GameSpeed);
				Quaternion value = (LookBone.rotation = quaternion3);
				_lastLookAt = value;
				flag2 = true;
			}
			if (!flag2 && _lastLookAt.HasValue)
			{
				Quaternion quaternion5 = Quaternion.Lerp(_lastLookAt.Value, LookBone.rotation, 5f * Time.deltaTime * GameSettings.GameSpeed);
				Quaternion value = (LookBone.rotation = quaternion5);
				_lastLookAt = value;
			}
		}
		else
		{
			_lastLookAt = null;
			_rndLookAt = null;
		}
	}

	private static float ClampNeckAngle(float angle)
	{
		if (angle >= 70f && angle < 180f)
		{
			return 70f;
		}
		if (angle > 180f && angle < 290f)
		{
			return 290f;
		}
		if (angle < -70f)
		{
			return -70f;
		}
		return angle;
	}

	private bool IsStandingUp()
	{
		AnimatorStateInfo currentAnimatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);
		int integer = anim.GetInteger("AnimControl");
		if (currentAnimatorStateInfo.IsTag("SitStates") && integer != 3 && integer != 4 && integer != 5 && integer != 7 && integer != 12 && integer != 13)
		{
			return true;
		}
		return false;
	}

	private bool IsStandingStill()
	{
		return anim.GetInteger("AnimControl") == 0;
	}

	private void FixedUpdate()
	{
		if (!base.isActiveAndEnabled || GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (GameSettings.GameSpeed > 0f)
		{
			anim.speed = ((!Turn && _isWalking) ? (GetWalkSpeedFactor(ActualPosition) * GameSettings.GameSpeed) : GameSettings.GameSpeed);
		}
		else
		{
			anim.speed = 0f;
		}
		bool flag = base.enabled && ((GameSettings.Instance.ActiveFloor >= 0 && ((currentRoom.Outside && ActualPosition.y <= (float)(GameSettings.Instance.ActiveFloor * 2) + 1.9f) || (Options.EmployeesAllFloor && !currentRoom.IsSurrounded && ActualPosition.y <= (float)(GameSettings.Instance.ActiveFloor * 2) + 1.9f))) || Mathf.Abs(ActualPosition.y / 2f - (float)GameSettings.Instance.ActiveFloor) < 0.8f || (Floor < GameSettings.Instance.ActiveFloor && (IsHighlight || currentRoom.Outdoors)) || CameraScript.Instance.FlyMode);
		if (!flag && GameSettings.Instance.ActiveFloor >= 0)
		{
			Room mainAtriumParent = currentRoom.GetMainAtriumParent();
			if (mainAtriumParent.IsAliveNotNull())
			{
				flag = GameSettings.Instance.ActiveFloor >= mainAtriumParent.Floor && GameSettings.Instance.ActiveFloor <= mainAtriumParent.Floor + mainAtriumParent.AtriumChildren.Count && ActualPosition.y < (float)GameSettings.Instance.ActiveFloor * 2f + 1.6f;
			}
		}
		if (LastVisible ^ flag)
		{
			SetVisible(flag);
		}
		WasOnScreen = flag && (VisibilityRenderer.isVisible || (ActualPosition + Vector3.up).IsOnScreen(64));
		if (SpecialState == HomeState.Sleeping)
		{
			if (!(UsingPoint == null))
			{
				Eyes.sleep = true;
				Eyes.UpdateMe();
				MakeUnIdle();
				return;
			}
			AIScript.currentNode = AIScript.BehaviorNodes["ShouldUseBed"];
			SpecialState = HomeState.Default;
			GoHomeNow = true;
		}
		if (Biking)
		{
			MakeUnIdle();
			if (base.transform.parent != null)
			{
				ActualPosition = base.transform.position;
			}
			if (MyCar.IsAliveNotNull() && MyCar.IsBike)
			{
				if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Biking"))
				{
					anim.speed = MyCar.CurrentSpeed / MyCar.Speed * GameSettings.GameSpeed;
				}
				else if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("BikingStart"))
				{
					anim.Play("OnBike", 0, 0f);
				}
			}
			else
			{
				Biking = false;
			}
			return;
		}
		if (WasOnScreen)
		{
			CheckSideWalk();
			if (_traitView != Employee.Trait.None && (Floor == GameSettings.Instance.ActiveFloor || currentRoom.Outside || currentRoom.Outdoors))
			{
				if (_traitViewExp.ToInt() - SDateTime.Now().ToInt() > 0)
				{
					TraitOverlayPanel.Instance.AddTrait(_traitView, _traitColor, NeckBone);
				}
				else
				{
					_traitView = Employee.Trait.None;
				}
			}
		}
		else if (GameSettings.GameSpeed > 0f && !IsStandingStill())
		{
			PosOffset = Vector2.zero;
		}
		if (!AtFurniture)
		{
			GameSettings.Instance.ActorGrid.Add(this);
		}
		AudioComp.volume = ((GameSettings.GameSpeed == 0f) ? 0f : 1f);
		if (DataOverlay.Instance.ActiveOverlay != null && LastVisible)
		{
			UpdateData();
		}
		if (GameSettings.GameSpeed == 0f)
		{
			return;
		}
		if (AItype == AI.AIType.Employee && !this.employee.Founder && AtFurniture && UsingPoint != null)
		{
			Furniture furniture = null;
			bool flag2 = false;
			if (UsingPoint.Parent.ComputerChair.IsAliveNotNull())
			{
				furniture = UsingPoint.Parent.ComputerChair;
				flag2 = true;
			}
			else if (UsingPoint.Parent.Type.Equals("Chair"))
			{
				furniture = UsingPoint.Parent;
				flag2 = true;
			}
			if (flag2)
			{
				if (furniture.MiscPotential < 0.5f && this.employee.Posture > 0f)
				{
					this.employee.Posture = Mathf.Max(0f, this.employee.Posture - Utilities.PerDay(1f - furniture.MiscPotential * 2f) * 0.03f * 3f);
				}
				else if (furniture.MiscPotential > 0.5f && this.employee.Posture < 1f)
				{
					float num = (furniture.HasUpg ? furniture.upg.Quality : 1f);
					this.employee.Posture = Mathf.Min(1f, this.employee.Posture + num * Utilities.PerDay((furniture.MiscPotential - 0.5f) * 2f) * 0.08f * 3f);
				}
			}
		}
		if (coffee != null)
		{
			coffee.MiscValue -= Time.deltaTime * GameSettings.GameSpeed;
			if (coffee.MiscValue <= 0f)
			{
				LeaveItem(coffee, true);
				coffee = null;
			}
		}
		if (!IsCrunching() && CrunchHangover > 0f)
		{
			CrunchHangover = Mathf.Max(0f, CrunchHangover - Time.deltaTime * GameSettings.GameSpeed / (float)GameSettings.DaysPerMonth / 60f);
		}
		if (LastCheckWait >= 0f)
		{
			LastCheckWait -= Time.deltaTime * GameSettings.GameSpeed;
		}
		Noisiness = 1f;
		bool flag3 = false;
		bool flag4 = false;
		if (Holding[0] != null)
		{
			flag3 = Holding[0].HoldStraight;
			flag4 = Holding[0].HoldStraight && Holding[0].HoldBoth;
		}
		if (!flag4 && Holding[1] != null)
		{
			flag3 |= Holding[1].HoldStraight && Holding[1].HoldBoth;
			flag4 = Holding[1].HoldStraight;
		}
		anim.SetBool("RightHand", flag3);
		anim.SetBool("LeftHand", flag4);
		Eyes.Energy = this.employee.Energy;
		Eyes.Happy = Effectiveness > 2f;
		if (WasOnScreen)
		{
			Eyes.UpdateMe();
		}
		if (!GoHomeNow)
		{
			if (IsEmployee())
			{
				if (SDateTime.Now() > LeaveTime)
				{
					GoHomeNow = true;
				}
			}
			else if (AItype == AI.AIType.Burglar)
			{
				if ((SDateTime.Now() - MeetingTime).ToInt() > 120)
				{
					GoHomeNow = true;
				}
			}
			else if ((SDateTime.Now() - MeetingTime).ToInt() > 60 * (OnCall ? 8 : GetStaffHours()))
			{
				GoHomeNow = true;
			}
		}
		if (currentRoom.IsOnFire)
		{
			if (!AIScript.HasFlag(AI.NodeFlag.Run))
			{
				FleeNow();
			}
			this.employee.AddInstantMood("FireScared", this);
			Burnt += Utilities.PerHour(2f);
			if (Burnt >= 1f)
			{
				AchievementController.SetAchievement("FIREPERISH");
				Room.FirePoof(ActualPosition);
				if (GameSettings.Instance.ActiveFireReport != null && !GameSettings.Instance.ActiveFireReport.Passed())
				{
					GameSettings.Lawsuit lawsuit = new GameSettings.Lawsuit("FounderShareCompany".Loc(this.employee.FullName), "Negligence", 1000000.0, 1f);
					lawsuit.Reasons.Add("FireInspectionLawsuit");
					GameSettings.Instance.LaunchSuit(lawsuit);
				}
				if (AItype == AI.AIType.Employee)
				{
					QuitAffectTeam(true);
					SpecialState = HomeState.Dead;
					float benefitValue = GetBenefitValue("Life insurance");
					GameSettings.Instance.MyCompany.MakeTransaction(0f - benefitValue, Company.TransactionCategory.Benefits, true, "Life insurance");
					HUD.Instance.insuranceWindow.AddTermination(new EmployeeTermination(this, EmployeeTermination.TerminationType.Dead, benefitValue), this);
					this.employee.Retired = true;
				}
				DestroyGO();
				return;
			}
		}
		else if (Burnt > 0f)
		{
			Burnt -= Utilities.PerHour(0.25f);
		}
		if (AItype == AI.AIType.Employee && !Despawned)
		{
			AirQuality -= Utilities.PerHour(currentRoom.Smell / 8f);
			if (DogBlessing)
			{
				SocialFactor = -32f;
				StressFactor = -4f;
			}
			if (SocialFactor > 0f && (GoHomeNow || GameSettings.Instance.sActorManager.Actors.Count < 4))
			{
				SocialFactor = 0f;
			}
			if (this.employee.HasTrait(Employee.Trait.Claustrophobic))
			{
				float num2 = ClaustrophobiaFactor();
				float value;
				if (num2 > 0f && (!this.employee.GetMood("TraitClaustrophobicMood", out value) || value < num2))
				{
					this.employee.AddMood("TraitClaustrophobicMood", this, Time.deltaTime, num2);
				}
			}
			float num3 = ((StressFactor > 0f) ? (this.employee.ModTrait(Employee.Trait.Stressed, 0.65f, 0.4f) * (this.employee.Founder ? 0.75f : 1f)) : StressRelief);
			if (StressFactor > 0f)
			{
				num3 *= 1f - currentRoom.GetAwardValue(AwardTrophy.BuffType.SocialStress);
			}
			if (!this.employee.Founder)
			{
				float num4 = ((SocialFactor > 0f) ? (this.employee.ModTrait(Employee.Trait.Independant, 0.05f, 0.75f) * (this.employee.InteractedWithBestFriend ? 0.5f : 1f)) : this.employee.ModTrait(Employee.Trait.Independant, 6f, 4f));
				float num5 = _cachedBenefitValue / EmployeeBenefit.MaxBenefits;
				if (num5 >= 0f)
				{
					this.employee.SetMood("GoodBenefits", this, num5);
					this.employee.SetMood("BadBenefits", this, 0f);
				}
				else
				{
					this.employee.SetMood("GoodBenefits", this, 0f);
					this.employee.SetMood("BadBenefits", this, 0f - num5);
				}
				if (this.employee.HasTrait(Employee.Trait.UnderTheWeather) && TimeOfDay.Instance.RainFactor > 0f)
				{
					this.employee.SetMood("TraitUnderTheWeather", this, 0.1f);
				}
				if (this.employee.HasTrait(Employee.Trait.Sunshine) && TimeOfDay.Instance.RainFactor <= 0f && TimeOfDay.Instance.SnowAmount <= 0f && TimeOfDay.Instance.Temperature > 21f)
				{
					this.employee.SetMood("TraitSunshine", this, 0.1f);
				}
				if (this.employee.HasTrait(Employee.Trait.Skyscraper) && currentRoom.Floor > 0)
				{
					this.employee.SetMood("TraitSkyscraper", this, currentRoom.Floor.MapRange(0f, 10f, 0f, 0.1f, true));
				}
				if (!this.employee.HasTrait(Employee.Trait.NightOwl))
				{
					float lateNightDebuff = Utilities.GetLateNightDebuff(SDateTime.Now(), this);
					if (lateNightDebuff > 0.1f)
					{
						HintController.Show(HintController.Hints.HintNightOwl);
					}
					this.employee.SetMood("NightShiftWork", this, lateNightDebuff);
				}
				else if (NightOwlDebuff > 0f)
				{
					NightOwlDebuff = Mathf.Max(0f, NightOwlDebuff - Utilities.PerHour(0.5f));
					SetTraitView(Employee.Trait.NightOwl, 0, 5, false, HUD.GetThemeColor(2));
				}
				else if (Utilities.IsLateNight(SDateTime.Now(), this))
				{
					SetTraitView(Employee.Trait.NightOwl, 0, 5, false, HUD.GetThemeColor(0));
				}
				if (IsIdle && (!this.employee.IsRole(Employee.RoleBit.Lead) || GetTeam().Count == 1))
				{
					this.employee.AddMood("IdleBored", this, Time.deltaTime, 0.6f);
				}
				if (currentRoom.DogBlessing)
				{
					this.employee.AddMood("LoveFriend", this, Time.deltaTime);
				}
				if (SocialFactor > 0f)
				{
					num4 *= 1f - currentRoom.GetAwardValue(AwardTrophy.BuffType.SocialStress);
				}
				this.employee.Update(Time.deltaTime * GameSettings.GameSpeed, WorksForFree(), GoHomeNow, !HasMet || AIScript.HasFlag(AI.NodeFlag.DisableAllNeeds), AIScript.HasFlag(AI.NodeFlag.DisableToiletNeed) ? Employee.Status.Disable : ((AIScript.HasFlag(AI.NodeFlag.DisableFoodNeed) || QueuedFor("Toilet")) ? Employee.Status.Freeze : Employee.Status.Enable), AIScript.HasFlag(AI.NodeFlag.DisableFoodNeed) ? Employee.Status.Disable : ((AIScript.HasFlag(AI.NodeFlag.DisableToiletNeed) || QueuedFor("FastFood") || QueuedFor("Tray")) ? Employee.Status.Freeze : Employee.Status.Enable), StressFactor * num3, SocialFactor * num4, 1f - currentRoom.GetAwardValue(AwardTrophy.BuffType.HungerBladder), !ShouldWork, this);
				float num6 = ((UsingPoint != null) ? UsingPoint.Parent.GetUseEffect(Furniture.UseEffect.SocialIsolation) : 0f);
				SocialFactor = (NeighbourSocialBoost * (1f - num6)).MapRange(0f, 2f, 1f, 0.01f) * (1f + num6 * 0.5f);
			}
			else
			{
				this.employee.Update(Time.deltaTime * GameSettings.GameSpeed, WorksForFree(), GoHomeNow, true, Employee.Status.Disable, Employee.Status.Disable, StressFactor * num3, 0f, 0f, !ShouldWork, this);
			}
			if (!IsWorking)
			{
				StressFactor = -1f;
			}
			Fatigue();
			UpdateProblems();
			if (GermAdd > 0f)
			{
				Room room = currentRoom;
				if (!room.Outside && !room.Outdoors && room.GermCount < 1f)
				{
					room.GetMainAtriumParentOrSelf().GermCount += Utilities.PerHour(GermAdd);
				}
			}
		}
		if (!this.employee.Founder && Team != null)
		{
			TeamRelationTimer -= Time.deltaTime * GameSettings.GameSpeed;
			if (TeamRelationTimer <= 0f)
			{
				TeamRelationTimer = TeamRelationTimerMax + Utilities.RandomRange(-2f, 2f);
				List<Actor> employeesDirect = GetTeam().GetEmployeesDirect();
				if (employeesDirect.Count > 1)
				{
					for (int i = 0; i < employeesDirect.Count; i++)
					{
						int num7 = (i + TeamRelationNum) % employeesDirect.Count;
						Actor actor = employeesDirect[num7];
						if (actor.enabled && actor != this && !actor.employee.HasTrait(Employee.Trait.Detached))
						{
							Employee employee = actor.employee;
							float num8 = this.employee.Compatibility(employee);
							employee.AddInstantMood((num8 >= 1f) ? "LikeTeamWork" : "DislikeTeamWork", actor, Mathf.Abs(num8 - 1f));
							TeamRelationNum = (num7 + 1) % employeesDirect.Count;
							break;
						}
					}
				}
			}
		}
		bool shouldWork = ShouldWork;
		ShouldWork = false;
		_isWalking = false;
		if (anim.GetCurrentAnimatorStateInfo(0).IsTag("VehicleOut"))
		{
			anim.enabled = true;
			TestVarVehicle += Time.deltaTime * GameSettings.GameSpeed;
		}
		else if (AIScript.HasFlag(AI.NodeFlag.Working) || ((!(GameSettings.GameSpeed <= 1f) || !anim.IsInTransition(0)) && !IsStandingUp()))
		{
			if (EState == ElevatorState.Queued || EState == ElevatorState.InTransit)
			{
				if (QueuedForElevator == null || !QueuedForElevator.IsUsing(this))
				{
					ResetState();
				}
				SetAnim(AnimationStates.Idle);
			}
			else if (Turn)
			{
				TestVarVehicle = 0f;
				TurnAround();
			}
			else
			{
				TestVarVehicle = 0f;
				string text = AIScript.currentNode.Name;
				AIScript.RunSimulation();
				if (AIScript.currentNode == null)
				{
					Debug.LogError("Went from: " + text + " to nothing");
				}
			}
		}
		if (!ShouldWork && IsWorking)
		{
			IsWorking = false;
		}
		if (WasOnScreen && Floor == GameSettings.Instance.ActiveFloor && IsEmployee())
		{
			if (IsWorking && EmitType != WorkParticle.None)
			{
				float num9 = Effectiveness;
				if (UsingPoint != null)
				{
					num9 *= UsingPoint.Parent.GetRawEffectivenessValue();
				}
				NextParticle -= Time.deltaTime * Mathf.Lerp(0.5f, 2f, num9) * (float)Mathf.Max(0, HUD.Instance.GameSpeed);
				if (NextParticle <= 0f)
				{
					int amount = Mathf.CeilToInt((num9 + 0.1f) * 5f);
					EmitParticle(ParticleSeed[(int)EmitType], amount, Color.Lerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), num9), NeckBone.position);
					NextParticle = 1f;
				}
			}
			if (BO && CameraScript.Instance.mainCam.transform.position.y - ActualPosition.y < 30f)
			{
				NextSmell -= Time.deltaTime * (float)HUD.Instance.GameSpeed * 4f;
				if (NextSmell <= 0f)
				{
					HUD.Instance.SmellSystem.Emit(new ParticleSystem.EmitParams
					{
						position = NeckBone.position + Vector3.up * 0.1f,
						velocity = new Vector3(UnityEngine.Random.Range(-0.1f, 0.1f), UnityEngine.Random.Range(0.5f, 1f), UnityEngine.Random.Range(-0.1f, 0.1f))
					}, 1);
					NextSmell += 1f;
				}
			}
		}
		if (Floor == GameSettings.Instance.ActiveFloor && ((AIScript.HasFlag(AI.NodeFlag.Snore) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Walk")) || (shouldWork && ShouldWork && !IsWorking && IdleStatus != WorkStatus.Working)))
		{
			if (AItype == AI.AIType.Employee && HintController.IsHintPossible(HintController.Hints.HintSendHome) && UsingPoint != null && "Computer".Equals(UsingPoint.Parent.Type))
			{
				HintController.Show(HintController.Hints.HintSendHome);
			}
			if (WasOnScreen)
			{
				NextParticle -= Time.deltaTime;
				if (NextParticle <= 0f)
				{
					ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
					{
						position = NeckBone.position
					};
					HUD.Instance.ZnoreEmitter.Emit(emitParams, 1);
					NextParticle = 1f;
				}
			}
			Eyes.sleep = true;
		}
		else
		{
			Eyes.sleep = false;
		}
	}

	public static void EmitParticle(uint[] seeds, int amount, Color c, Vector3 pos)
	{
		ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
		{
			position = pos,
			startColor = c
		};
		for (int i = 0; i < amount; i++)
		{
			emitParams.randomSeed = seeds.GetRandom();
			emitParams.velocity = new Vector3(UnityEngine.Random.Range(-0.2f, 0.2f), 0.5f, UnityEngine.Random.Range(-0.2f, 0.2f));
			HUD.Instance.EffectivenessEmitter.Emit(emitParams, 1);
		}
	}

	private float ClaustrophobiaFactor()
	{
		Room room = currentRoom;
		if (!room.Outdoors && !room.Outside)
		{
			float num = room.Area / Mathf.Sqrt(Mathf.Max(1, room.Occupants.Count));
			float num2 = room.WindowDarkLevelNoCap.MapRange(0f, 1f, 25f, 6f, true);
			if (num < num2)
			{
				return num.MapRange(1f, num2, 1f, 0.25f, true);
			}
		}
		return 0f;
	}

	public void UpdateDataBall()
	{
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		Color value = DataOverlay.Instance.ActiveOverlay.AcFunc(this);
		materialPropertyBlock.SetColor("_Color", value);
		DataBallRend.SetPropertyBlock(materialPropertyBlock);
	}

	public void UpdateData()
	{
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		Color value = ((AItype != AI.AIType.Employee || DataOverlay.Instance.ActiveOverlay.AcFunc == null) ? Color.white : DataOverlay.Instance.ActiveOverlay.AcFunc(this));
		materialPropertyBlock.SetColor("_DataColor", value);
		for (int i = 0; i < BodyItems.Count; i++)
		{
			ActorBodyItem actorBodyItem = BodyItems[i];
			if (!(actorBodyItem.rend != null))
			{
				continue;
			}
			if (actorBodyItem.GPUInstanced)
			{
				MaterialPropertyBlock materialPropertyBlock2 = new MaterialPropertyBlock();
				actorBodyItem.rend.GetPropertyBlock(materialPropertyBlock2);
				materialPropertyBlock2.SetColor("_DataColor", value);
				actorBodyItem.rend.SetPropertyBlock(materialPropertyBlock2);
				if (actorBodyItem.LOD1Renderer != null)
				{
					actorBodyItem.LOD1Renderer.SetPropertyBlock(materialPropertyBlock2);
				}
			}
			else
			{
				actorBodyItem.rend.SetPropertyBlock(materialPropertyBlock);
				if (actorBodyItem.LOD1Renderer != null)
				{
					actorBodyItem.LOD1Renderer.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}
		for (int j = 0; j < LOD2UpperBody.Length; j++)
		{
			LOD2UpperBody[j].GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetColor("_DataColor", value);
			LOD2UpperBody[j].SetPropertyBlock(materialPropertyBlock);
		}
		for (int k = 0; k < LOD2LowerBody.Length; k++)
		{
			LOD2LowerBody[k].GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetColor("_DataColor", value);
			LOD2LowerBody[k].SetPropertyBlock(materialPropertyBlock);
		}
		for (int l = 0; l < LOD2Head.Length; l++)
		{
			LOD2Head[l].GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetColor("_DataColor", value);
			LOD2Head[l].SetPropertyBlock(materialPropertyBlock);
		}
		for (int m = 0; m < LOD2Feet.Length; m++)
		{
			LOD2Feet[m].GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetColor("_DataColor", value);
			LOD2Feet[m].SetPropertyBlock(materialPropertyBlock);
		}
		for (int n = 0; n < LOD2Hair.Length; n++)
		{
			LOD2Hair[n].GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetColor("_DataColor", value);
			LOD2Hair[n].SetPropertyBlock(materialPropertyBlock);
		}
	}

	private void OnDisable()
	{
		currentRoom = null;
	}

	private void OnEnable()
	{
		if (employee != null)
		{
			UpdateAgeLook();
		}
	}

	public void SetVisible(bool visible)
	{
		LastVisible = visible;
		for (int i = 0; i < Children.Count; i++)
		{
			if (Children[i] == null)
			{
				Children.RemoveAt(i);
				i--;
			}
			else
			{
				Children[i].enabled = visible;
			}
		}
		for (int j = 0; j < Colliders.Length; j++)
		{
			Colliders[j].enabled = visible;
		}
		if (IsOnLift && LastVisible)
		{
			UpdateScissor();
		}
		if (!visible || SpecialState != HomeState.Sleeping)
		{
			return;
		}
		if (UsingPoint != null)
		{
			ActualPosition = UsingPoint.transform.position;
			base.transform.position = ActualPosition;
			base.transform.rotation = UsingPoint.transform.rotation;
		}
		for (int k = 0; k < BodyItems.Count; k++)
		{
			ActorBodyItem actorBodyItem = BodyItems[k];
			if (!actorBodyItem.AllowBed)
			{
				actorBodyItem.rend.enabled = false;
				if (actorBodyItem.LOD1Renderer != null)
				{
					actorBodyItem.LOD1Renderer.enabled = false;
				}
				actorBodyItem.ExtraRends.ForEachEnum(delegate(Renderer x)
				{
					x.enabled = false;
				});
			}
		}
	}

	public void UpdateAgeLook()
	{
		if (AItype == AI.AIType.Robot || AItype == AI.AIType.Burglar)
		{
			return;
		}
		float age = employee.GetAge();
		float value = ((age >= 50f) ? ((age - 50f) / 10f) : 0f);
		value = Mathf.Clamp01(value);
		ActorBodyItem actorBodyItem = _bodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Hair);
		if (actorBodyItem != null)
		{
			ActorBodyItem.ColorMapping colorMapping = actorBodyItem.Colormap.FirstOrDefault((ActorBodyItem.ColorMapping x) => x.ColorName.Equals("Hair"));
			if (colorMapping != null)
			{
				actorBodyItem.SetColorDirect(colorMapping.MaterialSlot, Color.Lerp(HairColor, Color.gray, value));
			}
		}
		ActorBodyItem actorBodyItem2 = _bodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
		if (actorBodyItem2 != null)
		{
			actorBodyItem2.rend.material.SetFloat("_Overlay2Factor", value);
		}
	}

	private void TurnAround()
	{
		Vector3 eulerAngles = base.transform.rotation.eulerAngles;
		float y = eulerAngles.y;
		if (Mathf.Abs(Mathf.DeltaAngle(y, TargetRot)) <= 0.001f)
		{
			Turn = false;
			anim.SetInteger("AnimControl", LastAnim);
			base.transform.rotation = Quaternion.Euler(eulerAngles.x, TargetRot, eulerAngles.z);
			return;
		}
		float num = TargetRot - y;
		int num2 = ((Mathf.Abs(num) > 180f) ? (-Utilities.Sign(num)) : Utilities.Sign(num));
		float num3 = Utilities.Modulo(y + (float)num2 * Time.deltaTime * GameSettings.GameSpeed * 200f, 360f);
		SetAnim((num2 < 0) ? AnimationStates.TurnLeft : AnimationStates.TurnRight);
		if (y != Utilities.Modulo(TargetRot - 180f, 360f) && Utilities.AnglePassed(y, num3, TargetRot))
		{
			num3 = TargetRot;
			Turn = false;
			anim.SetInteger("AnimControl", LastAnim);
		}
		base.transform.rotation = Quaternion.Euler(eulerAngles.x, num3, eulerAngles.z);
	}

	public Holdable GetItemAnyHand(string name)
	{
		int num = ((!(Holding[0] == null)) ? 1 : 0);
		bool flag = num == 0;
		if (Holding[num] == null)
		{
			Holdable holdable = ItemDispenser.Instance.Dispense(name);
			holdable.Holder = this;
			holdable.transform.SetParent(flag ? RightHand : LeftHand, true);
			holdable.transform.localPosition = new Vector3(flag ? holdable.OffsetTranslation.x : (0f - holdable.OffsetTranslation.x), holdable.OffsetTranslation.y, holdable.OffsetTranslation.z);
			holdable.transform.localRotation = Quaternion.Euler(holdable.OffsetRotation.x, holdable.OffsetRotation.y, flag ? holdable.OffsetRotation.z : (0f - holdable.OffsetRotation.z));
			Holding[(!flag) ? 1u : 0u] = holdable;
			for (int i = 0; i < holdable.Renderers.Length; i++)
			{
				holdable.Renderers[i].enabled = LastVisible;
			}
			Children.AddRange(holdable.Renderers);
			return holdable;
		}
		return null;
	}

	public Holdable GetItem(string itemName, bool right)
	{
		if ((right && Holding[0] == null) || (!right && Holding[1] == null))
		{
			Holdable holdable = ItemDispenser.Instance.Dispense(itemName);
			holdable.Holder = this;
			holdable.transform.SetParent(right ? RightHand : LeftHand, true);
			holdable.transform.localPosition = new Vector3(holdable.OffsetTranslation.x, holdable.OffsetTranslation.y, right ? holdable.OffsetTranslation.z : (0f - holdable.OffsetTranslation.z));
			holdable.transform.localRotation = Quaternion.Euler(right ? holdable.OffsetRotation.x : (0f - holdable.OffsetRotation.x), holdable.OffsetRotation.y, right ? holdable.OffsetRotation.z : (0f - holdable.OffsetRotation.z));
			Holding[(!right) ? 1u : 0u] = holdable;
			for (int i = 0; i < holdable.Renderers.Length; i++)
			{
				holdable.Renderers[i].enabled = LastVisible;
			}
			Children.AddRange(holdable.Renderers);
			return holdable;
		}
		return null;
	}

	public void LeaveItem(string name, bool destroy = false)
	{
		if (Holding[0] != null && Holding[0].Type.Equals(name))
		{
			Holding[0].RemoveActorChildren(this);
			if (Holding[0].Holder == this)
			{
				Holding[0].Holder = null;
			}
			if (destroy)
			{
				Holding[0].DestroyMe();
			}
			Holding[0] = null;
		}
		if (Holding[1] != null && Holding[1].Type.Equals(name))
		{
			Holding[1].RemoveActorChildren(this);
			if (Holding[1].Holder == this)
			{
				Holding[1].Holder = null;
			}
			if (destroy)
			{
				Holding[1].DestroyMe();
			}
			Holding[1] = null;
		}
	}

	public void LeaveItem(Holdable item, bool destroy = false)
	{
		if (Holding[0] == item)
		{
			Holding[0] = null;
			item.RemoveActorChildren(this);
		}
		if (Holding[1] == item)
		{
			Holding[1] = null;
			item.RemoveActorChildren(this);
		}
		if (item.Holder == this)
		{
			item.Holder = null;
		}
		if (destroy)
		{
			item.DestroyMe();
		}
	}

	public bool ReTakeItemAnyHand(Holdable item)
	{
		int num = ((!(Holding[0] == null)) ? 1 : 0);
		bool flag = num == 0;
		if (Holding[num] == null)
		{
			item.DecoupleFromParent();
			item.Holder = this;
			item.transform.SetParent(flag ? RightHand : LeftHand, true);
			item.transform.localPosition = new Vector3(item.OffsetTranslation.x, item.OffsetTranslation.y, flag ? item.OffsetTranslation.z : (0f - item.OffsetTranslation.z));
			item.transform.localRotation = Quaternion.Euler(flag ? item.OffsetRotation.x : (0f - item.OffsetRotation.x), item.OffsetRotation.y, flag ? item.OffsetRotation.z : (0f - item.OffsetRotation.z));
			Holding[(!flag) ? 1u : 0u] = item;
			for (int i = 0; i < item.Renderers.Length; i++)
			{
				item.Renderers[i].enabled = LastVisible;
			}
			Children.AddRange(item.Renderers);
			return true;
		}
		return false;
	}

	public bool ReTakeItem(Holdable item, bool right)
	{
		if ((right && Holding[0] == null) || (!right && Holding[1] == null))
		{
			item.DecoupleFromParent();
			item.transform.SetParent(right ? RightHand : LeftHand, true);
			item.transform.localPosition = new Vector3(item.OffsetTranslation.x, item.OffsetTranslation.y, right ? item.OffsetTranslation.z : (0f - item.OffsetTranslation.z));
			item.transform.localRotation = Quaternion.Euler(right ? item.OffsetRotation.x : (0f - item.OffsetRotation.x), item.OffsetRotation.y, right ? item.OffsetRotation.z : (0f - item.OffsetRotation.z));
			item.Holder = this;
			Holding[(!right) ? 1u : 0u] = item;
			for (int i = 0; i < item.Renderers.Length; i++)
			{
				item.Renderers[i].enabled = LastVisible;
			}
			Children.AddRange(item.Renderers);
			return true;
		}
		return false;
	}

	public void InitiateTurn(float targetdir)
	{
		Vector3 eulerAngles = base.transform.rotation.eulerAngles;
		if (Mathf.Approximately(eulerAngles.y, targetdir))
		{
			base.transform.rotation = Quaternion.Euler(eulerAngles.x, targetdir, eulerAngles.z);
			return;
		}
		Turn = true;
		TargetRot = targetdir;
		LastAnim = anim.GetInteger("AnimControl");
		TurnAround();
	}

	public static void ConvertPath(List<PathVector> path)
	{
	}

	public Vector3 GetFuturePoint(float dist)
	{
		if (CurrentPath == null || CurrentPath.Count == 0)
		{
			return ActualPosition;
		}
		float num = dist;
		float num2 = PathProg;
		int num3 = CurrentPathNode;
		int num4 = CurrentPathNode + 1;
		while (num3 < CurrentPath.Count - 1)
		{
			PathVector pathVector = CurrentPath[num3];
			if (num2 > 0f)
			{
				pathVector += (CurrentPath[num4] - pathVector) * num2;
			}
			float magnitude = (pathVector - CurrentPath[num4]).magnitude;
			if (!(magnitude < num))
			{
				break;
			}
			num3++;
			num4++;
			num2 = 0f;
			num -= magnitude;
		}
		if (num3 >= CurrentPath.Count - 1)
		{
			return CurrentPath[CurrentPath.Count - 1];
		}
		return CurrentPath[num3] + (CurrentPath[num4] - CurrentPath[num3]).normalized * num;
	}

	public Vector3 GetPathPoint(float nDist)
	{
		int num = Mathf.FloorToInt(nDist);
		if (num < CurrentPath.Count - 1)
		{
			return Vector3.Lerp(CurrentPath[num], CurrentPath[num + 1], nDist - (float)num);
		}
		return CurrentPath[CurrentPath.Count - 1];
	}

	public float GetWalkSpeedFactor(Vector3 p, int i = -1)
	{
		float num = 1f;
		if (employee.HasTrait(Employee.Trait.BumLeg))
		{
			num = 0.75f;
		}
		if (CurrentPath == null || CurrentPath.Count == 0)
		{
			return num;
		}
		float num2 = CurrentPath[Mathf.Clamp((i < 0) ? CurrentPathNode : i, 0, CurrentPath.Count - 1)].GetSpeed(p);
		if (float.IsInfinity(num2))
		{
			num2 = 0f;
		}
		return (1f + num2) * num;
	}

	private bool CheckElevator()
	{
		if (CurrentPath[CurrentPathNode].Type == PathVector.PathType.Elevator)
		{
			Furniture furniture = CurrentPath[CurrentPathNode].GetObject<Furniture>();
			if (furniture != null && furniture.EGroup != null)
			{
				TargetFloor = Mathf.FloorToInt((CurrentPath[CurrentPathNode + 2].y + 1f) / 2f);
				furniture.EGroup.Enqueue(this);
				if (AItype == AI.AIType.FireInspector)
				{
					MarkRoomEscapeViolation(furniture.Parent, furniture.EGroup);
				}
			}
			else
			{
				ResetState();
			}
			return true;
		}
		return false;
	}

	private void MarkRoomEscapeViolation(Room r, ElevatorGroup g)
	{
		if (!GameSettings.Instance.ActiveFireReport.EscapeRooms.Add(r.DID))
		{
			return;
		}
		bool flag = true;
		foreach (Room item in GameSettings.Instance.sRoomManager.GetConnected(r, true))
		{
			if (item != r && GameSettings.Instance.ActiveFireReport.EscapeRooms.Contains(item.DID))
			{
				flag = false;
				break;
			}
		}
		int floor = Floor;
		int num = ((TargetFloor >= floor) ? (floor - g.BaseFloor + 1) : (floor - g.BaseFloor - 1));
		if (num >= 0 && num < g.Elevators.Length)
		{
			r = g.Elevators[num].Parent;
			if (r != null && GameSettings.Instance.ActiveFireReport.EscapeRooms.Add(r.DID))
			{
				flag = true;
				foreach (Room item2 in GameSettings.Instance.sRoomManager.GetConnected(r, true))
				{
					if (item2 != r && GameSettings.Instance.ActiveFireReport.EscapeRooms.Contains(item2.DID))
					{
						flag = false;
						break;
					}
				}
			}
		}
		if (flag)
		{
			GameSettings.Instance.ActiveFireReport.EscapeViolations++;
			GameSettings.Instance.ActiveFireReport.EscapePaths.Add(CurrentPath.Skip(CurrentPathNode).Take(4).Select((Func<PathVector, SVector3>)((PathVector x) => x))
				.ToList());
		}
	}

	public bool WalkPath()
	{
		_isWalking = true;
		if (CurrentPath == null || CurrentPath.Count < 2 || (CurrentPath.Count == 2 && CurrentPath[0].Approximate(CurrentPath[1])))
		{
			ClearPath();
			return true;
		}
		AtFurniture = false;
		Noisiness = 2f;
		float f = 0f;
		if (CurrentPathNode < CurrentPath.Count - 1)
		{
			Vector3 to = CurrentPath[CurrentPathNode + 1] - CurrentPath[CurrentPathNode];
			if (Mathf.Abs(to.y) > 0.0001f)
			{
				f = Vector3.Angle(new Vector3(to.x, 0f, to.z), to);
			}
		}
		bool flag = Mathf.Abs(f) > 80f;
		bool flag2 = AIScript.HasFlag(AI.NodeFlag.Run);
		if (flag || IsOnLift)
		{
			SetAnim(AnimationStates.Idle);
		}
		else
		{
			AnimationStates state = (flag2 ? AnimationStates.Run : ((AItype != AI.AIType.Burglar || AIScript.HasFlag(AI.NodeFlag.GoingHome)) ? AnimationStates.Walk : AnimationStates.Sneak));
			if (!anim.IsActor(state))
			{
				SetAnim(state);
				if (GameSettings.GameSpeed <= 1f)
				{
					return false;
				}
				UnusedMeters -= 1.5f;
			}
			if (GameSettings.GameSpeed <= 1f && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Moving"))
			{
				return false;
			}
		}
		if (PathProg == 0f && CurrentPathNode == 0 && CheckElevator())
		{
			return true;
		}
		float num = GetWalkSpeedFactor(ActualPosition) * WalkSpeed * Time.deltaTime * GameSettings.GameSpeed;
		if (employee.HasTrait(Employee.Trait.BumLeg))
		{
			SetTraitView(Employee.Trait.BumLeg, 0, 5);
		}
		if (flag2)
		{
			num *= 2f;
		}
		if (GameSettings.GameSpeed > 1f)
		{
			num += UnusedMeters;
		}
		Vector3 vector = Vector3.zero;
		Vector3 vector2 = Vector3.zero;
		float min = (float)CurrentPathNode + PathProg;
		while (num > 0.0001f && CurrentPathNode < CurrentPath.Count - 1)
		{
			if (CurrentPath[CurrentPathNode].Type == PathVector.PathType.Portal)
			{
				if (CurrentPathNode < CurrentPath.Count - 1)
				{
					GameSettings.Instance.ElectricityBurst += 10f * (CurrentPath[CurrentPathNode] - CurrentPath[CurrentPathNode + 1]).magnitude;
				}
				if (GameSettings.Instance.Portal1 != null)
				{
					GameSettings.Instance.Portal1.InteractStart();
				}
				if (GameSettings.Instance.Portal2 != null)
				{
					GameSettings.Instance.Portal2.InteractStart();
				}
				if (GotoNextNode())
				{
					break;
				}
				continue;
			}
			vector = CurrentPath[CurrentPathNode];
			vector2 = CurrentPath[CurrentPathNode + 1];
			float magnitude = (vector - vector2).magnitude;
			if (num >= magnitude)
			{
				num -= magnitude;
				if (GotoNextNode())
				{
					break;
				}
				continue;
			}
			float b = 1f - PathProg;
			b = Mathf.Min(num / magnitude, b);
			PathProg += b;
			num -= magnitude * b;
			if (PathProg >= 0.9999f && GotoNextNode())
			{
				break;
			}
		}
		if (GameSettings.GameSpeed > 1f)
		{
			UnusedMeters = num;
		}
		else
		{
			UnusedMeters += num;
		}
		UpdateCurrentRoom();
		if (AItype != AI.AIType.Cleaning && CurrentPath != null && UnityEngine.Random.value / GameSettings.GameSpeed < 0.05f)
		{
			Room room = currentRoom;
			if (room.IsAliveNotNull() && room.Floor != Floor)
			{
				UpdateCurrentRoom(true);
				room = currentRoom;
			}
			if (CurrentPath != null && room.IsAliveNotNull() && (!IsEmployee() || !employee.HasTrait(Employee.Trait.Clean)))
			{
				if (room.Outside || (room.Outdoors && room.FloorMat.Equals("None")))
				{
					AvailableDirt = employee.ModTrait(Employee.Trait.OldSole, 1.5f, 0.5f);
				}
				else if (!room.IsUpperAtriumNotBalcony && AvailableDirt > 0.01f)
				{
					Vector2 vector3 = GetPathPoint(UnityEngine.Random.Range(min, (float)CurrentPathNode + PathProg)).FlattenVector3();
					Vector2 vector4 = (vector2 - vector).FlattenVector3();
					float sqrMagnitude = vector4.sqrMagnitude;
					float num2 = ((sqrMagnitude < 1E-06f) ? 0f : (UnityEngine.Random.Range(-0.25f, 0.5f) / Mathf.Sqrt(sqrMagnitude)));
					float num3 = room.AddDirt(vector3 + num2 * vector4, employee.ModTrait(Employee.Trait.OldSole, 0.1f, 0.05f), vector4);
					AvailableDirt -= num3;
				}
			}
		}
		f = 0f;
		if (CurrentPath == null)
		{
			return false;
		}
		if (CurrentPathNode < CurrentPath.Count - 1)
		{
			Vector3 to2 = CurrentPath[CurrentPathNode + 1] - CurrentPath[CurrentPathNode];
			if (!Mathf.Approximately(to2.y, 0f))
			{
				f = Vector3.Angle(new Vector3(to2.x, 0f, to2.z), to2);
			}
		}
		flag = Mathf.Abs(f) > 80f;
		if (CurrentPathNode >= CurrentPath.Count - 1)
		{
			ActualPosition = CurrentPath[CurrentPath.Count - 1];
			if (CurrentPath.Count > 1)
			{
				vector = Utilities.ReplaceY(CurrentPath[CurrentPath.Count - 2], 0f);
				vector2 = Utilities.ReplaceY(CurrentPath[CurrentPath.Count - 1], 0f);
				if (vector2 != vector)
				{
					base.transform.rotation = Quaternion.LookRotation(vector2 - vector);
				}
			}
			UpdateCurrentRoom(true);
			currentRoom.FixActorPosition(this);
			ClearPath(false);
			return true;
		}
		vector = CurrentPath[CurrentPathNode];
		vector2 = CurrentPath[CurrentPathNode + 1];
		Vector3 vector5 = vector2 - vector;
		ActualPosition = vector + vector5 * PathProg;
		if (!flag && vector2.FlattenVector3() != vector.FlattenVector3())
		{
			Quaternion b2 = Quaternion.LookRotation(vector5.ReplaceY(0f));
			bool flag3 = false;
			if (!flag2)
			{
				float flatAngle = vector5.GetFlatAngle();
				if (Utilities.AngleDistance(base.transform.forward.GetFlatAngle(), flatAngle) > 90f)
				{
					flag3 = true;
					InitiateTurn(flatAngle);
				}
			}
			if (!flag3)
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b2, Time.deltaTime * 10f * GameSettings.GameSpeed);
			}
		}
		return false;
	}

	public Vector2 GetPosWithOffset()
	{
		return new Vector2(ActualPosition.x + PosOffset.x, ActualPosition.z + PosOffset.y);
	}

	private void SimulateOffset()
	{
		Vector2 posOffset = PosOffset;
		List<Actor> list = GameSettings.Instance.ActorGrid.Query(GetPosWithOffset(), SimOffsetSize * 4f);
		PosOffset = Vector2.zero;
		Vector2 posWithOffset = GetPosWithOffset();
		int floor = Floor;
		for (int i = 0; i < list.Count; i++)
		{
			Actor actor = list[i];
			if (!actor.IsAliveNotNull() || (actor.DID <= DID && !actor.AtFurniture) || actor.Floor != floor)
			{
				continue;
			}
			Vector2 posWithOffset2 = actor.GetPosWithOffset();
			if (posWithOffset2.MaxDist(posWithOffset) < SimOffsetSize)
			{
				Vector2 vector = posWithOffset - posWithOffset2;
				float magnitude = vector.magnitude;
				if (magnitude < SimOffsetSize)
				{
					vector = ((magnitude > 0f) ? (vector / magnitude) : (-actor.transform.forward.FlattenVector3()));
					PosOffset += vector * (SimOffsetSize - magnitude);
					posWithOffset = GetPosWithOffset();
				}
			}
		}
		GridAreaQuery<Room> value;
		if (currentRoom.Outside && GameSettings.Instance.sRoomManager.RoomQuery.TryGetValue(0, out value))
		{
			foreach (Room item in value.QueryAround(GetPosWithOffset(), SimOffsetSize + 0.1f))
			{
				if (!item.IsAliveNotNull() || !item.IsInsideBounds(posWithOffset, SimOffsetSize + 0.1f))
				{
					continue;
				}
				for (int j = 0; j < item.Edges.Count; j++)
				{
					WallEdge wallEdge = item.Edges[j];
					WallEdge wallEdge2 = item.Edges[(j + 1) % item.Edges.Count];
					Vector2 res;
					if (Utilities.ProjectToLine(posWithOffset, wallEdge.Pos, wallEdge2.Pos, out res))
					{
						Vector2 vector2 = posWithOffset - res;
						float magnitude2 = vector2.magnitude;
						if (magnitude2 > 0f && magnitude2 < SimOffsetSize)
						{
							vector2 /= magnitude2;
							PosOffset += vector2 * (SimOffsetSize - magnitude2);
							posWithOffset = GetPosWithOffset();
							break;
						}
					}
				}
			}
		}
		PosOffset = Vector2.MoveTowards(posOffset, PosOffset, SimOffsetEffect * Time.deltaTime * GameSettings.GameSpeed);
	}

	public void InitLift(Vector3 position, float height, float rot)
	{
		IsOnLift = true;
		LiftStart = position;
		LiftHeight = height;
		LiftRot = rot;
		UpdateScissor();
	}

	private bool GotoNextNode()
	{
		PathProg = 0f;
		CurrentPathNode++;
		if (CurrentPath[CurrentPathNode].Type == PathVector.PathType.Door)
		{
			CurrentPath[CurrentPathNode].OpenDoors();
		}
		if (EState == ElevatorState.Entering)
		{
			if (QueuedForElevator == null)
			{
				EState = ElevatorState.None;
			}
			else
			{
				QueuedForElevator.Enter(this);
			}
			return true;
		}
		if (CurrentPathNode == CurrentPath.Count - 2 && CurrentPath[CurrentPathNode].y < CurrentPath[CurrentPath.Count - 1].y - 0.5f)
		{
			UpdateCurrentRoom();
			if (CurrentPath == null)
			{
				return true;
			}
			if (currentRoom.AtriumParent.IsAliveNotNull())
			{
				Quaternion quaternion = ((UsingPoint != null) ? UsingPoint.transform.rotation : base.transform.rotation);
				InitLift(CurrentPath[CurrentPathNode], Mathf.Abs(CurrentPath[CurrentPath.Count - 1].y - CurrentPath[CurrentPathNode].y), quaternion.eulerAngles.y + 90f);
			}
		}
		else if (IsOnLift && CurrentPathNode == 1)
		{
			IsOnLift = false;
			if (ActiveScissor != null)
			{
				ActiveScissor.Release();
				ActiveScissor = null;
			}
		}
		else if (CheckElevator())
		{
			return true;
		}
		return CurrentPath == null;
	}

	private void UpdateScissor()
	{
		if (IsOnLift && LastVisible)
		{
			if (ActiveScissor == null)
			{
				ActiveScissor = ScissorLift.Get(LiftStart, LiftHeight, Quaternion.Euler(0f, LiftRot, 0f), this);
			}
			else
			{
				ActiveScissor.Init(LiftHeight);
			}
		}
	}

	private void CheckSideWalk()
	{
		if (GameSettings.GameSpeed > 0f)
		{
			if (AtFurniture || EState != ElevatorState.None)
			{
				PosOffset = Vector2.MoveTowards(PosOffset, Vector2.zero, Time.deltaTime * GameSettings.GameSpeed);
			}
			else
			{
				SimulateOffset();
			}
		}
		Vector3 vector = (UseSimOffset ? GetPosWithOffset().ToVector3(ActualPosition.y) : ActualPosition);
		if (currentRoom.Outside && RoadManager.Instance.CheckSideWalk(vector))
		{
			base.transform.position = new Vector3(vector.x, vector.y + 0.06f, vector.z);
		}
		else
		{
			base.transform.position = vector;
		}
	}

	public void SetPath(List<PathVector> path, bool init = true)
	{
		ClearPath();
		_currentPath = path;
		if (init && _currentPath != null)
		{
			InitPath();
		}
	}

	public void TurnToFurniture()
	{
		if (UsingPoint != null)
		{
			InitiateTurn(UsingPoint.Rotation);
		}
	}

	public override string Description()
	{
		return "Employees";
	}

	private void Fatigue()
	{
		if (!employee.HasTrait(Employee.Trait.Capacitor) && !AIScript.currentNode.Name.Equals("Spawn") && !GoHomeNow)
		{
			int num = SDateTime.Now().ToInt() - MeetingTime.ToInt();
			if (600 - num < 0)
			{
				employee.AddMood("WornOut", this, Time.deltaTime, 2f);
			}
		}
	}

	public void InitPath()
	{
		ConvertPath(CurrentPath);
		CurrentPathNode = 0;
		PathProg = 0f;
	}

	public bool CanToilet(bool toilet, Room r)
	{
		if (toilet)
		{
			if (r.IsAliveNotNull())
			{
				return r.IsPrivate;
			}
			return false;
		}
		return true;
	}

	private bool CheckFilter(Func<Furniture, bool> filter, Furniture furn)
	{
		if (FilterCheck == 0)
		{
			FilterCheck = 1;
		}
		if (filter == null)
		{
			FilterCheck = 2;
			return true;
		}
		if (filter(furn))
		{
			FilterCheck = 2;
			return true;
		}
		return false;
	}

	private static bool RoomReady(Room r, bool forPathing)
	{
		if (forPathing)
		{
			return !r.NavmeshRebuildStarted;
		}
		return r.WaitForNavmesh();
	}

	public void RemoveFromQueue(string type)
	{
		InteractionPoint value;
		if (InQueue.TryGetValue(type, out value))
		{
			value.RemoveFromQueue(this);
			InQueue.Remove(type);
		}
	}

	public List<InteractionPoint> FindFurniture(string tname, InteractionPoint.ActionType action, int maxDistance = -1, Room fromRoom = null, bool enforceAssigned = false, Func<Furniture, bool> filter = null, bool canQueue = true, float maxSq = -1f, bool forPathing = true, bool ignoreAssigned = false, bool force = false)
	{
		FilterCheck = 0;
		_furnResultCache.Clear();
		_furnfinalResultCache.Clear();
		bool flag = "Toilet".Equals(tname);
		bool flag2 = !flag && "Computer".Equals(tname);
		if (QueuedFor(tname))
		{
			InteractionPoint interactionPoint = InQueue[tname];
			if (interactionPoint == null)
			{
				InQueue.Remove(tname);
			}
			else if (interactionPoint.Action != action)
			{
				interactionPoint.RemoveFromQueue(this);
				InQueue.Remove(tname);
			}
			else
			{
				if (!interactionPoint.IsUp(this) || !CanToilet(flag, interactionPoint.Parent.Parent))
				{
					return _furnfinalResultCache;
				}
				if (interactionPoint.Usable() && !interactionPoint.Parent.Parent.BuildingOnFire && !(interactionPoint.Parent.Parent.Burn > 0f) && CheckFilter(filter, interactionPoint.Parent) && RoomReady(interactionPoint.Parent.Parent, forPathing))
				{
					_furnfinalResultCache.Add(interactionPoint);
					return _furnfinalResultCache;
				}
				interactionPoint.RemoveFromQueue(this);
				InQueue.Remove(tname);
			}
		}
		if (Reserved.IsAliveNotNull() && Reserved.Type.Equals(tname) && CheckFilter(filter, Reserved))
		{
			InteractionPoint interactionPoint2 = (force ? Reserved.GetInteractionPoint(action, true) : Reserved.GetInteractionPoint(this, action));
			if (interactionPoint2 != null && !interactionPoint2.Parent.Parent.BuildingOnFire && interactionPoint2.Parent.Parent.Burn <= 0f && RoomReady(interactionPoint2.Parent.Parent, forPathing))
			{
				_furnfinalResultCache.Add(interactionPoint2);
				return _furnfinalResultCache;
			}
		}
		SortedList<float, InteractionPoint> furnResultCache = _furnResultCache;
		bool flag3 = false;
		if (!ignoreAssigned)
		{
			foreach (Room assignedRoom in GetAssignedRooms())
			{
				flag3 = true;
				if (assignedRoom == null || assignedRoom.BuildingOnFire || assignedRoom.Burn > 0f || !RoomReady(assignedRoom, forPathing))
				{
					continue;
				}
				HashList<Furniture> furniture = assignedRoom.GetFurniture(tname);
				int count = furniture.Count;
				if (count > 0 && FilterCheck == 0)
				{
					FilterCheck = 1;
				}
				for (int i = 0; i < count; i++)
				{
					Furniture furniture2 = furniture[i];
					if (furniture2.IsAliveNotNull() && CheckFilter(filter, furniture2))
					{
						InteractionPoint interactionPoint3 = (force ? furniture2.GetInteractionPoint(action, true) : furniture2.GetInteractionPoint(this, action));
						if (interactionPoint3 != null)
						{
							furnResultCache.Add(RoomDist(1 + Mathf.Abs(Floor - furniture2.Floor), furniture2, !flag2), interactionPoint3);
						}
					}
				}
			}
		}
		if (flag3 && (furnResultCache.Count > 0 || enforceAssigned))
		{
			_furnfinalResultCache.AddRange(furnResultCache.Values);
			return _furnfinalResultCache;
		}
		Furniture furniture3 = null;
		if (ReservedFurniture.Count > 0)
		{
			foreach (Furniture item in ReservedFurniture)
			{
				if (item.IsAliveNotNull() && item.Type.Equals(tname) && CheckFilter(filter, item))
				{
					if (item.CheckAllowedInRoom())
					{
						furniture3 = item;
					}
					break;
				}
			}
		}
		if (furniture3 == null && Owns.Count > 0)
		{
			foreach (Furniture own in Owns)
			{
				if (own.IsAliveNotNull() && own.Type.Equals(tname) && CheckFilter(filter, own))
				{
					if (own.CheckAllowedInRoom())
					{
						furniture3 = own;
					}
					break;
				}
			}
		}
		if (furniture3.IsAliveNotNull())
		{
			if (furniture3.Parent.IsAliveNotNull() && CanToilet(flag, furniture3.Parent) && furniture3.Parent.AllowedInRoom(this) && !furniture3.Parent.BuildingOnFire && furniture3.Parent.Burn <= 0f)
			{
				InteractionPoint interactionPoint4 = (force ? furniture3.GetInteractionPoint(action, true) : (furniture3.GetInteractionPoint(this, action) ?? furniture3.GetQueueableInteractionPoint(this, action)));
				if (interactionPoint4 != null)
				{
					furnResultCache.Add(RoomDist(1f, furniture3, !flag2), interactionPoint4);
					_furnfinalResultCache.AddRange(furnResultCache.Values);
					return _furnfinalResultCache;
				}
				if (flag2 && furniture3.OwnedBy == this)
				{
					InteractionPoint interactionPoint5 = furniture3.GetInteractionPoint(InteractionPoint.ActionType.Use, true);
					if (interactionPoint5 != null && interactionPoint5.UsedBy.IsAliveNotNull() && interactionPoint5.UsedBy.AItype == AI.AIType.IT)
					{
						_furnfinalResultCache.Clear();
						return _furnfinalResultCache;
					}
				}
				furniture3.Reserved = null;
			}
			if (flag2 && employee.HasDemanded(LeadDesignDemands.Demand.PrivateOffice))
			{
				_furnfinalResultCache.Clear();
				return _furnfinalResultCache;
			}
		}
		UpdateCurrentRoom();
		List<KeyValuePair<Room, int>> connectedRooms = GameSettings.Instance.sRoomManager.GetConnectedRooms(fromRoom ?? currentRoom);
		InteractionPoint queueing = null;
		float queueDistance = float.MaxValue;
		if (team != null)
		{
			for (int j = 0; j < connectedRooms.Count; j++)
			{
				Room key = connectedRooms[j].Key;
				if (key.BuildingOnFire || key.Burn > 0f || !RoomReady(key, forPathing))
				{
					continue;
				}
				if (maxDistance != -1 && connectedRooms[j].Value > maxDistance)
				{
					break;
				}
				if (!key.Accessible || !key.Teams.Contains(team) || !key.AllowedInRoom(this) || !CanToilet(flag, key))
				{
					continue;
				}
				if (key.AtriumParent.IsAliveNotNull())
				{
					foreach (Room item2 in key.GetElligableAtriumSearch())
					{
						SearchRoom(tname, action, item2, key, connectedRooms[j].Value, flag2, canQueue, filter, maxSq, furnResultCache, ref queueDistance, ref queueing, force);
					}
				}
				else
				{
					SearchRoom(tname, action, key, key, connectedRooms[j].Value, flag2, canQueue, filter, maxSq, furnResultCache, ref queueDistance, ref queueing, force);
				}
			}
		}
		if (furnResultCache.Count == 0)
		{
			for (int k = 0; k < connectedRooms.Count; k++)
			{
				Room key2 = connectedRooms[k].Key;
				if (key2.BuildingOnFire || key2.Burn > 0f || !RoomReady(key2, forPathing))
				{
					continue;
				}
				if (maxDistance != -1 && connectedRooms[k].Value > maxDistance)
				{
					break;
				}
				if ((IsEmployee() && key2.Teams.Count > 0) || !key2.Accessible || !key2.AllowedInRoom(this) || !CanToilet(flag, key2))
				{
					continue;
				}
				if (key2.AtriumParent.IsAliveNotNull())
				{
					foreach (Room item3 in key2.GetElligableAtriumSearch())
					{
						SearchRoom(tname, action, item3, key2, connectedRooms[k].Value, flag2, canQueue, filter, maxSq, furnResultCache, ref queueDistance, ref queueing, force);
					}
				}
				else
				{
					SearchRoom(tname, action, key2, key2, connectedRooms[k].Value, flag2, canQueue, filter, maxSq, furnResultCache, ref queueDistance, ref queueing, force);
				}
			}
		}
		if (canQueue && queueing != null)
		{
			bool flag4 = true;
			float magnitude = (ActualPosition - queueing.Parent.transform.position).magnitude;
			using (IEnumerator<KeyValuePair<float, InteractionPoint>> enumerator3 = furnResultCache.GetEnumerator())
			{
				if (enumerator3.MoveNext())
				{
					KeyValuePair<float, InteractionPoint> current6 = enumerator3.Current;
					if (current6.Key <= queueDistance || (current6.Value.Parent.Floor == queueing.Parent.Floor && (ActualPosition - current6.Value.Parent.transform.position).magnitude - 6f < magnitude))
					{
						flag4 = false;
					}
				}
			}
			if (flag4)
			{
				queueing.AddToQueue(this);
				InQueue[tname] = queueing;
				return _furnfinalResultCache;
			}
		}
		if (furnResultCache.Values.Count == 0)
		{
			Furniture furniture4 = Owns.FirstOrDefault((Furniture x) => x.IsAliveNotNull() && x.Type.Equals(tname) && !x.Parent.AllowedInRoom(this));
			if (furniture4.IsAliveNotNull() && !NotificationManager.CheckAggregate<FurnitureAssignmentIssue>(furniture4))
			{
				NotificationManager.AddNotification(new FurnitureAssignmentIssue(SDateTime.Now(), furniture4));
			}
		}
		_furnfinalResultCache.AddRange(furnResultCache.Values);
		return _furnfinalResultCache;
	}

	private void SearchRoom(string tname, InteractionPoint.ActionType action, Room room, Room actualRoom, int distance, bool pc, bool canQueue, Func<Furniture, bool> filter, float maxSq, SortedList<float, InteractionPoint> result, ref float queueDistance, ref InteractionPoint queueing, bool force)
	{
		float dist = RoomDistance(distance);
		HashList<Furniture> furniture = room.GetFurniture(tname);
		int count = furniture.Count;
		if (count > 0 && FilterCheck == 0)
		{
			FilterCheck = 1;
		}
		for (int i = 0; i < count; i++)
		{
			Furniture furniture2 = furniture[i];
			if (furniture2 == null || !CheckFilter(filter, furniture2) || (maxSq > 0f && (furniture2.transform.position - ActualPosition).sqrMagnitude > maxSq) || furniture2.InteractionParent != actualRoom)
			{
				continue;
			}
			InteractionPoint interactionPoint = (force ? furniture2.GetInteractionPoint(action, true) : furniture2.GetInteractionPoint(this, action));
			if (interactionPoint != null)
			{
				result.Add(RoomDist(dist, furniture2, !pc), interactionPoint);
			}
			else
			{
				if (!canQueue)
				{
					continue;
				}
				interactionPoint = furniture2.GetQueueableInteractionPoint(this, action);
				if (interactionPoint != null)
				{
					float num = RoomDist(dist, furniture2, !pc);
					if (queueing == null || queueDistance > num)
					{
						queueDistance = num;
						queueing = interactionPoint;
					}
				}
			}
		}
	}

	public void CreateParentCar()
	{
		RoadNode target = RoadManager.Instance.FindRandomParking();
		CarScript carScript = RoadManager.Instance.CreateCar(CarIdx);
		carScript.ForceAddOccupant(this);
		MyCar = carScript;
		carScript.Target = target;
		carScript.Init();
		carScript.GetComponent<NormalCar>().ForceFinishRoute();
	}

	public void UpdateParentState()
	{
		if (TimeOfDay.Instance.Hour >= 8 && TimeOfDay.Instance.Hour < 16)
		{
			if (MyCar != null)
			{
				RoadManager.Instance.DestroyCar(MyCar);
				MyCar = null;
			}
			if (base.isActiveAndEnabled)
			{
				SpecialState = HomeState.Default;
				UsingPoint = null;
				ClearPath();
				OnDespawn();
				AIScript.currentNode = AIScript.BehaviorNodes["Dummy"];
			}
			GameSettings.Instance.sActorManager.AddToAwaiting(this, SDateTime.Now().ChangeHourMinute(16, 0), true);
			return;
		}
		if (TimeOfDay.Instance.Hour >= 22 || TimeOfDay.Instance.Hour <= 6)
		{
			if (SpecialState != HomeState.Sleeping)
			{
				List<InteractionPoint> list = FindFurniture("Bed", InteractionPoint.ActionType.Use);
				if (list != null && list.Count > 0)
				{
					ClearPath();
					if (!base.isActiveAndEnabled)
					{
						base.enabled = true;
						SetVisible(true);
						anim.enabled = true;
						MeetNow();
					}
					AIScript.currentNode = AIScript.BehaviorNodes["Dummy"];
					UsingPoint = null;
					UsingPoint = list[0];
					UsingPoint.Parent.InteractStart();
					ActualPosition = UsingPoint.transform.position;
					base.transform.rotation = UsingPoint.transform.rotation;
					AtFurniture = true;
					UpdateCurrentRoom(true);
					SetAnim(UsingPoint.Animation);
					SkipAnimTime();
					OnDespawn();
					if (TimeOfDay.Instance.Hour >= 22)
					{
						SDateTime sDateTime = SDateTime.Now();
						GameSettings.Instance.sActorManager.AddToAwaiting(this, new SDateTime(0, 7, sDateTime.Day + 1, sDateTime.Month, sDateTime.Year), true);
					}
					else
					{
						GameSettings.Instance.sActorManager.AddToAwaiting(this, SDateTime.Now().ChangeHourMinute(7, 0), true);
					}
				}
			}
			if (MyCar == null)
			{
				CreateParentCar();
			}
			return;
		}
		if (!base.isActiveAndEnabled || SpecialState == HomeState.Sleeping)
		{
			SpecialState = HomeState.Default;
			base.enabled = true;
			SetVisible(true);
			anim.enabled = true;
			MeetNow();
			UsingPoint = null;
			ClearPath();
			SetAnim(AnimationStates.Idle);
			SkipAnimTime();
			AIScript.currentNode = AIScript.BehaviorNodes["Loiter"];
			Room room = GameSettings.Instance.sRoomManager.Rooms.FirstOrDefault((Room x) => x.DID == 101);
			if (room != null)
			{
				Vector2? vector = room.FindRandomSpot();
				if (vector.HasValue)
				{
					ActualPosition = vector.Value.ToVector3(room.Floor * 2);
				}
			}
			UpdateCurrentRoom(true);
		}
		if (MyCar == null)
		{
			CreateParentCar();
		}
	}

	public void SkipAnimTime()
	{
		float speed = anim.speed;
		anim.speed = 1f;
		for (int i = 0; i < 10; i++)
		{
			anim.Update(1f);
		}
		anim.speed = speed;
	}

	private float RoomDist(float dist, Furniture furn, bool man)
	{
		if (man)
		{
			dist *= ActualPosition.ManhattanDist3D(furn.transform.position);
		}
		else
		{
			float maxEffectivenessValue = furn.GetMaxEffectivenessValue(employee);
			dist = ((maxEffectivenessValue != 0f) ? (dist * (1f / maxEffectivenessValue)) : float.MaxValue);
		}
		return dist;
	}

	private float RoomDistance(int dist)
	{
		float num = (float)dist + 1f;
		return num * num;
	}

	public Employee.RoleBit GetRole()
	{
		if (!IsEmployee())
		{
			return Employee.RoleBit.AllRoles;
		}
		return employee.CurrentRoleBit;
	}

	public static Func<PathNode<Vector3>, float> GetWeightingFunc(AI.AIType weighting)
	{
		switch (weighting)
		{
		case AI.AIType.Burglar:
			return RoomManager.BurglarWeight;
		case AI.AIType.FireInspector:
			return RoomManager.FireInspectorWeight;
		default:
			return null;
		}
	}

	public bool PathToPoint(Vector3 e, bool anyRoom = false, bool elevator = true, AI.AIType weighting = AI.AIType.Employee)
	{
		Vector3 vector = ActualPosition;
		Room room = null;
		if (currentRoom.IsUpperAtriumNotBalcony)
		{
			room = currentRoom.FindFloorAtrium(vector.FlattenVector3());
			vector = new Vector3(vector.x, (float)room.Floor * 2f, vector.z);
		}
		bool failedRoom;
		SetPath(GameSettings.Instance.sRoomManager.FindPath(vector, e, base.transform.rotation.eulerAngles.y, team, GetRole(), anyRoom || TrappedInToilet || !IsEmployee(), out failedRoom, elevator, GetWeightingFunc(weighting)));
		if (CurrentPath == null)
		{
			return false;
		}
		if (room != null)
		{
			if (!IsOnLift)
			{
				InitLift(vector, ActualPosition.y - (float)room.Floor * 2f, base.transform.rotation.eulerAngles.y);
			}
			CurrentPath.Insert(0, ActualPosition);
		}
		return true;
	}

	public bool PathToFurniture(InteractionPoint furn, bool warning)
	{
		if (furn != null)
		{
			_furnPathCache[0] = furn;
			return PathToFurniture(_furnPathCache, warning);
		}
		return false;
	}

	public bool IsEmployee()
	{
		if (AItype != AI.AIType.Employee)
		{
			return AItype == AI.AIType.Robot;
		}
		return true;
	}

	public bool CanUseBrokenFurniture()
	{
		if (AItype != AI.AIType.IT && AItype != AI.AIType.Janitor && AItype != AI.AIType.FireInspector)
		{
			return AItype == AI.AIType.Burglar;
		}
		return true;
	}

	public bool PathToFurniture(IList<InteractionPoint> furns, bool warning)
	{
		InteractionPoint interactionPoint = null;
		if (furns.Count > 0)
		{
			bool flag = false;
			bool allowAny = !IsEmployee() || TrappedInToilet;
			float y = base.transform.rotation.eulerAngles.y;
			int i = 0;
			_failPathIgnore.Clear();
			Vector3 vector = ActualPosition;
			Room room = null;
			if (currentRoom.IsUpperAtriumNotBalcony)
			{
				room = currentRoom.FindFloorAtrium(vector.FlattenVector3());
				vector = new Vector3(vector.x, (float)room.Floor * 2f, vector.z);
			}
			for (; i < furns.Count; i++)
			{
				InteractionPoint interactionPoint2 = furns[i];
				if (interactionPoint2 == null || _failPathIgnore.Contains(interactionPoint2.Parent.Parent))
				{
					continue;
				}
				Vector2 point = interactionPoint2.Point;
				Room interactionParent = interactionPoint2.Parent.InteractionParent;
				Vector3 endV = new Vector3(point.x, interactionParent.Floor * 2, point.y);
				bool failedRoom;
				SetPath(GameSettings.Instance.sRoomManager.FindPath(vector, endV, y, team, GetRole(), allowAny, out failedRoom));
				if (CurrentPath == null && interactionPoint2.Parent.PathFailCount == 0)
				{
					interactionPoint2.Parent.UpdateFreeNavs();
					InteractionPoint interactionPoint3 = interactionPoint2.Parent.GetInteractionPoint(this, interactionPoint2.Action);
					if (interactionPoint3 != null)
					{
						interactionPoint2 = interactionPoint3;
						point = interactionPoint2.Point;
						endV = new Vector3(point.x, interactionParent.Floor * 2, point.y);
						SetPath(GameSettings.Instance.sRoomManager.FindPath(vector, endV, y, team, GetRole(), allowAny, out failedRoom));
						if (failedRoom)
						{
							_failPathIgnore.Add(interactionParent);
						}
					}
				}
				else if (failedRoom)
				{
					_failPathIgnore.Add(interactionParent);
				}
				if (CurrentPath != null)
				{
					if (interactionPoint2.Parent.Parent.IsUpperAtrium)
					{
						PathVector pathVector = CurrentPath.Last();
						CurrentPath.Add(new PathVector(pathVector.x, (float)interactionPoint2.Parent.Parent.Floor * 2f, pathVector.z, pathVector.Type, pathVector.ObjectID));
					}
					if (room != null)
					{
						if (!IsOnLift)
						{
							InitLift(vector, ActualPosition.y - (float)room.Floor * 2f, base.transform.rotation.eulerAngles.y);
						}
						CurrentPath.Insert(0, ActualPosition);
					}
					interactionPoint2.Parent.PathFailCount = 0;
					lock (HUD.Instance.UnreachableFuniture)
					{
						HUD.Instance.UnreachableFuniture.Remove(interactionPoint2.Parent);
					}
					flag = true;
					interactionPoint = interactionPoint2;
					break;
				}
				interactionPoint2.Parent.PathFailCount++;
				if (interactionPoint2.Parent.Reserved == this)
				{
					interactionPoint2.Parent.Reserved = null;
				}
				if (warning)
				{
					lock (HUD.Instance.UnreachableFuniture)
					{
						HUD.Instance.UnreachableFuniture.Add(interactionPoint2.Parent);
					}
				}
			}
			for (i++; i < furns.Count; i++)
			{
				if (furns[i] != null && furns[i].Parent.Reserved == this)
				{
					furns[i].Parent.Reserved = null;
				}
			}
			if (!flag)
			{
				return false;
			}
			if (UsingPoint != null)
			{
				UsingPoint.UsedBy = null;
			}
			interactionPoint.UsedBy = this;
			UsingPoint = interactionPoint;
			return true;
		}
		return false;
	}

	private static bool IsOnBathroom(Actor up, InteractionPoint ip)
	{
		if ("Toilet".Equals(ip.Parent.Type))
		{
			return up.currentRoom == ip.Parent.Parent;
		}
		return false;
	}

	public int GoToFurniture(string name, InteractionPoint.ActionType action, int maxDistance, bool warning, Room fromRoom = null, bool loiter = false, bool enforceAssigned = false, Func<Furniture, bool> filter = null, float maxSq = -1f, bool ignoreAssigned = false)
	{
		if (UsingPoint != null && UsingPoint.Parent.Broken())
		{
			UsingPoint.UsedBy = null;
			UsingPoint = null;
		}
		if (AtFurniture && UsingPoint != null && UsingPoint.Parent.Type.Equals(name) && UsingPoint.Action == action && (UsingPoint.Parent.OwnedBy == null || UsingPoint.Parent.OwnedBy == this) && (ActualPosition.FlattenVector3() - UsingPoint.transform.position.FlattenVector3()).sqrMagnitude < 0.01f)
		{
			ClearPath(false);
			return 2;
		}
		AtFurniture = false;
		if (WaitingForQueue >= 0f)
		{
			if (QueuedFor(name) && !IsUp(name))
			{
				if (CurrentPath != null)
				{
					WalkPath();
					return 1;
				}
				InteractionPoint interactionPoint = InQueue[name];
				Actor actor = interactionPoint.CurrentQueue[0];
				if (IsOnBathroom(actor, interactionPoint) || (actor.UsingPoint == interactionPoint && (actor.AtFurniture || (actor.ActualPosition.FlattenVector3() - interactionPoint.Point).sqrMagnitude < 4f)))
				{
					WaitingForQueue += Time.deltaTime * GameSettings.GameSpeed;
					if (WaitingForQueue > 30f)
					{
						WaitingForQueue = -1f;
						RemoveFromQueue(name);
						ClearPath();
						return 0;
					}
					SetAnim(AnimationStates.Idle);
					return 1;
				}
				if (actor.UsingPoint == interactionPoint)
				{
					actor.CutBathroomPath(interactionPoint);
					actor.UsingPoint = null;
					actor.WaitingForQueue = 0f;
				}
				interactionPoint.CurrentQueue.Remove(this);
				interactionPoint.CurrentQueue.Remove(actor);
				interactionPoint.CurrentQueue.Insert(0, this);
				interactionPoint.CurrentQueue.Insert(1, actor);
				actor.InQueue[name] = interactionPoint;
				UsingPoint = interactionPoint;
			}
			else
			{
				ClearPath();
			}
			WaitingForQueue = -1f;
		}
		if (UsingPoint == null || !UsingPoint.Parent.Type.Equals(name) || UsingPoint.Action != action)
		{
			InteractionPoint usingPoint = UsingPoint;
			List<InteractionPoint> list = FindFurniture(name, action, maxDistance, fromRoom, enforceAssigned, filter, true, maxSq, true, ignoreAssigned);
			IList<InteractionPoint> furns;
			if (!IsEmployee())
			{
				furns = ((!loiter) ? ((IList<InteractionPoint>)list) : ((IList<InteractionPoint>)list.SubOrderTwoGroups((InteractionPoint x) => x.Parent.Parent.OrderByRole(-2) == 0)));
			}
			else if (employee.HasDemanded(LeadDesignDemands.Demand.PrivateOffice) && name.Equals("Computer"))
			{
				furns = list.SubOrderTwoGroups((InteractionPoint x) => x.Parent.Parent.GetFurniture("Computer").Count == 1);
			}
			else
			{
				int r = (int)(loiter ? (~Employee.RoleBit.Lead) : GetRole());
				furns = list.SubOrderTwoGroups((InteractionPoint x) => x.Parent.Parent.OrderByRole(r) == 0);
			}
			if (PathToFurniture(furns, warning))
			{
				if (usingPoint != null)
				{
					usingPoint.UsedBy = null;
				}
				return 1;
			}
			bool flag = false;
			if (QueuedFor(name))
			{
				InteractionPoint interactionPoint2 = InQueue[name];
				flag = true;
				float sqrMagnitude = (ActualPosition - interactionPoint2.transform.position).sqrMagnitude;
				for (int num = 0; num < interactionPoint2.CurrentQueue.Count; num++)
				{
					Actor actor2 = interactionPoint2.CurrentQueue[num];
					if (actor2.IsAliveNotNull())
					{
						if (actor2 == this)
						{
							break;
						}
						if ((actor2.ActualPosition - interactionPoint2.transform.position).sqrMagnitude > sqrMagnitude)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					if (PathToFurniture(interactionPoint2, warning))
					{
						if (CurrentPath.Count > 1)
						{
							Vector2 vector = (CurrentPath.Last() - interactionPoint2.transform.forward * 0.4f).FlattenVector3();
							Vector2? pos;
							Vector2? vector2 = (interactionPoint2.Parent.Parent.GetNavOrClosest(vector, out pos) ? new Vector2?(vector) : pos);
							if (vector2.HasValue)
							{
								CurrentPath[CurrentPath.Count - 1] = vector2.Value.ToVector3(CurrentPath.Last().y);
							}
						}
						CutBathroomPath(interactionPoint2);
						WaitingForQueue = 0f;
						return 1;
					}
					flag = false;
					RemoveFromQueue(name);
				}
			}
			if (!flag && usingPoint != null)
			{
				AtFurniture = true;
				UsingPoint = usingPoint;
				if (UsingPoint.Action == InteractionPoint.ActionType.Use)
				{
					CheckOnHead(usingPoint.Parent);
					if (UsingPoint.Parent.OnWhenUsed)
					{
						UsingPoint.Parent.IsOn = true;
					}
				}
			}
			return 0;
		}
		if (CurrentPath == null)
		{
			if (PathToFurniture(UsingPoint, warning))
			{
				return 1;
			}
			UsingPoint = null;
			return 0;
		}
		bool num2 = WalkPath();
		if (num2)
		{
			AtFurniture = true;
			if (UsingPoint != null && UsingPoint.Action == InteractionPoint.ActionType.Use)
			{
				CheckOnHead(UsingPoint.Parent);
				if (UsingPoint.Parent.OnWhenUsed && UsingPoint.Action == InteractionPoint.ActionType.Use)
				{
					UsingPoint.Parent.IsOn = true;
				}
			}
		}
		if (!num2)
		{
			return 1;
		}
		return 2;
	}

	public void CutBathroomPath(InteractionPoint ip)
	{
		if (CurrentPath != null && "Toilet".Equals(ip.Parent.Type))
		{
			int num = CurrentPath.Count - 1;
			while (num >= 2 && GameSettings.Instance.sRoomManager.GetRoomFromPoint(CurrentPath[num]) == ip.Parent.Parent)
			{
				CurrentPath.RemoveAt(num);
				num--;
			}
		}
	}

	public int WaitForTimer(float time)
	{
		if (Timer == -1f)
		{
			Timer = time;
		}
		Timer -= Time.deltaTime * GameSettings.GameSpeed;
		if (Timer < 0f)
		{
			Timer = -1f;
			return 2;
		}
		return 1;
	}

	public void MeetingBoost()
	{
		Team team = GetTeam();
		if (team != null && team.Leader.IsAliveNotNull())
		{
			Employee employee = team.Leader.employee;
			float num = employee.GetSkill(Employee.EmployeeRole.Lead) * employee.ModTrait(Employee.Trait.BornLeader, 2f) * currentRoom.Acoustics;
			this.employee.AddMood("MeetingGreat", this, Time.deltaTime, num);
			if (this.employee.IsRole(Employee.RoleBit.Lead))
			{
				this.employee.ChangeSkill(Employee.EmployeeRole.Lead, 0.04f * currentRoom.Acoustics * currentRoom.GetAuraValue(Furniture.AuraTypes.Skill), true);
			}
			this.employee.ChangeSkill((Employee.EmployeeRole)UnityEngine.Random.Range(1, 5), num * 0.2f * currentRoom.GetAuraValue(Furniture.AuraTypes.Skill), true);
		}
	}

	public WorkItem MyWorkItem()
	{
		return MyWorkItem(CurrentWorkItem);
	}

	public WorkItem MyWorkItem(int i)
	{
		int count = AutoDevs.Count;
		int num = 0;
		if (Team != null)
		{
			num = GetTeam().WorkItems.Count;
			count += num;
			if (count > 0)
			{
				i %= count;
			}
			if (num > 0 && i < num)
			{
				return GetTeam().WorkItems[i];
			}
		}
		else if (count > 0)
		{
			i %= count;
		}
		if (AutoDevs.Count > 0)
		{
			return AutoDevs[i - num];
		}
		return null;
	}

	public int GetWorkCount()
	{
		int num = AutoDevs.Count;
		if (Team != null)
		{
			num += GetTeam().WorkItems.Count;
		}
		return num;
	}

	public void WorkBoost()
	{
		WorkItem workItem = MyWorkItem();
		if (workItem == null)
		{
			return;
		}
		Employee.EmployeeRole? employeeRole = workItem.GetBoostRole(this, SecondaryWork);
		if (!employeeRole.HasValue)
		{
			return;
		}
		float num = 0f;
		float num2 = 0f;
		bool flag = employeeRole.Value != Employee.EmployeeRole.Lead && employee.IsRole(Employee.RoleBit.Lead);
		if (flag && UnityEngine.Random.value > 0.25f)
		{
			employeeRole = Employee.EmployeeRole.Lead;
			num = employee.GetSkill(employeeRole.Value);
			num2 = 1f;
		}
		else
		{
			num = employee.GetSkill(employeeRole.Value);
			num2 = workItem.GetWorkBoost(employeeRole.Value, num);
			if (flag)
			{
				num2 *= 0.5f;
			}
		}
		employee.AddMood("LoveWork", this, Time.deltaTime, num);
		employee.ChangeSkill(employeeRole.Value, Mathf.Max(0f, 0.015f * num2 * currentRoom.GetAuraValue(Furniture.AuraTypes.Skill) * workItem.StressMultiplier()), true);
	}

	public TableScript FindFreeTable(Room.RoomLimits limit, bool largerIsBetter, bool emptyTables, bool preferTeam, int maxDistance = -1)
	{
		List<KeyValuePair<Room, int>> connectedRooms = GameSettings.Instance.sRoomManager.GetConnectedRooms(currentRoom);
		float num = (largerIsBetter ? 0f : float.MaxValue);
		float num2 = (largerIsBetter ? 0f : float.MaxValue);
		bool flag = false;
		int num3 = ((team == null) ? 1 : team.Count);
		TableScript tableScript = null;
		HashSet<int> hashSet = ValidLimits[limit];
		TableScript tableScript2 = null;
		if (preferTeam)
		{
			for (int i = 0; i < connectedRooms.Count; i++)
			{
				KeyValuePair<Room, int> keyValuePair = connectedRooms[i];
				if (!keyValuePair.Key.IsAliveNotNull() || keyValuePair.Key.BuildingOnFire || !(keyValuePair.Key.Burn <= 0f) || !keyValuePair.Key.Teams.Contains(team) || !keyValuePair.Key.CompatibleWithTeam(team) || !hashSet.Contains(keyValuePair.Key.ForceRole))
				{
					continue;
				}
				if (maxDistance > 0 && keyValuePair.Value > maxDistance)
				{
					break;
				}
				for (int j = 0; j < keyValuePair.Key.TableParents.Count; j++)
				{
					TableScript tableScript3 = keyValuePair.Key.TableParents[j];
					if (tableScript3 == null || (tableScript3.transform.position - ActualPosition).sqrMagnitude > 2500f || tableScript3.TableReserved != -1)
					{
						continue;
					}
					int num4 = tableScript3.CountFreeChairs(emptyTables, true);
					float num5 = (float)num4 / Mathf.Sqrt(keyValuePair.Value + 1);
					if (keyValuePair.Key.ForceRole != (int)limit)
					{
						if (!flag && num5 > num2)
						{
							if (num4 >= num3)
							{
								flag = true;
							}
							num2 = num5;
							tableScript2 = tableScript3;
						}
					}
					else if (num5 > num)
					{
						num = num5;
						tableScript = tableScript3;
						if (num4 >= num3)
						{
							return tableScript;
						}
					}
				}
			}
			if (tableScript != null)
			{
				return tableScript;
			}
			if (tableScript2 != null)
			{
				return tableScript2;
			}
		}
		for (int k = 0; k < connectedRooms.Count; k++)
		{
			KeyValuePair<Room, int> keyValuePair2 = connectedRooms[k];
			if (!keyValuePair2.Key.IsAliveNotNull() || keyValuePair2.Key.BuildingOnFire || !(keyValuePair2.Key.Burn <= 0f) || !keyValuePair2.Key.IsNeutral(limit == Room.RoomLimits.Meeting) || !keyValuePair2.Key.CompatibleWithTeam(team) || !hashSet.Contains(keyValuePair2.Key.ForceRole))
			{
				continue;
			}
			if (maxDistance > 0 && keyValuePair2.Value > maxDistance)
			{
				break;
			}
			for (int l = 0; l < keyValuePair2.Key.TableParents.Count; l++)
			{
				TableScript tableScript4 = keyValuePair2.Key.TableParents[l];
				if (tableScript4 == null || ((!preferTeam || tableScript4.TableReserved != -1) && (preferTeam || tableScript4.TableReserved >= 1)) || tableScript4.CountFreeChairs(emptyTables, false) == 0 || (tableScript4.transform.position - ActualPosition).sqrMagnitude > 2500f)
				{
					continue;
				}
				float num6 = tableScript4.CountFreeChairs(emptyTables, true);
				if (!largerIsBetter)
				{
					num6 *= Mathf.Sqrt(keyValuePair2.Value + 1);
					if (keyValuePair2.Key.ForceRole != (int)limit)
					{
						if (num6 < num2)
						{
							num2 = num6;
							tableScript2 = tableScript4;
						}
					}
					else if (num6 < num)
					{
						num = num6;
						tableScript = tableScript4;
					}
					continue;
				}
				float num7 = num6;
				num6 /= Mathf.Sqrt(keyValuePair2.Value + 1);
				if (keyValuePair2.Key.ForceRole != (int)limit)
				{
					if (!flag && num6 > num2)
					{
						if (preferTeam && num7 >= (float)num3)
						{
							flag = true;
						}
						num2 = num6;
						tableScript2 = tableScript4;
					}
				}
				else if (num6 > num)
				{
					num = num6;
					tableScript = tableScript4;
					if (preferTeam && num7 >= (float)num3)
					{
						return tableScript;
					}
				}
			}
		}
		return tableScript ?? tableScript2;
	}

	public List<Actor> CallForMeeting()
	{
		Team obj = GetTeam();
		int count = obj.MeetingTable.CountFreeChairs(false, false);
		List<Actor> list = (from x in obj.GetEmployees()
			where x.AItype == AI.AIType.Employee && x.isActiveAndEnabled
			orderby x.LastMeeting.ToInt()
			select x).ToList();
		list.Remove(this);
		return list.Take(count).ToList();
	}

	public void ChangeRole(Employee.EmployeeRole role, bool secondary, bool active)
	{
		Employee.RoleBit roleBit = Employee.RoleToMask[(int)role];
		if (!active)
		{
			ChangeRole(~roleBit & employee.CurrentRoleBit, ~roleBit & employee.SecondaryRole);
		}
		else if (secondary)
		{
			ChangeRole(~roleBit & employee.CurrentRoleBit, roleBit | employee.SecondaryRole);
		}
		else
		{
			ChangeRole(roleBit | employee.CurrentRoleBit, employee.SecondaryRole);
		}
	}

	public void ChangeRole(Employee.RoleBit roles, Employee.RoleBit sRoles)
	{
		Team team = GetTeam();
		Employee.RoleBit currentRoleBit = employee.CurrentRoleBit;
		if (employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead))
		{
			roles &= ~Employee.RoleBit.Lead;
		}
		if (team != null && team.MeetingTable != null)
		{
			roles = ((!employee.IsRole(Employee.EmployeeRole.Lead)) ? (roles & ~Employee.RoleBit.Lead) : (roles | Employee.RoleBit.Lead));
		}
		if ((roles & Employee.RoleBit.Lead) > Employee.RoleBit.None)
		{
			if (team != null)
			{
				if (team.Leader != null && team.Leader != this)
				{
					team.Leader.ChangeRole(Employee.EmployeeRole.Lead, false, false);
				}
				team.Leader = this;
				employee.SetRoles(roles, sRoles);
			}
		}
		else
		{
			if (employee.IsRole(Employee.RoleBit.Lead))
			{
				KillAutoDev();
				if (team != null)
				{
					team.Leader = null;
				}
			}
			employee.SetRoles(roles, sRoles);
		}
		NegotiateSalary = employee.Salary < employee.Worth() && !WorksForFree() && !employee.Dismissed;
		if (team == null)
		{
			return;
		}
		team.CalculateCompatibility();
		if ((currentRoleBit & Employee.RoleBit.Designer) <= Employee.RoleBit.None || (roles & Employee.RoleBit.Designer) != Employee.RoleBit.None)
		{
			return;
		}
		if (HUD.Instance.docWindow.Window.Shown && HUD.Instance.docWindow.LeadDesigner.CurrentEmployee == employee)
		{
			HUD.Instance.docWindow.PickBestLead(true);
		}
		foreach (DesignDocument item in team.WorkItems.OfType<DesignDocument>())
		{
			if (item.LeadDesigner == employee)
			{
				item.ResetLeadDesigner();
			}
		}
	}

	public void ShutdownPC()
	{
		if (UsingPoint != null && UsingPoint.Parent.Type.Equals("Computer"))
		{
			UsingPoint.Parent.IsOn = false;
		}
	}

	public float GetPCAddonBonus(Employee.EmployeeRole role)
	{
		return UsingPoint.Parent.GetEffectivenessValue(role);
	}

	public bool IsCrunching()
	{
		if (!employee.Founder && team != null)
		{
			return GetTeam().CrunchMode;
		}
		return false;
	}

	private float GetCrunchBuff(float crunchHours)
	{
		if (crunchHours < 7f)
		{
			return 0.5f + 0.5f * (1f - crunchHours / 7f);
		}
		if (crunchHours < 21f)
		{
			return 0.1f + 0.4f * (1f - (crunchHours - 7f) / 14f);
		}
		return 0.1f;
	}

	private WorkItem.HasWorkReturn ActuallyHasWork(WorkItem work)
	{
		if (work.Paused)
		{
			return WorkItem.HasWorkReturn.Ignore;
		}
		if (employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead) && !(work is DesignDocument))
		{
			return WorkItem.HasWorkReturn.NotApplicable;
		}
		return work.HasWork(this, SecondaryWork, true);
	}

	public void ThrowTrash(int type)
	{
		Room room = currentRoom;
		if (room.Outside || room.Outdoors || room.Pillar)
		{
			return;
		}
		bool flag = false;
		if (type == 1 && UsingPoint != null && "Computer".Equals(UsingPoint.Parent.Type))
		{
			TrashCan trashCan = UsingPoint.Parent.GetTrashCan();
			if (trashCan != null && !trashCan.IsFull())
			{
				trashCan.AddTrash();
				flag = true;
			}
		}
		if (!flag)
		{
			room.AddDirt(ActualPosition.FlattenVector3() + UnityEngine.Random.insideUnitCircle, 1f, null, type);
		}
	}

	public void TrashUpdate(float delta, int type, float minutes)
	{
		if (!IsEmployee() || !employee.HasTrait(Employee.Trait.Clean))
		{
			_trashTimer += delta / minutes;
			if (_trashTimer > 1f)
			{
				_trashTimer = UnityEngine.Random.Range(-0.1f, 0.1f);
				ThrowTrash(type);
			}
		}
	}

	public void DoWork(float delta)
	{
		if (!AIScript.HasFlag(AI.NodeFlag.Working))
		{
			return;
		}
		if (employee.HasTrait(Employee.Trait.Cupholder) && SDateTime.GetMonthsFlat(employee.Hired, SDateTime.Now()) > 6 && UsingPoint != null && UsingPoint.Parent.HasUpg && Utilities.GetRandomChance(SDateTime.Now(), employee.Name, (int)UsingPoint.Parent.DID, 77 * GameSettings.DaysPerMonth))
		{
			SetTraitView(Employee.Trait.Cupholder, 0, 30, true);
			UsingPoint.Parent.upg.BreakNow();
			return;
		}
		if (employee.HasTrait(Employee.Trait.RGBThumb) && UsingPoint != null && UsingPoint.Parent.HasUpg)
		{
			UsingPoint.Parent.upg.Quality = Mathf.Min(1f, UsingPoint.Parent.upg.Quality + Utilities.PerHour(0.1f, delta));
		}
		WorkItem workItem = MyWorkItem();
		if (workItem != null && Effectiveness > 0f)
		{
			float num = 1f;
			WorkItem.HasWorkReturn hasWorkReturn = ActuallyHasWork(workItem);
			if (hasWorkReturn == WorkItem.HasWorkReturn.True || hasWorkReturn == WorkItem.HasWorkReturn.Secondary)
			{
				TrashUpdate(delta * GameSettings.GameSpeed, 1, 60f);
				bool flag = Team != null && GetTeam().SecondaryTasks.Contains(workItem.GetTypeName());
				if (!flag && hasWorkReturn == WorkItem.HasWorkReturn.True)
				{
					SecondaryWork = false;
				}
				if (hasWorkReturn != WorkItem.HasWorkReturn.Secondary && !flag)
				{
					SecondaryTask = false;
				}
				bool flag2 = IsCrunching();
				num = workItem.StressMultiplier();
				if (flag2)
				{
					employee.AddMood("CrunchTimeProb", this, delta, num * 0.333f);
					CrunchHangover = Mathf.Min(288f, CrunchHangover + Utilities.PerHour(6f * num, delta) / (float)GameSettings.DaysPerMonth);
					num *= 2f;
				}
				if (employee.Founder && !(workItem is AutoDevWorkItem))
				{
					num *= 0.25f;
				}
				if (WorkCyclesLeft == 1)
				{
					LastWorkItems[LastWorkCounter] = workItem.ID;
					LastWorkCounter = (LastWorkCounter + 1) % LastWorkItems.Length;
				}
				IsWorking = true;
				MakeUnIdle();
				float num2 = 1f;
				if (employee.HasTrait(Employee.Trait.BornLeader))
				{
					if (workItem.IsLeaderTask())
					{
						num2 *= 1.25f;
					}
					else
					{
						SetTraitView(Employee.Trait.BornLeader, 0, 5, false, HUD.GetThemeColor(2));
						num2 *= 0.25f;
					}
				}
				workItem.DoWork(this, num2 * Effectiveness * (flag2 ? 3f : 1f), delta, SecondaryWork);
				workItem.AddLoss(Utilities.PerHour(GetRealSalary() / (float)GameSettings.DaysPerMonth, delta));
				EmitType = workItem.EmitType(this, SecondaryWork);
				workItem.HandleNetworkEnding(false);
			}
			else
			{
				WorkCyclesLeft = 0;
				IsWorking = hasWorkReturn == WorkItem.HasWorkReturn.Pretend;
				if (!IsWorking)
				{
					GameSettings.Instance.IdlePay += Utilities.PerHour(GetRealSalary() / (float)GameSettings.DaysPerMonth, delta);
				}
				EmitType = WorkParticle.None;
			}
			UpdateStateInfluence = true;
			WorkCyclesLeft--;
			if (WorkCyclesLeft <= 0)
			{
				int workCount = GetWorkCount();
				if (workCount == 0)
				{
					hasWorkReturn = WorkItem.HasWorkReturn.Ignore;
					CurrentWorkItem = 0;
					SubWorkItem = 0;
				}
				else
				{
					int num3 = 0;
					if (Team != null)
					{
						num3 = GetTeam().MaxTasks;
					}
					if (num3 > 0 && SubWorkItem >= num3)
					{
						CurrentWorkItem = workCount - 1;
						SubWorkItem = 0;
					}
					bool flag3 = false;
					bool flag4 = false;
					int num4 = -1;
					int num5 = -1;
					int num6 = -1;
					for (int i = 0; i <= workCount; i++)
					{
						CurrentWorkItem = (CurrentWorkItem + 1) % workCount;
						WorkItem workItem2 = MyWorkItem();
						if (workItem2 == null)
						{
							continue;
						}
						bool flag5 = Team != null && GetTeam().SecondaryTasks.Contains(WorkItem.GetWorkTypeName(workItem2));
						if (flag5 && !SecondaryTask)
						{
							continue;
						}
						WorkItem.HasWorkReturn hasWorkReturn2 = ActuallyHasWork(workItem2);
						int num7 = (flag5 ? 1 : 0);
						if (hasWorkReturn2 == WorkItem.HasWorkReturn.Secondary)
						{
							num7++;
						}
						if (hasWorkReturn2 == WorkItem.HasWorkReturn.True)
						{
							if (!flag5 || num3 <= 0)
							{
								hasWorkReturn = WorkItem.HasWorkReturn.True;
								flag3 = !flag5;
								flag4 = true;
								break;
							}
							if (num5 < 0 || num7 < num6)
							{
								num5 = CurrentWorkItem;
								num6 = num7;
							}
						}
						if (hasWorkReturn2 == WorkItem.HasWorkReturn.Secondary)
						{
							if (num3 <= 0)
							{
								hasWorkReturn = WorkItem.HasWorkReturn.True;
								flag4 = true;
								break;
							}
							if (num5 < 0 || num7 < num6)
							{
								num5 = CurrentWorkItem;
								num6 = num7;
							}
						}
						if (hasWorkReturn2 == WorkItem.HasWorkReturn.Pretend)
						{
							num4 = CurrentWorkItem;
						}
						if (hasWorkReturn2 > hasWorkReturn)
						{
							hasWorkReturn = hasWorkReturn2;
						}
					}
					if (!flag4 && num5 >= 0)
					{
						CurrentWorkItem = num5;
						hasWorkReturn = WorkItem.HasWorkReturn.True;
						flag4 = true;
					}
					bool flag6 = !flag4 && num4 > -1;
					SecondaryWork = !flag3 && !flag6;
					SecondaryTask = !flag3 && !flag6;
					if (flag6)
					{
						CurrentWorkItem = num4;
					}
					if (num3 > 0)
					{
						if (hasWorkReturn.IsWork())
						{
							SubWorkItem++;
						}
						else
						{
							SubWorkItem = 0;
						}
					}
				}
				WorkItem workItem3 = MyWorkItem();
				WorkCyclesLeft = ((workItem3 == null) ? 1 : workItem3.Priority);
			}
			switch (hasWorkReturn)
			{
			case WorkItem.HasWorkReturn.True:
			case WorkItem.HasWorkReturn.Waiting:
			case WorkItem.HasWorkReturn.Secondary:
			case WorkItem.HasWorkReturn.Pretend:
				MakeUnIdle();
				break;
			case WorkItem.HasWorkReturn.Finished:
				MakeIdle(WorkStatus.NoActiveWork);
				break;
			case WorkItem.HasWorkReturn.NotApplicable:
				MakeIdle(WorkStatus.NotApplicable);
				break;
			default:
				MakeIdle(WorkStatus.NoWork);
				break;
			}
			StressFactor = -1f;
			if (IsWorking)
			{
				StressFactor = (float)JobDiffCount() * num;
			}
		}
		else
		{
			if (workItem == null)
			{
				MakeIdle(WorkStatus.NoWork);
			}
			else if (Effectiveness <= 0f)
			{
				MakeIdle(WorkStatus.NoEffectiveness);
			}
			IsWorking = false;
			GameSettings.Instance.IdlePay += Utilities.PerHour(GetRealSalary() / (float)GameSettings.DaysPerMonth, delta);
			UpdateStateInfluence = true;
		}
	}

	public IEnumerable<WorkItem> GetCurrentWorkItems()
	{
		int c = GetWorkCount();
		int max = 0;
		if (Team != null)
		{
			max = GetTeam().MaxTasks;
		}
		int done = 0;
		int sLevel = 3;
		if (max > 0)
		{
			for (int i = 0; i < c; i++)
			{
				WorkItem workItem = MyWorkItem(i);
				WorkItem.HasWorkReturn hasWorkReturn = ActuallyHasWork(workItem);
				if (hasWorkReturn == WorkItem.HasWorkReturn.True || hasWorkReturn == WorkItem.HasWorkReturn.Secondary)
				{
					int num = ((Team != null && GetTeam().SecondaryTasks.Contains(WorkItem.GetWorkTypeName(workItem))) ? 1 : 0);
					if (hasWorkReturn == WorkItem.HasWorkReturn.Secondary)
					{
						num++;
					}
					sLevel = Mathf.Min(sLevel, num);
				}
			}
		}
		for (int j = 0; j < c; j++)
		{
			WorkItem workItem2 = MyWorkItem(j);
			bool flag = Team != null && GetTeam().SecondaryTasks.Contains(WorkItem.GetWorkTypeName(workItem2));
			if (flag && !SecondaryTask)
			{
				continue;
			}
			WorkItem.HasWorkReturn hasWorkReturn2 = ActuallyHasWork(workItem2);
			if (hasWorkReturn2 != WorkItem.HasWorkReturn.True && hasWorkReturn2 != WorkItem.HasWorkReturn.Secondary && hasWorkReturn2 != WorkItem.HasWorkReturn.Pretend && hasWorkReturn2 != WorkItem.HasWorkReturn.Waiting)
			{
				continue;
			}
			if (max > 0)
			{
				int num2 = (flag ? 1 : 0);
				if (hasWorkReturn2 == WorkItem.HasWorkReturn.Secondary)
				{
					num2++;
				}
				if (num2 > sLevel)
				{
					continue;
				}
			}
			if (hasWorkReturn2 == WorkItem.HasWorkReturn.True || hasWorkReturn2 == WorkItem.HasWorkReturn.Secondary)
			{
				done++;
			}
			yield return workItem2;
			if (max > 0 && done >= max)
			{
				break;
			}
		}
	}

	public IEnumerable<string> GetCurrentTasks()
	{
		foreach (WorkItem currentWorkItem in GetCurrentWorkItems())
		{
			yield return currentWorkItem.Name;
		}
	}

	private int JobDiffCount()
	{
		int num = 0;
		for (int i = 0; i < LastWorkItems.Length; i++)
		{
			if (LastWorkItems[i] == 0)
			{
				continue;
			}
			num++;
			for (int j = 0; j < i; j++)
			{
				if (LastWorkItems[j] == LastWorkItems[i])
				{
					num--;
					break;
				}
			}
		}
		_lastJobDiff = num;
		return num;
	}

	public float Affect(Affector cat, float value, float lowerCutoff = 1f, bool force = false)
	{
		value = ((value > lowerCutoff && value < 1f) ? 1f : value);
		if (!force && employee.Founder && value <= 1f)
		{
			return 1f;
		}
		Affactors[(int)cat] = value - 1f;
		return value;
	}

	public void FakeAffect(Affector cat, float value)
	{
		Affactors[(int)cat] = value - 1f;
	}

	public void NoAffect(Affector cat, bool remove = false)
	{
		if (remove)
		{
			Affactors[(int)cat] = -2f;
		}
		else
		{
			Affactors[(int)cat] = 0f;
		}
	}

	public void AddMoodNotification(ActorMoodNotification.Issue issue)
	{
		if (!NotificationManager.CheckAggregate<ActorMoodNotification>(employee, (uint)issue))
		{
			NotificationManager.AddNotification(new ActorMoodNotification(issue, employee));
		}
	}

	public float GetStateInfluence(float delta)
	{
		float num = 1f;
		bool flag = IsWorking && AIScript.currentNode != null && AIScript.HasFlag(AI.NodeFlag.Working);
		BreachedDemands = LeadDesignDemands.Demand.Fire;
		num *= Affect(Affector.Energy, 1f - Mathf.Pow(1f - employee.Energy, 3f), employee.ModTrait(Employee.Trait.Capacitor, 0.7f, 0.85f), true);
		if (!currentRoom.Outside && flag)
		{
			float num2 = Mathf.Max(0f, 1f - Mathf.Abs(21f - currentRoom.Temperature) / 24f);
			bool flag2 = currentRoom.Temperature < 21f;
			if (!employee.HasTrait(Employee.Trait.ThisIsFine) && (!employee.HasTrait(Employee.Trait.Sunshine) || flag2))
			{
				num2 = Mathf.Pow(num2, 2f);
			}
			num *= Affect(Affector.Temperature, num2, 0.5f, true);
			if ((double)num2 < 0.5)
			{
				employee.AddMood(flag2 ? "IsFreezing" : "IsBurning", this, delta, 0.5f - num2);
				if (num2 < 0.3f && flag)
				{
					AddMoodNotification((!flag2) ? ActorMoodNotification.Issue.BurningWarning : ActorMoodNotification.Issue.FreezingWarning);
				}
			}
		}
		else
		{
			NoAffect(Affector.Temperature);
		}
		if (employee.InteractedWithBestFriend)
		{
			num *= Affect(Affector.BestFriend, 1.25f);
		}
		else
		{
			NoAffect(Affector.BestFriend, true);
		}
		if (employee.Stress < 0.5f)
		{
			num *= Affect(Affector.Stress, employee.Stress * 2f, 1f, true);
		}
		else
		{
			NoAffect(Affector.Stress);
		}
		if (!employee.Founder)
		{
			num *= Affect(Affector.Hunger, 1f - Mathf.Pow(1f - employee.Hunger, 3f), 0.25f);
			if (employee.HasDemanded(LeadDesignDemands.Demand.LuxuryMeal) && employee.Hunger < 0.1f)
			{
				BreachedDemands |= LeadDesignDemands.Demand.LuxuryMeal;
			}
			num *= Affect(Affector.Bladder, 1f - Mathf.Pow(1f - employee.Bladder, 5f), 0.25f);
			num *= Affect(Affector.JobSatisfaction, Utilities.PosNeg(1f - Mathf.Pow(1f - employee.JobSatisfaction, 3f), 0.1f, 1.5f));
			if (BadBack)
			{
				num *= Affect(Affector.BadBack, employee.Posture.MapRange(0f, 1f, 0.5f, 1f));
			}
			if (employee.Social < 0.5f)
			{
				num *= Affect(Affector.Social, 0.25f + employee.Social * 1.5f);
			}
			else
			{
				NoAffect(Affector.Social);
			}
			if (!IsCrunching() && CrunchHangover > 0f)
			{
				num *= Affect(Affector.CrunchHangover, GetCrunchBuff(CrunchHangover));
			}
			else
			{
				NoAffect(Affector.CrunchHangover, true);
			}
			if (employee.Dismissed)
			{
				num *= Affect(Affector.Fired, 0.5f);
			}
			if (!currentRoom.Outside && flag)
			{
				float auraValue = currentRoom.GetAuraValue(Furniture.AuraTypes.Effectiveness);
				num *= Affect(Affector.RoomAura, auraValue);
			}
		}
		if (Team != null && !employee.HasTrait(Employee.Trait.Detached))
		{
			num *= Affect(Affector.TeamCompatibility, Utilities.PosNeg(TeamCompatibility, 0.25f, 1.12f), 1f, true);
		}
		if (employee.HasTrait(Employee.Trait.NightOwl))
		{
			if (NightOwlDebuff > 0f)
			{
				num *= Affect(Affector.TraitNightOwl, NightOwlDebuff.MapRange(0f, 1f, 1f, 0.5f));
			}
			else
			{
				NoAffect(Affector.TraitNightOwl, true);
			}
		}
		if (WasSick)
		{
			num *= Affect(Affector.TraitJustTheFlu, 0.75f);
			SetTraitView(Employee.Trait.JustTheFlu, 0, 5, false, HUD.GetThemeColor(2));
		}
		else
		{
			NoAffect(Affector.TraitJustTheFlu, true);
		}
		if (employee.HasTrait(Employee.Trait.UnderTheWeather))
		{
			if (TimeOfDay.Instance.RainFactor > 0f)
			{
				num *= Affect(Affector.TraitUnderTheWeather, 0.8f, 1f, true);
				SetTraitView(Employee.Trait.UnderTheWeather, 0, 5);
			}
			else
			{
				NoAffect(Affector.TraitUnderTheWeather);
			}
		}
		if (employee.HasTrait(Employee.Trait.Claustrophobic))
		{
			float num3 = ClaustrophobiaFactor();
			if (num3 > 0f)
			{
				num *= Affect(Affector.TraitClaustrophobic, 1f - num3 * 0.5f, 1f, true);
				SetTraitView(Employee.Trait.Claustrophobic, 0, 5);
			}
			else
			{
				NoAffect(Affector.TraitClaustrophobic);
			}
		}
		if (employee.HasTrait(Employee.Trait.Sunshine))
		{
			if (TimeOfDay.Instance.RainFactor <= 0f && TimeOfDay.Instance.SnowAmount <= 0f && TimeOfDay.Instance.Temperature > 21f)
			{
				num *= Affect(Affector.TraitSunshine, 1.15f, 1f, true);
				SetTraitView(Employee.Trait.Sunshine, 0, 5);
			}
			else
			{
				NoAffect(Affector.TraitSunshine);
			}
		}
		if (employee.HasTrait(Employee.Trait.Skyscraper))
		{
			if (currentRoom.Floor > 0)
			{
				num *= Affect(Affector.TraitSkyscraper, currentRoom.Floor.MapRange(0f, 10f, 1f, 1.25f, true));
				SetTraitView(Employee.Trait.Skyscraper, 0, 5);
			}
			else
			{
				NoAffect(Affector.TraitSkyscraper);
			}
		}
		if (!employee.HasTrait(Employee.Trait.ThisIsFine) && currentRoom.Smell > 0.25f)
		{
			num *= Affect(Affector.AirQuality, currentRoom.Smell.MapRange(0.25f, 1f, 0.95f, 0.25f, true), 1f, true);
			employee.AddMood("AirQualityBad", this, delta, currentRoom.Smell.MapRange(0.25f, 1f, 0.2f, 1f, true));
		}
		else
		{
			NoAffect(Affector.AirQuality);
		}
		if (UsingPoint != null && flag)
		{
			if (BeingMentored)
			{
				num *= Affect(Affector.Mentoring, 0.75f, 1f, true);
			}
			else
			{
				NoAffect(Affector.Mentoring, true);
			}
			float num4 = UsingPoint.Parent.Parent.GetEnvironment();
			bool flag3 = false;
			if (employee.HasTrait(Employee.Trait.NeatFreak))
			{
				flag3 = true;
				num4 *= UsingPoint.Parent.Parent.DirtScore;
				if (num4 < 1f)
				{
					num4 *= num4;
				}
			}
			float num5 = UsingPoint.Parent.GetComfort();
			if (employee.HasTrait(Employee.Trait.ThisIsFine))
			{
				if (!flag3 && num4 < 1f)
				{
					num4 = (num4 + 1f) * 0.5f;
				}
				if (num5 < 1f)
				{
					num5 = (num5 + 1f) * 0.5f;
				}
			}
			if (employee.HasTrait(Employee.Trait.SuperFocus))
			{
				if (_lastJobDiff > 0)
				{
					SetTraitView(Employee.Trait.SuperFocus, 0, 5, false, (_lastJobDiff == 1) ? HUD.GetThemeColor(0) : HUD.GetThemeColor(2));
				}
				num *= Affect(Affector.TraitSuperFocus, (_lastJobDiff <= 1) ? 1.3f : 0.7f, 1f, true);
			}
			num *= Affect(Affector.Environment, Utilities.PosNeg(num4, employee.ModTrait(Employee.Trait.NeatFreak, 0.25f, 0.5f), 1.12f), employee.ModTrait(Employee.Trait.NeatFreak, 1f, 0.75f), true);
			num *= Affect(Affector.Comfort, Utilities.PosNeg(num5, 0.5f, 1.1f), 0.75f);
			if (UsingPoint.Parent.HasUpg)
			{
				Upgradable upg = UsingPoint.Parent.upg;
				if (UsingPoint.Parent.Type.Equals("Computer"))
				{
					float num6 = UsingPoint.Parent.FinalNoise * (1f - UsingPoint.Parent.GetUseEffect(Furniture.UseEffect.NoiseCancelling));
					num6 *= num6;
					if (employee.HasTrait(Employee.Trait.ThisIsFine) && num6 < 0.75f)
					{
						num6 = 0.1f;
					}
					num *= Affect(Affector.Noise, 0.1f + (1f - num6) * 0.9f, employee.ModTrait(Employee.Trait.ThisIsFine, 0.8f), true);
					if (num6 > 0.25f && flag)
					{
						employee.AddMood("NoiseComplaint", this, delta, num6);
					}
					if (num6 == 0f)
					{
						employee.AddMood("NoNoiseGood", this, delta);
					}
					float rawEffectivenessValue = UsingPoint.Parent.GetRawEffectivenessValue();
					if (rawEffectivenessValue < 1f)
					{
						FakeAffect(Affector.Computer, rawEffectivenessValue);
						if (upg.Quality < 0.25f || UsingPoint.Parent.ComputerPower < 0.5f)
						{
							float num7 = Mathf.Min(upg.Quality, UsingPoint.Parent.ComputerPower);
							employee.AddMood("ComputerBad", this, delta, Mathf.Max(0f, 1f - num7 * 4f));
						}
					}
					else
					{
						NoAffect(Affector.Computer);
					}
				}
			}
			else
			{
				NoAffect(Affector.Computer);
			}
			if (!employee.Founder)
			{
				float num8 = 1f - Mathf.Pow(UsingPoint.Parent.Parent.DarknessLevel, 3f);
				if (num8 < 1f && employee.HasTrait(Employee.Trait.ThisIsFine))
				{
					num8 = (num8 + 1f) * 0.5f;
				}
				if ((double)num8 < 0.5)
				{
					employee.AddMood("NoSee", this, delta, 0.5f - num8);
					if (num8 < 0.2f && flag)
					{
						AddMoodNotification(ActorMoodNotification.Issue.NoSeeWarning);
					}
				}
				num *= Affect(Affector.Lighting, 0.25f + 0.75f * num8, 0.7f);
				if (num4 < employee.ModTrait(Employee.Trait.NeatFreak, 1f, 0.5f))
				{
					employee.AddMood((UsingPoint.Parent.Parent.FurnEnvironment < UsingPoint.Parent.Parent.DirtScore) ? "RoomLowEnv" : "RoomDirty", this, delta, 1f - num4);
				}
				else if (num4 > 1f)
				{
					employee.AddMood("RoomNotDirty", this, delta, num4);
				}
				float auraValue2 = currentRoom.GetAuraValue(Furniture.AuraTypes.Mood);
				if (auraValue2 > 1f)
				{
					employee.SetMood("RoomAuraBoost", this, auraValue2 - 1f);
				}
				else if (auraValue2 < 1f)
				{
					employee.SetMood("RoomAuraDebuff", this, 1f - auraValue2);
				}
				if (num5 < 0.75f)
				{
					employee.AddMood("UncomfortableFurniture", this, delta, (0.75f - num5) / 0.75f);
				}
			}
			if (employee.HasDemanded(LeadDesignDemands.Demand.PrivateOffice) && UsingPoint.Parent.Parent.Occupants.Any((Actor x) => x != this && x.AItype == AI.AIType.Employee && x.AtFurniture && x.UsingPoint != null && "Computer".Equals(x.UsingPoint.Parent.Type)))
			{
				Furniture furniture = Owns.FirstOrDefault((Furniture x) => x.Type.Equals("Computer"));
				if (furniture == null || !furniture.upg.Broken)
				{
					employee.SetMood("LeadDemandBreach", this, 1f);
					BreachedDemands |= LeadDesignDemands.Demand.PrivateOffice;
					if (employee.Founder)
					{
						AddMoodNotification(ActorMoodNotification.Issue.LeadDesignBreachWarning);
					}
				}
			}
		}
		else
		{
			NoAffect(Affector.Lighting);
			NoAffect(Affector.Environment);
			NoAffect(Affector.Comfort);
			NoAffect(Affector.Computer);
			NoAffect(Affector.Noise);
			NoAffect(Affector.Mentoring, true);
		}
		if (BreachedDemands != LeadDesignDemands.Demand.Fire)
		{
			num *= Affect(Affector.DemandBreach, 0.1f, 1f, true);
		}
		else
		{
			NoAffect(Affector.DemandBreach, true);
		}
		if (!employee.HasTrait(Employee.Trait.ThisIsFine))
		{
			if (currentRoom.Floor == -1)
			{
				num *= Affect(Affector.Basement, 0.8f, 1f, true);
				employee.AddMood("BasementComplaint", this, delta);
			}
			else
			{
				NoAffect(Affector.Basement, true);
			}
			if (UsingPoint != null && AnyNonTeamWorking())
			{
				num *= Affect(Affector.OtherTeams, 0.5f, 1f, true);
				employee.AddMood("OtherTeamComplaint", this, delta);
			}
			else
			{
				NoAffect(Affector.OtherTeams);
			}
		}
		if (employee.IsRole(Employee.RoleBit.Lead) && currentRoom.Occupants.Count == 1)
		{
			num *= Affect(Affector.OwnOffice, 1.25f);
		}
		else
		{
			NoAffect(Affector.OwnOffice, true);
		}
		return num;
	}

	private bool AnyNonTeamWorking()
	{
		if (Team == null)
		{
			return false;
		}
		List<Actor> occupants = currentRoom.Occupants;
		for (int i = 0; i < occupants.Count; i++)
		{
			Actor actor = occupants[i];
			if (actor != this && actor.IsWorking && actor.enabled && actor.Team != null && !actor.GetTeam().IsTaskCompatible(GetTeam()))
			{
				return true;
			}
		}
		return false;
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		AItype = (AI.AIType)dictionary.Get("AIType", 0);
		employee = dictionary.Get<Employee>("employee", null);
		if (employee != null && employee.AgeMonth > 0)
		{
			typeof(Employee).GetField("BirthDate").SetValue(employee, TimeOfDay.GetDateLocked() - employee.AgeMonth);
		}
		Furniture furniture = (Furniture)GetDeserializedObject(dictionary.Get("UsingFurniture", 0u));
		if (furniture != null)
		{
			InteractionPoint interactionPoint = furniture.GetInteractionPoint(InteractionPoint.ActionType.Use);
			if (interactionPoint != null)
			{
				interactionPoint.UsedBy = this;
				UsingPoint = interactionPoint;
				interactionPoint.Parent.SetInteractionMesh(true);
			}
		}
		Furniture furniture2 = (Furniture)GetDeserializedObject(dictionary.Get("UsingFurniture2", 0u));
		if (furniture2 != null)
		{
			int newP = dictionary.Get("UsingPoint", 0);
			InteractionPoint interactionPoint2 = furniture2.InteractionPoints.FirstOrDefault((InteractionPoint x) => x.Id == newP);
			if (interactionPoint2 != null)
			{
				interactionPoint2.UsedBy = this;
				UsingPoint = interactionPoint2;
				interactionPoint2.Parent.SetInteractionMesh(true);
			}
		}
		Stolen = dictionary.Get("Stolen", Stolen);
		WaitingForQueue = dictionary.Get("WaitingForQueue", WaitingForQueue);
		if (employee.HasTrait(Employee.Trait.NightOwl))
		{
			NightOwlDebuff = dictionary.Get("NightOwlDebuff", 0f);
		}
		if (employee.HasTrait(Employee.Trait.JustTheFlu))
		{
			WasSick = dictionary.Get("WasSick", false);
		}
		if (employee.HasTrait(Employee.Trait.Forgetful))
		{
			ForgetfulETA = dictionary.Get("ForgetfulETA", new SDateTime(0));
		}
		uint[] array = dictionary.Get("Reservations", new uint[0]);
		foreach (uint id in array)
		{
			Furniture furniture3 = GetDeserializedObject(id) as Furniture;
			if (furniture3 != null)
			{
				furniture3.Reserved = this;
			}
		}
		if (dictionary.Contains("VacationMonthNew"))
		{
			VacationMonth = dictionary.Get("VacationMonthNew", SDateTime.NextMonth(6));
		}
		else
		{
			int month = dictionary.Get("VacationMonth", 6);
			VacationMonth = SDateTime.NextMonth(month);
		}
		AlternateVacation = dictionary.Get("AlternateVacation", VacationMonth);
		if (dictionary.Contains("CurrentPath2"))
		{
			List<PathVector> list = dictionary.Get<List<PathVector>>("CurrentPath2", null);
			if (list != null)
			{
				SetPath(PathPool.Get(), false);
				_currentPath.AddRange(list);
			}
		}
		else
		{
			SVector3[] array2 = dictionary.Get<SVector3[]>("CurrentPath", null);
			if (array2 != null)
			{
				SetPath(PathPool.Get(), false);
				_currentPath.AddRange(((IList<SVector3>)array2).Select((Func<SVector3, PathVector>)((SVector3 x) => x.ToVector3())));
			}
		}
		LastMeeting = dictionary.Get("LastMeeting", new SDateTime(1900));
		MeetingTime = dictionary.Get("MeetingTime2", SDateTime.Now());
		DriveTime = dictionary.Get("DriveTime", MeetingTime);
		PathProg = dictionary.Get("PathProg", 0f);
		PathProg = (float.IsNaN(PathProg) ? 0f : PathProg);
		LastSocial = dictionary.Get("LastSocial", employee.Hired);
		Female = employee == null || employee.Female;
		uint[] l = dictionary.Get("Owns", new uint[0]);
		Owns = l.Select(base.GetDeserializedObject).OfType<Furniture>().ToHashSet();
		Owns.ToList().ForEach(delegate(Furniture x)
		{
			x.SetOwnedByDeserializing(this);
		});
		base.transform.position = (ActualPosition = dictionary.Get("position", (SVector3)Vector3.zero).ZeroNaN().ToVector3());
		LastWorldPos = base.transform.position;
		base.transform.rotation = dictionary.Get("rotation", (SVector3)Quaternion.identity).ToQuaternion();
		int value = dictionary.Get("animation", 0);
		anim.SetInteger("AnimControl", value);
		IdleStatus = (WorkStatus)dictionary.Get("IdleStatus", 0);
		_targetActorID = dictionary.Get("TargetActor", 0u);
		_guardingID = dictionary.Get("Guarding", 0u);
		uint num2 = dictionary.Get("OnHead", 0u);
		if (num2 != 0)
		{
			SetHeadDeserialize((Furniture)GetDeserializedObject(num2));
		}
		if (IsIdle)
		{
			HUD.Instance.AddToIdle(this);
		}
		if (dictionary.Contains("AnimState"))
		{
			int num3 = (int)dictionary["AnimState"];
			if (anim.HasState(0, num3))
			{
				float normalizedTime = dictionary.Get("AnimTime", 0f);
				anim.Play(num3, 0, normalizedTime);
				anim.Update(0f);
			}
		}
		SVector3 sVector = dictionary.Get("AnimBlend", new SVector3(1f, 0f, 0f));
		SetBlend(sVector.x, sVector.y, sVector.z, sVector.w);
		Reserved = (Furniture)GetDeserializedObject(dictionary.Get("ReservedFurniture", 0u));
		string[] array3 = dictionary.Get<string[]>("Holding", null);
		if (array3 != null)
		{
			if (array3[0] != null)
			{
				GetItem(array3[0].Replace("(Clone)", ""), true);
			}
			if (array3[1] != null)
			{
				GetItem(array3[1].Replace("(Clone)", ""), false);
			}
		}
		else
		{
			Holdable.HoldableData[] array4 = dictionary.Get<Holdable.HoldableData[]>("Holding2", null);
			if (array4 != null)
			{
				if (array4[0].Type != null)
				{
					GetItem(array4[0].Type, true).Deserialize(array4[0]);
				}
				if (array4[1].Type != null)
				{
					GetItem(array4[1].Type, false).Deserialize(array4[0]);
				}
			}
		}
		if (dictionary.Get("Coffee", false))
		{
			if (Holding[0] != null && Holding[0].Type.Equals("CoffeeCup"))
			{
				coffee = Holding[0];
			}
			else if (Holding[1] != null && Holding[1].Type.Equals("CoffeeCup"))
			{
				coffee = Holding[1];
			}
		}
		Furniture furniture4 = GetDeserializedObject(dictionary.Get("LoiterTable", 0u)) as Furniture;
		if (furniture4 != null)
		{
			LoiterTable = furniture4.GetComponent<TableScript>();
		}
		CleaningRoom = GetDeserializedObject(dictionary.Get("CleaningRoom", 0u)) as Room;
		if (dictionary.Contains("CourseRole"))
		{
			Employee.EmployeeRole key = (Employee.EmployeeRole)dictionary.Get("CourseRole", 0);
			string text = dictionary.Get<string>("CourseSpec", null);
			if (text != null)
			{
				Courses.Add(new KeyValuePair<Employee.EmployeeRole, string>(key, text));
			}
		}
		else
		{
			Courses = dictionary.Get("Courses", Courses);
		}
		LastCourse = dictionary.Get("LastCourse", employee.Hired);
		CleaningPoints = new Stack<Vector3>(from x in dictionary.Get("CleaningPoints", new SVector3[0])
			select x.ToVector3());
		SkinColor = dictionary.Get("SkinColor", new SVector3(1f, 1f, 1f, 1f)).ToColor();
		HairColor = dictionary.Get("HairColor", new SVector3(1f, 0f, 0f, 1f)).ToColor();
		if (employee != null && dictionary.Contains("NewStyle"))
		{
			employee.StyleGen = dictionary.Get<ActorBodyItem.BodyItemObject[]>("NewStyle", null);
		}
		Init();
		if (dictionary.Contains("currentNode"))
		{
			BehaviorNode value2;
			if (AIScript.BehaviorNodes.TryGetValue((string)dictionary["currentNode"], out value2))
			{
				AIScript.currentNode = value2;
			}
			else
			{
				ResetState();
			}
		}
		CarColor3 = dictionary.Get("CarColor3", (CarIdx > 0 && CarIdx < ObjectDatabase.Instance.CarPrefabs.Length) ? ((SVector3)ObjectDatabase.Instance.CarPrefabs[CarIdx].GetComponent<NormalCar>().Colors.GetRandom()) : new SVector3(1f, 1f, 1f, 1f));
		int hour = dictionary.Get("LeaveTime", 16);
		SDateTime sDateTime = SDateTime.Now();
		LeaveTime = dictionary.Get("LeaveTime2", new SDateTime(0, hour, sDateTime.Day + 1, sDateTime.Month, sDateTime.Year));
		bool visible = (base.enabled = dictionary.Get("IsEnabled", false));
		anim.enabled = visible;
		SetVisible(visible);
		AssignedRoomGroups = dictionary.Get("AssignedRoomGroups", new SHashSet<string>());
		deal = dictionary.Get<Deal>("Deal", null);
		ReservedFridge = GetDeserializedObject(dictionary.Get("ReservedFridge", 0u)) as Furniture;
		if (ReservedFridge != null)
		{
			ReservedFridge.AddStock();
		}
		ReservedPort = GetDeserializedObject(dictionary.Get("ReservedPort", 0u)) as Furniture;
		if (dictionary.Contains("FoodHold"))
		{
			Food = Holding[dictionary.Get("FoodHold", 0)];
		}
		else if (dictionary.Contains("FoodChair"))
		{
			Furniture furniture5 = (Furniture)GetDeserializedObject(dictionary.Get("FoodChair", 0u));
			Food = ItemDispenser.Instance.Dispense(employee.HasDemanded(LeadDesignDemands.Demand.LuxuryMeal) ? "FoodPlateFancy" : "FoodPlate");
			if (furniture5 != null)
			{
				if (dictionary.Contains("FoodTable"))
				{
					Furniture furniture6 = (Furniture)GetDeserializedObject(dictionary.Get("FoodTable", 0u));
					if (furniture6 != null)
					{
						furniture6.Table.PlaceHoldable(Food, furniture5.InteractionPoints[0].transform);
					}
					else if (!ReTakeItem(Food, true))
					{
						Food.DestroyMe();
					}
				}
				else
				{
					int num4 = dictionary.Get("FoodPoint", 0);
					if (num4 < furniture5.InteractionPoints.Length && furniture5.Table != null)
					{
						furniture5.Table.PlaceHoldable(Food, furniture5.InteractionPoints[num4].transform);
					}
					else if (!ReTakeItem(Food, true))
					{
						Food.DestroyMe();
					}
				}
			}
			else if (!ReTakeItem(Food, true))
			{
				Food.DestroyMe();
			}
		}
		uint[] array5 = dictionary.Get<uint[]>("InspectRooms", null);
		if (array5 != null)
		{
			InspectRooms = array5.SelectNotNull((uint x) => GetDeserializedObject(x) as Room).ToHashSet();
		}
		Order = dictionary.Get("PrintOrder2", new ProductPrintOrder());
		return this;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["IsEnabled"] = mode.Is(GameReader.NewLoadMode.Full) && base.isActiveAndEnabled;
		dictionary["VacationMonthNew"] = VacationMonth;
		dictionary["AlternateVacation"] = AlternateVacation;
		if (InspectRooms != null)
		{
			dictionary["InspectRooms"] = InspectRooms.SelectNotNull((Room x) => x.DID).ToArray();
		}
		if (mode.Is(GameReader.NewLoadMode.Full))
		{
			dictionary["UsingFurniture2"] = ((!(UsingPoint == null)) ? UsingPoint.Parent.DID : 0u);
			dictionary["UsingPoint"] = ((!(UsingPoint == null)) ? UsingPoint.Id : 0);
			dictionary["Reservations"] = (from x in GameSettings.Instance.sRoomManager.AllFurniture
				where x.IsAliveNotNull() && x.Reserved == this
				select x.DID).ToArray();
			dictionary["Owns"] = (from x in Owns
				where x != null && x.OwnedBy == this
				select x.DID).ToArray();
			dictionary["CurrentPath2"] = CurrentPath;
			dictionary["PathProg"] = PathProg;
			dictionary["Timer"] = Timer;
			dictionary["currentNode"] = AIScript.currentNode.Name;
			dictionary["position"] = (SVector3)ActualPosition;
			dictionary["rotation"] = (SVector3)base.transform.rotation;
			dictionary["animation"] = anim.GetInteger("AnimControl");
			dictionary["AnimState"] = anim.GetCurrentAnimatorStateInfo(0).shortNameHash;
			dictionary["AnimTime"] = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
			dictionary["AnimBlend"] = GetBlend();
			dictionary["LoiterTable"] = ((!(LoiterTable == null)) ? LoiterTable.FurnComp.DID : 0u);
			dictionary["CleaningRoom"] = ((!(CleaningRoom == null)) ? CleaningRoom.DID : 0u);
			dictionary["Holding2"] = Holding.SelectInPlace((Holdable x) => (!(x == null)) ? x.Serialize() : new Holdable.HoldableData(null));
			dictionary["Coffee"] = coffee != null;
			dictionary["IdleStatus"] = (int)IdleStatus;
			dictionary["WaitingForQueue"] = WaitingForQueue;
			if (Food != null)
			{
				if (Holding[0] == Food)
				{
					dictionary["FoodHold"] = 0;
				}
				else if (Holding[1] == Food)
				{
					dictionary["FoodHold"] = 1;
				}
				else if (UsingPoint != null)
				{
					dictionary["FoodChair"] = UsingPoint.Parent.DID;
					if (UsingPoint.Parent.SnappedTo != null)
					{
						dictionary["FoodTable"] = UsingPoint.Parent.SnappedTo.Parent.DID;
					}
					else
					{
						dictionary["FoodPoint"] = Array.IndexOf(UsingPoint.Parent.InteractionPoints, UsingPoint);
					}
				}
			}
			dictionary["CleaningPoints"] = ((IEnumerable<Vector3>)CleaningPoints).Select((Func<Vector3, SVector3>)((Vector3 x) => x)).ToArray();
			dictionary["AssignedRoomGroups"] = AssignedRoomGroups;
			dictionary["LeaveTime2"] = LeaveTime;
			dictionary["Deal"] = deal;
			dictionary["PrintOrder2"] = Order;
			dictionary["ReservedFurniture"] = ((!(Reserved == null)) ? Reserved.DID : 0u);
			dictionary["Guarding"] = ((Guarding != null) ? Guarding.DID : 0u);
			dictionary["ReservedFridge"] = ((ReservedFridge != null) ? ReservedFridge.DID : 0u);
			if (ReservedPort != null)
			{
				dictionary["ReservedPort"] = ReservedPort.DID;
			}
			if (OnHead != null)
			{
				dictionary["OnHead"] = OnHead.DID;
			}
			if (Stolen != null)
			{
				dictionary["Stolen"] = Stolen;
			}
		}
		dictionary["LastMeeting"] = LastMeeting;
		dictionary["LastSocial"] = LastSocial;
		dictionary["MeetingTime2"] = MeetingTime;
		dictionary["DriveTime"] = DriveTime;
		dictionary["employee"] = employee;
		dictionary["AIType"] = (int)AItype;
		dictionary["Female"] = Female;
		dictionary["Courses"] = Courses;
		dictionary["LastCourse"] = LastCourse;
		dictionary["SkinColor"] = (SVector3)SkinColor;
		dictionary["HairColor"] = (SVector3)HairColor;
		dictionary["CarColor3"] = (SVector3)CarColor3;
		dictionary["TargetActor"] = ((!(TargetActor == null)) ? TargetActor.DID : 0u);
		if (employee.HasTrait(Employee.Trait.NightOwl))
		{
			dictionary["NightOwlDebuff"] = NightOwlDebuff;
		}
		if (employee.HasTrait(Employee.Trait.JustTheFlu))
		{
			dictionary["WasSick"] = WasSick;
		}
		if (employee.HasTrait(Employee.Trait.Forgetful))
		{
			dictionary["ForgetfulETA"] = ForgetfulETA;
		}
	}

	public override void PostDeserialize()
	{
		base.PostDeserialize();
		if (_targetActorID != 0)
		{
			TargetActor = GetDeserializedObject(_targetActorID) as Actor;
		}
		if (_guardingID != 0)
		{
			Guarding = GetDeserializedObject(_guardingID) as RoomSegment;
		}
	}

	public override string WriteName()
	{
		return "Actor";
	}

	public void Fire(bool quit, bool waiveHandshake = false)
	{
		if (employee.Dismissed)
		{
			return;
		}
		if (AItype == AI.AIType.Employee)
		{
			float num = 0f;
			if (!QuitAmicably)
			{
				GameSettings.Instance.ApplicantScore.NoteFiring(employee);
				QuitAffectTeam(quit);
			}
			if (!quit)
			{
				num = GetBenefitValue("Severance pay");
				ComplaintLevel *= num.MapRange(0f, EmployeeBenefit.Benefits["Severance pay"].Max, 1f, 0.5f);
			}
			else
			{
				HUD.Instance.insuranceWindow.AddTermination(new EmployeeTermination(this, EmployeeTermination.TerminationType.Quit, 0f), this, !waiveHandshake && !QuitAmicably);
			}
			if (!waiveHandshake && employee.HasDemanded(LeadDesignDemands.Demand.GoldenHandshake))
			{
				num += 60f;
			}
			if (!QuitAmicably && SDateTime.GetMonths(employee.Hired, SDateTime.Now()) > 12f && _complaintReasons != null && _complaintReasons.Length != 0 && ComplaintLevel > 1f)
			{
				GameSettings.Lawsuit lawsuit = new GameSettings.Lawsuit(employee.FullName, "Negligence", ComplaintLevel * 500000f, ComplaintLevel.MapRange(1f, 2f, 0.25f, 1f, true));
				lawsuit.Reasons.AddRange(_complaintReasons);
				GameSettings.Instance.LaunchSuit(lawsuit);
			}
			if (num > 0f)
			{
				GameSettings.Instance.MyCompany.MakeTransaction((0f - num) * GetMonthlySalary(), Company.TransactionCategory.Benefits, true, "Severance pay");
			}
		}
		Dismiss(false);
	}

	public void Dismiss(bool transfer)
	{
		if (this.IsAliveNotNull() && (IsEmployee() || AI.IsStaff(AItype)))
		{
			KillAutoDev();
			MakeUnIdle();
			GoHomeNow = true;
			employee.Dismiss(transfer);
			employee.MyEmployer = null;
			IgnoreOffSalary = true;
			employee.Thoughts.Clear();
			employee.JobSatisfaction = 1f;
			if (!base.enabled)
			{
				DestroyGO();
				OnDestroy();
			}
		}
	}

	public bool WorksForFree()
	{
		if (!employee.Founder)
		{
			return AItype == AI.AIType.Robot;
		}
		return true;
	}

	public int GetWorkHours(bool forSalary = false)
	{
		if (forSalary && employee.HasDemanded(LeadDesignDemands.Demand.FixedRate))
		{
			return 8;
		}
		if (team != null)
		{
			return team.WorkHours;
		}
		return 8;
	}

	public float GetMonthlySalary()
	{
		if (AI.IsStaff(AItype))
		{
			if (!OnCall)
			{
				return employee.Salary;
			}
			return employee.Salary * 6f;
		}
		if (!IsEmployee())
		{
			return 0f;
		}
		if (!WorksForFree())
		{
			return employee.GetMonthlySalary(GetTeam());
		}
		return 0f;
	}

	public float GetRealSalary()
	{
		if (!IsEmployee() && OnCall)
		{
			return 0f;
		}
		if (!WorksForFree())
		{
			return employee.Salary;
		}
		return 0f;
	}

	private void UpdateProblems()
	{
		if (!employee.Dismissed && !employee.Founder && !currentRoom.BuildingOnFire && employee.SatisfactionHitZero)
		{
			employee.SatisfactionHitZero = false;
			EscalateProblem();
			employee.JobSatisfaction = 1f;
		}
	}

	public bool HandleComplaint(float wants, bool keep, float severity, float newsFactor = 1f)
	{
		employee.ActiveComplaint = false;
		if (keep)
		{
			ComplaintLevel *= 0.5f;
			QuitLevel *= 0.5f;
			_complaintReasons = null;
			employee.Thoughts.RemoveAll((KeyValuePair<string, Employee.ThoughtEffect> x) => x.Value.Mood.ClearOnComplaint);
			employee.ChangeSalary(wants, wants, this, false);
		}
		else if (QuitLevel > 3f)
		{
			GameSettings.Instance.EmployerAwardDis = true;
			Fire(true);
			return false;
		}
		return true;
	}

	private void EscalateProblem()
	{
		float num = employee.Thoughts.List.Where((Employee.ThoughtEffect x) => x.Mood.Negative).SumSafe((Employee.ThoughtEffect x) => x.Effect * x.Mood.Severity);
		QuitLevel += num;
		_problemCache.Clear();
		if (QuitLevel > 3f)
		{
			GameSettings.Instance.EmployerAwardDis = true;
			Fire(true);
			return;
		}
		for (int num2 = 0; num2 < employee.Thoughts.List.Count; num2++)
		{
			Employee.ThoughtEffect thoughtEffect = employee.Thoughts.List[num2];
			if (thoughtEffect.Mood.Negative && thoughtEffect.Mood.QuitReason != null)
			{
				_problemCache.AddUp(thoughtEffect.Mood.QuitReason, thoughtEffect.Effect);
			}
		}
		float num3 = _problemCache.MaxSafe((KeyValuePair<string, float> x) => x.Value, 0f);
		List<string> list = new List<string>();
		if (num3 > 0f)
		{
			foreach (KeyValuePair<string, float> item in _problemCache.OrderByDescending((KeyValuePair<string, float> x) => x.Value))
			{
				if (item.Value / num3 > 0.5f)
				{
					list.Add(item.Key);
				}
			}
		}
		else
		{
			list.AddRange(from x in _problemCache
				orderby x.Value descending
				select x.Key);
		}
		ComplaintLevel += employee.Thoughts.List.Where((Employee.ThoughtEffect x) => x.Mood.Sue).SumSafe((Employee.ThoughtEffect x) => x.Effect * x.Mood.Severity);
		_complaintReasons = employee.Thoughts.List.WhereSelect((Employee.ThoughtEffect x) => x.Mood.Sue && x.Effect > 0f, (Employee.ThoughtEffect x) => x.Mood.QuitReason).Distinct().ToArray();
		float num4 = Mathf.Round(num * 10f);
		num4 = Mathf.Max(5f, Mathf.Ceil(num4 / 5f) * 5f);
		num4 = Mathf.Max((employee.Worth(-2, false) - employee.Salary) * 0.25f, num4);
		num4 = Mathf.Min(Mathf.Abs(employee.Salary) * 0.25f, num4);
		employee.Demanded += num4;
		employee.ActiveComplaint = true;
		float num5 = employee.AskedFor - employee.Salary;
		if (num5 > 0f)
		{
			num4 += num5;
		}
		if (Team != null && GetTeam().Leader != this && GetTeam().CheckHRLevel(1) && GetTeam().HR.HandleComplaints)
		{
			float num6 = employee.Salary + num4;
			bool keep = GetTeam().HR.HandleComplaint(num6, employee.Worth(-1, false), GetTeam(), this);
			if (!HandleComplaint(num6, keep, num, 1f - GetTeam().Leader.employee.GetSkill(Employee.EmployeeRole.Lead)))
			{
				HUD.Instance.LogAuto("AutoLogHRFire", Team, employee.FullName);
				GetTeam().HR.Resignations++;
			}
		}
		else
		{
			HUD.Instance.complaintWindow.AddComplaint(this, list.ToArray(), num4, num);
		}
	}

	public override string ToString()
	{
		if (employee != null)
		{
			return employee.FullName;
		}
		return "N/A";
	}

	public Vector2 GetPos()
	{
		return GetPosWithOffset();
	}

	public Vector3 GetPosition()
	{
		return ActualPosition;
	}

	public KeyValuePair<Texture2D, Rect> Snapshot()
	{
		if (this == null || base.gameObject == null)
		{
			return new KeyValuePair<Texture2D, Rect>(null, Rect.zero);
		}
		KeyValuePair<PortraitMaker.PortraitAtlas, Vector2Int> actorTex = HUD.Instance.Portraits.GetActorTex(this);
		float num = 1f / (float)PortraitMaker.PortraitPerAtlas;
		Rect rect = new Rect((float)actorTex.Value.x * num, (float)actorTex.Value.y * num, num, num);
		GlobalSearchPanel.SearchItem searchItem;
		if (GlobalSearchPanel.Instance.TryGetSearchItem(this, out searchItem))
		{
			searchItem.SetThumbnail(actorTex.Key.Tex, rect);
		}
		return new KeyValuePair<Texture2D, Rect>(actorTex.Key.Tex, rect);
	}

	public void PrepareHighlight(ref bool highlight, ref bool secondary)
	{
		bool isHighlight = IsHighlight;
		bool isSecondary = IsSecondary;
		IsHighlight = highlight;
		IsSecondary = secondary;
		Highlight(highlight, secondary);
		highlight = isHighlight;
		secondary = isSecondary;
	}

	public void OnDespawn()
	{
		if (AItype == AI.AIType.Employee)
		{
			ClearNeighbours();
		}
		if (MyCar != null)
		{
			MyCar.SpawnPoints[CarSpawnID].Occupants.Remove(this);
			MyCar = null;
		}
		for (int i = 0; i < Holding.Length; i++)
		{
			Holdable holdable = Holding[i];
			if (holdable != null && holdable.DestroyOnDespawn)
			{
				LeaveItem(holdable, true);
			}
		}
		anim.SetBool("RightHand", false);
		anim.SetBool("LeftHand", false);
		if (team != null)
		{
			for (int j = 0; j < team.WorkItems.Count; j++)
			{
				SoftwareWorkItem obj = team.WorkItems[j] as SoftwareWorkItem;
				if (obj != null)
				{
					obj.RemoveWorking(employee);
				}
			}
		}
		if (!employee.Founder && employee.LowestSatisfaction >= 0f)
		{
			GameSettings.Instance.ApplicantScore.NoteSatisfaction(employee.LowestSatisfaction);
		}
		employee.RefreshFriendships(HasInteractedWith);
		HasInteractedWith.Clear();
		if (team != null)
		{
			team.SetCohesionDirty();
		}
		if (HUD.Instance.DetailWindow.Window.Shown && HUD.Instance.DetailWindow.CurrentEmployee == this)
		{
			HUD.Instance.DetailWindow.RefreshComps();
		}
		GameSettings.Instance.sActorManager.ReadyForHome.Remove(this);
		if (UsingPoint != null && UsingPoint.Parent.Type.Equals("Bed"))
		{
			SpecialState = HomeState.Sleeping;
			SetVisible(LastVisible);
		}
		else
		{
			base.enabled = false;
			anim.enabled = false;
			SetVisible(false);
		}
		GameSettings.Instance.ActorGrid.Remove(this);
		Biking = false;
		BO = false;
		GoHomeNow = false;
		DespawnTime = SDateTime.Now();
	}

	private void OnDrawGizmosSelected()
	{
		if (CurrentPath != null && CurrentPath.Count > 0)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(CurrentPath[0], 0.1f);
			for (int i = 1; i < CurrentPath.Count; i++)
			{
				Gizmos.DrawSphere(CurrentPath[i], 0.1f);
				Gizmos.DrawLine(CurrentPath[i - 1] + Vector3.up * 0.1f, CurrentPath[i] + Vector3.up * 0.1f);
			}
		}
		Gizmos.color = Color.cyan;
		foreach (uint neighbour in _neighbours)
		{
			Actor actor = GameSettings.Instance.sActorManager.Actors.FirstOrDefault((Actor x) => x.DID == neighbour);
			if (actor != null)
			{
				Gizmos.DrawLine(ActualPosition, actor.ActualPosition);
			}
		}
		Gizmos.color = Color.white;
		if (MyCar != null)
		{
			Gizmos.DrawLine(ActualPosition, MyCar.transform.position);
		}
	}

	public override int GetFloor()
	{
		return Floor;
	}

	public override bool IsSelectableInView()
	{
		Room room = currentRoom;
		if (!room.Outdoors && !room.Outside)
		{
			return room.IsContentVisible();
		}
		return true;
	}

	public override bool IsSelectionRestricted()
	{
		if (AItype == AI.AIType.Parent)
		{
			return true;
		}
		return base.IsSelectionRestricted();
	}

	public void UpdateNow(float delta)
	{
		UpdateCurrentRoom();
		if (UpdateStateInfluence)
		{
			UpdateStateInfluence = false;
			Effectiveness = GetStateInfluence(delta);
		}
		if (AItype == AI.AIType.Employee && GameSettings.GameSpeed > 0f)
		{
			employee.UpdateEmployeeMood(delta * GameSettings.GameSpeed, this);
		}
	}

	public void UpdateNow2(float delta)
	{
		if (ShouldWork && this.IsAliveNotNull())
		{
			DoWork(delta);
		}
	}

	public bool NeedUpdate(bool firstFunction)
	{
		if (base.enabled)
		{
			return this.IsAliveNotNull();
		}
		return false;
	}

	public bool WageNegotiationNecessary()
	{
		if (employee.Salary != 0f)
		{
			return Mathf.Abs(employee.Salary - employee.Worth(-2)) / employee.Salary > 0.01f;
		}
		return true;
	}

	public GameObject GetGameObject()
	{
		if (!(this == null))
		{
			return base.gameObject;
		}
		return null;
	}

	public float GetSpeed(float angle)
	{
		return 0f;
	}

	public bool ShouldTrySocial()
	{
		if (employee.Stress != 0f)
		{
			return SDateTime.Now().ToInt() - LastSocial.ToInt() > 180;
		}
		return true;
	}

	public void MakeIdle(WorkStatus status)
	{
		if (employee.Dismissed)
		{
			MakeUnIdle();
			return;
		}
		IdleStatus = status;
		if (!IsIdle)
		{
			HUD.Instance.AddToIdle(this);
		}
		IsIdle = true;
	}

	public void MakeUnIdle()
	{
		IdleStatus = WorkStatus.Working;
		if (IsIdle)
		{
			HUD.Instance.RemoveFromIdle(this);
		}
		IsIdle = false;
	}

	public void KillAutoDev()
	{
		for (int num = AutoDevs.Count - 1; num > -1; num--)
		{
			AutoDevWorkItem autoDevWorkItem = AutoDevs[num];
			if (autoDevWorkItem.Leader == this)
			{
				autoDevWorkItem.Leader = null;
			}
		}
	}

	public void ScheduleVacation(bool fromNow)
	{
		if (fromNow)
		{
			if (Team != null)
			{
				int nextVacation = GetTeam().GetNextVacation(this);
				SDateTime sDateTime = new SDateTime(0, 0, 0, nextVacation, (SDateTime.Now() + 1).Year + 1);
				VacationMonth = ((SDateTime.GetMonths(SDateTime.Now(), sDateTime) > 14f) ? SDateTime.NextMonth(nextVacation) : sDateTime);
			}
			else
			{
				VacationMonth = (SDateTime.Now() + 12).SimplifyMore();
			}
		}
		else if (Team != null)
		{
			int nextVacation2 = GetTeam().GetNextVacation(this);
			int num = Mathf.Abs(VacationMonth.Month - nextVacation2);
			if (num > 5)
			{
				num = 12 - num;
			}
			AlternateVacation = ((num <= 2) ? new SDateTime(0, 0, 0, nextVacation2, VacationMonth.Year) : VacationMonth);
		}
	}

	public Dictionary<string, float> GetBenefits()
	{
		return employee.CustomBenefits;
	}

	public float GetBenefitValue(string benefit, bool ignoreSelf = false)
	{
		if (!ignoreSelf && employee != null)
		{
			return employee.GetBenefitValue(benefit, team);
		}
		return EmployeeBenefit.GetBenefitValue(null, team, benefit);
	}

	private void InitBenefits()
	{
		if (_cachedBenefitValue != -1f)
		{
			return;
		}
		_cachedBenefitValue = 0f;
		foreach (KeyValuePair<string, EmployeeBenefit> benefit in EmployeeBenefit.Benefits)
		{
			float benefitValue = GetBenefitValue(benefit.Key);
			if (benefit.Value.OnChange != null)
			{
				_cachedBenefits[benefit.Key] = benefitValue;
				if (!Mathf.Approximately(benefitValue, benefit.Value.Default))
				{
					benefit.Value.OnChange(this, benefit.Value.Default, benefitValue);
				}
			}
			_cachedBenefitValue += benefit.Value.GetScore(benefitValue) * benefit.Value.GetWeight(employee, team);
		}
	}

	public void CacheBenefits()
	{
		_cachedBenefitValue = 0f;
		foreach (KeyValuePair<string, EmployeeBenefit> benefit in EmployeeBenefit.Benefits)
		{
			float benefitValue = GetBenefitValue(benefit.Key);
			if (benefit.Value.OnChange != null)
			{
				_cachedBenefits[benefit.Key] = benefitValue;
			}
			_cachedBenefitValue += benefit.Value.GetScore(benefitValue) * benefit.Value.GetWeight(employee, team);
		}
	}

	public float GetBenefitScore()
	{
		InitBenefits();
		return _cachedBenefitValue / (EmployeeBenefit.MaxBenefits / 2f);
	}

	public void ApplyNewBenefits()
	{
		if (_cachedBenefitValue == -1f)
		{
			InitBenefits();
			return;
		}
		float num = employee.Worth(-2);
		float num2 = 0f;
		foreach (KeyValuePair<string, EmployeeBenefit> benefit in EmployeeBenefit.Benefits)
		{
			float benefitValue = GetBenefitValue(benefit.Key);
			float value;
			if (benefit.Value.OnChange != null && _cachedBenefits.TryGetValue(benefit.Key, out value) && !Mathf.Approximately(benefitValue, value))
			{
				benefit.Value.OnChange(this, value, benefitValue);
			}
			num2 += benefit.Value.GetScore(benefitValue) * benefit.Value.GetWeight(employee, team);
		}
		float num3 = (num2 - _cachedBenefitValue) / (EmployeeBenefit.MaxBenefits / 2f);
		if (num3 > 0.001f)
		{
			employee.AddInstantMood("NewGoodBenfits", this, num3);
		}
		else if (num3 < -0.01f)
		{
			employee.AddInstantMood("NewBadBenefits", this, 0f - num3);
		}
		if (!employee.Founder && employee.Worth(-2) - num > 10f && Mathf.Abs(num3) > 0.05f)
		{
			NegotiateSalary = true;
		}
		CacheBenefits();
	}

	public float LeaderEffectivenessFactor(int level)
	{
		if (employee.IsRole(Employee.RoleBit.Lead))
		{
			if (employee.GetSpecialization(Employee.EmployeeRole.Lead, "Multitasking") < level)
			{
				return 0.25f;
			}
			return 1f;
		}
		return 1f;
	}

	public void QuitAffectTeam(bool quit, float factor = 1f)
	{
		if (Team == null || AItype != AI.AIType.Employee)
		{
			return;
		}
		foreach (var friendship in Employee.GetFriendships(employee))
		{
			if (!(friendship.Item2 > 0.5f))
			{
				continue;
			}
			Actor myActor = friendship.Item1.MyActor;
			if (myActor != null)
			{
				float item = friendship.Item2;
				if (item < 1f)
				{
					item = item.MapRange(0.5f, 1f, 0f, 0.1f, true);
				}
				else
				{
					item -= 1f;
					item *= item;
					item = item.MapRange(0f, 1f, 0.1f, 1f, true);
				}
				myActor.employee.AddInstantMood(quit ? "TeammateLeft" : "TeammateFired", myActor, ((myActor.team == team) ? 1f : 0.5f) * item * factor);
			}
		}
	}

	public void PostUpdate(bool allowHoliday)
	{
		_allowHoliday = allowHoliday;
		LOD[] lODs = LOD.GetLODs();
		lODs[0].renderers = _bodyItems.Concate(_shadow).SelectNotNull((ActorBodyItem x) => x.rend).ToArray();
		lODs[1].renderers = _bodyItems.SelectNotNull((ActorBodyItem x) => x.LOD1Renderer).Concat(from x in _bodyItems
			where x.SelfLOD1
			select x.rend).Concate(_shadow.rend)
			.ToArray();
		LOD.SetLODs(lODs);
		for (int num = 0; num < _bodyItems.Count; num++)
		{
			ActorBodyItem actorBodyItem = _bodyItems[num];
			if (actorBodyItem.rend != null)
			{
				Children.Add(actorBodyItem.rend);
				for (int num2 = 0; num2 < actorBodyItem.ExtraRends.Length; num2++)
				{
					Renderer item = actorBodyItem.ExtraRends[num2];
					Children.Add(item);
				}
			}
			if (actorBodyItem.LOD1Renderer != null)
			{
				Children.Add(actorBodyItem.LOD1Renderer);
			}
		}
	}

	public void SetLOD2Color(string part, Color col)
	{
		MaterialPropertyBlock block = new MaterialPropertyBlock();
		block.SetColor("_Color", col);
		switch (part)
		{
		case "Head":
			LOD2Head.ForEachEnum(delegate(Renderer x)
			{
				x.SetPropertyBlock(block);
			});
			break;
		case "Upper":
			LOD2UpperBody.ForEachEnum(delegate(Renderer x)
			{
				x.SetPropertyBlock(block);
			});
			break;
		case "Lower":
			LOD2LowerBody.ForEachEnum(delegate(Renderer x)
			{
				x.SetPropertyBlock(block);
			});
			break;
		case "Hair":
			LOD2Hair.ForEachEnum(delegate(Renderer x)
			{
				x.SetPropertyBlock(block);
			});
			break;
		case "Feet":
			LOD2Feet.ForEachEnum(delegate(Renderer x)
			{
				x.SetPropertyBlock(block);
			});
			break;
		}
	}

	public override Vector2 GetFlatPos()
	{
		return ActualPosition.FlattenVector3();
	}

	public string GetActualString()
	{
		return ToString();
	}

	public override bool CanRectSelect()
	{
		if (!IsEmployee())
		{
			return AI.IsStaff(AItype);
		}
		return true;
	}

	public override Vector3 GetSelectPosition()
	{
		return ActualPosition + Vector3.up;
	}

	public bool StaffBlockTimeSkip()
	{
		if (!base.enabled)
		{
			return false;
		}
		if (AItype == AI.AIType.Security && (SDateTime.Now() - MeetingTime).ToInt() < 60 * (GetStaffHours() - 1))
		{
			return false;
		}
		return true;
	}

	public void ClearLoiterTable()
	{
		if (!(LoiterTable != null))
		{
			return;
		}
		if (LoiterTable.IsOnlyUser(this) && LoiterTable.TableReserved < 1)
		{
			LoiterTable.ReserveTables(false);
		}
		if (UsingPoint != null && "Chair".Equals(UsingPoint.Parent.Type))
		{
			if (UsingPoint.Parent.Table != null)
			{
				if (UsingPoint.Parent.Table.Parent == LoiterTable)
				{
					UsingPoint = null;
				}
			}
			else if (UsingPoint.Parent.SnappedTo != null && UsingPoint.Parent.SnappedTo.Parent.Table != null && UsingPoint.Parent.SnappedTo.Parent.Table.Parent == LoiterTable)
			{
				UsingPoint = null;
			}
		}
		LoiterTable = null;
	}

	public override Vector3 GetTransformPosition()
	{
		return ActualPosition;
	}

	public void CleanUpEating()
	{
		if (Food != null)
		{
			Food.DestroyMe();
			Food = null;
		}
		LeaveItem("Spork", true);
	}

	public override string GetPanelActionName()
	{
		if (!IsEmployee())
		{
			return base.GetPanelActionName();
		}
		return "Details";
	}

	public override void InvokePanelAction(List<UndoObject.UndoAction> undos)
	{
		HUD.Instance.DetailWindow.Show(this);
	}

	public override bool PanelActionOnlyOnce()
	{
		return true;
	}

	public bool AllowAlternativeTraffic()
	{
		if (AItype != AI.AIType.FireInspector && AItype != AI.AIType.Security && AItype != AI.AIType.Cook && AItype != AI.AIType.Receptionist && AItype != AI.AIType.IT && AItype != AI.AIType.Cleaning && AItype != AI.AIType.Janitor)
		{
			return IsEmployee();
		}
		return true;
	}

	public int GetCourseBit()
	{
		int num = 0;
		if (!base.isActiveAndEnabled && Courses.Count > 0)
		{
			for (int i = 0; i < Courses.Count; i++)
			{
				num |= 1 << Employee.RoleOrderIndex[(int)Courses[i].Key];
			}
		}
		return num;
	}
}
