using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform carTransform;

	[Range(1f, 10f)]
	public float followSpeed;

	[Range(1f, 10f)]
	public float lookSpeed;

	private Vector3 initialCameraPosition;

	private Vector3 initialCarPosition;

	private Vector3 absoluteInitCameraPosition;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}
}
