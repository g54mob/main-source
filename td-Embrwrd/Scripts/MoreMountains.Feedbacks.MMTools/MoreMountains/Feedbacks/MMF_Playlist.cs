using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will let you pilot a MMPlaylist")]
	[FeedbackPath("Audio/MMPlaylist")]
	public class MMF_Playlist : MMF_Feedback
	{
		public enum Modes
		{
			Play = 0,
			PlayNext = 1,
			PlayPrevious = 2,
			Stop = 3,
			Pause = 4,
			PlaySongAt = 5,
			SetVolumeMultiplier = 6
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the action to call on the playlist")]
		[MMFInspectorGroup("MMPlaylist", true, 13, false, false)]
		public Modes Mode;

		[MMEnumCondition("Mode", new int[] { 5 })]
		[Tooltip("the index of the song to play")]
		public int SongIndex;

		[Tooltip("the volume multiplier to apply")]
		[MMEnumCondition("Mode", new int[] { 6 })]
		public float VolumeMultiplier;

		[Tooltip("whether to apply the volume multiplier instantly (true) or only when the next song starts playing (false)")]
		[MMEnumCondition("Mode", new int[] { 6 })]
		public bool ApplyVolumeMultiplierInstantly;

		protected Coroutine _coroutine;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
