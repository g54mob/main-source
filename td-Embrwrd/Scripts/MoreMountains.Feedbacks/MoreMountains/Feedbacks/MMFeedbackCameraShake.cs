using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("Define camera shake properties (duration in seconds, amplitude and frequency), and this will broadcast a MMCameraShakeEvent with these same settings. You'll need to add a MMCameraShaker on your camera for this to work (or a MMCinemachineCameraShaker component on your virtual camera if you're using Cinemachine). Note that although this event and system was built for cameras in mind, you could technically use it to shake other objects as well.")]
	[AddComponentMenu(null)]
	[FeedbackPath("Camera/Camera Shake")]
	public class MMFeedbackCameraShake : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Camera Shake")]
		[Tooltip("whether or not this shake should repeat forever, until stopped")]
		public bool RepeatUntilStopped;

		[Tooltip("the channel to broadcast this shake on")]
		public int Channel;

		[Tooltip("the properties of the shake (duration, intensity, frequenc)")]
		public MMCameraShakeProperties CameraShakeProperties;

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
