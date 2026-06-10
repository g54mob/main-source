using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("A feedback used to pilot color springs")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Springs/Spring Color")]
	public class MMF_SpringColor : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Spring", true, 72, false, false)]
		[Tooltip("the Color spring we want to pilot using this feedback. If you set one, only that spring will be targeted. If you don't, an event will be sent out to all springs matching the channel data info")]
		public MMSpringComponentBase TargetSpring;

		[Tooltip("the duration for the player to consider. This won't impact your particle system, but is a way to communicate to the MMF Player the duration of this feedback. Usually you'll want it to match your actual particle system, and setting it can be useful to have this feedback work with holding pauses.")]
		public float DeclaredDuration;

		[Tooltip("the command to use on that spring")]
		public SpringCommands Command = SpringCommands.Bump;

		[MMEnumCondition("Command", new int[] { 0, 1, 2, 4 })]
		[Tooltip("the new color this spring should move towards")]
		public Color MoveToColor = MMColors.Aquamarine;

		[Tooltip("the color to add to the spring's current velocity to disturb it and make it bump")]
		[MMEnumCondition("Command", new int[] { 5 })]
		public Color BumpColor = MMColors.Orange;

		[Tooltip("the min color from which to pick a random color in MoveToRandom mode")]
		[MMEnumCondition("Command", new int[] { 3 })]
		public Color MoveToRandomColorMin = MMColors.LawnGreen;

		[Tooltip("the max color from which to pick a random color in MoveToRandom mode")]
		[MMEnumCondition("Command", new int[] { 3 })]
		public Color MoveToRandomColorMax = MMColors.MediumSeaGreen;

		[Tooltip("the min color from which to pick a random color in BumpRandom mode")]
		[MMEnumCondition("Command", new int[] { 6 })]
		public Color BumpRandomColorMin = MMColors.HotPink;

		[Tooltip("the max color from which to pick a random color in BumpRandom mode")]
		[MMEnumCondition("Command", new int[] { 6 })]
		public Color BumpRandomColorMax = MMColors.Plum;

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
				MMSpringColorEvent.Trigger(Command, TargetSpring, _eventChannelData, MoveToColor, BumpColor, MoveToRandomColorMin, MoveToRandomColorMax, BumpRandomColorMin, BumpRandomColorMax, OverrideDamping, NewDamping, OverrideFrequency, NewFrequency);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				_eventChannelData = ((TargetSpring == null) ? ChannelData : null);
				MMSpringColorEvent.Trigger(SpringCommands.Stop, TargetSpring, _eventChannelData);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				_eventChannelData = ((TargetSpring == null) ? ChannelData : null);
				MMSpringColorEvent.Trigger(SpringCommands.RestoreInitialValue, TargetSpring, _eventChannelData);
			}
		}
	}
}
