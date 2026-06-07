using System;
using UnityEngine;

[Serializable]
public class TreeInstance : IHasVector
{
	public SVector3 Position;

	public SVector3 Rotation;

	public int Idx;

	public float LeaveOffset;

	[NonSerialized]
	public TreeBatch BelongsTo;

	public StaticTree TreeMesh
	{
		get
		{
			if (!GameSettings.Instance.IsReferenceNull())
			{
				return GameSettings.Instance.CachedTrees[Idx % GameSettings.Instance.CachedTrees.Length];
			}
			return null;
		}
	}

	public Bounds Bounds
	{
		get
		{
			Bounds bounds = TreeMesh.bounds;
			return new Bounds(bounds.center + Position, bounds.size);
		}
	}

	public Matrix4x4 Transform
	{
		get
		{
			return Matrix4x4.TRS(Position, Rotation, Vector3.one);
		}
	}

	public TreeInstance()
	{
	}

	public TreeInstance(Vector3 pos, Quaternion rot, int idx)
	{
		Position = pos;
		Rotation = rot;
		Idx = idx;
		LeaveOffset = UnityEngine.Random.value;
	}

	public Vector2 GetPos()
	{
		return Position.ToVector2Z();
	}
}
