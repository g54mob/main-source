using UnityEngine;

public class CameraFollowLag : MonoBehaviour
{
	[Header("References")]
	public Rigidbody playerRigidbody;

	public Transform cameraTransform;

	[Header("Lag Settings")]
	public float positionStrength = 0.05f;

	public float smoothTime = 0.08f;

	public float maxOffset = 0.15f;

	[Header("Bob")]
	public float bobStrength = 0.01f;

	public float bobSpeed = 8f;

	[Header("Rotation Sway")]
	public float rotationStrength = 2f;

	public float rotationSmooth = 10f;

	private Vector3 velocityOffset;

	private Vector3 velocityOffsetVel;

	private Vector3 initialLocalPos;

	private Quaternion initialLocalRot;

	private void Awake()
	{
		initialLocalPos = base.transform.localPosition;
		initialLocalRot = base.transform.localRotation;
	}

	private void LateUpdate()
	{
		if ((bool)playerRigidbody)
		{
			Vector3 vector = cameraTransform.InverseTransformDirection(playerRigidbody.linearVelocity);
			Vector3 vector2 = -vector * positionStrength;
			vector2 = Vector3.ClampMagnitude(vector2, maxOffset);
			if (playerRigidbody.linearVelocity.sqrMagnitude > 0.01f)
			{
				vector2.y += Mathf.Sin(Time.time * bobSpeed) * bobStrength;
			}
			velocityOffset = Vector3.SmoothDamp(velocityOffset, vector2, ref velocityOffsetVel, smoothTime);
			base.transform.localPosition = initialLocalPos + velocityOffset;
			Quaternion quaternion = Quaternion.Euler(vector.z * rotationStrength, (0f - vector.x) * rotationStrength, 0f);
			base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, initialLocalRot * quaternion, Time.deltaTime * rotationSmooth);
		}
	}
}
