using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackPath("Audio/MMSoundManager Sound Fade")]
	[FeedbackHelp("This feedback lets you trigger fades on a specific sound via the MMSoundManager. You will need a MMSoundManager in your scene for this to work.")]
	public class MMFeedbackMMSoundManagerSoundFade : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("MMSoundManager Sound Fade")]
		[Tooltip("the ID of the sound you want to fade. Has to match the ID you specified when playing the sound initially")]
		public int SoundID;

		[Tooltip("the duration of the fade, in seconds")]
		public float FadeDuration;

		[Tooltip("the volume towards which to fade")]
		[Range(0.0001f, 10f)]
		public float FinalVolume;

		[Tooltip("the tween to apply over the fade")]
		public MMTweenType FadeTween;

		protected AudioSource _targetAudioSource;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
