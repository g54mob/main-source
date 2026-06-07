using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback will let you turn the BlocksRaycast parameter of a target CanvasGroup on or off on play")]
	[FeedbackPath("UI/CanvasGroup BlocksRaycasts")]
	public class MMFeedbackCanvasGroupBlocksRaycasts : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Canvas Group")]
		[Tooltip("the target canvas group we want to control the BlocksRaycasts parameter on")]
		public CanvasGroup TargetCanvasGroup;

		[Tooltip("if this is true, on play, the target canvas group will block raycasts, if false it won't")]
		public bool ShouldBlockRaycasts;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
