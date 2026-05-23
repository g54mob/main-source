using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Data.Variables;
using Events;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils.Enums;

namespace Presentation.CameraView
{
	public class CameraView : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private Transform _origin;

		[SerializeField]
		private Transform _rotationPivot;

		[Header("ONLY SET THE LOCATOR ON THE MAIN CAMERA! NOT IN OPERATORS!")]
		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[Header("Inputs")]
		[SerializeField]
		private InputActionReference panInputAction;

		[SerializeField]
		private InputActionReference panGrabInputAction;

		[SerializeField]
		private InputActionReference scrollInputAction;

		[SerializeField]
		private InputActionReference rotateInputAction;

		[SerializeField]
		private InputActionReference pointerPositionInputAction;

		[SerializeField]
		private InputActionReference rotateCameraKeysInputAction;

		[SerializeField]
		private InputActionReference sprintInputAction;

		[Header("Zoom Settings")]
		[SerializeField]
		private FloatVariableSO zoomLevelPercentage;

		[SerializeField]
		private IntVariableSO zoomHeightLimitMax;

		[SerializeField]
		private IntVariableSO zoomHeightLimitMin;

		[SerializeField]
		private float zoomSpeed = 3f;

		[SerializeField]
		private AnimationCurve zoomPitchRestraintCurve;

		[Header("Pan Settings")]
		[SerializeField]
		private FloatVariableSO _cameraPanSensitivity;

		[SerializeField]
		private Vector2 keyPanSpeed = new Vector2(0.1f, 0.333f);

		[SerializeField]
		private Vector2 keyPanSpeedSprint = new Vector2(0.1f, 0.333f);

		[Space]
		[SerializeField]
		private Bounds _movementBounds = new Bounds(Vector3.zero, new Vector3(20f, 1000f, 20f));

		[SerializeField]
		private AvailableCamMovementChangedEvent _availableMovementDirectionsChangedEvent;

		[Header("Rotate Settings")]
		[SerializeField]
		private FloatVariableSO _cameraRotSensitivity;

		[SerializeField]
		private FloatVariableSO _cameraKeysRotSensitivity;

		[SerializeField]
		private float rotateSpeed = 10f;

		[SerializeField]
		private float pitchSpeed = 10f;

		[SerializeField]
		private float _minPitch = 25f;

		[SerializeField]
		private float _maxPitch = 70f;

		[SerializeField]
		private float _minYaw = -180f;

		[SerializeField]
		private float _maxYaw = 180f;

		[Header("Camera Lerp Settings")]
		[SerializeField]
		private float lerpSpeed = 0.05f;

		[Header("Audio")]
		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private Transform _listenerTransform;

		[Tooltip("The listener moves vertically up from the origin when zoomed all the way in, to this maxHeight when zoomed all the way out")]
		[SerializeField]
		private float _listenerMaxHeight = 5f;

		[Header("ModuleViewer")]
		[SerializeField]
		private BoolVariableSO _isHoveringOverScrollComponent;

		[SerializeField]
		private BaseEvent _cancelGrabPanEvent;

		private bool _isKeyPanning;

		private bool _isGrabPanning;

		private Vector2 _prevMousePosition;

		private Vector2 _deltaMousePosition;

		private bool _isKeyRotating;

		private bool _isRotating;

		private float _currentZoomLevel;

		private float _currentMaxZoomLevelModifier;

		private bool _isFollowingTarget;

		private bool _shouldOffsetCamera;

		private Transform _followTarget;

		private Vector3 _originLerpTarget;

		private const MovementDirectionFlags ALL_DIRECTIONS = MovementDirectionFlags.Up | MovementDirectionFlags.Down | MovementDirectionFlags.Left | MovementDirectionFlags.Right;

		private MovementDirectionFlags _availableMovementDirections = MovementDirectionFlags.Up | MovementDirectionFlags.Down | MovementDirectionFlags.Left | MovementDirectionFlags.Right;

		private Vector3 _grabbedWorldPosition;

		private Plane _floorPlane;

		private bool _blockInput;

		private bool _isLerpingToTarget;

		private float _currentRotation;

		private Vector3 _startGrapPanPosition;

		private float _lastInputedPitch;

