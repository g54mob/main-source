using System.Collections.Generic;
using PajamaLlama;
using UnityEngine;

public class MooringPointBlockedQuery : PathfindingQueryBase, INavigator
{
	private Data _data;

	private List<PathfindingNode> _neighbors;

	private static ObjectPool<MooringPointBlockedQuery> _instancePool;

	private static ObjectPool<Data> _dataPool;

	private float _constructionRadiusSquared;

	public MooringPoint MooringPoint { get; private set; }

	public bool IsBlocked { get; private set; }

	public byte RequiredClearance { get; private set; }

	public byte PreferredClearance { get; private set; }

	public int TransitionCost { get; private set; }

	private MooringPointBlockedQuery()
	{
	}

	~MooringPointBlockedQuery()
	{
		if (_dataPool != null)
		{
			_dataPool.Return(_data);
		}
	}

	private void Initialize(MooringPoint mooringPoint, byte minimumRequiredClearance = 3)
	{
		MooringPoint = mooringPoint;
		base.IsExecuting = true;
		IsBlocked = true;
		if ((bool)mooringPoint.LinkedBoat)
		{
			RequiredClearance = mooringPoint.LinkedBoat.Navigator.RequiredClearance;
			PreferredClearance = mooringPoint.LinkedBoat.Navigator.PreferredClearance;
			TransitionCost = mooringPoint.LinkedBoat.Navigator.TransitionCost;
		}
		else
		{
			byte requiredClearance = (PreferredClearance = minimumRequiredClearance);
			RequiredClearance = requiredClearance;
			TransitionCost = 1000;
		}
		_constructionRadiusSquared = Mathf.Pow(GameManager.Settings.GameplaySettings.ConstructionRadius, 2f);
	}

	public override bool Execute(int index, bool async = true)
	{
		PathfindingNode pathfindingNode = (((bool)MooringPoint && (bool)MooringPoint.MooringTarget) ? MooringPoint.MooringTarget.ReturnNode(Graph.Type.WaterSurface) : null);
		if (pathfindingNode == null)
		{
			base.IsExecuting = false;
			base.Completed = true;
			return true;
		}
		if (_dataPool == null)
		{
			_dataPool = new ObjectPool<Data>(CreateDataInstance, 4);
		}
		if (_dataPool.TryGet(out _data))
		{
			_nodes = _data.Nodes;
			_nodes.Clear();
			_openNodes = _data.OpenNodes;
			_openNodes.Clear();
			AddOpenNode(pathfindingNode.GetData());
			_neighbors = _data.Neighbors;
			return base.Execute(index, async);
		}
		return false;
	}

	protected override void Execute()
	{
		if (_openNodes.Count == 0)
		{
			LogErrorFormat("Blocked mooring point because it is out of bounds!");
			return;
		}
		while (ProcessNextNode())
		{
		}
		base.PathFound = !IsBlocked;
	}

	public override bool ProcessNextNode()
	{
		if (_openNodes.Count == 0)
		{
			return false;
		}
		PathfindingNodeData pathfindingNodeData = _openNodes.RemoveFirst();
		pathfindingNodeData.SetClosed(base.OpenFlag, base.ClosedFlag);
		if (pathfindingNodeData.Node.CanFitNavigator(this) && _constructionRadiusSquared < pathfindingNodeData.RootPosition.sqrMagnitude)
		{
			IsBlocked = false;
			return false;
		}
		_neighbors.Clear();
		pathfindingNodeData.PopulateNeighbors(_neighbors);
		foreach (PathfindingNode neighbor in _neighbors)
		{
			if (neighbor.Graph.GraphType != Graph.Type.WaterSurface || (neighbor.Flags & base.ClosedFlag) == base.ClosedFlag || neighbor.IsBlocked || !neighbor.CanFitNavigator(this))
			{
				continue;
			}
			if (TryReturnOpenNodeData(neighbor, out var openNode))
			{
				float num = openNode.ReturnGCost(pathfindingNodeData, this);
				if (num < openNode.GCost)
				{
					openNode.SetGCost(num);
					openNode.Parent = pathfindingNodeData;
					_openNodes.UpdateItem(openNode);
				}
			}
			else
			{
				openNode = neighbor.GetData();
				float num = openNode.ReturnGCost(pathfindingNodeData, this);
				float hCost = _constructionRadiusSquared - openNode.RootPosition.sqrMagnitude;
				openNode.SetFCost(num, hCost);
				openNode.SetOpen(base.OpenFlag);
				openNode.Parent = pathfindingNodeData;
				AddOpenNode(openNode);
			}
		}
		return true;
	}

	protected override void Clear()
	{
		_openNodes = null;
		if (_nodes != null)
		{
			ClearNodes(_nodes.Values);
			_nodes = null;
		}
		if (_data != null)
		{
			_dataPool.Return(_data);
			_data = null;
		}
	}

	public float ReturnTerrainPenalty(Navigator.TerrainType terrain)
	{
		if (terrain == Navigator.TerrainType.WaterSurface)
		{
			return 1f;
		}
		return 10000f;
	}

	private bool TryReturnOpenNodeData(PathfindingNode node, out PathfindingNodeData openNode)
	{
		openNode = null;
		if ((node.Flags & base.OpenFlag) != base.OpenFlag)
		{
			return false;
		}
		int count = _openNodes.Count;
		for (int i = 0; i < count; i++)
		{
			openNode = _openNodes.Items[i];
			if (openNode.Node == node)
			{
				return true;
			}
		}
		return false;
	}

	public override void OnDrawGizmos()
	{
		base.OnDrawGizmos();
	}

	public static MooringPointBlockedQuery Get(MooringPoint mooringPoint, byte minimumRequiredClearance = 3)
	{
		if (_instancePool == null)
		{
			_instancePool = new ObjectPool<MooringPointBlockedQuery>(CreateInstance);
		}
		MooringPointBlockedQuery mooringPointBlockedQuery = _instancePool.Get();
		mooringPointBlockedQuery.Initialize(mooringPoint, minimumRequiredClearance);
		return mooringPointBlockedQuery;
	}

	protected override void ReturnToPool()
	{
		Clear();
		_instancePool?.Return(this);
	}

	private static MooringPointBlockedQuery CreateInstance()
	{
		return new MooringPointBlockedQuery();
	}

	private static Data CreateDataInstance()
	{
		int num = (int)Mathf.Pow(GameManager.Settings.GameplaySettings.ConstructionRadius, 2f);
		return new Data
		{
			Nodes = new Dictionary<PathfindingNode, PathfindingNodeData>(num),
			OpenNodes = new Heap<PathfindingNodeData>(num),
			Neighbors = new List<PathfindingNode>(128)
		};
	}
}
