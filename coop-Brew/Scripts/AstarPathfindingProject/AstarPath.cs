using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding;
using Pathfinding.Drawing;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Graphs.Util;
using Pathfinding.Sync;
using Pathfinding.Util;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
[AddComponentMenu("Pathfinding/AstarPath")]
[DisallowMultipleComponent]
[HelpURL("https://arongranberg.com/astar/documentation/stable/astarpath.html")]
public class AstarPath : VersionedMonoBehaviour
{
	public enum AstarDistribution
	{
		WebsiteDownload = 0,
		AssetStore = 1,
		PackageManager = 2
	}

	private class DummyGraphUpdateContext : IGraphUpdateContext
	{
		public void DirtyBounds(Bounds bounds)
		{
		}
	}

	private class DestroyGraphPromise : IGraphUpdatePromise
	{
		public IGraphInternals graph;

		public IEnumerator<JobHandle> Prepare()
		{
			return null;
		}

		public void Apply(IGraphUpdateContext context)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDelayedGraphUpdate_003Ed__100 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CDelayedGraphUpdate_003Ed__100(int _003C_003E1__state)
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
	private sealed class _003CScanInternal_003Ed__129 : IEnumerable<Progress>, IEnumerable, IEnumerator<Progress>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Progress _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private NavGraph[] graphsToScan;

		public NavGraph[] _003C_003E3__graphsToScan;

		public AstarPath _003C_003E4__this;

		private bool async;

		public bool _003C_003E3__async;

		private PathProcessor.GraphUpdateLock _003CgraphUpdateLock_003E5__2;

		private Stopwatch _003Cwatch_003E5__3;

		private List<(IGraphUpdatePromise, IEnumerator<JobHandle>)> _003Cpromises_003E5__4;

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
		public _003CScanInternal_003Ed__129(int _003C_003E1__state)
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
	private sealed class _003CTickAsyncScanUntilCompletion_003Ed__126 : IEnumerable<Progress>, IEnumerable, IEnumerator<Progress>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Progress _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerator<Progress> task;

		public IEnumerator<Progress> _003C_003E3__task;

		public AstarPath _003C_003E4__this;

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
		public _003CTickAsyncScanUntilCompletion_003Ed__126(int _003C_003E1__state)
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
	private sealed class _003CUpdateGraphsInternal_003Ed__103 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CUpdateGraphsInternal_003Ed__103(int _003C_003E1__state)
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

	private bool hasScannedGraphAtStartup;

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

	[Obsolete("This setting has been removed. It is now always true", true)]
	public bool fullGetNearestSearch;

	[Obsolete("This setting has been removed. It was always a bit of a hack. Use NNConstraint.graphMask if you want to choose which graphs are searched.", true)]
	public bool prioritizeGraphs;

	[Obsolete("This setting has been removed. It was always a bit of a hack. Use NNConstraint.graphMask if you want to choose which graphs are searched.", true)]
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
	internal PathHandler debugPathData;

	[NonSerialized]
	internal ushort debugPathID;

	private string inGameDebugPath;

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

	public static Action OnPathsCalculated;

	private readonly GraphUpdateProcessor graphUpdates;

	internal readonly HierarchicalGraph hierarchicalGraph;

	public readonly OffMeshLinks offMeshLinks;

	public NavmeshUpdates navmeshUpdates;

	private readonly WorkItemProcessor workItems;

	private readonly PathProcessor pathProcessor;

	internal GlobalNodeStorage nodeStorage;

	private RWLock graphDataLock;

	private bool graphUpdateRoutineRunning;

	private bool graphUpdatesWorkItemAdded;

	private float lastGraphUpdate;

	private PathProcessor.GraphUpdateLock workItemLock;

	internal readonly PathReturnQueue pathReturnQueue;

	public EuclideanEmbedding euclideanEmbedding;

	private IEnumerator<Progress> asyncScanTask;

	public bool showGraphs;

