using System;
using UnityEngine;

[Serializable]
public class TransformData
{
	[Tooltip("Position of the object.")]
	public Vector3 Position = Vector3.zero;

	[Tooltip("Rotation of the object in euler angles.")]
	public Vector3 Rotation = Vector3.zero;

	[Tooltip("Scale of the object.")]
	public Vector3 Scale = Vector3.one;

	public TransformData(Vector3 position, Vector3 rotation, Vector3 scale)
	{
		Position = position;
		Rotation = rotation;
		Scale = scale;
	}

	public TransformData(Transform transform)
	{
		Position = transform.position;
		Rotation = transform.rotation.eulerAngles;
		Scale = transform.localScale;
	}

	public void Apply(Transform transform)
	{
		transform.localPosition = Position;
		transform.localRotation = Quaternion.Euler(Rotation);
		transform.localScale = Scale;
	}
}
