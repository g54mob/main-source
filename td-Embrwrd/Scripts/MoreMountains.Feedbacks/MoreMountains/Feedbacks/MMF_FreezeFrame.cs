using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Time/Freeze Frame")]
	[FeedbackHelp("This feedback will freeze the timescale for the specified duration (in seconds). I usually go with 0.01s or 0.02s, but feel free to tweak it to your liking. It requires a MMTimeManager in your scene to work.")]
	[AddComponentMenu(null)]
	public class MMF_FreezeFrame : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		[MMFInspectorGroup("Freeze Frame", true, 63, false, false)]
		[Tooltip("the duration of the freeze frame")]
		public float FreezeFrameDuration;

		[Tooltip("the minimum value the timescale should be at for this freeze frame to happen. This can be useful to avoid triggering freeze frames when the timescale is already frozen.")]
		public float MinimumTimescaleThreshold;

		public override float FeedbackDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
