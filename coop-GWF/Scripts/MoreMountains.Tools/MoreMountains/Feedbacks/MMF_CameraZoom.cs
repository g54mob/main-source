using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("Define zoom properties : For will set the zoom to the specified parameters for a certain duration, Set will leave them like that forever. Zoom properties include the field of view, the duration of the zoom transition (in seconds) and the zoom duration (the time the camera should remain zoomed in, in seconds). For this to work, you'll need to add a MMCameraZoom component to your Camera, or a MMCinemachineZoom if you're using virtual cameras.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Camera/Camera Zoom")]
	public class MMF_CameraZoom : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Camera Zoom", true, 72, false, false)]
		[Tooltip("the zoom mode (for : forward for TransitionDuration, static for Duration, backwards for TransitionDuration)")]
		public MMCameraZoomModes ZoomMode;

		[Tooltip("the target field of view")]
		public float ZoomFieldOfView = 30f;

		[Tooltip("the zoom transition duration")]
		public float ZoomTransitionDuration = 0.05f;

		[Tooltip("the duration for which the zoom is at max zoom")]
		public float ZoomDuration = 0.1f;

		[Tooltip("whether or not ZoomFieldOfView should add itself to the current camera's field of view value")]
		public bool RelativeFieldOfView;

		[Header("Transition Speed")]
		[Tooltip("the animation curve to apply to the zoom transition")]
		public MMTweenType ZoomTween = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)));

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(ZoomDuration);
			}
			set
			{
				ZoomDuration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool CanForceInitialValue => true;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				MMCameraZoomEvent.Trigger(ZoomMode, ZoomFieldOfView, ZoomTransitionDuration, FeedbackDuration, ChannelData, ComputedTimescaleMode == TimescaleModes.Unscaled, stop: false, RelativeFieldOfView, restore: false, ZoomTween);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				MMCameraZoomEvent.Trigger(ZoomMode, ZoomFieldOfView, ZoomTransitionDuration, FeedbackDuration, ChannelData, ComputedTimescaleMode == TimescaleModes.Unscaled, stop: true, relative: false, restore: false, ZoomTween);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				MMCameraZoomEvent.Trigger(ZoomMode, ZoomFieldOfView, ZoomTransitionDuration, FeedbackDuration, ChannelData, ComputedTimescaleMode == TimescaleModes.Unscaled, stop: false, relative: false, restore: true, ZoomTween);
			}
		}

		public override void AutomaticShakerSetup()
		{
			if (false)
			{
				MMCinemachineHelpers.AutomaticCinemachineShakersSetup(Owner, "CinemachineImpulse");
			}
			else if (!((MMCameraZoom)Object.FindFirstObjectByType(typeof(MMCameraZoom)) != null))
			{
				Camera.main.gameObject.MMGetOrAddComponent<MMCameraZoom>();
				MMDebug.DebugLogInfo("Added a MMCameraZoom to the main camera. You're all set.");
			}
		}
	}
}
