using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using Unity.Cinemachine;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Cinemachine/MMCinemachineClippingPlanesShaker")]
	[RequireComponent(typeof(CinemachineCamera))]
	public class MMCinemachineClippingPlanesShaker : MMShaker
	{
		[MMInspectorGroup("Clipping Planes", true, 45, false)]
		public bool RelativeClippingPlanes;

		[MMInspectorGroup("Near Plane", true, 46, false)]
		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeNear = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapNearZero = 0.3f;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapNearOne = 100f;

		[MMInspectorGroup("Far Plane", true, 47, false)]
		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeFar = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapFarZero = 1000f;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapFarOne = 1000f;

		protected CinemachineCamera _targetCamera;

		protected float _initialNear;

		protected float _initialFar;

		protected float _originalShakeDuration;

		protected bool _originalRelativeClippingPlanes;

		protected AnimationCurve _originalShakeNear;

		protected float _originalRemapNearZero;

		protected float _originalRemapNearOne;

		protected AnimationCurve _originalShakeFar;

		protected float _originalRemapFarZero;

		protected float _originalRemapFarOne;

		protected override void Initialization()
		{
			base.Initialization();
			_targetCamera = base.gameObject.GetComponent<CinemachineCamera>();
		}

		protected virtual void Reset()
		{
			ShakeDuration = 0.5f;
		}

		protected override void Shake()
		{
			float near = ShakeFloat(ShakeNear, RemapNearZero, RemapNearOne, RelativeClippingPlanes, _initialNear);
			float far = ShakeFloat(ShakeFar, RemapFarZero, RemapFarOne, RelativeClippingPlanes, _initialFar);
			SetNearFar(near, far);
		}

		protected virtual void SetNearFar(float near, float far)
		{
			_targetCamera.Lens.NearClipPlane = near;
			_targetCamera.Lens.FarClipPlane = far;
		}

		protected override void GrabInitialValues()
		{
			_initialNear = _targetCamera.Lens.NearClipPlane;
			_initialFar = _targetCamera.Lens.FarClipPlane;
		}

		public virtual void OnMMCameraClippingPlanesShakeEvent(AnimationCurve animNearCurve, float duration, float remapNearMin, float remapNearMax, AnimationCurve animFarCurve, float remapFarMin, float remapFarMax, bool relativeValues = false, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
		{
			if (!CheckEventAllowed(channelData))
			{
				return;
			}
			if (stop)
			{
				Stop();
			}
			else if (restore)
			{
				ResetTargetValues();
			}
			else if (Interruptible || !Shaking)
			{
				_resetShakerValuesAfterShake = resetShakerValuesAfterShake;
				_resetTargetValuesAfterShake = resetTargetValuesAfterShake;
				if (resetShakerValuesAfterShake)
				{
					_originalShakeDuration = ShakeDuration;
					_originalShakeNear = ShakeNear;
					_originalShakeFar = ShakeFar;
					_originalRemapNearZero = RemapNearZero;
					_originalRemapNearOne = RemapNearOne;
					_originalRemapFarZero = RemapFarZero;
					_originalRemapFarOne = RemapFarOne;
					_originalRelativeClippingPlanes = RelativeClippingPlanes;
				}
				if (!OnlyUseShakerValues)
				{
					TimescaleMode = timescaleMode;
					ShakeDuration = duration;
					ShakeNear = animNearCurve;
					RemapNearZero = remapNearMin * feedbacksIntensity;
					RemapNearOne = remapNearMax * feedbacksIntensity;
					ShakeFar = animFarCurve;
					RemapFarZero = remapFarMin * feedbacksIntensity;
					RemapFarOne = remapFarMax * feedbacksIntensity;
					RelativeClippingPlanes = relativeValues;
					ForwardDirection = forwardDirection;
				}
				Play();
			}
		}

		protected override void ResetTargetValues()
		{
			base.ResetTargetValues();
			SetNearFar(_initialNear, _initialFar);
		}

		protected override void ResetShakerValues()
		{
			base.ResetShakerValues();
			ShakeDuration = _originalShakeDuration;
			ShakeNear = _originalShakeNear;
			ShakeFar = _originalShakeFar;
			RemapNearZero = _originalRemapNearZero;
			RemapNearOne = _originalRemapNearOne;
			RemapFarZero = _originalRemapFarZero;
			RemapFarOne = _originalRemapFarOne;
			RelativeClippingPlanes = _originalRelativeClippingPlanes;
		}

		public override void StartListening()
		{
			base.StartListening();
			MMCameraClippingPlanesShakeEvent.Register(OnMMCameraClippingPlanesShakeEvent);
		}

		public override void StopListening()
		{
			base.StopListening();
			MMCameraClippingPlanesShakeEvent.Unregister(OnMMCameraClippingPlanesShakeEvent);
		}
	}
}
