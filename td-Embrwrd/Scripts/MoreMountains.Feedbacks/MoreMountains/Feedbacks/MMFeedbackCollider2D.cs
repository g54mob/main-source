using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback will let you enable/disable/toggle a target collider 2D, or change its trigger status")]
	[FeedbackPath("GameObject/Collider2D")]
	[AddComponentMenu(null)]
	public class MMFeedbackCollider2D : MMFeedback
	{
		public enum Modes
		{
			Enable = 0,
			Disable = 1,
			ToggleActive = 2,
			Trigger = 3,
			NonTrigger = 4,
			ToggleTrigger = 5
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Collider")]
		[Tooltip("the collider to act upon")]
		public Collider2D TargetCollider2D;

		public Modes Mode;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void ApplyChanges(Modes mode)
		{
		}
	}
}
