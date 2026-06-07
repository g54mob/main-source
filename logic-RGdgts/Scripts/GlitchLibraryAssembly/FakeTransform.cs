using System;
using UnityEngine;

[Serializable]
public struct FakeTransform
{
	public Vector3 position;

	public Quaternion rotation;

	public Vector3 scale;

	public FakeTransform(Vector3 position, Quaternion rotation, Vector3 scale)
	{
		this.position = default(Vector3);
		this.rotation = default(Quaternion);
		this.scale = default(Vector3);
	}

	public FakeTransform(Transform transform, bool local = false)
	{
		position = default(Vector3);
		rotation = default(Quaternion);
		scale = default(Vector3);
	}

	public override string ToString()
	{
		return null;
	}
}
