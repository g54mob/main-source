using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Debug/Comment")]
	[FeedbackHelp("This feedback doesn't do anything by default, it's just meant as a comment, you can store text in it for future reference, maybe to remember how you setup a particular MMFeedbacks. Optionally it can also output that comment to the console on Play.")]
	[AddComponentMenu(null)]
	public class MMFeedbackDebugComment : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[TextArea(10, 30)]
		[Tooltip("the comment / note associated to this feedback")]
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
