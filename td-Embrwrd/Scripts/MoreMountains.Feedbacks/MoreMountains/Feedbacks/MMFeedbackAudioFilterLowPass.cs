using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control a low pass audio filter over time. You'll need a MMAudioFilterLowPassShaker on your filter.")]
	[FeedbackPath("Audio/Audio Filter Low Pass")]
	[AddComponentMenu(null)]
	public class MMFeedbackAudioFilterLowPass : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the channel to emit on")]
		[Header("Low Pass Feedback")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Header("Low Pass")]
		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeLowPass;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeLowPass;

		[Range(10f, 22000f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapLowPassZero;

		[Range(10f, 22000f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapLowPassOne;

		public override float FeedbackDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
