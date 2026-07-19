using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Orbit : MonoBehaviour
{
	public GameObject copy;

	public Camera cameraCopyA;

	public Camera cameraCopyB;

	public Camera cameraCopyC;

	public Text perspectiveDisplay;

	private static float zoom = 3f;

	private float cameraSpeed = 0.15f;

	private Transform cameraHolder;

	private Gizmo gizmo;

	private Camera mainCamera;

	private Vector3 speed;

	private Vector3 dragOrigin;

	private Vector3 targetPosition;

	private Vector3 targetRotation;

	private Vector3 initialRotation;

	private Vector3 velocity = Vector3.zero;

	public static Orbit instance { get; private set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		mainCamera = Camera.main;
		initialRotation = base.transform.eulerAngles;
		targetRotation = initialRotation;
		cameraHolder = Global.elements["cameraRig"];
		gizmo = Global.elements["gizmo"].GetComponent<Gizmo>();
		OrbitRotation();
	}

	private void Update()
	{
		if (!Global.control)
		{
			return;
		}
		if (Input.GetMouseButton(1) && !EventSystem.current.IsPointerOverGameObject())
		{
			OrbitRotation();
		}
		if (EventSystem.current.currentSelectedGameObject == null)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * 30f);
			if (!EventSystem.current.IsPointerOverGameObject())
			{
				zoom -= Input.GetAxis("Mouse ScrollWheel") * zoom;
			}
			if (Hotkey.GetKey("Camera/Zoom in"))
			{
				zoom -= 0.1f;
			}
			if (Hotkey.GetKey("Camera/Zoom out"))
			{
				zoom += 0.1f;
			}
			zoom = Mathf.Clamp(zoom, 1f, 100f);
			if (!mainCamera.orthographic)
			{
				mainCamera.transform.localPosition = Vector3.SmoothDamp(mainCamera.transform.localPosition, new Vector3(0f, 0f, (0f - zoom) * 2f), ref velocity, 0.1f);
			}
			else
			{
				mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoom * 0.9f, Time.deltaTime * 10f);
			}
			gizmo.GizmoScaling();
			speed = Vector3.zero;
			if (!Hotkey.GetKey("Modifier/Control"))
			{
				if (Hotkey.GetKey("Camera/Left"))
				{
					speed.x = 0f - cameraSpeed;
				}
				else if (Hotkey.GetKey("Camera/Right"))
				{
					speed.x = cameraSpeed;
				}
				if (Hotkey.GetKey("Camera/Forward"))
				{
					speed.y = cameraSpeed;
				}
				else if (Hotkey.GetKey("Camera/Back"))
				{
					speed.y = 0f - cameraSpeed;
				}
				if (Hotkey.GetKey("Camera/Up"))
				{
					speed.z = cameraSpeed / 2f;
				}
				else if (Hotkey.GetKey("Camera/Down"))
				{
					speed.z = (0f - cameraSpeed) / 2f;
				}
			}
			if (Input.GetMouseButtonDown(2))
			{
				dragOrigin = Input.mousePosition;
			}
			if (Input.GetMouseButton(2))
			{
				speed.x -= (Input.mousePosition.x - dragOrigin.x) / 50f;
				speed.y -= (Input.mousePosition.y - dragOrigin.y) / 50f;
				dragOrigin = Input.mousePosition;
			}
			Quaternion rotation = cameraHolder.rotation;
			cameraHolder.rotation = Quaternion.Euler(0f, rotation.eulerAngles.y, 0f);
			targetPosition += cameraHolder.right * speed.x;
			targetPosition += cameraHolder.forward * speed.y;
			targetPosition += cameraHolder.up * speed.z;
			targetPosition.y = Mathf.Clamp(targetPosition.y, 0f, 10f);
			cameraHolder.position = Vector3.Lerp(cameraHolder.position, targetPosition, Time.deltaTime * 10f);
			cameraHolder.position = cameraHolder.position;
			cameraHolder.rotation = rotation;
			if (copy != null)
			{
				copy.transform.localPosition = mainCamera.transform.localPosition;
			}
			if (Hotkey.GetKey("Camera/Rotate up"))
			{
				targetRotation.x += 1f;
			}
			if (Hotkey.GetKey("Camera/Rotate down"))
			{
				targetRotation.x -= 1f;
			}
			if (Hotkey.GetKey("Camera/Rotate left"))
			{
				targetRotation.y += 1f;
			}
			if (Hotkey.GetKey("Camera/Rotate right"))
			{
				targetRotation.y -= 1f;
			}
			targetRotation.x = Mathf.Clamp(targetRotation.x, -90f, 90f);
		}
		cameraCopyA.orthographic = mainCamera.orthographic;
		cameraCopyA.orthographicSize = mainCamera.orthographicSize;
		cameraCopyB.orthographic = mainCamera.orthographic;
		cameraCopyB.orthographicSize = mainCamera.orthographicSize;
		cameraCopyC.orthographic = mainCamera.orthographic;
		cameraCopyC.orthographicSize = mainCamera.orthographicSize;
		perspectiveDisplay.text = (mainCamera.orthographic ? "Orthographic" : "Perspective");
		if (Hotkey.GetKeyDown("Camera/Perspective"))
		{
			SwitchOrthographic();
		}
	}

	public void SwitchOrthographic(bool _set = true)
	{
		if (_set)
		{
			mainCamera.orthographic = !mainCamera.orthographic;
		}
		if (mainCamera.orthographic)
		{
			mainCamera.transform.localPosition = new Vector3(0f, 0f, -20f);
			mainCamera.orthographicSize = zoom * 0.9f;
		}
		else
		{
			mainCamera.transform.localPosition = new Vector3(0f, 0f, (0f - zoom) * 2f);
		}
	}

	public void SetPosition(Vector3 v)
	{
		targetPosition = v;
	}

	public void SetRotation(Vector3 _rotation)
	{
		targetRotation = _rotation;
	}

	public void OrbitRotation()
	{
		targetRotation.y += Input.GetAxis("Mouse X") * 4f;
		targetRotation.x -= Input.GetAxis("Mouse Y") * 4f;
		targetRotation.x = Mathf.Clamp(targetRotation.x, -90f, 90f);
	}

	public void ResetCamera()
	{
		targetPosition = Vector3.zero;
		cameraHolder.position = targetPosition;
		targetRotation = initialRotation;
		mainCamera.orthographic = false;
		SwitchOrthographic(_set: false);
		zoom = 3f;
	}
}
