using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gh
{
	public abstract class CameraRigBase : MonoBehaviour
	{
		public enum ControlMode
		{
			Full = 0,
			SecondaryInteractAndKeysOnly = 1,
			Frozen = 2
		}

		[SerializeField]
		protected BasicAnimationEventObserver _animationEventObserver;

		[SerializeField]
		protected Animator _animator;

		[SerializeField]
		private CinematicCinemaBars3DUIView _cinemaBars;

		private float _fovTweenDuration;

		private Tween _fovTween;

		public List<MonoBehaviour> enabledWhenInMotion;

		public float motionScriptsMagnitudeThreshold;

		protected Vector3 _lastCradlePosition;

		protected InputAction _moveAction;

		protected InputAction _moveWithMouseAction;

		private Vector3 _lastPosition;

		public const float CameraPrecision = 1E-05f;

		private float _lastUpdateTime;

		protected static float CAMERA_DELTA_TIME;

		protected bool _inputConsumptionUpdate;

		protected Vector2 _mouseStartPosition;

		protected float _panScreenThreshold;

		protected bool _mouseMoveStarted;

		private float _zoomLevel;

		protected Tween _moveTween;

		private float _cinematicFocusTransitionTime;

		private Ease _cinematicFocusTransitionEase;

		[SerializeField]
		private float _locationFocusTransitionTime;

		[SerializeField]
		private Ease _locationFocusTransitionEase;

		[SerializeField]
		protected Transform _attachedAudioListener;

		public float listenerScreenHeightOffsetPercentage;

		public BasicAnimationEventObserver AnimationObserver => null;

		public CinematicCinemaBars3DUIView CinemaBars => null;

		public bool IsCinemaBarsActive => false;

		public bool IsFreeRotating { get; protected set; }

		public float TargetFOV { get; private set; }

		public bool IsAnimating => false;

		public bool MotionScriptsEnabled { get; set; }

		public Camera Camera { get; private set; }

		public Transform CameraCradle { get; private set; }

		public float ZoomLevel
		{
			get
			{
				return 0f;
			}
			protected set
			{
			}
		}

		public Transform AudioListenerTransform => null;

		public ControlMode CurrentControlMode { get; protected set; }

		public float AnimationSpeed { get; private set; }

		public event EventHandler ZoomPercentageChanged
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

		public virtual void TriggerAnimator(string key)
		{
		}

		public void SetCameraRoll(float rollDegree)
		{
		}

		public void SetCameraFOV(float targetFOV, bool animate = true)
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		private void OnLoadingScreenClosing(object sender, EventArgs e)
		{
		}

		private void OnOpenStateChanged(object sender, EventArgs e)
		{
		}

		private void OnDialogChanged(object sender, EventArgs e)
		{
		}

		private void UpdateCinemaBarState()
		{
		}

		private void SetCinemaBarVisibleState(bool isOpen)
		{
		}

		public virtual Vector3 GetCameraLookAtTarget()
		{
			return default(Vector3);
		}

		protected Vector3 GetTargetPosition(Vector3 screenPosition)
		{
			return default(Vector3);
		}

		public Vector3 GetPositionDelta()
		{
			return default(Vector3);
		}

		public bool IsMoving()
		{
			return false;
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		protected virtual void OnCameraUpdateStarted()
		{
		}

		protected virtual void OnCameraUpdateFinished()
		{
		}

		protected virtual void UpdateCamera()
		{
		}

		public bool CanCameraUpdate()
		{
			return false;
		}

		protected virtual void UpdateTweens()
		{
		}

		protected virtual void HideTooltipsIfMoving()
		{
		}

		public bool IsMousePanThresholdExceeded()
		{
			return false;
		}

		public void EnableMotionScripts(bool isEnabled)
		{
		}

		protected virtual void UpdateMotionScripts()
		{
		}

		public void ResetProjectionMatrices()
		{
		}

		protected Action<InputAction.CallbackContext> StartedCameraInputWrapper(Action<InputAction.CallbackContext> action)
		{
			return null;
		}

		protected Action<InputAction.CallbackContext> CanceledCameraInputWrapper(Action<InputAction.CallbackContext> action)
		{
			return null;
		}

		public abstract void ForceRotate(float rotationDegree);

		public abstract void ForcePan(Vector3 panDelta);

		private Vector3 GetTargetFocusPoint(GameObject newTarget)
		{
			return default(Vector3);
		}

		public void FocusOnLocation(GameObject newTarget, bool tween = false)
		{
		}

		public void CinematicFocusOnLocation(GameObject newTarget, Action onFinished)
		{
		}

		public void CinematicFocusOnLocation(Vector3 position, Action onFinished)
		{
		}

		public virtual void FocusOnLocation(Vector3 position, bool tween = false)
		{
		}

		private Tween CreateLocationFocusTween(Vector3 newPosition, float time, Ease ease)
		{
			return null;
		}

		protected Vector3 CalculateMiddleOfScreen()
		{
			return default(Vector3);
		}

		protected virtual void ResetInputState()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void ClearCameraTweens()
		{
		}

		protected virtual void UpdateAudioListener()
		{
		}

		public abstract CameraTransformData GetCameraTransformData();

		public abstract void SetCameraTransformData(CameraTransformData cameraTransformData);

		public virtual void SetCameraControlMode(ControlMode controlMode)
		{
		}

		public abstract void ReleaseControls();

		protected void SetAnimationSpeed(float speed)
		{
		}

		public void FastForwardAnimation()
		{
		}

		public void UpdateAudioValues()
		{
		}

		public abstract void SetFollowTarget(Transform transformRoot, float heightOffset = 0f);
	}
}