		private TweenerCore<float, float, FloatOptions> _yawLerp;

		private TweenerCore<float, float, FloatOptions> _pitchLerp;

		private float _cameraCurrentFollowPixelOffset;

		private float _cameraTargetFollowPixelOffset;

		private float _lastZoomTime;

		public Vector3 OriginLerpTarget => _originLerpTarget;

		public Vector3 OriginPosition => _origin.transform.position;

		public float OriginYawRotation => _currentRotation;

		public float CameraPitchRotation => _rotationPivot.eulerAngles.x;

		public float CurrentZoomPercentage => (_currentZoomLevel - (float)zoomHeightLimitMax.Value) / ((float)zoomHeightLimitMin.Value + _currentMaxZoomLevelModifier - (float)zoomHeightLimitMax.Value);

		public Vector3 ListenerPosition => _listenerTransform.position;

		public bool IsLerpingToTarget => _isLerpingToTarget;

		private void Awake()
		{
			if (_originLerpTarget == Vector3.zero)
			{
				_originLerpTarget = _origin.transform.position;
			}
			if (_cameraViewLocator != null)
			{
				_cameraViewLocator.SetCameraView(this);
			}
			ResetCurrentRotation();
			_cancelGrabPanEvent.Register(StopGrabPanInput);
		}

		private void OnEnable()
		{
			_currentZoomLevel = ((float)zoomHeightLimitMax.Value + ((float)zoomHeightLimitMin.Value + _currentMaxZoomLevelModifier)) / 2f;
			if (zoomLevelPercentage != null)
			{
				zoomLevelPercentage.SetValue(CurrentZoomPercentage);
			}
			if (scrollInputAction != null)
			{
				scrollInputAction.action.performed += HandleScrollInput;
			}
			if (panInputAction != null)
			{
				panInputAction.action.performed += HandlePanInputStarted;
			}
			if (panInputAction != null)
			{
				panInputAction.action.canceled += HandlePanInputEnded;
			}
			if (panGrabInputAction != null)
			{
				panGrabInputAction.action.performed += HandleGrabPanInputStarted;
			}
			if (panGrabInputAction != null)
			{
				panGrabInputAction.action.canceled += HandleGrabPanInputEnded;
			}
			if (rotateInputAction != null)
			{
				rotateInputAction.action.performed += HandleRotateInputStarted;
			}
			if (rotateInputAction != null)
			{
				rotateInputAction.action.canceled += HandleRotateInputEnded;
			}
			if (rotateCameraKeysInputAction != null)
			{
				rotateCameraKeysInputAction.action.performed += HandleRotateKeysInputStarted;
			}
			if (rotateCameraKeysInputAction != null)
			{
				rotateCameraKeysInputAction.action.canceled += HandleRotateKeysInputEnded;
			}
			_floorPlane = new Plane(Vector3.up, Vector3.zero);
			_rotationPivot.transform.LookAt(_origin, Vector3.up);
		}

		private void ResetCurrentRotation()
		{
			_currentRotation = _origin.transform.eulerAngles.y;
			_lastInputedPitch = _rotationPivot.eulerAngles.x;
		}

		private void OnDisable()
		{
			_isGrabPanning = false;
			_isKeyPanning = false;
			if (scrollInputAction != null)
			{
				scrollInputAction.action.performed -= HandleScrollInput;
			}
			if (panInputAction != null)
			{
				panInputAction.action.performed -= HandlePanInputStarted;
			}
			if (panInputAction != null)
			{
				panInputAction.action.canceled -= HandlePanInputEnded;
			}
			if (panGrabInputAction != null)
			{
				panGrabInputAction.action.performed -= HandleGrabPanInputStarted;
			}
			if (panGrabInputAction != null)
			{
				panGrabInputAction.action.canceled -= HandleGrabPanInputEnded;
			}
			if (rotateInputAction != null)
			{
				rotateInputAction.action.performed -= HandleRotateInputStarted;
			}
			if (rotateInputAction != null)
			{
				rotateInputAction.action.canceled -= HandleRotateInputEnded;
			}
			if (rotateCameraKeysInputAction != null)
			{
				rotateCameraKeysInputAction.action.performed -= HandleRotateKeysInputStarted;
			}
			if (rotateCameraKeysInputAction != null)
			{
				rotateCameraKeysInputAction.action.canceled -= HandleRotateKeysInputEnded;
			}
			_cancelGrabPanEvent.UnRegister(StopGrabPanInput);
		}

