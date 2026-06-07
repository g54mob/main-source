using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("A feedback used to pilot float springs")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Springs/Spring Float")]
	public class MMF_SpringFloat : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Spring", true, 72, false, false)]
		[Tooltip("the spring we want to pilot using this feedback. If you set one, only that spring will be targeted. If you don't, an event will be sent out to all springs matching the channel data info")]
		public MMSpringComponentBase TargetSpring;

		[Tooltip("the duration for the player to consider. This won't impact your particle system, but is a way to communicate to the MMF Player the duration of this feedback. Usually you'll want it to match your actual particle system, and setting it can be useful to have this feedback work with holding pauses.")]
		public float DeclaredDuration;

		[Tooltip("the command to use on that spring")]
		public SpringCommands Command = SpringCommands.Bump;

		[MMEnumCondition("Command", new int[] { 0, 1, 2, 4 })]
		[Tooltip("the new value this spring should move towards")]
		public float MoveToValue = 2f;

		[Tooltip("the amount to add to the spring's current velocity to disturb it and make it bump")]
		[MMEnumCondition("Command", new int[] { 5 })]
		public float BumpAmount = 75f;

		[Tooltip("a min and max values to pick a random value from to move the spring to when MoveToRandom is called")]
		[MMEnumCondition("Command", new int[] { 3 })]
		public Vector2 MoveToRandomValue = new Vector2(-2f, 2f);

		[Tooltip("a min and max values to pick a random value from to add to the spring's velocity when BumpRandom is called")]
		[MMEnumCondition("Command", new int[] { 6 })]
		public Vector2 BumpAmountRandomValue = new Vector2(-50f, 50f);

		[Header("Overrides")]
		[Tooltip("whether or not to override the current Damping value of the target spring(s) with the one specified below (NewDamping)")]
		public bool OverrideDamping;

		[Tooltip("the new damping value to apply to the target spring(s) if OverrideDamping is true")]
		[MMFCondition("OverrideDamping", true)]
		public float NewDamping = 0.8f;

		[Tooltip("whether or not to override the current Frequency value of the target spring(s) with the one specified below (NewFrequency)")]
		public bool OverrideFrequency;

		[Tooltip("the new frequency value to apply to the target spring(s) if OverrideFrequency is true")]
		[MMFCondition("OverrideFrequency", true)]
		public float NewFrequency = 5f;

		protected MMChannelData _eventChannelData;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(DeclaredDuration);
			}
			set
			{
				DeclaredDuration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool CanForceInitialValue => true;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				_eventChannelData = ((TargetSpring == null) ? ChannelData : null);
				MMSpringFloatEvent.Trigger(Command, TargetSpring, _eventChannelData, MoveToValue, BumpAmount, MoveToRandomValue, BumpAmountRandomValue, OverrideDamping, NewDamping, OverrideFrequency, NewFrequency);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				_eventChannelData = ((TargetSpring == null) ? ChannelData : null);
				MMSpringFloatEvent.Trigger(SpringCommands.Stop, TargetSpring, _eventChannelData);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				_eventChannelData = ((TargetSpring == null) ? ChannelData : null);
				MMSpringFloatEvent.Trigger(SpringCommands.RestoreInitialValue, TargetSpring, _eventChannelData);
			}
		}
	}
}
