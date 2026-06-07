using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Group : EventEmitter, ArcadeColliderType
{
	private HashSet<PhaserGameObject> children;

	private readonly HashSet<PhaserGameObject> childrenToRemove;

	private readonly HashSet<PhaserGameObject> childrenToAdd;

	public PhysicsType _physicsType;

	private static readonly ProfilerMarker MarkerRemove;

	public int length => 0;

	public bool isParent => false;

	public BaseBody body => null;

	public bool isTilemap => false;

	public GameObject gameObject => null;

	public Group(int capacity)
	{
	}

	public Group add(PhaserGameObject child)
	{
		return null;
	}

	public void remove(PhaserGameObject child)
	{
	}

	public bool isFull()
	{
		return false;
	}

	public int countActive(bool value = true)
	{
		return 0;
	}

	public bool contains(PhaserGameObject child)
	{
		return false;
	}

	public HashSet<PhaserGameObject> getChildren()
	{
		return null;
	}

	protected void clear()
	{
	}

	public void UpdateHashSetElements()
	{
	}
}
