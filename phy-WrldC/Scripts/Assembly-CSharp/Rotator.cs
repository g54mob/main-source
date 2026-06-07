using UnityEngine;

public class Rotator : MonoBehaviour
{
	public Vector3 axis = Vector3.up;

	public float speed;

	private void Update()
	{
		base.transform.Rotate(axis, Time.deltaTime * speed, Space.Self);
	}
}
