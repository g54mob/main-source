using UnityEngine;

public class SpringArmCamera : PlayerCamera
{
	private GameObject lookTarget;

	private CapsuleCollider lookTargetCapsule;

	[SerializeField]
	private float height = 1.9f;

	[SerializeField]
	private float zoom = 4.5f;

	[SerializeField]
	private LayerMask collisionLayers = 0;

	[SerializeField]
	private float minBumperDistance = 0.15f;

	private float bumperDistance;

	[Header("Rotations")]
	[SerializeField]
	private float pitch = 10f;

	[SerializeField]
	private float minPitch = -50f;

	[SerializeField]
	private float maxPitch = 50f;

	private float yaw;

	private bool bUpdateInputRotations;

	[Header("Smooths")]
	[SerializeField]
	[Range(0f, 1f)]
	private float movementSmooth = 0.92f;

	[SerializeField]
	[Range(0f, 1f)]
	private float rotationSmooth = 0.7f;

	[SerializeField]
	[Range(0f, 1f)]
	private float autoRotationSmooth = 0.94f;

	[SerializeField]
	[Range(0f, 1f)]
	private float zoomSmooth = 0.75f;

	private Vector3 velocity = Vector3.zero;

	private void FixedUpdate()
	{
		FollowTarget();
	}

	protected override void InitCamera()
	{
		base.InitCamera();
		base.OwnCamera.transform.localPosition = new Vector3(0f, 0f, 0f - zoom);
		bumperDistance = zoom;
	}

	public void SetTarget(GameObject target, bool teleportToTarget = false)
	{
		base.target = target;
		if ((bool)base.target && teleportToTarget)
		{
			base.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + height, target.transform.position.z);
		}
	}

	public void SetLookTarget(GameObject lookTarget)
	{
		this.lookTarget = lookTarget;
		if ((bool)this.lookTarget)
		{
			lookTargetCapsule = lookTarget.GetComponent<CapsuleCollider>();
		}
	}

	public void AddCameraPitch(float pitch)
	{
		this.pitch += pitch;
		if (this.pitch < minPitch)
		{
			this.pitch = minPitch;
		}
		else if (this.pitch > maxPitch)
		{
			this.pitch = maxPitch;
		}
		pitch %= 360f;
		bUpdateInputRotations = true;
	}

	public void AddCameraYaw(float yaw)
	{
		this.yaw += yaw;
		yaw %= 360f;
		bUpdateInputRotations = true;
	}

	public void CenterYaw()
	{
		yaw = target.transform.rotation.eulerAngles.y;
		bUpdateInputRotations = true;
	}

	private void FollowTarget()
	{
		if ((bool)target)
		{
			UpdatePosition();
			UpdateRotation();
			UpdateZoom();
		}
	}

	private void UpdatePosition()
	{
		base.transform.position = Vector3.SmoothDamp(base.transform.position, new Vector3(target.transform.position.x, target.transform.position.y + height, target.transform.position.z), ref velocity, 1f - movementSmooth);
	}

	private void UpdateRotation()
	{
		if ((bool)lookTarget)
		{
			Vector3 forward = lookTarget.transform.position + Vector3.up * (lookTargetCapsule.height / 2f) - base.transform.position;
			Quaternion quaternion = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(forward, Vector3.up), 1f - rotationSmooth);
			base.transform.rotation = Quaternion.Euler(quaternion.eulerAngles.x, quaternion.eulerAngles.y, 0f);
			yaw = base.transform.rotation.eulerAngles.y % 360f;
			pitch = base.transform.rotation.eulerAngles.x;
			if (pitch > maxPitch)
			{
				pitch -= 360f;
			}
		}
		else if (bUpdateInputRotations && !Mathf.Approximately(Quaternion.Angle(base.transform.rotation, Quaternion.Euler(pitch, yaw, base.transform.rotation.eulerAngles.z)), 0f))
		{
			Quaternion quaternion2 = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(pitch, yaw, 0f), rotationSmooth);
			base.transform.rotation = Quaternion.Euler(quaternion2.eulerAngles.x, quaternion2.eulerAngles.y, 0f);
		}
		else
		{
			bUpdateInputRotations = false;
			Quaternion b = Quaternion.Euler(pitch, Quaternion.LookRotation(target.transform.position + Vector3.up * height - ownCamera.transform.position, Vector3.up).eulerAngles.y, 0f);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 1f - autoRotationSmooth);
			yaw = base.transform.rotation.eulerAngles.y % 360f;
		}
	}

	private void UpdateZoom()
	{
		Vector3 vector = target.transform.position + Vector3.up * height;
		if (Physics.Raycast(vector, base.OwnCamera.transform.position - vector, out var hitInfo, zoom, collisionLayers))
		{
			bumperDistance = Mathf.Clamp(hitInfo.distance, minBumperDistance, zoom);
		}
		else
		{
			bumperDistance = zoom;
		}
		base.OwnCamera.transform.localPosition = Vector3.Lerp(base.OwnCamera.transform.localPosition, new Vector3(base.OwnCamera.transform.localPosition.x, base.OwnCamera.transform.localPosition.y, 0f - bumperDistance), 1f - zoomSmooth);
	}
}
