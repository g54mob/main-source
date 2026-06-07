using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback allows you to trigger a target MMFeedbacks, or any MMFeedbacks on the specified Channel within a certain range. You'll need an MMFeedbacksShaker on them.")]
	[AddComponentMenu(null)]
	[FeedbackPath("Feedbacks/Feedbacks Player")]
	public class MMF_Feedbacks : MMF_Feedback
	{
		public enum Modes
		{
			PlayFeedbacksInArea = 0,
			PlayTargetFeedbacks = 1
		}

		public static bool FeedbackTypeAuthorized;

		[MMFInspectorGroup("Feedbacks", true, 79, false, false)]
		[Tooltip("the selected mode for this feedback")]
		public Modes Mode;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("a specific MMFeedbacks / MMF_Player to play")]
		public MMFeedbacks TargetFeedbacks;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("whether or not to use a range")]
		public bool OnlyTriggerPlayersInRange;

		[Tooltip("the range of the event, in units")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float EventRange;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the transform to use to broadcast the event as origin point")]
		public Transform EventOriginTransform;

		public override float FeedbackDuration => 0f;

		public override bool HasChannel => false;

		protected override void CustomInitialization(MMF_Player owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
