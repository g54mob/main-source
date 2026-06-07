using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Feedbacks/MMF Player Control")]
	[FeedbackHelp("This feedback allows you to control one or more target MMF Players")]
	[AddComponentMenu(null)]
	public class MMF_PlayerControl : MMF_Feedback
	{
		public enum Modes
		{
			PlayFeedbacks = 0,
			StopFeedbacks = 1,
			PauseFeedbacks = 2,
			ResumeFeedbacks = 3,
			Initialization = 4,
			PlayFeedbacksInReverse = 5,
			PlayFeedbacksOnlyIfReversed = 6,
			PlayFeedbacksOnlyIfNormalDirection = 7,
			ResetFeedbacks = 8,
			Revert = 9,
			SetDirectionTopToBottom = 10,
			SetDirectionBottomToTop = 11,
			RestoreInitialValues = 12,
			SkipToTheEnd = 13,
			RefreshCache = 14
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("a specific MMFeedbacks / MMF_Player to play")]
		[MMFInspectorGroup("MMF Player", true, 79, false, false)]
		public List<MMF_Player> TargetPlayers;

		public Modes Mode;

		public override bool HasChannel => false;

		protected override void CustomInitialization(MMF_Player owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
