using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

[HelpURL("http://arongranberg.com/astar/documentation/stable/class_astar_path.php")]
[AddComponentMenu("Pathfinding/Pathfinder")]
[ExecuteInEditMode]
public class AstarPath : VersionedMonoBehaviour
{
	public enum AstarDistribution
	{
		WebsiteDownload = 0,
		AssetStore = 1,
		PackageManager = 2
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass142_0
	{
		public NavGraph graph;

		internal void _003CScanGraph_003Eb__0(GraphNode node)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDelayedGraphUpdate_003Ed__110 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AstarPath _003C_003E4__this;

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
		public _003CDelayedGraphUpdate_003Ed__110(int _003C_003E1__state)
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
	private sealed class _003CScanAsync_003Ed__141 : IEnumerable<Progress>, IEnumerable, IEnumerator<Progress>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Progress _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private NavGraph[] graphsToScan;

		public NavGraph[] _003C_003E3__graphsToScan;

		public AstarPath _003C_003E4__this;

		private PathProcessor.GraphUpdateLock _003CgraphUpdateLock_003E5__2;

		private Stopwatch _003Cwatch_003E5__3;

		private int _003Ci_003E5__4;

		private float _003Cminp_003E5__5;

		private float _003Cmaxp_003E5__6;

		private string _003CprogressDescriptionPrefix_003E5__7;

		private IEnumerator<Progress> _003Ccoroutine_003E5__8;

		Progress IEnumerator<Progress>.Current
		{
			[DebuggerHidden]
			get
			{
				return default(Progress);
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
		public _003CScanAsync_003Ed__141(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<Progress> IEnumerable<Progress>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CScanGraph_003Ed__142 : IEnumerable<Progress>, IEnumerable, IEnumerator<Progress>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Progress _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private NavGraph graph;

		public NavGraph _003C_003E3__graph;

		private _003C_003Ec__DisplayClass142_0 _003C_003E8__1;

		private IEnumerator<Progress> _003C_003E7__wrap1;

		Progress IEnumerator<Progress>.Current
		{
			[DebuggerHidden]
			get
			{
				return default(Progress);
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
		public _003CScanGraph_003Ed__142(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}

		[DebuggerHidden]
		IEnumerator<Progress> IEnumerable<Progress>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdateGraphsInternal_003Ed__113 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public AstarPath _003C_003E4__this;

		public GraphUpdateObject ob;

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
		public _003CUpdateGraphsInternal_003Ed__113(int _003C_003E1__state)
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

	public static readonly Version Version;

	public static readonly AstarDistribution Distribution;

	public static readonly string Branch;

	[FormerlySerializedAs("astarData")]
	public AstarData data;

	public static AstarPath active;

	public bool showNavGraphs;

	public bool showUnwalkableNodes;

	public GraphDebugMode debugMode;

	public float debugFloor;

	public float debugRoof;

	public bool manualDebugFloorRoof;

	public bool showSearchTree;

	public float unwalkableNodeDebugSize;

	public PathLog logPathResults;

	public float maxNearestNodeDistance;

	public bool scanOnStartup;

	public bool fullGetNearestSearch;

	[Obsolete("This setting is discouraged, and it will be removed in a future update")]
	public bool prioritizeGraphs;

	[Obsolete("This setting is discouraged, and it will be removed in a future update")]
	public float prioritizeGraphsLimit;

	public AstarColor colorSettings;

	[SerializeField]
	protected string[] tagNames;

	public Heuristic heuristic;

	public float heuristicScale;

	public ThreadCount threadCount;

	public float maxFrameTime;

	public bool batchGraphUpdates;

	public float graphUpdateBatchingInterval;

	[NonSerialized]
	public PathHandler debugPathData;

	[NonSerialized]
	public ushort debugPathID;

	private string inGameDebugPath;

	[NonSerialized]
	private bool isScanningBacking;

	public static Action OnAwakeSettings;

	public static OnGraphDelegate OnGraphPreScan;

	public static OnGraphDelegate OnGraphPostScan;

	public static OnPathDelegate OnPathPreSearch;

	public static OnPathDelegate OnPathPostSearch;

	public static OnScanDelegate OnPreScan;

	public static OnScanDelegate OnPostScan;

	public static OnScanDelegate OnLatePostScan;

	public static OnScanDelegate OnGraphsUpdated;

	public static Action On65KOverflow;

	[Obsolete]
	public Action OnGraphsWillBeUpdated;

	[Obsolete]
	public Action OnGraphsWillBeUpdated2;

	private readonly GraphUpdateProcessor graphUpdates;

	internal readonly HierarchicalGraph hierarchicalGraph;

	public readonly NavmeshUpdates navmeshUpdates;

	private readonly WorkItemProcessor workItems;

	private PathProcessor pathProcessor;

	private bool graphUpdateRoutineRunning;

	private bool graphUpdatesWorkItemAdded;

	private float lastGraphUpdate;

	private PathProcessor.GraphUpdateLock workItemLock;

	internal readonly PathReturnQueue pathReturnQueue;

	public EuclideanEmbedding euclideanEmbedding;

	public bool showGraphs;

	private ushort nextFreePathID;

	private RetainedGizmos gizmos;

	private static int waitForPathDepth;

	private static readonly NNConstraint NNConstraintNone;

	[Obsolete]
	public Type[] graphTypes => null;

	[Obsolete("The 'astarData' field has been renamed to 'data'")]
	public AstarData astarData => null;

	public NavGraph[] graphs => null;

	public float maxNearestNodeDistanceSqr => 0f;

	[Obsolete("This field has been renamed to 'batchGraphUpdates'")]
	public bool limitGraphUpdates
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Obsolete("This field has been renamed to 'graphUpdateBatchingInterval'")]
	public float maxGraphUpdateFreq
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float lastScanTime { get; private set; }

	public bool isScanning
	{
		get
		{
			return false;
		}
		private set
		{
		}
	}

	public int NumParallelThreads => 0;

	public bool IsUsingMultithreading => false;

	[Obsolete("Fixed grammar, use IsAnyGraphUpdateQueued instead")]
	public bool IsAnyGraphUpdatesQueued => false;

	public bool IsAnyGraphUpdateQueued => false;

	public bool IsAnyGraphUpdateInProgress => false;

	public bool IsAnyWorkItemInProgress => false;

	internal bool IsInsideWorkItem => false;

	private AstarPath()
	{
	}

	public string[] GetTagNames()
	{
		return null;
	}

	public static void FindAstarPath()
	{
	}

	public static string[] FindTagNames()
	{
		return null;
	}

	internal ushort GetNextPathID()
	{
		return 0;
	}

	private void RecalculateDebugLimits()
	{
	}

	private void OnDrawGizmos()
	{
	}

	private void OnGUI()
	{
	}

	private void LogPathResults(Path path)
	{
	}

	private void Update()
	{
	}

	private void PerformBlockingActions(bool force = false)
	{
	}

	[Obsolete("This method has been moved. Use the method on the context object that can be sent with work item delegates instead")]
	public void QueueWorkItemFloodFill()
	{
	}

	[Obsolete("This method has been moved. Use the method on the context object that can be sent with work item delegates instead")]
	public void EnsureValidFloodFill()
	{
	}

	public void AddWorkItem(Action callback)
	{
	}

	public void AddWorkItem(Action<IWorkItemContext> callback)
	{
	}

	public void AddWorkItem(AstarWorkItem item)
	{
	}

	public void QueueGraphUpdates()
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedGraphUpdate_003Ed__110))]
	private IEnumerator DelayedGraphUpdate()
	{
		return null;
	}

	public void UpdateGraphs(Bounds bounds, float delay)
	{
	}

	public void UpdateGraphs(GraphUpdateObject ob, float delay)
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateGraphsInternal_003Ed__113))]
	private IEnumerator UpdateGraphsInternal(GraphUpdateObject ob, float delay)
	{
		return null;
	}

