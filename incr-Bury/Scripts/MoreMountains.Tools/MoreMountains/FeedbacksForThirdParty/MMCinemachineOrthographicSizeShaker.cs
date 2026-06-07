using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using Unity.Cinemachine;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Cinemachine/MM Cinemachine Orthographic Size Shaker")]
	[RequireComponent(typeof(CinemachineCamera))]
	public class MMCinemachineOrthographicSizeShaker : MMShaker
	{
		[MMInspectorGroup("Orthographic Size", true, 43, false)]
		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeOrthographicSize;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeOrthographicSize = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapOrthographicSizeZero = 5f;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapOrthographicSizeOne = 10f;

		protected CinemachineCamera _targetCamera;

		protected float _initialOrthographicSize;

		protected float _originalShakeDuration;

		protected bool _originalRelativeOrthographicSize;

		protected AnimationCurve _originalShakeOrthographicSize;

		protected float _originalRemapOrthographicSizeZero;

		protected float _originalRemapOrthographicSizeOne;

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
			float orthographicSize = ShakeFloat(ShakeOrthographicSize, RemapOrthographicSizeZero, RemapOrthographicSizeOne, RelativeOrthographicSize, _initialOrthographicSize);
			_targetCamera.Lens.OrthographicSize = orthographicSize;
		}

		protected override void GrabInitialValues()
		{
			_initialOrthographicSize = _targetCamera.Lens.OrthographicSize;
		}

		public virtual void OnMMCameraOrthographicSizeShakeEvent(AnimationCurve distortionCurve, float duration, float remapMin, float remapMax, bool relativeDistortion = false, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
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
					_originalShakeOrthographicSize = ShakeOrthographicSize;
					_originalRemapOrthographicSizeZero = RemapOrthographicSizeZero;
					_originalRemapOrthographicSizeOne = RemapOrthographicSizeOne;
					_originalRelativeOrthographicSize = RelativeOrthographicSize;
				}
				if (!OnlyUseShakerValues)
				{
					TimescaleMode = timescaleMode;
					ShakeDuration = duration;
					ShakeOrthographicSize = distortionCurve;
					RemapOrthographicSizeZero = remapMin * feedbacksIntensity;
					RemapOrthographicSizeOne = remapMax * feedbacksIntensity;
					RelativeOrthographicSize = relativeDistortion;
					ForwardDirection = forwardDirection;
				}
				Play();
			}
		}

		protected override void ResetTargetValues()
		{
			base.ResetTargetValues();
			_targetCamera.Lens.OrthographicSize = _initialOrthographicSize;
		}

		protected override void ResetShakerValues()
		{
			base.ResetShakerValues();
			ShakeDuration = _originalShakeDuration;
			ShakeOrthographicSize = _originalShakeOrthographicSize;
			RemapOrthographicSizeZero = _originalRemapOrthographicSizeZero;
			RemapOrthographicSizeOne = _originalRemapOrthographicSizeOne;
			RelativeOrthographicSize = _originalRelativeOrthographicSize;
		}

		public override void StartListening()
		{
			base.StartListening();
			MMCameraOrthographicSizeShakeEvent.Register(OnMMCameraOrthographicSizeShakeEvent);
		}

		public override void StopListening()
		{
			base.StopListening();
			MMCameraOrthographicSizeShakeEvent.Unregister(OnMMCameraOrthographicSizeShakeEvent);
		}
	}
}