		private void Update()
		{
			if (!_blockInput)
			{
				if (_isKeyPanning)
				{
					PanViaKeys();
				}
				if (_isGrabPanning)
				{
					PanViaMouseGrab();
				}
				if (_isRotating)
				{
					Rotate();
				}
				if (_isKeyRotating)
				{
					RotateViaKeys();
				}
				UpdateMouseDelta();
			}
			LerpCameraMovements();
			UpdateListener();
			UpdateCameraSideOffset();
		}

		private void UpdateListener()
		{
			if (!(_listenerTransform == null))
			{
				Vector3 position = _origin.transform.position + Vector3.up * (CurrentZoomPercentage * _listenerMaxHeight);
				_listenerTransform.position = position;
				_audioManagerLocator.AudioManager.SetZoomLevelParameter(position.y / _listenerMaxHeight);
			}
		}

		private void UpdateCameraSideOffset()
		{
			float b = (_shouldOffsetCamera ? _cameraTargetFollowPixelOffset : 0f);
			_cameraCurrentFollowPixelOffset = Mathf.Lerp(_cameraCurrentFollowPixelOffset, b, lerpSpeed * Time.deltaTime);
			if (Mathf.Approximately(_cameraCurrentFollowPixelOffset, 0f))
			{
				_camera.transform.localPosition = Vector3.zero;
				return;
			}
			_camera.transform.localPosition = Vector3.zero;
			Vector3 pos = new Vector3((float)Screen.width * 0.5f - _cameraCurrentFollowPixelOffset, (float)Screen.height * 0.5f, 0f);
			Ray ray = _camera.ScreenPointToRay(pos);
			float num = Vector3.Distance(_camera.transform.position, _origin.position);
			float x = Vector3.Distance(_camera.transform.position + ray.direction * num, _origin.position);
			_camera.transform.localPosition = new Vector3(x, 0f, 0f);
		}

		public void SetCameraFollowOffset(float followPixelOffset)
		{
			_cameraTargetFollowPixelOffset = followPixelOffset;
		}

		private void LateUpdate()
		{
			if (_isFollowingTarget)
			{
				_origin.transform.position = _followTarget.position;
			}
		}

		private void LerpCameraMovements()
		{
			if (!_isLerpingToTarget && !_isFollowingTarget)
			{
				CheckAndClampMovementBounds(ref _originLerpTarget);
			}
			if (_isFollowingTarget)
			{
				_originLerpTarget = _followTarget.position;
			}
			_origin.transform.position = Vector3.Lerp(_origin.transform.position, _originLerpTarget, lerpSpeed * Time.deltaTime);
			_rotationPivot.localPosition = Vector3.Lerp(_rotationPivot.localPosition, _rotationPivot.localPosition.normalized * _currentZoomLevel, lerpSpeed * Time.deltaTime);
			float num = Mathf.Lerp(_maxPitch, _minPitch, zoomPitchRestraintCurve.Evaluate(CurrentZoomPercentage));
			float num2 = Mathf.Clamp01(Time.deltaTime * lerpSpeed);
			if (CameraPitchRotation < num)
			{
				float num3 = Mathf.Clamp(CameraPitchRotation, num, _maxPitch) - CameraPitchRotation;
				_rotationPivot.transform.RotateAround(_origin.transform.position, _rotationPivot.right, num3 * num2);
			}
			else if (CameraPitchRotation > _lastInputedPitch)
			{
				float num4 = Mathf.Clamp(_lastInputedPitch, num, _maxPitch) - CameraPitchRotation;
				_rotationPivot.transform.RotateAround(_origin.transform.position, _rotationPivot.right, num4 * num2);
			}
			if (_blockInput && Vector3.Distance(_origin.transform.position, _originLerpTarget) <= 0.025f)
			{
				_origin.transform.position = _originLerpTarget;
				_blockInput = false;
				_isLerpingToTarget = false;
			}
		}

