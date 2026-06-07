using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform carTransform;

	[Range(1f, 10f)]
	public float followSpeed = 2f;

	[Range(1f, 10f)]
	public float lookSpeed = 5f;

	private Vector3 initialCameraPosition;

	private Vector3 initialCarPosition;

	private Vector3 absoluteInitCameraPosition;

	private void Start()
	{
		initialCameraPosition = base.gameObject.transform.position;
		initialCarPosition = carTransform.position;
		absoluteInitCameraPosition = initialCameraPosition - initialCarPosition;
	}

	private void FixedUpdate()
	{
		Quaternion b = Quaternion.LookRotation(new Vector3(carTransform.position.x, carTransform.position.y, carTransform.position.z) - base.transform.position, Vector3.up);
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, lookSpeed * Time.deltaTime);
		Vector3 b2 = absoluteInitCameraPosition + carTransform.transform.position;
		base.transform.position = Vector3.Lerp(base.transform.position, b2, followSpeed * Time.deltaTime);
	}
}
