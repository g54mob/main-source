using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback will let you pilot a MMPlaylist")]
	[AddComponentMenu(null)]
	[FeedbackPath("Audio/MMPlaylist")]
	public class MMFeedbackPlaylist : MMFeedback
	{
		public enum Modes
		{
			Play = 0,
			PlayNext = 1,
			PlayPrevious = 2,
			Stop = 3,
			Pause = 4,
			PlaySongAt = 5
		}

		public static bool FeedbackTypeAuthorized;

		[Header("MMPlaylist")]
		[Tooltip("the channel of the target MMPlaylist")]
		public int Channel;

		[Tooltip("the action to call on the playlist")]
		public Modes Mode;

		[Tooltip("the index of the song to play")]
		[MMEnumCondition("Mode", new int[] { 5 })]
		public int SongIndex;

		protected Coroutine _coroutine;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