		private void CheckAndClampMovementBounds(ref Vector3 position)
		{
			MovementDirectionFlags availableMovementDirections = _availableMovementDirections;
			_availableMovementDirections = MovementDirectionFlags.Up | MovementDirectionFlags.Down | MovementDirectionFlags.Left | MovementDirectionFlags.Right;
			if (position.x <= _movementBounds.min.x)
			{
				position.x = _movementBounds.min.x;
				_availableMovementDirections &= ~MovementDirectionFlags.Left;
			}
			else if (position.x >= _movementBounds.max.x)
			{
				position.x = _movementBounds.max.x;
				_availableMovementDirections &= ~MovementDirectionFlags.Right;
			}
			if (position.z <= _movementBounds.min.z)
			{
				position.z = _movementBounds.min.z;
				_availableMovementDirections &= ~MovementDirectionFlags.Down;
			}
			else if (position.z >= _movementBounds.max.z)
			{
				position.z = _movementBounds.max.z;
				_availableMovementDirections &= ~MovementDirectionFlags.Up;
			}
			if (availableMovementDirections != _availableMovementDirections)
			{
				_availableMovementDirectionsChangedEvent.Fire(_availableMovementDirections);
			}
		}

		private void HandleRotateInputStarted(InputAction.CallbackContext obj)
		{
			if (!(_isHoveringOverScrollComponent != null) || !_isHoveringOverScrollComponent.Value)
			{
				TryClearLerp();
				ResetPreviousMousePosition();
				_isRotating = true;
				_audioManagerLocator.AudioManager.PlayCameraRotate(_camera.gameObject);
			}
		}

		private void HandleRotateInputEnded(InputAction.CallbackContext obj)
		{
			_isRotating = false;
			_audioManagerLocator.AudioManager.StopCameraRotate();
		}

		private void HandleGrabPanInputStarted(InputAction.CallbackContext obj)
		{
			if (!(_isHoveringOverScrollComponent != null) || !_isHoveringOverScrollComponent.Value)
			{
				TryClearLerp();
				UpdateGrabbedWorldPosition();
				_startGrapPanPosition = _grabbedWorldPosition;
				_isGrabPanning = true;
				_audioManagerLocator.AudioManager.PlayCameraPan(_camera.gameObject);
				if (_isFollowingTarget)
				{
					_originLerpTarget.y = 0f;
				}
				_isFollowingTarget = false;
				_shouldOffsetCamera = false;
			}
		}

		private void StopGrabPanInput()
		{
			_isGrabPanning = false;
			_audioManagerLocator.AudioManager.StopCameraPan();
		}

		private void HandleGrabPanInputEnded(InputAction.CallbackContext obj)
		{
			StopGrabPanInput();
		}

		private void HandlePanInputEnded(InputAction.CallbackContext obj)
		{
			_isKeyPanning = false;
			_audioManagerLocator.AudioManager.StopCameraPan();
		}

		private void HandlePanInputStarted(InputAction.CallbackContext obj)
		{
			_isKeyPanning = true;
			_audioManagerLocator.AudioManager.PlayCameraPan(_camera.gameObject);
			if (_isFollowingTarget)
			{
				_originLerpTarget.y = 0f;
			}
			_isFollowingTarget = false;
			_shouldOffsetCamera = false;
		}

		private void HandleRotateKeysInputStarted(InputAction.CallbackContext obj)
		{
			TryClearLerp();
			_isKeyRotating = true;
		}

		private void HandleRotateKeysInputEnded(InputAction.CallbackContext obj)
		{
			_isKeyRotating = false;
		}

		private void PanViaMouseGrab()
		{
			UpdateGrabbedWorldPosition();
			_originLerpTarget = _startGrapPanPosition - (_grabbedWorldPosition - _origin.transform.position);
			_originLerpTarget.y = 0f;
		}

		private void PanViaKeys()
		{
			Vector2 delta = panInputAction.action.ReadValue<Vector2>();
			if (delta.sqrMagnitude > 0.01f)
			{
				TryClearLerp();
			}
			float speed = GetZoomAdjustedKeyPanSpeed() * Time.deltaTime;
			_originLerpTarget += GetOffsetRotatedWithCamera(delta, speed);
			_originLerpTarget.y = 0f;
		}

