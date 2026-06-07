using System;
using System.Collections.Generic;
using DG.Tweening;
using InputControl;
using Libs;
using Spine.Unity;
using UnityEngine;

namespace UI
{
	public class ChoiceRouteCtrl : SingletonMonoBehaviour<ChoiceRouteCtrl>
	{
		private class PresetData
		{
			public int lineCount;

			public bool isCross;

			public bool dynamicLine;

			public int[] widthPerWave { get; set; }

			public int StartCount => 0;

			public int Width => 0;

			public PresetData(int[] width, int lineCount, bool isCross, bool dynamicLine = true)
			{
			}
		}

		public enum eNodeState
		{
			None = 0,
			Now = 1,
			Selectable = 2,
			Selected = 3
		}

		[Serializable]
		public class RouteNode : IEquatable<RouteNode>
		{
			public int nodeId;

			public int division;

			public int level;

			public int wave;

			public int levelIdx;

			public int attachEnemyId;

			private MstEnemyChoiceDataEntities _attachEnemyData;

			public int subEnemyId;

			private MstEnemyChoiceDataEntities _subEnemyData;

			public Vector3 buttonLocalPosition;

			[SerializeField]
			private List<int> _parentIdx;

			private List<RouteNode> _parents;

			[SerializeField]
			private List<int> _branchIdx;

			private List<RouteBranch> _branches;

			public eEnemyType enemyType;

			public bool isPowerOrdeal;

			public eNodeLevel NodeLevel => default(eNodeLevel);

			public MstEnemyChoiceDataEntities AttachEnemyData => null;

			public MstEnemyChoiceDataEntities SubEnemyData => null;

			public List<RouteNode> Parents => null;

			public List<RouteBranch> Branches => null;

			public eNodeState State => default(eNodeState);

			public void SetAttachEnemyId(int value)
			{
			}

			public void AddParent(RouteNode node)
			{
			}

			public void AddBranch(RouteBranch branch)
			{
			}

			public RouteNode(int nodeId, int division, int level, int wave, int levelIdx)
			{
			}

			public void OverwriteNode(int? nodeId = null, int? division = null, int? waveCount = null, int? level = null, int? levelIdx = null)
			{
			}

			public RouteBranch SearchRouteBranch(RouteNode child)
			{
				return null;
			}

			public override string ToString()
			{
				return null;
			}

			public void GetHistoryEvent(ref List<EventCounter> history, EventCounter prevRoute)
			{
			}

			public List<RouteBranch> GetRouteBranches(ref List<RouteBranch> result, RouteNode node, int finishLevel, int nowLevel = 0)
			{
				return null;
			}

			public List<RouteNode> GetRandomNodeOnBranch(int finishLevel)
			{
				return null;
			}

			public (eEnemyType, eEnemy)? GetInfo()
			{
				return null;
			}

			public bool Equals(RouteNode other)
			{
				return false;
			}
		}

		public enum eNodeLevel
		{
			None = 0,
			Home = 1,
			Start = 2,
			End = 3
		}

		[Serializable]
		public class RouteBranch : IEquatable<RouteBranch>
		{
			public int division;

			public int branchId;

			public int parentId;

			private RouteNode _parent;

			public int childId;

			private RouteNode _child;

			[SerializeField]
			private eRouteEvent routeEvent;

			public eRouteEvent subRouteEvent;

			private eRouteEvent _additionalEvent;

			public Vector2 centerPoint;

			public int crossBranchId;

			private RouteBranch _crossBranch;

			public bool ignoreEventIcon;

			public bool isEnforcement;

			public bool isLockBranch;

			public bool isKnowledgeOrdeal;

			public string BranchName => null;

			public RouteNode Parent => null;

			public RouteNode Child => null;

			public eRouteEvent RouteEvent
			{
				get
				{
					return default(eRouteEvent);
				}
				set
				{
				}
			}

			public eRouteEvent AdditionalEvent => default(eRouteEvent);

			public RouteBranch CrossBranch => null;

			public bool IsPassed => false;

			public bool IsSelectable => false;

			public bool IsReachable => false;

			public RouteBranch(int branchId, int division, int parentIdx, int childIdx)
			{
			}

			public bool Equals(RouteBranch other)
			{
				return false;
			}
		}

		public class EventCounter
		{
			public Dictionary<eRouteEvent, int> eventCount;

			public Dictionary<eEnemyType, int> enemyTypeCount;

			public List<RouteBranch> targetBranch;

			public EventCounter()
			{
			}

			public EventCounter(EventCounter copy)
			{
			}

			public void AddBranch(RouteBranch branch)
			{
			}

			public bool ClearCondition(ChoiceRouteDataEntities.ConditionEvent condition)
			{
				return false;
			}

			public void ChangeOtherEvent(eRouteEvent routeEvent, SRandom randomState)
			{
			}

			public void ChangeEvent(eRouteEvent routeEvent, SRandom randomState)
			{
			}

			public void ChangeElite(int divisionCount, SRandom randomState)
			{
			}

			public void UpdateEventInfo()
			{
			}

			public void UpdateEnemyInfo()
			{
			}

			public override string ToString()
			{
				return null;
			}

			public string ToFollowString()
			{
				return null;
			}
		}

		public RectTransform choiceNodeArea;

		public GameObject displayGroup;

		public RectTransform guidePallet;

		public Vector2 dummyBossImagePos;

		public RectTransform dummyButtonArea;

		[SerializeField]
		private RouteOrdeal routeOrdeal;

