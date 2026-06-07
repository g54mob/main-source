using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Achievements;
using DevConsole;
using SINetworking;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour, IBenefitReceiver
{
	public enum WallState
	{
		High = 0,
		Back = 1,
		Low = 2,
		LowNoSeg = 3
	}

	public struct PlotLoanData
	{
		public uint ID;

		public float Monthly;

		public float MonthlyInterest;

		public int MonthsLeft;

		public PlotLoanData(uint id, float monthly, float monthlyInterest, int monthsLeft)
		{
			ID = id;
			Monthly = monthly;
			MonthlyInterest = monthlyInterest;
			MonthsLeft = monthsLeft;
		}

		public void Apply(List<PlotArea> ps)
		{
			uint id = ID;
			PlotArea plotArea = ps.FirstOrDefault((PlotArea x) => x.ID == id);
			if (plotArea != null)
			{
				plotArea.MonthsLeft = MonthsLeft;
				plotArea.Monthly = Monthly;
				plotArea.MonthlyInterest = MonthlyInterest;
			}
		}

		public static PlotLoanData? TryGetLoan(PlotArea p)
		{
			if (p.MonthsLeft > 0)
			{
				return new PlotLoanData(p.ID, p.Monthly, p.MonthlyInterest, p.MonthsLeft);
			}
			return null;
		}
	}

	[Serializable]
	public class Lawsuit
	{
		public bool External;

		public Company Plaintiff;

		public string Persons;

		public string Subject;

		[AltWasFloat(0)]
		public double Money;

		public float Difficulty;

		public SDateTime Start;

		public HashSet<string> Reasons = new HashSet<string>();

		public bool ClassAction;

		public int PersonCount;

		public bool Spiff;

		public Lawsuit()
		{
		}

		public Lawsuit(Company c, string subject, double money, float difficulty)
		{
			External = true;
			Plaintiff = c;
			Subject = subject;
			Money = money;
			Difficulty = difficulty;
			Start = SDateTime.Now();
		}

		public Lawsuit(string person, string subject, double money, float difficulty)
		{
			External = false;
			Persons = person;
			Subject = subject;
			Money = money;
			Difficulty = difficulty;
			Start = SDateTime.Now();
			PersonCount = 1;
		}

		public Lawsuit(string subject, double money, float difficulty)
		{
			External = true;
			Subject = subject;
			Money = money;
			Difficulty = difficulty;
			Start = SDateTime.Now();
		}

		public Lawsuit SetDate(SDateTime date)
		{
			Start = date;
			return this;
		}

		public bool CanCombine(Lawsuit l)
		{
			if (l.Plaintiff == null && Plaintiff == null && Subject.Equals(l.Subject))
			{
				return External == l.External;
			}
			return false;
		}

		public void Combine(Lawsuit l)
		{
			ClassAction = true;
			Persons = null;
			PersonCount += l.PersonCount;
			Difficulty = Mathf.Max(Difficulty, l.Difficulty);
			Money += l.Money;
			Reasons.AddRange(l.Reasons);
		}

		public void Launch()
		{
			ForcePause = true;
			object obj = (External ? Plaintiff : ((object)new FormatColorString(Persons)));
			DialogWindow msgBox = WindowManager.SpawnDialog();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(ClassAction ? "ClassLawsuitPrompt".LocColor(new FormatColorString(Subject.Loc()), Money.Currency()) : "LawsuitPrompt".LocColor(new FormatColorString(Subject.Loc()), obj, Money.Currency()));
			if (Reasons.Count > 0)
			{
				stringBuilder.AppendLine("Reasonsgiven".Loc());
				foreach (string reason in Reasons)
				{
					stringBuilder.AppendLine(reason.Loc());
				}
			}
			if (PersonCount >= 10)
			{
				AchievementController.SetAchievement("EMPLOYEESUIT");
			}
			msgBox.Show(stringBuilder.ToString(), false, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("CourtAction", delegate
			{
				LegalWork legalWork = (External ? new LegalWork(Plaintiff, Subject, Money, Difficulty) : new LegalWork(Subject, Money, Difficulty));
				if (Spiff)
				{
					legalWork.Spiff = true;
				}
				Instance.MyCompany.AddWorkItem(legalWork);
				Instance.ApplyDefaultTeams(legalWork, string.Concat(legalWork.Type, "Team"));
				ForcePause = false;
				msgBox.Window.Close();
			}), new KeyValuePair<string, Action>("Settle", delegate
			{
				if (!External || HasCompletedMission("Mission13"))
				{
					Instance.MyCompany.MakeTransaction(0.0 - Money, Company.TransactionCategory.Legal, true, "Lawsuit");
					if (Plaintiff != null)
					{
						Plaintiff.MakeTransaction(Money, Company.TransactionCategory.Legal, true, "Lawsuit");
					}
					ForcePause = false;
					msgBox.Window.Close();
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("CampaignLockError".Loc(), true, DialogWindow.DialogType.Information, msgBox.Window);
				}
			}));
		}
	}

	public const float ElectricityIncomeFactor = 0.25f;

	public const float MaxHeat = 10000000f;

	public const int HeatReductionTime = 12;

	public static bool HasQuitSaved = false;

	public static HashSet<string> FixServerWiringNow = new HashSet<string>();

	public static HashSet<string> CalculateServerPowerNow = new HashSet<string>();

	public static Dictionary<string, float> MiscStatOrder = new Dictionary<string, float>
	{
		{ "Hired", 0f },
		{ "Fired", 1f },
		{ "Retired", 2f },
		{ "Quit", 3f },
		{ "SickDays", 4f },
		{ "ProductsReleased", 5f },
		{ "PrintsShipped", 6f },
		{ "ContractsCompleted", 7f },
		{ "ServerBandwidth", 8f },
		{ "ServerFailure", 9f },
		{ "Fires", 10f },
		{ "SuccessfulBurglaries", 11f },
		{ "ThwartedBurglaries", 12f }
	};

	public bool WireMode = true;

	public static GameSettings Instance;

	public static GameSettings LastInstance;

	public static int MaxFloor = 10;

	public int FireCounter;

	public int Looted;

	public int StolenBack;

	public bool Arrested;

	public bool LODDirty = true;

	public Confiscator ConfiscatorPrefab;

	[NonSerialized]
	public List<Confiscator> Confiscators = new List<Confiscator>();

	public Transform AudioListener;

	public Material TreeTrunkMat;

	public Material tTreeTrunkMat;

	public Material LeaveMat;

	public Material CactusTrunkMat;

	public StaticTree[] CachedTrees = new StaticTree[0];

	public TreeBatch TreeBatchPrefab;

	public BoxController BoxController;

	public ConferenceController ConferenceController;

	public UnlockChecker UnlockCheck;

	public ScissorLift ScissorPrefab;

	public List<TreeBatch> TreeBatches = new List<TreeBatch>();

	[NonSerialized]
	private Dictionary<KeyValuePair<uint, uint>, HardwareDesignFurn.HardwareFurnInstance> _hardwareFurnInstances = new Dictionary<KeyValuePair<uint, uint>, HardwareDesignFurn.HardwareFurnInstance>();

	[NonSerialized]
	public Dictionary<uint, BillboardAd> Billboards = new Dictionary<uint, BillboardAd>();

	public uint BillboardID;

	public BillboardAd BillboardPrefab;

	public List<GameObject> MergedTreeTrunks = new List<GameObject>();

	public List<GameObject> MergedLeaves = new List<GameObject>();

	[NonSerialized]
	public HashSet<Room> Burgled = new HashSet<Room>();

	public ParticleSystem ChimneySmokePrefab;

	[NonSerialized]
	public List<TreeInstance> Trees = new List<TreeInstance>();

	[NonSerialized]
	public Dictionary<Mesh, List<Matrix4x4>> TreeInstance = new Dictionary<Mesh, List<Matrix4x4>>();

	[NonSerialized]
	public List<ReceptionDesk> ReceptionDesks = new List<ReceptionDesk>();

	[NonSerialized]
	public List<TreeInstance> TempTrees = new List<TreeInstance>();

	public List<RoomStyle> RoomStyles = new List<RoomStyle>();

	public RoomStyle DefaultOutdoorRoomStyle = new RoomStyle("Default", "Wood", "Plain white", "None", false, Color.white, new SVector3(0.992f, 0.788f, 0.525f, 1f), new Color32(173, 173, 173, byte.MaxValue));

	public RoomStyle DefaultIndoorRoomStyle = new RoomStyle("Default", "Concrete wall", "Drywall", "Concrete floor", false, Color.white, Color.gray, Color.white);

	public RoomStyle DefaultRoofStyle = new RoomStyle("Oldschool", "Brick wall", null, "Roof tiles", false, new Color(0.7f, 0.5f, 0.5f), Color.white, new Color(0.9f, 0.5f, 0.3f));

	public RoomStyle DefaultPathStyle = new RoomStyle("Brick path", "BrickPath", null, null, false, new Color(0.5f, 0.5f, 0.5f), Color.white, Color.white);

	public RoomStyle DefaultBalconyStyle = new RoomStyle("Default", "Concrete wall", "Drywall", "Concrete floor", "Glass", Color.white, Color.gray, Color.white, Color.gray);

	[NonSerialized]
	public QuadTree<TreeInstance> TreeTree = new QuadTree<TreeInstance>(new Rect(0f, 0f, 256f, 256f), 4f, 4, 4);

	public RoomManager sRoomManager;

	[SaveField("Electricity", 0f, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float ElectricityBill;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float ElectricityIncome;

	[SaveField("Water", 0f, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float Waterbill;

	[SaveField("Gas", 0f, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float Gasbill;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public float LastWattUse;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public float LastWattSaved;

	public double ElectricityDelta;

	public double ElectricityGenerationDelta;

	public double WaterDelta;

	public double GasDelta;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public double ElectricityBurst;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float ContentsInsured;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float IdlePay;

	public ActorManager sActorManager;

	public int ActiveFloor;

	[NonSerialized]
	[SaveField(NetworkMode = false)]
	private uint _nextLocalNetworkID = 1u;

	[NonSerialized]
	public Company MyCompany;

	private int WindowIDCounter = 10;

	[SaveField("WorkItemID", 1u, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	private uint WorkItemIDCounter = 1u;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	private SDateTime LastTaxCase;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public SDateTime NextOnlookerCheck;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float NextHeatActionAdd;

	public bool HideCeilingFurniture;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public int[] PlatinumProgress = new int[4];

	public bool AssignOverlay;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public bool MuteIssues;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public bool MuteGuide;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public bool InsuranceIncidentPossible;

	[NonSerialized]
	public MarketSimulation simulation;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public ApplicantAttractionData ApplicantScore = new ApplicantAttractionData();

	public Color[] PlotColors = new Color[8]
	{
		new Color32(126, 207, 112, byte.MaxValue),
		new Color32(95, 122, 155, byte.MaxValue),
		new Color32(220, 108, 130, byte.MaxValue),
		new Color32(236, 157, 112, byte.MaxValue),
		new Color32(126, 95, 160, byte.MaxValue),
		new Color32(90, 203, 207, byte.MaxValue),
		new Color32(216, 194, 89, byte.MaxValue),
		new Color32(199, 40, 40, byte.MaxValue)
	};

	public GameObject RoomObject;

	public GameObject ActorObj;

	public int ExpansionSize = 5;

	[NonSerialized]
	public DifficultyValues.DifficultySetting Difficulty = DifficultyValues.DefaultSettings;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public bool HasFounder = true;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public int MissedSink;

	public float ExpansionCost = 350f;

	[NonSerialized]
	public SaveGame AssociatedSave;

	[NonSerialized]
	public SaveGame AssociatedAutoSave;

	private GameObject TreeRoot;

	private static int _forcePause = 0;

	public static bool FreezeGame = false;

	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public int LastBurglarSpawn;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public bool EmployerAwardDis;

	public static WallState WallsDown = WallState.High;

	public HashSet<string> DisabledTutorials = new HashSet<string>();

	[NonSerialized]
	public List<Loan> Loans = new List<Loan>();

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public Dictionary<string, float> CompanyBenefits = new Dictionary<string, float>();

	public PersonalityGraph Personalities;

	[NonSerialized]
	public InsuranceAccount Insurance = new InsuranceAccount();

	public Dictionary<string, Color> ColorDefaults = new Dictionary<string, Color>();

	[NonSerialized]
	public Dictionary<KeyValuePair<Company, SoftwareCategory>, SDateTime> LastFanWarning = new Dictionary<KeyValuePair<Company, SoftwareCategory>, SDateTime>();

	public Dictionary<string, string> StyleDefaults = new Dictionary<string, string>();

	[NonSerialized]
	public Dictionary<string, HashSet<string>> TeamDefaults = new Dictionary<string, HashSet<string>>();

	[NonSerialized]
	private Dictionary<string, ServerGroup> ServerGroups = new Dictionary<string, ServerGroup>();

	[NonSerialized]
	private Dictionary<int, List<Furniture>> _LODFloors = new Dictionary<int, List<Furniture>>();

	[NonSerialized]
	public List<IServerItem> UnsupportedServerItems = new List<IServerItem>();

	[NonSerialized]
	public List<Actor> Founders = new List<Actor>();

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public Dictionary<string, List<float>> MiscStats = new Dictionary<string, List<float>>();

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public HashSet<string> CompletedTasks = new HashSet<string>();

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public HashSet<string> ClaimedRewards = new HashSet<string>();

	public Dictionary<string, int> TaskProgress = new Dictionary<string, int>();

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany)]
	public List<StockMarket> StockMarkets = new List<StockMarket>();

	[NonSerialized]
	public List<StockMarket> MetalMarkets;

	public double OffshoreAccount;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float Heat;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float HeatCountdown;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float HeatFullCountdown;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public List<Investment> Investments = new List<Investment>();

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public HashSet<string> ColumnsDisabled = new HashSet<string>();

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public Dictionary<string, string[]> ColumnOrder = new Dictionary<string, string[]>();

	[NonSerialized]
	public bool ColumnDataLoaded;

	[NonSerialized]
	public List<TrashCan> FullTrashCans = new List<TrashCan>();

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public List<KeyValuePair<SoftwareProduct, int>> DDoS = new List<KeyValuePair<SoftwareProduct, int>>();

	[NonSerialized]
	public Furniture Portal1;

	[NonSerialized]
	public Furniture Portal2;

	private int _taskOffset;

	private int _taskSubOffset;

	private static float _gameSpeed = 1f;

	private static float lastGameSpeed = 1f;

	public string[] Specializations;

	public string[] CodeSpecializations;

	public string[] ArtSpecializations;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public int LocalDefaultPriority = 5;

	public static bool IsQuitting = false;

	public float FireInspectorCluster = 7f;

	public Camera LoadingCamera;

	public Text LoadingText;

	public RawImage LoadingImage;

	public GUIProgressBar LoadingBar;

	private bool CachedSpecs;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public List<AwardTrophy.AwardData> Awards = new List<AwardTrophy.AwardData>();

	private SDateTime LastSpec;

	private string[][] CachedSpecDict = new string[5][];

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public Color CompanyCarColor;

	[SaveField(1, LoadFor = GameReader.NewLoadMode.FullOrCompany)]
	public static int DaysPerMonth = 1;

	public GameObject PreSimLoadPanel;

	public Text PreSimLoadText;

	public Text PreSimSWText;

	public GUIProgressBar PreSimBar;

	public List<Actor> Vacations;

	public GameObject BusStopSign;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float SalaryDue;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float NightSalaryDue;

	[SaveField(0f, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float StaffSalaryDue;

	[SaveField("None", LoadFor = GameReader.NewLoadMode.FullOrBuilding)]
	public string RNDString;

	public string RNDStringOverride = "Test";

	public bool RNDStringOverrideRandom;

	public bool RuralBigPlotOverride = true;

	public bool CheckOSLicenses;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public bool DangerFreebie = true;

	public EnvironmentPreset Environment;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrBuilding)]
	public GameData.EnvironmentType EnvType;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrBuilding)]
	public GameData.ClimateType CliType;

	public Mesh PipeMesh;

	public Material PipeMat;

	public bool SkipSimulation;

	public bool SkipTrees;

	public bool EditMode;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany)]
	public bool CampaignMode = true;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrBuilding)]
	public bool RentMode;

	[SaveField(NetworkMode = false)]
	public HashSet<string> CurrentMissions = new HashSet<string>();

	[SaveField(NetworkMode = false)]
	public HashSet<string> CompletedMissions = new HashSet<string>();

	public AnimationCurve TreeFalloff;

	public FrameDistributor ActorUpdateHandler;

	public FrameDistributor WorkUpdateHandler;

	public FrameDistributor FurnitureUpdateHandler;

	public FrameDistributor ComputerNoiseUpdateHandler;

	public FrameDistributor LampUpdateHandler;

	public SHashSet<string> Errors = new SHashSet<string>();

	[NonSerialized]
	public bool FurnitureErrorOccured;

	[NonSerialized]
	public List<ReviewWork> ReviewJobs = new List<ReviewWork>();

	[NonSerialized]
	public List<SoftwareWorkItem> FollowerSimulation = new List<SoftwareWorkItem>();

	[NonSerialized]
	public HashSet<SoftwareAlpha> PressBuildQueue = new HashSet<SoftwareAlpha>();

	[NonSerialized]
	public DictionaryList<IStockable, PrintJob> PrintOrders = new DictionaryList<IStockable, PrintJob>();

	[NonSerialized]
	public DictionaryList<uint, NetworkPrintDeal> NetworkPrintOrders = new DictionaryList<uint, NetworkPrintDeal>();

	[NonSerialized]
	private Dictionary<IStockable, uint> _printsInStorage = new Dictionary<IStockable, uint>();

	[NonSerialized]
	public List<ProductPrinter> ProductPrinters = new List<ProductPrinter>();

	[NonSerialized]
	public List<FoodAssemblyInput> FoodAssemblers = new List<FoodAssemblyInput>();

	[NonSerialized]
	public List<Furniture> GaragePorts = new List<Furniture>();

	[NonSerialized]
	public List<ProductPallet> ProductPallets = new List<ProductPallet>();

	[NonSerialized]
	public List<Conveyor> Recyclers = new List<Conveyor>();

	[NonSerialized]
	public Dictionary<Company.TransactionCategory, Dictionary<string, float>> BillsCurrent = new Dictionary<Company.TransactionCategory, Dictionary<string, float>>();

	[NonSerialized]
	public Dictionary<Company.TransactionCategory, Dictionary<string, float>> BillsNext = new Dictionary<Company.TransactionCategory, Dictionary<string, float>>();

	private List<UndoObject> UndoList = new List<UndoObject>();

	public static int MaxUndo = 30;

	public GameObject UndoButton;

	public Dictionary<int, MeshFilter> FloorRentGrids = new Dictionary<int, MeshFilter>();

	public HashSet<int> DirtyRentGrid = new HashSet<int>();

	public GUIToolTipper UndoTip;

	[NonSerialized]
	private Dictionary<string, RoomGroup> RoomGroups = new Dictionary<string, RoomGroup>();

	[NonSerialized]
	[SaveField(false, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public bool SkipDesignGeneration;

	[NonSerialized]
	public WriteDictionary ModData;

	[NonSerialized]
	public List<ElevatorGroup> ElevatorGroups = new List<ElevatorGroup>();

	[NonSerialized]
	public Dictionary<string, List<InventoryItem>> FurnitureInventory = new Dictionary<string, List<InventoryItem>>();

	[NonSerialized]
	public uint PrinterChangeCounter;

	[NonSerialized]
	public bool ElevatorsSerialized = true;

	[NonSerialized]
	public bool PermanentUnlock = true;

	[NonSerialized]
	public FireReport ActiveFireReport = new FireReport();

	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public bool PassedFireInspection = true;

	[NonSerialized]
	private int? _dirtyHelipad;

	[NonSerialized]
	public Subway ActiveSubway;

	[NonSerialized]
	public bool HasSubway;

	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	private Dictionary<string, List<FurnitureStyle>> _furnStyles = new Dictionary<string, List<FurnitureStyle>>();

	[NonSerialized]
	private List<AssemblyLine> _assemblyLines = new List<AssemblyLine>();

	[NonSerialized]
	private HashSet<Room> _navRooms = new HashSet<Room>();

	public GameObject NavIcon;

	[NonSerialized]
	public List<Battery> Batteries = new List<Battery>();

	[NonSerialized]
	private Battery _batteryConsume;

	[NonSerialized]
	private Battery _batteryFill;

	[NonSerialized]
	public List<Furniture> OnFire = new List<Furniture>();

	[NonSerialized]
	private List<UndoObject.UndoAction> _destructionUndo = new List<UndoObject.UndoAction>();

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany)]
	public List<KeyValuePair<Company, string>>[] AwardWinners;

	[NonSerialized]
	public float DestructionUndoCost;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public float[] HourWattUse = new float[24];

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public float[] HourWattGen = new float[24];

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public float[] HourWaterUse = new float[24];

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public float[] HourGasUse = new float[24];

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public float[] MonthWattGen = new float[12];

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public float[] MonthWattUse = new float[12];

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public float[] MonthWaterUse = new float[12];

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public float[] MonthGasUse = new float[12];

	[NonSerialized]
	public string HotDep;

	[NonSerialized]
	public string CoolDep;

	[NonSerialized]
	public DateTime LastSaveTime;

	[NonSerialized]
	public ObjectPool<ScissorLift> ScissorPool;

	[NonSerialized]
	public GridQuery<Actor> ActorGrid = new GridQuery<Actor>(new Rect(0f, 0f, 256f, 256f));

	[NonSerialized]
	private AccountingWork _backgroundAccounting;

	[NonSerialized]
	public Vector3 BusDir = Vector3.forward;

	[NonSerialized]
	public Vector3 BusStart = new Vector3(5.75f, 0f, -4f);

	[NonSerialized]
	public NetworkMeta NetworkData;

	[NonSerialized]
	[SaveField]
	public float? YearlyNetworkIPO;

	[NonSerialized]
	[SaveField]
	public bool PlotAdjacency;

	[NonSerialized]
	[SaveField]
	public float RoundLimit = float.PositiveInfinity;

	[NonSerialized]
	[SaveField]
	public NetworkLobby.RoundLimitType RoundType;

	[NonSerialized]
	public HashSet<Room> QueuedNetworkRooms = new HashSet<Room>();

	[NonSerialized]
	public HashSet<Room> QueuedNetworkEdges = new HashSet<Room>();

	[NonSerialized]
	public Dictionary<RoomSegment, bool> QueuedNetworkSegments = new Dictionary<RoomSegment, bool>();

	[NonSerialized]
	public HashSet<Furniture> QueuedNetworkFurniture = new HashSet<Furniture>();

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public Dictionary<string, string> PreferredServerGroup = new Dictionary<string, string>();

	[NonSerialized]
	[SaveField]
	public HashSet<string> BanList = new HashSet<string>();

	[NonSerialized]
	public HashSet<ulong> SteamInvitedToGame = new HashSet<ulong>();

	public Material SignSDFMat;

	[NonSerialized]
	private Dictionary<Company, ValueTuple<RenderTexture, Material>> _companyBuildingNames = new Dictionary<Company, ValueTuple<RenderTexture, Material>>();

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	private bool DisableAchievements;

	[NonSerialized]
	private HashSet<Furniture> ITStations = new HashSet<Furniture>();

	[NonSerialized]
	public HashList<Furniture> BrokenIT = new HashList<Furniture>();

	[NonSerialized]
	public ITServerTask ITSupportProcess;

	[NonSerialized]
	[SaveField(LoadFor = GameReader.NewLoadMode.Full, NetworkMode = false)]
	public string ITSupportServer;

	public int ForceTimeType;

	[NonSerialized]
	public List<Actor> ResetRooms = new List<Actor>();

	[NonSerialized]
	public HashSet<ValueTuple<Team, Team>> TeamTaskComp = new HashSet<ValueTuple<Team, Team>>();

	[NonSerialized]
	[SaveField(0f, LoadFor = GameReader.NewLoadMode.FullOrCompany, NetworkMode = false)]
	public float ServerCost;

	[NonSerialized]
	public EventHandler OnServersChanged;

	public static EventHandler IsDoneLoadingGame;

	public static EventHandler GameReady;

	public static EventHandler OnHardwareAtlasInitialized;

	public float UndoAutosaveWait;

	public bool wasSkipping;

	public HashSet<object> Cached = new HashSet<object>();

	public GameObject PlotPrefab;

	public Transform PlotHolder;

	[NonSerialized]
	public List<PlotArea> Plots = new List<PlotArea>();

	[NonSerialized]
	public List<PlotArea> PlayerPlots = new List<PlotArea>();

	private Thread _simThread;

	private static readonly HashSet<string> _stockNameFilter = new HashSet<string> { "FAG", "JAP", "KKK", "NIG" };

	[NonSerialized]
	public bool HasToFinalizeTimers;

	[NonSerialized]
	private List<WorkItem> _workItemUpdateLoopCache = new List<WorkItem>();

	private int _refreshFurnEdgeNum;

	private int _refreshFurnEdgeOffset;

	public float InGameMinute;

	public float LeaveShakeSpeed = 15f;

	public float LeaveShakeStart = 6f;

	public float LeaveTime = 60f;

	private float _leaveShake;

	[NonSerialized]
	public bool PreSimActive;

	[NonSerialized]
	public bool PreSimFinished;

	private string presimloadtxt;

	private string presimswtext;

	private float presimloadbar;

	private SDateTime presimfinaltime;

	[NonSerialized]
	public List<EmployeeTermination> SerializedEvents;

	[NonSerialized]
	public List<TransportBox.SaveBox> SerializedBoxes;

	[NonSerialized]
	public List<HelicopterData> SerializedHeli;

	[NonSerialized]
	public Dictionary<string, MissionGuide.CampaignCharacter> CampaignCharacters;

	[NonSerialized]
	public List<PlotLoanData> PLoanData;

	[NonSerialized]
	private uint _tempPortal1;

	[NonSerialized]
	private uint _tempPortal2;

	[NonSerialized]
	private float _fetchCooldown;

	[NonSerialized]
	private byte[] _lastGrassFetch;

	[NonSerialized]
	private bool _fetchingGrass;

	[NonSerialized]
	private AsyncGPUReadbackRequest? _lastFetchTask;

	[NonSerialized]
	private Texture2D _tempGrassTex;

	[NonSerialized]
	private List<Lawsuit> _lawsuitQueue = new List<Lawsuit>();

	public float GrassTrotUpdate = 1f;

	public int TrotSize = 1024;

	private float _grassTrotTime;

	public RenderTexture GrassTrot;

	public Camera GrassTrotCam;

	public Mesh GrassTrotQuad;

	public Material GrassTrotMat;

	public Material GrassTrotResetMat;

	public Material TrotNullMat;

	public Texture TrotNullTexture;

	private SDateTime _lastUpdate;

	private bool _dynamicPaths = true;

	private List<ValueTuple<uint, uint>> _buyouts = new List<ValueTuple<uint, uint>>();

	[NonSerialized]
	private Dictionary<int, float> _computerPower = new Dictionary<int, float>();

	public static bool IgnoreBusinessRep
	{
		get
		{
			if (Instance.Difficulty.Contracts < 0.5f)
			{
				return Instance.Difficulty.Deals < 0.5f;
			}
			return false;
		}
	}

	public static int DefaultPriority
	{
		get
		{
			if (!Instance.IsReferenceNull())
			{
				return Instance.LocalDefaultPriority;
			}
			return 5;
		}
	}

	public bool IsNetworkMode
	{
		get
		{
			if (!GameData.MultiplayerMode)
			{
				return NetworkData != null;
			}
			return true;
		}
	}

	public bool AllowModdedFurniture
	{
		get
		{
			if (NetworkData != null)
			{
				return NetworkData.AllowModdedFurniture;
			}
			return true;
		}
	}

	public int ITStationCount
	{
		get
		{
			return ITStations.Count;
		}
	}

	public bool IsHost
	{
		get
		{
			return NetworkManager.IsHost;
		}
	}

	public bool AchievementsDisabled
	{
		get
		{
			return DisableAchievements;
		}
	}

	public AccountingWork BackgroundAccounting
	{
		get
		{
			if (_backgroundAccounting == null)
			{
				_backgroundAccounting = MyCompany.WorkItems.FirstOrDefault((WorkItem x) =>
				{
					AccountingWork accountingWork;
					return (accountingWork = x as AccountingWork) != null && accountingWork.Type == AccountingWork.WorkType.BackgroundWork;
				}) as AccountingWork;
				if (_backgroundAccounting == null)
				{
					_backgroundAccounting = new AccountingWork(true);
					_backgroundAccounting.Hidden = true;
					MyCompany.AddWorkItem(_backgroundAccounting);
				}
			}
			return _backgroundAccounting;
		}
	}

	public bool AnyDestructionUndos
	{
		get
		{
			return _destructionUndo.Count > 0;
		}
	}

	public int UndoCount
	{
		get
		{
			return UndoList.Count;
		}
	}

	public static float GameSpeed
	{
		get
		{
			return _gameSpeed;
		}
		set
		{
			if (GameSpeed == value)
			{
				HUD.UpdateHUDSpeed();
				return;
			}
			if (Instance.ForceTimeType == 1)
			{
				value = Mathf.Max(1f, value);
			}
			else if (Instance.ForceTimeType == 2)
			{
				value = Mathf.Max(HUD.GetSpeed(3), value);
			}
			if (!ForcePause)
			{
				_gameSpeed = value;
			}
			TimeOfDay.SyncPlayerTime();
			HUD.UpdateHUDSpeed();
			lastGameSpeed = value;
			int gameSpeed = HUD.Instance.GameSpeed;
			HUD.Instance.UpdateBorderOverlay();
			if (gameSpeed > -1 && HUD.Instance != null)
			{
				for (int i = 0; i < 4; i++)
				{
					HUD.Instance.SpeedToggles[i].isOn = gameSpeed == i;
				}
			}
		}
	}

	public static bool ForcePause
	{
		get
		{
			return _forcePause > 0;
		}
		set
		{
			if (Instance != null && Instance.ForceTimeType > 0)
			{
				value = false;
			}
			bool forcePause = ForcePause;
			_forcePause = Mathf.Max(0, _forcePause + (value ? 1 : (-1)));
			if (!value)
			{
				FreezeGame = false;
			}
			if (forcePause == ForcePause)
			{
				return;
			}
			if (ForcePause)
			{
				Instance.wasSkipping = TimeOfDay.Instance.IsSkipping || Instance.wasSkipping;
			}
			else if (Instance != null && Instance.wasSkipping)
			{
				Instance.wasSkipping = false;
				TimeOfDay.Instance.SkipTime();
			}
			if (ForcePause)
			{
				lastGameSpeed = _gameSpeed;
				if (_gameSpeed > 0f)
				{
					UISoundFX.PlaySFX("Pause");
				}
				_gameSpeed = 0f;
			}
			else
			{
				if (_gameSpeed != lastGameSpeed && lastGameSpeed > 0f)
				{
					UISoundFX.PlaySFX("NormalSpeed");
				}
				_gameSpeed = lastGameSpeed;
			}
			HUD.UpdateHUDSpeed();
			if (HUD.Instance != null)
			{
				HUD.Instance.disableSpeedPanel = true;
				for (int i = 0; i < 4; i++)
				{
					HUD.Instance.SpeedToggles[i].isOn = HUD.Instance.GameSpeed == i;
				}
				HUD.Instance.disableSpeedPanel = false;
				HUD.Instance.UpdateBorderOverlay();
				TimeOfDay.SyncPlayerTime();
			}
		}
	}

	public bool LawsuitsQueued
	{
		get
		{
			return _lawsuitQueue.Count > 0;
		}
	}

	public float HeatPercent
	{
		get
		{
			return Heat / 10000000f;
		}
	}

	public static event EventHandler OnQuit;

	public static float GetMetalPriceFactor(int level)
	{
		if (level <= 0)
		{
			return 10000f;
		}
		if (level != 1)
		{
			return 1000000f;
		}
		return 100000f;
	}

	public void EnforceTime(int type)
	{
		if (type > 0 == ForceTimeType > 0)
		{
			return;
		}
		ForceTimeType = type;
		if (type > 0)
		{
			_forcePause = 0;
			ForcePause = false;
			if (HUD.Instance.BuildMode)
			{
				HUD.Instance.BuildMode = false;
			}
			HUD.Instance.disableSpeedPanel = true;
			HUD.Instance.GameSpeed = ((type == 1) ? 1 : 3);
			HUD.Instance.disableSpeedPanel = false;
		}
		for (int i = 0; i < HUD.Instance.SpeedToggles.Length; i++)
		{
			bool interactable = true;
			switch (type)
			{
			case 1:
				interactable = i > 0;
				break;
			case 2:
				interactable = i == 3;
				break;
			}
			HUD.Instance.SpeedToggles[i].interactable = interactable;
		}
	}

	public void AddITStation(Furniture furn)
	{
		ITStations.Add(furn);
		UpdateITTask();
	}

	public void RemoveITStation(Furniture furn)
	{
		ITStations.Remove(furn);
		UpdateITTask();
	}

	public void UpdateITTask()
	{
		if (ITSupportProcess != null)
		{
			if (ITStations.Count == 0)
			{
				string iTSupportServer = ITSupportServer;
				DeregisterServerItem(ITSupportProcess);
				ITSupportProcess = null;
				ITSupportServer = iTSupportServer;
			}
		}
		else if (ITStations.Count > 0)
		{
			ITSupportProcess = new ITServerTask();
			RegisterWithServer(ITSupportServer, ITSupportProcess);
		}
	}

	public int ActiveStations()
	{
		return ITStations.Count((Furniture x) => x.IsOn);
	}

	public void InitITStuff()
	{
		for (int i = 0; i < sRoomManager.AllFurniture.Count; i++)
		{
			Furniture furniture = sRoomManager.AllFurniture[i];
			if (furniture.IsAliveNotNull())
			{
				if (furniture.HasUpg && furniture.ITFix && furniture.upg.Quality < 0.8f)
				{
					BrokenIT.Add(furniture);
				}
				else if ("ITStation".Equals(furniture.Type))
				{
					ITStations.Add(furniture);
				}
			}
		}
		UpdateITTask();
	}

	public void DisableAllAchievements()
	{
		DisableAchievements = true;
	}

	public ValueTuple<RenderTexture, Material> GetCompanyBuildingName(Company c)
	{
		ValueTuple<RenderTexture, Material> value;
		if (!_companyBuildingNames.TryGetValue(c, out value))
		{
			Material material = new Material(SignSDFMat);
			RenderTexture renderTexture = (RenderTexture)(material.mainTexture = new RenderTexture(512, 256, 0));
			SelectorController.Instance.RenderLogo(c.Name, renderTexture);
			return _companyBuildingNames[c] = new ValueTuple<RenderTexture, Material>(renderTexture, material);
		}
		return value;
	}

	public static bool GetPrefServer(string type, out ServerGroup server)
	{
		server = null;
		string value;
		if (!Instance.IsReferenceNull() && Instance.PreferredServerGroup.TryGetValue(type, out value))
		{
			return Instance.TryGetServerGroup(value, out server);
		}
		return false;
	}

	public static void SavePrefServer(string type, string server)
	{
		if (!Instance.IsReferenceNull() && server != null)
		{
			Instance.PreferredServerGroup[type] = server;
		}
	}

	public void UtilityTurn(bool month)
	{
		for (int i = 0; i < 23; i++)
		{
			HourWaterUse[i] = HourWaterUse[i + 1];
			HourWattUse[i] = HourWattUse[i + 1];
			HourWattGen[i] = HourWattGen[i + 1];
			HourGasUse[i] = HourGasUse[i + 1];
		}
		HourWattUse[23] = 0f;
		HourWattGen[23] = 0f;
		HourWaterUse[23] = 0f;
		HourGasUse[23] = 0f;
		if (month)
		{
			for (int j = 0; j < 11; j++)
			{
				MonthWaterUse[j] = MonthWaterUse[j + 1];
				MonthWattUse[j] = MonthWattUse[j + 1];
				MonthWattGen[j] = MonthWattGen[j + 1];
				MonthGasUse[j] = MonthGasUse[j + 1];
			}
			MonthWattUse[11] = 0f;
			MonthWattGen[11] = 0f;
			MonthWaterUse[11] = 0f;
			MonthGasUse[11] = 0f;
		}
	}

	public void UndoDestruction()
	{
		new UndoObject(FixDestructionUndo()).Execute();
		ResetDestruction();
	}

	private UndoObject.UndoAction[] FixDestructionUndo()
	{
		UndoObject.UndoAction[] array = new UndoObject.UndoAction[_destructionUndo.Count];
		int cur = 0;
		for (int i = 0; i < _destructionUndo.Count; i++)
		{
			UndoObject.UndoAction undoAction = _destructionUndo[i];
			Room.CheckDeps(_destructionUndo, array, i, ref cur);
			array[cur] = undoAction;
			cur++;
		}
		return array;
	}

	public void ResetDestruction()
	{
		_destructionUndo.Clear();
		DestructionUndoCost = 0f;
		BuildController.Instance.RefreshRestoreButton();
	}

	public static bool HasCompletedMission(string missionID)
	{
		if (!Instance.IsReferenceNull())
		{
			if (Instance.CampaignMode)
			{
				return Instance.CompletedMissions.Contains(missionID);
			}
			return true;
		}
		return true;
	}

	public static bool HasCompletedOrInMission(string missionID)
	{
		if (!Instance.IsReferenceNull())
		{
			if (Instance.CampaignMode && !Instance.CurrentMissions.Contains(missionID))
			{
				return Instance.CompletedMissions.Contains(missionID);
			}
			return true;
		}
		return true;
	}

	public static void StartNav(Room r)
	{
		if (Instance != null)
		{
			lock (Instance._navRooms)
			{
				Instance._navRooms.Add(r);
			}
		}
	}

	public static void EndNav(Room r)
	{
		if (Instance != null)
		{
			lock (Instance._navRooms)
			{
				Instance._navRooms.Remove(r);
			}
		}
	}

	public void PrinterChanged()
	{
		PrinterChangeCounter++;
	}

	public List<AssemblyLine> GetAssemblyLinesUnsafe()
	{
		return _assemblyLines;
	}

	public IEnumerable<AssemblyLine> GetAssemblyLines()
	{
		lock (_assemblyLines)
		{
			for (int i = 0; i < _assemblyLines.Count; i++)
			{
				yield return _assemblyLines[i];
			}
		}
	}

	public List<Color> GetAssemblyLineColors()
	{
		List<Color> list = new List<Color>();
		lock (_assemblyLines)
		{
			for (int i = 0; i < _assemblyLines.Count; i++)
			{
				list.Add(_assemblyLines[i].AColor);
			}
			return list;
		}
	}

	public void AddAssemblyLine(AssemblyLine line)
	{
		lock (_assemblyLines)
		{
			_assemblyLines.Add(line);
		}
	}

	public void RemoveAssemblyLine(AssemblyLine line)
	{
		lock (_assemblyLines)
		{
			_assemblyLines.Remove(line);
		}
	}

	public void SetDirtyHelipad(int floor)
	{
		if (floor > 0)
		{
			if (_dirtyHelipad.HasValue)
			{
				_dirtyHelipad = Mathf.Max(floor, _dirtyHelipad.Value);
			}
			_dirtyHelipad = floor;
		}
	}

	public void TogglePermanentUnlock(bool value)
	{
		PermanentUnlock = value;
		if (PermanentUnlock)
		{
			ClaimedRewards.AddRange(CompletedTasks);
		}
		HUD.Instance.RefreshBuildButtons();
		HUD.Instance.UpdateFurnitureButtons();
	}

	private void RaiseQuit()
	{
		if (GameSettings.OnQuit != null)
		{
			GameSettings.OnQuit(this, null);
		}
	}

	public void MoveLOD(Furniture f, int from, int to)
	{
		if (from != to)
		{
			DeregisterLOD(f, from);
			RegisterLOD(f, to);
		}
	}

	public void DeregisterLOD(Furniture f, int floor)
	{
		_LODFloors.GetOrAdd(floor, (int x) => new List<Furniture>()).Remove(f);
	}

	public void RegisterLOD(Furniture f, int floor)
	{
		_LODFloors.GetOrAdd(floor, (int x) => new List<Furniture>()).Add(f);
	}

	public bool HasCompletedTask(string task)
	{
		if (!PermanentUnlock || !Options.UnlockedRewards.Contains(task))
		{
			return CompletedTasks.Contains(task);
		}
		return true;
	}

	public bool HasClaimedReward(string task)
	{
		if (!PermanentUnlock || !Options.UnlockedRewards.Contains(task))
		{
			return ClaimedRewards.Contains(task);
		}
		return true;
	}

	public RoomGroup GetRoomGroup(string name)
	{
		if (name != null)
		{
			return RoomGroups.GetOrNull(name);
		}
		return null;
	}

	public IEnumerable<string> GetRoomGroups(bool withReadonly, bool order = false)
	{
		if (order)
		{
			if (!withReadonly)
			{
				return from x in RoomGroups
					where x.Value.SaveMe
					orderby x.Value.Name
					select x.Key;
			}
			return from x in RoomGroups
				orderby x.Value.SaveMe ? 1 : 0, x.Value.Name
				select x.Key;
		}
		if (!withReadonly)
		{
			return from x in RoomGroups
				where x.Value.SaveMe
				select x.Key;
		}
		return RoomGroups.Keys;
	}

	public IEnumerable<RoomGroup> GetUnderlyingRoomGroups(bool withReadonly)
	{
		if (!withReadonly)
		{
			return RoomGroups.Values.Where((RoomGroup x) => x.SaveMe);
		}
		return RoomGroups.Values;
	}

	public RoomGroup AddRoomGroup(string name)
	{
		RoomGroup roomGroup = new RoomGroup(name);
		RoomGroups[name] = roomGroup;
		HUD.Instance.roomGroupWindow.UpdateList();
		return roomGroup;
	}

	public void RemoveRoomFromGroups(Room room)
	{
		foreach (RoomGroup value in RoomGroups.Values)
		{
			value.RemoveRoom(room);
		}
	}

	public bool CancelDanger()
	{
		if (DangerFreebie)
		{
			DangerFreebie = false;
			return TutorialSystem.Instance.StartTutorial("Office Dangers");
		}
		return false;
	}

	public void RemoveRoomGroup(string name)
	{
		RoomGroup roomGroup = GetRoomGroup(name);
		if (roomGroup == null)
		{
			return;
		}
		List<Room> rooms = roomGroup.GetRooms();
		for (int i = 0; i < rooms.Count; i++)
		{
			rooms[i].RoomGroup = null;
		}
		foreach (Actor item in Instance.sActorManager.Staff)
		{
			item.AssignedRoomGroups.Remove(name);
		}
		RoomGroups.Remove(name);
		HUD.Instance.roomGroupWindow.UpdateList();
	}

	private void OnApplicationQuit()
	{
		if (NetworkManager.IsConnected)
		{
			NetworkMessaging.DisconnectMyself();
			NetworkMessaging.SendAllNow();
			NetworkLayer.Active.LeaveLobby();
			NetworkManager.Instance.Connected = false;
		}
		IsQuitting = true;
		Instance = null;
	}

	public ServerGroup GetServerGroup(string name)
	{
		if (name != null)
		{
			return ServerGroups.GetOrNull(name);
		}
		return null;
	}

	public bool TryGetServerGroup(string name, out ServerGroup sv)
	{
		sv = null;
		if (name != null)
		{
			return ServerGroups.TryGetValue(name, out sv);
		}
		return false;
	}

	public ServerGroup GetCloud()
	{
		return ServerGroups.Values.FirstOrDefault((ServerGroup x) => x.IsCloud);
	}

	public IEnumerable<ServerGroup> GetAllServerGroups(bool includeNull = false, bool includeCloud = true)
	{
		if (includeNull)
		{
			yield return null;
		}
		if (!IsNetworkMode)
		{
			foreach (KeyValuePair<string, ServerGroup> item in ServerGroups.OrderBy((KeyValuePair<string, ServerGroup> x) => x.Key))
			{
				yield return item.Value;
			}
			yield break;
		}
		if (includeCloud)
		{
			foreach (KeyValuePair<string, ServerGroup> item2 in from x in ServerGroups
				orderby x.Value.CloudProvider, x.Key
				select x)
			{
				yield return item2.Value;
			}
			yield break;
		}
		foreach (KeyValuePair<string, ServerGroup> item3 in from x in ServerGroups
			where x.Value.CloudProvider == 0
			orderby x.Key
			select x)
		{
			yield return item3.Value;
		}
	}

	public void CleanServerGroups()
	{
		List<ServerGroup> list = new List<ServerGroup>();
		foreach (KeyValuePair<string, ServerGroup> serverGroup in ServerGroups)
		{
			if (serverGroup.Value.Servers.Count == 0)
			{
				list.Add(serverGroup.Value);
			}
		}
		foreach (ServerGroup item in list)
		{
			DestroyServerGroup(item);
		}
	}

	public void FlipBills()
	{
		Dictionary<Company.TransactionCategory, Dictionary<string, float>> billsNext = BillsNext;
		BillsNext = BillsCurrent;
		BillsNext.Clear();
		BillsCurrent = billsNext;
		foreach (KeyValuePair<string, List<float>> miscStat in MiscStats)
		{
			miscStat.Value.Add(0f);
		}
	}

	public void AddUndo(params UndoObject.UndoAction[] undos)
	{
		ResetDestruction();
		int num = undos.Count((UndoObject.UndoAction x) => x.Type == UndoObject.UndoAction.ActionType.Nothing);
		if (num == undos.Length)
		{
			return;
		}
		if (num > 0)
		{
			UndoObject.UndoAction[] array = new UndoObject.UndoAction[undos.Length - num];
			int num2 = 0;
			for (int num3 = 0; num3 < undos.Length; num3++)
			{
				if (undos[num3].Type != UndoObject.UndoAction.ActionType.Nothing)
				{
					array[num2] = undos[num3];
					num2++;
				}
			}
			undos = array;
		}
		UndoButton.SetActive(HUD.Instance.BuildMode);
		UndoList.Add(new UndoObject(undos));
		if (UndoList.Count > MaxUndo)
		{
			UndoList.RemoveAt(0);
		}
		UpdateUndoTip();
	}

	public void ResetUndo()
	{
		UndoList.Clear();
		UndoButton.SetActive(false);
	}

	private void UpdateUndoTip()
	{
		if (UndoList.Count > 0)
		{
			UndoTip.TooltipDescription = UndoList[UndoList.Count - 1].Description;
			UndoTip.UpdateTip();
		}
	}

	public void Undo()
	{
		if (UndoList.Count > 0)
		{
			UndoObject undoObject = UndoList[UndoList.Count - 1];
			UndoList.RemoveAt(UndoList.Count - 1);
			UpdateUndoTip();
			BuildController.Instance.ClearBuild();
			undoObject.Execute();
			if (UndoList.Count == 0)
			{
				UndoButton.SetActive(false);
			}
		}
	}

	public void AddPrintOrder(PrintJob job, bool autoAssign)
	{
		lock (PrintOrders)
		{
			if (!PrintOrders.ContainsKey(job.Target))
			{
				PrintOrders.Add(job.Target, job);
			}
			else
			{
				Debug.Log("Tried adding print job for existing target " + job.Target.GetName());
			}
		}
		if (autoAssign && job.Hardware)
		{
			bool flag = false;
			bool flag2 = false;
			foreach (AssemblyLine assemblyLine in GetAssemblyLines())
			{
				int num = assemblyLine.IsCompatible(job);
				if (num > 1)
				{
					assemblyLine.AddTask(job, false);
					flag = true;
				}
				else if (num > 0)
				{
					flag2 = true;
				}
			}
			if (!flag && flag2)
			{
				foreach (AssemblyLine assemblyLine2 in GetAssemblyLines())
				{
					if (assemblyLine2.IsCompatible(job) > 0)
					{
						assemblyLine2.AddTask(job, false);
					}
				}
			}
		}
		DistributionWindow.RefreshHardwareStats();
	}

	public void PromptPrintAssignment(PrintJob job, bool newTask = true)
	{
		Dictionary<AssemblyLine, int> dictionary = new Dictionary<AssemblyLine, int>();
		bool anyGood = false;
		foreach (AssemblyLine assemblyLine in GetAssemblyLines())
		{
			int num = assemblyLine.IsCompatible(job);
			if (num > 0)
			{
				dictionary[assemblyLine] = num;
				if (num > 1)
				{
					anyGood = true;
				}
			}
		}
		if (dictionary.Count > 0)
		{
			List<AssemblyLine> keys = dictionary.Keys.ToList();
			bool[] selected = (newTask ? dictionary.Select((KeyValuePair<AssemblyLine, int> x) => !anyGood || x.Value > 1).ToArray() : dictionary.Select((KeyValuePair<AssemblyLine, int> x) => x.Key.HasTask(job)).ToArray());
			WindowManager.Instance.MultiWindow.ShowMulti("Assign", dictionary.Select((KeyValuePair<AssemblyLine, int> x) => x.Key.Name + ((x.Value > 1) ? "" : "^")), selected, delegate(int[] xs)
			{
				xs.IndexToBool(selected);
				for (int i = 0; i < selected.Length; i++)
				{
					if (selected[i])
					{
						keys[i].AddTask(job, true);
					}
					else
					{
						keys[i].RemoveTask(job, true);
					}
				}
			}, true, false, false, false, "AssemblyLineWarning", dictionary.Select((KeyValuePair<AssemblyLine, int> x) => x.Key.AColor).ToArray());
		}
		else
		{
			WindowManager.SpawnDialog("NoValidAssemblyLines".Loc(), true, DialogWindow.DialogType.Error);
		}
	}

	public void CancelPrintOrder(IStockable st, bool repercussion)
	{
		if (BoxController.Highlight == st)
		{
			BoxController.Highlight = null;
		}
		PrintJob job = GetPrintJob(st);
		if (job == null)
		{
			return;
		}
		lock (PrintOrders)
		{
			PrintOrders.Remove(st);
		}
		if (job.DealID.HasValue)
		{
			Deal value;
			if (HUD.Instance.dealWindow.AllDeals.TryGetValue(job.DealID.Value, out value) && value.Active)
			{
				if (repercussion)
				{
					PrintDeal printDeal;
					if ((printDeal = value as PrintDeal) != null)
					{
						printDeal.FinalizeDeal();
					}
					else
					{
						HUD.Instance.dealWindow.CancelDeal(value, false);
					}
				}
				else
				{
					HUD.Instance.dealWindow.CancelDeal(value, false);
				}
			}
		}
		else if (repercussion)
		{
			ContractWork work;
			NetworkPrintDeal networkPrintDeal;
			if ((work = st as ContractWork) != null)
			{
				HUD.Instance.contractWindow.ContractResults.Items.Add(new ContractResult(work, true));
			}
			else if ((networkPrintDeal = st as NetworkPrintDeal) != null)
			{
				if (networkPrintDeal.Penalty > 0f && networkPrintDeal.PhysicalCopies < networkPrintDeal.MaxCopies)
				{
					Company playerCompany = simulation.GetPlayerCompany(networkPrintDeal.Client);
					if (playerCompany != null)
					{
						MyCompany.MakeTransaction(0f - networkPrintDeal.Penalty, Company.TransactionCategory.Contracts, true, "Printjobcopies");
						playerCompany.MakeTransaction(networkPrintDeal.Penalty, Company.TransactionCategory.Contracts, true, "Printjobcopies");
					}
				}
				networkPrintDeal.Cancel();
			}
		}
		DistributionWindow.RefreshHardwareStats();
		lock (_assemblyLines)
		{
			_assemblyLines.ForEach(delegate(AssemblyLine x)
			{
				x.DeleteTask(job);
			});
		}
	}

	public void CancelPrintOrder(PrintJob job, bool repercussion)
	{
		CancelPrintOrder(job.Target, repercussion);
	}

	public void CancelPrintNetworkDeals(IStockable target)
	{
		for (int i = 0; i < NetworkPrintOrders.List.Count; i++)
		{
			NetworkPrintDeal networkPrintDeal = NetworkPrintOrders.List[i];
			if (networkPrintDeal.Target == target)
			{
				networkPrintDeal.Cancel();
				i--;
			}
		}
	}

	public static Team GetTeam(string name)
	{
		if (!(Instance != null))
		{
			return null;
		}
		return Instance.sActorManager.Teams.GetOrNull(name);
	}

	public static bool HasTeam(string name)
	{
		if (Instance != null)
		{
			return Instance.sActorManager.Teams.ContainsKey(name);
		}
		return false;
	}

	public void MoveStorage(IStockable source, IStockable target)
	{
		lock (_printsInStorage)
		{
			uint value;
			if (_printsInStorage.TryGetValue(source, out value))
			{
				_printsInStorage.AddUp(target, value);
				_printsInStorage.Remove(source);
			}
		}
	}

	public void SetPrintsToStorage(IStockable st, uint amount, bool add)
	{
		lock (_printsInStorage)
		{
			uint orDefault = _printsInStorage.GetOrDefault(st, 0u);
			if (add)
			{
				orDefault += amount;
				_printsInStorage[st] = orDefault;
			}
			else if (amount >= orDefault)
			{
				_printsInStorage.Remove(st);
			}
			else
			{
				_printsInStorage[st] = orDefault - amount;
			}
		}
	}

	public bool CheckStorage(Dictionary<IStockable, uint> stock, StringBuilder sb)
	{
		bool result = false;
		lock (_printsInStorage)
		{
			HashSet<IStockable> hashSet = new HashSet<IStockable>(_printsInStorage.Keys);
			foreach (KeyValuePair<IStockable, uint> item in stock)
			{
				IStockable key = item.Key;
				hashSet.Remove(key);
				uint orDefault = _printsInStorage.GetOrDefault(key, 0u);
				uint value = item.Value;
				if (orDefault != value)
				{
					if (value == 0)
					{
						_printsInStorage.Remove(key);
					}
					else
					{
						_printsInStorage[key] = value;
					}
					result = true;
					if (sb != null)
					{
						uint num = 0u;
						num = ((value <= orDefault) ? (orDefault - value) : (value - orDefault));
						sb.AppendLine(key.GetIdentifyingName() + " changed by " + num + " copies");
					}
				}
			}
			foreach (IStockable item2 in hashSet)
			{
				if (sb != null)
				{
					sb.AppendLine(item2.GetIdentifyingName() + " changed by " + _printsInStorage[item2] + " copies");
				}
				result = true;
				_printsInStorage.Remove(item2);
			}
			return result;
		}
	}

	public void RegisterStat(string statName, float amount)
	{
		List<float> value;
		if (!MiscStats.TryGetValue(statName, out value))
		{
			value = new List<float>();
			MiscStats[statName] = value;
			SDateTime sDateTime = SDateTime.Now();
			SDateTime start = ((MyCompany.Founded > sDateTime) ? sDateTime : MyCompany.Founded);
			int num = Mathf.Max(1, SDateTime.GetMonthsFlat(start, sDateTime) + 1);
			for (int i = 0; i < num; i++)
			{
				value.Add(0f);
			}
		}
		value[value.Count - 1] += amount;
		if (HUD.Instance.financeWindow.Window.Shown && HUD.Instance.financeWindow.CompanyChartPanel.Stats)
		{
			HUD.Instance.financeWindow.CompanyChartPanel.UpdateChart();
		}
	}

	public static void UnloadNow()
	{
		if (Instance != null)
		{
			Instance.RaiseQuit();
			Instance.simulation.DestroyAtlas();
			Instance.BoxController.StopThread();
			Instance.ConferenceController.StopThread();
		}
		IsQuitting = true;
		if (Instance != null && Instance._simThread != null && Instance._simThread.IsAlive)
		{
			Instance._simThread.Abort();
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			while (Instance._simThread.IsAlive && Time.realtimeSinceStartup - realtimeSinceStartup < 5f)
			{
			}
			Debug.Log("Quitting while simulating: Waited " + (Time.realtimeSinceStartup - realtimeSinceStartup).SecondsToTime() + " - Thread state " + Instance._simThread.ThreadState);
		}
		Instance = null;
	}

	public bool HasPrintJob(PrintJob p)
	{
		PrintJob orDefault;
		lock (PrintOrders)
		{
			orDefault = PrintOrders.GetOrDefault(p.Target);
		}
		return orDefault != null;
	}

	public PrintJob GetPrintJob(IStockable target)
	{
		lock (PrintOrders)
		{
			return PrintOrders.GetOrDefault(target);
		}
	}

	public uint GetPrintsInStorage(IStockable st, bool withStock = false)
	{
		uint num;
		lock (_printsInStorage)
		{
			num = _printsInStorage.GetOrDefault(st, 0u);
		}
		if (withStock)
		{
			num += st.PhysicalCopies;
		}
		return num;
	}

	public bool AnyPrintsInStorage()
	{
		lock (_printsInStorage)
		{
			foreach (KeyValuePair<IStockable, uint> item in _printsInStorage)
			{
				if (item.Value != 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public void RegisterActor(Actor act, bool register)
	{
		if (register)
		{
			if (act.IsEmployee())
			{
				WorkUpdateHandler.RegisterObject(act);
			}
			ActorUpdateHandler.RegisterObject(act);
		}
		else
		{
			WorkUpdateHandler.UnregisterObject(act);
			ActorUpdateHandler.UnregisterObject(act);
		}
	}

	public void RemoveTeamAssociation(Team team)
	{
		foreach (Room room in sRoomManager.Rooms)
		{
			if (room.Teams.Remove(team))
			{
				sRoomManager.TeamAssignmentDirty = true;
			}
		}
		foreach (AutoDevWorkItem item in MyCompany.WorkItems.OfType<AutoDevWorkItem>())
		{
			item.DesignTeams.Remove(team.Name);
			item.SDevTeams.Remove(team.Name);
			item.SecondaryDevTeams.Remove(team.Name);
			item.SupportTeams.Remove(team.Name);
			item.MarketingTeams.Remove(team.Name);
			item.PostMarketingTeams.Remove(team.Name);
			item.UpdateTeams.Remove(team.Name);
			item.PortingTeams.Remove(team.Name);
			item.RefreshTeams();
		}
		TeamDefaults.Values.ForEachEnum(delegate(HashSet<string> x)
		{
			x.Remove(team.Name);
		});
		HUD.Instance.contractWindow.DesignTeams.Remove(team.Name);
		HUD.Instance.contractWindow.DevTeams.Remove(team.Name);
	}

	public void SwitchTeamAssociation(Team team, Team newTeam)
	{
		foreach (Room room in sRoomManager.Rooms)
		{
			if (room.Teams.Contains(team))
			{
				room.Teams.Remove(team);
				room.AddTeam(newTeam);
			}
		}
		foreach (AutoDevWorkItem item in MyCompany.WorkItems.OfType<AutoDevWorkItem>())
		{
			item.DesignTeams.Swap(team.Name, newTeam.Name);
			item.SDevTeams.Swap(team.Name, newTeam.Name);
			item.SecondaryDevTeams.Swap(team.Name, newTeam.Name);
			item.SupportTeams.Swap(team.Name, newTeam.Name);
			item.MarketingTeams.Swap(team.Name, newTeam.Name);
			item.PostMarketingTeams.Swap(team.Name, newTeam.Name);
			item.UpdateTeams.Swap(team.Name, newTeam.Name);
			item.PortingTeams.Swap(team.Name, newTeam.Name);
			item.RefreshTeams();
		}
		TeamDefaults.Values.ForEachEnum(delegate(HashSet<string> x)
		{
			x.Swap(team.Name, newTeam.Name);
		});
		HUD.Instance.contractWindow.DesignTeams.Swap(team.Name, newTeam.Name);
		HUD.Instance.contractWindow.DevTeams.Swap(team.Name, newTeam.Name);
		if (HUD.Instance.AutoDevWindow.Window.Shown)
		{
			HUD.Instance.AutoDevWindow.RefreshTeamLabels(team.Name, newTeam.Name);
		}
		sRoomManager.TeamAssignmentDirty = true;
	}

	public void AddServer(IServerHost server)
	{
		RemoveServer(server);
		if (ServerGroups.ContainsKey(server.ServerName))
		{
			server.ServerName = GenerateServerName();
			return;
		}
		ServerGroup serverGroup = new ServerGroup(server.ServerName);
		ServerGroups[server.ServerName] = serverGroup;
		serverGroup.Servers.Add(server);
		serverGroup.RefreshRep();
		CameraScript.Instance.WireRender.ForceDirty = true;
		CalculateServerPowerNow.Add(serverGroup.Name);
		if (HUD.Instance != null && HUD.Instance.serverWindow != null)
		{
			EventHandler onServersChanged = OnServersChanged;
			if (onServersChanged != null)
			{
				onServersChanged(this, null);
			}
			HUD.Instance.serverWindow.UpdateServerList();
		}
	}

	public string GenerateServerName()
	{
		ServerGroup serverGroup = ServerGroups.Values.FirstOrDefault((ServerGroup x) => x.Servers.Count == 0);
		if (serverGroup != null)
		{
			return serverGroup.Name;
		}
		string text = "Server 0";
		int num = ServerGroups.Count;
		while (ServerGroups.ContainsKey(text))
		{
			text = "Server " + num;
			num++;
		}
		return text;
	}

	public void ChangeServerName(string oldName, string newName)
	{
		ServerGroup value;
		if (!ServerGroups.TryGetValue(oldName, out value))
		{
			return;
		}
		ServerGroups[newName] = value;
		ServerGroups.Remove(oldName);
		value.Name = newName;
		foreach (IServerHost item in value.Servers.ToList())
		{
			item.ServerName = newName;
		}
		foreach (ServerGroup value2 in ServerGroups.Values)
		{
			if (oldName.Equals(value2.Fallback))
			{
				value2.Fallback = newName;
			}
		}
		foreach (IServerItem item2 in value.Items)
		{
			item2.SerializeServer(newName);
		}
		foreach (AutoDevWorkItem item3 in MyCompany.WorkItems.OfType<AutoDevWorkItem>())
		{
			if (oldName.Equals(item3.MainServer))
			{
				item3.MainServer = newName;
			}
			if (oldName.Equals(item3.SCMServer))
			{
				item3.SCMServer = newName;
			}
		}
		if (HUD.Instance != null && HUD.Instance.serverWindow != null)
		{
			EventHandler onServersChanged = OnServersChanged;
			if (onServersChanged != null)
			{
				onServersChanged(this, null);
			}
			HUD.Instance.serverWindow.UpdateServerList();
		}
	}

	public void RemoveServer(IServerHost server, bool destroyIfEmpty = true)
	{
		if (server.ServerName == null)
		{
			return;
		}
		ServerGroup orDefault = ServerGroups.GetOrDefault(server.ServerName);
		if (orDefault != null)
		{
			orDefault.Servers.Remove(server);
			if (orDefault.Servers.Count == 0 && destroyIfEmpty)
			{
				DestroyServerGroup(orDefault);
			}
			else
			{
				orDefault.RefreshRep();
				CalculateServerPowerNow.Add(orDefault.Name);
				FixServerWiringNow.Add(orDefault.Name);
			}
		}
		if (HUD.Instance != null && HUD.Instance.serverWindow != null)
		{
			EventHandler onServersChanged = OnServersChanged;
			if (onServersChanged != null)
			{
				onServersChanged(this, null);
			}
			HUD.Instance.serverWindow.UpdateServerList();
		}
	}

	public bool HasServerName(string name)
	{
		return ServerGroups.ContainsKey(name);
	}

	private void DestroyServerGroup(ServerGroup g)
	{
		foreach (ServerGroup value in ServerGroups.Values)
		{
			if (g.Name.Equals(value.Fallback))
			{
				value.Fallback = null;
			}
		}
		if (g.Items.Count > 0)
		{
			List<IServerItem> list = g.Items.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				RegisterWithServer(null, list[i]);
			}
		}
		ServerGroups.Remove(g.Name);
		if (g.IsCloud)
		{
			NetworkMessaging.SendUpdateCloudService(NetworkManager.LocalPlayerID, -1f, -1f, NetworkMessaging.MessageTarget.Everyone, 0);
		}
	}

	public void ValidateServer(Server server)
	{
		ServerGroup orNull = ServerGroups.GetOrNull(server.ServerName);
		foreach (ServerGroup item in ServerGroups.Values.ToList())
		{
			if (item != orNull && item.Servers.Remove(server))
			{
				if (item.Servers.Count == 0)
				{
					DestroyServerGroup(item);
					continue;
				}
				CalculateServerPowerNow.Add(item.Name);
				item.RefreshRep();
			}
		}
		if (orNull == null)
		{
			AddServer(server);
		}
		else if (orNull.Servers.Add(server))
		{
			CalculateServerPowerNow.Add(orNull.Name);
			orNull.RefreshRep();
			CameraScript.Instance.WireRender.ForceDirty = true;
		}
		if (HUD.Instance != null && HUD.Instance.serverWindow != null)
		{
			EventHandler onServersChanged = OnServersChanged;
			if (onServersChanged != null)
			{
				onServersChanged(this, null);
			}
			HUD.Instance.serverWindow.UpdateServerList();
		}
	}

	public void DeregisterServerItem(IServerItem item)
	{
		if (UnsupportedServerItems.Contains(item))
		{
			UnsupportedServerItems.Remove(item);
			if (HUD.Instance != null)
			{
				HUD.Instance.serverWindow.UpdateServerWarning();
			}
		}
		else
		{
			foreach (ServerGroup value in ServerGroups.Values)
			{
				if (value.Items.Contains(item))
				{
					value.Items.Remove(item);
					break;
				}
			}
		}
		if (HUD.Instance != null && HUD.Instance.serverWindow != null)
		{
			HUD.Instance.serverWindow.UpdateServerList();
		}
		item.SerializeServer(null);
	}

	public void RegisterWithServer(string name, IServerItem item, bool updateGUI = true)
	{
		if (UnsupportedServerItems.Contains(item))
		{
			UnsupportedServerItems.Remove(item);
			if (HUD.Instance != null)
			{
				HUD.Instance.serverWindow.UpdateServerWarning();
			}
		}
		else
		{
			foreach (ServerGroup value in ServerGroups.Values)
			{
				if (value.Items.Contains(item))
				{
					if (value.Name.Equals(name))
					{
						item.SerializeServer(name);
						return;
					}
					value.Items.Remove(item);
					break;
				}
			}
		}
		if (name == null || !ServerGroups.ContainsKey(name))
		{
			if (!item.CancelOnUnload())
			{
				UnsupportedServerItems.Add(item);
				if (HUD.Instance != null)
				{
					HUD.Instance.serverWindow.UpdateServerWarning();
				}
			}
			item.SerializeServer(null);
		}
		else
		{
			ServerGroups[name].Items.Add(item);
			item.SerializeServer(name);
		}
		if (updateGUI && HUD.Instance != null && HUD.Instance.serverWindow != null)
		{
			HUD.Instance.serverWindow.UpdateItems();
		}
	}

	public static void ResetForcePause()
	{
		_forcePause = 0;
		FreezeGame = false;
	}

	private void OnDestroy()
	{
		Application.wantsToQuit -= OnWantsToQuit;
		if (Instance == this)
		{
			ResetForcePause();
			Instance = null;
		}
		foreach (KeyValuePair<Company, ValueTuple<RenderTexture, Material>> companyBuildingName in _companyBuildingNames)
		{
			UnityEngine.Object.Destroy(companyBuildingName.Value.Item1);
		}
		foreach (HardwareDesignFurn.HardwareFurnInstance value in _hardwareFurnInstances.Values)
		{
			value.Clear();
		}
		_companyBuildingNames.Clear();
		DestroyGrassTrot();
		RoomManager.TempGroupPool.ReleaseAll();
	}

	private void OnDrawGizmosSelected()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		Gizmos.color = Color.red;
		foreach (WallEdge allSegment in sRoomManager.AllSegments)
		{
			if (allSegment.Floor != ActiveFloor)
			{
				continue;
			}
			Gizmos.DrawWireSphere(allSegment.Pos.ToVector3(ActiveFloor * 2), 0.05f);
			foreach (KeyValuePair<IRoom, WallEdge> link in allSegment.Links)
			{
				Gizmos.DrawLine(allSegment.Pos.ToVector3(ActiveFloor * 2), link.Value.Pos.ToVector3(ActiveFloor * 2));
			}
		}
	}

	public int GetWindowID()
	{
		WindowIDCounter++;
		return WindowIDCounter;
	}

	public uint GetWorkItemID()
	{
		WorkItemIDCounter++;
		return WorkItemIDCounter;
	}

	public Color GetDefaultColor(string key, Color def)
	{
		return ColorDefaults.GetOrDefault(key, def);
	}

	public string GetDefaultStyle(string key, string def)
	{
		return StyleDefaults.GetOrDefault(key, def);
	}

	public string CompareObjects(object obj1, object obj2, string fieldName, string typeName)
	{
		if (obj1 == null && obj2 == null)
		{
			return null;
		}
		if (obj1 == null)
		{
			return "Got different null values with " + obj2.ToString() + " for field " + fieldName + " in type " + typeName;
		}
		if (obj2 == null)
		{
			return "Got different null values with " + obj1.ToString() + " for field " + fieldName + " in type " + typeName;
		}
		if (Cached.Contains(obj1))
		{
			return null;
		}
		Cached.Add(obj1);
		Type type = obj1.GetType();
		Type type2 = obj2.GetType();
		if (type != type2)
		{
			return "Got 2 types " + type.Name + " " + type2.Name + " for field " + fieldName;
		}
		if (type.IsArray)
		{
			Array array = (Array)obj1;
			Array array2 = (Array)obj2;
			if (array.Rank != array2.Rank)
			{
				return "Got different ranks for array field " + fieldName + " in type " + typeName;
			}
			for (int i = 0; i < array.Rank; i++)
			{
				if (array.GetLength(i) != array2.GetLength(i))
				{
					return "Got different array lengths for field " + fieldName + " in type " + typeName;
				}
			}
			IEnumerator enumerator = array.GetEnumerator();
			IEnumerator enumerator2 = array2.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator2.MoveNext();
				string text = CompareObjects(enumerator.Current, enumerator2.Current, fieldName, typeName);
				if (text != null)
				{
					return text;
				}
			}
			return null;
		}
		if (type.GetInterface("System.Collections.IList") != null)
		{
			IList list = (IList)obj1;
			IList list2 = (IList)obj2;
			if (list.Count != list2.Count)
			{
				return "Got different List lengths for field " + fieldName + " in type " + typeName;
			}
			for (int j = 0; j < list.Count; j++)
			{
				string text2 = CompareObjects(list[j], list2[j], fieldName, typeName);
				if (text2 != null)
				{
					return text2;
				}
			}
			return null;
		}
		if (type.GetInterface("System.Collections.IDictionary") != null)
		{
			IDictionary dictionary = (IDictionary)obj1;
			IDictionary dictionary2 = (IDictionary)obj2;
			if (dictionary.Count != dictionary2.Count)
			{
				return "Got different List lengths for field " + fieldName + " in type " + typeName;
			}
			IDictionaryEnumerator enumerator3 = dictionary.GetEnumerator();
			IDictionaryEnumerator enumerator4 = dictionary2.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				enumerator4.MoveNext();
				string text3 = CompareObjects(enumerator3.Key, enumerator4.Key, fieldName + " key", typeName);
				if (text3 != null)
				{
					return text3;
				}
				text3 = CompareObjects(enumerator3.Value, enumerator4.Value, fieldName + " value", typeName);
				if (text3 != null)
				{
					return text3;
				}
			}
			return null;
		}
		if (type == typeof(string))
		{
			if (!obj1.Equals(obj2))
			{
				return string.Concat("Got different values ", obj1, " and ", obj2, " for field ", fieldName, " in type ", typeName);
			}
			return null;
		}
		if (type.IsPrimitive)
		{
			if (!obj1.Equals(obj2))
			{
				return "Got different values " + obj1.ToString() + " and " + obj2.ToString() + " for field " + fieldName + " in type " + typeName;
			}
			return null;
		}
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			object value = fieldInfo.GetValue(obj1);
			object value2 = fieldInfo.GetValue(obj2);
			string text4 = CompareObjects(value, value2, fieldInfo.Name, type.Name);
			if (text4 != null)
			{
				return text4;
			}
		}
		return null;
	}

	public void InitPlots(bool color)
	{
		if (color)
		{
			RecolorPlots(PlotColors.Take(PlotColors.Length - 1).ToArray(), PlotColors[PlotColors.Length - 1]);
		}
		uint num = 1u;
		foreach (PlotArea plot in GetPlots())
		{
			if (plot.ID == 0)
			{
				plot.ID = num;
				num++;
			}
			if (!plot.IsInitialized())
			{
				plot.CreateObject(PlotPrefab).transform.SetParent(PlotHolder, false);
			}
		}
	}

	public List<UndoObject.UndoAction> BuyPlot(PlotArea plot, bool updateOwner)
	{
		if (!plot.PlayerOwned)
		{
			if (updateOwner)
			{
				if (IsNetworkMode)
				{
					byte b = NetworkManager.LocalPlayerID;
					if (b == byte.MaxValue)
					{
						b = 1;
						Debug.Log("Tried to buy plot with network id 255, using 1 instead");
					}
					NetworkMessaging.SendPlotOwner(plot.ID, b, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					TransmitExtraWorth();
					plot.SetOwner(b);
				}
				else
				{
					plot.SetOwner(1);
				}
			}
			plot.AddonCost = 0f;
			RoadManager.Instance.UpdateParkingAvailability(false);
			List<UndoObject.UndoAction> list = RoadManager.Instance.UpdateScrapers();
			List<Furniture> furnitures = sRoomManager.Outside.GetFurnitures();
			for (int i = 0; i < furnitures.Count; i++)
			{
				Furniture furniture = furnitures[i];
				if (furniture.IsAliveNotNull() && furniture.PartOfGen && Utilities.IsInside(furniture.transform.position.FlattenVector3(), plot.Polygon))
				{
					furniture.PartOfGen = false;
					if (furniture.NetworkID != 0)
					{
						NetworkMessaging.SendDestroyNetworkObject(furniture.NetworkID, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
						furniture.NetworkID = 0u;
						furniture.SendNetwork();
					}
					list.Add(new UndoObject.UndoAction(furniture, true, null));
				}
			}
			return list;
		}
		return null;
	}

	public List<UndoObject.UndoAction> SellPlot(PlotArea plot, List<Room> destroyed, bool updateOwner)
	{
		if (plot.PlayerOwned)
		{
			if (updateOwner)
			{
				if (IsNetworkMode)
				{
					NetworkMessaging.SendPlotOwner(plot.ID, 0, false, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					TransmitExtraWorth();
					NetworkManager.Instance.TradeController.CancelAllTradesFor(plot);
				}
				plot.SetOwner(0);
			}
			HashSet<Room> rooms = sRoomManager.Rooms.ToHashSet();
			for (int i = 0; i < destroyed.Count; i++)
			{
				rooms.Remove(destroyed[i]);
			}
			for (int j = 1; j < MaxFloor; j++)
			{
				int tI = j;
				foreach (Room item in sRoomManager.Rooms.Where((Room x) => x.Floor == tI && rooms.Contains(x)))
				{
					if (!item.IsSupported(rooms))
					{
						rooms.Remove(item);
						destroyed.Add(item);
					}
				}
			}
			HashSet<Roof> hashSet = new HashSet<Roof>();
			for (int num = 0; num < destroyed.Count; num++)
			{
				Room room = destroyed[num];
				if (room.Roofing != null)
				{
					hashSet.Add(room.Roofing);
				}
			}
			HashSet<Furniture> hashSet2 = new HashSet<Furniture>();
			HashSet<RoomSegment> segments = new HashSet<RoomSegment>();
			List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
			List<UndoObject.UndoAction> list2 = new List<UndoObject.UndoAction>();
			foreach (Roof item2 in hashSet)
			{
				if (item2.IsAliveNotNull())
				{
					list2.Add(new UndoObject.UndoAction(false, item2));
					item2.DestroyGO();
				}
			}
			HashSet<Room> destroy = destroyed.ToHashSet();
			foreach (Room item3 in destroyed.OrderByDescending((Room x) => x.GetAtriumSubOrder()))
			{
				if (item3.IsAliveNotNull())
				{
					list2.Add(new UndoObject.UndoAction(item3, false, 0f));
					List<RoomSegment> segments2 = item3.GetSegments(destroy);
					list.AddRange(segments2.WhereSelect((RoomSegment z) => !segments.Contains(z), (RoomSegment z) => new UndoObject.UndoAction(z, false)));
					segments.AddRange(segments2);
					hashSet2.AddRange(item3.GetFurnitures());
					item3.DestroyGO();
				}
			}
			list2.Reverse();
			list2.AddRange(list);
			list2.AddRange(from z in hashSet2
				where z.IsAliveNotNull()
				orderby z.GetSnappingDepth()
				select new UndoObject.UndoAction(z, false));
			List<Furniture> furnitures = sRoomManager.Outside.GetFurnitures();
			for (int num2 = 0; num2 < furnitures.Count; num2++)
			{
				Furniture furniture = furnitures[num2];
				if (furniture.IsAliveNotNull())
				{
					if (!furniture.PartOfGen && !PlayerOwnedArea(furniture.FinalBoundary, false, plot))
					{
						list2.Add(new UndoObject.UndoAction(furniture, false));
						furniture.DestroyGO();
					}
					else if (SelectorController.Instance.Selected.Contains(furniture))
					{
						furniture.Highlight(false);
						SelectorController.Instance.Selected.Remove(furniture);
					}
				}
			}
			RoadManager.Instance.UpdateParkingAvailability(false);
			return list2;
		}
		return null;
	}

	public static void GlassOpaqueChange()
	{
		if (Instance != null)
		{
			Furniture.UpdateEdgeDetection();
			for (int i = 0; i < Instance.sRoomManager.Rooms.Count; i++)
			{
				Room room = Instance.sRoomManager.Rooms[i];
				room.UpdateSurrounded();
				room.UpdateVisibility();
			}
		}
	}

	public Rect PlotRect()
	{
		if (PlayerPlots.Count == 0)
		{
			return new Rect(0f, 0f, 0f, 0f);
		}
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		for (int i = 0; i < PlayerPlots.Count; i++)
		{
			PlotArea plotArea = PlayerPlots[i];
			for (int j = 0; j < plotArea.Polygon.Length; j++)
			{
				Vector2 vector = plotArea.Polygon[j];
				num = Math.Min(num, vector.x);
				num2 = Math.Min(num2, vector.y);
				num3 = Math.Max(num3, vector.x);
				num4 = Math.Max(num4, vector.y);
			}
		}
		return Rect.MinMaxRect(num, num2, num3, num4);
	}

	public Rect BuildingRect()
	{
		if (sRoomManager.Rooms.Count == 0)
		{
			return new Rect(0f, 0f, 0f, 0f);
		}
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		for (int i = 0; i < sRoomManager.Rooms.Count; i++)
		{
			Room room = sRoomManager.Rooms[i];
			for (int j = 0; j < room.Edges.Count; j++)
			{
				WallEdge wallEdge = room.Edges[j];
				num = Math.Min(num, wallEdge.Pos.x);
				num2 = Math.Min(num2, wallEdge.Pos.y);
				num3 = Math.Max(num3, wallEdge.Pos.x);
				num4 = Math.Max(num4, wallEdge.Pos.y);
			}
		}
		return Rect.MinMaxRect(num - 1f, num2 - 1f, num3 + 1f, num4 + 1f);
	}

	public bool PlayerOwnedPoint(Vector2 p, bool allowRoads = false, PlotArea ignorePlot = null, bool allowBus = false)
	{
		if (allowBus && p.x > BusStopSign.transform.position.x - 2f && p.x < BusStopSign.transform.position.x + 2f && p.y > BusStopSign.transform.position.z - 14f && p.y < BusStopSign.transform.position.z + 3f)
		{
			return true;
		}
		if (allowRoads && RoadManager.Instance.GetRoad(p, 0) == 1)
		{
			float offset = (IsNetworkMode ? (RoadManager.Instance.RoadSize / 2f + 0.01f) : RoadManager.Instance.RoadSize);
			for (int i = 0; i < PlayerPlots.Count; i++)
			{
				if (PlayerPlots[i] != ignorePlot && PlayerPlots[i].IsInside(p, offset))
				{
					return true;
				}
			}
			return false;
		}
		for (int j = 0; j < PlayerPlots.Count; j++)
		{
			if (PlayerPlots[j] != ignorePlot && PlayerPlots[j].IsInside(p))
			{
				return true;
			}
		}
		return false;
	}

	public PlotArea GetPlot(Vector2 p)
	{
		if (RoadManager.Instance.GetRoad(p, 0) == 1)
		{
			float offset = (IsNetworkMode ? (RoadManager.Instance.RoadSize / 2f + 0.01f) : RoadManager.Instance.RoadSize);
			for (int i = 0; i < Plots.Count; i++)
			{
				if (Plots[i].IsInside(p, offset))
				{
					return Plots[i];
				}
			}
			for (int j = 0; j < PlayerPlots.Count; j++)
			{
				if (PlayerPlots[j].IsInside(p, offset))
				{
					return PlayerPlots[j];
				}
			}
			return null;
		}
		for (int k = 0; k < Plots.Count; k++)
		{
			if (Plots[k].IsInside(p))
			{
				return Plots[k];
			}
		}
		for (int l = 0; l < PlayerPlots.Count; l++)
		{
			if (PlayerPlots[l].IsInside(p))
			{
				return PlayerPlots[l];
			}
		}
		return null;
	}

	public bool PlayerOwnedLine(Vector2 a, Vector2 b, bool allowRoads = false, PlotArea ignorePlot = null, bool allowBus = false)
	{
		Vector2 vector = b - a;
		float magnitude = vector.magnitude;
		vector *= 1f / magnitude;
		for (float num = 0.5f; num < magnitude; num += 0.5f)
		{
			if (!PlayerOwnedPoint(a + vector * num, allowRoads, ignorePlot, allowBus))
			{
				return false;
			}
		}
		return true;
	}

	public bool PlayerOwnedArea(IList<Vector2> area, bool allowRoads = false, PlotArea ignorePlot = null, bool allowBus = false)
	{
		for (int i = 0; i < area.Count; i++)
		{
			Vector2 vector = area[i];
			if (!PlayerOwnedPoint(vector, allowRoads, ignorePlot, allowBus))
			{
				return false;
			}
			Vector2 b = area[(i + 1) % area.Count];
			if (!PlayerOwnedLine(vector, b, allowRoads, ignorePlot, allowBus))
			{
				return false;
			}
		}
		int[] array = new Triangulator(area).Triangulate();
		for (int j = 0; j < array.Length; j += 3)
		{
			Vector2 triangleCentroid = Utilities.GetTriangleCentroid(area[array[j]], area[array[j + 1]], area[array[j + 2]]);
			if (!PlayerOwnedPoint(triangleCentroid, allowRoads, ignorePlot, allowBus))
			{
				return false;
			}
		}
		return true;
	}

	public IEnumerable<PlotArea> GetPlots()
	{
		for (int i = 0; i < Plots.Count; i++)
		{
			yield return Plots[i];
		}
		for (int i = 0; i < PlayerPlots.Count; i++)
		{
			yield return PlayerPlots[i];
		}
	}

	public PlotArea GetPlot(uint id)
	{
		for (int i = 0; i < Plots.Count; i++)
		{
			PlotArea plotArea = Plots[i];
			if (plotArea.ID == id)
			{
				return plotArea;
			}
		}
		for (int j = 0; j < PlayerPlots.Count; j++)
		{
			PlotArea plotArea2 = PlayerPlots[j];
			if (plotArea2.ID == id)
			{
				return plotArea2;
			}
		}
		return null;
	}

	public void UpdateCutoffShaders()
	{
		Shader.SetGlobalFloat("_HeightCutoff", ActiveFloor / 2 * 4 + 4);
		Shader.SetGlobalFloat("_SupportHeightCutoff", ActiveFloor * 2 + 2);
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(Instance);
		}
		_leaveShake = LeaveTime;
		LastInstance = (Instance = this);
		PipeMat = new Material(PipeMat);
		Application.wantsToQuit += OnWantsToQuit;
	}

	private bool OnWantsToQuit()
	{
		if (!HasQuitSaved && LastInstance != null && LastInstance.IsNetworkMode)
		{
			GameSettings instance = Instance;
			Instance = LastInstance;
			SaveGameManager.Instance.AutoSave();
			Thread.Sleep(100);
			lock (GameReader.WriteLock)
			{
				Thread.Sleep(1);
			}
			Instance = instance;
			HasQuitSaved = true;
		}
		return true;
	}

	public void CreateOutsideGroup()
	{
		RoomGroup roomGroup = new RoomGroup("Outside".Loc());
		roomGroup.SaveMe = false;
		roomGroup.AddRoom(sRoomManager.Outside);
		RoomGroups["CannotDeleteOutsideRoomLol"] = roomGroup;
	}

	private void CreateMetalMarkets()
	{
		MetalMarkets = new List<StockMarket>
		{
			new StockMarket("Gold", 0.5f, 4f),
			new StockMarket("Silver", 0.5f, 4f),
			new StockMarket("Copper", 0.5f, 4f)
		};
	}

	private void Start()
	{
		PipLight.ForceWhite = false;
		AchievementController.Init();
		SDFCreator.Bind();
		ScissorPool = new ObjectPool<ScissorLift>(() => UnityEngine.Object.Instantiate(ScissorPrefab), delegate(ScissorLift x)
		{
			x.gameObject.SetActive(true);
		}, delegate(ScissorLift x)
		{
			x.gameObject.SetActive(false);
		});
		LastSaveTime = DateTime.Now;
		InitGrassTrot();
		UpdateCutoffShaders();
		DaysPerMonth = GameData.DaysPerMonth;
		LeaveMat = new Material(LeaveMat);
		TreeRoot = new GameObject("Trees");
		ResetForcePause();
		GameSpeed = 1f;
		Dictionary<string, SoftwareType> dictionary = GameData.AllSoftwareTypes().ToDictionary((SoftwareType x) => x.Name);
		string[][] specialization = GameData.GetSpecialization(dictionary.Values.ToArray());
		CodeSpecializations = specialization[1];
		ArtSpecializations = specialization[2];
		Specializations = specialization[0];
		Dictionary<string, CompanyType> companyTypes = GameData.AllCompanyTypes().ToDictionary((CompanyType x) => x.Name);
		Dictionary<string, RandomNameGenerator> rng = GameData.MergeGenerators(GameData.AllNameGenerators());
		Personalities = GameData.AllPersonalities();
		GameData.ModPackages.ForEach(delegate(ModPackage x)
		{
			x.Enabled = false;
		});
		sRoomManager = new RoomManager();
		Room component = UnityEngine.Object.Instantiate(RoomObject).GetComponent<Room>();
		component.Init(null, 0, false, null, true, false);
		component.Outside = true;
		sRoomManager.Outside = component;
		sRoomManager.RoomNearnessDirty = true;
		CreateOutsideGroup();
		EditMode = GameData.EditMode;
		GameData.CampaignMode = false;
		if (EditMode && !GameData.LoadAnyOnLoad)
		{
			RentMode = true;
		}
		TimeOfDay.Instance.InitYear(GameData.ActiveYear);
		if (!GameData.LoadBuildingOnLoad)
		{
			EnvType = GameData.Environment;
			CliType = GameData.Climate;
			TimeOfDay.Instance.CurrentWeather = ObjectDatabase.Instance.WeatherPresets[(int)CliType];
			Environment = ObjectDatabase.Instance.EnvironmentPresets[(int)EnvType];
			CritterController.Instance.PopulateCritter(CliType, EnvType);
			TimeOfDay.Instance.UpdateExtraLayerColor();
			TimeOfDay.Instance.RunUpdate();
			UISoundFX.ChangeMusicState("Spring");
		}
		tTreeTrunkMat = new Material((CliType == GameData.ClimateType.Warm) ? CactusTrunkMat : TreeTrunkMat);
		sActorManager = new ActorManager();
		simulation = new MarketSimulation(!EditMode, new SDateTime(1970), dictionary, companyTypes, rng);
		if (GameData.RestartCompany)
		{
			MyCompany = new Company(GameData.CompanyName, GameData.StartingMoney, GameData.CompanyDate, GameData.RestartCompanyID);
			if (GameData.RestartEvents != null)
			{
				MyCompany.MarketEvents.InsertRange(0, GameData.RestartEvents);
				GameData.RestartEvents = null;
			}
		}
		else
		{
			MyCompany = new Company(EditMode ? "Company Name" : GameData.CompanyName, GameData.StartingMoney, new SDateTime(GameData.ActiveYear + 1900), simulation);
		}
		MyCompany.RepEffects = new Dictionary<string, Company.RepEffectItem>();
		MyCompany.Player = true;
		MyCompany.Logo = (EditMode ? SDFCreator.GetTreeFromString("TYwxEsIwDAStk+3YiZOUTBr+AB9IQ0FDxTOoqCjDDD+gy0dSQsmzhBwmE3SNTrc6MhRkUPVGR8TASy/DdJN3ttMVDA3sDGH7g+D0Rv6Z5k/V2I0dFRoNj8viEcgYxEyWOVlJVNrCaT/PGuVucnVeD0cFmtd5I/fdP/A5GdsuJjIT2LGFdyjAgQqOwaKMXPkSqUJt0dTcpuYL") : GameData.CompanyLogo);
		simulation.AddCompany(MyCompany, false);
		if (!GameData.LoadCompanyOnLoad && !NetworkManager.IsClient && !EditMode)
		{
			CreateMetalMarkets();
			IsQuitting = false;
			_simThread = new Thread(InitSimThread);
			for (int num = 0; num < 5; num++)
			{
				GenerateStockMarket();
			}
			if (GameData.LoadAnyOnLoad)
			{
				StartCoroutine(DelaySimThread());
			}
			else
			{
				_simThread.Start();
			}
			CompanyBenefits = EmployeeBenefit.GetDefaultBenefits();
			HUD.Instance.contractWindow.UpdateContracts(TimeOfDay.Instance.GetDate(true));
			Difficulty = GameData.SelectedDifficulty;
		}
		else
		{
			TimeOfDay.Instance.DisableSunUpdate = false;
		}
		if (GameData.Founders != null)
		{
			Founders = GameData.Founders.ToList();
			GameData.Founders = null;
			foreach (Actor founder in Founders)
			{
				founder.enabled = true;
				founder.employee.Employ(MyCompany, SDateTime.Now(), false);
				SceneManager.MoveGameObjectToScene(founder.gameObject, base.gameObject.scene);
				if (founder.employee.LeadSpecPick != null)
				{
					founder.employee.LeadSpecializationFix[founder.employee.LeadSpecPick] = 1f;
					founder.employee.LeadSpecPick = null;
				}
			}
			if (Founders.Count > 1)
			{
				MyCompany.CreateFounderStocks((from x in Founders.Skip(1)
					select x.employee).ToArray(), simulation, GameData.ActiveYear);
			}
		}
		BuildController.Instance.ResetGrid();
		if (EditMode)
		{
			MyCompany.InfiniteMoney();
			HUD.Instance.BuildMode = true;
			PlotArea plotArea = new PlotArea(new PlotArea.PlotPoint(248f, 8f), new PlotArea.PlotPoint(248f, 248f), new PlotArea.PlotPoint(8f, 248f), new PlotArea.PlotPoint(8f, 8f));
			Plots.Add(plotArea);
			plotArea.SetOwner(1);
			InitPlots(false);
			TimeOfDay.Instance.DisableSunUpdate = false;
		}
		if (CliType == GameData.ClimateType.Warm)
		{
			TimeOfDay.Instance.GroundMat.SetTexture("_GrassNormal", null);
			TimeOfDay.Instance.GroundMat2.SetTexture("_GrassNormal", null);
		}
	}

	public HardwareDesignFurn.HardwareFurnInstance GetHardwareFurnInstance(uint productID, uint addonId, IDisplayable product)
	{
		KeyValuePair<uint, uint> key = new KeyValuePair<uint, uint>(productID, addonId);
		HardwareDesignFurn.HardwareFurnInstance value;
		if (_hardwareFurnInstances.TryGetValue(key, out value))
		{
			return value;
		}
		if (product == null)
		{
			return null;
		}
		float price = 0f;
		SoftwareProduct softwareProduct;
		AddOnProduct addOnProduct;
		if ((softwareProduct = product as SoftwareProduct) != null)
		{
			price = softwareProduct.Price;
		}
		else if ((addOnProduct = product as AddOnProduct) != null)
		{
			price = addOnProduct.Price;
		}
		value = new HardwareDesignFurn.HardwareFurnInstance(key.Key, key.Value, price, product.GetName(), product.HardwareDesign);
		if (value.LoadData())
		{
			_hardwareFurnInstances[key] = value;
			return value;
		}
		return null;
	}

	public void CountHardwareFurnInstance(uint productID, uint addonId, bool add)
	{
		KeyValuePair<uint, uint> key = new KeyValuePair<uint, uint>(productID, addonId);
		HardwareDesignFurn.HardwareFurnInstance value;
		if (_hardwareFurnInstances.TryGetValue(key, out value))
		{
			value.Count += (add ? 1 : (-1));
			if (value.Count == 0)
			{
				value.Clear();
				_hardwareFurnInstances.Remove(key);
			}
		}
	}

	public void Generate()
	{
		if (GameData.LoadBuildingOnLoad)
		{
			return;
		}
		CachedTrees = ObjectDatabase.Instance.Trees.Where((StaticTree x) => x.ValidFor(CliType)).ToArray();
		RNDString = GameData.RandomString;
		GameData.InitRND();
		if (EnvType == GameData.EnvironmentType.Rural && !EditMode)
		{
			Plots = PlotArea.GenerateRandom(GameData.RuralBigPlots, GameData.MultiplayerMode);
			InitPlots(true);
			PlotArea plotArea = Plots[0];
			plotArea.Price = (GameData.MultiplayerMode ? 0f : PlotArea.StartPlotPrice);
			BuyPlot(plotArea, true);
			if (GameData.MultiplayerMode)
			{
				for (int num = 0; num < 3; num++)
				{
					Plots[num].Price = 0f;
				}
				NetworkManager.Self.StartPlot = plotArea.ID;
			}
		}
		if (EnvType != GameData.EnvironmentType.Rural)
		{
			return;
		}
		SpawnTrees();
		if (!RNDString.StartsWith("NOLAKES"))
		{
			float num2 = 6000f;
			List<PlotArea> list = (EditMode ? PlotArea.GenerateRandom(false, GameData.MultiplayerMode) : Plots).OrderByDescending((PlotArea x) => x.Area).ToList();
			while (num2 > 0f)
			{
				int index = GameData.RNDRange(0, Mathf.FloorToInt((float)list.Count * 0.5f));
				PlotArea plotArea2 = list[index];
				num2 -= plotArea2.Area;
				RoadManager.Instance.CreateLake(plotArea2.Polygon);
				Plots.Remove(plotArea2);
				list.RemoveAt(index);
				if (!EditMode)
				{
					UnityEngine.Object.Destroy(plotArea2.PlotObject.gameObject);
				}
			}
		}
		if (!EditMode)
		{
			GenerateMills(Plots.Where((PlotArea x) => !x.PlayerOwned).MinInstance((PlotArea x) => Mathf.Abs(x.Area - 1000f)));
		}
		TimeOfDay.Instance.GroundTopDirty = true;
	}

	private void GenerateMills(PlotArea a)
	{
		Rect bounds = ((IList<Vector2>)a.Polygon).GetBounds();
		int num = 14;
		int num2 = Mathf.FloorToInt(bounds.xMin / (float)num);
		int num3 = Mathf.FloorToInt(bounds.yMin / (float)num);
		int num4 = Mathf.CeilToInt(bounds.xMax / (float)num);
		int num5 = Mathf.CeilToInt(bounds.yMax / (float)num);
		GameObject furniture = ObjectDatabase.Instance.GetFurniture("Wind turbine");
		for (int i = num2; i < num4; i++)
		{
			for (int j = num3; j < num5; j++)
			{
				float x = (float)(i * num) + (float)num * 0.5f;
				float num6 = (float)(j * num) + (float)num * 0.5f;
				if (Utilities.IsInside(new Vector2(x, num6), a.Polygon))
				{
					bool inventory;
					Furniture furniture2 = FurnitureBuilder.MakeFurn(new Vector3(x, 0f, num6), Quaternion.identity, sRoomManager.Outside, null, null, 0f, false, null, furniture, 0f, false, out inventory, true, true);
					if (IsNetworkMode)
					{
						NetworkManager.Instance.SetAndRegisterNetworkObject(furniture2);
					}
					a.AddonCost += furniture2.Cost * 0.75f;
					furniture2.Insured = false;
				}
			}
		}
	}

	private IEnumerator DelaySimThread()
	{
		yield return new WaitForEndOfFrame();
		while (LoadingCamera.gameObject.activeSelf)
		{
			yield return new WaitForEndOfFrame();
		}
		_simThread.Start();
	}

	private static string MakeStockmaketName()
	{
		string text = "";
		for (int i = 0; i < 3; i++)
		{
			text += (char)(65 + UnityEngine.Random.Range(0, 25));
		}
		return text;
	}

	public void GenerateStockMarket()
	{
		string newName = MakeStockmaketName();
		while (_stockNameFilter.Contains(newName) || StockMarkets.Any((StockMarket x) => x.Name.Equals(newName)))
		{
			newName = MakeStockmaketName();
		}
		StockMarket stockMarket = new StockMarket(newName, 0.5f, 4f);
		StockMarkets.Add(stockMarket);
		NetworkMessaging.SendAddStockMarket(stockMarket.Name, stockMarket.Range, stockMarket.Factor, stockMarket.History, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
	}

	private void RecolorPlots(Color[] colors, Color defCol)
	{
		List<int> list = new List<int>();
		Dictionary<PlotArea, List<PlotArea>> dictionary = new Dictionary<PlotArea, List<PlotArea>>();
		List<PlotArea> list2 = GetPlots().ToList();
		for (int i = 0; i < list2.Count; i++)
		{
			PlotArea plotArea = list2[i];
			for (int j = i + 1; j < list2.Count; j++)
			{
				PlotArea p = list2[j];
				if (plotArea.Points.Any((KeyValuePair<PlotArea.PlotPoint, PlotArea.PointLink> x) => p.Points.ContainsKey(x.Key)))
				{
					dictionary.Append(plotArea, p);
					dictionary.Append(p, plotArea);
				}
			}
		}
		Dictionary<PlotArea, int> dictionary2 = new Dictionary<PlotArea, int>();
		foreach (PlotArea item in from x in dictionary
			orderby x.Value.Count descending
			select x.Key)
		{
			list.AddRange(Enumerable.Range(0, colors.Length));
			foreach (KeyValuePair<PlotArea, int> p2 in dictionary2)
			{
				if (item.Points.Any((KeyValuePair<PlotArea.PlotPoint, PlotArea.PointLink> x) => p2.Key.Points.ContainsKey(x.Key)))
				{
					list.Remove(p2.Value);
				}
			}
			if (list.Count > 0)
			{
				int num = (dictionary2[item] = list.GetRandom());
				item.PlotColor = colors[num];
			}
			else
			{
				item.PlotColor = defCol;
			}
			list.Clear();
		}
	}

	public void SimulateWork(SDateTime start, float deltaInMinutes)
	{
		for (int i = 0; i < ReviewJobs.Count; i++)
		{
			ReviewJobs[i].Tick(deltaInMinutes);
		}
		for (int j = 0; j < FollowerSimulation.Count; j++)
		{
			FollowerSimulation[j].SimulateFollowers(deltaInMinutes);
		}
		if (MyCompany == null || MyCompany.WorkItems.Count <= 0)
		{
			return;
		}
		bool num = deltaInMinutes > 10f;
		float num2 = deltaInMinutes;
		bool flag = !num;
		bool flag2 = num || (start.Hour >= 8 && start.Hour < 16);
		_workItemUpdateLoopCache.Clear();
		_workItemUpdateLoopCache.AddRange(MyCompany.WorkItems);
		for (int k = 0; k < _workItemUpdateLoopCache.Count; k++)
		{
			WorkItem workItem = _workItemUpdateLoopCache[k];
			AutoDevWorkItem autoDevWorkItem;
			if ((autoDevWorkItem = workItem as AutoDevWorkItem) != null)
			{
				if (!autoDevWorkItem.Hidden)
				{
					try
					{
						autoDevWorkItem.Update(deltaInMinutes);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			else
			{
				if (!flag2 || workItem.Paused || workItem.GetNetworkDealState() != WorkItem.NetworkDealState.None || workItem.CompanyWorker == null || !workItem.HasCompanyWork())
				{
					continue;
				}
				if (!flag)
				{
					flag = true;
					if (start.Hour < 8 || start.Hour >= 16)
					{
						flag2 = false;
					}
					else
					{
						num2 = Mathf.Min(deltaInMinutes, 960 - start.Hour * 60 - start.Minute);
						flag2 = num2 > 0f;
					}
				}
				if (flag2)
				{
					if (workItem.CompanyWorker.DoWork(Utilities.PerDay(workItem.StressMultiplier() / 2f, num2, false)))
					{
						float num3 = workItem.CompanyWork(num2);
						workItem.AddLoss(num3);
						workItem.CompanyWorker.WorkItemCost += num3;
					}
					else if (!NotificationManager.CheckAggregate<CompanyDetailNotification>(null, workItem.CompanyWorker.ID))
					{
						NotificationManager.AddNotification(new CompanyDetailNotification(workItem.CompanyWorker, "SubsidiaryOverworked".LocColor(workItem.CompanyWorker), "Skyskraper", SDateTime.Now(), NotificationManager.NotificationType.Warning));
					}
				}
			}
		}
	}

	public void UpdateEdgeDetection()
	{
		_refreshFurnEdgeNum = sRoomManager.AllFurniture.Count;
		foreach (PlayerMap value in sRoomManager.PlayerMaps.Values)
		{
			value.UpdateEdgeDetection();
		}
	}

	private void EmitFire(Vector3 p)
	{
		ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
		{
			position = p,
			rotation = UnityEngine.Random.value * 360f,
			velocity = Vector3.up * 4f,
			startLifetime = 0.5f,
			startSize = 1.5f
		};
		BuildController.Instance.FireEmitter.Emit(emitParams, 1);
	}

	private void AddToDestruction(Furniture f)
	{
		UndoObject.UndoAction undoAction = new UndoObject.UndoAction(f);
		_destructionUndo.Add(undoAction);
		DestructionUndoCost += undoAction.BalanceDiff;
		for (int i = 0; i < f.SnapPoints.Length; i++)
		{
			SnapPoint snapPoint = f.SnapPoints[i];
			if (snapPoint.UsedByCount <= 0)
			{
				continue;
			}
			foreach (Furniture item in snapPoint.GetAllUsedBy())
			{
				AddToDestruction(item);
			}
		}
		InsuranceIncident();
	}

	public void ReduceHeat(float delta)
	{
		if (HeatCountdown > 0f)
		{
			HeatCountdown -= delta / (float)DaysPerMonth;
			if (HeatCountdown > 0f)
			{
				return;
			}
			delta = (0f - HeatCountdown) * (float)DaysPerMonth;
			HeatCountdown = 0f;
		}
		if (HeatFullCountdown > 0f)
		{
			HeatFullCountdown -= delta / (float)DaysPerMonth;
			if (HeatFullCountdown < 0f)
			{
				HeatFullCountdown = 0f;
			}
		}
		Heat = Mathf.Max(0f, Heat - Utilities.PerDay(833333.3f, delta, false));
	}

	private void FixedUpdate()
	{
		if (Instance.IsReferenceNull())
		{
			return;
		}
		if (GameSpeed > 0f && SelectorController.Instance.DoneLoading)
		{
			BrokenIT.SortList((Furniture x, Furniture y) => x.upg.Quality.CompareTo(y.upg.Quality));
			float num = Time.deltaTime * GameSpeed;
			ReduceHeat(num);
			BackgroundAccounting.UpdateBackgroundTask();
			SimulateWork(SDateTime.Now(), num);
			UpdateUtilities(GameSpeed * Time.deltaTime, false);
			for (int num2 = 0; num2 < OnFire.Count; num2++)
			{
				Furniture furniture = OnFire[num2];
				if (furniture == null)
				{
					OnFire.RemoveAt(num2);
					num2--;
					continue;
				}
				bool flag = furniture.IsChildVisible();
				if (flag && (Time.realtimeSinceStartup + UnityEngine.Random.value * 1.5f) % 1.5f > 1f)
				{
					EmitFire(furniture.GetSelectPosition());
				}
				furniture.OnFire += Utilities.PerHour(UnityEngine.Random.Range(3f, 6f));
				if (!(furniture.OnFire > 1f))
				{
					continue;
				}
				if (flag)
				{
					Room.FirePoof(furniture.transform.position);
					UISoundFX.PlaySFX("FireBreak", furniture.transform.position, sRoomManager.CameraRoom != furniture.Parent);
				}
				furniture.InsurancePayout();
				furniture.Undo = true;
				furniture.NonPlayerDestruction = true;
				AddToDestruction(furniture);
				List<Furniture> furnitures = furniture.Parent.GetFurnitures();
				for (int num3 = 0; num3 < furnitures.Count; num3++)
				{
					Furniture furniture2 = furnitures[num3];
					if (furniture2 != furniture && furniture2 != null)
					{
						float magnitude = (furniture2.transform.position.FlattenVector3() - furniture.transform.position.FlattenVector3()).magnitude;
						if (magnitude == 0f || (magnitude <= 3f && UnityEngine.Random.value < 0.5f / magnitude))
						{
							furniture2.SetFire();
						}
					}
				}
				furniture.Parent.UpdateFurnOnFire(furniture);
				furniture.DestroyGO();
				OnFire.RemoveAt(num2);
				num2--;
				FireCounter--;
			}
			for (int num4 = 0; num4 < ElevatorGroups.Count; num4++)
			{
				if (ElevatorGroups[num4].Elevators.Length == 0)
				{
					ElevatorGroups.RemoveAt(num4);
					num4--;
				}
				else
				{
					ElevatorGroups[num4].Tick(num);
				}
			}
		}
		if (HasSubway)
		{
			if (ActiveSubway.SFX.isPlaying)
			{
				if (GameSpeed == 0f)
				{
					ActiveSubway.SFX.Pause();
				}
			}
			else if (GameSpeed > 0f)
			{
				ActiveSubway.SFX.Play();
			}
		}
		if (LODDirty)
		{
			List<Furniture> orNull = _LODFloors.GetOrNull(ActiveFloor);
			if (orNull != null)
			{
				for (int num5 = 0; num5 < orNull.Count; num5++)
				{
					if (orNull[num5].IsChildVisible())
					{
						orNull[num5].UpdateLOD();
					}
				}
			}
			LODDirty = false;
		}
		if (sRoomManager.AllFurniture.Count > 0)
		{
			_refreshFurnEdgeNum = Mathf.Min(_refreshFurnEdgeNum, sRoomManager.AllFurniture.Count);
			int num6 = Mathf.Min(_refreshFurnEdgeNum, Mathf.Max(100, sRoomManager.AllFurniture.Count / 5));
			for (int num7 = 0; num7 < num6; num7++)
			{
				Furniture furniture3 = sRoomManager.AllFurniture[(_refreshFurnEdgeOffset + num7) % sRoomManager.AllFurniture.Count];
				if (furniture3 != null)
				{
					furniture3.RefreshEdgeDetection();
				}
			}
			_refreshFurnEdgeNum -= num6;
			_refreshFurnEdgeOffset = (_refreshFurnEdgeOffset + num6) % sRoomManager.AllFurniture.Count;
		}
		if (sRoomManager.PlayerMaps.Count > 0)
		{
			foreach (PlayerMap value in sRoomManager.PlayerMaps.Values)
			{
				value.RefreshVisibility();
				value.RefreshSnaps();
				value.UpdateRooms();
			}
		}
		if (SelectorController.Instance.DoneLoading)
		{
			string text = GameData.CheckTasks(CompletedTasks, PermanentUnlock ? Options.UnlockedRewards : null, TaskProgress, ref _taskOffset, ref _taskSubOffset);
			if (text != null)
			{
				CompletedTasks.Add(text);
			}
		}
	}

	public void UpdateGridVisibility()
	{
		foreach (KeyValuePair<int, MeshFilter> floorRentGrid in FloorRentGrids)
		{
			floorRentGrid.Value.gameObject.SetActive(HUD.Instance.BuildMode && floorRentGrid.Key == ActiveFloor);
		}
	}

	private Battery GetBattery(bool consume)
	{
		if (consume)
		{
			if (_batteryConsume == null || _batteryConsume.CurrentCharge <= 0f || _batteryConsume.Broken)
			{
				_batteryConsume = Batteries.FirstOrDefault((Battery x) => x.CurrentCharge > 0f);
			}
			return _batteryConsume;
		}
		if (_batteryFill == null || _batteryFill.CurrentCharge >= _batteryFill.MaxCapacity || _batteryFill.Broken)
		{
			_batteryFill = Batteries.FirstOrDefault((Battery x) => x.CurrentCharge < x.MaxCapacity);
		}
		return _batteryFill;
	}

	public void UpdateUtilities(float delta, bool skip)
	{
		float num = delta / 60f / (float)DaysPerMonth;
		float num2 = 0.03f * num;
		float num3 = 0f;
		for (int i = 0; i < ProductPrinters.Count; i++)
		{
			ProductPrinter productPrinter = ProductPrinters[i];
			if (productPrinter.OwedWatt > 0f)
			{
				float num4 = (skip ? productPrinter.OwedWatt : (productPrinter.Furn.Wattage * productPrinter.Furn.UseModifier * num2));
				productPrinter.OwedWatt -= num4;
				if (productPrinter.OwedWatt < 0f)
				{
					num4 += productPrinter.OwedWatt;
					productPrinter.OwedWatt = 0f;
				}
				num3 += num4;
			}
		}
		float num5 = (float)(ElectricityGenerationDelta * (double)num2);
		float num6 = (float)(ElectricityDelta * (double)num2 + (double)num3 + ElectricityBurst);
		ElectricityBurst = 0.0;
		LastWattSaved += Mathf.Min(num5, num6);
		LastWattUse += num6;
		HourWattUse[23] += num6;
		HourWattGen[23] += num5;
		MonthWattUse[11] += num6;
		MonthWattGen[11] += num5;
		num6 -= num5;
		if (num6 > 0f && Batteries.Count > 0)
		{
			Battery battery = GetBattery(true);
			if (battery != null)
			{
				float num7 = battery.TakeCharge(num6);
				LastWattSaved += num7;
				num6 -= num7;
				while (num6 > 0f && battery != null && battery.CurrentCharge == 0f)
				{
					battery = GetBattery(true);
					if (battery != null)
					{
						float num8 = battery.TakeCharge(num6);
						LastWattSaved += num8;
						num6 -= num8;
					}
				}
			}
		}
		else if (num6 < 0f && Batteries.Count > 0)
		{
			Battery battery2 = GetBattery(false);
			if (battery2 != null)
			{
				num6 += battery2.AddCharge(0f - num6);
				while (num6 < 0f && battery2 != null && battery2.CurrentCharge == battery2.MaxCapacity)
				{
					battery2 = GetBattery(false);
					if (battery2 != null)
					{
						num6 += battery2.AddCharge(0f - num6);
					}
				}
			}
		}
		if (num6 > 0f)
		{
			ElectricityBill += num6;
		}
		else
		{
			ElectricityIncome -= num6;
		}
		float num9 = (float)(WaterDelta * (double)num * 30.0);
		HourWaterUse[23] += num9;
		MonthWaterUse[11] += num9;
		Waterbill += num9;
		float num10 = (float)(GasDelta * (double)num * 30.0);
		HourGasUse[23] += num10;
		MonthGasUse[11] += num10;
		Gasbill += num10;
	}

	public bool AnyNavRooms()
	{
		lock (_navRooms)
		{
			return _navRooms.Count > 0;
		}
	}

	public int NavRoomCount()
	{
		lock (_navRooms)
		{
			return _navRooms.Count;
		}
	}

	private void LateUpdate()
	{
		if (QueuedNetworkEdges.Count > 0)
		{
			foreach (Room queuedNetworkEdge in QueuedNetworkEdges)
			{
				if (queuedNetworkEdge.IsAliveNotNull())
				{
					queuedNetworkEdge.UpdateEdgesNetwork();
				}
			}
			QueuedNetworkEdges.Clear();
		}
		if (QueuedNetworkRooms.Count > 0)
		{
			BuildingPrefab buildingPrefab = BuildingPrefab.SaveRoomsForNetwork(QueuedNetworkRooms.Where((Room x) => x.IsAliveNotNull()).ToArray(), Array.Empty<Roof>(), true);
			if (buildingPrefab.Rooms.Length != 0 || buildingPrefab.Roofs.Length != 0)
			{
				NetworkMessaging.SendNewRoom(buildingPrefab, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
			QueuedNetworkRooms.Clear();
		}
		if (QueuedNetworkSegments.Count > 0)
		{
			foreach (KeyValuePair<RoomSegment, bool> queuedNetworkSegment in QueuedNetworkSegments)
			{
				if (queuedNetworkSegment.Value && queuedNetworkSegment.Key != null)
				{
					queuedNetworkSegment.Key.SendNetwork();
				}
				else if (queuedNetworkSegment.Key.NetworkID != 0)
				{
					NetworkMessaging.SendDestroyNetworkObject(queuedNetworkSegment.Key.NetworkID, true, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					queuedNetworkSegment.Key.NetworkID = 0u;
				}
			}
			QueuedNetworkSegments.Clear();
		}
		if (QueuedNetworkFurniture.Count <= 0)
		{
			return;
		}
		foreach (Furniture item in QueuedNetworkFurniture)
		{
			if (item != null)
			{
				NetworkMessaging.SendNewFurniture(new BuildingPrefab.FurnitureObject(item, true), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
			}
		}
		QueuedNetworkFurniture.Clear();
	}

	public void SetTreeShake(Vector2 pos)
	{
		if (_leaveShake == LeaveShakeStart)
		{
			Vector4 vector = LeaveMat.GetVector("_Shake");
			pos = (pos + (Vector2)vector) * 0.5f;
		}
		_leaveShake = LeaveShakeStart;
		LeaveMat.SetVector("_Shake", new Vector4(pos.x, pos.y, _leaveShake, LeaveTime));
	}

	private void Update()
	{
		if (Instance.IsReferenceNull())
		{
			return;
		}
		if (ResetRooms.Count > 0)
		{
			for (int i = 0; i < ResetRooms.Count; i++)
			{
				ResetRooms[i].UpdateCurrentRoom(true);
			}
			ResetRooms.Clear();
		}
		if (_leaveShake < LeaveTime)
		{
			_leaveShake = Mathf.Min(_leaveShake + Time.deltaTime * LeaveShakeSpeed, LeaveTime);
			Vector4 vector = LeaveMat.GetVector("_Shake");
			LeaveMat.SetVector("_Shake", new Vector4(vector.x, vector.y, _leaveShake, LeaveTime));
		}
		ClearBuyouts();
		lock (_navRooms)
		{
			bool flag = _navRooms.Count > 0;
			if (flag != NavIcon.activeSelf)
			{
				NavIcon.SetActive(flag);
			}
		}
		if (SelectorController.Instance.DoneLoading && !simulation.ManufacturingIconsInitialized)
		{
			simulation.InitializeAtlas();
			BoxController.BoxMat.SetTexture("_AtlasTex", MarketSimulation.Active.ManufacturingIcons);
			BoxController.BoxMat.SetInt("_AtlasWidth", MarketSimulation.Active.ManAtlasWidth);
			BoxController.BoxMat.SetInt("_AtlasHeight", MarketSimulation.Active.ManAtlasHeight);
			for (int j = 0; j < ProductPrinters.Count; j++)
			{
				ProductPrinters[j].UpdateSticker();
			}
			EventHandler onHardwareAtlasInitialized = OnHardwareAtlasInitialized;
			if (onHardwareAtlasInitialized != null)
			{
				onHardwareAtlasInitialized(this, null);
			}
		}
		UpdateGrassTrot();
		bool flag2 = false;
		bool flag3 = false;
		for (int k = 0; k < sRoomManager.TempGroups.Count; k++)
		{
			TemperatureGroup temperatureGroup = sRoomManager.TempGroups[k];
			flag2 |= ((temperatureGroup.ForceHighlight | temperatureGroup.Selected) & TemperatureGroup.TempType.Heat) > TemperatureGroup.TempType.None;
			flag3 |= ((temperatureGroup.ForceHighlight | temperatureGroup.Selected) & TemperatureGroup.TempType.Cool) > TemperatureGroup.TempType.None;
			if (flag2 && flag3)
			{
				break;
			}
		}
		Color value = new Color(flag2 ? 1 : 0, 1f, flag3 ? 1 : 0);
		PipeMat.SetColor("_Mask", value);
		PipeMat.SetFloat("_YCutOff", (float)ActiveFloor * 2f + 1.95f);
		float value2 = ((GameSpeed == 0f) ? 1f : Mathf.Min(3f, 0.98f + GameSpeed / 50f));
		AudioManager.MasterMixer.SetFloat("MasterPitch", value2);
		AudioManager.MasterMixer.SetFloat("EnvPitch", value2);
		LeaveMat.SetFloat("_Speed", HUD.Instance.GameSpeed * 2);
		ParticleSystem.MainModule main = ChimneySmokePrefab.main;
		main.simulationSpeed = Mathf.Max(0.01f, HUD.Instance.GameSpeed);
		if (UndoAutosaveWait >= 0f)
		{
			UndoAutosaveWait -= Time.deltaTime;
		}
		for (int l = 0; l < TempTrees.Count; l++)
		{
			TreeInstance treeInstance = TempTrees[l];
			Graphics.DrawMesh(treeInstance.TreeMesh.TreeMesh.sharedMesh, treeInstance.Transform, LeaveMat, 0);
		}
		if (DirtyRentGrid.Count > 0)
		{
			foreach (int i2 in DirtyRentGrid)
			{
				bool flag4 = false;
				MeshFilter meshFilter = FloorRentGrids.GetOrNull(i2);
				if (meshFilter == null)
				{
					flag4 = true;
					GameObject obj = new GameObject("RentGridFloor" + i2);
					obj.transform.position = Vector3.up * ((float)i2 * 2f + 0.03f);
					meshFilter = obj.AddComponent<MeshFilter>();
					meshFilter.sharedMesh = new Mesh();
					obj.AddComponent<MeshRenderer>().sharedMaterial = BuildController.Instance.MainGridMaterial;
					FloorRentGrids[i2] = meshFilter;
				}
				List<Room> list = sRoomManager.Rooms.Where((Room x) => x.Floor == i2 && x.PlayerOwned && !x.Pillar).ToList();
				if (list.Count > 0)
				{
					List<Vector3> list2 = new List<Vector3>();
					List<int> list3 = new List<int>();
					for (int num = 0; num < list.Count; num++)
					{
						Room room = list[num];
						if (!room.IsUpperAtriumNotBalcony)
						{
							Mesh sharedMesh = room.FloorMesh.GetComponent<MeshFilter>().sharedMesh;
							int c = list2.Count;
							list2.AddRange(sharedMesh.vertices);
							list3.AddRange(sharedMesh.triangles.Select((int x) => x + c));
						}
					}
					Mesh sharedMesh2 = meshFilter.sharedMesh;
					if (!flag4)
					{
						sharedMesh2.triangles = new int[0];
					}
					sharedMesh2.vertices = list2.ToArray();
					sharedMesh2.normals = list2.SelectInPlace((Vector3 x) => Vector3.up);
					sharedMesh2.uv = list2.SelectInPlace((Vector3 x) => x.FlattenVector3());
					sharedMesh2.triangles = list3.ToArray();
				}
				else
				{
					meshFilter.sharedMesh.Clear();
				}
			}
			DirtyRentGrid.Clear();
			UpdateGridVisibility();
		}
		if (CheckOSLicenses)
		{
			Dictionary<SoftwareProduct, HashSet<uint>> dictionary = new Dictionary<SoftwareProduct, HashSet<uint>>();
			List<uint> cache = new List<uint>();
			foreach (WorkItem workItem in MyCompany.WorkItems)
			{
				if (workItem.GetNetworkDealState() != WorkItem.NetworkDealState.Sender)
				{
					SoftwareAlpha softwareAlpha;
					SoftwareUpdate softwareUpdate;
					SoftwarePort softwarePort;
					if ((softwareAlpha = workItem as SoftwareAlpha) != null && softwareAlpha.ActiveDeal == null && softwareAlpha.contract == null && softwareAlpha.OSs != null)
					{
						AddOSs(softwareAlpha, dictionary, cache, softwareAlpha.OSs);
					}
					else if ((softwareUpdate = workItem as SoftwareUpdate) != null && softwareUpdate.ActiveDeal == null && softwareUpdate.contract == null && softwareUpdate.OSs != null)
					{
						AddOSs(softwareUpdate, dictionary, cache, softwareUpdate.OSs);
					}
					else if ((softwarePort = workItem as SoftwarePort) != null && softwarePort.Current != null)
					{
						AddOSs(softwarePort, dictionary, cache, softwarePort.Current.Product);
					}
				}
			}
			MyCompany.UpdateOSLicenses(dictionary.ToDictionary((KeyValuePair<SoftwareProduct, HashSet<uint>> x) => x.Key, (KeyValuePair<SoftwareProduct, HashSet<uint>> x) => x.Value.Count), false);
			CheckOSLicenses = false;
		}
		for (int num2 = 0; num2 < TreeBatches.Count; num2++)
		{
			TreeBatch treeBatch = TreeBatches[num2];
			if (!treeBatch.GenerateMesh())
			{
				TreeBatches.RemoveAt(num2);
				UnityEngine.Object.Destroy(treeBatch.gameObject);
				num2--;
			}
		}
		if (HUD.Instance.serverWindow.ShouldUpdateServerList)
		{
			HUD.Instance.serverWindow.DoUpdateServerList();
		}
		if (HasToFinalizeTimers)
		{
			TimeProbe.FinalizeTime("Server init time:");
			TimeProbe.FinalizeTime("Furniture init time:");
			HasToFinalizeTimers = false;
		}
		if (sRoomManager.RoomRoadDirty > -1)
		{
			sRoomManager.RoomRoadDirty--;
			if (sRoomManager.RoomRoadDirty == 0)
			{
				sRoomManager.RoomRoadDirty = -1;
				sRoomManager.UpdateRoomRoadConnections();
			}
		}
		else if (sRoomManager.RoomNearnessDirty)
		{
			sRoomManager.RecalculateNearRooms();
		}
		if (SelectorController.Instance.DoneLoading)
		{
			sRoomManager.CheckTeamAssignment();
		}
		if (sRoomManager.TemperatureControlDirty)
		{
			sRoomManager.UpdateTemperatureControllers();
		}
		if (sRoomManager.CCTVDirty)
		{
			sRoomManager.UpdateCCTVControllers();
		}
		sRoomManager.RefreshRoofOffsets();
		if (Room.UpdatePCNoisiness.Count > 0)
		{
			Room room2 = Room.UpdatePCNoisiness.First();
			HashList<Furniture> furniture = room2.GetFurniture("Computer");
			for (int num3 = 0; num3 < furniture.Count; num3++)
			{
				Furniture furniture2 = furniture[num3];
				if (furniture2 != null)
				{
					furniture2.EnvironmentNoise = Furniture.RecalculateNoise(furniture2.OriginalPosition.FlattenVector3(), false, furniture2.Parent, furniture2);
					furniture2.RefreshFinalNoiseValue();
				}
			}
			Room.UpdatePCNoisiness.Remove(room2);
		}
		if (FixServerWiringNow.Count > 0)
		{
			foreach (string item in FixServerWiringNow)
			{
				ServerGroup orDefault = ServerGroups.GetOrDefault(item);
				if (orDefault != null)
				{
					orDefault.FixWiring();
				}
			}
			FixServerWiringNow.Clear();
			CameraScript.Instance.WireRender.ForceDirty = true;
		}
		if (CalculateServerPowerNow.Count > 0)
		{
			foreach (string item2 in CalculateServerPowerNow)
			{
				ServerGroup orDefault2 = ServerGroups.GetOrDefault(item2);
				if (orDefault2 != null)
				{
					orDefault2.RefreshPower();
				}
			}
			CalculateServerPowerNow.Clear();
		}
		if (CameraScript.Instance.FlyMode)
		{
			int floor = Mathf.FloorToInt(CameraScript.Instance.mainCam.transform.position.y / 2f);
			sRoomManager.CameraRoom = sRoomManager.GetRoomFromPoint(floor, CameraScript.Instance.mainCam.transform.position.FlattenVector3()) ?? sRoomManager.Outside;
		}
		else
		{
			sRoomManager.CameraRoom = sRoomManager.GetRoomFromPoint(ActiveFloor, new Vector2(AudioListener.position.x, AudioListener.position.z)) ?? sRoomManager.Outside;
		}
		AudioManager.MasterMixer.SetFloat("EnvLowPass", (sRoomManager.CameraRoom == sRoomManager.Outside) ? 22000f : Mathf.Abs(CameraScript.Instance.mainCam.transform.position.y - sRoomManager.CameraRoom.transform.position.y).MapRange(40f, 100f, 2000f, 22000f, true));
		HandleSimGUI();
		tTreeTrunkMat.color = DataOverlay.Instance.GetColor((CliType == GameData.ClimateType.Warm) ? CactusTrunkMat.color : TreeTrunkMat.color);
		if (!PreSimActive && GameSpeed > 0f)
		{
			InGameMinute += GameSpeed * Time.deltaTime;
			if (InGameMinute >= 1f)
			{
				InGameMinute = 0f;
				sActorManager.DoUpdate();
			}
		}
		bool flag5 = ActiveFloor >= 0;
		for (int num4 = 0; num4 < sRoomManager.PathController.AllPathObjects.Count; num4++)
		{
			PathObject pathObject = sRoomManager.PathController.AllPathObjects[num4];
			if (pathObject.MeshRend.enabled != flag5)
			{
				pathObject.MeshRend.enabled = flag5;
			}
		}
		for (int num5 = 0; num5 < MergedTreeTrunks.Count; num5++)
		{
			MergedTreeTrunks[num5].SetActive(flag5);
		}
		for (int num6 = 0; num6 < MergedLeaves.Count; num6++)
		{
			MergedLeaves[num6].SetActive(flag5);
		}
		if (GameSpeed > 0f)
		{
			sRoomManager.UpdateStates();
		}
		BusStopSign.SetActive(Instance.ActiveFloor > -1);
		if (_dirtyHelipad.HasValue)
		{
			for (int num7 = 0; num7 < ProductPallets.Count; num7++)
			{
				ProductPallet productPallet = ProductPallets[num7];
				if (productPallet != null && productPallet.Furn != null && !productPallet.StaticBox && productPallet.Furn.GetFloor() + 1 < _dirtyHelipad.Value)
				{
					productPallet.CheckBlocked();
				}
			}
			_dirtyHelipad = null;
		}
		if (!(HUD.Instance != null))
		{
			return;
		}
		List<object> activeDealsPerformance = HUD.Instance.dealWindow.GetActiveDealsPerformance();
		for (int num8 = 0; num8 < activeDealsPerformance.Count; num8++)
		{
			Deal deal = (Deal)activeDealsPerformance[num8];
			if (deal != null && deal.Active)
			{
				deal.HandleUpdate();
			}
		}
	}

	private void AddOSs(WorkItem item, Dictionary<SoftwareProduct, HashSet<uint>> dict, List<uint> cache, params SoftwareProduct[] OSs)
	{
		bool flag = false;
		for (int i = 0; i < OSs.Length; i++)
		{
			if (OSs[i].HasToPay(MyCompany))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		cache.Clear();
		List<Team> devTeams = item.GetDevTeams();
		for (int j = 0; j < devTeams.Count; j++)
		{
			List<Actor> employeesDirect = devTeams[j].GetEmployeesDirect();
			for (int k = 0; k < employeesDirect.Count; k++)
			{
				Actor actor = employeesDirect[k];
				WorkItem.HasWorkReturn hasWorkReturn = item.HasWork(actor, actor.SecondaryWork, false);
				if (hasWorkReturn == WorkItem.HasWorkReturn.True || hasWorkReturn == WorkItem.HasWorkReturn.Secondary)
				{
					cache.Add(actor.DID);
				}
			}
		}
		foreach (SoftwareProduct softwareProduct in OSs)
		{
			if (softwareProduct.HasToPay(MyCompany))
			{
				dict.GetOrAdd(softwareProduct, (SoftwareProduct x) => new HashSet<uint>()).AddRange(cache);
			}
		}
	}

	public void BatchTempTrees()
	{
		Trees.AddRange(TempTrees);
		for (int i = 0; i < TempTrees.Count; i++)
		{
			AddTreeToBatch(TempTrees[i]);
			TreeTree.Insert(TempTrees[i]);
		}
		TempTrees.Clear();
	}

	public void RemoveTree(TreeInstance tree)
	{
		tree.BelongsTo.RemoveTree(tree);
		Trees.Remove(tree);
		TreeTree.removeItem(tree);
	}

	public TreeInstance AddTree(Vector3 pos, bool temp = false)
	{
		return AddTree(pos, GameData.RNDRange(0, CachedTrees.Length), UnityEngine.Random.Range(0, 360), temp);
	}

	public TreeInstance AddTree(Vector3 pos, int type, float rotation, bool temp = false)
	{
		return CreateTree(type, pos, Quaternion.Euler(0f, rotation, 0f), temp);
	}

	public void AddTree(TreeInstance t)
	{
		Trees.Add(t);
		TreeTree.Insert(t);
		AddTreeToBatch(t);
	}

	private TreeInstance CreateTree(int id, Vector3 position, Quaternion rotation, bool temp = false)
	{
		TreeInstance treeInstance = new TreeInstance(position, rotation, id);
		if (temp)
		{
			TempTrees.Add(treeInstance);
		}
		else
		{
			Trees.Add(treeInstance);
			TreeTree.Insert(treeInstance);
			AddTreeToBatch(treeInstance);
		}
		return treeInstance;
	}

	private void AddTreeToBatch(TreeInstance tree)
	{
		float num = 64f;
		TreeBatch treeBatch = null;
		Vector2 pos = tree.GetPos();
		for (int i = 0; i < TreeBatches.Count; i++)
		{
			TreeBatch treeBatch2 = TreeBatches[i];
			float num2 = treeBatch2.Center.ManhattanDist(pos);
			if (treeBatch2.CanAdd(tree) && num2 < num)
			{
				num = num2;
				treeBatch = treeBatch2;
			}
		}
		if (treeBatch == null)
		{
			treeBatch = UnityEngine.Object.Instantiate(TreeBatchPrefab);
			treeBatch.transform.SetParent(TreeRoot.transform);
			treeBatch.TreeMaterial = LeaveMat;
			TreeBatches.Add(treeBatch);
		}
		treeBatch.AddTree(tree);
	}

	public void SpawnTreeAreas(List<Rect> areas)
	{
		if (CachedTrees.Length == 0)
		{
			Debug.LogError("No cached trees to spawn");
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		for (int i = 0; i < areas.Count; i++)
		{
			SpawnTreeArea(areas[i], null);
		}
		Debug.Log("TreeGen time: " + (Time.realtimeSinceStartup - realtimeSinceStartup).SecondsToTime());
	}

	public void SpawnTreeArea(Rect area, Vector2[] polygon, System.Random rnd = null, float densityFactor = 1f)
	{
		rnd = rnd ?? GameData.RND;
		float num = ((CliType == GameData.ClimateType.Warm) ? 10f : 4f) * densityFactor;
		float num2 = num / 2f - 0.5f;
		area = area.Expand(-2f, -2f);
		for (float num3 = area.xMin + num2 + 0.001f; num3 < area.xMax; num3 += num)
		{
			for (float num4 = area.yMin + num2 + 0.001f; num4 < area.yMax; num4 += num)
			{
				Vector2 vector = new Vector2(num3, num4);
				vector += new Vector2(rnd.Range(-1f, 1f), rnd.Range(-1f, 1f)).normalized * rnd.Range(num2 / 4f, num2);
				if (area.Contains(vector) && (polygon == null || Utilities.IsInside(vector, polygon)))
				{
					CreateTree(rnd.Next(0, CachedTrees.Length), vector.ToVector3(0f), Quaternion.Euler(0f, UnityEngine.Random.Range(0, 360), 0f));
				}
			}
		}
	}

	public void SpawnTreePolygon(Vector2[] polygon)
	{
		SpawnTreeArea(((IList<Vector2>)polygon).GetBounds(), polygon);
	}

	private void SpawnTrees()
	{
		if (CachedTrees.Length == 0)
		{
			Debug.LogError("No cached trees to spawn");
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		Rect rect = new Rect(8f, 8f, 239f, 239f);
		float num = ((CliType == GameData.ClimateType.Warm) ? 20f : 55f);
		float max = 1f / num * 254f;
		float num2 = 3f;
		Vector2 vector = new Vector2(GameData.RNDRange(0f, 10f), GameData.RNDRange(0f, 10f));
		for (float num3 = 0f; num3 < num; num3 += 1f)
		{
			for (float num4 = 0f; num4 < num; num4 += 1f)
			{
				Vector3 position = new Vector3(rect.xMin + num3 / num * rect.width, 0f, rect.yMin + num4 / num * rect.height);
				position += new Vector3(GameData.RNDRange(0f, max), 0f, GameData.RNDRange(0f, max));
				float time = Mathf.PerlinNoise(vector.x + num3 / num * num2, vector.y + num4 / num * num2);
				if (GameData.RNDValue < TreeFalloff.Evaluate(time))
				{
					CreateTree(GameData.RNDRange(0, CachedTrees.Length), position, Quaternion.Euler(0f, UnityEngine.Random.Range(0, 360), 0f));
				}
			}
		}
		Debug.Log("TreeGen time: " + (Time.realtimeSinceStartup - realtimeSinceStartup).SecondsToTime());
	}

	public Actor SpawnActor(bool female, bool randomEmployee, bool initWritable = true, string style = "Default")
	{
		Actor component = UnityEngine.Object.Instantiate(ActorObj).GetComponent<Actor>();
		component.employee = new Employee(SDateTime.Now(), female, UnityEngine.Random.Range(Employee.Youngest, Employee.RetirementAge), style);
		component.employee.Employ(MyCompany, SDateTime.Now(), false);
		component.Female = female;
		if (initWritable)
		{
			component.InitWritable();
		}
		return component;
	}

	public Actor SpawnActor(Employee emp, bool initWritable = true)
	{
		Actor component = UnityEngine.Object.Instantiate(ActorObj).GetComponent<Actor>();
		component.employee = emp;
		component.Female = emp.Female;
		if (initWritable)
		{
			component.InitWritable();
		}
		return component;
	}

	public void OnGameReady()
	{
		if (TimeOfDay.Instance.Month == 5 && TimeOfDay.Instance.Day == 0)
		{
			ConferenceController.StartThread();
		}
		ConferenceController.UpdateActive();
		if (!EditMode)
		{
			MarketSimulation.Active.GetAllCompanies().ForEachEnum(delegate(Company c)
			{
				GlobalSearchPanel.Instance.AddSearchItem(c, c.Name, delegate
				{
					HUD.Instance.companyWindow.ShowCompanyDetails(c);
				}, LogoController.Instance.LogoTexture, LogoController.Instance.GetLogoRect(c), false);
			});
			MarketSimulation.Active.OnCompanyFounded += delegate(object s, Company c)
			{
				GlobalSearchPanel.Instance.AddSearchItem(c, c.Name, delegate
				{
					HUD.Instance.companyWindow.ShowCompanyDetails(c);
				}, LogoController.Instance.LogoTexture, LogoController.Instance.GetLogoRect(c), false);
			};
			MarketSimulation.Active.OnCompanyClosed += delegate(object s, Company c)
			{
				GlobalSearchPanel.Instance.RemoveSearchItem(c);
			};
			MarketSimulation.Active.GetAllProducts(true).ForEachEnum(delegate(SoftwareProduct p)
			{
				GlobalSearchPanel.Instance.AddSearchItem(p, p.Name, delegate
				{
					HUD.Instance.GetProductWindow(null).ShowProductDetails(p);
				}, delegate(RenderTexture x)
				{
					HardwareDesignRenderer.Instance.RenderProduct(p, x, false);
				}, false);
			});
			MarketSimulation.Active.OnProductReleased += delegate(object s, SoftwareProduct p)
			{
				GlobalSearchPanel.Instance.AddSearchItem(p, p.Name, delegate
				{
					HUD.Instance.GetProductWindow(null).ShowProductDetails(p);
				}, delegate(RenderTexture x)
				{
					HardwareDesignRenderer.Instance.RenderProduct(p, x, false);
				}, false);
			};
			MarketSimulation.Active.OnProductRemoved += delegate(object s, SoftwareProduct p)
			{
				GlobalSearchPanel.Instance.RemoveSearchItem(p);
			};
			MarketSimulation.Active.AddOnProducts.ForEach(delegate(AddOnProduct a)
			{
				GlobalSearchPanel.Instance.AddSearchItem(a, a.Name, delegate
				{
					HUD.Instance.GetProductWindow(null).ShowAddonDetails(a);
				}, delegate(RenderTexture x)
				{
					HardwareDesignRenderer.Instance.RenderProduct(a, x, false);
				}, false);
			});
			MarketSimulation.Active.OnAddOnReleased += delegate(object s, AddOnProduct a)
			{
				GlobalSearchPanel.Instance.AddSearchItem(a, a.Name, delegate
				{
					HUD.Instance.GetProductWindow(null).ShowAddonDetails(a);
				}, delegate(RenderTexture x)
				{
					HardwareDesignRenderer.Instance.RenderProduct(a, x, false);
				}, false);
			};
			MarketSimulation.Active.OnAddOnRemoved += delegate(object s, AddOnProduct a)
			{
				GlobalSearchPanel.Instance.RemoveSearchItem(a);
			};
			sActorManager.Teams.Values.ForEachEnum(delegate(Team x)
			{
				sActorManager.ApplySearchToTeam(x);
			});
		}
		if (!RentMode)
		{
			GlobalSearchPanel.Instance.AddSearchItem(PlotController.Instance, "Plots".Loc(), delegate
			{
				PlotController.Instance.Toggle();
			}, "Plot", true);
			GlobalSearchPanel.Instance.AddSearchItem(BlueprintWindow.Instance, "Blueprints".Loc(), delegate
			{
				BlueprintWindow.Instance.Show();
			}, "Building", true);
		}
		HUD.Instance.RefreshRentModeSearch();
		HintController.Show(HintController.Hints.HintGlobalSearch);
		EventHandler gameReady = GameReady;
		if (gameReady != null)
		{
			gameReady(this, null);
		}
	}

	private void HandleSimGUI()
	{
		if (PreSimFinished)
		{
			SDateTime sDateTime = SDateTime.Now();
			foreach (Actor actor in sActorManager.Actors)
			{
				sActorManager.AddToAwaiting(actor, new SDateTime(0, 7, sDateTime.Day, sDateTime.Month, sDateTime.Year), true, false);
			}
			PreSimFinished = false;
			UnlockCheck.UpdateMe(true);
			Newspaper.StoryRollover(presimfinaltime);
			if (!CampaignMode)
			{
				HUD.Instance.SpeedToggles[1].isOn = true;
			}
			HUD.Instance.dealWindow.CancelDueWork(false);
			HUD.Instance.eventWindow.UpdateEvents();
			HUD.Instance.UpdateFurnitureButtons();
			if (IsNetworkMode)
			{
				foreach (SimulatedCompany value in MarketSimulation.Active.Companies.Values)
				{
					if (value.LeadDesigner != null)
					{
						NetworkMessaging.MoveLeadDesigner(value.LeadDesigner, value, false, false);
					}
				}
				foreach (Employee freeLead in MarketSimulation.Active.FreeLeads)
				{
					NetworkMessaging.MoveLeadDesigner(freeLead, null, false, true);
				}
			}
			MyCompany.ResetAcceptRates();
			ConferenceController.UpdateDay();
			OnGameReady();
		}
		if (PreSimActive)
		{
			if (!PreSimLoadPanel.activeSelf)
			{
				ForcePause = true;
				PreSimLoadPanel.SetActive(true);
			}
			if (!FreezeGame)
			{
				FreezeGame = true;
			}
			PreSimLoadText.text = presimloadtxt;
			PreSimSWText.text = presimswtext;
			PreSimBar.Value = presimloadbar;
		}
		else if (PreSimLoadPanel.activeSelf)
		{
			ForcePause = false;
			PreSimLoadPanel.SetActive(false);
		}
	}

	private void InitSimThread()
	{
		using (new ReadWriteLockUse(GameReader.SaveLock))
		{
			SDateTime time = new SDateTime(1970);
			try
			{
				Dictionary<string, string> translate = simulation.SoftwareTypes.ToDictionary((KeyValuePair<string, SoftwareType> x) => x.Key, (KeyValuePair<string, SoftwareType> x) => Localization.GetSoftware(x.Value)[0]);
				simulation.RaiseEvents = false;
				PreSimActive = true;
				DateTime now = DateTime.Now;
				SDateTime time2 = SDateTime.Now();
				int num = TimeOfDay.Instance.Year - time.Year;
				simulation.InitialReleases(time);
				for (int num2 = 0; num2 <= 12 * num; num2++)
				{
					if (IsQuitting)
					{
						return;
					}
					presimloadtxt = time.RealYear.ToString();
					presimswtext = "CompanyLoadMsg".Loc() + ": " + (simulation.CompanyCount - 1) + "\n" + string.Join("\n", (from x in simulation.GetAllProducts(true)
						group x by new KeyValuePair<string, string>(translate[x.Type.Name], x.Category.Name.LocSWC(x.Type.Name)) into x
						orderby x.Key.Key
						select x.Key.Key + " - " + x.Key.Value + ": " + x.Count()).ToArray());
					presimloadbar = (float)num2 / ((float)num * 12f);
					for (int num3 = 0; num3 < DaysPerMonth; num3++)
					{
						if (num2 > 1 && SkipSimulation)
						{
							break;
						}
						lock (TimeOfDay.Instance.TimeLock)
						{
							TimeOfDay.Instance.UpdateTime(time);
							simulation.SimulateMonth(time, true);
							TimeOfDay.Instance.UpdateTime(time2);
						}
						if (num2 == 12 * num)
						{
							break;
						}
						time += new SDateTime(1, 0, 0);
					}
					simulation.EndDay(time, MyCompany);
					if (num2 == 12 * num - 1)
					{
						Newspaper.StoryRollover(time, true, true);
					}
				}
				time += new SDateTime(0, 7, 0, 0);
				TimeOfDay.Instance.UpdateTime(time);
				TimeOfDay.Instance.DisableSunUpdate = false;
				Debug.Log("Market presim time: " + (DateTime.Now - now).TotalSeconds.SecondsToTime());
				presimfinaltime = time;
				PreSimActive = false;
				PreSimFinished = true;
				simulation.RaiseEvents = true;
				simulation.TurnLoss();
			}
			catch (ThreadAbortException)
			{
			}
			catch (Exception ex2)
			{
				ErrorLogging.AddException(ex2);
				presimfinaltime = time;
				PreSimActive = false;
				PreSimFinished = true;
				simulation.RaiseEvents = true;
			}
		}
	}

	public void LoadPortalData()
	{
		if ((_tempPortal1 != 0 || _tempPortal2 != 0) && Portal1 == null && Portal2 == null)
		{
			Portal1 = Writeable.STGetDeserializedObject(_tempPortal1) as Furniture;
			Portal2 = Writeable.STGetDeserializedObject(_tempPortal2) as Furniture;
			_tempPortal1 = 0u;
			_tempPortal2 = 0u;
			ConnectPortals();
		}
	}

	private void ConnectPortals()
	{
		if (Portal1 != null && Portal2 != null)
		{
			if (Portal1.pathNode.AddConnection(Portal2.pathNode) | Portal2.pathNode.AddConnection(Portal1.pathNode))
			{
				sRoomManager.RoomNearnessDirty = true;
			}
			Portal1.IsOn = true;
			Portal2.IsOn = true;
			return;
		}
		if (Portal1 != null)
		{
			Portal1.IsOn = false;
		}
		if (Portal2 != null)
		{
			Portal2.IsOn = false;
		}
	}

	public void InitNewPortal(Furniture portal)
	{
		if (Portal1 == null)
		{
			Portal1 = portal;
		}
		else if (Portal2 == null)
		{
			Portal2 = portal;
		}
		else
		{
			if (Portal1.pathNode.RemoveConnection(Portal2.pathNode) | Portal2.pathNode.RemoveConnection(Portal1.pathNode))
			{
				sRoomManager.RoomNearnessDirty = true;
			}
			Portal2.IsOn = false;
			Portal2 = portal;
		}
		ConnectPortals();
	}

	public void RefreshPortals(Furniture ignore)
	{
		if (Portal1 == null)
		{
			Portal1 = sRoomManager.GetFurniture("Portal").FirstOrDefault((Furniture x) => x != Portal2 && x != ignore);
		}
		if (Portal2 == null)
		{
			Portal2 = sRoomManager.GetFurniture("Portal").FirstOrDefault((Furniture x) => x != Portal1 && x != ignore);
		}
		ConnectPortals();
	}

	public void Deserialize(WriteDictionary dictionary, Writeable.LoadType networkMode)
	{
		ColumnDataLoaded = true;
		GameReader.NewLoadMode lm = GameReader.NewLoadMode.Full;
		if (dictionary.Contains("SaveMode"))
		{
			switch (dictionary.Get("SaveMode", GameReader.LoadMode.Full))
			{
			case GameReader.LoadMode.Full:
				lm = GameReader.NewLoadMode.Full;
				break;
			case GameReader.LoadMode.Building:
				lm = GameReader.NewLoadMode.Building;
				break;
			case GameReader.LoadMode.Company:
				lm = GameReader.NewLoadMode.Company;
				break;
			}
		}
		else
		{
			lm = dictionary.Get("NewSaveMode", GameReader.NewLoadMode.Full);
		}
		if (networkMode != Writeable.LoadType.NetworkClient && IsNetworkMode)
		{
			NetworkManager.Instance.DeserializeNetworkIDs(dictionary);
		}
		PermanentUnlock = dictionary.Get("PermanentUnlock", true);
		if (PermanentUnlock)
		{
			TogglePermanentUnlock(true);
		}
		Errors.AddRange(dictionary.Get("Errors", new SHashSet<string>()));
		RoomStyles = dictionary.Get("RoomStyles", RoomStyles);
		if (dictionary.Contains("AutoLog"))
		{
			HUD.Instance.AutoLog.SetLog(dictionary.Get<string>("AutoLog"));
		}
		CampaignCharacters = dictionary.Get<Dictionary<string, MissionGuide.CampaignCharacter>>("CampaignCharacters", null);
		string autos = dictionary.Get<string>("Autosave", null);
		if (autos != null)
		{
			AssociatedAutoSave = SaveGameManager.SaveGames.FirstOrDefault((SaveGame x) => !x.Readonly && x.FileName.Equals(autos));
			if (AssociatedAutoSave != null && EditMode != AssociatedAutoSave.BuildingOnly)
			{
				AssociatedAutoSave = null;
			}
		}
		if (lm.Is(GameReader.NewLoadMode.Building))
		{
			ElevatorsSerialized = false;
		}
		if (lm.Is(GameReader.NewLoadMode.FullOrBuilding))
		{
			if (CliType == GameData.ClimateType.Warm)
			{
				TimeOfDay.Instance.GroundMat.SetTexture("_GrassNormal", null);
				TimeOfDay.Instance.GroundMat2.SetTexture("_GrassNormal", null);
			}
			if (!EditMode)
			{
				if (networkMode == Writeable.LoadType.NetworkClient)
				{
					List<PlotArea> list = dictionary.Get<List<PlotArea>>("PlayerPlots");
					if (list != null)
					{
						PLoanData = list.SelectNotNullable(PlotLoanData.TryGetLoan).ToList();
					}
				}
				else
				{
					Plots = dictionary.Get("Plots", Plots);
					PlayerPlots = dictionary.Get("PlayerPlots", PlayerPlots);
					if (lm.Is(GameReader.NewLoadMode.Building))
					{
						PlayerPlots.ForEach(delegate(PlotArea x)
						{
							x.MonthsLeft = 0;
						});
					}
					InitPlots(false);
				}
			}
			if (networkMode != Writeable.LoadType.NetworkClient)
			{
				TimeOfDay.Instance.CurrentWeather = ObjectDatabase.Instance.WeatherPresets[(int)CliType];
				Environment = ObjectDatabase.Instance.EnvironmentPresets[(int)EnvType];
				CritterController.Instance.PopulateCritter(CliType, EnvType);
				CachedTrees = ObjectDatabase.Instance.Trees.Where((StaticTree x) => x.ValidFor(CliType)).ToArray();
				List<TreeInstance> list2 = dictionary.Get<List<TreeInstance>>("Trees2", null);
				if (list2 == null)
				{
					SpawnTrees();
				}
				else
				{
					foreach (TreeInstance item in list2)
					{
						CreateTree(item.Idx, item.Position, item.Rotation);
					}
				}
			}
			if (networkMode != Writeable.LoadType.NetworkHost)
			{
				_tempPortal1 = dictionary.Get("Portal1", _tempPortal1);
				_tempPortal2 = dictionary.Get("Portal2", _tempPortal2);
				_hardwareFurnInstances = dictionary.Get("HardwareFurnInstances", _hardwareFurnInstances);
				KeyValuePair<KeyValuePair<uint, uint>, HardwareDesignFurn.HardwareFurnInstance>[] array = _hardwareFurnInstances.ToArray();
				for (int num = 0; num < array.Length; num++)
				{
					KeyValuePair<KeyValuePair<uint, uint>, HardwareDesignFurn.HardwareFurnInstance> keyValuePair = array[num];
					if (!keyValuePair.Value.LoadData())
					{
						_hardwareFurnInstances.Remove(keyValuePair.Key);
					}
				}
			}
			TimeOfDay.Instance.UpdateExtraLayerColor();
			RoomGroups = dictionary.Get("RoomGroups", RoomGroups);
			CreateOutsideGroup();
			if (dictionary.Contains("ServerGroups"))
			{
				ServerGroups = dictionary.Get("ServerGroups", Array.Empty<WriteDictionary>()).ToDictionary((WriteDictionary x) => x["Name"].ToString(), ServerGroup.Deserialize);
			}
		}
		if (lm.Is(GameReader.NewLoadMode.FullOrCompany))
		{
			if (dictionary.Contains("ReadyState"))
			{
				NetworkManager.Self.Ready = dictionary.Get<NetworkPlayer.ReadyStatus>("ReadyState");
			}
			if (dictionary.Contains("EmployeeTerminations"))
			{
				SerializedEvents = dictionary["EmployeeTerminations"] as List<EmployeeTermination>;
			}
			SDateTime sDateTime = (SDateTime)dictionary["Time"];
			TimeOfDay.Instance.Minute = sDateTime.Minute;
			TimeOfDay.Instance.Hour = sDateTime.Hour;
			TimeOfDay.Instance.Day = sDateTime.Day;
			TimeOfDay.Instance.Month = sDateTime.Month;
			TimeOfDay.Instance.Year = sDateTime.Year;
			TimeOfDay.Instance.targetDate = TimeOfDay.Instance.GetDate(true).ToInt();
			simulation = (MarketSimulation)dictionary["Simulation"];
			MyCompany = dictionary.Get("Company", MyCompany);
			EventList<object> eventList = dictionary.Get<EventList<object>>("Contracts", null);
			if (eventList != null)
			{
				HUD.Instance.contractWindow.Contracts.Items = eventList;
			}
			NotificationMessage[][] array2 = dictionary.Get<NotificationMessage[][]>("Notifications", null);
			if (array2 != null)
			{
				NotificationManager.Instance.DeserializeAll(array2);
			}
			if (dictionary.Contains("DisabledTutorials"))
			{
				DisabledTutorials = dictionary.Get("DisabledTutorials", new List<string>()).ToHashSet();
			}
			Loans = dictionary.Get("Loans2", Loans);
			List<KeyValuePair<int, float>> list3 = dictionary.Get("Loans", new List<KeyValuePair<int, float>>());
			if (list3 != null)
			{
				Loans.AddRange(list3.Select((KeyValuePair<int, float> x) => new Loan(x.Key, x.Value, 0f, 0f)));
			}
			string[][] specialization = GameData.GetSpecialization(simulation.SoftwareTypes.Values.ToArray());
			CodeSpecializations = specialization[1];
			ArtSpecializations = specialization[2];
			Specializations = specialization[0];
			Personalities = dictionary.Get("Personalities", GameData.AllPersonalities());
			Personalities.FixTraits();
			StyleDefaults = dictionary.Get("StyleDef", StyleDefaults);
			if (networkMode != Writeable.LoadType.NetworkHost)
			{
				OffshoreAccount = (dictionary.Contains("OffshoreAccount") ? ((double)dictionary.Get("OffshoreAccount", (float)OffshoreAccount)) : dictionary.Get("OffshoreAccount2", OffshoreAccount));
			}
			if (dictionary.Contains("ColorDef"))
			{
				ColorDefaults = dictionary.Get("ColorDef", new Dictionary<string, SVector3>()).ToDictionary((KeyValuePair<string, SVector3> x) => x.Key, (KeyValuePair<string, SVector3> x) => x.Value.ToColor());
			}
			Insurance = dictionary.Get("Insurance", Insurance);
			if (dictionary.Contains("Difficulty2"))
			{
				if (dictionary.TryGet<DifficultyValues.DifficultySetting>("Difficulty2", out Difficulty))
				{
					Difficulty = DifficultyValues.TryGetEquivalent(Difficulty) ?? Difficulty;
				}
				else
				{
					Difficulty = DifficultyValues.DefaultSettings;
				}
			}
			else
			{
				Difficulty = DifficultyValues.GetDifficulty(GameData.ObsoleteDifficultySettings[Mathf.Clamp(dictionary.Get("Difficulty", 0), 0, GameData.ObsoleteDifficultySettings.Length - 1)]);
			}
			if (dictionary.Contains("Company"))
			{
				if (networkMode == Writeable.LoadType.Default)
				{
					MyCompany.Products.ForEach(delegate(SoftwareProduct x)
					{
						x.RegisterServer();
					});
				}
				foreach (WorkItem workItem in MyCompany.WorkItems)
				{
					SoftwareAlpha softwareAlpha;
					SoftwareUpdate softwareUpdate;
					if ((softwareAlpha = workItem as SoftwareAlpha) != null)
					{
						softwareAlpha.RegisterServer();
					}
					else if ((softwareUpdate = workItem as SoftwareUpdate) != null)
					{
						softwareUpdate.RegisterServer();
					}
				}
			}
			Newspaper.Instance.Stories = dictionary.Get("NewspaperCurrent", Newspaper.Instance.Stories);
			Newspaper.Instance.InitializeSections();
			Newspaper.UpdateStories();
			HUD.Instance.contractWindow.ContractResults.Items.AddRange(dictionary.Get("ContractResults", Array.Empty<ContractResult>()));
			HUD.Instance.dealWindow.Deserialize(dictionary);
			HUD.Instance.eventWindow.Deserialize(dictionary);
			if (dictionary.Contains("TeamDefaults"))
			{
				TeamDefaults = dictionary.Get("TeamDefaults", new Dictionary<string, string[]>()).ToDictionary((KeyValuePair<string, string[]> x) => x.Key, (KeyValuePair<string, string[]> x) => x.Value.ToHashSet());
			}
			ReviewJobs = dictionary.Get("ReviewJobs", ReviewJobs);
			FollowerSimulation = dictionary.Get("FollowerSimulation", FollowerSimulation);
			if (dictionary.Contains("PressBuildQueue"))
			{
				PressBuildQueue = dictionary.Get("PressBuildQueue", new List<SoftwareAlpha>()).ToHashSet();
			}
			TimeOfDay.Instance.Banktupcy = dictionary.Get("Bankruptcy", TimeOfDay.Instance.Banktupcy);
			if (dictionary.Contains("PrintOrders3"))
			{
				PrintOrders = dictionary.Get("PrintOrders3", new List<PrintJob>()).ToDictionaryList((PrintJob x) => x.Target, (PrintJob x) => x);
				HUD.Instance.distributionWindow.RefreshOrders();
			}
			if (dictionary.Contains("NetworkPrintOrders"))
			{
				NetworkPrintOrders = dictionary.Get("NetworkPrintOrders", NetworkPrintOrders);
			}
			if (dictionary.Contains("WorkItemFilter"))
			{
				Dictionary<string, bool> dictionary2 = dictionary.Get("WorkItemFilter", new Dictionary<string, bool>());
				if (dictionary2.Any((KeyValuePair<string, bool> x) => x.Value))
				{
					foreach (KeyValuePair<string, bool> item2 in dictionary2)
					{
						Toggle orNull = HUD.Instance.WorkToToggle.GetOrNull(item2.Key);
						if (orNull != null)
						{
							orNull.isOn = item2.Value;
						}
					}
				}
				HUD.Instance.GroupTaskManager.ChangeType((int)dictionary.Get("WorkItemGroup", WorkGroupManager.GroupType.None));
			}
			Dictionary<string, List<InventoryItem>> val;
			if (dictionary.TryGet<Dictionary<string, List<InventoryItem>>>("FurnitureInventory", out val) && val != null)
			{
				foreach (KeyValuePair<string, List<InventoryItem>> item3 in val)
				{
					FurnitureInventory.GetOrAdd(item3.Key, (string x) => new List<InventoryItem>()).AddRange(item3.Value);
				}
			}
			BillsNext = dictionary.Get("BillsNext2", BillsNext);
			BillsCurrent = dictionary.Get("BillsCurrent2", BillsCurrent);
			_lawsuitQueue = dictionary.Get("LawsuitQueue", _lawsuitQueue);
			if (dictionary.Contains("Complaints"))
			{
				Complaint[] range = dictionary.Get<Complaint[]>("Complaints");
				HUD.Instance.complaintWindow.ComplaintList.Items.AddRange(range);
			}
			BoxController.BoxesShippedLast = dictionary.Get("BoxesShippedLast", BoxController.BoxesShippedLast);
			BoxController.BoxesShipped = dictionary.Get("BoxesShipped", BoxController.BoxesShipped);
			_assemblyLines = dictionary.Get("AssemblyLines", _assemblyLines);
			_assemblyLines.ForEach(delegate(AssemblyLine x)
			{
				x.CleanUp();
			});
			HUD.Instance.hireWindow.LastFilter = dictionary.Get("LastHireFilter", HUD.Instance.hireWindow.LastFilter);
			HUD.Instance.hireWindow.HireFilters = dictionary.Get("AllHireFilters", HUD.Instance.hireWindow.HireFilters);
			MetalMarkets = dictionary.Get("MetalMarkets", MetalMarkets);
			if (MetalMarkets == null)
			{
				CreateMetalMarkets();
			}
			HUD.Instance.hireWindow.HireWin.BonusPool = dictionary.Get("BonusPool", HUD.Instance.hireWindow.HireWin.BonusPool);
			if (networkMode != Writeable.LoadType.NetworkHost)
			{
				UnlockCheck.Deserialize(dictionary);
			}
		}
		if (!lm.Is(GameReader.NewLoadMode.Full))
		{
			return;
		}
		ActiveFireReport = dictionary.Get("FireReport", ActiveFireReport);
		ElevatorGroups = dictionary.Get("ElevatorGroups", ElevatorGroups);
		ElevatorsSerialized = dictionary.Contains("ElevatorGroups") && ElevatorGroups.Count > 0;
		_printsInStorage = dictionary.Get("PrintsInStorage2", new Dictionary<IStockable, uint>());
		TimeOfDay.Instance.Cloudiness = dictionary.Get("CloudCloudiness", 0f);
		TimeOfDay.Instance.Offset = dictionary.Get("CloudOffset", new SVector3(0f, 0f, 0f));
		TimeOfDay.Instance.Windiness = dictionary.Get("CloudWindiness", new SVector3(0f, 0f, 0f));
		TimeOfDay.Instance.SunLight.cookieSize = dictionary.Get("CloudSize", 300f);
		SerializedBoxes = dictionary.Get("TransportBoxes", SerializedBoxes);
		SerializedHeli = dictionary.Get("Helicopters", SerializedHeli);
		HUD.Instance.hireWindow.HireWin.HirePool = dictionary.Get("HirePool", HUD.Instance.hireWindow.HireWin.HirePool);
		if (Options.DynamicPaths && dictionary.Contains("Trot2"))
		{
			try
			{
				_lastGrassFetch = dictionary.Get<byte[]>("Trot2");
				Texture2D texture2D = new Texture2D(TrotSize, TrotSize, TextureFormat.RFloat, false);
				texture2D.SetPixels(_lastGrassFetch.Select((byte x) => new Color((float)(int)x / 255f, 1f, 1f, 1f)).ToArray());
				texture2D.Apply();
				Graphics.CopyTexture(texture2D, GrassTrot);
				UnityEngine.Object.Destroy(texture2D);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			_lastUpdate = SDateTime.Now();
		}
		WriteDictionary val2;
		if (dictionary.TryGet<WriteDictionary>("ForcedPrefab", out val2))
		{
			BuildController.Instance.CreateForcedPrefab().Deserialize(val2);
		}
	}

	public WriteDictionary Serialize(GameReader.NewLoadMode mode, Writeable.LoadType networkMode)
	{
		WriteDictionary writeDictionary = new WriteDictionary("GameSettings");
		writeDictionary["NewSaveMode"] = mode;
		if (networkMode != Writeable.LoadType.NetworkHost)
		{
			writeDictionary["Errors"] = Errors;
			writeDictionary["Autosave"] = ((AssociatedAutoSave != null) ? AssociatedAutoSave.FileName : null);
			writeDictionary["RoomStyles"] = RoomStyles;
			writeDictionary["ServerGroups"] = ServerGroups.Values.Select((ServerGroup x) => x.Serialize()).ToArray();
			if (IsNetworkMode)
			{
				NetworkManager.Instance.SerializeNetworkIDs(writeDictionary);
			}
		}
		if (mode.Is(GameReader.NewLoadMode.FullOrCompany))
		{
			writeDictionary["Time"] = SDateTime.Now();
			writeDictionary["Simulation"] = simulation;
			if (networkMode != Writeable.LoadType.NetworkHost)
			{
				writeDictionary["Company"] = MyCompany;
				writeDictionary["Contracts"] = HUD.Instance.contractWindow.Contracts.Items;
				writeDictionary["Notifications"] = NotificationManager.Instance.SerializeAll();
				writeDictionary["DisabledTutorials"] = DisabledTutorials.ToList();
				writeDictionary["Loans2"] = Loans;
				writeDictionary["Insurance"] = Insurance;
				writeDictionary["StyleDef"] = StyleDefaults;
				writeDictionary["ColorDef"] = ((IEnumerable<KeyValuePair<string, Color>>)ColorDefaults).ToDictionary((Func<KeyValuePair<string, Color>, string>)((KeyValuePair<string, Color> x) => x.Key), (Func<KeyValuePair<string, Color>, SVector3>)((KeyValuePair<string, Color> x) => x.Value));
				writeDictionary["NewspaperCurrent"] = Newspaper.Instance.Stories;
				writeDictionary["ContractResults"] = HUD.Instance.contractWindow.ContractResults.Items.Cast<ContractResult>().ToArray();
				writeDictionary["EmployeeTerminations"] = HUD.Instance.insuranceWindow.Terminations.Items.OfType<EmployeeTermination>().ToList();
				HUD.Instance.dealWindow.Serialize(writeDictionary);
				HUD.Instance.eventWindow.Serialize(writeDictionary);
				writeDictionary["TeamDefaults"] = TeamDefaults.ToDictionary((KeyValuePair<string, HashSet<string>> x) => x.Key, (KeyValuePair<string, HashSet<string>> x) => x.Value.ToArray());
				writeDictionary["ReviewJobs"] = ReviewJobs;
				writeDictionary["FollowerSimulation"] = FollowerSimulation;
				writeDictionary["PressBuildQueue"] = PressBuildQueue.ToList();
				writeDictionary["Bankruptcy"] = TimeOfDay.Instance.Banktupcy;
				writeDictionary["WorkItemFilter"] = HUD.Instance.WorkToToggle.ToDictionary((KeyValuePair<string, Toggle> x) => x.Key, (KeyValuePair<string, Toggle> x) => x.Value.isOn);
				writeDictionary["WorkItemGroup"] = HUD.Instance.GroupTaskManager.Grouping;
				writeDictionary["PrintOrders3"] = PrintOrders.List;
				if (IsNetworkMode)
				{
					writeDictionary["NetworkPrintOrders"] = NetworkPrintOrders;
				}
				writeDictionary["BillsNext2"] = BillsNext;
				writeDictionary["BillsCurrent2"] = BillsCurrent;
				writeDictionary["LawsuitQueue"] = _lawsuitQueue;
				writeDictionary["Complaints"] = HUD.Instance.complaintWindow.ComplaintList.Items.OfType<Complaint>().ToArray();
				writeDictionary["PermanentUnlock"] = PermanentUnlock;
				writeDictionary["AutoLog"] = HUD.Instance.AutoLog.MainText.text;
				writeDictionary["BoxesShippedLast"] = BoxController.BoxesShippedLast;
				writeDictionary["BoxesShipped"] = BoxController.BoxesShipped;
				writeDictionary["AssemblyLines"] = _assemblyLines;
				writeDictionary["LastHireFilter"] = HUD.Instance.hireWindow.LastFilter;
				writeDictionary["AllHireFilters"] = HUD.Instance.hireWindow.HireFilters;
				writeDictionary["FurnitureInventory"] = FurnitureInventory;
				UnlockCheck.Serialize(writeDictionary);
				if (IsNetworkMode)
				{
					writeDictionary["ReadyState"] = NetworkManager.Self.Ready;
				}
				writeDictionary["OffshoreAccount2"] = OffshoreAccount;
				writeDictionary["HardwareFurnInstances"] = _hardwareFurnInstances;
			}
			writeDictionary["Portal1"] = ((Portal1 != null) ? Portal1.DID : 0u);
			writeDictionary["Portal2"] = ((Portal2 != null) ? Portal2.DID : 0u);
			writeDictionary["Personalities"] = Personalities;
			writeDictionary["Difficulty2"] = Difficulty;
			writeDictionary["MetalMarkets"] = MetalMarkets;
			writeDictionary["BonusPool"] = HUD.Instance.hireWindow.HireWin.BonusPool;
			if (CampaignMode && !EditMode)
			{
				writeDictionary["CampaignCharacters"] = CampaignCharacters;
			}
		}
		if (mode.Is(GameReader.NewLoadMode.Full))
		{
			if (networkMode != Writeable.LoadType.NetworkHost)
			{
				writeDictionary["FireReport"] = ActiveFireReport;
				writeDictionary["PrintsInStorage2"] = _printsInStorage;
				ElevatorGroups.ForEach(delegate(ElevatorGroup x)
				{
					x.PrepareSerialize();
				});
				writeDictionary["ElevatorGroups"] = ElevatorGroups;
				if (Options.DynamicPaths)
				{
					if (_lastFetchTask.HasValue)
					{
						_lastFetchTask.Value.WaitForCompletion();
					}
					if (_lastGrassFetch != null)
					{
						writeDictionary["Trot2"] = _lastGrassFetch;
					}
				}
				writeDictionary["TransportBoxes"] = BoxController.Serialize();
				writeDictionary["Helicopters"] = BoxController.GetHelicopterData();
				if (BuildController.Instance.ActivePrefab != null)
				{
					writeDictionary["ForcedPrefab"] = BuildController.Instance.ActivePrefab.Serialize();
				}
			}
			writeDictionary["CloudCloudiness"] = TimeOfDay.Instance.Cloudiness;
			writeDictionary["CloudOffset"] = (SVector3)TimeOfDay.Instance.Offset;
			writeDictionary["CloudWindiness"] = (SVector3)TimeOfDay.Instance.Windiness;
			writeDictionary["CloudSize"] = TimeOfDay.Instance.SunLight.cookieSize;
			if (networkMode != Writeable.LoadType.NetworkHost)
			{
				writeDictionary["HirePool"] = HUD.Instance.hireWindow.HireWin.HirePool;
			}
		}
		if (mode.Is(GameReader.NewLoadMode.FullOrBuilding))
		{
			if (networkMode != Writeable.LoadType.NetworkHost)
			{
				writeDictionary["RoomGroups"] = RoomGroups.Where((KeyValuePair<string, RoomGroup> x) => x.Value.SaveMe).ToDictionary((KeyValuePair<string, RoomGroup> x) => x.Key, (KeyValuePair<string, RoomGroup> x) => x.Value);
			}
			writeDictionary["Plots"] = Plots;
			writeDictionary["PlayerPlots"] = PlayerPlots;
			writeDictionary["Trees2"] = Trees;
		}
		return writeDictionary;
	}

	public float GetTrotAmount(Vector2 p)
	{
		if (_lastGrassFetch == null)
		{
			return 0f;
		}
		int num = Mathf.FloorToInt(p.x / 256f * (float)TrotSize);
		int num2 = Mathf.FloorToInt(p.y / 256f * (float)TrotSize) * TrotSize + num;
		if (num2 > 0 && num2 < _lastGrassFetch.Length)
		{
			return (float)(255 - _lastGrassFetch[num2]) / 255f;
		}
		return 0f;
	}

	public void FetchGrass()
	{
		if (Options.DynamicPaths && GrassTrot != null)
		{
			if (!_fetchingGrass && Time.realtimeSinceStartup - _fetchCooldown > 1f)
			{
				_fetchingGrass = true;
				if (!SystemInfo.supportsAsyncGPUReadback)
				{
					if (_tempGrassTex != null && _tempGrassTex.width != GrassTrot.width)
					{
						UnityEngine.Object.Destroy(_tempGrassTex);
						_tempGrassTex = null;
					}
					if (_tempGrassTex == null)
					{
						_tempGrassTex = new Texture2D(GrassTrot.width, GrassTrot.height, TextureFormat.ARGB32, false);
					}
					RenderTexture active = RenderTexture.active;
					RenderTexture temporary = RenderTexture.GetTemporary(GrassTrot.width, GrassTrot.height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
					Graphics.Blit(GrassTrot, temporary);
					RenderTexture.active = temporary;
					_tempGrassTex.ReadPixels(new Rect(0f, 0f, GrassTrot.width, GrassTrot.height), 0, 0, false);
					_tempGrassTex.Apply(false);
					RenderTexture.active = active;
					RenderTexture.ReleaseTemporary(temporary);
					byte[] rawTextureData = _tempGrassTex.GetRawTextureData();
					int num = rawTextureData.Length / 4;
					if (_lastGrassFetch == null || _lastGrassFetch.Length != num)
					{
						_lastGrassFetch = new byte[num];
					}
					for (int i = 0; i < num; i++)
					{
						_lastGrassFetch[i] = rawTextureData[i * 4 + 1];
					}
					_fetchingGrass = false;
				}
				else
				{
					_lastFetchTask = AsyncGPUReadback.Request(GrassTrot, 0, delegate(AsyncGPUReadbackRequest req)
					{
						if (req.done && !req.hasError)
						{
							try
							{
								NativeArray<float> data = req.GetData<float>();
								int num2 = req.width * req.height;
								if (_lastGrassFetch == null || _lastGrassFetch.Length != num2)
								{
									_lastGrassFetch = new byte[num2];
								}
								for (int j = 0; j < num2; j++)
								{
									_lastGrassFetch[j] = (byte)Mathf.Clamp(data[j] * 256f, 0f, 255f);
								}
							}
							catch (Exception)
							{
							}
						}
						_fetchingGrass = false;
						_lastFetchTask = null;
					});
				}
			}
			_fetchCooldown = Time.realtimeSinceStartup;
		}
		else
		{
			_fetchingGrass = false;
		}
	}

	public string[] GetAllSpecializations(Employee.EmployeeRole role)
	{
		switch (role)
		{
		case Employee.EmployeeRole.Lead:
			return Employee.LeadSpecs;
		case Employee.EmployeeRole.Programmer:
			return CodeSpecializations;
		case Employee.EmployeeRole.Designer:
			return Specializations;
		case Employee.EmployeeRole.Artist:
			return ArtSpecializations;
		case Employee.EmployeeRole.Service:
			return Employee.ServiceSpecs;
		default:
			throw new ArgumentOutOfRangeException("role", role, null);
		}
	}

	private void RefreshSpecCache()
	{
		lock (CachedSpecDict)
		{
			if (!CachedSpecs || LastSpec.Day != TimeOfDay.Instance.Day || LastSpec.Year != TimeOfDay.Instance.Year || LastSpec.Month != TimeOfDay.Instance.Month)
			{
				CachedSpecs = true;
				LastSpec = SDateTime.Now();
				List<SoftwareType> types = simulation.SoftwareTypes.Values.ToList();
				SoftwareType oS = simulation.SoftwareTypes["Operating System"];
				CachedSpecDict[0] = Employee.LeadSpecs;
				CachedSpecDict[4] = Employee.ServiceSpecs;
				CachedSpecDict[3] = GameData.FilterUnlockedSpecs(ArtSpecializations, TimeOfDay.Instance.Year, types, oS);
				CachedSpecDict[1] = GameData.FilterUnlockedSpecs(CodeSpecializations, TimeOfDay.Instance.Year, types, oS);
				CachedSpecDict[2] = GameData.FilterUnlockedSpecs(Specializations, TimeOfDay.Instance.Year, types, oS);
			}
		}
	}

	public string[][] GetAllUnlockedSpecializations()
	{
		RefreshSpecCache();
		return CachedSpecDict;
	}

	public string[] GetUnlockedSpecializations(Employee.EmployeeRole role)
	{
		RefreshSpecCache();
		return CachedSpecDict[(int)role];
	}

	public static int GetMaxSpecPoints(Employee.EmployeeRole role, bool forceFull = false, bool limitToUnlocked = false)
	{
		if (Instance.IsReferenceNull())
		{
			return GameData.GetMaxSpecPoints(role);
		}
		if (forceFull)
		{
			switch (role)
			{
			case Employee.EmployeeRole.Lead:
				return Employee.LeadSpecs.Length * 3;
			case Employee.EmployeeRole.Programmer:
			{
				int num2 = Instance.CodeSpecializations.Length * 3;
				if (limitToUnlocked)
				{
					num2 = Mathf.Min(num2, Instance.GetUnlockedSpecializations(Employee.EmployeeRole.Programmer).Length * 3);
				}
				return num2;
			}
			case Employee.EmployeeRole.Designer:
			{
				int num3 = Instance.Specializations.Length * 3;
				if (limitToUnlocked)
				{
					num3 = Mathf.Min(num3, Instance.GetUnlockedSpecializations(Employee.EmployeeRole.Designer).Length * 3);
				}
				return num3;
			}
			case Employee.EmployeeRole.Artist:
			{
				int num = Instance.ArtSpecializations.Length * 3;
				if (limitToUnlocked)
				{
					num = Mathf.Min(num, Instance.GetUnlockedSpecializations(Employee.EmployeeRole.Artist).Length * 3);
				}
				return num;
			}
			case Employee.EmployeeRole.Service:
				return Employee.ServiceSpecs.Length * 3;
			}
		}
		else
		{
			switch (role)
			{
			case Employee.EmployeeRole.Lead:
				return Employee.MaxLeadSpec;
			case Employee.EmployeeRole.Programmer:
			{
				int num5 = GameData.MaxDevSpec(Instance.CodeSpecializations.Length);
				if (limitToUnlocked)
				{
					num5 = Mathf.Min(num5, Instance.GetUnlockedSpecializations(Employee.EmployeeRole.Programmer).Length * 3);
				}
				return num5;
			}
			case Employee.EmployeeRole.Designer:
			{
				int num6 = GameData.MaxDevSpec(Instance.Specializations.Length);
				if (limitToUnlocked)
				{
					num6 = Mathf.Min(num6, Instance.GetUnlockedSpecializations(Employee.EmployeeRole.Designer).Length * 3);
				}
				return num6;
			}
			case Employee.EmployeeRole.Artist:
			{
				int num4 = GameData.MaxDevSpec(Instance.ArtSpecializations.Length);
				if (limitToUnlocked)
				{
					num4 = Mathf.Min(num4, Instance.GetUnlockedSpecializations(Employee.EmployeeRole.Artist).Length * 3);
				}
				return num4;
			}
			case Employee.EmployeeRole.Service:
				return Employee.MaxServiceSpec;
			}
		}
		throw new ArgumentOutOfRangeException("role", role, null);
	}

	public double PaybackLoan()
	{
		double num = 0.0;
		float num2 = 0f;
		for (int i = 0; i < Loans.Count; i++)
		{
			Loan loan = Loans[i];
			num += loan.Monthly;
			num2 += loan.MonthlyInterest;
			if (loan.Payee != null)
			{
				loan.Payee.MakeTransaction(loan.Monthly, Company.TransactionCategory.Loan, false, MyCompany.Name);
				loan.Payee.AddTax(TaxReport.TaxType.Interest, loan.MonthlyInterest);
			}
			loan.Months--;
			if (loan.Months == 0)
			{
				Loans.RemoveAt(i);
				i--;
			}
		}
		MyCompany.MakeTransaction(0.0 - num, Company.TransactionCategory.Loan, false);
		MyCompany.AddTax(TaxReport.TaxType.Interest, 0f - num2);
		return num;
	}

	public bool IsResearching(string spec)
	{
		return MyCompany.WorkItems.OfType<ResearchWork>().Any((ResearchWork x) => x.Spec.Equals(spec));
	}

	public HashSet<string> GetDefaultTeams(string cat)
	{
		HashSet<string> value;
		if (TeamDefaults.TryGetValue(cat, out value))
		{
			return value;
		}
		string text = sActorManager.Teams.Keys.FirstOrDefault();
		if (text != null)
		{
			return new HashSet<string> { text };
		}
		return new HashSet<string>();
	}

	public HashSet<string> GetDefaultTeams(string cat, HashSet<string> defaultTeams)
	{
		return TeamDefaults.GetOrDefault(cat, defaultTeams);
	}

	public void ApplyDefaultTeams(WorkItem work, string cat)
	{
		work.AddDevTeams(GetDefaultTeams(cat));
	}

	public float GetMapCost(bool withMortgage)
	{
		return sRoomManager.GetRooms().SumSafe((Room y) => BuildController.GetRoomCost(y, false, false)) + sRoomManager.AllFurniture.Where((Furniture x) => !x.PartOfGen && string.IsNullOrEmpty(x.MetalMarket) && !"Award".Equals(x.Type)).SumSafe((Furniture x) => x.GetTimelessCost()) + sRoomManager.RoomSegments.SumSafe((RoomSegment x) => x.Cost) + PlayerPlots.SumSafe((PlotArea y) => (!withMortgage) ? y.Price : (y.Price - y.Monthly * (float)y.MonthsLeft));
	}

	public void UpdateLawsuitQueue()
	{
		SDateTime sDateTime = SDateTime.Now();
		for (int i = 0; i < _lawsuitQueue.Count; i++)
		{
			Lawsuit lawsuit = _lawsuitQueue[i];
			if (lawsuit.Start <= sDateTime)
			{
				lawsuit.Launch();
				_lawsuitQueue.RemoveAt(i);
				break;
			}
		}
	}

	public void LaunchSuit(Lawsuit l, bool now = false)
	{
		for (int i = 0; i < _lawsuitQueue.Count; i++)
		{
			Lawsuit lawsuit = _lawsuitQueue[i];
			if (lawsuit.CanCombine(l))
			{
				lawsuit.Combine(l);
				return;
			}
		}
		_lawsuitQueue.Add(now ? l : l.SetDate(SDateTime.Now() + UnityEngine.Random.value));
	}

	public bool SpawnPolice(bool confiscate)
	{
		bool result = false;
		if (confiscate)
		{
			int num = sRoomManager.AllFurniture.Count((Furniture x) => "PreciousMetal".Equals(x.Type));
			if (num > 0)
			{
				ResetUndo();
				num = Mathf.Min(4, Mathf.CeilToInt((float)num / 4f));
				for (int num2 = 0; num2 < num; num2++)
				{
					Actor actor = SpawnActor(UnityEngine.Random.value > 0.5f, true, true, "Police");
					actor.AItype = AI.AIType.Police;
					actor.IgnoreOffSalary = true;
					sActorManager.AddToAwaiting(actor, SDateTime.Now(), true);
					actor.Init();
					actor.enabled = false;
					actor.WaitSpawn = false;
					result = true;
				}
			}
		}
		else
		{
			foreach (Actor item in sActorManager.Others["Burglars"].Where((Actor x) => x.isActiveAndEnabled && x.TargetActor == null))
			{
				Actor actor2 = SpawnActor(UnityEngine.Random.value > 0.5f, true, true, "Police");
				actor2.AItype = AI.AIType.Police;
				actor2.TargetActor = item;
				item.TargetActor = actor2;
				sActorManager.AddToAwaiting(actor2, SDateTime.Now(), true);
				result = true;
			}
		}
		return result;
	}

	public float GetBurglarWorth()
	{
		float num = 0f;
		for (int i = 0; i < sRoomManager.AllFurniture.Count; i++)
		{
			Furniture furniture = sRoomManager.AllFurniture[i];
			if (furniture.CheckCanSteal())
			{
				num += furniture.GetSellPriceIgnoreQuality();
			}
		}
		return num;
	}

	public void SpawnFireFighter(Room r)
	{
		List<FireTruck> list = (from x in RoadManager.Instance.Cars.SelectNotNull((CarScript x) => x.GetComponent<FireTruck>())
			where !x.Car.GoHome
			select x).ToList();
		HashSet<RoadSegment> hashSet = new HashSet<RoadSegment>();
		FireTruck fireTruck = null;
		float num = float.MaxValue;
		foreach (FireTruck item in list)
		{
			if ((item.Car.Car.Target.GetFlatPos() - r.Center).magnitude <= 3f * RoadManager.Instance.RoadSize)
			{
				float num2 = item.Rooms.SumSafe((Room x) => x.Area * x.BurnStop);
				if (!(num2 + r.Area > 200f))
				{
					item.Rooms.Add(r);
					return;
				}
				if (num2 < num)
				{
					fireTruck = item;
					num = num2;
				}
			}
			hashSet.Add(item.Car.Car.Target.Parent);
		}
		if (list.Count > 3)
		{
			if (fireTruck != null)
			{
				fireTruck.Rooms.Add(r);
			}
			return;
		}
		RoadNode roadNode = null;
		float num3 = float.MaxValue;
		Vector2 center = r.Center;
		for (int num4 = -3; num4 <= 3; num4++)
		{
			for (int num5 = -3; num5 <= 3; num5++)
			{
				Vector2 vector = new Vector2(center.x + (float)(num4 * 8), center.y + (float)(num5 * 8));
				byte road = RoadManager.Instance.GetRoad(vector, 0);
				if (road < 1 || road > 3)
				{
					continue;
				}
				RoadSegment segment = RoadManager.Instance.GetSegment(vector, 0);
				if (!(segment != null) || hashSet.Contains(segment))
				{
					continue;
				}
				for (int num6 = 0; num6 < segment.AllNodes.Count; num6++)
				{
					RoadNode roadNode2 = segment.AllNodes[num6];
					if (!roadNode2.Unreachable)
					{
						float magnitude = (center - roadNode2.GetFlatPos()).magnitude;
						if (magnitude < num3)
						{
							num3 = magnitude;
							roadNode = roadNode2;
						}
					}
				}
			}
		}
		if (roadNode != null && num3 <= 3f * RoadManager.Instance.RoadSize)
		{
			CarScript carScript = RoadManager.Instance.CreateCar(5);
			carScript.Target = roadNode;
			carScript.Delay = UnityEngine.Random.Range(0f, 10f);
			carScript.Init();
			carScript.GetComponent<FireTruck>().Rooms = new List<Room> { r };
			if (roadNode.Unreachable)
			{
				SpawnFireFighter(r);
			}
		}
	}

	public void SpawnBurglar(int count, bool offset = false)
	{
		if (CancelDanger())
		{
			return;
		}
		SDateTime time = SDateTime.Now();
		if (offset)
		{
			HashSet<int> hashSet = new HashSet<int>(new int[24]
			{
				0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
				10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
				20, 21, 22, 23
			});
			foreach (Team value in sActorManager.Teams.Values)
			{
				if (value.WorkStart > value.WorkEnd)
				{
					for (int i = value.WorkStart; i < 24; i++)
					{
						hashSet.Remove(i);
					}
					for (int j = 0; j < value.WorkEnd; j++)
					{
						hashSet.Remove(j);
					}
				}
				else
				{
					for (int k = value.WorkStart; k < value.WorkEnd; k++)
					{
						hashSet.Remove(k);
					}
				}
				if (hashSet.Count == 0)
				{
					break;
				}
			}
			if (hashSet.Count == 0)
			{
				time += new SDateTime(UnityEngine.Random.Range(0, 60), UnityEngine.Random.Range(1, 24), 0, 0, 0);
			}
			else
			{
				time = new SDateTime(UnityEngine.Random.Range(0, 60), hashSet.GetRandom(hashSet.Count), time.Day + 1, time.Month, time.Year);
			}
		}
		for (int l = 0; l < count; l++)
		{
			InsuranceIncidentPossible = true;
			Actor actor = SpawnActor(new Employee(UnityEngine.Random.value > 0.5f, "Burglar"));
			actor.AItype = AI.AIType.Burglar;
			sActorManager.AddToAwaiting(actor, time, true);
		}
	}

	public bool HasDanger()
	{
		if (FireCounter <= 0 && !BurglarPresent())
		{
			return ConfiscationUnderway();
		}
		return true;
	}

	public static bool InspectorPresent()
	{
		if (Instance != null && Instance.sActorManager != null)
		{
			return Instance.sActorManager.Others["FireInspector"].Any((Actor x) => x.isActiveAndEnabled);
		}
		return false;
	}

	public static bool BurglarPresent()
	{
		if (Instance != null && Instance.sActorManager != null)
		{
			return Instance.sActorManager.Others["Burglars"].Any((Actor x) => x.isActiveAndEnabled);
		}
		return false;
	}

	public static bool ConstructionAllowed()
	{
		if (!BurglarPresent())
		{
			return !ConfiscationUnderway();
		}
		return false;
	}

	public static bool ConfiscationUnderway()
	{
		if (Instance != null)
		{
			if (Instance.Confiscators.Count <= 0)
			{
				if (Instance.sActorManager != null)
				{
					return Instance.sActorManager.Others["Police"].Any((Actor x) => x.IgnoreOffSalary);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool AllBurglarsPresent()
	{
		if (Instance != null && Instance.sActorManager != null)
		{
			return Instance.sActorManager.Others["Burglars"].All((Actor x) => x.isActiveAndEnabled);
		}
		return false;
	}

	public void GenerateBurglarMessage()
	{
		if (Arrested && Looted == 0)
		{
			NotificationManager.AddNotification("BurglarNotificationArrest".Loc(), "Burglar", NotificationManager.NotificationType.Good);
			RegisterStat("ThwartedBurglaries", 1f);
		}
		else if (Arrested)
		{
			NotificationManager.AddNotification(new RoomRestoreNotification("BurglarNotificationRetrieval".Loc(StolenBack, Looted), "BuglarNotificationHint".Loc(), "Burglar", Burgled));
			RegisterStat("ThwartedBurglaries", 1f);
		}
		else if (Looted > 0)
		{
			NotificationManager.AddNotification(new RoomRestoreNotification("BurglarNotificationLoot".Loc(Looted), "BuglarNotificationHint".Loc(), "Burglar", Burgled));
			RegisterStat("SuccessfulBurglaries", 1f);
		}
		else
		{
			NotificationManager.AddNotification("BurglarNotificationFail".Loc(), "Burglar", NotificationManager.NotificationType.Good);
			RegisterStat("ThwartedBurglaries", 1f);
		}
		Looted = 0;
		StolenBack = 0;
		Burgled.Clear();
		Arrested = false;
	}

	public float GetTotalStat(string stat)
	{
		List<float> value;
		if (!MiscStats.TryGetValue(stat, out value))
		{
			return 0f;
		}
		return value.SumSafe((float x) => x);
	}

	public static float GetStockPercent()
	{
		return 0.2f;
	}

	public void RefreshGaragePorts(int floor)
	{
		for (int i = 0; i < GaragePorts.Count; i++)
		{
			Furniture furniture = GaragePorts[i];
			if (furniture != null && furniture.GetFloor() == floor)
			{
				furniture.GetInteractionPoint(InteractionPoint.ActionType.Visit, true).UpdateFreeNav(false, false);
			}
		}
	}

	public bool CanCallFireInspectors()
	{
		return sActorManager.Others["FireInspector"].Count == 0;
	}

	public void CreateFireReport(FireReport fireReport)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 72;
		stringBuilder.AppendLine("FireInspection".Loc(), 24);
		if (PassedFireInspection)
		{
			stringBuilder.AppendLine("Passed".Loc(), 20, new Color(0f, 0.5f, 0f));
			num += 20;
		}
		else
		{
			stringBuilder.AppendLine("Failed".Loc(), 20, new Color(0.5f, 0f, 0f));
			stringBuilder.AppendLine("Violations".Loc() + ":", 18);
			num += 38;
			if (fireReport.EscapeViolations > 0)
			{
				stringBuilder.AppendLine(fireReport.EscapeViolations + " x " + "EscapeViolations".Loc(), 16);
				stringBuilder.AppendLine("EscapeViolationHint".Loc(), 14, new Color(0.4f, 0.4f, 0.4f));
				stringBuilder.AppendLine();
				num += 58;
			}
			if (fireReport.AlarmViolations > 0)
			{
				stringBuilder.AppendLine(fireReport.AlarmViolations + " x " + "FireAlarmViolations".Loc(), 16);
				stringBuilder.AppendLine("FireAlarmViolationHint".Loc(), 14, new Color(0.4f, 0.4f, 0.4f));
				stringBuilder.AppendLine();
				num += 58;
			}
			if (fireReport.SprinklerViolations > 0)
			{
				stringBuilder.AppendLine(fireReport.SprinklerViolations + " x " + "SprinklerViolations".Loc(), 16);
				stringBuilder.AppendLine("SprinklerViolationHint".Loc(), 14, new Color(0.4f, 0.4f, 0.4f));
				stringBuilder.AppendLine();
				num += 44;
			}
		}
		if (fireReport.Warnings)
		{
			stringBuilder.AppendLine("Warnings".Loc() + ":", 18);
			num += 18;
			if (fireReport.MaintenanceWarning)
			{
				stringBuilder.AppendLine("MaintenanceFireHint".Loc());
				stringBuilder.AppendLine();
				num += 28;
			}
			if (fireReport.ITWarning)
			{
				stringBuilder.AppendLine("ITFireHint".Loc());
				stringBuilder.AppendLine();
				num += 28;
			}
			if (fireReport.SprinklerWarning)
			{
				stringBuilder.AppendLine("SprinklerFireHint".Loc());
				stringBuilder.AppendLine();
				num += 42;
			}
		}
		if (fireReport.Fee > 0f)
		{
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("YouWereFined".Loc(fireReport.Fee.Currency()), 20, new Color(0.5f, 0f, 0f));
			num += 50;
		}
		DialogWindow d = WindowManager.SpawnDialog();
		ForcePause = true;
		FreezeGame = true;
		if (fireReport.AlarmRooms.Count > 0 || fireReport.SprinklerRooms.Count > 0 || fireReport.EscapeRooms.Count > 0)
		{
			List<KeyValuePair<string, Action>> list = new List<KeyValuePair<string, Action>>();
			list.Add(new KeyValuePair<string, Action>("OK", delegate
			{
				ForcePause = false;
				d.Window.Close();
			}));
			if (!PassedFireInspection && sActorManager.Others["FireInspector"].Count == 0)
			{
				list.Add(new KeyValuePair<string, Action>("CallFireInspector", delegate
				{
					SpawnFireInspectors(false);
					ForcePause = false;
					d.Window.Close();
				}));
			}
			list.Add(new KeyValuePair<string, Action>("View", delegate
			{
				DataOverlay.Instance.ActivateFunc("FireInspection");
				DataOverlay.Instance.Show();
				SelectorController.Instance.Highligt(false);
				SelectorController.Instance.Selected.Clear();
				for (int i = 0; i < sRoomManager.Rooms.Count; i++)
				{
					Room room = sRoomManager.Rooms[i];
					if (fireReport.AlarmRooms.Contains(room.DID) || fireReport.SprinklerRooms.Contains(room.DID) || fireReport.EscapeRooms.Contains(room.DID))
					{
						SelectorController.Instance.Selected.Add(room);
					}
				}
				SelectorController.Instance.DoPostSelectChecks();
				if (SelectorController.Instance.Selected.Count > 0)
				{
					Selectable selectable = SelectorController.Instance.Selected.First();
					CameraScript.Instance.MoveTo(selectable.GetFlatPos(), selectable.GetFloor());
				}
				HintController.Show(HintController.Hints.HintJumpToSelection);
				ForcePause = false;
				d.Window.Close();
			}));
			d.Show(stringBuilder.ToString(), false, DialogWindow.DialogType.Information, list.ToArray());
		}
		else
		{
			d.Show(stringBuilder.ToString(), false, DialogWindow.DialogType.Information, new KeyValuePair<string, Action>("OK", delegate
			{
				ForcePause = false;
				d.Window.Close();
			}));
		}
		RectTransform component = d.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(512f, num);
		component.anchoredPosition = new Vector2((float)Screen.width / Options.UISize / 2f - 256f, (float)(-Screen.height) / Options.UISize / 2f + component.sizeDelta.y / 2f);
	}

	public void FinishFireReport()
	{
		PassedFireInspection = ActiveFireReport.Finish();
		if (!PassedFireInspection)
		{
			CreateFireReport(ActiveFireReport);
			if (ActiveFireReport.IncludeFee && !PassedFireInspection)
			{
				MyCompany.MakeTransaction(0f - ActiveFireReport.Fee, Company.TransactionCategory.Bills, true, "FireInspection");
			}
			NotificationManager.AddNotification(new FireInspectionFailed(ActiveFireReport));
		}
		else
		{
			NotificationManager.AddNotification("FireInspectionPassed".Loc(), "Checkmark", NotificationManager.NotificationType.Good);
		}
	}

	public void SpawnFireInspectors(bool includeFee)
	{
		if (sActorManager.Others["FireInspector"].Count != 0)
		{
			return;
		}
		ActiveFireReport.Reset();
		ActiveFireReport.IncludeFee = includeFee;
		SDateTime sDateTime = SDateTime.Now() + SDateTime.GetDay(1);
		sDateTime = new SDateTime(0, 7, sDateTime.Day, sDateTime.Month, sDateTime.Year);
		HashSet<Room> hashSet = sRoomManager.Rooms.Where((Room x) => !x.Outdoors && (x.AtriumParent == null || x.AtriumParent == x)).ToHashSet();
		List<List<Room>> list = new List<List<Room>>();
		while (hashSet.Count > 0)
		{
			Room room = hashSet.First();
			List<Room> connected = sRoomManager.GetConnected(room, false, false, false);
			list.Add(connected);
			for (int num = 0; num < connected.Count; num++)
			{
				hashSet.Remove(connected[num]);
				hashSet.RemoveRange(connected[num].AtriumChildren);
			}
		}
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			list[num2].RemoveAll((Room x) => x.GetFurniture("Toilet").Count > 0);
			if (list[num2].Count > 50)
			{
				List<List<Room>> list2 = list[num2].SimpleClustering(RoomDistance, FireInspectorCluster);
				list[num2] = list2[0];
				for (int num3 = 1; num3 < list2.Count; num3++)
				{
					num2++;
					list.Insert(num2, list2[num3]);
				}
			}
		}
		for (int num4 = 0; num4 < list.Count; num4++)
		{
			if (list[num4].Count <= 50)
			{
				continue;
			}
			IEnumerable<IGrouping<int, Room>> source = from x in list[num4]
				group x by x.Floor;
			list[num4] = new List<Room>();
			Room room2 = null;
			foreach (IGrouping<int, Room> item in source.OrderBy((IGrouping<int, Room> x) => x.Key))
			{
				if (room2 != null)
				{
					list[num4].Add(room2);
					room2 = null;
				}
				list[num4].AddRange(item);
				if (list[num4].Count > 50)
				{
					room2 = item.First();
					list[num4].Remove(room2);
					num4++;
					list.Insert(num4, new List<Room>());
				}
			}
			if (list[num4].Count == 0)
			{
				list.RemoveAt(num4);
				num4--;
			}
			if (room2 != null)
			{
				list[num4].Add(room2);
			}
		}
		for (int num5 = 0; num5 < list.Count; num5++)
		{
			List<Room> l = list[num5];
			Actor actor = SpawnActor(UnityEngine.Random.value > 0.5f, true);
			actor.AItype = AI.AIType.FireInspector;
			actor.employee = new Employee();
			actor.InspectRooms = l.Where((Room x) => x.GetFurniture("Toilet").Count == 0).ToHashSet();
			sActorManager.AddToAwaiting(actor, sDateTime, true);
		}
	}

	private static float RoomDistance(Room r1, Room r2)
	{
		return (r1.Center.ToVector3(r1.Floor) - r2.Center.ToVector3(r2.Floor)).magnitude;
	}

	public static void AddToInventory(Furniture furn)
	{
		if (!(Instance != null))
		{
			return;
		}
		if (furn.Type.Equals("Award"))
		{
			AwardTrophy component = furn.GetComponent<AwardTrophy>();
			Instance.AddAward(component.Type, component.Tier, component.Year, component.For);
			return;
		}
		List<InventoryItem> orAdd = Instance.FurnitureInventory.GetOrAdd(furn.name, (string x) => new List<InventoryItem>());
		orAdd.Add(new InventoryItem(furn));
		HUD.Instance.RefreshInventoryCount(furn.name, orAdd.Count);
	}

	public static void AddToInventory(InventoryItem item)
	{
		if (Instance != null)
		{
			List<InventoryItem> orAdd = Instance.FurnitureInventory.GetOrAdd(item.Type, (string x) => new List<InventoryItem>());
			orAdd.Add(item);
			HUD.Instance.RefreshInventoryCount(item.Type, orAdd.Count);
		}
	}

	public static InventoryItem PopFromInventory(string type)
	{
		if (Instance != null)
		{
			List<InventoryItem> orNull = Instance.FurnitureInventory.GetOrNull(type);
			if (orNull != null && orNull.Count > 0)
			{
				InventoryItem result = orNull[orNull.Count - 1];
				orNull.RemoveAt(orNull.Count - 1);
				HUD.Instance.RefreshInventoryCount(type, orNull.Count);
				return result;
			}
		}
		return null;
	}

	public static InventoryItem FetchFromInventory(string type, uint did)
	{
		if (Instance != null)
		{
			List<InventoryItem> orNull = Instance.FurnitureInventory.GetOrNull(type);
			if (orNull != null)
			{
				for (int i = 0; i < orNull.Count; i++)
				{
					if (orNull[i].DID == did)
					{
						InventoryItem result = orNull[i];
						orNull.RemoveAt(i);
						HUD.Instance.RefreshInventoryCount(type, orNull.Count);
						return result;
					}
				}
			}
		}
		return null;
	}

	public static bool HasInventoryItem(string type, uint did)
	{
		if (Instance != null)
		{
			List<InventoryItem> orNull = Instance.FurnitureInventory.GetOrNull(type);
			if (orNull != null)
			{
				for (int i = 0; i < orNull.Count; i++)
				{
					if (orNull[i].DID == did)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public static int GetInventoryCount(string type)
	{
		List<InventoryItem> value;
		if (Instance != null && Instance.FurnitureInventory.TryGetValue(type, out value))
		{
			return value.Count;
		}
		return 0;
	}

	public IEnumerable<FurnitureStyle> GetStyles(WallSnap f)
	{
		WallSnap actual = ((f is Furniture) ? ((WallSnap)ObjectDatabase.Instance.GetFurnitureComponent(f.name)) : ((WallSnap)ObjectDatabase.Instance.GetSegmentComponent(f.name)));
		yield return new FurnitureStyle(actual, true);
		List<FurnitureStyle> l;
		if (_furnStyles.TryGetValue(f.DefaultColorGroup, out l))
		{
			for (int i = 0; i < l.Count; i++)
			{
				yield return l[i];
			}
		}
		else
		{
			for (int i = 0; i < actual.AltStyles.Count; i++)
			{
				yield return actual.AltStyles[i];
			}
		}
	}

	public int GetStyleCount(WallSnap f)
	{
		List<FurnitureStyle> value;
		if (_furnStyles.TryGetValue(f.DefaultColorGroup, out value))
		{
			return value.Count + 1;
		}
		return f.AltStyles.Count + 1;
	}

	public void AddAward(AwardTrophy.AwardType type, AwardTrophy.AwardTier tier, int year, string isFor)
	{
		AwardTrophy.AwardData awardData = new AwardTrophy.AwardData(type, tier, year, isFor);
		Awards.Add(awardData);
		HUD.Instance.UpdateAwardButtons();
		awardData.AddToSearch();
	}

	public void RemoveAward(AwardTrophy.AwardData a)
	{
		if (Awards.Remove(a))
		{
			a.RemoveFromSearch();
			HUD.Instance.UpdateAwardButtons();
		}
	}

	public void RemoveAward(AwardTrophy.AwardType type, AwardTrophy.AwardTier tier, int year)
	{
		bool flag = false;
		for (int i = 0; i < Awards.Count; i++)
		{
			AwardTrophy.AwardData awardData = Awards[i];
			if (awardData.Type == type && awardData.Tier == tier && awardData.Year == year)
			{
				flag = true;
				awardData.RemoveFromSearch();
				Awards.RemoveAt(i);
				i--;
			}
		}
		if (flag)
		{
			HUD.Instance.UpdateAwardButtons();
		}
	}

	public List<FurnitureStyle> GetLocalStyles(WallSnap furn)
	{
		List<FurnitureStyle> value;
		if (_furnStyles.TryGetValue(furn.DefaultColorGroup, out value))
		{
			return value;
		}
		value = new List<FurnitureStyle>();
		_furnStyles.Add(furn.DefaultColorGroup, value);
		value.AddRange(furn.AltStyles);
		return value;
	}

	public void RemoveStyles(WallSnap furn, FurnitureStyle style)
	{
		GetLocalStyles(furn).Remove(style);
	}

	public void AddStyle(WallSnap furn)
	{
		GetLocalStyles(furn).Add(new FurnitureStyle(furn, false));
	}

	public void AddStyle(FurnitureStyle f, WallSnap furnPrefab)
	{
		GetLocalStyles(furnPrefab).Add(f);
	}

	public void RefreshAllInventoryCounts()
	{
		foreach (KeyValuePair<string, List<InventoryItem>> item in FurnitureInventory)
		{
			HUD.Instance.RefreshInventoryCount(item.Key, item.Value.Count);
		}
	}

	public static void SellAllInventory(string type)
	{
		if (!(Instance != null))
		{
			return;
		}
		List<InventoryItem> orNull = Instance.FurnitureInventory.GetOrNull(type);
		if (orNull == null)
		{
			return;
		}
		Furniture prefab = ObjectDatabase.Instance.GetFurnitureComponent(type);
		if (prefab != null)
		{
			bool flag = false;
			float num = orNull.SumSafe((InventoryItem x) => (!x.Offshore) ? x.SellPrice(prefab) : 0f);
			if (num > 0f)
			{
				Instance.MyCompany.MakeTransaction(num, Company.TransactionCategory.Construction, false, "Furniture");
				flag = true;
			}
			num = orNull.SumSafe((InventoryItem x) => (!x.Offshore) ? 0f : x.SellPrice(prefab));
			if (num > 0f)
			{
				Instance.OffshoreAccount += num;
				flag = true;
			}
			if (flag)
			{
				UISoundFX.PlaySFX("Kaching");
			}
			orNull.Clear();
			HUD.Instance.RefreshInventoryCount(prefab, 0);
		}
	}

	public bool AddHeat(float amount, bool percent = false)
	{
		Heat += (percent ? (amount * 10000000f) : amount);
		HeatCountdown = 1440f;
		if (Heat > 10000000f)
		{
			Heat = 10000000f;
			if (HeatFullCountdown == 0f)
			{
				HeatFullCountdown = 1440f;
				Audit(true);
				return true;
			}
		}
		return false;
	}

	public bool WouldBeAudited(TaxReport report)
	{
		if (!report.IllegalActions)
		{
			return false;
		}
		if (MyCompany.WorkItems.OfType<AccountingWork>().Any((AccountingWork x) => x.Type == AccountingWork.WorkType.MoneyFunneling))
		{
			return true;
		}
		if (sRoomManager.AllFurniture.Any((Furniture x) => "PreciousMetal".Equals(x.Type)))
		{
			return true;
		}
		if (SDateTime.GetMonths(LastTaxCase, SDateTime.Now().Simplify().ChangeDayMonth(0, 3)) >= 12f && OffshoreAccount > 0.0)
		{
			return true;
		}
		return false;
	}

	public bool Audit(bool fromHeat = false)
	{
		bool flag = false;
		foreach (AccountingWork item in from x in MyCompany.WorkItems.OfType<AccountingWork>()
			where x.Type == AccountingWork.WorkType.MoneyFunneling
			select x)
		{
			item.Cost -= item.Interest;
			item.Interest = 0f;
			flag = true;
		}
		if (SpawnPolice(true))
		{
			flag = true;
		}
		string text = null;
		if ((fromHeat || SDateTime.GetMonths(LastTaxCase, SDateTime.Now()) >= 12f) && (OffshoreAccount > 0.0 || flag))
		{
			double num = Math.Max(fromHeat ? 10000000.0 : 1000000.0, OffshoreAccount);
			text = num.Currency();
			LaunchSuit(new Lawsuit("TaxFraud", num, 1f), true);
			LastTaxCase = SDateTime.Now();
			flag = true;
		}
		if (flag || fromHeat)
		{
			EmployerAwardDis = true;
			for (int num2 = 0; num2 < sActorManager.Actors.Count; num2++)
			{
				Actor actor = sActorManager.Actors[num2];
				if (actor.employee.Founder)
				{
					continue;
				}
				int num3 = Mathf.Abs(actor.employee.Name.GetHashCode() % 11);
				if (num3 >= 3)
				{
					if (num3 < 10)
					{
						actor.employee.AddInstantMood("UnethicalCompany", actor, Utilities.RandomValue.WeightOne(0.75f));
						continue;
					}
					actor.Fire(true);
					actor.employee.AddInstantMood("UnethicalCompany", actor, 10f);
				}
			}
			MyCompany.ChangeBusinessRep(-0.5f, "TaxFraud");
			NotificationManager.AddNotification(new DismissableIssue("TaxCaughtMessage".Loc(), "Exclamation"));
			Newspaper.Instance.AddNewStory(SDateTime.Now(), new Newspaper.Story("TaxCaughtNewsTitle".Loc(MyCompany), "TaxCaughtNewsDesc".Loc(MyCompany, text), Newspaper.Section.Industry, null, float.PositiveInfinity), true);
			ApplicantScore.TaxFraud = 1f;
			return true;
		}
		return false;
	}

	public float GetTaxeRate()
	{
		return Mathf.Round(DifficultyValues.Difficulty.Taxes * Environment.AddedTax * 100f) / 100f;
	}

	public void DispatchConfiscator(Furniture f)
	{
		Confiscator c = UnityEngine.Object.Instantiate(ConfiscatorPrefab);
		f.FireProtection = true;
		c.Target = f;
		c.Init();
		if (Confiscators.Count == 1)
		{
			WindowManager.Instance.ShowMessageBox("PoliceDroneWarning".Loc(), true, DialogWindow.DialogType.Warning, new KeyValuePair<string, Action>("Follow", delegate
			{
				CameraScript.Instance.Follow = c.transform;
				GameSpeed = 1f;
			}), new KeyValuePair<string, Action>("Ignore", delegate
			{
			}));
		}
		AchievementController.SetAchievement("POLICEDRONE");
	}

	private void InitGrassTrot()
	{
		GrassTrotResetMat = new Material(GrassTrotResetMat);
		CreateGrassTrotTexture();
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = GrassTrot;
		GL.Clear(false, true, Color.white);
		RenderTexture.active = active;
	}

	private void DestroyGrassTrot()
	{
		UnityEngine.Object.Destroy(GrassTrot);
		if (_tempGrassTex != null)
		{
			UnityEngine.Object.Destroy(_tempGrassTex);
		}
	}

	private void CreateGrassTrotTexture()
	{
		GrassTrot = new RenderTexture(TrotSize, TrotSize, 0, RenderTextureFormat.RFloat);
		TimeOfDay.Instance.GroundMat.mainTexture = GrassTrot;
		GrassTrotCam.targetTexture = GrassTrot;
		TimeOfDay.Instance.NoiseGrassMaterial.SetTexture("_Trot", GrassTrot);
	}

	private void UpdateGrassTrot()
	{
		if (!SelectorController.Instance.DoneLoading)
		{
			return;
		}
		if (Options.DynamicPaths != _dynamicPaths)
		{
			_dynamicPaths = Options.DynamicPaths;
			TimeOfDay.Instance.GroundMat.mainTexture = (_dynamicPaths ? GrassTrot : null);
		}
		if (!_dynamicPaths)
		{
			return;
		}
		bool flag = false;
		if (GrassTrot == null)
		{
			CreateGrassTrotTexture();
			flag = true;
		}
		if (!GrassTrot.IsCreated())
		{
			GrassTrot.Create();
			flag = true;
		}
		if (flag)
		{
			bool flag2 = true;
			if (_lastGrassFetch != null)
			{
				try
				{
					Texture2D texture2D = new Texture2D(TrotSize, TrotSize, TextureFormat.RFloat, false);
					texture2D.SetPixels(_lastGrassFetch.Select((byte x) => new Color((float)(int)x / 255f, 1f, 1f, 1f)).ToArray());
					texture2D.Apply();
					Graphics.CopyTexture(texture2D, GrassTrot);
					flag2 = false;
					UnityEngine.Object.Destroy(texture2D);
				}
				catch (Exception)
				{
				}
			}
			if (flag2)
			{
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = GrassTrot;
				GL.Clear(false, true, Color.white);
				RenderTexture.active = active;
			}
		}
		_grassTrotTime += Time.deltaTime * GameSpeed;
		if (!(_grassTrotTime > GrassTrotUpdate))
		{
			return;
		}
		SDateTime sDateTime = SDateTime.Now();
		float months = SDateTime.GetMonths(_lastUpdate, sDateTime);
		_grassTrotTime = 0f;
		Camera.SetupCurrent(GrassTrotCam);
		RenderTexture active2 = RenderTexture.active;
		RenderTexture.active = GrassTrot;
		GL.PushMatrix();
		GL.LoadProjectionMatrix(GL.GetGPUProjectionMatrix(GrassTrotCam.projectionMatrix, false));
		GL.LoadIdentity();
		GL.modelview = GrassTrotCam.worldToCameraMatrix;
		GrassTrotResetMat.mainTexture = GrassTrot;
		GrassTrotResetMat.SetFloat("_GrowRate", months / 12f);
		if (GrassTrotResetMat.SetPass(0))
		{
			Graphics.DrawMeshNow(GrassTrotQuad, Matrix4x4.TRS(new Vector3(128f, 0f, 128f), Quaternion.identity, new Vector3(256f, 1f, 256f)));
			if (GrassTrotMat.SetPass(0))
			{
				for (int num = 0; num < sRoomManager.Outside.Occupants.Count; num++)
				{
					Actor actor = sRoomManager.Outside.Occupants[num];
					Vector3 actualPosition = actor.ActualPosition;
					if (actualPosition.y < 0.1f)
					{
						Vector3 vector = actualPosition - actor.LastWorldPos;
						if ((double)vector.sqrMagnitude > 1E-06)
						{
							Graphics.DrawMeshNow(GrassTrotQuad, Matrix4x4.TRS((actualPosition + actor.LastWorldPos) * 0.5f, Quaternion.Euler(0f, Mathf.Atan2(vector.x, vector.z) * 57.29578f, 0f), new Vector3(3f, 1f, vector.magnitude + 3f)));
						}
					}
					actor.LastWorldPos = actualPosition;
				}
			}
			else
			{
				Debug.LogError("Failed setting Grass Path material");
				Options.DynamicPaths = false;
			}
		}
		else
		{
			Debug.LogError("Failed setting Grass Path Reset material");
			Options.DynamicPaths = false;
		}
		GL.PopMatrix();
		RenderTexture.active = active2;
		_lastUpdate = sDateTime;
	}

	public bool CanUseBuildMode()
	{
		if (ForceTimeType == 0)
		{
			if (CampaignMode && !EditMode)
			{
				return CompletedMissions.Contains("Mission001");
			}
			return true;
		}
		return false;
	}

	public void TransmitExtraWorth()
	{
		if (NetworkManager.IsConnected)
		{
			NetworkMessaging.SendExtraWorth(MyCompany.ID, MyCompany.GetPlayerExtraWorth(), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
	}

	public void AddBuyout(Company c, Company buyer)
	{
		if (NetworkManager.IsConnected && NetworkManager.Instance.Players.Count > 0 && !PreSimActive)
		{
			_buyouts.Add(new ValueTuple<uint, uint>(c.ID, (buyer != null) ? buyer.ID : 0u));
		}
	}

	public void ClearBuyouts()
	{
		for (int i = 0; i < _buyouts.Count; i++)
		{
			ValueTuple<uint, uint> valueTuple = _buyouts[i];
			NetworkMessaging.SendBuyOut(valueTuple.Item1, valueTuple.Item2, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		_buyouts.Clear();
	}

	public uint GetLocalNetworkID()
	{
		uint nextLocalNetworkID = _nextLocalNetworkID;
		_nextLocalNetworkID++;
		return nextLocalNetworkID;
	}

	public void ResetComputerPower()
	{
		_computerPower.Clear();
	}

	public float GetComputerPower(int modelYear, float modifier)
	{
		float value;
		if (!_computerPower.TryGetValue(modelYear, out value))
		{
			SDateTime sDateTime = SDateTime.Now();
			value = ((sDateTime.RealYear < modelYear) ? 1f : Mathf.Pow(0.95f, Mathf.Max(0f, sDateTime.ToFloat() + 1900f - (float)modelYear)));
			_computerPower[modelYear] = value;
		}
		return value * modifier;
	}

	public void CalculatePlotNeighbors()
	{
		List<PlotArea> list = GetPlots().ToList();
		for (int i = 0; i < list.Count; i++)
		{
			list[i].CalculateNeighbors(list, EnvType);
		}
	}

	public bool CanReachPlot(PlotArea p)
	{
		for (int i = 0; i < PlayerPlots.Count; i++)
		{
			PlotArea plotArea = PlayerPlots[i];
			if (plotArea.Neighbors == null)
			{
				CalculatePlotNeighbors();
			}
			if (plotArea.Neighbors.Contains(p.ID))
			{
				return true;
			}
		}
		return false;
	}

	public void FixReferences()
	{
		ServerGroups.Values.ForEachEnum(delegate(ServerGroup x)
		{
			x.FixReferences();
		});
		DictionaryList<IStockable, PrintJob> dictionaryList = new DictionaryList<IStockable, PrintJob>();
		lock (PrintOrders)
		{
			foreach (PrintJob item in PrintOrders.Values.ToList())
			{
				PrintJob printJob;
				if ((printJob = item.FixReferences() as PrintJob) != null)
				{
					dictionaryList[printJob.Target] = printJob;
				}
			}
			PrintOrders = dictionaryList;
		}
		lock (_printsInStorage)
		{
			_printsInStorage = _printsInStorage.FixKeyReferences(true);
		}
		lock (_assemblyLines)
		{
			_assemblyLines.FixMyReferences(false);
		}
		for (int num = 0; num < NetworkPrintOrders.List.Count; num++)
		{
			if (NetworkPrintOrders.List[num].FixReferences() == null)
			{
				num--;
			}
		}
		NetworkPrintOrders.FixValueReferences(true);
	}

	public void RemovePlayerFromCloudService(byte player)
	{
		ServerGroup cloud = GetCloud();
		NetworkServerItem networkServerItem = ((cloud != null) ? cloud.GetItemFor(player) : null);
		if (networkServerItem != null)
		{
			RegisterWithServer(null, networkServerItem);
		}
	}

	public bool CanOutsourcePrint(IManufacturable man)
	{
		if (!IsNetworkMode)
		{
			return false;
		}
		foreach (Company playerCompany in simulation.GetPlayerCompanies())
		{
			if (!playerCompany.LocalPlayer)
			{
				if (!man.IsHardware() && playerCompany.SoftwarePrintMarkup.HasValue)
				{
					return true;
				}
				if (man.IsHardware() && playerCompany.HardwarePrintMarkup.ContainsKey(man))
				{
					return true;
				}
			}
		}
		return false;
	}

	public IEnumerable<Company> GetOutsourcePrint(IManufacturable man)
	{
		foreach (Company pl in simulation.GetPlayerCompanies())
		{
			if (!pl.LocalPlayer)
			{
				if (!man.IsHardware() && pl.SoftwarePrintMarkup.HasValue)
				{
					yield return pl;
				}
				if (man.IsHardware() && pl.HardwarePrintMarkup.ContainsKey(man))
				{
					yield return pl;
				}
			}
		}
	}

	public void RenameRoomGroup(RoomGroup group)
	{
		WindowManager.SpawnInputDialog("Roomgroups".Loc(), "NewRoomGroupPrompt".Loc(), group.Name, delegate(string newName)
		{
			if (!RoomGroups.ContainsKey(newName))
			{
				string text = group.Name;
				RoomGroups.Remove(text);
				group.Name = newName;
				RoomGroups[newName] = group;
				foreach (Room room in group.GetRooms())
				{
					room.RoomGroup = newName;
				}
				{
					foreach (Actor item in sActorManager.Staff)
					{
						if (item.AssignedRoomGroups.Remove(text))
						{
							item.AssignedRoomGroups.Add(newName);
						}
					}
					return;
				}
			}
			WindowManager.Instance.ShowMessageBox("RoomGroupNameError".Loc(), true, DialogWindow.DialogType.Error);
		});
	}

	public void RestartCompany(double money)
	{
		HashSet<Employee> holders = (from x in MyCompany.NewStock.Select((NewStock x) => x.Buyer).OfType<FounderShareHolder>()
			select x.Founder).ToHashSet();
		Actor actor = sActorManager.Actors.FirstOrDefault((Actor x) => x.employee.Founder && !holders.Contains(x.employee));
		if (actor != null)
		{
			bool flag = false;
			SaveGame saveGame = null;
			if (!RentMode && sRoomManager.Rooms.Count > 0)
			{
				saveGame = SaveGameManager.Instance.BuildingSave();
				flag = true;
			}
			if (flag && saveGame == null)
			{
				SaveGameManager.Instance.HideWaitPanel();
				return;
			}
			foreach (Actor actor2 in sActorManager.Actors)
			{
				if (actor2 != actor)
				{
					Employee employee = actor2.employee;
					if (!employee.Retired && (employee.MyEmployer == null || employee.MyEmployer == MyCompany) && employee.CreativityKnown >= 1f && employee.Creativity >= 0.85f)
					{
						employee.Dismiss(true);
						employee.MyEmployer = null;
						employee.PlayerQuarantine = null;
						MarketSimulation.Active.FreeLeads.Add(employee);
					}
				}
			}
			GameData.CompanyDate = SDateTime.Now();
			GameData.ActiveYear = GameData.CompanyDate.Year;
			GameData.DaysPerMonth = DaysPerMonth;
			GameData.RestartEvents = MyCompany.MarketEvents.ToList();
			GameData.RestartCompletedMissions = CompletedMissions.ToHashSet();
			GameData.RestartActiveMissions = CurrentMissions.ToHashSet();
			int num = GameData.RestartEvents.FindIndex((MarketEvent x) => x.Type == MarketEvent.EventType.Founded && x.Subjects != null && x.Subjects.Length != 0 && x.Subjects[0] == MyCompany.ID);
			if (num >= 0)
			{
				GameData.RestartEvents[num] = new MarketEvent(MarketEvent.EventType.Founded, GameData.RestartEvents[num].Date, MyCompany.Name);
			}
			GameData.RestartCompanyID = simulation.GetCompanyID();
			GameData.RestartCompany = true;
			GameData.LoadCompanyOnLoad = true;
			GameData.RestartCompanyFunds = money;
			GameData.RestartCompanyPersonalities = Personalities;
			GameData.RestartCompanySpecs = GetAllUnlockedSpecializations();
			GameData.CompanyData = GameReader.CreateDictionaryData(GameReader.NewLoadMode.Company, Writeable.LoadType.NetworkHost, 0);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.WriteObject(actor.employee);
				GameData.RestartCompanyFounder = memoryStream.ToArray();
			}
			UnloadNow();
			ErrorLogging.FirstOfScene = true;
			ErrorLogging.SceneChanging = true;
			DevConsole.Console.SaveConsole();
			SceneManager.LoadScene("Customization");
			FrameTransition.StartTransition(true);
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("RestartCompanyFounderError".Loc(), true, DialogWindow.DialogType.Error);
		}
	}

	public void AddToFireCounter()
	{
		if (FireCounter == 0)
		{
			InsuranceIncidentPossible = true;
		}
		FireCounter++;
	}

	public void InsuranceIncident()
	{
		if (InsuranceIncidentPossible)
		{
			Insurance.RecordInsuranceIncident();
			InsuranceIncidentPossible = false;
		}
	}

	public Dictionary<string, float> GetBenefits()
	{
		return CompanyBenefits;
	}

	public float GetBenefitValue(string benefit, bool ignoreSelf = false)
	{
		if (!ignoreSelf)
		{
			return EmployeeBenefit.GetBenefitValue(null, null, benefit);
		}
		return EmployeeBenefit.Benefits[benefit].Default;
	}

	public void CacheBenefits()
	{
		sActorManager.Actors.ForEach(delegate(Actor x)
		{
			x.CacheBenefits();
		});
	}

	public void ApplyNewBenefits()
	{
		sActorManager.Actors.ForEach(delegate(Actor x)
		{
			x.ApplyNewBenefits();
		});
	}

	public void PostChangeDifficulty()
	{
		if (!(Difficulty.Burglaries < 0.5f))
		{
			return;
		}
		foreach (Actor item in sActorManager.Others["Burglars"].ToList())
		{
			if (!item.isActiveAndEnabled)
			{
				item.DestroyGO();
			}
		}
	}
}