		private float GetZoomAdjustedKeyPanSpeed()
		{
			Vector2 vector = (sprintInputAction.action.IsPressed() ? keyPanSpeedSprint : keyPanSpeed);
			return Mathf.Lerp(vector.x * _cameraPanSensitivity.Value, vector.y * _cameraPanSensitivity.Value, CurrentZoomPercentage);
		}

		private Vector3 GetOffsetRotatedWithCamera(Vector2 delta, float speed)
		{
			return (_rotationPivot.right * delta.x + Vector3.ProjectOnPlane(_rotationPivot.forward, Vector3.up).normalized * delta.y) * speed;
		}

		private void HandleScrollInput(InputAction.CallbackContext obj)
		{
			if (_blockInput || (_isHoveringOverScrollComponent != null && _isHoveringOverScrollComponent.Value))
			{
				return;
			}
			Vector2 vector = scrollInputAction.action.ReadValue<Vector2>();
			if (!(vector == Vector2.zero))
			{
				if (Time.time - _lastZoomTime > 0.25f)
				{
					_audioManagerLocator.AudioManager.PlayCameraZoom();
				}
				_lastZoomTime = Time.time;
				_currentZoomLevel = Mathf.Clamp(_currentZoomLevel - vector.y * zoomSpeed, zoomHeightLimitMax.Value, (float)zoomHeightLimitMin.Value + _currentMaxZoomLevelModifier);
				if (zoomLevelPercentage != null)
				{
					zoomLevelPercentage.SetValue(CurrentZoomPercentage);
				}
			}
		}

		public void SetMaxZoomLevelModifier(int maxZoomLevelModifier)
		{
			_currentMaxZoomLevelModifier = maxZoomLevelModifier;
			_currentZoomLevel = Mathf.Clamp(_currentZoomLevel, zoomHeightLimitMax.Value, (float)zoomHeightLimitMin.Value + _currentMaxZoomLevelModifier);
			zoomLevelPercentage.SetValue(CurrentZoomPercentage);
		}

		private void Rotate()
		{
			YawRotateMouse();
			float min = Mathf.Lerp(_maxPitch, _minPitch, zoomPitchRestraintCurve.Evaluate(CurrentZoomPercentage));
			float num = Mathf.Clamp(CameraPitchRotation + _deltaMousePosition.y * pitchSpeed * Time.deltaTime * _cameraRotSensitivity.Value, min, _maxPitch);
			float num2 = num - CameraPitchRotation;
			_rotationPivot.transform.RotateAround(_origin.transform.position, _rotationPivot.right, num2);
			if (Mathf.Abs(num2) > 0.05f)
			{
				_lastInputedPitch = num;
			}
		}

		private void YawRotateMouse()
		{
			if (!_blockInput && (_yawLerp == null || !_yawLerp.IsActive()))
			{
				_currentRotation -= _deltaMousePosition.x * (rotateSpeed / 100f) * _cameraRotSensitivity.Value;
			}
			if (_currentRotation <= -360f)
			{
				_currentRotation += 360f;
			}
			if (_currentRotation >= 360f)
			{
				_currentRotation -= 360f;
			}
			_currentRotation = Mathf.Clamp(_currentRotation, _minYaw, _maxYaw);
			_origin.transform.eulerAngles = new Vector3(0f, _currentRotation, 0f);
		}

		private void RotateViaKeys()
		{
			Vector2 rotationInput = rotateCameraKeysInputAction.action.ReadValue<Vector2>();
			YawRotateKeys(rotationInput);
			float num = Mathf.Clamp(CameraPitchRotation + rotationInput.y * pitchSpeed * Time.deltaTime * _cameraKeysRotSensitivity.Value * 3f, _minPitch, _maxPitch);
			float num2 = num - CameraPitchRotation;
			_rotationPivot.transform.RotateAround(_origin.transform.position, _rotationPivot.right, num2);
			if (Mathf.Abs(num2) > 0.05f)
			{
				_lastInputedPitch = num;
			}
		}

