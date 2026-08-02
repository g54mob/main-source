using UnityEngine;

public class FpsCameraStabilizer : MonoBehaviour
{
	public Transform target;

	public bool followX = true;

	public bool followY = true;

	public bool followZ = true;

	private void Update()
	{
		if (!(target == null))
		{
			Vector3 position = base.transform.position;
			float x = (followX ? target.position.x : position.x);
			float y = (followY ? target.position.y : position.y);
			float z = (followZ ? target.position.z : position.z);
			base.transform.position = new Vector3(x, y, z);
		}
	}
}
