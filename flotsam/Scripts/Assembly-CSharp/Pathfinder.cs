using System;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : SceneBehaviour
{
	public const int QUERY_SLOTS = 8;

	[SerializeField]
	[Range(1f, 4f)]
	[Tooltip("The number of threads reserved for agent pathfinding")]
	private int _pathThreads = 3;

	[SerializeField]
	[Tooltip("Should all pathfinding queries be stored or only the ones that failed?")]
	private bool _debugAllPathfindingQueries;

	[SerializeField]
	[Tooltip("Should all boat queries be stored or only the ones that failed?")]
	private bool _debugAllBoatQueries;

	[SerializeField]
	private DebugPathfinder _pathDebugger;

	public List<PathfindingQueryBase> QueriesToDebug;

	private static Pathfinder _instance;

	private PathfinderQuery _query;

	private PathfindingQueryBase[] _querySlots = new PathfindingQueryBase[8];

	private LinkedList<PathfindingQueryBase> _queryQueue = new LinkedList<PathfindingQueryBase>();

	private bool _showDebugDialog = true;

	public static bool HasInstance => _instance != null;

	public List<PathfinderPath> PathQueue { get; private set; } = new List<PathfinderPath>();

	protected override void Awake()
	{
		base.Awake();
		if (_instance == null)
		{
			_instance = this;
		}
		else if (_instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void OnDestroy()
	{
		_instance = null;
	}

	public static bool TryQueuePath(out PathfinderPath path, Navigator navigator, ITarget target)
	{
		if ((bool)_instance)
		{
			path = new PathfinderPath(navigator, target);
			path.SetState(NavigatorPathState.Queued);
			_instance.PathQueue.Add(path);
			return true;
		}
		path = null;
		return false;
	}

	public static bool QueuePath(PathfinderPath path)
	{
		if ((bool)_instance && (path.State == NavigatorPathState.None || path.State == NavigatorPathState.Recalculate))
		{
			_instance.PathQueue.Add(path);
			path.SetState(NavigatorPathState.Queued);
			return true;
		}
		Debug.LogException(new NotSupportedException("Trying to queue a path that is not marked for (re)calculation."));
		return false;
	}

	public static bool DequeuePath(PathfinderPath path)
	{
		if ((bool)_instance && _instance.PathQueue.Remove(path))
		{
			return true;
		}
		return false;
	}

	public static bool QueueQuery(PathfindingQueryBase query)
	{
		if (_instance == null)
		{
			return false;
		}
		if (!_instance.TryExecuteQuery(query))
		{
			_instance._queryQueue.AddLast(query);
		}
		return true;
	}

	private bool TryExecuteQuery(PathfindingQueryBase query)
	{
		for (int i = _pathThreads; i < 8; i++)
		{
			PathfindingQueryBase pathfindingQueryBase = _querySlots[i];
			if (pathfindingQueryBase == null || pathfindingQueryBase.Completed)
			{
				if (query.Execute(i))
				{
					_querySlots[i] = query;
					return true;
				}
				return false;
			}
		}
		return false;
	}

	public static void ProcessQueue()
	{
		if ((bool)_instance)
		{
			_instance.Internal_ProcessQueue();
		}
	}

	private void Internal_ProcessQueue()
	{
		LinkedListNode<PathfindingQueryBase> linkedListNode = _queryQueue.First;
		while (linkedListNode != null)
		{
			LinkedListNode<PathfindingQueryBase> next = linkedListNode.Next;
			if (TryExecuteQuery(linkedListNode.Value))
			{
				_queryQueue.Remove(linkedListNode);
			}
			linkedListNode = next;
		}
		if ((!(_pathDebugger != null) || !_pathDebugger.IsDebugging) && TryReturnAvailableQueuedPathSlotIndex(out var i) && TryReturnQueuedPath(out var path))
		{
			PathfinderQuery pathfinderQuery = PathfinderQuery.Get();
			pathfinderQuery.Initialize(path);
			if (pathfinderQuery.Execute(i))
			{
				_querySlots[i] = pathfinderQuery;
				return;
			}
			Debug.LogException(new Exception($"Unable to execute QueuedPath for '{path.Navigator}' haeding to '{path.Target}'"));
			RequeueQueuedPath(path);
			pathfinderQuery.Return();
		}
	}

	private bool TryReturnQueuedPath(out PathfinderPath path)
	{
		while (0 < PathQueue.Count)
		{
			path = PathQueue[0];
			PathQueue.RemoveAt(0);
			if (path != null)
			{
				path.ClearNodes();
				if (path.ValidateTarget())
				{
					return true;
				}
			}
		}
		path = null;
		return false;
	}

	private bool TryReturnAvailableQueuedPathSlotIndex(out int i)
	{
		for (i = 0; i < _pathThreads; i++)
		{
			PathfindingQueryBase pathfindingQueryBase = _querySlots[i];
			if (pathfindingQueryBase == null || pathfindingQueryBase.Completed)
			{
				return true;
			}
		}
		i = -1;
		return false;
	}

	private void RequeueQueuedPath(PathfinderPath path)
	{
		PathQueue.Insert(0, path);
	}

	public void LogWarning(string message)
	{
	}

	public void LogError(string message)
	{
	}

	public static bool AddQueryToDebug(PathfindingQueryBase pathfindingQuery)
	{
		return false;
	}

	private string GetNoPathFoundMessage(PathfindingQueryBase pathfindingQuery)
	{
		if (pathfindingQuery is PathfinderQuery pathfinderQuery)
		{
			return $"Pathfinder was unable to find a path to '{pathfinderQuery.Target}' for '{pathfinderQuery.PathfinderPath.Navigator}'";
		}
		return "Pathfinder was unable to find a path.";
	}

	public void RemoveQueryToDebug(int index)
	{
		if (index < QueriesToDebug.Count)
		{
			QueriesToDebug[index].Return();
			QueriesToDebug.RemoveAt(index);
		}
	}

	public void DebugPathfindingQuery(int index)
	{
		if (index < QueriesToDebug.Count)
		{
			ReturnDebugPathfinder().DebugQuery(QueriesToDebug[index]);
		}
	}

	public DebugPathfinder ReturnDebugPathfinder()
	{
		if (_pathDebugger == null)
		{
			_pathDebugger = new GameObject().AddComponent<DebugPathfinder>();
			_pathDebugger.name = "Path Debugger";
			_pathDebugger.transform.SetParent(base.transform.parent);
		}
		return _pathDebugger;
	}
}
