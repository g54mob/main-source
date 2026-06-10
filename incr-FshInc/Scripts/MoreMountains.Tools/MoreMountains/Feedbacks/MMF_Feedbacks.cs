using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback allows you to trigger a target MMF_Player, or any MMF_Player on the specified Channel within a certain range. You'll need an MMFeedbacksShaker on them.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Feedbacks/Feedbacks Player")]
	public class MMF_Feedbacks : MMF_Feedback
	{
		public enum Modes
		{
			PlayFeedbacksInArea = 0,
			PlayTargetFeedbacks = 1,
			TriggerMMF_PlayerEvent = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Feedbacks", true, 79, false, false)]
		[Tooltip("the selected mode for this feedback")]
		public Modes Mode;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("a specific MMFeedbacks / MMF_Player to play")]
		public MMFeedbacks TargetFeedbacks;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("whether or not to use a range")]
		public bool OnlyTriggerPlayersInRange;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the range of the event, in units")]
		public float EventRange = 100f;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the transform to use to broadcast the event as origin point")]
		public Transform EventOriginTransform;

		public override float FeedbackDuration
		{
			get
			{
				if (TargetFeedbacks == Owner)
				{
					return 0f;
				}
				if (Mode == Modes.PlayTargetFeedbacks && TargetFeedbacks != null)
				{
					return TargetFeedbacks.TotalDuration;
				}
				return 0f;
			}
		}

		public override bool HasChannel => true;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (EventOriginTransform == null)
			{
				EventOriginTransform = owner.transform;
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!(TargetFeedbacks == Owner) && Active && FeedbackTypeAuthorized)
			{
				if (Mode == Modes.PlayFeedbacksInArea)
				{
					MMFeedbacksShakeEvent.Trigger(ChannelData, OnlyTriggerPlayersInRange, EventRange, EventOriginTransform.position);
				}
				else if (Mode == Modes.PlayTargetFeedbacks)
				{
					TargetFeedbacks?.PlayFeedbacks(position, feedbacksIntensity);
				}
				else if (Mode == Modes.TriggerMMF_PlayerEvent)
				{
					MMF_PlayerEvent.Trigger(ChannelData, usePosition: true, Owner.transform.position, MMF_PlayerEvent.Modes.PlayFeedbacks, feedbacksIntensity);
				}
			}
		}
	}
}
