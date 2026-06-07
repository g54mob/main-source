using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("Define zoom properties : For will set the zoom to the specified parameters for a certain duration, Set will leave them like that forever. Zoom properties include the field of view, the duration of the zoom transition (in seconds) and the zoom duration (the time the camera should remain zoomed in, in seconds). For this to work, you'll need to add a MMCameraZoom component to your Camera, or a MMCinemachineZoom if you're using virtual cameras.")]
	[AddComponentMenu(null)]
	[FeedbackPath("Camera/Camera Zoom")]
	public class MMFeedbackCameraZoom : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the channel to broadcast that zoom event on")]
		[Header("Camera Zoom")]
		public int Channel;

		[Tooltip("the zoom mode (for : forward for TransitionDuration, static for Duration, backwards for TransitionDuration)")]
		public MMCameraZoomModes ZoomMode;

		[Tooltip("the target field of view")]
		public float ZoomFieldOfView;

		[Tooltip("the zoom transition duration")]
		public float ZoomTransitionDuration;

		[Tooltip("the duration for which the zoom is at max zoom")]
		public float ZoomDuration;

		[Tooltip("whether or not ZoomFieldOfView should add itself to the current camera's field of view value")]
		public bool RelativeFieldOfView;

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
