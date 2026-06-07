using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will let you change the text of a target TMP text component")]
	[FeedbackPath("TextMesh Pro/TMP Text")]
	public class MMFeedbackTMPText : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the target TMP_Text component we want to change the text on")]
		[Header("TextMesh Pro")]
		public TMP_Text TargetTMPText;

		[TextArea]
		[Tooltip("the new text to replace the old one with")]
		public string NewText;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
