using System;
using DG.Tweening;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
	public Camera mainCamera;

	[Space(10f)]
	public float zoomStep = 1.5f;

	public float minZoomDistance = 1.5f;

	public float maxZoomDistance = 20f;

	[Space(10f)]
	public float xRotationSpeed = 75f;

	public float yRotationSpeed = 75f;

	public float maxRotationAngle = 90f;

	public float minRotationAngle = -90f;

	public float initialAngleX = 45f;

	public float initialAngleY = 45f;

	[Space(10f)]
	public float xTranslationSpeed = 10f;

	public float yTranslationSpeed = 10f;

	[Space(10f)]
	public bool shouldKeyboardTranslationActiveByRMB;

	public float keyboardTranslationNormalSpeed = 10f;

	public float keyboardTranslationHighSpeed = 20f;

	[Space(10f)]
	public bool shouldMMBFocusOnlySetPosition;

	public Transform target;

	private Vector3 targetPosition;

	private Ray mouseRay;

	private RaycastHit mouseRaycastHit;

	private float xR;

	private float yR;

	private Vector3 firstMousePosition;

	private Vector3 currentMousePosition;

	private float zoomDistance;

	private bool isRotationActive = true;

	private bool isMouseTranslationActive = true;

	private bool isMouseInteractionActive = true;

	private bool isKeyboardTranslationActive = true;

	private bool isKeyboardVerticalTranslationActive = true;

	private bool isZoomActive = true;

	private bool shouldUseKeyboard = true;

	private bool shouldChangeAnglesSmoothly;

	private bool isMouseTranslating;

	private bool isKeyboardTranslating;

	private bool isMovementHandled;

	private bool isMoveImmediately;

	private GameObject focusPointObject;

	private Transform focusPointParent;

	private GameObject cameraFolder;

	private GameObject auxiliaryCameraRig;

	private float lastZoomDistance;

	private bool shouldStartTargetTween;

	private Vector3 destinyPosition;

	private Tween targetTween;

	private KeyCode forwardMoveKey;

	private KeyCode backwardMoveKey;

	private KeyCode leftMoveKey;

	private KeyCode rightMoveKey;

	private KeyCode upMoveKey;

	private KeyCode downMoveKey;

	public bool IsKeyboardTranslationActive => isKeyboardTranslationActive;

	public bool IsKeyboardVerticalTranslationActive => isKeyboardVerticalTranslationActive;

	public bool IsJoystickRotationActive { get; set; }

	public int TargetMaskLayers { get; set; }

	public Vector3 WorldPosition => cameraFolder.transform.position;

	public Vector3 TranslationBoundaries { get; set; }

	public bool IsTranslating
	{
		get
		{
			if (!isMouseTranslating)
			{
				return isKeyboardTranslating;
			}
			return true;
		}
	}

	public bool IsRotating { get; private set; }

	public bool IsZooming { get; private set; }

	public float TargetMovementDuration { get; set; } = 0.5f;

	private void Awake()
	{
		auxiliaryCameraRig = new GameObject("AuxiliaryCameraRig");
		forwardMoveKey = KeyCode.W;
		backwardMoveKey = KeyCode.S;
		leftMoveKey = KeyCode.A;
		rightMoveKey = KeyCode.D;
		upMoveKey = KeyCode.Q;
		downMoveKey = KeyCode.E;
		if (mainCamera == null)
		{
			mainCamera = Camera.main;
		}
	}

	private void Start()
	{
		cameraFolder = base.transform.GetChild(0).gameObject;
		focusPointObject = base.gameObject;
		focusPointObject.transform.position = target.position;
		targetPosition = target.position;
		auxiliaryCameraRig.transform.SetParent(base.transform.parent);
		xR = initialAngleX;
		yR = initialAngleY;
		zoomDistance = 0f - Vector3.Distance(target.position, cameraFolder.transform.position);
		IsRotating = false;
		IsZooming = false;
		isMouseTranslating = false;
		isKeyboardTranslating = false;
		isMovementHandled = false;
		isMoveImmediately = false;
		IsJoystickRotationActive = false;
		shouldStartTargetTween = false;
	}

	private void Update()
	{
		if (mainCamera == null || !isMouseInteractionActive)
		{
			return;
		}
		mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(mouseRay, out mouseRaycastHit, 100f, TargetMaskLayers) && Input.GetKeyUp(KeyCode.Mouse2) && !IsTranslating)
		{
			if (shouldMMBFocusOnlySetPosition)
			{
				SetTargetPosition(mouseRaycastHit.transform.position);
			}
			else
			{
				SetTarget(mouseRaycastHit.transform);
			}
		}
	}

	private void LateUpdate()
	{
		if (target != null)
		{
			auxiliaryCameraRig.transform.position = target.position;
		}
		if (isRotationActive)
		{
			Rotation();
		}
		if (isMouseTranslationActive)
		{
			MouseTranslation();
		}
		if (isKeyboardTranslationActive)
		{
			KeyboardTranslation();
		}
		if (isZoomActive)
		{
			Zoom();
		}
		UpdateTransform();
	}

	private void UpdateTransform()
	{
		Quaternion quaternion = Quaternion.Euler(xR, yR, 0f);
		if (target != null && !target.gameObject.activeInHierarchy)
		{
			target = null;
		}
		if (target != null)
		{
			targetPosition = target.position;
		}
		targetPosition = ClampPosition(targetPosition, TranslationBoundaries);
		if (shouldStartTargetTween)
		{
			if (targetTween != null)
			{
				targetTween.Kill();
			}
			targetTween = focusPointObject.transform.DOMove(targetPosition, TargetMovementDuration);
			targetTween.SetEase(Ease.OutQuad);
			destinyPosition = targetPosition;
			shouldStartTargetTween = false;
		}
		if (targetTween == null || !targetTween.IsActive() || isMoveImmediately)
		{
			if (targetTween != null && targetTween.IsActive())
			{
				targetTween.Kill();
			}
			focusPointObject.transform.position = targetPosition;
			isMoveImmediately = false;
		}
		else if (targetTween.IsActive() && targetTween.IsPlaying())
		{
			targetPosition = focusPointObject.transform.position;
			if (target != null && destinyPosition != target.position && !isMovementHandled)
			{
				targetTween.Kill();
				focusPointObject.transform.SetParent(auxiliaryCameraRig.transform, worldPositionStays: true);
				targetTween = focusPointObject.transform.DOLocalMove(Vector3.zero, 0.5f);
				targetTween.SetEase(Ease.OutQuad);
				TweenCallback action = delegate
				{
					focusPointObject.transform.SetParent(focusPointParent, worldPositionStays: true);
					targetPosition = focusPointObject.transform.position;
					isMovementHandled = false;
					targetTween = null;
				};
				targetTween.OnComplete(action);
				targetTween.OnKill(action);
				isMovementHandled = true;
			}
			if (IsTranslating)
			{
				targetTween.Kill();
			}
		}
		if (shouldChangeAnglesSmoothly)
		{
			if (focusPointObject.transform.rotation != quaternion)
			{
				focusPointObject.transform.DORotateQuaternion(quaternion, 0.5f);
			}
			else
			{
				shouldChangeAnglesSmoothly = false;
			}
		}
		else
		{
			focusPointObject.transform.rotation = quaternion;
		}
		if (lastZoomDistance != zoomDistance)
		{
			cameraFolder.transform.DOLocalMoveZ(zoomDistance, 0.5f);
		}
		lastZoomDistance = zoomDistance;
	}

	private void MouseTranslation()
	{
		if (Input.GetKeyDown(KeyCode.Mouse2))
		{
			firstMousePosition = Input.mousePosition;
		}
		else if (Input.GetKeyUp(KeyCode.Mouse2))
		{
			isMouseTranslating = false;
		}
		if (Input.GetKey(KeyCode.Mouse2))
		{
			float x = (0f - Input.GetAxis("Mouse X")) * xTranslationSpeed * 0.01f;
			float y = (0f - Input.GetAxis("Mouse Y")) * yTranslationSpeed * 0.01f;
			Vector3 vector = focusPointObject.transform.TransformPoint(x, y, 0f) - focusPointObject.transform.position;
			targetPosition = vector + targetPosition;
			target = null;
			currentMousePosition = Input.mousePosition;
			isMouseTranslating = Vector3.Distance(firstMousePosition, currentMousePosition) > 5f;
		}
	}

	private void Rotation()
	{
		float num = Input.GetAxis(AxisCode.RS_r.ToString());
		float num2 = Input.GetAxis(AxisCode.RS_u.ToString());
		if (Input.GetKey(KeyCode.Mouse1) || ((num != 0f || num2 != 0f) && IsJoystickRotationActive))
		{
			if (shouldChangeAnglesSmoothly)
			{
				xR = focusPointObject.transform.rotation.eulerAngles.x;
				yR = focusPointObject.transform.rotation.eulerAngles.y;
				shouldChangeAnglesSmoothly = false;
			}
			if (!IsJoystickRotationActive)
			{
				num = 0f;
				num2 = 0f;
			}
			xR += (0f - Input.GetAxis("Mouse Y") + num2 * 0.5f) * xRotationSpeed * 0.1f;
			yR += (Input.GetAxis("Mouse X") + num * 0.5f) * yRotationSpeed * 0.1f;
			xR = Mathf.Clamp(xR, minRotationAngle, maxRotationAngle);
			yR = Mathf.DeltaAngle(0f, yR);
			IsRotating = true;
		}
		else
		{
			IsRotating = false;
		}
	}

	private void Zoom()
	{
		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			zoomDistance -= zoomStep;
			zoomDistance = 0f - Mathf.Clamp(Mathf.Abs(zoomDistance), minZoomDistance, maxZoomDistance);
			IsZooming = true;
		}
		else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			zoomDistance += zoomStep;
			zoomDistance = 0f - Mathf.Clamp(Mathf.Abs(zoomDistance), minZoomDistance, maxZoomDistance);
			IsZooming = true;
		}
		else
		{
			IsZooming = false;
		}
	}

	private void KeyboardTranslation()
	{
		if (!shouldUseKeyboard)
		{
			isKeyboardTranslating = false;
		}
		else if (shouldKeyboardTranslationActiveByRMB && !Input.GetKey(KeyCode.Mouse1))
		{
			isKeyboardTranslating = false;
		}
		else if (Input.GetKey(forwardMoveKey) || Input.GetKey(backwardMoveKey) || Input.GetKey(rightMoveKey) || Input.GetKey(leftMoveKey) || Input.GetKey(upMoveKey) || Input.GetKey(downMoveKey))
		{
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = Vector3.zero;
			Vector3 vector3 = Vector3.zero;
			Vector3 vector4 = Vector3.zero;
			Vector3 vector5 = Vector3.zero;
			Vector3 vector6 = Vector3.zero;
			float num = (Input.GetKey(KeyCode.LeftShift) ? keyboardTranslationHighSpeed : keyboardTranslationNormalSpeed);
			if (Input.GetKey(forwardMoveKey))
			{
				vector = Vector3.forward * Time.deltaTime * num;
			}
			if (Input.GetKey(backwardMoveKey))
			{
				vector2 = Vector3.back * Time.deltaTime * num;
			}
			if (Input.GetKey(rightMoveKey))
			{
				vector3 = Vector3.right * Time.deltaTime * num;
			}
			if (Input.GetKey(leftMoveKey))
			{
				vector4 = Vector3.left * Time.deltaTime * num;
			}
			if (Input.GetKey(upMoveKey) && isKeyboardVerticalTranslationActive)
			{
				vector5 = Vector3.up * Time.deltaTime * num;
			}
			if (Input.GetKey(downMoveKey) && isKeyboardVerticalTranslationActive)
			{
				vector6 = Vector3.down * Time.deltaTime * num;
			}
			Vector3 vector7 = vector + vector2 + vector3 + vector4 + vector5 + vector6;
			targetPosition += focusPointObject.transform.TransformPoint(vector7.x, vector7.z * Mathf.Sin((float)Math.PI / 180f * focusPointObject.transform.rotation.eulerAngles.x) + vector7.y * Mathf.Cos((float)Math.PI / 180f * focusPointObject.transform.rotation.eulerAngles.x), vector7.z * Mathf.Cos((float)Math.PI / 180f * focusPointObject.transform.rotation.eulerAngles.x) - vector7.y * Mathf.Sin((float)Math.PI / 180f * focusPointObject.transform.rotation.eulerAngles.x)) - focusPointObject.transform.position;
			target = null;
			isKeyboardTranslating = true;
		}
		else
		{
			isKeyboardTranslating = false;
		}
	}

	private Vector3 ClampPosition(Vector3 position, Vector3 boundaries)
	{
		float x = position.x;
		float y = position.y;
		float z = position.z;
		float x2 = boundaries.x;
		float y2 = boundaries.y;
		float z2 = boundaries.z;
		x = ((x2 > 0f) ? Mathf.Clamp(x, 0f - x2, x2) : x);
		y = ((y2 > 0f) ? Mathf.Clamp(y, 0f - y2, y2) : y);
		z = ((z2 > 0f) ? Mathf.Clamp(z, 0f - z2, z2) : z);
		return new Vector3(x, y, z);
	}

	public void SetTarget(Transform newTarget, bool isMoveImmediately = false)
	{
		target = newTarget;
		targetPosition = target.position;
		this.isMoveImmediately = isMoveImmediately;
		shouldStartTargetTween = !isMoveImmediately;
	}

	public void SetTargetPosition(Vector3 newTargetPosition, bool isMoveImmediately = false)
	{
		target = null;
		targetPosition = newTargetPosition;
		this.isMoveImmediately = isMoveImmediately;
		shouldStartTargetTween = !isMoveImmediately;
	}

	public Transform GetTarget()
	{
		return target;
	}

	public Vector3 GetTargetPosition()
	{
		return targetPosition;
	}

	public void SetAngles(float angleX, float angleY, bool isMoveImmediately = false)
	{
		if (!IsTranslating && !IsRotating && !IsZooming)
		{
			xR = angleX;
			yR = angleY;
			shouldChangeAnglesSmoothly = !isMoveImmediately;
		}
	}

	public (float x, float y) GetAngles()
	{
		return (x: xR, y: yR);
	}

	public void SetZoomDistance(float zoom)
	{
		zoomDistance = zoom;
	}

	public float GetZoomDistance()
	{
		return zoomDistance;
	}

	public void SetMovementsActive(bool value)
	{
		SetRotationActive(value);
		SetMouseTranslationActive(value);
		SetMouseInteractionActive(value);
		SetZoomActive(value);
		SetKeyboardTranslationActive(value);
	}

	public void SetRotationActive(bool value)
	{
		isRotationActive = value;
	}

	public void SetMouseTranslationActive(bool value)
	{
		isMouseTranslationActive = value;
	}

	public void SetMouseInteractionActive(bool value)
	{
		isMouseInteractionActive = value;
	}

	public void SetKeyboardTranslationActive(bool value)
	{
		isKeyboardTranslationActive = value;
	}

	public void SetKeyboardVerticalTranslationActive(bool isActive)
	{
		isKeyboardVerticalTranslationActive = isActive;
	}

	public void SetZoomActive(bool value)
	{
		isZoomActive = value;
	}

	public void SetXYRotationSpeed(float rotationSpeed)
	{
		xRotationSpeed = rotationSpeed;
		yRotationSpeed = rotationSpeed;
	}

	public void SetMovementKeys(KeyCode forward, KeyCode backward, KeyCode left, KeyCode right, KeyCode up, KeyCode down)
	{
		forwardMoveKey = forward;
		backwardMoveKey = backward;
		leftMoveKey = left;
		rightMoveKey = right;
		upMoveKey = up;
		downMoveKey = down;
	}

	public void SetKeyboardUsability(bool shouldUseKeyboard)
	{
		this.shouldUseKeyboard = shouldUseKeyboard;
	}
}
