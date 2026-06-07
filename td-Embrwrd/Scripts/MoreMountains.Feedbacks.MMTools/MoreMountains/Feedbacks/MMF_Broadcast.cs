using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you broadcast a float value to the MMRadio system.")]
	[AddComponentMenu(null)]
	[FeedbackPath("GameObject/Broadcast")]
	public class MMF_Broadcast : MMF_FeedbackBase
	{
		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Header("Level")]
		[Tooltip("the curve to tween the intensity on")]
		public MMTweenType Curve;

		[Tooltip("the value to remap the intensity curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapZero;

		[MMFEnumCondition("Mode", new int[] { 0 })]
		[Tooltip("the value to remap the intensity curve's 1 to")]
		public float RemapOne;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("the value to move the intensity to in instant mode")]
		public float InstantChange;

		protected MMF_BroadcastProxy _proxy;

		public override bool HasChannel => false;

		protected override void CustomInitialization(MMF_Player owner)
		{
		}

		protected override void FillTargets()
		{
		}
	}
}
