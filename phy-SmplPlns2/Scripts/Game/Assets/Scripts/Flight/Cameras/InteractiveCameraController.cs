using Assets.Scripts.Input;
using Assets.Scripts.Input.Events;
using Assets.Scripts.Input.XR;
using Assets.Scripts.Settings;
using Jundroo.Common.Utils;
using Rewired;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

namespace Assets.Scripts.Flight.Cameras
{
	public abstract class InteractiveCameraController : CameraController
	{
		public const float MaxZoomDistance = 500f;

		public const float MinZoomDistance = 1.5f;

		protected float _cameraRotationOffset;

		protected Vector2 _deltaRotation;

		protected bool _fovZoom;

		protected bool _pinching;

		protected float _rotationSensitivity = 1f;

		protected CameraSettings _settings;

		protected float _targetDistance = 20f;

		protected Vector3 _targetPositionOffset;

		protected bool _touching;

		private float _fovZoomSmoothing = 30f;

		private float _fovZoomTarget;

		private float _fovZoomVelocity;

		private Mouse _mouse;

		private bool _mouseLook;

		private Vector3? _xrLeftHandPosition;

		private Vector3 _xrMovementSensitivity = new Vector3(600f, 200f, 100f);

		private Vector3? _xrRightHandPosition;

		public override bool IsRecenterAvailable
		{
			get
			{
				if (!(_targetPositionOffset.sqrMagnitude > 0f))
				{
					return _cameraRotationOffset != 0f;
				}
				return true;
			}
		}

		public bool MouseLook
		{
			get
			{
				return _mouseLook;
			}
			set
			{
				_mouseLook = value;
				UpdateCursor();
			}
		}

		public override float PreferredClosestShadowDistance => Mathf.Max(base.CameraManager.SharedCameraDistance, 4f);

		public Vector2 TargetPositionOffset => _targetPositionOffset;

		public bool ViewIsFocused
		{
			get
			{
				if (!Game.Instance.UserInterface.AnyDialogsOpen)
				{
					return !PauseManager.Paused;
				}
				return false;
			}
		}

		protected float CameraLookLeftRightAxis { get; set; }

		protected float CameraLookUpDownAxis { get; set; }

		protected float CameraLookZoomAxis { get; set; }

		protected virtual float FovZoomRate => 3f;

		protected virtual float InitialFov => _settings.FieldOfView;

		protected virtual float MaximumFov => _settings.FieldOfView;

		protected virtual float MinimumFov => (float)_settings.FieldOfView * 0.25f;

		protected virtual bool SupportsMovementInXR => false;

		public InteractiveCameraController(CameraManagerScript cameraManager)
			: base(cameraManager)
		{
			_settings = Game.Instance.Settings.Gameplay.Camera;
			_fovZoomTarget = InitialFov;
			_mouse = InputWrapper.Player.controllers.Mouse;
		}

		public override void HandleInput(InputEvent e)
		{
			if (_pinching)
			{
				return;
			}
			if (e.InputButton == InputButton.Primary || MouseLook)
			{
				Vector2 vector = e.DeltaPosition / Game.Instance.Device.Dpi;
				if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
				{
					vector *= 160f;
				}
				else
				{
					vector *= 80f;
				}
				Rotate(new Vector2(0f - vector.y, vector.x), additiveRotation: true);
				if (e.InputState == InputState.Begin)
				{
					_touching = true;
				}
				else if (e.InputState == InputState.End)
				{
					_touching = false;
				}
			}
			if (e.InputButton == InputButton.Middle)
			{
				if (UnityEngine.Input.GetKey(KeyCode.LeftShift) || UnityEngine.Input.GetKey(KeyCode.RightShift))
				{
					_cameraRotationOffset += e.DeltaPosition.x;
				}
				else
				{
					Move(new Vector2(0f - e.DeltaPosition.x, 0f - e.DeltaPosition.y));
				}
			}
		}

		public override void HandlePinch(PinchEvent e)
		{
			if (e.InputState != InputState.End)
			{
				_pinching = true;
				float num = e.DistanceDelta / Game.Instance.Device.Dpi;
				Zoom(num * 12f);
			}
			else
			{
				_pinching = false;
			}
		}

