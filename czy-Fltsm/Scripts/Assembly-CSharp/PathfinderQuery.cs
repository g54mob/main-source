using System;
using System.Collections.Generic;
using PajamaLlama;
using PajamaLlama.Math;
using UnityEngine;

public class PathfinderQuery : PathQuery
{
	private static ObjectPool<PathfinderQuery> _instancePool = new ObjectPool<PathfinderQuery>(CreateInstance);

	private PathfindingNode _startNode;

	private PathfindingNode _targetNode;

	private List<PathfindingNode> _endNodes;

	private PathfindingNodeData _closestNodeData;

	private int _closestNodeItterations;

	private int _closestNodeItterationMax;

	private bool _ignoreClearance;

	public PathfinderPath PathfinderPath { get; private set; }

	public Navigator Navigator => PathfinderPath.Navigator;

	public ITarget Target => PathfinderPath.Target;

	public override PathfindingNode StartNode => _startNode;

	public override PathfindingNode TargetNode => _targetNode;

	public static PathfinderQuery Get()
	{
		return _instancePool.Get();
	}

	private static PathfinderQuery CreateInstance()
	{
		return new PathfinderQuery();
	}

	protected override void ReturnToPool()
	{
		Clear();
		_instancePool?.Return(this);
	}

	public void Initialize(PathfinderPath pathfinderPath)
	{
		PathfinderPath = pathfinderPath;
	}

	public override bool Execute(int index, bool async = true)
	{
		if (index < 0)
		{
			Clear();
		}
		else
		{
			_startNode = PathfinderPath.Navigator.ReturnPathfindingNode(null);
			_targetNode = Target.ReturnPathfindingNode(Navigator);
			if (_startNode == null || _targetNode == null)
			{
				if (_startNode == null)
				{
					Debug.LogException(new NotSupportedException($"[Pathfinder] No valid starting node found for {Navigator}."), Navigator);
				}
				if (_targetNode == null)
				{
					Debug.LogError(new NotSupportedException($"[Pathfinder] No valid target node found for {Target}."), Target.gameObject);
				}
				base.IsExecuting = false;
				base.Completed = true;
				return true;
			}
			if (CanNavigateByLineOfSight(Navigator, Target, _startNode, _targetNode))
			{
				PathfinderPath.SetState(NavigatorPathState.Processed);
				base.Completed = true;
				return true;
			}
		}
		if (!TryReturnEndNodes(Navigator, Target, _targetNode, out _endNodes))
		{
			LogWarning($"No target nodes found for target '{Target.name}' that fit navigator '{Navigator.name}, this needs to be fixed!. Generating partial path as fallback.");
		}
		if (base.Execute(index, async))
		{
			PathfinderPath.SetState(NavigatorPathState.Processing);
			_closestNodeData = base.StartNodeData;
			_closestNodeItterations = 0;
			_closestNodeItterationMax = Mathf.CeilToInt(Mathf.Pow(GameManager.Settings.GameplaySettings.ConstructionRadius * 2, 2f));
			return true;
		}
		return false;
	}

	public override bool ProcessNextNode()
	{
		if (_openNodes.Count == 0 || _closestNodeItterationMax <= _closestNodeItterations)
		{
			return false;
		}
		PathfindingNodeData pathfindingNodeData = _openNodes.RemoveFirst();
		pathfindingNodeData.SetClosed(base.OpenFlag, base.ClosedFlag);
		if (_endNodes.Contains(pathfindingNodeData.Node))
		{
			base.TargetNodeData = pathfindingNodeData;
			base.PathFound = true;
			return false;
		}
		base.Neighbors.Clear();
		pathfindingNodeData.PopulateNeighbors(base.Neighbors);
		int count = base.Neighbors.Count;
		_ignoreClearance = _ignoreClearance && pathfindingNodeData.ReturnIgnoreClearane(Navigator);
		for (int i = 0; i < count; i++)
		{
			ReturnAddNeighborToOpenNodes(pathfindingNodeData, base.Neighbors[i], _openNodes, Navigator, base.StartNodeData.Node, TargetNode, _ignoreClearance);
		}
		if (pathfindingNodeData.HCost < _closestNodeData.HCost || _closestNodeData == base.StartNodeData)
		{
			_closestNodeData = pathfindingNodeData;
			_closestNodeItterations = 0;
		}
		else
		{
			_closestNodeItterations++;
		}
		return true;
	}

	public override void UnityCompletedCallback()
	{
		if (base.TargetNodeData == null)
		{
			Debug.LogException(new Exception($"<color=red><b>Incomplete path found...</b></color>\nNavigator: {Navigator} -> Target: {Target}\r\n" + $"Closed node count: {_nodes.Count}\r\n" + $"Open node count: {_openNodes.Count}"));
			if (PathfinderPath.Navigator.AllowIncompletePath)
			{
				PathfinderPath.SetNodes(ReturnRetracedPath(base.StartNodeData, _closestNodeData), incompletePath: true);
			}
			else
			{
				PathfinderPath.NoPathFound = true;
			}
		}
		else
		{
			List<PathfindingNode> list = ReturnRetracedPath(base.StartNodeData, base.TargetNodeData);
			if (list.IsNullOrEmpty())
			{
				Debug.LogException(new Exception($"<color=red><b>Looping path found...</b></color>\nNavigator: {Navigator} -> Target: {Target}"));
				PathfinderPath.NoPathFound = true;
			}
			else
			{
				PathfinderPath.SetNodes(list);
			}
		}
		PathfinderPath.SetState(NavigatorPathState.Processed);
		if (!Pathfinder.AddQueryToDebug(this))
		{
			base.UnityCompletedCallback();
			Return();
		}
	}

