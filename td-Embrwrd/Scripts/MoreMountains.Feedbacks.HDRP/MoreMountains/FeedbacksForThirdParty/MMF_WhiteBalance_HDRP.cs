using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackHelp("This feedback allows you to control white balance temperature and tint over time. It requires you have in your scene an object with a Volume with WhiteBalance active, and a MMWhiteBalanceShaker_HDRP component.")]
	[AddComponentMenu(null)]
	public class MMF_WhiteBalance_HDRP : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		[MMFInspectorGroup("White Balance", true, 32, false, false)]
		[Tooltip("the duration of the shake, in seconds")]
		public float ShakeDuration;

		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeValues;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Tooltip("the curve used to animate the temperature value on")]
		[MMFInspectorGroup("Temperature", true, 33, false, false)]
		public AnimationCurve ShakeTemperature;

		[Range(-100f, 100f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapTemperatureZero;

		[Range(-100f, 100f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapTemperatureOne;

		[MMFInspectorGroup("Tint", true, 34, false, false)]
		[Tooltip("the curve used to animate the tint value on")]
		public AnimationCurve ShakeTint;

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(-100f, 100f)]
		public float RemapTintZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(-100f, 100f)]
		public float RemapTintOne;

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