		public virtual void Move(Vector2 direction)
		{
			float num = 0.05f;
			Vector3 vector = base.CameraTransform.right * (direction.x * num) + base.CameraTransform.up * (direction.y * num);
			_targetPositionOffset += vector;
		}

		public override void OnSelected()
		{
			base.OnSelected();
			UpdateCursor();
		}

		public override void RecenterView()
		{
			base.RecenterView();
			_targetPositionOffset = Vector2.zero;
			_cameraRotationOffset = 0f;
		}

		public virtual void Rotate(Vector2 rotation, bool additiveRotation)
		{
			if (additiveRotation)
			{
				_deltaRotation += rotation * (0.4f * _rotationSensitivity);
				_deltaRotation = new Vector2(Mathf.Clamp(_deltaRotation.x, -89f, 89f), _deltaRotation.y);
			}
			else
			{
				_deltaRotation = rotation;
			}
		}

		public override void Update(int frameCount)
		{
			if (!PauseManager.Paused && MouseLook)
			{
				Rotate(GetMouseLookDelta(1f), additiveRotation: true);
			}
			if (frameCount == 1 && Game.Instance.UserInterface.AllowKeyboardInputs && (FlightSceneScript.Instance.FlightUI.IsPointerInsideGameView || MouseLook) && !Game.Instance.UIInfo.IsInteracting)
			{
				UpdateInputs();
				Vector2 vector = InputRotationMultiplier();
				Vector2 rotation = new Vector2(CameraLookUpDownAxis * vector.x, CameraLookLeftRightAxis * vector.y);
				if (rotation.x != 0f || rotation.y != 0f)
				{
					Rotate(rotation, InputRotationIsAdditives());
				}
				if (CameraLookZoomAxis != 0f)
				{
					Zoom(CameraLookZoomAxis);
				}
				if (_fovZoom && base.CameraManager.MainCamera.fieldOfView != _fovZoomTarget)
				{
					float cameraFov = Mathf.SmoothDamp(base.CameraManager.MainCamera.fieldOfView, _fovZoomTarget, ref _fovZoomVelocity, _fovZoomSmoothing * Time.unscaledDeltaTime / FovZoomRate, float.PositiveInfinity, Time.unscaledDeltaTime);
					base.CameraManager.SetCameraFov(cameraFov);
				}
			}
			if (_targetDistance < 1.5f)
			{
				_targetDistance = 1.5f;
			}
			else if (_targetDistance > 500f)
			{
				_targetDistance = 500f;
			}
			if (base.CameraManager.SharedCameraDistance < 1.5f)
			{
				base.CameraManager.SharedCameraDistance = 1.5f;
			}
		}

		public override void UpdateCursor()
		{
			base.UpdateCursor();
			if (base.IsSelected)
			{
				if (MouseLook && ViewIsFocused)
				{
					Cursor.lockState = CursorLockMode.Locked;
					Cursor.visible = false;
				}
				else
				{
					Cursor.lockState = CursorLockMode.None;
					Cursor.visible = true;
				}
			}
		}

		public void Zoom(float amount)
		{
			if (_fovZoom)
			{
				_rotationSensitivity = Mathf.Clamp((_fovZoomTarget = Mathf.MoveTowards(_fovZoomTarget, (Mathf.Sign(amount) > 0f) ? MinimumFov : MaximumFov, Mathf.Abs(amount) * FovZoomRate)) / (float)_settings.FieldOfView, 0.01f, 1f);
				return;
			}
			float num = _targetDistance / 10f;
			float num2 = amount * num;
			_targetDistance -= num2;
		}

		protected void ForceCameraAboveTerrain(Vector3 targetPosition)
		{
			RaycastHit hitInfo = default(RaycastHit);
			Vector3 normalized = (base.CameraTransform.position - new Vector3(0f, 0.5f, 0f) - targetPosition).normalized;
			float maxDistance = Mathf.Max(base.CameraManager.SharedCameraDistance, 0.5f);
			if (Physics.Raycast(targetPosition, normalized, out hitInfo, maxDistance, 1048576, QueryTriggerInteraction.Ignore))
			{
				base.CameraTransform.position = hitInfo.point + Vector3.up * 0.5f;
				base.CameraTransform.LookAt(targetPosition);
			}
		}

