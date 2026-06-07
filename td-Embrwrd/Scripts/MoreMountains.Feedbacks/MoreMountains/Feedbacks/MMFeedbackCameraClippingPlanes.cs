using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Camera/Clipping Planes")]
	[FeedbackHelp("This feedback lets you control a camera's clipping planes over time. You'll need a MMCameraClippingPlanesShaker on your camera.")]
	[AddComponentMenu(null)]
	public class MMFeedbackCameraClippingPlanes : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Clipping Planes Feedback")]
		[Tooltip("the channel to emit on")]
		public int Channel;

		[Tooltip("the duration of the shake, in seconds")]
		public float Duration;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake;

		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeClippingPlanes;

		[Tooltip("the curve used to animate the intensity value on")]
		[Header("Near Plane")]
		public AnimationCurve ShakeNear;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapNearZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapNearOne;

		[Tooltip("the curve used to animate the intensity value on")]
		[Header("Far Plane")]
		public AnimationCurve ShakeFar;

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapFarZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapFarOne;

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