		[SerializeField]
		[Tooltip("イベント交換の最大処理回数")]
		private int _maxAdjustmentCount;

		[SerializeField]
		private ChoiceRouteView _routeViewPrefab;

		[SerializeField]
		private DummyRouteNodeButton _dummyButtonPrefab;

		[SerializeField]
		private DummyRouteBossImage _dummyRouteBossImagePrefab;

		[SerializeField]
		private Vector3 _adjustmentDummyPosition;

		[Header("敵情報設定")]
		[SerializeField]
		private RouteEnemyInfo _routeEnemyInfo;

		[SerializeField]
		private Vector3 _enemyInfoTweenStartOffset;

		[SerializeField]
		private float _limitY;

		[Header("Animation")]
		[SerializeField]
		private SkeletonGraphic _nextStageCutin;

		[SerializeField]
		private PadInputConfigure _padInputConfigure;

		[SerializeField]
		private CursorUIGroup _selectGroup;

		[SerializeField]
		private GameObject _padGuide;

		[SerializeField]
		private SkeletonGraphic _endlessCutin;

		private static List<ChoiceRouteDataEntities> _routeData;

		public static readonly Color selectableColor;

		public static readonly Color selectedColor;

		public static readonly Color dontSelectColor;

		public static readonly Color lightBlueColor;

		private Vector3 _initialGuidePosition;

		private SRandom _routeRandomState;

		private static int _openDivision;

		private ChoiceRouteView _routeViewBook;

		private List<DummyRouteNodeButton> dummyRouteButtons;

		private DummyRouteBossImage _dummyRouteBossImage;

		private int _nodeId;

		private int _branchId;

		private CursorUIItem _defaultSelectItem;

		private bool _finishEndlessCutin;

		private Dictionary<ChoiceRouteDataEntities.eStagePreset, PresetData> _presetData;

		public static List<ChoiceRouteDataEntities> RouteDatas => null;

		public static ChoiceRouteDataEntities NowRoute => null;

		public List<RouteNode> TargetDivision => null;

		public List<RouteBranch> TargetDivisionBranch => null;

		public RouteNode NowNode => null;

		public SRandom RouteRandomState => null;

		public RouteNode ConvertToNode(string id)
		{
			return null;
		}

		private void Awake()
		{
		}

		public void Init()
		{
		}

		public void AdditionalRouteSetting(eStageDivision openDivision)
		{
		}

		private void RouteDataSetting()
		{
		}

		private ChoiceRouteDataEntities GetDivisionData(string divisionName)
		{
			return null;
		}

		private void AddHomeNode()
		{
		}

		public ChoiceRouteView CreateRouteView(RectTransform parent, bool referenceMode, bool isEndless = false, bool activeStageNum = true)
		{
			return null;
		}

		public bool UpdateRoute(eStageDivision openDivision)
		{
			return false;
		}

		public void UpdateBossAscension()
		{
		}

		public void CreateDummyButton()
		{
		}

		public void CreateBossDummyButton()
		{
		}

		private void RemoveOrdeal()
		{
		}

		private void ClickDummyButton(RouteNode node)
		{
		}

		public void DisplayDummyButton()
		{
		}

		public void OnPadCancel()
		{
		}

		private void CalculationButtonPosition()
		{
		}

		private void TargetRouteSetting()
		{
		}

		private void ChangeDivision(eStageDivision openDivision)
		{
		}

		public void CreateRoute(int divisionCount)
		{
		}

		private RouteNode CreateRouteEvent(int division, int level, int wave, int index)
		{
			return null;
		}

		public void RegisterEvent(int divisionCount, bool debug = false)
		{
		}

		private void RegisterOrdeal(int divisionCount)
		{
		}

		private void RegisterShop(int divisionCount)
		{
		}

		private eRouteEvent GetCustomEvent(eRouteEvent original)
		{
			return default(eRouteEvent);
		}

		private bool EventConditionCheck(ChoiceRouteDataEntities.RouteEventCondition eventCondition)
		{
			return false;
		}

		private eRouteEvent EventChoiceGacha(int divisionCount, int level, eRouteEvent removeEvent = eRouteEvent.None)
		{
			return default(eRouteEvent);
		}

		private eRouteEvent EventChoiceGacha(List<RouteNodeData> eventList, int level)
		{
			return default(eRouteEvent);
		}

		public void RegisterEnemy(int divisionCount)
		{
		}

		public MstEnemyChoiceDataEntities GetRandomTakeOneNamedData(MstEnemyChoiceDataEntities[] pool)
		{
			return null;
		}

		private void EliteSetting(int divisionCount)
		{
		}

		public void AdjustmentEvent(int divisionCount)
		{
		}

		public List<MstEnemyChoiceDataEntities> DisplayEnemyChoice(eWaveTierId currentTier, int choiceCount)
		{
			return null;
		}

		private void GuidePalletAnimation()
		{
		}

		public Sequence TurnPageSequence(eStageDivision openDivision)
		{
			return null;
		}

		private void RegisterBossEliteLevel(RouteNode node)
		{
		}

		public List<string> GetRandomRoute(int targetDivision, int toWave)
		{
			return null;
		}

		public void RouteEventShuffle()
		{
		}

		public Sequence StartNextStageCutin()
		{
			return null;
		}

		public void StopNextStageCutin()
		{
		}

		private void EndlessProcess()
		{
		}

		private void Update()
		{
		}

		public void OnNextOrdeal()
		{
		}

		public void OnHiddenOrdealInfo()
		{
		}
	}
}
