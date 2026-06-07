using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PathQuery : PathfindingQueryBase
{
	private Data _data;

	public abstract PathfindingNode StartNode { get; }

	public PathfindingNodeData StartNodeData { get; private set; }

	public abstract PathfindingNode TargetNode { get; }

	public PathfindingNodeData TargetNodeData { get; protected set; }

	public List<PathfindingNode> Path { get; protected set; }

	protected List<PathfindingNode> Neighbors { get; private set; }

	public UnityEvent<PathQuery> CompletedEvent { get; private set; } = new UnityEvent<PathQuery>();

	~PathQuery()
	{
		Clear();
	}

	public override bool Execute(int index, bool async = true)
	{
		if (Data.TryGet(out _data, this))
		{
			_nodes = _data.Nodes;
			_nodes.Clear();
			_openNodes = _data.OpenNodes;
			_openNodes.Clear();
			Neighbors = _data.Neighbors;
			StartNodeData = StartNode.GetData();
			AddOpenNode(StartNodeData);
			return base.Execute(index, async);
		}
		return false;
	}

	protected override void Execute()
	{
		while (ProcessNextNode())
		{
		}
	}

	protected override void Clear()
	{
		TargetNodeData = null;
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

	public bool CanExecute()
	{
		return Data.CanGet();
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

	public override void OnDrawGizmos()
	{
		StartNode?.DrawGizmo(Color.green);
		TargetNode?.DrawGizmo(Color.red);
	}
}
