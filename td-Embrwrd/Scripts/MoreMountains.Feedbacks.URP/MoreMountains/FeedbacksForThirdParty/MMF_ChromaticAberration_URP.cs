using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackPath("PostProcess/Chromatic Aberration URP")]
	[FeedbackHelp("This feedback allows you to control chromatic aberration intensity over time. It requires you have in your scene an object with a Volume with Chromatic Aberration active, and a MMChromaticAberrationShaker_URP component.")]
	[AddComponentMenu(null)]
	public class MMF_ChromaticAberration_URP : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the duration of the shake, in seconds")]
		[MMFInspectorGroup("Chromatic Aberration", true, 42, false, false)]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(0f, 1f)]
		public float RemapIntensityZero;

		[Range(0f, 1f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapIntensityOne;

		[Tooltip("the curve to animate the intensity on")]
		[MMFInspectorGroup("Intensity", true, 43, false, false)]
		public AnimationCurve Intensity;

		[Tooltip("the multiplier to apply to the intensity curve")]
		[Range(0f, 1f)]
		public float Amplitude;

		[Tooltip("whether or not to add to the initial intensity")]
		public bool RelativeIntensity;

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

		public override bool HasChannel => false;

		public override bool HasRandomness => false;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomRestoreInitialValues()
		{
		}
	}
}
