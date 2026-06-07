using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will allow you to play an audio oneshot on the Thronefall Sound Manager.")]
	[FeedbackPath("Thronefall/Audio Oneshot")]
	public class OneShotAudioTrigger : MMF_Feedback
	{
		[MMFInspectorGroup("Audio", true, 12, true, false)]
		[Tooltip("The oneshot you want to play.")]
		public ThronefallAudioManager.AudioOneShot oneshot;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			ThronefallAudioManager.Oneshot(oneshot);
		}
	}
}
