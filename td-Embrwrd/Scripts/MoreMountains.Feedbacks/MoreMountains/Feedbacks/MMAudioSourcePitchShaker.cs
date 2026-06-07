using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[RequireComponent(typeof(AudioSource))]
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Audio/MMAudioSourcePitchShaker")]
	public class MMAudioSourcePitchShaker : MMShaker
	{
		[Tooltip("whether or not to add to the initial value")]
		[MMInspectorGroup("Pitch", true, 57)]
		public bool RelativePitch;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakePitch;

		[Range(-3f, 3f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapPitchZero;

		[Range(-3f, 3f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapPitchOne;

		protected AudioSource _targetAudioSource;

		protected float _initialPitch;

		protected float _originalShakeDuration;

		protected bool _originalRelativePitch;

		protected AnimationCurve _originalShakePitch;

		protected float _originalRemapPitchZero;

		protected float _originalRemapPitchOne;

		protected override void Initialization()
		{
		}

		protected virtual void Reset()
		{
		}

		protected override void Shake()
		{
		}

		protected override void GrabInitialValues()
		{
		}

		public virtual void OnMMAudioSourcePitchShakeEvent(AnimationCurve pitchCurve, float duration, float remapMin, float remapMax, bool relativePitch = false, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
		{
		}

		protected override void ResetTargetValues()
		{
		}

		protected override void ResetShakerValues()
		{
		}

		public override void StartListening()
		{
		}

		public override void StopListening()
		{
		}
	}
}
