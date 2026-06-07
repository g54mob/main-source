using UnityEngine;

public interface IRoomConnector
{
	bool IsConnecter { get; set; }

	PathNode<Vector3> pathNode { get; set; }

	Transform ObjectTransform { get; }

	bool IsNull { get; }

	bool IsRefreshing { get; }

	bool MovesBetweenFloors { get; }

	bool IsBlocked { get; }

	Vector3 GetOffsetPos(Room room, bool inverse = false);

	bool AllowExit();

	bool AllowEntry();

	void UpdateBlocked();

	Transform[] IntermediatePoints(Room from);
}
