using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Pathfinding;
using Pathfinding.Drawing;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Graphs.Util;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
[AddComponentMenu("Pathfinding/AstarPath")]
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

	public static readonly Version Version = new Version(5, 1, 2);

	public static readonly AstarDistribution Distribution = AstarDistribution.AssetStore;

	public static readonly string Branch = "master";

	[FormerlySerializedAs("astarData")]
	public AstarData data;

	public static AstarPath active;

	public bool showNavGraphs = true;

	public bool showUnwalkableNodes = true;

	public GraphDebugMode debugMode;

	public float debugFloor;

	public float debugRoof = 20000f;

	public bool manualDebugFloorRoof;

	public bool showSearchTree;

	public float unwalkableNodeDebugSize = 0.3f;

	public PathLog logPathResults = PathLog.Normal;

	public float maxNearestNodeDistance = 100f;

	public bool scanOnStartup = true;

	[Obsolete("This setting has been removed. It is now always true", true)]
	public bool fullGetNearestSearch;

	[Obsolete("This setting has been removed. It was always a bit of a hack. Use NNConstraint.graphMask if you want to choose which graphs are searched.", true)]
	public bool prioritizeGraphs;

	[Obsolete("This setting has been removed. It was always a bit of a hack. Use NNConstraint.graphMask if you want to choose which graphs are searched.", true)]
	public float prioritizeGraphsLimit = 1f;

	public AstarColor colorSettings;

	[SerializeField]
	protected string[] tagNames;

	public Heuristic heuristic = Heuristic.Euclidean;

	public float heuristicScale = 1f;

	public ThreadCount threadCount = ThreadCount.One;

	public float maxFrameTime = 1f;

	public bool batchGraphUpdates;

	public float graphUpdateBatchingInterval = 0.2f;

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

	public static Action OnPathsCalculated;

	private readonly GraphUpdateProcessor graphUpdates;

	internal readonly HierarchicalGraph hierarchicalGraph;

	public readonly OffMeshLinks offMeshLinks;

	public NavmeshUpdates navmeshUpdates = new NavmeshUpdates();

	private readonly WorkItemProcessor workItems;

	private readonly PathProcessor pathProcessor;

	internal GlobalNodeStorage nodeStorage;

	private RWLock graphDataLock = new RWLock();

	private bool graphUpdateRoutineRunning;

	private bool graphUpdatesWorkItemAdded;

	private float lastGraphUpdate = -9999f;

	private PathProcessor.GraphUpdateLock workItemLock;

	internal readonly PathReturnQueue pathReturnQueue;

	public EuclideanEmbedding euclideanEmbedding = new EuclideanEmbedding();

	public bool showGraphs;

	private ushort nextFreePathID = 1;

	private RedrawScope redrawScope;

	private bool hasScannedGraphAtStartup;

	private static int waitForPathDepth = 0;

	private static readonly NNConstraint NNConstraintNone = NNConstraint.None;

	internal static readonly NNConstraint NNConstraintClosestAsSeenFromAbove = new NNConstraint
	{
		constrainWalkability = false,
		constrainTags = false,
		constrainDistance = true,
		distanceMetric = DistanceMetric.ClosestAsSeenFromAbove()
	};

	public NavGraph[] graphs => data.graphs;

	public float maxNearestNodeDistanceSqr => maxNearestNodeDistance * maxNearestNodeDistance;

	public float lastScanTime { get; private set; }

	public bool isScanning
	{
		get
		{
			return isScanningBacking;
		}
		private set
		{
			isScanningBacking = value;
		}
	}

	public int NumParallelThreads => pathProcessor.NumThreads;

	public bool IsUsingMultithreading => pathProcessor.IsUsingMultithreading;

	public bool IsAnyGraphUpdateQueued => graphUpdates.IsAnyGraphUpdateQueued;

	public bool IsAnyGraphUpdateInProgress => graphUpdates.IsAnyGraphUpdateInProgress;

	public bool IsAnyWorkItemInProgress => workItems.workItemsInProgress;

	internal bool IsInsideWorkItem => workItems.workItemsInProgressRightNow;

	private AstarPath()
	{
		pathReturnQueue = new PathReturnQueue(this, delegate
		{
			if (OnPathsCalculated != null)
			{
				OnPathsCalculated();
			}
		});
		nodeStorage = new GlobalNodeStorage(this);
		hierarchicalGraph = new HierarchicalGraph(nodeStorage);
		pathProcessor = new PathProcessor(this, pathReturnQueue, 1, multithreaded: false);
		offMeshLinks = new OffMeshLinks(this);
		workItems = new WorkItemProcessor(this);
		graphUpdates = new GraphUpdateProcessor(this);
		navmeshUpdates.astar = this;
		data = new AstarData(this);
		workItems.OnGraphsUpdated += delegate
		{
			if (OnGraphsUpdated != null)
			{
				try
				{
					OnGraphsUpdated(this);
				}
				catch (Exception exception)
				{
					UnityEngine.Debug.LogException(exception);
				}
			}
		};
		pathProcessor.OnPathPreSearch += delegate(Path path)
		{
			OnPathPreSearch?.Invoke(path);
		};
		pathProcessor.OnPathPostSearch += delegate(Path path)
		{
			LogPathResults(path);
			OnPathPostSearch?.Invoke(path);
		};
		pathProcessor.OnQueueUnblocked += delegate
		{
			if (euclideanEmbedding.dirty)
			{
				euclideanEmbedding.RecalculateCosts();
			}
		};
	}

	public string[] GetTagNames()
	{
		if (tagNames == null || tagNames.Length != 32)
		{
			tagNames = new string[32];
			for (int i = 0; i < tagNames.Length; i++)
			{
				tagNames[i] = i.ToString() ?? "";
			}
			tagNames[0] = "Basic Ground";
		}
		return tagNames;
	}

	public static void FindAstarPath()
	{
		if (!Application.isPlaying)
		{
			if (active == null)
			{
				active = UnityCompatibility.FindAnyObjectByType<AstarPath>();
			}
			if (active != null && (active.data.graphs == null || active.data.graphs.Length == 0))
			{
				active.data.DeserializeGraphs();
			}
		}
	}

	public static string[] FindTagNames()
	{
		FindAstarPath();
		if (!(active != null))
		{
			return new string[1] { "There is no AstarPath component in the scene" };
		}
		return active.GetTagNames();
	}

	internal ushort GetNextPathID()
	{
		if (nextFreePathID == 0)
		{
			nextFreePathID++;
			if (On65KOverflow != null)
			{
				Action on65KOverflow = On65KOverflow;
				On65KOverflow = null;
				on65KOverflow();
			}
		}
		return nextFreePathID++;
	}

	private void RecalculateDebugLimits()
	{
		debugFloor = 0f;
		debugRoof = 1f;
	}

	public override void DrawGizmos()
	{
		if (active != this || graphs == null)
		{
			return;
		}
		colorSettings.PushToStatic(this);
		if (!redrawScope.isValid)
		{
			redrawScope = DrawingManager.GetRedrawScope(base.gameObject);
		}
		if (workItems.workItemsInProgress || isScanning)
		{
			return;
		}
		redrawScope.Rewind();
		if (showNavGraphs && !manualDebugFloorRoof)
		{
			RecalculateDebugLimits();
		}
		for (int i = 0; i < graphs.Length; i++)
		{
			if (graphs[i] != null && graphs[i].drawGizmos)
			{
				graphs[i].OnDrawGizmos(DrawingManager.instance.gizmos, showNavGraphs, redrawScope);
			}
		}
		if (showNavGraphs)
		{
			euclideanEmbedding.OnDrawGizmos();
			if (debugMode == GraphDebugMode.HierarchicalNode)
			{
				hierarchicalGraph.OnDrawGizmos(DrawingManager.instance.gizmos, redrawScope);
			}
			if (debugMode == GraphDebugMode.NavmeshBorderObstacles)
			{
				hierarchicalGraph.navmeshEdges.OnDrawGizmos(DrawingManager.instance.gizmos, redrawScope);
			}
		}
	}

	private void OnGUI()
	{
		if (logPathResults == PathLog.InGame && inGameDebugPath != "")
		{
			GUI.Label(new Rect(5f, 5f, 400f, 600f), inGameDebugPath);
		}
	}

	private void LogPathResults(Path path)
	{
		if (logPathResults != PathLog.None && (path.error || logPathResults != PathLog.OnlyErrors))
		{
			string message = ((IPathInternals)path).DebugString(logPathResults);
			if (logPathResults == PathLog.InGame)
			{
				inGameDebugPath = message;
			}
			else if (path.error)
			{
				UnityEngine.Debug.LogWarning(message);
			}
			else
			{
				UnityEngine.Debug.Log(message);
			}
		}
	}

	private void Update()
	{
		if (Application.isPlaying)
		{
			navmeshUpdates.Update();
			if (!isScanning)
			{
				PerformBlockingActions();
			}
			if (!pathProcessor.IsUsingMultithreading)
			{
				pathProcessor.TickNonMultithreaded();
			}
			pathReturnQueue.ReturnPaths(timeSlice: true);
		}
	}

	private void PerformBlockingActions(bool force = false)
	{
		if (workItemLock.Held && pathProcessor.queue.allReceiversBlocked)
		{
			pathReturnQueue.ReturnPaths(timeSlice: false);
			if (workItems.ProcessWorkItemsForUpdate(force))
			{
				workItemLock.Release();
			}
		}
	}

	public void AddWorkItem(Action callback)
	{
		AddWorkItem(new AstarWorkItem(callback));
	}

	public void AddWorkItem(Action<IWorkItemContext> callback)
	{
		AddWorkItem(new AstarWorkItem(callback));
	}

	public void AddWorkItem(AstarWorkItem item)
	{
		workItems.AddWorkItem(item);
		if (!workItemLock.Held)
		{
			workItemLock = PausePathfindingSoon();
		}
	}

	public void QueueGraphUpdates()
	{
		if (!graphUpdatesWorkItemAdded)
		{
			graphUpdatesWorkItemAdded = true;
			AstarWorkItem workItem = graphUpdates.GetWorkItem();
			AddWorkItem(new AstarWorkItem(delegate(IWorkItemContext context)
			{
				graphUpdatesWorkItemAdded = false;
				lastGraphUpdate = Time.realtimeSinceStartup;
				workItem.initWithContext(context);
			}, workItem.updateWithContext));
		}
	}

	private IEnumerator DelayedGraphUpdate()
	{
		graphUpdateRoutineRunning = true;
		yield return new WaitForSeconds(graphUpdateBatchingInterval - (Time.realtimeSinceStartup - lastGraphUpdate));
		QueueGraphUpdates();
		graphUpdateRoutineRunning = false;
	}

	public void UpdateGraphs(Bounds bounds, float delay)
	{
		UpdateGraphs(new GraphUpdateObject(bounds), delay);
	}

	public void UpdateGraphs(GraphUpdateObject ob, float delay)
	{
		StartCoroutine(UpdateGraphsInternal(ob, delay));
	}

	private IEnumerator UpdateGraphsInternal(GraphUpdateObject ob, float delay)
	{
		yield return new WaitForSeconds(delay);
		UpdateGraphs(ob);
	}

	public void UpdateGraphs(Bounds bounds)
	{
		UpdateGraphs(new GraphUpdateObject(bounds));
	}

	public void UpdateGraphs(GraphUpdateObject ob)
	{
		if (ob.internalStage != -1)
		{
			throw new Exception("You are trying to update graphs using the same graph update object twice. Please create a new GraphUpdateObject instead.");
		}
		ob.internalStage = -2;
		graphUpdates.AddToQueue(ob);
		if (batchGraphUpdates && Time.realtimeSinceStartup - lastGraphUpdate < graphUpdateBatchingInterval)
		{
			if (!graphUpdateRoutineRunning)
			{
				StartCoroutine(DelayedGraphUpdate());
			}
		}
		else
		{
			QueueGraphUpdates();
		}
	}

	public void FlushGraphUpdates()
	{
		if (IsAnyGraphUpdateQueued || IsAnyGraphUpdateInProgress)
		{
			QueueGraphUpdates();
			FlushWorkItems();
		}
	}

	public void FlushWorkItems()
	{
		if (workItems.anyQueued || workItems.workItemsInProgress)
		{
			PathProcessor.GraphUpdateLock graphUpdateLock = PausePathfinding();
			PerformBlockingActions(force: true);
			graphUpdateLock.Release();
		}
	}

	public static int CalculateThreadCount(ThreadCount count)
	{
		if (count == ThreadCount.AutomaticLowLoad || count == ThreadCount.AutomaticHighLoad)
		{
			int num = Mathf.Max(1, SystemInfo.processorCount);
			int num2 = SystemInfo.systemMemorySize;
			if (num2 <= 0)
			{
				UnityEngine.Debug.LogError("Machine reporting that is has <= 0 bytes of RAM. This is definitely not true, assuming 1 GiB");
				num2 = 1024;
			}
			if (num <= 1)
			{
				return 0;
			}
			if (num2 <= 512)
			{
				return 0;
			}
			if (count == ThreadCount.AutomaticHighLoad)
			{
				if (num2 <= 1024)
				{
					num = Math.Min(num, 2);
				}
			}
			else
			{
				num /= 2;
				num = Mathf.Max(1, num);
				if (num2 <= 1024)
				{
					num = Math.Min(num, 2);
				}
				num = Math.Min(num, 6);
			}
			return num;
		}
		return (int)count;
	}

	private void InitializePathProcessor()
	{
		int num = CalculateThreadCount(threadCount);
		if (!Application.isPlaying)
		{
			num = 0;
		}
		int processors = Mathf.Max(num, 1);
		bool multithreaded = num > 0;
		pathProcessor.StopThreads();
		pathProcessor.SetThreadCount(processors, multithreaded);
	}

	internal void VerifyIntegrity()
	{
		if (data.graphs == null)
		{
			data.graphs = new NavGraph[0];
			data.UpdateShortcuts();
		}
	}

	public void ConfigureReferencesInternal()
	{
		colorSettings = colorSettings ?? new AstarColor();
		colorSettings.PushToStatic(this);
	}

	private void InitializeGraphs()
	{
		data.FindGraphTypes();
		data.OnEnable();
		data.UpdateShortcuts();
	}

	private void ShutdownPathfindingThreads()
	{
		PathProcessor.GraphUpdateLock graphUpdateLock = PausePathfinding();
		navmeshUpdates.OnDisable();
		euclideanEmbedding.dirty = false;
		graphUpdates.DiscardQueued();
		FlushWorkItems();
		if (logPathResults == PathLog.Heavy)
		{
			UnityEngine.Debug.Log("Processing Possible Work Items");
		}
		pathProcessor.StopThreads();
		if (logPathResults == PathLog.Heavy)
		{
			UnityEngine.Debug.Log("Returning Paths");
		}
		pathReturnQueue.ReturnPaths(timeSlice: false);
		graphUpdateLock.Release();
		euclideanEmbedding.OnDisable();
	}

	private void OnEnable()
	{
		if (active != null)
		{
			if (active != this && Application.isPlaying)
			{
				if (base.enabled)
				{
					UnityEngine.Debug.LogWarning("Another A* component is already in the scene. More than one A* component cannot be active at the same time. Disabling this one.", this);
				}
				base.enabled = false;
			}
			return;
		}
		active = this;
		base.useGUILayout = false;
		if (OnAwakeSettings != null)
		{
			OnAwakeSettings();
		}
		hierarchicalGraph.OnEnable();
		GraphModifier.FindAllModifiers();
		RelevantGraphSurface.FindAllGraphSurfaces();
		ConfigureReferencesInternal();
		data.OnEnable();
		FlushWorkItems();
		euclideanEmbedding.dirty = true;
		InitializePathProcessor();
		if (Application.isPlaying)
		{
			navmeshUpdates.OnEnable();
			if (scanOnStartup && !hasScannedGraphAtStartup && (!data.cacheStartup || data.file_cachedStartup == null))
			{
				hasScannedGraphAtStartup = true;
				Scan();
			}
		}
	}

	private void OnDisable()
	{
		redrawScope.Dispose();
		if (active == this)
		{
			graphDataLock.WriteSync().Unlock();
			ShutdownPathfindingThreads();
			data.DestroyAllNodes();
			data.DisposeUnmanagedData();
			hierarchicalGraph.OnDisable();
			nodeStorage.OnDisable();
			offMeshLinks.OnDisable();
			active = null;
		}
	}

	private void OnDestroy()
	{
		if (logPathResults == PathLog.Heavy)
		{
			UnityEngine.Debug.Log("AstarPath Component Destroyed - Cleaning Up Pathfinding Data");
		}
		AstarPath astarPath = active;
		active = this;
		ShutdownPathfindingThreads();
		pathProcessor.Dispose();
		if (logPathResults == PathLog.Heavy)
		{
			UnityEngine.Debug.Log("Destroying Graphs");
		}
		if (data != null)
		{
			data.OnDestroy();
		}
		active = astarPath;
		if (logPathResults == PathLog.Heavy)
		{
			UnityEngine.Debug.Log("Cleaning up variables");
		}
		if (active == this)
		{
			OnAwakeSettings = null;
			OnGraphPreScan = null;
			OnGraphPostScan = null;
			OnPathPreSearch = null;
			OnPathPostSearch = null;
			OnPreScan = null;
			OnPostScan = null;
			OnLatePostScan = null;
			On65KOverflow = null;
			OnGraphsUpdated = null;
			active = null;
		}
	}

	public JobHandle AllocateNodes<T>(T[] result, int count, Func<T> createNode, uint variantsPerNode) where T : GraphNode
	{
		if (!pathProcessor.queue.allReceiversBlocked)
		{
			throw new Exception("Trying to initialize a node when it is not safe to initialize any nodes. Must be done during a graph update. See http://arongranberg.com/astar/docs/graph-updates.html#direct");
		}
		return nodeStorage.AllocateNodesJob(result, count, createNode, variantsPerNode);
	}

	internal void InitializeNode(GraphNode node)
	{
		if (!pathProcessor.queue.allReceiversBlocked)
		{
			throw new Exception("Trying to initialize a node when it is not safe to initialize any nodes. Must be done during a graph update. See http://arongranberg.com/astar/docs/graph-updates.html#direct");
		}
		nodeStorage.InitializeNode(node);
	}

	internal void InitializeNodes(GraphNode[] nodes)
	{
		if (!pathProcessor.queue.allReceiversBlocked)
		{
			throw new Exception("Trying to initialize a node when it is not safe to initialize any nodes. Must be done during a graph update. See http://arongranberg.com/astar/docs/graph-updates.html#direct");
		}
		for (int i = 0; i < nodes.Length; i++)
		{
			nodeStorage.InitializeNode(nodes[i]);
		}
	}

	internal void DestroyNode(GraphNode node)
	{
		nodeStorage.DestroyNode(node);
	}

	public PathProcessor.GraphUpdateLock PausePathfinding()
	{
		graphDataLock.WriteSync().Unlock();
		return pathProcessor.PausePathfinding(block: true);
	}

	public PathProcessor.GraphUpdateLock PausePathfindingSoon()
	{
		return pathProcessor.PausePathfinding(block: false);
	}

	public void Scan(NavGraph graphToScan)
	{
		if (graphToScan == null)
		{
			throw new ArgumentNullException();
		}
		Scan(new NavGraph[1] { graphToScan });
	}

	public void Scan(NavGraph[] graphsToScan = null)
	{
		ScanningStage scanningStage = (ScanningStage)(-1);
		foreach (Progress item in ScanInternal(graphsToScan, async: false))
		{
			if (scanningStage != item.stage)
			{
				scanningStage = item.stage;
			}
		}
	}

	public IEnumerable<Progress> ScanAsync(NavGraph graphToScan)
	{
		if (graphToScan == null)
		{
			throw new ArgumentNullException();
		}
		return ScanAsync(new NavGraph[1] { graphToScan });
	}

	public IEnumerable<Progress> ScanAsync(NavGraph[] graphsToScan = null)
	{
		return ScanInternal(graphsToScan, async: true);
	}

	private IEnumerable<Progress> ScanInternal(NavGraph[] graphsToScan, bool async)
	{
		if (graphsToScan == null)
		{
			graphsToScan = graphs;
		}
		if (graphsToScan == null || graphsToScan.Length == 0)
		{
			yield break;
		}
		if (isScanning)
		{
			throw new InvalidOperationException("Another async scan is already running");
		}
		if (!base.enabled)
		{
			throw new InvalidOperationException("The AstarPath object must be enabled to scan graphs");
		}
		if (active != this)
		{
			throw new InvalidOperationException("The AstarPath object is not enabled in a scene");
		}
		isScanning = true;
		VerifyIntegrity();
		PathProcessor.GraphUpdateLock graphUpdateLock = PausePathfinding();
		pathReturnQueue.ReturnPaths(timeSlice: false);
		workItems.ProcessWorkItemsForScan(force: true);
		if (!Application.isPlaying)
		{
			data.FindGraphTypes();
			GraphModifier.FindAllModifiers();
		}
		yield return new Progress(0.05f, ScanningStage.PreProcessingGraphs);
		RWLock.LockSync lockSync = graphDataLock.WriteSync();
		if (OnPreScan != null)
		{
			OnPreScan(this);
		}
		GraphModifier.TriggerEvent(GraphModifier.EventType.PreScan);
		GraphModifier.TriggerEvent(GraphModifier.EventType.PreUpdate);
		lockSync.Unlock();
		data.LockGraphStructure();
		Physics.SyncTransforms();
		Physics2D.SyncTransforms();
		Stopwatch watch = Stopwatch.StartNew();
		if (!async)
		{
			RWLock.LockSync lockSync2 = graphDataLock.WriteSync();
			for (int i = 0; i < graphsToScan.Length; i++)
			{
				if (graphsToScan[i] != null)
				{
					((IGraphInternals)graphsToScan[i]).DestroyAllNodes();
				}
			}
			lockSync2.Unlock();
		}
		if (OnGraphPreScan != null)
		{
			RWLock.LockSync lockSync3 = graphDataLock.WriteSync();
			for (int j = 0; j < graphsToScan.Length; j++)
			{
				if (graphsToScan[j] != null)
				{
					OnGraphPreScan(graphsToScan[j]);
				}
			}
			lockSync3.Unlock();
		}
		IGraphUpdatePromise[] promises = new IGraphUpdatePromise[graphsToScan.Length];
		IEnumerator<JobHandle>[] array = new IEnumerator<JobHandle>[graphsToScan.Length];
		for (int k = 0; k < graphsToScan.Length; k++)
		{
			if (graphsToScan[k] != null)
			{
				promises[k] = ((IGraphInternals)graphsToScan[k]).ScanInternal(async);
				array[k] = promises[k].Prepare();
			}
		}
		IEnumerator<Progress> it = ProgressScanningIteratorsConcurrently(array, promises, async);
		while (true)
		{
			try
			{
				if (!it.MoveNext())
				{
					break;
				}
			}
			catch
			{
				isScanning = false;
				data.UnlockGraphStructure();
				graphUpdateLock.Release();
				throw;
			}
			yield return it.Current.MapTo(0.1f, 0.8f);
		}
		yield return new Progress(0.95f, ScanningStage.FinishingScans);
		RWLock.LockSync lockSync4 = graphDataLock.WriteSync();
		DummyGraphUpdateContext context = new DummyGraphUpdateContext();
		for (int l = 0; l < promises.Length; l++)
		{
			try
			{
				if (promises[l] != null)
				{
					promises[l].Apply(context);
				}
			}
			catch
			{
				isScanning = false;
				data.UnlockGraphStructure();
				graphUpdateLock.Release();
				lockSync4.Unlock();
				throw;
			}
		}
		for (int m = 0; m < graphsToScan.Length; m++)
		{
			if (graphsToScan[m] != null)
			{
				if (OnGraphPostScan != null)
				{
					OnGraphPostScan(graphsToScan[m]);
				}
				if (!(graphsToScan[m] is LinkGraph))
				{
					offMeshLinks.DirtyBounds(graphsToScan[m].bounds);
				}
			}
		}
		data.UnlockGraphStructure();
		if (OnPostScan != null)
		{
			OnPostScan(this);
		}
		GraphModifier.TriggerEvent(GraphModifier.EventType.PostScan);
		if (workItemLock.Held)
		{
			workItems.ProcessWorkItemsForScan(force: true);
			workItemLock.Release();
		}
		offMeshLinks.Refresh();
		GraphModifier.TriggerEvent(GraphModifier.EventType.PostUpdateBeforeAreaRecalculation);
		hierarchicalGraph.RecalculateIfNecessary();
		GraphModifier.TriggerEvent(GraphModifier.EventType.PostUpdate);
		if (OnGraphsUpdated != null)
		{
			OnGraphsUpdated(this);
		}
		isScanning = false;
		if (OnLatePostScan != null)
		{
			OnLatePostScan(this);
		}
		GraphModifier.TriggerEvent(GraphModifier.EventType.LatePostScan);
		lockSync4.Unlock();
		euclideanEmbedding.dirty = true;
		euclideanEmbedding.RecalculatePivots();
		FlushWorkItems();
		graphUpdateLock.Release();
		watch.Stop();
		lastScanTime = (float)watch.Elapsed.TotalSeconds;
		if (logPathResults != PathLog.None && logPathResults != PathLog.OnlyErrors)
		{
			UnityEngine.Debug.Log("Scanned graphs in " + (lastScanTime * 1000f).ToString("0") + " ms");
		}
	}

	internal static IEnumerator<Progress> ProgressScanningIteratorsConcurrently(IEnumerator<JobHandle>[] iterators, IGraphUpdatePromise[] promises, bool async)
	{
		while (true)
		{
			int num = -1;
			bool flag = false;
			for (int i = 0; i < iterators.Length; i++)
			{
				IEnumerator<JobHandle> enumerator = iterators[i];
				if (enumerator == null)
				{
					continue;
				}
				if (async)
				{
					if (!enumerator.Current.IsCompleted)
					{
						if (num == -1)
						{
							num = i;
						}
						continue;
					}
					flag = true;
					enumerator.Current.Complete();
				}
				else
				{
					enumerator.Current.Complete();
				}
				if (enumerator.MoveNext())
				{
					if (num == -1)
					{
						num = i;
					}
				}
				else
				{
					iterators[i] = null;
				}
			}
			if (num == -1)
			{
				break;
			}
			if (async)
			{
				if (!flag)
				{
					Thread.Yield();
				}
				float a = (float)num / (float)iterators.Length;
				float b = ((float)num + 0.95f) / (float)iterators.Length;
				yield return new Progress(Mathf.Lerp(a, b, promises[num].Progress), ScanningStage.ScanningGraph, num, iterators.Length);
			}
		}
	}

	internal void DirtyBounds(Bounds bounds)
	{
		offMeshLinks.DirtyBounds(bounds);
		workItems.DirtyGraphs();
	}

	public static void BlockUntilCalculated(Path path)
	{
		if (active == null)
		{
			throw new Exception("Pathfinding is not correctly initialized in this scene (yet?). AstarPath.active is null.\nDo not call this function in Awake");
		}
		if (path == null)
		{
			throw new ArgumentNullException("path");
		}
		if (active.pathProcessor.queue.isClosed)
		{
			return;
		}
		if (path.PipelineState == PathState.Created)
		{
			throw new Exception("The specified path has not been started yet.");
		}
		waitForPathDepth++;
		if (waitForPathDepth == 5)
		{
			UnityEngine.Debug.LogError("You are calling the BlockUntilCalculated function recursively (maybe from a path callback). Please don't do this.");
		}
		if (path.PipelineState < PathState.ReturnQueue)
		{
			if (active.IsUsingMultithreading)
			{
				while (path.PipelineState < PathState.ReturnQueue)
				{
					if (active.pathProcessor.queue.isClosed)
					{
						waitForPathDepth--;
						throw new Exception("Pathfinding Threads seem to have crashed.");
					}
					Thread.Sleep(1);
					active.PerformBlockingActions(force: true);
				}
			}
			else
			{
				while (path.PipelineState < PathState.ReturnQueue)
				{
					if (active.pathProcessor.queue.isEmpty && path.PipelineState != PathState.Processing)
					{
						waitForPathDepth--;
						throw new Exception("Critical error. Path Queue is empty but the path state is '" + path.PipelineState.ToString() + "'");
					}
					active.pathProcessor.TickNonMultithreaded();
					active.PerformBlockingActions(force: true);
				}
			}
		}
		active.pathReturnQueue.ReturnPaths(timeSlice: false);
		waitForPathDepth--;
	}

	public static void StartPath(Path path, bool pushToFront = false, bool assumeInPlayMode = false)
	{
		AstarPath astarPath = active;
		if ((object)astarPath == null)
		{
			UnityEngine.Debug.LogError("There is no AstarPath object in the scene or it has not been initialized yet");
			return;
		}
		if (path.PipelineState != PathState.Created)
		{
			throw new Exception("The path has an invalid state. Expected " + PathState.Created.ToString() + " found " + path.PipelineState.ToString() + "\nMake sure you are not requesting the same path twice");
		}
		if (astarPath.pathProcessor.queue.isClosed)
		{
			path.FailWithError("No new paths are accepted");
			return;
		}
		if (astarPath.graphs == null || astarPath.graphs.Length == 0)
		{
			UnityEngine.Debug.LogError("There are no graphs in the scene");
			path.FailWithError("There are no graphs in the scene");
			UnityEngine.Debug.LogError(path.errorLog);
			return;
		}
		path.Claim(astarPath);
		((IPathInternals)path).AdvanceState(PathState.PathQueue);
		if (pushToFront)
		{
			astarPath.pathProcessor.queue.PushFront(path);
		}
		else
		{
			astarPath.pathProcessor.queue.Push(path);
		}
		if (!assumeInPlayMode && !JobsUtility.IsExecutingJob && !Application.isPlaying)
		{
			BlockUntilCalculated(path);
		}
	}

	public bool IsPointOnNavmesh(Vector3 position)
	{
		NNInfo nearest = GetNearest(position, NNConstraintClosestAsSeenFromAbove);
		if (nearest.node != null && nearest.node.Walkable)
		{
			return nearest.distanceCostSqr < 0.0001f;
		}
		return false;
	}

	public NNInfo GetNearest(Vector3 position)
	{
		return GetNearest(position, null);
	}

	public unsafe NNInfo GetNearest(Vector3 position, NNConstraint constraint)
	{
		NavGraph[] array = graphs;
		float num = ((constraint == null || constraint.constrainDistance) ? maxNearestNodeDistanceSqr : float.PositiveInfinity);
		NNInfo result = NNInfo.Empty;
		if (array == null || array.Length == 0)
		{
			return result;
		}
		if (array.Length == 1)
		{
			NavGraph navGraph = array[0];
			if (navGraph == null || (constraint != null && !constraint.SuitableGraph(0, navGraph)))
			{
				return result;
			}
			result = navGraph.GetNearest(position, constraint, num);
		}
		else
		{
			(float, int)* ptr = stackalloc(float, int)[array.Length];
			UnsafeSpan<(float, int)> unsafeSpan = new UnsafeSpan<(float, int)>(ptr, array.Length);
			int length = 0;
			for (int i = 0; i < array.Length; i++)
			{
				NavGraph navGraph2 = array[i];
				if (navGraph2 != null && (constraint == null || constraint.SuitableGraph(i, navGraph2)))
				{
					float num2 = navGraph2.NearestNodeDistanceSqrLowerBound(position, constraint);
					if (!(num2 > num))
					{
						unsafeSpan[length++] = (num2, i);
					}
				}
			}
			unsafeSpan = unsafeSpan.Slice(0, length);
			unsafeSpan.Sort<(float, int)>();
			for (int j = 0; j < unsafeSpan.Length && !(unsafeSpan[j].Item1 > num); j++)
			{
				NNInfo nearest = array[unsafeSpan[j].Item2].GetNearest(position, constraint, num);
				if (nearest.distanceCostSqr < num)
				{
					num = nearest.distanceCostSqr;
					result = nearest;
				}
			}
		}
		return result;
	}

	public GraphNode GetNearest(Ray ray)
	{
		if (graphs == null)
		{
			return null;
		}
		float minDist = float.PositiveInfinity;
		GraphNode nearestNode = null;
		Vector3 lineDirection = ray.direction;
		Vector3 lineOrigin = ray.origin;
		for (int i = 0; i < graphs.Length; i++)
		{
			graphs[i].GetNodes(delegate(GraphNode node)
			{
				Vector3 vector = (Vector3)node.position;
				Vector3 vector2 = lineOrigin + Vector3.Dot(vector - lineOrigin, lineDirection) * lineDirection;
				float num = Mathf.Abs(vector2.x - vector.x);
				if (!(num * num > minDist))
				{
					float num2 = Mathf.Abs(vector2.z - vector.z);
					if (!(num2 * num2 > minDist))
					{
						float sqrMagnitude = (vector2 - vector).sqrMagnitude;
						if (sqrMagnitude < minDist)
						{
							minDist = sqrMagnitude;
							nearestNode = node;
						}
					}
				}
			});
		}
		return nearestNode;
	}

	public GraphSnapshot Snapshot(Bounds bounds, GraphMask graphMask)
	{
		List<IGraphSnapshot> list = new List<IGraphSnapshot>();
		for (int i = 0; i < graphs.Length; i++)
		{
			if (graphs[i] != null && graphMask.Contains(i))
			{
				IGraphSnapshot graphSnapshot = graphs[i].Snapshot(bounds);
				if (graphSnapshot != null)
				{
					list.Add(graphSnapshot);
				}
			}
		}
		return new GraphSnapshot(list);
	}

	public RWLock.ReadLockAsync LockGraphDataForReading()
	{
		return graphDataLock.Read();
	}

	public RWLock.WriteLockAsync LockGraphDataForWriting()
	{
		return graphDataLock.Write();
	}

	public RWLock.LockSync LockGraphDataForWritingSync()
	{
		return graphDataLock.WriteSync();
	}

	public NavmeshEdges.NavmeshBorderData GetNavmeshBorderData(out RWLock.CombinedReadLockAsync readLock)
	{
		return hierarchicalGraph.navmeshEdges.GetNavmeshEdgeData(out readLock);
	}
}
