using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackPath("Debug/Log")]
	[FeedbackHelp("This feedback will let you output a message to the console, using a custom MM debug method, or Log, Assertion, Error or Warning logs.")]
	public class MMFeedbackDebugLog : MMFeedback
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

		[Header("Debug")]
		[Tooltip("the selected debug mode")]
		public DebugLogModes DebugLogMode;

		[TextArea]
		[Tooltip("the message to display")]
		public string DebugMessage;

		[Tooltip("the color of the message when in DebugLogTime mode")]
		[MMFEnumCondition("DebugLogMode", new int[] { 0 })]
		public Color DebugColor;

		[Tooltip("whether or not to display the frame count when in DebugLogTime mode")]
		[MMFEnumCondition("DebugLogMode", new int[] { 0 })]
		public bool DisplayFrameCount;

		public override float FeedbackDuration => 0f;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
