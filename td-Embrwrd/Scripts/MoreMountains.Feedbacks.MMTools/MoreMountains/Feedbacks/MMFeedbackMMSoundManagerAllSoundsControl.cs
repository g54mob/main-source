using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackPath("Audio/MMSoundManager All Sounds Control")]
	[FeedbackHelp("A feedback used to control all sounds playing on the MMSoundManager at once. It'll let you pause, play, stop and free (stop and returns the audiosource to the pool) sounds. You will need a MMSoundManager in your scene for this to work.")]
	public class MMFeedbackMMSoundManagerAllSoundsControl : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("The selected control mode")]
		[Header("MMSoundManager All Sounds Control")]
		public MMSoundManagerAllSoundsControlEventTypes ControlMode;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
