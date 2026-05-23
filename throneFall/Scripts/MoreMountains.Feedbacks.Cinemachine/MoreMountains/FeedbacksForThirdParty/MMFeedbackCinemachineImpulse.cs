using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackPath("Camera/Cinemachine Impulse")]
	[FeedbackHelp("This feedback lets you trigger a Cinemachine Impulse event. You'll need a Cinemachine Impulse Listener on your camera for this to work.")]
	public class MMFeedbackCinemachineImpulse : MMFeedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[Header("Cinemachine Impulse")]
		[Tooltip("the velocity to apply to the impulse shake")]
		public Vector3 Velocity;

		[Tooltip("whether or not to clear impulses (stopping camera shakes) when the Stop method is called on that feedback")]
		public bool ClearImpulseOnStop;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active)
			{
				_ = FeedbackTypeAuthorized;
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && ClearImpulseOnStop)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
			}
		}
	}
}
