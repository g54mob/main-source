using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using Unity.Cinemachine;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Cinemachine/MMCinemachineFieldOfViewShaker")]
	[RequireComponent(typeof(CinemachineCamera))]
	public class MMCinemachineFieldOfViewShaker : MMShaker
	{
		[MMInspectorGroup("Field of view", true, 41, false)]
		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeFieldOfView;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeFieldOfView = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(0f, 179f)]
		public float RemapFieldOfViewZero = 60f;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(0f, 179f)]
		public float RemapFieldOfViewOne = 120f;

		protected CinemachineCamera _targetCamera;

		protected float _initialFieldOfView;

		protected float _originalShakeDuration;

		protected bool _originalRelativeFieldOfView;

		protected AnimationCurve _originalShakeFieldOfView;

		protected float _originalRemapFieldOfViewZero;

		protected float _originalRemapFieldOfViewOne;

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
			float fieldOfView = ShakeFloat(ShakeFieldOfView, RemapFieldOfViewZero, RemapFieldOfViewOne, RelativeFieldOfView, _initialFieldOfView);
			SetFieldOfView(fieldOfView);
		}

		protected virtual void SetFieldOfView(float newFieldOfView)
		{
			_targetCamera.Lens.FieldOfView = newFieldOfView;
		}

		protected override void GrabInitialValues()
		{
			_initialFieldOfView = _targetCamera.Lens.FieldOfView;
		}

		public virtual void OnMMCameraFieldOfViewShakeEvent(AnimationCurve distortionCurve, float duration, float remapMin, float remapMax, bool relativeDistortion = false, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
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
					_originalShakeFieldOfView = ShakeFieldOfView;
					_originalRemapFieldOfViewZero = RemapFieldOfViewZero;
					_originalRemapFieldOfViewOne = RemapFieldOfViewOne;
					_originalRelativeFieldOfView = RelativeFieldOfView;
				}
				if (!OnlyUseShakerValues)
				{
					TimescaleMode = timescaleMode;
					ShakeDuration = duration;
					ShakeFieldOfView = distortionCurve;
					RemapFieldOfViewZero = remapMin * feedbacksIntensity;
					RemapFieldOfViewOne = remapMax * feedbacksIntensity;
					RelativeFieldOfView = relativeDistortion;
					ForwardDirection = forwardDirection;
				}
				Play();
			}
		}

		protected override void ResetTargetValues()
		{
			base.ResetTargetValues();
			SetFieldOfView(_initialFieldOfView);
		}

		protected override void ResetShakerValues()
		{
			base.ResetShakerValues();
			ShakeDuration = _originalShakeDuration;
			ShakeFieldOfView = _originalShakeFieldOfView;
			RemapFieldOfViewZero = _originalRemapFieldOfViewZero;
			RemapFieldOfViewOne = _originalRemapFieldOfViewOne;
			RelativeFieldOfView = _originalRelativeFieldOfView;
		}

		public override void StartListening()
		{
			base.StartListening();
			MMCameraFieldOfViewShakeEvent.Register(OnMMCameraFieldOfViewShakeEvent);
		}

		public override void StopListening()
		{
			base.StopListening();
			MMCameraFieldOfViewShakeEvent.Unregister(OnMMCameraFieldOfViewShakeEvent);
		}
	}
}
