using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback will let you control the RaycastTarget parameter of a target image, turning it on or off on play")]
	[FeedbackPath("UI/Image RaycastTarget")]
	[AddComponentMenu(null)]
	public class MMFeedbackImageRaycastTarget : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Image")]
		[Tooltip("the target Image we want to control the RaycastTarget parameter on")]
		public Image TargetImage;

		[Tooltip("if this is true, when played, the target image will become a raycast target")]
		public bool ShouldBeRaycastTarget;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
