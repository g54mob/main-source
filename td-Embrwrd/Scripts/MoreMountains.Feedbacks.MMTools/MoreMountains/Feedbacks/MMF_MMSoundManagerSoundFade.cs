using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback lets you trigger fades on a specific sound via the MMSoundManager. You will need a MMSoundManager in your scene for this to work.")]
	[FeedbackPath("Audio/MMSoundManager Sound Fade")]
	public class MMF_MMSoundManagerSoundFade : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the ID of the sound you want to fade. Has to match the ID you specified when playing the sound initially")]
		[MMFInspectorGroup("MMSoundManager Sound Fade", true, 30, false, false)]
		public int SoundID;

		[Tooltip("the duration of the fade, in seconds")]
		public float FadeDuration;

		[Range(0.0001f, 10f)]
		[Tooltip("the volume towards which to fade")]
		public float FinalVolume;

		[Tooltip("the tween to apply over the fade")]
		public MMTweenType FadeTween;

		protected AudioSource _targetAudioSource;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
