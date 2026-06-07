using UnityEngine;

[AddComponentMenu("BoneCracker Games/Simple Car Controller/SCC Camera")]
public class SCC_Camera : MonoBehaviour
{
	public Transform playerCar;

	public float distance = 6f;

	public float height = 2f;

	public float heightDamping = 1.2f;

	public bool useCameraCollision = true;

	public float closerRadius = 0.2f;

	public float closerSnapLag = 0.2f;

	public float rotationSnapTime = 0.3f;

	private Vector3 wantedPosition = Vector3.zero;

	private float wantedRotationAngle;

	private float wantedHeight;

	private float currentRotationAngle;

	public Vector3 lookAtOffset = Vector3.zero;

	private float currentDistance;

	private float yVelocity;

	private float zVelocity;

	private float targetDistance;

	private void Start()
	{
		currentDistance = distance;
	}

	private void LateUpdate()
	{
		if (!playerCar)
		{
			return;
		}
		wantedHeight = playerCar.position.y + height;
		wantedRotationAngle = playerCar.eulerAngles.y;
		currentRotationAngle = base.transform.eulerAngles.y;
		currentRotationAngle = Mathf.SmoothDampAngle(currentRotationAngle, wantedRotationAngle, ref yVelocity, rotationSnapTime);
		if (useCameraCollision)
		{
			if (Physics.Raycast(playerCar.position, base.transform.TransformDirection(-Vector3.forward), out var hitInfo, distance) && !hitInfo.transform.IsChildOf(playerCar))
			{
				targetDistance = hitInfo.distance - closerRadius;
			}
			else
			{
				targetDistance = distance;
			}
		}
		else
		{
			targetDistance = distance;
		}
		currentDistance = Mathf.SmoothDamp(currentDistance, targetDistance, ref zVelocity, closerSnapLag * 0.3f);
		wantedPosition = playerCar.position;
		wantedPosition.y = wantedHeight;
		wantedPosition += Quaternion.Euler(0f, currentRotationAngle, 0f) * new Vector3(0f, 0f, 0f - currentDistance);
		base.transform.position = wantedPosition;
		base.transform.LookAt(playerCar.position + lookAtOffset);
	}
}
