using UnityEngine;

public class LocalWirePoint
{
	public Transform parent;

	public Vector3 localPoint;

	public Vector3 WorldSpace => default(Vector3);

	public LocalWirePoint(Transform tr, Vector3 point)
	{
	}
}
