using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackHelp("This feedback allows you to control channel mixer's red, green and blue over time.It requires you have in your scene an object with a Volumewith Channel Mixer active, and a MMChannelMixerShaker_HDRP component.")]
	[FeedbackPath("PostProcess/Channel Mixer HDRP")]
	[AddComponentMenu(null)]
	public class MMFeedbackChannelMixer_HDRP : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the channel to emit on")]
		[Header("Color Grading")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float ShakeDuration;

		[Tooltip("whether or not to add to the initial intensity")]
		public bool RelativeIntensity;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Tooltip("the curve used to animate the red value on")]
		[Header("Red")]
		public AnimationCurve ShakeRed;

		[Range(-200f, 200f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapRedZero;

		[Range(-200f, 200f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapRedOne;

		[Tooltip("the curve used to animate the green value on")]
		[Header("Green")]
		public AnimationCurve ShakeGreen;

		[Range(-200f, 200f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapGreenZero;

		[Range(-200f, 200f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapGreenOne;

		[Tooltip("the curve used to animate the blue value on")]
		[Header("Blue")]
		public AnimationCurve ShakeBlue;

		[Range(-200f, 200f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapBlueZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-200f, 200f)]
		public float RemapBlueOne;

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
