using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackPath("Audio/AudioSource Stereo Pan")]
	[FeedbackHelp("This feedback lets you control the stereo pan of a target AudioSource over time.")]
	public class MMFeedbackAudioSourceStereoPan : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("StereoPan Feedback")]
		[Tooltip("the channel to emit on")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Tooltip("whether or not to add to the initial value")]
		[Header("StereoPan")]
		public bool RelativeStereoPan;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeStereoPan;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-1f, 1f)]
		public float RemapStereoPanZero;

		[Range(-1f, 1f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapStereoPanOne;

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
