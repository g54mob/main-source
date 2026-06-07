using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class RTFocusCamera : MonoSingleton<RTFocusCamera>
	{
		private enum MoveDirection
		{
			Left = 0,
			Right = 1,
			Up = 2,
			Down = 3,
			Forward = 4,
			Backwards = 5
		}

		[SerializeField]
		private Camera _targetCamera;

		private Transform _targetTransform;

		[SerializeField]
		private float _fieldOfView;

		private WorldTransformSnapshot _worldTransformSnapshot = new WorldTransformSnapshot();

		private CameraPrjSwitchTransition _prjSwitchTranstion = new CameraPrjSwitchTransition();

		private bool _isDoingFocus;

		private IEnumerator _focusCrtn;

		private bool _isDoingRotationSwitch;

		private IEnumerator _genricCamTransformCrtn;

		private bool _isObjectVisibilityDirty = true;

		private List<GameObject> _visibleObjects = new List<GameObject>();

		private float _focusPointOffset = 5f;

		private Vector3 _lastFocusPoint;

		private bool[] _moveDirFlags = new bool[Enum.GetValues(typeof(MoveDirection)).Length];

		private float _currentAcceleration;

		[SerializeField]
		private CameraSettings _settings = new CameraSettings();

		[SerializeField]
		private CameraMoveSettings _moveSettings = new CameraMoveSettings();

		[SerializeField]
		private CameraPanSettings _panSettings = new CameraPanSettings();

		[SerializeField]
		private CameraLookAroundSettings _lookAroundSettings = new CameraLookAroundSettings();

		[SerializeField]
		private CameraOrbitSettings _orbitSettings = new CameraOrbitSettings();

		[SerializeField]
		private CameraZoomSettings _zoomSettings = new CameraZoomSettings();

		[SerializeField]
		private CameraFocusSettings _focusSettings = new CameraFocusSettings();

		[SerializeField]
		private CameraRotationSwitchSettings _rotationSwitchSettings = new CameraRotationSwitchSettings();

		[SerializeField]
		private CameraProjectionSwitchSettings _projectionSwitchSettings = new CameraProjectionSwitchSettings();

		[SerializeField]
		private CameraHotkeys _hotkeys = new CameraHotkeys();

		public Camera TargetCamera => _targetCamera;

		public bool IsDoingProjectionSwitch => _prjSwitchTranstion.IsActive;

		public CameraPrjSwitchTransition.Type PrjSwitchTransitionType => _prjSwitchTranstion.TransitionType;

		public bool IsDoingRotationSwitch => _isDoingRotationSwitch;

		public float PrjSwitchProgress => _prjSwitchTranstion.Progress;

		public float PrjSwitchDurationInSeconds => _projectionSwitchSettings.TransitionDurationInSeconds;

		public bool IsDoingFocus => _isDoingFocus;

		public Vector3 WorldPosition
		{
			get
			{
				return _targetTransform.position;
			}
			set
			{
				Vector3 focusPoint = GetFocusPoint();
				_targetTransform.position = value;
				SetFocusPoint(focusPoint);
			}
		}

		public Quaternion WorldRotation
		{
			get
			{
				return _targetTransform.rotation;
			}
			set
			{
				_targetTransform.rotation = value;
			}
		}

		public Vector3 Right => _targetTransform.right;

		public Vector3 Up => _targetTransform.up;

		public Vector3 Look => _targetTransform.forward;

		public bool IsMovingForward => _moveDirFlags[4];

		public bool IsMovingBackwards => _moveDirFlags[5];

		public bool IsMovingLeft => _moveDirFlags[0];

		public bool IsMovingRight => _moveDirFlags[1];

		public bool IsMovingUp => _moveDirFlags[2];

		public bool IsMovingDown => _moveDirFlags[3];

		public CameraSettings Settings => _settings;

		public CameraMoveSettings MoveSettings => _moveSettings;

		public CameraPanSettings PanSettings => _panSettings;

		public CameraLookAroundSettings LookAroundSettings => _lookAroundSettings;

		public CameraOrbitSettings OrbitSettings => _orbitSettings;

		public CameraZoomSettings ZoomSettings => _zoomSettings;

		public CameraFocusSettings FocusSettings => _focusSettings;

		public CameraRotationSwitchSettings RotationSwitchSettings => _rotationSwitchSettings;

		public CameraProjectionSwitchSettings ProjectionSwitchSettings => _projectionSwitchSettings;

		public CameraHotkeys Hotkeys => _hotkeys;

		public event CameraProjectionSwitchBeginHandler PrjSwitchTransitionBegin;

		public event CameraProjectionSwitchUpdateHandler PrjSwitchTransitionUpdate;

		public event CameraProjectionSwitchBeginHandler PrjSwitchTransitionEnd;

		public event CameraCanProcessInputHandler CanProcessInput;

		public event CameraCanUseScrollWheelHandler CanUseScrollWheel;

		public bool IsViewportHoveredByDevice()
		{
			Vector2 vector = MonoSingleton<RTInputDevice>.Get.Device.GetPositionYAxisUp();
			Vector3 vector2 = TargetCamera.ScreenToViewportPoint(vector);
			if (vector2.x >= 0f && vector2.x <= 1f && vector2.y >= 0f)
			{
				return vector2.y <= 1f;
			}
			return false;
		}

		public void SetTargetCamera(Camera camera)
		{
			if (!(camera == null) && Application.isPlaying && !IsDoingFocus && !IsDoingProjectionSwitch && !IsDoingRotationSwitch)
			{
				_targetCamera = camera;
				_targetTransform = camera.transform;
				_fieldOfView = camera.fieldOfView;
				SetFocusPoint(GetFocusPoint());
				AdjustOrthoSizeForFocusPt();
				_isObjectVisibilityDirty = true;
			}
		}

		public void SetFieldOfView(float fov)
		{
			_targetCamera.fieldOfView = fov;
			_fieldOfView = fov;
		}

		public void SetObjectVisibilityDirty()
		{
			_isObjectVisibilityDirty = true;
		}

		public List<GameObject> GetVisibleObjects()
		{
			if (_isObjectVisibilityDirty)
			{
				_visibleObjects = TargetCamera.GetVisibleObjects(new CameraViewVolume(TargetCamera));
				_isObjectVisibilityDirty = false;
			}
			return new List<GameObject>(_visibleObjects);
		}

		public void PerformRotationSwitch(Quaternion targetRotation)
		{
			if (!IsDoingProjectionSwitch)
			{
				StopCamTransform();
				StopFocus();
				if (RotationSwitchSettings.SwitchMode == CameraRotationSwitchMode.Constant)
				{
					StartCoroutine(_genricCamTransformCrtn = DoConstantRotationSwitch(targetRotation));
				}
				else if (RotationSwitchSettings.SwitchMode == CameraRotationSwitchMode.Smooth)
				{
					StartCoroutine(_genricCamTransformCrtn = DoSmoothRotationSwitch(targetRotation));
				}
				else
				{
					_targetTransform.rotation = targetRotation;
				}
			}
		}

		public void PerformProjectionSwitch()
		{
			StopCamTransform();
			StopFocus();
			if (ProjectionSwitchSettings.SwitchMode == CameraProjectionSwitchMode.Transition)
			{
				_prjSwitchTranstion.TargetCamera = _targetCamera;
				_prjSwitchTranstion.CamFieldOfView = _fieldOfView;
				_prjSwitchTranstion.CamFocusPoint = GetFocusPoint();
				_prjSwitchTranstion.DurationInSeconds = ProjectionSwitchSettings.TransitionDurationInSeconds;
				_prjSwitchTranstion.Begin();
			}
			else
			{
				PerformInstantProjectionSwitch();
			}
		}

		public void Focus(AABB focusAABB)
		{
			if (!_isDoingFocus && !IsDoingProjectionSwitch && !IsDoingRotationSwitch && focusAABB.IsValid)
			{
				StopCamTransform();
				CameraFocus.Data focusData = CameraFocus.CalculateFocusData(TargetCamera, focusAABB, FocusSettings);
				if (FocusSettings.FocusMode == CameraFocusMode.Instant)
				{
					PerformInstantFocus(focusData);
				}
				else if (FocusSettings.FocusMode == CameraFocusMode.Constant)
				{
					StartCoroutine(_focusCrtn = DoConstantFocus(focusData));
				}
				else if (FocusSettings.FocusMode == CameraFocusMode.Smooth)
				{
					StartCoroutine(_focusCrtn = DoSmoothFocus(focusData));
				}
			}
		}

		public void Update_SystemCall()
		{
			if (CanCameraProcessInput() && MonoSingleton<RTInputDevice>.Get.DeviceType == InputDeviceType.Mouse)
			{
				HandleMouseAndKeyboardInput();
			}
			if (!_worldTransformSnapshot.SameAs(_targetTransform))
			{
				SetObjectVisibilityDirty();
				_worldTransformSnapshot.Snaphot(_targetTransform);
			}
		}

		private void Awake()
		{
			if (TargetCamera == null)
			{
				Debug.Break();
				Debug.LogError("RTCamera: No target camera was specified.");
			}
			SetTargetCamera(TargetCamera);
			_worldTransformSnapshot.Snaphot(_targetTransform);
			_prjSwitchTranstion.TargetMono = this;
			_prjSwitchTranstion.TransitionBegin += OnPrjSwitchTransitionBegin;
			_prjSwitchTranstion.TransitionUpdate += OnPrjSwitchTransitionUpate;
			_prjSwitchTranstion.TransitionEnd += OnPrjSwitchTransitionEnd;
		}

		private void Start()
		{
			_lastFocusPoint = Vector3.zero;
			SetFocusPoint(_lastFocusPoint);
			AdjustOrthoSizeForFocusPt();
		}

		private void HandleMouseAndKeyboardInput()
		{
			float num = ((Hotkeys.AlternateMoveSpeed.IsActive() ? _moveSettings.AlternateMoveSpeed : _moveSettings.MoveSpeed) + _currentAcceleration) * Time.deltaTime;
			Vector3 zero = Vector3.zero;
			_moveDirFlags[4] = Hotkeys.MoveForward.IsActive();
			_moveDirFlags[5] = !_moveDirFlags[4] && Hotkeys.MoveBack.IsActive();
			_moveDirFlags[0] = Hotkeys.StrafeLeft.IsActive();
			_moveDirFlags[1] = !_moveDirFlags[0] && Hotkeys.StrafeRight.IsActive();
			_moveDirFlags[2] = Hotkeys.MoveUp.IsActive();
			_moveDirFlags[3] = !_moveDirFlags[2] && Hotkeys.MoveDown.IsActive();
			bool flag = false;
			if (IsMovingForward)
			{
				Zoom(num);
				flag = true;
			}
			else if (IsMovingBackwards)
			{
				Zoom(0f - num);
				flag = true;
			}
			if (IsMovingLeft)
			{
				zero -= _targetTransform.right * num;
			}
			else if (IsMovingRight)
			{
				zero += _targetTransform.right * num;
			}
			if (IsMovingUp)
			{
				zero += _targetTransform.up * num;
			}
			else if (IsMovingDown)
			{
				zero -= _targetTransform.up * num;
			}
			bool num2 = zero.sqrMagnitude != 0f;
			if (num2)
			{
				_targetTransform.position += zero;
			}
			if (num2 || flag)
			{
				float num3 = MoveSettings.AccelerationRate * Mathf.Abs(_targetCamera.EstimateZoomFactor(_lastFocusPoint)) * Time.deltaTime;
				_currentAcceleration += num3;
			}
			else
			{
				_currentAcceleration = 0f;
			}
			float axis = Input.GetAxis("Mouse X");
			float axis2 = Input.GetAxis("Mouse Y");
			if (axis != 0f || axis2 != 0f)
			{
				if (_panSettings.IsPanningEnabled && Hotkeys.Pan.IsActive())
				{
					if (_panSettings.PanMode == CameraPanMode.Standard)
					{
						Pan(CalculatePanAmount(axis, axis2));
					}
					else
					{
						StopCamTransform();
						StartCoroutine(_genricCamTransformCrtn = DoSmoothPan(axis, axis2));
					}
				}
				else if (_orbitSettings.IsOrbitEnabled && Hotkeys.Orbit.IsActive())
				{
					if (_orbitSettings.OrbitMode == CameraOrbitMode.Standard)
					{
						Vector2 vector = CalculateOrbitRotation(axis, axis2);
						Orbit(vector.x, vector.y);
					}
					else
					{
						StopCamTransform();
						StartCoroutine(_genricCamTransformCrtn = DoSmoothOrbit(axis, axis2));
					}
				}
				else if (_lookAroundSettings.IsLookAroundEnabled && Hotkeys.LookAround.IsActive())
				{
					if (_lookAroundSettings.LookAroundMode == CameraLookAroundMode.Standard)
					{
						Vector2 vector2 = CalculateLookAroundRotation(axis, axis2);
						LookAround(vector2.x, vector2.y);
					}
					else
					{
						StopCamTransform();
						StartCoroutine(_genricCamTransformCrtn = DoSmoothLookAround(axis, axis2));
					}
				}
			}
			if (!CanUseMouseScrollWheel())
			{
				return;
			}
			float axis3 = Input.GetAxis("Mouse ScrollWheel");
			if (axis3 != 0f && _zoomSettings.IsZoomEnabled)
			{
				if (_zoomSettings.ZoomMode == CameraZoomMode.Standard)
				{
					Zoom(CalculateScrollZoomAmount(axis3));
					return;
				}
				StopCamTransform();
				StartCoroutine(_genricCamTransformCrtn = DoSmoothZoom(axis3));
			}
		}

		private bool CanUseMouseScrollWheel()
		{
			if (this.CanUseScrollWheel == null)
			{
				return true;
			}
			YesNoAnswer yesNoAnswer = new YesNoAnswer();
			this.CanUseScrollWheel(yesNoAnswer);
			return yesNoAnswer.HasOnlyYes;
		}

		private bool CanCameraProcessInput()
		{
			if (!_settings.CanProcessInput || _isDoingFocus || IsDoingProjectionSwitch || _isDoingRotationSwitch)
			{
				return false;
			}
			if (this.CanProcessInput == null)
			{
				return true;
			}
			YesNoAnswer yesNoAnswer = new YesNoAnswer();
			this.CanProcessInput(yesNoAnswer);
			return yesNoAnswer.HasOnlyYes;
		}

		private void Zoom(float zoomAmount)
		{
			Vector3 focusPoint = GetFocusPoint();
			_targetTransform.position += _targetTransform.forward * zoomAmount;
			if (TargetCamera.orthographic && Vector3.Dot(focusPoint - _targetTransform.position, _targetTransform.forward) < 0.01f)
			{
				_targetTransform.position = focusPoint - _targetTransform.forward * 0.001f;
			}
			SetFocusPoint(focusPoint);
			AdjustOrthoSizeForFocusPt();
		}

		private Vector3 GetFocusPoint()
		{
			return _targetTransform.position + _targetTransform.forward * _focusPointOffset;
		}

		private float CalculateScrollZoomAmount(float deviceScroll)
		{
			float num = deviceScroll * _zoomSettings.GetZoomSensitivity(TargetCamera);
			if (_zoomSettings.InvertZoomAxis)
			{
				num *= -1f;
			}
			return num * _targetCamera.EstimateZoomFactorSpherical(_lastFocusPoint);
		}

		private void Pan(Vector2 panAmount)
		{
			_targetTransform.position += _targetTransform.right * panAmount.x + _targetTransform.up * panAmount.y;
		}

		public void LookAround(float degreesLocalX, float degreesWorldY)
		{
			_targetTransform.Rotate(Vector3.up, degreesWorldY, Space.World);
			_targetTransform.Rotate(_targetTransform.right, degreesLocalX, Space.World);
		}

		private void Orbit(float degreesLocalX, float degreesWorldY)
		{
			Vector3 vector = _targetTransform.position + _targetTransform.forward * _focusPointOffset;
			_targetTransform.RotateAround(vector, Vector3.up, degreesWorldY);
			_targetTransform.RotateAround(vector, _targetTransform.right, degreesLocalX);
			_targetTransform.LookAt(vector, _targetTransform.up);
		}

		private void PerformInstantFocus(CameraFocus.Data focusData)
		{
			_targetTransform.position = focusData.CameraWorldPosition;
			SetFocusPoint(focusData.FocusPoint);
			_lastFocusPoint = focusData.FocusPoint;
			AdjustOrthoSizeForFocusPt();
		}

		private void PerformInstantProjectionSwitch()
		{
			TargetCamera.orthographic = !TargetCamera.orthographic;
		}

		private Vector2 CalculateLookAroundRotation(float deviceAxisX, float deviceAxisY)
		{
			Vector2 zero = Vector2.zero;
			zero.x = (0f - deviceAxisY) * _lookAroundSettings.Sensitivity;
			if (_lookAroundSettings.InvertY)
			{
				zero.x *= -1f;
			}
			zero.y = deviceAxisX * _lookAroundSettings.Sensitivity;
			if (_lookAroundSettings.InvertX)
			{
				zero.y *= -1f;
			}
			return zero;
		}

		private Vector2 CalculateOrbitRotation(float deviceAxisX, float deviceAxisY)
		{
			Vector2 zero = Vector2.zero;
			zero.x = (0f - deviceAxisY) * _orbitSettings.OrbitSensitivity;
			if (_orbitSettings.InvertY)
			{
				zero.x *= -1f;
			}
			zero.y = deviceAxisX * _orbitSettings.OrbitSensitivity;
			if (_orbitSettings.InvertX)
			{
				zero.y *= -1f;
			}
			return zero;
		}

		private Vector2 CalculatePanAmount(float deviceAxisX, float deviceAxisY)
		{
			Vector2 zero = Vector2.zero;
			zero.x = (0f - deviceAxisX) * _panSettings.Sensitivity;
			if (_panSettings.InvertX)
			{
				zero.x *= -1f;
			}
			zero.y = (0f - deviceAxisY) * _panSettings.Sensitivity;
			if (_panSettings.InvertY)
			{
				zero.y *= -1f;
			}
			return zero * Mathf.Abs(_targetCamera.EstimateZoomFactorSpherical(_lastFocusPoint));
		}

		private void StopCamTransform()
		{
			if (_genricCamTransformCrtn != null)
			{
				StopCoroutine(_genricCamTransformCrtn);
				_genricCamTransformCrtn = null;
			}
		}

		private void StopFocus()
		{
			if (_focusCrtn != null)
			{
				StopCoroutine(_focusCrtn);
				_focusCrtn = null;
			}
		}

		private void SetFocusPoint(Vector3 focusPoint)
		{
			_focusPointOffset = (focusPoint - _targetTransform.position).magnitude;
		}

		private void AdjustOrthoSizeForFocusPt()
		{
			TargetCamera.orthographicSize = Mathf.Max(0.5f * TargetCamera.GetFrustumHeightFromDistance(_focusPointOffset), 0.0001f);
		}

		private IEnumerator DoSmoothPan(float deviceAxisX, float deviceAxisY)
		{
			Vector2 panAmount = CalculatePanAmount(deviceAxisX, deviceAxisY);
			while (true)
			{
				Pan(panAmount);
				panAmount = Vector2.Lerp(panAmount, Vector2.zero, _panSettings.SmoothValue * Time.deltaTime);
				if (!Mathf.Approximately(panAmount.sqrMagnitude, 0f))
				{
					yield return null;
					continue;
				}
				break;
			}
		}

		private IEnumerator DoSmoothLookAround(float deviceAxisX, float deviceAxisY)
		{
			Vector2 rotationAmount = CalculateLookAroundRotation(deviceAxisX, deviceAxisY);
			while (true)
			{
				LookAround(rotationAmount.x, rotationAmount.y);
				rotationAmount = Vector2.Lerp(rotationAmount, Vector2.zero, _lookAroundSettings.SmoothValue * Time.deltaTime);
				if (!Mathf.Approximately(rotationAmount.sqrMagnitude, 0f))
				{
					yield return null;
					continue;
				}
				break;
			}
		}

		private IEnumerator DoSmoothOrbit(float deviceAxisX, float deviceAxisY)
		{
			Vector2 rotationAmount = CalculateOrbitRotation(deviceAxisX, deviceAxisY);
			while (true)
			{
				Orbit(rotationAmount.x, rotationAmount.y);
				rotationAmount = Vector2.Lerp(rotationAmount, Vector2.zero, _orbitSettings.SmoothValue * Time.deltaTime);
				if (!Mathf.Approximately(rotationAmount.sqrMagnitude, 0f))
				{
					yield return null;
					continue;
				}
				break;
			}
		}

		private IEnumerator DoSmoothZoom(float deviceScroll)
		{
			float zoomAmount = CalculateScrollZoomAmount(deviceScroll);
			while (true)
			{
				Zoom(zoomAmount);
				zoomAmount = Mathf.Lerp(zoomAmount, 0f, _zoomSettings.GetZoomSmoothValue(TargetCamera) * Time.deltaTime);
				if (!Mathf.Approximately(zoomAmount, 0f))
				{
					yield return null;
					continue;
				}
				break;
			}
		}

		private IEnumerator DoConstantRotationSwitch(Quaternion targetRotation)
		{
			Quaternion sourceRotation = _targetTransform.rotation;
			float elapsedTime = 0f;
			_isDoingRotationSwitch = true;
			while (true)
			{
				_targetTransform.rotation = Quaternion.Slerp(sourceRotation, targetRotation, elapsedTime / RotationSwitchSettings.ConstantSwitchDurationInSeconds);
				elapsedTime += Time.deltaTime;
				if (Mathf.Abs(Quaternion.Angle(_targetTransform.rotation, targetRotation)) < 0.0001f)
				{
					break;
				}
				yield return null;
			}
			_targetTransform.rotation = targetRotation;
			_isDoingRotationSwitch = false;
		}

		private IEnumerator DoSmoothRotationSwitch(Quaternion targetRotation)
		{
			_isDoingRotationSwitch = true;
			while (true)
			{
				_targetTransform.rotation = Quaternion.Slerp(_targetTransform.rotation, targetRotation, Time.deltaTime * RotationSwitchSettings.SmoothValue);
				if (Mathf.Abs(Quaternion.Angle(_targetTransform.rotation, targetRotation)) < 0.0001f)
				{
					break;
				}
				yield return null;
			}
			_targetTransform.rotation = targetRotation;
			_isDoingRotationSwitch = false;
		}

		private IEnumerator DoConstantFocus(CameraFocus.Data focusData)
		{
			float targetOrthoSize = 0.5f * TargetCamera.GetFrustumHeightFromDistance(focusData.FocusPointOffset);
			Vector3 position = _targetTransform.position;
			Vector3 camMoveDir = Vector3.Normalize(focusData.CameraWorldPosition - position);
			float distanceToTravel = (position - focusData.CameraWorldPosition).magnitude;
			float initialCamOrthoSize = TargetCamera.orthographicSize;
			_isDoingFocus = true;
			while (true)
			{
				_targetTransform.position += camMoveDir * FocusSettings.ConstantSpeed * Time.deltaTime;
				float t = 1f - (_targetTransform.position - focusData.CameraWorldPosition).magnitude / distanceToTravel;
				TargetCamera.orthographicSize = Mathf.Lerp(initialCamOrthoSize, targetOrthoSize, t);
				if (Vector3.Dot(camMoveDir, focusData.CameraWorldPosition - _targetTransform.position) <= 0f)
				{
					break;
				}
				yield return null;
			}
			_targetTransform.position = focusData.CameraWorldPosition;
			TargetCamera.orthographicSize = targetOrthoSize;
			SetFocusPoint(focusData.FocusPoint);
			_lastFocusPoint = focusData.FocusPoint;
			_isDoingFocus = false;
		}

		private IEnumerator DoSmoothFocus(CameraFocus.Data focusData)
		{
			float targetOrthoSize = 0.5f * TargetCamera.GetFrustumHeightFromDistance(focusData.FocusPointOffset);
			Vector3 position = _targetTransform.position;
			Vector3 camMoveDir = Vector3.Normalize(focusData.CameraWorldPosition - position);
			float elapsedTime = 0f;
			_isDoingFocus = true;
			while (true)
			{
				float t = elapsedTime / FocusSettings.SmoothTime;
				_targetTransform.position = Vector3.Lerp(_targetTransform.position, focusData.CameraWorldPosition, t);
				TargetCamera.orthographicSize = Mathf.Lerp(TargetCamera.orthographicSize, targetOrthoSize, t);
				elapsedTime += Time.deltaTime;
				if (Vector3.Dot(camMoveDir, focusData.CameraWorldPosition - _targetTransform.position) <= 0f)
				{
					break;
				}
				yield return null;
			}
			_targetTransform.position = focusData.CameraWorldPosition;
			TargetCamera.orthographicSize = targetOrthoSize;
			SetFocusPoint(focusData.FocusPoint);
			_lastFocusPoint = focusData.FocusPoint;
			_isDoingFocus = false;
		}

		private void OnPrjSwitchTransitionBegin(CameraPrjSwitchTransition.Type transitionType)
		{
			if (this.PrjSwitchTransitionBegin != null)
			{
				this.PrjSwitchTransitionBegin(transitionType);
			}
		}

		private void OnPrjSwitchTransitionUpate(CameraPrjSwitchTransition.Type transitionType)
		{
			if (this.PrjSwitchTransitionUpdate != null)
			{
				this.PrjSwitchTransitionUpdate(transitionType);
			}
		}

		private void OnPrjSwitchTransitionEnd(CameraPrjSwitchTransition.Type transitionType)
		{
			if (this.PrjSwitchTransitionEnd != null)
			{
				this.PrjSwitchTransitionEnd(transitionType);
			}
		}
	}
}