		protected virtual float GetCameraLookLeftRightAxis(float lookLeftRightAxis, float lookBackAxis)
		{
			if (lookLeftRightAxis == 0f)
			{
				return lookBackAxis;
			}
			return lookLeftRightAxis;
		}

		protected virtual bool InputRotationIsAdditives()
		{
			return true;
		}

		protected virtual Vector2 InputRotationMultiplier()
		{
			return new Vector2(360f, -360f) * Time.unscaledDeltaTime;
		}

		protected virtual void UpdateInputs()
		{
			GameInputs instance = GameInputs.Instance;
			float lookUpDown = 0f - instance.CameraLookUpDown.GetAxisIfEnabled();
			float lookLeftRight = 0f - instance.CameraLookLeftRight.GetAxisIfEnabled();
			float axisIfEnabled = instance.CameraLookBack.GetAxisIfEnabled();
			float lookZoom = instance.CameraLookZoom.GetAxisIfEnabled();
			if (SupportsMovementInXR && base.CameraManager.XRCameraManager.XrCamerasEnabled)
			{
				if (XRInputs.Flight.InteractLeft.IsPressed())
				{
					Vector3 newPosition = (Game.Instance.Device.IsPicoXRBuild ? XRInputs.PoseLeftHand.DevicePosition.ReadValue<Vector3>() : XRInputs.PoseLeftHand.DevicePose.ReadValue<UnityEngine.XR.OpenXR.Input.Pose>().position);
					_xrLeftHandPosition = UpdateLookInuptsForXR(newPosition, _xrLeftHandPosition);
				}
				else
				{
					_xrLeftHandPosition = null;
				}
				if (XRInputs.Flight.InteractRight.IsPressed())
				{
					Vector3 newPosition2 = (Game.Instance.Device.IsPicoXRBuild ? XRInputs.PoseRightHand.DevicePosition.ReadValue<Vector3>() : XRInputs.PoseRightHand.DevicePose.ReadValue<UnityEngine.XR.OpenXR.Input.Pose>().position);
					_xrRightHandPosition = UpdateLookInuptsForXR(newPosition2, _xrRightHandPosition);
				}
				else
				{
					_xrRightHandPosition = null;
				}
			}
			else
			{
				_xrLeftHandPosition = null;
				_xrRightHandPosition = null;
			}
			CameraLookUpDownAxis = lookUpDown;
			CameraLookLeftRightAxis = GetCameraLookLeftRightAxis(lookLeftRight, axisIfEnabled);
			CameraLookZoomAxis = lookZoom * 0.5f;
			if (CameraLookZoomAxis == 0f && instance.MouseWheelAlwaysZooms)
			{
				CameraLookZoomAxis = UnityEngine.Input.mouseScrollDelta.y;
			}
			Vector3 UpdateLookInuptsForXR(Vector3 vector2, Vector3? currentPosition)
			{
				Vector3 vector = currentPosition ?? vector2;
				Vector3 vector3 = vector2 - vector;
				vector3 = Quaternion.Inverse(base.CameraManager.XRCameraManager.MainCamera.transform.localRotation) * vector3;
				vector3 *= -1f;
				Vector3 vector4 = Vector3.Scale(vector3, _xrMovementSensitivity);
				lookLeftRight += vector4.x;
				lookUpDown += vector4.y;
				lookZoom += vector4.z * 1f;
				return vector2;
			}
		}

		private Vector2 GetMouseLookDelta(float smoothingAmount)
		{
			Vector2 vector = new Vector2(0f - _mouse.GetAxis(1), _mouse.GetAxis(0)) * _settings.CameraSensitivityFPV / 3.5f;
			smoothingAmount *= (float)_settings.CameraSmoothingFPV;
			if (smoothingAmount > 0.005f)
			{
				float val = Utilities.Max(Utilities.Abs(vector));
				float num = Mathf.Lerp(0.1f, 1f, MathUtility.PercentBetween(val, 0.05f, 10f * smoothingAmount));
				vector *= num;
			}
			return vector;
		}
	}
}