	private ushort nextFreePathID;

	private RedrawScope redrawScope;

	private static int waitForPathDepth;

	internal static readonly NNConstraint NNConstraintClosestAsSeenFromAbove;

	public NavGraph[] graphs => null;

	public float maxNearestNodeDistanceSqr => 0f;

	public float lastScanTime { get; private set; }

	[field: NonSerialized]
	public bool isScanning { get; private set; }

	public int NumParallelThreads => 0;

	public bool IsUsingMultithreading => false;

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

	public override void DrawGizmos()
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

	[IteratorStateMachine(typeof(_003CDelayedGraphUpdate_003Ed__100))]
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

	[IteratorStateMachine(typeof(_003CUpdateGraphsInternal_003Ed__103))]
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

	public static int CalculateThreadCount(ThreadCount count)
	{
		return 0;
	}

	private void InitializePathProcessor()
	{
	}

	private void InitializeColors()
	{
	}

	private void ShutdownPathfindingThreads()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public JobHandle AllocateNodes<T>(T[] result, int count, Func<T> createNode, uint variantsPerNode) where T : GraphNode
	{
		return default(JobHandle);
	}

	internal void InitializeNode(GraphNode node)
	{
	}

	internal void InitializeNodes(GraphNode[] nodes)
	{
	}

	internal void DestroyNode(GraphNode node)
	{
	}

	public PathProcessor.GraphUpdateLock PausePathfinding()
	{
		return default(PathProcessor.GraphUpdateLock);
	}

	public PathProcessor.GraphUpdateLock PausePathfindingSoon()
	{
		return default(PathProcessor.GraphUpdateLock);
	}

	private void BlockUntilAsyncScanComplete()
	{
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

	public IEnumerable<Progress> ScanAsync(NavGraph[] graphsToScan = null)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CTickAsyncScanUntilCompletion_003Ed__126))]
	private IEnumerable<Progress> TickAsyncScanUntilCompletion(IEnumerator<Progress> task)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CScanInternal_003Ed__129))]
	private IEnumerable<Progress> ScanInternal(NavGraph[] graphsToScan, bool async)
	{
		return null;
	}

	internal void DirtyBounds(Bounds bounds)
	{
	}

	public static void BlockUntilCalculated(Path path)
	{
	}

	public static void StartPath(Path path, bool pushToFront = false, bool assumeInPlayMode = false)
	{
	}

	public bool IsPointOnNavmesh(Vector3 position)
	{
		return false;
	}

	public NNInfo GetNearest(Vector3 position)
	{
		return default(NNInfo);
	}

	public NNInfo GetNearest(Vector3 position, NNConstraint constraint)
	{
		return default(NNInfo);
	}

	public bool Linecast(Vector3 start, Vector3 end)
	{
		return false;
	}

	public bool Linecast(Vector3 start, Vector3 end, out GraphHitInfo hit)
	{
		hit = default(GraphHitInfo);
		return false;
	}

	private IRaycastableGraph ClosestRaycastableGraph(Vector3 point)
	{
		return null;
	}

	public GraphNode GetNearest(Ray ray)
	{
		return null;
	}

	public GraphSnapshot Snapshot(Bounds bounds, GraphMask graphMask)
	{
		return default(GraphSnapshot);
	}

	public RWLock.ReadLockAsync LockGraphDataForReading()
	{
		return default(RWLock.ReadLockAsync);
	}

	public RWLock.WriteLockAsync LockGraphDataForWriting()
	{
		return default(RWLock.WriteLockAsync);
	}

	public RWLock.LockSync LockGraphDataForWritingSync()
	{
		return default(RWLock.LockSync);
	}

	public NavmeshEdges.NavmeshBorderData GetNavmeshBorderData(out RWLock.CombinedReadLockAsync readLock)
	{
		readLock = default(RWLock.CombinedReadLockAsync);
		return default(NavmeshEdges.NavmeshBorderData);
	}
}
