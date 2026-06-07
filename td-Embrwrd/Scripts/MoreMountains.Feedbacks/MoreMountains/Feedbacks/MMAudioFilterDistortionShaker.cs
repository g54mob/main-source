using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Audio/MMAudioFilterDistortionShaker")]
	[RequireComponent(typeof(AudioDistortionFilter))]
	public class MMAudioFilterDistortionShaker : MMShaker
	{
		[MMInspectorGroup("Distortion", true, 51)]
		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeDistortion;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeDistortion;

		[Range(0f, 1f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapDistortionZero;

		[Range(0f, 1f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapDistortionOne;

		protected AudioDistortionFilter _targetAudioDistortionFilter;

		protected float _initialDistortion;

		protected float _originalShakeDuration;

		protected bool _originalRelativeDistortion;

		protected AnimationCurve _originalShakeDistortion;

		protected float _originalRemapDistortionZero;

		protected float _originalRemapDistortionOne;

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

		public virtual void OnMMAudioFilterDistortionShakeEvent(AnimationCurve distortionCurve, float duration, float remapMin, float remapMax, bool relativeDistortion = false, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
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