		private void YawRotateKeys(Vector2 rotationInput)
		{
			_currentRotation += (0f - rotationInput.x) * 3f * (rotateSpeed / 100f) * _cameraKeysRotSensitivity.Value;
			if (_currentRotation <= -360f)
			{
				_currentRotation += 360f;
			}
			if (_currentRotation >= 360f)
			{
				_currentRotation -= 360f;
			}
			_currentRotation = Mathf.Clamp(_currentRotation % 360f, _minYaw, _maxYaw);
			_origin.transform.eulerAngles = new Vector3(0f, _currentRotation, 0f);
		}

		private void ResetPreviousMousePosition()
		{
			_prevMousePosition = pointerPositionInputAction.action.ReadValue<Vector2>();
		}

		private void UpdateMouseDelta()
		{
			Vector2 vector = pointerPositionInputAction.action.ReadValue<Vector2>();
			_deltaMousePosition = _prevMousePosition - vector;
			_prevMousePosition = vector;
		}

		private void UpdateGrabbedWorldPosition()
		{
			Vector2 vector = pointerPositionInputAction.action.ReadValue<Vector2>();
			Vector3 vector2 = _camera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 0.25f));
			Ray ray = new Ray(vector2, vector2 - _camera.transform.position);
			if (_floorPlane.Raycast(ray, out var enter))
			{
				_grabbedWorldPosition = ray.GetPoint(enter);
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawSphere(_grabbedWorldPosition, 0.25f);
		}

		public void LerpToTarget(Vector3 position, bool blockInput)
		{
			_isFollowingTarget = false;
			_shouldOffsetCamera = false;
			_blockInput = blockInput;
			_isLerpingToTarget = true;
			_originLerpTarget = position;
		}

		public void LerpToTargetPosition(Vector3 position, float zoomPercentage, bool blockInput)
		{
			_currentZoomLevel = Mathf.Lerp(zoomHeightLimitMax.Value, (float)zoomHeightLimitMin.Value + _currentMaxZoomLevelModifier, zoomPercentage);
			LerpToTarget(position, blockInput);
		}

		public void LerpToTarget(Vector3 position, float zoomPercentage, float targetYaw, float targetPitch, bool blockInput)
		{
			LerpYaw(targetYaw);
			LerpPitch(targetPitch);
			LerpToTargetPosition(position, zoomPercentage, blockInput);
		}

		public void SetFollowTarget(Transform transform)
		{
			_followTarget = transform;
			_isFollowingTarget = true;
			_shouldOffsetCamera = true;
			_blockInput = false;
			_isLerpingToTarget = true;
			_originLerpTarget = _followTarget.position;
		}

		public void SetIsFollowingTarget()
		{
			_shouldOffsetCamera = true;
		}

		private void TryClearLerp()
		{
			if (!_blockInput && _isLerpingToTarget)
			{
				_isLerpingToTarget = false;
				_originLerpTarget = _origin.transform.position;
				_yawLerp.Kill();
				_pitchLerp.Kill();
			}
		}

		private void LerpYaw(float rotationAngleX)
		{
			float num = rotationAngleX - _currentRotation;
			if (Mathf.Abs(num) > 180f)
			{
				_currentRotation += ((num > 0f) ? 360f : (-360f));
			}
			float duration = 0.7f;
			_yawLerp = DOTween.To(() => _currentRotation, delegate(float x)
			{
				_currentRotation = x;
			}, rotationAngleX, duration).OnUpdate(YawRotateMouse).SetEase(Ease.OutCubic);
		}

		private void LerpPitch(float targetPitch)
		{
			float currentPitch = _rotationPivot.eulerAngles.x;
			float duration = 0.7f;
			_pitchLerp = DOTween.To(() => currentPitch, delegate(float x)
			{
				currentPitch = x;
			}, targetPitch, duration).OnUpdate(delegate
			{
				_rotationPivot.transform.RotateAround(_origin.transform.position, _rotationPivot.right, currentPitch - _rotationPivot.eulerAngles.x);
			}).SetEase(Ease.OutCubic);
		}

		public void ToggleCameraEnabled(bool enabled)
		{
			_camera.enabled = enabled;
		}

		public void SetMovementBounds(Bounds bounds)
		{
			if (bounds.extents.sqrMagnitude == 0f)
			{
				_movementBounds = new Bounds(Vector3.zero, Vector3.positiveInfinity);
			}
			else
			{
				_movementBounds = bounds;
			}
		}
	}
}
