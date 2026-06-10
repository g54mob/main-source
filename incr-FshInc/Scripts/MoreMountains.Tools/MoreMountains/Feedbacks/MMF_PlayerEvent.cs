using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	public struct MMF_PlayerEvent
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
			ChangeDirection = 9,
			SetDirectionTopToBottom = 10,
			SetDirectionBottomToTop = 11,
			RestoreInitialValues = 12,
			SkipToTheEnd = 13,
			RefreshCache = 14
		}

		private static MMF_PlayerEvent e;

		public MMChannelData ChannelData;

		public bool UsePosition;

		public Vector3 Position;

		public Modes Mode;

		public float FeedbacksIntensity;

		public bool ForceChangeDirection;

		public static void Trigger(MMChannelData channelData, bool usePosition, Vector3 position, Modes mode = Modes.PlayFeedbacks, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			e.ChannelData = channelData;
			e.UsePosition = usePosition;
			e.Position = position;
			e.Mode = mode;
			e.FeedbacksIntensity = feedbacksIntensity;
			e.ForceChangeDirection = forceChangeDirection;
			MMEventManager.TriggerEvent(e);
		}
	}
}
