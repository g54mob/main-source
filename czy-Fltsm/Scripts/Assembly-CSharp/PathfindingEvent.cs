using System.Collections.Generic;

public class PathfindingEvent : GameEvent
{
	private static PathfindingEvent _instance = new PathfindingEvent();

	private HashSet<PathfindingNode> _updatedPathfindinNodes = new HashSet<PathfindingNode>();

	public PathfindingNode PathfindingNode { get; private set; }

	private PathfindingEvent()
		: base(GameEventType.PathfindingNodeUpdated)
	{
	}

	public static void TryDispatch()
	{
		if (!_instance._updatedPathfindinNodes.IsNullOrEmpty())
		{
			_instance.Dispatch();
			_instance._updatedPathfindinNodes.Clear();
		}
	}

	public static void AddUpdatedPathfindingNode(PathfindingNode pathfindingNode)
	{
		_instance._updatedPathfindinNodes.Add(pathfindingNode);
	}

	public bool HasNodeUpdatedOnPath(IEnumerable<PathfindingNode> path)
	{
		if (path == null)
		{
			return false;
		}
		foreach (PathfindingNode item in path)
		{
			if (_updatedPathfindinNodes.Contains(item))
			{
				return true;
			}
		}
		return false;
	}
}