	public void UpdateGraphs(Bounds bounds)
	{
	}

	public void UpdateGraphs(GraphUpdateObject ob)
	{
	}

	public void FlushGraphUpdates()
	{
	}

	public void FlushWorkItems()
	{
	}

	[Obsolete("Use FlushWorkItems() instead")]
	public void FlushWorkItems(bool unblockOnComplete, bool block)
	{
	}

	[Obsolete("Use FlushWorkItems instead")]
	public void FlushThreadSafeCallbacks()
	{
	}

	public static int CalculateThreadCount(ThreadCount count)
	{
		return 0;
	}

	protected override void Awake()
	{
	}

	private void InitializePathProcessor()
	{
	}

	internal void VerifyIntegrity()
	{
	}

	public void ConfigureReferencesInternal()
	{
	}

	private void InitializeProfiler()
	{
	}

	private void InitializeAstarData()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	[Obsolete("Not meaningful anymore. The HierarchicalGraph takes care of things automatically behind the scenes")]
	public void FloodFill(GraphNode seed)
	{
	}

	[Obsolete("Not meaningful anymore. The HierarchicalGraph takes care of things automatically behind the scenes")]
	public void FloodFill(GraphNode seed, uint area)
	{
	}

	[ContextMenu("Flood Fill Graphs")]
	[Obsolete("Avoid using. This will force a full recalculation of the connected components. In most cases the HierarchicalGraph class takes care of things automatically behind the scenes now.")]
	public void FloodFill()
	{
	}

	internal int GetNewNodeIndex()
	{
		return 0;
	}

	internal void InitializeNode(GraphNode node)
	{
	}

	internal void DestroyNode(GraphNode node)
	{
	}

	[Obsolete("Use PausePathfinding instead. Make sure to call Release on the returned lock.", true)]
	public void BlockUntilPathQueueBlocked()
	{
	}

	public PathProcessor.GraphUpdateLock PausePathfinding()
	{
		return default(PathProcessor.GraphUpdateLock);
	}

	private PathProcessor.GraphUpdateLock PausePathfindingSoon()
	{
		return default(PathProcessor.GraphUpdateLock);
	}

	public void Scan(NavGraph graphToScan)
	{
	}

	public void Scan(NavGraph[] graphsToScan = null)
	{
	}

	public IEnumerable<Progress> ScanAsync(NavGraph graphToScan)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CScanAsync_003Ed__141))]
	public IEnumerable<Progress> ScanAsync(NavGraph[] graphsToScan = null)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CScanGraph_003Ed__142))]
	private IEnumerable<Progress> ScanGraph(NavGraph graph)
	{
		return null;
	}

	[Obsolete("This method has been renamed to BlockUntilCalculated")]
	public static void WaitForPath(Path path)
	{
	}

	public static void BlockUntilCalculated(Path path)
	{
	}

	[Obsolete("Use AddWorkItem(System.Action) instead. Note the slight change in behavior (mentioned in the documentation).")]
	public static void RegisterSafeUpdate(Action callback)
	{
	}

	public static void StartPath(Path path, bool pushToFront = false)
	{
	}

	public NNInfo GetNearest(Vector3 position)
	{
		return default(NNInfo);
	}

	public NNInfo GetNearest(Vector3 position, NNConstraint constraint)
	{
		return default(NNInfo);
	}

	public NNInfo GetNearest(Vector3 position, NNConstraint constraint, GraphNode hint)
	{
		return default(NNInfo);
	}

	public GraphNode GetNearest(Ray ray)
	{
		return null;
	}
}
