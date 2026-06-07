using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control a low pass audio filter over time. You'll need a MMAudioFilterReverbShaker on your filter.")]
	[FeedbackPath("Audio/Audio Filter Reverb")]
	[AddComponentMenu(null)]
	public class MMFeedbackAudioFilterReverb : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Reverb Feedback")]
		[Tooltip("the channel to emit on")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Tooltip("whether or not to add to the initial value")]
		[Header("Reverb")]
		public bool RelativeReverb;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeReverb;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-10000f, 2000f)]
		public float RemapReverbZero;

		[Range(-10000f, 2000f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapReverbOne;

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
