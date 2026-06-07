using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMPaniniProjectionShaker_URP")]
	[RequireComponent(typeof(Volume))]
	public class MMPaniniProjectionShaker_URP : MMShaker
	{
		[Tooltip("whether or not to add to the initial value")]
		[MMInspectorGroup("Distance", true, 62)]
		public bool RelativeDistance;

		[Tooltip("the curve used to animate the distance value on")]
		public AnimationCurve ShakeDistance;

		[Range(0f, 1f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapDistanceZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(0f, 1f)]
		public float RemapDistanceOne;

		protected Volume _volume;

		protected PaniniProjection _paniniProjection;

		protected float _initialDistance;

		protected float _originalShakeDuration;

		protected AnimationCurve _originalShakeDistance;

		protected float _originalRemapDistanceZero;

		protected float _originalRemapDistanceOne;

		protected bool _originalRelativeDistance;

		protected override void Initialization()
		{
		}

		protected override void Shake()
		{
		}

		protected override void GrabInitialValues()
		{
		}

		public virtual void OnPaniniProjectionShakeEvent(AnimationCurve distance, float duration, float remapMin, float remapMax, bool relativeDistance = false, float attenuation = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
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
