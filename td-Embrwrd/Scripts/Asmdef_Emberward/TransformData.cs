using UnityEngine;

public class TransformData
{
	private Vector3 position;

	private Quaternion rotation;

	private Vector3 scale;

	public Vector3 Position => default(Vector3);

	public Quaternion Rotation => default(Quaternion);

	public Vector3 Scale => default(Vector3);

	public TransformData(Transform transform)
	{
	}

	public void SaveData(Transform from)
	{
	}
}
