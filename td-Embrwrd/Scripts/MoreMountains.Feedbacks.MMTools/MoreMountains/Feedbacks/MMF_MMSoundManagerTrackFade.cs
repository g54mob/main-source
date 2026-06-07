using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback will let you fade all the sounds on a specific track at once. You will need a MMSoundManager in your scene for this to work.")]
	[FeedbackPath("Audio/MMSoundManager Track Fade")]
	[AddComponentMenu(null)]
	public class MMF_MMSoundManagerTrackFade : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the track to fade the volume on")]
		[MMFInspectorGroup("MMSoundManager Track Fade", true, 30, false, false)]
		public MMSoundManager.MMSoundManagerTracks Track;

		[Tooltip("the duration of the fade, in seconds")]
		public float FadeDuration;

		[Range(0.0001f, 10f)]
		[Tooltip("the volume to reach at the end of the fade")]
		public float FinalVolume;

		[Tooltip("the tween to operate the fade on")]
		public MMTweenType FadeTween;

		public override float FeedbackDuration => 0f;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
