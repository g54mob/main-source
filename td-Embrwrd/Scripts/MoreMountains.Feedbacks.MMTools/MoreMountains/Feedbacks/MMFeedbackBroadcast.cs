using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("GameObject/Broadcast")]
	[FeedbackHelp("This feedback lets you broadcast a float value to the MMRadio system.")]
	[AddComponentMenu(null)]
	public class MMFeedbackBroadcast : MMFeedbackBase
	{
		[Tooltip("the channel to write the level to")]
		[Header("Target Channel")]
		public int Channel;

		[Header("Level")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the curve to tween the intensity on")]
		public MMTweenType Curve;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the intensity curve's 0 to")]
		public float RemapZero;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the intensity curve's 1 to")]
		public float RemapOne;

		[Tooltip("the value to move the intensity to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantChange;

		[Tooltip("a debug view of the current level being broadcasted")]
		[MMReadOnly]
		public float DebugLevel;

		[MMReadOnly]
		[Tooltip("whether or not a broadcast is in progress (will be false while the value is not changing, and thus not broadcasting)")]
		public bool BroadcastInProgress;

		protected float _levelLastFrame;

		public float ThisLevel { get; set; }

		protected override void FillTargets()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void ProcessBroadcast()
		{
		}
	}
}
