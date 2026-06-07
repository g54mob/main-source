using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback will let you change the text of a target TMP text component")]
	[AddComponentMenu(null)]
	[FeedbackPath("TextMesh Pro/TMP Text")]
	public class MMF_TMPText : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the target TMP_Text component we want to change the text on")]
		[MMFInspectorGroup("TextMeshPro Change Text", true, 12, true, false)]
		public TMP_Text TargetTMPText;

		[Tooltip("the new text to replace the old one with")]
		[TextArea]
		public string NewText;

		protected string _initialText;

		public override bool HasAutomatedTargetAcquisition => false;

		protected override void AutomateTargetAcquisition()
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomRestoreInitialValues()
		{
		}
	}
}
