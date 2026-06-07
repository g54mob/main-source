using UnityEngine;

public interface ITarget : IPathfindingNodeProvider
{
	Graph.Type GraphType { get; }

	Vector3 Position { get; }

	float Range { get; }

	GameObject gameObject { get; }

	string name { get; }

	string tag { get; }

	void AddQueuedPath(NavigatorPathBase queuedPath);

	void RemoveQueuedPath(NavigatorPathBase queuedPath);

	ITarget ReturnTarget();

	Vector3 ReturnPosition();

	T GetComponent<T>();

	T GetComponentInParent<T>();

	bool IsNull();
}
