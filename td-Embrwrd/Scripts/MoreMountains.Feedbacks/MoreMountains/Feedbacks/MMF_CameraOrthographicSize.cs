using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control a camera's orthographic size over time. You'll need a MMCameraOrthographicSizeShaker on your camera.")]
	[AddComponentMenu(null)]
	[FeedbackPath("Camera/Orthographic Size")]
	public class MMF_CameraOrthographicSize : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the duration of the shake, in seconds")]
		[MMFInspectorGroup("Orthographic Size", true, 41, false, false)]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeOrthographicSize;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeOrthographicSize;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapOrthographicSizeZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapOrthographicSizeOne;

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
