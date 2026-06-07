using UnityEngine;
using UnityEngine.Events;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback allows you to bind any type of Unity events to this feebdack's Play, Stop, Initialization and Reset methods.")]
	[FeedbackPath("Events/Events")]
	public class MMFeedbackEvents : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Events")]
		[Tooltip("the events to trigger when the feedback is played")]
		public UnityEvent PlayEvents;

		[Tooltip("the events to trigger when the feedback is stopped")]
		public UnityEvent StopEvents;

		[Tooltip("the events to trigger when the feedback is initialized")]
		public UnityEvent InitializationEvents;

		[Tooltip("the events to trigger when the feedback is reset")]
		public UnityEvent ResetEvents;

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomReset()
		{
		}
	}
}
