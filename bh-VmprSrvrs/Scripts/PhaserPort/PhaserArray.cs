using System.Collections.Generic;
using UnityEngine;

public class PhaserArray : ArcadeColliderType
{
	public ArcadeColliderType[] _objects;

	public bool isParent => false;

	public BaseBody body => null;

	public bool isTilemap => false;

	public int length => 0;

	public GameObject gameObject => null;

	public ArcadeColliderType this[int i]
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public PhaserArray(ArcadeColliderType singleObject)
	{
	}

	public PhaserArray(List<PhaserGameObject> objects)
	{
	}

	public PhaserArray(HashSet<PhaserGameObject> objects)
	{
	}
}
