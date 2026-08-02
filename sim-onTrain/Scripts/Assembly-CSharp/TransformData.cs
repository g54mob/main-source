using System;
using UnityEngine;

[Serializable]
public class TransformData
{
	public Vector3 position;

	public Quaternion rotation;

	public int wagonIndex;

	public TransformData(Vector3 pos, Quaternion rot, int wagonIdx)
	{
		position = pos;
		rotation = rot;
		wagonIndex = wagonIdx;
	}

	public void ApplyToTransform(Transform transform)
	{
		transform.position = position;
		transform.rotation = rotation;
	}
}
