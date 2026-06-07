using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you control the pitch of a target AudioSource over time.")]
	[FeedbackPath("Audio/AudioSource Pitch")]
	public class MMFeedbackAudioSourcePitch : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Pitch Feedback")]
		[Tooltip("the channel to emit on")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Tooltip("whether or not to add to the initial value")]
		[Header("Pitch")]
		public bool RelativePitch;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve PitchTween;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-3f, 3f)]
		public float RemapPitchZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-3f, 3f)]
		public float RemapPitchOne;

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
