using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback doesn't do anything by default, it's just meant as a comment, you can store text in it for future reference, maybe to remember how you setup a particular MMFeedbacks. Optionally it can also output that comment to the console on Play.")]
	[FeedbackPath("Debug/Comment")]
	public class MMF_DebugComment : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		[MMFInspectorGroup("Comment", true, 61, false, false)]
		[Tooltip("the comment / note associated to this feedback")]
		[TextArea(10, 30)]
		public string Comment;

		[Tooltip("if this is true, the comment will be output to the console on Play")]
		public bool LogComment;

		[MMCondition("LogComment", true)]
		[Tooltip("the color of the message when in DebugLogTime mode")]
		public Color DebugColor;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
