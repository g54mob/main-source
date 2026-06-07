using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using App.Data;
using Aux;
using DeepTraffic;
using Localization;
using ReinforcementLearning.Environment;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class Construction : ActiveComponent
{
	public class BlockInScheme
	{
		private BlockData bd;

		private BaseBlock bb;

		public GameObject go;

		public GameObject pov;

		public float povShift;

		public int keyhash;

		public string keyname;

		public BlockInScheme(ConstructionBlock block)
		{
			pov = ActiveComponent.Model.GetGameObjectFromPool(ActiveComponent.Model.construction.blockPov, Vector3.zero, Quaternion.identity, ActiveComponent.Model.construction.algoBlockDrag);
			pov.transform.localScale = Vector3.one;
			if (block != null)
			{
				pov.GetComponent<Image>().color = Logic.GetColor(block.Type);
			}
			else
			{
				pov.GetComponent<Image>().color = Logic.GetColor("UTILITY");
			}
			pov.SetActive(value: false);
			povShift = pov.GetComponent<RectTransform>().rect.height;
		}

		public void SetKeyName(string kname)
		{
			keyhash = kname.GetHashCode();
			keyname = kname;
		}

		public void SetParent(Transform parent, bool worldPositionStays = true)
		{
			go.transform.SetParent(parent, worldPositionStays);
			go.transform.localScale = Vector3.one;
		}

		public void SetParent(GameObject block, bool worldPositionStays = true)
		{
			SetParent(block.transform, worldPositionStays);
			go.transform.localScale = Vector3.one;
		}

		public void SetParent(BlockInScheme block, bool worldPositionStays = true)
		{
			SetParent(block.go, worldPositionStays);
			go.transform.localScale = Vector3.one;
		}

		public Transform GetParent()
		{
			return go.transform.parent;
		}

		private bool IsBlockVisibleInConstructionArea()
		{
			Vector3[] array = new Vector3[4];
			go.GetComponent<RectTransform>().GetWorldCorners(array);
			Rect worldRect = Helper.GetWorldRect(ActiveComponent.Model.construction.constrBlock);
			Vector3[] array2 = array;
			foreach (Vector3 point in array2)
			{
				if (worldRect.Contains(point))
				{
					pov.gameObject.SetActive(value: false);
					return true;
				}
			}
			pov.gameObject.SetActive(value: true);
			return false;
		}

		public void ResetPOV()
		{
			if (!IsBlockVisibleInConstructionArea())
			{
				SetBlockPOVOnBorder();
			}
		}

		private void SetBlockPOVOnBorder()
		{
			Rect worldRect = Helper.GetWorldRect(ActiveComponent.Model.construction.constrBlock);
			float num = 2.1474836E+09f;
			if (go.transform.position.x < worldRect.xMin)
			{
				num = Math.Min(num, Mathf.Abs((ActiveComponent.Model.construction.constrBlock.transform.position.x - worldRect.xMin) / (go.transform.position.x - ActiveComponent.Model.construction.constrBlock.transform.position.x)));
			}
			if (go.transform.position.x > worldRect.xMax)
			{
				num = Math.Min(num, Mathf.Abs((ActiveComponent.Model.construction.constrBlock.transform.position.x - worldRect.xMax) / (go.transform.position.x - ActiveComponent.Model.construction.constrBlock.transform.position.x)));
			}
			if (go.transform.position.y > worldRect.yMax)
			{
				num = Math.Min(num, Mathf.Abs((ActiveComponent.Model.construction.constrBlock.transform.position.y - worldRect.yMax) / (go.transform.position.y - ActiveComponent.Model.construction.constrBlock.transform.position.y)));
			}
			if (go.transform.position.y < worldRect.yMin)
			{
				num = Math.Min(num, Mathf.Abs((ActiveComponent.Model.construction.constrBlock.transform.position.y - worldRect.yMin) / (go.transform.position.y - ActiveComponent.Model.construction.constrBlock.transform.position.y)));
			}
			Vector3 position = (go.transform.position - ActiveComponent.Model.construction.constrBlock.transform.position) * num + ActiveComponent.Model.construction.constrBlock.transform.position;
			position.z = 0f;
			Helper.Rotate(ActiveComponent.Model.construction.constrBlock.transform.position, go.transform.position, pov.transform);
			pov.transform.position = position;
			pov.transform.localScale = Vector3.one * (1f / pov.transform.parent.localScale.x);
		}

		public int GetParentChildIndex()
		{
			Transform parent = GetParent();
			for (int i = 0; i < parent.childCount; i++)
			{
				if (parent.GetChild(i) == go.transform)
				{
					return i;
				}
			}
			return -1;
		}

		public void SetPosition(Vector3 pos)
		{
			pos.z = 0f;
			if (!(go == null))
			{
				go.transform.position = pos;
			}
		}

		public void SetPosition(BlockInScheme block)
		{
			SetPosition(block.go.transform.position);
		}

		public Vector3 GetPosition()
		{
			if (go == null)
			{
				return Vector3.zero;
			}
			if (go.transform == null)
			{
				return Vector3.zero;
			}
			return go.transform.position;
		}

		public int GetUniqueHash()
		{
			return BlockData().GetUniqueHash();
		}

		public void ConnectTo(int srcFlags, BlockInScheme destBlock, int destFlags, BlockInScheme realBlockIn, BlockInScheme realBlockOut)
		{
			BlockData blockData = BlockData();
			BlockData destBlock2 = destBlock.BlockData();
			blockData.ConnectTo(srcFlags, destBlock2, destFlags, realBlockIn.BlockData(), realBlockOut.BlockData());
		}

		public void Destroy(bool deleteChains = true, bool invoke = true)
		{
			if (deleteChains)
			{
				DeleteChains(invoke);
			}
			go.GetComponent<BlockData>().ClearBeforeDelete();
			if (!Logic.IsBaseBlock(go.name))
			{
				go.name = "CUSTOM";
			}
			ActiveComponent.Model.DisableBaseBlockObj(go.GetComponent<BaseBlock>());
			ActiveComponent.Model.DisableGameObj(pov);
			go = null;
			pov = null;
		}

		public void HideChains(bool state = true)
		{
			Socket[] componentsInChildren = go.transform.GetComponentsInChildren<Socket>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].HideChains(state);
			}
		}

		public void DeleteChains(bool invoke)
		{
			Socket[] componentsInChildren = go.transform.GetComponentsInChildren<Socket>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].DeleteChains(invoke);
			}
		}

		public BlockData BlockData()
		{
			if (bd != null)
			{
				return bd;
			}
			bd = go.GetComponent<BlockData>();
			return bd;
		}

		public BaseBlock BaseBlock()
		{
			if (bb != null)
			{
				return bb;
			}
			bb = go.GetComponent<BaseBlock>();
			return bb;
		}

		public bool CanBeCopied()
		{
			return BlockData().CanBeCopied();
		}
	}

	public class SchemeStack
	{
		public class Entry
		{
			public string keyName;

			public BaseQuest quest;

			public ConstructionState state;

			public Entry(ConstructionState s, BaseQuest q, string n)
			{
				state = s;
				keyName = n;
				quest = q;
			}

			public BaseQuest GetBaseQuest()
			{
				return quest;
			}

			public T GetQuest<T>() where T : BaseQuest
			{
				return (T)quest;
			}

			public bool IsQuest<T>()
			{
				return quest is T;
			}
		}

		public List<Entry> coll = new List<Entry>();

		public void Push(ConstructionState state, BaseQuest quest, string keyName)
		{
			coll.Add(new Entry(state, quest, keyName));
		}

		public Entry Pop()
		{
			Entry result = coll.LastItem();
			coll.RemoveAt(coll.Count - 1);
			return result;
		}

		public Entry Top()
		{
			return coll.LastItem();
		}

		public bool IsEmpty()
		{
			return coll.Count == 0;
		}

		public int GetCount()
		{
			return coll.Count;
		}

		public void Clear()
		{
			coll.Clear();
		}
	}

	public struct DeepTrafficInitArgs
	{
		public Func<int, CellObjects, System.Random, int> DataEncoder;

		public Action<int> NextCallback;

		public float MoneyPerSec;
	}

	public enum Info
	{
		ShowProgressAndSaveName = 0,
		ShowOnlySaveName = 1,
		ShowOnlyProgress = 2,
		ShowNothing = 3
	}

	private enum HelpInfoState
	{
		Error = 0,
		Good = 1,
		GoodBad = 2
	}

	public enum DragInteraction
	{
		None = 0,
		ConstrArea = 1,
		Block = 2
	}

	public enum OneTouchState
	{
		Normal = 0,
		Long = 1,
		FailedLong = 2
	}

	public const float BlockZ = 0f;

	private Button AlgoButton;

	[SceneBind("TestTrainButtons")]
	private RectTransform trainTestButtonBox;

	[SceneBind("FactoryHolder")]
	public RectTransform FactoryHolder;

	[SceneBind("TestTrainButtons/TestButton")]
	public Button TestButton;

	[SceneBind("TestTrainButtons/TrainButton")]
	private Button TrainButton;

	[SceneBind("TestTrainButtons/TestAfterTrain")]
	private Button TestAfterTrain;

	[SceneBind("TestTrainButtons/TestFirst")]
	private Button TestFirst;

	[SceneBind("Tune")]
	public Button TuneButton;

	[SceneBind("TuneReleased")]
	public Button TuneReleasedButton;

	[SceneBind("SaveReleasedWithTune")]
	public Button SaveReleasedWithTuneButton;

	[SceneBind("NextButton")]
	private Button nextButton;

	[SceneBind("ChangeList")]
	private Image ChangeList;

	[SceneBind("ChangeList/Slider")]
	private Slider NodesSlider;

	[SceneBind("ChangeList/StatusText")]
	private Text StatusText;

	[SceneBind("SpeedLayerMobile")]
	public RectTransform SpeedLayerMobile;

	[SceneBind("SpeedLayer/PlusTime")]
	public Button PlusSpeed;

	[SceneBind("SpeedLayer/MinusTime")]
	public Button MinusSpeed;

	[SceneBind("SpeedLayer/Speed")]
	private Text Speed;

	[SceneBind("SpeedLayer/Speed")]
	private Button PauseBtn;

	[SceneBind("ZoomPlus")]
	private Button ZoomPlus;

	[SceneBind("ZoomMinus")]
	private Button ZoomMinus;

	[SceneBind("ZoomPlusDisabled")]
	private Image ZoomPlusDisabled;

	[SceneBind("ZoomMinusDisabled")]
	private Image ZoomMinusDisabled;

	[SceneBind("CtrlV")]
	private Button CtrlV;

	[SceneBind("CtrlC")]
	private Button CtrlC;

	[SceneBind("TaskId")]
	private Text TaskId;

	[SceneBind("DeepTrafficQuestController/TaskIdCar")]
	private Text DeepTrafficQuestControllerTaskId;

	[SceneBind("SchemeName")]
	public InputField SchemeName;

	[SceneBind("Filter")]
	private InputField Filter;

	[SceneBind("SchemeNameText")]
	private Text SchemeNameText;

	[SceneBind("Deploy")]
	public Button DeployBtn;

	[SceneBind("Deploy/Text")]
	public Text DeployBtntext;

	[SceneBind("Sandbox")]
	private Button buttonSandbox;

	[SceneBind("ExitButton")]
	public Button buttonExit;

	[SceneBind("SaveSheme")]
	private Button SaveScheme;

	[SceneBind("ConstructionBlock")]
	public RectTransform constrBlock;

	[SceneBind("DarkLayerHideAlgoBlock")]
	public RectTransform darkLayerHideAlgoBlock;

	[SceneBind("ConstructionBlock")]
	public Button constrBlockBtn;

	[SceneBind("ConstructionBlock/BoundHolder")]
	private Transform shiftOnlyBounds;

	[SceneBind("AlgoBlock")]
	public RectTransform algoBlock;

	[SceneBind("AlgoBlockDrag")]
	public RectTransform algoBlockDrag;

	[SceneBind("ConstructionBlockPopups")]
	public RectTransform constructionBlockPopups;

	[SceneBind("ConstructionBlockPopups/LongTapMenu")]
	public RectTransform LongTapMenu;

	[SceneBind("ConstructionBlockPopups/LongTapMenu/Paste")]
	public Button MobilePaste;

	[SceneBind("ConstructionBlockPopups/LongTapMenu/Copy")]
	public Button MobileCopy;

	[SceneBind("ConstructionBlockPopups/LongTapMenu/All")]
	public Button MobileSelectAll;

	[SceneBind("AlgoBlockImg")]
	public RectTransform algoBlockImg;

	private Vector3 algoBlockParentPosition;

	public Transform algoBlockParent;

	public RectTransform algoBlockRectTransform;

	[SceneBind("DATA_RESULTS")]
	private RectTransform dataResults;

	[SceneBind("DATA_RESULTS/Datas")]
	private RectTransform datasContainers;

	[SceneBind("DATA_RESULTS/Results")]
	private RectTransform resultsContainer;

	[SceneBind("BaseBlock")]
	private RectTransform baseBlock;

	[SceneBind("BaseBlock/Scroll View/Scrollbar Vertical")]
	private Scrollbar baseBlockScrollBar;

	[SceneBind("BaseBlock")]
	private ScrollRect baseBlockRect;

	[SceneBind("HelpBlock")]
	private Image helpBlock;

	[SceneBind("TooManyNodesDrag")]
	private Image TooManyNodesDrag;

	[SceneBind("TooManyNodesDrag/Ok")]
	private Button CloseTooManyNodesDrag;

	[SceneBind("TooManyNodesDrag/Toggle")]
	private Toggle ToggleTooManyNodesDrag;

	[SceneBind("HelpBlock/Warning_null/Cat_warning")]
	private Image CatWarningHelp;

	[SceneBind("HelpBlock/Warning_null/Cat_good")]
	private Image CatWarningGood;

	[SceneBind("HelpBlock/Warning_null/Cat_good_bad")]
	private Image CatWarningGoodBad;

	[SceneBind("SaveBlock")]
	public Image saveBlock;

	[SceneBind("NextExit")]
	public Image exitNext;

	[SceneBind("Medal")]
	private MedalController Medal;

	[SceneBind("Blocker")]
	private RectTransform blocker;

	[SceneBind("TutorialWindow")]
	private Image TutorialWindow;

	[SceneBind("ShowSaveImage")]
	private Image ShowSaveImage;

	[SceneBind("AttentionClear")]
	private Image AttentionClear;

	[SceneBind("AttentionClear/AcceptClearBtn")]
	private Button AcceptClearBtn;

	[SceneBind("AttentionClear/CancelClearBtn")]
	private Button CancelClear;

	[SceneBind("AcceptDeploy")]
	private Image AcceptDeploy;

	[SceneBind("AcceptDeploy/AcceptDeployBtn")]
	private Button AcceptDeployBtn;

	[SceneBind("AcceptDeploy/CancelDeployBtn")]
	private Button CancelDeployBtn;

	[SceneBind("AcceptDeploy/Hide")]
	private Toggle HideDeployAttention;

	[SceneBind("AcceptDeployStartup")]
	private Image AcceptDeployStartup;

	[SceneBind("AcceptDeployStartup/AcceptDeployBtn")]
	private Button AcceptDeployStartupBtn;

	[SceneBind("AcceptDeployStartup/CancelDeployBtn")]
	private Button CancelDeployStartupBtn;

	[SceneBind("AcceptDeployStartup/Hide")]
	private Toggle HideStartupAttention;

	[SceneBind("AcceptDeploy/LockHide")]
	public Image LockHide;

	[SceneBind("Values")]
	private Text Values;

	[SceneBind("StaticServ")]
	private Text StaticServ;

	[SceneBind("StaticReward")]
	private Text StaticReward;

	[SceneBind("DynamicMoney")]
	private Text DynamicMoney;

	[SceneBind("BlockLimit")]
	private Text BlockLimit;

	[SceneBind("CustomBlockLimit")]
	private Text CustomBlockLimit;

	[SceneBind("ServersLimit")]
	private Text ServersLimit;

	[SceneBind("MoneySpent")]
	private Text MoneySpent;

	[SceneBind("UsersDay")]
	private Text UsersDay;

	[SceneBind("AvDestTime")]
	private Text AvDestTime;

	[SceneBind("Money")]
	private Text Money;

	[SceneBind("DynamicTime")]
	private Text DynamicTime;

	[SceneBind("BonusLayer/ChainSpeed")]
	private Text ChainSpeed;

	[SceneBind("BonusLayer/BlocksSpeed")]
	private Text BlocksSpeed;

	[SceneBind("BonusLayer/ServersCost")]
	private Text BonusServersCost;

	[SceneBind("BonusLayer/SocketDepth")]
	private Text SocketDepth;

	[SceneBind("Iter")]
	private Text iterText;

	[SceneBind("MoneyValue")]
	private Text moneyValue;

	[SceneBind("CurTaskText")]
	private Text CurTaskText;

	[SceneBind("StopButton")]
	public Button StopButton;

	[SceneBind("ClearAll")]
	public Button ClearAll;

	[SceneBind("SelectAll")]
	public Button SelectAllBtn;

	[SceneBind("Undo")]
	public Button Undo;

	[SceneBind("Redo")]
	public Button Redo;

	[SceneBind("RedoMobile")]
	public Button RedoMobile;

	[SceneBind("CustomBlockLayer")]
	public Image CustomBlockLayer;

	[SceneBind("BaseBlockLayer")]
	public Image BaseBlockLayer;

	[SceneBind("LibraryBlockLayer")]
	public Image LibraryBlockLayer;

	[SceneBind("BaseBlockBtn")]
	public Button BaseBlockBtn;

	[SceneBind("CustomBlockBtn")]
	public Button CustomBlockBtn;

	[SceneBind("LibraryBlockBtn")]
	public Button LibraryBlockBtn;

	[SceneBind("SaveBtn")]
	public Button SaveBtn;

	[SceneBind("SpeedLayer")]
	public Image SpeedLayer;

	[SceneBind("SavingConstr")]
	public RectTransform Saving;

	[SceneBind("QuestResult")]
	public QuestRunResult QuestResult;

	[SceneBind("BlockTutorial")]
	public BlockTutuorial BlockTutuorial;

	[SceneBind("BlockTutorial/NewBlock")]
	public Image NewBlockTutorialIndicator;

	[SceneBind("CustomTurorialWindow")]
	public TutorialList CustomTutorialWindow;

	[SceneBind("StartupTrainTutorial")]
	public TutorialList StartupTrainTutorial;

	[SceneBind("StartupComicsTutorial")]
	public TutorialList StartupComicsTutorial;

	[SceneBind("CustomTurorialGeneticWindow")]
	public TutorialList CustomTurorialGeneticWindow;

	[SceneBind("PressStopStartupTutorial")]
	public RectTransform PressStopStartupTutorial;

	[SceneBind("DLLTutorial")]
	public TutorialList DLLTutorialWindow;

	[SceneBind("FirstNonForumQuestTutorial")]
	public TutorialList firstNonForumQuestTutorialWindow;

	[SceneBind("StartupTutorialWindow")]
	public TutorialList StartupTutorialWindow;

	[SceneBind("BonusLayer")]
	private Image BonusLayer;

	[SceneBind("HelpBlock/Ok")]
	private Button HelpOk;

	[SceneBind("BasicTutorials")]
	public BasicTutorials BasicTutorials;

	[SceneBind("BasicTutorials/StartDragWindow/PlaceNode")]
	public RectTransform PlaceNodeTutorial;

	[SceneBind("CatHubRadio")]
	private ToggleGroup CatHubRadio;

	[SceneBind("CatHubStartupRadio")]
	private ToggleGroup CatHubStartupRadio;

	[SceneBind("CatHubTutorial")]
	private TutorialList CatHubTutorial;

	[SceneBind("MedalTutorial")]
	private TutorialList MedalTutorial;

	[SceneBind("SandboxTutorial")]
	private TutorialList SandboxTutorial;

	[SceneBind("SandboxTrainableTutorial")]
	private TutorialList SandboxTrainableTutorial;

	[SceneBind("LidarSchemeTutorial")]
	private TutorialList LidarSchemeTutorial;

	[SceneBind("ElemsHierTutorial")]
	private TutorialList ElemsHierTutorial;

	[SceneBind("MutationTutorial")]
	public TutorialList MutationTutorial;

	[SceneBind("LidarTutorial")]
	public TutorialList LidarTutorial;

	[SceneBind("MutationRateTutorial")]
	public TutorialList MutationRateTutorial;

	[SceneBind("GeneticPopulationSizeTutorial")]
	public TutorialList GeneticPopulationTutorial;

	[SceneBind("MeetTheMLTutorial")]
	public TutorialList MeetTheMLTutorial;

	[SceneBind("CrossoverTutorial")]
	public TutorialList CrossoverTutorial;

	[SceneBind("ErrorTutorial")]
	private TutorialList ErrorTutorial;

	[SceneBind("TimeTutorial")]
	private TutorialList TimeTutorial;

	[SceneBind("MemoryTutorial")]
	private TutorialList MemoryTutorial;

	[SceneBind("ServersTutorial")]
	private TutorialList ServersTutorial;

	[SceneBind("SpeedTutorial")]
	private TutorialList SpeedTutorial;

	[SceneBind("CopyTutorial")]
	private TutorialList CopyTutorial;

	[SceneBind("LastEpochReachedTutorial")]
	public TutorialList LastEpochReachedTutorial;

	[SceneBind("LastEpochReachedTutorial/Page1/Tutorial_null/Ok")]
	public Button LastEpochReachedTutorialClose;

	[SceneBind("OccAndAccTimerTutorial")]
	private TutorialList MaintainAccLevelTutorial;

	[SceneBind("StopTrainingAttentionLastEpoch")]
	public RectTransform StopTrainingAttentionLastEpoch;

	[SceneBind("StopTrainingAttentionLastEpoch/Accept")]
	private Button StopTrainingAttentionLastEpochAccept;

	[SceneBind("OccAndAccTutorial")]
	private TutorialList OccAndAccTutorial;

	[SceneBind("PressTrainAfterTeachTutorial")]
	public TutorialList PressTrainAfterTeachTutorial;

	[SceneBind("PressTestAfterTeachTutorial")]
	public TutorialList PressTestAfterTeachTutorial;

	[SceneBind("SandboxLayer")]
	private Image sandboxLayer;

	[SceneBind("BaseBlock/Scroll View/Viewport/BlocksContent/GoToDLLBlock")]
	private RectTransform GoToDLLBlock;

	[SceneBind("BaseBlock/Scroll View/Viewport/BlocksContent/GoToDLLBlock/GoToDLL")]
	private Button GoToDLLBtn;

	[SceneBind("CarQuestResult")]
	private CarQuestResultController carQuestResult;

	[SceneBind("DeepTrafficQuestController")]
	public DeepTrafficQuestController deepTrafficQuestController;

	[SceneBind("DeepTrafficQuestController/DeepTrafficGameController")]
	private RectTransform deepTrafficGameController;

	[SceneBind("DeepTrafficQuestController/LeftBackground")]
	private RectTransform LeftBackground;

	public List<CathubBtn> catHubs = new List<CathubBtn>();

	public UnityEvent startDragEvent = new UnityEvent();

	public UnityEvent endDragEvent = new UnityEvent();

	public UnityEvent startDrawLineEvent = new UnityEvent();

	public UnityEvent endDrawLineEvent = new UnityEvent();

	public UnityEvent deleteEvent = new UnityEvent();

	public UnityEvent testEvent = new UnityEvent();

	public UnityEvent releaseEvent = new UnityEvent();

	public UnityEvent stopEvent = new UnityEvent();

	public UnityEvent testSuccessEvent = new UnityEvent();

	public UnityEvent releaseSucessEvent = new UnityEvent();

	private List<Button> buttonBlocks = new List<Button>();

	private List<GameObject> showBlocks = new List<GameObject>();

	public List<SandboxObjController> sandboxList = new List<SandboxObjController>();

	private List<GameObject> ConstructBlockObjects;

	public Dictionary<int, GameObject> prefabs = new Dictionary<int, GameObject>();

	public List<Sprite> medals = new List<Sprite>();

	private GameObject blockPov;

	public bool testMode;

	public bool testCompleted;

	public bool isPenNow;

	public Vector3 penDelta;

	private bool _trainable;

	public List<BlockInScheme> blocksInScheme = new List<BlockInScheme>();

	public Dictionary<GameObject, BlockInScheme> objToBlockMap = new Dictionary<GameObject, BlockInScheme>();

	public GameObject lastAttached;

	public GameObject attached;

	public GameObject chain;

	private GameObject customBlock;

	public bool Deploy;

	public bool Complete;

	private GameObject BlockSpawn;

	private Rect blockRect = Rect.zero;

	private GameObject BlocksContent;

	private RectTransform blocksContentRect;

	private float baseBlocksHeight;

	private int skipFrames;

	private ContentSizeFitter sizeFilter;

	private VerticalLayoutGroup layoutGroup;

	private Text rent;

	private NodesState nodesState;

	public float SpeedCoef;

	private List<GameObject> BlocksList = new List<GameObject>();

	private GameObject currentChain;

	public List<Data> datas;

	public List<Result> results;

	private int curBlocks;

	private bool Sandbox;

	private RedrawEnum resetRedraw = RedrawEnum.States;

	private bool updateRedraw;

	private float scaleX = 1f;

	private float scaleY = 1f;

	public float predictMoneyInDeploy;

	public GameObject draggingParent;

	public bool selectionMode;

	private Vector2 selectionStart;

	private Vector2 selectionEnd;

	private Rect selectionRect;

	private Rect selectionBox;

	private readonly Vector2 selectionMargin = Vector2.one * -2f;

	public List<BlockInScheme> selectedBlocks = new List<BlockInScheme>();

	private BlockInScheme selectionParent;

	public ConstructionState constrState;

	public SchemeStack schemeStack = new SchemeStack();

	private string startupTask;

	public bool recordingAllowed = true;

	private Camera cam;

	private string img = "";

	private List<Dictionary<int, float>[]> stochasticMatrix = new List<Dictionary<int, float>[]>();

	private List<int[]> trueCellObjectCounts = new List<int[]>();

	public bool save;

	public float saveTimer;

	public bool AutoSaved;

	private Vector3 addDragPosition;

	public float minConditionTime;

	public int soundIteratorBeforeFail = 3;

	private bool redrawChain = true;

	private bool prevTestBtnStatus;

	private bool prevTrainBtnStatus;

	private bool prevTuneBtnStatus;

	private bool prevDeployBtnStatus;

	private bool prevTestFirstBtnStatus;

	private bool prevTestAfterTrainBtnStatus;

	private bool firstTestTick;

	private QuestLine.Quest curQuestlineQuest;

	private ConstructionQuest curTableQuest;

	private int curOpenSheme;

	private float moneyCoef;

	public bool end = true;

	public int elementsOnLines;

	public bool pause;

	private bool testTrain;

	private float timeInStartup;

	private bool waitTutorial;

	private float screenWidth;

	private static float xMinConstrBlock;

	private static float xMaxConstrBlock;

	private static float yMinConstrBlock;

	private static float yMaxConstrBlock;

	private int curIter;

	private float helpTimer;

	private float helpDelay;

	public int couTest;

	public int schemeCapacity;

	public QuestCondition curCondition;

	public int rememberedConditionId;

	public float curSpendMoney;

	public float moneyPerSecond;

	public int moneySpended;

	public float timer;

	private float realMoneyPerSecond;

	public float curMoneyPerSecond;

	private List<BlockInScheme> blockHierarchy = new List<BlockInScheme>();

	private bool prevMouseOnEmptyField;

	private float autoSaveTimer;

	private bool replayMode;

	private float replaySpeed = 1f;

	private float replayTimer;

	private Rect algoInRect;

	private Rect algoRect;

	private bool algoRectInited;

	public float DragSensibility = 5f;

	private bool longAction;

	public float moveCoef = 0.5f;

	public float zoomCoef = 2f;

	private bool waitingDropdown;

	private bool movedArea;

	private bool wasTripleTap;

	public DragInteraction interactState;

	private float oneTouchTimer;

	private Vector3 startOneFingerPosition = Vector3.zero;

	public OneTouchState longTap;

	private List<string> currentResults = new List<string>();

	public float helpStopTimer = 3f;

	public float startupTutorialTimer;

	private bool rightBtn;

	private Vector3 middlePos;

	private BlockCopyPaster blockCopyPaster;

	public Transform draggingParentBlock;

	private bool pasteInCenter;

	private bool Trainable
	{
		get
		{
			return _trainable;
		}
		set
		{
			if (_trainable ^ value)
			{
				if (value)
				{
					SetObjectWidth(TestButton.gameObject, (0f - trainTestButtonBox.sizeDelta.x) / 2f - 2f);
				}
				else
				{
					SetObjectWidth(TestButton.gameObject, 0f);
				}
			}
			TrainButton.gameObject.SetActive(value);
			_trainable = value;
		}
	}

	public bool WaitTutorial
	{
		get
		{
			return waitTutorial;
		}
		set
		{
			waitTutorial = value;
		}
	}

	private float ZoomStrength => ActiveComponent._staticData.Settings.ZoomStrength;

	private void SetObjectWidth(GameObject button, float width)
	{
		RectTransform component = button.GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		sizeDelta.x = width;
		component.sizeDelta = sizeDelta;
	}

	public bool IsTraining()
	{
		if (ActiveComponent.Model.trainTest)
		{
			return ActiveComponent.Model.construction.testMode;
		}
		return false;
	}

	private void SetInfinityDynamicTime()
	{
		string[] array = DynamicTime.text.Split();
		DynamicTime.text = array[0].Substring(0, array[0].LastIndexOf('>') + 1) + "<size=24>∞</size></color>";
	}

	public BlockInScheme GetBlockInSchemeFromGO(GameObject go)
	{
		if (!objToBlockMap.TryGetValue(go, out var value))
		{
			return null;
		}
		return value;
	}

	public GameObject AddBlockToScheme(BlockInScheme bis)
	{
		blocksInScheme.Add(bis);
		objToBlockMap.Add(bis.go, bis);
		return bis.go;
	}

	public bool RemoveBlockFromScheme(BlockInScheme bis, bool destroyBlock = true)
	{
		int num = blocksInScheme.FindIndex((BlockInScheme b) => b == bis);
		if (num >= 0)
		{
			objToBlockMap.Remove(bis.go);
			blocksInScheme.RemoveAt(num);
			List<BlockInScheme> list = new List<BlockInScheme>();
			foreach (BlockInScheme item in blocksInScheme)
			{
				if (item.go.transform.parent == bis.go.transform)
				{
					list.Add(item);
				}
			}
			foreach (BlockInScheme item2 in list)
			{
				RemoveBlockFromScheme(item2);
			}
			if (IsBasciTutorialsOpen())
			{
				deleteEvent.Invoke();
			}
			if (destroyBlock)
			{
				bis.Destroy();
			}
			return true;
		}
		return false;
	}

	public void ClearBlockScheme()
	{
		blocksInScheme.Clear();
		objToBlockMap.Clear();
	}

	public bool IsInConstructionMode()
	{
		if (!MessageBox.IsVisible() && !deepTrafficQuestController.gameObject.activeInHierarchy && !helpBlock.gameObject.activeInHierarchy && !QuestResult.gameObject.activeInHierarchy && !ActiveComponent._controller.newspaper.gameObject.activeInHierarchy && !BlockTutuorial.gameObject.activeInHierarchy && !CustomTutorialWindow.gameObject.activeInHierarchy && !DLLTutorialWindow.gameObject.activeInHierarchy && !AttentionClear.gameObject.activeInHierarchy && !AcceptDeploy.gameObject.activeInHierarchy && !AcceptDeployStartup.gameObject.activeInHierarchy && !WaitTutorial && !TooManyNodesDrag.gameObject.activeInHierarchy && !BasicTutorials.IsActive())
		{
			return !StartupComicsTutorial.gameObject.activeInHierarchy;
		}
		return false;
	}

	public bool IsInConstructionGameMode()
	{
		if (!testMode && !replayMode)
		{
			return IsInConstructionMode();
		}
		return false;
	}

	public int GetIdLinkByGameObject(GameObject go)
	{
		return blocksInScheme.FindIndex((BlockInScheme i) => i.go == go);
	}

	public void ExitClick()
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf && schemeStack.GetCount() == 1)
		{
			base.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(ExitClick);
			return;
		}
		if (ActiveComponent.Model.constructionState == ConstructionState.Startup && schemeStack.GetCount() == 1)
		{
			ActiveComponent.Model.curStartupInWork.timeInStartup += timeInStartup;
			ActiveComponent.Model.curStartupInWork.patch++;
			Logic.SendAnalytics("CONSTRUCTION_STARTUP_PATCH", new Dictionary<string, object>
			{
				{
					"keyName",
					ActiveComponent.Model.curStartupInWork.baseStartup.KeyName
				},
				{
					"patches",
					ActiveComponent.Model.curStartupInWork.patch
				},
				{
					"blocks used",
					GetBlocksCou()
				},
				{
					"servers used",
					GetServersCouInSheme()
				},
				{
					"test runs",
					ActiveComponent.Model.curStartupInWork.testRunsInStartup
				},
				{ "time in this edit", timeInStartup },
				{
					"global time in startup",
					ActiveComponent.Model.curStartupInWork.timeInStartup
				},
				{
					"custom blocks",
					GetCustomBlocksInScheme()
				},
				{
					"catHubs",
					GetNumValidCatHubs()
				}
			});
			timeInStartup = 0f;
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		GetCurCathub().ClearHistory();
		ClearBlockCopyPaster();
		if (schemeStack.GetCount() > 1)
		{
			schemeStack.Pop();
			SchemeStack.Entry entry = schemeStack.Top();
			ActiveComponent.Model.SandboxOpen = entry.keyName;
			OpenWindowInit(QuestLine.GetQuest(entry.keyName), replay: false, customBlockOpened: false, entry.keyName, addToSchemeStack: false);
			return;
		}
		Time.timeScale = 1f;
		AcceptDeployStartup.gameObject.SetActive(value: false);
		if (IsInNormalTaskRunMode())
		{
			if (nodesState != NodesState.Base)
			{
				ShowBaseClick();
			}
			if (!QuestLine.GetCurrentQuest().IsCompleted())
			{
				AutoSave();
			}
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			QuestResult.gameObject.SetActive(value: false);
			ClearCanvasScheme();
			Time.timeScale = 1f;
			ActiveComponent._controller._resourcesView.InitRedraw();
		}
		else
		{
			AutoSaveDelay();
		}
		ClearBlockCopyPaster();
		if (constrState == ConstructionState.SandBox)
		{
			ClearCanvasScheme();
			Time.timeScale = 1f;
			ActiveComponent._controller._resourcesView.InitRedraw();
		}
		ClearCanvasScheme();
		ClearEnds();
		end = true;
		schemeStack.Clear();
		QuestLine.GetCurrentQuest().GetBaseQuest().End();
		base.gameObject.SetActive(value: false);
		ActiveComponent.Sound.ActiveMusic("Monokanal/WhileTrueLearn_Music_For_Gameplay");
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", ActiveComponent.Model.globalSaves.soundVolume);
		ActiveComponent.Model.ClearBaseBlocksPool();
		ActiveComponent._controller.RedrawBackgrounds();
	}

	private void DeleteObjectChains(GameObject go, bool invoke)
	{
		Socket[] componentsInChildren = go.transform.GetComponentsInChildren<Socket>();
		foreach (Socket socket in componentsInChildren)
		{
			if (socket.chain != null)
			{
				socket.DeleteChains(invoke);
			}
		}
	}

	private void DeleteChainLayerClick()
	{
		if (currentChain != null)
		{
			Chain component = currentChain.GetComponent<Chain>();
			component.ClearBeforeDelete();
			ActiveComponent.Model.DisableChainObj(component);
			RedrawAllSockets();
		}
	}

	public void ClearCanvasScheme(bool sendDeleteEvent = false)
	{
		ActiveComponent.Program.cursor.HideAndResetCanvas();
		DropSelection(ignoreConditions: true);
		curBlocks = 0;
		foreach (BlockInScheme item in blocksInScheme)
		{
			item.Destroy();
		}
		foreach (Data data in datas)
		{
			DeleteObjectChains(data.gameObject, invoke: false);
		}
		foreach (Result result in results)
		{
			DeleteObjectChains(result.gameObject, invoke: false);
		}
		ClearBlockScheme();
		Chain[] componentsInChildren = base.gameObject.GetComponentsInChildren<Chain>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].DestroyGameObject();
		}
		if (BasicTutorials.gameObject.activeSelf && sendDeleteEvent)
		{
			deleteEvent.Invoke();
		}
	}

	private GameObject GetGOByKeyName(string KeyName)
	{
		GameObject gameObject = ConstructBlockObjects.Find((GameObject i) => i.name == KeyName);
		if (!gameObject)
		{
			return customBlock;
		}
		return gameObject;
	}

	private void ToggleTestReleaseLaunchButtons()
	{
		Helper.SetVisibility("Deploy", Helper.Visibility.Toggle);
		Helper.SetVisibility("Filter", Helper.Visibility.Toggle);
		Text child = Helper.GetChild<Text>(Helper.SetVisibility("Launch", Helper.Visibility.Toggle), 0);
		if ((bool)child)
		{
			child.text = "Launch";
		}
	}

	private void ToggleQuestResultText()
	{
		Text child = Helper.GetChild<Text>(QuestResult.gameObject, "InformValue");
		Text child2 = Helper.GetChild<Text>(QuestResult.gameObject, "InformText");
		if ((bool)child)
		{
			Helper.SetVisibility(child.gameObject, Helper.Visibility.Toggle);
		}
		if ((bool)child2)
		{
			Helper.SetVisibility(child2.gameObject, Helper.Visibility.Toggle);
		}
	}

	private void FullClear()
	{
		CustomBlock[] componentsInChildren = base.gameObject.transform.GetComponentsInChildren<CustomBlock>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Clear();
		}
		blocksInScheme.ForEach(delegate(BlockInScheme block)
		{
			block.BlockData().Clear();
		});
		Chain[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<Chain>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			componentsInChildren2[i].ElemsClear();
		}
	}

	public void LoadFromScheme()
	{
		selectedBlocks.Clear();
		SchemeBlock helpSh = QuestLine.GetCurrentQuest().GetLastOpenCathubSchemeBlock();
		if (constrState == ConstructionState.Startup)
		{
			helpSh = ActiveComponent.Model.curStartupInWork.GetCathub().GetCustomScheme();
		}
		LoadFromScheme(helpSh);
		CtrlCtrlvButtonsStatesUpdate();
	}

	public Chain CreateChain()
	{
		return ActiveComponent.Model.GetChainObjectFromPool(ActiveComponent.Model.chainPrefab, Vector3.zero, Quaternion.identity, constrBlock.transform);
	}

	public Chain CreateChainWithTransform(Vector3 pos, Quaternion rot, bool imageEnabled = false)
	{
		Chain chainObjectFromPool = ActiveComponent.Model.GetChainObjectFromPool(ActiveComponent.Model.chainPrefab, pos, rot, constrBlock.transform);
		chainObjectFromPool.gameObject.GetComponent<Image>().enabled = imageEnabled;
		return chainObjectFromPool;
	}

	public Chain CreateChainWithTransform(Transform xform, bool imageEnabled = false)
	{
		return CreateChainWithTransform(xform.position, xform.rotation, imageEnabled);
	}

	public void LoadFromScheme(SchemeBlock helpSh, bool changeZoomAndPos = true, bool load = true)
	{
		recordingAllowed = false;
		CathubScheme curCathubScheme = GetCurCathub().GetCurCathubScheme();
		Vector3 position = algoBlock.position;
		Vector3 localScale = algoBlock.localScale;
		Vector2 pivot = algoBlockRectTransform.pivot;
		InitAlgoBlock(curCathubScheme.penPosition ?? constrBlock.transform.position, curCathubScheme.zoom, curCathubScheme.pivot);
		ClearCanvasScheme();
		if (helpSh == null)
		{
			recordingAllowed = true;
			Redraw(RedrawEnum.Full);
			return;
		}
		ClearBlockScheme();
		SchemeBlock schemeBlock = new SchemeBlock();
		schemeBlock.BaseInit(helpSh);
		bool flag = helpSh.useGlobalPosition == 1;
		flag = false;
		for (int i = 0; i < schemeBlock.blocks.Count; i++)
		{
			GameObject gOByKeyName = GetGOByKeyName(schemeBlock.blocks[i].GetKeyName());
			if (gOByKeyName != null)
			{
				BlockInScheme blockInScheme = new BlockInScheme(Logic.GetConstrBlockByKeyHash(schemeBlock.blocks[i].KeyHash));
				schemeBlock.blocks[i].position.z = 0f;
				blockInScheme.go = ActiveComponent.Model.GetBaseBlockObjectFromPool(gOByKeyName, schemeBlock.blocks[i].position, schemeBlock.blocks[i].rotation, GetAlgoTransform()).gameObject;
				if (!flag)
				{
					Vector3 position2 = schemeBlock.blocks[i].position;
					Vector2 vector = new Vector2(schemeBlock.constrWidthSaved, schemeBlock.constrHeightSaved);
					Vector2 vector2 = new Vector2(constrBlock.sizeDelta.x, constrBlock.sizeDelta.y);
					_ = vector.x / vector2.x;
					float b = vector.y / vector2.y;
					vector /= Mathf.Max(scaleX, b);
					position2.x *= vector2.x / vector.x;
					position2.y *= vector2.y / vector.y;
					blockInScheme.go.transform.localPosition = position2;
				}
				else
				{
					blockInScheme.go.transform.position = schemeBlock.blocks[i].position;
				}
				blockInScheme.SetKeyName(schemeBlock.blocks[i].GetKeyName());
				GameObject gameObject = AddBlockToScheme(blockInScheme);
				gameObject.name = schemeBlock.blocks[i].GetKeyName();
				gameObject.GetComponent<BlockData>().Active(schemeBlock.blocks[i], this);
				Vector3 localScale2 = gameObject.transform.localScale;
				localScale2.Set(scaleX, scaleY, 1f);
				gameObject.transform.localScale = localScale2;
				if (!Logic.IsBaseBlock(schemeBlock.blocks[i].KeyName))
				{
					gameObject.GetComponent<CustomBlock>().Init(Logic.GetSchemeBlockByHash(schemeBlock.blocks[i].KeyHash), flag: true);
				}
			}
		}
		for (int j = 0; j < schemeBlock.blocks.Count; j++)
		{
			Socket[] componentsInChildren = blocksInScheme[j].go.GetComponentsInChildren<Socket>();
			for (int k = 0; k < componentsInChildren.Length; k++)
			{
				if (componentsInChildren[k].inSocket)
				{
					continue;
				}
				int nextSchemeBlock = schemeBlock.blocks[j].GetNextSchemeBlock(componentsInChildren[k].num);
				int nextSocketId = schemeBlock.blocks[j].GetNextSocketId(componentsInChildren[k].num);
				if (nextSchemeBlock != -1)
				{
					if (nextSocketId == -1)
					{
						continue;
					}
					Socket[] componentsInChildren2 = blocksInScheme[nextSchemeBlock].go.GetComponentsInChildren<Socket>();
					for (int l = 0; l < componentsInChildren2.Length; l++)
					{
						if (componentsInChildren2[l].inSocket && componentsInChildren2[l].num == nextSocketId && componentsInChildren2[l].gameObject.activeInHierarchy)
						{
							Chain chain = CreateChainWithTransform(schemeBlock.blocks[j].position, schemeBlock.blocks[j].rotation);
							Socket chainOutSocket = componentsInChildren2[l];
							chain.SetSockets(componentsInChildren[k], chainOutSocket);
							chain.InitDraw();
							if (redrawChain)
							{
								chain.ImgState(state: true);
							}
							if (IsBasciTutorialsOpen())
							{
								endDrawLineEvent.Invoke();
							}
							break;
						}
					}
					continue;
				}
				int nextResult = schemeBlock.blocks[j].GetNextResult(componentsInChildren[k].num);
				if (nextResult != -1)
				{
					Chain chain2 = CreateChainWithTransform(schemeBlock.blocks[j].position, schemeBlock.blocks[j].rotation, imageEnabled: true);
					Socket componentInChildren = results[nextResult].GetComponentInChildren<Socket>();
					chain2.SetSockets(componentsInChildren[k], componentInChildren);
					chain2.InitDraw();
					if (redrawChain)
					{
						chain2.ImgState(state: true);
					}
				}
			}
		}
		for (int m = 0; m < schemeBlock.inSockets.Count; m++)
		{
			if (schemeBlock.inSockets[m] == null || schemeBlock.inSockets[m].nextBlock == -1)
			{
				continue;
			}
			Socket[] componentsInChildren3 = blocksInScheme[schemeBlock.GetIdBySchemeBlock(schemeBlock.blocks[schemeBlock.inSockets[m].nextBlock])].go.GetComponentsInChildren<Socket>();
			for (int n = 0; n < componentsInChildren3.Length; n++)
			{
				if (componentsInChildren3[n].inSocket && componentsInChildren3[n].num == schemeBlock.inSockets[m].nextSocketNum && componentsInChildren3[n].gameObject.activeInHierarchy)
				{
					Chain chain3 = CreateChainWithTransform(base.transform);
					chain3.SetInSocket(datas[m].socketsOut[2]);
					chain3.SetOutSocket(componentsInChildren3[n]);
					chain3.InitDraw();
					if (redrawChain)
					{
						chain3.ImgState(state: true);
					}
					break;
				}
			}
		}
		RecalcStatsInScheme();
		MatchAlgoBlockSiblings();
		if (!changeZoomAndPos)
		{
			InitAlgoBlock(position, localScale, pivot);
		}
		SetZoomToAllStates();
		if (IsBasciTutorialsOpen())
		{
			endDragEvent.Invoke();
		}
		if (flag)
		{
			AutoSaveDelay(Info.ShowNothing, saveInmemory: true, "SCHEME AUTOSAVED AS", reload: false);
		}
		recordingAllowed = true;
		Redraw(RedrawEnum.Full);
	}

	public void InitAlgoBlock(Vector3 position, Vector3 zoom, Vector2 pivot)
	{
		if (position == Vector3.zero)
		{
			position = constrBlock.transform.position;
		}
		if (float.IsNaN(position.x) || float.IsNaN(position.y) || float.IsNaN(position.z))
		{
			position = constrBlock.transform.position;
		}
		if (float.IsInfinity(position.x) || float.IsInfinity(position.y) || float.IsInfinity(position.z))
		{
			position = constrBlock.transform.position;
		}
		algoBlock.position = position;
		algoBlockRectTransform.pivot = pivot;
		algoBlock.localScale = Vector3.one;
		algoBlockRectTransform.sizeDelta = constrBlock.sizeDelta / ActiveComponent._staticData.Settings.MinZoom;
		if (float.IsNaN(zoom.x) || float.IsNaN(zoom.y) || zoom.x < ActiveComponent._staticData.Settings.MinZoom || zoom.y < ActiveComponent._staticData.Settings.MinZoom)
		{
			zoom = Vector3.one;
		}
		zoom.z = 1f;
		algoBlock.localScale = zoom;
		algoBlockImg.localScale = zoom;
		algoBlockDrag.localScale = zoom;
		MatchAlgoBlockSiblings();
	}

	private void MatchAlgoBlockSiblings()
	{
		algoBlockDrag.pivot = algoBlockRectTransform.pivot;
		algoBlockDrag.transform.localPosition = algoBlock.localPosition;
		algoBlockDrag.transform.localScale = algoBlock.localScale;
		algoBlockDrag.sizeDelta = algoBlockRectTransform.sizeDelta;
		algoBlockImg.pivot = algoBlockRectTransform.pivot;
		algoBlockImg.transform.localPosition = algoBlock.localPosition;
		algoBlockImg.transform.localScale = algoBlock.localScale;
		algoBlockImg.sizeDelta = algoBlockRectTransform.sizeDelta;
	}

	private string fileName(int width, int height)
	{
		return string.Format("screen_{0}x{1}_{2}.png", width, height, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}

	private void SaveAddNewScheme()
	{
		SchemeBlock schemeBlock = new SchemeBlock();
		schemeBlock.Init(this);
		ActiveComponent.Model.Scheme = schemeBlock;
		schemeBlock.SetShowName(SchemeName.text);
		Logic.SaveCurCathub();
	}

	private void FinalizeStochasticMatrices()
	{
		for (int i = 0; i < trueCellObjectCounts.Count; i++)
		{
			for (int j = 0; j < trueCellObjectCounts[i].Length; j++)
			{
				foreach (int item in new List<int>(stochasticMatrix[i][j].Keys))
				{
					stochasticMatrix[i][j][item] /= trueCellObjectCounts[i][j];
				}
			}
		}
	}

	private void UpdatePrecision(int id, CellObjects trueObj, int predictedCode)
	{
		trueCellObjectCounts[id][(int)trueObj]++;
		if (!stochasticMatrix[id][(int)trueObj].ContainsKey(predictedCode))
		{
			stochasticMatrix[id][(int)trueObj][predictedCode] = 0f;
		}
		Dictionary<int, float> obj = stochasticMatrix[id][(int)trueObj];
		float value = obj[predictedCode] + 1f;
		obj[predictedCode] = value;
	}

	public int PredictCode(int id, CellObjects trueCellObject, System.Random random)
	{
		float num = 0f;
		float num2 = (float)random.NextDouble();
		foreach (KeyValuePair<int, float> item in stochasticMatrix[id][(int)trueCellObject])
		{
			if (num2 < num + item.Value)
			{
				return item.Key;
			}
			num += item.Value;
		}
		return CarObjectTree.GetCodeByName("unknown");
	}

	private void Tune()
	{
		if (deepTrafficQuestController.gameObject.activeInHierarchy || !CheckRunConditions())
		{
			return;
		}
		AutoSave();
		SchemeBlock customScheme = QuestLine.GetQuest(schemeStack.Top().GetBaseQuest().KeyName).GetCatHub().GetCustomScheme();
		customScheme.ReInit();
		customScheme.InitOnLoad(customScheme);
		customScheme.Clear();
		trueCellObjectCounts.Clear();
		stochasticMatrix.Clear();
		for (int i = 0; i < 5; i++)
		{
			if (datas[i].gameObject.activeSelf)
			{
				trueCellObjectCounts.Add(new int[DeepTrafficStatic.cellObjectSize]);
				stochasticMatrix.Add(new Dictionary<int, float>[DeepTrafficStatic.cellObjectSize]);
				for (int j = 0; j < DeepTrafficStatic.cellObjectSize; j++)
				{
					trueCellObjectCounts[trueCellObjectCounts.Count - 1][j] = 0;
					stochasticMatrix[stochasticMatrix.Count - 1][j] = new Dictionary<int, float>();
				}
			}
		}
		int num = 0;
		for (int k = 0; k < 5; k++)
		{
			if (customScheme.inSockets[k] == null)
			{
				continue;
			}
			IEnumerator<Element> carReleaseElems = GetCarReleaseElems(k);
			while (carReleaseElems.MoveNext())
			{
				Element current = carReleaseElems.Current;
				customScheme.ClearBeforeRun();
				customScheme.inSockets[k].SetElement(current);
				customScheme.PushInBlock();
				if (customScheme.outSockets[2] == null)
				{
					current.stopped = true;
				}
				else if (customScheme.outSockets[2].GetElement() == null)
				{
					current.stopped = true;
				}
				if (current.stopped)
				{
					current.predictedObject = "unknown";
				}
				UpdatePrecision(num, current.trueCellObject, CarObjectTree.GetCodeByName(current.predictedObject));
			}
			num++;
		}
		FinalizeStochasticMatrices();
		deepTrafficQuestController.Init((CarQuest)QuestLine.GetQuest(schemeStack.Top().GetBaseQuest().KeyName).GetBaseQuest(), PredictCode, delegate(int x)
		{
			QuestLine.GetCurrentQuest().SetScore(x + 1);
			ExitClick();
		}, GetMoneyPerSecond());
		deepTrafficQuestController.gameObject.SetActive(value: true);
		RunAllTutorials();
	}

	private IEnumerator<Element> GetCarReleaseElems(int lidarNumber)
	{
		CarQuest quest = schemeStack.Top().GetQuest<CarQuest>();
		CarDatas carData = null;
		if (quest.CarEnv.maxLanesSide > 0)
		{
			if (quest.CarEnv.maxPatchesBehind > quest.CarEnv.carHeight)
			{
				switch (lidarNumber)
				{
				case 0:
					carData = quest.LeftCarDatas;
					break;
				case 1:
					carData = quest.FrontCarDatas;
					break;
				case 3:
					carData = quest.BehindCarDatas;
					break;
				case 4:
					carData = quest.RightCarDatas;
					break;
				}
			}
			else
			{
				switch (lidarNumber)
				{
				case 0:
					carData = quest.LeftCarDatas;
					break;
				case 1:
					carData = quest.FrontCarDatas;
					break;
				case 4:
					carData = quest.RightCarDatas;
					break;
				}
			}
		}
		else if (lidarNumber == 1)
		{
			carData = quest.FrontCarDatas;
		}
		int i = 0;
		while (i < carData.dummyCar * carData.releaseCoef)
		{
			yield return new Element(CellObjects.car)
			{
				startup = true,
				Try = true
			};
			int num = i + 1;
			i = num;
		}
		i = 0;
		while (i < carData.emptySpace * carData.releaseCoef)
		{
			yield return new Element(CellObjects.empty, "unknown", false, true, 0)
			{
				startup = true,
				Try = true
			};
			int num = i + 1;
			i = num;
		}
		i = 0;
		while (i < carData.wall * carData.releaseCoef)
		{
			yield return new Element(CellObjects.wall)
			{
				startup = true,
				Try = true
			};
			int num = i + 1;
			i = num;
		}
	}

	private void Save()
	{
		if (constrState != ConstructionState.SandBox)
		{
			AutoSaveDelay(Info.ShowProgressAndSaveName, saveInmemory: true, "SCHEME SAVED AS");
		}
		if (constrState == ConstructionState.SandBox)
		{
			AutoSaveDelay(Info.ShowProgressAndSaveName, saveInmemory: true, "DLL SAVED AS");
		}
	}

	public void InitSocketsNums()
	{
		for (int i = 0; i < blocksInScheme.Count; i++)
		{
			if (blocksInScheme[i].go != null)
			{
				Socket[] componentsInChildren = blocksInScheme[i].go.GetComponentsInChildren<Socket>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					componentsInChildren[j].BlockNumParent = i;
				}
			}
		}
	}

	public void AutoSaveDelay(Info saveInfo = Info.ShowProgressAndSaveName, bool saveInmemory = true, string saveKeyName = "SCHEME AUTOSAVED AS", bool reload = true, bool redraw = true)
	{
		SetAllParentsToDefault();
		if (nodesState != NodesState.Base)
		{
			ShowBaseClick();
		}
		InitSocketsNums();
		if (IsInNormalTaskRunMode() || constrState == ConstructionState.CarTask)
		{
			SaveAddNewScheme();
			QuestLine.Quest currentQuest = QuestLine.GetCurrentQuest();
			int currentCathubScheme = currentQuest.GetCurrentCathubScheme();
			SchemeBlock cathubSchemeBlock = currentQuest.GetCathubSchemeBlock(currentCathubScheme);
			string s = string.Empty;
			ActiveComponent.Model.Scheme.ClearToSave();
			ImportConstructBlocks(redraw);
			if (saveInmemory)
			{
				Logic.UpdateGameSaves();
			}
			Chain[] componentsInChildren = GetComponentsInChildren<Chain>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].SetStopDraw(flag: false);
			}
			if (saveInmemory && reload)
			{
				LoadFromScheme(cathubSchemeBlock);
			}
			if (saveInfo == Info.ShowOnlySaveName || saveInfo == Info.ShowProgressAndSaveName)
			{
				s = TextResources.GetString(saveKeyName) + " '" + Logic.GetShowNameById(QuestLine.GetCurrentQuestName()) + "'";
			}
			SetInfo(s, saveInfo);
		}
		if (constrState == ConstructionState.Startup)
		{
			ActiveComponent.Model.curStartupInWork.Init(this);
			SetInfo(TextResources.GetString("STARTUPAUTOSAVE"));
			ActiveComponent.Model.curStartupInWork.ClearToSave();
			ImportConstructBlocks(redraw);
		}
		if (constrState == ConstructionState.SandBox)
		{
			string keyName = schemeStack.Top().keyName;
			ActiveComponent.Model.P.sandboxSchemes[keyName].Init(this);
			if (reload)
			{
				LoadFromScheme(ActiveComponent.Model.P.sandboxSchemes[keyName].GetCurrentScheme());
			}
			if (saveInmemory)
			{
				Logic.UpdateGameSaves();
			}
			ActiveComponent.Model.Scheme = ActiveComponent.Model.P.sandboxSchemes[keyName].GetCurrentScheme();
			string s2 = string.Empty;
			if (saveInfo == Info.ShowOnlySaveName || saveInfo == Info.ShowProgressAndSaveName)
			{
				s2 = TextResources.GetString(saveKeyName) + " '" + Logic.GetShowNameById(keyName) + "'";
			}
			SetInfo(s2, saveInfo);
		}
		if (saveInfo == Info.ShowProgressAndSaveName || saveInfo == Info.ShowOnlyProgress)
		{
			autoSaveTimer = Time.unscaledTime;
			Saving.gameObject.SetActive(value: true);
			Saving.gameObject.GetComponent<Saving>().ShowSave();
		}
		save = false;
	}

	public void AutoSave(Info saveInfo = Info.ShowProgressAndSaveName, bool saveInMemory = true)
	{
		if (nodesState != NodesState.Base)
		{
			ShowBaseClick();
		}
		AutoSaveDelay(saveInfo, saveInMemory, "SCHEME AUTOSAVED AS", reload: true, redraw: false);
		if (saveInfo == Info.ShowProgressAndSaveName || saveInfo == Info.ShowOnlyProgress)
		{
			Saving.gameObject.SetActive(value: true);
			Saving.gameObject.GetComponent<Saving>().ShowSave();
		}
	}

	private bool HasWrongStartupOption()
	{
		if (schemeStack.Top().keyName != "TUTORIAL_STARTUP")
		{
			return false;
		}
		return blocksInScheme[0].go.GetComponent<IfShape>().top.value == 2;
	}

	private bool HasWrongConnections()
	{
		if (schemeStack.Top().keyName != ActiveComponent._staticData.ForumQuests[0].KeyName && schemeStack.Top().keyName != "TUTORIAL_STARTUP")
		{
			return false;
		}
		int num = -1;
		if (blocksInScheme[0].keyname == "IFCOLOR")
		{
			num = blocksInScheme[0].go.GetComponent<IfColor>().top.value;
		}
		if (blocksInScheme[0].keyname == "IFSHAPE")
		{
			num = blocksInScheme[0].go.GetComponent<IfShape>().top.value;
		}
		bool result = true;
		if (blocksInScheme[0].BaseBlock().socketsOut[1].chain.socketOut.gameObject.transform.parent.gameObject.name == results[1].gameObject.name && blocksInScheme[0].BaseBlock().socketsOut[3].chain.socketOut.gameObject.transform.parent.gameObject.name == results[3].gameObject.name && num == 0)
		{
			result = false;
		}
		if (blocksInScheme[0].BaseBlock().socketsOut[1].chain.socketOut.gameObject.transform.parent.gameObject.name == results[3].gameObject.name && blocksInScheme[0].BaseBlock().socketsOut[3].chain.socketOut.gameObject.transform.parent.gameObject.name == results[1].gameObject.name && num == 1)
		{
			result = false;
		}
		return result;
	}

	public bool HasFreeOutSockets()
	{
		if (constrState == ConstructionState.SandBox)
		{
			return false;
		}
		if (schemeStack.Top().keyName != ActiveComponent._staticData.ForumQuests[0].KeyName && schemeStack.Top().keyName != "TUTORIAL_STARTUP")
		{
			return false;
		}
		foreach (BlockInScheme item in blocksInScheme)
		{
			Socket[] componentsInChildren = item.go.GetComponentsInChildren<Socket>();
			foreach (Socket socket in componentsInChildren)
			{
				if (!socket.enabled)
				{
					continue;
				}
				if (!socket.inSocket)
				{
					if (socket.chain == null)
					{
						return true;
					}
				}
				else if (socket.inChains.Count == 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public BlockInScheme AttachNewBlockToMouse(GameObject go, bool dummy = false)
	{
		BlockInScheme blockInSchemeFromGO = GetBlockInSchemeFromGO(go);
		if (blockInSchemeFromGO == null)
		{
			return null;
		}
		return AttachNewBlockToMouse(blockInSchemeFromGO, dummy);
	}

	public BlockInScheme AttachNewBlockToMouse(BlockInScheme blockInScheme, bool dummy = false)
	{
		GameObject go = blockInScheme.go;
		curBlocks++;
		Redraw(RedrawEnum.OnlyText);
		BlockInScheme blockInScheme2 = new BlockInScheme(Logic.GetConstrBlockByKeyHash(go.name.GetHashCode()));
		GameObject gameObject = null;
		GameObject value = null;
		gameObject = ((!prefabs.TryGetValue(go.name.GetHashCode(), out value)) ? ActiveComponent.Model.GetBaseBlockObjectFromPool(customBlock, base.transform.position, base.transform.rotation, base.transform).gameObject : ActiveComponent.Model.GetBaseBlockObjectFromPool(value, base.transform.position, base.transform.rotation, base.transform).gameObject);
		gameObject.name = go.name;
		gameObject.transform.SetParent(GetAlgoTransform());
		gameObject.transform.localScale = Vector3.one;
		Vector3 mouseInWorld = Logic.GetMouseInWorld();
		if (!dummy && IsBasciTutorialsOpen())
		{
			startDragEvent.Invoke();
		}
		blockInScheme2.SetKeyName(gameObject.name);
		blockInScheme2.go = gameObject;
		blockInScheme2.SetPosition(go.transform.position);
		gameObject.GetComponent<BlockData>().Init(go.GetComponent<BlockData>(), dummy);
		addDragPosition = blockInScheme2.GetPosition() - mouseInWorld;
		AddBlockToScheme(blockInScheme2);
		if (!dummy)
		{
			DropSelection(ignoreConditions: true);
		}
		return blockInScheme2;
	}

	public void AttachNewBlockToMouse(int block)
	{
		if (currentChain != null)
		{
			return;
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_BlockFromList");
		curBlocks++;
		Redraw(RedrawEnum.OnlyText);
		BlockInScheme blockInScheme = new BlockInScheme(Logic.GetConstrBlockByKeyHash(ConstructBlockObjects[block].name.GetHashCode()));
		GameObject gameObject = ActiveComponent.Model.GetBaseBlockObjectFromPool(ConstructBlockObjects[block], base.transform.position, base.transform.rotation, algoBlockDrag).gameObject;
		gameObject.name = ConstructBlockObjects[block].name;
		gameObject.transform.localScale = Vector3.one;
		Vector3 mouseInWorld = Logic.GetMouseInWorld();
		attached = gameObject;
		interactState = DragInteraction.Block;
		if (IsBasciTutorialsOpen())
		{
			startDragEvent.Invoke();
		}
		if (nodesState != NodesState.Base)
		{
			SchemeBlock schemeBlockByKeyName = Logic.GetSchemeBlockByKeyName(showBlocks[block].name);
			gameObject.GetComponent<CustomBlock>().Init(schemeBlockByKeyName, flag: true);
			blockInScheme.SetKeyName(schemeBlockByKeyName.GetKeyName());
			gameObject.name = schemeBlockByKeyName.GetKeyName();
			gameObject.GetComponent<BlockData>().Active(schemeBlockByKeyName, this);
		}
		if (nodesState == NodesState.Base)
		{
			blockInScheme.SetKeyName(ConstructBlockObjects[block].name);
			gameObject.name = ConstructBlockObjects[block].name;
			gameObject.GetComponent<BlockData>().Active(null, this);
		}
		blockInScheme.go = gameObject;
		blockInScheme.SetPosition(showBlocks[block].transform.position);
		addDragPosition = blockInScheme.GetPosition() - mouseInWorld;
		AddBlockToScheme(blockInScheme);
		RecalcStatsInScheme();
		Redraw(RedrawEnum.States);
		string text = gameObject.name;
		int num = 0;
		foreach (Socket item in gameObject.GetComponent<BlockData>().socketsOut)
		{
			if (item != null)
			{
				text = text + " " + num;
			}
			num++;
		}
		DropSelection(ignoreConditions: true);
		SetZoomToAllStates();
	}

	private bool HasCustomBlocksInScheme()
	{
		return blocksInScheme.Find((BlockInScheme b) => !Logic.IsBaseBlock(b.keyname)) != null;
	}

	private bool CheckRunConditions()
	{
		int num = 0;
		int num2 = num;
		QuestCondition questCondition = null;
		num2 = ActiveComponent._staticData.Settings.MaxSandboxBlocks;
		int num3 = 50;
		if (constrState == ConstructionState.Startup)
		{
			questCondition = (QuestCondition)QuestLine.GetQuest(ActiveComponent.Model.curStartup.TaskKeyName).GetCondition(2);
			num2 = questCondition.Blocks;
			num3 = questCondition.CustomBlocks;
		}
		if (constrState == ConstructionState.Task)
		{
			questCondition = (QuestCondition)QuestLine.GetCurrentQuest().GetCondition(0);
		}
		if (constrState == ConstructionState.Forum)
		{
			questCondition = (QuestCondition)QuestLine.GetQuest(QuestLine.GetCurrentQuest().GetForumQuest().QuestKeyName).GetCondition(0);
		}
		if (constrState != ConstructionState.SandBox && constrState != ConstructionState.CarTask)
		{
			num2 = questCondition.Blocks;
			num3 = questCondition.CustomBlocks;
			if (questCondition.CustomBlocks == -1)
			{
				num3 = num;
			}
			if (questCondition.Blocks == -1)
			{
				num2 = num;
			}
			if (questCondition.Servers != -1 && GetServersCouInSheme() > questCondition.Servers)
			{
				SetHelp(TextResources.GetString("TOO_MANY_SERVERS"));
				return false;
			}
			if (questCondition.CustomBlocks != -1 && GetCustomBlocksCou() > num3)
			{
				SetHelp(TextResources.GetString("TOO_MANY_CUSTOMS"));
				return false;
			}
		}
		if (constrState == ConstructionState.CarTask)
		{
			CarQuest quest = schemeStack.Top().GetQuest<CarQuest>();
			num2 = quest.BlocksLimit;
			if (quest.ServersLimit != -1 && GetServersCouInSheme() > quest.ServersLimit)
			{
				SetHelp(TextResources.GetString("TOO_MANY_SERVERS"));
				return false;
			}
			if (quest.ServersLimit != -1 && GetCustomBlocksCou() > quest.CustomsLimit)
			{
				SetHelp(TextResources.GetString("TOO_MANY_CUSTOMS"));
				return false;
			}
		}
		if (GetBlocksCou() > num2)
		{
			SetHelp(TextResources.GetString("Too much blocks in scheme"));
			return false;
		}
		return true;
	}

	private void PlayerClickTestTrain(bool isTrain)
	{
		if (testMode)
		{
			return;
		}
		redrawChain = false;
		if (isTrain)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_LearnButton");
		}
		else
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_TestButton");
		}
		startupTutorialTimer = 0f;
		ActiveComponent.Model.trainTest = isTrain;
		bool flag = false;
		foreach (Data data in datas)
		{
			if (data.socketsOut[2].chain != null && data.socketsOut[2].chain.socketOut.transform.parent.gameObject.name.Contains("RESULT"))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			SetHelp(TextResources.GetString("LINE_DATA_RESULT"), HelpInfoState.GoodBad);
			return;
		}
		string customs = QuestLine.GetCurrentQuest().GetName();
		if (constrState == ConstructionState.SandBox)
		{
			customs = ActiveComponent.Model.SandboxOpen;
		}
		if (constrState == ConstructionState.Startup)
		{
			customs = ActiveComponent.Model.curStartupInWork.baseStartup.KeyName;
		}
		foreach (BlockInScheme item in blocksInScheme)
		{
			if (!Logic.IsBaseBlock(item.keyname) && item.go.GetComponent<CustomBlock>().scheme.hasRecursion(customs))
			{
				SetHelp(TextResources.GetString("CONTAINS_RECURSION"), HelpInfoState.GoodBad);
				return;
			}
		}
		if (isTrain)
		{
			bool flag2 = false;
			bool flag3 = false;
			foreach (BlockInScheme item2 in blocksInScheme)
			{
				if (!item2.BaseBlock().IsTrained())
				{
					flag2 = true;
				}
				if (Logic.IsBaseBlock(item2.keyname) && Logic.GetConstrBlockByKeyHash(item2.keyname.GetHashCode()).Trainable == 1)
				{
					flag3 = true;
				}
			}
			if (!flag3)
			{
				SetHelp(TextResources.GetString("NO_TRAINABLE_NODES"), HelpInfoState.GoodBad);
				return;
			}
			if (!flag2)
			{
				SetHelp(TextResources.GetString("NO_TRAINING"), HelpInfoState.GoodBad);
				return;
			}
		}
		if (IsInNormalTaskRunMode())
		{
			QuestLine.GetCurrentQuest().testRunsOnQuest++;
			QuestLine.Quest quest = QuestLine.GetCurrentQuest();
			if (constrState == ConstructionState.Forum)
			{
				quest = QuestLine.GetQuest(quest.GetForumQuest().QuestKeyName);
			}
			minConditionTime = ((QuestCondition)quest.GetCondition(0)).Time;
		}
		else if (constrState == ConstructionState.Startup)
		{
			ActiveComponent.Model.curStartup.testRunsInStartup++;
		}
		predictMoneyInDeploy = 0f;
		Deploy = false;
		if (nodesState != NodesState.Base)
		{
			ShowBaseClick();
		}
		if (!CheckRunConditions())
		{
			ActiveComponent.Model.trainTest = false;
			return;
		}
		if (blocksInScheme.Count == 0)
		{
			ActiveComponent.Model.trainTest = false;
			SetHelp(TextResources.GetString("You must add at least one block to the scheme"));
			return;
		}
		if (QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.Settings.DropdownTrigger && ((IfColor)blocksInScheme[0].BaseBlock()).top.value == 0)
		{
			ActiveComponent.Model.trainTest = false;
			SetHelp(TextResources.GetString("CHANGE_DROPDOWN_VALUE"));
			return;
		}
		if (HasFreeOutSockets())
		{
			ActiveComponent.Model.trainTest = false;
			SetHelp(TextResources.GetString("FREESOCKETS"));
			return;
		}
		if (IsBasciTutorialsOpen())
		{
			testEvent.Invoke();
		}
		if (HasWrongStartupOption())
		{
			ActiveComponent.Model.trainTest = false;
			SetHelp(TextResources.GetString("WRONG_IFSHAPE_OPTION"));
			return;
		}
		if (HasWrongConnections())
		{
			ActiveComponent.Model.trainTest = false;
			SetHelp(TextResources.GetString("WRONG_CONNECTIONS"));
			return;
		}
		if (CheckCustomtutorial())
		{
			ActiveComponent.Model.trainTest = false;
			return;
		}
		AutoSave(Info.ShowProgressAndSaveName, saveInMemory: false);
		prevTestBtnStatus = TestButton.gameObject.activeSelf;
		prevTrainBtnStatus = TrainButton.gameObject.activeSelf;
		prevTuneBtnStatus = TuneButton.gameObject.activeSelf;
		prevDeployBtnStatus = DeployBtn.gameObject.activeSelf;
		prevTestFirstBtnStatus = TestFirst.gameObject.activeSelf;
		prevTestAfterTrainBtnStatus = TestAfterTrain.gameObject.activeSelf;
		TestButton.gameObject.SetActive(value: false);
		TrainButton.gameObject.SetActive(value: false);
		TuneButton.gameObject.SetActive(value: false);
		DeployBtn.gameObject.SetActive(value: false);
		TestFirst.gameObject.SetActive(value: false);
		TestAfterTrain.gameObject.SetActive(value: false);
		SaveBtn.gameObject.SetActive(value: false);
		ClickTest();
		Redraw(RedrawEnum.OnlyText);
		if (Time.timeScale < 0.1f)
		{
			Time.timeScale = ActiveComponent.Model.P.rememberedSpeed;
		}
		MinusSpeed.gameObject.SetActive(!(Time.timeScale < 0.6f));
		PlusSpeed.gameObject.SetActive(!(Time.timeScale > 2.9f));
		Speed.text = "x" + (float)(int)(Time.timeScale * 2f) / 2f;
		SpeedCoef = Time.timeScale;
	}

	private bool CheckCustomtutorial()
	{
		if (IsInNormalTaskRunMode() && ActiveComponent._staticData.Settings.CustomtutorialTask.Split(',').Contains(QuestLine.GetCurrentQuest().GetName()) && !HasCustomBlocksInScheme())
		{
			SetHelp(TextResources.GetString("USECUSTOM"));
			return true;
		}
		return false;
	}

	private void PlayerClickDeploy()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_ReleaseButton");
		QuestLine.GetCurrentQuest().deployRunsOnQuest++;
		predictMoneyInDeploy = 0f;
		Deploy = true;
		curSpendMoney = 0f;
		if (TryRaiseError())
		{
			TestButton.gameObject.SetActive(prevTestBtnStatus);
			TrainButton.gameObject.SetActive(prevTrainBtnStatus);
			TuneButton.gameObject.SetActive(prevTuneBtnStatus);
			DeployBtn.gameObject.SetActive(prevDeployBtnStatus);
			TestFirst.gameObject.SetActive(prevTestFirstBtnStatus);
			TestAfterTrain.gameObject.SetActive(prevTestAfterTrainBtnStatus);
			SaveBtn.gameObject.SetActive(value: true);
			return;
		}
		_ = Logic.GetCurrentTableQuest().MaxBlock;
		if (constrState == ConstructionState.Startup)
		{
			_ = Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName).MaxBlock;
		}
		if (!CheckRunConditions())
		{
			return;
		}
		if (CheckCustomtutorial())
		{
			ActiveComponent.Model.trainTest = false;
			return;
		}
		if (HasWrongStartupOption())
		{
			ActiveComponent.Model.trainTest = false;
			SetHelp(TextResources.GetString("WRONG_IFSHAPE_OPTION"));
			return;
		}
		if (HasWrongConnections())
		{
			ActiveComponent.Model.trainTest = false;
			SetHelp(TextResources.GetString("WRONG_CONNECTIONS"));
			return;
		}
		ActiveComponent.Model.trainTest = false;
		AutoSave();
		ClickTest();
		if (Time.timeScale < 0.1f)
		{
			Time.timeScale = ActiveComponent.Model.P.rememberedSpeed;
		}
		MinusSpeed.gameObject.SetActive(!(Time.timeScale < 0.6f));
		PlusSpeed.gameObject.SetActive(!(Time.timeScale > 2.9f));
		Speed.text = "x" + (float)(int)(Time.timeScale * 2f) / 2f;
		SpeedCoef = Time.timeScale;
	}

	public void ClickStop()
	{
		if (testMode || Deploy)
		{
			SaveBtn.gameObject.SetActive(value: true);
			if (ActiveComponent.Model.trainTest)
			{
				GetCurCathub().RecordHistory();
			}
			PressStopStartupTutorial.gameObject.SetActive(value: false);
			RunAllTutorials();
			stopEvent.Invoke();
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			ClickTest();
			Deploy = false;
			ReInitConstructionArea();
		}
	}

	private bool HasIlleagalBlocks()
	{
		string text = "";
		for (int i = 0; i < ActiveComponent._staticData.ConstructionBlocks.Count; i++)
		{
			if (UnlockGroup.IsUnlocked(ActiveComponent._staticData.ConstructionBlocks[i].ReqUnlockGroups) && ActiveComponent._staticData.ConstructionBlocks[i].LockSandbox == 0)
			{
				bool flag = ActiveComponent.Model.P.extraUnlockedAlgos.Contains(ActiveComponent._staticData.ConstructionBlocks[i].KeyName);
				if (ActiveComponent._staticData.ConstructionBlocks[i].Extra == 0 || flag)
				{
					text = text + ActiveComponent._staticData.ConstructionBlocks[i].KeyName + ", ";
				}
			}
		}
		foreach (BlockInScheme item in blocksInScheme)
		{
			if (Logic.IsBaseBlock(item.go.name))
			{
				continue;
			}
			if (constrState == ConstructionState.Task)
			{
				ConstructionQuest currentTableQuest = Logic.GetCurrentTableQuest();
				if (!item.go.GetComponent<CustomBlock>().scheme.onlyLegalBlocks(currentTableQuest.UnlockedBlocks, currentTableQuest.KeyName))
				{
					return true;
				}
			}
			if (constrState == ConstructionState.Startup)
			{
				ConstructionQuest taskByKeyName = Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName);
				if (!item.go.GetComponent<CustomBlock>().scheme.onlyLegalBlocks(taskByKeyName.UnlockedBlocks, ""))
				{
					return true;
				}
			}
			if (constrState == ConstructionState.SandBox)
			{
				return text.Contains(item.go.name);
			}
		}
		return false;
	}

	public void ClearEnds()
	{
		if (IsInNormalTaskRunMode())
		{
			for (int i = 0; i < results.Count; i++)
			{
				if (Logic.ResultQuest(Logic.GetCurrentTableQuest(), i) != "-")
				{
					results[i].Clear();
				}
			}
		}
		if (constrState == ConstructionState.Startup)
		{
			for (int j = 0; j < results.Count; j++)
			{
				if (Logic.ResultQuest(Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName), j) != "-")
				{
					results[j].Clear();
				}
			}
		}
		if (constrState == ConstructionState.SandBox)
		{
			for (int k = 0; k < results.Count; k++)
			{
				results[k].Clear();
			}
		}
	}

	public void SleepEnds()
	{
		if (!IsInNormalTaskRunMode())
		{
			return;
		}
		for (int i = 0; i < results.Count; i++)
		{
			if (Logic.ResultQuest(Logic.GetCurrentTableQuest(), i) != "-")
			{
				results[i].Sleep();
			}
		}
	}

	public void ClickTest(bool clearResults = true)
	{
		elementsOnLines = 0;
		RedrawResults();
		if (HasIlleagalBlocks())
		{
			SetHelp(TextResources.GetString("Your scheme has custom nodes created from nodes illegal for this task"));
			TestButton.gameObject.SetActive(prevTestBtnStatus);
			TrainButton.gameObject.SetActive(prevTrainBtnStatus);
			TuneButton.gameObject.SetActive(prevTuneBtnStatus);
			DeployBtn.gameObject.SetActive(prevDeployBtnStatus);
			TestFirst.gameObject.SetActive(prevTestFirstBtnStatus);
			TestAfterTrain.gameObject.SetActive(prevTestAfterTrainBtnStatus);
			SaveBtn.gameObject.SetActive(value: true);
			return;
		}
		if (blocksInScheme.Count <= 0)
		{
			SetHelp(TextResources.GetString("You must add at least one block to the scheme"));
			TestButton.gameObject.SetActive(prevTestBtnStatus);
			TrainButton.gameObject.SetActive(prevTrainBtnStatus);
			TuneButton.gameObject.SetActive(prevTuneBtnStatus);
			DeployBtn.gameObject.SetActive(prevDeployBtnStatus);
			TestFirst.gameObject.SetActive(prevTestFirstBtnStatus);
			TestAfterTrain.gameObject.SetActive(prevTestAfterTrainBtnStatus);
			SaveBtn.gameObject.SetActive(value: true);
			return;
		}
		curIter = 0;
		FullClear();
		DropSelection();
		AutoSaveDelay();
		testMode = !testMode;
		moneyCoef = 0f;
		ReInitConstructionArea();
		Complete = false;
		blocker.gameObject.SetActive(testMode);
		if (testMode)
		{
			if (IsInNormalTaskRunMode())
			{
				SetConditionsInRuntime(2);
			}
			StopButton.gameObject.SetActive(value: true);
			curQuestlineQuest = QuestLine.GetCurrentQuest();
			if (IsInNormalTaskRunMode())
			{
				Logic.SendAnalytics("CONSTRUCTION_TASK_TEST", new Dictionary<string, object>
				{
					{
						"keyName",
						QuestLine.GetCurrentQuestName()
					},
					{
						"money spend",
						(int)curQuestlineQuest.moneySpent
					},
					{
						"blocks used",
						GetBlocksCou()
					},
					{
						"servers used",
						GetServersCouInSheme()
					},
					{ "test runs", curQuestlineQuest.testRunsOnQuest },
					{ "time in quest", curQuestlineQuest.timeInQuest },
					{
						"custom blocks",
						GetCustomBlocksInScheme()
					},
					{
						"catHubs",
						GetNumValidCatHubs()
					}
				});
			}
			if (constrState == ConstructionState.Startup)
			{
				ActiveComponent.Model.curStartupInWork.testRunsInStartup++;
			}
		}
		else
		{
			StopButton.gameObject.SetActive(value: false);
			Chain[] componentsInChildren = GetComponentsInChildren<Chain>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].ElemsClear();
			}
			Socket[] componentsInChildren2 = GetComponentsInChildren<Socket>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].Clear();
			}
			if (clearResults)
			{
				ClearEnds();
			}
			TestButton.gameObject.SetActive(prevTestBtnStatus);
			TrainButton.gameObject.SetActive(prevTrainBtnStatus);
			TuneButton.gameObject.SetActive(prevTuneBtnStatus);
			DeployBtn.gameObject.SetActive(prevDeployBtnStatus);
			TestFirst.gameObject.SetActive(prevTestFirstBtnStatus);
			TestAfterTrain.gameObject.SetActive(prevTestAfterTrainBtnStatus);
			SaveBtn.gameObject.SetActive(value: true);
		}
		foreach (BlockInScheme item in blocksInScheme)
		{
			if (!Logic.IsBaseBlock(item.keyname))
			{
				item.go.GetComponent<CustomBlock>().Init(Logic.GetSchemeBlockByHash(item.keyhash), flag: true);
			}
		}
		for (int j = 0; j < datas.Count; j++)
		{
			if (IsInNormalTaskRunMode())
			{
				datas[j].ChangePlay();
			}
			else
			{
				datas[j].StartupChangePlay();
			}
		}
		RecalcStatsInScheme();
		Redraw(RedrawEnum.OnlyText);
		if (testMode)
		{
			timer = 0f;
			firstTestTick = true;
		}
		currentResults = new List<string>();
		for (int k = 0; k < results.Count; k++)
		{
			if (constrState == ConstructionState.Startup)
			{
				currentResults.Add(Logic.ResultQuest(Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName), k));
			}
			if (IsInNormalTaskRunMode())
			{
				currentResults.Add(Logic.ResultQuest(Logic.GetCurrentTableQuest(), k));
			}
		}
		curQuestlineQuest = QuestLine.GetCurrentQuest();
		curTableQuest = Logic.GetCurrentTableQuest();
		UpdateSpeedActiveBtns();
	}

	private void CheckBtnsActive()
	{
		using List<BlockInScheme>.Enumerator enumerator = blocksInScheme.GetEnumerator();
		while (enumerator.MoveNext() && enumerator.Current.BaseBlock().IsTrained())
		{
		}
	}

	private bool ContainsBase(GameObject go)
	{
		return Helper.GetWorldRect(baseBlock).Contains(go.transform.position);
	}

	private bool ContainsConstruct(GameObject go)
	{
		return Helper.GetWorldRect(constrBlock).Contains(go.transform.position);
	}

	private void ImportConstructBlocksCustomNode()
	{
		if (nodesState == NodesState.Customs)
		{
			for (int i = 0; i < QuestLine.GetNumCompleted(); i++)
			{
				ConstructBlockObjects.Add(customBlock);
			}
		}
	}

	private void ImportConstructBlocksSandboxNode()
	{
		if (nodesState == NodesState.SandBox)
		{
			for (int i = 0; i < Logic.GetCurSandboxes(); i++)
			{
				ConstructBlockObjects.Add(customBlock);
			}
		}
	}

	private void ImportConstructBlockBaseNode(int i)
	{
		bool flag = ActiveComponent.Model.P.extraUnlockedAlgos.Contains(ActiveComponent._staticData.ConstructionBlocks[i].KeyName);
		if (ActiveComponent._staticData.ConstructionBlocks[i].Extra == 0 || flag)
		{
			ConstructBlockObjects.Add(prefabs[ActiveComponent._staticData.ConstructionBlocks[i].KeyName.GetHashCode()]);
		}
	}

	private void ImportConstructBlocksTask(ConstructionQuest cq)
	{
		if (nodesState == NodesState.Base)
		{
			for (int i = 0; i < ActiveComponent._staticData.ConstructionBlocks.Count; i++)
			{
				if (cq.UnlockedBlocks.Contains(ActiveComponent._staticData.ConstructionBlocks[i].KeyName))
				{
					ImportConstructBlockBaseNode(i);
				}
			}
		}
		ImportConstructBlocksCustomNode();
		ImportConstructBlocksSandboxNode();
	}

	private void ImportConstructBlocksStartup()
	{
		ConstructionQuest tableQuest = QuestLine.GetQuest(ActiveComponent.Model.curStartup.TaskKeyName).GetTableQuest();
		ImportConstructBlocksTask(tableQuest);
	}

	private void ImportConstructBlocksSandbox()
	{
		if (nodesState == NodesState.Base)
		{
			for (int i = 0; i < ActiveComponent._staticData.ConstructionBlocks.Count; i++)
			{
				if (UnlockGroup.IsUnlocked(ActiveComponent._staticData.ConstructionBlocks[i].ReqUnlockGroups) && ActiveComponent._staticData.ConstructionBlocks[i].LockSandbox == 0)
				{
					ImportConstructBlockBaseNode(i);
				}
			}
		}
		ImportConstructBlocksCustomNode();
		ImportConstructBlocksSandboxNode();
	}

	private void ImportConstructBlocksCarQuest()
	{
		if (nodesState == NodesState.Base)
		{
			for (int i = 0; i < ActiveComponent._staticData.ConstructionBlocks.Count; i++)
			{
				if (schemeStack.Top().GetQuest<BaseGameQuest>().UnlockedBlocks.Contains(ActiveComponent._staticData.ConstructionBlocks[i].KeyName))
				{
					ImportConstructBlockBaseNode(i);
				}
			}
		}
		ImportConstructBlocksCustomNode();
	}

	private void ImportConstructBlocks(bool redraw = true)
	{
		baseBlocksHeight = -1f;
		skipFrames = 0;
		sizeFilter.enabled = true;
		baseBlockRect.enabled = true;
		layoutGroup.enabled = true;
		ConstructBlockObjects = new List<GameObject>();
		ConstructBlockObjects.Clear();
		if (constrState == ConstructionState.Task)
		{
			ImportConstructBlocksTask(QuestLine.GetCurrentQuest().GetTableQuest());
		}
		else if (constrState == ConstructionState.Forum)
		{
			ImportConstructBlocksTask(QuestLine.GetQuest(QuestLine.GetCurrentQuest().GetForumQuest().QuestKeyName).GetTableQuest());
		}
		else if (constrState == ConstructionState.Startup)
		{
			ImportConstructBlocksStartup();
		}
		else if (constrState == ConstructionState.SandBox)
		{
			ImportConstructBlocksSandbox();
		}
		else if (constrState == ConstructionState.CarTask)
		{
			ImportConstructBlocksCarQuest();
		}
		if (redraw)
		{
			RedrawBlocks();
		}
	}

	private void DisableGroup(Vector2 value)
	{
	}

	private bool TryRaiseError()
	{
		if (HasIlleagalBlocks())
		{
			SetHelp(TextResources.GetString("Your scheme has custom nodes created from nodes illegal for this task"));
			return true;
		}
		if (blocksInScheme.Count <= 0)
		{
			SetHelp(TextResources.GetString("You must add at least one block to the scheme"));
			return true;
		}
		if (HasFreeOutSockets())
		{
			SetHelp(TextResources.GetString("FREESOCKETS"));
			return true;
		}
		return false;
	}

	private void DeployClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		prevTestBtnStatus = TestButton.gameObject.activeSelf;
		prevTrainBtnStatus = TrainButton.gameObject.activeSelf;
		prevTuneBtnStatus = TuneButton.gameObject.activeSelf;
		prevDeployBtnStatus = DeployBtn.gameObject.activeSelf;
		prevTestFirstBtnStatus = TestFirst.gameObject.activeSelf;
		prevTestAfterTrainBtnStatus = TestAfterTrain.gameObject.activeSelf;
		if (nodesState != NodesState.Base)
		{
			ShowBaseClick();
		}
		releaseEvent.Invoke();
		if (TryRaiseError())
		{
			SaveBtn.gameObject.SetActive(value: true);
		}
		else if (constrState == ConstructionState.Task)
		{
			if (ActiveComponent.Model.P.hideAttentiondeploy == 1)
			{
				AcceptDeployClick();
				return;
			}
			AcceptDeploy.gameObject.SetActive(value: true);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
			float num = 0f;
			foreach (BlockInScheme item in blocksInScheme)
			{
				num += (float)Logic.GetServersCouInBlock(item.keyname);
			}
			if ((double)num < 0.01)
			{
				num = 1f;
			}
			if (blocksInScheme.Count == 0)
			{
				num = 0f;
			}
			num *= (float)ActiveComponent._staticData.Settings.ServerCost * (1f - ActiveComponent.Model.P.upgradeStats.ServersCostBonus);
			num = (float)Math.Round(num, 3);
			rent.text = TextResources.GetString("IT WILL COST") + " " + Logic.ColorTransform("RED", num + "$") + " " + TextResources.GetString("SLSEC");
		}
		else if (CheckRunConditions())
		{
			if (HasIlleagalBlocks())
			{
				SetHelp(TextResources.GetString("Your scheme has custom nodes created from nodes illegal for this task"));
			}
			else if (HasWrongStartupOption())
			{
				ActiveComponent.Model.trainTest = false;
				SetHelp(TextResources.GetString("WRONG_IFSHAPE_OPTION"));
			}
			else if (HasWrongConnections())
			{
				ActiveComponent.Model.trainTest = false;
				SetHelp(TextResources.GetString("WRONG_CONNECTIONS"));
			}
			else if (ActiveComponent.Model.P.hideAttentionStartup == 1)
			{
				ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
				ActiveComponent._controller.Transition.ActiveOnFade(AcceptDeployStartupClick);
			}
			else
			{
				AcceptDeployStartup.gameObject.SetActive(value: true);
				ActiveComponent.Program.cursor.SetPosition(AcceptDeployStartupBtn.transform.position);
			}
		}
	}

	public IEnumerator WaitForUserAction()
	{
		while (!end)
		{
			yield return new WaitForEndOfFrame();
		}
		base.gameObject.SetActive(value: false);
		if (IsInNormalTaskRunMode() || constrState == ConstructionState.CarTask)
		{
			ActiveComponent._controller.CloseConstructionTask();
			yield break;
		}
		switch (constrState)
		{
		case ConstructionState.Startup:
			ActiveComponent.Model.RunTaskWhenTreeOpens = string.Empty;
			ActiveComponent._controller.CloseConstructionStartup();
			break;
		case ConstructionState.SandBox:
			ActiveComponent.Model.RunTaskWhenTreeOpens = string.Empty;
			ActiveComponent._controller.CloseSandBox();
			break;
		}
	}

	private void AcceptDeployClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		PlayerClickDeploy();
		moneyCoef = 1f;
		RecalcStatsInScheme();
		Redraw(RedrawEnum.OnlyText);
		AcceptDeploy.gameObject.SetActive(value: false);
	}

	private void CancelDeployClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		testSuccessEvent.Invoke();
		AcceptDeploy.gameObject.SetActive(value: false);
	}

	private void ShowBaseClick(bool sound = true)
	{
		if (sound)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		}
		nodesState = NodesState.Base;
		GoToDLLBlock.gameObject.SetActive(value: false);
		bool flag = true;
		if (schemeStack.Top().keyName != "TUTORIAL_STARTUP")
		{
			flag = false;
		}
		CustomBlockBtn.gameObject.SetActive(!flag && ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.ShowCustomsTrigger) && constrState != ConstructionState.Forum);
		BaseBlockBtn.gameObject.SetActive(value: false);
		BaseBlockLayer.gameObject.SetActive(value: true);
		LibraryBlockBtn.gameObject.SetActive(!flag && ActiveComponent.Model.curPreview.IsQuestDone(ActiveComponent._staticData.Settings.SandBoxTrigger) && constrState != ConstructionState.Forum);
		LibraryBlockLayer.gameObject.SetActive(value: false);
		CustomBlockLayer.gameObject.SetActive(value: false);
		ImportConstructBlocks();
		BlocksContent.transform.parent.parent.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
	}

	private void ShowCustomClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		nodesState = NodesState.Customs;
		GoToDLLBlock.gameObject.SetActive(value: false);
		BaseBlockLayer.gameObject.SetActive(value: false);
		CustomBlockBtn.gameObject.SetActive(value: false);
		BaseBlockBtn.gameObject.SetActive(value: true);
		CustomBlockLayer.gameObject.SetActive(value: true);
		LibraryBlockBtn.gameObject.SetActive(ActiveComponent.Model.curPreview.IsQuestDone(ActiveComponent._staticData.Settings.SandBoxTrigger) && constrState != ConstructionState.Forum);
		LibraryBlockLayer.gameObject.SetActive(value: false);
		ImportConstructBlocks();
		BlocksContent.transform.parent.parent.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
	}

	private void ShowLibraryClick()
	{
		GoToDLLBlock.gameObject.SetActive(constrState != ConstructionState.SandBox);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		nodesState = NodesState.SandBox;
		LibraryBlockBtn.gameObject.SetActive(value: false);
		CustomBlockBtn.gameObject.SetActive(ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.ShowCustomsTrigger) && constrState != ConstructionState.Forum);
		BaseBlockBtn.gameObject.SetActive(value: true);
		LibraryBlockLayer.gameObject.SetActive(value: true);
		CustomBlockLayer.gameObject.SetActive(value: false);
		BaseBlockLayer.gameObject.SetActive(value: false);
		ImportConstructBlocks();
		BlocksContent.transform.parent.parent.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
	}

	private void PlusClick()
	{
		if (!testMode || deepTrafficQuestController.gameObject.activeSelf)
		{
			return;
		}
		if (pause)
		{
			ActiveComponent.Model.P.rememberedSpeed = 0f;
			SpeedCoef = 0f;
		}
		else
		{
			SpeedCoef = ActiveComponent.Model.P.rememberedSpeed;
		}
		pause = false;
		if (!(SpeedCoef > 2.9f))
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Faster_Button");
			SpeedCoef = Mathf.Min(3f, SpeedCoef + 0.5f);
			PlusSpeed.gameObject.SetActive(!(SpeedCoef > 2.9f));
			MinusSpeed.gameObject.SetActive(SpeedCoef > 0.6f);
			ActiveComponent.Model.P.rememberedSpeed = SpeedCoef;
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			Time.timeScale = SpeedCoef;
			if (!testMode)
			{
				Time.timeScale = 1f;
			}
			Speed.text = "x" + (float)(int)(SpeedCoef * 2f) / 2f;
		}
	}

	private void MinusClick()
	{
		if (testMode && !deepTrafficQuestController.gameObject.activeSelf && !(SpeedCoef < 0.1f))
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Slower_Button");
			SpeedCoef = Mathf.Max(0.5f, SpeedCoef - 0.5f);
			MinusSpeed.gameObject.SetActive(!(SpeedCoef < 0.6f));
			PlusSpeed.gameObject.SetActive(value: true);
			ActiveComponent.Model.P.rememberedSpeed = SpeedCoef;
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			if (!testMode)
			{
				Time.timeScale = 1f;
			}
			Time.timeScale = SpeedCoef;
			Speed.text = "x" + (float)(int)(SpeedCoef * 2f) / 2f;
		}
	}

	private void CloseError()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		helpBlock.gameObject.SetActive(value: false);
		foreach (Data data in datas)
		{
			if (data.socketsOut[2].chain != null && data.socketsOut[2].chain.socketOut.transform.parent.gameObject.name.Contains("RESULT"))
			{
				ActiveComponent.Model.DisableChainObj(data.socketsOut[2].chain);
			}
		}
		BasicTutorials.TestWindow.gameObject.SetActive(value: false);
	}

	private void AcceptDeployStartupClick()
	{
		AcceptDeployStartup.gameObject.SetActive(value: false);
		AutoSaveDelay();
		ActiveComponent.Model.curStartupInWork.SetReleased(1);
		ActiveComponent._controller.RunCorotuneCheckTutorials();
		ExitClick();
		ActiveComponent._controller._startupView.Redraw();
	}

	private void CancelDeployStartupClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		AcceptDeployStartup.gameObject.SetActive(value: false);
	}

	private void HideDeployClick(bool click)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (click)
		{
			ActiveComponent.Model.P.hideAttentiondeploy = 1;
		}
		else
		{
			ActiveComponent.Model.P.hideAttentiondeploy = 0;
		}
		Logic.UpdateGameSaves();
	}

	private void HideStartupClick(bool click)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (click)
		{
			ActiveComponent.Model.P.hideAttentionStartup = 1;
		}
		else
		{
			ActiveComponent.Model.P.hideAttentionStartup = 0;
		}
		Logic.UpdateGameSaves();
	}

	private void TestTrainClick(bool click)
	{
		Redraw(RedrawEnum.OnlyText);
	}

	private void HideClearAllClick(bool click)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (click)
		{
			ActiveComponent.Model.P.HideClearAll = 1;
		}
		else
		{
			ActiveComponent.Model.P.HideClearAll = 0;
		}
	}

	public void RedrawResults()
	{
		if (IsInNormalTaskRunMode())
		{
			for (int i = 0; i < results.Count; i++)
			{
				if (Logic.ResultQuest(Logic.GetCurrentTableQuest(), i) == "-")
				{
					results[i].SetShow(active: false);
					continue;
				}
				results[i].SetShow(active: true);
				results[i].InitQuest(Logic.GetCurrentTableQuest(), Logic.GetResultByKeyName(Logic.ResultQuest(Logic.GetCurrentTableQuest(), i)), Deploy, constrState, testMode);
			}
		}
		Redraw(RedrawEnum.States);
	}

	public void DefaultOpenWindowInit()
	{
		redrawChain = false;
		SaveBtn.gameObject.SetActive(value: true);
		testCompleted = false;
		TestFirst.gameObject.SetActive(value: false);
		TestButton.gameObject.SetActive(value: true);
		DeployBtn.gameObject.SetActive(value: false);
		ActiveComponent.Sound.ActiveMusic("Monokanal/WhileTrueLearn_Music_For_Gameplay");
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
		ClearCanvasScheme();
		ActiveComponent.Model.recordHistory = true;
		ActiveComponent.Model.linesContainer = constrBlock.gameObject;
		ActiveComponent.Model.constructionState = constrState;
		foreach (Result result in results)
		{
			result.ClearLines();
		}
		buttonExit.gameObject.SetActive(value: true);
		BasicTutorials.gameObject.SetActive(value: false);
		CatHubTutorial.gameObject.SetActive(value: false);
		MedalTutorial.gameObject.SetActive(value: false);
		SandboxTutorial.gameObject.SetActive(value: false);
		SandboxTrainableTutorial.gameObject.SetActive(value: false);
		LidarSchemeTutorial.gameObject.SetActive(value: false);
		ElemsHierTutorial.gameObject.SetActive(value: false);
		LidarTutorial.gameObject.SetActive(value: false);
		MutationRateTutorial.gameObject.SetActive(value: false);
		MutationTutorial.gameObject.SetActive(value: false);
		GeneticPopulationTutorial.gameObject.SetActive(value: false);
		MeetTheMLTutorial.gameObject.SetActive(value: false);
		CrossoverTutorial.gameObject.SetActive(value: false);
		TimeTutorial.gameObject.SetActive(value: false);
		MemoryTutorial.gameObject.SetActive(value: false);
		CopyTutorial.gameObject.SetActive(value: false);
		MaintainAccLevelTutorial.gameObject.SetActive(value: false);
		LastEpochReachedTutorial.gameObject.SetActive(value: false);
		PressTrainAfterTeachTutorial.gameObject.SetActive(value: false);
		PressTestAfterTeachTutorial.gameObject.SetActive(value: false);
		OccAndAccTutorial.gameObject.SetActive(value: false);
		ServersTutorial.gameObject.SetActive(value: false);
		ErrorTutorial.gameObject.SetActive(value: false);
		for (int i = 0; i < ActiveComponent._staticData.Settings.MaxSandbox; i++)
		{
			sandboxList[i].gameObject.SetActive(value: true);
		}
		BasicTutorials.Hide();
		ClearCanvasScheme();
		testCompleted = false;
		InitAlgoBlock(constrBlock.position, Vector3.one, constrBlock.pivot);
		MatchAlgoBlockSiblings();
		shiftOnlyBounds.gameObject.SetActive(value: false);
		BaseBlock.InitBounds();
	}

	public Cathub GetCurCathub()
	{
		if (constrState == ConstructionState.Startup)
		{
			return ActiveComponent.Model.curStartupInWork.GetCathub();
		}
		if (constrState == ConstructionState.SandBox)
		{
			return ActiveComponent.Model.P.sandboxSchemes[schemeStack.Top().keyName].GetCatHub();
		}
		return QuestLine.GetCurrentQuest().GetCatHub();
	}

	private void SetZoomToAllStates()
	{
		foreach (BlockInScheme item in blocksInScheme)
		{
			item.BlockData().bb.SetZoom(algoBlockDrag.transform.localScale.x);
		}
	}

	public void RunReplay(string replay, float speed = 1f)
	{
		replayMode = GetCurCathub().LoadHistory(replay);
		if (replayMode)
		{
			replaySpeed = speed;
		}
	}

	public void OpenWindowInit(QuestLine.Quest cq, bool replay = false, bool customBlockOpened = false, string schemeName = "", bool addToSchemeStack = true)
	{
		DefaultOpenWindowInit();
		ActiveComponent.Model.linesContainer = constrBlock.gameObject;
		if (cq == null)
		{
			if (schemeName == "")
			{
				schemeName = "SANDBOX" + ActiveComponent.Model.P.lastOpenSandbox;
			}
			OpenWindowInit(ConstructionState.SandBox, null, customBlockOpened, schemeName, addToSchemeStack);
			return;
		}
		DeployBtntext.text = TextResources.GetString("RELEASE AND CHECK");
		if (cq.GetBaseQuest().Is<ConstructionQuest>())
		{
			if (cq.GetTableQuest().IsTask == 1)
			{
				OpenWindowInit(ConstructionState.Task, cq.GetTableQuest(), customBlockOpened, "", addToSchemeStack);
			}
			else
			{
				OpenWindowInit(ConstructionState.Startup, Logic.GetTaskByKeyName(cq.GetName()), customBlockOpened, "", addToSchemeStack);
			}
		}
		else if (cq.GetBaseQuest().Is<CarQuest>())
		{
			OpenWindowInit(cq.GetCarQuest(), customBlockOpened, "", addToSchemeStack);
		}
		else if (cq.GetBaseQuest().Is<ForumQuest>())
		{
			OpenWindowInit(cq.GetForumQuest(), customBlockOpened, "", addToSchemeStack);
		}
	}

	public void OpenWindowInit(ForumQuest cq, bool customBlockOpened = false, string schemeName = "", bool addToSchemeStack = true)
	{
		constrState = ConstructionState.Forum;
		ActiveComponent.Model.constructionState = constrState;
		if (addToSchemeStack && (schemeStack.IsEmpty() || customBlockOpened))
		{
			schemeStack.Push(constrState, cq, cq.KeyName);
		}
		if (cq.KeyName != ActiveComponent._staticData.ForumQuests[0].KeyName)
		{
			ActiveComponent.Model.P.basicsTutorial = 1;
			ActiveComponent.Model.P.passedFirstQuest = 1;
		}
		buttonExit.gameObject.SetActive(ActiveComponent.Model.P.passedFirstQuest == 1);
		QuestLine.GetQuest(cq.KeyName).SetOpened(state: true);
		QuestLine.SetCurrentQuest(cq.KeyName);
		sandboxLayer.gameObject.SetActive(value: false);
		Trainable = Logic.TaskContainsSelflearningBlocks(QuestLine.GetQuest(cq.QuestKeyName).GetTableQuest().UnlockedBlocks);
		ReInitConstructionArea();
		AfterOpenWindowInit();
	}

	public void OpenWindowInit(CarQuest cq, bool customBlockOpened = false, string schemeName = "", bool addToSchemeStack = true)
	{
		DeepTrafficQuestControllerTaskId.text = Logic.ColorTransform("GREEN", TextResources.GetString(QuestLine.GetCurrentQuest().GetTexts() + "SHORTT"));
		constrState = ConstructionState.CarTask;
		TestFirst.gameObject.SetActive(value: true);
		TestButton.gameObject.SetActive(value: false);
		ActiveComponent.Model.constructionState = constrState;
		if (addToSchemeStack && (schemeStack.IsEmpty() || customBlockOpened))
		{
			schemeStack.Push(constrState, cq, cq.KeyName);
		}
		QuestLine.GetQuest(cq.KeyName).SetOpened(state: true);
		QuestLine.SetCurrentQuest(cq);
		sandboxLayer.gameObject.SetActive(value: false);
		Trainable = Logic.TaskContainsSelflearningBlocks(cq.UnlockedBlocks);
		ReInitConstructionArea();
		AfterOpenWindowInit();
	}

	public void OpenWindowInit(ConstructionState state, ConstructionQuest cq, bool customBlockOpened = false, string schemeName = "", bool addToSchemeStack = true)
	{
		DefaultOpenWindowInit();
		DeployBtntext.text = TextResources.GetString("RELEASE AND CHECK");
		constrState = state;
		ActiveComponent.Model.constructionState = state;
		for (int i = 0; i < sandboxList.Count; i++)
		{
			if (ActiveComponent.Model.SandboxOpen == "SANDBOX" + i)
			{
				ActiveComponent.Model.P.lastOpenSandbox = i;
				break;
			}
		}
		if (addToSchemeStack)
		{
			string text = "";
			if (schemeStack.GetCount() > 0)
			{
				text = schemeStack.Top().keyName;
			}
			if (schemeStack.IsEmpty())
			{
				timeInStartup = 0f;
			}
			if ((schemeStack.IsEmpty() || customBlockOpened) && state != ConstructionState.SandBox && cq.KeyName != text)
			{
				schemeStack.Push(constrState, cq, cq.KeyName);
			}
			if (state == ConstructionState.SandBox && schemeName != text)
			{
				schemeStack.Push(constrState, cq, schemeName);
			}
		}
		if (state == ConstructionState.Task && schemeStack.GetCount() == 0)
		{
			ActiveComponent.Model.P.ShowFastMailTask = QuestLine.GetQuest(cq.KeyName);
		}
		if (state != ConstructionState.Startup && state != ConstructionState.SandBox && state != ConstructionState.Forum)
		{
			QuestLine.SetCurrentQuest(cq);
		}
		if (state == ConstructionState.Startup)
		{
			DeployBtn.gameObject.SetActive(value: true);
			bool flag = Logic.TaskContainsSelflearningBlocks(cq.UnlockedBlocks);
			TestFirst.gameObject.SetActive(flag);
			TestButton.gameObject.SetActive(!flag);
			bool flag2 = true;
			int hashCode = ActiveComponent.Model.curStartup.KeyName.GetHashCode();
			foreach (StartupScheme startup in ActiveComponent.Model.P.Startups)
			{
				if (startup.baseStartup.KeyName.GetHashCode() == hashCode)
				{
					flag2 = false;
					ActiveComponent.Model.curStartupInWork = startup;
					break;
				}
			}
			DeployBtntext.text = TextResources.GetString("LAUNCH_STARTUP_BTN");
			if (ActiveComponent.Model.curStartupInWork != null && ActiveComponent.Model.curStartupInWork.released == 1)
			{
				DeployBtntext.text = TextResources.GetString("LAUNCH_STARTUP_PATCH_BTN");
			}
			if (flag2)
			{
				StartupScheme startupScheme = new StartupScheme(new Startup(ActiveComponent.Model.curStartup));
				ActiveComponent.Model.curStartupInWork = startupScheme;
				ActiveComponent.Model.P.Startups.Add(startupScheme);
				Logic.UpdateGameSaves();
			}
		}
		if (state != ConstructionState.SandBox)
		{
			if (cq.KeyName != ActiveComponent._staticData.ForumQuests[0].KeyName)
			{
				ActiveComponent.Model.P.basicsTutorial = 1;
				ActiveComponent.Model.P.passedFirstQuest = 1;
			}
			if (state != ConstructionState.Startup && !QuestLine.GetQuest(cq.KeyName).IsTaskOpened())
			{
				QuestLine.GetCurrentQuest().Clear();
			}
			QuestLine.GetQuest(cq.KeyName).SetOpened(state: true);
		}
		ReInitConstructionArea();
		couTest = 0;
		curSpendMoney = 0f;
		if (state != ConstructionState.SandBox)
		{
			if (IsInNormalTaskRunMode() || constrState == ConstructionState.Startup)
			{
				Trainable = Logic.TaskContainsSelflearningBlocks(cq.UnlockedBlocks);
			}
			if (IsInNormalTaskRunMode())
			{
				SchemeBlock cathubSchemeBlock = QuestLine.GetCurrentQuest().GetCathubSchemeBlock(QuestLine.GetCurrentQuestCathubSchemeIndex());
				LoadFromScheme(cathubSchemeBlock);
			}
			else
			{
				int currentScheme = ActiveComponent.Model.curStartupInWork.GetCathub().GetCurrentScheme();
				SchemeBlock schemeBlock = ActiveComponent.Model.curStartupInWork.GetCathub().GetSchemeBlock(currentScheme);
				LoadFromScheme(schemeBlock);
			}
			end = false;
			helpBlock.gameObject.SetActive(value: false);
			RunAllTutorials();
		}
		if (state == ConstructionState.SandBox)
		{
			Trainable = false;
			if (ActiveComponent.Model.P.sandboxSchemes.ContainsKey(schemeName))
			{
				LoadFromScheme(ActiveComponent.Model.P.sandboxSchemes[schemeName].GetCurrentScheme());
			}
			RunAllTutorials();
		}
		AfterOpenWindowInit();
		Redraw(RedrawEnum.Full);
	}

	public void AfterOpenWindowInit()
	{
		bool active = ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.SandBoxTrigger);
		LibraryBlockBtn.gameObject.SetActive(active);
		RefreshCathubs();
		RefreshSandboxBtns();
		ResetConditions();
		foreach (CathubBtn catHub in catHubs)
		{
			catHub.Refresh();
		}
		ShowBaseClick(sound: false);
		ClearEnds();
		UpdateSpeed(ActiveComponent.Model.P.rememberedSpeed);
		RunAllTutorials();
		GetCurCathub().ClearHistory();
		GetCurCathub().RecordHistory();
		Redraw(RedrawEnum.Full);
		OpenCustomTutorial();
		timeInStartup = 0f;
		Undo.interactable = false;
		Redo.interactable = false;
		CtrlC.interactable = false;
		CtrlV.interactable = false;
	}

	private void OpenCustomTutorial()
	{
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			ActiveComponent.Model.P.showCustom = 1;
		}
		if (!WaitTutorial && ActiveComponent.Model.P.showCustom == 0 && QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.Settings.ShowCustomsTrigger)
		{
			CustomTutorialWindow.gameObject.SetActive(value: true);
			CustomTutorialWindow.Redraw();
			ActiveComponent.Program.cursor.SetPosition(CustomTutorialWindow.GetClickPosition());
			ActiveComponent.Model.P.showCustom = 1;
		}
	}

	public void RefreshCathubs()
	{
		CatHubRadio.transform.GetComponent<RadioButton>().DisableListeners();
		CatHubStartupRadio.transform.GetComponent<RadioButton>().DisableListeners();
		CatHubStartupRadio.gameObject.SetActive(value: false);
		if (constrState == ConstructionState.SandBox)
		{
			string keyName = schemeStack.Top().keyName;
			InitAllCathubs(CatHubRadio, ActiveComponent.Model.P.sandboxSchemes[keyName].GetCatHub());
			CatHubRadio.gameObject.SetActive(value: false);
			foreach (CathubBtn catHub in catHubs)
			{
				catHub.gameObject.SetActive(value: false);
			}
		}
		else if (constrState == ConstructionState.Task)
		{
			InitAllCathubs(CatHubRadio, QuestLine.GetCurrentQuest().GetCatHub());
		}
		else if (constrState == ConstructionState.Forum)
		{
			QuestLine.GetCurrentQuest();
			InitAllCathubs(CatHubRadio, QuestLine.GetCurrentQuest().GetCatHub());
		}
		else if (constrState == ConstructionState.Startup)
		{
			CatHubRadio.gameObject.SetActive(value: false);
			CatHubStartupRadio.gameObject.SetActive(value: true);
			InitAllCathubs(CatHubStartupRadio, ActiveComponent.Model.curStartupInWork.GetCathub());
			if (ActiveComponent.Model.curStartupInWork.baseStartup.KeyName == "TUTORIAL_STARTUP")
			{
				CatHubStartupRadio.gameObject.SetActive(value: false);
				foreach (CathubBtn catHub2 in catHubs)
				{
					catHub2.gameObject.SetActive(value: false);
				}
				ChangeCustomCatHub(0);
			}
		}
		else if (constrState == ConstructionState.CarTask)
		{
			InitAllCathubs(CatHubRadio, QuestLine.GetCurrentQuest().GetCatHub());
		}
		CatHubRadio.transform.GetComponent<RadioButton>().EnableListeners();
		CatHubStartupRadio.transform.GetComponent<RadioButton>().EnableListeners();
	}

	private void InitAllCathubs(ToggleGroup RadioButton, Cathub cathub)
	{
		bool active = ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.ShowCatHubTrigger);
		RadioButton.gameObject.SetActive(active);
		foreach (CathubBtn catHub in catHubs)
		{
			catHub.gameObject.SetActive(active);
			catHub.SetCathub(cathub);
		}
		RadioButton.GetComponent<RadioButton>().ActiveButton(0, active: true, cathub.GetUseAsCustom() == 0);
		for (int i = 1; i < ActiveComponent._staticData.Settings.MaxCatHubs; i++)
		{
			RadioButton.GetComponent<RadioButton>().ActiveButton(i, cathub.GetScheme(i).IsValid(), cathub.GetUseAsCustom() == i);
		}
		for (int j = 0; j < ActiveComponent._staticData.Settings.MaxCatHubs; j++)
		{
			catHubs[j].SetActiveScheme(j == cathub.GetCurrentScheme());
		}
	}

	public void RefreshSandboxBtns()
	{
		bool flag = ActiveComponent.Model.curPreview.IsQuestDone(ActiveComponent._staticData.Settings.SandBoxTrigger);
		sandboxLayer.gameObject.SetActive(flag && constrState == ConstructionState.SandBox);
		string text = "";
		if (schemeStack.GetCount() > 0 && schemeStack.GetCount() >= 2)
		{
			text = schemeStack.coll[schemeStack.coll.Count - 2].keyName;
		}
		for (int i = 0; i < sandboxList.Count; i++)
		{
			sandboxList[i].Redraw(i < Logic.GetCurSandboxes() && "SANDBOX" + i != text, i == ActiveComponent.Model.P.lastOpenSandbox);
		}
	}

	private bool RunTutorial(bool flag, TutorialList tutorial, ref int tutorialFlag)
	{
		if (flag && tutorialFlag == 0)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_TutorialPopup");
			StartCoroutine(WaitTutorialList(tutorial));
			tutorialFlag = 1;
			return true;
		}
		return false;
	}

	private bool UnlockedTrainableNodes()
	{
		foreach (ConstructionBlock constructionBlock in ActiveComponent._staticData.ConstructionBlocks)
		{
			if (constructionBlock.Trainable == 1 && UnlockGroup.IsUnlocked(constructionBlock.ReqUnlockGroups))
			{
				return true;
			}
		}
		return false;
	}

	public void RunAllTutorials()
	{
		Redraw(RedrawEnum.OnlyText);
		if (WaitTutorial || ActiveComponent._controller.newspaper.gameObject.activeSelf)
		{
			return;
		}
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			ActiveComponent.Model.P.catHubTutorial = 1;
			ActiveComponent.Model.P.timeTutorial = 1;
			ActiveComponent.Model.P.errorTutorial = 1;
			ActiveComponent.Model.P.serversTutorial = 1;
			ActiveComponent.Model.P.memoryRNNTutorial = 1;
			ActiveComponent.Model.P.occAndAccTutorial = 1;
			ActiveComponent.Model.P.speedTutorial = 1;
			ActiveComponent.Model.P.copyTutorial = 1;
			ActiveComponent.Model.P.maintainAccLevelTutorial = 1;
			ActiveComponent.Model.P.sandboxTutorial = 1;
			ActiveComponent.Model.P.elemHierTutorial = 1;
			ActiveComponent.Model.P.meetTheMLtutorial = 1;
			ActiveComponent.Model.P.geneticPopulationTutorial = 1;
			ActiveComponent.Model.P.mutationTutorial = 1;
			ActiveComponent.Model.P.medalTutorial = 1;
			ActiveComponent.Model.P.lidarsSchemeTutorial = 1;
			ActiveComponent.Model.P.mutationRateTutorial = 1;
			ActiveComponent.Model.P.lidarTutorial = 1;
			ActiveComponent.Model.P.crossoverTutorial = 1;
			ActiveComponent.Model.P.firstNonForumQuestTutorial = 1;
			ActiveComponent.Model.P.startupConstructionTutorial = 1;
			ActiveComponent.Model.P.customTurorialGeneticWindow = 1;
			ActiveComponent.Model.P.startupComicsTutorial = 1;
			ActiveComponent.Model.P.startupTrainTutorial = 1;
			foreach (ConstructionBlock constructionBlock in ActiveComponent._staticData.ConstructionBlocks)
			{
				ActiveComponent.Model.P.watchBlockTutorials[constructionBlock.KeyName] = 1;
			}
		}
		if ((constrState == ConstructionState.SandBox && (RunTutorial(flag: true, SandboxTutorial, ref ActiveComponent.Model.P.sandboxTutorial) || RunTutorial(UnlockedTrainableNodes(), SandboxTrainableTutorial, ref ActiveComponent.Model.P.sandboxTrainableTutorial))) || (constrState == ConstructionState.CarTask && (RunTutorial(ActiveComponent._staticData.Settings.ElemsHierTrigger.Contains(QuestLine.GetCurrentQuest().GetName()), ElemsHierTutorial, ref ActiveComponent.Model.P.elemHierTutorial) || RunTutorial(ActiveComponent._staticData.Settings.UnlockSideLidarTrigger.Contains(QuestLine.GetCurrentQuest().GetName()), LidarSchemeTutorial, ref ActiveComponent.Model.P.lidarsSchemeTutorial) || RunTutorial(ActiveComponent._staticData.Settings.MeetTheMLTrigger.Contains(QuestLine.GetCurrentQuest().GetName()) && deepTrafficQuestController.gameObject.activeSelf, MeetTheMLTutorial, ref ActiveComponent.Model.P.meetTheMLtutorial) || RunTutorial(ActiveComponent._staticData.Settings.GeneticPopulationTrigger == QuestLine.GetCurrentQuest().GetName() && deepTrafficQuestController.gameObject.activeSelf, GeneticPopulationTutorial, ref ActiveComponent.Model.P.geneticPopulationTutorial) || RunTutorial(ActiveComponent._staticData.Settings.MutationTrigger == QuestLine.GetCurrentQuest().GetName() && deepTrafficQuestController.gameObject.activeSelf, MutationTutorial, ref ActiveComponent.Model.P.mutationTutorial) || RunTutorial(ActiveComponent._staticData.Settings.CrossoverTrigger == QuestLine.GetCurrentQuest().GetName() && deepTrafficQuestController.gameObject.activeSelf, CrossoverTutorial, ref ActiveComponent.Model.P.crossoverTutorial) || RunTutorial(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.UnlockLidarTrigger) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.UnlockLidarTrigger).IsTaskOpened() && deepTrafficQuestController.gameObject.activeSelf && deepTrafficQuestController.IsLidarWindowOpened(), LidarTutorial, ref ActiveComponent.Model.P.lidarTutorial) || RunTutorial(ActiveComponent._staticData.Settings.MutationRateTrigger.Contains(QuestLine.GetCurrentQuest().GetName()) && deepTrafficQuestController.gameObject.activeSelf, MutationRateTutorial, ref ActiveComponent.Model.P.mutationRateTutorial))) || (constrState == ConstructionState.Startup && (RunTutorial(flag: true, StartupTutorialWindow, ref ActiveComponent.Model.P.startupConstructionTutorial) || RunTutorial(ActiveComponent._staticData.Settings.StartupComicsTrigger.Contains(ActiveComponent.Model.curStartup.KeyName) && testMode, StartupComicsTutorial, ref ActiveComponent.Model.P.startupComicsTutorial) || RunTutorial(ActiveComponent._staticData.Settings.StartupTrainTrigger.Contains(ActiveComponent.Model.curStartup.KeyName), StartupTrainTutorial, ref ActiveComponent.Model.P.startupTrainTutorial))))
		{
			return;
		}
		if (IsInNormalTaskRunMode() || constrState == ConstructionState.CarTask)
		{
			if (RunTutorial(testCompleted && !QuestLine.GetCurrentQuest().IsCompleted() && ActiveComponent._staticData.Settings.ShowFirstNonForumQuestTutorial == QuestLine.GetCurrentQuestName(), firstNonForumQuestTutorialWindow, ref ActiveComponent.Model.P.firstNonForumQuestTutorial) || RunTutorial(ActiveComponent._staticData.Settings.ShowCatHubTrigger == QuestLine.GetCurrentQuest().GetName(), CatHubTutorial, ref ActiveComponent.Model.P.catHubTutorial) || RunTutorial(ActiveComponent._staticData.Settings.MedalTrigger == QuestLine.GetCurrentQuest().GetName(), MedalTutorial, ref ActiveComponent.Model.P.medalTutorial) || RunTutorial(ActiveComponent._staticData.Settings.TimeTutorial == QuestLine.GetCurrentQuest().GetName(), TimeTutorial, ref ActiveComponent.Model.P.timeTutorial) || RunTutorial(ActiveComponent._staticData.Settings.ErrorTutorial == QuestLine.GetCurrentQuest().GetName(), ErrorTutorial, ref ActiveComponent.Model.P.errorTutorial) || RunTutorial(ActiveComponent._staticData.Settings.ShowServersTrigger == QuestLine.GetCurrentQuest().GetName(), ServersTutorial, ref ActiveComponent.Model.P.serversTutorial) || RunTutorial(ActiveComponent._staticData.Settings.SpeedTutorial.Contains(QuestLine.GetCurrentQuest().GetName() + ";"), SpeedTutorial, ref ActiveComponent.Model.P.speedTutorial) || RunTutorial(ActiveComponent._staticData.Settings.CopyTutorial == QuestLine.GetCurrentQuest().GetName(), CopyTutorial, ref ActiveComponent.Model.P.copyTutorial) || RunTutorial(ActiveComponent._staticData.Settings.OccAndAccTutorial == QuestLine.GetCurrentQuest().GetName(), OccAndAccTutorial, ref ActiveComponent.Model.P.occAndAccTutorial) || RunTutorial(ActiveComponent._staticData.Settings.MaintainAccTutorial == QuestLine.GetCurrentQuest().GetName(), MaintainAccLevelTutorial, ref ActiveComponent.Model.P.maintainAccLevelTutorial) || RunTutorial(ActiveComponent._staticData.Settings.MemoryRNNTutorial == QuestLine.GetCurrentQuest().GetName(), MemoryTutorial, ref ActiveComponent.Model.P.memoryRNNTutorial) || RunTutorial(ActiveComponent._staticData.Settings.DLLTrigger == QuestLine.GetCurrentQuest().GetName(), DLLTutorialWindow, ref ActiveComponent.Model.P.DLLTutorial) || RunTutorial(ActiveComponent._staticData.Settings.CustomTurorialGeneticTrigger == QuestLine.GetCurrentQuest().GetName(), CustomTurorialGeneticWindow, ref ActiveComponent.Model.P.customTurorialGeneticWindow))
			{
				return;
			}
			foreach (ConstructionBlock constructionBlock2 in ActiveComponent._staticData.ConstructionBlocks)
			{
				if (ActiveComponent.Model.P.watchBlockTutorials[constructionBlock2.KeyName] != 0 || (constructionBlock2.Extra != 0 && !ActiveComponent.Model.P.extraUnlockedAlgos.Contains(constructionBlock2.KeyName)) || !(constructionBlock2.KeyName != "IFCOLOR") || (!UnlockContainslevel(QuestLine.GetCurrentQuest().GetName(), constructionBlock2.ReqUnlockGroups) && !UnlockGroup.IsUnlocked(constructionBlock2.ReqUnlockGroups)))
				{
					continue;
				}
				if (IsInNormalTaskRunMode())
				{
					if (Logic.GetCurrentTableQuest().UnlockedBlocks.Contains(constructionBlock2.KeyName))
					{
						StartCoroutine(WaitBlockTutorial(constructionBlock2.KeyName, firstTime: true));
						ActiveComponent.Model.P.watchBlockTutorials[constructionBlock2.KeyName] = 1;
						return;
					}
				}
				else if (Logic.GetCarQuestByKeyName(QuestLine.GetCurrentQuest().GetName()).UnlockedBlocks.Contains(constructionBlock2.KeyName))
				{
					StartCoroutine(WaitBlockTutorial(constructionBlock2.KeyName, firstTime: true));
					ActiveComponent.Model.P.watchBlockTutorials[constructionBlock2.KeyName] = 1;
					return;
				}
			}
			OpenCustomTutorial();
		}
		OpenBasicTutorials();
	}

	private bool UnlockContainslevel(string KeyName, List<UnlockGroup> ReqUnlockGroups)
	{
		int hashCode = KeyName.GetHashCode();
		foreach (UnlockGroup ReqUnlockGroup in ReqUnlockGroups)
		{
			foreach (int questsHash in ReqUnlockGroup.questsHashes)
			{
				if (questsHash == hashCode)
				{
					return true;
				}
			}
		}
		return false;
	}

	private IEnumerator WaitBlockTutorial(string KeyName, bool firstTime = false)
	{
		WaitTutorial = true;
		BlockTutuorial.gameObject.SetActive(value: true);
		BlockTutuorial.Redraw(KeyName);
		NewBlockTutorialIndicator.gameObject.SetActive(firstTime);
		yield return BlockTutuorial.WaitForUserAction();
		WaitTutorial = false;
		NewBlockTutorialIndicator.gameObject.SetActive(value: false);
		RunAllTutorials();
	}

	private IEnumerator WaitTutorialList(TutorialList tutorial)
	{
		if (tutorial == null)
		{
			yield return null;
			yield break;
		}
		WaitTutorial = true;
		tutorial.Redraw();
		tutorial.gameObject.SetActive(value: true);
		ActiveComponent.Program.cursor.SetPosition(tutorial.GetClickPosition());
		yield return tutorial.WaitForUserAction();
		WaitTutorial = false;
		RunAllTutorials();
	}

	private void FilterChange(string val)
	{
		Filter.text = val;
		ApplyFilter();
	}

	private void OpenBasicTutorials()
	{
		if (!WaitTutorial && !BasicTutorials.gameObject.activeSelf && !ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial) && ActiveComponent.Model.P.basicsTutorial != 1 && !QuestLine.GetCurrentQuest().IsCompleted() && ActiveComponent._staticData.Settings.BasicsTutorialTrigger.Contains(QuestLine.GetCurrentQuest().GetName()) && IsBasciTutorialsOpen())
		{
			BasicTutorials.gameObject.SetActive(value: true);
			BasicTutorials.StartTutorial();
		}
	}

	public void ChangeCustomCatHub(int id)
	{
		if (constrState == ConstructionState.SandBox)
		{
			ActiveComponent.Model.P.sandboxSchemes[schemeStack.Top().keyName].SetUseAsCustom(id);
		}
		if (IsInNormalTaskRunMode())
		{
			QuestLine.GetCurrentQuest().SetCathubUseAsCustom(id);
		}
		if (constrState == ConstructionState.Startup)
		{
			ActiveComponent.Model.curStartupInWork.GetCathub().SetUseAsCustom(id);
		}
	}

	private void SandBoxClick(int id)
	{
		ActiveComponent.Model.SandboxOpen = "SANDBOX" + id;
		ActiveComponent.Model.P.lastOpenSandbox = id;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		schemeStack.Pop();
		OpenWindowInit(ConstructionState.SandBox, null, customBlockOpened: true, ActiveComponent.Model.SandboxOpen);
	}

	private void CloseTooManyNodesDragClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		TooManyNodesDrag.gameObject.SetActive(value: false);
	}

	private void HideTooManyDrag(bool value)
	{
		ActiveComponent.Model.P.hideDragTooMany = value;
	}

	private void OnShiftPressed(bool pressed, int count)
	{
		if (base.gameObject.activeSelf)
		{
			shiftOnlyBounds.gameObject.SetActive(pressed);
		}
	}

	public void OnUnInit()
	{
		InputSystem.RemoveListener(OnMouseWheel);
		InputSystem.RemoveListener(OnLeftMouseButton, InputSystem.EventType.LeftMouseButton);
		InputSystem.RemoveListener(OnLeftMouseButtonUp, InputSystem.EventType.LeftMouseButtonUp);
		InputSystem.RemoveListener(OnRightMouseButtonUp, InputSystem.EventType.RightMouseButtonUp);
		InputSystem.RemoveListener(OnRightMouseButtonDown, InputSystem.EventType.RightMouseButtonDown);
		InputSystem.RemoveListener(OnRightMouseButton, InputSystem.EventType.RightMouseButton);
		InputSystem.RemoveListener(OnCtrlA, InputSystem.EventType.CtrlA);
		InputSystem.RemoveListener(OnCtrlC, InputSystem.EventType.CtrlC);
		InputSystem.RemoveListener(OnCtrlV, InputSystem.EventType.CtrlV);
		InputSystem.RemoveListener(OnCtrlZ, InputSystem.EventType.CtrlZ);
		InputSystem.RemoveListener(OnCtrlY, InputSystem.EventType.CtrlY);
	}

	protected override void OnInit()
	{
		InputSystem.AddListener(OnMouseWheel);
		InputSystem.AddListener(OnLeftMouseButton, InputSystem.EventType.LeftMouseButton);
		InputSystem.AddListener(OnLeftMouseButtonUp, InputSystem.EventType.LeftMouseButtonUp);
		InputSystem.AddListener(OnRightMouseButtonUp, InputSystem.EventType.RightMouseButtonUp);
		InputSystem.AddListener(OnRightMouseButtonDown, InputSystem.EventType.RightMouseButtonDown);
		InputSystem.AddListener(OnRightMouseButton, InputSystem.EventType.RightMouseButton);
		InputSystem.AddListener(OnCtrlA, InputSystem.EventType.CtrlA);
		InputSystem.AddListener(OnCtrlC, InputSystem.EventType.CtrlC);
		InputSystem.AddListener(OnCtrlV, InputSystem.EventType.CtrlV);
		InputSystem.AddListener(OnCtrlZ, InputSystem.EventType.CtrlZ);
		InputSystem.AddListener(OnCtrlY, InputSystem.EventType.CtrlY);
		InputSystem.AddListener(OnPanReset, InputSystem.EventType.Tab);
		InputSystem.AddListener(OnShiftPressed, InputSystem.EventType.LeftShift);
		InputSystem.AddListener(OnShiftPressed, InputSystem.EventType.RightShift);
		GameObject original = Resources.Load("Prefabs/SandboxObj") as GameObject;
		blockPov = Resources.Load("Prefabs/BlockPOV") as GameObject;
		medals.Clear();
		medals.Add(Logic.LoadSprite("BRONZE"));
		medals.Add(Logic.LoadSprite("SILVER"));
		medals.Add(Logic.LoadSprite("GOLD"));
		endDrawLineEvent.AddListener(RecalcStatsInScheme);
		deleteEvent.AddListener(RecalcStatsInScheme);
		nodesState = NodesState.Base;
		end = false;
		curIter = 0;
		attached = null;
		testMode = false;
		moneyCoef = 0.2f;
		SceneBindContainer.BindObjects(this, base.transform);
		screenWidth = Helper.GetWorldRect(base.transform.root.GetComponent<RectTransform>()).width;
		Medal.Init();
		deepTrafficQuestController.gameObject.SetActive(value: false);
		foreach (ConstructionBlock constructionBlock in ActiveComponent._staticData.ConstructionBlocks)
		{
			prefabs.Add(constructionBlock.KeyName.GetHashCode(), Logic.LoadPrefab(constructionBlock.KeyName));
		}
		prefabs.Add("CUSTOM".GetHashCode(), Logic.LoadPrefab("CUSTOM"));
		for (int i = 0; i < ActiveComponent._staticData.Settings.MaxSandbox; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(original, base.transform.position, base.transform.rotation);
			gameObject.transform.SetParent(sandboxLayer.transform);
			gameObject.transform.localScale = Vector3.one;
			sandboxList.Add(gameObject.GetComponent<SandboxObjController>());
			gameObject.GetComponent<SandboxObjController>().Init();
			int newId = i;
			sandboxList[i].GetComponent<Button>().onClick.AddListener(delegate
			{
				SandBoxClick(newId);
			});
		}
		BasicTutorials.OnInit(this);
		CatHubTutorial.Init();
		CustomTurorialGeneticWindow.Init();
		CustomTurorialGeneticWindow.gameObject.SetActive(value: false);
		PressStopStartupTutorial.gameObject.SetActive(value: false);
		MedalTutorial.Init();
		StartupTutorialWindow.Init();
		CatHubTutorial.gameObject.SetActive(value: false);
		MedalTutorial.gameObject.SetActive(value: false);
		BasicTutorials.gameObject.SetActive(value: false);
		TooManyNodesDrag.gameObject.SetActive(value: false);
		CloseTooManyNodesDrag.onClick.AddListener(CloseTooManyNodesDragClick);
		ToggleTooManyNodesDrag.isOn = ActiveComponent.Model.P.hideDragTooMany;
		ToggleTooManyNodesDrag.onValueChanged.AddListener(HideTooManyDrag);
		ClearAll.onClick.AddListener(ClearAllClick);
		SelectAllBtn.onClick.AddListener(delegate
		{
			OnCtrlA(pressed: true, 1);
		});
		Undo.onClick.AddListener(delegate
		{
			OnCtrlZ(pressed: true, 1);
		});
		Redo.onClick.AddListener(delegate
		{
			OnCtrlY(pressed: true, 1);
		});
		BonusLayer.gameObject.SetActive(value: false);
		CatHubRadio.transform.GetComponent<RadioButton>().Init();
		CatHubRadio.transform.GetComponent<RadioButton>().ChangeEvent.AddListener(ChangeCustomCatHub);
		LastEpochReachedTutorialClose.onClick.AddListener(delegate
		{
			StopTrainingAttentionLastEpoch.gameObject.SetActive(value: true);
		});
		StopTrainingAttentionLastEpoch.gameObject.SetActive(value: false);
		StopTrainingAttentionLastEpochAccept.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			StopTrainingAttentionLastEpoch.gameObject.SetActive(value: false);
			deepTrafficQuestController.teachButton.gameObject.SetActive(QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.CarQuests[0].KeyName);
		});
		CatHubStartupRadio.transform.GetComponent<RadioButton>().Init();
		CatHubStartupRadio.transform.GetComponent<RadioButton>().ChangeEvent.AddListener(ChangeCustomCatHub);
		Saving.gameObject.GetComponent<Saving>().Init();
		PlusSpeed.onClick.AddListener(PlusClick);
		PauseBtn.onClick.AddListener(Pause);
		MinusSpeed.onClick.AddListener(MinusClick);
		QuestResult.Init();
		QuestResult.gameObject.SetActive(value: false);
		QuestResult.disableCallback = delegate
		{
			if (IsInNormalTaskRunMode())
			{
				QuestLine.GetCurrentQuest().SetCurrentCondition(rememberedConditionId);
				ResetConditions();
			}
		};
		carQuestResult.Init();
		BlockTutuorial.Init();
		HelpOk.onClick.AddListener(CloseError);
		BlockTutuorial.gameObject.SetActive(value: false);
		SaveBtn.onClick.AddListener(delegate
		{
			Save();
		});
		SaveReleasedWithTuneButton.onClick.AddListener(Save);
		TuneButton.onClick.AddListener(Tune);
		TuneReleasedButton.onClick.AddListener(Tune);
		ActiveComponent._controller.newspaper.closeNews.AddListener(RunAllTutorials);
		MemoryTutorial.Init();
		TimeTutorial.Init();
		SpeedTutorial.Init();
		CopyTutorial.Init();
		OccAndAccTutorial.Init();
		MaintainAccLevelTutorial.Init();
		LastEpochReachedTutorial.Init();
		PressTrainAfterTeachTutorial.Init();
		PressTestAfterTeachTutorial.Init();
		ErrorTutorial.Init();
		ServersTutorial.Init();
		SandboxTutorial.Init();
		SandboxTrainableTutorial.Init();
		LidarSchemeTutorial.Init();
		ElemsHierTutorial.Init();
		LidarTutorial.Init();
		MutationRateTutorial.Init();
		MutationTutorial.Init();
		GeneticPopulationTutorial.Init();
		MeetTheMLTutorial.Init();
		CrossoverTutorial.Init();
		StartupComicsTutorial.Init();
		MemoryTutorial.gameObject.SetActive(value: false);
		TimeTutorial.gameObject.SetActive(value: false);
		SpeedTutorial.gameObject.SetActive(value: false);
		CopyTutorial.gameObject.SetActive(value: false);
		OccAndAccTutorial.gameObject.SetActive(value: false);
		ErrorTutorial.gameObject.SetActive(value: false);
		ServersTutorial.gameObject.SetActive(value: false);
		MaintainAccLevelTutorial.gameObject.SetActive(value: false);
		LastEpochReachedTutorial.gameObject.SetActive(value: false);
		SandboxTutorial.gameObject.SetActive(value: false);
		SandboxTrainableTutorial.gameObject.SetActive(value: false);
		StartupComicsTutorial.gameObject.SetActive(value: false);
		LidarSchemeTutorial.gameObject.SetActive(value: false);
		ElemsHierTutorial.gameObject.SetActive(value: false);
		LidarTutorial.gameObject.SetActive(value: false);
		MutationRateTutorial.gameObject.SetActive(value: false);
		MutationTutorial.gameObject.SetActive(value: false);
		MeetTheMLTutorial.gameObject.SetActive(value: false);
		CrossoverTutorial.gameObject.SetActive(value: false);
		GeneticPopulationTutorial.gameObject.SetActive(value: false);
		_ = firstNonForumQuestTutorialWindow.gameObject.activeInHierarchy;
		firstNonForumQuestTutorialWindow.Init();
		catHubs.Clear();
		for (int num = 0; num < ActiveComponent._staticData.Settings.MaxCatHubs; num++)
		{
			CathubBtn component = base.gameObject.transform.Find("CatHub" + num).GetComponent<CathubBtn>();
			catHubs.Add(component);
			component.Init();
		}
		AttentionClear.gameObject.SetActive(value: false);
		HideDeployAttention.isOn = ActiveComponent.Model.P.hideAttentiondeploy == 1;
		HideStartupAttention.isOn = ActiveComponent.Model.P.hideAttentionStartup == 1;
		HideDeployAttention.onValueChanged.AddListener(HideDeployClick);
		HideStartupAttention.onValueChanged.AddListener(HideStartupClick);
		AcceptClearBtn.onClick.AddListener(AcceptClearAll);
		CancelClear.onClick.AddListener(CancelClearAll);
		Filter.onValueChanged.AddListener(FilterChange);
		Filter.gameObject.SetActive(value: false);
		BlocksContent = GameObject.Find("BlocksContent");
		blocksContentRect = BlocksContent.GetComponent<RectTransform>();
		sizeFilter = BlocksContent.GetComponent<ContentSizeFitter>();
		layoutGroup = BlocksContent.GetComponent<VerticalLayoutGroup>();
		CustomTutorialWindow.Init();
		StartupTrainTutorial.Init();
		CustomTutorialWindow.gameObject.SetActive(value: false);
		StartupTrainTutorial.gameObject.SetActive(value: false);
		DLLTutorialWindow.Init();
		DLLTutorialWindow.gameObject.SetActive(value: false);
		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		AcceptDeployBtn.onClick.AddListener(AcceptDeployClick);
		AcceptDeployStartupBtn.onClick.AddListener(delegate
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(AcceptDeployStartupClick);
		});
		CancelDeployStartupBtn.onClick.AddListener(CancelDeployStartupClick);
		rent = GameObject.Find("RentText").GetComponent<Text>();
		BaseBlockBtn.onClick.AddListener(delegate
		{
			ShowBaseClick();
		});
		CustomBlockBtn.onClick.AddListener(ShowCustomClick);
		LibraryBlockBtn.onClick.AddListener(ShowLibraryClick);
		CancelDeployBtn.onClick.AddListener(CancelDeployClick);
		nextButton.onClick.AddListener(PassClick);
		curBlocks = 0;
		AlgoButton = algoBlockImg.gameObject.GetComponent<Button>();
		AlgoButton.onClick.AddListener(DeleteChainLayerClick);
		DeployBtn.onClick.AddListener(DeployClick);
		buttonExit.onClick.AddListener(ExitClick);
		AcceptDeploy.gameObject.SetActive(value: false);
		AcceptDeployStartup.gameObject.SetActive(value: false);
		datas = new List<Data>();
		results = new List<Result>();
		TestButton.onClick.AddListener(delegate
		{
			PlayerClickTestTrain(isTrain: false);
		});
		TrainButton.onClick.AddListener(delegate
		{
			PlayerClickTestTrain(isTrain: true);
		});
		TestAfterTrain.onClick.AddListener(delegate
		{
			PlayerClickTestTrain(isTrain: false);
		});
		TestFirst.onClick.AddListener(delegate
		{
			PlayerClickTestTrain(isTrain: false);
		});
		TestAfterTrain.gameObject.SetActive(value: false);
		TestFirst.gameObject.SetActive(value: false);
		buttonBlocks = new List<Button>();
		buttonBlocks.Clear();
		customBlock = Logic.LoadPrefab("CUSTOM");
		BlockSpawn = Resources.Load("Prefabs/Block") as GameObject;
		StopButton.onClick.AddListener(ClickStop);
		StopButton.gameObject.SetActive(value: false);
		helpBlock.gameObject.SetActive(value: false);
		saveBlock.gameObject.SetActive(value: false);
		for (int num2 = 0; num2 < 5; num2++)
		{
			datas.Add(datasContainers.transform.Find("DATA" + num2).Find("DATA" + num2).GetComponent<Data>());
			Socket[] componentsInChildren = datas[num2].GetComponentsInChildren<Socket>();
			for (int num3 = 0; num3 < componentsInChildren.Length; num3++)
			{
				componentsInChildren[num3].dataNum = num2;
			}
			datas[num2].InitData();
			results.Add(resultsContainer.transform.Find("RESULT" + num2).Find("RESULT" + num2).GetComponent<Result>());
			componentsInChildren = results[num2].GetComponentsInChildren<Socket>();
			for (int num3 = 0; num3 < componentsInChildren.Length; num3++)
			{
				componentsInChildren[num3].resultNum = num2;
			}
		}
		ActiveComponent.Model.construction = this;
		blocker.gameObject.SetActive(value: false);
		StartupTutorialWindow.gameObject.SetActive(value: false);
		testSuccessEvent.AddListener(delegate
		{
			testCompleted = true;
			DeployBtn.gameObject.SetActive(value: false);
			RunAllTutorials();
		});
		algoBlockRectTransform = algoBlock.GetComponent<RectTransform>();
		Vector2 vector = new Vector2(1129f, 635.0626f);
		constrBlock.sizeDelta += base.transform.parent.GetComponent<RectTransform>().sizeDelta - vector;
		darkLayerHideAlgoBlock.sizeDelta = constrBlock.sizeDelta;
		constructionBlockPopups.sizeDelta = constrBlock.sizeDelta;
		StartupComicsTutorial.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		LastEpochReachedTutorial.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		ServersTutorial.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		ErrorTutorial.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		MemoryTutorial.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		TimeTutorial.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		OccAndAccTutorial.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		MaintainAccLevelTutorial.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		PressTrainAfterTeachTutorial.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		PressTestAfterTeachTutorial.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		CustomTutorialWindow.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		CatHubTutorial.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		BasicTutorials.gameObject.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		deepTrafficGameController.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		MutationRateTutorial.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		GeneticPopulationTutorial.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		CrossoverTutorial.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		MutationTutorial.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		MeetTheMLTutorial.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		ElemsHierTutorial.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		CustomTurorialGeneticWindow.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		LidarSchemeTutorial.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		MedalTutorial.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		dataResults.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		SpeedTutorial.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		LidarTutorial.GetComponent<RectTransform>().sizeDelta = constrBlock.sizeDelta;
		InitAlgoBlock(constrBlock.position, Vector3.one, constrBlock.pivot);
		xMinConstrBlock = constrBlock.localPosition.x - constrBlock.sizeDelta.x / 2f;
		xMaxConstrBlock = constrBlock.localPosition.x + constrBlock.sizeDelta.x / 2f;
		yMinConstrBlock = constrBlock.localPosition.y - constrBlock.sizeDelta.y / 2f;
		yMaxConstrBlock = constrBlock.localPosition.y + constrBlock.sizeDelta.y / 2f;
		stopEvent.AddListener(delegate
		{
			ActiveComponent.Model.trainTest = false;
		});
		LongTapMenu.gameObject.SetActive(value: false);
		GoToDLLBtn.onClick.AddListener(GoToSandBox);
		if (Logic.IsSteamDeckRunning())
		{
			SchemeName.interactable = false;
			SchemeName.transform.Find("Pencil").gameObject.SetActive(value: false);
			SchemeName.GetComponent<Image>().enabled = false;
		}
		CtrlC.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			OnCtrlC(pressed: true, 1);
		});
		CtrlV.onClick.AddListener(delegate
		{
			pasteInCenter = true;
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			OnCtrlV(pressed: true, 1);
			pasteInCenter = false;
		});
	}

	private void GoToSandBox()
	{
		AutoSaveDelay();
		Logic.SaveCurCathub();
		ActiveComponent.Model.SandboxOpen = "SANDBOX" + ActiveComponent.Model.P.lastOpenSandbox;
		OpenWindowInit(null, false, false, "", true);
	}

	private void SetHelp(string s, HelpInfoState negativeMsg = HelpInfoState.Error)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
		helpBlock.gameObject.SetActive(value: true);
		ActiveComponent.Program.cursor.SetPosition(HelpOk.transform.position);
		CatWarningGood.gameObject.SetActive(negativeMsg == HelpInfoState.Good);
		CatWarningHelp.gameObject.SetActive(negativeMsg == HelpInfoState.Error);
		CatWarningGoodBad.gameObject.SetActive(negativeMsg == HelpInfoState.GoodBad);
		helpBlock.gameObject.GetComponentInChildren<Text>().text = s;
	}

	public void PassClick()
	{
	}

	private void SetInfo(string s, Info info = Info.ShowProgressAndSaveName)
	{
		if (info != Info.ShowNothing)
		{
			saveBlock.gameObject.SetActive(value: true);
			helpTimer = Time.unscaledTime;
			helpDelay = 3f;
			saveBlock.gameObject.GetComponentInChildren<Text>().text = s;
		}
	}

	public void ReInitConstructionArea(bool resetInOut = true)
	{
		DefaultTaskList();
		if (constrState != ConstructionState.SandBox)
		{
			schemeStack.Top().GetBaseQuest().ReInitConstructionArea(resetInOut);
		}
		else
		{
			string keyName = schemeStack.Top().keyName;
			SchemeName.text = Logic.GetShowNameById(keyName);
			DeployBtn.gameObject.SetActive(value: false);
			if (ActiveComponent.Model.P.sandboxSchemes.ContainsKey(keyName))
			{
				SandboxScheme sandboxScheme = ActiveComponent.Model.P.sandboxSchemes[keyName];
				if (resetInOut)
				{
					for (int i = 0; i < results.Count; i++)
					{
						results[i].SetShow(active: false, sandbox: true);
						results[i].InitQuest(sandboxScheme.GetResult(i), testMode);
					}
					for (int j = 0; j < datas.Count; j++)
					{
						datas[j].SetShow(active: false, sandbox: true);
						datas[j].InitQuest(sandboxScheme.GetData(j));
					}
				}
			}
		}
		Redraw(RedrawEnum.Full);
	}

	public void ReInitConstructionArea(ConstructionQuest cq, bool resetInOut = true)
	{
		TuneButton.gameObject.SetActive(value: false);
		TuneReleasedButton.gameObject.SetActive(value: false);
		SaveReleasedWithTuneButton.gameObject.SetActive(value: false);
		if (IsInNormalTaskRunMode())
		{
			QuestLine.GetCurrentQuest().GetCathubUseAsCustom();
			QuestLine.Quest quest = QuestLine.GetCurrentQuest();
			if (constrState == ConstructionState.Forum)
			{
				quest = QuestLine.GetQuest(quest.GetForumQuest().QuestKeyName);
			}
			SchemeName.text = Logic.GetShowNameById(quest.GetName());
			for (int i = 0; i < results.Count; i++)
			{
				if (Logic.ResultQuest(cq, i) == "-")
				{
					results[i].SetShow(active: false);
					continue;
				}
				results[i].SetShow(active: true);
				results[i].InitQuest(cq, Logic.GetResultByKeyName(Logic.ResultQuest(cq, i)), Deploy, constrState, testMode);
			}
			for (int j = 0; j < datas.Count; j++)
			{
				if (Logic.DataQuest(cq, j) == "-")
				{
					datas[j].SetShow(active: false);
					continue;
				}
				datas[j].SetShow(active: true);
				datas[j].InitQuest(cq, Logic.GetDataByKeyName(Logic.DataQuest(cq, j)), Deploy, constrState);
			}
			if (constrState == ConstructionState.Forum)
			{
				LoadFromScheme();
			}
		}
		if (constrState == ConstructionState.Startup)
		{
			for (int k = 0; k < results.Count; k++)
			{
				if (Logic.ResultQuest(Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName), k) == "-")
				{
					results[k].SetShow(active: false);
					results[k].gameObject.SetActive(value: false);
				}
				else
				{
					results[k].gameObject.SetActive(value: true);
					results[k].InitQuest(Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName), Logic.GetResultByKeyName(Logic.ResultQuest(Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName), k)), Deploy, constrState, testMode);
				}
			}
			for (int l = 0; l < datas.Count; l++)
			{
				if (Logic.DataQuest(Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName), l) == "-")
				{
					datas[l].SetShow(active: false);
					continue;
				}
				datas[l].SetShow(active: true);
				datas[l].InitQuest(Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName), Logic.GetDataByKeyName(Logic.DataQuest(Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName), l)), Deploy, constrState);
			}
		}
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			ActiveComponent.Model.P.passedFirstQuest = 1;
		}
		else if (constrState == ConstructionState.Forum)
		{
			DeployBtn.gameObject.SetActive(value: false);
		}
		if (ActiveComponent.Model.P.passedFirstQuest == 0)
		{
			DeployBtn.gameObject.SetActive(value: false);
		}
		bool flag = ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.ShowCustomsTrigger);
		bool flag2 = true;
		if (cq == null || cq.KeyName != "TUTORIAL_STARTUP")
		{
			flag2 = false;
		}
		bool active = flag && constrState != ConstructionState.Forum && !flag2;
		CustomBlockBtn.gameObject.SetActive(active);
		CustomBlockLayer.gameObject.SetActive(value: false);
		active = ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.SandBoxTrigger) && constrState != ConstructionState.Forum && !flag2;
		LibraryBlockLayer.gameObject.SetActive(value: false);
		LibraryBlockBtn.gameObject.SetActive(active);
		flag = ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.ShowApplyDeploy);
		LockHide.gameObject.SetActive(!flag);
		Redraw(RedrawEnum.OnlyText);
		RefreshCathubs();
	}

	public void ReInitConstructionArea(CarQuest cq)
	{
		QuestLine.Quest currentQuest = QuestLine.GetCurrentQuest();
		SchemeName.text = Logic.GetShowNameById(QuestLine.GetCurrentQuestName());
		bool flag = currentQuest.IsCompleted();
		TuneButton.gameObject.SetActive(!flag);
		DeployBtn.gameObject.SetActive(value: false);
		TuneReleasedButton.gameObject.SetActive(flag);
		SaveReleasedWithTuneButton.gameObject.SetActive(flag);
		DeepTrafficEnvPresets carEnv = cq.CarEnv;
		if (carEnv.maxLanesSide > 0)
		{
			if (carEnv.maxPatchesBehind > carEnv.carHeight)
			{
				datas[2].SetShow(active: false);
				datas[0].SetShow(active: true);
				datas[0].InitAsProcessor(cq.LeftCarDatas);
				datas[1].SetShow(active: true);
				datas[1].InitAsProcessor(cq.FrontCarDatas);
				datas[3].SetShow(active: true);
				datas[3].InitAsProcessor(cq.BehindCarDatas);
				datas[4].SetShow(active: true);
				datas[4].InitAsProcessor(cq.RightCarDatas);
			}
			else
			{
				datas[2].SetShow(active: false);
				datas[3].SetShow(active: false);
				datas[0].SetShow(active: true);
				datas[0].InitAsProcessor(cq.LeftCarDatas);
				datas[1].SetShow(active: true);
				datas[1].InitAsProcessor(cq.FrontCarDatas);
				datas[4].SetShow(active: true);
				datas[4].InitAsProcessor(cq.RightCarDatas);
			}
		}
		else
		{
			datas[1].SetShow(active: true);
			datas[1].InitAsProcessor(cq.FrontCarDatas);
			datas[2].SetShow(active: false);
			datas[3].SetShow(active: false);
			datas[0].SetShow(active: false);
			datas[4].SetShow(active: false);
		}
		string[] statLists = new string[5] { cq.LeftStatList, cq.FrontStatList, null, cq.BehindStatList, cq.RightStatList };
		for (int i = 0; i < results.Count; i++)
		{
			if (i == 2)
			{
				results[i].SetShow(active: true);
				results[i].InitAsProcessor(testMode, cq.LeftCarDatas.need + cq.FrontCarDatas.need + cq.BehindCarDatas.need + cq.RightCarDatas.need, statLists);
			}
			else
			{
				results[i].SetShow(active: false);
			}
		}
		Cathub catHub = QuestLine.GetQuest(schemeStack.Top().GetBaseQuest().KeyName).GetCatHub();
		LoadFromScheme(catHub.GetSchemeBlock(catHub.GetCurrentScheme()));
	}

	private void DefaultTaskList()
	{
		selectedBlocks.Clear();
		Filter.text = "";
		predictMoneyInDeploy = 0f;
		BlocksContent.transform.parent.parent.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
		pause = false;
		if (testMode)
		{
			Time.timeScale = ActiveComponent.Model.P.rememberedSpeed;
		}
		else
		{
			Time.timeScale = 1f;
		}
		nodesState = NodesState.Base;
		bool flag = true;
		if (schemeStack.Top().keyName != "TUTORIAL_STARTUP")
		{
			flag = false;
		}
		CustomBlockBtn.gameObject.SetActive(!flag && ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.ShowCustomsTrigger));
		BaseBlockBtn.gameObject.SetActive(value: false);
		ImportConstructBlocks(redraw: false);
		end = false;
		timer = 0f;
		CtrlCtrlvButtonsStatesUpdate();
	}

	private bool SetConditionsInRuntime(int id)
	{
		if (id == -1)
		{
			return false;
		}
		QuestLine.Quest quest = QuestLine.GetCurrentQuest();
		if (constrState == ConstructionState.Forum)
		{
			quest = QuestLine.GetQuest(quest.GetForumQuest().QuestKeyName);
		}
		if (!quest.GetCondition(id).IsValid())
		{
			return false;
		}
		quest.SetCurrentCondition(id);
		ResetConditionsInRuntime();
		if (!Logic.CheckConditions((QuestCondition)quest.GetCondition(id), this))
		{
			return SetConditionsInRuntime(id - 1);
		}
		return true;
	}

	public void ResetConditions()
	{
		QuestLine.Quest currentQuest = QuestLine.GetCurrentQuest();
		rememberedConditionId = currentQuest.GetCurCondition();
		ResetConditionsInRuntime();
	}

	public void ResetConditionsInRuntime()
	{
		if (IsInNormalTaskRunMode())
		{
			QuestLine.Quest currentQuest = QuestLine.GetCurrentQuest();
			QuestLine.Quest quest = currentQuest;
			if (constrState == ConstructionState.Forum)
			{
				quest = QuestLine.GetQuest(currentQuest.GetForumQuest().QuestKeyName);
			}
			curCondition = (QuestCondition)quest.GetCondition(currentQuest.GetCurCondition());
			Medal.Init(currentQuest.GetName());
			Redraw(RedrawEnum.States);
		}
	}

	private void ApplyFilter()
	{
		if (Filter.text.Length <= 0)
		{
			foreach (GameObject showBlock in showBlocks)
			{
				showBlock.SetActive(value: true);
			}
			return;
		}
		foreach (GameObject showBlock2 in showBlocks)
		{
			showBlock2.SetActive(showBlock2.GetComponentInChildren<BlockData>().GetShowName().ToLower()
				.Contains(Filter.text.ToLower()));
		}
	}

	public void SetInfotutorialsState(bool state)
	{
		showBlocks.ForEach(delegate(GameObject block)
		{
			block.GetComponent<AlgoBlockDrag>().SetInfoTutorialState(state);
		});
	}

	private GameObject AddNodeToList(GameObject prefab, int i)
	{
		GameObject obj = ActiveComponent.Model.GetBaseBlockObjectFromPool(prefab, base.transform.position, base.transform.rotation, base.transform).gameObject;
		obj.GetComponent<BlockData>().Active(null, this);
		obj.GetComponent<BlockData>().StopHover();
		obj.transform.SetParent(showBlocks[i].transform);
		obj.transform.localPosition = Vector3.zero;
		_ = obj.transform.localScale;
		obj.transform.SetParent(baseBlock.transform);
		Vector3 localScale = obj.transform.localScale;
		localScale.Set(scaleX, scaleY, 1f);
		obj.transform.localScale = localScale;
		obj.transform.SetParent(showBlocks[i].transform);
		showBlocks[i].GetComponent<AlgoBlockDrag>().SetShowImage(ShowSaveImage);
		showBlocks[i].GetComponent<AlgoBlockDrag>().Init(prefab.name, BlockTutuorial, prefab, nodesState != NodesState.Base);
		showBlocks[i].GetComponent<AlgoBlockDrag>().UpdateLayerInfo();
		return obj;
	}

	private void AddCustomToList(GameObject prefab, int i, SchemeBlock iblock)
	{
		GameObject gameObject = AddNodeToList(prefab, i);
		showBlocks[i].GetComponent<AlgoBlockDrag>().Init(iblock.KeyName, BlockTutuorial, ConstructBlockObjects[i], nodesState != NodesState.Base);
		showBlocks[i].GetComponent<AlgoBlockDrag>().UpdateLayerInfo();
		gameObject.GetComponent<CustomBlock>().Init(iblock, flag: false);
		showBlocks[i].GetComponent<AlgoBlockDrag>().num = i;
		gameObject.name = gameObject.GetComponent<CustomBlock>().scheme.GetKeyName();
		showBlocks[i].name = gameObject.GetComponent<CustomBlock>().scheme.GetKeyName();
		gameObject.GetComponent<BlockData>().DeActive(disableSockets: true);
	}

	private void RedrawBlocks()
	{
		for (int i = 0; i < showBlocks.Count; i++)
		{
			BlockData componentInChildren = showBlocks[i].GetComponentInChildren<BlockData>();
			if (componentInChildren != null)
			{
				componentInChildren.RemoveCustomBlockListenerBeforeDelete();
			}
			BaseBlock componentInChildren2 = showBlocks[i].GetComponentInChildren<BaseBlock>();
			if (componentInChildren2 != null)
			{
				if (!Logic.IsBaseBlock(componentInChildren2.gameObject.name))
				{
					componentInChildren2.gameObject.name = "CUSTOM";
				}
				ActiveComponent.Model.DisableBaseBlockObj(componentInChildren2);
			}
			UnityEngine.Object.Destroy(showBlocks[i]);
		}
		showBlocks.Clear();
		for (int j = 0; j < ConstructBlockObjects.Count; j++)
		{
			GameObject gameObjectFromPool = ActiveComponent.Model.GetGameObjectFromPool(BlockSpawn, base.transform.position, base.transform.rotation, BlocksContent.transform);
			gameObjectFromPool.transform.localScale = Vector3.one;
			gameObjectFromPool.name = ConstructBlockObjects[j].name;
			showBlocks.Add(gameObjectFromPool);
		}
		List<string> listCompleted = QuestLine.GetListCompleted();
		string text = "";
		for (int k = 0; k < ActiveComponent._staticData.ConstructionBlocks.Count; k++)
		{
			if (UnlockGroup.IsUnlocked(ActiveComponent._staticData.ConstructionBlocks[k].ReqUnlockGroups) && ActiveComponent._staticData.ConstructionBlocks[k].LockSandbox == 0)
			{
				bool flag = ActiveComponent.Model.P.extraUnlockedAlgos.Contains(ActiveComponent._staticData.ConstructionBlocks[k].KeyName);
				if (ActiveComponent._staticData.ConstructionBlocks[k].Extra == 0 || flag)
				{
					text = text + ActiveComponent._staticData.ConstructionBlocks[k].KeyName + ", ";
				}
			}
		}
		for (int l = 0; l < ConstructBlockObjects.Count; l++)
		{
			if (nodesState == NodesState.Customs)
			{
				SchemeBlock schemeCustomBlockByKeyName = Logic.GetSchemeCustomBlockByKeyName(listCompleted[l]);
				if (schemeCustomBlockByKeyName != null)
				{
					schemeCustomBlockByKeyName.ReInit();
					if (IsInNormalTaskRunMode())
					{
						if (schemeCustomBlockByKeyName.KeyName.GetHashCode() != QuestLine.GetCurrentQuest().GetName().GetHashCode())
						{
							ConstructionQuest currentTableQuest = Logic.GetCurrentTableQuest();
							if (schemeCustomBlockByKeyName.onlyLegalBlocks(currentTableQuest.UnlockedBlocks, currentTableQuest.KeyName + "," + QuestLine.GetCurrentQuest().GetName()) && schemeCustomBlockByKeyName.blocks.Count > 0)
							{
								AddCustomToList(customBlock, l, schemeCustomBlockByKeyName);
							}
							else
							{
								showBlocks[l].name = BlockSpawn.name;
								ActiveComponent.Model.DisableGameObj(showBlocks[l]);
								showBlocks[l] = null;
							}
						}
						else
						{
							showBlocks[l].name = BlockSpawn.name;
							ActiveComponent.Model.DisableGameObj(showBlocks[l]);
							showBlocks[l] = null;
						}
					}
					if (constrState == ConstructionState.CarTask)
					{
						if (schemeCustomBlockByKeyName.KeyName.GetHashCode() != QuestLine.GetCurrentQuest().GetName().GetHashCode())
						{
							CarQuest currentCarQuest = QuestLine.GetCurrentCarQuest();
							if (schemeCustomBlockByKeyName.onlyLegalBlocks(currentCarQuest.UnlockedBlocks, currentCarQuest.KeyName + "," + QuestLine.GetCurrentQuest().GetName()) && schemeCustomBlockByKeyName.blocks.Count > 0)
							{
								AddCustomToList(customBlock, l, schemeCustomBlockByKeyName);
							}
							else
							{
								showBlocks[l].name = BlockSpawn.name;
								ActiveComponent.Model.DisableGameObj(showBlocks[l]);
								showBlocks[l] = null;
							}
						}
						else
						{
							showBlocks[l].name = BlockSpawn.name;
							ActiveComponent.Model.DisableGameObj(showBlocks[l]);
							showBlocks[l] = null;
						}
					}
					if (constrState == ConstructionState.Startup)
					{
						ConstructionQuest taskByKeyName = Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName);
						if (schemeCustomBlockByKeyName.onlyLegalBlocks(taskByKeyName.UnlockedBlocks, "") && schemeCustomBlockByKeyName.blocks.Count > 0)
						{
							AddCustomToList(customBlock, l, schemeCustomBlockByKeyName);
						}
						else
						{
							showBlocks[l].name = BlockSpawn.name;
							ActiveComponent.Model.DisableGameObj(showBlocks[l]);
							showBlocks[l] = null;
						}
					}
					if (constrState == ConstructionState.SandBox)
					{
						if (schemeCustomBlockByKeyName.onlyLegalBlocks(text, schemeStack.Top().keyName) && schemeCustomBlockByKeyName.blocks.Count > 0)
						{
							AddCustomToList(customBlock, l, schemeCustomBlockByKeyName);
						}
						else
						{
							showBlocks[l].name = BlockSpawn.name;
							ActiveComponent.Model.DisableGameObj(showBlocks[l]);
							showBlocks[l] = null;
						}
					}
				}
				else
				{
					showBlocks[l].name = BlockSpawn.name;
					ActiveComponent.Model.DisableGameObj(showBlocks[l]);
					showBlocks[l] = null;
				}
			}
			if (nodesState == NodesState.SandBox)
			{
				string key = "SANDBOX" + l;
				SchemeBlock useAsCustomScheme = ActiveComponent.Model.P.sandboxSchemes[key].GetUseAsCustomScheme();
				if (useAsCustomScheme != null)
				{
					useAsCustomScheme.ReInit();
					switch (constrState)
					{
					case ConstructionState.SandBox:
						if (schemeStack.Top().keyName.GetHashCode() != useAsCustomScheme.KeyHash)
						{
							if (useAsCustomScheme.onlyLegalBlocks(text, schemeStack.Top().keyName))
							{
								if (useAsCustomScheme.blocks.Count > 0)
								{
									AddCustomToList(customBlock, l, useAsCustomScheme);
									break;
								}
								showBlocks[l].name = BlockSpawn.name;
								ActiveComponent.Model.DisableGameObj(showBlocks[l]);
								showBlocks[l] = null;
							}
							else
							{
								showBlocks[l].name = BlockSpawn.name;
								ActiveComponent.Model.DisableGameObj(showBlocks[l]);
								showBlocks[l] = null;
							}
						}
						else
						{
							showBlocks[l].name = BlockSpawn.name;
							ActiveComponent.Model.DisableGameObj(showBlocks[l]);
							showBlocks[l] = null;
						}
						break;
					case ConstructionState.Task:
					case ConstructionState.Forum:
						useAsCustomScheme.ReInit();
						if (useAsCustomScheme.KeyName.GetHashCode() != QuestLine.GetCurrentQuest().GetName().GetHashCode())
						{
							ConstructionQuest currentTableQuest2 = Logic.GetCurrentTableQuest();
							if (useAsCustomScheme.onlyLegalBlocks(currentTableQuest2.UnlockedBlocks, currentTableQuest2.KeyName + "," + QuestLine.GetCurrentQuest().GetName()) && useAsCustomScheme.blocks.Count > 0)
							{
								AddCustomToList(customBlock, l, useAsCustomScheme);
								break;
							}
							showBlocks[l].name = BlockSpawn.name;
							ActiveComponent.Model.DisableGameObj(showBlocks[l]);
							showBlocks[l] = null;
						}
						else
						{
							showBlocks[l].name = BlockSpawn.name;
							ActiveComponent.Model.DisableGameObj(showBlocks[l]);
							showBlocks[l] = null;
						}
						break;
					case ConstructionState.Startup:
					{
						ConstructionQuest taskByKeyName2 = Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName);
						if (useAsCustomScheme.onlyLegalBlocks(taskByKeyName2.UnlockedBlocks, "") && useAsCustomScheme.blocks.Count > 0)
						{
							AddCustomToList(customBlock, l, useAsCustomScheme);
							break;
						}
						showBlocks[l].name = BlockSpawn.name;
						ActiveComponent.Model.DisableGameObj(showBlocks[l]);
						showBlocks[l] = null;
						break;
					}
					}
				}
				else
				{
					showBlocks[l].name = BlockSpawn.name;
					ActiveComponent.Model.DisableGameObj(showBlocks[l]);
					showBlocks[l] = null;
				}
			}
			if (nodesState == NodesState.Base)
			{
				GameObject obj = AddNodeToList(ConstructBlockObjects[l], l);
				obj.name = ConstructBlockObjects[l].name;
				showBlocks[l].name = ConstructBlockObjects[l].name;
				obj.GetComponent<BlockData>().DeActive(disableSockets: true);
			}
		}
		for (int m = 0; m < showBlocks.Count; m++)
		{
			if (showBlocks[m] == null)
			{
				ConstructBlockObjects.RemoveAt(m);
				showBlocks.RemoveAt(m);
				m--;
			}
		}
	}

	public int GetCustomBlocksInScheme()
	{
		int num = 0;
		foreach (BlockInScheme item in blocksInScheme)
		{
			if (!Logic.IsBaseBlock(item.go.name))
			{
				num++;
			}
		}
		return num;
	}

	public void Redraw(RedrawEnum resetRedraw = RedrawEnum.OnlyTime)
	{
		if (resetRedraw < this.resetRedraw)
		{
			this.resetRedraw = resetRedraw;
		}
		updateRedraw = true;
	}

	private void DefaultRedraw()
	{
		moneyValue.gameObject.SetActive(value: false);
		updateRedraw = false;
		ActiveComponent.Model.curSpeed = 1f;
		TaskId.gameObject.SetActive(value: false);
		SchemeName.gameObject.SetActive(value: false);
		Medal.gameObject.SetActive(value: false);
		ZoomPlus.gameObject.SetActive(value: false);
		ZoomMinus.gameObject.SetActive(value: false);
		ZoomMinusDisabled.gameObject.SetActive(value: false);
		ZoomPlusDisabled.gameObject.SetActive(value: false);
		TaskId.text = "";
		DynamicMoney.gameObject.SetActive(value: false);
		MoneySpent.gameObject.SetActive(value: false);
		DynamicTime.gameObject.SetActive(value: false);
		AvDestTime.gameObject.SetActive(value: false);
		StaticReward.gameObject.SetActive(value: false);
		ServersLimit.gameObject.SetActive(value: false);
		CustomBlockLimit.gameObject.SetActive(value: false);
		BlockLimit.gameObject.SetActive(value: true);
		UsersDay.gameObject.SetActive(value: false);
		StaticServ.gameObject.SetActive(value: false);
		ClearAll.interactable = blocksInScheme.Count != 0;
		SelectAllBtn.interactable = blocksInScheme.Count != 0;
		CtrlC.gameObject.SetActive(value: false);
		CtrlV.gameObject.SetActive(value: false);
	}

	private void RedrawTask()
	{
		if (resetRedraw == RedrawEnum.Full)
		{
			moneyValue.gameObject.SetActive(value: false);
			TaskId.gameObject.SetActive(value: true);
			SchemeName.gameObject.SetActive(value: true);
			Medal.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.MedalTrigger) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.MedalTrigger).IsTaskOpened());
			CtrlC.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
			CtrlV.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
			RedoUndoButtonsStatesUpdate();
			ZoomPlus.gameObject.SetActive(value: false);
			ZoomMinus.gameObject.SetActive(value: false);
			ZoomMinusDisabled.gameObject.SetActive(value: false);
			ZoomPlusDisabled.gameObject.SetActive(value: false);
			TaskId.text = Logic.ColorTransform("GREEN", TextResources.GetString(QuestLine.GetCurrentQuest().GetTexts() + "SHORTT"));
			DynamicTime.gameObject.SetActive(!ActiveComponent.Model.trainTest);
			ServersLimit.gameObject.SetActive(value: true);
			StaticServ.gameObject.SetActive(value: true);
			DynamicMoney.gameObject.SetActive(value: false);
			MoneySpent.gameObject.SetActive(value: false);
			if (!testCompleted && ActiveComponent._staticData.Settings.ShowFirstNonForumQuestTutorial == QuestLine.GetCurrentQuestName() && ActiveComponent.Model.P.firstNonForumQuestTutorial == 0)
			{
				DeployBtn.gameObject.SetActive(value: false);
			}
		}
		if (resetRedraw <= RedrawEnum.States)
		{
			bool flag = ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.ShowServersTrigger);
			bool flag2 = curCondition.Servers != -1;
			ServersLimit.gameObject.SetActive(flag2 && flag);
			StaticReward.gameObject.SetActive(!QuestLine.GetCurrentQuest().IsCompleted());
			BlockLimit.gameObject.SetActive(curCondition != null && curCondition.Blocks != -1);
			flag = ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.ShowCustomsTrigger);
			CustomBlockLimit.gameObject.SetActive(curCondition != null && curCondition.CustomBlocks != -1);
		}
		if (resetRedraw <= RedrawEnum.OnlyText)
		{
			float num = GetMoneyPerSecond();
			StaticServ.text = Logic.ColorTransform("RED", num + " $" + TextResources.GetString("SLSEC"));
			ServersLimit.text = GetServersCouInSheme() + " / " + curCondition.Servers;
			CustomBlockLimit.text = GetCustomBlocksCou() + " / " + curCondition.CustomBlocks;
			BlockLimit.text = GetBlocksCou() + " / " + curCondition.Blocks;
			StaticReward.text = Logic.ColorTransform("MONEY", QuestLine.GetCurrentQuest().GetRewardFromMedal(QuestLine.GetCurrentQuest().GetCurCondition()) + " $");
		}
		float num2 = curCondition.Time - timer;
		moneyValue.text = Logic.ColorTransform("MONEY", ActiveComponent.Model.P.Money + " $");
		DynamicTime.text = Logic.ColorTransform("TIME", (int)(num2 * 10f) / 10 + "." + Mathf.CeilToInt(num2 * 10f) % 10 + " " + TextResources.GetString("SEC"));
		if (ActiveComponent.Model.trainTest && QuestLine.GetCurrentQuest().GetTableQuest().OnlyAcc == 1)
		{
			SetInfinityDynamicTime();
		}
	}

	private void RedrawForum()
	{
		if (resetRedraw == RedrawEnum.Full)
		{
			TaskId.gameObject.SetActive(value: true);
			SchemeName.gameObject.SetActive(value: true);
			TaskId.text = Logic.ColorTransform("GREEN", TextResources.GetString(QuestLine.GetCurrentQuest().GetTexts() + "SHORTT"));
			DynamicTime.gameObject.SetActive(!ActiveComponent.Model.trainTest && schemeStack.Top().keyName != ActiveComponent._staticData.ForumQuests[0].KeyName);
			ServersLimit.gameObject.SetActive(value: true);
			CtrlC.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
			CtrlV.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
			RedoUndoButtonsStatesUpdate();
		}
		if (resetRedraw <= RedrawEnum.States)
		{
			bool flag = ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.ShowServersTrigger);
			ServersLimit.gameObject.SetActive(curCondition.Servers != -1 && flag);
			BlockLimit.gameObject.SetActive(curCondition.Blocks != -1 && schemeStack.Top().keyName != ActiveComponent._staticData.ForumQuests[0].KeyName);
			flag = ActiveComponent.Model.curPreview.IsQuestAvailable(ActiveComponent._staticData.Settings.ShowCustomsTrigger);
			CustomBlockLimit.gameObject.SetActive(curCondition.CustomBlocks != -1);
		}
		if (resetRedraw <= RedrawEnum.OnlyText)
		{
			ServersLimit.text = GetServersCouInSheme() + " / " + curCondition.Servers;
			CustomBlockLimit.text = GetCustomBlocksCou() + " / " + curCondition.CustomBlocks;
			BlockLimit.text = GetBlocksCou() + " / " + curCondition.Blocks;
		}
		float num = curCondition.Time - timer;
		DynamicTime.text = Logic.ColorTransform("TIME", Math.Max(0.0, Math.Round(num, 1)) + " " + TextResources.GetString("SEC"));
		if (ActiveComponent.Model.trainTest && QuestLine.GetQuest(QuestLine.GetCurrentQuest().GetForumQuest().QuestKeyName).GetTableQuest().OnlyAcc == 1)
		{
			SetInfinityDynamicTime();
		}
	}

	private void RedrawStartup()
	{
		if (resetRedraw == RedrawEnum.Full)
		{
			TaskId.gameObject.SetActive(value: true);
			TaskId.text = Logic.ColorTransform("GREEN", TextResources.GetString(ActiveComponent.Model.curStartup.Texts + "SHORTT"));
			StaticServ.gameObject.SetActive(value: true);
			DeployBtn.gameObject.SetActive(ActiveComponent.Model.P.startupComicsTutorial == 1 || ActiveComponent.Model.curStartup.KeyName != ActiveComponent._staticData.Settings.StartupComicsTrigger);
			TestButton.gameObject.SetActive(!DeployBtn.gameObject.activeSelf);
			TestFirst.gameObject.SetActive(DeployBtn.gameObject.activeSelf && !StopButton.gameObject.activeSelf);
			CtrlC.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
			CtrlV.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
			RedoUndoButtonsStatesUpdate();
		}
		float num = GetMoneyPerSecond();
		StaticServ.text = Logic.ColorTransform("RED", num + " $" + TextResources.GetString("SLSEC"));
		BlockLimit.text = GetBlocksCou() + " / " + ((QuestCondition)QuestLine.GetQuest(ActiveComponent.Model.curStartup.TaskKeyName).GetCondition(2)).Blocks;
	}

	private void RedrawSandbox()
	{
		if (resetRedraw == RedrawEnum.Full)
		{
			SchemeName.gameObject.SetActive(value: true);
			StaticServ.gameObject.SetActive(value: true);
			TuneButton.gameObject.SetActive(value: false);
			TuneReleasedButton.gameObject.SetActive(value: false);
			SaveReleasedWithTuneButton.gameObject.SetActive(value: false);
			TaskId.gameObject.SetActive(value: true);
			TaskId.text = Logic.ColorTransform("GREEN", TextResources.GetString("DLL_SLOT") + " " + ActiveComponent.Model.P.lastOpenSandbox);
			CtrlC.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
			CtrlV.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
			RedoUndoButtonsStatesUpdate();
		}
		float num = GetMoneyPerSecond();
		StaticServ.text = Logic.ColorTransform("RED", num + " $" + TextResources.GetString("SLSEC"));
		BlockLimit.text = GetBlocksCou() + " / " + ActiveComponent._staticData.Settings.MaxSandboxBlocks;
	}

	private void RedrawCarTask()
	{
		if (!end)
		{
			CarQuest quest = schemeStack.Top().GetQuest<CarQuest>();
			if (resetRedraw == RedrawEnum.Full)
			{
				SchemeName.gameObject.SetActive(value: true);
				TaskId.gameObject.SetActive(value: true);
				TaskId.text = Logic.ColorTransform("GREEN", TextResources.GetString(QuestLine.GetCurrentQuest().GetTexts() + "SHORTT"));
				DeepTrafficQuestControllerTaskId.text = Logic.ColorTransform("GREEN", TextResources.GetString(QuestLine.GetCurrentQuest().GetTexts() + "SHORTT"));
				CtrlC.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
				CtrlV.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
				RedoUndoButtonsStatesUpdate();
			}
			float num = GetMoneyPerSecond();
			StaticServ.text = Logic.ColorTransform("RED", num + " $" + TextResources.GetString("SLSEC"));
			ServersLimit.gameObject.SetActive(quest.ServersLimit != -1);
			CustomBlockLimit.gameObject.SetActive(quest.CustomsLimit != -1);
			AvDestTime.text = Logic.ColorTransform("TIME", RoundFloatTostr(GetAvDestTime()) + " " + TextResources.GetString("SEC"));
			ServersLimit.text = GetServersCouInSheme() + " / " + quest.BlocksLimit;
			CustomBlockLimit.text = GetCustomBlocksCou() + " / " + quest.CustomsLimit;
			BlockLimit.text = GetBlocksCou() + " / " + quest.BlocksLimit;
		}
	}

	public void PerformRedraw()
	{
		updateRedraw = false;
		ActiveComponent.Model.curSpeed = 1f;
		if (resetRedraw == RedrawEnum.Full)
		{
			DefaultRedraw();
		}
		if (constrState == ConstructionState.Task)
		{
			RedrawTask();
		}
		else if (constrState == ConstructionState.SandBox)
		{
			RedrawSandbox();
		}
		else if (constrState == ConstructionState.Startup)
		{
			RedrawStartup();
		}
		else if (constrState == ConstructionState.CarTask)
		{
			RedrawCarTask();
		}
		else if (constrState == ConstructionState.Forum)
		{
			RedrawForum();
		}
		resetRedraw = RedrawEnum.OnlyTime;
	}

	private string RoundFloatTostr(float f)
	{
		return (int)(f * 10f) / 10 + "." + (int)(f * 10f) % 10;
	}

	private int GetUsersInDay()
	{
		int num = 0;
		foreach (Result result in results)
		{
			if (result.gameObject.activeSelf)
			{
				num += result.GetStartupUsersInDay();
			}
		}
		return num;
	}

	private float GetAvDestTime()
	{
		return results.Average((Result res) => (!res.gameObject.activeInHierarchy || res.curElems == 0) ? ((float?)null) : new float?(res.avarageGoTime)).GetValueOrDefault();
	}

	private void RecalcStatsInScheme()
	{
		moneyPerSecond = GetMoneyPerSecond();
		moneyPerSecond *= moneyCoef;
		Redraw(RedrawEnum.OnlyText);
	}

	public int GetServersCouInSheme()
	{
		int num = 0;
		foreach (BlockInScheme item in blocksInScheme)
		{
			num += Logic.GetServersCouInBlock(item.keyname);
		}
		if (num == 0 && blocksInScheme.Count > 0)
		{
			num = 1;
		}
		return num;
	}

	public int GetBlocksCou()
	{
		int num = 0;
		foreach (BlockInScheme item in blocksInScheme)
		{
			num = ((!Logic.IsBaseBlock(item.keyname) || !(item.keyname != "REMOVE")) ? (num + Logic.GetBlocksCouInSheme(item.keyname)) : (num + 1));
		}
		if (GetRemoveCou() > 0)
		{
			num++;
		}
		return num;
	}

	public int GetRemoveCou()
	{
		int num = 0;
		foreach (BlockInScheme item in blocksInScheme)
		{
			num = ((!(item.keyname == "REMOVE")) ? (num + Logic.GetRemoveCouInSheme(item.keyname)) : (num + 1));
		}
		return num;
	}

	public int GetCustomBlocksCou()
	{
		int num = 0;
		foreach (BlockInScheme item in blocksInScheme)
		{
			if (!Logic.IsBaseBlock(item.keyname))
			{
				num += Logic.GetCustomBlockCouInSheme(item.keyname);
			}
		}
		return num;
	}

	public float GetSocketSleep()
	{
		float num = 0f;
		Socket[] componentsInChildren = base.gameObject.GetComponentsInChildren<Socket>();
		Socket[] array = componentsInChildren;
		foreach (Socket socket in array)
		{
			if (socket.resultNum == -1 && socket.dataNum == -1 && socket.inGame && socket.gameObject.transform.parent.gameObject.name != "REMOVE")
			{
				num += socket.emptyTime;
			}
		}
		return num / (float)componentsInChildren.Length;
	}

	public float GetSocketOverLoad()
	{
		float num = 0f;
		Socket[] componentsInChildren = base.gameObject.GetComponentsInChildren<Socket>();
		Socket[] array = componentsInChildren;
		foreach (Socket socket in array)
		{
			if (socket.resultNum == -1 && socket.dataNum == -1 && socket.inGame && socket.gameObject.transform.parent.gameObject.name != "REMOVE")
			{
				num += socket.overloadTime;
			}
		}
		return num / (float)componentsInChildren.Length;
	}

	public bool CheckDelete(GameObject go)
	{
		if (go == null)
		{
			return false;
		}
		BlockInScheme blockInScheme = blocksInScheme.Find((BlockInScheme block) => block.go == go);
		if (blockInScheme == null)
		{
			foreach (BlockInScheme item in blocksInScheme)
			{
				if (item.go.transform.parent == go.transform)
				{
					ActiveComponent.Model.DisableBaseBlockObj(item.go.GetComponent<BaseBlock>());
				}
			}
			ActiveComponent.Model.DisableBaseBlockObj(go.GetComponent<BaseBlock>());
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Block_Remove");
			return true;
		}
		AddBlockToSelection(blockInScheme, null, alwaysSelect: true);
		return CheckDelete(blockInScheme);
	}

	public bool CheckDelete(BlockInScheme blockToDelete = null)
	{
		if (blockToDelete != null && IsInDeleteZone(blockToDelete.go))
		{
			DeletePressMultipleBlocks();
		}
		return false;
	}

	public bool IsInDeleteZone(GameObject go)
	{
		if (!ContainsConstruct(go) || ContainsBase(go))
		{
			return true;
		}
		if (PlaceNodeTutorial.gameObject.activeInHierarchy)
		{
			Vector3[] worldCorners = Helper.GetWorldCorners(go.transform.GetComponent<RectTransform>());
			foreach (Vector3 point in worldCorners)
			{
				if (!Helper.GetWorldRect(PlaceNodeTutorial).Contains(point))
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	private bool TooManyNodesCheck()
	{
		int num = 50;
		QuestCondition questCondition = null;
		num = ActiveComponent._staticData.Settings.MaxSandboxBlocks;
		if (constrState == ConstructionState.Startup)
		{
			questCondition = (QuestCondition)QuestLine.GetQuest(ActiveComponent.Model.curStartup.TaskKeyName).GetCondition(2);
			num = questCondition.Blocks;
		}
		if (constrState == ConstructionState.Task)
		{
			questCondition = (QuestCondition)QuestLine.GetCurrentQuest().GetCondition(0);
		}
		if (constrState == ConstructionState.Forum)
		{
			questCondition = (QuestCondition)QuestLine.GetQuest(QuestLine.GetCurrentQuest().GetForumQuest().QuestKeyName).GetCondition(0);
		}
		if (constrState != ConstructionState.SandBox && constrState != ConstructionState.CarTask)
		{
			num = questCondition.Blocks;
			if (questCondition.Blocks == -1)
			{
				num = 50;
			}
		}
		if (constrState == ConstructionState.CarTask)
		{
			num = schemeStack.Top().GetQuest<CarQuest>().BlocksLimit;
		}
		return GetBlocksCou() > num;
	}

	private void CheckSpawn()
	{
		if (attached != null)
		{
			return;
		}
		for (int i = 0; i < showBlocks.Count; i++)
		{
			if (showBlocks[i] == null)
			{
				ConstructBlockObjects.RemoveAt(i);
				showBlocks.RemoveAt(i);
				i--;
			}
		}
		for (int j = 0; j < showBlocks.Count; j++)
		{
			if (showBlocks[j].GetComponent<AlgoBlockDrag>().dragged)
			{
				AttachNewBlockToMouse(j);
				showBlocks[j].GetComponent<AlgoBlockDrag>().dragged = false;
				if (CustomTutorialWindow.gameObject.activeSelf)
				{
					CustomTutorialWindow.NextClick();
				}
			}
		}
	}

	private void DrawPOVsOnConstrAreaBorders()
	{
		blocksInScheme.ForEach(delegate(BlockInScheme block)
		{
			block.ResetPOV();
		});
	}

	private void DeletePressMultipleBlocks()
	{
		List<BlockInScheme> list = new List<BlockInScheme>();
		foreach (BlockInScheme item in blocksInScheme)
		{
			if (item.BlockData().IsSelected())
			{
				list.Add(item);
			}
		}
		selectedBlocks.Clear();
		foreach (BlockInScheme item2 in list)
		{
			DeletePress(item2);
		}
		if (list.Count > 0 && attached == null)
		{
			deleteEvent.Invoke();
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Block_Remove");
			GetCurCathub().RecordHistory();
			RedoUndoButtonsStatesUpdate();
		}
	}

	private void DeletePress(BlockInScheme blockToDelete = null)
	{
		BlockInScheme blockInScheme = blockToDelete;
		if (blockInScheme == null)
		{
			for (int i = 0; i < blocksInScheme.Count; i++)
			{
				if (blocksInScheme[i].BlockData().hover)
				{
					blockInScheme = blocksInScheme[i];
					break;
				}
			}
		}
		if (blockInScheme != null)
		{
			curBlocks--;
			RemoveBlockFromScheme(blockInScheme);
			RecalcStatsInScheme();
			Redraw(RedrawEnum.OnlyText);
		}
	}

	private void CheckButtonsActive()
	{
		if (true)
		{
			_ = !HasFreeOutSockets();
		}
		else
			_ = 0;
	}

	private void UpdateSpeedActiveBtns()
	{
		MinusSpeed.gameObject.SetActive(!(SpeedCoef < 0.6f) && testMode);
		PlusSpeed.gameObject.SetActive(!(SpeedCoef > 2.9f) && testMode);
	}

	public void UpdateSpeed(float speed)
	{
		SpeedCoef = speed;
		UpdateSpeedActiveBtns();
		Time.timeScale = SpeedCoef;
		Speed.text = "x" + (float)(int)(SpeedCoef * 2f) / 2f;
		ActiveComponent.Model.P.rememberedSpeed = speed;
		if (!testMode)
		{
			Time.timeScale = 1f;
		}
	}

	public float GetMoneyPerSecond()
	{
		float num = 0f;
		foreach (BlockInScheme item in blocksInScheme)
		{
			num += (float)Logic.GetServersCouInBlock(item.keyname);
		}
		if (num < 0.01f)
		{
			num = 1f;
		}
		if (blocksInScheme.Count == 0)
		{
			num = 0f;
		}
		num *= (float)ActiveComponent._staticData.Settings.ServerCost * (1f - ActiveComponent.Model.P.upgradeStats.ServersCostBonus);
		realMoneyPerSecond = (float)Math.Round(num, 3);
		curMoneyPerSecond = realMoneyPerSecond;
		return curMoneyPerSecond;
	}

	private void BonusClick()
	{
		BonusLayer.gameObject.SetActive(!BonusLayer.gameObject.activeSelf);
	}

	private Rect GetAlgoRect()
	{
		if (!algoRectInited)
		{
			algoRectInited = true;
			algoRect = Helper.GetWorldRect(algoBlock.GetComponent<RectTransform>());
			algoInRect = Helper.ExpandRect(algoRect, -10f);
		}
		return algoRect;
	}

	public Transform GetAlgoTransform()
	{
		if (!algoBlockParent)
		{
			algoBlockParent = algoBlock.Find("AlgoBlockParent");
			algoBlockParentPosition = algoBlockParent.position;
		}
		return algoBlockParent;
	}

	public static Rect GetBlockRect(GameObject block, float border = 5f)
	{
		if (block == null)
		{
			return Rect.MinMaxRect(0f, 0f, 0f, 0f);
		}
		Rect worldRect = Helper.GetWorldRect(block.GetComponent<RectTransform>());
		if (border != 0f)
		{
			worldRect.xMin -= border;
			worldRect.yMin -= border;
			worldRect.xMax += border;
			worldRect.yMax += border;
		}
		return worldRect;
	}

	public static Rect GetBlockRect(BlockInScheme block)
	{
		return GetBlockRect(block.go);
	}

	private Vector3 ScreenToWorld(float x, float y, float z = 1f)
	{
		Vector3 one = Vector3.one;
		one.Set(x, y, z);
		return Camera.main.ScreenToWorldPoint(one);
	}

	public BlockInScheme GetBlockUnderCursor(List<BlockInScheme> blocks = null, bool checkHoverOnly = false)
	{
		if (blocks == null)
		{
			blocks = blocksInScheme;
		}
		Vector3 mouseInWorld = Logic.GetMouseInWorld();
		blockHierarchy.Clear();
		foreach (BlockInScheme block in blocks)
		{
			if (block == null)
			{
				continue;
			}
			if (checkHoverOnly)
			{
				if (block.BlockData().hover)
				{
					blockHierarchy.Add(block);
				}
			}
			else if (GetBlockRect(block).Contains(mouseInWorld))
			{
				blockHierarchy.Add(block);
			}
		}
		if (blockHierarchy.Count == 0)
		{
			return null;
		}
		_ = blockHierarchy[0].go.transform.parent;
		blockHierarchy.Sort((BlockInScheme a, BlockInScheme b) => (a.GetParentChildIndex() <= b.GetParentChildIndex()) ? 1 : (-1));
		return blockHierarchy[0];
	}

	public static Rect GetMultipleBlocksRect(List<BlockInScheme> blocks)
	{
		if (blocks.Count == 0)
		{
			return Rect.MinMaxRect(0f, 0f, 0f, 0f);
		}
		Rect result = GetBlockRect(blocks[0]);
		for (int i = 1; i < blocks.Count; i++)
		{
			Rect rect = GetBlockRect(blocks[i]);
			if (rect.xMin < result.xMin)
			{
				result.xMin = rect.xMin;
			}
			if (rect.yMin < result.yMin)
			{
				result.yMin = rect.yMin;
			}
			if (rect.xMax > result.xMax)
			{
				result.xMax = rect.xMax;
			}
			if (rect.yMax > result.yMax)
			{
				result.yMax = rect.yMax;
			}
		}
		return result;
	}

	private Vector3 GetSnappedBlockPosition(Vector3 position, Rect blocksRect, Rect snapRect)
	{
		Vector3 result = position;
		if (blocksRect.yMin < snapRect.yMin)
		{
			result.y += snapRect.yMin - blocksRect.yMin + selectionMargin.y;
		}
		else if (blocksRect.yMax > snapRect.yMax)
		{
			result.y -= blocksRect.yMax - snapRect.yMax + selectionMargin.y;
		}
		if (blocksRect.xMin < snapRect.xMin)
		{
			result.x += snapRect.xMin - blocksRect.xMin + selectionMargin.x;
		}
		else if (blocksRect.xMax > snapRect.xMax)
		{
			result.x -= blocksRect.xMax - snapRect.xMax + selectionMargin.x;
		}
		return result;
	}

	private void OnGUI()
	{
		if (selectionMode && selectionRect.width > 3f && selectionRect.height > 3f)
		{
			GUI.Box(selectionRect, (Texture)null);
		}
	}

	public void DropSelection(bool ignoreConditions = false)
	{
		if (selectedBlocks.Count <= 0)
		{
			return;
		}
		foreach (BlockInScheme item in blocksInScheme)
		{
			DropBlockSelection(item, removeFromList: false, ignoreConditions);
		}
		selectedBlocks.Clear();
		CtrlCtrlvButtonsStatesUpdate();
	}

	public void DropBlockSelectionAction(GameObject go)
	{
		BlockInScheme block = blocksInScheme.Find((BlockInScheme b) => b.go == go);
		DropBlockSelection(block);
		selectedBlocks.ForEach(delegate(BlockInScheme b)
		{
			b.SetParent(GetAlgoTransform());
		});
		CtrlCtrlvButtonsStatesUpdate();
	}

	private void DropBlockSelection(BlockInScheme block, bool removeFromList = true, bool ignoreConditions = false)
	{
		block.BlockData().SetSelected(state: false, ignoreConditions);
		block.SetParent(GetAlgoTransform());
		if (removeFromList)
		{
			selectedBlocks.Remove(block);
			CtrlCtrlvButtonsStatesUpdate();
		}
	}

	private void AddBlockToSelection(BlockInScheme block, BlockInScheme parent = null, bool alwaysSelect = false)
	{
		if (alwaysSelect || interactState != DragInteraction.ConstrArea || ActiveComponent.Model.construction.longTap == OneTouchState.Long)
		{
			block.BlockData().SetSelected(state: true, alwaysSelect);
			if (parent != null)
			{
				block.SetParent(parent);
			}
			if (selectedBlocks.Find((BlockInScheme p) => p == block) == null)
			{
				block.go.transform.SetAsLastSibling();
				selectedBlocks.Add(block);
				CtrlCtrlvButtonsStatesUpdate();
			}
		}
	}

	private bool CheckPointInsideConstrBlock(Vector3 point)
	{
		return Helper.IsVector2InWorldRect(constrBlock, point);
	}

	private bool CheckPointOutsideAllBaseBlocks(Vector3 point)
	{
		BaseBlock[] componentsInChildren = algoBlock.GetComponentsInChildren<BaseBlock>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (Helper.IsVector2InWorldRect(componentsInChildren[i].GetComponent<RectTransform>(), point))
			{
				return false;
			}
		}
		return true;
	}

	public bool CanPlaceInConstrBlock()
	{
		if (PlaceNodeTutorial.gameObject.activeInHierarchy)
		{
			Vector3[] worldCorners = Helper.GetWorldCorners(attached.transform.GetComponent<RectTransform>());
			foreach (Vector3 point in worldCorners)
			{
				if (!Helper.GetWorldRect(PlaceNodeTutorial).Contains(point))
				{
					return false;
				}
			}
			return true;
		}
		return CheckPointInsideConstrBlock(Logic.GetMouseInWorld());
	}

	private void OnLeftMouseButtonUp(bool pressed, int count)
	{
		if (!Input.GetMouseButton(1) && IsInConstructionMode() && pressed)
		{
			Vector3 mouseInWorld = Logic.GetMouseInWorld();
			if (CheckPointInsideConstrBlock(mouseInWorld) && CheckPointOutsideAllBaseBlocks(mouseInWorld))
			{
				prevMouseOnEmptyField = true;
			}
			else
			{
				prevMouseOnEmptyField = false;
			}
		}
	}

	private void UpdateBlockSelection()
	{
		if (selectionMode)
		{
			selectionEnd = InputSystem.GetCursor();
			if (selectionEnd.x < selectionStart.x)
			{
				selectionRect.xMin = selectionEnd.x;
				selectionRect.xMax = selectionStart.x;
			}
			else
			{
				selectionRect.xMin = selectionStart.x;
				selectionRect.xMax = selectionEnd.x;
			}
			if (selectionEnd.y < selectionStart.y)
			{
				selectionRect.yMin = selectionEnd.y;
				selectionRect.yMax = selectionStart.y;
			}
			else
			{
				selectionRect.yMin = selectionStart.y;
				selectionRect.yMax = selectionEnd.y;
			}
		}
	}

	private void LateUpdate()
	{
		if (base.gameObject.activeSelf && ActiveComponent.Model != null && !waitingDropdown)
		{
			if (firstTestTick)
			{
				firstTestTick = false;
				timer = 0f;
			}
			if (Time.unscaledTime - helpDelay > helpTimer && saveBlock != null)
			{
				saveBlock.gameObject.SetActive(value: false);
			}
			if (!ActiveComponent.Model.trainTest && selectionParent != null && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
			{
				Rect blocksRect = ((selectedBlocks.Count > 0) ? GetMultipleBlocksRect(selectedBlocks) : GetBlockRect(selectionParent));
				Rect snapRect = GetAlgoRect();
				selectionParent.SetPosition(GetSnappedBlockPosition(selectionParent.GetPosition(), blocksRect, snapRect));
				selectionParent = null;
			}
			DrawPOVsOnConstrAreaBorders();
		}
	}

	private void CheckAlt()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt) && !QuestResult.gameObject.activeSelf && !ActiveComponent._controller.newspaper.gameObject.activeSelf && !BlockTutuorial.gameObject.activeSelf && !CustomTutorialWindow.gameObject.activeSelf)
		{
			BonusClick();
		}
	}

	private void RecalcMousePos()
	{
		if (attached != null)
		{
			Vector3 mouseInWorld = Logic.GetMouseInWorld();
			attached.transform.position = mouseInWorld + addDragPosition;
		}
	}

	private void Pause()
	{
		if (!testMode)
		{
			return;
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Pause");
		if (!pause && SpeedCoef > 0f)
		{
			SpeedCoef = 0f;
			Speed.text = "x" + 0;
			MinusSpeed.gameObject.SetActive(value: false);
			PlusSpeed.gameObject.SetActive(value: true);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			Time.timeScale = SpeedCoef;
			if (!testMode)
			{
				Time.timeScale = 1f;
			}
			pause = true;
		}
		else
		{
			SpeedCoef = ActiveComponent.Model.P.rememberedSpeed;
			Speed.text = "x" + (float)(int)(SpeedCoef * 2f) / 2f;
			UpdateSpeed(ActiveComponent.Model.P.rememberedSpeed);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			Time.timeScale = SpeedCoef;
			if (!testMode)
			{
				Time.timeScale = 1f;
			}
			pause = false;
		}
	}

	private void CheckSpace()
	{
		if (!deepTrafficQuestController.gameObject.activeSelf && !QuestResult.gameObject.activeSelf && !ActiveComponent._controller.newspaper.gameObject.activeSelf && !BlockTutuorial.gameObject.activeSelf && !CustomTutorialWindow.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space) && !Filter.isFocused && !SchemeName.isFocused)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Pause");
			Pause();
		}
	}

	private void CheckEscape()
	{
		if (ActiveComponent._controller.Transition.gameObject.activeSelf || StartupComicsTutorial.gameObject.activeSelf || AcceptDeployStartup.gameObject.activeSelf)
		{
			return;
		}
		bool flag = false;
		flag = Input.GetKeyDown(KeyCode.Escape);
		flag = ActiveComponent.Program.joyInput.bUp;
		if (ActiveComponent.Model.KeyBoardTicks > 0 || !flag || ActiveComponent._controller.credit.gameObject.activeInHierarchy || firstNonForumQuestTutorialWindow.gameObject.activeSelf)
		{
			return;
		}
		if (AcceptDeploy.gameObject.activeSelf)
		{
			AcceptDeploy.gameObject.SetActive(value: false);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		}
		else if (QuestResult.gameObject.activeSelf)
		{
			ReInitConstructionArea();
			ClearEnds();
			QuestResult.gameObject.SetActive(value: false);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		}
		else if (AttentionClear.gameObject.activeSelf)
		{
			CancelClearAll();
		}
		else if (AcceptDeployStartup.gameObject.activeSelf)
		{
			CancelDeployStartupClick();
		}
		else
		{
			if (PressStopStartupTutorial.gameObject.activeSelf)
			{
				return;
			}
			if (testMode)
			{
				ClickTest();
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				SaveBtn.gameObject.SetActive(value: true);
			}
			else if (ActiveComponent._controller.newspaper.gameObject.activeSelf)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				ActiveComponent._controller.newspaper.closeNews.Invoke();
				ActiveComponent._controller.newspaper.CloseNewspaper();
			}
			else if (BlockTutuorial.gameObject.activeSelf)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				BlockTutuorial.OkClick();
			}
			else if (helpBlock.gameObject.activeSelf)
			{
				helpBlock.gameObject.SetActive(value: false);
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			}
			else
			{
				if (CustomTutorialWindow.gameObject.activeSelf)
				{
					return;
				}
				if (AttentionClear.gameObject.activeSelf)
				{
					CancelClearAll();
				}
				else if (!deepTrafficQuestController.gameObject.activeSelf && !StartupComicsTutorial.gameObject.activeSelf)
				{
					if (TooManyNodesDrag.gameObject.activeSelf)
					{
						CloseTooManyNodesDragClick();
					}
					else if (ActiveComponent.Model.P.firstTreeTutorialCompleted && !waitTutorial)
					{
						ExitClick();
						ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
					}
				}
			}
		}
	}

	private void CheckArrowsAndControl()
	{
		if (!QuestResult.gameObject.activeSelf && !ActiveComponent._controller.newspaper.gameObject.activeSelf && !BlockTutuorial.gameObject.activeSelf && !CustomTutorialWindow.gameObject.activeSelf && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftMeta) && !Input.GetKey(KeyCode.RightMeta) && !Filter.isFocused && !SchemeName.isFocused)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
			{
				MinusClick();
			}
			if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			{
				PlusClick();
			}
		}
	}

	private void CheckDelete()
	{
		if ((Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace)) && !BasicTutorials.IsActive() && IsInConstructionGameMode())
		{
			DeletePressMultipleBlocks();
		}
	}

	public void SetAllParentsToDefault()
	{
		foreach (BlockInScheme item in blocksInScheme)
		{
			item.go.transform.SetParent(GetAlgoTransform());
		}
	}

	private void Update()
	{
		if (!base.IsInited || ActiveComponent.Model.P == null)
		{
			return;
		}
		skipFrames++;
		if (skipFrames == 5 && blocksContentRect.rect.height != baseBlocksHeight)
		{
			baseBlocksHeight = blocksContentRect.rect.height;
			sizeFilter.enabled = false;
			baseBlockRect.enabled = baseBlockScrollBar.gameObject.activeSelf;
			layoutGroup.enabled = false;
		}
		if (waitingDropdown)
		{
			return;
		}
		if (firstTestTick)
		{
			firstTestTick = false;
			timer = 0f;
		}
		if (rightBtn && !waitTutorial && !helpBlock.gameObject.activeSelf && !TooManyNodesDrag.gameObject.activeSelf)
		{
			Vector3 mouseInWorld = Logic.GetMouseInWorld();
			Vector3 delta = algoBlock.InverseTransformPoint(mouseInWorld) - algoBlock.InverseTransformPoint(middlePos);
			DragAlgoBlock(delta);
			middlePos = mouseInWorld;
		}
		if (ActiveComponent.Program.joyInput.areaMove && !deepTrafficQuestController.gameObject.activeSelf)
		{
			DragAlgoBlock(ActiveComponent.Program.joyInput.areaMoveDelta * 18f * moveCoef);
		}
		if (ActiveComponent.Program.joyInput.zoomIn > 0f)
		{
			Zoom(1f + 0.04f * zoomCoef * ActiveComponent.Program.joyInput.zoomIn);
		}
		if (ActiveComponent.Program.joyInput.zoomOut > 0f)
		{
			Zoom(1f - 0.04f * zoomCoef * ActiveComponent.Program.joyInput.zoomOut);
		}
		if (ActiveComponent.Program.joyInput.copy)
		{
			OnCtrlC(pressed: true, 1);
		}
		if (ActiveComponent.Program.joyInput.paste)
		{
			OnCtrlV(pressed: true, 1);
		}
		if (ActiveComponent.Program.joyInput.undo)
		{
			OnCtrlZ(pressed: true, 1);
		}
		if (ActiveComponent.Program.joyInput.redo)
		{
			OnCtrlY(pressed: true, 1);
		}
		if (ActiveComponent.Model.CurInputDeviceIsController)
		{
			if (ActiveComponent.Program.joyInput.dragEnd)
			{
				if ((IsInConstructionGameMode() || PlaceNodeTutorial.gameObject.activeInHierarchy) && ActiveComponent.Program.cursor.curGo != SelectAllBtn.gameObject)
				{
					OnLeftMouseButton(pressed: false, 1);
				}
			}
			else
			{
				if (ActiveComponent.Program.joyInput.lmbUp && IsInConstructionGameMode() && ActiveComponent.Program.cursor.curGo != SelectAllBtn.gameObject)
				{
					OnLeftMouseButton(pressed: true, 1);
				}
				if (selectionMode && ActiveComponent.Model.CurInputDeviceIsController && !ActiveComponent.Program.joyInput.drag && !ActiveComponent.Program.joyInput.dragStart)
				{
					DropSelection(ignoreConditions: true);
					selectedBlocks.Clear();
					selectionMode = false;
				}
			}
		}
		if (ActiveComponent.Model.CurInputDeviceIsController && ActiveComponent.Program.joyInput.dragStart && ActiveComponent.Program.cursor.OnDefaultCanvas() && ActiveComponent.Model.currentChain == null && GetBlockUnderCursor(blocksInScheme) == null)
		{
			DropSelection(ignoreConditions: true);
			selectedBlocks.Clear();
			selectionMode = CheckPointInsideConstrBlock(Logic.GetMouseInWorld());
			selectionStart = InputSystem.GetCursor();
		}
		if (isPenNow && Helper.IsVector2InWorldRect(ActiveComponent.Model.construction.constrBlock, Logic.GetMouseInWorld()) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
		{
			PenField(penDelta);
		}
		if (Filter.isFocused || SchemeName.isFocused)
		{
			DropSelection();
		}
		RecalcMousePos();
		CheckSpace();
		CheckArrowsAndControl();
		CheckDelete();
		CheckEscape();
		CheckJoyConSpecialsControls();
		if (updateRedraw)
		{
			PerformRedraw();
		}
		if (IsInConstructionGameMode())
		{
			UpdateBlockSelection();
		}
		else
		{
			selectionMode = false;
		}
	}

	private void PerformXUp()
	{
		if (TuneButton.gameObject.activeSelf || TuneReleasedButton.gameObject.activeSelf)
		{
			Tune();
		}
		else if (DeployBtn.gameObject.activeSelf)
		{
			DeployClick();
		}
		else if (TrainButton.gameObject.activeSelf)
		{
			PlayerClickTestTrain(isTrain: false);
		}
		else if (TestButton.gameObject.activeSelf)
		{
			PlayerClickTestTrain(isTrain: false);
		}
	}

	private IEnumerator WaitDropdown(GameObject canvas)
	{
		while (canvas != null)
		{
			yield return new WaitForEndOfFrame();
		}
		waitingDropdown = false;
		PerformXUp();
	}

	private void CheckJoyConSpecialsControls()
	{
		if (!PressStopStartupTutorial.gameObject.activeSelf && !IsInConstructionMode())
		{
			return;
		}
		if (ActiveComponent.Program.joyInput.yUp && !PressStopStartupTutorial.gameObject.activeSelf)
		{
			if (constrState != ConstructionState.Startup && TrainButton.gameObject.activeSelf)
			{
				if (!ActiveComponent.Program.cursor.OnDefaultCanvas())
				{
					ActiveComponent.Program.cursor.HideAndResetCanvas();
				}
				PlayerClickTestTrain(isTrain: true);
			}
			else if (TestFirst.gameObject.activeSelf)
			{
				if (!ActiveComponent.Program.cursor.OnDefaultCanvas())
				{
					ActiveComponent.Program.cursor.HideAndResetCanvas();
				}
				PlayerClickTestTrain(isTrain: false);
			}
		}
		else
		{
			if (!ActiveComponent.Program.joyInput.xUp)
			{
				return;
			}
			if (StopButton.gameObject.activeSelf)
			{
				ClickStop();
				return;
			}
			if (!ActiveComponent.Program.cursor.OnDefaultCanvas())
			{
				ActiveComponent.Program.cursor.HideAndResetCanvas();
			}
			if (attached != null)
			{
				attached.transform.SetParent(GetAlgoTransform());
				attached.GetComponent<BaseBlock>().OnEndDrag(null);
			}
			PerformXUp();
		}
	}

	public void PenField(Vector3 delta)
	{
		draggingParentBlock.localPosition -= DragAlgoBlock(-delta) / algoBlock.localScale.x;
	}

	public Vector3 DragAlgoBlock(Vector3 delta)
	{
		if ((double)Mathf.Abs(algoBlock.localScale.x - ActiveComponent._staticData.Settings.MinZoom) < 1E-05)
		{
			return Vector3.zero;
		}
		delta.z = 0f;
		delta.x = Mathf.Min(delta.x, xMinConstrBlock - (algoBlock.localPosition.x - algoBlockRectTransform.pivot.x * algoBlockRectTransform.sizeDelta.x * algoBlock.localScale.x));
		delta.x = Mathf.Max(delta.x, xMaxConstrBlock - (algoBlock.localPosition.x + (1f - algoBlockRectTransform.pivot.x) * algoBlockRectTransform.sizeDelta.x * algoBlock.localScale.x));
		delta.y = Mathf.Min(delta.y, yMinConstrBlock - (algoBlock.localPosition.y - algoBlockRectTransform.pivot.y * algoBlockRectTransform.sizeDelta.y * algoBlock.localScale.y));
		delta.y = Mathf.Max(delta.y, yMaxConstrBlock - (algoBlock.localPosition.y + (1f - algoBlockRectTransform.pivot.y) * algoBlockRectTransform.sizeDelta.y * algoBlock.localScale.y));
		if (delta.sqrMagnitude > 5000f)
		{
			return Vector3.zero;
		}
		algoBlock.localPosition += delta;
		MatchAlgoBlockSiblings();
		if (Logic.openedDropdown != null)
		{
			ActiveComponent.Program.cursor.SetCanvas(null);
			Logic.openedDropdown.Hide();
			Logic.openedDropdown = null;
			Logic.openedCanvas = null;
		}
		return delta;
	}

	private void ClearAllClick()
	{
		if (ActiveComponent.Model.P.HideClearAll == 1)
		{
			if (blocksInScheme.Count != 0)
			{
				Cathub curCathub = GetCurCathub();
				curCathub.RecordHistory();
				RedoUndoButtonsStatesUpdate();
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Wipe");
				ClearCanvasScheme();
				RecalcStatsInScheme();
				curCathub.RecordHistory();
			}
		}
		else
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			AttentionClear.gameObject.SetActive(value: true);
			ActiveComponent.Program.cursor.SetPosition(AcceptClearBtn.transform.position);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
		}
	}

	private void AcceptClearAll()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Wipe");
		AttentionClear.gameObject.SetActive(value: false);
		if (blocksInScheme.Count != 0)
		{
			Cathub curCathub = GetCurCathub();
			RedoUndoButtonsStatesUpdate();
			ClearCanvasScheme();
			if (BasicTutorials.gameObject.activeSelf)
			{
				deleteEvent.Invoke();
			}
			curCathub.RecordHistory();
			RedoUndoButtonsStatesUpdate();
		}
	}

	private void CancelClearAll()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		AttentionClear.gameObject.SetActive(value: false);
	}

	private void RedrawAllSockets()
	{
	}

	private void ClearBlockCopyPaster()
	{
		if (blockCopyPaster != null)
		{
			blockCopyPaster.Clear();
			blockCopyPaster = null;
		}
	}

	public int GetNumValidCatHubs()
	{
		return QuestLine.GetCurrentQuest().GetNumValidCathubSchemes();
	}

	private bool IsFloatChangedForPlayerVision(float a, float b)
	{
		int num = (int)(10f * a);
		return (int)(10f * b) != num;
	}

	private void SoundBeforeFail()
	{
		if (soundIteratorBeforeFail >= 0)
		{
			if (soundIteratorBeforeFail == 3)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Count_3");
				soundIteratorBeforeFail--;
			}
			else if (soundIteratorBeforeFail == 2)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Count_2");
				soundIteratorBeforeFail--;
			}
			else if (soundIteratorBeforeFail == 1)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Count_1");
				soundIteratorBeforeFail--;
			}
		}
	}

	private void FixedUpdate()
	{
		if (!base.IsInited || ActiveComponent.Model.P == null || waitingDropdown)
		{
			return;
		}
		if (firstTestTick)
		{
			firstTestTick = false;
			timer = 0f;
		}
		if (base.gameObject.activeInHierarchy)
		{
			if (IsInNormalTaskRunMode())
			{
				QuestLine.GetCurrentQuest().timeInQuest += Time.fixedUnscaledDeltaTime;
			}
			if (constrState == ConstructionState.Startup)
			{
				timeInStartup += Time.fixedUnscaledDeltaTime;
			}
		}
		if (!save && !testMode)
		{
			CheckSpawn();
		}
		if (!testMode)
		{
			return;
		}
		if (constrState == ConstructionState.Startup && ActiveComponent.Model.P.startupComicsTutorial == 0)
		{
			startupTutorialTimer += Time.fixedUnscaledDeltaTime;
			if (startupTutorialTimer > helpStopTimer && ActiveComponent.Model.curStartup.KeyName == "TUTORIAL_STARTUP")
			{
				PressStopStartupTutorial.gameObject.SetActive(value: true);
			}
		}
		Redraw();
		_ = curSpendMoney;
		if (IsInNormalTaskRunMode())
		{
			float num = curMoneyPerSecond;
			_ = curSpendMoney;
			_ = predictMoneyInDeploy;
			predictMoneyInDeploy += Time.deltaTime * num;
			if (!ActiveComponent.Model.trainTest && (curTableQuest.OnlyAcc != 1 || Deploy || !ActiveComponent.Model.trainTest))
			{
				timer += Time.deltaTime;
				if ((int)(10f * minConditionTime - 10f * timer) == 10 * soundIteratorBeforeFail)
				{
					SoundBeforeFail();
				}
			}
		}
		bool flag = true;
		if (curQuestlineQuest.Is<CarQuest>())
		{
			timer += Time.deltaTime;
			for (int i = 0; i < results.Count; i++)
			{
				if (results[i].gameObject.activeInHierarchy)
				{
					flag = flag && results[i].End();
				}
			}
		}
		else if (constrState != ConstructionState.SandBox)
		{
			for (int j = 0; j < results.Count; j++)
			{
				if (currentResults[j] != "-")
				{
					flag = flag && results[j].End();
				}
			}
		}
		if (ActiveComponent.Model.trainTest)
		{
			flag = false;
		}
		if (constrState == ConstructionState.SandBox)
		{
			flag = false;
		}
		if (ActiveComponent.Model.trainTest)
		{
			bool flag2 = false;
			foreach (BlockInScheme item in blocksInScheme)
			{
				if (!item.BaseBlock().IsTrained())
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				ClickStop();
				SetHelp(TextResources.GetString("ALL_NODES_TRAINED"), HelpInfoState.Good);
			}
		}
		if (constrState == ConstructionState.CarTask)
		{
			flag = results[2].End();
			Redraw();
		}
		if (flag && constrState == ConstructionState.CarTask)
		{
			CarQuest quest = schemeStack.Top().GetQuest<CarQuest>();
			carQuestResult.Show(results[2].avarageGoTime, DeepTrafficStatic.GetMoneySpend(GetMoneyPerSecond(), quest.CarController.iterationsToEvaluate), results[2].ClassifierStatistics);
			ClickTest(clearResults: false);
			SaveBtn.gameObject.SetActive(value: true);
			AutoSaveDelay(Info.ShowProgressAndSaveName, saveInmemory: false);
		}
		if (flag && constrState != ConstructionState.CarTask)
		{
			Complete = true;
			testSuccessEvent.Invoke();
			ActiveComponent.Model.P.passedFirstQuest = 1;
			timer = Mathf.Min(timer, curCondition.Time);
			float num2 = timer;
			int scoreFromCurConstructuion = Logic.GetScoreFromCurConstructuion();
			if (Deploy)
			{
				releaseSucessEvent.Invoke();
				SpeedCoef = 1f;
				Speed.text = "x" + 1;
				MinusSpeed.gameObject.SetActive(value: true);
				PlusSpeed.gameObject.SetActive(value: true);
				DeployBtn.gameObject.SetActive(value: false);
				ActiveComponent.Model.globalSaves.passedTasksCou[QuestLine.GetCurrentQuestName()]++;
				Logic.UpdateGameSaves();
				ActiveComponent.Model.P.playerUnit.score += UnityEngine.Random.Range(curTableQuest.MinScore, curTableQuest.MaxScore);
			}
			Medal.Init(curQuestlineQuest.GetName());
			QuestResult.gameObject.SetActive(value: true);
			SaveBtn.gameObject.SetActive(value: true);
			QuestResult.InitQuestResult(this, num2, scoreFromCurConstructuion, (int)predictMoneyInDeploy);
			ClickTest(clearResults: false);
		}
		else
		{
			Complete = false;
		}
		if (IsInNormalTaskRunMode() && Mathf.FloorToInt(timer * 10f) > Mathf.FloorToInt(10f * curCondition.Time))
		{
			QuestLine.Quest quest2 = curQuestlineQuest;
			if (!SetConditionsInRuntime(quest2.GetCurCondition() - 1))
			{
				Medal.Init(curQuestlineQuest.GetName());
				QuestResult.gameObject.SetActive(value: true);
				SaveBtn.gameObject.SetActive(value: true);
				QuestResult.InitQuestResult(this, timer, Logic.GetScoreFromCurConstructuion(), (int)predictMoneyInDeploy);
				ClickTest(clearResults: false);
			}
		}
	}

	private bool IsBasciTutorialsOpen()
	{
		if (!base.gameObject.activeSelf)
		{
			return false;
		}
		return QuestLine.GetCurrentQuest().GetName() == ActiveComponent._staticData.Settings.BasicsTutorialTrigger;
	}

	public bool IsInNormalTaskRunMode()
	{
		if (constrState != ConstructionState.Task)
		{
			return constrState == ConstructionState.Forum;
		}
		return true;
	}

	private void Zoom(float zoomStrength, bool toCenter = false)
	{
		if (BasicTutorials.gameObject.activeSelf && BasicTutorials.StartDragWindow.gameObject.activeSelf)
		{
			return;
		}
		Vector3 localScale = algoBlock.localScale;
		localScale.x *= zoomStrength;
		localScale.y *= zoomStrength;
		localScale.z = 1f;
		bool flag = false;
		if (zoomStrength > 1f)
		{
			if (localScale.x >= ActiveComponent._staticData.Settings.MaxZoom)
			{
				localScale.x = (localScale.y = ActiveComponent._staticData.Settings.MaxZoom);
			}
		}
		else if (localScale.x <= ActiveComponent._staticData.Settings.MinZoom)
		{
			localScale.x = (localScale.y = ActiveComponent._staticData.Settings.MinZoom);
			zoomStrength = localScale.x / algoBlock.localScale.x;
			flag = true;
		}
		Vector2 localPoint = Vector2.zero;
		RectTransform component = algoBlock.GetComponent<RectTransform>();
		RectTransformUtility.ScreenPointToLocalPointInRectangle(component, Input.mousePosition, Camera.main, out localPoint);
		localPoint = Rect.PointToNormalized(component.rect, localPoint);
		if (float.IsNaN(localScale.x))
		{
			localScale.x = 0f;
		}
		if (float.IsNaN(localScale.y))
		{
			localScale.y = 0f;
		}
		if (zoomStrength < 1f)
		{
			if (flag)
			{
				localPoint.x = (localPoint.y = 0.5f);
				component.pivot = localPoint;
				algoBlock.localPosition = constrBlock.localPosition;
				algoBlock.localScale = localScale;
				return;
			}
			localPoint.x = Mathf.Min(localPoint.x, (xMinConstrBlock - algoBlock.localPosition.x + component.pivot.x * component.sizeDelta.x * algoBlock.localScale.x) / (component.sizeDelta.x * algoBlock.localScale.x * (1f - zoomStrength)));
			localPoint.x = Mathf.Max(localPoint.x, (xMaxConstrBlock - algoBlock.localPosition.x + (component.pivot.x - zoomStrength) * component.sizeDelta.x * algoBlock.localScale.x) / (component.sizeDelta.x * algoBlock.localScale.x * (1f - zoomStrength)));
			localPoint.y = Mathf.Min(localPoint.y, (yMinConstrBlock - algoBlock.localPosition.y + component.pivot.y * component.sizeDelta.y * algoBlock.localScale.y) / (component.sizeDelta.y * algoBlock.localScale.y * (1f - zoomStrength)));
			localPoint.y = Mathf.Max(localPoint.y, (yMaxConstrBlock - algoBlock.localPosition.y + (component.pivot.y - zoomStrength) * component.sizeDelta.y * algoBlock.localScale.y) / (component.sizeDelta.y * algoBlock.localScale.y * (1f - zoomStrength)));
		}
		if (toCenter)
		{
			localPoint.x = (localPoint.y = 0.5f);
			component.pivot = localPoint;
			algoBlock.localScale = localScale;
		}
		Vector2 vector = localPoint - component.pivot;
		vector.x *= component.sizeDelta.x * algoBlock.localScale.x;
		vector.y *= component.sizeDelta.y * algoBlock.localScale.y;
		if (float.IsNaN(vector.x))
		{
			vector.x = 0f;
		}
		if (float.IsNaN(vector.y))
		{
			vector.y = 0f;
		}
		component.pivot = localPoint;
		component.localPosition += (Vector3)vector;
		algoBlock.localScale = localScale;
		SetZoomToAllStates();
		DragAlgoBlock(Vector3.zero);
	}

	private void OnMouseWheel(float f)
	{
		if (IsInConstructionMode() && Helper.GetWorldRect(constrBlock).Contains(Logic.GetMouseInWorld()))
		{
			float zoomStrength = 1f / ZoomStrength;
			if (f < 0f)
			{
				Zoom(ZoomStrength);
			}
			else
			{
				Zoom(zoomStrength);
			}
			MatchAlgoBlockSiblings();
		}
	}

	public void AddBlockToSelectionAction(GameObject go)
	{
		BlockInScheme block = blocksInScheme.Find((BlockInScheme b) => b.go == go);
		AddBlockToSelectionAction(block);
	}

	public void AddBlockToSelectionAction(BlockInScheme block)
	{
		AddBlockToSelection(block);
		BlockData blockData = block.BlockData();
		if (blockData != null)
		{
			blockData.SetCornerStyleSelected(scaleUp: true);
		}
	}

	private void OnLeftMouseButton(bool pressed, int count)
	{
		if (!ActiveComponent.Program.cursor.OnDefaultCanvas() || (!PlaceNodeTutorial.gameObject.activeInHierarchy && !IsInConstructionGameMode()) || Input.GetMouseButton(1) || !base.gameObject.activeInHierarchy)
		{
			return;
		}
		if (pressed)
		{
			if (!GetAlgoRect().Contains(Logic.GetMouseInWorld()))
			{
				return;
			}
			foreach (Data data in datas)
			{
				foreach (Socket item in data.socketsOut)
				{
					if (item != null && item.hover)
					{
						return;
					}
				}
			}
			foreach (Result result in results)
			{
				foreach (Socket item2 in result.socketsIn)
				{
					if (item2 != null && item2.hover)
					{
						return;
					}
				}
			}
			BlockInScheme blockUnderCursor = GetBlockUnderCursor(blocksInScheme);
			if (blockUnderCursor != null && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftMeta) || Input.GetKey(KeyCode.RightMeta)))
			{
				if (blockUnderCursor.BlockData().ToggleSelection())
				{
					AddBlockToSelection(blockUnderCursor);
				}
				else
				{
					DropBlockSelection(blockUnderCursor);
				}
				return;
			}
			if (!selectionMode && selectedBlocks.Count >= 0)
			{
				BlockInScheme blockInScheme = blockUnderCursor;
				if (blockInScheme != null)
				{
					if (blockInScheme.BlockData().IsSelected() && (ActiveComponent.Program.cursor == null || !ActiveComponent.Program.cursor.Visible()))
					{
						blockInScheme.SetParent(GetAlgoTransform());
						foreach (BlockInScheme selectedBlock in selectedBlocks)
						{
							if (selectedBlock != blockInScheme)
							{
								selectedBlock.SetParent(blockInScheme);
								selectedBlock.go.transform.SetAsFirstSibling();
							}
						}
						draggingParent = blockInScheme.go;
						BaseBlock component = draggingParent.GetComponent<BaseBlock>();
						component.SetBoundsCheck(selectedBlocks.Count > 1);
						component.SetDrags(selectedBlocks);
						draggingParent.transform.SetParent(algoBlockDrag, worldPositionStays: true);
					}
					else
					{
						selectionMode = false;
						DropSelection();
						if (!testMode)
						{
							blockInScheme.BlockData().SetHovered(state: true);
						}
					}
				}
				else if (ActiveComponent.Program.cursor != null && ActiveComponent.Program.cursor.Visible())
				{
					selectionMode = false;
					DropSelection(ignoreConditions: true);
				}
			}
			if (blockUnderCursor == null)
			{
				bool flag = false;
				PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
				{
					pointerId = -1
				};
				pointerEventData.position = Input.mousePosition;
				List<RaycastResult> list = new List<RaycastResult>();
				EventSystem.current.RaycastAll(pointerEventData, list);
				foreach (RaycastResult item3 in list)
				{
					if (item3.gameObject == CtrlC.gameObject)
					{
						flag = true;
						break;
					}
				}
				if (!Model.steamDeckRunning && !flag)
				{
					DropSelection(ignoreConditions: true);
					selectedBlocks.Clear();
					if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
					{
						selectionMode = CheckPointInsideConstrBlock(Logic.GetMouseInWorld());
						selectionStart = InputSystem.GetCursor();
					}
					else
					{
						selectionMode = false;
					}
				}
				CtrlCtrlvButtonsStatesUpdate();
			}
			else
			{
				AddBlockToSelectionAction(blockUnderCursor);
			}
			middlePos = InputSystem.GetMouse();
			return;
		}
		if (attached != null && !IsInDeleteZone(attached))
		{
			attached.transform.SetParent(GetAlgoTransform());
			attached.GetComponent<BaseBlock>().OnEndDrag(null);
			lastAttached = attached;
			attached = null;
			if (TooManyNodesCheck() && !ActiveComponent.Model.P.hideDragTooMany)
			{
				TooManyNodesDrag.gameObject.SetActive(value: true);
				ActiveComponent.Program.cursor.SetPosition(CloseTooManyNodesDrag.transform.position);
			}
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Block_Install");
			RedoUndoButtonsStatesUpdate();
		}
		if (attached != null && !CanPlaceInConstrBlock())
		{
			GameObject go = attached;
			_ = PlaceNodeTutorial.gameObject.activeInHierarchy;
			lastAttached = attached;
			CheckDelete(go);
			attached = null;
		}
		attached = null;
		if (ActiveComponent.Program.cursor != null && ActiveComponent.Program.cursor.Visible())
		{
			interactState = DragInteraction.None;
		}
		if ((bool)draggingParent)
		{
			draggingParent.transform.SetParent(algoBlock, worldPositionStays: true);
			BaseBlock component2 = draggingParent.GetComponent<BaseBlock>();
			component2.SetBoundsCheck(state: false);
			component2.SetDrags(null);
			draggingParent = null;
		}
		if (IsBasciTutorialsOpen())
		{
			endDragEvent.Invoke();
		}
		if (selectedBlocks.Count < 2)
		{
			BlockInScheme blockUnderCursor2 = GetBlockUnderCursor(blocksInScheme);
			if (blockUnderCursor2 != null)
			{
				CheckDelete(blockUnderCursor2);
			}
			selectionMode = false;
			Vector3 vector = ScreenToWorld(selectionRect.xMin, (float)Screen.height - selectionRect.yMax);
			Vector3 vector2 = ScreenToWorld(selectionRect.xMax, (float)Screen.height - selectionRect.yMin);
			selectionBox.xMin = vector.x;
			selectionBox.yMin = vector.y;
			selectionBox.xMax = vector2.x;
			selectionBox.yMax = vector2.y;
			foreach (BlockInScheme item4 in blocksInScheme)
			{
				if (item4.BlockData().CanBeSelected() && selectionBox.Overlaps(GetBlockRect(item4)))
				{
					AddBlockToSelection(item4);
				}
			}
			selectionRect.Set(0f, 0f, 0f, 0f);
		}
		else
		{
			selectionParent = GetBlockUnderCursor(selectedBlocks);
			if (selectionParent != null)
			{
				CheckDelete(selectionParent);
			}
		}
	}

	private void OnRightMouseButtonUp(bool pressed, int count)
	{
		rightBtn = false;
		interactState = DragInteraction.None;
	}

	private void OnRightMouseButtonDown(bool pressed, int count)
	{
		if (!Helper.GetWorldRect(constrBlock).Contains(Logic.GetMouseInWorld()) || !IsInConstructionMode())
		{
			return;
		}
		bool flag = false;
		foreach (BlockInScheme item in blocksInScheme)
		{
			if (Helper.GetWorldRect(item.go.GetComponent<RectTransform>()).Contains(Logic.GetMouseInWorld()))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			interactState = DragInteraction.Block;
		}
		else
		{
			interactState = DragInteraction.ConstrArea;
		}
	}

	private void OnRightMouseButton(bool pressed, int count)
	{
		if (Helper.GetWorldRect(constrBlock).Contains(Logic.GetMouseInWorld()) && IsInConstructionMode())
		{
			rightBtn = pressed;
			middlePos = Logic.GetMouseInWorld();
		}
	}

	private void SelectAll(bool alwaysSelect = false)
	{
		DropSelection(ignoreConditions: true);
		foreach (BlockInScheme item in blocksInScheme)
		{
			if (item.BlockData().CanBeSelected())
			{
				AddBlockToSelection(item, null, alwaysSelect);
			}
		}
	}

	private void OnCtrlA(bool pressed, int count)
	{
		if (IsInConstructionGameMode() && pressed)
		{
			SelectAll(alwaysSelect: true);
		}
	}

	private void OnCtrlC(bool pressed, int count)
	{
		if (!IsInConstructionGameMode() || !pressed || !recordingAllowed)
		{
			return;
		}
		recordingAllowed = false;
		SetAllParentsToDefault();
		InitSocketsNums();
		ClearBlockCopyPaster();
		blockCopyPaster = new BlockCopyPaster(blocksInScheme);
		int num = 0;
		int num2 = 0;
		foreach (BlockInScheme item in blockCopyPaster.Scheme())
		{
			num++;
			if (item.CanBeCopied())
			{
				num2++;
				BlockInScheme blockInScheme = AttachNewBlockToMouse(item, dummy: true);
				RemoveBlockFromScheme(blocksInScheme.LastItem(), destroyBlock: false);
				blockCopyPaster.Add(blockInScheme, item);
				blockInScheme.HideChains();
			}
		}
		if (num2 == 0)
		{
			blockCopyPaster = null;
			recordingAllowed = true;
			return;
		}
		if (blockCopyPaster.HasSocketConnections())
		{
			foreach (BlockInScheme item2 in blockCopyPaster.Buffer())
			{
				item2.HideChains();
				HashSet<Socket.Connections> socketConnections = blockCopyPaster.GetSocketConnections(item2);
				if (socketConnections != null)
				{
					item2.GetUniqueHash();
					foreach (Socket.Connections item3 in socketConnections)
					{
						foreach (KeyValuePair<int, HashSet<Socket.Connections.Flags>> c in item3.Out)
						{
							if (blockCopyPaster.GetSocketConnections(c.Key) == null)
							{
								continue;
							}
							BlockInScheme blockInScheme2 = blockCopyPaster.Buffer().Find((BlockInScheme pb) => pb.GetUniqueHash() == c.Key);
							foreach (Socket.Connections.Flags item4 in c.Value)
							{
								item2.ConnectTo(item4.src, blockInScheme2, item4.dest, blockCopyPaster.GetRealObject(item2), blockCopyPaster.GetRealObject(blockInScheme2));
							}
						}
					}
				}
				item2.HideChains();
			}
		}
		SetInfo(TextResources.GetString("COPY_ACTION"));
		if (!blockCopyPaster.IsEmpty())
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		}
		else
		{
			ClearBlockCopyPaster();
		}
		recordingAllowed = true;
		CtrlCtrlvButtonsStatesUpdate();
	}

	private void OnCtrlV(bool pressed, int count)
	{
		if (TooManyNodesCheck() && !ActiveComponent.Model.P.hideDragTooMany)
		{
			TooManyNodesDrag.gameObject.SetActive(value: false);
			return;
		}
		SetAllParentsToDefault();
		if (!IsInConstructionGameMode() || !pressed || this.blockCopyPaster == null || !recordingAllowed)
		{
			return;
		}
		recordingAllowed = false;
		this.blockCopyPaster.Buffer().ForEach(delegate(BlockInScheme block)
		{
			UpdateSocketInBlock(block);
		});
		List<BlockInScheme> list = new List<BlockInScheme>();
		BlockInScheme blockInScheme = null;
		for (int num = 0; num < blocksInScheme.Count; num++)
		{
			if (blocksInScheme[num].go != null)
			{
				Socket[] componentsInChildren = blocksInScheme[num].go.GetComponentsInChildren<Socket>();
				for (int num2 = 0; num2 < componentsInChildren.Length; num2++)
				{
					componentsInChildren[num2].BlockNumParent = num;
				}
			}
		}
		DropSelection(ignoreConditions: true);
		BlockCopyPaster blockCopyPaster = new BlockCopyPaster(this.blockCopyPaster.Buffer());
		foreach (BlockInScheme item in this.blockCopyPaster.Buffer())
		{
			BlockInScheme blockInScheme2 = AttachNewBlockToMouse(item);
			blockInScheme2.go.SetActive(value: true);
			blockInScheme2.BlockData().Init(item.BlockData());
			blockInScheme2.go.name = item.go.name;
			blockInScheme2.SetPosition(item);
			list.Add(blockInScheme2);
			blockCopyPaster.Add(blockInScheme2, item);
			if (blockInScheme == null)
			{
				blockInScheme = blockInScheme2;
			}
			else
			{
				blockInScheme2.SetParent(blockInScheme);
			}
			if (Input.GetKey(KeyCode.LeftShift))
			{
				blockInScheme2.DeleteChains(invoke: true);
			}
		}
		for (int num3 = 1; num3 < list.Count; num3++)
		{
			list[num3].SetParent(blockInScheme);
		}
		if (blockCopyPaster.HasSocketConnections())
		{
			foreach (BlockInScheme item2 in blockCopyPaster.Buffer())
			{
				HashSet<Socket.Connections> socketConnections = blockCopyPaster.GetSocketConnections(item2);
				if (socketConnections == null)
				{
					continue;
				}
				item2.GetUniqueHash();
				foreach (Socket.Connections item3 in socketConnections)
				{
					foreach (KeyValuePair<int, HashSet<Socket.Connections.Flags>> c in item3.Out)
					{
						if (blockCopyPaster.GetSocketConnections(c.Key) == null)
						{
							continue;
						}
						BlockInScheme blockInScheme3 = blockCopyPaster.Buffer().Find((BlockInScheme pb) => pb.GetUniqueHash() == c.Key);
						foreach (Socket.Connections.Flags item4 in c.Value)
						{
							item2.ConnectTo(item4.src, blockInScheme3, item4.dest, blockCopyPaster.GetRealObject(item2), blockCopyPaster.GetRealObject(blockInScheme3));
						}
					}
				}
			}
		}
		attached = null;
		if (list.Count > 0)
		{
			foreach (BlockInScheme item5 in list)
			{
				AddBlockToSelection(item5);
			}
		}
		selectionParent = blockInScheme;
		if (pasteInCenter)
		{
			Vector3 position = constrBlock.transform.position;
			selectionParent.SetPosition(position);
		}
		else
		{
			selectionParent.SetPosition(Logic.GetMouseInWorld());
		}
		recordingAllowed = true;
		GetCurCathub().RecordHistory();
		RedoUndoButtonsStatesUpdate();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Block_Install");
		if (TooManyNodesCheck() && !ActiveComponent.Model.P.hideDragTooMany)
		{
			TooManyNodesDrag.gameObject.SetActive(value: true);
			ActiveComponent.Program.cursor.SetPosition(CloseTooManyNodesDrag.transform.position);
		}
		SetInfo(TextResources.GetString("PASTE_ACTION"));
		SetZoomToAllStates();
		CtrlCtrlvButtonsStatesUpdate();
	}

	private void UpdateSocketInBlock(BlockInScheme block)
	{
		block.BlockData().socketsIn.ForEach(delegate(Socket so)
		{
			UpdateSocketColor(so);
		});
		block.BlockData().socketsOut.ForEach(delegate(Socket so)
		{
			UpdateSocketColor(so);
		});
	}

	private void UpdateSocketColor(Socket s)
	{
		if (s != null)
		{
			s.RedrawSocketColor();
		}
	}

	public void RedoUndoButtonsStatesUpdate()
	{
		Cathub curCathub = GetCurCathub();
		Undo.interactable = curCathub.isUndoAvialble();
		Redo.interactable = curCathub.isRedoAviable();
		ClearAll.interactable = blocksInScheme.Count != 0;
		SelectAllBtn.interactable = blocksInScheme.Count != 0;
		Undo.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
		Redo.gameObject.SetActive(QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.CopyTutorial) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.CopyTutorial).IsTaskOpened());
		CtrlCtrlvButtonsStatesUpdate();
	}

	public void CtrlCtrlvButtonsStatesUpdate()
	{
		CtrlC.interactable = selectedBlocks.Count > 0;
		CtrlV.interactable = blockCopyPaster != null && blockCopyPaster.Buffer().Count > 0;
	}

	private void OnCtrlZ(bool pressed, int count)
	{
		if (recordingAllowed && IsInConstructionGameMode() && pressed)
		{
			recordingAllowed = false;
			if (nodesState != NodesState.Base)
			{
				ShowBaseClick();
			}
			GetCurCathub().UndoHistory();
			RedoUndoButtonsStatesUpdate();
			recordingAllowed = true;
		}
	}

	private void OnCtrlY(bool pressed, int count)
	{
		if (recordingAllowed && IsInConstructionGameMode() && pressed)
		{
			recordingAllowed = false;
			if (nodesState != NodesState.Base)
			{
				ShowBaseClick();
			}
			GetCurCathub().RedoHistory();
			RedoUndoButtonsStatesUpdate();
			recordingAllowed = true;
		}
	}

	private void OnPanReset(bool pressed, int count)
	{
		if (pressed && IsInConstructionMode())
		{
			Zoom(ActiveComponent._staticData.Settings.MinZoom);
			MatchAlgoBlockSiblings();
		}
	}
}
