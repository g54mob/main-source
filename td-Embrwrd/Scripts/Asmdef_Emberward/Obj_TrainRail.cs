using UnityEngine;

[SelectionBase]
public class Obj_TrainRail : MonoBehaviour
{
	[SerializeField]
	private Vector3 startPoint;

	[SerializeField]
	private Vector3 midPoint;

	[SerializeField]
	private Vector3 endPoint;

	public Vector3 StartPoint => default(Vector3);

	public Vector3 MidPoint => default(Vector3);

	public Vector3 EndPoint => default(Vector3);

	public Vector3 GetCartDirection()
	{
		return default(Vector3);
	}
}
