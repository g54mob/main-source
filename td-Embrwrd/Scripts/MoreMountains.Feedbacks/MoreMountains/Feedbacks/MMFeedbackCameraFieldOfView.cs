using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control a camera's field of view over time. You'll need a MMCameraFieldOfViewShaker on your camera.")]
	[FeedbackPath("Camera/Field of View")]
	[AddComponentMenu(null)]
	public class MMFeedbackCameraFieldOfView : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the channel to emit on")]
		[Header("Field of View Feedback")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Tooltip("whether or not to add to the initial value")]
		[Header("Field of View")]
		public bool RelativeFieldOfView;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeFieldOfView;

		[Range(0f, 179f)]
		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapFieldOfViewZero;

		[Range(0f, 179f)]
		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapFieldOfViewOne;

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
