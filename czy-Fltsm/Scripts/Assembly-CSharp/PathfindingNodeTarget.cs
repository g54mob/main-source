using PajamaLlama.Debugs;
using UnityEngine;

public class PathfindingNodeTarget : ITarget, IPathfindingNodeProvider
{
	private PathfindingNode _pathfindingNode;

	public Graph.Type GraphType { get; private set; }

	public Transform transform => null;

	public Vector3 Position => _pathfindingNode.RootPosition;

	public float Range { get; private set; }

	public bool Temporary => false;

	public GameObject gameObject => null;

	public string name { get; private set; }

	public string tag => "None";

	public PathfindingNodeTarget(PathfindingNode node)
	{
		_pathfindingNode = node;
		GraphType = node.Graph.GraphType;
		Range = 0.5f;
		name = "Pathfinding node target";
	}

	public void AddQueuedPath(NavigatorPathBase queuedPath)
	{
	}

	public void RemoveQueuedPath(NavigatorPathBase queuedPath)
	{
	}

	public ITarget ReturnTarget()
	{
		return this;
	}

	public PathfindingNode ReturnPathfindingNode(Navigator navigator)
	{
		return _pathfindingNode;
	}

	public bool IsInRange(ITarget target)
	{
		if (target == null)
		{
			Debugger.Warning("Target is null.");
			return true;
		}
		return Vector3.Distance(_pathfindingNode.RootPosition, target.Position) < Range + target.Range;
	}

	public Object ReturnOwner()
	{
		return null;
	}

	public Vector3 ReturnPosition()
	{
		return _pathfindingNode.RootPosition;
	}

	public T GetComponent<T>()
	{
		return default(T);
	}

	public T GetComponentInParent<T>()
	{
		return default(T);
	}

	public bool IsNull()
	{
		return this == null;
	}
}
