using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you trigger a blink on an MMBlink object.")]
	[AddComponentMenu(null)]
	[FeedbackPath("Renderer/MMBlink")]
	public class MMFeedbackBlink : MMFeedback
	{
		public enum BlinkModes
		{
			Toggle = 0,
			Start = 1,
			Stop = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the target object to blink")]
		[Header("Blink")]
		public MMBlink TargetBlink;

		[Tooltip("the selected mode for this feedback")]
		public BlinkModes BlinkMode;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
