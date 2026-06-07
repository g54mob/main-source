using System;
using PajamaLlama;
using PajamaLlama.Math;
using UnityEngine;

public class GridNodeData : PathfindingNodeData
{
	private const int G_COST_STRAIGHT_COST = 10;

	private const int G_COST_DIAGONAL_COST = 14;

	private const int H_COST_STRAIGHT_COST = 10;

	private const int H_COST_DIAGONAL_COST = 14;

	private const int CLEARANCE_PENALTY = 30;

	private GridNode _node;

	private Vector3 _rootPosition;

	private Vector2 _rootPosition2D;

	private int _referenceCount;

	private static ObjectPool<GridNodeData> _instancePool;

	public override PathfindingNode Node => _node;

	public override Vector3 RootPosition => _rootPosition;

	public override Vector2 RootPosition2D => _rootPosition2D;

	public override bool IsGridNode => true;

	private GridNodeData()
	{
	}

	private void SetNode(GridNode node)
	{
		_node = node;
		_rootPosition = _node.RootPosition;
		_rootPosition2D = _node.RootPosition2D;
	}

	public override void Clear(PathfindingFlags openFlag, PathfindingFlags closedFlag)
	{
		base.Clear(openFlag, closedFlag);
		_node = null;
	}

	public override bool CanFitNavigator(INavigator navigator)
	{
		return navigator.RequiredClearance <= _node.Clearance;
	}

	public override bool ReturnIgnoreClearane(INavigator navigator)
	{
		return _node.Clearance < navigator.RequiredClearance;
	}

	public override int ReturnClearancePenalty(INavigator navigator)
	{
		byte clearance = _node.Clearance;
		byte requiredClearance = navigator.RequiredClearance;
		if (clearance < requiredClearance)
		{
			return (requiredClearance - clearance) * 100 * 30;
		}
		return 0;
	}

	public override float ReturnGCost(PathfindingNodeData antecede, INavigator navigator)
	{
		int num2;
		float num;
		if (antecede.IsGridNode)
		{
			Vector2 rootPosition2D = antecede.RootPosition2D;
			num = ((rootPosition2D.x != _rootPosition2D.x && rootPosition2D.y != _rootPosition2D.y) ? 14f : 10f);
			num2 = 0;
		}
		else
		{
			num = (int)antecede.RootPosition.DistanceToSquared(new Vector3(_rootPosition2D.x, 0f, _rootPosition2D.y));
			num2 = navigator.TransitionCost;
		}
		num += (float)_node.Penalty;
		num += (float)ReturnClearancePenalty(navigator);
		num *= navigator.ReturnTerrainPenalty(_node.Graph.TerrainType);
		num += (float)num2;
		return antecede.GCost + num;
	}

	public override float ReturnHCost(PathfindingNode target, INavigator navigator)
	{
		float num = navigator.ReturnTerrainPenalty(_node.Graph.TerrainType);
		float num2 = System.Math.Abs(_rootPosition2D.x - target.RootPosition2D.x);
		float num3 = System.Math.Abs(_rootPosition2D.y - target.RootPosition2D.y);
		if (num2 < num3)
		{
			return (int)((num3 - num2) * num * 10f + num2 * num * 14f);
		}
		return (int)((num2 - num3) * num * 10f + num3 * num * 14f);
	}

	public static GridNodeData Get(GridNode node)
	{
		if (_instancePool == null)
		{
			_instancePool = new ObjectPool<GridNodeData>(Instantiate);
		}
		GridNodeData gridNodeData = _instancePool.Get();
		gridNodeData.SetNode(node);
		gridNodeData._referenceCount++;
		return gridNodeData;
	}

	private static GridNodeData Instantiate()
	{
		return new GridNodeData();
	}

	protected override void Return()
	{
		if (_referenceCount > 0)
		{
			_instancePool.Return(this);
			_referenceCount = 0;
		}
		else
		{
			Debug.LogException(new Exception("Return() was invoked on GridNodeData which is already pooled"));
		}
	}
}
