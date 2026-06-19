using System;
using System.Collections.Generic;
using Cinemachine;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	public class TopDownCameraLogic : MustCallDestroy
	{
		[DontVisitInternalsForAssetReference]
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public enum ScrollRegionSideFunctionType
			{
				Pan = 0,
				Rotate = 1
			}

			[Serializable]
			public struct DOFSettings
			{
				public float FocalLength;

				public float Aperture;
			}

			[InspectorHeader("Scroll region")]
			[InspectorTooltip("Size of the regions at the edges of the screen that are used for 'nudge' movement, as a number of pixels.")]
			public int ScrollRegionSizePixels = 1;

			[InspectorTooltip("What happens when you move the mouse to the sides of the window.")]
			public ScrollRegionSideFunctionType ScrollRegionSideFunction;

			[InspectorHeader("Speeds / Thresholds / Drag")]
			public float PanSpeed = 10f;

			public float PanSpeedZoomMultiplier = 1.2f;

			public float PanMovedThreshold = 0.05f;

			public float ZoomSpeed = 0.55f;

			public float RotateSpeedUsingKeyboard = 60f;

			public float RotateSpeedUsingMouseDrag = 10f;

			public float PitchSpeedUsingMouseDrag = 4f;

			public float PitchSpeedUsingKeyboard = 20f;

			public float PitchMinAngle = -40f;

			public float PitchMaxAngle = 20f;

			public float PitchResetRate = 6f;

			public float MouseRotatePitchYawAngle = 45f;

			public float MouseRotateAxisTime = 0.1f;

			[InspectorHeader("View Frustum")]
			public float FOV = 30f;

			public float NearPlace = 1.2f;

			public float FarPlace = 500f;

			public Vector3 InitialFocalPoint = new Vector3(0f, 0f, 0f);

			[InspectorTooltip("How far in Y to adjust the target point when tracking a target, e.g. a character. Use this to e.g. make sure the camera points at a character's head rather than feet.")]
			public float YOffsetForTrackedTarget = 0.75f;

			[InspectorRange(0f, 1f)]
			public float InitialZoomScalar = 0.3f;

			[InspectorTooltip("Max amount for zoom scalar; use to prevent camera being able to zoom out too far. Camera follows normal curve, just stops short.")]
			[InspectorRange(0f, 1f)]
			public float MaxZoomScalar = 1f;

			[InspectorRange(0f, 360f)]
			public float InitialRotation;

			[InspectorTooltip("Path will be scaled using this value; the last point in the path will have this height. Use to scale whole path without needing to edit points.")]
			public float HeightAtFurthestZoom = 200f;

			[InspectorTooltip("Before interpolating along the path, the zoom scalar will go through this response curve. Use to speed up or slow down zoom in parts of the zoom range.")]
			public AnimationCurve ZoomScalarPathDistanceCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

			[InspectorHeader("Smoothing")]
			public float ZoomScalarSmoothTime = 0.1f;

			public float RotationSmoothTime = 0.15f;

			public float RotationSmoothTimeWhileUsingMouseRotation = 0.04f;

			public float FocalPointSmoothTime = 0.1f;

			public float FocalPointSmoothTimeWhileGrabbing = 0.02f;

			public float FocalPointSmoothTimeWhileTracking = 0.1f;

			public float PostGrabVelocityStartMagn = 10f;

			public float PostGrabVelocityStopMagn = 0.25f;

			public float PostGrabVelocityMagnMax = 500f;

			public float PostGrabVelocityDampingTime = 0.15f;

			public float FrameTrackedObjectSmoothTime = 0.1f;

			public float FrameTrackedObjectSmoothReduceRate = 0.1f;

			[InspectorHeader("Rotation Resetting")]
			public bool ResetRotationOnRelease;

			[InspectorTooltip("Speed the camera snaps back to 0 in degrees/sec")]
			public float RotationResetSpeed = 20f;

			[InspectorTooltip("The time in seconds to smooth the value to 0")]
			public float RotationResetSmoothTime = 1f;

			[InspectorHeader("Rotation Constraints")]
			public bool ConstrainRotationAngles;

			[InspectorTooltip("The degrees before the camera starts to gets harder to rotate")]
			public float SoftConstraintLimit = 30f;

			[InspectorTooltip("The degrees where the camera cannot rotate any further")]
			public float HardConstraintLimit = 70f;

			[InspectorHeader("Cutscene Settings")]
			public float CutsceneFocalPointSmoothTime = 0.1f;

			public float CutscenePositionSmoothTime = 0.15f;

			public CinemachineBlenderSettings CinemachineBlenderSettings;

			[InspectorHeader("Miscellaneous")]
			public bool UseGrabPan = true;

			public bool UsePostGrabVelocity = true;

			public float CharacterFadeSpeed = 1f;

			public bool PlayAudioOnRotationThresholds = true;

			public int AudioRotationIntervalMinor = 15;

			public int AudioRotationIntervalMajor = 45;

			public MouseButton RotateMouseButton = MouseButton.Middle;

			public MouseButton PanMouseButton = MouseButton.Right;

			public Spline2D PositionPath;

			public PostProcessProfile PostProcessingProfile;

			public PostProcessResources PostProcessingResources;

			public bool AutoDepthOfField;

			public float DepthOfFieldTargetPlaneHeight = 10f;

			public float CloseDOFDistance;

			public float FarDOFDistance = 100f;

			public float DOFLerpCurve = 1f;

			public DOFSettings CloseDOFSetting;

			public DOFSettings FarDOFSetting;

			public LayerMask CullingMask = -1;

			public LayerMask PostProcessLayerMask;

			public string PostProcessVolumeLayer;

			public float _overrideShadowDistance;

			public float JoystickSlowPanMultiplier = 0.2f;

			public float JoystickSlowRotateMultiplier = 0.2f;

			public float JoystickSlowZoomMultiplier = 0.2f;

			public float JoystickLeftBumperOverallMultiplier = 0.5f;

			public float JoystickRightBumperOverallMultiplier = 0.33f;

			[InspectorHeader("Dynamic Shadow Distance")]
			public bool DynamicShadowDistance = true;

			public float MaxDynamicShadowDistance = 500f;

			public float DynamicShadowDistanceBias = 10f;
		}

		private readonly Config _config;

		private readonly CameraEvents _cameraEvents;

		[DontSave]
		private InputManager _inputManager;

		[DontSave]
		private Preferences _preferences;

		[DontSave]
		private LocalPreferences _localPreferences;

		private float _targetZoomScalar;

		private float _currentZoomScalar;

		private float _currentZoomScalarVelocity;

		private float _targetRotation;

		private float _currentRotation;

		private float _currentRotationVelocity;

		private float _currentPitch;

		private bool _rotatingPitch;

		private bool _rotatingYaw;

		private float _timeRotatingYaw;

		private float _timeRotatingPitch;

		private Vector3 _targetFocalPoint;

		private Vector3 _currentFocalPoint;

		private Vector3 _currentFocalPointVelocity;

		private Bounds _bounds;

		private ConvexPolygon _convexBounds = new ConvexPolygon();

		private Vector3 _worldLocationOnGrab;

		[DontSave]
		private float _shadowPlaneHeight;

		[DontSave]
		private float _shadowPlaneFadeDistance;

		private bool _isGrabbing;

		private float _postGrabVelocityMagn;

		private float _postGrabVelocityMagnPrev;

		private Vector3 _postGrabVelocityDirection;

		[DontSave]
		private GameObject _gameObject;

		[DontSave]
		private Camera _cameraComponent;

		[DontSave]
		private Transform _transformComponent;

		[DontSave]
		private PostProcessVolume _postProcessVolume;

		[DontSave]
		private Transform _trackedObject;

		[DontSave]
		private CutsceneCameraLogic _cutsceneCameraLogic;

		[DontSave]
		private CinemachineBrain _cinemachineBrain;

		[DontSave]
		private CameraHeightFadeComponent _cameraHeightFadeComponent;

		[DontSave]
		private Transform _fixedTransform;

		[DontSave]
		public bool IsDebugCameraEnabled;

		[DontSave]
		private const float _debugPitchMin = -40f;

		[DontSave]
		private const float _debugPitchMax = 30f;

		private readonly Vector3[] _frustumCorners = new Vector3[4];

		private Plane[] _frustumPlanes = new Plane[6];

		private bool _boundCamera = true;

		private Rect? _trackedObjectFrame;

		private const float TargetMidPoint = 0.875f;

		private float _frameTrackedObjectOffsetDuration;

		private Vector3 _targetFrameTrackedObjectOffset = Vector3.zero;

		private Vector3 _currentFrameTrackedObjectOffset = Vector3.zero;

		private Vector3 _frameTrackedObjectVelocity = Vector3.zero;

		public Camera CameraComponent => _cameraComponent;

		public CutsceneCameraLogic CutsceneCamera => _cutsceneCameraLogic;

		public Vector3[] FrustumCorners => _frustumCorners;

		public Plane[] FrustumPlanes => _frustumPlanes;

		public PostProcessLayer PostProcessLayer => _gameObject.GetComponent<PostProcessLayer>();

		public float CurrentZoomScalar => _currentZoomScalar;

		public CinemachineBrain CinemachineBrain => _cinemachineBrain;

		public float ShadowPlaneHeight
		{
			get
			{
				return _shadowPlaneHeight;
			}
			set
			{
				_shadowPlaneHeight = value;
			}
		}

		public float ShadowPlaneFadeDistance
		{
			get
			{
				return _shadowPlaneFadeDistance;
			}
			set
			{
				_shadowPlaneFadeDistance = Mathf.Max(0.1f, value);
			}
		}

		public TopDownCameraLogic(InputManager inputManager, Config config, Preferences preferences, LocalPreferences localPreferences, Transform rootObject, CameraEvents cameraEvents, Level level = null)
		{
			_config = config;
			_cameraEvents = cameraEvents;
			Initialise(inputManager, preferences, localPreferences, rootObject, level);
			Reset();
		}

		public void RestoreFromSave(InputManager inputManager, Preferences preferences, LocalPreferences localPreferences, Transform rootObject, Level level = null)
		{
			Initialise(inputManager, preferences, localPreferences, rootObject, level);
			if (_convexBounds == null)
			{
				SetBounds(_bounds.min, _bounds.max);
			}
			if (_config._overrideShadowDistance > 0f)
			{
				QualitySettings.shadowDistance = _config._overrideShadowDistance;
			}
			_trackedObjectFrame = null;
			UpdateTransform();
		}

		private void Initialise(InputManager inputManager, Preferences preferences, LocalPreferences localPreferences, Transform rootObject, Level level = null)
		{
			_inputManager = inputManager;
			_preferences = preferences;
			_localPreferences = localPreferences;
			_localPreferences.Video.OnAmbientOcclusionChange += OnAmbientOcclusionChange;
			_localPreferences.Video.OnBloomChange += OnBloomChange;
			_localPreferences.Video.OnDepthOfFieldChange += OnDepthOfFieldChange;
			_localPreferences.Video.OnAntialiasingChange += OnAntialiasingChange;
			_shadowPlaneHeight = -5f;
			_shadowPlaneFadeDistance = 0.1f;
			_gameObject = new GameObject("TopDownCameraLogic");
			_gameObject.tag = "MainCamera";
			if (rootObject != null)
			{
				_gameObject.transform.SetParent(rootObject);
			}
			_transformComponent = _gameObject.GetComponent<Transform>();
			_cameraComponent = CameraUtils.AddCameraComponent(_gameObject, _config);
			_cameraHeightFadeComponent = CameraUtils.AddCameraHeightFadeComponent(_gameObject, level, _cameraComponent.transform, _config);
			_postProcessVolume = CameraUtils.AddPostProcessLayer(_gameObject, _config);
			_gameObject.AddComponent<CameraWidthLimiter>();
			if (_postProcessVolume != null)
			{
				if (_postProcessVolume.profile.TryGetSettings<AmbientOcclusion>(out var outSetting))
				{
					outSetting.active = _localPreferences.Video.AmbientOcclusion;
				}
				if (_postProcessVolume.profile.TryGetSettings<Bloom>(out var outSetting2))
				{
					outSetting2.active = _localPreferences.Video.Bloom;
				}
				if (_postProcessVolume.profile.TryGetSettings<DepthOfField>(out var outSetting3))
				{
					outSetting3.active = _localPreferences.Video.DepthOfField;
				}
				ReloadLevelLightingConfig(level?.Config.GetLevelLightingConfig());
			}
			if ((bool)PostProcessLayer)
			{
				PostProcessLayer.antialiasingMode = (_localPreferences.Video.Antialiasing ? PostProcessLayer.Antialiasing.FastApproximateAntialiasing : PostProcessLayer.Antialiasing.None);
			}
			_cutsceneCameraLogic = new CutsceneCameraLogic(_cameraComponent, this, _config);
		}

		public void ReloadLevelLightingConfig(LevelLightingConfig levelLightingConfig)
		{
			if (levelLightingConfig != null && _postProcessVolume.profile.TryGetSettings<HeightFogSettings>(out var outSetting))
			{
				outSetting.active = levelLightingConfig.EnableHeightFog;
				outSetting.FogFadeInHeight.overrideState = true;
				outSetting.FogFadeInHeight.value = levelLightingConfig.FogSettings.FogFadeInHeight;
				outSetting.FogFadeOutHeight.overrideState = true;
				outSetting.FogFadeOutHeight.value = levelLightingConfig.FogSettings.FogFadeOutHeight;
				outSetting.FogColor.overrideState = true;
				outSetting.FogColor.value = levelLightingConfig.FogSettings.FogColor;
			}
		}

		public void Reset()
		{
			if (_config._overrideShadowDistance > 0f)
			{
				QualitySettings.shadowDistance = _config._overrideShadowDistance;
			}
			_targetZoomScalar = _config.InitialZoomScalar;
			_currentZoomScalar = _targetZoomScalar;
			_targetRotation = _config.InitialRotation;
			_currentRotation = _targetRotation;
			_targetFocalPoint = _config.InitialFocalPoint;
			_currentFocalPoint = _targetFocalPoint;
			_postGrabVelocityMagn = 0f;
			_shadowPlaneHeight = -5f;
			_shadowPlaneFadeDistance = 0.1f;
			UpdateTransform();
		}

		public void Reset(float zoom, float rotation)
		{
			_targetZoomScalar = zoom;
			_currentZoomScalar = _targetZoomScalar;
			_targetRotation = rotation;
			_currentRotation = _targetRotation;
			_currentFocalPoint = _targetFocalPoint;
			_postGrabVelocityMagn = 0f;
			UpdateTransform();
		}

		public void SetFocalPoint(Vector3 focalPoint, bool snap)
		{
			_targetFocalPoint = focalPoint;
			if (snap)
			{
				_currentFocalPoint = _targetFocalPoint;
			}
		}

		public void SetInitialFocalPoint(Vector3 focalPoint, float rotation)
		{
			_targetFocalPoint = focalPoint;
			_currentFocalPoint = _targetFocalPoint;
			_targetRotation = rotation;
			_currentRotation = rotation;
		}

		public Vector3 GetFocalPoint()
		{
			return _currentFocalPoint;
		}

		public Vector3 GetTargetFocalPoint()
		{
			return _targetFocalPoint;
		}

		public void SetFixedTransform(Transform transform)
		{
			_fixedTransform = transform;
		}

		public void Update()
		{
			if (_fixedTransform != null)
			{
				CameraComponent.transform.position = _fixedTransform.position;
				CameraComponent.transform.rotation = _fixedTransform.rotation;
			}
			else if (_cutsceneCameraLogic.IsInCutscene)
			{
				_cutsceneCameraLogic.Update();
			}
			else
			{
				UpdateInput();
				UpdateTransform();
			}
			ApplyEffects();
			ApplyShadowDistance();
			if (DebugVars.ShowCameraBounds.Value)
			{
				DebugDraw();
			}
			GameObjectUtils.SetActive(_gameObject, !DebugVars.DisableTopDownCameras.Value);
		}

		private void UpdateInput()
		{
			bool flag = false;
			float currentPitch = _currentPitch;
			bool mouseDragOnScene = _inputManager.GetMouseDragOnScene(_config.RotateMouseButton);
			float num = 0f;
			float num2 = Mathf.Min(Time.unscaledDeltaTime, 0.25f);
			if (mouseDragOnScene)
			{
				float num3 = _inputManager.GetAxis(42) * 0.1f;
				float num4 = _inputManager.GetAxis(43) * 0.1f;
				if (!_rotatingYaw && !_rotatingPitch)
				{
					Vector2 vector = new Vector2(Mathf.Abs(num3), Mathf.Abs(num4));
					if (vector.magnitude > 0.001f)
					{
						if (Vector2.Angle(Vector2.up, vector.normalized) > _config.MouseRotatePitchYawAngle)
						{
							_timeRotatingYaw += num2;
						}
						else
						{
							_timeRotatingPitch += num2;
						}
						_rotatingYaw = _timeRotatingYaw > _config.MouseRotateAxisTime;
						_rotatingPitch = _timeRotatingPitch > _config.MouseRotateAxisTime;
					}
				}
				if (_rotatingPitch)
				{
					_currentPitch += _config.PitchSpeedUsingMouseDrag * num4;
				}
				else if (_rotatingYaw)
				{
					flag = true;
					num += _config.RotateSpeedUsingMouseDrag * num3;
					if (_cameraEvents != null)
					{
						_cameraEvents.OnCameraRotate.InvokeSafe(num);
					}
				}
			}
			else
			{
				bool flag2 = false;
				bool flag3 = false;
				flag = true;
				_rotatingYaw = false;
				_rotatingPitch = false;
				_timeRotatingYaw = 0f;
				_timeRotatingPitch = 0f;
				if (!_inputManager.GetMouseDragOnScene(_config.PanMouseButton) && !_inputManager.IsMouseOverGui && _preferences.Control.EnableEdgeScrolling && _config.ScrollRegionSideFunction == Config.ScrollRegionSideFunctionType.Rotate && Application.isFocused)
				{
					if (Input.mousePosition.x <= (float)_config.ScrollRegionSizePixels)
					{
						flag2 = true;
					}
					else if (Input.mousePosition.x >= (float)(Screen.width - _config.ScrollRegionSizePixels))
					{
						flag3 = true;
					}
				}
				if (flag2)
				{
					num -= num2 * _config.RotateSpeedUsingKeyboard;
				}
				else if (flag3)
				{
					num += num2 * _config.RotateSpeedUsingKeyboard;
				}
				float num5 = 1f;
				if (Input.GetKey(KeyCode.JoystickButton4))
				{
					num5 *= _config.JoystickLeftBumperOverallMultiplier;
				}
				if (Input.GetKey(KeyCode.JoystickButton5))
				{
					num5 *= _config.JoystickRightBumperOverallMultiplier;
				}
				if (Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.JoystickButton5))
				{
					num5 *= _config.JoystickSlowRotateMultiplier;
				}
				float axis = _inputManager.GetAxis(5);
				num -= num2 * _config.RotateSpeedUsingKeyboard * (0f - axis) * num5;
				if (_inputManager.GetButton(38))
				{
					num += _config.RotateSpeedUsingKeyboard * num2;
				}
				if (_inputManager.GetButton(39))
				{
					num -= _config.RotateSpeedUsingKeyboard * num2;
				}
				if (_cameraEvents != null)
				{
					_cameraEvents.OnCameraRotate.InvokeSafe(num);
				}
			}
			if (flag)
			{
				_currentPitch += (0f - _currentPitch) * num2 * _config.PitchResetRate;
			}
			_currentPitch -= _inputManager.GetAxis(45) * num2 * _config.PitchSpeedUsingKeyboard;
			if (_inputManager.GetButton(47))
			{
				_currentPitch -= num2 * _config.PitchSpeedUsingKeyboard;
			}
			if (_inputManager.GetButton(46))
			{
				_currentPitch += num2 * _config.PitchSpeedUsingKeyboard;
			}
			_currentPitch %= 360f;
			if (_boundCamera)
			{
				if (IsDebugCameraEnabled)
				{
					_currentPitch = Mathf.Clamp(_currentPitch, -40f, 30f);
				}
				else
				{
					_currentPitch = Mathf.Clamp(_currentPitch, _config.PitchMinAngle, _config.PitchMaxAngle);
				}
			}
			if (_cameraEvents != null)
			{
				float num6 = _currentPitch - currentPitch;
				if (Mathf.Abs(num6) > float.Epsilon)
				{
					_cameraEvents.OnCameraPitch.InvokeSafe(num6);
				}
			}
			if (_config.ConstrainRotationAngles)
			{
				float p = 1f;
				float f = _targetRotation + num;
				if (Mathf.Abs(f) > _config.HardConstraintLimit)
				{
					p = 0f;
				}
				else if (Mathf.Abs(f) > _config.SoftConstraintLimit)
				{
					p = 1f - (Mathf.Abs(f) - _config.SoftConstraintLimit) / (_config.HardConstraintLimit - _config.SoftConstraintLimit);
				}
				num *= EasingsUtils.CubicEaseOut(p);
			}
			float currentRotation = _currentRotation;
			_targetRotation += num;
			_targetRotation %= 360f;
			bool flag4 = mouseDragOnScene || num > float.Epsilon;
			if (_config.ResetRotationOnRelease && !flag4)
			{
				if (_targetRotation < -0.01f)
				{
					_targetRotation = Mathf.Min(_targetRotation + _config.RotationResetSpeed * Time.unscaledDeltaTime, 0f);
				}
				else if (_targetRotation > 0.01f)
				{
					_targetRotation = Mathf.Max(_targetRotation - _config.RotationResetSpeed * Time.unscaledDeltaTime, 0f);
				}
				_currentRotation = Mathf.SmoothDampAngle(_currentRotation, _targetRotation, ref _currentRotationVelocity, _config.RotationResetSmoothTime, float.PositiveInfinity, num2);
			}
			else
			{
				_currentRotation = Mathf.SmoothDampAngle(_currentRotation, _targetRotation, ref _currentRotationVelocity, mouseDragOnScene ? _config.RotationSmoothTimeWhileUsingMouseRotation : _config.RotationSmoothTime, float.PositiveInfinity, num2);
			}
			if (_config.PlayAudioOnRotationThresholds)
			{
				int num7 = (int)(currentRotation / (float)_config.AudioRotationIntervalMajor);
				int num8 = (int)(_currentRotation / (float)_config.AudioRotationIntervalMajor);
				int num9 = (int)(currentRotation / (float)_config.AudioRotationIntervalMinor);
				int num10 = (int)(_currentRotation / (float)_config.AudioRotationIntervalMinor);
				if (num7 != num8)
				{
					AudioManager.Instance.Play("45RotateTick");
				}
				else if (num9 != num10)
				{
					AudioManager.Instance.Play("RotateTick");
				}
			}
			Quaternion quaternion = Quaternion.Euler(_currentPitch, _currentRotation, 0f);
			Vector3 vector2 = -(quaternion * Vector3.forward);
			Vector3 vector3 = -(quaternion * Vector3.right);
			_targetZoomScalar -= _inputManager.GetMouseWheel() * 0.1f * _config.ZoomSpeed;
			float num11 = 1f;
			if (Input.GetKey(KeyCode.JoystickButton4))
			{
				num11 *= _config.JoystickLeftBumperOverallMultiplier;
			}
			if (Input.GetKey(KeyCode.JoystickButton5))
			{
				num11 *= _config.JoystickRightBumperOverallMultiplier;
			}
			if (Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.JoystickButton5))
			{
				num11 *= _config.JoystickSlowZoomMultiplier;
			}
			_targetZoomScalar -= _inputManager.GetAxis(3) * num2 * _config.ZoomSpeed * num11;
			if (_inputManager.GetButton(40))
			{
				_targetZoomScalar -= num2 * _config.ZoomSpeed * num11;
			}
			if (_inputManager.GetButton(41))
			{
				_targetZoomScalar += num2 * _config.ZoomSpeed * num11;
			}
			_targetZoomScalar = Mathf.Clamp(_targetZoomScalar, 0f, _config.MaxZoomScalar);
			_currentZoomScalar = Mathf.SmoothDamp(_currentZoomScalar, _targetZoomScalar, ref _currentZoomScalarVelocity, _config.ZoomScalarSmoothTime, float.PositiveInfinity, num2);
			_currentZoomScalar = Mathf.Clamp(_currentZoomScalar, 0f, _config.MaxZoomScalar);
			if (_cameraEvents != null)
			{
				float num12 = _targetZoomScalar - _currentZoomScalar;
				if (Mathf.Abs(num12) > float.Epsilon)
				{
					_cameraEvents.OnCameraZoom.InvokeSafe(num12);
				}
			}
			Vector3 targetFocalPoint = _targetFocalPoint;
			if (_config.UseGrabPan && _isGrabbing && !_inputManager.GetMouseDragOnScene(_config.PanMouseButton))
			{
				_isGrabbing = false;
				_postGrabVelocityMagn = 0f;
				if (_config.UsePostGrabVelocity)
				{
					float magnitude = _currentFocalPointVelocity.magnitude;
					if (magnitude > _config.PostGrabVelocityStartMagn)
					{
						magnitude = Mathf.Min(magnitude, _config.PostGrabVelocityMagnMax);
						_postGrabVelocityMagnPrev = 0f;
						_postGrabVelocityMagn = magnitude;
						_postGrabVelocityDirection = _currentFocalPointVelocity;
						_postGrabVelocityDirection.Normalize();
					}
				}
			}
			float num13 = _inputManager.GetAxis(0);
			float num14 = _inputManager.GetAxis(1);
			if (_inputManager.GetButton(34))
			{
				num13 = -1f;
			}
			if (_inputManager.GetButton(35))
			{
				num13 = 1f;
			}
			if (_inputManager.GetButton(36))
			{
				num14 = 1f;
			}
			if (_inputManager.GetButton(37))
			{
				num14 = -1f;
			}
			bool flag5 = Mathf.Abs(num13) > 0f || Mathf.Abs(num14) > 0f;
			if (!flag5 && _inputManager.GetMouseDragOnScene(_config.PanMouseButton))
			{
				Vector3 targetFocalPoint2 = _targetFocalPoint;
				if (_config.UseGrabPan)
				{
					Vector3 offset = GetOffset();
					if (!_isGrabbing)
					{
						Ray ray = _cameraComponent.ScreenPointToRay(Input.mousePosition);
						if (new Plane(Vector3.up, 0f - _targetFocalPoint.y).Raycast(ray, out var enter))
						{
							_isGrabbing = true;
							Vector3 point = ray.GetPoint(enter);
							_worldLocationOnGrab = point;
						}
					}
					else
					{
						Ray ray2 = _cameraComponent.ScreenPointToRay(Input.mousePosition);
						if (!(Mathf.Abs(ray2.direction.y) < Mathf.Epsilon))
						{
							float num15 = offset.y / ray2.direction.y;
							Vector3 vector4 = _worldLocationOnGrab + ray2.direction * num15;
							_targetFocalPoint = vector4 - offset;
						}
					}
				}
				else
				{
					_targetFocalPoint += vector3 * num2 * _config.PanSpeed * (Input.mousePosition.x - (float)Screen.width * 0.5f) / ((float)Screen.width * 0.5f);
					_targetFocalPoint += vector2 * num2 * _config.PanSpeed * (Input.mousePosition.y - (float)Screen.height * 0.5f) / ((float)Screen.height * 0.5f);
				}
				if (_trackedObject == null && Vector3.Distance(targetFocalPoint2, _targetFocalPoint) > _config.PanMovedThreshold)
				{
					_inputManager.Flush();
				}
			}
			else
			{
				if (_preferences.Control.EnableEdgeScrolling && !_inputManager.IsMouseOverGui && !mouseDragOnScene && Application.isFocused)
				{
					if (_config.ScrollRegionSideFunction == Config.ScrollRegionSideFunctionType.Pan)
					{
						if (Input.mousePosition.x >= (float)(Screen.width - _config.ScrollRegionSizePixels))
						{
							_targetFocalPoint += vector3 * num2 * GetZoomCorrectedPanSpeed();
						}
						else if (Input.mousePosition.x <= (float)_config.ScrollRegionSizePixels)
						{
							_targetFocalPoint -= vector3 * num2 * GetZoomCorrectedPanSpeed();
						}
					}
					if (Input.mousePosition.y >= (float)(Screen.height - _config.ScrollRegionSizePixels))
					{
						_targetFocalPoint += vector2 * num2 * GetZoomCorrectedPanSpeed();
					}
					else if (Input.mousePosition.y <= (float)_config.ScrollRegionSizePixels)
					{
						_targetFocalPoint -= vector2 * num2 * GetZoomCorrectedPanSpeed();
					}
				}
				if (_config.UsePostGrabVelocity && _postGrabVelocityMagn > 0f)
				{
					_postGrabVelocityMagn = Mathf.SmoothDamp(_postGrabVelocityMagn, 0f, ref _postGrabVelocityMagnPrev, _config.PostGrabVelocityDampingTime, float.PositiveInfinity, num2);
					if (_postGrabVelocityMagn <= _config.PostGrabVelocityStopMagn)
					{
						_postGrabVelocityMagn = 0f;
					}
				}
				if (flag5)
				{
					float num16 = 1f;
					if (Input.GetKey(KeyCode.JoystickButton4))
					{
						num16 *= _config.JoystickLeftBumperOverallMultiplier;
					}
					if (Input.GetKey(KeyCode.JoystickButton5))
					{
						num16 *= _config.JoystickRightBumperOverallMultiplier;
					}
					if (Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.JoystickButton5))
					{
						num16 *= _config.JoystickSlowPanMultiplier;
					}
					_targetFocalPoint += vector3 * num2 * GetZoomCorrectedPanSpeed() * num13 * num16;
					_targetFocalPoint += vector2 * num2 * GetZoomCorrectedPanSpeed() * num14 * num16;
				}
				else if (_postGrabVelocityMagn > 0f && _config.UsePostGrabVelocity)
				{
					_targetFocalPoint += _postGrabVelocityDirection * num2 * _postGrabVelocityMagn;
				}
			}
			float num17 = targetFocalPoint.SquareDistance2D(_targetFocalPoint);
			if (num17 > 0.001f)
			{
				_trackedObject = null;
				if (_cameraEvents != null)
				{
					_cameraEvents.OnCameraPan.InvokeSafe(num17);
				}
			}
		}

		private void UpdateTransform()
		{
			Quaternion quaternion = Quaternion.Euler(_currentPitch, _currentRotation, 0f);
			Vector3 vector = -(quaternion * Vector3.forward);
			Vector3 rhs = -(quaternion * Vector3.right);
			Vector3 offset = GetOffset();
			Vector3 vector2 = Vector3.Normalize(-offset);
			if (vector2.sqrMagnitude < 0.5f)
			{
				vector2 = vector;
			}
			Vector3 upwards = Vector3.Cross(vector2, rhs);
			Quaternion rotation = Quaternion.LookRotation(vector2, upwards);
			_transformComponent.rotation = rotation;
			if (_trackedObject != null)
			{
				_targetFocalPoint = _trackedObject.position;
			}
			_targetFocalPoint.y = _config.YOffsetForTrackedTarget;
			if (_boundCamera && !IsDebugCameraEnabled)
			{
				_targetFocalPoint = ClampToBounds(_targetFocalPoint, _convexBounds);
			}
			float smoothTime = (_isGrabbing ? _config.FocalPointSmoothTimeWhileGrabbing : _config.FocalPointSmoothTime);
			if (_trackedObject != null)
			{
				smoothTime = _config.FocalPointSmoothTimeWhileTracking;
			}
			_currentFocalPoint = Vector3.SmoothDamp(_currentFocalPoint, _targetFocalPoint, ref _currentFocalPointVelocity, smoothTime, float.PositiveInfinity, Time.unscaledDeltaTime);
			if (_boundCamera && !IsDebugCameraEnabled)
			{
				_currentFocalPoint = ClampToBounds(_currentFocalPoint, _convexBounds);
			}
			_transformComponent.position = _currentFocalPoint + offset;
			FrameTrackedObject();
			_cameraComponent.CalculateFrustumCorners(new Rect(0f, 0f, 1f, 1f), _cameraComponent.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, _frustumCorners);
			for (int i = 0; i < 4; i++)
			{
				_frustumCorners[i] = _cameraComponent.transform.TransformVector(_frustumCorners[i]);
			}
			GeometryUtility.CalculateFrustumPlanes(_cameraComponent, _frustumPlanes);
		}

		private void FrameTrackedObject()
		{
			if (_trackedObject != null && _trackedObjectFrame.HasValue)
			{
				Vector3 vector = ClampToBounds(_currentFocalPoint, _convexBounds);
				Vector2 center = _trackedObjectFrame.Value.center;
				center.y = (float)Screen.height - center.y;
				Plane plane = new Plane(Vector3.up, Vector3.zero);
				Ray ray = _cameraComponent.ScreenPointToRay(center);
				if (plane.Raycast(ray, out var enter))
				{
					_targetFrameTrackedObjectOffset = vector - ray.GetPoint(enter);
				}
				_frameTrackedObjectOffsetDuration += Time.unscaledDeltaTime;
			}
			else
			{
				_frameTrackedObjectOffsetDuration = 0f;
				_targetFrameTrackedObjectOffset = Vector3.zero;
			}
			float num = _config.FrameTrackedObjectSmoothTime;
			float num2 = _frameTrackedObjectOffsetDuration - _config.FrameTrackedObjectSmoothTime;
			if (num2 >= 0f)
			{
				num2 /= _config.FrameTrackedObjectSmoothReduceRate;
				num = Mathf.SmoothStep(num, 0.001f, num2);
			}
			_currentFrameTrackedObjectOffset = Vector3.SmoothDamp(_currentFrameTrackedObjectOffset, _targetFrameTrackedObjectOffset, ref _frameTrackedObjectVelocity, num, float.PositiveInfinity, Time.unscaledDeltaTime);
			_transformComponent.position += _currentFrameTrackedObjectOffset;
		}

		public Vector3 GetOffset()
		{
			Quaternion quaternion = Quaternion.Euler(_currentPitch, _currentRotation, 0f);
			Vector2[] controlPoints = _config.PositionPath.ControlPoints;
			float t = _config.ZoomScalarPathDistanceCurve.Evaluate(_currentZoomScalar);
			Vector2 vector = CatmullRomSpline.EvaluateCatmullRomSpline(controlPoints, t);
			Vector3 vector2 = new Vector3(0f, vector.y, vector.x);
			return quaternion * (vector2 / controlPoints[controlPoints.Length - 2].y * _config.HeightAtFurthestZoom);
		}

		private static Vector3 ClampToBounds(Vector3 point, ConvexPolygon bounds)
		{
			if (bounds == null)
			{
				return point;
			}
			Vector2 vector = bounds.ClampToBounds(point.Xz());
			return new Vector3(vector.x, point.y, vector.y);
		}

		public void TrackObject(Transform objectToTrack)
		{
			_trackedObject = objectToTrack;
		}

		public void SetTrackedObjectFrame(Rect? frame)
		{
			_trackedObjectFrame = frame;
			_frameTrackedObjectOffsetDuration = 0f;
		}

		private void SetBounds(Vector3 min, Vector3 max)
		{
			_convexBounds = new ConvexPolygon();
			_convexBounds.Points.Add(new Vector2(min.x, min.z));
			_convexBounds.Points.Add(new Vector2(min.x, max.z));
			_convexBounds.Points.Add(new Vector2(max.x, max.z));
			_convexBounds.Points.Add(new Vector2(max.x, min.z));
			_convexBounds.Calculate();
		}

		public void SetBounds(List<Vector2> points, float border)
		{
			if (points.Count != 0)
			{
				while (points.Count < 3)
				{
					points.Add(points[0] + RandomUtils.RandomXZVector(0f - border, border).Xz());
				}
				ConvexPolygon convexPolygon = new ConvexPolygon();
				convexPolygon.Points.AddRange(points);
				convexPolygon.Calculate();
				_convexBounds = ConvexPolygon.Enlarge(convexPolygon, border);
				_convexBounds.Calculate();
			}
		}

		public void SetLevelBounds(WorldState worldState)
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("LevelBounds");
			for (int i = 0; i < array.Length; i++)
			{
				BoxCollider component = array[i].GetComponent<BoxCollider>();
				if (!(component == null))
				{
					SetBounds(component.center - component.size * 0.5f, component.center + component.size * 0.5f);
					return;
				}
			}
			SetBounds(new Vector3(worldState.Bounds.Min.X * 2, 0f, worldState.Bounds.Min.Y * 2), new Vector3(worldState.Bounds.Max.X * 2, 1f, worldState.Bounds.Max.Y * 2));
		}

		public override void Destroy()
		{
			_localPreferences.Video.OnAmbientOcclusionChange -= OnAmbientOcclusionChange;
			_localPreferences.Video.OnBloomChange -= OnBloomChange;
			_localPreferences.Video.OnAntialiasingChange -= OnAntialiasingChange;
			if (_cameraHeightFadeComponent != null)
			{
				_cameraHeightFadeComponent.Destroy();
			}
			_cutsceneCameraLogic.Destroy();
			UnityEngine.Object.Destroy(_gameObject);
			base.Destroy();
		}

		private void OnAmbientOcclusionChange(bool active)
		{
			if (_postProcessVolume != null && _postProcessVolume.profile.TryGetSettings<AmbientOcclusion>(out var outSetting))
			{
				outSetting.active = active;
			}
		}

		private void OnBloomChange(bool active)
		{
			if (_postProcessVolume != null && _postProcessVolume.profile.TryGetSettings<Bloom>(out var outSetting))
			{
				outSetting.active = active;
			}
		}

		private void OnDepthOfFieldChange(bool active)
		{
			if (_postProcessVolume != null && _postProcessVolume.profile.TryGetSettings<DepthOfField>(out var outSetting))
			{
				outSetting.active = active;
			}
		}

		private void OnAntialiasingChange(bool active)
		{
			if ((bool)PostProcessLayer)
			{
				PostProcessLayer.antialiasingMode = (_localPreferences.Video.Antialiasing ? PostProcessLayer.Antialiasing.FastApproximateAntialiasing : PostProcessLayer.Antialiasing.None);
			}
		}

		private void ApplyShadowDistance()
		{
			if (!_config.DynamicShadowDistance)
			{
				return;
			}
			Plane plane = new Plane(Vector3.up, new Vector3(0f, _shadowPlaneHeight, 0f));
			float num = 0f;
			for (int i = 0; i < 4; i++)
			{
				Vector3 direction = FrustumCorners[i];
				if (plane.Raycast(new Ray(CameraComponent.transform.position, direction), out var enter))
				{
					num = Mathf.Max(num, enter);
				}
			}
			num += _config.DynamicShadowDistanceBias;
			num = Mathf.Ceil(num / 10f) * 10f;
			num = Mathf.Clamp(num, 0f, _config.MaxDynamicShadowDistance);
			QualitySettings.shadowDistance = num;
			Shader.SetGlobalVector("_ShadowPlaneHeight", new Vector2(_shadowPlaneHeight, _shadowPlaneFadeDistance));
		}

		private void ApplyEffects()
		{
			CameraEffect[] components = _cameraComponent.GetComponents<CameraEffect>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].Apply(_cameraComponent);
			}
			if (_config.AutoDepthOfField && _postProcessVolume.profile.TryGetSettings<DepthOfField>(out var outSetting))
			{
				Plane plane = new Plane(Vector3.up, new Vector3(0f, _config.DepthOfFieldTargetPlaneHeight, 0f));
				Ray ray = new Ray(_transformComponent.position, _transformComponent.forward);
				if (plane.Raycast(ray, out var enter))
				{
					float value = Mathf.InverseLerp(_config.CloseDOFDistance, _config.FarDOFDistance, enter);
					value = Mathf.Clamp01(value);
					value = Mathf.Pow(value, Mathf.Max(0.0001f, _config.DOFLerpCurve));
					outSetting.aperture.value = Mathf.Lerp(_config.CloseDOFSetting.Aperture, _config.FarDOFSetting.Aperture, value);
					outSetting.focalLength.value = Mathf.Lerp(_config.CloseDOFSetting.FocalLength, _config.FarDOFSetting.FocalLength, value);
					outSetting.focusDistance.value = enter;
				}
			}
		}

		private float GetZoomCorrectedPanSpeed()
		{
			return _config.PanSpeed * Mathf.Lerp(1f, _config.PanSpeedZoomMultiplier, _currentZoomScalar);
		}

		private void DebugDraw()
		{
			DebugDrawUtils.ConvexPolygon(_convexBounds, Color.magenta);
		}

		public void ToggleCameraBounds()
		{
			_boundCamera = !_boundCamera;
		}
	}
}
