using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will let you control all sounds playing on a specific track (master, UI, music, sfx), and play, pause, mute, unmute, resume, stop, free them all at once. You will need a MMSoundManager in your scene for this to work.")]
	[FeedbackPath("Audio/MMSoundManager Track Control")]
	public class MMFeedbackMMSoundManagerTrackControl : MMFeedback
	{
		public enum ControlModes
		{
			Mute = 0,
			UnMute = 1,
			SetVolume = 2,
			Pause = 3,
			Play = 4,
			Stop = 5,
			Free = 6
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the track to mute/unmute/pause/play/stop/free/etc")]
		[Header("MMSoundManager Track Control")]
		public MMSoundManager.MMSoundManagerTracks Track;

		[Tooltip("the selected control mode to interact with the track. Free will stop all sounds and return them to the pool")]
		public ControlModes ControlMode;

		[Tooltip("if setting the volume, the volume to assign to the track")]
		[MMEnumCondition("ControlMode", new int[] { 2 })]
		public float Volume;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
