using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will let you trigger save, load, and reset on MMSoundManager settings. You will need a MMSoundManager in your scene for this to work.")]
	[FeedbackPath("Audio/MMSoundManager Save and Load")]
	public class MMFeedbackMMSoundManagerSaveLoad : MMFeedback
	{
		public enum Modes
		{
			Save = 0,
			Load = 1,
			Reset = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the selected mode to interact with save settings on the MMSoundManager")]
		[Header("MMSoundManager Save and Load")]
		public Modes Mode;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
