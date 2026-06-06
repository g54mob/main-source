using UnityEngine;

public class CameraController : MonoBehaviour
{
	public static CameraController instance;

	[SerializeField]
	private Transform newCameraLocation;

	public bool firstPersonMode;

	[SerializeField]
	private GameObject mainCamera;

	[SerializeField]
	private Vector3 velocity = Vector3.zero;

	[SerializeField]
	private float cameraSpeed = 10f;

	[SerializeField]
	private float cameraBaseZoom = 10f;

	[SerializeField]
	private GameObject cameraHolder;

	[SerializeField]
	private Transform audioListenerObject;

	[SerializeField]
	private LayerMask zeroMask;

	private Vector3 clickMoveOrigin;

	private Vector3 cameraOrigin;

	private void Awake()
	{
		instance = this;
		if (PlayerPrefs.GetInt("FirstPersonMode", 0) == 1)
		{
			firstPersonMode = true;
		}
		else
		{
			firstPersonMode = false;
		}
	}

	private void Start()
	{
		if (!firstPersonMode)
		{
			Camera.main.orthographicSize = cameraBaseZoom;
		}
		else
		{
			mainCamera.transform.position = newCameraLocation.position;
			mainCamera.transform.rotation = newCameraLocation.rotation;
			mainCamera.transform.parent = newCameraLocation;
			Camera.main.orthographic = false;
			Camera.main.fieldOfView = 80f;
		}
		if (audioListenerObject != null)
		{
			if (firstPersonMode)
			{
				audioListenerObject.parent = newCameraLocation;
				audioListenerObject.position = newCameraLocation.position;
				audioListenerObject.rotation = newCameraLocation.rotation;
			}
			else
			{
				audioListenerObject.position = new Vector3(audioListenerObject.position.x, cameraBaseZoom, audioListenerObject.position.z);
			}
		}
	}

	private void Update()
	{
		if (!firstPersonMode)
		{
			UpdateMovement();
			UpdateZoom();
		}
	}

	private void UpdateMovement()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			base.transform.position = Vector3.zero;
		}
		if (Input.GetMouseButtonDown(1) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 2000f, zeroMask, QueryTriggerInteraction.Collide))
		{
			clickMoveOrigin = hitInfo.point;
			cameraOrigin = base.transform.position;
		}
		if (Input.GetMouseButton(1))
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo2, 2000f, zeroMask, QueryTriggerInteraction.Collide))
			{
				Vector3 vector = cameraOrigin - 2f * (hitInfo2.point - clickMoveOrigin);
				base.transform.position = (base.transform.position + vector) / 2f;
			}
			return;
		}
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			velocity *= 1f - Time.deltaTime;
			velocity += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")) * Time.deltaTime * 2f;
			float num = Mathf.Clamp(Camera.main.orthographicSize / 10f, 1f, 5f);
			base.transform.Translate(velocity * Time.deltaTime * cameraSpeed * num);
			return;
		}
		velocity = Vector3.zero;
		Vector3 vector2 = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
		if (vector2.sqrMagnitude > 0.1f)
		{
			float num2 = Mathf.Clamp(Camera.main.orthographicSize / 10f, 1f, 5f);
			base.transform.Translate(vector2.normalized * Time.deltaTime * cameraSpeed * num2);
		}
	}

	private void UpdateZoom()
	{
		float num = Mathf.Clamp(Camera.main.orthographicSize - Input.mouseScrollDelta.y, 1f, 50f);
		Camera.main.orthographicSize = num;
		cameraHolder.transform.localPosition = new Vector3(0f, 5f + 2f * num, -2f * num - 5f);
		if (audioListenerObject != null)
		{
			audioListenerObject.position = new Vector3(audioListenerObject.position.x, (num + 10f) / 2f, audioListenerObject.position.z);
		}
	}
}
