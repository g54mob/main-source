using InControl;
using UnityEngine;

public class ObjectRotationArea : MonoBehaviour
{
	public Camera rotationCameraRef;

	public Transform rotationTransform;

	public Transform secondaryRotationTransform;

	private bool isRotatingObject;

	private bool cursorInRotationArea;

	private Vector3 mousePosStart = Vector3.zero;

	private Quaternion startRot = Quaternion.identity;

	private float camSizeMin = 0.5f;

	private float camSizeMax = 10f;

	private float camSizeUpdate = 0.5f;

	private string portraitZoomSound = "portrait_zoom";

	private bool mouseInputAllowed = true;

	private CursorController cursorRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		if (rotationCameraRef == null)
		{
			Debug.LogError("Rotation area has no camera assigned!");
			return;
		}
		rotationCameraRef.transform.SetParent(null);
		registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).MoveObjectToDogSpawningScene(rotationCameraRef.gameObject);
	}

	private void OnDestroy()
	{
		Object.Destroy(rotationCameraRef.gameObject);
	}

	private void Update()
	{
		if (mouseInputAllowed)
		{
			if (isRotatingObject)
			{
				UpdateObjectRotation();
			}
			else if (cursorInRotationArea)
			{
				CheckZoom();
				cursorRef.SetCursor(CursorController.CursorType.PETTABLE);
			}
		}
	}

	public void SetMouseInputAllowed(bool val)
	{
		mouseInputAllowed = val;
	}

	public void StartObjectRotation()
	{
		isRotatingObject = true;
		mousePosStart = InputManager.MouseProvider.GetPosition();
		startRot = rotationTransform.transform.rotation;
	}

	public void OnCursorEnterRotationArea()
	{
		cursorInRotationArea = true;
	}

	public void OnCursorExitRotationArea()
	{
		cursorInRotationArea = false;
	}

	private void UpdateObjectRotation()
	{
		if (GameControls.actions.Interact.WasReleased || GameControls.actions.CameraRotateMode.WasReleased || GameControls.actions.CameraPanMode.WasReleased)
		{
			isRotatingObject = false;
			return;
		}
		cursorRef.SetCursor(CursorController.CursorType.GRABBING2D);
		Vector3 vector = InputManager.MouseProvider.GetPosition();
		float num = vector.x - mousePosStart.x;
		float num2 = vector.y - mousePosStart.y;
		Vector3 vector2 = new Vector3(0f, 0f - num, 0f - num2) / 2f;
		rotationTransform.transform.rotation = Quaternion.Euler(startRot.eulerAngles + vector2);
		if (secondaryRotationTransform != null)
		{
			secondaryRotationTransform.transform.rotation = rotationTransform.transform.rotation;
		}
	}

	private void CheckZoom()
	{
		float num = 0f;
		GameControls.CheckScrollValuesIfNeeded();
		if (GameControls.actions.ZoomIn.IsPressed)
		{
			num = ((!GameControls.isZoomInScrollWheel || !(Input.mouseScrollDelta != Vector2.zero)) ? ((0f - camSizeUpdate) * 0.25f) : ((0f - camSizeUpdate) * GameControls.currentScrollMultiplier));
		}
		else if (GameControls.actions.ZoomOut.IsPressed)
		{
			num = ((!GameControls.isZoomOutScrollWheel || !(Input.mouseScrollDelta != Vector2.zero)) ? (camSizeUpdate * 0.25f) : (camSizeUpdate * GameControls.currentScrollMultiplier));
		}
		if (num != 0f)
		{
			float num2 = Mathf.Clamp(rotationCameraRef.orthographicSize + num, camSizeMin, camSizeMax);
			if (rotationCameraRef.orthographicSize != num2)
			{
				AudioController.Play(portraitZoomSound);
			}
			rotationCameraRef.orthographicSize = num2;
		}
	}

	public float GetZoom()
	{
		return rotationCameraRef.orthographicSize;
	}

	public void SetZoom(float val)
	{
		rotationCameraRef.orthographicSize = val;
	}
}
