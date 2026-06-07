using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject target;

	public Vector3 offset;

	public void LateUpdate()
	{
		Vector3 vector = target.transform.position + offset;
		base.transform.position = new Vector3(base.transform.position.x, vector.y, base.transform.position.z);
	}
}
