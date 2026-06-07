using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback lets you control the contents of a target Text over time.")]
	[FeedbackPath("UI/Text")]
	[AddComponentMenu(null)]
	public class MMFeedbackText : MMFeedback
	{
		public enum ColorModes
		{
			Instant = 0,
			Gradient = 1,
			Interpolate = 2
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Target")]
		[Tooltip(" Text component to control")]
		public Text TargetText;

		[Tooltip("the new text to replace the old one with")]
		[TextArea]
		public string NewText;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
