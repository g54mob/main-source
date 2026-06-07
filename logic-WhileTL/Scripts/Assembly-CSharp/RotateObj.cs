using UnityEngine;

public class RotateObj : MonoBehaviour
{
	public float fullRooundInSec;

	private Vector3 rotate;

	private void Start()
	{
		rotate = Vector3.zero;
		rotate.z = -360f / (fullRooundInSec / Time.unscaledDeltaTime);
	}

	private void Update()
	{
		base.transform.Rotate(rotate);
	}
}
