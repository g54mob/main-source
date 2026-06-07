using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackPath("Debug/Log")]
	[FeedbackHelp("This feedback will let you output a message to the console, using a custom MM debug method, or Log, Assertion, Error or Warning logs.")]
	[AddComponentMenu(null)]
	public class MMF_DebugLog : MMF_Feedback
	{
		public enum DebugLogModes
		{
			DebugLogTime = 0,
			Log = 1,
			Assertion = 2,
			Error = 3,
			Warning = 4
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the selected debug mode")]
		[MMFInspectorGroup("Debug", true, 17, false, false)]
		public DebugLogModes DebugLogMode;

		[Tooltip("the message to display")]
		[TextArea]
		public string DebugMessage;

		[Tooltip("the color of the message when in DebugLogTime mode")]
		[MMFEnumCondition("DebugLogMode", new int[] { 0 })]
		public Color DebugColor;

		[MMFEnumCondition("DebugLogMode", new int[] { 0 })]
		[Tooltip("whether or not to display the frame count when in DebugLogTime mode")]
		public bool DisplayFrameCount;

		public override float FeedbackDuration => 0f;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
