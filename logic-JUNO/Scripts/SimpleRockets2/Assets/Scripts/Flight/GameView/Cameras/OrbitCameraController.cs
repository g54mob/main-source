using System;
using DG.Tweening;
using ModApi;
using ModApi.Common.Attributes;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Input.Events;
using ModApi.Math;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.GameView.Cameras
{
	internal class OrbitCameraController : InteractiveCameraController
	{
		public enum ReferencePlaneType
		{
			[DisplayName("Planet Aligned")]
			PlanetPositionNormal = 0,
			[DisplayName("Part Aligned")]
			Target = 1,
			[DisplayName("Solar System Aligned")]
			SolarSystem = 2,
			[DisplayName("Nav Sphere Aligned")]
			NavSphere = 3
		}

		private const float SoiTransitionTime = 1.5f;

		private Vector3 _cameraUpBeforeSoiSwitch;

		private bool _centerOnRigidBody;

		private Vector3 _currentRotation;

		private bool _debugRotatePanEnabled;

		private FlightSettings _flightSettings;

		private IGameView _gameView;

		private MouseInputSettingsFlight _mouseInputSettings;

		private Camera _nearCamera;

		private Vector3 _panPositionOffset = Vector3.zero;

		private Vector3 _panRotationOffset = Vector3.zero;

		private Transform _parentTransform;

		private ReferencePlaneType _referencePlane;

		private ReferencePlaneType _referencePlanePrevious;

		private Vector3 _targetRotation;

		private Transform _transform;

		private bool _transitioning;

		private float _transitionTime;

		private float _transitionUpVectorEndTime;

		public override bool AllowDefault => true;

		public bool AutoSwitchBasedOnAltitude { get; set; }

		public override Vector2 CurrentRotation
		{
			get
			{
				return new Vector2(_targetRotation.x, _targetRotation.y);
			}
			set
			{
				_targetRotation.x = value.x;
				_targetRotation.y = value.y;
			}
		}

		public override float CurrentTilt
		{
			get
			{
				return _targetRotation.z;
			}
			set
			{
				_targetRotation.z = value;
			}
		}

		public override float CurrentZoom
		{
			get
			{
				return base.TargetDistance;
			}
			set
			{
				base.TargetDistance = value;
				base.TargetDistance = Mathf.Clamp(base.TargetDistance, 1.5f, 2250000f);
			}
		}

		public Vector3? DefaultRotation { get; set; }

		public float? DefaultZoom { get; set; }

		public bool InvertLeftRightAxisInput { get; set; }

		public float OrientationSpeed { get; set; }

		public bool PanningEnabled { get; set; } = true;

		public override string Type => "Orbit";

		internal OrbitCameraController(CameraManagerScript cameraManager)
			: base(cameraManager)
		{
			base.TargetDistance = 150f;
			base.DeltaRotation = new Vector3(15f, 0f, 0f);
			Initialize();
		}

		public Transform LoadIntoGameView(IGameView gameView)
		{
			return _parentTransform;
		}

		public override void OnDeselected()
		{
			base.OnDeselected();
			((IGameCamera)base.CameraManager).UnregisterPositionOffset((CameraOffset)GetPanPositionOffset);
			((IGameCamera)base.CameraManager).UnregisterRotationOffset((CameraOffset)GetPanRotationOffset);
			UnsubscribeFromChaseCameraSettingEventsIfNecessary();
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			UnsubscribeFromChaseCameraSettingEventsIfNecessary();
			IFlightScene flightScene = Game.Instance.FlightScene;
			if (flightScene != null)
			{
				flightScene.PlayerChangedSoi -= OnPlayerChangedSoi;
			}
		}

		public override bool OnDrag(PointerEventData eventData)
		{
			bool inverted = false;
			InputButton inputButton = eventData.InputButton();
			if (eventData.IsTouchPrimary() || _mouseInputSettings.CanRotateCamera(inputButton, out inverted))
			{
				Rotate(eventData.delta * ((!inverted) ? 1 : (-1)));
			}
			else if (PanningEnabled && _mouseInputSettings.CanPanCamera(inputButton, out inverted))
			{
				Pan(eventData.delta * ((!inverted) ? 1 : (-1)));
			}
			else if (_mouseInputSettings.CanSpinForwardAxis(inputButton, out inverted))
			{
				Tilt(eventData.delta.x * (float)((!inverted) ? 1 : (-1)));
			}
			return true;
		}

		public override bool OnPinch(PinchEventData eventData)
		{
			float zoomPercentage = (eventData.Distance - eventData.DistanceDelta) / eventData.Distance;
			Zoom(zoomPercentage);
			return true;
		}

		public override void OnSelected(int subMode)
		{
			base.OnSelected(subMode);
			((IGameCamera)base.CameraManager).RegisterPositionOffset((CameraOffset)GetPanPositionOffset);
			((IGameCamera)base.CameraManager).RegisterRotationOffset((CameraOffset)GetPanRotationOffset);
			switch (subMode)
			{
			case 0:
				_referencePlane = ReferencePlaneType.PlanetPositionNormal;
				break;
			case 1:
				_referencePlane = ReferencePlaneType.SolarSystem;
				break;
			case 2:
				_referencePlane = ReferencePlaneType.Target;
				UpdateChaseCameraOrientationSpeed();
				_flightSettings.CameraSmoothingChase.Changed += OnChaseCameraSmoothingSettingChanged;
				break;
			case 3:
				_referencePlane = ReferencePlaneType.NavSphere;
				break;
			default:
				throw new Exception($"Unknown submode: {subMode}");
			}
		}

		public override void Pan(Vector2 delta)
		{
			if (!_debugRotatePanEnabled)
			{
				Vector2 vector = delta * base.TargetDistance / 1000f;
				_panPositionOffset -= _transform.right * vector.x + _transform.up * vector.y;
			}
			else
			{
				_panRotationOffset += new Vector3(0f - delta.y, delta.x, 0f) * 0.25f;
			}
		}

		public override void RecalculateFrameState(IReferenceFrame referenceFrame)
		{
			base.RecalculateFrameState(referenceFrame);
			UpdateCamera();
		}

		public override void Recenter(bool immediate = false)
		{
			if (immediate)
			{
				_panPositionOffset = Vector3.zero;
				_targetRotation.z = 0f;
				if (DefaultRotation.HasValue)
				{
					_targetRotation = DefaultRotation.Value;
				}
				if (DefaultZoom.HasValue)
				{
					CurrentZoom = DefaultZoom.Value;
				}
				return;
			}
			DOTween.To(() => _panPositionOffset, delegate(Vector3 x)
			{
				_panPositionOffset = x;
			}, Vector3.zero, 1f).SetEase(Ease.OutCubic);
			DOTween.To(() => _targetRotation.z, delegate(float x)
			{
				_targetRotation.z = x;
			}, 0f, 0.25f).SetEase(Ease.InOutCubic);
			if (DefaultRotation.HasValue)
			{
				DOTween.To(() => _targetRotation, delegate(Vector3 x)
				{
					_targetRotation = x;
				}, DefaultRotation.Value, 0.25f).SetEase(Ease.InOutCubic);
			}
			if (DefaultZoom.HasValue)
			{
				DOTween.To(() => CurrentZoom, delegate(float x)
				{
					CurrentZoom = x;
				}, DefaultZoom.Value, 0.25f).SetEase(Ease.InOutCubic);
			}
		}

		public override void Rotate(Vector2 delta)
		{
			float num = 1f;
			double num2 = MathUtils.LimitAngleNegPItoPI(_targetRotation.x * (MathF.PI / 180f)) * 57.295780181884766;
			if (num2 < -90.0 || num2 > 90.0)
			{
				num = -1f;
			}
			_targetRotation += new Vector3(0f - delta.y, num * delta.x, 0f) * ((float)_flightSettings.CameraSensitivity / 8f);
		}

		public Ray ScreenPointToRay(Vector2 screenPoint)
		{
			return Utilities.ScreenPointToRay(base.CameraTransform.GetComponent<Camera>(), screenPoint);
		}

		public void SetPhysicsEnabled(bool enabled, PhysicsChangeReason reason)
		{
		}

		public void SetRotation(Vector3 rotation)
		{
			_currentRotation = rotation;
			_targetRotation = rotation;
		}

		public override void Tilt(float delta)
		{
			_targetRotation.z += delta;
		}

		public override void Update(int frameCount)
		{
			base.Update(frameCount);
			UpdateCamera();
		}

		public void UpdateCamera()
		{
			_transform.localPosition = new Vector3(0f, 0f, _transform.localPosition.z);
			if (base.Target != null)
			{
				Vector3 zero = Vector3.zero;
				foreach (CameraOffset positionOffset in base.CameraManager.PositionOffsets)
				{
					zero += positionOffset();
				}
				if (!base.LockPosition)
				{
					_parentTransform.position = base.Target.CameraTarget.position + zero;
				}
			}
			Vector2 vector = InputRotationMultiplier();
			Vector2 vector2 = new Vector2((0f - base.CameraLookLeftRightAxis) * vector.x * (float)((!InvertLeftRightAxisInput) ? 1 : (-1)), base.CameraLookUpDownAxis * vector.y);
			if (!Utilities.CompareVector3s(vector2, Vector2.zero))
			{
				Rotate(vector2);
			}
			float num = Mathf.Clamp(Time.unscaledDeltaTime, 0f, 0.05f);
			OrientCamera(num);
			if (!FlightSceneScript.Instance.TimeManager.Paused && !Utilities.CompareVector3s(_panRotationOffset, Vector3.zero))
			{
				_panRotationOffset = Quaternion.RotateTowards(Quaternion.Euler(_panRotationOffset), Quaternion.identity, 50f * num).eulerAngles;
				if (_panRotationOffset.magnitude < 0.001f)
				{
					_panRotationOffset = Vector3.zero;
				}
			}
			float num2 = 0f - base.TargetDistance - _transform.localPosition.z;
			_transform.localPosition += new Vector3(0f, 0f, num2 * num * 5f);
			base.PlanetPosition = _gameView.ReferenceFrame.FrameToPlanetPosition(_transform.position);
			base.IsOffCenter = _panPositionOffset.sqrMagnitude > 0f || Mathf.Abs(_currentRotation.z) > 0.1f;
			if (DefaultRotation.HasValue)
			{
				base.IsOffCenter |= !Utilities.CompareVector3s(DefaultRotation.Value, _currentRotation, 0.5f);
			}
			if (DefaultZoom.HasValue)
			{
				base.IsOffCenter |= !Utilities.CompareFloats(DefaultZoom.Value, CurrentZoom, 0.5f);
			}
		}

		protected override Vector2 InputRotationMultiplier()
		{
			return new Vector2(360f, -360f) * Time.unscaledDeltaTime * 2f;
		}

		protected override void OnCameraBelowTerrain(Vector3 suggestedCameraFramePos, double distanceRaised)
		{
			base.OnCameraBelowTerrain(suggestedCameraFramePos, distanceRaised);
			Quaternion quaternion = Quaternion.LookRotation(_parentTransform.position - suggestedCameraFramePos, _parentTransform.up);
			_parentTransform.rotation = quaternion;
			_transform.position = suggestedCameraFramePos;
			if (_referencePlane != ReferencePlaneType.SolarSystem)
			{
				Quaternion rotation = Quaternion.FromToRotation(Vector3.up, GetDefaultCameraUp(_referencePlane));
				_targetRotation.x = (Quaternion.Inverse(rotation) * quaternion).eulerAngles.x;
				_currentRotation.x = _targetRotation.x;
			}
			else
			{
				_targetRotation = quaternion.eulerAngles;
				_currentRotation = _targetRotation;
			}
		}

		private Vector3 GetDefaultCameraUp(ReferencePlaneType refPlane)
		{
			Vector3 vector;
			switch (refPlane)
			{
			case ReferencePlaneType.PlanetPositionNormal:
			case ReferencePlaneType.NavSphere:
			{
				vector = _gameView.ReferenceFrame.PlanetToFrameVector(base.Target.CameraTargetPlanetPosition.normalized);
				float num = _transitionUpVectorEndTime - Time.unscaledTime;
				if (num > 0f)
				{
					vector = Vector3.Lerp(_cameraUpBeforeSoiSwitch, vector, 1f - num / 1.5f);
				}
				break;
			}
			case ReferencePlaneType.SolarSystem:
				vector = Vector3.up;
				break;
			case ReferencePlaneType.Target:
				vector = base.Target.CameraTarget.up;
				break;
			default:
				Debug.LogError($"Unsupported reference plane type: {refPlane}");
				vector = Vector3.up;
				break;
			}
			return vector;
		}

		private Quaternion GetFinalCameraRotation(ReferencePlaneType refPlane, Vector3 rotationOffsets)
		{
			return GetNeutralCameraRotation(refPlane) * Quaternion.Euler(rotationOffsets);
		}

		private Quaternion GetNeutralCameraRotation(ReferencePlaneType refPlane)
		{
			switch (refPlane)
			{
			case ReferencePlaneType.PlanetPositionNormal:
				return Quaternion.FromToRotation(Vector3.up, GetDefaultCameraUp(refPlane));
			case ReferencePlaneType.SolarSystem:
				return Quaternion.identity;
			case ReferencePlaneType.Target:
				return base.Target.CameraTarget.rotation;
			case ReferencePlaneType.NavSphere:
			{
				float heading = Game.Instance.FlightScene.FlightSceneUI.NavSphere.Heading;
				Vector3 defaultCameraUp = GetDefaultCameraUp(refPlane);
				Vector3 vector = _gameView.ReferenceFrame.PlanetToFrameVector(Game.Instance.FlightScene.CraftNode.CraftScript.FlightData.East);
				return Quaternion.LookRotation(Quaternion.AngleAxis(heading, defaultCameraUp) * vector, defaultCameraUp);
			}
			default:
				Debug.LogError($"Unsupported reference plane type: {refPlane}");
				return Quaternion.identity;
			}
		}

		private Vector3 GetPanPositionOffset()
		{
			return _panPositionOffset;
		}

		private Vector3 GetPanRotationOffset()
		{
			return _panRotationOffset;
		}

		private void Initialize()
		{
			_parentTransform = base.CameraTransform.parent;
			_transform = base.CameraTransform;
			_nearCamera = _transform.GetComponent<Camera>();
			_flightSettings = Game.Instance.Settings.Game.Flight;
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputFlight;
			_gameView = Game.Instance.FlightScene.ViewManager.GameView;
			_referencePlane = ReferencePlaneType.PlanetPositionNormal;
			Vector3 position = base.Target.CameraTarget.position;
			_parentTransform.position = new Vector3(position.x, position.y, _parentTransform.position.z);
			base.PlanetPosition = _gameView.ReferenceFrame.FrameToPlanetPosition(_transform.position);
			Game.Instance.FlightScene.PlayerChangedSoi += OnPlayerChangedSoi;
		}

		private void OnChaseCameraSmoothingSettingChanged(object sender, SettingChangedEventArgs<float> e)
		{
			UpdateChaseCameraOrientationSpeed();
		}

		private void OnPlayerChangedSoi(ICraftNode playerCraftNode, IPlanetNode newParent)
		{
			if (_referencePlane == ReferencePlaneType.PlanetPositionNormal)
			{
				_cameraUpBeforeSoiSwitch = GetDefaultCameraUp(_referencePlane);
				_transitionUpVectorEndTime = Time.unscaledTime + 1.5f;
			}
		}

		private void OrientCamera(float time)
		{
			_currentRotation = Vector3.Lerp(_currentRotation, _targetRotation, time * (float)_flightSettings.CameraSpeed);
			Vector3 zero = Vector3.zero;
			foreach (CameraOffset rotationOffset in base.CameraManager.RotationOffsets)
			{
				zero += rotationOffset();
			}
			_transform.localEulerAngles = zero;
			double num = (double)base.Target.CameraTargetPlanetPosition.magnitude - _gameView.PlanetNode.PlanetData.Radius;
			if (!_transitioning)
			{
				ReferencePlaneType referencePlaneType = _referencePlane;
				if (AutoSwitchBasedOnAltitude && _referencePlane != ReferencePlaneType.Target && _referencePlane != ReferencePlaneType.NavSphere)
				{
					if (num < 950000.0)
					{
						referencePlaneType = ReferencePlaneType.PlanetPositionNormal;
					}
					else if (num > 1000000.0)
					{
						referencePlaneType = ReferencePlaneType.SolarSystem;
					}
				}
				if (referencePlaneType != _referencePlane)
				{
					_transitioning = true;
					_referencePlane = referencePlaneType;
					_transitionTime = 0f;
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage($"{base.Name} - {_referencePlane}");
				}
			}
			Quaternion quaternion = GetFinalCameraRotation(_referencePlane, _currentRotation);
			if (_transitioning)
			{
				float t = _transitionTime / 0.5f;
				Quaternion finalCameraRotation = GetFinalCameraRotation(_referencePlanePrevious, _currentRotation);
				Quaternion b = quaternion;
				quaternion = Quaternion.Lerp(finalCameraRotation, b, t);
				_transitionTime += time;
				if (_transitionTime > 0.5f)
				{
					_transitioning = false;
					_referencePlanePrevious = _referencePlane;
				}
			}
			if (OrientationSpeed > 0f)
			{
				_parentTransform.rotation = Quaternion.Lerp(_parentTransform.rotation, quaternion, OrientationSpeed * time);
			}
			else
			{
				_parentTransform.rotation = quaternion;
			}
		}

		private void UnsubscribeFromChaseCameraSettingEventsIfNecessary()
		{
			if (_referencePlane == ReferencePlaneType.Target && _flightSettings != null)
			{
				_flightSettings.CameraSmoothingChase.Changed -= OnChaseCameraSmoothingSettingChanged;
			}
		}

		private void UpdateChaseCameraOrientationSpeed()
		{
			if (_referencePlane == ReferencePlaneType.Target)
			{
				float value = _flightSettings.CameraSmoothingChase.Value;
				OrientationSpeed = ((value == 1f) ? 0f : (2f + (10f - value)));
			}
		}
	}
}
