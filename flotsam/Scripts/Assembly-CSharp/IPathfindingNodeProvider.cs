using UnityEngine;

public interface IPathfindingNodeProvider
{
	Transform transform { get; }

	PathfindingNode ReturnPathfindingNode(Navigator navigator = null);
}
