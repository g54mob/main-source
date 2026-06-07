using System;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	public class FreeCameraRig : CameraRigBase
	{
		public const float DEFAULT_FOV_DIFF = 10f;

		public float mouseMoveSpeed;

		[Tooltip("Left/Right, Up/Down, Forward/Backward")]
		public Vector3 keyboardMoveSpeed;

		public float mouseRotateSpeedX;

		public float mouseRotateSpeedY;

		public float zoomSpeed;

		[SerializeField]
		private float _minRotationTargetDistance;

		[SerializeField]
		private float _panSmoothTime;

		[SerializeField]
		private float _orbitSmoothTime;

		[SerializeField]
		private float _zoomSmoothTime;

		private Vector3 _keyPanMoveInputVector;

		private Vector3 _targetMoveVector;

		private Vector3 _targetOrbitVector;

		private float _zoomInputAmount;

		private float _targetZoomAmount;

		private float _zoomAmount;

		[SerializeField]
		private float _maxZoomHeight;

		private bool _isFocusMode;

		private bool _isFreeRotateStarted;

		private float _zoomInputValue;

		public LayerMask focusableLayers;

		protected Vector2 _orbitMouseStartPosition;

		protected float _orbitScreenThreshold;

		private bool _scrolledDuringOrbit;

		private bool _waitingToSnapToHandle;

		private float _followTargetHeightOffset;

		[SerializeField]
		private GameObject _onFocusedEffect;

		public float _lookAtTweenDuration;

		public Ease easeType;

		private Tween _lookAtTween;

		private Vector3 _currentOrbitVelocity;

		private Vector3 _currentMoveVelocity;

		private Vector3 _currentPanAcceleration;

		private float _currentZoomVelocity;

		private float _currentZoomAcceleration;

		public AnimationCurve targetDistanceZoomMultiplier;

		public AnimationCurve targetDistancePanMultiplier;

		public AnimationCurve targetDistanceMousePanMultiplier;

		public AnimationCurve targetDistanceKeyPanMultiplier;

		public float panAccelerationRate;

		public float zoomAccelerationRate;

		private Transform _defaultRotationTarget;

		private float _rotationTargetDistance;

		public GameObject RotationTarget;

		private Transform _followTarget;

		private Sequence _animationSequence;

		private float _currentAnimationTime;

		private Quaternion _lastCradleRotation;

		public float motionScriptsRotationThreshold;

		public bool IsOrbiting => false;

		private Transform DefaultRotationTarget => null;

		public bool IsCameraAnimActive => false;

		public Tween AnimationTween { get; private set; }

		public AnimationClip AnimationClip { get; private set; }

		public static event EventHandler OrbitTargetPicked
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

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void PerformZoomWithInput(float inputMultiplier)
		{
		}

		private void OnUIReset(object sender, EventArgs e)
		{
		}

		public override void ReleaseControls()
		{
		}

		private void OnDialogOpening(object sender, EventArgs e)
		{
		}

		private void SetFocusTarget()
		{
		}

		public bool IsOrbitThresholdExceeded()
		{
			return false;
		}

		private void SnapToHandle()
		{
		}

		private void SnapToHandleInternal()
		{
		}

		private void OnGizmoSnapped(object sender, EventArgs e)
		{
		}

		private void OnSyncedEntitiesChanged(object sender, EventArgs e)
		{
		}

		private void OnMovementMade(object sender, EventArgs e)
		{
		}

		protected override void OnDisable()
		{
		}

		private void ResetState()
		{
		}

		private void FollowTarget(Transform target)
		{
		}

		private void UpdateFollowTarget(Transform followTarget)
		{
		}

		public override void SetFollowTarget(Transform transformRoot, float heightOffset = 0f)
		{
		}

		private void FocusTarget(Transform target)
		{
		}

		private void SetRotationTarget(Vector3 position, bool animate = false)
		{
		}

		private void ApplyFocusModeListeners()
		{
		}

		private void ClearListeners()
		{
		}

		private void UnfocusTarget(bool showMessage = true)
		{
		}

		private void UnfollowTarget()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnSelectableChanged(object sender, EventArgs e)
		{
		}

		protected override void UpdateCamera()
		{
		}

		protected override void UpdateTweens()
		{
		}

		public void CalculateRotationTargetDistance()
		{
		}

		public void UpdateRotationTarget()
		{
		}

		private void OnEnable()
		{
		}

		private void InitLookAtTarget()
		{
		}

		public override Vector3 GetCameraLookAtTarget()
		{
			return default(Vector3);
		}

		public void SetTargetDistance(float dataAudioListenerDistanceOverride)
		{
		}

		public override void TriggerAnimator(string key)
		{
		}

		public override void ForcePan(Vector3 panDelta)
		{
		}

		public void ForceZoom(float zoomDelta)
		{
		}

		public override void ForceRotate(float rotationDegree)
		{
		}

		public override void FocusOnLocation(Vector3 position, bool tween = false)
		{
		}

		public override void SetCameraControlMode(ControlMode controlMode)
		{
		}

		public void UpdateRotationTargetVisualState()
		{
		}

		protected override void UpdateAudioListener()
		{
		}

		public override CameraTransformData GetCameraTransformData()
		{
			return null;
		}

		public override void SetCameraTransformData(CameraTransformData cameraTransformData)
		{
		}

		public void SkipAnimation()
		{
		}

		public void PlayAnimationClip(AnimationClip animationClip)
		{
		}

		private void UpdateAnimationClip(float deltaTime)
		{
		}

		public void ClearAnimations()
		{
		}

		public void PlayTween(Tween seq)
		{
		}

		private void UpdateTween(float deltaTime)
		{
		}

		protected override void UpdateMotionScripts()
		{
		}

		public void TweenToPreset(DirectorsToolbar3DUIView.CameraPresetData levelPositionPreset, Action onComplete, Ease tavernFocusEase, float tavernFocusDuration)
		{
		}
	}
}
