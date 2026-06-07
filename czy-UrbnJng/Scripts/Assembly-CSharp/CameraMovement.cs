using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using NewGameplayScripts;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
	[SerializeField]
	private CinemachineVirtualCamera cinemachineVirtualCamera;

	[SerializeField]
	private Camera UICamera;

	[SerializeField]
	private CameraSettingsSO cameraSettings;

	[SerializeField]
	private bool useEdgeScrolling;

	[SerializeField]
	private bool useDragPan;

	[SerializeField]
	private bool useRotateDragPan;

	private float fieldOfViewMax;

	private float fieldOfViewMin;

	private float followOffsetMin;

	private float followOffsetMax;

	private float followOffsetMinY;

	private float followOffsetMaxY;

	private float xMin;

	private float xMax;

	private float zMin;

	private float zMax;

	private float minRotation;

	private float maxRotation;

	private float rotationSpeed;

	private bool dragPanMoveActive;

	private Vector2 lastMousePosition;

	private float targetFieldOfView = 20f;

	private Vector3 followOffset;

	private InputAction zoomAction;

	private PlayerInputActions inputActions;

	private float previousScrollValue;

	private int cameraZoomDelay;

	private void Awake()
	{
		followOffset = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
		fieldOfViewMax = cameraSettings.fieldOfViewMax;
		fieldOfViewMin = cameraSettings.fieldOfViewMin;
		followOffsetMin = cameraSettings.followOffsetMin;
		followOffsetMax = cameraSettings.followOffsetMax;
		followOffsetMinY = cameraSettings.followOffsetMinY;
		followOffsetMaxY = cameraSettings.followOffsetMaxY;
		xMin = cameraSettings.xMin;
		xMax = cameraSettings.xMax;
		zMin = cameraSettings.zMin;
		zMax = cameraSettings.zMax;
		minRotation = cameraSettings.minRotation;
		maxRotation = cameraSettings.maxRotation;
		rotationSpeed = cameraSettings.rotationSpeed;
		inputActions = new PlayerInputActions();
		zoomAction = inputActions.Camera.Zoom;
	}

	private void Start()
	{
		InputManager.Instance.OnCameraMove += InputManager_OnCameraMove;
		InputManager.Instance.OnCameraRotation += InputManager_OnCameraRotation;
		zoomAction.Enable();
	}

	private void OnZoomPerformed(InputAction.CallbackContext context)
	{
		float y = context.ReadValue<Vector2>().normalized.y;
		if (!MovementSystem.Instance.IsMoving() && !InputManager.Instance.gamePause && !IsMouseOverUI())
		{
			HandleCameraZoom_LowerY_FOV(y);
		}
	}

	private void InputManager_OnCameraMove(object sender, InputManager.OnCameraMoveEventArgs e)
	{
		HandleCameraMovement(new Vector3(e.inputVector.x, 0f, e.inputVector.y));
	}

	private void InputManager_OnCameraRotation(object sender, InputManager.OnCameraRotationEventArgs e)
	{
		HandleCameraRotation(-1f * e.rotationVector.x);
	}

	private void Update()
	{
		if (useEdgeScrolling && !MainMenuUI.Instance.IsActive())
		{
			HandleCameraMovementEdgeScrolling();
		}
		if (useDragPan && !MainMenuUI.Instance.IsActive())
		{
			HandleCameraMovementDragPan();
		}
		if (useRotateDragPan && !MovementSystem.Instance.IsMoving())
		{
			HandleCameraRotationDragPan();
		}
		if (!MovementSystem.Instance.IsMoving() && !InputManager.Instance.gamePause && !IsMouseOverSpecialScrollUI())
		{
			HandleCameraZoom_LowerY_FOV(zoomAction.ReadValue<Vector2>().normalized.y);
		}
	}

	private bool IsMouseOverUI()
	{
		PointerEventData eventData = new PointerEventData(EventSystem.current)
		{
			position = Input.mousePosition
		};
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, list);
		return list.Any((RaycastResult result) => result.gameObject.layer == LayerMask.NameToLayer("UI"));
	}

	private bool IsMouseOverSpecialScrollUI()
	{
		PointerEventData eventData = new PointerEventData(EventSystem.current)
		{
			position = Input.mousePosition
		};
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, list);
		return list.Any((RaycastResult result) => result.gameObject.layer == LayerMask.NameToLayer("SpecialMouseScrollUI") || result.gameObject.layer == LayerMask.NameToLayer("UI"));
	}

	private void HandleCameraMovement(Vector3 inputDir)
	{
		if (!IsMouseOverUI())
		{
			Vector3 vector = base.transform.forward * inputDir.z + base.transform.right * inputDir.x;
			float num = 4f;
			base.transform.position += vector * (num * Time.deltaTime);
			base.transform.position = new Vector3(Mathf.Clamp(base.transform.position.x + vector.x * num * Time.deltaTime, xMin, xMax), base.transform.position.y, Mathf.Clamp(base.transform.position.z + vector.z * num * Time.deltaTime, zMin, zMax));
		}
	}

	private void HandleCameraMovementEdgeScrolling()
	{
		Vector3 vector = new Vector3(0f, 0f, 0f);
		int num = 20;
		Vector2 vector2 = InputManager.Instance.GetMousePosition();
		if (vector2.x < (float)num)
		{
			vector.x = -1f;
		}
		if (vector2.y < (float)num)
		{
			vector.z = -1f;
		}
		if (vector2.x > (float)(Screen.width - num))
		{
			vector.x = 1f;
		}
		if (vector2.y > (float)(Screen.height - num))
		{
			vector.z = 1f;
		}
		Vector3 vector3 = base.transform.forward * vector.z + base.transform.right * vector.x;
		float num2 = 4f;
		base.transform.position = new Vector3(Mathf.Clamp(base.transform.position.x + vector3.x * num2 * Time.deltaTime, xMin, xMax), base.transform.position.y, Mathf.Clamp(base.transform.position.z + vector3.z * num2 * Time.deltaTime, zMin, zMax));
	}

	private void HandleCameraMovementDragPan()
	{
		Vector3 vector = new Vector3(0f, 0f, 0f);
		if (Input.GetMouseButtonDown(1))
		{
			dragPanMoveActive = true;
			lastMousePosition = InputManager.Instance.GetMousePosition();
		}
		if (Input.GetMouseButtonUp(1))
		{
			dragPanMoveActive = false;
		}
		if (dragPanMoveActive)
		{
			Vector2 vector2 = (Vector2)Input.mousePosition - lastMousePosition;
			float num = 0.1f;
			vector.x = vector2.x * num;
			vector.z = vector2.y * num;
			lastMousePosition = Input.mousePosition;
		}
		Vector3 vector3 = base.transform.forward * vector.z + base.transform.right * vector.x;
		float num2 = 0.5f;
		base.transform.position += vector3 * num2 * Time.deltaTime;
	}

	private void HandleCameraRotationDragPan()
	{
		float num = 0.025f;
		if (Input.GetMouseButtonDown(1))
		{
			dragPanMoveActive = true;
			lastMousePosition = InputManager.Instance.GetMousePosition();
		}
		if (Input.GetMouseButtonUp(1))
		{
			dragPanMoveActive = false;
		}
		if (dragPanMoveActive)
		{
			Vector2 vector = (Vector2)Input.mousePosition - lastMousePosition;
			if (Vector3.Dot(base.transform.up, Vector3.up) >= 0f)
			{
				base.transform.Rotate(base.transform.up, (0f - Vector3.Dot(vector, Camera.main.transform.right)) * num, Space.World);
				base.transform.eulerAngles = new Vector3(0f, Mathf.Clamp(base.transform.eulerAngles.y, minRotation, maxRotation), 0f);
			}
			lastMousePosition = Input.mousePosition;
		}
	}

	private void HandleCameraRotation(float rotateDir)
	{
		if (!IsMouseOverUI())
		{
			base.transform.eulerAngles += new Vector3(0f, rotateDir * rotationSpeed * Time.deltaTime, 0f);
			base.transform.eulerAngles = new Vector3(0f, Mathf.Clamp(base.transform.eulerAngles.y, minRotation, maxRotation), 0f);
		}
	}

	private void HandleCameraZoom_FieldOfView(float mouseScrollDeltaY)
	{
		float num = 5f;
		targetFieldOfView -= mouseScrollDeltaY * num;
		targetFieldOfView = Mathf.Clamp(targetFieldOfView, fieldOfViewMin, fieldOfViewMax);
		float fieldOfView = cinemachineVirtualCamera.m_Lens.FieldOfView;
		float fieldOfView2 = UICamera.fieldOfView;
		cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fieldOfView, targetFieldOfView, Time.deltaTime * num);
		UICamera.fieldOfView = Mathf.Lerp(fieldOfView2, targetFieldOfView, Time.deltaTime * num);
	}

	private void HandleCameraZoom_MoveForward()
	{
		Vector3 normalized = followOffset.normalized;
		float num = 3f;
		if (Input.mouseScrollDelta.y > 0f)
		{
			followOffset -= normalized * num;
		}
		if (Input.mouseScrollDelta.y < 0f)
		{
			followOffset += normalized * num;
		}
		if (followOffset.magnitude < followOffsetMin)
		{
			followOffset = normalized * followOffsetMin;
		}
		if (followOffset.magnitude > followOffsetMax)
		{
			followOffset = normalized * followOffsetMax;
		}
		float num2 = 5f;
		cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime * num2);
	}

	private void HandleCameraZoom_LowerY()
	{
		float num = 3f;
		if (Input.mouseScrollDelta.y > 0f)
		{
			followOffset.y -= num;
		}
		if (Input.mouseScrollDelta.y < 0f)
		{
			followOffset.y += num;
		}
		followOffset.y = Mathf.Clamp(followOffset.y, followOffsetMinY, followOffsetMaxY);
		float num2 = 10f;
		cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime * num2);
	}

	private void HandleCameraZoom_LowerY_FOV(float mouseScrollDeltaY)
	{
		float num = mouseScrollDeltaY;
		float num2 = 4f;
		float num3 = 4f;
		float num4 = 4f;
		if (previousScrollValue == num && cameraZoomDelay++ < 15)
		{
			num = 0f;
		}
		else
		{
			cameraZoomDelay = 0;
		}
		if (num > 0f)
		{
			followOffset.y -= num2;
		}
		if (num < 0f)
		{
			followOffset.y += num2;
		}
		followOffset.y = Mathf.Clamp(followOffset.y, followOffsetMinY, followOffsetMaxY);
		cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime * num3);
		targetFieldOfView -= num * num4;
		targetFieldOfView = Mathf.Clamp(targetFieldOfView, fieldOfViewMin, fieldOfViewMax);
		float fieldOfView = cinemachineVirtualCamera.m_Lens.FieldOfView;
		float fieldOfView2 = UICamera.fieldOfView;
		cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fieldOfView, targetFieldOfView, Time.deltaTime * num4);
		UICamera.fieldOfView = Mathf.Lerp(fieldOfView2, targetFieldOfView, Time.deltaTime * num4);
		previousScrollValue = mouseScrollDeltaY;
	}

	private void OnDestroy()
	{
		InputManager.Instance.OnCameraMove -= InputManager_OnCameraMove;
		InputManager.Instance.OnCameraRotation -= InputManager_OnCameraRotation;
		zoomAction.Disable();
	}
}
