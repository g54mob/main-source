using System;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	public class StandardCameraRig : CameraRigBase
	{
		[Header("Panning")]
		public AnimationCurve panRangeCurve;

		[Range(0.1f, 20f)]
		public float feedbackSpeed;

		[Range(0.001f, 1f)]
		public float edgePanReduction;

		private Vector3 _panStartCenter;

		private Vector3? _currentPanPosition;

		[Range(1f, 500f)]
		public float keyPanningSpeed;

		[Header("Zoom/Panning")]
		[Tooltip("X0 is min zoom, X1 is max zoom. High Y numbers means faster panning")]
		public AnimationCurve mousePanFactor;

		[Tooltip("X0 is min zoom, X1 is max zoom. High Y numbers means faster panning")]
		public AnimationCurve keyPanFactor;

		public AnimationCurve moveMaxMagnitudePerZoom;

		[SerializeField]
		private float _maxPanSpeed;

		[Header("Zoom")]
		[Range(1f, 30f)]
		public float perspectiveZoomSegments;

		[Range(-5000f, 400f)]
		public float zoomIn;

		[Range(-5000f, 400f)]
		public float zoomOut;

		[Range(0.1f, 2f)]
		public float zoomDuration;

		public Ease zoomEase;

		private float _zoomTarget;

		private Tween _zoomTween;

		private float _zoomTweenTarget;

		[Header("Rotation")]
		public bool lockRotation;

		private Vector3 _rotationPoint;

		private float _rotationIncrementDegree;

		private float _rotationDegreeChange;

		public float freeRotateSpeed;

		private bool _wasFreeRotating;

		private float _rotationDegreeTotal;

		private float _rotationTime;

		[Header("TiltPivot")]
		public AnimationCurve tiltZoomCurve;

		private Vector2 _previousMoveWithMouseValue;

		private float _rotationAnimationDuration;

		private float _freeRotationAnimationDuration;

		private Vector3 _targetPanPosition;

		private Vector3 _panVelocity;

		private float panSmoothTime;

		private Vector4 _edgeSizePercentage;

		private float _edgePanningTime;

		private float _edgePanningDuration;

		private Color edgeColor;

		public bool showEdgePanOverlay;

		private Vector4 _lastEdgeValues;

		private Vector3? _zoomLookAtTarget;

		private Vector3 _zoomLookAtTargetMousePosition;

		private float _lastTimeZoomInput;

		private float _zoomInputValue;

		private float _keyboardZoomSpeed;

		private float _keyboardHoldZoomTime;

		[SerializeField]
		private GameObject _followTarget;

		private bool _isTargetInFrame;

		private float _followTargetHeightOffset;

		private Vector3 _followTargetVelocity;

		private float _followTargetTweenProgress;

		private float _previousZoomTarget;

		private GameObject currentDissolveController;

		private GameObject currentLevelEdgeDissolveController;

		public Transform cameraShakeTarget;

		private Transform shakeSource;

		private int distanceFalloff;

		private Vector3 shakeAmount;

		public float minTimeBetweenShakes;

		public float maxTimeBetweenShakes;

		private float distanceFromSource;

		private bool shake;

		public AnimationCurve earthquakeIntensityCurve;

		private bool earthquake;

		private float earthquakeIntensity;

		public ParticleSystem earthquakeScreenParticles;

		private float earthquakeParticlesRate;

		private bool _keyPanningStarted;

		private bool IsUsingMouseRotation => false;

		private bool IsKeyPanning => false;

		private bool IsEdgePanning { get; set; }

		private bool IsUsingZoomMouseMode => false;

		public GameObject FollowTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[field: SerializeField]
		public float CameraFollowSpeed { get; set; }

		[field: SerializeField]
		public float FollowTargetBoundryPadding { get; set; }

		[field: SerializeField]
		public float FollowSmoothTime { get; set; }

		public bool IsEarthquakeActive => false;

		public event EventHandler FollowTargetChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler TargetInFrame
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public bool IsRotating()
		{
			return false;
		}

		public bool IsPanning()
		{
			return false;
		}

		public new void Awake()
		{
		}

		private void Start()
		{
		}

		private void PerformZoomInput(float direction)
		{
		}

		public override void ReleaseControls()
		{
		}

		private void OnDialogOpening(object sender, EventArgs e)
		{
		}

		protected override void ResetInputState()
		{
		}

		private float GetCurrentZoomFactor()
		{
			return 0f;
		}

		private void ResetDefaultValues()
		{
		}

		protected override void ClearCameraTweens()
		{
		}

		protected override void UpdateCamera()
		{
		}

		protected override void OnCameraUpdateFinished()
		{
		}

		protected override void HideTooltipsIfMoving()
		{
		}

		private bool IsTiltControlsEnabled()
		{
			return false;
		}

		private void UpdateZoomTilt()
		{
		}

		private Vector3 GetRotationPivotPoint()
		{
			return default(Vector3);
		}

		private void UpdateFreeRotate(float delta)
		{
		}

		public void SetRotationDegree(float rotationDegree, bool snapToIncrementDegree = true)
		{
		}

		private void AdjustRotationDegree(float adjustmentDegree, Vector3 rotationPoint, bool snapToIncrementDegree = true)
		{
		}

		private void UpdateRotate()
		{
		}

		private void RotateCamera(float rotationDelta)
		{
		}

		private void RotateCamera(float rotationDelta, Vector3 rotationPoint)
		{
		}

		private float CalculateRotationDelta()
		{
			return 0f;
		}

		private static float RotationEasing_CircEaseInOut(float time, float startingValue, float finishValue, float animationDuration)
		{
			return 0f;
		}

		private static float RotationEasing_QuadEaseOut(float time, float startingValue, float finishValue, float animationDuration)
		{
			return 0f;
		}

		private void ApplyMoveVector(Vector3 moveVector, bool withAcceleration = true)
		{
		}

		private void SetPanPosition(Vector3 position)
		{
		}

		private Vector3 CalculateMoveVector(Vector3 newVector, Vector3 previousVector)
		{
			return default(Vector3);
		}

		private void StartNewPan(Vector3 startingPosition)
		{
		}

		private void UpdatePan()
		{
		}

		private void UpdateEdgePanning()
		{
		}

		private void OnGUI()
		{
		}

		private void UpdateKeyPanning()
		{
		}

		private void UpdateMousePanning()
		{
		}

		private void UpdateZoomControls(float direction)
		{
		}

		private void UpdateZoomTargets()
		{
		}

		private void UpdateZoom()
		{
		}

		private void UpdateZoomTween(Ease easing, float overrideDuration = -1f)
		{
		}

		private void UpdatePositionAfterZoom()
		{
		}

		private float CalculateZoomPercentage(float position)
		{
			return 0f;
		}

		private void SetCameraZoom(float position, bool updatePositionAndRotation = true)
		{
		}

		private bool PanKeyIsHeld()
		{
			return false;
		}

		private bool MousePanningEnabled()
		{
			return false;
		}

		private bool KeyPanningEnabled()
		{
			return false;
		}

		private bool ZoomControlsEnabled()
		{
			return false;
		}

		private bool RotateControlsEnabled()
		{
			return false;
		}

		private void SmoothFollowTarget(GameObject followGameObject)
		{
		}

		private void TriggerTargetInFrame()
		{
		}

		public void RevertZoomLevel()
		{
		}

		public void SetZoomLevel(float zoomInPercentage, bool snapToSegment = true, bool tween = false, float tweenDuration = -1f, Ease easing = Ease.OutSine)
		{
		}

		public void UpdateAfterCustomMovement()
		{
		}

		public void ResetPosition()
		{
		}

		public override CameraTransformData GetCameraTransformData()
		{
			return null;
		}

		public override void SetCameraTransformData(CameraTransformData cameraTransformData)
		{
		}

		public override void ForceRotate(float rotationDegree)
		{
		}

		public void ForceStartNewPan()
		{
		}

		public override void ForcePan(Vector3 panDelta)
		{
		}

		[ContextMenu("Create Cam Config Here")]
		public void CreateCameraConfigHere()
		{
		}

		public void ApplyCameraConfig(CameraLevelConfig config)
		{
		}

		public void StartEarthquake()
		{
		}

		public void StopEarthquake()
		{
		}

		public void StartShake(Transform shakeSourceTransform)
		{
		}

		public void StopShake()
		{
		}

		private void UpdateCameraShake()
		{
		}

		public void UpdateEarthquakeEffect(float progress, float intensity)
		{
		}

		public override void FocusOnLocation(Vector3 position, bool tween = false)
		{
		}

		protected override void UpdateTweens()
		{
		}

		private void TweenToNewPosition()
		{
		}

		[ContextMenu("Trigger Chaos Event Camera Shake")]
		public void TriggerChaosEventCameraShake()
		{
		}

		public override void SetFollowTarget(Transform transformRoot, float heightOffset = 0f)
		{
		}
	}
}
