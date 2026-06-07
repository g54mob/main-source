using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Achievements;
using DG.Tweening;
using SINetworking;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class HUD : MonoBehaviour
{
	private struct CategoryKey
	{
		public readonly int BuildType;

		public readonly string Category;

		public readonly int Function;

		public CategoryKey(BuildDescriptor.BuildType buildType, string category, BuildDescriptor.CategoryType function)
		{
			BuildType = (int)buildType;
			Category = category;
			Function = (int)function;
		}

		public bool Match(BuildDescriptor.BuildType buildType, BuildDescriptor.CategoryType function)
		{
			if (buildType == (BuildDescriptor.BuildType)BuildType)
			{
				return function == (BuildDescriptor.CategoryType)Function;
			}
			return false;
		}

		public bool Equals(CategoryKey other)
		{
			if (BuildType == other.BuildType && string.Equals(Category, other.Category))
			{
				return Function == other.Function;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is CategoryKey)
			{
				return Equals((CategoryKey)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((BuildType * 397) ^ ((Category != null) ? Category.GetHashCode() : 0)) * 397) ^ Function;
		}
	}

	public Camera MainCamera;

	public static HUD Instance;

	public Sprite MissingSprite;

	public Sprite BuildModeOn;

	public Sprite BuildModeOff;

	public Image BuildModeButtonIcon;

	public OverlayWarning WarningOverlay;

	public GameObject[] TopPanels;

	public GameObject BuildPlane;

	public GameObject BuildModePanel;

	public GameObject RoomHelpAnim;

	public GameObject RoomObject;

	public GameObject FlatPlane;

	public GameObject RoomWall;

	public GameObject roomCorner;

	public GameObject RoomDarkness;

	public GameObject ClearSearchButton;

	public GameObject[] HideInBuild;

	public RectTransform MainBottomButtonPanel;

	public RectTransform[] DefaultBottomPanels;

	public GameObject BottomPanelPrefab;

	public GameObject NetworkSyncPanel;

	public GameObject NetworkNudgePanel;

	public GameObject VoteToSkip;

	public Text NetworkSyncLabel;

	public Text NetworkNudgeLabel;

	public MainBottomButton BottomButtonPrefab;

	public ButtonCounter ButtonCounterPrefab;

	public List<ButtonCounter> ButtonCounters;

	public Image BuildModePanelImage;

	public Image BuildModeIcon;

	public GameObject BottomDealButton;

	public GameObject BottomContractButton;

	public GameObject BottomLoanButton;

	public IconFillBar ReputationBar;

	public Scrollbar BuildMenuScroll;

	public Slider SunSlider;

	private float lastRep;

	public RectTransform MainWorkItemPanel;

	public RectTransform WorkItemPanel;

	public RectTransform WorkItemDrag;

	[NonSerialized]
	public List<MainBottomButton> BottomButtons = new List<MainBottomButton>();

	[NonSerialized]
	public GUIWorkItem DraggingWork;

	public GameObject CategoryPanel;

	public GameObject BuildButtonPanel;

	public GameObject BuyButtonPrefab;

	public GameObject TogglePrefab;

	public GameObject workItemTogglePanel;

	public GameObject BuildModeMainButtonPanel;

	public GameObject GroupItemTogglePanel;

	public GameObject FurnitureNewIcon;

	public GameObject[] BuildModeMainButtons;

	public Image[] BuildModeMainButtonImages;

	public GameObject[] WorkItemPrefab;

	public BuilderDetailPanel BuildDetailPanel;

	public InputField SearchBar;

	public BlurOptimized BlurScript;

	public ColorCorrectionLookup ColorScript;

	public ParticleSystem SmokeSystem;

	public ParticleSystem SmellSystem;

	public Sprite RoomThumbnail;

	public Sprite RectRoomThumbnail;

	public Sprite CurveWallThumbnail;

	public Sprite DragWallThumbnail;

	public Sprite RemoveWallThumbnail;

	public Sprite PillarToggleThumnail;

	public Sprite FenceThumbnail;

	public Sprite RectFenceThumbnail;

	public Sprite RoadThumbnail;

	public Sprite NoRoadThumbnail;

	public Sprite ParkHorThumbnail;

	public Sprite ParkVertThumbnail;

	public Sprite BikeHorThumb;

	public Sprite BikeVertThumb;

	public Sprite HouseThumbnail;

	public Sprite TreeThumbnail;

	public Sprite LakeThumbnail;

	public Sprite SkyscraperThumbnail;

	public Sprite RampThumbnail;

	public Sprite PathThumbnail;

	public Sprite SmoothPathThumbnail;

	public Sprite NoPathThumbnail;

	public Sprite FavoriteIcon;

	public Sprite AtriumThumbnail;

	public Toggle[] SpeedToggles;

	public Sprite[] lowerWallImages;

	public Image LowerWallImage;

	public Image FireBuildStop;

	public Image ThiefBuildStop;

	public Image ConfiscationBuildStop;

	public Toggle DataOverlayToggle;

	public Toggle HideLampsToggle;

	public Toggle WireModeToggle;

	public Toggle AudioOverlayToggle;

	public Toggle RoomLabelToggle;

	public Toggle[] DataToggles;

	public Button SkipButton;

	public Button ActualBuildButton;

	public RectTransform SkipButtonRect;

	public RectTransform ToggleBuildModeButton;

	private Dictionary<CategoryKey, Toggle> BuildCategories = new Dictionary<CategoryKey, Toggle>();

	private List<BuildButton> BuildButtons = new List<BuildButton>();

	private List<BuildButton> AwardButtons = new List<BuildButton>();

	private Dictionary<WallSnap, BuildButton> FurnButtons = new Dictionary<WallSnap, BuildButton>();

	private Vector3 sPoint;

	[NonSerialized]
	private List<PathVector> _path;

	public bool FinishPath;

	private bool AllWorkTogglesOff = true;

	public GUIStyle ProgressBack;

	public GUIStyle ProgressFront;

	public GUIBarChart CashflowChart;

	public ReputationBars mainReputataionBars;

	public DropDownPanel[] dropDownPanels;

	public Text MoneyLabel;

	public Text TimeLabel;

	public Text DateLabel;

	public Text PopularityLabel;

	public Text BuildMoneyLabel;

	public Text DayLabel;

	public Text BuildModeTypeText;

	public Text FanLabel;

	public Text GameEndCountdown;

	public RawImage MoneyLabelBack;

	public RectTransform ClockArm;

	public HintFocusPanel HintPanel;

	public GameObject BankruptcyWarning;

	public GameObject ServerProcessWarning;

	public MainBottomButton ServerImageButton;

	public MainBottomButton ComplaintButton;

	public BuildShortcutPanel ShortcutPanel;

	public GlobalSearchPanel SearchPanel;

	public DesignDocumentWindow docWindow;

	[SerializeField]
	private ProductWindow productWindow;

	public RoofEditWindow roofEditWindow;

	public DistDealNegWindow distDealNegWindow;

	public TexturePickerWindow textureWindow;

	public BenefitWindow benefitWindow;

	public MarketingWindow marketingWindow;

	public RoleSelectWindow roleSelect;

	public ContractWindow contractWindow;

	public ResearchWindow researchWindow;

	public PauseWindow pauseWindow;

	public LookHireWindow hireWindow;

	public CompanyWorksheet financeWindow;

	public StaffWindow staffWindow;

	public TeamWindow TeamWindow;

	public TeamSelectWindow TeamSelectWindow;

	public EducationWindow educationWindow;

	public EmployeeWindow employeeWindow;

	public AutoDevWindow AutoDevWindow;

	public LoanWindow loanWindow;

	public ReviewWindow reviewWindow;

	public EventWindow eventWindow;

	public InsuranceWindow insuranceWindow;

	public ComingReleaseWindow comingReleaseWindow;

	public DetailWindow DetailWindow;

	public RoleGrid roleGrid;

	public WageWindow wageWindow;

	public ComplaintWindow complaintWindow;

	public DistributionWindow distributionWindow;

	public DigitalDistributionWindow digitalDistributionWindow;

	public ServerWindow serverWindow;

	public CopyOrderWindow copyOrderWindow;

	public DealWindow dealWindow;

	public Newspaper newspaper;

	public RoomGroupWindow roomGroupWindow;

	public BlueprintWindow blueprint;

	public DateRangeWindow dateRangeWindow;

	public NumberRangeWindow numberRangeWindow;

	public StartReviewWindow startReviewWindow;

	public FinalReviewWindow finalReviewWindow;

	public ProductWindow PlayerProductWindow;

	public AutomationLog AutoLog;

	public ManufacturingPanel ManufacturingWindow;

	public ManufacturingPanel ManufacturingSelectWindow;

	public GUIWindow RewardTaskWindow;

	public RewardWindow rewardWindow;

	public AssemblyLineWindow assemblyLineWindow;

	public CalendarWindow calendarWindow;

	public MarketAnalysisWindow marketAnalysisWindow;

	public CompetitionAnalysis compAnalysisWindow;

	public AddonDesignWindow addonDesignWindow;

	public HardwareEditorWindow hardwareEditorWindow;

	public UpdateWindow updateWindow;

	public LeadDesignWindow leadDesignWindow;

	public TraitFilterWindow traitFilterWindow;

	public WorkerDetailWindow workerDetailWindow;

	public AssemblerDetailWindow AssemblerWindow;

	public SpecializationWindow SpecializationWindow;

	public AccountingWindow accountingWindow;

	public LogoEditorWindow logoWindow;

	public LogoManagerWindow logoManagerWindow;

	public AwardWindow awardWindow;

	public EventTimeLine TimeLineWindow;

	public ExclusivityDealWindow ExclusivityWindow;

	public NetworkDealWindow networkDealWindow;

	public NewUnlockWindow newUnlockWindow;

	public ViewControlTutorial ControlTutorial;

	public FloorDrawer floorDrawer;

	public Texture2D ColorMap;

	public Texture2D LightMap;

	public Texture2D TopBar;

	public ParticleSystem EffectivenessEmitter;

	public ParticleSystem DirtEmitter;

	public ParticleSystem ZnoreEmitter;

	public PopupManager popupManager;

	public PortraitMaker Portraits;

	public RectTransform Compass;

	public WorkGroupManager GroupTaskManager;

	public Text IdleCounter;

	public bool SeeThroughWalls;

	private static Color[][] _posNeg = new Color[4][]
	{
		new Color[2]
		{
			new Color32(51, 204, 51, byte.MaxValue),
			new Color32(239, 60, 57, byte.MaxValue)
		},
		new Color[2]
		{
			new Color32(2, 85, 253, byte.MaxValue),
			new Color32(152, 138, 3, byte.MaxValue)
		},
		new Color[2]
		{
			new Color32(0, 80, byte.MaxValue, byte.MaxValue),
			new Color32(109, 100, 23, byte.MaxValue)
		},
		new Color[2]
		{
			new Color32(17, 164, 197, byte.MaxValue),
			new Color32(215, 70, 113, byte.MaxValue)
		}
	};

	[NonSerialized]
	private int _dirtyButtonVis = 2;

	private static Color[][] _themeColors = new Color[4][]
	{
		new Color[8]
		{
			new Color32(126, 207, 112, byte.MaxValue),
			new Color32(95, 122, 155, byte.MaxValue),
			new Color32(220, 108, 130, byte.MaxValue),
			new Color32(236, 157, 112, byte.MaxValue),
			new Color32(126, 95, 160, byte.MaxValue),
			new Color32(90, 203, 207, byte.MaxValue),
			new Color32(216, 194, 89, byte.MaxValue),
			new Color32(199, 40, 40, byte.MaxValue)
		},
		new Color[8]
		{
			new Color32(171, 160, 55, byte.MaxValue),
			new Color32(2, 85, 253, byte.MaxValue),
			new Color32(111, 130, 206, byte.MaxValue),
			new Color32(196, 180, 0, byte.MaxValue),
			new Color32(17, 82, 172, byte.MaxValue),
			new Color32(152, 138, 3, byte.MaxValue),
			new Color32(byte.MaxValue, 248, 57, byte.MaxValue),
			new Color32(98, 91, 73, byte.MaxValue)
		},
		new Color[8]
		{
			new Color32(185, 170, 53, byte.MaxValue),
			new Color32(0, 80, byte.MaxValue, byte.MaxValue),
			new Color32(121, 139, 211, byte.MaxValue),
			new Color32(181, 166, 3, byte.MaxValue),
			new Color32(2, 53, 178, byte.MaxValue),
			new Color32(109, 100, 23, byte.MaxValue),
			new Color32(254, 251, 52, byte.MaxValue),
			new Color32(63, 67, 78, byte.MaxValue)
		},
		new Color[8]
		{
			new Color32(97, 210, 250, byte.MaxValue),
			new Color32(251, 170, 189, byte.MaxValue),
			new Color32(251, 38, 104, byte.MaxValue),
			new Color32(17, 164, 197, byte.MaxValue),
			new Color32(181, 95, 122, byte.MaxValue),
			new Color32(58, 186, 225, byte.MaxValue),
			new Color32(252, 227, 233, byte.MaxValue),
			new Color32(215, 70, 113, byte.MaxValue)
		}
	};

	private static Color[] _accentColor = new Color[4]
	{
		new Color32(126, 240, 112, byte.MaxValue),
		new Color32(240, 240, 0, byte.MaxValue),
		new Color32(240, 240, 0, byte.MaxValue),
		new Color32(97, byte.MaxValue, byte.MaxValue, byte.MaxValue)
	};

	private static Color[] _warningColor = new Color[4]
	{
		new Color32(byte.MaxValue, 92, 92, byte.MaxValue),
		new Color32(92, 92, byte.MaxValue, byte.MaxValue),
		new Color32(92, 92, byte.MaxValue, byte.MaxValue),
		new Color32(240, 38, 104, byte.MaxValue)
	};

	public Material LineMat;

	public CompanyWindow companyWindow;

	public CompanyChart companyChart;

	public GameObject PlotHolder;

	public List<Furniture> AllFurniture;

	private bool buildMode;

	public RectTransform BuildPanel;

	public RectTransform BuildHelperPanel;

	public RectTransform MainContentPanel;

	public RectTransform TemperatureProg;

	public RectTransform TemperatureHolder;

	public Image[] TemperatureColor;

	public GUIToolTipper TemperatureTip;

	private static float[] speeds = new float[4] { 0f, 1f, 10f, 30f };

	public Texture2D[] PlayButtons;

	public Scrollbar WorkItemScroll;

	public Scrollbar BuildScrollBar;

	public GameObject FurnitureCategoryPanel;

	public bool disableSpeedPanel;

	private int BeforePause = 1;

	public Texture2D ErrorIcon;

	public GUIStyle ErrorBox;

	public Canvas[] UICanvases;

	public GameObject UICamera;

	public Toggle[] WorkItemToggles;

	public Toggle SelectionFilterToggle;

	public Toggle InHouseFilterToggle;

	public Toggle DealFilterToggle;

	public Toggle ContractFilterToggle;

	public Toggle MultiplayerToggle;

	public Image ToggleBack;

	public TemperaturePanel TempPanel;

	public string[] WorkItemNames;

	[NonSerialized]
	public Dictionary<string, Toggle> WorkToToggle;

	[NonSerialized]
	public HashSet<Room> InaccessibleRoom = new HashSet<Room>();

	[NonSerialized]
	public HashSet<Furniture> UnreachableFuniture = new HashSet<Furniture>();

	[NonSerialized]
	public HashSet<Furniture> NoInputTemp = new HashSet<Furniture>();

	[NonSerialized]
	public HashSet<Furniture> NoChairPC = new HashSet<Furniture>();

	[NonSerialized]
	public HashSet<Furniture> NotAllowedInRoom = new HashSet<Furniture>();

	[NonSerialized]
	public HashSet<Furniture> CCTVNoConnection = new HashSet<Furniture>();

	[NonSerialized]
	public HashSet<ProductPallet> FetchBlocked = new HashSet<ProductPallet>();

	[NonSerialized]
	public HashSet<Conveyor> ConveyorNoOutput = new HashSet<Conveyor>();

	[NonSerialized]
	public HashSet<Conveyor> ConveyorBlocked = new HashSet<Conveyor>();

	[NonSerialized]
	public HashSet<ProductPrinter> PrinterBlocked = new HashSet<ProductPrinter>();

	[NonSerialized]
	public bool BlockChanged;

	[NonSerialized]
	public HashSet<IRoomConnector> BlockedDoorways = new HashSet<IRoomConnector>();

	[NonSerialized]
	public HashSet<RoadNode> UnreachableParking = new HashSet<RoadNode>();

	[NonSerialized]
	public HashSet<Actor> CantGetHome = new HashSet<Actor>();

	[NonSerialized]
	private List<GUIWindow> _disabledWindows;

	[NonSerialized]
	private List<GUIWindow> _disabledWindowsHUDHide;

	public static int HUDSpeed = 1;

	public GUIRewardTask TaskPrefab;

	public GameObject TaskPanelPrefab;

	public GameObject DependsArrow;

	public Transform TaskPanel;

	public Dictionary<string, RectTransform> BottomPanels = new Dictionary<string, RectTransform>();

	[NonSerialized]
	private float _saveInterval;

	[NonSerialized]
	private bool _disableWorkToggleRefresh;

	private AudioSource Aud;

	[NonSerialized]
	private HashSet<Actor> _idleEmployees = new HashSet<Actor>();

	public BuildDescriptor.BuildType LastType;

	public BuildDescriptor.CategoryType LastCatType;

	private bool disableSearch;

	private bool _lastBlur;

	private float _blurStamp;

	public float BlurSpeed = 2f;

	public Transform RoadDummy;

	[NonSerialized]
	private StringBuilder _networkStatus = new StringBuilder();

	[NonSerialized]
	private float _lastScreenWidth;

	private float _inaccessibleRoomTimer;

	private bool _inaccessibleRoomTry;

	private static bool _isReporting = false;

	public static bool DrawSpeed = true;

	[NonSerialized]
	public bool AvoidInitialSkip = true;

	public GameObject AutoProjectDetailWindow;

	[NonSerialized]
	private Dictionary<string, ProductWindow> _pWindows = new Dictionary<string, ProductWindow>();

	public int GameSpeed
	{
		get
		{
			return HUDSpeed;
		}
		set
		{
			if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.EditMode)
			{
				value = 0;
			}
			if (value <= -1 || value >= speeds.Length)
			{
				return;
			}
			if (value > 0 && BuildMode)
			{
				BuildMode = false;
			}
			if (GameSettings.GameSpeed != speeds[value] && !GameSettings.ForcePause)
			{
				switch (value)
				{
				case 0:
					UISoundFX.PlaySFX("Pause");
					break;
				case 1:
					UISoundFX.PlaySFX("NormalSpeed");
					break;
				case 2:
					UISoundFX.PlaySFX("FastSpeed");
					break;
				case 3:
					UISoundFX.PlaySFX("FasterSpeed");
					break;
				}
			}
			GameSettings.GameSpeed = speeds[value];
		}
	}

	public bool BuildMode
	{
		get
		{
			return buildMode;
		}
		set
		{
			if (WindowManager.HasModal)
			{
				return;
			}
			AudioVisualizer.NoiseDirty = true;
			if (!GameSettings.Instance.IsReferenceNull())
			{
				if (GameSettings.Instance.HasDanger() || !GameSettings.Instance.CanUseBuildMode())
				{
					if (!BuildMode)
					{
						return;
					}
					value = false;
				}
				if (GameSettings.Instance.EditMode)
				{
					if (BuildMode)
					{
						return;
					}
					value = true;
				}
			}
			if (buildMode != value)
			{
				if (value)
				{
					UISoundFX.ChangeMusicState("BuildMode");
					UISoundFX.PlaySFX("BuildModeEnter");
					BuildController.Instance.RefreshRestoreButton();
				}
				else
				{
					UISoundFX.ChangeMusicState("MainScene");
					UISoundFX.ChangeMusicState((new string[4] { "Spring", "Summer", "Autumn", "Winter" })[TimeOfDay.Instance.Month / 3]);
					UISoundFX.PlaySFX("BuildModeExit");
				}
				GameSettings.ForcePause = value;
				_saveInterval = Options.BuildModeSaveInterval;
			}
			BuildModeButtonIcon.sprite = (value ? BuildModeOff : BuildModeOn);
			bool flag = (floorDrawer.enabled = value);
			buildMode = flag;
			TimeOfDay.SyncPlayerTime();
			MaterialPreviewer.Instance.RefreshState();
			UpdateServerWarning();
			if (!GameSettings.Instance.IsReferenceNull())
			{
				GameSettings.Instance.UpdateGridVisibility();
				if (buildMode)
				{
					BuildModeMainButtons[3].SetActive(GameSettings.Instance.EditMode);
					BuildModeMainButtons[4].SetActive(!GameSettings.Instance.EditMode && !GameSettings.Instance.RentMode);
					BuildModeMainButtons[5].SetActive(GameSettings.Instance.EditMode || !GameSettings.Instance.RentMode);
					BuildModeMainButtons[6].SetActive(GameSettings.Instance.EditMode || !GameSettings.Instance.RentMode);
					BuildModeMainButtons[7].SetActive(GameSettings.Instance.EditMode || !GameSettings.Instance.RentMode);
				}
				bool flag3 = true;
				Image image = null;
				for (int i = 0; i < BuildModeMainButtonImages.Length; i++)
				{
					Image image2 = BuildModeMainButtonImages[i];
					if (image2.gameObject.activeSelf)
					{
						if (flag3)
						{
							flag3 = false;
							image2.sprite = ObjectDatabase.Instance.GetSprite(false, false, true, true);
							image2.type = Image.Type.Sliced;
						}
						else
						{
							image2.sprite = null;
							image = image2;
						}
					}
				}
				if (image != null)
				{
					image.sprite = ObjectDatabase.Instance.GetSprite(true, true, false, false);
					image.type = Image.Type.Sliced;
				}
				if (!GameSettings.Instance.EditMode && GameSettings.Instance.RentMode)
				{
					SetBuildType(1);
				}
				GameSettings.Instance.UndoButton.SetActive(buildMode && GameSettings.Instance.UndoCount > 0);
				PlotHolder.SetActive(value);
			}
			if (AudioVisualizer.Instance != null)
			{
				AudioVisualizer.Instance.ForceRedraw();
			}
			MainWorkItemPanel.gameObject.SetActive(!value);
			for (int j = 0; j < HideInBuild.Length; j++)
			{
				HideInBuild[j].SetActive(!value);
			}
			for (int k = 0; k < ButtonCounters.Count; k++)
			{
				ButtonCounters[k].UpdateActive();
			}
			UpdateBorderOverlay();
			NotificationManager.Instance.UpdateY();
			for (int l = 0; l < TopPanels.Length; l++)
			{
				TopPanels[l].SetActive(!value);
			}
			DayLabel.transform.parent.gameObject.SetActive(!value && GameSettings.DaysPerMonth > 1);
			if (value)
			{
				CloseDropDownPanels();
				newspaper.ShowNow(false);
				SpecializationProgress.Instance.Hide();
				_disabledWindows = WindowManager.DisableAll(false, true);
				StartBuildModTut(false);
				SDateTime sDateTime = SDateTime.Now();
				float num = sDateTime.Hour;
				int num2 = sDateTime.Minute;
				if (num >= 14f)
				{
					num = 14f - (num - 14f) * 1.4f;
					num2 = -num2;
				}
				float value2 = (num + (float)num2 / 60f) / 14f;
				SunSlider.value = value2;
				UpdateBuildButtonVis(false);
			}
			else
			{
				WindowManager.EnableAll(_disabledWindows);
				if (_disabledWindows != null)
				{
					_disabledWindows.Clear();
				}
				BuildController.Instance.ClearBuild();
				if (CameraScript.Instance != null)
				{
					CameraScript.Instance.TopDown = false;
				}
			}
		}
	}

	public static Color GetPosNeg(bool pos)
	{
		if (Options.ColorBlindness != -1)
		{
			return _posNeg[Options.ColorBlindness][(!pos) ? 1u : 0u];
		}
		return Options.GetCustomColor(17 + (pos ? 2 : 3));
	}

	public static Color GetAccentColor()
	{
		if (Options.ColorBlindness != -1)
		{
			return _accentColor[Options.ColorBlindness];
		}
		return Options.GetCustomColor(17);
	}

	public static Color GetWarningColor()
	{
		if (Options.ColorBlindness != -1)
		{
			return _warningColor[Options.ColorBlindness];
		}
		return Options.GetCustomColor(18);
	}

	public static Color GetThemeColor(int i)
	{
		if (Options.ColorBlindness != -1)
		{
			return _themeColors[Options.ColorBlindness][i % _themeColors[Options.ColorBlindness].Length];
		}
		return Options.GetCustomColor(i % 8);
	}

	public static Color[] GetThemeColors()
	{
		if (Options.ColorBlindness == -1)
		{
			if (Options.CustomColors.Length < 8)
			{
				return _themeColors[0];
			}
			return Options.CustomColors.Take(8).ToArray();
		}
		return _themeColors[Options.ColorBlindness];
	}

	public static void UpdateSpeeds()
	{
		speeds[2] = Options.SecondSpeed;
		if (Instance != null)
		{
			int num = Mathf.Max(speeds.Length, Instance.SpeedToggles.Length);
			for (int i = 1; i < num; i++)
			{
				Instance.SpeedToggles[i].GetComponent<GUIToolTipper>().ToolTipValue = speeds[i] + "x ";
			}
		}
	}

	public static float GetSpeed(int i)
	{
		return speeds[i];
	}

	public static void UpdateHUDSpeed()
	{
		for (int i = 0; i < speeds.Length; i++)
		{
			if (speeds[i] == GameSettings.GameSpeed)
			{
				HUDSpeed = i;
				return;
			}
		}
		HUDSpeed = ((GameSettings.GameSpeed > 0f) ? 1 : 0);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public string GetActiveBuildTutorial()
	{
		if (GameSettings.Instance.EditMode)
		{
			return "Custom Map";
		}
		if (!GameSettings.Instance.RentMode)
		{
			return "Build Mode";
		}
		return "Leasing";
	}

	public void CloseDropDownPanels()
	{
		for (int i = 0; i < dropDownPanels.Length; i++)
		{
			dropDownPanels[i].InstaClose();
		}
	}

	public void StartBuildModTut(bool force)
	{
		TutorialSystem.Instance.StartTutorial(GetActiveBuildTutorial(), force);
	}

	public void ClearFilters()
	{
		_disableWorkToggleRefresh = true;
		for (int i = 0; i < WorkItemToggles.Length; i++)
		{
			WorkItemToggles[i].isOn = false;
		}
		InHouseFilterToggle.isOn = true;
		ContractFilterToggle.isOn = true;
		DealFilterToggle.isOn = true;
		MultiplayerToggle.isOn = true;
		SelectionFilterToggle.isOn = false;
		_disableWorkToggleRefresh = false;
		OnWorkItemToggle(-1);
	}

	public void OnWorkItemToggle(int toggleIdx)
	{
		if (_disableWorkToggleRefresh)
		{
			return;
		}
		_disableWorkToggleRefresh = true;
		if (toggleIdx >= 0 && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
		{
			bool isOn = WorkItemToggles[toggleIdx].isOn;
			for (int i = 0; i < WorkItemToggles.Length; i++)
			{
				WorkItemToggles[i].isOn = (i == toggleIdx) ^ isOn;
			}
		}
		if (SelectorController.Instance != null)
		{
			SelectorController.Instance.UpdateTeamSelection(SelectionFilterToggle.isOn);
		}
		AllWorkTogglesOff = true;
		for (int j = 0; j < WorkItemToggles.Length; j++)
		{
			if (WorkItemToggles[j].isOn)
			{
				AllWorkTogglesOff = false;
			}
		}
		ToggleBack.color = ((AllWorkTogglesOff && InHouseFilterToggle.isOn && ContractFilterToggle.isOn && DealFilterToggle.isOn && MultiplayerToggle.isOn) ? Color.white : GetThemeColor(0)).Alpha(ToggleBack.color.a);
		for (int k = 0; k < WorkItemToggles.Length; k++)
		{
			WorkItemToggles[k].GetComponentInChildren<Text>().color = ((AllWorkTogglesOff || WorkItemToggles[k].isOn) ? new Color32(50, 50, 50, byte.MaxValue) : new Color32(100, 100, 100, byte.MaxValue));
		}
		foreach (WorkItem workItem in GameSettings.Instance.MyCompany.WorkItems)
		{
			if (workItem.guiItem != null)
			{
				workItem.guiItem.UpdateActivation();
			}
		}
		WorkItemScroll.value = 1f;
		NoDragScrollRect component = MainWorkItemPanel.GetComponent<NoDragScrollRect>();
		component.OnChange(component.normalizedPosition);
		_disableWorkToggleRefresh = false;
		WorkItemPanel.gameObject.SetActive(false);
		WorkItemPanel.gameObject.SetActive(true);
	}

	private void Start()
	{
		if (Options.MainPanelOffset.HasValue)
		{
			MainContentPanel.offsetMin = new Vector2(Options.MainPanelOffset.Value.x, 0f);
			MainContentPanel.offsetMax = new Vector2(0f - Options.MainPanelOffset.Value.y, 0f);
			MainContentPanel.GetComponent<Image>().enabled = true;
			MainContentPanel.gameObject.AddComponent<Mask>().showMaskGraphic = false;
		}
		WorkToToggle = new Dictionary<string, Toggle>();
		for (int i = 0; i < WorkItemToggles.Length; i++)
		{
			WorkToToggle[WorkItemNames[i]] = WorkItemToggles[i];
		}
		Aud = GetComponent<AudioSource>();
		if (Instance == null)
		{
			Instance = this;
			for (int j = 0; j < DefaultBottomPanels.Length; j++)
			{
				RectTransform rectTransform = DefaultBottomPanels[j];
				BottomPanels[rectTransform.transform.parent.name] = rectTransform;
				MainBottomButton[] componentsInChildren = rectTransform.GetComponentsInChildren<MainBottomButton>();
				foreach (MainBottomButton mainBottomButton in componentsInChildren)
				{
					mainBottomButton.InitSearchMode();
					BottomButtons.Add(mainBottomButton);
				}
			}
			UpdateSpeeds();
			AllFurniture = (from x in ObjectDatabase.Instance.GetAllFurniture().SelectNotNull((GameObject x) => x.GetComponent<Furniture>())
				where !x.OnlyInEditor
				select x).ToList();
			InitializeBuildMode();
			BuildMode = false;
			UpdateIdleCounter();
			CashflowChart.Values = new List<List<float>>
			{
				new List<float> { 0f, 0f, 0f, 0f, 0f }
			};
			Dictionary<string, IGrouping<string, RewardTask>> dict = (from x in GameData.Tasks
				where x.DependsOn != null
				group x by x.DependsOn).ToDictionary((IGrouping<string, RewardTask> x) => x.Key, (IGrouping<string, RewardTask> x) => x);
			for (int num = 0; num < GameData.Tasks.Count; num++)
			{
				RewardTask rewardTask = GameData.Tasks[num];
				if (rewardTask.DependsOn != null)
				{
					continue;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(TaskPanelPrefab);
				gameObject.transform.SetParent(TaskPanel, false);
				GUIRewardTask gUIRewardTask = UnityEngine.Object.Instantiate(TaskPrefab);
				gUIRewardTask.transform.SetParent(gameObject.transform, false);
				gUIRewardTask.Init(rewardTask);
				IGrouping<string, RewardTask> orDefault = dict.GetOrDefault(rewardTask.Name);
				if (orDefault == null)
				{
					continue;
				}
				UnityEngine.Object.Instantiate(DependsArrow).transform.SetParent(gameObject.transform, false);
				foreach (RewardTask item in orDefault)
				{
					GUIRewardTask gUIRewardTask2 = UnityEngine.Object.Instantiate(TaskPrefab);
					gUIRewardTask2.transform.SetParent(gameObject.transform, false);
					gUIRewardTask2.Init(item);
				}
			}
			LayoutGroup component = MainBottomButtonPanel.GetComponent<LayoutGroup>();
			component.CalculateLayoutInputHorizontal();
			component.SetLayoutHorizontal();
			UpdateButtonCounterPositions();
			MainBottomButtonPanel.gameObject.SetActive(false);
			MainBottomButtonPanel.gameObject.SetActive(true);
			if (!GameSettings.Instance.EditMode && !GameData.EditMode)
			{
				SearchPanel.AddSearchItem(financeWindow.SheetPanel, "Sheet".Loc(), delegate
				{
					financeWindow.Show(false);
					financeWindow.OnToggle(0);
				}, "Chart", false);
				SearchPanel.AddSearchItem(financeWindow.TaxReportDesc, "Taxes".Loc(), delegate
				{
					financeWindow.Show(false);
					financeWindow.OnToggle(4);
				}, "Chart", false);
				SearchPanel.AddSearchItem(financeWindow.CompanyChartPanel, "Chart".Loc(), delegate
				{
					financeWindow.Show(false);
					financeWindow.OnToggle(1);
				}, "Chart", false);
				SearchPanel.AddSearchItem(financeWindow.CompletionAbility, "Stats".Loc(), delegate
				{
					financeWindow.Show(false);
					financeWindow.OnToggle(2);
				}, "Chart", false);
				SearchPanel.AddSearchItem(financeWindow.Window, "Timeline".Loc(), delegate
				{
					financeWindow.ShowTimeline();
				}, "Chart", false);
				SearchPanel.AddSearchItem(roomGroupWindow, "Roomgroups".Loc(), delegate
				{
					roomGroupWindow.Window.Show();
				}, "Building", false);
				SearchPanel.AddSearchItem(RewardTaskWindow, "Tasks".Loc(), delegate
				{
					RewardTaskWindow.Show();
				}, "Reward", false);
				SearchPanel.AddSearchItem(assemblyLineWindow, "AssemblyLines".Loc(), delegate
				{
					assemblyLineWindow.Show();
				}, "Hardware", false);
				SearchPanel.AddSearchItem(calendarWindow, "Schedule".Loc(), delegate
				{
					calendarWindow.Show(true);
				}, "Calendar", false);
				SearchPanel.AddSearchItem(AutoLog, "AutomationLog".Loc(), delegate
				{
					AutoLog.Window.Show();
				}, "Checkmark", false);
				SearchPanel.AddSearchItem(IdleCounter, "Idleemployees".Loc(), delegate
				{
					ShowIdleEmployees();
				}, "Sleeping", false);
			}
			foreach (KeyValuePair<string, Toggle> t in DataOverlay.Instance.DataToggles)
			{
				GlobalSearchPanel.Instance.AddSearchItem(t.Value, "ToggleOverlay".Loc(t.Key.Loc()), delegate
				{
					t.Value.isOn = !t.Value.isOn;
				}, "Layers");
			}
			SearchPanel.AddSearchItem(OptionsWindow.Instance, "Options".Loc(), delegate
			{
				pauseWindow.ToggleShow();
				pauseWindow.DoAction(4);
				OptionsWindow.Instance.ActivatePanel(0);
			}, "Cogs");
			SearchPanel.AddSearchItem(OptionsWindow.Instance.GraphicsPanel, "Graphics".Loc(), delegate
			{
				pauseWindow.ToggleShow();
				pauseWindow.DoAction(4);
				OptionsWindow.Instance.ActivatePanel(1);
			}, "Cogs");
			SearchPanel.AddSearchItem(OptionsWindow.Instance.AudioPanel, "Audio".Loc(), delegate
			{
				pauseWindow.ToggleShow();
				pauseWindow.DoAction(4);
				OptionsWindow.Instance.ActivatePanel(2);
			}, "Cogs");
			SearchPanel.AddSearchItem(OptionsWindow.Instance.KeyPanel, "Keys".Loc(), delegate
			{
				pauseWindow.ToggleShow();
				pauseWindow.DoAction(4);
				OptionsWindow.Instance.ActivatePanel(3);
			}, "Cogs");
			SearchPanel.AddSearchItem(OptionsWindow.Instance.AchievementPanel, "Achievements".Loc(), delegate
			{
				pauseWindow.ToggleShow();
				pauseWindow.DoAction(4);
				OptionsWindow.Instance.ActivatePanel(6);
			}, "Cogs");
			SearchPanel.AddSearchItem(OptionsWindow.Instance.TutorialPanel, "Tutorials".Loc(), delegate
			{
				pauseWindow.ToggleShow();
				pauseWindow.DoAction(4);
				OptionsWindow.Instance.ActivatePanel(4);
			}, "Cogs");
			SearchPanel.AddSearchItem(OptionsWindow.Instance.ModPanel, "Mods".Loc(), delegate
			{
				pauseWindow.ToggleShow();
				pauseWindow.DoAction(4);
				OptionsWindow.Instance.ActivatePanel(5);
			}, "Cogs");
			SearchPanel.AddSearchItem(pauseWindow.MoveButton, "Movecompany".Loc(), delegate
			{
				pauseWindow.DoAction(7);
			}, "ArrowRight");
			SearchPanel.AddSearchItem(pauseWindow.LoadButton, "LoadGame".Loc(), delegate
			{
				pauseWindow.ToggleShow();
				pauseWindow.DoAction(3);
			}, "Download");
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public bool CheckBuildMode(bool mode)
	{
		BuildMode = mode;
		return BuildMode == mode;
	}

	public ButtonCounter AddButtonCounter(MainBottomButton parent, string label)
	{
		ButtonCounter buttonCounter = UnityEngine.Object.Instantiate(ButtonCounterPrefab);
		buttonCounter.Title = label;
		buttonCounter.Parent = parent.Button;
		buttonCounter.transform.SetParent(MainBottomButtonPanel, false);
		ButtonCounters.Add(buttonCounter);
		buttonCounter.UpdateActive();
		UpdateButtonCounterPositions();
		return buttonCounter;
	}

	public MainBottomButton AddBottomButton(string panel, string name, string desc, Sprite icon)
	{
		MainBottomButton mainBottomButton = UnityEngine.Object.Instantiate(BottomButtonPrefab);
		GUIToolTipper component = mainBottomButton.GetComponent<GUIToolTipper>();
		component.ToolTipValue = name;
		component.TooltipDescription = desc;
		component.GetComponentsInChildren<Image>()[1].sprite = icon;
		RectTransform value;
		if (!BottomPanels.TryGetValue(panel, out value))
		{
			BottomPanels.Values.MaxInstance((RectTransform x) => x.transform.parent.GetSiblingIndex()).parent.GetComponentInChildren<Image>().sprite = null;
			GameObject obj = UnityEngine.Object.Instantiate(BottomPanelPrefab);
			obj.name = panel;
			obj.GetComponentInChildren<Image>().sprite = ObjectDatabase.Instance.GetSprite(true, false, false, false);
			obj.GetComponentInChildren<Text>().text = panel;
			obj.transform.SetParent(MainBottomButtonPanel, false);
			value = obj.GetComponentsInChildren<RectTransform>()[3];
			BottomPanels[panel] = value;
		}
		mainBottomButton.transform.SetParent(value, false);
		BottomButtons.Add(mainBottomButton);
		UpdateButtonCounterPositions();
		mainBottomButton.InitSearchMode();
		return mainBottomButton;
	}

	public bool CheckDealContractFilter(WorkItem w)
	{
		WorkItem.NetworkDealState networkDealState = w.GetNetworkDealState();
		if (!InHouseFilterToggle.isOn && w.contract == null && w.ActiveDeal == null && networkDealState != WorkItem.NetworkDealState.Receiver)
		{
			return false;
		}
		if (!ContractFilterToggle.isOn && w.contract != null)
		{
			return false;
		}
		if (!DealFilterToggle.isOn && w.ActiveDeal != null)
		{
			return false;
		}
		if (!MultiplayerToggle.isOn && networkDealState != WorkItem.NetworkDealState.None)
		{
			return false;
		}
		return true;
	}

	public bool GetWorkTypeToggled(string type)
	{
		if (AllWorkTogglesOff)
		{
			return true;
		}
		Toggle orNull = WorkToToggle.GetOrNull(type);
		if (!(orNull == null))
		{
			return orNull.isOn;
		}
		return true;
	}

	public void SetBorderOverlayPanelNoLoc(string type = null, string icon = null, Color color = default(Color), bool showMoney = true)
	{
		if (type == null || GameSettings.Instance.IsReferenceNull())
		{
			BuildModePanel.SetActive(false);
			return;
		}
		BuildModeIcon.sprite = ObjectDatabase.GetIcon(icon);
		BuildModeIcon.color = color.Alpha(1f);
		BuildModeTypeText.text = type;
		BuildModePanelImage.color = color;
		BuildMoneyLabel.gameObject.SetActive(showMoney && !GameSettings.Instance.EditMode);
		BuildModePanel.SetActive(true);
	}

	public void SetBorderOverlayPanel(string type = null, string icon = null, Color color = default(Color), bool showMoney = true)
	{
		SetBorderOverlayPanelNoLoc(type.Loc(), icon, color, showMoney);
	}

	public void UpdateBuildButtonVis(bool immediate)
	{
		if (immediate)
		{
			_dirtyButtonVis = 0;
			Vector3[] array = new Vector3[4];
			BuildButtonPanel.transform.parent.GetComponent<RectTransform>().GetWorldCorners(array);
			Rect r = Rect.MinMaxRect(array[1].x, array[3].y, array[3].x, array[1].y);
			for (int i = 0; i < BuildButtons.Count; i++)
			{
				BuildButton buildButton = BuildButtons[i];
				if (buildButton.gameObject.activeSelf)
				{
					buildButton.UpdateVisible(r, array);
				}
			}
			for (int j = 0; j < AwardButtons.Count; j++)
			{
				BuildButton buildButton2 = AwardButtons[j];
				if (buildButton2.IsInRentMode)
				{
					if (buildButton2.gameObject.activeSelf)
					{
						buildButton2.UpdateVisible(r, array);
					}
					continue;
				}
				break;
			}
		}
		else
		{
			_dirtyButtonVis = 2;
		}
	}

	public void UpdateFurnitureButtons()
	{
		for (int i = 0; i < BuildButtons.Count; i++)
		{
			BuildButton buildButton = BuildButtons[i];
			if (buildButton.Descriptor.Type == BuildDescriptor.BuildType.Furniture)
			{
				if (!buildButton.Descriptor.Furniture.IsPlayerControlled())
				{
					if (buildButton.button.interactable)
					{
						buildButton.button.interactable = false;
					}
				}
				else if (buildButton.Descriptor.Furniture.IsPurchasable() && buildButton.Descriptor.Furniture.IsUnlocked())
				{
					if (!buildButton.button.interactable)
					{
						buildButton.button.interactable = true;
					}
				}
				else if (buildButton.button.interactable)
				{
					buildButton.button.interactable = false;
				}
				SearchPanel.SetEnabled(buildButton.Furn, buildButton.button.interactable);
				continue;
			}
			if (buildButton.IsInRentMode || !GameSettings.Instance.RentMode || GameSettings.Instance.EditMode)
			{
				if (!buildButton.button.interactable)
				{
					buildButton.button.interactable = true;
				}
			}
			else if (buildButton.button.interactable)
			{
				buildButton.button.interactable = false;
			}
			SearchPanel.SetEnabled(buildButton, buildButton.button.interactable);
		}
	}

	public void ShowIdleEmployees()
	{
		employeeWindow.Show(_idleEmployees.Where((Actor x) => x != null && x.gameObject != null));
	}

	public void RemoveFromIdle(Actor actor)
	{
		_idleEmployees.Remove(actor);
		UpdateIdleCounter();
	}

	public void AddToIdle(Actor actor)
	{
		_idleEmployees.Add(actor);
		UpdateIdleCounter();
	}

	private void UpdateIdleCounter()
	{
		IdleCounter.text = _idleEmployees.Count.ToString();
	}

	public GUIWorkItem SpawnWorkItem(WorkItem work, int type)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(WorkItemPrefab[type]);
		GUIWorkItem gw = gameObject.GetComponent<GUIWorkItem>();
		gw.work = work;
		SearchPanel.AddSearchItem(gw, work.QueryString, delegate
		{
			gw.Highlight();
		}, work.GetIcon(), false);
		SearchPanel.SetEnabled(gw, !work.Hidden);
		gw.transform.SetParent(WorkItemPanel, false);
		gw.InitPos();
		return gw;
	}

	public void AddCustomBuildButton(BuildDescriptor.BuildType bt, string realName, string name, string desc, float price, string category, string funcCat, string search, Action OnClick, Sprite thumb, bool isInRentMode)
	{
		BuildButton component = UnityEngine.Object.Instantiate(BuyButtonPrefab).GetComponent<BuildButton>();
		component.transform.SetParent(BuildButtonPanel.transform, false);
		component.Descriptor = new BuildDescriptor(bt, funcCat, search, null, category);
		if (isInRentMode)
		{
			component.button.onClick.AddListener(delegate
			{
				OnClick();
			});
		}
		else
		{
			component.button.onClick.AddListener(delegate
			{
				if (GameSettings.Instance.EditMode || !GameSettings.Instance.RentMode)
				{
					OnClick();
				}
			});
		}
		component.IsInRentMode = isInRentMode;
		component.SetAttributes(realName, name, desc, thumb, price);
		component.ButtonImage.sprite = thumb;
		component.Order = BuildButtons.Count;
		BuildButtons.Add(component);
		if ((!"Environment".Equals(category) || GameData.EditMode) && (GameData.EditMode || isInRentMode || !GameSettings.Instance.RentMode))
		{
			SearchPanel.AddSearchItem(component, name, OnClick, thumb, true);
		}
	}

	public void RefreshRentModeSearch()
	{
		if (!GameSettings.Instance.RentMode)
		{
			return;
		}
		foreach (BuildButton buildButton in BuildButtons)
		{
			if (!buildButton.IsInRentMode)
			{
				SearchPanel.RemoveSearchItem(buildButton);
			}
		}
	}

	private void RefreshBuildButtonOrder()
	{
		BuildButtons.Sort((BuildButton x, BuildButton y) => x.CompareTo(y));
		for (int num = 0; num < BuildButtons.Count; num++)
		{
			BuildButtons[num].transform.SetSiblingIndex(num);
		}
		UpdateBuildButtonVis(true);
	}

	private bool Match(BuildDescriptor bd, BuildDescriptor.CategoryType function)
	{
		if (function == BuildDescriptor.CategoryType.Room && (bd.Category == null || bd.Category.Length == 0))
		{
			return false;
		}
		if (bd.Type != BuildDescriptor.BuildType.Furniture && function == BuildDescriptor.CategoryType.Function)
		{
			return false;
		}
		if (function == BuildDescriptor.CategoryType.Function || (bd.Category != null && bd.Category.Length == 1))
		{
			CategoryKey key = new CategoryKey(bd.Type, (function == BuildDescriptor.CategoryType.Function) ? bd.FunctionalCategory : bd.Category[0], function);
			Toggle value;
			if (BuildCategories.TryGetValue(key, out value))
			{
				return value.isOn;
			}
			return false;
		}
		if (bd.Category != null)
		{
			for (int i = 0; i < bd.Category.Length; i++)
			{
				string category = bd.Category[i];
				CategoryKey key2 = new CategoryKey(bd.Type, category, BuildDescriptor.CategoryType.Room);
				Toggle value2;
				if (BuildCategories.TryGetValue(key2, out value2) && value2.isOn)
				{
					return true;
				}
			}
		}
		return false;
	}

	private int IconicLevel(string[] has, string needs, string extra, string[] extra2 = null)
	{
		if (needs != null)
		{
			if (has != null && has.Length != 0 && has.Contains(needs))
			{
				return 2;
			}
			if (needs.Equals(extra) || (extra2 != null && extra2.Contains(needs)))
			{
				return 1;
			}
		}
		return 0;
	}

	private Sprite GetCatSprite(bool forCon, string cat)
	{
		Sprite sprite = null;
		if (forCon)
		{
			for (int i = 0; i < ObjectDatabase.Instance.RoomSegments.Count; i++)
			{
				RoomSegment component = ObjectDatabase.Instance.RoomSegments[i].GetComponent<RoomSegment>();
				switch (IconicLevel(component.IsIconic, cat, component.Type))
				{
				case 2:
					return component.Thumbnail;
				case 1:
					if (sprite == null)
					{
						sprite = component.Thumbnail;
					}
					break;
				}
			}
		}
		for (int j = 0; j < AllFurniture.Count; j++)
		{
			Furniture furniture = AllFurniture[j];
			if (forCon)
			{
				if (!furniture.IsConstructionFurniture())
				{
					continue;
				}
				switch (IconicLevel(furniture.IsIconic, cat, furniture.Type))
				{
				case 2:
					return furniture.Thumbnail;
				case 1:
					if (sprite == null)
					{
						sprite = furniture.Thumbnail;
					}
					break;
				}
			}
			else
			{
				if (furniture.IsConstructionFurniture())
				{
					continue;
				}
				switch (IconicLevel(furniture.IsIconic, cat, furniture.FunctionCategory, furniture.Category))
				{
				case 2:
					return furniture.Thumbnail;
				case 1:
					if (sprite == null)
					{
						sprite = furniture.Thumbnail;
					}
					break;
				}
			}
		}
		return sprite ?? MissingSprite;
	}

	private void AddCategory(BuildDescriptor.BuildType bt, string cat, BuildDescriptor.CategoryType function, Sprite icon = null)
	{
		CategoryKey key = new CategoryKey(bt, cat, function);
		if (!BuildCategories.ContainsKey(key))
		{
			GameObject obj = UnityEngine.Object.Instantiate(TogglePrefab);
			obj.GetComponent<GUIToolTipper>().ToolTipValue = cat;
			obj.GetComponentsInChildren<Image>()[2].sprite = icon ?? GetCatSprite(bt == BuildDescriptor.BuildType.Construction, cat);
			Toggle component = obj.GetComponent<Toggle>();
			component.onValueChanged.AddListener(delegate
			{
				UpdateCatFilter(bt, function);
			});
			component.group = CategoryPanel.GetComponent<ToggleGroup>();
			obj.transform.SetParent(CategoryPanel.transform, false);
			BuildCategories.Add(key, component);
		}
	}

	private void InitializeBuildMode()
	{
		bool flag = ((GameData.NetworkData != null) ? GameData.NetworkData.AllowModdedFurniture : ((GameData.LobbyName != null) ? GameData.NetworkAllowFurnitureMods : GameSettings.Instance.AllowModdedFurniture));
		AddCategory(BuildDescriptor.BuildType.Furniture, "Favorites", BuildDescriptor.CategoryType.Function, FavoriteIcon);
		AddCategory(BuildDescriptor.BuildType.Furniture, "Favorites", BuildDescriptor.CategoryType.Room, FavoriteIcon);
		Sprite thumbnail = ObjectDatabase.Instance.GetFurnitureComponent("Best Product Award").Thumbnail;
		AddCategory(BuildDescriptor.BuildType.Furniture, "Awards", BuildDescriptor.CategoryType.Function, thumbnail);
		AddCategory(BuildDescriptor.BuildType.Furniture, "Awards", BuildDescriptor.CategoryType.Room, thumbnail);
		foreach (string item in ObjectDatabase.Instance.RoomSegments.Select((GameObject x) => x.GetComponent<RoomSegment>().Type).Distinct())
		{
			AddCategory(BuildDescriptor.BuildType.Construction, item, BuildDescriptor.CategoryType.Room);
		}
		foreach (Furniture item2 in AllFurniture)
		{
			if (!item2.Queryable() || (!flag && item2.FileName != null))
			{
				continue;
			}
			if (item2.IsConstructionFurniture())
			{
				AddCategory(BuildDescriptor.BuildType.Construction, item2.Type, BuildDescriptor.CategoryType.Room);
				continue;
			}
			if (item2.Category != null)
			{
				for (int num = 0; num < item2.Category.Length; num++)
				{
					string cat = item2.Category[num];
					AddCategory(BuildDescriptor.BuildType.Furniture, cat, BuildDescriptor.CategoryType.Room);
				}
			}
			AddCategory(BuildDescriptor.BuildType.Furniture, item2.FunctionCategory, BuildDescriptor.CategoryType.Function);
		}
		AddCategory(BuildDescriptor.BuildType.Construction, "Wall", BuildDescriptor.CategoryType.Room, RoomThumbnail);
		AddCategory(BuildDescriptor.BuildType.Construction, "Fence", BuildDescriptor.CategoryType.Room, FenceThumbnail);
		AddCategory(BuildDescriptor.BuildType.Roads, "Road", BuildDescriptor.CategoryType.Room, RoadThumbnail);
		AddCategory(BuildDescriptor.BuildType.Roads, "Parking", BuildDescriptor.CategoryType.Room, ParkHorThumbnail);
		AddCategory(BuildDescriptor.BuildType.Roads, "Path", BuildDescriptor.CategoryType.Room, PathThumbnail);
		AddCategory(BuildDescriptor.BuildType.Roads, "BikeRack", BuildDescriptor.CategoryType.Room, BikeHorThumb);
		int num2 = 0;
		foreach (KeyValuePair<CategoryKey, Toggle> item3 in from x in BuildCategories
			orderby (!"Favorites".Equals(x.Key.Category)) ? ((!"Awards".Equals(x.Key.Category)) ? 1 : 2) : 0, x.Key.Category.LocTry()
			select x)
		{
			item3.Value.transform.SetSiblingIndex(num2);
			num2++;
		}
		AddCustomBuildButton(BuildDescriptor.BuildType.Construction, "Wall", "Freeanglerooms".Loc(), "ContructRoomDesc".Loc(BuildController.WallPrice.Currency(), BuildController.RoomPrice.Currency(), "", "RDescRooms".Loc(), "RDescRoomWalls".Loc(), "RDescRoomSq".Loc()), BuildController.RoomPrice + BuildController.WallPrice * 4f, "Wall", null, "Wall".LocTry() + "Room".LocTry(), delegate
		{
			BuildController.Instance.ActivateBuildMode(false);
		}, RoomThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Construction, "RectangleWall", "Rectanglerooms".Loc(), "ContructRoomDesc".Loc(BuildController.WallPrice.Currency(), BuildController.RoomPrice.Currency(), "RDescRectangle".Loc(), "RDescRooms".Loc(), "RDescRoomWalls".Loc(), "RDescRoomSq".Loc(), false), BuildController.RoomPrice + BuildController.WallPrice * 4f, "Wall", null, "Wall".LocTry() + "Room".LocTry(), delegate
		{
			BuildController.Instance.BeginRectBuilding(false);
		}, RectRoomThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Construction, "CurveTool", "CurveTool".Loc(), "CurveToolDesc".Loc(), BuildController.RoomPrice + BuildController.WallPrice * 4f, "Wall", null, "Wall".LocTry() + "Room".LocTry() + "Curve".LocTry(), delegate
		{
			CurveBuilder.Instance.Show();
		}, CurveWallThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Construction, "WallDragTool", "WallDragTool".Loc(), "WallDragToolDesc".Loc(), BuildController.RoomPrice + BuildController.WallPrice * 4f, "Wall", null, "Wall".LocTry() + "Room".LocTry(), delegate
		{
			WallDragTool.Instance.Show();
		}, DragWallThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Construction, "DestroyWall", "DestroyWall".Loc(), "Teardownwallsbetweenrooms".Loc(), 0f, "Wall", null, "Fence".LocTry() + "Wall".LocTry() + "Room".LocTry() + "DestroyWall".LocTry(), delegate
		{
			WallRemovalTool.Instance.Show();
		}, RemoveWallThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Construction, "PillarToggle", "PillarToggle".Loc(), "PillarToggleDesc".Loc(), 0f, "Wall", null, "Wall".LocTry() + "Room".LocTry() + "Pillar".LocTry(), delegate
		{
			PillarToggler.Instance.gameObject.SetActive(true);
		}, PillarToggleThumnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Construction, "Atrium", "Atrium".Loc(), "AtriumTip".Loc(), 0f, "Wall", null, "Wall".LocTry() + "Room".LocTry() + "Atrium".LocTry(), delegate
		{
			AtriumTool.Instance.gameObject.SetActive(true);
		}, AtriumThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Construction, "Fence", "Freeangleoutdoorareas".Loc(), "ContructRoomDesc".Loc(BuildController.FencePrice.Currency(), BuildController.OutdoorPrice.Currency(), "", "RDescOutdoorAreas".Loc(), "RDescOutdoorFence".Loc(), "RDescOutdoorSq".Loc()), BuildController.OutdoorPrice + BuildController.FencePrice * 4f, "Fence", null, "Fence".LocTry() + "Room".LocTry(), delegate
		{
			BuildController.Instance.ActivateBuildMode(true);
		}, FenceThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Construction, "RectangleFence", "Rectangleoutdoorareas".Loc(), "ContructRoomDesc".Loc(BuildController.FencePrice.Currency(), BuildController.OutdoorPrice.Currency(), "RDescRectangle".Loc(), "RDescOutdoorAreas".Loc(), "RDescOutdoorFence".Loc(), "RDescOutdoorSq".Loc()), BuildController.OutdoorPrice + BuildController.FencePrice * 4f, "Fence", null, "Fence".LocTry() + "Room".LocTry(), delegate
		{
			BuildController.Instance.BeginRectBuilding(true);
		}, RectFenceThumbnail, false);
		float price = RoadBuildCube.ActualRoadCost(1, 0);
		AddCustomBuildButton(BuildDescriptor.BuildType.Roads, "BuildRoad", "Buildroad".Loc(), "", price, "Road", null, "Road".LocTry() + "Normal".LocTry(), delegate
		{
			RoadBuildCube.Instance.Type = 1;
			RoadBuildCube.Instance.gameObject.SetActive(true);
			AchievementController.SetInteraction(AchievementController.Mechanics.Roads);
		}, RoadThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Roads, "HorizontalParking", "Horizontalparking".Loc(), "", price, "Parking", null, "Parking".LocTry() + "Horizontal".LocTry(), delegate
		{
			RoadBuildCube.Instance.Type = 2;
			RoadBuildCube.Instance.gameObject.SetActive(true);
			RoadBuildCube.Instance.ShowArrow(0f, true);
			AchievementController.SetInteraction(AchievementController.Mechanics.Roads);
		}, ParkHorThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Roads, "VerticalParking", "Verticalparking".Loc(), "", price, "Parking", null, "Parking".LocTry() + "Vertical".LocTry(), delegate
		{
			RoadBuildCube.Instance.Type = 3;
			RoadBuildCube.Instance.gameObject.SetActive(true);
			RoadBuildCube.Instance.ShowArrow(90f, true);
			AchievementController.SetInteraction(AchievementController.Mechanics.Roads);
		}, ParkVertThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Roads, "HorizontalBikeRack", "HorizontalBikeRack".Loc(), "BikeRackDesc".Loc(), price, "BikeRack", null, "Parking".LocTry() + "Horizontal".LocTry() + "BikeRack".Loc(), delegate
		{
			RoadBuildCube.Instance.Type = 8;
			RoadBuildCube.Instance.gameObject.SetActive(true);
			RoadBuildCube.Instance.ShowArrow(0f, true);
		}, BikeHorThumb, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Roads, "VerticalBikeRack", "VerticalBikeRack".Loc(), "BikeRackDesc".Loc(), price, "BikeRack", null, "Parking".LocTry() + "Vertical".LocTry() + "BikeRack".Loc(), delegate
		{
			RoadBuildCube.Instance.Type = 9;
			RoadBuildCube.Instance.gameObject.SetActive(true);
			RoadBuildCube.Instance.ShowArrow(90f, true);
		}, BikeVertThumb, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Roads, "BuildRamp", "Ramp".Loc(), "", RoadBuildCube.ActualRoadCost(4, 0), "Road", null, "Road".LocTry() + "Ramp".LocTry(), delegate
		{
			RoadBuildCube.Instance.Type = 4;
			RoadBuildCube.Instance.gameObject.SetActive(true);
			RoadBuildCube.Instance.ShowArrow(0f, false);
			AchievementController.SetInteraction(AchievementController.Mechanics.Roads);
		}, RampThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Roads, "RemoveRoad", "Removeroad".Loc(), "", RoadBuildCube.ActualRoadCost(0, 0), "Road", null, "Road".LocTry() + "Destroy".LocTry() + "Remove".LocTry(), delegate
		{
			RoadBuildCube.Instance.Type = 0;
			RoadBuildCube.Instance.gameObject.SetActive(true);
		}, NoRoadThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Roads, "BuildPath", "Buildpath".Loc(), "PathDesc".Loc(), 0f, "Path", null, "Path".LocTry(), delegate
		{
			PathBuilder.Instance.Show(false, false);
		}, PathThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Roads, "BuildSmoothPath", "Buildsmoothpath".Loc(), "SmoothPathDesc".Loc(), 0f, "Path", null, "Smooth".LocTry() + "Path".LocTry(), delegate
		{
			PathBuilder.Instance.Show(true, false);
		}, SmoothPathThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Roads, "RemovePath", "Removepath".Loc(), "RemovePathDesc".Loc(), 0f, "Path", null, "Destroy".LocTry() + "Remove".LocTry() + "Path".LocTry(), delegate
		{
			PathBuilder.Instance.Show(false, true);
		}, NoPathThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Environment, "Houses", "Houses".Loc(), "HouseEditToolDesc".Loc(), 0f, "Environment", null, "Environment".LocTry() + "Houses".LocTry(), delegate
		{
			EnvironmentEditor.Instance.Show(EnvironmentEditor.EditorType.House);
		}, HouseThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Environment, "Skyscrapers", "Skyscrapers".Loc(), "SkyscraperEditToolDesc".Loc(), 0f, "Environment", null, "Environment".LocTry() + "Skyscrapers".LocTry(), delegate
		{
			EnvironmentEditor.Instance.Show(EnvironmentEditor.EditorType.Skyscraper);
		}, SkyscraperThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Environment, "Trees", "Trees".Loc(), "TreeEditToolDesc".Loc(), 0f, "Environment", null, "Environment".LocTry() + "Trees".LocTry(), delegate
		{
			EnvironmentEditor.Instance.Show(EnvironmentEditor.EditorType.Trees);
		}, TreeThumbnail, false);
		AddCustomBuildButton(BuildDescriptor.BuildType.Environment, "Lake", "Lake".Loc(), null, 0f, "Environment", null, "Environment".LocTry() + "Lake".LocTry(), delegate
		{
			EnvironmentEditor.Instance.Show(EnvironmentEditor.EditorType.Lake);
		}, LakeThumbnail, false);
		foreach (Furniture item4 in AllFurniture)
		{
			if (flag || item4.FileName == null)
			{
				AddFurnitureButton(item4.gameObject);
			}
		}
		foreach (RoomSegment item5 in ObjectDatabase.Instance.RoomSegments.Select((GameObject x) => x.GetComponent<RoomSegment>()))
		{
			if (!item5.Hidden)
			{
				AddSegmentButton(item5);
			}
		}
		LastType = BuildDescriptor.BuildType.Roads;
		SetBuildType(0);
		RefreshBuildButtonOrder();
		UpdateFurnitureButtons();
	}

	public void AddSegmentButton(RoomSegment segment)
	{
		string[] furniture = Localization.GetFurniture(segment.name, segment.name, segment.ButtonDescription);
		BuildButton component = UnityEngine.Object.Instantiate(BuyButtonPrefab).GetComponent<BuildButton>();
		component.transform.SetParent(BuildButtonPanel.transform, false);
		component.Descriptor = new BuildDescriptor(BuildDescriptor.BuildType.Construction, null, segment.Type.LocTry() + furniture[0], null, segment.Type);
		RoomSegment localSegment = segment;
		component.button.onClick.AddListener(delegate
		{
			if (!GameSettings.Instance.RentMode || GameSettings.Instance.EditMode)
			{
				BuildController.Instance.BeginSegmentBuild(localSegment.gameObject);
			}
		});
		component.SetAttributes(segment.name, furniture[0], (furniture.Length > 1) ? furniture[1] : "", segment.Thumbnail, segment.Cost);
		component.IsInRentMode = false;
		component.ButtonImage.sprite = segment.Thumbnail;
		component.Order = BuildButtons.Count;
		FurnButtons[segment] = component;
		BuildButtons.Add(component);
		if (!GameSettings.Instance.RentMode || GameData.EditMode)
		{
			SearchPanel.AddSearchItem(segment, furniture[0], delegate
			{
				BuildController.Instance.BeginSegmentBuild(localSegment.gameObject);
			}, segment.Thumbnail, true);
		}
	}

	public void SetFurnitureNew(Furniture furn, bool isNew)
	{
		BuildButton orNull = FurnButtons.GetOrNull(furn);
		if (orNull != null)
		{
			orNull.IsNew = isNew;
			FurnitureNewIcon.SetActive(isNew || BuildButtons.Any((BuildButton x) => x.IsNew));
		}
	}

	public void AddFurnitureButton(GameObject furniture)
	{
		Furniture component = furniture.GetComponent<Furniture>();
		if (!component.Queryable())
		{
			return;
		}
		if (component.IsConstructionFurniture())
		{
			string[] furniture2 = Localization.GetFurniture(component.GetLocalizationName(), component.GetDefaultName(), component.ButtonDescription);
			BuildButton component2 = UnityEngine.Object.Instantiate(BuyButtonPrefab).GetComponent<BuildButton>();
			component2.name = "BuildButton" + component.name;
			component2.transform.SetParent(BuildButtonPanel.transform, false);
			component2.Descriptor = new BuildDescriptor(BuildDescriptor.BuildType.Construction, null, component.Type.LocTry() + furniture2[0], component, component.Type);
			Furniture localSegment = component;
			component2.button.onClick.AddListener(delegate
			{
				if (!GameSettings.Instance.RentMode || GameSettings.Instance.EditMode)
				{
					BuildController.Instance.BeginBuildFurniture(localSegment.gameObject);
				}
			});
			component2.IsInRentMode = false;
			component2.Furn = component;
			component2.ButtonImage.sprite = component.Thumbnail;
			component2.Order = BuildButtons.Count;
			BuildButtons.Add(component2);
			FurnButtons[component] = component2;
			if (GameData.EditMode || GameSettings.Instance.EditMode || !GameSettings.Instance.RentMode)
			{
				SearchPanel.AddSearchItem(component, furniture2[0], delegate
				{
					BuildController.Instance.BeginBuildFurniture(localSegment.gameObject);
				}, component.Thumbnail, true);
			}
			return;
		}
		string[] furniture3 = Localization.GetFurniture(component.GetLocalizationName(), component.GetDefaultName(), component.ButtonDescription);
		BuildButton component3 = UnityEngine.Object.Instantiate(BuyButtonPrefab).GetComponent<BuildButton>();
		component3.name = "BuildButton" + component.name;
		component3.transform.SetParent(BuildButtonPanel.transform, false);
		string text = ((component.Category == null) ? "" : string.Join(" ", component.Category.SelectInPlace((string x) => x.LocTry())));
		string text2 = text + " " + component.FunctionCategory.LocTry() + " " + component.Type.LocTry() + " " + furniture3[0];
		if (furniture3.Length > 1 && !string.IsNullOrWhiteSpace(furniture3[1]))
		{
			text2 = text2 + " " + furniture3[1];
		}
		component3.Descriptor = new BuildDescriptor(BuildDescriptor.BuildType.Furniture, component.FunctionCategory, text2, component, component.Category);
		Furniture localFurn = component;
		component3.Furn = component;
		component3.ButtonImage.sprite = component.Thumbnail;
		component3.button.onClick.AddListener(delegate
		{
			BuildController.Instance.BeginBuildFurniture(localFurn.gameObject);
		});
		component3.Order = BuildButtons.Count;
		BuildButtons.Add(component3);
		FurnButtons[component] = component3;
		if (GameData.EditMode || GameSettings.Instance.EditMode || component.InRentMode || !GameSettings.Instance.RentMode)
		{
			SearchPanel.AddSearchItem(component, furniture3[0], delegate
			{
				BuildController.Instance.BeginBuildFurniture(localFurn.gameObject);
			}, component.Thumbnail, true);
		}
	}

	public void RemoveFurnitureButton(GameObject furn)
	{
		WallSnap component = furn.GetComponent<WallSnap>();
		BuildButton value;
		if (FurnButtons.TryGetValue(component, out value))
		{
			BuildButtons.Remove(value);
			UnityEngine.Object.Destroy(value.gameObject);
		}
		FurnButtons.Remove(component);
		SearchPanel.RemoveSearchItem(component);
		UpdateBuildButtonVis(true);
	}

	public BuildButton GetAwardButton(int i)
	{
		if (i < AwardButtons.Count)
		{
			return AwardButtons[i];
		}
		BuildButton component = UnityEngine.Object.Instantiate(BuyButtonPrefab).GetComponent<BuildButton>();
		component.transform.SetParent(BuildButtonPanel.transform, false);
		AwardButtons.Add(component);
		return component;
	}

	public void UpdateAwardButtons(bool refresh = true)
	{
		int num = 0;
		foreach (AwardTrophy.AwardData item in from x in GameSettings.Instance.Awards
			orderby (int)x.Type, x.Year descending, (int)x.Tier
			select x)
		{
			BuildButton awardButton = GetAwardButton(num);
			string text = AwardTrophy.AwardFurn[(int)item.Type];
			Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(text);
			string[] furniture = Localization.GetFurniture(furnitureComponent.GetLocalizationName(), furnitureComponent.GetDefaultName(), furnitureComponent.ButtonDescription);
			string text2 = ((furnitureComponent.Category == null) ? "" : string.Join(" ", furnitureComponent.Category.SelectInPlace((string x) => x.LocTry())));
			string text3 = text2 + " " + furnitureComponent.FunctionCategory.LocTry() + " " + furnitureComponent.Type.LocTry() + " " + furniture[0];
			if (furniture.Length > 1 && !string.IsNullOrWhiteSpace(furniture[1]))
			{
				text3 = text3 + " " + furniture[1] + item.Year;
			}
			awardButton.Descriptor = new BuildDescriptor(BuildDescriptor.BuildType.Furniture, furnitureComponent.FunctionCategory, text3, furnitureComponent, furnitureComponent.Category);
			Furniture localFurn = furnitureComponent;
			AwardTrophy.AwardData localA = item;
			awardButton.button.onClick.AddListener(delegate
			{
				BuildController.Instance.BeginBuildFurniture(localFurn.gameObject);
				BuildController.Instance.CurrentFurnitureBuilder.AwardData = localA;
			});
			awardButton.Award = item;
			awardButton.Furn = furnitureComponent;
			awardButton.ButtonImage.sprite = ObjectDatabase.Instance.GetAwardSprite(item);
			awardButton.IsInRentMode = true;
			num++;
		}
		for (int num2 = num; num2 < AwardButtons.Count; num2++)
		{
			AwardButtons[num2].IsInRentMode = false;
			AwardButtons[num2].gameObject.SetActive(false);
		}
		if (refresh)
		{
			RefreshBuildButtons();
		}
	}

	private void UpdateCatFilter(BuildDescriptor.BuildType type, BuildDescriptor.CategoryType cType)
	{
		RefreshBuildButtonOrder();
		ClearSearch();
		bool flag = true;
		bool flag2 = false;
		foreach (KeyValuePair<CategoryKey, Toggle> buildCategory in BuildCategories)
		{
			if (buildCategory.Value.gameObject.activeSelf && buildCategory.Key.Match(type, cType) && buildCategory.Value.isOn)
			{
				if ("Favorites".Equals(buildCategory.Key.Category))
				{
					flag2 = true;
				}
				flag = false;
				break;
			}
		}
		for (int i = 0; i < BuildButtons.Count; i++)
		{
			BuildButton buildButton = BuildButtons[i];
			if (buildButton.Furn != null && !buildButton.Furn.IsUnlocked())
			{
				buildButton.gameObject.SetActive(false);
			}
			else if (buildButton.Descriptor.Type == type)
			{
				bool active = flag || (flag2 && buildButton.Furn != null && Options.IsFavFurn(buildButton.Furn)) || Match(buildButton.Descriptor, cType);
				buildButton.gameObject.SetActive(active);
			}
			else
			{
				buildButton.gameObject.SetActive(false);
			}
		}
		for (int j = 0; j < AwardButtons.Count; j++)
		{
			BuildButton buildButton2 = AwardButtons[j];
			if (!buildButton2.IsInRentMode)
			{
				break;
			}
			if (buildButton2.Descriptor.Type == type)
			{
				bool active2 = flag || (flag2 && buildButton2.Furn != null && Options.IsFavFurn(buildButton2.Furn)) || Match(buildButton2.Descriptor, cType);
				buildButton2.gameObject.SetActive(active2);
			}
			else
			{
				buildButton2.gameObject.SetActive(false);
			}
		}
		BuildMenuScroll.value = 1f;
		UpdateBuildButtonVis(false);
	}

	public void SetBuildType(int type)
	{
		ClearSearch();
		LastCatType = BuildDescriptor.CategoryType.Room;
		FurnitureCategoryPanel.SetActive(type == 1);
		LastType = (BuildDescriptor.BuildType)type;
		BuildScrollBar.value = 1f;
		foreach (KeyValuePair<CategoryKey, Toggle> buildCategory in BuildCategories)
		{
			buildCategory.Value.gameObject.SetActive((buildCategory.Key.BuildType != 1 || !"Favorites".Equals(buildCategory.Key.Category) || Options.HasFavoriteFurns()) && buildCategory.Key.Match((BuildDescriptor.BuildType)type, BuildDescriptor.CategoryType.Room));
		}
		for (int i = 0; i < 4; i++)
		{
			BuildModeMainButtons[i].GetComponent<Button>().ChangeMainColor((i == type) ? GetThemeColor(0) : Color.white, true);
			BuildModeMainButtons[i].GetComponentsInChildren<Image>()[1].color = ((i == type) ? Color.white : new Color(0.2f, 0.2f, 0.2f));
		}
		UpdateCatFilter((BuildDescriptor.BuildType)type, BuildDescriptor.CategoryType.Room);
	}

	public void RefreshCats()
	{
		foreach (KeyValuePair<CategoryKey, Toggle> buildCategory in BuildCategories)
		{
			buildCategory.Value.gameObject.SetActive((buildCategory.Key.BuildType != 1 || !"Favorites".Equals(buildCategory.Key.Category) || Options.HasFavoriteFurns()) && buildCategory.Key.Match(LastType, LastCatType));
		}
	}

	public void SetCatType(int type)
	{
		BuildDescriptor.CategoryType cType = (LastCatType = (BuildDescriptor.CategoryType)type);
		BuildScrollBar.value = 1f;
		RefreshCats();
		UpdateCatFilter(LastType, cType);
	}

	private void ClearSearch()
	{
		disableSearch = true;
		SearchBar.text = "";
		disableSearch = false;
		ClearSearchButton.SetActive(false);
	}

	public void RefreshBuildButtons()
	{
		float value = BuildMenuScroll.value;
		UpdateCatFilter(LastType, LastCatType);
		BuildMenuScroll.value = value;
		UpdateBuildButtonVis(false);
	}

	public void ClearSearchClick()
	{
		int lastCatType = (int)LastCatType;
		SetBuildType((int)LastType);
		if (LastType == BuildDescriptor.BuildType.Furniture)
		{
			SetCatType(lastCatType);
		}
	}

	public void SearchBuildMode()
	{
		if (disableSearch)
		{
			return;
		}
		ClearSearchButton.SetActive(true);
		string text = SearchBar.text.ToLower();
		for (int i = 0; i < BuildButtons.Count; i++)
		{
			BuildButton buildButton = BuildButtons[i];
			if (buildButton.Furn != null && !buildButton.Furn.IsUnlocked(text.Length > 0))
			{
				buildButton.gameObject.SetActive(false);
				continue;
			}
			bool flag = GameSettings.Instance.EditMode || !GameSettings.Instance.RentMode || buildButton.Descriptor.Type == BuildDescriptor.BuildType.Furniture;
			if (buildButton.Descriptor.Type == BuildDescriptor.BuildType.Environment && !GameSettings.Instance.EditMode)
			{
				flag = false;
			}
			buildButton.gameObject.SetActive(flag && buildButton.Descriptor.SearchString.Contains(text));
		}
		for (int j = 0; j < AwardButtons.Count; j++)
		{
			BuildButton buildButton2 = AwardButtons[j];
			if (!buildButton2.IsInRentMode)
			{
				break;
			}
			buildButton2.gameObject.SetActive(buildButton2.Descriptor.SearchString.Contains(text));
		}
		BuildMenuScroll.value = 1f;
		UpdateBuildButtonVis(true);
	}

	public void UpdateCashflow()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		List<List<float>> list = (from x in GameSettings.Instance.MyCompany.Cashflow
			where !x.Key.Equals("Balance") && !x.Key.Equals("Intercompany") && !x.Key.Equals("NA")
			select x.Value).ToList();
		if (GameSettings.DaysPerMonth > 1)
		{
			float f = GameSettings.Instance.MyCompany.tempCashflow.Where((KeyValuePair<string, float> x) => !x.Key.Equals("Balance")).Sum((KeyValuePair<string, float> x) => x.Value);
			CashflowChart.Values[0][4] = Mathf.Pow(Mathf.Abs(f), 0.4f) * Mathf.Sign(f);
			for (int num = 0; num < 4; num++)
			{
				int j = num;
				if (list[0].Count - 1 - j >= 0)
				{
					float f2 = list.Select((List<float> x) => x[x.Count - 1 - j]).Sum();
					CashflowChart.Values[0][3 - num] = Mathf.Pow(Mathf.Abs(f2), 0.4f) * Mathf.Sign(f2);
				}
			}
		}
		else
		{
			for (int num2 = 0; num2 < 5; num2++)
			{
				int j2 = num2;
				if (list[0].Count - 1 - j2 >= 0)
				{
					float f3 = list.Select((List<float> x) => x[x.Count - 1 - j2]).Sum();
					CashflowChart.Values[0][4 - num2] = Mathf.Pow(Mathf.Abs(f3), 0.4f) * Mathf.Sign(f3);
				}
			}
		}
		CashflowChart.UpdateCachedBars();
	}

	public void AddPopupMessage(string msg, string icon, PopupManager.NotificationSound sfx, Color color, float importance, PopupManager.PopupIDs id = PopupManager.PopupIDs.None, int cooldown = 1)
	{
		if (id == PopupManager.PopupIDs.None)
		{
			NotificationManager.AddNotification(msg, icon, ScriptSystem.DefaultScope.NotificationTypeToType(sfx));
		}
	}

	public void AddPopupMessage(string msg, string icon, PopupManager.NotificationSound sfx, float importance, PopupManager.PopupIDs id = PopupManager.PopupIDs.None, int cooldown = 1)
	{
		if (id == PopupManager.PopupIDs.None)
		{
			NotificationManager.AddNotification(msg, icon, ScriptSystem.DefaultScope.NotificationTypeToType(sfx));
		}
	}

	public void AddPopupMessage(string msg, string icon, PopupManager.PopUpAction action, uint target, PopupManager.NotificationSound sfx, float importance, PopupManager.PopupIDs id = PopupManager.PopupIDs.None, int cooldown = 1)
	{
		if (id == PopupManager.PopupIDs.None)
		{
			NotificationManager.AddNotification(msg, icon, ScriptSystem.DefaultScope.NotificationTypeToType(sfx));
		}
	}

	public void AddPopupMessage(string msg, string icon, PopupManager.PopUpAction action, uint[] target, PopupManager.NotificationSound sfx, float importance, PopupManager.PopupIDs id = PopupManager.PopupIDs.None, int cooldown = 1)
	{
		if (id == PopupManager.PopupIDs.None)
		{
			NotificationManager.AddNotification(msg, icon, ScriptSystem.DefaultScope.NotificationTypeToType(sfx));
		}
	}

	public static void FlashMoney()
	{
		if (Instance != null)
		{
			DOTween.Sequence().Append(Instance.BuildMoneyLabel.DOColor(Color.red, 0.5f)).Append(Instance.BuildMoneyLabel.DOColor(Color.white, 0.5f));
		}
	}

	public void GotoDanger(int type)
	{
		if (!BuildController.Instance.CanChangeFloor())
		{
			return;
		}
		bool flag = false;
		Vector2 p = Vector2.zero;
		int floor = 0;
		switch (type)
		{
		case 0:
		{
			Room randomWhere = GameSettings.Instance.sRoomManager.Rooms.GetRandomWhere((Room x) => x.IsOnFire);
			if (randomWhere != null)
			{
				p = randomWhere.Center;
				floor = randomWhere.Floor;
				flag = true;
			}
			break;
		}
		case 1:
		{
			Actor random3 = GameSettings.Instance.sActorManager.Others["Burglars"].Where((Actor x) => x.enabled).GetRandom();
			if (random3 != null)
			{
				p = random3.ActualPosition.FlattenVector3();
				floor = random3.Floor;
				flag = true;
			}
			break;
		}
		case 2:
		{
			if (GameSettings.Instance.Confiscators.Count > 0)
			{
				Confiscator random = GameSettings.Instance.Confiscators.GetRandom();
				p = random.transform.position.FlattenVector3();
				floor = Mathf.FloorToInt(random.transform.position.y / 2f);
				flag = true;
				break;
			}
			Actor random2 = GameSettings.Instance.sActorManager.Others["Police"].Where((Actor x) => x.enabled).GetRandom();
			if (random2 != null)
			{
				p = random2.ActualPosition.FlattenVector3();
				floor = random2.Floor;
				flag = true;
			}
			break;
		}
		}
		if (flag)
		{
			CameraScript.Instance.MoveTo(p, floor);
		}
	}

	private string GetTimeLabel(TimeSpan span)
	{
		if (span.TotalSeconds < 60.0)
		{
			return "Second".LocPlural((int)span.TotalSeconds);
		}
		return (int)span.TotalMinutes + ":" + ((int)span.TotalSeconds % 60).ToString("00");
	}

	public void VoteToSkipAction()
	{
		NetworkMessaging.SendControlStatement(NetworkMessaging.ControlType.VoteToSkip, NetworkMessaging.MessageTarget.Everyone, 0);
	}

	private string RoundTimer()
	{
		if (!float.IsInfinity(GameSettings.Instance.RoundLimit) && NetworkManager.Instance.Players.Count > 1)
		{
			float num = GameSettings.Instance.RoundLimit - (Time.realtimeSinceStartup - TimeOfDay.Instance.RealTimeDayStart);
			float num2 = (1440f - ((float)(TimeOfDay.Instance.Hour * 60) + TimeOfDay.Instance.Minute)) / speeds[speeds.Length - 1];
			if (num - 20f < num2)
			{
				int num3 = Mathf.FloorToInt(num / 60f);
				int num4 = Mathf.FloorToInt(num % 60f);
				return num3.ToString("00") + ":" + num4.ToString("00");
			}
		}
		return null;
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (!_lastScreenWidth.Appx((float)Screen.width / Options.UISize))
		{
			float num = 0f;
			foreach (KeyValuePair<string, RectTransform> bottomPanel in BottomPanels)
			{
				num += bottomPanel.Value.rect.width + 5f;
			}
			_lastScreenWidth = (float)Screen.width / Options.UISize;
			MainWorkItemPanel.offsetMin = new Vector2(MainWorkItemPanel.offsetMin.x, (_lastScreenWidth < MainBottomButtonPanel.anchoredPosition.x - MainBottomButtonPanel.rect.width / 2f + num + MainWorkItemPanel.rect.width) ? 112 : 42);
		}
		if (_dirtyButtonVis > 0)
		{
			_dirtyButtonVis--;
			if (_dirtyButtonVis == 0)
			{
				UpdateBuildButtonVis(true);
			}
		}
		if (!SelectorController.Instance.DoneLoading)
		{
			return;
		}
		FixBFSStuck();
		if (buildMode)
		{
			if (_saveInterval > 0f)
			{
				_saveInterval -= Time.unscaledDeltaTime / 60f;
				if (_saveInterval <= 0f)
				{
					if (PauseWindow.CheckRentModeError(false))
					{
						SaveGameManager.Instance.AutoSave();
					}
					_saveInterval = Options.BuildModeSaveInterval;
				}
				if (Options.BuildModeSaveInterval == 0)
				{
					_saveInterval = 0f;
				}
			}
			else if (Options.BuildModeSaveInterval > 0)
			{
				_saveInterval = Options.BuildModeSaveInterval;
			}
		}
		Compass.rotation = Quaternion.Euler(0f, 0f, CameraScript.Instance.transform.rotation.eulerAngles.y - 90f);
		ParticleSystem.MainModule main = EffectivenessEmitter.main;
		ParticleSystem.MainModule main2 = SmokeSystem.main;
		ParticleSystem.MainModule main3 = BuildController.Instance.FireEmitter.main;
		ParticleSystem.MainModule main4 = SmellSystem.main;
		float num2 = (main.simulationSpeed = Mathf.Max(0.01f, GameSpeed));
		float num4 = (main2.simulationSpeed = num2);
		float simulationSpeed = (main3.simulationSpeed = num4);
		main4.simulationSpeed = simulationSpeed;
		ParticleSystem.MainModule main5 = DirtEmitter.main;
		main5.simulationSpeed = Mathf.Max(1f, GameSpeed);
		WorkItemDragging();
		ComplaintButton.Warning = complaintWindow.ComplaintList.Items.Count > 0;
		ServerImageButton.Warning = GameSettings.Instance.UnsupportedServerItems.Count > 0;
		BuildModePanelImage.color = BuildModePanelImage.color.Alpha((Mathf.Cos(Time.realtimeSinceStartup * (float)Math.PI * 1.5f) + 1.5f) * 0.4f * 0.8f);
		bool flag = GameSettings.FreezeGame && (!OptionsWindow.Instance.Window.Shown || !OptionsWindow.Instance.Panels[1].activeSelf);
		if (TimeOfDay.Instance.WaitingOnNetwork() && NetworkManager.Self.IsReady)
		{
			NetworkSyncPanel.SetActive(true);
			_networkStatus.Clear();
			_networkStatus.AppendLine("WaitingOnMultiplayer".Loc() + ":");
			bool flag2 = false;
			for (int i = 0; i < NetworkManager.Instance.Players.Count; i++)
			{
				NetworkPlayer networkPlayer = NetworkManager.Instance.Players[i];
				if (!networkPlayer.Self && !networkPlayer.IsReady)
				{
					_networkStatus.AppendLine(networkPlayer.Name + " - " + networkPlayer.GetGameStatus(true));
					flag2 = true;
				}
			}
			NetworkSyncLabel.text = (flag2 ? _networkStatus.ToString().TrimEnd() : "");
			VoteToSkip.SetActive(!NetworkManager.Self.VoteToSkip && NetworkManager.Instance.Players.Any((NetworkPlayer x) => x.AFK) && NetworkManager.Instance.Players.All((NetworkPlayer x) => x.IsReady || x.AFK));
		}
		else if (NetworkSyncPanel.activeSelf)
		{
			NetworkSyncPanel.SetActive(false);
		}
		if (NetworkManager.IsConnected && !NetworkManager.Self.IsReady)
		{
			string text = RoundTimer();
			bool flag3 = NetworkManager.Instance.Players.Any((NetworkPlayer x) => !x.Self && x.IsReady);
			if (text != null || flag3)
			{
				NetworkNudgePanel.SetActive(true);
				_networkStatus.Clear();
				if (flag3)
				{
					for (int num7 = 0; num7 < NetworkManager.Instance.Players.Count; num7++)
					{
						NetworkPlayer networkPlayer2 = NetworkManager.Instance.Players[num7];
						if (!networkPlayer2.Self && networkPlayer2.IsReady)
						{
							_networkStatus.AppendLine("PlayerReady".Loc(networkPlayer2.Name) + " (" + GetTimeLabel(DateTime.Now - networkPlayer2.ReadyTiming) + ")");
						}
					}
				}
				if (text != null)
				{
					_networkStatus.AppendLine("DayLimitCountDown".Loc(text).FontColor(Color.red));
				}
				NetworkNudgePanel.GetComponent<VerticalLayoutGroup>().padding = new RectOffset(6, 6, buildMode ? 16 : 88, 6);
				NetworkNudgeLabel.text = _networkStatus.ToString().TrimEnd();
			}
			else if (NetworkNudgePanel.activeSelf)
			{
				NetworkNudgePanel.SetActive(false);
			}
		}
		else if (NetworkNudgePanel.activeSelf)
		{
			NetworkNudgePanel.SetActive(false);
		}
		if (_lastBlur ^ flag)
		{
			_lastBlur = flag;
			_blurStamp = Time.realtimeSinceStartup;
			if (flag)
			{
				BlurScript.enabled = true;
			}
		}
		if (!flag && BlurScript.blurSize == 0f)
		{
			BlurScript.enabled = false;
		}
		if (BlurScript.enabled)
		{
			BlurScript.blurSize = Mathf.Lerp((!flag) ? 4 : 0, flag ? 4 : 0, Mathf.Min(1f, (Time.realtimeSinceStartup - _blurStamp) * BlurSpeed));
		}
		ColorScript.enabled = flag;
		float num8 = (float)GameSettings.Instance.ActiveFloor * 2f + 0.03f;
		if (roofEditWindow.Window.Shown)
		{
			num8 += roofEditWindow.HeightSlider.value;
		}
		PlotHolder.transform.position = new Vector3(0f, num8, 0f);
		UpdateWarnings();
		MoneyLabel.text = GameSettings.Instance.MyCompany.Money.Currency();
		MoneyLabelBack.color = ((GameSettings.Instance.MyCompany.Money > 0.0) ? new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue) : new Color32(248, 87, 87, byte.MaxValue));
		FanLabel.text = GameSettings.Instance.MyCompany.Fans.ToString("N0");
		SDateTime? takeOver = GameSettings.Instance.MyCompany.TakeOver;
		bool flag4 = TimeOfDay.Instance.Banktupcy.HasValue || takeOver.HasValue;
		if (flag4 != GameEndCountdown.gameObject.activeSelf)
		{
			GameEndCountdown.gameObject.SetActive(flag4);
		}
		if (flag4)
		{
			string input = "Bankruptcy";
			bool flag5 = true;
			SDateTime value;
			if (TimeOfDay.Instance.Banktupcy.HasValue)
			{
				if (takeOver.HasValue && takeOver.Value < TimeOfDay.Instance.Banktupcy.Value)
				{
					input = "Takeover";
					value = takeOver.Value;
					flag5 = false;
				}
				else
				{
					value = TimeOfDay.Instance.Banktupcy.Value;
				}
			}
			else
			{
				input = "Takeover";
				value = takeOver.Value;
				flag5 = false;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(input.Loc() + ": " + SDateTime.DateDiff(SDateTime.Now(), value + SDateTime.GetHour(1)));
			if (flag5)
			{
				double num9 = GameSettings.Instance.MyCompany.NewOwnedStock.SumSafe((NewStock x) => x.TotalWorth) + (double)GameSettings.Instance.Investments.SumSafe((Investment x) => x.CurrentValue);
				double maxWithdraw = GameSettings.Instance.Insurance.GetMaxWithdraw();
				float num10 = ((GameSettings.Instance.Difficulty.Loans > 0.5f) ? ((float)loanWindow.MaxLoan(1) * 10000f) : 0f);
				if (num9 > 0.0)
				{
					stringBuilder.AppendLine("AvailableForBankrupt".Loc(num9.Currency(), "Stocks".Loc()));
				}
				if (maxWithdraw > 0.0)
				{
					stringBuilder.AppendLine("AvailableForBankrupt".Loc(maxWithdraw.Currency(), "Bonds".Loc()));
				}
				if (num10 > 0f)
				{
					stringBuilder.AppendLine("AvailableForBankrupt".Loc(num10.Currency(), "Loans".Loc()));
				}
			}
			GameEndCountdown.text = stringBuilder.ToString();
		}
		if (BuildMode)
		{
			BuildMoneyLabel.text = GameSettings.Instance.MyCompany.Money.Currency();
		}
		TimeLabel.text = SDateTime.Now().ToTimeString();
		if (GameSettings.DaysPerMonth > 1)
		{
			DayLabel.text = "Day".Loc() + " " + (TimeOfDay.Instance.Day + 1) + "/" + GameSettings.DaysPerMonth;
			DateLabel.text = SDateTime.Now().ToVeryCompactString();
		}
		else
		{
			DateLabel.text = SDateTime.Now().ToCompactString();
		}
		if (lastRep != GameSettings.Instance.MyCompany.BusinessReputation)
		{
			ReputationBar.Colors[1] = ((lastRep > GameSettings.Instance.MyCompany.BusinessReputation) ? GetPosNeg(false) : GetPosNeg(true));
			lastRep = GameSettings.Instance.MyCompany.BusinessReputation;
		}
		ReputationBar[1] = GameSettings.Instance.MyCompany.BusinessReputation * 6f;
		ReputationBar[2] = GameSettings.Instance.MyCompany.DiscreteRep * 6f;
		TemperatureTip.ToolTipValue = TimeOfDay.Instance.Temperature.Temperature(false);
		TemperatureTip.UpdateTip();
		float num11 = TimeOfDay.Instance.Temperature.MapRange(-5f, 35f, 0f, 1f, true);
		TemperatureProg.offsetMax = new Vector2(TemperatureProg.offsetMax.x, (num11 - 1f) * TemperatureHolder.rect.height);
		Color color = Color.Lerp(GetThemeColor(1), GetThemeColor(2), num11);
		for (int num12 = 0; num12 < TemperatureColor.Length; num12++)
		{
			TemperatureColor[num12].color = color;
		}
		ClockArm.rotation = Quaternion.Euler(0f, 0f, (0f - ((float)(TimeOfDay.Instance.Hour % 12) + TimeOfDay.Instance.Minute / 60f)) / 12f * 360f);
		SkipButton.interactable = !BuildMode && TimeOfDay.Instance.canSkip;
		if (SkipButton.interactable)
		{
			if ((!AvoidInitialSkip && Options.AutoSkip) || InputController.GetKeyUp(InputController.Keys.SkipDay))
			{
				SkipDay();
			}
			else
			{
				HelpTipPanel.Show(HintController.Hints.SkipTimeHint, SkipButtonRect);
			}
		}
		ToggleBuildModeButton.anchoredPosition = new Vector2(Mathf.Lerp(ToggleBuildModeButton.anchoredPosition.x, (!GameSettings.Instance.EditMode) ? 0f : (0f - ToggleBuildModeButton.sizeDelta.x), Time.deltaTime * 8f), ToggleBuildModeButton.anchoredPosition.y);
		FireBuildStop.gameObject.SetActive(GameSettings.Instance.FireCounter > 0);
		ThiefBuildStop.gameObject.SetActive(GameSettings.BurglarPresent());
		ConfiscationBuildStop.gameObject.SetActive(GameSettings.ConfiscationUnderway());
		bool flag6 = !GameSettings.Instance.HasDanger() && GameSettings.Instance.CanUseBuildMode();
		if (flag6 ^ ActualBuildButton.interactable)
		{
			ActualBuildButton.interactable = flag6;
			ActualBuildButton.GetComponent<GUIToolTipper>().Disabled = !flag6;
		}
		BuildPanel.anchoredPosition = new Vector2(BuildPanel.anchoredPosition.x, Mathf.CeilToInt(Mathf.Lerp(BuildPanel.anchoredPosition.y, buildMode ? 0f : (0f - BuildPanel.sizeDelta.y - 10f), Time.deltaTime * 10f)));
		bool flag7 = BuildPanel.anchoredPosition.y > 0f - (BuildPanel.sizeDelta.y - 10f);
		if (BuildPanel.gameObject.activeSelf ^ flag7)
		{
			BuildPanel.gameObject.SetActive(flag7);
		}
		BuildHelperPanel.anchoredPosition = new Vector2(Mathf.CeilToInt(Mathf.Lerp(BuildHelperPanel.anchoredPosition.x, (Options.GridPanel && buildMode) ? 0f : (BuildHelperPanel.sizeDelta.x + 10f), Time.deltaTime * 10f)), BuildHelperPanel.anchoredPosition.y);
		MainBottomButtonPanel.anchoredPosition = new Vector2(MainBottomButtonPanel.anchoredPosition.x, Mathf.CeilToInt(Mathf.Lerp(MainBottomButtonPanel.anchoredPosition.y, buildMode ? (0f - MainBottomButtonPanel.rect.height - 12f) : 0f, Time.deltaTime * 10f)));
		bool flag8 = (GameSettings.Instance.MyCompany.WorkItems.Any((WorkItem x) => !x.Hidden) || GroupTaskManager.HasAny) && !BuildMode;
		workItemTogglePanel.SetActive(flag8);
		GroupItemTogglePanel.SetActive(flag8);
		if (MainWorkItemPanel.gameObject.activeSelf != flag8)
		{
			MainWorkItemPanel.gameObject.SetActive(flag8);
			if (flag8)
			{
				NoDragScrollRect component = MainWorkItemPanel.GetComponent<NoDragScrollRect>();
				component.OnChange(component.normalizedPosition);
			}
		}
		if (WorkItemScroll.gameObject.activeSelf)
		{
			MainWorkItemPanel.sizeDelta = new Vector2(266f, MainWorkItemPanel.sizeDelta.y);
		}
		else
		{
			MainWorkItemPanel.sizeDelta = new Vector2(256f, MainWorkItemPanel.sizeDelta.y);
			WorkItemScroll.value = 1f;
		}
		if (!GameSettings.FreezeGame)
		{
			if (InputController.GetKeyDown(InputController.Keys.ShowFurnitureInfluence) && BuildController.Instance.CurrentFurnitureBuilder == null)
			{
				if (FurnitureInfluenceDrawer.Instance.enabled)
				{
					FurnitureInfluenceDrawer.Instance.Disable();
				}
				else
				{
					foreach (Furniture item in SelectorController.Instance.Selected.OfType<Furniture>())
					{
						if (FurnitureDistances.Distances.ContainsKey(item.Type))
						{
							FurnitureInfluenceDrawer.Instance.Set(item);
							break;
						}
					}
				}
			}
			if (InputController.GetKeyUp(InputController.Keys.SaveGame) && PauseWindow.CheckRentModeError())
			{
				SaveGameManager.Instance.AutoSave(false, null, true);
			}
			if (InputController.GetKeyUp(InputController.Keys.HideHUD))
			{
				if (WindowManager.Instance.MainPanel.activeSelf)
				{
					_disabledWindowsHUDHide = WindowManager.DisableAll(true);
				}
				else
				{
					WindowManager.EnableAll(_disabledWindowsHUDHide);
				}
			}
			if (InputController.GetKeyDown(InputController.Keys.ToggleBuildMode))
			{
				BuildMode = !BuildMode;
			}
		}
		if (BuildMode && !WindowManager.HasModal && InputController.GetKeyDown(InputController.Keys.Undo))
		{
			GameSettings.Instance.Undo();
		}
		if (InputController.GetKeyUp(InputController.Keys.Pause))
		{
			if (GameSpeed == 0)
			{
				disableSpeedPanel = true;
				GameSpeed = BeforePause;
				disableSpeedPanel = false;
			}
			else
			{
				disableSpeedPanel = true;
				BeforePause = GameSpeed;
				GameSpeed = 0;
				disableSpeedPanel = false;
			}
		}
		if (InputController.GetKeyUp(InputController.Keys.Speed1))
		{
			disableSpeedPanel = true;
			GameSpeed = 1;
			disableSpeedPanel = false;
		}
		if (InputController.GetKeyUp(InputController.Keys.Speed2))
		{
			disableSpeedPanel = true;
			GameSpeed = 2;
			disableSpeedPanel = false;
		}
		if (InputController.GetKeyUp(InputController.Keys.Speed3))
		{
			disableSpeedPanel = true;
			GameSpeed = 3;
			disableSpeedPanel = false;
		}
		if ((Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Joystick1Button7)) && !WindowManager.HasModal && !SearchPanel.gameObject.activeSelf)
		{
			newspaper.ShowNow(false);
			pauseWindow.ToggleShow();
		}
		if (!pauseWindow.gameObject.activeSelf && !WindowManager.HasModal && InputController.GetKeyUp(InputController.Keys.GlobalSearch))
		{
			SearchPanel.Show();
		}
		if (InputController.GetKeyUp(InputController.Keys.ToggleWalls))
		{
			LowerWallsButton();
		}
		if (InputController.GetKeyUp(InputController.Keys.ToggleLights))
		{
			HideLampsToggle.isOn = !HideLampsToggle.isOn;
		}
		if (InputController.GetKeyUp(InputController.Keys.ToggleAudioOverlay))
		{
			AudioOverlayToggle.isOn = !AudioOverlayToggle.isOn;
		}
		if (InputController.GetKeyUp(InputController.Keys.ToggleDataOverlay))
		{
			DataOverlay.Instance.Toggle();
		}
		if (InputController.GetKeyUp(InputController.Keys.ToggleTeamLabels))
		{
			RoomLabelToggle.isOn = !RoomLabelToggle.isOn;
		}
		if (InputController.GetKeyUp(InputController.Keys.ToggleWireMode))
		{
			WireModeToggle.isOn = !WireModeToggle.isOn;
		}
		if (InputController.GetKeyUp(InputController.Keys.CloseAllWindows) && !WindowManager.HasModal)
		{
			WindowManager.Instance.ShowMessageBox("CloseAllWindowWarning".Loc(), true, DialogWindow.DialogType.Warning, delegate
			{
				WindowManager.Instance.CloseAll(TutorialSystem.Instance.Window);
			}, "Close all windows");
		}
		if (InputController.GetKeyDown(InputController.Keys.ReportScreen) && !FeedbackWindow.Instance.Window.Shown)
		{
			StartCoroutine(ReportScreen());
		}
	}

	private void FixBFSStuck()
	{
		if (GameSettings.Instance.sRoomManager.RoomNearnessDirty || GameSettings.Instance.sRoomManager.IsBFSStarted())
		{
			return;
		}
		lock (InaccessibleRoom)
		{
			if (!_inaccessibleRoomTry && InaccessibleRoom.Count > 0 && InaccessibleRoom.Any((Room x) => x.PathNodes.Any((PathNode<Vector3> z) => z.ConnectionCount > 0)))
			{
				_inaccessibleRoomTimer += Time.unscaledDeltaTime;
				if (_inaccessibleRoomTimer > 1f)
				{
					_inaccessibleRoomTry = true;
					_inaccessibleRoomTimer = 0f;
					GameSettings.Instance.sRoomManager.RoomNearnessDirty = true;
					Debug.Log("Retrying BFS due to inaccessible rooms");
				}
			}
			else if (_inaccessibleRoomTry)
			{
				if (InaccessibleRoom.Count == 0 || InaccessibleRoom.None((Room x) => x.PathNodes.Any((PathNode<Vector3> z) => z.ConnectionCount > 0)))
				{
					_inaccessibleRoomTimer += Time.unscaledDeltaTime;
					if (_inaccessibleRoomTimer > 2f)
					{
						_inaccessibleRoomTry = false;
					}
				}
			}
			else
			{
				_inaccessibleRoomTimer = 0f;
			}
		}
	}

	public IEnumerator ReportScreen()
	{
		if (_isReporting)
		{
			yield break;
		}
		_isReporting = true;
		string path;
		try
		{
			path = Path.Combine(Path.GetFullPath("./"), "ScreenCap.png");
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			ScreenCapture.CaptureScreenshot(path);
		}
		catch (Exception)
		{
			_isReporting = false;
			throw;
		}
		float w = Time.realtimeSinceStartup;
		while (!File.Exists(path) && Time.realtimeSinceStartup - w < 4f)
		{
			yield return new WaitForEndOfFrame();
		}
		if (!File.Exists(path))
		{
			path = null;
		}
		if (path == null)
		{
			FeedbackWindow.Instance.Show(FeedbackWindow.ReportTypes.Feedback, path, false, false, null);
		}
		else
		{
			FeedbackWindow.Instance.Show(FeedbackWindow.ReportTypes.Feedback, path, false, false, null, path);
		}
		_isReporting = false;
	}

	public void PlayAnyClip(AudioClip clip)
	{
		Aud.PlayOneShot(clip);
	}

	public Vector2 GetScreenProj(Vector2 pos, float offsetY = 0f, bool useFloor = true)
	{
		if (useFloor)
		{
			offsetY += (float)GameSettings.Instance.ActiveFloor * 2f;
		}
		Ray ray = CameraScript.Instance.SSAScript.ScreenPointToRay(pos);
		Plane plane = new Plane(Vector3.up, Vector3.up * offsetY);
		float enter = 0f;
		plane.Raycast(ray, out enter);
		Vector3 point = ray.GetPoint(enter);
		return new Vector2(point.x, point.z);
	}

	public Vector2 GetMouseProj(float offsetY = 0f, bool useFloor = true)
	{
		return GetScreenProj(Input.mousePosition, offsetY, useFloor);
	}

	public Rect MakeRect(Vector2 v1, Vector2 v2)
	{
		float num = Mathf.Min(v1.x, v2.x);
		float num2 = Mathf.Max(v1.x, v2.x);
		float num3 = Mathf.Min(v1.y, v2.y);
		float num4 = Mathf.Max(v1.y, v2.y);
		return new Rect(num, num3, num2 - num - 1f, num4 - num3 - 1f);
	}

	public Vector2 IntVec(Vector2 v, bool floor)
	{
		if (floor)
		{
			return new Vector2(Mathf.Floor(v.x), Mathf.Floor(v.y));
		}
		return new Vector2(Mathf.Ceil(v.x), Mathf.Ceil(v.y));
	}

	private void DrawGizmoPath(Vector3 p1, Vector3 p2, float speed, float len)
	{
		if (DrawSpeed)
		{
			Gizmos.color = Color.Lerp(Color.red, Color.green, speed.MapRange(-0.25f, 0f, 0f, 1f, true));
		}
		else
		{
			bool num = speed < 0f;
			Color a = (num ? Color.red : Color.green);
			Color b = (num ? Color.yellow : Color.blue);
			Gizmos.color = Color.Lerp(a, b, len);
		}
		Gizmos.DrawSphere(p1, 0.1f);
		Gizmos.DrawLine(p1 + Vector3.up * 0.05f, p2 + Vector3.up * 0.05f);
	}

	private void DrawGizmoPath(PathVector p1, PathVector p2, float len)
	{
		if (p1.Type == PathVector.PathType.Outside)
		{
			Vector3 vector = p1;
			float num = p1.GetSpeed(vector);
			Vector3 vector2 = p2 - p1;
			float magnitude = vector2.magnitude;
			float num2 = 0.1f;
			Vector3 vector3 = vector2 * (1f / magnitude);
			float num3 = 0f;
			while (num3 < magnitude)
			{
				num3 += num2;
				Vector3 vector4 = p1 + vector3 * num3;
				float speed = p1.GetSpeed(vector4);
				if (speed != num)
				{
					DrawGizmoPath(vector, vector4, num, len);
					vector = vector4;
					num = speed;
				}
			}
			DrawGizmoPath(vector, p2, num, len);
		}
		else
		{
			DrawGizmoPath(p1, p2, p1.GetSpeed(p1), len);
		}
	}

	private void OnDrawGizmos()
	{
		if (_path != null && _path.Count > 0)
		{
			Gizmos.color = Color.green;
			for (int i = 1; i < _path.Count; i++)
			{
				DrawGizmoPath(_path[i - 1], _path[i], (float)i / (float)(_path.Count - 1));
			}
			Gizmos.color = Color.white;
			Gizmos.DrawSphere(_path[_path.Count - 1] + Vector3.up * 0.05f, 0.1f);
		}
		if (!GameSettings.Instance.IsReferenceNull())
		{
			PathController pathController = GameSettings.Instance.sRoomManager.PathController;
			PathController.PathPoint pathFirst = pathController.GetPathFirst(GetMouseProj(), 1f);
			for (int j = 0; j < pathController.AllPoints.Count; j++)
			{
				PathController.PathPoint pathPoint = pathController.AllPoints[j];
				Vector3 vector = pathPoint.Point.ToVector3(0f);
				Gizmos.color = ((pathPoint == pathFirst) ? Color.white : (pathController.EndPoints.Contains(pathPoint) ? Color.cyan : Color.magenta));
				Gizmos.DrawSphere(vector, 0.1f);
				for (int k = 0; k < pathPoint.Connections.Count; k++)
				{
					PathController.PathPoint key = pathPoint.Connections[k].Key;
					if (pathPoint.ID > key.ID)
					{
						Gizmos.color = ((key == pathFirst || pathPoint == pathFirst) ? Color.white : Color.magenta);
						Gizmos.DrawLine(vector, key.Point.ToVector3(0f));
					}
				}
			}
		}
		Gizmos.color = Color.white;
	}

	public void EmployeesButton()
	{
		employeeWindow.Show();
	}

	public void DealsButton()
	{
		dealWindow.Toggle();
	}

	public void HireEmployeesButton()
	{
		hireWindow.Show();
		TutorialSystem.Instance.StartTutorial("Hiring");
	}

	public void NewspaperButton()
	{
		newspaper.ShowNow(true);
	}

	public void TeamsButton()
	{
		TeamWindow.Window.Toggle();
		TutorialSystem.Instance.StartTutorial("Team management");
	}

	public void StaffButton()
	{
		staffWindow.Show();
	}

	public void ServerButton()
	{
		ServerProcessWarning.SetActive(false);
		serverWindow.Window.Toggle();
	}

	public void MyReleasesButton()
	{
		if (PlayerProductWindow.Window.Shown)
		{
			PlayerProductWindow.Window.Close();
		}
		else
		{
			ShowMyReleases();
		}
	}

	public void ShowMyReleases()
	{
		PlayerProductWindow.Init();
		PlayerProductWindow.ShowPlayer();
	}

	public void AllReleasesButton()
	{
		ProductWindow productWindow = GetProductWindow("AllRelease");
		if (productWindow.Window.Shown)
		{
			productWindow.Window.Close();
			return;
		}
		productWindow.SetFilters(true, true);
		productWindow.Show(true, "AllReleaes".Loc());
		productWindow.ApplyFilters();
	}

	public void DevelopButton()
	{
		docWindow.ToggleVisible();
	}

	public void InsuranceButton()
	{
		insuranceWindow.Show();
	}

	public void ContractButton()
	{
		contractWindow.Show();
	}

	public void CompanyButton()
	{
		companyWindow.Window.Toggle();
	}

	public void ResearchButton()
	{
		researchWindow.ToggleShow();
	}

	public void StockButton()
	{
		companyWindow.ToggleCompanyDetails(GameSettings.Instance.MyCompany);
	}

	public void LoanButton()
	{
		loanWindow.Show();
	}

	public void BuildModeButton()
	{
		BuildMode = !BuildMode;
	}

	public void HideCeilingButton()
	{
		GameSettings.Instance.HideCeilingFurniture = HideLampsToggle.isOn;
		Furniture.UpdateEdgeDetection();
		GameSettings.Instance.sRoomManager.ChangeFloor();
	}

	public void WireModeButton()
	{
		GameSettings.Instance.WireMode = WireModeToggle.isOn;
		if (GameSettings.Instance.WireMode)
		{
			SelectorController.Instance.Highligt(false);
			SelectorController.Instance.Selected.Clear();
		}
		CameraScript.Instance.WireRender.enabled = WireModeToggle.isOn;
		UpdateBorderOverlay();
	}

	public void UpdateBorderOverlay()
	{
		if (WallRemovalTool.Instance != null && WallRemovalTool.Instance.gameObject.activeSelf)
		{
			SetBorderOverlayPanel("ActionMergeRooms", "Room", new Color(1f, 1f, 0.5f, 0.8f));
		}
		else if (CurveBuilder.Instance != null && CurveBuilder.Instance.gameObject.activeSelf)
		{
			SetBorderOverlayPanel("CurveTool", "Room", new Color(1f, 1f, 0.5f, 0.8f));
		}
		else if (WallDragTool.Instance != null && WallDragTool.Instance.gameObject.activeSelf)
		{
			SetBorderOverlayPanel("WallDragTool", "Room", new Color(1f, 1f, 0.5f, 0.8f));
		}
		else if (PillarToggler.Instance != null && PillarToggler.Instance.gameObject.activeSelf)
		{
			SetBorderOverlayPanel("Pillar", "Pillar", new Color(1f, 1f, 0.5f, 0.8f));
		}
		else if (AtriumTool.Instance != null && AtriumTool.Instance.gameObject.activeSelf)
		{
			SetBorderOverlayPanel("Atrium", "Atrium", new Color(1f, 1f, 0.5f, 0.8f));
		}
		else if (BuildController.Instance != null && BuildController.Instance.alignNow)
		{
			SetBorderOverlayPanel("Anchor grid", "Grid", new Color(0.5f, 0.5f, 1f, 0.8f), false);
		}
		else if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.WireMode)
		{
			SetBorderOverlayPanelNoLoc("WireMode".Loc() + AddKey(InputController.Keys.ToggleWireMode), "Wires", new Color(1f, 0.5f, 0.5f, 0.8f), false);
		}
		else if (PlotController.Instance != null && PlotController.Instance.gameObject.activeSelf)
		{
			SetBorderOverlayPanel("Plot view", "Plot", new Color(0.5f, 1f, 1f, 0.8f));
		}
		else if (PathBuilder.Instance != null && PathBuilder.Instance.enabled)
		{
			SetBorderOverlayPanel("Path", "Road", new Color(1f, 0.5f, 1f, 0.8f));
		}
		else if (buildMode)
		{
			SetBorderOverlayPanelNoLoc("BuildMode".Loc() + AddKey(InputController.Keys.ToggleBuildMode), "BuildMode", new Color(1f, 1f, 1f, 0.8f));
		}
		else if (GameSettings.GameSpeed == 0f && !GameSettings.ForcePause)
		{
			SetBorderOverlayPanelNoLoc("", "Pause2", new Color(0.5f, 1f, 0.5f, 0.8f), false);
		}
		else
		{
			SetBorderOverlayPanel();
		}
		MaterialPreviewer.Instance.RefreshState();
	}

	public string AddKey(InputController.Keys key, bool paran = true)
	{
		string fullKeyBindString = InputController.GetFullKeyBindString(key, false, true);
		if (fullKeyBindString != null)
		{
			if (!paran)
			{
				return fullKeyBindString;
			}
			return " (" + fullKeyBindString + ")";
		}
		return "";
	}

	public void LowerWallsButton()
	{
		int wallsDown = (int)GameSettings.WallsDown;
		wallsDown = (wallsDown + 1) % 4;
		LowerWallImage.sprite = lowerWallImages[wallsDown];
		GameSettings.WallsDown = (GameSettings.WallState)wallsDown;
		Furniture.UpdateEdgeDetection();
		GameSettings.Instance.sRoomManager.ChangeFloor();
	}

	public void DataOverlayButton(BaseEventData ev)
	{
		PointerEventData pointerEventData = (PointerEventData)ev;
		if (pointerEventData.button == PointerEventData.InputButton.Left)
		{
			DataOverlay.Instance.Toggle();
			RefreshDataoverlayToggle();
		}
		else if (pointerEventData.button == PointerEventData.InputButton.Right && DataOverlayToggle.isOn)
		{
			DataOverlayToggle.isOn = false;
			DataOverlay.Instance.ActivateFunc(null);
			SelectorController.CanClick = false;
			for (int i = 0; i < DataToggles.Length; i++)
			{
				DataToggles[i].isOn = false;
			}
		}
	}

	public void RefreshDataoverlayToggle()
	{
		DataOverlayToggle.isOn = DataOverlay.HasActive || DataToggles.Any((Toggle x) => x.isOn);
	}

	public void TeamTextButton()
	{
		GameSettings.Instance.sRoomManager.TeamText = RoomLabelToggle.isOn;
	}

	public void ShowCompanyChart()
	{
		companyChart.Show(GameSettings.Instance.MyCompany);
	}

	public void EventButton()
	{
		eventWindow.Window.Toggle();
	}

	public void UpdateSpeed()
	{
		if (disableSpeedPanel)
		{
			return;
		}
		disableSpeedPanel = true;
		for (int i = 0; i < SpeedToggles.Length; i++)
		{
			if (SpeedToggles[i].isOn)
			{
				GameSpeed = i;
				break;
			}
		}
		disableSpeedPanel = false;
	}

	public void SkipDay()
	{
		AvoidInitialSkip = false;
		HelpTipPanel.DismissHint(HintController.Hints.SkipTimeHint);
		TimeOfDay.Instance.SkipTime();
	}

	public void ComingReleaseButton()
	{
		comingReleaseWindow.Toggle();
	}

	public void FixUpperDayPanel()
	{
		if (GameSettings.DaysPerMonth > 1)
		{
			RectTransform component = TimeLabel.transform.parent.GetComponent<RectTransform>();
			RectTransform component2 = DateLabel.transform.parent.GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(component.sizeDelta.x * 2f / 3f, component.sizeDelta.y);
			component.anchoredPosition = new Vector2(0f - component.sizeDelta.x - 1f, component.anchoredPosition.y);
			component2.sizeDelta = new Vector2(component2.sizeDelta.x * 2f / 3f - 1f, component2.sizeDelta.y);
			component2.anchoredPosition = new Vector2(component2.sizeDelta.x + 1f, component2.anchoredPosition.y);
		}
		DayLabel.transform.parent.gameObject.SetActive(!buildMode && GameSettings.DaysPerMonth > 1);
	}

	public void ShowAutoProjDetail(AutoDevWorkItem workItem)
	{
		AutoDevDetailWindow autoDevDetailWindow = WindowManager.FindWindowType<AutoDevDetailWindow>().FirstOrDefault((AutoDevDetailWindow x) => x.workItem == workItem);
		if (autoDevDetailWindow != null)
		{
			WindowManager.Focus(autoDevDetailWindow.Window);
			return;
		}
		GameObject obj = UnityEngine.Object.Instantiate(AutoProjectDetailWindow);
		obj.GetComponent<AutoDevDetailWindow>().workItem = workItem;
		obj.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
	}

	private void UpdateWarnings()
	{
		if (GameSettings.Instance.IsReferenceNull() || GameSettings.FreezeGame)
		{
			return;
		}
		Vector3 mousePosition = Input.mousePosition;
		bool flag = true;
		WarningOverlay.BeginMessageUpdate();
		for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
		{
			Room room = GameSettings.Instance.sRoomManager.Rooms[i];
			if (BuildMode || room.MajorProblem)
			{
				if (!CameraScript.Instance.TopDown && room.Floor == GameSettings.Instance.ActiveFloor && room.Problems.Count > 0 && room.OuterWalls != null && room.OuterWalls.GetComponent<Renderer>().isVisible)
				{
					Vector3 p = new Vector3(room.Center.x, room.Floor * 2 + 1, room.Center.y);
					flag &= WarningOverlay.AddMessages(WTS(p), mousePosition, room.Problems);
					if (!flag)
					{
						break;
					}
				}
			}
			else if (!room.CanClean && room.Floor == GameSettings.Instance.ActiveFloor && room.OuterWalls != null && room.OuterWalls.GetComponent<Renderer>().isVisible)
			{
				Vector3 p2 = new Vector3(room.Center.x, room.Floor * 2 + 1, room.Center.y);
				flag &= WarningOverlay.AddMessages(WTS(p2), mousePosition, "CleaningBlocked".Loc());
				if (!flag)
				{
					break;
				}
			}
		}
		if (GameSettings.Instance.EditMode || !GameSettings.Instance.RentMode)
		{
			lock (InaccessibleRoom)
			{
				if (flag && InaccessibleRoom.Count > 0)
				{
					foreach (Room item in InaccessibleRoom)
					{
						if (item != null && item.Floor == GameSettings.Instance.ActiveFloor && !item.NavmeshRebuildStarted)
						{
							Vector3 p3 = new Vector3(item.Center.x, (float)(item.Floor * 2) + 1.5f, item.Center.y);
							flag &= WarningOverlay.AddMessages(WTS(p3), mousePosition, "InaccessibleRoom".Loc());
							if (!flag)
							{
								break;
							}
						}
					}
				}
			}
		}
		if (flag && UnreachableFuniture.Count > 0)
		{
			lock (UnreachableFuniture)
			{
				foreach (Furniture item2 in UnreachableFuniture)
				{
					if (item2 != null && item2.Parent != null && item2.Parent.Floor == GameSettings.Instance.ActiveFloor)
					{
						string[] furniture = Localization.GetFurniture(item2.GetLocalizationName(), item2.GetDefaultName(), null);
						flag &= WarningOverlay.AddMessages(WTS(item2.transform.position + Vector3.up * item2.Height2), mousePosition, "UnreachableFurniture".Loc(furniture[0]));
						if (!flag)
						{
							break;
						}
					}
				}
			}
		}
		if (flag && GameSettings.Instance.ActiveFloor == 0)
		{
			HashSet<PathController.PathPoint> inAccessibleEndPoints = GameSettings.Instance.sRoomManager.PathController.InAccessibleEndPoints;
			if (inAccessibleEndPoints.Count > 0)
			{
				foreach (PathController.PathPoint item3 in inAccessibleEndPoints)
				{
					flag &= WarningOverlay.AddMessages(WTS(item3.Point.ToVector3(1f)), mousePosition, "UnreachablePath".Loc());
					if (!flag)
					{
						break;
					}
				}
			}
		}
		if (flag && CCTVNoConnection.Count > 0)
		{
			foreach (Furniture item4 in CCTVNoConnection)
			{
				if (item4.Parent != null && item4.Parent.Floor == GameSettings.Instance.ActiveFloor)
				{
					flag &= WarningOverlay.AddMessages(WTS(item4.transform.position + Vector3.up * item4.Height2), mousePosition, "CCTVConnectionError".Loc());
					if (!flag)
					{
						break;
					}
				}
			}
		}
		if (flag && NotAllowedInRoom.Count > 0)
		{
			foreach (Furniture item5 in NotAllowedInRoom)
			{
				if (item5.Parent != null && item5.Parent.Floor == GameSettings.Instance.ActiveFloor)
				{
					string[] furniture2 = Localization.GetFurniture(item5.GetLocalizationName(), item5.GetDefaultName(), null);
					flag &= WarningOverlay.AddMessages(WTS(item5.transform.position + Vector3.up * item5.Height2), mousePosition, "FurnitureInLimitRoomError".Loc(furniture2[0]));
					if (!flag)
					{
						break;
					}
				}
			}
		}
		if (flag && NoChairPC.Count > 0)
		{
			foreach (Furniture item6 in NoChairPC)
			{
				if (item6.Parent != null && item6.Parent.Floor == GameSettings.Instance.ActiveFloor)
				{
					string[] furniture3 = Localization.GetFurniture(item6.GetLocalizationName(), item6.GetDefaultName(), null);
					flag &= WarningOverlay.AddMessages(WTS(item6.transform.position + Vector3.up * item6.Height2), mousePosition, "MissingChairHint".Loc(furniture3[0]));
					if (!flag)
					{
						break;
					}
				}
			}
		}
		if (flag && CantGetHome.Count > 0)
		{
			foreach (Actor item7 in CantGetHome)
			{
				if (Mathf.FloorToInt((item7.ActualPosition.y + 1f) / 2f) == GameSettings.Instance.ActiveFloor)
				{
					Vector3 p4 = new Vector3(item7.ActualPosition.x, Mathf.Floor(item7.ActualPosition.y / 2f) * 2f + 2f, item7.ActualPosition.z);
					flag &= WarningOverlay.AddMessages(WTS(p4), mousePosition, "EmployeeStuck".Loc(item7.ToString()));
					if (!flag)
					{
						break;
					}
				}
			}
		}
		if (flag && BlockedDoorways.Count > 0)
		{
			string message = "PathwayBlocked".Loc();
			foreach (IRoomConnector blockedDoorway in BlockedDoorways)
			{
				Transform objectTransform = blockedDoorway.ObjectTransform;
				int num = Mathf.FloorToInt((objectTransform.position.y + 1f) / 2f);
				if (!blockedDoorway.IsRefreshing && (num == GameSettings.Instance.ActiveFloor || (blockedDoorway.MovesBetweenFloors && num + 1 == GameSettings.Instance.ActiveFloor)))
				{
					flag &= WarningOverlay.AddMessages(WTS(objectTransform.position + 2f * Vector3.up), mousePosition, message);
					if (!flag)
					{
						break;
					}
				}
			}
		}
		if (flag && NoInputTemp.Count > 0)
		{
			foreach (Furniture item8 in NoInputTemp)
			{
				if (item8.Parent != null && item8.Parent.Floor == GameSettings.Instance.ActiveFloor)
				{
					string[] furniture4 = Localization.GetFurniture(item8.GetLocalizationName(), item8.GetDefaultName(), null);
					string text = ((item8.TempControlType == Furniture.TemperatureType.Cooling) ? GameSettings.Instance.CoolDep : GameSettings.Instance.HotDep);
					flag &= WarningOverlay.AddMessages(WTS(item8.transform.position + Vector3.up * item8.Height2), mousePosition, "TemperatureInputMissing".Loc(furniture4[0], text));
					if (!flag)
					{
						break;
					}
				}
			}
		}
		if (flag && BuildMode && GameSettings.Instance.ActiveFloor >= 0 && UnreachableParking.Count > 0)
		{
			string message2 = "UnreachableParking".Loc();
			foreach (RoadNode item9 in UnreachableParking)
			{
				if ((float)(GameSettings.Instance.ActiveFloor * 2 + 1) >= item9.transform.position.y)
				{
					flag &= WarningOverlay.AddMessages(WTS(item9.transform.position), mousePosition, message2);
					if (!flag)
					{
						break;
					}
				}
			}
		}
		if (flag && ConveyorNoOutput.Count > 0)
		{
			foreach (Conveyor item10 in ConveyorNoOutput)
			{
				Furniture parent = item10.Parent;
				if (parent.Parent != null && parent.Parent.Floor == GameSettings.Instance.ActiveFloor)
				{
					flag &= WarningOverlay.AddMessages(WTS(parent.transform.position + Vector3.up * parent.Height2), mousePosition, "ConveyorNoOutput".Loc());
					if (!flag)
					{
						break;
					}
				}
			}
		}
		lock (ConveyorBlocked)
		{
			if (BlockChanged)
			{
				foreach (Conveyor item11 in ConveyorBlocked)
				{
					if (!NotificationManager.CheckAggregate<ConveyorBlockedNotification>(item11.Parent))
					{
						NotificationManager.AddNotification(new ConveyorBlockedNotification(ConveyorBlocked.Select((Conveyor x) => x.Parent)));
						break;
					}
				}
				BlockChanged = false;
			}
			if (flag && ConveyorBlocked.Count > 0)
			{
				foreach (Conveyor item12 in ConveyorBlocked)
				{
					Furniture parent2 = item12.Parent;
					if (parent2.Parent != null && parent2.Parent.Floor == GameSettings.Instance.ActiveFloor)
					{
						flag &= WarningOverlay.AddMessages(WTS(parent2.transform.position + Vector3.up * parent2.Height2), mousePosition, "PartInPortError".Loc());
						if (!flag)
						{
							break;
						}
					}
				}
			}
		}
		lock (PrinterBlocked)
		{
			if (PrinterBlocked.Count > 0)
			{
				bool flag2 = true;
				foreach (ProductPrinter item13 in PrinterBlocked)
				{
					if (!(item13 != null))
					{
						continue;
					}
					item13.LastBlockTime = SDateTime.Now();
					if (flag2 && !NotificationManager.CheckAggregate<PrinterBlockedNotification>(item13.Furn))
					{
						NotificationManager.AddNotification(new PrinterBlockedNotification(PrinterBlocked.Select((ProductPrinter x) => x.Furn)));
						flag2 = false;
					}
				}
				PrinterBlocked.Clear();
			}
		}
		if (flag && FetchBlocked.Count > 0)
		{
			foreach (ProductPallet item14 in FetchBlocked)
			{
				Furniture furn = item14.Furn;
				if (furn.Parent != null && furn.Parent.Floor <= GameSettings.Instance.ActiveFloor)
				{
					flag &= WarningOverlay.AddMessages(WTS(furn.transform.position + Vector3.up * furn.Height2), mousePosition, "BlockedHelipad".Loc());
					if (!flag)
					{
						break;
					}
				}
			}
		}
		if (flag)
		{
			for (int num2 = 0; num2 < GameSettings.Instance.ProductPrinters.Count; num2++)
			{
				ProductPrinter productPrinter = GameSettings.Instance.ProductPrinters[num2];
				if ((productPrinter.InvalidOutput || (productPrinter.MissingRecycler && productPrinter.IsFinalAssembly())) && productPrinter.Furn.Floor == GameSettings.Instance.ActiveFloor && productPrinter != null)
				{
					flag &= WarningOverlay.AddMessages(WTS(productPrinter.transform.position + Vector3.up), mousePosition, productPrinter.InvalidOutput ? "ComponentOutputWrongError".Loc() : "RecyclerWarning".Loc());
					if (!flag)
					{
						break;
					}
				}
			}
		}
		WarningOverlay.EndMessageUpdate();
	}

	private Vector3 WTS(Vector3 p)
	{
		return CameraScript.Instance.SSAScript.WorldToScreenPoint(p);
	}

	public void UpdateServerWarning()
	{
		if (!BuildMode && GameSettings.Instance.UnsupportedServerItems.Count > 0)
		{
			ServerProcessWarning.SetActive(true);
		}
		else
		{
			ServerProcessWarning.SetActive(false);
		}
	}

	public void AddDrawLine(Vector3 a, Vector3 b)
	{
	}

	public void AddDebugLog(string value)
	{
	}

	private int GetIndex(float y)
	{
		int num = 0;
		float num2 = 0f;
		for (int i = 0; i < WorkItemPanel.childCount; i++)
		{
			Transform child = WorkItemPanel.GetChild(i);
			if (child.gameObject.activeSelf)
			{
				if (child.gameObject == WorkItemDrag.gameObject)
				{
					if (num2 + 132f > y)
					{
						return num;
					}
					num2 += child.GetComponent<RectTransform>().rect.height + 4f;
				}
				else
				{
					num2 += child.GetComponent<RectTransform>().rect.height + 4f;
					if (num2 > y)
					{
						return num;
					}
				}
			}
			num++;
		}
		return num;
	}

	public void WorkItemDragging()
	{
		if (DraggingWork != null)
		{
			if (!WorkItemDrag.gameObject.activeSelf)
			{
				WorkItemDrag.gameObject.SetActive(true);
				WorkItemDrag.GetComponent<LayoutElement>().minHeight = (DraggingWork.work.Collapsed ? 43 : 128);
			}
			Vector2 localPoint;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(WorkItemPanel, Input.mousePosition, UICamSize.GetUICam(), out localPoint);
			WorkItemDrag.SetSiblingIndex(GetIndex(0f - localPoint.y));
			if (!Input.GetMouseButtonUp(0))
			{
				return;
			}
			DraggingWork.transform.SetSiblingIndex(WorkItemDrag.GetSiblingIndex());
			WorkItemDrag.gameObject.SetActive(false);
			DraggingWork.gameObject.SetActive(true);
			DraggingWork = null;
			for (int i = 0; i < WorkItemPanel.childCount; i++)
			{
				GUIWorkItem component = WorkItemPanel.GetChild(i).GetComponent<GUIWorkItem>();
				if (component != null)
				{
					component.work.SiblingIndex = i;
				}
			}
			GameSettings.Instance.sActorManager.Teams.Values.ForEachEnum(delegate(Team x)
			{
				x.OrderTasks();
			});
		}
		else if (WorkItemDrag.gameObject.activeSelf)
		{
			WorkItemDrag.gameObject.SetActive(false);
		}
	}

	public void RefreshInventoryCount(string furn, int count)
	{
		Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(furn);
		if (furnitureComponent != null)
		{
			RefreshInventoryCount(furnitureComponent, count);
		}
	}

	public void RefreshInventoryCount(Furniture furn, int count)
	{
		BuildButton orNull = FurnButtons.GetOrNull(furn);
		if (orNull != null)
		{
			orNull.RefreshInventory(count);
		}
	}

	public ProductWindow GetProductWindow(string id)
	{
		if (id == null)
		{
			return productWindow;
		}
		ProductWindow value = null;
		if (!_pWindows.TryGetValue(id, out value))
		{
			value = UnityEngine.Object.Instantiate(productWindow);
			value.name = id + "ProductWindow";
			value.Window.StartHidden = false;
			value.Window.gameObject.SetActive(false);
			value.Window.WindowSizeID += id;
			value.ProductList.SpecialID = id;
			value.Init();
			value.ApplyFilters();
			value.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
			_pWindows[id] = value;
		}
		return value;
	}

	public void LogAuto(string msg, params object[] args)
	{
		AutoLog.Log(msg.LocColorAll(args));
	}

	public void ApplyProductWindowFilters()
	{
		PlayerProductWindow.RefreshPlayerItems();
		foreach (KeyValuePair<string, ProductWindow> pWindow in _pWindows)
		{
			pWindow.Value.ApplyFilters();
		}
	}

	public void UpdateDifficultyButtons()
	{
		if (!GameSettings.Instance.CampaignMode)
		{
			BottomDealButton.SetActive(GameSettings.Instance.Difficulty.Deals > 0.5f);
			BottomContractButton.SetActive(GameSettings.Instance.Difficulty.Contracts > 0.5f);
			BottomLoanButton.SetActive(GameSettings.Instance.Difficulty.Loans > 0.5f);
			bool activeSelf = MainContentPanel.gameObject.activeSelf;
			MainContentPanel.gameObject.SetActive(true);
			ForceUpdateLayoutGroups(MainBottomButtonPanel);
			UpdateButtonCounterPositions();
			MainContentPanel.gameObject.SetActive(activeSelf);
		}
	}

	public void UpdateButtonCounterPositions()
	{
		StartCoroutine(UpdateButtonCounterPositionsSub());
	}

	private IEnumerator UpdateButtonCounterPositionsSub()
	{
		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();
		for (int i = 0; i < ButtonCounters.Count; i++)
		{
			ButtonCounters[i].UpdatePosition();
		}
	}

	private void ForceUpdateLayoutGroups(Transform t)
	{
		for (int i = 0; i < t.childCount; i++)
		{
			ForceUpdateLayoutGroups(t.GetChild(i));
		}
		LayoutGroup component;
		if (t.TryGetComponent<LayoutGroup>(out component))
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(component.GetComponent<RectTransform>());
		}
	}
}