	protected override void Clear()
	{
		_endNodes?.Dispose();
		base.Clear();
	}

	private bool TryReturnEndNodes(Navigator navigator, ITarget target, PathfindingNode targetNode, out List<PathfindingNode> endNodes)
	{
		if (targetNode == null)
		{
			LogError($"Target node is null for target '{target.name}' and navigator '{navigator.name}'.");
			endNodes = null;
			return false;
		}
		if (navigator == null)
		{
			LogError("Navigator is null.");
			endNodes = null;
			return false;
		}
		endNodes = ListPool<PathfindingNode>.Get();
		if (targetNode.CanFitNavigator(navigator))
		{
			endNodes.Add(targetNode);
		}
		if (targetNode.IsGridNode)
		{
			Grid obj = (targetNode.Graph as Grid) ?? throw new NotSupportedException("Grid == null! Could it be the GraphManager has not yet been initialized");
			Vector2 vector = target.ReturnPosition().Vector2TopDown();
			PathfindingNode[] array = obj.ReturnNeighborhood(vector.x, vector.y, Mathf.CeilToInt(target.Range));
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				PathfindingNode pathfindingNode = array[i];
				if (pathfindingNode != null && pathfindingNode != targetNode && array[i].CanFitNavigator(navigator))
				{
					endNodes.Add(pathfindingNode);
				}
			}
		}
		if (0 < endNodes.Count)
		{
			if (!endNodes.Contains(targetNode))
			{
				LogWarning($"Target node for target '{target.name}' does not fit navigator '{navigator.name}', this should be fixed! However a node in the targets range does fit the navigator.");
			}
			return true;
		}
		return false;
	}

	public bool ReturnAddNeighborToOpenNodes(PathfindingNodeData currentNode, PathfindingNode neighbor, Heap<PathfindingNodeData> openNodes, Navigator navigator, PathfindingNode startNode, PathfindingNode targetNode, bool ignoreClearance, bool displayDebugs = false)
	{
		if (!neighbor.IsBlocked && neighbor.Graph.TypesMatch(navigator.TargetGraphType) && (ignoreClearance || neighbor.CanFitNavigator(navigator)))
		{
			PathfindingNodeData pathfindingNodeData = GetPathfindingNodeData(neighbor);
			float num = pathfindingNodeData.ReturnGCost(currentNode, navigator);
			if (num < pathfindingNodeData.GCost)
			{
				pathfindingNodeData.Parent = currentNode;
				pathfindingNodeData.SetGCost(num);
				if (pathfindingNodeData.IsFlagSet(base.OpenFlag))
				{
					openNodes.UpdateItem(pathfindingNodeData);
				}
			}
			if (pathfindingNodeData.IsFlagSet(base.OpenFlag | base.ClosedFlag))
			{
				return false;
			}
			pathfindingNodeData.Parent = currentNode;
			pathfindingNodeData.SetFCost(num, pathfindingNodeData.ReturnHCost(targetNode, navigator));
			AddOpenNode(pathfindingNodeData);
			pathfindingNodeData.SetOpen(base.OpenFlag);
			return true;
		}
		return false;
	}

	private List<PathfindingNode> ReturnRetracedPath(PathfindingNodeData startNode, PathfindingNodeData targetNode)
	{
		List<PathfindingNode> list = new List<PathfindingNode>();
		PathfindingNodeData pathfindingNodeData = targetNode;
		while (pathfindingNodeData != startNode)
		{
			if (list.AddUnique(pathfindingNodeData.Node))
			{
				pathfindingNodeData = pathfindingNodeData.Parent;
				continue;
			}
			return null;
		}
		list.Add(startNode.Node);
		list.Reverse();
		return list;
	}

	private bool CanNavigateByLineOfSight(Navigator navigator, ITarget target, PathfindingNode startNode, PathfindingNode targetNode)
	{
		if (startNode is GridNode && startNode.Graph == targetNode.Graph && navigator.IsOnGraph(startNode.Graph))
		{
			return HasLineOfSightAt(navigator, startNode.RootPosition, targetNode.RootPosition, target, 2.1474836E+09f);
		}
		return false;
	}

	private bool HasLineOfSightAt(Navigator navigator, Vector3 originPosition, Vector3 targetPosition, ITarget target, float range)
	{
		if (Vector3.Distance(originPosition, targetPosition) > range)
		{
			return false;
		}
		Vector3 direction = targetPosition - originPosition;
		for (int i = 0; i < Obstacle.AllObstacles.Count; i++)
		{
			Obstacle obstacle = Obstacle.AllObstacles[i];
			if (obstacle != target && (target == null || Graph.TypesMatch(target.GraphType, obstacle.ObstacleGraphType)) && obstacle.ReturnIsLineIntersecting(originPosition, direction, navigator.Width))
			{
				Debug.Log($"{navigator} its line of sight was blocked by obstacle {obstacle.name}.");
				return false;
			}
		}
		return true;
	}

	private PathfindingNodeData GetPathfindingNodeData(PathfindingNode pathfindingNode)
	{
		if ((pathfindingNode.Flags & (base.OpenFlag | base.ClosedFlag)) != PathfindingFlags.None && _nodes.TryGetValue(pathfindingNode, out var value))
		{
			return value;
		}
		return pathfindingNode.GetData();
	}

	public override void DebugGCost(PathfindingNodeData pathfindingNodeData)
	{
		pathfindingNodeData.ReturnGCost(pathfindingNodeData.Parent, Navigator);
	}

	public void LogWarning(string message)
	{
	}

	public void LogError(string message)
	{
	}
}
