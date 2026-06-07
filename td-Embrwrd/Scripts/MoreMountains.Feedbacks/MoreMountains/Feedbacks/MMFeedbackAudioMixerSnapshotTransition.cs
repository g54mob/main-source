using UnityEngine;
using UnityEngine.Audio;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Audio/AudioMixer Snapshot Transition")]
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will let you transition to a target AudioMixer Snapshot over a specified time")]
	public class MMFeedbackAudioMixerSnapshotTransition : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the target audio mixer snapshot we want to transition to")]
		[Header("AudioMixer Snapshot")]
		public AudioMixerSnapshot TargetSnapshot;

		[Tooltip("the audio mixer snapshot we want to transition from, optional, only needed if you plan to play this feedback in reverse")]
		public AudioMixerSnapshot OriginalSnapshot;

		[Tooltip("the duration, in seconds, over which to transition to the selected snapshot")]
		public float TransitionDuration;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
