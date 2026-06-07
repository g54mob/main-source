using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control a high pass audio filter over time. You'll need a MMAudioFilterHighPassShaker on your filter.")]
	[FeedbackPath("Audio/Audio Filter High Pass")]
	[AddComponentMenu(null)]
	public class MMFeedbackAudioFilterHighPass : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("High Pass Feedback")]
		[Tooltip("the channel to emit on")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Header("High Pass")]
		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeHighPass;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeHighPass;

		[Range(10f, 22000f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapHighPassZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(10f, 22000f)]
		public float RemapHighPassOne;

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
