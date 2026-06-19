using UnityEngine;

public class RotationPID : MonoBehaviour
{
	public Vector3 testTarget;

	private float maxAcc = 150f;

	private Vector3 targetRotation;

	private float xVal;

	private float yVal;

	private float zVal;

	private SingleAxisPID xPID;

	private SingleAxisPID yPID;

	private SingleAxisPID zPID;

	private Rigidbody selfRigidbody;

	private void Awake()
	{
		selfRigidbody = GetComponent<Rigidbody>();
		maxAcc *= selfRigidbody.mass;
		InitializePID(testTarget);
	}

	public void InitializePID(Vector3 rot)
	{
		targetRotation = rot;
		xPID = new SingleAxisPID(targetRotation.x);
		yPID = new SingleAxisPID(targetRotation.y);
		zPID = new SingleAxisPID(targetRotation.z);
	}

	private void FixedUpdate()
	{
		FixedUpdateTorque(maxAcc, maxAcc, maxAcc);
	}

	public void FixedUpdateTorque(float maxAccelerationX, float maxAccelerationY, float maxAccelerationZ)
	{
		Vector3 localEulerAngles = base.transform.localEulerAngles;
		xVal = xPID.GetTorqueFixedUpdate(localEulerAngles.x, maxAccelerationX);
		yVal = yPID.GetTorqueFixedUpdate(localEulerAngles.y, maxAccelerationY);
		zVal = zPID.GetTorqueFixedUpdate(localEulerAngles.z, maxAccelerationZ);
		selfRigidbody.AddRelativeTorque(new Vector3(xVal, yVal, zVal));
	}
}
