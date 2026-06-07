using PajamaLlama;
using UnityEngine;

public class HierarchicalNodeData : PathfindingNodeData
{
	private HierarchicalNode _node;

	private static ObjectPool<HierarchicalNodeData> _instancePool;

	public override PathfindingNode Node => _node;

	public override bool IsGridNode => false;

	public override Vector3 RootPosition => _node.RootPosition;

	public override Vector2 RootPosition2D => _node.RootPosition2D;

	private HierarchicalNodeData()
	{
	}

	private void SetNode(HierarchicalNode node)
	{
		_node = node;
	}

	public override bool CanFitNavigator(INavigator navigator)
	{
		return true;
	}

	public override bool ReturnIgnoreClearane(INavigator navigator)
	{
		return false;
	}

	public override int ReturnClearancePenalty(INavigator navigator)
	{
		return 0;
	}

	public override float ReturnGCost(PathfindingNodeData antecede, INavigator navigator)
	{
		return antecede.GCost + Vector3.Distance(_node.RootPosition, antecede.RootPosition) * navigator.ReturnTerrainPenalty(_node.Graph.TerrainType) + (float)_node.Penalty;
	}

	public override float ReturnHCost(PathfindingNode target, INavigator navigator)
	{
		return Vector3.Distance(_node.RootPosition, target.RootPosition) * navigator.ReturnTerrainPenalty(_node.Graph.TerrainType);
	}

	public static HierarchicalNodeData Get(HierarchicalNode node)
	{
		if (_instancePool == null)
		{
			_instancePool = new ObjectPool<HierarchicalNodeData>(Instantiate);
		}
		HierarchicalNodeData hierarchicalNodeData = _instancePool.Get();
		hierarchicalNodeData.SetNode(node);
		return hierarchicalNodeData;
	}

	private static HierarchicalNodeData Instantiate()
	{
		return new HierarchicalNodeData();
	}

	protected override void Return()
	{
		_instancePool.Return(this);
	}
}
