using FreeCamTool;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[Header("Camera Control")]
	[SerializeField]
	private float defaultCameraZoom = 7f;

	[SerializeField]
	private float speedMultiplier = 30f;

	[SerializeField]
	private float rotationSpeed = 3f;

	[SerializeField]
	private Vector2 pitchClamp = new Vector2(-80f, 80f);

	[SerializeField]
	private bool clampYaw;

	[SerializeField]
	private Vector2 yawClamp = new Vector2(0f, 0f);

	[SerializeField]
	private Camera camera;

	[SerializeField]
	private global::FreeCamTool.FreeCamTool freeCamTool;

	[SerializeField]
	public Transform pivot;

	private float Yawn;

	private float Pitch;

	private bool activated;

	public Camera GetCamera()
	{
		return camera;
	}

	public void SetCameraSensitivity(float sensitivity)
	{
		rotationSpeed = sensitivity / speedMultiplier;
	}

	public Vector3 GetForwardDirection()
	{
		return new Vector3(0f - Mathf.Sin(base.transform.eulerAngles.y), 0f, 0f - Mathf.Cos(base.transform.eulerAngles.y));
	}

	public float GetDefaultCameraZoom()
	{
		return defaultCameraZoom;
	}

	private void Start()
	{
		Yawn = pivot.transform.eulerAngles.y;
		Pitch = camera.transform.localEulerAngles.x;
		activated = true;
		if (freeCamTool != null)
		{
			Object.Destroy(freeCamTool.gameObject);
		}
		if (GetComponent<Camera>() != null)
		{
			Object.Destroy(GetComponent<CinemachineBrain>());
		}
	}

	public void Turn(Vector2 direction)
	{
		if (activated)
		{
			RotateCamera(direction);
		}
	}

	private void RotateCamera(Vector2 inputDirection)
	{
		Yawn += inputDirection.x * rotationSpeed;
		Pitch -= inputDirection.y * rotationSpeed;
		if (Pitch < pitchClamp.x)
		{
			Pitch = pitchClamp.x;
		}
		if (Pitch > pitchClamp.y)
		{
			Pitch = pitchClamp.y;
		}
		if (clampYaw)
		{
			if (Yawn < yawClamp.x)
			{
				Yawn = yawClamp.x;
			}
			if (Yawn > yawClamp.y)
			{
				Yawn = yawClamp.y;
			}
		}
		Vector3 eulerAngles = new Vector3(pivot.eulerAngles.x, Yawn, pivot.eulerAngles.z);
		pivot.eulerAngles = eulerAngles;
		camera.transform.localRotation = Quaternion.Euler(Pitch, 0f, 0f);
	}

	public void SetZoom(float zoom)
	{
		camera.orthographicSize = zoom;
	}

	public void Activate()
	{
		camera.enabled = true;
		activated = true;
	}

	public void Deactivate()
	{
		camera.enabled = false;
		activated = false;
	}
}
