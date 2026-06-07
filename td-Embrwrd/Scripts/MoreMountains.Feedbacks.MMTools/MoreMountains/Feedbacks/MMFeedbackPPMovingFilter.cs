using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("PostProcess/PPMovingFilter")]
	[FeedbackHelp("This feedback will trigger a post processing moving filter event, meant to be caught by a MMPostProcessingMovableFilter object")]
	[AddComponentMenu(null)]
	public class MMFeedbackPPMovingFilter : MMFeedback
	{
		public enum Modes
		{
			Toggle = 0,
			On = 1,
			Off = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the selected mode for this feedback")]
		[Header("PostProcessing Profile Moving Filter")]
		public Modes Mode;

		[Tooltip("the channel to target")]
		public int Channel;

		[Tooltip("the duration of the transition")]
		public float TransitionDuration;

		[Tooltip("the curve to move along to")]
		public MMTweenType Curve;

		protected bool _active;

		protected bool _toggle;

		public override float FeedbackDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
