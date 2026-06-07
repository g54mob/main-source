using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("A feedback used to pilot Vector2 springs")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Springs/Spring Vector2")]
	public class MMF_SpringVector2 : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Spring", true, 72, false, false)]
		[Tooltip("the Vector2 spring we want to pilot using this feedback. If you set one, only that spring will be targeted. If you don't, an event will be sent out to all springs matching the channel data info")]
		public MMSpringComponentBase TargetSpring;

		[Tooltip("the duration for the player to consider. This won't impact your particle system, but is a way to communicate to the MMF Player the duration of this feedback. Usually you'll want it to match your actual particle system, and setting it can be useful to have this feedback work with holding pauses.")]
		public float DeclaredDuration;

		[Tooltip("the command to use on that spring")]
		public SpringCommands Command = SpringCommands.Bump;

		[MMEnumCondition("Command", new int[] { 0, 1, 2, 4 })]
		[Tooltip("the new value this spring should move towards")]
		public Vector2 MoveToValue = new Vector2(2f, 2f);

		[Tooltip("the amount to add to the spring's current velocity to disturb it and make it bump")]
		[MMEnumCondition("Command", new int[] { 5 })]
		public Vector2 BumpAmount = new Vector2(75f, 75f);

		[Tooltip("the min values between which a random target x value will be picked when calling MoveToRandom")]
		[MMEnumCondition("Command", new int[] { 3 })]
		public Vector2 MoveToRandomValueMin = new Vector2(-2f, -2f);

		[Tooltip("the min (x) and max (y) values between which a random target y value will be picked when calling MoveToRandom")]
		[MMEnumCondition("Command", new int[] { 3 })]
		public Vector2 MoveToRandomValueMax = new Vector2(2f, 2f);

		[Tooltip("the min (x) and max (y) values between which a random bump x value will be picked when calling BumpRandom")]
		[MMEnumCondition("Command", new int[] { 6 })]
		public Vector2 BumpAmountRandomValueMin = new Vector2(-20f, -20f);

		[Tooltip("the min (x) and max (y) values between which a random bump y value will be picked when calling BumpRandom")]
		[MMEnumCondition("Command", new int[] { 6 })]
		public Vector2 BumpAmountRandomValueMax = new Vector2(20f, 20f);

		[Header("Overrides")]
		[Tooltip("whether or not to override the current Damping value of the target spring(s) with the one specified below (NewDamping)")]
		public bool OverrideDamping;

		[Tooltip("the new damping value to apply to the target spring(s) if OverrideDamping is true")]
		[MMFCondition("OverrideDamping", true)]
		public Vector2 NewDamping = new Vector2(0.8f, 0.8f);

		[Tooltip("whether or not to override the current Frequency value of the target spring(s) with the one specified below (NewFrequency)")]
		public bool OverrideFrequency;

		[Tooltip("the new frequency value to apply to the target spring(s) if OverrideFrequency is true")]
		[MMFCondition("OverrideFrequency", true)]
		public Vector2 NewFrequency = new Vector2(5f, 5f);

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
				MMSpringVector2Event.Trigger(Command, TargetSpring, _eventChannelData, MoveToValue, BumpAmount, MoveToRandomValueMin, MoveToRandomValueMax, BumpAmountRandomValueMin, BumpAmountRandomValueMax, OverrideDamping, NewDamping, OverrideFrequency, NewFrequency);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				_eventChannelData = ((TargetSpring == null) ? ChannelData : null);
				MMSpringVector2Event.Trigger(SpringCommands.Stop, TargetSpring, _eventChannelData);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				_eventChannelData = ((TargetSpring == null) ? ChannelData : null);
				MMSpringVector2Event.Trigger(SpringCommands.RestoreInitialValue, TargetSpring, _eventChannelData);
			}
		}
	}
}
