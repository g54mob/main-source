using System;
using System.Collections.Generic;
using PajamaLlama;
using UnityEngine;

public abstract class PathfindingQueryBase : ThreadPoolManager.ITask
{
	protected class Data
	{
		public PathfindingQueryBase Owner;

		public Dictionary<PathfindingNode, PathfindingNodeData> Nodes;

		public Heap<PathfindingNodeData> OpenNodes;

		public List<PathfindingNode> Neighbors;

		private static ObjectPool<Data> Pool = new ObjectPool<Data>(CreateInstance, 8);

		public static bool CanGet()
		{
			return Pool.CanGet();
		}

		public static bool TryGet(out Data instance, PathfindingQueryBase owner)
		{
			if (Pool.TryGet(out instance))
			{
				instance.Owner = owner;
				return true;
			}
			Debug.LogException(new Exception($"Unable to get Data object for '{owner}'"));
			instance = null;
			return false;
		}

		public void Return()
		{
			Owner = null;
			Pool.Return(this);
		}

		private static Data CreateInstance()
		{
			Mathf.Pow(GameManager.Settings.GameplaySettings.ConstructionRadius, 2f);
			return new Data
			{
				Nodes = new Dictionary<PathfindingNode, PathfindingNodeData>(GameManager.GraphManager.ClosedNodeListSize),
				OpenNodes = new Heap<PathfindingNodeData>(GameManager.GraphManager.OpenNodeHeapSize),
				Neighbors = new List<PathfindingNode>(128)
			};
		}
	}

	protected Dictionary<PathfindingNode, PathfindingNodeData> _nodes;

	protected Heap<PathfindingNodeData> _openNodes;

	private bool _taskCompleted;

	private Exception _exception;

	private bool _queuedForDebug;

	public int Index { get; private set; }

	public bool IsExecuting { get; protected set; }

	bool ThreadPoolManager.ITask.Completed => _taskCompleted;

	public bool Completed { get; protected set; }

	public bool PathFound { get; protected set; }

	public Dictionary<PathfindingNode, PathfindingNodeData> Nodes => _nodes;

	public Heap<PathfindingNodeData> OpenNodes => _openNodes;

	public List<string> Errors { get; private set; }

	public PathfindingFlags OpenFlag { get; private set; }

	public PathfindingFlags ClosedFlag { get; private set; }

	public virtual bool Execute(int index, bool async = true)
	{
		SetIndex(index);
		IsExecuting = true;
		Completed = false;
		PathFound = false;
		if (Errors != null)
		{
			Errors.Clear();
		}
		if (async)
		{
			_taskCompleted = false;
			ThreadPoolManager.QueueTask(this);
		}
		else if (index > 0)
		{
			ThreadPoolWaitCallback(null);
			UnityCompletedCallback();
		}
		return true;
	}

	protected abstract void Execute();

	public abstract bool ProcessNextNode();

	protected void AddOpenNode(PathfindingNodeData data)
	{
		if (_nodes.TryAdd(data.Node, data))
		{
			_openNodes.Add(data);
		}
		else
		{
			Debug.LogException(new Exception("Unable to add open node!"));
		}
	}

	protected abstract void Clear();

	protected void ClearNode(PathfindingNodeData node)
	{
		node?.Clear(OpenFlag, ClosedFlag);
	}

	protected void ClearNodes(IEnumerable<PathfindingNodeData> nodes)
	{
		int num = 0;
		foreach (PathfindingNodeData node in nodes)
		{
			ClearNode(node);
			num++;
		}
	}

	protected void LogErrorFormat(string format, params object[] args)
	{
		if (Errors == null)
		{
			Errors = new List<string>();
		}
		Errors.Add(string.Format(format, args));
	}

	public void ThreadPoolWaitCallback(object state)
	{
		try
		{
			Execute();
		}
		catch (Exception exception)
		{
			_exception = exception;
		}
		finally
		{
			_taskCompleted = true;
		}
	}

	public virtual void UnityCompletedCallback()
	{
		IsExecuting = false;
		Completed = true;
		if (_exception != null)
		{
			Debug.LogException(_exception);
		}
		Clear();
	}

	private void SetIndex(int index)
	{
		if (index < 0)
		{
			Index = index;
			OpenFlag = PathfindingFlags.DebugQuery_Open;
			ClosedFlag = PathfindingFlags.DebugQuery_Closed;
			return;
		}
		if (index < 8)
		{
			int num = 1 << index + index;
			int closedFlag = num << 1;
			Index = index;
			OpenFlag = (PathfindingFlags)num;
			ClosedFlag = (PathfindingFlags)closedFlag;
			return;
		}
		throw new NotSupportedException("Currently only 8 concurrent pathfinding queries are supported.");
	}

	public virtual void OnDrawGizmos()
	{
	}

	public void DrawOpenNodes()
	{
		for (int i = 0; i < _openNodes.Count; i++)
		{
			_ = Color.cyan;
			PathfindingNode node = _openNodes.Items[i].Node;
			switch (node.Graph.GraphType)
			{
			case Graph.Type.Constructions:
				node.DrawGizmo(Color.yellow);
				break;
			case Graph.Type.WaterSurface:
				node.DrawGizmo(Color.blue);
				break;
			}
		}
	}

	public void DrawClosedNodes()
	{
		foreach (PathfindingNodeData value in _nodes.Values)
		{
			if (value.IsFlagSet(ClosedFlag))
			{
				value.Node.DrawGizmo(Color.black);
			}
		}
	}

	public void DrawPath()
	{
		if (_openNodes != null && !_openNodes.Items.IsNullOrEmpty())
		{
			PathfindingNodeData pathfindingNodeData = _openNodes.Items[0];
			Gizmos.color = Color.white;
			while (pathfindingNodeData.Parent != null)
			{
				pathfindingNodeData = pathfindingNodeData.Parent;
				Gizmos.DrawSphere(pathfindingNodeData.RootPosition + Vector3.up, 0.1f);
			}
		}
	}

	public virtual void DebugGCost(PathfindingNodeData pathfindingNodeData)
	{
	}

	public void Return()
	{
		_queuedForDebug = false;
		ReturnToPool();
	}

	protected abstract void ReturnToPool();
}
