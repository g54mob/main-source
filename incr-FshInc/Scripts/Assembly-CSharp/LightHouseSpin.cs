using UnityEngine;

public class LightHouseSpin : MonoBehaviour
{
	[Header("Rotation Settings")]
	[Tooltip("Speed of the lighthouse rotation in degrees per second.")]
	public float rotationSpeed = 90f;

	private void Update()
	{
		float zAngle = rotationSpeed * Time.deltaTime;
		base.transform.Rotate(0f, 0f, zAngle);
	}
}
