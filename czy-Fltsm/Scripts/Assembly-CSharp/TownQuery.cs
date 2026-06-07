using System;
using System.Collections.Generic;
using PajamaLlama;
using UnityEngine;
using UnityEngine.Events;

public class TownQuery : PathfindingQueryBase
{
	private PathfindingNode _startNode;

	private PathfindingNodeData _startNodeData;

	private PathfindingNode _targetNode;

	private PathfindingNodeData _targetNodeData;

	private Data _data;

	private List<PathfindingNode> _neighbors;

	private static ObjectPool<TownQuery> _instancePool;

	public IPathfindingNodeProvider From { get; private set; }

	public IPathfindingNodeProvider To { get; private set; }

	public List<PathfindingNode> Path { get; private set; }

	public UnityEvent<TownQuery> CompletedEvent { get; private set; }

	private TownQuery()
	{
		CompletedEvent = new UnityEvent<TownQuery>();
	}

	~TownQuery()
	{
		_data?.Return();
	}

	private void Initialize(IPathfindingNodeProvider from, IPathfindingNodeProvider to)
	{
		From = from;
		To = to;
		Path = null;
		base.IsExecuting = true;
	}

	public override bool Execute(int index, bool async = true)
	{
		try
		{
			_startNode = From.ReturnPathfindingNode();
			_targetNode = To.ReturnPathfindingNode();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			_startNode = null;
			_targetNode = null;
		}
		if (_startNode == null || _targetNode == null)
		{
			base.IsExecuting = false;
			base.Completed = true;
			return true;
		}
		if (Data.TryGet(out _data, this))
		{
			_nodes = _data.Nodes;
			_nodes.Clear();
			_openNodes = _data.OpenNodes;
			_openNodes.Clear();
			_neighbors = _data.Neighbors;
			_startNodeData = _startNode.GetData();
			AddOpenNode(_startNodeData);
			return base.Execute(index, async);
		}
		return false;
	}

	protected override void Execute()
	{
		while (ProcessNextNode())
		{
		}
		if (_targetNodeData != null)
		{
			Path = ReturnRetracedPath(_startNodeData, _targetNodeData);
		}
		else
		{
			Debug.LogWarning("TownQuery: No path found!");
		}
	}

	public override bool ProcessNextNode()
	{
		if (_openNodes.Count == 0)
		{
			return false;
		}
		PathfindingNodeData pathfindingNodeData = _openNodes.RemoveFirst();
		pathfindingNodeData.SetClosed(base.OpenFlag, base.ClosedFlag);
		if (pathfindingNodeData.Node == _targetNode)
		{
			_targetNodeData = pathfindingNodeData;
			base.PathFound = true;
			return false;
		}
		_neighbors.Clear();
		pathfindingNodeData.PopulateNeighbors(_neighbors);
		foreach (PathfindingNode neighbor in _neighbors)
		{
			if (neighbor.Graph.GraphType != Graph.Type.Constructions || (neighbor.Flags & base.ClosedFlag) != PathfindingFlags.None || neighbor.IsBlocked)
			{
				continue;
			}
			if (TryReturnNodeData(neighbor, out var nodeData))
			{
				float num = ReturnGCost(nodeData, pathfindingNodeData);
				if (num < nodeData.GCost)
				{
					nodeData.SetGCost(num);
					nodeData.Parent = pathfindingNodeData;
					if (nodeData.IsFlagSet(base.OpenFlag))
					{
						_openNodes.UpdateItem(nodeData);
					}
				}
			}
			else
			{
				nodeData = neighbor.GetData();
				float num = ReturnGCost(nodeData, pathfindingNodeData);
				float hCost = Vector3.Distance(nodeData.RootPosition, _targetNode.RootPosition);
				nodeData.SetFCost(num, hCost);
				nodeData.SetOpen(base.OpenFlag);
				nodeData.Parent = pathfindingNodeData;
				AddOpenNode(nodeData);
			}
		}
		return true;
	}

	public override void UnityCompletedCallback()
	{
		if (_targetNodeData != null)
		{
			Path = ReturnRetracedPath(_startNodeData, _targetNodeData);
			_targetNodeData = null;
		}
		base.UnityCompletedCallback();
		CompletedEvent.Invoke(this);
		CompletedEvent.RemoveAllListeners();
		Return();
	}

	protected override void Clear()
	{
		_targetNodeData = null;
		_openNodes = null;
		if (_nodes != null)
		{
			ClearNodes(_nodes.Values);
			_nodes = null;
		}
		if (_data != null)
		{
			_data.Return();
			_data = null;
		}
	}

	private bool TryReturnNodeData(PathfindingNode node, out PathfindingNodeData nodeData)
	{
		nodeData = null;
		if ((node.Flags & (base.OpenFlag | base.ClosedFlag)) != PathfindingFlags.None)
		{
			return _nodes.TryGetValue(node, out nodeData);
		}
		return false;
	}

	private float ReturnGCost(PathfindingNodeData node, PathfindingNodeData antecede)
	{
		return antecede.GCost + Vector3.Distance(node.RootPosition, antecede.RootPosition);
	}

	private List<PathfindingNode> ReturnRetracedPath(PathfindingNodeData startNode, PathfindingNodeData targetNode)
	{
		List<PathfindingNode> list = new List<PathfindingNode>();
		for (PathfindingNodeData pathfindingNodeData = targetNode; pathfindingNodeData != startNode; pathfindingNodeData = pathfindingNodeData.Parent)
		{
			list.Add(pathfindingNodeData.Node);
		}
		list.Add(startNode.Node);
		list.Reverse();
		return list;
	}

	public static TownQuery Get(IPathfindingNodeProvider from, IPathfindingNodeProvider to)
	{
		if (_instancePool == null)
		{
			_instancePool = new ObjectPool<TownQuery>(CreateInstance);
		}
		TownQuery townQuery = _instancePool.Get();
		townQuery.Initialize(from, to);
		return townQuery;
	}

	protected override void ReturnToPool()
	{
		Clear();
		_instancePool?.Return(this);
	}

	private static TownQuery CreateInstance()
	{
		return new TownQuery();
	}
}
